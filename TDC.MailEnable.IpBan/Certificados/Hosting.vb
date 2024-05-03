Imports System.Xml.Serialization
Imports System.Collections.Concurrent

Namespace Certificados
    Public Class Hosting
        Public Property Name As String = String.Empty

        ' XmlSerializer no soporta Uri directamente, por lo tanto, usamos String.
        <XmlIgnore>
        Public Property Url As Uri

        ' Propiedad para serializar y deserializar Url.
        <XmlElement("Url")>
        Public Property UrlString As String
            Get
                Return Url?.ToString()
            End Get
            Set(value As String)
                Url = If(value Is Nothing, Nothing, New Uri(value))
            End Set
        End Property

        ' Usamos una estructura más simple para serializar el diccionario.
        <XmlElement("NavigationEntry")>
        Public Property NavigationList As List(Of KeyValuePair(Of String, String))
            Get
                Return Navigation.Select(Function(kvp) New KeyValuePair(Of String, String)(kvp.Key, kvp.Value.ToString())).ToList()
            End Get
            Set(value As List(Of KeyValuePair(Of String, String)))
                Navigation = New ConcurrentDictionary(Of String, Uri)(value.Select(Function(kvp) New KeyValuePair(Of String, Uri)(kvp.Key, New Uri(kvp.Value))))
            End Set
        End Property

        <XmlIgnore>
        Public Property Navigation As New ConcurrentDictionary(Of String, Uri)

        <XmlElement("ScriptEntry")>
        Public Property ScriptsList As List(Of KeyValuePair(Of String, String))
            Get
                Return Scripts.ToList()
            End Get
            Set(value As List(Of KeyValuePair(Of String, String)))
                Scripts = New ConcurrentDictionary(Of String, String)(value)
            End Set
        End Property

        <XmlIgnore>
        Public Property Scripts As New ConcurrentDictionary(Of String, String)

        Public Sub New(Nombre As String)
            Me.Name = Nombre
        End Sub

    End Class
End Namespace