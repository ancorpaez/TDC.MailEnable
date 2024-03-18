Namespace NET
    Module Core
        Public Property EasyPortManager As New AsociadorPuertos With {.Listen = 143, .Route = 144}
        Public Property EasyPortManagerSsl As New AsociadorPuertos With {.Listen = 993, .Route = 994}
    End Module
End Namespace