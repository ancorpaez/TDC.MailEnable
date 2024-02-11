Imports System.Net
Imports System.Text.RegularExpressions
Imports TDC.MailEnable.Core.MailEnableLog

Namespace GeoLocalizacion
    Public Class IpInfo
        Public Function Geolocalizar(Ip As String, Almacen As Cls_Geolocalizacion) As String
            Try
                If Not Almacen.Contains(Ip) Then
                    Dim Req As HttpWebRequest = HttpWebRequest.Create("https://ipinfo.io/" & Ip & "?token=34f171996c5865")
                    Dim Resp As HttpWebResponse
                    Req.Method = "GET"
                    Req.UserAgent = "curl/7/29/0"
                    Resp = Req.GetResponse
                    Dim Pais = ObtenerPais(New IO.StreamReader(Resp.GetResponseStream).ReadToEnd)
                    Almacen.Add(Ip, Pais)
                    Return Pais
                Else
                    Return Almacen.Get(Ip)
                End If

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