﻿Imports System.Net.Sockets
Namespace Enrutadores
    Public Class BufferEnrutador
        Public Property SocketOrigen As Socket
        Public SocketDestino As Socket
        Public Buffer As Byte()
        Public Sub New(Origen As Socket, Destino As Socket)
            SocketOrigen = Origen
            SocketDestino = Destino
            Buffer = New Byte(8191) {}
        End Sub

    End Class
End Namespace