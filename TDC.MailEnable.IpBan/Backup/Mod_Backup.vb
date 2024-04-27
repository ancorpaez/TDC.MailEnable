Imports System.Threading.Tasks
Imports TDC.MailEnable.IpBan.MailEnableLog
Namespace Backup
    Module Mod_Backup

#Region "0.2"
        '        'Tablas
        Public MAI As New Core.BDD.MailBackup_MAI  'Emails
        Public VCF As New Core.BDD.MailBackup_MAI  'Contactos
        Public TSK As New Core.BDD.MailBackup_MAI  'Tareas
        Public CAL As New Core.BDD.MailBackup_MAI  'Calendario
        Public Cleaner As New Core.BDD.MailBackupCleaner 'Limpieza

        Public BddCleanerFullPath As String = $"{Application.StartupPath}\BDD\Cleaner.xml"
        Public BddMAIFullPath As String = $"{Application.StartupPath}\BDD\MAI.xml"

        Public ExtesionesArchivos As New List(Of String) From {NameOf(MAI), NameOf(VCF), NameOf(TSK), NameOf(CAL)}
        'Public Colas As New Concurrent.ConcurrentDictionary(Of String, Concurrent.ConcurrentQueue(Of String))
        Public WithEvents BuscadorCarpetas As New Cls_BuscadorDeDirectorios
        Public WithEvents BuscadorArchivos As New Cls_BuscadorDeArchivos
        Public WithEvents IndexadorArchivos As New Cls_AnalizadorDeArchivos
        Private WithEvents iFaceNotificador As New Core.Bucle.DoBucle("iFaceNotificadorBackup")
        Private WithEvents AutoIndex As New Core.Bucle.DoBucle("AutoIndexMailBackup") With {.Intervalo = DateDiff(DateInterval.Second, Now, Now.AddHours(1)) * 1000}
        Public Sub Main()
            If IO.File.Exists(BddMAIFullPath) Then MAI.Tabla.ReadXml(BddMAIFullPath)
            If IO.File.Exists(BddCleanerFullPath) Then Cleaner.Tabla.ReadXml(BddCleanerFullPath)

            For i = 0 To 99
                Dim Buscador As Core.Bucle.DoBucle = Core.Bucle.GetOrCreate($"MailBackup{i}")
            Next
            'For Each Cola In ColasString
            '    Colas.TryAdd(Cola, New Concurrent.ConcurrentQueue(Of String))
            'Next
            iFaceNotificador.Iniciar()
            Task.Run(Sub() BuscadorCarpetas.Buscar(Configuracion.CARPETA_BACKUP))
            AutoIndex.Iniciar()
        End Sub
        Private Sub BuscadorCarpetas_AlIniciarBusquedaDeCarpetas(sender As Object) Handles BuscadorCarpetas.AlIniciarBusquedaDeCarpetas
            If BuscadorArchivos.Extensiones.Count = 0 Then
                For Each Extension In ExtesionesArchivos
                    BuscadorArchivos.Extensiones.Add($".{Extension}")
                Next
            End If
            BuscadorArchivos.Buscar(BuscadorCarpetas.Directorios)
        End Sub
        Private Sub BuscardorCarpetas_AlFinalizarBusqueda(sender As Object) Handles BuscadorCarpetas.AlFinalizarBusquedaCarpetas
            If BuscadorArchivos.Estado = Cls_BuscadorDeArchivos.EnumEstado.Analizado Then BuscadorArchivos.Continuar()
        End Sub

        Private Sub BuscadorArchivos_AlIniciarBusquedaDeArchivos(sender As Object) Handles BuscadorArchivos.AlIniciarBusquedaDeArchivos
            IndexadorArchivos.Analizar(BuscadorArchivos.Archivos)
        End Sub
        Private Sub BuscadorArchivos_AlFinalizarBusquedaArchivos(sender As Object) Handles BuscadorArchivos.AlFinalizarBusquedaArchivos
            If BuscadorCarpetas.Estado = Cls_BuscadorDeDirectorios.EnumEstado.Analizando Then BuscadorArchivos.Continuar()
        End Sub
        Private Sub IndexadorArchivos_AlFinalizarIndexacionDeArchivos(sender As Object) Handles IndexadorArchivos.AlFinalizarIndexacionDeArchivos
            If BuscadorCarpetas.Estado = Cls_BuscadorDeDirectorios.EnumEstado.Analizado AndAlso BuscadorArchivos.Estado = Cls_BuscadorDeArchivos.EnumEstado.Analizado Then
                'Denetener los Buscadores
                For i = 0 To 99
                    Dim Buscador As Core.Bucle.DoBucle = Core.Bucle.GetOrCreate($"MailBackup{i}")
                    If Not Buscador.Cancelar OrElse Buscador.Estado = Core.Bucle.DoBucle.EnumEstado.Corriendo Then Buscador.Detener()
                Next

                'Guardar los datos
                MAI.Guardar(BddMAIFullPath)
                Cleaner.Guardar(BddCleanerFullPath)
                IpBanForm.TablaMailBackup.Enabled = True
                IpBanForm.ProgresoIndexacion.Style = ProgressBarStyle.Blocks

            Else
                IndexadorArchivos.Continuar()
            End If
        End Sub
        Private Sub iFaceNotificador_Foreground(Sender As Object, Detener As Core.Bucle.BackgroundEventArgs) Handles iFaceNotificador.ForeGround
            IpBanForm.lblCarpetas.Text = $"Carpetas ({BuscadorCarpetas.Directorios.Count})"
            IpBanForm.lblEmails.Text = $"Pendientes ({BuscadorArchivos.Archivos.Count})"
            IpBanForm.lblAnalizadoresBackup.Text = $"Analizadores (" &
            $"Indexadores: {IndexadorArchivos.Buscadores.TakeWhile(Function(Buscador) Buscador.Value.Estado = Core.Bucle.DoBucle.EnumEstado.Corriendo).Count}, " &
            $"Archivos: {BuscadorArchivos.Buscadores.TakeWhile(Function(Buscador) Buscador.Value.Estado = Core.Bucle.DoBucle.EnumEstado.Corriendo).Count}, " &
            $"Carpetas: {BuscadorCarpetas.Buscadores.Count} , " &
            $"Escaneo: {BuscadorCarpetas.Escaneo.Count} - " &
            $"Timer: {Configuracion.ANALIZADORES_BACKUP_TIMER})"
            If BuscadorCarpetas.Estado = Cls_BuscadorDeDirectorios.EnumEstado.Analizando OrElse
            BuscadorArchivos.Estado = Cls_BuscadorDeArchivos.EnumEstado.Analizando OrElse
            IndexadorArchivos.Estado = Cls_AnalizadorDeArchivos.EnumEstado.Analizando Then
                If Not IpBanForm.ProgresoIndexacion.Style = ProgressBarStyle.Marquee Then IpBanForm.ProgresoIndexacion.Style = ProgressBarStyle.Marquee
            End If
            If Not IsNothing(IpBanForm.TablaMailBackup.Columns) AndAlso IpBanForm.TablaMailBackup.Columns.Contains("Asunto") AndAlso IpBanForm.TablaMailBackup.Columns("Asunto").AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet Then IpBanForm.TablaMailBackup.Columns("Asunto").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Sub

        Private Sub AutoIndex_Background(Sender As Object, Detener As Core.Bucle.BackgroundEventArgs) Handles AutoIndex.BackGround
            BuscadorCarpetas.Buscar(Configuracion.CARPETA_BACKUP)
        End Sub

















