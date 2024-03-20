Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading.Tasks

Namespace CodeCowboy.NetworkRoute
    Public Class NicInterface

        Public Shared Function GetNetworkAdaptor(interfaceIndex As Integer) As NetworkAdaptor
            Dim na As NetworkAdaptor = Nothing
            Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            For Each adapter As NetworkInterface In nics
                Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
                If Not HasIp4Support(adapter) Then
                    Continue For
                End If
                Dim ip4Properties As IPv4InterfaceProperties = properties.GetIPv4Properties()
                If properties.GetIPv4Properties().Index = interfaceIndex Then
                    na = New NetworkAdaptor()
                    na.Name = adapter.Name
                    na.Description = adapter.Description
                    na.MACAddress = adapter.GetPhysicalAddress().ToString()
                    na.InterfaceIndex = ip4Properties.Index
                    na.PrimaryIpAddress = properties.UnicastAddresses.Where(Function(i) i.Address.AddressFamily = AddressFamily.InterNetwork)?.First()?.Address
                    na.SubnetMask = properties.UnicastAddresses.Where(Function(i) i.Address.AddressFamily = AddressFamily.InterNetwork)?.First()?.IPv4Mask
                    If properties.GatewayAddresses.Count > 0 Then
                        na.PrimaryGateway = Nothing
                        For Each gatewayInfo As GatewayIPAddressInformation In properties.GatewayAddresses
                            If gatewayInfo.Address IsNot Nothing AndAlso gatewayInfo.Address.AddressFamily = AddressFamily.InterNetwork Then
                                na.PrimaryGateway = gatewayInfo.Address
                                Exit For
                            End If
                        Next
                    Else
                        'if the gateways on the Network adaptor properties is null, then get it from the routing table, especially the case for VPN routers
                        Dim routeTable As List(Of Ip4RouteEntry) = Ip4RouteTable.GetRouteTable()
                        If routeTable.Where(Function(i) i.InterfaceIndex = na.InterfaceIndex)?.Count() > 0 Then
                            na.PrimaryGateway = routeTable.Where(Function(i) i.InterfaceIndex = na.InterfaceIndex)?.First()?.GatewayIP
                        End If
                    End If
                    'not ideal and incorrect, but hopefully it doesn't execute this as the gateways are defined elsewhere
                    'the correct way is to locate the primary gateway in some other property other than the 3 methods here
                    If na.PrimaryGateway Is Nothing AndAlso properties.DhcpServerAddresses.Count > 0 Then
                        na.PrimaryGateway = properties.DhcpServerAddresses.First()
                    End If
                    Exit For
                End If
            Next
            Return na
        End Function

        Public Shared Function GetAllNetworkAdaptor() As List(Of NetworkAdaptor)
            Dim naList As New List(Of NetworkAdaptor)()
            Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            For Each adapter As NetworkInterface In nics
                Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
                Dim ip4Properties As IPv4InterfaceProperties = Nothing
                If Not HasIp4Support(adapter) Then
                    Continue For
                Else
                    ip4Properties = properties.GetIPv4Properties()
                End If

                Dim na As New NetworkAdaptor()
                na.Name = adapter.Name
                na.Description = adapter.Description
                na.MACAddress = adapter.GetPhysicalAddress().ToString()
                na.InterfaceIndex = If(ip4Properties IsNot Nothing, ip4Properties.Index, 0)
                na.PrimaryIpAddress = properties.UnicastAddresses.Where(Function(i) i.Address.AddressFamily = AddressFamily.InterNetwork)?.First()?.Address
                na.SubnetMask = properties.UnicastAddresses.Where(Function(i) i.Address.AddressFamily = AddressFamily.InterNetwork)?.First()?.IPv4Mask
                If properties.GatewayAddresses.Count > 0 Then
                    na.PrimaryGateway = Nothing
                    For Each gatewayInfo As GatewayIPAddressInformation In properties.GatewayAddresses
                        If gatewayInfo.Address IsNot Nothing AndAlso gatewayInfo.Address.AddressFamily = AddressFamily.InterNetwork Then
                            na.PrimaryGateway = gatewayInfo.Address
                            Exit For
                        End If
                    Next
                Else
                    'if the gateways on the Network adaptor properties is null, then get it from the routing table
                    Dim routeTable As List(Of Ip4RouteEntry) = Ip4RouteTable.GetRouteTable()
                    If routeTable.Where(Function(i) i.InterfaceIndex = na.InterfaceIndex).Count() > 0 Then
                        na.PrimaryGateway = routeTable.Where(Function(i) i.InterfaceIndex = na.InterfaceIndex)?.First()?.GatewayIP
                    End If
                End If
                If na.PrimaryGateway Is Nothing AndAlso properties.DhcpServerAddresses.Count > 0 Then
                    na.PrimaryGateway = properties.DhcpServerAddresses.First()
                End If
                naList.Add(na)
            Next
            Return naList
        End Function

        Public Shared Sub PrintAllNetworkInterface()
            Dim naList As List(Of NetworkAdaptor) = NicInterface.GetAllNetworkAdaptor()
            Console.WriteLine("{0,18} {1,18} {2,18} {3,20} {4,6} {5}", "IP Address", "Subnet Mask", "Gateway", "MAC", "IF", "Name")
            For Each na As NetworkAdaptor In naList
                Console.WriteLine("{0,18} {1,18} {2,18} {3,20} {4,6} {5}", na.PrimaryIpAddress, na.SubnetMask, na.PrimaryGateway, na.MACAddress, na.InterfaceIndex, na.Name)
            Next
        End Sub

        Private Shared Function HasIp4Support(adapter As NetworkInterface) As Boolean
            Try
                adapter.GetIPProperties().GetIPv4Properties()
                Return True
            Catch
                Return False
            End Try
        End Function
    End Class

    Public Class NetworkAdaptor
        Public Property Name As String
        Public Property Description As String
        Public Property MACAddress As String
        Public Property InterfaceIndex As Integer
        Public Property PrimaryIpAddress As IPAddress
        Public Property SubnetMask As IPAddress
        Public Property PrimaryGateway As IPAddress
    End Class
End Namespace


