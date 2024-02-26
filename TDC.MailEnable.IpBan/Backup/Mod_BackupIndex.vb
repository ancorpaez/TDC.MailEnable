Imports System.Threading.Tasks
Imports TDC.MailEnable.IpBan.MailEnableLog
Namespace Backup
    Module Mod_BackupIndex
        Public Indexacion As New Core.BDD.MailBackupIndex

        Public Async Function Indexar() As Task
            'No Indexar en caso de no estar configurada la carpeta
            If String.IsNullOrEmpty(MailEnableLog.Configuracion.CARPETA_BACKUP) Then Exit Function
            If IO.File.Exists("Indexacion.xml") Then Indexacion.Tabla.ReadXml("Indexacion.xml")
            MailEnableLog.IpBanForm.Invoke(Sub() MailEnableLog.IpBanForm.TablaMailBackup.DataSource = Indexacion.Tabla)
            Await Indexar(MailEnableLog.Configuracion.CARPETA_BACKUP)


        End Function
        Public Async Function Indexar(Ruta As String) As Task
            If String.IsNullOrEmpty(Ruta) Then Exit Function
            Mod_Core.IpBanForm.Invoke(Sub() Interfaz.IpBan.LabelErroresDataTable.Text = "Indexando...")
            Mod_Core.IpBanForm.Invoke(Sub() Interfaz.IpBan.ProgresoIndexacion.Style = ProgressBarStyle.Marquee)

            Dim MailScan As New Cls_IndexMailScan()
            AddHandler MailScan.AnalizarArchivo, AddressOf AnalizarArchivo
            Await MailScan.EscanerCarpeta(Ruta)
            Indexacion.Tabla.WriteXml("Indexacion.xml")
            Mod_Core.IpBanForm.Invoke(Sub()
                                          Mod_Core.IpBanForm.TablaMailBackup.Enabled = True
                                          Mod_Core.IpBanForm.LabelErroresDataTable.Text = $"Indexado ({Indexacion.Tabla.Rows.Count})"
                                          Mod_Core.IpBanForm.ProgresoIndexacion.Style = ProgressBarStyle.Blocks
                                          Mod_Core.IpBanForm.TablaMailBackup.Refresh()
                                      End Sub)
        End Function
        Private Sub AnalizarArchivo(FullName As String)
            'Console.WriteLine($"Archivo encontrado: {FullName}")
            Try
                Dim Analizar As New Email(FullName)
                'Archivo Analizado No está Indexado
                Indexacion.Add(New Core.BDD.MailBackupIndex.Rows With {
                .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
                .Asunto = If(Analizar.Asunto = String.Empty, "", Analizar.Asunto),
                .Remitente = If(Analizar.Remitente = String.Empty, "", Analizar.Remitente),
                .Destinatarios = If(IsNothing(Analizar.Destinatarios), "", String.Join(";", Analizar.Destinatarios)),
                .Fecha = Analizar.Fecha,
                .ConCopia = If(IsNothing(Analizar.ConCopia), "", String.Join(";", Analizar.ConCopia))})
                Mod_Core.IpBanForm.Invoke(Sub() Interfaz.IpBan.LabelErroresDataTable.Text = $"Indexando ({Indexacion.Tabla.Rows.Count})")
                'Analizar.ImprimirDebug()
                'Stop
            Catch ex As Exception

            End Try
        End Sub

        Public Sub Restaurar(Archivo As String)
            Try
                Mod_Core.IpBanForm.TablaMailBackup.Enabled = False
                'En Archivos
                Dim RutaOriginal As String = Configuracion.POST_OFFICES
                Dim RutaCopia As String = Configuracion.CARPETA_BACKUP
                Dim RutaRestauracion As String = Archivo.Replace(RutaCopia, RutaOriginal)
                If Not IO.File.Exists(RutaRestauracion) Then IO.File.Copy(Archivo, RutaRestauracion)
                IO.File.WriteAllText(New IO.FileInfo(RutaRestauracion).Directory.FullName & "\_change.dty", "0")

                'En la Tabla
                Dim Fila As DataRow = Indexacion.GetRow("Archivo", Archivo)
                If Not IsNothing(Fila) Then Indexacion.Tabla.Rows.Remove(Fila)
                Indexacion.Tabla.WriteXml("Indexacion.xml")

                'Actualizar Interface
                Dim Remover As DataGridViewRow = Mod_Core.IpBanForm.TablaMailBackup.SelectedRows(0)
                Mod_Core.IpBanForm.TablaMailBackup.Rows.Remove(Remover)
                Mod_Core.IpBanForm.TablaMailBackup.Enabled = True
            Catch ex As Exception
                Mod_Core.IpBanForm.LabelErroresDataTable.Text = "No se pudo restaurar el Email."
                Mod_Core.IpBanForm.TablaMailBackup.Enabled = True
            End Try
        End Sub
    End Module
End Namespace