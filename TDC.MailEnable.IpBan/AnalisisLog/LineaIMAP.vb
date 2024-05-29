Namespace AnalisisLog
    Public Class LineaIMAP
        'Desarrollo para comprobar si conviene trabajar con Celdas.
        Inherits Linea
        '#Fields: date time c-ip agent account cs-username s-ip s-port cs-method cs-uristem cs-uriquery s-computername sc-bytes cs-bytes time-taken
        Public Property Fecha As DateTime
        Public Property Hora As TimeSpan
        Public Property ClienteIP As String
        Public Property Agente As String
        Public Property Cuenta As String
        Public Property Usuario As String
        Public Property ServidorIP As String
        Public Property PuertoServidor As Integer
        Public Property MetodoComando As String
        Public Property UriStem As String
        Public Property UriQuery As String
        Public Property NombreServidor As String
        Public Property BytesServidor As Integer
        Public Property BytesCliente As Integer
        Public Property TiempoRespuesta As Integer

    End Class
End Namespace
