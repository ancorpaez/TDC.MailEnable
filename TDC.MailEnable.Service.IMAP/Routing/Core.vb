Imports System.Net
Imports System.Net.Sockets
Imports TDC.MailEnable.Core
Imports TDC.MailEnable.Core.BDD

Namespace Routing
    Module Core
        'Private ReadOnly listaBlanca As New List(Of String) From {"127.0.0.1"} ' Puedes agregar direcciones IP permitidas aquí
        Private WithEvents EscuchadorImap As New Bucle.DoBucle
        Private WithEvents EscuchadorImapSsl As New Bucle.DoBucle

        Public imapListener As New TcpListener(IPAddress.Any, 144)
        Public imapSslListener As New TcpListener(IPAddress.Any, 994)
        Private PuertoservidorImap As Integer = 143
        Private PuertoservidorImapSsl As Integer = 993
        Private WithEvents EventosConexionCliente As Cliente

        Public Clientes As New BDD.IMAPCorrectas
        Public Rechazados As New BDD.IMAPBaneadas
        Public Conexiones As New Collections.Concurrent.ConcurrentDictionary(Of String, Cliente)
        Public ActualizarConexionesActivas As Func(Of String) = Nothing

        'Lista Unica IpBan (Se Obtiene del programa Principal) Mediante Pipe
        Public IpBaneadas As Concurrent.ConcurrentBindingList(Of String) = Nothing
        Public WithEvents IpBaneadasPipe As Pipe.ClientPipe
        Public Enum EnumEstadoIpBan
            Esperando
            Iniciando
            Iniciada
            Actualizando
            [Error]
        End Enum
        Public IpBaneadasEstado As EnumEstadoIpBan = EnumEstadoIpBan.Esperando


        Sub Main()

            'Habilitar  traduccion de direcciones
            imapListener.AllowNatTraversal(True)
            imapSslListener.AllowNatTraversal(True)

            'Iniciar Listeners
            imapListener.Start()
            imapSslListener.Start()

            'Cerrar Listeners
            AddHandler AppDomain.CurrentDomain.ProcessExit, AddressOf DetenerListeners

            Console.WriteLine("Servidor IMAP escuchando en los puertos " & imapListener.LocalEndpoint.ToString & " y " & imapSslListener.LocalEndpoint.ToString & "...")

            EscuchadorImap.Intervalo = 10
            EscuchadorImap.Iniciar()
            EscuchadorImapSsl.Intervalo = 10
            EscuchadorImapSsl.Iniciar()
        End Sub
        Private Sub EscuchadorImap_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles EscuchadorImap.Background
            'Intento de proteger el Bucle de errores Inesperados
            Try
                Dim NuevoCliente As Cliente = Nothing
                'Comprueba que se acepto la conexion
                If FiltrarCliente(imapListener, PuertoservidorImap, NuevoCliente) Then
                    'Comprueba que no hubo errores en la conexion
                    If Not IsNothing(NuevoCliente) Then
                        Conexiones.TryAdd(NuevoCliente.Cliente.ToString, NuevoCliente)
                        'Crear Delegado para Limpiar recursos de la Conexion
                        AddHandler NuevoCliente.AlCerrarConexion, AddressOf EventosConexionCliente_AlCerrarConexion
                    End If
                End If
            Catch ex As Exception
                Stop
            End Try
        End Sub

        Private Sub EscuchadorImapSsl_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles EscuchadorImapSsl.Background
            'Intento de proteger el Bucle de errores Inesperados
            Try
                Dim NuevoCliente As Cliente = Nothing
                'Comprueba que se acepto la conexion
                If FiltrarCliente(imapSslListener, PuertoservidorImapSsl, NuevoCliente) Then
                    'Comprueba que no hubo errores en la conexion
                    If Not IsNothing(NuevoCliente) Then
                        'Crear Delegado para Limpiar recursos de la Conexion
                        AddHandler NuevoCliente.AlCerrarConexion, AddressOf EventosConexionCliente_AlCerrarConexion
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        ''' <summary>
        ''' Devuelve True/False al Aceptar/Rechazar la conexion del Socket
        ''' </summary>
        ''' <param name="Escucha">Listeners TCP (Seguro y No Seguro)</param>
        ''' <param name="PuertoServidor">Puerto real del servicio IMAP</param>
        ''' <param name="Cliente">Clase Personalizada que Filtra el Socket</param>
        ''' <returns></returns>
        Private Function FiltrarCliente(Escucha As TcpListener, PuertoServidor As Integer, ByRef Cliente As Cliente) As Boolean
            Try
                If Escucha.Pending() Then

                    'Filtra la conexion (Crea un .Origen Vacio al Bloquear la Conexion)
                    Dim CrearCliente As New Cliente(Escucha.AcceptSocket, PuertoServidor)

                    If Not IsNothing(CrearCliente.Destino) Then

                        '*** CONEXIONES ACEPTADAS

                        'Eventos
                        'AddHandler CrearCliente.AlCerrarConexion, AddressOf EventosConexionCliente_AlCerrarConexion

                        'Identificadores
                        Dim Key As String = CrearCliente.Cliente.Address.ToString
                        Dim Value As Integer? = 1

                        'Lista de Clientes
                        If Not Clientes.Contains("IP", Key) Then

                            Dim Geolocalizar As New GeoLocalizacion.IpInfo
                            Clientes.Add(New BDD.IMAPCorrectas.Rows With {
                                       .IP = Key,
                                       .Accesos = Value,
                                       .Pais = "ES"}) ' Geolocalizar.Geolocalizar(Key)})
                        Else
                            Value = Clientes.Get(Clientes.GetItemIndex("IP", Key), "Accesos") + 1
                            If Not IsNothing(Value) Then Clientes.Update(Clientes.GetItemIndex("IP", Key), "Accesos", Value)
                        End If

                        'Devolucion del cliente (Socket)
                        Cliente = CrearCliente

                        'Lista de Conexiones Activas
                        If Not Conexiones.ContainsKey(Cliente.Cliente.ToString) Then
                            Conexiones.TryAdd(Cliente.Cliente.ToString, Cliente)
                        End If

                        'Delegado del Interface para visualizar las conexiones
                        If Not IsNothing(ActualizarConexionesActivas) Then ActualizarConexionesActivas()

                    Else

                        '*** CONEXIONES RECHAZADAS

                        'Identificadores
                        Dim Key As String = CrearCliente.Cliente.Address.ToString
                        Dim Value As Integer = 1

                        'Lista de Rechazadas
                        If Not Rechazados.Contains("IP", Key) Then

                            Dim Geolocalizar As New GeoLocalizacion.IpInfo

                            Rechazados.Add(New BDD.IMAPBaneadas.Rows With {
                                       .IP = Key,
                                       .Intentos = Value,
                                       .Pais = "ES"}) 'Geolocalizar.Geolocalizar(Key)})
                        Else
                            Value = Rechazados.Get(Rechazados.GetItemIndex("IP", Key), "Intentos") + 1
                            If Not IsNothing(Value) Then Rechazados.Update(Rechazados.GetItemIndex("IP", Key), "Intentos", Value)
                        End If

                        'Eliminar Recursos
                        CrearCliente = Nothing

                        'Delegado del Interface para visualizar las conexiones
                        If Not IsNothing(ActualizarConexionesActivas) Then ActualizarConexionesActivas()
                        Return False
                    End If
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Private Sub EventosConexionCliente_AlCerrarConexion(Cliente As Cliente) Handles EventosConexionCliente.AlCerrarConexion
            Try
                If Not IsNothing(Cliente.Origen) Then
                    If Conexiones.ContainsKey(Cliente.Cliente.ToString) Then
                        If Not Conexiones.TryRemove(Cliente.Cliente.ToString, Cliente) Then
                            Stop
                        End If
                        Cliente.Dispose()
                    End If
                End If
                If Not IsNothing(ActualizarConexionesActivas) Then ActualizarConexionesActivas()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub IpBaneadasPipe_AlObtenerLaLista(Lista As List(Of String)) Handles IpBaneadasPipe.AlObtenerLaLista
            'Inicalizar Variable
            If IsNothing(IpBaneadas) Then
                IpBaneadasEstado = EnumEstadoIpBan.Iniciando
                IpBaneadas = New Concurrent.ConcurrentBindingList(Of String)
            Else
                IpBaneadasEstado = EnumEstadoIpBan.Actualizando
            End If

            'Actualizar Variable
            Try
                'Actualizar la lista
                For Each Ip In Lista
                    If Not IpBaneadas.Contains(Ip) Then IpBaneadas.Add(Ip)
                Next

                'Buscar Eliminaciones en caliente
                Dim NoCoincidentes As New List(Of String)
                For Each Ip In IpBaneadas
                    If Not Lista.Contains(Ip) Then
                        NoCoincidentes.Add(Ip)
                    End If
                Next

                'Eliminar Ip no Baneadas en Caliente
                If NoCoincidentes.Count > 0 Then
                    For Each Ip In NoCoincidentes
                        IpBaneadas.Remove(Ip)
                    Next
                End If

                IpBaneadasEstado = EnumEstadoIpBan.Iniciada
            Catch ex As Exception
                IpBaneadasEstado = EnumEstadoIpBan.Error
                IpBaneadas = Nothing
            End Try
        End Sub

        'Llamada el procedimiento al cerrar la aplicacion
        Private Sub DetenerListeners()
            Try
                imapListener.Stop()
                imapSslListener.Stop()
            Catch ex As Exception
            End Try
        End Sub

    End Module
End Namespace