#End Region

        '#Region "0.1"
        '        'Tablas
        '        Public MAI As New Core.BDD.MailBackup_MAI  'Emails
        '        Public VCF As New Core.BDD.MailBackup_MAI  'Contactos
        '        Public TSK As New Core.BDD.MailBackup_MAI  'Tareas
        '        Public CAL As New Core.BDD.MailBackup_MAI  'Calendario
        '        Public Cleaner As New Core.BDD.MailBackupCleaner 'Limpieza

        '        'Asosiacion de Colas con BDD
        '        Public ColasName As New List(Of String) From {NameOf(MAI), NameOf(VCF), NameOf(TSK), NameOf(CAL)}

        '        'Colas de Archivos
        '        Public Colas As New Concurrent.ConcurrentDictionary(Of String, Concurrent.ConcurrentQueue(Of String))

        '        Public CleanerString As String = "Cleaner.xml"
        '        Private MAIString As String = "MAI.xml"

        '        'Bandera para Inicializar Variables
        '        Private isMain As Boolean = False

        '        'Cola con las Carpetas encontradas
        '        Private Carpetas As New Concurrent.ConcurrentQueue(Of String)

        '        'Consulta la Cola de Carpetas para Extraer los Archivos
        '        Private WithEvents BuscadorArchivos As Core.Bucle.DoBucle

        '        'Muestra el avance en el Interface
        '        Private WithEvents iFaceNotificador As Core.Bucle.DoBucle

        '        'Puntero para recibir los eventos de los Analizadores de Archivos
        '        Private WithEvents AnalizadoresEmailEvents As Core.Bucle.DoBucle
        '        'Bolsa con todos los Analizadores de Archivos
        '        Private AnalizadoresEmail As New Concurrent.ConcurrentBag(Of Core.Bucle.DoBucle)

        '        'Bandera para Indidicar la finalizacion de busqueda de Carpetas
        '        Private FinalBuscadorCarpetas As Boolean = False
        '        'Cola con los Buscadores de Archivos por Carpeta
        '        Private QueneBuscadoresArchivos As New Concurrent.ConcurrentQueue(Of Cls_IndexMailScan)


        '        Public Sub Main()
        '            For Each Cola In ColasName
        '                Colas.TryAdd(Cola, New Concurrent.ConcurrentQueue(Of String))
        '            Next
        '            For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
        '                Dim CrearAnalizador As Core.Bucle.DoBucle = Nothing
        '                IpBanForm.Invoke(Sub() CrearAnalizador = New Core.Bucle.DoBucle($"AnalizadoresEmail{i}") With {.Intervalo = 10})
        '                AddHandler CrearAnalizador.Background, Sub(sender As Object, ByRef Cancelar As Boolean)
        '                                                           'Indexar Emails
        '                                                           Dim FullArchivo As String = String.Empty
        '                                                           If Colas(NameOf(MAI)).TryDequeue(FullArchivo) Then
        '                                                               Try
        '                                                                   'Comprobar la Antiguedad
        '                                                                   Dim Fecha As Date
        '                                                                   If Cleaner.Contains(Cleaner.GetColString(Core.BDD.MailBackupCleaner.Columnas.Archivo), FullArchivo) Then
        '                                                                       Dim Item As Integer = Cleaner.GetItemIndex(Cleaner.GetColString(Core.BDD.MailBackupCleaner.Columnas.Archivo), FullArchivo)
        '                                                                       Fecha = Cleaner.Get(Item, Cleaner.GetColString(Core.BDD.MailBackupCleaner.Columnas.Registrado))
        '                                                                   Else
        '                                                                       Fecha = Now
        '                                                                   End If
        '                                                                   Dim Antiguedad As Integer = DateDiff(DateInterval.Day, Fecha, Now)

        '                                                                   'Banderas 
        '                                                                   Dim Indexar As Boolean = False
        '                                                                   Dim Eliminar As Boolean = False
        '                                                                   Dim Limpiar As Boolean = False

        '                                                                   'Si no supera la Antiguedad ni Esta Indexado (Indexar)
        '                                                                   If Not Antiguedad > Configuracion.ANTIGUEDAD_EMAILS AndAlso Not MAI.Contains(Core.BDD.MailBackup_MAI.Columnas.Archivo.ToString, FullArchivo) Then Indexar = True

        '                                                                   'Si no se Indexa y Supera la Antiguedad (Eliminar)
        '                                                                   If Not Indexar AndAlso Antiguedad > Configuracion.ANTIGUEDAD_EMAILS Then Eliminar = True

        '                                                                   'Si hay que eliminar y esta Indexado (Limpiar)
        '                                                                   If Eliminar AndAlso MAI.Contains(Core.BDD.MailBackup_MAI.Columnas.Archivo.ToString, FullArchivo) Then Limpiar = True

        '                                                                   'Limpiamos de la BDD
        '                                                                   If Limpiar Then
        '                                                                       'Si hay que limpiar
        '                                                                       Dim Fila As DataRow = MAI.GetRow("Archivo", FullArchivo)
        '                                                                       If Not IsNothing(Fila) Then MAI.Tabla.Rows.Remove(Fila)
        '                                                                   End If

        '                                                                   'Eliminamos el archivo del Backup
        '                                                                   If Eliminar Then
        '                                                                       'Si hay que Eliminar
        '                                                                       IO.File.Delete(FullArchivo)
        '                                                                       Dim Contar As Integer = CInt(IpBanForm.lblLimpiadosBackup.Text.Split(" ")(1).Replace("(", "").Replace(")", ""))
        '                                                                       Contar += 1
        '                                                                       Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.lblLimpiadosBackup.Text = $"Limpiados ({Contar})")
        '                                                                   End If

        '                                                                   'Indexamos el Archivo
        '                                                                   If Indexar Then
        '                                                                       'Si hay que indexar
        '                                                                       Dim Analizar As New Email(FullArchivo)
        '                                                                       MAI.Add(New Core.BDD.MailBackup_MAI.Rows With {
        '                                                                            .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
        '                                                                            .Asunto = If(Analizar.Asunto = String.Empty, "", Analizar.Asunto),
        '                                                                            .Remitente = If(Analizar.Remitente = String.Empty, "", Analizar.Remitente),
        '                                                                            .Destinatarios = If(IsNothing(Analizar.Destinatarios), "", String.Join(";", Analizar.Destinatarios)),
        '                                                                            .Fecha = Analizar.Fecha,
        '                                                                            .ConCopia = If(IsNothing(Analizar.ConCopia), "", String.Join(";", Analizar.ConCopia))})
        '                                                                       Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.lblMensajesBackup.Text = $"Indexando ({MAI.Tabla.Rows.Count})")

        '                                                                       'Registra el archivo en el Cleaner
        '                                                                       Cleaner.Add(New Core.BDD.MailBackupCleaner.Rows With {
        '                                                                                        .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
        '                                                                                        .Registrado = CDate(Now.ToShortDateString)})
        '                                                                   End If
        '                                                               Catch ex As Exception

        '                                                               End Try
        '                                                           End If

        '                                                           'Calendario
        '                                                           Try
        '                                                               If Colas(NameOf(CAL)).TryDequeue(FullArchivo) Then

        '                                                               End If
        '                                                           Catch ex As Exception

        '                                                           End Try
        '                                                           'Contactos
        '                                                           Try
        '                                                               If Colas(NameOf(VCF)).TryDequeue(FullArchivo) Then

        '                                                               End If
        '                                                           Catch ex As Exception

        '                                                           End Try
        '                                                           'Tareas
        '                                                           Try
        '                                                               If Colas(NameOf(TSK)).TryDequeue(FullArchivo) Then

        '                                                               End If
        '                                                           Catch ex As Exception

        '                                                           End Try

        '                                                           'Establecer Fin de Indexacion
        '                                                           If ColasName.All(Function(Cola) Colas(Cola).Count = 0) AndAlso FinalBuscadorCarpetas AndAlso BuscadorArchivos.Cancelar Then IndexadoEnd = True
        '                                                       End Sub

        '                AddHandler CrearAnalizador.Foreground, AddressOf AnalizadoresEmailEvents_Foreground
        '                AddHandler CrearAnalizador.Endground, AddressOf AnalizadoresEmailEvents_Endground
        '                AnalizadoresEmail.Add(CrearAnalizador)
        '                CrearAnalizador.Iniciar()
        '            Next
        '            isMain = True
        '        End Sub
        '        Public Async Function Indexar() As Task
        '            'No Indexar en caso de no estar configurada la carpeta
        '            If String.IsNullOrEmpty(MailEnableLog.Configuracion.CARPETA_BACKUP) Then Exit Function
        '            If IO.File.Exists(MAIString) Then MAI.Tabla.ReadXml(MAIString)
        '            If IO.File.Exists(CleanerString) Then Cleaner.Tabla.ReadXml(CleanerString)
        '            MailEnableLog.IpBanForm.Invoke(Sub() MailEnableLog.IpBanForm.TablaMailBackup.DataSource = MAI.Tabla)
        '            MailEnableLog.IpBanForm.Invoke(Sub() BuscadorArchivos = New Core.Bucle.DoBucle("BuscarMAI") With {.Intervalo = 10})
        '            MailEnableLog.IpBanForm.Invoke(Sub() iFaceNotificador = New Core.Bucle.DoBucle("iFaceNotificadorBackup") With {.Intervalo = 100})
        '            BuscadorArchivos.Iniciar()
        '            iFaceNotificador.Iniciar()
        '            Await Indexar(MailEnableLog.Configuracion.CARPETA_BACKUP)
        '        End Function

        '        Public Async Function Indexar(Ruta As String) As Task
        '            FinalBuscadorCarpetas = False
        '            If Not isMain Then Main()

        '            'Escanea la Carpeta y busca archivos nuevos para Indexar
        '            If String.IsNullOrEmpty(Ruta) Then Exit Function
        '            Mod_Core.IpBanForm.Invoke(Sub() Interfaz.IpBan.lblMensajesBackup.Text = "Buscando...")
        '            Mod_Core.IpBanForm.Invoke(Sub() Interfaz.IpBan.ProgresoIndexacion.Style = ProgressBarStyle.Marquee)
        '            Mod_Core.IpBanForm.Invoke(Sub() Interfaz.IpBan.lblAnalizadoresBackup.Text = $"Analizadores ({AnalizadoresEmail.Count})")

        '            Dim MailScan As New Cls_IndexMailScan()
        '            AddHandler MailScan.NuevaCarpeta, AddressOf NuevaCarpeta
        '            Await MailScan.ObtenerCarpetas(Ruta)
        '            FinalBuscadorCarpetas = True

        '            If BuscadorArchivos.Cancelar Then BuscadorArchivos.Iniciar()
        '            For Each Analizador In AnalizadoresEmail
        '                If Analizador.Cancelar Then Analizador.Iniciar()
        '            Next
        '        End Function


        '        Private Sub NuevaCarpeta(FullDirectory As String)
        '            Carpetas.Enqueue(FullDirectory)
        '            'iCarpetas += 1
        '            'Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.lblEmailsAnalizados.Text = $"Carpetas ({iCarpetas})")
        '        End Sub

        '        'Dim Encontrados As Integer = 0
        '        Private Sub AnalizarArchivo(FullName As String)
        '            'Analiza el archivo y decide si sindexar o limpiar
        '            Try
        '                Select Case IO.Path.GetExtension(FullName).ToUpper
        '                    Case $".{ NameOf(MAI)}"
        '                        Colas(NameOf(MAI)).Enqueue(FullName)
        '                    Case $".{ NameOf(VCF)}"
        '                        Colas(NameOf(VCF)).Enqueue(FullName)
        '                    Case $".{ NameOf(TSK)}"
        '                        Colas(NameOf(TSK)).Enqueue(FullName)
        '                    Case $".{ NameOf(CAL)}"
        '                        Colas(NameOf(CAL)).Enqueue(FullName)
        '                    Case Else
        '                        Stop
        '                End Select

        '                'Encontrados += 1

        '                'Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.lblEmails.Text = $"Encontrados ({Encontrados})")
        '                Exit Sub
        '                ''Comprobar la Antiguedad
        '                'Dim Fecha As Date
        '                'If Cleaner.Contains(Cleaner.GetColString(Core.BDD.MailBackupCleaner.Columnas.Archivo), FullName) Then
        '                '    Dim Item As Integer = Cleaner.GetItemIndex(Cleaner.GetColString(Core.BDD.MailBackupCleaner.Columnas.Archivo), FullName)
        '                '    Fecha = Cleaner.Get(Item, Cleaner.GetColString(Core.BDD.MailBackupCleaner.Columnas.Registrado))
        '                'Else
        '                '    Fecha = Now
        '                'End If
        '                'Dim Antiguedad As Integer = DateDiff(DateInterval.Day, Fecha, Now)

        '                ''Banderas 
        '                'Dim Indexar As Boolean = False
        '                'Dim Eliminar As Boolean = False
        '                'Dim Limpiar As Boolean = False

        '                ''Si no supera la Antiguedad ni Esta Indexado (Indexar)
        '                'If Not Antiguedad > Configuracion.ANTIGUEDAD_EMAILS AndAlso Not MAI.Contains(Core.BDD.MailBackup_MAI.Columnas.Archivo.ToString, FullName) Then Indexar = True

        '                ''Si no se Indexa y Supera la Antiguedad (Eliminar)
        '                'If Not Indexar AndAlso Antiguedad > Configuracion.ANTIGUEDAD_EMAILS Then Eliminar = True

        '                ''Si hay que eliminar y esta Indexado (Limpiar)
        '                'If Eliminar AndAlso MAI.Contains(Core.BDD.MailBackup_MAI.Columnas.Archivo.ToString, FullName) Then Limpiar = True

        '                ''Limpiamos de la BDD
        '                'If Limpiar Then
        '                '    'Si hay que limpiar
        '                '    Dim Fila As DataRow = MAI.GetRow("Archivo", FullName)
        '                '    If Not IsNothing(Fila) Then MAI.Tabla.Rows.Remove(Fila)
        '                'End If

        '                ''Eliminamos el archivo del Backup
        '                'If Eliminar Then
        '                '    'Si hay que Eliminar
        '                '    IO.File.Delete(FullName)
        '                '    Dim Contar As Integer = CInt(IpBanForm.lblLimpiadosBackup.Text.Split(" ")(1).Replace("(", "").Replace(")", ""))
        '                '    Contar += 1
        '                '    Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.lblLimpiadosBackup.Text = $"Limpiados ({Contar})")
        '                'End If

        '                ''Indexamos el Archivo
        '                'If Indexar Then
        '                '    'Si hay que indexar
        '                '    Dim Analizar As New Email(FullName)
        '                '    MAI.Add(New Core.BDD.MailBackup_MAI.Rows With {
        '                '    .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
        '                '    .Asunto = If(Analizar.Asunto = String.Empty, "", Analizar.Asunto),
        '                '    .Remitente = If(Analizar.Remitente = String.Empty, "", Analizar.Remitente),
        '                '    .Destinatarios = If(IsNothing(Analizar.Destinatarios), "", String.Join(";", Analizar.Destinatarios)),
        '                '    .Fecha = Analizar.Fecha,
        '                '    .ConCopia = If(IsNothing(Analizar.ConCopia), "", String.Join(";", Analizar.ConCopia))})
        '                '    Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.LabelErroresDataTable.Text = $"Indexando ({MAI.Tabla.Rows.Count})")

        '                '    'Registra el archivo en el Cleaner
        '                '    Cleaner.Add(New Core.BDD.MailBackupCleaner.Rows With {
        '                '                .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
        '                '                .Registrado = CDate(Now.ToShortDateString)})
        '                'End If

        '            Catch ex As Exception
        '                Stop
        '            End Try
        '        End Sub

        '        Public Sub Restaurar(Archivo As String)
        '            Try
        '                Mod_Core.IpBanForm.TablaMailBackup.Enabled = False
        '                'En Archivos
        '                Dim RutaOriginal As String = Configuracion.POST_OFFICES
        '                Dim RutaCopia As String = Configuracion.CARPETA_BACKUP
        '                Dim RutaRestauracion As String = Archivo.Replace(RutaCopia, RutaOriginal)
        '                If Not IO.File.Exists(RutaRestauracion) Then IO.File.Copy(Archivo, RutaRestauracion)
        '                IO.File.WriteAllText(New IO.FileInfo(RutaRestauracion).Directory.FullName & "\_change.dty", "0")

        '                'En la Tabla
        '                Dim Fila As DataRow = MAI.GetRow("Archivo", Archivo)
        '                If Not IsNothing(Fila) Then MAI.Tabla.Rows.Remove(Fila)
        '                MAI.Guardar(MAIString)

        '                'Actualizar Interface
        '                Dim Remover As DataGridViewRow = Mod_Core.IpBanForm.TablaMailBackup.SelectedRows(0)
        '                Mod_Core.IpBanForm.TablaMailBackup.Rows.Remove(Remover)
        '                Mod_Core.IpBanForm.TablaMailBackup.Enabled = True
        '            Catch ex As Exception
        '                Mod_Core.IpBanForm.lblMensajesBackup.Text = "No se pudo restaurar el Email."
        '                Mod_Core.IpBanForm.TablaMailBackup.Enabled = True
        '            End Try
        '        End Sub

        '        Private Sub BuscadorArchivos_Background(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles BuscadorArchivos.Background
        '            Dim BuscadorArchivos_Background_Carpeta As String = String.Empty
        '            If Carpetas.TryDequeue(BuscadorArchivos_Background_Carpeta) Then
        '                Dim MailScan As New Cls_IndexMailScan()
        '                AddHandler MailScan.AnalizarArchivo, AddressOf AnalizarArchivo
        '                MailScan.EscanerCarpeta(BuscadorArchivos_Background_Carpeta)
        '                QueneBuscadoresArchivos.Enqueue(MailScan)
        '            End If
        '        End Sub
        '        Private Sub BuscadorArchivos_Foreground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles BuscadorArchivos.Foreground
        '            If FinalBuscadorCarpetas AndAlso Carpetas.Count = 0 Then BuscadorArchivos.Detener()
        '        End Sub
        '        Private Sub BuscadorArchivos_Endground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles BuscadorArchivos.Endground
        '            Do While Not QueneBuscadoresArchivos.Count = 0
        '                Dim Buscador As Cls_IndexMailScan = Nothing
        '                If QueneBuscadoresArchivos.TryDequeue(Buscador) Then
        '                    RemoveHandler Buscador.AnalizarArchivo, AddressOf AnalizarArchivo
        '                End If
        '            Loop
        '        End Sub

        '        Private Sub iFaceNotificador_Foreground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles iFaceNotificador.Foreground
        '            IpBanForm.lblCarpetas.Text = $"Carpetas ({Carpetas.Count})"
        '            IpBanForm.lblEmails.Text = $"Pendientes ({Colas(NameOf(MAI)).Count})"
        '        End Sub



        '        Dim IndexadoEnd As Boolean = False
        '        Private Sub AnalizadoresEmailEvents_Foreground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles AnalizadoresEmailEvents.Foreground
        '            If IndexadoEnd AndAlso Not IpBanForm.TablaMailBackup.Enabled Then IpBanForm.TablaMailBackup.Enabled = True
        '            If IndexadoEnd AndAlso Interfaz.IpBan.ProgresoIndexacion.Style = ProgressBarStyle.Marquee Then Interfaz.IpBan.ProgresoIndexacion.Style = ProgressBarStyle.Blocks
        '            If IndexadoEnd Then CType(Sender, Core.Bucle.DoBucle).Detener()
        '        End Sub

        '        Private Sub AnalizadoresEmailEvents_Endground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles AnalizadoresEmailEvents.Endground
        '            If AnalizadoresEmail.All(Function(Analizador) Analizador.Cancelar) AndAlso BuscadorArchivos.Cancelar Then
        '                Try
        '                    MAI.Guardar(MAIString)
        '                    Cleaner.Guardar(CleanerString)
        '                Catch ex As Exception
        '                    Stop
        '                End Try
        '            End If
        '        End Sub
        '#End Region
    End Module
End Namespace