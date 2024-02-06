Imports System.Net.NetworkInformation

Namespace Routing
    Public Class NetSH
        Private StringCommandAdd As String = "interface ip add address ""ENRUTADOR"" 0.0.0.0"
        Private StringCommandDelete As String = "interface ip delete address ""ENRUTADOR"" 0.0.0.0"
        Private LaunchCommand As String = ""
        Private Cliente As Cliente
        Public Property RoutingAddress As String = "0.0.0.0"
        Public Sub New(Cliente As Cliente)
            Me.Cliente = Cliente
        End Sub
        Public Sub AddRoute()
            If Not IsIPInNetworkInterface(RoutingAddress, "ENRUTADOR") Then
                LaunchCommand = StringCommandAdd.Replace("0.0.0.0", RoutingAddress)
                LaunchCommandProcess()
                Do While Not IsIPInNetworkInterface(RoutingAddress, "ENRUTADOR")
                    Threading.Thread.Sleep(100)
                Loop
            End If
        End Sub
        Public Sub DeleteRoute()
            If IsIPInNetworkInterface(RoutingAddress, "ENRUTADOR") Then
                Dim esActivo As Boolean = False
                For Each Conexion In Conexiones.Keys
                    If Conexion.Split(":")(0) = RoutingAddress Then esActivo = True
                Next
                If Not esActivo Then
                    LaunchCommand = StringCommandDelete.Replace("0.0.0.0", RoutingAddress)
                    LaunchCommandProcess()
                End If
            End If
        End Sub
        Private Sub LaunchCommandProcess()
            Try
                Using Launch As New Process
                    With Launch
                        With .StartInfo
                            .FileName = "netsh"
                            .Verb = "runas"
                            .Arguments = LaunchCommand
                            .CreateNoWindow = True
                            .UseShellExecute = False
                        End With
                        .Start()
                        .WaitForExit()
                    End With
                End Using
            Catch ex As Exception
                Stop
            End Try
        End Sub

        Function IsIPInNetworkInterface(ipToCheck As String, interfaceName As String) As Boolean
            ' Obtiene todas las interfaces de red
            Dim interfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()

            ' Busca la interfaz de red específica por nombre
            Dim selectedInterface As NetworkInterface = interfaces.FirstOrDefault(Function(ni) ni.Name = interfaceName)

            ' Verifica si la interfaz de red existe
            If selectedInterface IsNot Nothing Then
                ' Obtiene las direcciones IP asociadas con la interfaz de red
                Dim ipProperties As IPInterfaceProperties = selectedInterface.GetIPProperties()
                Dim unicastIPs As UnicastIPAddressInformationCollection = ipProperties.UnicastAddresses

                ' Verifica si la IP está incluida en las direcciones IP de la interfaz de red
                If unicastIPs.Any(Function(ip) ip.Address.ToString() = ipToCheck) Then
                    Return True
                End If
            End If

            ' La IP no está incluida en la tarjeta de red especificada
            Return False
        End Function

    End Class
End Namespace