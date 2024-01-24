Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim PruebaGeo As New GeoLocalizacion.IpInfo
        Dim Cadena As String = PruebaGeo.Geolocalizar("176.83.188.220")
        Stop
    End Sub
End Class
