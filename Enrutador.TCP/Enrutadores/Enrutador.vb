Imports System.Net
Imports System.Net.Sockets
Imports TDC.MailEnable.Core

Namespace Enrutadores
    Public Class Enrutador
        Public Conexion As Socket = Nothing
        Public Servidor As Socket = Nothing

        Private WithEvents Dispadaror As Bucle.DoBucle
        Private PuertoServidor As Integer
        Private IPENAT As IPEndPoint = New IPEndPoint(IPAddress.Any, 0)
        Public Property ENATAddress As IPEndPoint = New IPEndPoint(IPAddress.Any, 0)
        Private FalloENATAddress As IPAddress

        Private BufferConexion As BufferEnrutador
        Private BufferServidor As BufferEnrutador
        Private Activo As Date

        Private WithEvents Temporizador As Bucle.DoBucle
        Private TimeOut As Integer = 3600

        Private Enum EnumTipoRouting
            ESTABLECIENDO
            ENAT
            NORMAL
        End Enum
        Private TipoEnrutamiento As EnumTipoRouting = EnumTipoRouting.ESTABLECIENDO

        Public Property ConexionAceptada As Boolean = False

        Public Event Actividad(Activo As Integer, Enrutador As Enrutador)
        Public Event AlCerrarEnrutador(Enrutador As Enrutador)

        Public Sub New(Conexion As Socket, FalloENATAddress As IPAddress, PuertoServidor As Integer)
            Me.Conexion = Conexion
            Me.FalloENATAddress = FalloENATAddress
            Me.PuertoServidor = PuertoServidor
            Temporizador = New Bucle.DoBucle("Temporizador " & Conexion.RemoteEndPoint.ToString, False)
            Dispadaror = New Bucle.DoBucle("Dispadaror " & Conexion.RemoteEndPoint.ToString, False)
        End Sub

        Public Sub Iniciar()
            Dispadaror.Iniciar()
        End Sub
        Private Function EsRedClaseC(EnatIp As IPAddress) As Boolean
            Dim ipBytes As Byte() = EnatIp.GetAddressBytes()
            If ipBytes(0) >= 192 AndAlso ipBytes(0) <= 223 Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Sub Dispadaror_Background(Sender As Object, ByRef Detener As Boolean) Handles Dispadaror.Background
            Try
                'Establecer la ip a Simular
                If IPENAT.Port = 0 Then
                    IPENAT = CType(Conexion.RemoteEndPoint, IPEndPoint)
                End If
                If Not EsRedClaseC(IPENAT.Address) Then
                    If Not ENAT.Existe(IPENAT.Address.ToString) Then
                        If ENAT.Crear(IPENAT.Address.ToString) Then
                            TipoEnrutamiento = EnumTipoRouting.ENAT
                        Else
                            TipoEnrutamiento = EnumTipoRouting.NORMAL
                        End If
                    Else
                        TipoEnrutamiento = EnumTipoRouting.ENAT
                    End If
                Else
                    TipoEnrutamiento = EnumTipoRouting.NORMAL
                End If



                Select Case TipoEnrutamiento
                    Case EnumTipoRouting.ENAT
                        If Servidor Is Nothing Then
                            Servidor = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                            ENATAddress = New IPEndPoint(IPENAT.Address, BuscarPuertoLibre)
                            Servidor.Bind(ENATAddress)
                        End If
                        If Servidor IsNot Nothing AndAlso Not Servidor.Connected Then
                            Me.Servidor.Connect(IPENAT.Address, PuertoServidor)
                            BufferConexion = New BufferEnrutador(Me.Conexion, Me.Servidor)
                            Me.Conexion.BeginReceive(BufferConexion.Buffer, 0, BufferConexion.Buffer.Length, 0, AddressOf AlRecibirDatosDeLaConexion, BufferConexion)
                            BufferServidor = New BufferEnrutador(Me.Servidor, Me.Conexion)
                            Me.Servidor.BeginReceive(BufferServidor.Buffer, 0, BufferServidor.Buffer.Length, 0, AddressOf AlRecibirDatosDelServidor, BufferServidor)
                        End If

                    Case EnumTipoRouting.NORMAL
                        If Servidor Is Nothing Then
                            Servidor = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                            ENATAddress = New IPEndPoint(FalloENATAddress, BuscarPuertoLibre)
                            Servidor.Bind(ENATAddress)
                        End If
                        If Servidor IsNot Nothing AndAlso Not Servidor.Connected Then
                            Me.Servidor.Connect(FalloENATAddress, PuertoServidor)
                            BufferConexion = New BufferEnrutador(Me.Conexion, Me.Servidor)
                            Me.Conexion.BeginReceive(BufferConexion.Buffer, 0, BufferConexion.Buffer.Length, 0, AddressOf AlRecibirDatosDeLaConexion, BufferConexion)
                            BufferServidor = New BufferEnrutador(Me.Servidor, Me.Conexion)
                            Me.Servidor.BeginReceive(BufferServidor.Buffer, 0, BufferServidor.Buffer.Length, 0, AddressOf AlRecibirDatosDelServidor, BufferServidor)
                        End If
                End Select
                If Servidor IsNot Nothing AndAlso Servidor.Connected Then Dispadaror.Detener()
            Catch ex As Exception
                'Stop
            End Try
        End Sub
        Private Sub Dispadaror_Endground(Sender As Object, ByRef Detener As Boolean) Handles Dispadaror.Endground
            Dispadaror.Matar()
            Temporizador.Intervalo = 1000
            Temporizador.Iniciar()
        End Sub
        Private Sub AlRecibirDatosDeLaConexion(Resultado As IAsyncResult)
            Try
                If Temporizador IsNot Nothing AndAlso Not Temporizador.Cancelar Then
                    Activo = Now
                    Dim ENATBuffer As BufferEnrutador = CType(Resultado.AsyncState, BufferEnrutador)
                    Dim LeerBytes = ENATBuffer.SocketOrigen.EndReceive(Resultado)
                    If LeerBytes > 0 Then
                        ENATBuffer.SocketDestino.Send(ENATBuffer.Buffer, LeerBytes, SocketFlags.None)
                        ENATBuffer.SocketOrigen.BeginReceive(ENATBuffer.Buffer, 0, ENATBuffer.Buffer.Length, 0, AddressOf AlRecibirDatosDeLaConexion, ENATBuffer)
                    End If
                End If
            Catch ex As Exception
                Temporizador.Detener()
            End Try
        End Sub
        Private Sub AlRecibirDatosDelServidor(Resultado As IAsyncResult)
            Try
                If Temporizador IsNot Nothing AndAlso Not Temporizador.Cancelar Then
                    Activo = Now
                    Dim ENATBuffer As BufferEnrutador = CType(Resultado.AsyncState, BufferEnrutador)
                    Dim LeerBytes = ENATBuffer.SocketOrigen.EndReceive(Resultado)
                    If LeerBytes > 0 Then
                        ENATBuffer.SocketDestino.Send(ENATBuffer.Buffer, LeerBytes, SocketFlags.None)
                        ENATBuffer.SocketOrigen.BeginReceive(ENATBuffer.Buffer, 0, ENATBuffer.Buffer.Length, 0, AddressOf AlRecibirDatosDelServidor, ENATBuffer)
                    End If
                End If
            Catch ex As Exception
                Temporizador.Detener()
            End Try
        End Sub

        Private Sub Temporizador_Background(Sender As Object, ByRef Detener As Boolean) Handles Temporizador.Background
            If DateDiff(DateInterval.Second, Activo, Now) > TimeOut OrElse IpBanPipe.Contains(CType(Conexion.RemoteEndPoint, IPEndPoint).Address.ToString) Then
                Detener = True
            End If
        End Sub

        Private Sub Temporizador_Foreground(Sender As Object, ByRef Detener As Boolean) Handles Temporizador.Foreground
            RaiseEvent Actividad(TimeOut - DateDiff(DateInterval.Second, Activo, Now), Me)
            Console.WriteLine(TimeOut - DateDiff(DateInterval.Second, Activo, Now), Me)
        End Sub

        Private Sub Temporizador_Endground(Sender As Object, ByRef Detener As Boolean) Handles Temporizador.Endground
            'Te termino la conexión 
            RaiseEvent AlCerrarEnrutador(Me)
            Temporizador.Matar()
            Temporizador = Nothing
            If Servidor IsNot Nothing AndAlso Servidor.Connected Then Servidor.Close()
            If Conexion.Connected Then Conexion.Close()
        End Sub
    End Class
End Namespace