Imports System.Threading.Tasks
Imports TDC.MailEnable.IpBan.MailEnableLog
Namespace Backup
    Module Mod_BackupIndex
        Public Indexacion As New Core.BDD.MailBackupIndex
        Public Cleaner As New Core.BDD.MailBackupCleaner

        Public Async Function Indexar() As Task
            'No Indexar en caso de no estar configurada la carpeta
            If String.IsNullOrEmpty(MailEnableLog.Configuracion.CARPETA_BACKUP) Then Exit Function
            If IO.File.Exists("Indexacion.xml") Then Indexacion.Tabla.ReadXml("Indexacion.xml")
            If IO.File.Exists("Cleaner.xml") Then Indexacion.Tabla.ReadXml("Cleaner.xml")
            MailEnableLog.IpBanForm.Invoke(Sub() MailEnableLog.IpBanForm.TablaMailBackup.DataSource = Indexacion.Tabla)
            Await Indexar(MailEnableLog.Configuracion.CARPETA_BACKUP)
        End Function

        Public Async Function Indexar(Ruta As String) As Task
            'Escanea la Carpeta y busca archivos nuevos para Indexar
            If String.IsNullOrEmpty(Ruta) Then Exit Function
            Mod_Core.IpBanForm.Invoke(Sub() Interfaz.IpBan.LabelErroresDataTable.Text = "Indexando...")
            Mod_Core.IpBanForm.Invoke(Sub() Interfaz.IpBan.ProgresoIndexacion.Style = ProgressBarStyle.Marquee)

            Dim MailScan As New Cls_IndexMailScan()
            AddHandler MailScan.AnalizarArchivo, AddressOf AnalizarArchivo
            Analisis = 0
            Await MailScan.EscanerCarpeta(Ruta)
            Indexacion.Tabla.WriteXml("Indexacion.xml")
            Cleaner.Tabla.WriteXml("Cleaner.xml")
            Mod_Core.IpBanForm.Invoke(Sub()
                                          Mod_Core.IpBanForm.TablaMailBackup.Enabled = True
                                          Mod_Core.IpBanForm.LabelErroresDataTable.Text = $"Indexado ({Indexacion.Tabla.Rows.Count})"
                                          Mod_Core.IpBanForm.ProgresoIndexacion.Style = ProgressBarStyle.Blocks
                                          Mod_Core.IpBanForm.TablaMailBackup.Refresh()
                                          IpBanForm.TablaMailBackup_Resize(Nothing, New EventArgs)
                                      End Sub)
        End Function
        Dim Analisis As Integer = 0
        Private Sub AnalizarArchivo(FullName As String)
            'Analiza el archivo y decide si sindexar o limpiar
            Try
                Analisis += 1
                Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.lblEmailsAnalizados.Text = $"Analizados ({Analisis})")
                'Comprobar la Antiguedad
                Dim Fecha As Date
                If Cleaner.Contains(Cleaner.GetColString(Core.BDD.MailBackupCleaner.Columnas.Archivo), FullName) Then
                    Dim Item As Integer = Cleaner.GetItemIndex(Cleaner.GetColString(Core.BDD.MailBackupCleaner.Columnas.Archivo), FullName)
                    Fecha = Cleaner.Get(Item, Cleaner.GetColString(Cleaner.GetColString(Core.BDD.MailBackupCleaner.Columnas.Registrado)))
                Else
                    Fecha = Now
                End If
                Dim Antiguedad As Integer = DateDiff(DateInterval.Day, Fecha, Now)

                'Banderas 
                Dim Indexar As Boolean = False
                Dim Eliminar As Boolean = False
                Dim Limpiar As Boolean = False

                'Si no supera la Antiguedad ni Esta Indexado (Indexar)
                If Not Antiguedad > Configuracion.ANTIGUEDAD_EMAILS AndAlso Not Indexacion.Contains(Core.BDD.MailBackupIndex.Columnas.Archivo.ToString, FullName) Then Indexar = True

                'Si no se Indexa y Supera la Antiguedad (Eliminar)
                If Not Indexar AndAlso Antiguedad > Configuracion.ANTIGUEDAD_EMAILS Then Eliminar = True

                'Si hay que eliminar y esta Indexado (Limpiar)
                If Eliminar AndAlso Indexacion.Contains(Core.BDD.MailBackupIndex.Columnas.Archivo.ToString, FullName) Then Limpiar = True

                'Limpiamos de la BDD
                If Limpiar Then
                    'Si hay que limpiar
                    Dim Fila As DataRow = Indexacion.GetRow("Archivo", FullName)
                    If Not IsNothing(Fila) Then Indexacion.Tabla.Rows.Remove(Fila)
                End If

                'Eliminamos el archivo del Backup
                If Eliminar Then
                    'Si hay que Eliminar
                    IO.File.Delete(FullName)
                    Dim Contar As Integer = CInt(IpBanForm.lblLimpiadosBackup.Text.Split(" ")(1).Replace("(", "").Replace(")", ""))
                    Contar += 1
                    Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.lblLimpiadosBackup.Text = $"Limpiados ({Contar})")
                End If

                'Indexamos el Archivo
                If Indexar Then
                    'Si hay que indexar
                    Dim Analizar As New Email(FullName)
                    Indexacion.Add(New Core.BDD.MailBackupIndex.Rows With {
                    .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
                    .Asunto = If(Analizar.Asunto = String.Empty, "", Analizar.Asunto),
                    .Remitente = If(Analizar.Remitente = String.Empty, "", Analizar.Remitente),
                    .Destinatarios = If(IsNothing(Analizar.Destinatarios), "", String.Join(";", Analizar.Destinatarios)),
                    .Fecha = Analizar.Fecha,
                    .ConCopia = If(IsNothing(Analizar.ConCopia), "", String.Join(";", Analizar.ConCopia))})
                    Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.LabelErroresDataTable.Text = $"Indexando ({Indexacion.Tabla.Rows.Count})")

                    'Registra el archivo en el Cleaner
                    Cleaner.Add(New Core.BDD.MailBackupCleaner.Rows With {
                                .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
                                .Registrado = CDate(Now.ToShortDateString)})
                End If

            Catch ex As Exception
                Stop
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