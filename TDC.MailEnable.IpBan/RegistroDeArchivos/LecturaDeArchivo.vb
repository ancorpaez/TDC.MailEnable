Imports System.IO
Imports System.Threading
Imports TDC.MailEnable.Core
Imports TDC.MailEnable.Core.GeoLocalizacion
Imports TDC.MailEnable.IpBan.MailEnableLog
Imports System.Text.RegularExpressions

'Esta clase Analiza Archivos Log en busqueda de Patrones configurables segun el Filtro aplicado
Namespace RegistroDeArchivos
    Public Class LecturaDeArchivo
        Implements IDisposable

        'Bucle BackGround y ForeGround
        Private WithEvents Lector As Bucle.DoBucle
        'Lista con los Filtros a comprobar por Linea
        Public Filtros As New List(Of Cls_Filtro)
        'Solicita la ip al Hilo principal donde estan agrupadas las diferentens funciones para realizarlo.
        Public Property ObtenerIp As Func(Of String, String)
        'Almacena las coincidencias por IP la lectura General del Archivo
        Private Coincidentes As New Collections.Concurrent.ConcurrentDictionary(Of String, Integer)
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
                Mod_Core.IpBanForm.Invoke(Sub() Lector = TDC.MailEnable.Core.Bucle.GetOrCreate(Archivo))
                AddHandler Lector.Background, AddressOf Lector_Background
                AddHandler Lector.Foreground, AddressOf Lector_Foreground
                AddHandler Lector.Endground, AddressOf Lector_Endground

                'Establecer una Memoria de Archivo
                If Not FileMemory.ContainsKey(Archivo) Then FileMemory.TryAdd(Archivo, New Cls_FileMemory)

                'Cargar el Archivo en Memoria
                Using Cargar As StreamReader = New IO.StreamReader(IO.File.Open(Archivo, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite))
                    Dim Linea As String = String.Empty
                    Dim Index As Integer = 0
                    Do
                        If Not FileMemory(Archivo).Lines.ContainsKey(Index) Then

                            'Obtener la linea
                            Linea = Cargar.ReadLine
                            If Not String.IsNullOrEmpty(Linea) Then

                                'Cargar la linea
                                If Not FileMemory(Archivo).Lines.TryAdd(Index, Linea) Then
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
                Total = FileMemory(Archivo).Lines.Count

            Catch ex As Exception

            End Try

            'Aplicar configuracion de los Bucles
            If IsNumeric(Configuracion.TIMER_LECTURA) Then Lector.Intervalo = Configuracion.TIMER_LECTURA Else Lector.Intervalo = 1
        End Sub

        Private Sub Lector_Background(Sender As Object, ByRef Detener As Boolean)
            Try
                'Establecer el punto más rapido en caso de falla de configuración
                If IsNumeric(Configuracion.TIMER_LECTURA) Then Lector.Intervalo = Configuracion.TIMER_LECTURA Else Lector.Intervalo = 1

                'Si el Control de Memoria no contiene el archivo detenemos el analizador.
                If Not FileMemory.ContainsKey(Archivo) Then
                    Estado = EnumEstado.Analizado
                    Lector.Detener()
                    Exit Sub
                End If

                'Analizamos Linea por Linea
                If FileMemory(Archivo).Line <= FileMemory(Archivo).Lines.Count AndAlso FileMemory(Archivo).Lines.ContainsKey(FileMemory(Archivo).Line) Then
                    Estado = EnumEstado.Analizando
                    If Not IsNothing(Filtros) Then
                        'Analizamos la linea con cada Filtro
                        For Each Filtro In Filtros
                            'Valores Iniciales para establecer si el filtro se Aplica
                            Dim Linea As String = FileMemory(Archivo).Lines(FileMemory(Archivo).Line)
                            Dim TipoComparacion As Cls_Filtro.EnumTipoComparacion = Filtro.TrueSi
                            Dim NumeroCoincidentes As Integer = Filtro.Repeteciones
                            Dim ComprobarMailBox As Boolean = Filtro.VerificarMailBox
                            Dim Comparaciones As List(Of Cls_Coincidencia) = Filtro.Coincidencias
                            Dim Coincide As Boolean = False

                            'Establecer Coincidencia
                            Select Case TipoComparacion
                                Case Cls_Filtro.EnumTipoComparacion.Todo
                                    Coincide = True
                                    For Each Comparador In Comparaciones
                                        Select Case Comparador.Condicion
                                            Case Cls_Coincidencia.EnumCondicion.Contiene
                                                If Not Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = False
                                            Case Cls_Coincidencia.EnumCondicion.NoContiene
                                                If Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = False
                                        End Select
                                    Next

                                Case Cls_Filtro.EnumTipoComparacion.Cualquiera
                                    Coincide = False
                                    For Each Comparador In Comparaciones
                                        Select Case Comparador.Condicion
                                            Case Cls_Coincidencia.EnumCondicion.Contiene
                                                If Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = True
                                            Case Cls_Coincidencia.EnumCondicion.NoContiene
                                                If Not Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = True
                                        End Select
                                    Next
                            End Select

                            'Se aplica el Filtro
                            If Coincide Then
                                'Ip Remota del cliente
                                Dim Ip As String = ObtenerIp(Linea)
                                'Verifica que sea IPv4
                                If Not VerificarIp(Ip) Then Exit For

                                'Datos necesarios para la Logica
                                Dim Geolocalizar As New IpInfo
                                Dim Pais As String = Geolocalizar.Geolocalizar(Ip, Mod_Core.Geolocalizador)
                                Dim FullMailbox = ExtraerEmails(Linea)
                                'Bandera para saber si se debe Banear la IP
                                Dim Banear As Boolean = False
                                'Almacena la Ip Remota o Suma en Contador de la Misma
                                If Not Coincidentes.ContainsKey(Ip) Then Me.Coincidentes.TryAdd(Ip, 1) Else Me.Coincidentes.TryUpdate(Ip, Me.Coincidentes(Ip) + 1, Me.Coincidentes(Ip))

                                'Comprueba si es Aplicable el Filtro por Pais
                                If Not ExclusionPais.Any(Function(Concide) Concide = Pais) Then
                                    'Pais no Excluido

                                    'Actualiza el numero de coincidencias maximo por pais (Defecto en su contra)
                                    If CoincidenciasPais.ContainsKey(Pais) AndAlso CoincidenciasPais(Pais).ContainsKey(Filtro.Key) Then NumeroCoincidentes = CoincidenciasPais(Pais)(Filtro.Key)

                                    'Comprueba si la Ip Remota supera el Maximo de coincidencias para el Filtro
                                    If Coincidentes(Ip) > NumeroCoincidentes Then Banear = True

                                    'Si el Filtro solicita comprobar el MailBox
                                    If Filtro.VerificarMailBox AndAlso Not Banear Then
                                        If Not String.IsNullOrEmpty(FullMailbox) Then
                                            Dim PostOffice As String = FullMailbox.Split("@")(1)
                                            Dim MailBox As String = FullMailbox.Split("@")(0)
                                            'Si no existe el PostOffice o el MailBox banea la IP
                                            If Not Mod_Core.PostOfficesCenter.PostOffices.Contains(PostOffice) Then
                                                'No existe el PostOffice
                                                Banear = True
                                            Else
                                                If Not Mod_Core.PostOfficesCenter.PostOffice(PostOffice).MailBoxes.ContainsKey(MailBox) Then
                                                    'No existe el MailBox
                                                    Banear = True
                                                Else
                                                    'Establece coincidencias por MailBox
                                                    If Not FileMemory(Archivo).MailBoxLogin.Exist(FullMailbox) Then FileMemory(Archivo).MailBoxLogin.Add(FullMailbox)
                                                    FileMemory(Archivo).MailBoxLogin.AddIp(FullMailbox, Ip)
                                                    If FileMemory(Archivo).MailBoxLogin.Exist(FullMailbox) AndAlso FileMemory(Archivo).MailBoxLogin.Count(FullMailbox) >= NumeroCoincidentes Then
                                                        'El MailBox supera el limite de Coincidencias del Filtro
                                                        Banear = True
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If

                                    If Banear Then
                                        If Not ComprobarMailBox Then
                                            'Se requiere Banear sin Comprobar MailBox
                                            If Not FiltroIp.Contains(Ip) Then FiltroIp.Add(Ip)
                                            Console.WriteLine($"BAN({Filtro.Key.ToString}): {Ip},{FullMailbox},{Pais},IpCount:{Coincidentes(Ip)},MailCount:No")
                                        Else
                                            'Se solicita Banear comprobando el MailBox
                                            If FileMemory(Archivo).MailBoxLogin.Exist(FullMailbox) Then
                                                'Existe el MailBox se Banean todas las Ip Almacenadas que intentaron hacer login a la cuenta
                                                For Each IpBox In FileMemory(Archivo).MailBoxLogin.Get(FullMailbox)
                                                    If Not String.IsNullOrEmpty(IpBox) Then
                                                        'Banear la IP (Evita Bloquear Ip[ES][ERR]) Comprueba la Bandera (GeolocalizarID, 0(Bloquea) o 1(No bloquea))
                                                        Dim IpGeolocalizar As New IpInfo
                                                        Dim IpPais As String = IpGeolocalizar.Geolocalizar(IpBox, Mod_Core.Geolocalizador)
                                                        Dim IpCoincidencias As Integer = 0
                                                        If CoincidenciasPais.ContainsKey(IpPais) AndAlso CoincidenciasPais(IpPais).ContainsKey(Filtro.Key) Then IpCoincidencias = CoincidenciasPais(IpPais)(Filtro.Key)
                                                        'Intenta Respetar el Limite Por Pais si Existe
                                                        If Coincidentes.ContainsKey(IpBox) Then
                                                            'Ya ha sido Contabilizada la Ip
                                                            If Coincidentes(IpBox) > IpCoincidencias Then
                                                                If Not FiltroIp.Contains(IpBox) Then FiltroIp.Add(IpBox)
                                                                Console.WriteLine($"BAN({Filtro.Key.ToString}): {IpBox},{FullMailbox},{IpPais},IpCount:{Coincidentes(IpBox)},MailCount:{FileMemory(Archivo).MailBoxLogin.Count(FullMailbox)}")
                                                            End If
                                                        Else
                                                            'No ha sido contabilizada la Ip, Excluiremos si tiene Reasignacion de Concurrentes por Pais
                                                            If Not CoincidenciasPais.ContainsKey(IpPais) Then
                                                                'Baneamos la Ip
                                                                If Not FiltroIp.Contains(IpBox) Then FiltroIp.Add(IpBox)
                                                                Console.WriteLine($"BAN({Filtro.Key.ToString}): {IpBox},{FullMailbox},{IpPais},IpCount:0,MailCount:{FileMemory(Archivo).MailBoxLogin.Count(FullMailbox)}")
                                                            Else
                                                                'No ha sido contabilizada la Ip  Pero Tiene Pais asociado a la Reasignacion
                                                                'Si tiene Reasignacion para este Filtro, Y está esta establecida en 0 o en 1
                                                                If CoincidenciasPais(IpPais).ContainsKey(Filtro.Key) AndAlso Not CoincidenciasPais(IpPais)(Filtro.Key) > 1 Then
                                                                    'Baneamos la Ip
                                                                    If Not FiltroIp.Contains(IpBox) Then FiltroIp.Add(IpBox)
                                                                    Console.WriteLine($"BAN({Filtro.Key.ToString}): {IpBox},{FullMailbox},{IpPais},IpCount:0,MailCount:{FileMemory(Archivo).MailBoxLogin.Count(FullMailbox)}")
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                            Else
                                                'No existe el MailBox Banea la IP
                                                If Not FiltroIp.Contains(Ip) Then FiltroIp.Add(Ip)
                                                Console.WriteLine($"BAN({Filtro.Key.ToString}): {Ip},{FullMailbox},{Pais},{Coincidentes(Ip)}")
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    End If
                Else
                    Estado = EnumEstado.Analizado
                End If

            Catch ex As Exception
                Stop
            End Try
        End Sub
        Private Function VerificarIp(Ip As String) As Boolean
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
        Private Sub Lector_Foreground(Sender As Object, ByRef Detener As Boolean)
            If Estado = EnumEstado.Analizando Then
                'Avanza en el conteo de lineas procesadas
                FileMemory(Archivo).Line += 1

                'Informa en el avance de lectura
                Index = FileMemory(Archivo).Line
            Else
                Detener = True
            End If
        End Sub
        Private Sub Lector_Endground(Sender As Object, ByRef Detener As Boolean)
            'Quitamos el Bloque de Analisis
            Bloqueo.Set()
        End Sub
        Public Sub Escanear()
            Lector.Iniciar()
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

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: eliminar el estado administrado (objetos administrados)
                    RemoveHandler Lector.Background, AddressOf Lector_Background
                    RemoveHandler Lector.Foreground, AddressOf Lector_Foreground
                    RemoveHandler Lector.Endground, AddressOf Lector_Endground

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