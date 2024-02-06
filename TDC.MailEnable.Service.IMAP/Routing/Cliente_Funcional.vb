Imports System
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Text
Imports TDC.MailEnable.Core

Namespace Routing
    Public Class Cliente
        Implements IDisposable

        Private BufferOrigen As BufferConexion
        Private BufferDestino As BufferConexion
        Private disposedValue As Boolean
        Private WithEvents Temporizador As New Bucle.Bucle
        Private Actividad As Date

        Public Origen As Socket
        Public Destino As Socket
        Public Cliente As IPEndPoint

        Public Event AlCerrarConexion(Cliente As Cliente)

        Private Function BuscarPuertoLibre() As Integer
            Dim Local As TcpListener = New TcpListener(IPAddress.Loopback, 0)
            Local.Start()
            Dim Puerto As Integer = CType(Local.LocalEndpoint, IPEndPoint).Port
            Local.Stop()
            Return Puerto
        End Function
        Public Sub New(ByRef SocketCliente As Socket, Destino As EndPoint)
            Try
                'Establecer el Origen
                Me.Origen = SocketCliente

                'Almacenar Cliente
                Cliente = CType(SocketCliente.RemoteEndPoint, IPEndPoint)

                'Comprobar la Lista Negra
                Dim clientIp As String = CType(SocketCliente.RemoteEndPoint, IPEndPoint).Address.ToString()

                'Si está Preparada la Lista se Contrasta
                If Core.IpBaneadasEstado = EnumEstadoIpBan.Iniciada OrElse Core.IpBaneadasEstado = EnumEstadoIpBan.Actualizando Then
                    If Not IsNothing(Core.IpBaneadas) Then
                        If Core.IpBaneadas.Contains(clientIp) Then
                            'Es IP BANEADA
                            'No conectamos al Servidor y Cerramos inmediatamente.
                            Me.Dispose()
                            Exit Sub
                        End If
                    End If
                End If

                'Establecer Temporizador de Inactividad
                Temporizador.Intervalo = 1000
                Actividad = Now
                Temporizador.Inicia()

                'Enrutar la Conexion
                'Me.Destino = New Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IPv4)
                Me.Destino = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                'Me.Destino.EndSend()
                'Me.Destino = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                'Dim NatSocket As New IPEndPoint(IPAddress.Parse(clientIp), BuscarPuertoLibre)
                'Me.Destino.SetIPProtectionLevel(IPProtectionLevel.Unrestricted)
                'Dim Prueba As New TcpClient(NatSocket)
                'Me.Destino.Bind(NatSocket)
                'Me.Destino.Connect(Destino)
                'Dim TarjetaDeRed As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces().First(Function(ni) ni.Name = "INTERNET")

                'Me.Destino.IOControl(IOControlCode.)
                Me.Destino.Connect(Destino)
                'SocketCliente.Bind(Me.Destino.LocalEndPoint)
                BufferOrigen = New BufferConexion(Me.Origen, Me.Destino)
                Me.Origen.BeginReceive(BufferOrigen.Buffer, 0, BufferOrigen.Buffer.Length, 0, AddressOf AlRecibirDatosDelOrigen, BufferOrigen)
                BufferDestino = New BufferConexion(Me.Destino, Me.Origen)
                Me.Destino.BeginReceive(BufferDestino.Buffer, 0, BufferDestino.Buffer.Length, 0, AddressOf AlRecibirDatosDelDestino, BufferDestino)

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
                Actividad = Now
                Dim Conexion As BufferConexion = CType(Resultado.AsyncState, BufferConexion)
                Dim LeerBytes = Conexion.SocketOrigen.EndReceive(Resultado)
                If LeerBytes > 0 Then
                    Conexion.SocketDestino.Send(Conexion.Buffer, LeerBytes, SocketFlags.None)
                    Conexion.SocketOrigen.BeginReceive(Conexion.Buffer, 0, Conexion.Buffer.Length, 0, AddressOf AlRecibirDatosDelDestino, Conexion)
                End If
            Catch ex As Exception
                Me.Dispose()
            End Try
        End Sub

        Private Sub Temporizador_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Temporizador.IBucle_Bucle
            If DateDiff(DateInterval.Second, Actividad, Now) > 3600 Then
                Me.Dispose()
            End If
        End Sub

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: eliminar el estado administrado (objetos administrados)
                    RaiseEvent AlCerrarConexion(Me)

                    Try
                        If Not IsNothing(Origen) AndAlso Origen.Connected Then
                            Origen.Close()
                            Origen.Dispose()
                            Origen = Nothing
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsNothing(Destino) AndAlso Destino.Connected Then
                            Destino.Close()
                            Destino.Dispose()
                            Destino = Nothing
                        End If
                    Catch ex As Exception
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

    End Class
End Namespace