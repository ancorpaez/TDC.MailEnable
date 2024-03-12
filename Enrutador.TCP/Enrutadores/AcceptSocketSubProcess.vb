Imports System.ComponentModel
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Namespace Enrutadores
    Public Class AcceptSocketSubProcess
        Private WithEvents Proceso As BackgroundWorker
        Public Property Conexion As Socket
        Private Puerto As Integer
        Private Aceptado As Boolean = False
        Public Event ConexionAceptada(Aceptador As AcceptSocketSubProcess, Conexion As Socket)
        Public Event ConexionRechadaza(Aceptador As AcceptSocketSubProcess, Conexion As Socket)

        Public Sub New(Conexion As Socket, Puerto As Integer)
            Me.Conexion = Conexion
            Me.Puerto = Puerto
            Proceso = New BackgroundWorker
            Proceso.RunWorkerAsync()
        End Sub

        Private Sub Proceso_DoWork(sender As Object, e As DoWorkEventArgs) Handles Proceso.DoWork
            If Not Aceptado AndAlso Conexion IsNot Nothing Then If Not IpBanPipe.Contains(CType(Conexion.RemoteEndPoint, IPEndPoint).Address.ToString) Then Aceptado = True
        End Sub

        Private Sub Proceso_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Proceso.RunWorkerCompleted
            If Aceptado Then
                Add(Conexion, ObtenerIPv4Principal, Puerto)
                RaiseEvent ConexionAceptada(Me, Conexion)
            Else
                If Conexion IsNot Nothing Then RaiseEvent ConexionRechadaza(Me, Conexion)
                If Conexion IsNot Nothing AndAlso Conexion.Connected Then Conexion.Close()
            End If
        End Sub
        Private Function ObtenerIPv4Principal() As IPAddress
            Dim principalIPv4 As String = ""

            ' Obtener todas las interfaces de red
            Dim interfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()

            ' Filtrar las interfaces para encontrar la interfaz activa que es del tipo Ethernet o Wifi y tiene una dirección IPv4
            Dim principalInterface As NetworkInterface = interfaces.
                Where(Function(interf) interf.OperationalStatus = OperationalStatus.Up AndAlso (interf.NetworkInterfaceType = NetworkInterfaceType.Ethernet OrElse interf.NetworkInterfaceType = NetworkInterfaceType.Wireless80211) AndAlso
                interf.GetIPProperties().UnicastAddresses.Any(Function(addr) addr.Address.AddressFamily = Sockets.AddressFamily.InterNetwork)).
                FirstOrDefault()

            ' Si se encuentra la interfaz, obtener su dirección IPv4
            If principalInterface IsNot Nothing Then
                principalIPv4 = principalInterface.GetIPProperties().UnicastAddresses.
                    Where(Function(addr) addr.Address.AddressFamily = Sockets.AddressFamily.InterNetwork).
                    Select(Function(addr) addr.Address.ToString()).
                    FirstOrDefault()
            End If

            Return IPAddress.Parse(principalIPv4)
        End Function

        Protected Overrides Sub Finalize()
            Proceso.Dispose()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace