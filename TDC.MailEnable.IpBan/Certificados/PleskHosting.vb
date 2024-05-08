Imports System.Xml.Serialization
Imports System.Collections.Concurrent

Namespace Certificados
    Public Class PleskHosting
        Public ReadOnly Property Name As String
            Get
                Return _Name
            End Get
        End Property
        Private _Name As String = String.Empty

        Public Url As Uri = Nothing
        Public Navigation As New Concurrent.ConcurrentDictionary(Of String, Uri)
        Public Scripts As New Concurrent.ConcurrentDictionary(Of String, String)
        Public Sub New(Nombre As String)
            _Name = Nombre
        End Sub

    End Class
End Namespace