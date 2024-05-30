Imports System.IO
Imports System.Threading
Imports TDC.MailEnable.Core
Imports TDC.MailEnable.Core.GeoLocalizacion
Imports TDC.MailEnable.IpBan.MailEnable
Imports System.Text.RegularExpressions
Imports System.Web.UI
Imports TDC.MailEnable.IpBan.Interfaz
Imports System.Net

'Esta clase Analiza Archivos Log en busqueda de Patrones configurables segun el Filtro aplicado
Namespace AnalisisLog
    Public Class Archivo
        Inherits Linea
        Implements IDisposable

        'Bucle BackGround y ForeGround
        Private WithEvents Lector As Bucle.DoBucle
        'Lista con los Filtros a comprobar por Linea
        Public Filtros As New List(Of Filtro)
        'Solicita la ip al Hilo principal donde estan agrupadas las diferentens funciones para realizarlo.
        Public Property ObtenerIp As Func(Of String, String)
        'Almacena los MailBox a los que accedio la IP
        Private IpMailBoxLogins As New Collections.Concurrent.ConcurrentDictionary(Of String, String)
        'Evita la continuacion del codigo hasta haber procesado todas las lineas del archivo
        Private Bloqueo As New ManualResetEvent(False)
        'Almacena todas las Ip previstas para ser Baneadas
        Public FiltroIp As New Concurrent.ConcurrentBindingList(Of String)
        'Punteros de control para la lectura del archivo
        Public Total As Integer = 0
        Public Index As Integer = 0
        'Estados del Analizador
        Public Enum EnumEstado
            Iniciando
            Analizando
            Analizado
        End Enum
        Public Estado As EnumEstado = EnumEstado.Iniciando
        'Archivo a procesar
        Private Archivo As String
        'Implementdacion IDisposable
        Private disposedValue As Boolean

        Public Sub New(Archivo As String)

            Try
                'Identificador (FullName Archivo)
                Me.Archivo = Archivo

                'Crear o Enlazar Bucle del Control General de Bucles
                If IpBanForm.InvokeRequired Then IpBanForm.Invoke(Sub() Lector = Bucle.GetOrCreate(Archivo)) Else Lector = Bucle.GetOrCreate(Archivo)
                AddHandler Lector.BackGround, AddressOf Lector_Background
                AddHandler Lector.ForeGround, AddressOf Lector_Foreground
                AddHandler Lector.EndGround, AddressOf Lector_Endground

                'Establecer una Memoria de Archivo
                If Not ArchivosEnMemoria.Archivos.ContainsKey(Archivo) Then ArchivosEnMemoria.Archivos.TryAdd(Archivo, New ArchivosEnMemoria.Archivo)

                'Cargar el Archivo en Memoria
                Using Cargar As StreamReader = New IO.StreamReader(IO.File.Open(Archivo, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite))
                    Dim Linea As String = String.Empty
                    Dim Index As Integer = 0
                    Do
                        If Not ArchivosEnMemoria.Archivos(Archivo).Lines.ContainsKey(Index) Then

                            'Obtener la linea
                            Linea = Cargar.ReadLine
                            If Not String.IsNullOrEmpty(Linea) Then

                                'Cargar la linea
                                If Not ArchivosEnMemoria.Archivos(Archivo).Lines.TryAdd(Index, Linea) Then
                                    Console.WriteLine($"No se pudo cargar la línea{Index} del Archivo {Archivo}.")
                                End If
                            End If
                        Else

                            'Desechar la Linea
                            Cargar.ReadLine()
                            Linea = " "
                        End If

                        'Avanzar una línea
                        Index += 1
                    Loop While Not String.IsNullOrEmpty(Linea)
                End Using
                Total = ArchivosEnMemoria.Archivos(Archivo).Lines.Count

            Catch ex As Exception

            End Try

            'Aplicar configuracion de los Bucles
            If IsNumeric(MailEnable.Main.Configuracion.TIMER_LECTURA) Then Lector.Intervalo = MailEnable.Main.Configuracion.TIMER_LECTURA Else Lector.Intervalo = 1
        End Sub

        Private Sub Lector_Background(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs)
            Try
                'Establecer el punto más rapido en caso de falla de configuración
                If IsNumeric(MailEnable.Main.Configuracion.TIMER_LECTURA) Then Lector.Intervalo = MailEnable.Main.Configuracion.TIMER_LECTURA Else Lector.Intervalo = 1

                'Si el Control de Memoria no contiene el archivo detenemos el analizador.
                If Not ArchivosEnMemoria.Archivos.ContainsKey(Archivo) Then
                    Estado = EnumEstado.Analizado
                    Lector.Detener()
                    Exit Sub
                End If

                'Analizamos Linea por Linea
                If ArchivosEnMemoria.Archivos(Archivo).Line <= ArchivosEnMemoria.Archivos(Archivo).Lines.Count AndAlso ArchivosEnMemoria.Archivos(Archivo).Lines.ContainsKey(ArchivosEnMemoria.Archivos(Archivo).Line) Then
                    Estado = EnumEstado.Analizando
                    If Not IsNothing(Filtros) Then
                        'Analizamos la linea con cada Filtro
                        Dim Linea As String = ArchivosEnMemoria.Archivos(Archivo).Lines(ArchivosEnMemoria.Archivos(Archivo).Line)

                        For Each Filtro In Filtros
                            Dim Celdas As Linea = Nothing

                            'Deteccion por Celdas
                            Select Case Filtro.Key
                                Case FilterKeys.FilterKey.SMTPLoginFailNoMailBox, FilterKeys.FilterKey.SMTPLoginFailMailBox, FilterKeys.FilterKey.SMTPOutNoLogin, FilterKeys.FilterKey.SMTPMultipleDomainLogin
                                    'Celdas = New LineaSMTP(Linea)
                                Case FilterKeys.FilterKey.IMAPLoginFail, FilterKeys.FilterKey.IMAPMultipleDomainLogin
                                    'Celdas = New LineaIMAP(Linea)
                                Case FilterKeys.FilterKey.PopLoginFail
                                    'Celdas = New LineaPOP
                                Case Else
                                    'Stop
                            End Select

                            Select Case Filtro.DetectarCrossDomainLogin
                                'Filtro estandar True/False para Baneo de Ip
                                Case False
                                    'Establece el Tipo de Comparacion Simulando a (Todo(.All), Cualquiera(.Any))
                                    Dim TipoComparacion As Filtro.EnumTipoComparacion = Filtro.VerdaderoSi

                                    'Recoge los Strings a Comparar
                                    Dim Comparaciones As List(Of Coincidencia) = Filtro.Coincidencias

                                    'Establece si el Filtro Tiene Coincidencias
                                    Dim Coincide As Boolean = False

                                    'Establecer Coincidencia (Simula el .All o .Any)
                                    Select Case TipoComparacion
                                        Case Filtro.EnumTipoComparacion.Todo
                                            Coincide = True
                                            For Each Comparador In Comparaciones
                                                Select Case Comparador.Condicion
                                                    Case Coincidencia.EnumCondicion.Contiene
                                                        If Not Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = False
                                                    Case Coincidencia.EnumCondicion.NoContiene
                                                        If Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = False
                                                End Select
                                            Next

                                        Case Filtro.EnumTipoComparacion.Cualquiera
                                            Coincide = False
                                            For Each Comparador In Comparaciones
                                                Select Case Comparador.Condicion
                                                    Case Coincidencia.EnumCondicion.Contiene
                                                        If Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = True
                                                    Case Coincidencia.EnumCondicion.NoContiene
                                                        If Not Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = True
                                                End Select
                                            Next
                                    End Select

                                    'Si Coincide se examina la posibilidad de Baneo
                                    If Coincide Then
                                        'Ip Remota del cliente
                                        Dim Ip As String = ObtenerIp(Linea)
                                        'Verifica que sea IPv4
                                        If VerificarIpV4(Ip) Then
                                            'Obtenemos el Pais Asociado a la IP
                                            Dim Geolocalizar As New IpInfo
                                            Dim Pais As String = Geolocalizar.Geolocalizar(Ip, MailEnable.Geolocalizador)

                                            'Desecha los Paises Excentos al Baneo
                                            If Not ExclusionPais.Any(Function(Excento) Excento = Pais) Then

                                                'Almacena la Ip Remota o Suma en Contador de la Misma
                                                If Not ArchivosEnMemoria.Archivos(Archivo).Coincidentes.ContainsKey(Ip) Then ArchivosEnMemoria.Archivos(Archivo).Coincidentes.TryAdd(Ip, 1) Else ArchivosEnMemoria.Archivos(Archivo).Coincidentes(Ip) += 1

                                                'Bandera para saber si se debe Banear la IP
                                                Dim Banear As Boolean = False

                                                'Bandera para Saber si Banear el MailBox
                                                Dim BanearMailBox As Boolean = False

                                                'Establece cuantas repeticiones maximas se permiten antes de Banear
                                                Dim NumeroCoincidentes As Integer = Filtro.Repeteciones

                                                'Actualiza el numero de coincidencias maximo por pais (Defecto en su contra)
                                                If CoincidenciasPais.ContainsKey(Pais) AndAlso CoincidenciasPais(Pais).ContainsKey(Filtro.Key) Then NumeroCoincidentes = CoincidenciasPais(Pais)(Filtro.Key)

                                                'Establece si el Filtro debe contrastar la existencia del MailBox
                                                Dim ComprobarMailBox As Boolean = Filtro.VerificarMailBox

                                                'Inicializa FullMailBox (Se utiliza en Comprobacion(ComprobarMailBox) y Baneo(BanearMailBox))
                                                Dim FullMailbox As String = String.Empty


                                                'Si el Filtro solicita comprobar el MailBox
                                                If ComprobarMailBox Then

                                                    'Adquiere de forma Generica el MailBox de los Log especial para el SMTP
                                                    FullMailbox = ExtraerEmailGenerico(Linea)

                                                    'Corrige el Fallo de Regex
                                                    If FullMailbox.Contains("+") Then FullMailbox = FullMailbox.Replace(FullMailbox.Substring(0, FullMailbox.IndexOf("+") + 1), "")

                                                    'Adquiere el MailBox del Log IMAP
                                                    If String.IsNullOrEmpty(FullMailbox) Then FullMailbox = ExtraerEmailIMAP(Linea)
                                                    If FullMailbox.Contains("+") Then Stop

                                                    'Adquiere el MailBox del Log POP
                                                    If String.IsNullOrEmpty(FullMailbox) Then FullMailbox = ExtraerEmailPOP(Linea)
                                                    If FullMailbox.Contains("+") Then Stop

                                                    If Not String.IsNullOrEmpty(FullMailbox) Then
                                                        'Si existe el MailBox en la linea
                                                        Dim PostOffice As String = FullMailbox.Split("@")(1)
                                                        Dim MailBox As String = FullMailbox.Split("@")(0)
                                                        'Si no existe el PostOffice o el MailBox banea la IP
                                                        If Not MailEnable.PostOfficesCenter.PostOffices.Contains(PostOffice) Then
                                                            'No existe el PostOffice
                                                            Banear = True
                                                        ElseIf Not MailEnable.PostOfficesCenter.PostOffice(PostOffice).MailBoxes.ContainsKey(MailBox) Then
                                                            'No existe el MailBox
                                                            Banear = True
                                                        Else
                                                            'Existe el MailBox
                                                            Select Case Filtro.Key
                                                                Case FilterKeys.FilterKey.SMTPLoginFailMailBox
                                                                    Dim Get64Password As String = Linea.Split(" ")(8)
                                                                    If Not String.IsNullOrEmpty(Get64Password) Then
                                                                        Try
                                                                            'Registramos la Ip,MailBox y contraseña.
                                                                            Dim PasswordRecord As String = String.Empty
                                                                            PasswordRecord = Text.Encoding.UTF8.GetString(Convert.FromBase64String(Get64Password))
                                                                            If Not ArchivosEnMemoria.Archivos(Archivo).IpLoginsRecords.ContainsKey(Ip) Then ArchivosEnMemoria.Archivos(Archivo).IpLoginsRecords.TryAdd(Ip, New ArchivosEnMemoria.MailBoxLogins)
                                                                            ArchivosEnMemoria.Archivos(Archivo).IpLoginsRecords(Ip).Add(New ArchivosEnMemoria.MailBoxLogin With {.MailBox = FullMailbox, .Password = PasswordRecord})
                                                                        Catch ex As Exception
                                                                            'Preparado para el Futuro si otro Filtro requiere comprobar MailBox, para registrar la Ip,MailBox y contraseña
                                                                            Stop
                                                                        End Try
                                                                    End If

                                                                Case FilterKeys.FilterKey.IMAPLoginFail
                                                                    Dim PasswordRecord As String = String.Empty
                                                                    PasswordRecord = Linea.Split(" ")(10).Split("+").First
                                                                    If Not ArchivosEnMemoria.Archivos(Archivo).IpLoginsRecords.ContainsKey(Ip) Then ArchivosEnMemoria.Archivos(Archivo).IpLoginsRecords.TryAdd(Ip, New ArchivosEnMemoria.MailBoxLogins)
                                                                    ArchivosEnMemoria.Archivos(Archivo).IpLoginsRecords(Ip).Add(New ArchivosEnMemoria.MailBoxLogin With {.MailBox = FullMailbox, .Password = PasswordRecord})

                                                                Case FilterKeys.FilterKey.PopLoginFail
                                                                    Dim PasswordRecord As String = String.Empty
                                                                    PasswordRecord = Linea.Split(" ")(8).Split("+").Last
                                                                    If Not ArchivosEnMemoria.Archivos(Archivo).IpLoginsRecords.ContainsKey(Ip) Then ArchivosEnMemoria.Archivos(Archivo).IpLoginsRecords.TryAdd(Ip, New ArchivosEnMemoria.MailBoxLogins)
                                                                    ArchivosEnMemoria.Archivos(Archivo).IpLoginsRecords(Ip).Add(New ArchivosEnMemoria.MailBoxLogin With {.MailBox = FullMailbox, .Password = PasswordRecord})

                                                                Case Else
                                                                    Stop
                                                            End Select
                                                            'Establece coincidencias por MailBox
                                                            If Not ArchivosEnMemoria.Archivos(Archivo).MailBoxLogin.Exist(FullMailbox) Then ArchivosEnMemoria.Archivos(Archivo).MailBoxLogin.Add(FullMailbox)
                                                            ArchivosEnMemoria.Archivos(Archivo).MailBoxLogin.AddIp(FullMailbox, Ip)

                                                            'Comprobamos el Limite del Filtro (No del Pais), MailBox
                                                            If ArchivosEnMemoria.Archivos(Archivo).MailBoxLogin.Exist(FullMailbox) AndAlso ArchivosEnMemoria.Archivos(Archivo).MailBoxLogin.Count(FullMailbox) >= Filtro.Repeteciones Then
                                                                'El MailBox supera el limite de Coincidencias del Filtro
                                                                Banear = True
                                                                BanearMailBox = True
                                                                'Comprobamos el Limite por Pais (No del Filtro), Ip
                                                            ElseIf ArchivosEnMemoria.Archivos(Archivo).Coincidentes(Ip) >= NumeroCoincidentes Then
                                                                Banear = True
                                                            End If

                                                        End If
                                                    Else
                                                        'Solicita verificar MailBox pero no existe en la linea o esta incompleto
                                                        Banear = True
                                                    End If
                                                Else
                                                    'No requiere Comprobar MailBox se comprueba el limite de Concidencias
                                                    If ArchivosEnMemoria.Archivos(Archivo).Coincidentes(Ip) > NumeroCoincidentes Then Banear = True
                                                End If


                                                If Banear Then
                                                    Dim FiltroStringOut As String = "Filtro: {0,22} | {1,15} | {2,40} | {3,2} | IpCount:{4,3} | MailCount:{5,3} | Límite:{6,2} | Pwd:{7,21} {8}"
                                                    If BanearMailBox Then
                                                        'Solicita Banear el MailBox
                                                        If ArchivosEnMemoria.Archivos(Archivo).MailBoxLogin.Exist(FullMailbox) Then
                                                            'Existe el MailBox Banea todas Las IP Que Intentaron Loguear
                                                            For Each IpBox In ArchivosEnMemoria.Archivos(Archivo).MailBoxLogin.Get(FullMailbox)
                                                                If Not String.IsNullOrEmpty(IpBox) Then
                                                                    'Obtiene los datos Necesario por IP {Coincidencias por Pais}
                                                                    Dim IpGeolocalizar As New IpInfo
                                                                    Dim IpPais As String = IpGeolocalizar.Geolocalizar(IpBox, MailEnable.Geolocalizador)
                                                                    Dim IpCoincidencias As Integer = Filtro.Repeteciones

                                                                    'Establece las Coincidencias por Pais
                                                                    If CoincidenciasPais.ContainsKey(IpPais) AndAlso CoincidenciasPais(IpPais).ContainsKey(Filtro.Key) Then IpCoincidencias = CoincidenciasPais(IpPais)(Filtro.Key)

                                                                    'Si el Numero de Logins del MailBox Supera o Iguala al Pais Baneamos
                                                                    If ArchivosEnMemoria.Archivos(Archivo).MailBoxLogin.Count(FullMailbox) > IpCoincidencias Then
                                                                        If Not FiltroIp.Contains(IpBox) Then FiltroIp.Add(IpBox)
                                                                        'Escaneamos los Logins asociados a la IP y el MailBox
                                                                        If ArchivosEnMemoria.Archivos(Archivo).IpLoginsRecords.ContainsKey(IpBox) Then
                                                                            For Each LoginRecord In ArchivosEnMemoria.Archivos(Archivo).IpLoginsRecords(IpBox).Items
                                                                                If LoginRecord.MailBox = FullMailbox Then
                                                                                    'Imprimimos las coincidencias
                                                                                    LOG.Logs(LOG.MemoryLOG.EnumLogs.General).Lineas.Enqueue(String.Format(FiltroStringOut, Filtro.Key.ToString, IpBox, FullMailbox, IpPais, ArchivosEnMemoria.Archivos(Archivo).Coincidentes(IpBox), ArchivosEnMemoria.Archivos(Archivo).MailBoxLogin.Count(FullMailbox), IpCoincidencias, LoginRecord.Password, vbNewLine))
                                                                                End If
                                                                            Next
                                                                        Else
                                                                            LOG.Logs(LOG.MemoryLOG.EnumLogs.General).Lineas.Enqueue(String.Format(FiltroStringOut, Filtro.Key.ToString, IpBox, FullMailbox, IpPais, ArchivosEnMemoria.Archivos(Archivo).Coincidentes(IpBox), ArchivosEnMemoria.Archivos(Archivo).MailBoxLogin.Count(FullMailbox), IpCoincidencias, "*", vbNewLine))
                                                                        End If
                                                                        'LOG.Logs(LOG.MemoryLOG.EnumLogs.General).Lineas.Enqueue(String.Format(FiltroStringOut, Filtro.Key.ToString, IpBox, FullMailbox, IpPais, ArchivoEnMemoria.FileMemory(Archivo).Coincidentes(IpBox), ArchivoEnMemoria.FileMemory(Archivo).MailBoxLogin.Count(FullMailbox), IpCoincidencias, vbNewLine))
                                                                    End If
                                                                End If
                                                            Next
                                                        End If
                                                    ElseIf Not BanearMailBox Then
                                                        'Solicita Banear IP
                                                        If Not FiltroIp.Contains(Ip) Then FiltroIp.Add(Ip)
                                                        LOG.Logs(LOG.MemoryLOG.EnumLogs.General).Lineas.Enqueue(String.Format(FiltroStringOut, Filtro.Key.ToString, Ip, FullMailbox, Pais, ArchivosEnMemoria.Archivos(Archivo).Coincidentes(Ip), "0", NumeroCoincidentes, "*", vbNewLine))
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If

                                'Filtro Especial para detectar Login Correcto entre Dominios
                                Case True
                                    Dim Coincidir As Coincidencia.EnumCondicion = Filtro.VerdaderoSi
                                    Dim Coincide As Boolean = False

                                    Dim Comparaciones As List(Of Coincidencia) = Filtro.Coincidencias

                                    Select Case Coincidir
                                        Case Filtro.EnumTipoComparacion.Todo
                                            Coincide = True
                                            For Each Comparador In Comparaciones
                                                Select Case Comparador.Condicion
                                                    Case Coincidencia.EnumCondicion.Contiene
                                                        If Not Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = False
                                                    Case Coincidencia.EnumCondicion.NoContiene
                                                        If Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = False
                                                End Select
                                            Next

                                        Case Filtro.EnumTipoComparacion.Cualquiera
                                            Coincide = False
                                            For Each Comparador In Comparaciones
                                                Select Case Comparador.Condicion
                                                    Case Coincidencia.EnumCondicion.Contiene
                                                        If Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = True
                                                    Case Coincidencia.EnumCondicion.NoContiene
                                                        If Not Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = True
                                                End Select
                                            Next
                                    End Select

                                    If Coincide Then
                                        Dim IpCliente = ObtenerIp(Linea)
                                        If VerificarIpV4(IpCliente) AndAlso Not EsRedClaseC(IPAddress.Parse(IpCliente)) Then

                                            Dim FullMailBox As String = String.Empty
                                            Select Case Filtro.Key
                                                Case FilterKeys.FilterKey.SMTPMultipleDomainLogin
                                                    FullMailBox = SMTPLoginFromOutlook(Linea)
                                                    If String.IsNullOrEmpty(FullMailBox) Then FullMailBox = SMTPLoginFromThunderbird(Linea)

                                                Case FilterKeys.FilterKey.IMAPMultipleDomainLogin
                                                    FullMailBox = IMAPLogin(Linea)
                                            End Select

                                            If Not String.IsNullOrEmpty(FullMailBox) AndAlso FullMailBox.Contains("@") Then
                                                Dim Dominio As String = FullMailBox.Split("@")(1).ToLower
                                                If FullMailBox.Contains("-") Then Stop
                                                If Not ArchivosEnMemoria.Archivos(Archivo).CrossLogin.ContainsKey(IpCliente) Then ArchivosEnMemoria.Archivos(Archivo).CrossLogin.TryAdd(IpCliente, New Collections.Concurrent.ConcurrentDictionary(Of String, Collections.Concurrent.ConcurrentBag(Of String)))
                                                If Not ArchivosEnMemoria.Archivos(Archivo).CrossLogin(IpCliente).ContainsKey(Dominio) Then ArchivosEnMemoria.Archivos(Archivo).CrossLogin(IpCliente).TryAdd(Dominio, New Collections.Concurrent.ConcurrentBag(Of String))
                                                If Not ArchivosEnMemoria.Archivos(Archivo).CrossLogin(IpCliente)(Dominio).Contains($"{FullMailBox} {Linea}{vbNewLine}") Then ArchivosEnMemoria.Archivos(Archivo).CrossLogin(IpCliente)(Dominio).Add($"{FullMailBox} {Linea}")
                                                If ArchivosEnMemoria.Archivos(Archivo).CrossLogin(IpCliente).Count > 1 Then
                                                    Dim LogString As String = vbNewLine & "Filtro: {0,22} ({1,15}) | ({2,40}) {3,40}"
                                                    Dim Dom1 = String.Empty, Box1 = String.Empty
                                                    Dom1 = String.Join(",", ArchivosEnMemoria.Archivos(Archivo).CrossLogin(IpCliente).Keys)

                                                    For Each Dom In ArchivosEnMemoria.Archivos(Archivo).CrossLogin(IpCliente)
                                                        For Each Box In Dom.Value
                                                            Box1 &= $"{vbNewLine}{vbTab}{Box},"
                                                        Next
                                                    Next
                                                    Box1 = Box1.TrimEnd(",") & vbNewLine
                                                    LOG.Logs(LOG.MemoryLOG.EnumLogs.CrossDomain).Lineas.Enqueue(String.Format(LogString, Filtro.Key.ToString, IpCliente, Dom1, Box1))
                                                    'If Not FiltroIp.Contains(IpCliente) Then FiltroIp.Add(IpCliente)
                                                End If
                                            End If

                                        End If
                                    End If
                            End Select

                        Next
                    End If
                Else
                    Estado = EnumEstado.Analizado
                End If

            Catch ex As Exception
                IpBanForm.Invoke(Sub() IpBanForm.SalidaConsola.AppendText($"Filtro(ERROR : {ex.Message})"))
            End Try
        End Sub

        Private Sub Lector_Foreground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs)
            If Estado = EnumEstado.Analizando Then
                'Avanza en el conteo de lineas procesadas
                ArchivosEnMemoria.Archivos(Archivo).Line += 1

                'Informa en el avance de lectura
                Index = ArchivosEnMemoria.Archivos(Archivo).Line
            Else
                Detener.Detener = True
            End If
        End Sub
        Private Sub Lector_Endground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs)
            'Quitamos el Bloque de Analisis
            Bloqueo.Set()
        End Sub
        Public Sub Escanear()
            Lector.Iniciar()
            Bloqueo.WaitOne()
        End Sub

        Private Function VerificarIpV4(Ip As String) As Boolean
            If Ip <> "0.0.0.0" Then
                Try
                    'Testear que es una IPV4 Real, Si no es IPV4 desecha las comprobaciones
                    Ip = Net.IPAddress.Parse(Ip).ToString
                    If Net.IPAddress.Parse(Ip).AddressFamily = Net.Sockets.AddressFamily.InterNetworkV6 Then Return False
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            Else
                Return False
            End If
        End Function
        Private Function EsRedClaseC(EnatIp As IPAddress) As Boolean
            Dim ipBytes As Byte() = EnatIp.GetAddressBytes()
            If ipBytes(0) >= 192 AndAlso ipBytes(0) <= 223 OrElse ipBytes(0) = 127 Then
                'Es red Local
                Return True
            Else
                'Internet
                Return False
            End If
        End Function
        Private Function ExtraerEmailGenerico(texto As String) As String
            Dim emails As New List(Of String)
            Dim regex As New Regex("\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b")

            Dim coincidencias As MatchCollection = regex.Matches(texto)

            For Each coincidencia As Match In coincidencias
                emails.Add(coincidencia.Value)
            Next

            If emails.Count > 0 Then Return emails.First Else Return ""
        End Function

        Function ExtraerEmailIMAP(Texto As String) As String
            Dim Cuenta As String = String.Empty
            Dim Dominio As String = String.Empty
            Dim Log() As String = Texto.Split(" ")
            If Log(3) = "IMAP-IN" Then
                If IsNumeric(Log(6).Replace(".", "")) Then
                    Cuenta = Log(5)
                    Dominio = Log(4)
                End If
            End If
            If Not String.IsNullOrEmpty(Cuenta) AndAlso Not String.IsNullOrEmpty(Dominio) Then Return $"{Cuenta}@{Dominio}"
            Return ""
        End Function

        Function ExtraerEmailPOP(Texto As String) As String
            Dim Log() = Texto.Split(" ")
            If Log.Last.Contains("@") Then Return Log.Last
            Return ""
        End Function

        Private Function SMTPLoginFromOutlook(Linea As String) As String
            Dim Cuenta As String = String.Empty
            Dim Log() As String = Linea.Trim.Split(" ")
            If Log.Last.Contains("@") Then Cuenta = Log.Last
            Return Cuenta
        End Function
        Private Function SMTPLoginFromThunderbird(Linea As String) As String
            Dim Cuenta As String = String.Empty
            Dim Log() As String = Linea.Trim.Split(" ")
            Cuenta = $"{Log(13)}@{Log(4)}"
            Return Cuenta
        End Function

        Private Function IMAPLogin(Linea As String) As String
            Dim Cuenta As String = String.Empty
            Dim Log() As String = Linea.Trim.Split(" ")
            Cuenta = $"{Log(5)}@{Log(4)}"
            Return Cuenta
        End Function
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: eliminar el estado administrado (objetos administrados)
                    RemoveHandler Lector.BackGround, AddressOf Lector_Background
                    RemoveHandler Lector.ForeGround, AddressOf Lector_Foreground
                    RemoveHandler Lector.EndGround, AddressOf Lector_Endground

                    'Lector.Matar()
                End If

                ' TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                ' TODO: establecer los campos grandes como NULL
                disposedValue = True
            End If
        End Sub

        ' ' TODO: reemplazar el finalizador solo si "Dispose(disposing As Boolean)" tiene código para liberar los recursos no administrados
        ' Protected Overrides Sub Finalize()
        '     ' No cambie este código. Coloque el código de limpieza en el método "Dispose(disposing As Boolean)".
        '     Dispose(disposing:=False)
        '     MyBase.Finalize()
        ' End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            ' No cambie este código. Coloque el código de limpieza en el método "Dispose(disposing As Boolean)".
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub
    End Class
End Namespace