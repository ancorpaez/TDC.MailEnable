Imports System.Net.NetworkInformation
Imports System.Runtime.InteropServices

Namespace RouteTable
    Public Module Core
        <StructLayout(LayoutKind.Sequential)>
        Public Structure PMIB_IPFORWARDROW
            Dim dwForwardDest As UInteger
            Dim dwForwardMask As UInteger
            Dim dwForwardPolicy As UInteger
            Dim dwForwardNextHop As UInteger
            Dim dwForwardIfIndex As UInteger
            Dim dwForwardType As UInteger
            Dim dwForwardProto As UInteger
            Dim dwForwardAge As UInteger
            Dim dwForwardNextHopAS As UInteger
            Dim dwForwardMetric1 As UInteger
            Dim dwForwardMetric2 As UInteger
            Dim dwForwardMetric3 As UInteger
            Dim dwForwardMetric4 As UInteger
            Dim dwForwardMetric5 As UInteger
        End Structure

        Public Class NativeMethods
            <DllImport("iphlpapi", CharSet:=CharSet.Auto)>
            Public Shared Function GetIpForwardTable(ByVal pIpForwardTable As IntPtr, ByRef pdwSize As Integer, ByVal bOrder As Boolean) As Integer
            End Function

            <DllImport("iphlpapi", CharSet:=CharSet.Auto)>
            Public Shared Function CreateIpForwardEntry(ByVal pRoute As IntPtr) As Integer
            End Function

            <DllImport("iphlpapi", CharSet:=CharSet.Auto)>
            Public Shared Function DeleteIpForwardEntry(ByVal pRoute As IntPtr) As Integer
            End Function
        End Class

        Public Sub Test()
            CodeCowboy.NetworkRoute.NicInterface.PrintAllNetworkInterface()
            If CodeCowboy.NetworkRoute.Ip4RouteTable.InterfaceIndexExists(13) Then
                If Not CodeCowboy.NetworkRoute.Ip4RouteTable.RouteExists("89.7.222.215") Then
                    Dim nroute As New CodeCowboy.NetworkRoute.Ip4RouteEntry With {.DestinationIP = System.Net.IPAddress.Parse("89.7.222.215"),
                        .ForwardAge = 1,
                        .ForwardProtocol = 2,
                        .ForwardType = 3,
                        .GatewayIP = System.Net.IPAddress.Parse("10.0.0.0"),
                        .Metric = 281,
                        .InterfaceIndex = 13,
                        .SubnetMask = System.Net.IPAddress.Parse("255.255.255.255")}

                    CodeCowboy.NetworkRoute.Ip4RouteTable.CreateRoute(nroute)
                    'CodeCowboy.NetworkRoute.Ip4RouteTable.CreateRoute("89.7.222.215", "255.255.255.255", 23, 281)
                    'CodeCowboy.NetworkRoute.Ip4RouteTable.CreateRoute("89.0.0.0", "255.0.0.0", 13, 281)
                    'CodeCowboy.NetworkRoute.Ip4RouteTable.CreateRoute("89.255.255.255", "255.255.255.255", 13, 281)
                Else
                    CodeCowboy.NetworkRoute.Ip4RouteTable.RoutePrint()
                    Dim t = CodeCowboy.NetworkRoute.Ip4RouteTable.GetRouteEntry("89.7.222.215")
                    Stop
                End If
            End If
        End Sub
    End Module
End Namespace