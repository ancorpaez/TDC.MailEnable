Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization

Namespace GeoLocalizacion
    Public Class IpInfo

        Public Function Geolocalizar(Ip As String) As String
            Try
                Dim Req As HttpWebRequest = HttpWebRequest.Create("https://ipinfo.io/" & Ip)
                Dim Resp As HttpWebResponse
                Req.Method = "GET"
                Req.UserAgent = "curl/7/29/0"
                Resp = Req.GetResponse
                Return ObtenerPais(New IO.StreamReader(Resp.GetResponseStream).ReadToEnd)
            Catch ex As Exception
            End Try
            Return "ERR"
        End Function

        Private Function ObtenerPais(Cadena As String) As String
            Dim Coincidencia = Regex.Match(Cadena, """country"":\s*""([^""]*)""")
            If Coincidencia.Success Then
                Return Coincidencia.Groups(1).Value
            Else
                Return "ERR"
            End If
        End Function
    End Class
End Namespace