Namespace AnalisisLog
    Public Class ArchivoSMTP
        Inherits MI_Archivo
        '#Fields: date time c-ip agent account s-ip s-port cs-method cs-uristem cs-uriquery s-computername sc-bytes cs-bytes cs-username

        ' Registro 4
        ' date           2024-05-29
        ' time           05:23:30
        ' c-ip           83.57.21.251
        ' agent          SMTP-IN
        ' account        sunandbeachhotels.com
        ' s-ip           192.168.79.100
        ' s-port         1076
        ' cs-method      AUTH
        ' cs-uristem     {blank}
        ' cs-uriquery    235+Authenticated
        ' s-computername BLANK
        ' sc-bytes       19
        ' cs-bytes       14
        ' cs-username    receproyal@sunandbeachhotels.com

        ' Registro 4
        ' date           2024-05-29
        ' time           00:33:59
        ' c-ip           121.202.152.115
        ' agent          SMTP-IN
        ' account        sunandbeachhotels.com
        ' s-ip           192.168.79.100
        ' s-port         1756
        ' cs-method      AUTH
        ' cs-uristem     TWFyY29yb21lcm8yMDI0
        ' cs-uriquery    535+Invalid+Username+or+Password
        ' s-computername BLANK
        ' sc-bytes       34
        ' cs-bytes       22
        ' cs-username    marcoromero@sunandbeachhotels.com




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

    End Class
End Namespace
