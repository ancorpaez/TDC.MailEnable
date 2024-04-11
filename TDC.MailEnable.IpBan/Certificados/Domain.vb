Namespace Certificados
    Public Class Domain
        Public Key As String
        Public Url As Uri
        Public DomainID As String = String.Empty
        Public CertificarteID As String = String.Empty
        Public DomainUserName As String = String.Empty
        Public DomainPassword As String = String.Empty
        Public Navigation As New Concurrent.ConcurrentDictionary(Of String, Uri)
        Public Scripts As New Concurrent.ConcurrentDictionary(Of String, String)
        Public Viewer As Interfaz.Navegador
        Public Sub New(Key As String)
            Me.Key = Key
        End Sub
        Public Sub Download()
            Viewer = New Interfaz.Navegador(Me) With {.TopLevel = False, .FormBorderStyle = FormBorderStyle.None, .Name = Me.Key, .Text = Me.Key}
            Viewer.Show()
        End Sub
        Public Sub LogOut()
            Dim LogOutUrl As New Uri($"{Url.AbsoluteUri}logout.php")
            Viewer.WB.Source = LogOutUrl
        End Sub
    End Class
End Namespace