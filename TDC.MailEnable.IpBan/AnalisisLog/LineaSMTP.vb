Namespace AnalisisLog
    Public Class LineaSMTP
        'Desarrollo para comprobar si conviene trabajar con Celdas.
        Inherits Linea
        '#Fields: date time c-ip agent account s-ip s-port cs-method cs-uristem cs-uriquery s-computername sc-bytes cs-bytes cs-username

        Private Elementos() As String = {}
        Private Linea As String = String.Empty

        Public esLogin As Boolean = False
        Public esAutentificado As Boolean = False
        Public PostOffice As String = String.Empty
        Public MailBox As String = String.Empty
        Public Contraseña As String = String.Empty

        Public Sub New(Linea As String)
            Me.Linea = Linea
            Elementos = Linea.Split(" ")
            Try
                If Elementos.Count = 15 AndAlso Not Elementos.First.ToLower.Contains("fields") Then
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
                End If
            Catch ex As Exception
                Stop
            End Try

            'If esLogin Then Stop
        End Sub


        Public Property Fecha As DateTime
        Public Property Hora As TimeSpan
        Public Property ClienteIP As String
        Public Property Agente As String
        Public Property Cuenta As String
        Public Property ServidorIP As String
        Public Property PuertoServidor As Integer
        Public Property MetodoComando As String
        Private _UriStem As String = String.Empty
        Public Property UriStem As String
            Get
                Return _UriStem
            End Get
            Set(value As String)
                _UriStem = value
                If MetodoComando = "AUTH" Then
                    If Not _UriStem = "AUTH+LOGIN" AndAlso Not _UriStem = "{blank}" Then
                        Contraseña = "*"
                        Try
                            Contraseña = Text.Encoding.UTF8.GetString(Convert.FromBase64String(_UriStem))
                        Catch ex As Exception
                            Stop
                        End Try
                    End If
                End If
            End Set
        End Property
        Private _UriQuery As String = String.Empty
        Public Property UriQuery As String
            Get
                Return _UriQuery
            End Get
            Set(value As String)
                _UriQuery = value

                If MetodoComando = "AUTH" Then
                    esLogin = True
                    If _UriQuery.Contains("+") Then
                        Select Case CInt(value.Split("+").First)
                            Case 235 'Autentificado
                                esAutentificado = True
                            Case 334 '?
                                Dim DecodeUri As String = Text.Encoding.UTF8.GetString(Convert.FromBase64String(_UriQuery.Split("+")(1))).Trim("<", ">")
                                MailBox = DecodeUri

                                If DecodeUri.Contains("@") Then
                                    PostOffice = DecodeUri.Split("@")(1)
                                Else
                                    PostOffice = DecodeUri
                                End If
                            Case 535 'Invalid Password
                                'Nada
                            Case Else
                                Stop
                        End Select
                    Else
                        Stop
                    End If




                End If
            End Set
        End Property
        Public Property NombreServidor As String
        Public Property BytesServidor As Integer
        Public Property BytesCliente As Integer
        Private _Usuario As String = String.Empty
        Public Property Usuario As String
            Get
                Return _Usuario
            End Get
            Set(value As String)
                _Usuario = value
                If MetodoComando = "AUTH" AndAlso MailBox = String.Empty Then
                    PostOffice = Cuenta
                    If Usuario.Contains("@") Then MailBox = Usuario Else MailBox = $"{_Usuario}@{Cuenta}"
                End If
            End Set
        End Property


    End Class
End Namespace
