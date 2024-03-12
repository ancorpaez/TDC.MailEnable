Imports System.Net.NetworkInformation

Namespace RouteTable
    Module Core
        Public Sub Test()
            Dim tIp As String = "89.7.222.215"
            Console.WriteLine(Contains(tIp))
            If Not Contains(tIp) Then
                Create(New RouteEntry With {.Ip = tIp, .Mask = "255.255.255.255", .Gateway = "10.0.0.0"})
            End If
        End Sub

        Public Function Contains(Ip As String) As Boolean
            Using Tabla As New RouteTableParser
                Return Tabla.Route.ContainsKey(Ip)
            End Using
        End Function

        Public Function Create(Route As RouteEntry) As Boolean
            Using AddRoute As New RouteOperation
                Return AddRoute.Add(Route)
            End Using
        End Function
    End Module
End Namespace