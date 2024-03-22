Namespace NET
    Module Core
        Public Property EasyPortManager As New AsociadorPuertos With {.Listen = 144, .Route = 143}
        Public Property EasyPortManagerSsl As New AsociadorPuertos With {.Listen = 994, .Route = 993}
    End Module
End Namespace