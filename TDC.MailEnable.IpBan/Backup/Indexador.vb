Imports TDC.MailEnable.IpBan.MailEnableLog
Namespace Backup
    Public Class Indexador
        Implements IDisposable

        Private Archivos As Concurrent.ConcurrentQueue(Of String)
        Private WithEvents BuscadoresEvents As MailEnable.Core.Bucle.DoBucle
        Public ReadOnly Buscadores As New Concurrent.ConcurrentDictionary(Of String, MailEnable.Core.Bucle.DoBucle)
        Private WithEvents Controlador As MailEnable.Core.Bucle.DoBucle

        Dim disposedValue As Boolean
        Public Event AlFinalizarIndexacionDeArchivos(sender As Object)
        Private AlFinalizarIndexacionNotificado As Boolean = False

        Public Enum EnumEstado
            Iniciando
            Analizando
            Analizado
        End Enum
        Public Property Estado As EnumEstado = EnumEstado.Iniciando

        Public Sub New()
            For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
                IpBanForm.Invoke(Sub()
                                     Dim Buscador As KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle) = CrearBuscador(i)
                                     If Not IsNothing(Buscador) Then
                                         Buscadores.TryAdd(Buscador.Key, Buscador.Value)
                                     Else
                                         Stop
                                     End If
                                 End Sub)
            Next
            Controlador = MailEnable.Core.Bucle.GetOrCreate("Global100")
            Controlador.Iniciar()
        End Sub

        Private Function CrearBuscador(Optional Index As Integer = -1) As KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle)
            Select Case Index
                Case -1
                    For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
                        If Not Buscadores.ContainsKey($"MailBackup{i}") Then
                            Dim Buscador As MailEnable.Core.Bucle.DoBucle = MailEnable.Core.Bucle.GetOrCreate($"MailBackup{i}")
                            Buscador.Intervalo = Configuracion.ANALIZADORES_BACKUP_TIMER
                            AddHandler Buscador.BackGround, AddressOf BuscadoresEvents_Background
                            AddHandler Buscador.ForeGround, AddressOf BuscadoresEvents_Foreground
                            AddHandler Buscador.EndGround, AddressOf BuscadoresEvents_Endground
                                                                Return New KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle)(Buscador.Name, Buscador)
                        End If
                    Next
                Case Else
                    If Not Buscadores.ContainsKey($"MailBackup{Index}") Then
                        Dim Buscador As MailEnable.Core.Bucle.DoBucle = MailEnable.Core.Bucle.GetOrCreate($"MailBackup{Index}")
                        Buscador.Intervalo = Configuracion.ANALIZADORES_BACKUP_TIMER
                        AddHandler Buscador.Background, AddressOf BuscadoresEvents_Background
                        AddHandler Buscador.Foreground, AddressOf BuscadoresEvents_Foreground
                        AddHandler Buscador.Endground, AddressOf BuscadoresEvents_Endground
                        Return New KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle)(Buscador.Name, Buscador)
                    End If
            End Select
            Return Nothing
        End Function
        Public Sub Analizar(Archivos As Concurrent.ConcurrentQueue(Of String))
            Me.Archivos = Archivos

            If Buscadores.IsEmpty Then
                For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
                    Dim Buscador As KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle) = CrearBuscador(i)
                    If Not IsNothing(Buscador) Then
                        Buscadores.TryAdd(Buscador.Key, Buscador.Value)
                    Else
                        Stop
                    End If
                Next
            End If

            For Each Buscador In Buscadores.Values
                If Buscador.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Iniciar()
            Next
            AlFinalizarIndexacionNotificado = False
            Estado = EnumEstado.Analizando
        End Sub
        Public Sub Continuar()
            For Each Buscador In Buscadores.Values
                Try
                    If Buscador.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Iniciar()
                    AlFinalizarIndexacionNotificado = False
                Catch ex As Exception
                    Stop
                End Try
            Next
        End Sub
        Private Sub AnalizarArchivo(Archivo As String)
            If Not IO.File.Exists(OriginalPath(Archivo)) Then
