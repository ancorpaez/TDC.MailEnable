Namespace AnalisisLog
    Public Class LineaSMTP
        'Desarrollo para comprobar si conviene trabajar con Celdas.
        Inherits Linea
        '#Fields: date time c-ip agent account s-ip s-port cs-method cs-uristem cs-uriquery s-computername sc-bytes cs-bytes cs-username

        Private Elementos() As String = {}
        Public Sub New(Linea As String)
            Elementos = Linea.Split(" ")
            Fecha = Date.Parse(Elementos(0))
            Hora = TimeSpan.Parse(Elementos(1))
            ClienteIP = Elementos(2)
            Agente = Elementos(3)
            Cuenta = Elementos(4)
            ServidorIP = Elementos(5)
            PuertoServidor = Elementos(6)
            MetodoComando = Elementos(7)
            UriStem = Elementos(8)
            UriQuery = Elementos(9)
            NombreServidor = Elementos(10)
            BytesServidor = Elementos(11)
            BytesCliente = Elementos(12)
            Usuario = Elementos(13)
        End Sub


        Public Property Fecha As DateTime
        Public Property Hora As TimeSpan
        Public Property ClienteIP As String
        Public Property Agente As String
        Public Property Cuenta As String
        Public Property ServidorIP As String
        Public Property PuertoServidor As Integer
        Public Property MetodoComando As String
        Public Property UriStem As String
        Public Property UriQuery As String
        Public Property NombreServidor As String
        Public Property BytesServidor As Integer
        Public Property BytesCliente As Integer
        Public Property Usuario As String

        Public esLogin As Boolean = False
        Public esAutentificado As Boolean = False

    End Class
End Namespace
