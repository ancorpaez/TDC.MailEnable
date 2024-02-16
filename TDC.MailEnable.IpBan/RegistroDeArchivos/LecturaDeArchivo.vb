Imports System.IO
Imports System.Threading
Imports Microsoft.VisualBasic.Logging
Imports TDC.MailEnable.Core
Imports TDC.MailEnable.Core.GeoLocalizacion
Imports TDC.MailEnable.IpBan.MailEnableLog
Imports System.Text.RegularExpressions

Namespace RegistroDeArchivos
    Public Class LecturaDeArchivo
        Private WithEvents Lector As New Bucle.Bucle
        'Private IndexLinea As Integer = 0
        'Filtros.Add(New Tuple(Of Integer, List(Of String))(EnumTipoComparacion.Cualquiera, New List(Of String) From {"Uno", "Dos"}))
        ''' <summary>
        ''' Integer, Tipo de comparacion (Cualquier coincidencia del List, Todo el List)
        ''' Integer, Numero de Concidencias por IP
        ''' List, Comparaciones del Filtro
        ''' </summary>
        Public Filtros As New List(Of Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura)))
        Public Property ObtenerIp As Func(Of String, String)

        Private Coincidentes As New Collections.Concurrent.ConcurrentDictionary(Of String, Integer)

        Private Bloqueo As New ManualResetEvent(False)
        Public FiltroIp As New Concurrent.ConcurrentBindingList(Of String)

        Public Total As Integer = 0
        Public Index As Integer = 0
        Public Enum EnumEstado
            Iniciando
            Analizando
            Analizado
        End Enum
        Public Estado As EnumEstado = EnumEstado.Iniciando

        Public Enum EnumTipoComparacion
            Cualquiera
            Todo
        End Enum

        Private Archivo As String


        Public Sub New(Archivo As String)

            Try
                'Identificador
                Me.Archivo = Archivo

                'Establecer una Memoria de Archivo
                If Not FileMemory.ContainsKey(Archivo) Then FileMemory.TryAdd(Archivo, New Cls_FileMemory)

                'Cargar el Archivo en Memoria
                Using Cargar As StreamReader = New IO.StreamReader(IO.File.Open(Archivo, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite))
                    Dim Linea As String
                    Dim Index As Integer = 0
                    Do
                        Linea = Cargar.ReadLine
                        If Not String.IsNullOrEmpty(Linea) Then
                            FileMemory(Archivo).Lines.TryAdd(Index, Linea)
                        End If
                        Index += 1
                    Loop While Not String.IsNullOrEmpty(Linea)
                End Using


            Catch ex As Exception

            End Try

            'Aplicar configuracion de los Bucles
            If IsNumeric(Configuracion.TIMER_LECTURA) Then Lector.Intervalo = Configuracion.TIMER_LECTURA Else Lector.Intervalo = 1
        End Sub

        Private Sub Lector_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Lector.IBucle_Bucle
            Try
                If IsNumeric(Configuracion.TIMER_LECTURA) Then Lector.Intervalo = Configuracion.TIMER_LECTURA Else Lector.Intervalo = 1
                'If IndexLinea < Lineas.Count Then
                If Not FileMemory.ContainsKey(Archivo) Then
                    Estado = EnumEstado.Analizado
                    Lector.Detener()
                    Exit Sub
                End If
                If FileMemory(Archivo).Line <= FileMemory(Archivo).Lines.Count AndAlso FileMemory(Archivo).Lines.ContainsKey(FileMemory(Archivo).Line) Then
                    Estado = EnumEstado.Analizando
                    If Not IsNothing(Filtros) Then
                        'Si coincide cualquiera de los Filtros almacenados.
                        If Filtros.Any(Function(Filtro) VerificarFiltro(Filtro, FileMemory(Archivo).Lines(FileMemory(Archivo).Line))) Then

                            'Solicitar la IP al Nucleo central
                            Dim Ip As String = ObtenerIp(FileMemory(Archivo).Lines(FileMemory(Archivo).Line))
                            If Ip <> "0.0.0.0" Then
                                Try
                                    'Testear que es una IPV4 Real, Si no es IPV4 desecha las comprobaciones
                                    Ip = Net.IPAddress.Parse(Ip).ToString
                                    If Net.IPAddress.Parse(Ip).AddressFamily = Net.Sockets.AddressFamily.InterNetworkV6 Then Ip = ""
                                Catch ex As Exception
                                    Ip = ""
                                End Try
                            Else
                                Ip = ""
                            End If

                            'Geolocalizar  la IP
                            If Not String.IsNullOrEmpty(Ip) Then
                                Dim Geolocalizar As New IpInfo
                                Dim Pais As String = Geolocalizar.Geolocalizar(Ip, Mod_Core.Geolocalizador)
                                Dim GeolocalizarID As Integer = 0
                                If Pais = "ES" OrElse Pais = "ERR" Then GeolocalizarID = 1

                                'Banear la IP (Evita Bloquear Ip[ES][ERR]) Comprueba la Bandera (GeolocalizarID, 0(Bloquea) o 1(No bloquea))
                                If GeolocalizarID = 0 Then If Not FiltroIp.Contains(Ip) Then FiltroIp.Add(Ip)
                            End If

                            'Consultar estado de logins del MailBox
                            For Each ConfFiltro In Filtros
                                'Si algun Filtro debe comprobar el MailBox
                                If ConfFiltro.Item3 Then
                                    Dim MailBox = ExtraerEmails(FileMemory(Archivo).Lines(FileMemory(Archivo).Line))
                                    Dim Coincidencias As Integer = ConfFiltro.Item2
                                    If Not String.IsNullOrEmpty(Ip) AndAlso Not String.IsNullOrEmpty(MailBox) Then
                                        If FileMemory(Archivo).MailBoxLogin.Exist(MailBox) AndAlso FileMemory(Archivo).MailBoxLogin.Count(MailBox) >= Coincidencias Then
                                            For Each IpBox In FileMemory(Archivo).MailBoxLogin.Get(MailBox)
                                                If Not String.IsNullOrEmpty(IpBox) Then
                                                    Dim Geolocalizar As New IpInfo
                                                    Dim Pais As String = Geolocalizar.Geolocalizar(IpBox, Mod_Core.Geolocalizador)
                                                    Dim GeolocalizarID As Integer = 0
                                                    If Pais = "ES" OrElse Pais = "ERR" Then GeolocalizarID = 1

                                                    'Banear la IP (Evita Bloquear Ip[ES][ERR]) Comprueba la Bandera (GeolocalizarID, 0(Bloquea) o 1(No bloquea))
                                                    If GeolocalizarID = 0 Then If Not FiltroIp.Contains(IpBox) Then FiltroIp.Add(IpBox)
                                                End If
                                            Next
                                        End If
                                    End If
                                End If
                            Next
                        End If

                    End If
                    'Informa en el avance de lectura
                    'RaiseEvent Progreso(FileMemory(Archivo).Line + 1, FileMemory(Archivo).Lines.Count)
                    Total = FileMemory(Archivo).Lines.Count
                    Index = FileMemory(Archivo).Line + 1

                    'Avanza en el conteo de lineas procesadas
                    FileMemory(Archivo).Line += 1

                Else
                    Estado = EnumEstado.Analizado
                    Lector.Detener()
                    Bloqueo.Set()
                End If
            Catch ex As Exception
                'Stop
            End Try

        End Sub
        Private Function VerificarFiltro(Filtro As Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura)), Linea As String) As Boolean
            Dim TipoComparacion As EnumTipoComparacion = Filtro.Item1
            Dim NumeroCoincidentes As Integer = Filtro.Item2
            Dim ComprobarMailBox As Boolean = Filtro.Item3
            Dim Comparaciones As List(Of FiltroLectura) = Filtro.Item4
            Dim Coincide As Boolean

            Select Case TipoComparacion
                Case EnumTipoComparacion.Todo
                    Coincide = True
                    For Each Comparador In Comparaciones
                        Select Case Comparador.Condicion
                            Case FiltroLectura.EnumCondicion.Contiene
                                If Not Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = False
                            Case FiltroLectura.EnumCondicion.NoContiene
                                If Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = False
                        End Select
                    Next

                Case EnumTipoComparacion.Cualquiera
                    Coincide = False
                    For Each Comparador In Comparaciones
                        Select Case Comparador.Condicion
                            Case FiltroLectura.EnumCondicion.Contiene
                                If Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = True
                            Case FiltroLectura.EnumCondicion.NoContiene
                                If Not Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = True
                        End Select
                    Next
            End Select

            If Coincide Then
                'Si no supera ComprobarMailBox establecemos NumeroCoincidentes a 0
                'Para banear la IP Automaticamente
                If ComprobarMailBox Then
                    Dim FullMailbox As String = ExtraerEmails(Linea)
                    If Not String.IsNullOrEmpty(FullMailbox) Then
                        Dim PostOffice As String = FullMailbox.Split("@")(1)
                        Dim MailBox As String = FullMailbox.Split("@")(0)
                        'Si no existe el PostOffice o el MailBox banea la IP
                        If Not Mod_Core.PostOfficesCenter.PostOffices.Contains(PostOffice) Then
                            'No existe el PostOffice
                            NumeroCoincidentes = 0
                        Else
                            If Not Mod_Core.PostOfficesCenter.PostOffice(PostOffice).MailBoxes.ContainsKey(MailBox) Then
                                'No existe el MailBox
                                NumeroCoincidentes = 0
                            Else
                                'Establece coincidencias por MailBox
                                If Not FileMemory(Archivo).MailBoxLogin.Exist(FullMailbox) Then FileMemory(Archivo).MailBoxLogin.Add(FullMailbox)
                                FileMemory(Archivo).MailBoxLogin.AddIp(FullMailbox, ObtenerIp(Linea))
                            End If
                        End If
                    Else
                        NumeroCoincidentes = 0
                    End If

                    'Establece coincidencias por MailBox
                    If NumeroCoincidentes > 0 AndAlso Not String.IsNullOrEmpty(FullMailbox) Then
                        If FileMemory(Archivo).MailBoxLogin.Exist(FullMailbox) AndAlso FileMemory(Archivo).MailBoxLogin.Count(FullMailbox) >= NumeroCoincidentes Then
                            NumeroCoincidentes = 0
                        End If
                    End If
                End If

                'Comprueba las coincidencias del filtro establecidas
                If NumeroCoincidentes > 0 Then
                    Dim oIp As String = ObtenerIp(Linea)
                    If Not Me.Coincidentes.ContainsKey(oIp) Then Me.Coincidentes.TryAdd(oIp, 1) Else Me.Coincidentes.TryUpdate(oIp, Me.Coincidentes(oIp) + 1, Me.Coincidentes(oIp))
                    If Me.Coincidentes(oIp) > NumeroCoincidentes Then Coincide = True Else Coincide = False
                End If


            End If

            Return Coincide
        End Function

        Public Sub Escanear()
            Lector.Inicia()
            Bloqueo.WaitOne()
        End Sub

        Private Function ExtraerEmails(texto As String) As String
            Dim emails As New List(Of String)
            Dim regex As New Regex("\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b")

            Dim coincidencias As MatchCollection = regex.Matches(texto)

            For Each coincidencia As Match In coincidencias
                emails.Add(coincidencia.Value)
            Next

            If emails.Count > 0 Then Return emails.First Else Return ""
        End Function

    End Class
End Namespace