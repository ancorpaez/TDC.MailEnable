Imports System
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports TDC.MailEnable.Core

Namespace Enrutador
    Public Class TCP
        Implements IDisposable

        Private BufferOrigen As BufferConexion
        Private BufferDestino As BufferConexion
        Private disposedValue As Boolean
        Private WithEvents Temporizador As Bucle.DoBucle
        Private WithEvents Enrutador As Bucle.DoBucle
        Private Actividad As Date
        Private EsperarSync As New ManualResetEvent(False)

        Public Origen As Socket
        Public Destino As Socket
        Public Cliente As IPEndPoint
        Public IpRuteada As New NetSH(Me)
        Public Event TimeLeft(Left As Integer, Cliente As TCP)
        Public Event AlCerrarConexion(Cliente As TCP)
        Public PuertoDestino As Integer = 0
        Private Function BuscarPuertoLibre() As Integer
            Dim Local As TcpListener = New TcpListener(IPAddress.Loopback, 0)
            Local.Start()
            Dim Puerto As Integer = CType(Local.LocalEndpoint, IPEndPoint).Port
            Local.Stop()
            Return Puerto
        End Function
        Public Sub New(ByRef SocketCliente As Socket, PuertoDestino As Integer)
            Try
                'Establecer el puerto del servidor
                Me.PuertoDestino = PuertoDestino

                'Establecer el Origen
                Me.Origen = SocketCliente

                'Almacenar Cliente
                Cliente = CType(SocketCliente.RemoteEndPoint, IPEndPoint)

                'Establecer Enrutamiento IP
                IpRuteada.RoutingAddress = CType(SocketCliente.RemoteEndPoint, IPEndPoint).Address.ToString()

                'Si está Preparada la Lista se Contrasta
                If Core.IpBaneadasEstado = EnumEstadoIpBan.Iniciada OrElse Core.IpBaneadasEstado = EnumEstadoIpBan.Actualizando Then
                    If Not IsNothing(Core.IpBaneadas) Then
                        If Core.IpBaneadas.Contains(IpRuteada.RoutingAddress) Then
                            'Es IP BANEADA
                            'No conectamos al Servidor y Cerramos inmediatamente.
                            Me.Dispose()
                            Exit Sub
                        End If
                    End If
                End If

                'Añadir enrutamiento IP
                IpRuteada.AddRoute()

                'Establecer Temporizador de Inactividad
                Application.OpenForms.Item("Main").Invoke(Sub() Temporizador = New Bucle.DoBucle($"Temporizador {Cliente.Address.ToString}", False))
                Temporizador.Intervalo = 1000
                Actividad = Now
                Temporizador.Iniciar()

                'Enrutar la Conexion
                Application.OpenForms.Item("Main").Invoke(Sub() Enrutador = New Bucle.DoBucle($"Enrutador {Cliente.Address.ToString}", False))
                Enrutador.Intervalo = 150
                Enrutador.Iniciar()

                'Esperar al enrutamiento
                EsperarSync.WaitOne()

            Catch ex As Exception
                Me.Dispose()
            End Try
        End Sub
        Private Sub AlRecibirDatosDelOrigen(Resultado As IAsyncResult)
            Try
                Dim Conexion As BufferConexion = CType(Resultado.AsyncState, BufferConexion)
                Dim LeerBytes = Conexion.SocketOrigen.EndReceive(Resultado)
                If LeerBytes > 0 Then
                    Conexion.SocketDestino.Send(Conexion.Buffer, LeerBytes, SocketFlags.None)
                    Conexion.SocketOrigen.BeginReceive(Conexion.Buffer, 0, Conexion.Buffer.Length, 0, AddressOf AlRecibirDatosDelOrigen, Conexion)
                End If
                Actividad = Now
            Catch ex As Exception
                Me.Dispose()
            End Try
        End Sub
        Private Sub AlRecibirDatosDelDestino(Resultado As IAsyncResult)
            Try
                If Not Temporizador.Cancelar Then
                    Actividad = Now
                    Dim Conexion As BufferConexion = CType(Resultado.AsyncState, BufferConexion)
                    Dim LeerBytes = Conexion.SocketOrigen.EndReceive(Resultado)
                    If LeerBytes > 0 Then
                        Conexion.SocketDestino.Send(Conexion.Buffer, LeerBytes, SocketFlags.None)
                        Conexion.SocketOrigen.BeginReceive(Conexion.Buffer, 0, Conexion.Buffer.Length, 0, AddressOf AlRecibirDatosDelDestino, Conexion)
                    End If
                End If
            Catch ex As Exception
                Me.Dispose()
            End Try
        End Sub

        Private Sub Temporizador_Background(Sender As Object, ByRef Detener As Boolean) Handles Temporizador.Background
            If DateDiff(DateInterval.Second, Actividad, Now) > 3600 Then
                'If DateDiff(DateInterval.Second, Actividad, Now) > 3600 Then
                'Me.Dispose()
                Detener = True
            End If
        End Sub
        Private Sub Temporizador_Foreground(Sender As Object, ByRef Detener As Boolean) Handles Temporizador.Foreground
            RaiseEvent TimeLeft(3600 - DateDiff(DateInterval.Second, Actividad, Now), Me)
        End Sub
        Private Sub Temporizador_Endground(Sender As Object, ByRef Detener As Boolean) Handles Temporizador.Endground
            Me.Dispose()
        End Sub
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: eliminar el estado administrado (objetos administrados)

                    Try
                        'Detener Bucles
                        If Not IsNothing(Temporizador) Then
                            Temporizador.Detener()
                            Temporizador.Matar()
                        End If
                        If Not IsNothing(Enrutador) Then
                            Enrutador.Detener()
                            Enrutador.Matar()
                        End If


                        'Avisar de desconexion
                        RaiseEvent AlCerrarConexion(Me)

                        'Eliminar enrutamiento
                        IpRuteada.DeleteRoute()

                        'Liberar recursos
                        If Not IsNothing(Origen) AndAlso Origen.Connected Then
                            Origen.Close()
                            Origen.Dispose()
                            Origen = Nothing
                        End If
                    Catch ex As Exception
                        Stop
                    End Try
                    Try
                        If Not IsNothing(Destino) AndAlso Destino.Connected Then
                            Destino.Close()
                            Destino.Dispose()
                            Destino = Nothing
                        End If
                    Catch ex As Exception
                        Stop
                    End Try
                    BufferOrigen = Nothing
                    BufferDestino = Nothing
                End If

                ' TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                ' TODO: establecer los campos grandes como NULL
                disposedValue = True
            End If
        End Sub

        ' ' TODO: reemplazar el finalizador solo si "Dispose(disposing As Boolean)" tiene código para liberar los recursos no administrados
        ' Protected Overrides Sub Finalize()
        '     ' No cambie este código. Coloque el código de limpieza en el método "Dispose(disposing As Boolean)".
        '     Dispose(disposing:=False)
        '     MyBase.Finalize()
        ' End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            ' No cambie este código. Coloque el código de limpieza en el método "Dispose(disposing As Boolean)".
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub

        Dim ErrorHResultCount As Integer = 0
        Private Sub Enrutador_Background(Sender As Object, ByRef Detener As Boolean) Handles Enrutador.Background
            'Enrutar la conexion
            Try
                Me.Destino = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim NatSocket As New IPEndPoint(IPAddress.Parse(IpRuteada.RoutingAddress), BuscarPuertoLibre)
                Me.Destino.Bind(NatSocket)
                Me.Destino.Connect(IpRuteada.RoutingAddress, PuertoDestino)
                BufferOrigen = New BufferConexion(Me.Origen, Me.Destino)
                Me.Origen.BeginReceive(BufferOrigen.Buffer, 0, BufferOrigen.Buffer.Length, 0, AddressOf AlRecibirDatosDelOrigen, BufferOrigen)
                BufferDestino = New BufferConexion(Me.Destino, Me.Origen)
                Me.Destino.BeginReceive(BufferDestino.Buffer, 0, BufferDestino.Buffer.Length, 0, AddressOf AlRecibirDatosDelDestino, BufferDestino)

                'Deshabilitar el enrutador
                Enrutador.Detener()

                'Desbloquear el enrutamiento
                EsperarSync.Set()
            Catch ex As Exception
                Select Case ex.HResult
                    Case -2147467259
                        Console.WriteLine("Error controlado:")
                        ErrorHResultCount += 1
                        If ErrorHResultCount = 11 Then Me.Dispose()
                        System.Threading.Thread.Sleep(100)
                        IpRuteada.AddRoute()
                    Case Else
                        Me.Dispose()
                End Select

            End Try

        End Sub

    End Class
End Namespace