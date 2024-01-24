Imports System.Net
Imports System.Net.Sockets

Namespace Routing
    Public Class TcpForwarderSlim
        Private ReadOnly _mainSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        Public Sub Start(local As IPEndPoint, remote As IPEndPoint)
            _mainSocket.Bind(local)
            _mainSocket.Listen(10)

            While True
                Dim source = _mainSocket.Accept()
                Dim destination = New TcpForwarderSlim()
                Dim state = New State(source, destination._mainSocket)
                destination.Connect(remote, source)
                source.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, AddressOf OnDataReceive, state)
            End While
        End Sub

        Private Sub Connect(remoteEndpoint As EndPoint, destination As Socket)
            Dim state = New State(_mainSocket, destination)
            _mainSocket.Connect(remoteEndpoint)
            _mainSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, AddressOf OnDataReceive, state)
        End Sub

        Private Shared Sub OnDataReceive(result As IAsyncResult)
            Dim state = DirectCast(result.AsyncState, State)

            Try
                Dim bytesRead = state.SourceSocket.EndReceive(result)
                If bytesRead > 0 Then
                    state.DestinationSocket.Send(state.Buffer, bytesRead, SocketFlags.None)
                    state.SourceSocket.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, AddressOf OnDataReceive, state)
                End If
            Catch
                state.DestinationSocket.Close()
                state.SourceSocket.Close()
            End Try
        End Sub

        Private Class State
            Public Property SourceSocket As Socket
            Public Property DestinationSocket As Socket
            Public Property Buffer As Byte()

            Public Sub New(source As Socket, destination As Socket)
                SourceSocket = source
                DestinationSocket = destination
                Buffer = New Byte(8192) {}
            End Sub
        End Class
    End Class
End Namespace
