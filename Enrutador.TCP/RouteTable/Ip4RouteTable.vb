Imports System
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.Collections.Generic

Namespace CodeCowboy.NetworkRoute
    Public Class Ip4RouteTable
        Public Shared Sub RoutePrint(testing As Boolean)
            Dim fwdTable = IntPtr.Zero
            Dim size As Integer = 0
            Dim result = NativeMethods.GetIpForwardTable(fwdTable, size, True)
            fwdTable = Marshal.AllocHGlobal(size)

            result = NativeMethods.GetIpForwardTable(fwdTable, size, True)

            Dim forwardTable = NativeMethods.ReadIPForwardTable(fwdTable)

            Marshal.FreeHGlobal(fwdTable)

            Console.Write(vbTab & "Number of entries: {0}" & vbLf, forwardTable.Size)

            For i As Integer = 0 To forwardTable.Table.Length - 1
                Console.Write(vbLf & vbTab & "Route[{0}] Dest IP: {1}" & vbLf, i, New IPAddress(CLng(forwardTable.Table(i).dwForwardDest)).ToString())
                Console.Write(vbTab & "Route[{0}] Subnet Mask: {1}" & vbLf, i, New IPAddress(CLng(forwardTable.Table(i).dwForwardMask)).ToString())
                Console.Write(vbTab & "Route[{0}] Next Hop: {1}" & vbLf, i, New IPAddress(CLng(forwardTable.Table(i).dwForwardNextHop)).ToString())
                Console.Write(vbTab & "Route[{0}] If Index: {1}" & vbLf, i, forwardTable.Table(i).dwForwardIfIndex)
                Console.Write(vbTab & "Route[{0}] Type: {1}" & vbLf, i, forwardTable.Table(i).dwForwardType)
                Console.Write(vbTab & "Route[{0}] Proto: {1}" & vbLf, i, forwardTable.Table(i).dwForwardProto)
                Console.Write(vbTab & "Route[{0}] Age: {1}" & vbLf, i, forwardTable.Table(i).dwForwardAge)
                Console.Write(vbTab & "Route[{0}] Metric1: {1}" & vbLf, i, forwardTable.Table(i).dwForwardMetric1)
            Next
        End Sub

        Public Shared Sub RoutePrint()
            Dim routeTable As List(Of Ip4RouteEntry) = GetRouteTable()
            RoutePrint(routeTable)
        End Sub

        Public Shared Sub RoutePrint(routeTable As List(Of Ip4RouteEntry))
            Console.WriteLine("Route Count: {0}", routeTable.Count)
            Console.WriteLine("{0,18} {1,18} {2,18} {3,5} {4,8} ", "DestinationIP", "NetMask", "Gateway", "IF", "Metric")
            For Each entry As Ip4RouteEntry In routeTable
                Console.WriteLine("{0,18} {1,18} {2,18} {3,5} {4,8} ", entry.DestinationIP, entry.SubnetMask, entry.GatewayIP, entry.InterfaceIndex, entry.Metric)
            Next
        End Sub

        Public Shared Function GetRouteTable() As List(Of Ip4RouteEntry)
            Dim fwdTable = IntPtr.Zero
            Dim size As Integer = 0
            Dim result = NativeMethods.GetIpForwardTable(fwdTable, size, True)
            fwdTable = Marshal.AllocHGlobal(size)

            result = NativeMethods.GetIpForwardTable(fwdTable, size, True)

            Dim forwardTable = NativeMethods.ReadIPForwardTable(fwdTable)

            Marshal.FreeHGlobal(fwdTable)

            Dim routeTable As New List(Of Ip4RouteEntry)()
            For i As Integer = 0 To forwardTable.Table.Length - 1
                Dim entry As New Ip4RouteEntry()
                entry.DestinationIP = New IPAddress(CLng(forwardTable.Table(i).dwForwardDest))
                entry.SubnetMask = New IPAddress(CLng(forwardTable.Table(i).dwForwardMask))
                entry.GatewayIP = New IPAddress(CLng(forwardTable.Table(i).dwForwardNextHop))
                entry.InterfaceIndex = Convert.ToInt32(forwardTable.Table(i).dwForwardIfIndex)
                entry.ForwardType = Convert.ToInt32(forwardTable.Table(i).dwForwardType)
                entry.ForwardProtocol = Convert.ToInt32(forwardTable.Table(i).dwForwardProto)
                entry.ForwardAge = Convert.ToInt32(forwardTable.Table(i).dwForwardAge)
                entry.Metric = Convert.ToInt32(forwardTable.Table(i).dwForwardMetric1)
                routeTable.Add(entry)
            Next
            Return routeTable
        End Function

        Public Shared Function InterfaceIndexExists(interfaceIndex As Integer) As Boolean
            Dim routeTable As List(Of Ip4RouteEntry) = Ip4RouteTable.GetRouteTable()
            Dim routeEntry As Ip4RouteEntry = routeTable.Find(Function(i) i.InterfaceIndex.Equals(interfaceIndex))
            Return (routeEntry IsNot Nothing)
        End Function

        Public Shared Function RouteExists(destinationIP As String) As Boolean
            Dim routeTable As List(Of Ip4RouteEntry) = Ip4RouteTable.GetRouteTable()
            Dim routeEntry As Ip4RouteEntry = routeTable.Find(Function(i) i.DestinationIP.ToString().Equals(destinationIP))
            Return (routeEntry IsNot Nothing)
        End Function

        Public Shared Function GetRouteEntry(destinationIP As String) As List(Of Ip4RouteEntry)
            Dim routeTable As List(Of Ip4RouteEntry) = Ip4RouteTable.GetRouteTable()
            Dim routeMatches As List(Of Ip4RouteEntry) = routeTable.FindAll(Function(i) i.DestinationIP.ToString().Equals(destinationIP))
            Return routeMatches
        End Function

        Public Shared Function GetRouteEntry(destinationIP As String, mask As String) As List(Of Ip4RouteEntry)
            Dim routeTable As List(Of Ip4RouteEntry) = Ip4RouteTable.GetRouteTable()
            Dim routeMatches As List(Of Ip4RouteEntry) = routeTable.FindAll(Function(i) i.DestinationIP.ToString().Equals(destinationIP) AndAlso i.SubnetMask.ToString().Equals(mask))
            Return routeMatches
        End Function

        Public Shared Sub CreateRoute(routeEntry As Ip4RouteEntry)
            Dim route = New NativeMethods.MIB_IPFORWARDROW() With {
                .dwForwardDest = BitConverter.ToUInt32(IPAddress.Parse(routeEntry.DestinationIP.ToString()).GetAddressBytes(), 0),
                .dwForwardMask = BitConverter.ToUInt32(IPAddress.Parse(routeEntry.SubnetMask.ToString()).GetAddressBytes(), 0),
                .dwForwardNextHop = BitConverter.ToUInt32(IPAddress.Parse(routeEntry.GatewayIP.ToString()).GetAddressBytes(), 0),
                .dwForwardMetric1 = 99,
                .dwForwardType = Convert.ToUInt32(3),
                .dwForwardProto = Convert.ToUInt32(3),
                .dwForwardAge = 0,
                .dwForwardIfIndex = Convert.ToUInt32(routeEntry.InterfaceIndex)
            }

            Dim ptr = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(NativeMethods.MIB_IPFORWARDROW)))
            Try
                Marshal.StructureToPtr(route, ptr, False)
                Dim status = NativeMethods.CreateIpForwardEntry(ptr)
            Finally
                Marshal.FreeHGlobal(ptr)
            End Try
        End Sub

        Public Shared Sub CreateRoute(destination As String, mask As String, interfaceIndex As Integer, metric As Integer)
            Dim adaptor As NetworkAdaptor = NicInterface.GetNetworkAdaptor(interfaceIndex)
            Dim route = New NativeMethods.MIB_IPFORWARDROW() With {
                .dwForwardDest = BitConverter.ToUInt32(IPAddress.Parse(destination).GetAddressBytes(), 0),
                .dwForwardMask = BitConverter.ToUInt32(IPAddress.Parse(mask).GetAddressBytes(), 0),
                .dwForwardNextHop = BitConverter.ToUInt32(IPAddress.Parse(adaptor.PrimaryGateway.ToString()).GetAddressBytes(), 0),
                .dwForwardMetric1 = Convert.ToUInt32(metric),
                .dwForwardType = Convert.ToUInt32(3),
                .dwForwardProto = Convert.ToUInt32(3),
                .dwForwardAge = 0,
                .dwForwardIfIndex = Convert.ToUInt32(interfaceIndex)
            }

            Dim ptr = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(NativeMethods.MIB_IPFORWARDROW)))
            Try
                Marshal.StructureToPtr(route, ptr, False)
                Dim status = NativeMethods.CreateIpForwardEntry(ptr)
            Finally
                Marshal.FreeHGlobal(ptr)
            End Try
        End Sub

        Public Shared Sub DeleteRoute(routeEntry As Ip4RouteEntry)
            Dim route = New NativeMethods.MIB_IPFORWARDROW() With {
                .dwForwardDest = BitConverter.ToUInt32(IPAddress.Parse(routeEntry.DestinationIP.ToString()).GetAddressBytes(), 0),
                .dwForwardMask = BitConverter.ToUInt32(IPAddress.Parse(routeEntry.SubnetMask.ToString()).GetAddressBytes(), 0),
                .dwForwardNextHop = BitConverter.ToUInt32(IPAddress.Parse(routeEntry.GatewayIP.ToString()).GetAddressBytes(), 0),
                .dwForwardMetric1 = 99,
                .dwForwardType = Convert.ToUInt32(3),
                .dwForwardProto = Convert.ToUInt32(3),
                .dwForwardAge = 0,
                .dwForwardIfIndex = Convert.ToUInt32(routeEntry.InterfaceIndex)
            }

            Dim ptr = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(NativeMethods.MIB_IPFORWARDROW)))
            Try
                Marshal.StructureToPtr(route, ptr, False)
                Dim status = NativeMethods.DeleteIpForwardEntry(ptr)
            Finally
                Marshal.FreeHGlobal(ptr)
            End Try
        End Sub

        Public Shared Sub DeleteRoute(destinationIP As String)
            Dim routeMatches As List(Of Ip4RouteEntry) = Ip4RouteTable.GetRouteEntry(destinationIP)
            If routeMatches Is Nothing Then
                Return
            End If

            For Each routeEntry As Ip4RouteEntry In routeMatches
                DeleteRoute(routeEntry)
            Next
        End Sub

        Public Shared Sub DeleteRoute(destinationIP As String, mask As String)
            Dim routeMatches As List(Of Ip4RouteEntry) = Ip4RouteTable.GetRouteEntry(destinationIP, mask)
            If routeMatches Is Nothing Then
                Return
            End If

            For Each routeEntry As Ip4RouteEntry In routeMatches
                DeleteRoute(routeEntry)
            Next
        End Sub

        Public Shared Sub DeleteRoute(interfaceIndex As Integer)
            Dim fwdTable = IntPtr.Zero
            Dim size As Integer = 0
            Dim result = NativeMethods.GetIpForwardTable(fwdTable, size, True)
            fwdTable = Marshal.AllocHGlobal(size)

            result = NativeMethods.GetIpForwardTable(fwdTable, size, True)

            Dim forwardTable = NativeMethods.ReadIPForwardTable(fwdTable)

            Marshal.FreeHGlobal(fwdTable)

            Dim uIndex As UInteger = Convert.ToUInt32(interfaceIndex)
            Dim filtered As New List(Of NativeMethods.MIB_IPFORWARDROW)()
            For i As Integer = 0 To forwardTable.Table.Length - 1
                If forwardTable.Table(i).dwForwardIfIndex.Equals(uIndex) Then
                    filtered.Add(forwardTable.Table(i))
                End If
            Next

            Dim ptr = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(NativeMethods.MIB_IPFORWARDROW)))
            Try
                For Each routeEntry As NativeMethods.MIB_IPFORWARDROW In filtered
                    Marshal.StructureToPtr(routeEntry, ptr, False)
                    Dim status = NativeMethods.DeleteIpForwardEntry(ptr)
                Next
            Finally
                Marshal.FreeHGlobal(ptr)
            End Try
        End Sub
    End Class

    Public Class Ip4RouteEntry
        Public Property DestinationIP As IPAddress
        Public Property SubnetMask As IPAddress
        Public Property GatewayIP As IPAddress
        Public Property InterfaceIndex As Integer
        Public Property ForwardType As Integer
        Public Property ForwardProtocol As Integer
        Public Property ForwardAge As Integer
        Public Property Metric As Integer
    End Class

    Friend NotInheritable Class NativeMethods
        <ComVisible(False), StructLayout(LayoutKind.Sequential)>
        Public Structure IPForwardTable
            Public Size As UInteger

            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)>
            Public Table As MIB_IPFORWARDROW()
        End Structure

        <ComVisible(False), StructLayout(LayoutKind.Sequential)>
        Public Structure MIB_IPFORWARDROW
            Friend dwForwardDest As UInteger 'DWORD
            Friend dwForwardMask As UInteger 'DWORD
            Friend dwForwardPolicy As UInteger 'DWORD
            Friend dwForwardNextHop As UInteger 'DWORD
            Friend dwForwardIfIndex As UInteger 'DWORD
            Friend dwForwardType As UInteger 'DWORD
            Friend dwForwardProto As UInteger 'DWORD
            Friend dwForwardAge As UInteger 'DWORD
            Friend dwForwardNextHopAS As UInteger 'DWORD
            Friend dwForwardMetric1 As UInteger 'DWORD
            Friend dwForwardMetric2 As UInteger 'DWORD
            Friend dwForwardMetric3 As UInteger 'DWORD
            Friend dwForwardMetric4 As UInteger 'DWORD
            Friend dwForwardMetric5 As UInteger 'DWORD
        End Structure

        Public Enum MIB_IPFORWARD_TYPE As UInteger
            MIB_IPROUTE_TYPE_OTHER = 1
            MIB_IPROUTE_TYPE_INVALID = 2
            MIB_IPROUTE_TYPE_DIRECT = 3
            MIB_IPROUTE_TYPE_INDIRECT = 4
        End Enum

        Public Enum MIB_IPFORWARD_PROTO As UInteger
            MIB_IPPROTO_OTHER = 1
            MIB_IPPROTO_LOCAL = 2
            MIB_IPPROTO_NETMGMT = 3
            MIB_IPPROTO_ICMP = 4
            MIB_IPPROTO_EGP = 5
            MIB_IPPROTO_GGP = 6
            MIB_IPPROTO_HELLO = 7
            MIB_IPPROTO_RIP = 8
            MIB_IPPROTO_IS_IS = 9
            MIB_IPPROTO_ES_IS = 10
            MIB_IPPROTO_CISCO = 11
            MIB_IPPROTO_BBN = 12
            MIB_IPPROTO_OSPF = 13
            MIB_IPPROTO_BGP = 14
            MIB_IPPROTO_NT_AUTOSTATIC = 10002
            MIB_IPPROTO_NT_STATIC = 10006
            MIB_IPPROTO_NT_STATIC_NON_DOD = 10007
        End Enum

        Public Shared Function ReadIPForwardTable(tablePtr As IntPtr) As IPForwardTable
            Dim result = CType(Marshal.PtrToStructure(tablePtr, GetType(IPForwardTable)), IPForwardTable)

            Dim table(result.Size - 1) As MIB_IPFORWARDROW
            Dim p As IntPtr = New IntPtr(tablePtr.ToInt64() + Marshal.SizeOf(result.Size))
            For i As Integer = 0 To result.Size - 1
                table(i) = CType(Marshal.PtrToStructure(p, GetType(MIB_IPFORWARDROW)), MIB_IPFORWARDROW)
                p = New IntPtr(p.ToInt64() + Marshal.SizeOf(GetType(MIB_IPFORWARDROW)))
            Next
            result.Table = table

            Return result
        End Function

        'public extern static int CreateIpForwardEntry(ref /*PMIB_IPFORWARDROW*/ Ip4RouteTable.PMIB_IPFORWARDROW pRoute);  Can do by reference or by Pointer

        <DllImport("iphlpapi", CharSet:=CharSet.Auto)>
        Public Shared Function GetIpForwardTable(<[In]> pIpForwardTable As IntPtr, <[In], Out> ByRef pdwSize As Integer, bOrder As Boolean) As Integer
        End Function

        <DllImport("iphlpapi", CharSet:=CharSet.Auto)>
        Public Shared Function CreateIpForwardEntry(<[In]> pRoute As IntPtr) As Integer
        End Function

        <DllImport("iphlpapi", CharSet:=CharSet.Auto)>
        Public Shared Function DeleteIpForwardEntry(<[In]> pRoute As IntPtr) As Integer
        End Function

        <DllImport("iphlpapi", CharSet:=CharSet.Auto)>
        Public Shared Function SetIpForwardEntry(<[In]> pRoute As IntPtr) As Integer
        End Function
    End Class
End Namespace
