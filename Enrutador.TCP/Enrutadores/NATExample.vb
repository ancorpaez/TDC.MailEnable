Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class NATExample

    Private listener As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    Private port As Integer = 8080  ' Puerto de escucha
    Private publicIp As String = "192.168.1.100"  ' IP pública para NAT

    Private Sub StartServer()
        listener.Bind(New IPEndPoint(IPAddress.Any, port))
        listener.Listen(10)

        Console.WriteLine("Servidor NAT iniciado en el puerto: " & port.ToString())
        AcceptConnections()
    End Sub

    Private Sub AcceptConnections()
        While True
            Dim clientSocket As Socket = listener.Accept()
            Console.WriteLine("Nueva conexión entrante de: " & clientSocket.RemoteEndPoint.ToString())

            Dim workerThread As New Thread(Sub(s As Socket)
                                               HandleClient(s)
                                           End Sub)
            workerThread.Start(clientSocket)
        End While
    End Sub

    Private Sub HandleClient(clientSocket As Socket)
        Dim serverSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        ' Conectar al servidor real (reemplazar con la lógica de tu servidor)
        serverSocket.Connect(New IPEndPoint(IPAddress.Parse("8.8.8.8"), 53))  ' Conexión de ejemplo a un servidor DNS

        Dim clientBuffer As Byte() = New Byte(1024)
        Dim serverBuffer As Byte() = New Byte(1024)

        While True
            Dim bytesRead = clientSocket.Receive(clientBuffer)
            If bytesRead > 0 Then
                ' Realizar NAT: reemplazar IP origen por IP pública
                ReplaceSourceIp(clientBuffer, 0, bytesRead)
                serverSocket.Send(clientBuffer, bytesRead, SocketFlags.None)

                Dim bytesReceivedFromServer = serverSocket.Receive(serverBuffer)
                If bytesReceivedFromServer > 0 Then
                    ' Reemplazar IP destino por IP del cliente
                    ReplaceDestinationIp(serverBuffer, 0, bytesReceivedFromServer)
                    clientSocket.Send(serverBuffer, bytesReceivedFromServer, SocketFlags.None)
                Else
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        clientSocket.Close()
        serverSocket.Close()
    End Sub

    ' Reemplaza la IP de origen en el buffer por la IP pública del NAT
    Private Sub ReplaceSourceIp(buffer As Byte(), offset As Integer, length As Integer)
        Dim originalIp As Byte() = New Byte(4)
        Array.Copy(buffer, offset + 12, originalIp, 0, 4)  ' Extraer la IP de origen (posición 12 en adelante)
        Array.Copy(IPAddress.Parse(publicIp).GetAddressBytes(), 0, buffer, offset + 12, 4)  ' Reemplazar por la IP pública
    End Sub

    ' Reemplaza la IP de destino en el buffer por la IP del cliente
    Private Sub ReplaceDestinationIp(buffer As Byte(), offset As Integer, length As Integer)
        Dim destinationIp As Byte() = New Byte(4)
        Array.Copy(buffer, offset + 16, destinationIp, 0, 4)  ' Extraer la IP de destino (posición 16 en adelante)
        Array.Copy(clientSocket.RemoteEndPoint.Address.GetAddressBytes(), 0, buffer, offset + 16, 4)  ' Reemplazar por la IP del cliente
    End Sub

    Static Sub Main(args As String())
        Dim natServer As New NATServer()
        natServer.StartServer()
        Console.WriteLine("Presiona Enter para detener el servidor")
        Console.ReadLine()
    End Sub
End Class