#Region "Email"
                'Emails
                Try
                    If IO.Path.GetExtension(Archivo).ToUpper = $".{NameOf(MAI)}" Then
                        'Comprobar la Antiguedad
                        Dim Fecha As Date
                        If Cleaner.Contains(Cleaner.GetColString(MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo) Then
                            Dim Item As Integer = Cleaner.GetItemIndex(Cleaner.GetColString(MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo)
                            Fecha = Cleaner.Get(Item, Cleaner.GetColString(MailEnable.Core.BDD.MailBackupCleaner.Columnas.Registrado))
                        Else
                            Fecha = Now
                        End If
                        Dim Antiguedad As Integer = DateDiff(DateInterval.Day, Fecha, Now)

                        'Banderas 
                        Dim Indexar As Boolean = False
                        Dim Eliminar As Boolean = False
                        Dim Limpiar As Boolean = False

                        'Si no supera la Antiguedad ni Esta Indexado (Indexar)
                        If Not Antiguedad > Configuracion.ANTIGUEDAD_EMAILS AndAlso Not MAI.Contains(MailEnable.Core.BDD.MailBackup_MAI.Columnas.Archivo.ToString, Archivo) Then Indexar = True

                        'Si no se Indexa y Supera la Antiguedad (Eliminar)
                        If Not Indexar AndAlso Antiguedad > Configuracion.ANTIGUEDAD_EMAILS Then Eliminar = True

                        'Si hay que eliminar y esta Indexado (Limpiar)
                        If Eliminar AndAlso MAI.Contains(MailEnable.Core.BDD.MailBackup_MAI.Columnas.Archivo.ToString, Archivo) Then Limpiar = True

                        'Limpiamos de la BDD
                        If Limpiar Then
                            'Si hay que limpiar
                            Dim Fila As DataRow = MAI.GetRow("Archivo", Archivo)
                            If Not IsNothing(Fila) Then MAI.Tabla.Rows.Remove(Fila)
                        End If

                        'Eliminamos el archivo del Backup
                        If Eliminar Then
                            'Si hay que Eliminar
                            IO.File.Delete(Archivo)
                            Dim Contar As Integer = CInt(IpBanForm.lblLimpiadosBackup.Text.Split(" ")(1).Replace("(", "").Replace(")", ""))
                            Contar += 1
                            Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.lblLimpiadosBackup.Text = $"Limpiados ({Contar})")
                        End If

                        'Indexamos el Archivo
                        If Indexar Then
                            'Si hay que indexar
                            If IO.File.Exists(Archivo) Then
                                Dim Analizar As New Email1(Archivo)
                                MAI.Add(New MailEnable.Core.BDD.MailBackup_MAI.Rows With {
                                     .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
                                     .Asunto = If(Analizar.Asunto = String.Empty, "", Analizar.Asunto),
                                     .Remitente = If(Analizar.Remitente = String.Empty, "", Analizar.Remitente),
                                     .Destinatarios = If(IsNothing(Analizar.Destinatarios), "", String.Join(";", Analizar.Destinatarios)),
                                     .Fecha = Analizar.Fecha,
                                     .ConCopia = If(IsNothing(Analizar.ConCopia), "", String.Join(";", Analizar.ConCopia))})

                                'Registra el archivo en el Cleaner
                                Cleaner.Add(New MailEnable.Core.BDD.MailBackupCleaner.Rows With {
                                                 .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
                                                 .Registrado = CDate(Now.ToShortDateString)})
                            End If
                        End If
                    End If
                Catch ex As Exception

                End Try
#End Region

#Region "Calendario"
                'Calendario
                Try
                    If IO.Path.GetExtension(Archivo).ToUpper = $".{NameOf(CAL)}" Then
                        'Comprobar la Antiguedad
                        Dim Fecha As Date
                        If Cleaner.Contains(Cleaner.GetColString(MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo) Then
                            Dim Item As Integer = Cleaner.GetItemIndex(Cleaner.GetColString(MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo)
                            Fecha = Cleaner.Get(Item, Cleaner.GetColString(MailEnable.Core.BDD.MailBackupCleaner.Columnas.Registrado))
                        Else
                            Fecha = Now
                        End If
                        Dim Antiguedad As Integer = DateDiff(DateInterval.Day, Fecha, Now)

                        'Banderas 
                        Dim Indexar As Boolean = False
                        Dim Eliminar As Boolean = False
                        Dim Limpiar As Boolean = False

                        'Si no supera la Antiguedad ni Esta Indexado (Indexar)
                        If Not Antiguedad > Configuracion.ANTIGUEDAD_EMAILS AndAlso Not CAL.Contains(MailEnable.Core.BDD.MailBackup_CAL.Columnas.Archivo.ToString, Archivo) Then Indexar = True


                        'Si no se Indexa y Supera la Antiguedad (Eliminar)
                        If Not Indexar AndAlso Antiguedad > Configuracion.ANTIGUEDAD_EMAILS Then Eliminar = True


                        'Si hay que eliminar y esta Indexado (Limpiar)
                        If Eliminar AndAlso CAL.Contains(MailEnable.Core.BDD.MailBackup_CAL.Columnas.Archivo.ToString, Archivo) Then Limpiar = True


                        'Limpiamos de la BDD
                        If Limpiar Then
                            'Si hay que limpiar
                            Dim Fila As DataRow = CAL.GetRow("Archivo", Archivo)
                            If Not IsNothing(Fila) Then CAL.Tabla.Rows.Remove(Fila)
                        End If

                        'Eliminamos el archivo del Backup
                        If Eliminar Then
                            'Si hay que Eliminar
                            IO.File.Delete(Archivo)
                            Dim Contar As Integer = CInt(IpBanForm.lblLimpiadosBackup.Text.Split(" ")(1).Replace("(", "").Replace(")", ""))
                            Contar += 1
                            Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.lblLimpiadosBackup.Text = $"Limpiados ({Contar})")
                        End If


                        'Indexamos el Archivo
                        If Indexar Then
                            'Si hay que indexar
                            Dim Analizar As New Calendar(Archivo)
                            Analizar.Analizar()
                            CAL.Add(New MailEnable.Core.BDD.MailBackup_CAL.Rows With {
                                 .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
                                 .Descripcion = If(Analizar.Descricion = String.Empty, "", Analizar.Descricion),
                                 .Hubicacion = If(Analizar.Hubicacion = String.Empty, "", Analizar.Hubicacion),
                                 .Inicio = If(Analizar.Inicio = String.Empty, "", Analizar.Inicio),
                                 .Fin = If(Analizar.Fin = String.Empty, "", Analizar.Fin)})

                            'Registra el archivo en el Cleaner
                            Cleaner.Add(New MailEnable.Core.BDD.MailBackupCleaner.Rows With {
                                             .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
                                             .Registrado = CDate(Now.ToShortDateString)})
                        End If
                    End If
                Catch ex As Exception

                End Try
#End Region

#Region "Contactos"
                'Contactos
                Try
                    If IO.Path.GetExtension(Archivo).ToUpper = $".{NameOf(VCF)}" Then
                        'Comprobar la Antiguedad
                        Dim Fecha As Date
                        If Cleaner.Contains(Cleaner.GetColString(MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo) Then
                            Dim Item As Integer = Cleaner.GetItemIndex(Cleaner.GetColString(MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo)
                            Fecha = Cleaner.Get(Item, Cleaner.GetColString(MailEnable.Core.BDD.MailBackupCleaner.Columnas.Registrado))
                        Else
                            Fecha = Now
                        End If
                        Dim Antiguedad As Integer = DateDiff(DateInterval.Day, Fecha, Now)

                        'Banderas 
                        Dim Indexar As Boolean = False
                        Dim Eliminar As Boolean = False
                        Dim Limpiar As Boolean = False

                        'Si no supera la Antiguedad ni Esta Indexado (Indexar)
                        If Not Antiguedad > Configuracion.ANTIGUEDAD_EMAILS AndAlso Not VCF.Contains(MailEnable.Core.BDD.MailBackup_VCF.Columnas.Archivo.ToString, Archivo) Then Indexar = True


                        'Si no se Indexa y Supera la Antiguedad (Eliminar)
                        If Not Indexar AndAlso Antiguedad > Configuracion.ANTIGUEDAD_EMAILS Then Eliminar = True


                        'Si hay que eliminar y esta Indexado (Limpiar)
                        If Eliminar AndAlso VCF.Contains(MailEnable.Core.BDD.MailBackup_VCF.Columnas.Archivo.ToString, Archivo) Then Limpiar = True


                        'Limpiamos de la BDD
                        If Limpiar Then
                            'Si hay que limpiar
                            Dim Fila As DataRow = VCF.GetRow("Archivo", Archivo)
                            If Not IsNothing(Fila) Then VCF.Tabla.Rows.Remove(Fila)
                        End If

                        'Eliminamos el archivo del Backup
                        If Eliminar Then
                            'Si hay que Eliminar
                            IO.File.Delete(Archivo)
                            Dim Contar As Integer = CInt(IpBanForm.lblLimpiadosBackup.Text.Split(" ")(1).Replace("(", "").Replace(")", ""))
                            Contar += 1
                            Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.lblLimpiadosBackup.Text = $"Limpiados ({Contar})")
                        End If


                        'Indexamos el Archivo
                        If Indexar Then
                            'Si hay que indexar
                            Dim Analizar As New Contact(Archivo)
                            Analizar.Analizar()
                            VCF.Add(New MailEnable.Core.BDD.MailBackup_VCF.Rows With {
                                 .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
                                 .Nombre = If(Analizar.Nombre = String.Empty, "", Analizar.Nombre),
                                 .NombreCompleto = If(Analizar.NombreCompleto = String.Empty, "", Analizar.NombreCompleto),
                                 .Email = If(IsNothing(Analizar.Email), "", String.Join(";", Analizar.Email)),
                                 .EmailPersonal = If(IsNothing(Analizar.EmailPersonal), "", String.Join(";", Analizar.EmailPersonal)),
                                 .EmailTrabajo = If(IsNothing(Analizar.EmailTrabajo), "", String.Join(";", Analizar.EmailTrabajo)),
                                 .Nick = If(IsNothing(Analizar.Nick), "", String.Join(";", Analizar.Nick))})

                            'Registra el archivo en el Cleaner
                            Cleaner.Add(New MailEnable.Core.BDD.MailBackupCleaner.Rows With {
                                             .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
                                             .Registrado = CDate(Now.ToShortDateString)})
                        End If


                    End If
                Catch ex As Exception

                End Try
#End Region

#Region "TAREAS"
                'Tareas
                Try
                    If IO.Path.GetExtension(Archivo).ToUpper = $".{NameOf(TSK)}" Then
                        'Comprobar la Antiguedad
                        Dim Fecha As Date
                        If Cleaner.Contains(Cleaner.GetColString(MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo) Then
                            Dim Item As Integer = Cleaner.GetItemIndex(Cleaner.GetColString(MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo)
                            Fecha = Cleaner.Get(Item, Cleaner.GetColString(MailEnable.Core.BDD.MailBackupCleaner.Columnas.Registrado))
                        Else
                            Fecha = Now
                        End If
                        Dim Antiguedad As Integer = DateDiff(DateInterval.Day, Fecha, Now)

                        'Banderas 
                        Dim Indexar As Boolean = False
                        Dim Eliminar As Boolean = False
                        Dim Limpiar As Boolean = False

                        'Si no supera la Antiguedad ni Esta Indexado (Indexar)
                        If Not Antiguedad > Configuracion.ANTIGUEDAD_EMAILS AndAlso Not TSK.Contains(MailEnable.Core.BDD.MailBackup_TSK.Columnas.Archivo.ToString, Archivo) Then Indexar = True


                        'Si no se Indexa y Supera la Antiguedad (Eliminar)
                        If Not Indexar AndAlso Antiguedad > Configuracion.ANTIGUEDAD_EMAILS Then Eliminar = True


                        'Si hay que eliminar y esta Indexado (Limpiar)
                        If Eliminar AndAlso TSK.Contains(MailEnable.Core.BDD.MailBackup_TSK.Columnas.Archivo.ToString, Archivo) Then Limpiar = True


                        'Limpiamos de la BDD
                        If Limpiar Then
                            'Si hay que limpiar
                            Dim Fila As DataRow = TSK.GetRow("Archivo", Archivo)
                            If Not IsNothing(Fila) Then TSK.Tabla.Rows.Remove(Fila)
                        End If

                        'Eliminamos el archivo del Backup
                        If Eliminar Then
                            'Si hay que Eliminar
                            IO.File.Delete(Archivo)
                            Dim Contar As Integer = CInt(IpBanForm.lblLimpiadosBackup.Text.Split(" ")(1).Replace("(", "").Replace(")", ""))
                            Contar += 1
                            Mod_Core.IpBanForm.Invoke(Sub() IpBanForm.lblLimpiadosBackup.Text = $"Limpiados ({Contar})")
                        End If


                        'Indexamos el Archivo
                        If Indexar Then
                            'Si hay que indexar
                            Dim Analizar As New Task(Archivo)
                            Analizar.Analizar()
                            TSK.Add(New MailEnable.Core.BDD.MailBackup_TSK.Rows With {
                                 .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
                                 .Asunto = If(Analizar.Asunto = String.Empty, "", Analizar.Asunto),
                                 .Notas = If(Analizar.Notas = String.Empty, "", Analizar.Notas)})

                            'Registra el archivo en el Cleaner
                            Cleaner.Add(New MailEnable.Core.BDD.MailBackupCleaner.Rows With {
                                             .Archivo = If(Analizar.Archivo = String.Empty, "", Analizar.Archivo),
                                             .Registrado = CDate(Now.ToShortDateString)})
                        End If
                    End If
                Catch ex As Exception

                End Try

            End If
#End Region

        End Sub
        Private Function OriginalPath(Archivo As String) As String
            Return Archivo.Replace(MailEnableLog.Configuracion.CARPETA_BACKUP, MailEnableLog.Configuracion.POST_OFFICES)
        End Function

        Private Sub BuscadoresEvents_Background(Sender As Object, Detener As MailEnable.Core.Bucle.BackgroundEventArgs) Handles BuscadoresEvents.BackGround
            If Not IsNothing(Archivos) Then
                If Not Archivos.IsEmpty Then
                    Dim Archivo As String = String.Empty
                    If Archivos.TryDequeue(Archivo) Then
                        If IO.File.Exists(Archivo) Then AnalizarArchivo(Archivo)
                    End If
            Else
            'Detener = True
            If BuscadorArchivos.Estado = QueneArchivos.EnumEstado.Analizado Then
                If Buscadores.ContainsKey(CType(Sender, MailEnable.Core.Bucle.DoBucle).Name) Then
                    If Buscadores.TryRemove(CType(Sender, MailEnable.Core.Bucle.DoBucle).Name, Nothing) Then
                        RemoveHandler CType(Sender, MailEnable.Core.Bucle.DoBucle).BackGround, AddressOf BuscadoresEvents_Background
                                RemoveHandler CType(Sender, MailEnable.Core.Bucle.DoBucle).ForeGround, AddressOf BuscadoresEvents_Foreground
                                RemoveHandler CType(Sender, MailEnable.Core.Bucle.DoBucle).EndGround, AddressOf BuscadoresEvents_Endground
                            Else
                        Stop
                    End If
                Else
                    RemoveHandler CType(Sender, MailEnable.Core.Bucle.DoBucle).BackGround, AddressOf BuscadoresEvents_Background
                            RemoveHandler CType(Sender, MailEnable.Core.Bucle.DoBucle).ForeGround, AddressOf BuscadoresEvents_Foreground
                            RemoveHandler CType(Sender, MailEnable.Core.Bucle.DoBucle).EndGround, AddressOf BuscadoresEvents_Endground
                        End If
            End If
            End If
            End If
        End Sub

        Private Sub BuscadoresEvents_Foreground(Sender As Object, Detener As MailEnable.Core.Bucle.BackgroundEventArgs) Handles BuscadoresEvents.ForeGround
            'Actualizar Interface
            IpBanForm.lblMensajesBackup.Text = $"Encontrados ({MAI.Tabla.Rows.Count})"

            'Comprobar  Límite de Analizadores
            If Buscadores.Count > Configuracion.ANALIZADORES_BACKUP AndAlso Not Archivos.IsEmpty Then
                'Extraer Buscadores
                Dim Buscador As MailEnable.Core.Bucle.DoBucle = Nothing
                If Buscadores.ContainsKey(CType(Sender, MailEnable.Core.Bucle.DoBucle).Name) Then
                    Buscadores.TryRemove(CType(Sender, MailEnable.Core.Bucle.DoBucle).Name, Nothing)
                End If
            ElseIf Buscadores.Count < Configuracion.ANALIZADORES_BACKUP AndAlso Not Archivos.IsEmpty Then
                'Añadir  Buscadores
                Dim Buscador As KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle) = CrearBuscador()
                If Not IsNothing(Buscador) Then Buscadores.TryAdd(Buscador.Key, Buscador.Value)
                If Buscador.Value.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Value.Iniciar()
            End If

            'Comprobar Buscadores Removidos
            If Not Buscadores.ContainsKey(CType(Sender, MailEnable.Core.Bucle.DoBucle).Name) Then
                RemoveHandler CType(Sender, MailEnable.Core.Bucle.DoBucle).ForeGround, AddressOf BuscadoresEvents_Foreground
                RemoveHandler CType(Sender, MailEnable.Core.Bucle.DoBucle).EndGround, AddressOf BuscadoresEvents_Endground
                RemoveHandler CType(Sender, MailEnable.Core.Bucle.DoBucle).BackGround, AddressOf BuscadoresEvents_Background
                'CType(Sender, Core.Bucle.DoBucle).Matar()
            Else
                'Comprobar Intervalo General
                If CType(Sender, MailEnable.Core.Bucle.DoBucle).Intervalo <> Configuracion.ANALIZADORES_BACKUP_TIMER Then CType(Sender, MailEnable.Core.Bucle.DoBucle).Intervalo = Configuracion.ANALIZADORES_BACKUP_TIMER
            End If
        End Sub

        Private Sub BuscadoresEvents_Endground(Sender As Object, Detener As MailEnable.Core.Bucle.BackgroundEventArgs) Handles BuscadoresEvents.EndGround
            If Not IsNothing(Archivos) Then
                If Not Archivos.IsEmpty Then CType(Sender, MailEnable.Core.Bucle.DoBucle).Iniciar()

                'If Buscadores.All(Function(Buscador) Buscador.Cancelar) Then
                '    If Not AlFinalizarIndexacionNotificado Then AlFinalizarIndexacionNotificado = True : RaiseEvent AlFinalizarIndexacionDeArchivos(Me)
                'End If
            End If
        End Sub
        Private Sub Controlador_Foreground(Sender As Object, Detener As MailEnable.Core.Bucle.BackgroundEventArgs) Handles Controlador.ForeGround
            If Estado = EnumEstado.Analizando Then
                If Archivos.IsEmpty Then
                    For Each Buscador In Buscadores.Values
                        If Buscador.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then
                            Buscador.Iniciar()
                        End If
                    Next
                End If

                If Buscadores.IsEmpty AndAlso Archivos.IsEmpty Then
                    If Not AlFinalizarIndexacionNotificado Then
                        AlFinalizarIndexacionNotificado = True
                        Estado = EnumEstado.Analizado
                        RaiseEvent AlFinalizarIndexacionDeArchivos(Me)
                    End If
                End If
            End If
        End Sub

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: eliminar el estado administrado (objetos administrados)
                    Buscadores.Clear()
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