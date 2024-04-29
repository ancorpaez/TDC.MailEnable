Imports System.Threading.Tasks
Imports TDC.MailEnable.Core.Bucle
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
        Public ControlesProtegidos As New List(Of Control) From {IpBanForm.TreePostOffices, IpBanForm.TabFilesBackup, IpBanForm.MenuTablaBackup}
        Public Sub Main()
            If IO.File.Exists(BddMAIFullPath) Then MAI.Tabla.ReadXml(BddMAIFullPath)
            If IO.File.Exists(BddCleanerFullPath) Then Cleaner.Tabla.ReadXml(BddCleanerFullPath)

            For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
                Dim Buscador As Core.Bucle.DoBucle = Core.Bucle.GetOrCreate($"MailBackup{i}")
            Next

            'iFaceNotificador.Iniciar()
            Dim CrearRegistro As New ListViewItem With {.Text = $"{Now.ToShortTimeString} {Now.ToShortDateString}"}
            IpBanForm.lstAutoIndex.Items.Add(CrearRegistro)
            BuscadorCarpetas.Buscar(Configuracion.CARPETA_BACKUP)
            AutoIndex.Iniciar()
        End Sub
        Private Sub BuscadorCarpetas_AlIniciarBusquedaDeCarpetas(sender As Object) Handles BuscadorCarpetas.AlIniciarBusquedaDeCarpetas
            'Iniciar el Notificador con la Iniciacion de la Busqueda
            If iFaceNotificador.Estado = DoBucle.EnumEstado.Detenido Then iFaceNotificador.Iniciar()

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
                For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
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
            $"Temporizador: {Configuracion.ANALIZADORES_BACKUP_TIMER})"

            If BuscadorCarpetas.Estado = Cls_BuscadorDeDirectorios.EnumEstado.Analizando OrElse
               BuscadorArchivos.Estado = Cls_BuscadorDeArchivos.EnumEstado.Analizando OrElse
               IndexadorArchivos.Estado = Cls_AnalizadorDeArchivos.EnumEstado.Analizando Then
                For Each ControlProtegido In ControlesProtegidos
                    If ControlProtegido.Enabled Then ControlProtegido.Enabled = Not ControlProtegido.Enabled
                Next
                'ElseIf BuscadorCarpetas.Estado = Cls_BuscadorDeDirectorios.EnumEstado.Analizado AndAlso
                '        BuscadorArchivos.Estado = Cls_BuscadorDeArchivos.EnumEstado.Analizado AndAlso
                '        IndexadorArchivos.Estado = Cls_AnalizadorDeArchivos.EnumEstado.Analizado Then
                '    If Not IpBanForm.ProgresoIndexacion.Style = ProgressBarStyle.Continuous Then IpBanForm.ProgresoIndexacion.Style = ProgressBarStyle.Continuous
                '    For Each ControlProtegido In ControlesProtegidos
                '        If Not ControlProtegido.Enabled Then ControlProtegido.Enabled = Not ControlProtegido.Enabled
                '    Next
            End If
            If Not IsNothing(IpBanForm.TablaMailBackup.Columns) AndAlso IpBanForm.TablaMailBackup.Columns.Contains("Asunto") AndAlso IpBanForm.TablaMailBackup.Columns("Asunto").AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet Then IpBanForm.TablaMailBackup.Columns("Asunto").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            'Desactivar el Notificador al terminar la Indexacion
            If BuscadorCarpetas.Estado = Cls_BuscadorDeDirectorios.EnumEstado.Analizado AndAlso
                    BuscadorArchivos.Estado = Cls_BuscadorDeArchivos.EnumEstado.Analizado AndAlso
                    IndexadorArchivos.Estado = Cls_AnalizadorDeArchivos.EnumEstado.Analizado Then
                iFaceNotificador.Detener()
            End If
        End Sub

        Private Sub iFaceNotificador_EndGround(Sender As Object, e As BackgroundEventArgs) Handles iFaceNotificador.EndGround
            For Each ControlProtegido In ControlesProtegidos
                If Not ControlProtegido.Enabled Then ControlProtegido.Enabled = Not ControlProtegido.Enabled
            Next
        End Sub


        Private Sub AutoIndex_Background(Sender As Object, Detener As Core.Bucle.BackgroundEventArgs) Handles AutoIndex.BackGround
            If BuscadorCarpetas.Estado = Cls_BuscadorDeDirectorios.EnumEstado.Analizado Then BuscadorCarpetas.Buscar(Configuracion.CARPETA_BACKUP)
        End Sub

        Private Sub AutoIndex_ForeGround(Sender As Object, e As BackgroundEventArgs) Handles AutoIndex.ForeGround
            Dim CrearRegistro As New ListViewItem With {.Text = $"{Now.ToShortTimeString} {Now.ToShortDateString}"}
            IpBanForm.lstAutoIndex.Items.Add(CrearRegistro)
        End Sub

















#End Region


    End Module
End Namespace