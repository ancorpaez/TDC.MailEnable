Imports System.Collections.Concurrent
Imports System.Net
Imports System.Net.Sockets

Namespace Enrutadores
    Module Core
        Private Enrutadores As New Concurrent.ConcurrentDictionary(Of String, Enrutador)
        Private ENATS As New ConcurrentDictionary(Of IPAddress, Integer)

        Private SyncPuerto As New Object
        Private SyncObtener As New Object

        Public Property InactiveTimeOut As Integer = 360
        Public ReadOnly Property MaximunRoutersPerIp As Integer = 30

        Public Function Add(Conexion As Socket, ServerAddress As IPAddress, Port As Integer) As Boolean
            Try
                If Enrutadores.TryAdd(Conexion.RemoteEndPoint.ToString, New Enrutador(Conexion, ServerAddress, Port)) Then
                    AddHandler Enrutadores(Conexion.RemoteEndPoint.ToString).AlCerrarEnrutador, AddressOf EliminarENAT
                    Enrutadores(Conexion.RemoteEndPoint.ToString).Iniciar()
                    Dim ENATIP As IPAddress = CType(Conexion.RemoteEndPoint, IPEndPoint).Address
                    If ENATS.ContainsKey(ENATIP) Then ENATS(ENATIP) += 1
                    If Not ENATS.ContainsKey(ENATIP) Then ENATS.TryAdd(ENATIP, 1)
                    Return True
                End If
                Return False
            Catch ex As Exception
                Return False
            End Try
            Return False
        End Function
        Public Function Obtener(Key As String) As Enrutador

            Return Enrutadores(Key)
        End Function
        Private Sub EliminarENAT(Enrutador As Enrutador)
            RemoveHandler Enrutadores(Enrutador.Conexion.RemoteEndPoint.ToString).AlCerrarEnrutador, AddressOf EliminarENAT
            Enrutadores.TryRemove(Enrutador.Conexion.RemoteEndPoint.ToString, Nothing)

            If Not Enrutador.ENATAddress.Address.ToString = IPAddress.Any.ToString Then
                Dim ENATIP As IPAddress = Enrutador.ENATAddress.Address
                If ENATS.ContainsKey(ENATIP) Then ENATS(ENATIP) -= 1
                If ENATS.ContainsKey(ENATIP) Then If ENATS(ENATIP) < 1 Then If Not ENAT.Eliminar(ENATIP.ToString) Then Stop
            End If
        End Sub

        Public Function ConcurrentENATS(Ip As IPAddress) As Integer
            Try
                If ENATS.ContainsKey(Ip) Then Return ENATS(Ip)
            Catch ex As Exception
                Return 0
            End Try
            Return 0
        End Function
        Friend Function BuscarPuertoLibre() As Integer
            SyncLock SyncPuerto
                Dim Local As TcpListener = New TcpListener(IPAddress.Loopback, 0)
                Local.Start()
                Dim Puerto As Integer = CType(Local.LocalEndpoint, IPEndPoint).Port
                Local.Stop()
                Return Puerto
            End SyncLock
        End Function
    End Module
End Namespace