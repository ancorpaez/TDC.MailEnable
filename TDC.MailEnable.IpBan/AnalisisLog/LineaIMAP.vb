Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO

Namespace AnalisisLog
    Public Class LineaIMAP
        'Desarrollo para comprobar si conviene trabajar con Celdas.
        Inherits Linea
        '#Fields: date time c-ip agent account cs-username s-ip s-port cs-method cs-uristem cs-uriquery s-computername sc-bytes cs-bytes time-taken
        Private Elementos() As String = {}
        Private Linea As String = String.Empty

        Public esLogin As Boolean = False
        Public esAutentificado As Boolean = False
        Public PostOffice As String = String.Empty
        Public MailBox As String = String.Empty
        Public Contraseña As String = "*"
        Public esLog As Boolean = False
        Public Sub New(Linea As String)
            Me.Linea = Linea
            Elementos = Linea.Split(" ")
            Try
                If Elementos.Count = 15 AndAlso Not Elementos.First.ToLower.Contains("fields") Then
                    esLog = True
                    Fecha = Date.Parse(Elementos(0))
                    Hora = TimeSpan.Parse(Elementos(1))
                    ClienteIP = Elementos(2)
                    Agente = Elementos(3)
                    Cuenta = Elementos(4)
                    Usuario = Elementos(5)
                    ServidorIP = Elementos(6)
                    PuertoServidor = Elementos(7)
                    MetodoComando = Elementos(8)
                    UriStem = Elementos(9)
                    UriQuery = Elementos(10)
                    NombreServidor = Elementos(11)
                    BytesServidor = Elementos(12)
                    BytesCliente = Elementos(13)
                    TiempoRespuesta = Elementos(14)
                End If
            Catch ex As Exception
                Stop
            End Try

            'If esLog AndAlso esLogin AndAlso Not esAutentificado Then Stop
        End Sub
        Public Property Fecha As DateTime
        Public Property Hora As TimeSpan
        Public Property ClienteIP As String
        Public Property Agente As String
        Public Property Cuenta As String
        Private _Usuario As String = String.Empty
        Public Property Usuario As String
            Get
                Return _Usuario
            End Get
            Set(value As String)
                _Usuario = value
                PostOffice = Cuenta
                MailBox = $"{_Usuario}@{Cuenta}"
            End Set
        End Property
        Public Property ServidorIP As String
        Public Property PuertoServidor As Integer
        Private _MetodoComando As String = String.Empty
        Public Property MetodoComando As String
            Get
                Return _MetodoComando
            End Get
            Set(value As String)
                _MetodoComando = value
                If _MetodoComando.Contains("LOGIN") Then esLogin = True
                If _MetodoComando.Contains("AUTHENTICATE") Then esLogin = True
            End Set
        End Property
        Public Property UriStem As String
        Private _UriQuery As String = String.Empty
        Public Property UriQuery As String
            Get
                Return _UriQuery
            End Get
            Set(value As String)
                _UriQuery = value
                If _UriQuery.Contains("") Then Stop

                If MetodoComando.Contains("LOGIN") OrElse MetodoComando.Contains("AUTHENTICATE") AndAlso _UriQuery.Contains("LOGIN+completed") Then
                    esAutentificado = True
                ElseIf MetodoComando.Contains("LOGIN") OrElse MetodoComando.Contains("AUTHENTICATE") Then
                    Try
                        Contraseña = ByteArrayToString(DecodeUtf7Imap(UriStem))
                    Catch ex As Exception
                        Contraseña = UriStem
                    End Try
                    'Stop
                End If
            End Set
        End Property
        Public Property NombreServidor As String
        Public Property BytesServidor As Integer
        Public Property BytesCliente As Integer
        Public Property TiempoRespuesta As Integer

        Public Function DecodeUtf7Imap(input As String) As Byte()
            Dim utf7Imap As String = input.Replace("&", "+").Replace(",", "/")
            Return Convert.FromBase64String(utf7Imap)
        End Function

        Public Function ByteArrayToString(bytes As Byte()) As String
            Dim sb As New StringBuilder()
            For Each b As Byte In bytes
                If b >= 32 AndAlso b <= 126 Then
                    sb.Append(ChrW(b))
                End If
            Next
            Return sb.ToString()
        End Function


    End Class
End Namespace
