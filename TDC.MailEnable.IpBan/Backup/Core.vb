Imports System.Threading.Tasks
Imports TDC.MailEnable.Core.Bucle
Imports TDC.MailEnable.IpBan.MailEnableLog
Namespace Backup
    Module Core

#Region "0.2"
        'Tablas
        Public ReadOnly Property MAI As New MailEnable.Core.BDD.MailBackup_MAI  'Emails
        Public ReadOnly Property VCF As New MailEnable.Core.BDD.MailBackup_VCF  'Contactos
        Public ReadOnly Property TSK As New MailEnable.Core.BDD.MailBackup_TSK  'Tareas
        Public ReadOnly Property CAL As New MailEnable.Core.BDD.MailBackup_CAL  'Calendario
        Public ReadOnly Property Cleaner As New MailEnable.Core.BDD.MailBackupCleaner 'Limpieza

        Public BddMAIFullPath As String = $"{Application.StartupPath}\BDD\MAI.xml"
        Public BddVCFFullPath As String = $"{Application.StartupPath}\BDD\VCF.xml"
        Public BddCALFullPath As String = $"{Application.StartupPath}\BDD\CAL.xml"
        Public BddTSKFullPath As String = $"{Application.StartupPath}\BDD\TSK.xml"
        Public BddCleanerFullPath As String = $"{Application.StartupPath}\BDD\Cleaner.xml"

        Public ExtesionesArchivos As New List(Of String) From {NameOf(MAI), NameOf(VCF), NameOf(TSK), NameOf(CAL)}
        'Public Colas As New Concurrent.ConcurrentDictionary(Of String, Concurrent.ConcurrentQueue(Of String))
        Public WithEvents BuscadorCarpetas As New QueneDirectorios
        Public WithEvents BuscadorArchivos As New QueneArchivos
        Public WithEvents IndexadorArchivos As New Indexador
        Private WithEvents iFaceNotificador As New MailEnable.Core.Bucle.DoBucle("iFaceNotificadorBackup")
        Private WithEvents AutoIndex As New MailEnable.Core.Bucle.DoBucle("AutoIndexMailBackup") With {.Intervalo = DateDiff(DateInterval.Second, Now, Now.AddHours(1)) * 1000}
        Public ControlesProtegidos As New List(Of Control) From {IpBanForm.TreePostOffices, IpBanForm.TabBackup, IpBanForm.MenuTablaBackup}
        Public Sub Main()
            If IO.File.Exists(BddMAIFullPath) Then MAI.Tabla.ReadXml(BddMAIFullPath)
            If IO.File.Exists(BddVCFFullPath) Then VCF.Tabla.ReadXml(BddVCFFullPath)
            If IO.File.Exists(BddCALFullPath) Then CAL.Tabla.ReadXml(BddCALFullPath)
            If IO.File.Exists(BddTSKFullPath) Then TSK.Tabla.ReadXml(BddTSKFullPath)
            If IO.File.Exists(BddCleanerFullPath) Then Cleaner.Tabla.ReadXml(BddCleanerFullPath)

            For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
                Dim Buscador As MailEnable.Core.Bucle.DoBucle = MailEnable.Core.Bucle.GetOrCreate($"MailBackup{i}")
            Next

            'iFaceNotificador.Iniciar()
            Dim CrearRegistro As New ListViewItem With {.Text = $"{Now.ToShortTimeString} {Now.ToShortDateString}"}
            IpBanForm.lstAutoIndex.Items.Add(CrearRegistro)
            BuscadorCarpetas.Buscar(Configuracion.CARPETA_BACKUP)
            AutoIndex.Iniciar()
        End Sub

        Public Function Restaurar(Archivo As String) As Boolean
            If IO.File.Exists(Archivo) Then
                If Not IO.File.Exists(OriginalPath(Archivo)) Then
                    If IO.Directory.Exists(IO.Path.GetDirectoryName(OriginalPath(Archivo))) Then
                        Try
                            IO.File.Copy(Archivo, OriginalPath(Archivo))
                            IO.File.WriteAllText($"{IO.Path.GetDirectoryName(OriginalPath(Archivo))}\_change.dty", "index")
                            Return True
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    Else
                        MsgBox($"No existe un directorio donde restaurar el archivo, {OriginalPath(Archivo)}")
                    End If
                Else
                    IO.File.WriteAllText($"{IO.Path.GetDirectoryName(OriginalPath(Archivo))}\_change.dty", "index")
                    Return True
                End If
            Else
                MsgBox($"No existe el archivo del Backup, {Archivo}")
            End If
            Return False
        End Function
        Private Function OriginalPath(Archivo As String) As String
            Return Archivo.Replace(MailEnableLog.Configuracion.CARPETA_BACKUP, MailEnableLog.Configuracion.POST_OFFICES)
        End Function

        Private Sub BuscadorCarpetas_AlIniciarBusquedaDeCarpetas(sender As Object) Handles BuscadorCarpetas.AlIniciarBusquedaDeCarpetas
            'Iniciar el Notificador con la Iniciacion de la Busqueda
            If iFaceNotificador.Estado = DoBucle.EnumEstado.Detenido Then iFaceNotificador.Iniciar()
            iFaceNotificador.Intervalo = 100

            If BuscadorArchivos.Extensiones.Count = 0 Then
                For Each Extension In ExtesionesArchivos
                    BuscadorArchivos.Extensiones.Add($".{Extension}")
                Next
            End If
            BuscadorArchivos.Buscar(BuscadorCarpetas.Directorios)
        End Sub
        Private Sub BuscardorCarpetas_AlFinalizarBusqueda(sender As Object) Handles BuscadorCarpetas.AlFinalizarBusquedaCarpetas
            If BuscadorArchivos.Estado = QueneArchivos.EnumEstado.Analizado Then BuscadorArchivos.Continuar()
        End Sub

        Private Sub BuscadorArchivos_AlIniciarBusquedaDeArchivos(sender As Object) Handles BuscadorArchivos.AlIniciarBusquedaDeArchivos
            IndexadorArchivos.Analizar(BuscadorArchivos.Archivos)
        End Sub
        Private Sub BuscadorArchivos_AlFinalizarBusquedaArchivos(sender As Object) Handles BuscadorArchivos.AlFinalizarBusquedaArchivos
            If BuscadorCarpetas.Estado = QueneDirectorios.EnumEstado.Analizando Then BuscadorArchivos.Continuar()
        End Sub
        Private Sub IndexadorArchivos_AlFinalizarIndexacionDeArchivos(sender As Object) Handles IndexadorArchivos.AlFinalizarIndexacionDeArchivos
            If BuscadorCarpetas.Estado = QueneDirectorios.EnumEstado.Analizado AndAlso
                BuscadorArchivos.Estado = QueneArchivos.EnumEstado.Analizado AndAlso
                IndexadorArchivos.Estado = Indexador.EnumEstado.Analizado Then
                'Denetener los Buscadores
                For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
                    Dim Buscador As MailEnable.Core.Bucle.DoBucle = MailEnable.Core.Bucle.GetOrCreate($"MailBackup{i}")
                    If Not Buscador.Cancelar OrElse Buscador.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Corriendo Then Buscador.Detener()
                Next

                'Guardar los datos
                CAL.Guardar(BddCALFullPath)
                MAI.Guardar(BddMAIFullPath)
                VCF.Guardar(BddVCFFullPath)
                TSK.Guardar(BddTSKFullPath)
                Cleaner.Guardar(BddCleanerFullPath)
                IpBanForm.TablaMailBackupMAI.Enabled = True
                IpBanForm.ProgresoIndexacion.Style = ProgressBarStyle.Blocks

            Else
                IndexadorArchivos.Continuar()
            End If
        End Sub
        Private Sub iFaceNotificador_Foreground(Sender As Object, Detener As MailEnable.Core.Bucle.BackgroundEventArgs) Handles iFaceNotificador.ForeGround
            'Si hay Archivos por Indexar
            If IndexadorArchivos.Estado = Indexador.EnumEstado.Analizando AndAlso IndexadorArchivos.Quened > 0 Then IpBanForm.lblMailBackupSeleccionados.Text = $"Analizados ({IndexadorArchivos.Quened})"
            'Si no hay por Indexar pero seguimos en Analizados, Actualiza el Interface a 0
            If IndexadorArchivos.Estado = Indexador.EnumEstado.Analizando AndAlso IpBanForm.lblMailBackupSeleccionados.Text.StartsWith("Analizados") Then IpBanForm.lblMailBackupSeleccionados.Text = $"Analizados ({IndexadorArchivos.Quened})"

            IpBanForm.lblCarpetas.Text = $"Carpetas, {BuscadorCarpetas.Directorios.Count}]"
            IpBanForm.lblEmails.Text = $"Colas: [Archivos, {BuscadorArchivos.Archivos.Count}"
            IpBanForm.lblAnalizadoresBackup.Text = $"" &
            $"Subprocesos: [Indexadores {IndexadorArchivos.Indexadores.TakeWhile(Function(Buscador) Buscador.Value.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Corriendo).Count}, " &
            $"Archivos {BuscadorArchivos.Buscadores.TakeWhile(Function(Buscador) Buscador.Value.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Corriendo).Count}, " &
            $"Carpetas {BuscadorCarpetas.Buscadores.Count} , " &
            $"Relajación {Configuracion.ANALIZADORES_BACKUP_TIMER} ms]"

            If BuscadorCarpetas.Estado = QueneDirectorios.EnumEstado.Analizando OrElse
               BuscadorArchivos.Estado = QueneArchivos.EnumEstado.Analizando OrElse
               IndexadorArchivos.Estado = Indexador.EnumEstado.Analizando Then
                For Each ControlProtegido In ControlesProtegidos
                    If ControlProtegido.Enabled Then ControlProtegido.Enabled = Not ControlProtegido.Enabled
                Next
            End If
            If Not IsNothing(IpBanForm.TablaMailBackupMAI.Columns) AndAlso IpBanForm.TablaMailBackupMAI.Columns.Contains("Asunto") AndAlso IpBanForm.TablaMailBackupMAI.Columns("Asunto").AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet Then IpBanForm.TablaMailBackupMAI.Columns("Asunto").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            If Not IsNothing(IpBanForm.TablaMailBackupVCF.Columns) AndAlso IpBanForm.TablaMailBackupVCF.Columns.Contains("Nombre") AndAlso IpBanForm.TablaMailBackupVCF.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet Then IpBanForm.TablaMailBackupVCF.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            If Not IsNothing(IpBanForm.TablaMailBackupCAL.Columns) AndAlso IpBanForm.TablaMailBackupCAL.Columns.Contains("Descripcion") AndAlso IpBanForm.TablaMailBackupCAL.Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet Then IpBanForm.TablaMailBackupCAL.Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            If Not IsNothing(IpBanForm.TablaMailBackupTSK.Columns) AndAlso IpBanForm.TablaMailBackupTSK.Columns.Contains("Asunto") AndAlso IpBanForm.TablaMailBackupTSK.Columns("Asunto").AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet Then IpBanForm.TablaMailBackupTSK.Columns("Asunto").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            'Desactivar el Notificador al terminar la Indexacion
            If BuscadorCarpetas.Estado = QueneDirectorios.EnumEstado.Analizado AndAlso
                    BuscadorArchivos.Estado = QueneArchivos.EnumEstado.Analizado AndAlso
                    IndexadorArchivos.Estado = Indexador.EnumEstado.Analizado Then
                If iFaceNotificador.Intervalo <> 1000 Then
                    iFaceNotificador.Intervalo = 1000
                    iFaceNotificador_EndGround(Sender, Detener)
                End If
            End If
        End Sub

        Private Sub iFaceNotificador_EndGround(Sender As Object, e As BackgroundEventArgs) Handles iFaceNotificador.EndGround
            For Each ControlProtegido In ControlesProtegidos
                If Not ControlProtegido.Enabled Then ControlProtegido.Enabled = Not ControlProtegido.Enabled
            Next
        End Sub


        Private Sub AutoIndex_Background(Sender As Object, Detener As MailEnable.Core.Bucle.BackgroundEventArgs) Handles AutoIndex.BackGround
            If BuscadorCarpetas.Estado = QueneDirectorios.EnumEstado.Analizado Then BuscadorCarpetas.Buscar(Configuracion.CARPETA_BACKUP)
        End Sub

        Private Sub AutoIndex_ForeGround(Sender As Object, e As BackgroundEventArgs) Handles AutoIndex.ForeGround
            Dim CrearRegistro As New ListViewItem With {.Text = $"{Now.ToShortTimeString} {Now.ToShortDateString}"}
            IpBanForm.lstAutoIndex.Items.Add(CrearRegistro)
        End Sub

#End Region


    End Module
End Namespace