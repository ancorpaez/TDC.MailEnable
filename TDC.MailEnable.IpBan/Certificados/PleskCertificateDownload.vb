Imports System.Security.Policy

Namespace Certificados
    Public Class PleskCertificateDownload
        Public Hosting As PleskHosting = Nothing
        Public Domain As PleskDomain = Nothing
        Public Viewer As Interfaz.Navegador
        Public Sub Download()
            Viewer = New Interfaz.Navegador(Me) With {.TopLevel = False, .FormBorderStyle = FormBorderStyle.None, .Name = Domain.Name, .Text = Domain.Name}
            Viewer.Show()
        End Sub
        Public Sub LogOut()
            Dim LogOutUrl As New Uri($"{Hosting.Url.AbsoluteUri}logout.php")
            Viewer.WB.Source = LogOutUrl
        End Sub
    End Class
End Namespace