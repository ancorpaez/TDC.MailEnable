Namespace Certificados
    Public Class PleskDomain
        Public ReadOnly Property Name As String
            Get
                Return _Name
            End Get
        End Property
        Private _Name As String = String.Empty

        Public DomainId As Integer = 0
        Public CertificateId As Integer = 0
        Public UserName As String = String.Empty
        Public UserPassword As String = String.Empty
        Public HostingKey As String = String.Empty

        Public Sub New(Nombre As String)
            _Name = Nombre
        End Sub
    End Class
End Namespace