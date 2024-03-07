Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading.Thread


Namespace ENAT
    Public Class ENATIP
        Private StringCommandAdd As String = "interface ip add address ""ENRUTADOR"" 0.0.0.0"
        Private StringCommandDelete As String = "interface ip delete address ""ENRUTADOR"" 0.0.0.0"
        Private LanzarComando As String = ""

        Public Property Ip As IPAddress
        Public Property Tarjeta As NetworkInterface

        Public Sub New(Ip As String, Tarjeta As String)
            Try
                Me.Ip = IPAddress.Parse(Ip)
            Catch ex As Exception
                Me.Ip = IPAddress.Any
            End Try
            Try
                Me.Tarjeta = BuscarTarjeta(Tarjeta)
            Catch ex As Exception
                Me.Tarjeta = Nothing
            End Try
            If Tarjeta Is Nothing Then Throw New ArgumentException("Tarjeta de red no Encontrada")
            If Me.Ip.ToString = IPAddress.Any.ToString Then Throw New ArgumentException("Ip no válida")
        End Sub
        Public Function Crear() As Boolean
            Try
                Tarjeta = BuscarTarjeta(Tarjeta.Name)
                If Not Existe() Then
                    LanzarComando = StringCommandAdd.Replace("ENRUTADOR", Tarjeta.Name).Replace("0.0.0.0", Ip.ToString)
                    LanzarProceso()
                    Dim Limite As Integer = 0
                    While Not Existe()
                        Tarjeta = BuscarTarjeta(Tarjeta.Name)
                        Limite += 1
                        Sleep(100)
                        If Limite > 49 Then Exit While
                        Console.WriteLine($"Add - Limite: {50 - Limite}")
                    End While
                    If Limite > 49 Then Return False
                End If
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Public Function Eliminar() As Boolean
            Try
                Tarjeta = BuscarTarjeta(Tarjeta.Name)
                If Existe() Then
                    LanzarComando = StringCommandDelete.Replace("ENRUTADOR", Tarjeta.Name).Replace("0.0.0.0", Ip.ToString)
                    LanzarProceso()
                    Dim Limite As Integer = 0
                    While Existe()
                        Tarjeta = BuscarTarjeta(Tarjeta.Name)
                        Limite += 1
                        Sleep(100)
                        If Limite > 49 Then Exit While
                        Console.WriteLine($"Del - Limite: {50 - Limite}")
                    End While
                    If Limite > 49 Then Return False
                End If
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Public Function Existe() As Boolean
            If Tarjeta IsNot Nothing Then
                Dim ipProperties As IPInterfaceProperties = Tarjeta.GetIPProperties()
                Dim unicastIPs As UnicastIPAddressInformationCollection = ipProperties.UnicastAddresses
                If unicastIPs.Any(Function(IpTarjeta) IpTarjeta.Address.ToString() = Ip.ToString) Then
                    Return True
                End If
            End If
            Return False
        End Function

        Private Sub LanzarProceso()
            Try
                Using Lanzar As New Process
                    With Lanzar
                        With .StartInfo
                            .FileName = "netsh"
                            .Verb = "runas"
                            .Arguments = LanzarComando
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

        Private Function BuscarTarjeta(Tarjeta As String) As NetworkInterface
            Return ObtenerTarjeta(Tarjeta)
        End Function
        Public Shared Function ObtenerTarjeta(Tarjeta As String) As NetworkInterface
            Dim Tarjetas As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces
            Return Tarjetas.FirstOrDefault(Function(t) t.Name = Tarjeta)
        End Function
    End Class
End Namespace