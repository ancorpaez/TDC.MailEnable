Imports System.Net
Namespace GeoLocalizacion
    Public Class MyNsLookUp

        Public Function EsLegitima(IP As String) As Boolean
            Try
                Dim FindDominio As List(Of String) = Dns.GetHostEntry(IPAddress.Parse(IP)).HostName.Split(".").ToList
                Dim Dominio As String = String.Empty
                If FindDominio.Count > 1 Then Dominio = $"{FindDominio(FindDominio.Count - 2)}.{FindDominio(FindDominio.Count - 1)}"
                If String.IsNullOrEmpty(Dominio) Then Return False

                Dim IpDominio As IPAddress = Dns.GetHostEntry(Dominio).AddressList.First

            Catch ex As Exception
                Return False
            End Try
            Dim t1 = Dns.GetHostEntry(IP)
            Dim hostEntry As IPHostEntry = Dns.GetHostEntry(IPAddress.Parse(IP))

            For Each [alias] As String In hostEntry.Aliases
                Console.WriteLine("Alias: " & [alias])
            Next

            For Each ip1 As IPAddress In hostEntry.AddressList
                Console.WriteLine("Address: " & ip1.ToString())
            Next

            ' Validar si la IP tiene un registro MX
            Dim mxRecords As String() = nslookup(IP, "MX")
            If mxRecords.Length = 0 Then
                Return False
            End If

            ' Validar si la IP está en el registro SPF
            Dim spfRecords As String() = nslookup(IP, "SPF")
            If Not spfRecords.Any(Function(r) r.Contains(IP)) Then
                Return False
            End If

            Return True
        End Function

        Sub Main()
            Dim hostEntry As IPHostEntry = Dns.GetHostEntry("example.com")

            For Each [alias] As String In hostEntry.Aliases
                Console.WriteLine("Alias: " & [alias])
            Next

            For Each ip As IPAddress In hostEntry.AddressList
                Console.WriteLine("Address: " & ip.ToString())
            Next
            'Dim mxRecords As String() = hostEntry.Aliases

            Console.ReadKey()
        End Sub

        Private Function nslookup(IP As String, RecordType As String) As String()

            ' Usar la herramienta nslookup para obtener los registros
            Dim process As New Process()
            process.StartInfo.FileName = "nslookup"
            process.StartInfo.Arguments = $"-type={RecordType} {IP}"
            process.StartInfo.UseShellExecute = False
            process.StartInfo.RedirectStandardOutput = True
            process.Start()

            ' Leer la salida de nslookup
            Dim output As String = process.StandardOutput.ReadToEnd()
            process.WaitForExit()

            ' Extraer los registros
            Dim records As String() = output.Split(vbLf)
            Return records.Where(Function(r) Not r.StartsWith("***")).ToArray()

        End Function

    End Class

End Namespace