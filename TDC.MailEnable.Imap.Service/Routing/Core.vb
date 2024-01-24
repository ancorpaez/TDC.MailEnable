Imports System.Net
Imports System.Net.Sockets
Imports TDC.MailEnable.Core

Namespace Routing
    Module Core
        'Private ReadOnly listaBlanca As New List(Of String) From {"127.0.0.1"} ' Puedes agregar direcciones IP permitidas aquí
        Private WithEvents EscuchadorImap As New Bucle.Bucle
        Private WithEvents EscuchadorImapSsl As New Bucle.Bucle

        Private imapListener As New TcpListener(IPAddress.Any, 144)
        Private imapSslListener As New TcpListener(IPAddress.Any, 994)
        Private servidorImap As New IPEndPoint(IPAddress.Parse("127.0.0.1"), 143)
        Private servidorImapSsl As New IPEndPoint(IPAddress.Parse("127.0.0.1"), 993)
        Private WithEvents EventosConexionCliente As Cliente

        'Public Clientes As New BDD.IMAPCorrectas
        'Public Rechazados As New BDD.IMAPBaneadas
        Public Conexiones As New Collections.Concurrent.ConcurrentDictionary(Of String, Cliente)
        Public ActualizarConexionesActivas As Func(Of String) = Nothing
        'Sub Main()

        '    imapListener.Start()
        '    imapSslListener.Start()

        '    Console.WriteLine("Servidor IMAP escuchando en los puertos 143 y 993...")

        '    EscuchadorImap.Intervalo = 10
        '    EscuchadorImap.Inicia()
        '    EscuchadorImapSsl.Intervalo = 10
        '    EscuchadorImapSsl.Inicia()
        'End Sub
        Private Sub EscuchadorImap_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles EscuchadorImap.IBucle_Bucle
            Dim NuevoCliente As Cliente = Nothing
            If FiltrarCliente(imapListener, servidorImap, NuevoCliente) Then
                If Not IsNothing(NuevoCliente) Then
                    Conexiones.TryAdd(NuevoCliente.Cliente.ToString, NuevoCliente)
                    AddHandler NuevoCliente.AlCerrarConexion, AddressOf EventosConexionCliente_AlCerrarConexion
                End If
            End If
        End Sub

        Private Sub EscuchadorImapSsl_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles EscuchadorImapSsl.IBucle_Bucle
            Dim NuevoCliente As Cliente = Nothing
            If FiltrarCliente(imapSslListener, servidorImapSsl, NuevoCliente) Then
                If Not IsNothing(NuevoCliente) Then
                    AddHandler NuevoCliente.AlCerrarConexion, AddressOf EventosConexionCliente_AlCerrarConexion
                End If
            End If
        End Sub

        Private Function FiltrarCliente(Escucha As TcpListener, Servidor As IPEndPoint, ByRef Cliente As Cliente) As Boolean
            Try
                If Escucha.Pending() Then
                    Dim CrearCliente As New Cliente(Escucha.AcceptSocket, Servidor)
                    'If Not IsNothing(CrearCliente.Origen) Then
                    '    Dim Key As String = CrearCliente.Cliente.Address.ToString
                    '    Dim Value As Integer? = 1
                    '    If Not Clientes.Contains("IP", Key) Then
                    '        Clientes.Add(New BDD.IMAPCorrectas.Rows With {
                    '                   .IP = Key,
                    '                   .Accesos = Value})
                    '    Else
                    '        Value = Clientes.Get(Clientes.GetItemIndex("IP", Key), "Accesos") + 1
                    '        If Not IsNothing(Value) Then Clientes.Update(Clientes.GetItemIndex("IP", Key), "Accesos", Value)
                    '    End If
                    '    Cliente = CrearCliente
                    '    If Not Conexiones.ContainsKey(Cliente.Cliente.ToString) Then
                    '        Conexiones.TryAdd(Cliente.Cliente.ToString, Cliente)
                    '    End If
                    '    If Not IsNothing(ActualizarConexionesActivas) Then ActualizarConexionesActivas()
                    'Else
                    '    Dim Key As String = CrearCliente.Cliente.Address.ToString
                    '    Dim Value As Integer = 1
                    '    If Not Rechazados.Contains("IP", Key) Then
                    '        Rechazados.Add(New BDD.IMAPBaneadas.Rows With {
                    '                   .IP = Key,
                    '                   .Intentos = Value})
                    '    Else
                    '        Value = Rechazados.Get(Rechazados.GetItemIndex("IP", Key), "Intentos") + 1
                    '        If Not IsNothing(Value) Then Rechazados.Update(Rechazados.GetItemIndex("IP", Key), "Intentos", Value)
                    '    End If
                    '    CrearCliente.Dispose()
                    '    If Not IsNothing(ActualizarConexionesActivas) Then ActualizarConexionesActivas()
                    '    Return False
                    'End If

                End If
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Private Sub EventosConexionCliente_AlCerrarConexion(Cliente As Cliente) Handles EventosConexionCliente.AlCerrarConexion
            If Not IsNothing(Cliente.Origen) Then
                If Conexiones.ContainsKey(Cliente.Cliente.ToString) Then
                    Conexiones.TryRemove(Cliente.Cliente.ToString, Cliente)
                End If
            End If
            If Not IsNothing(ActualizarConexionesActivas) Then ActualizarConexionesActivas()
        End Sub


    End Module
End Namespace