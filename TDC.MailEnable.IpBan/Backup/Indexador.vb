Imports TDC.MailEnable.IpBan.MailEnableLog
Namespace Backup
    Public Class Indexador
        Implements IDisposable

        Private Archivos As Concurrent.ConcurrentQueue(Of String)
        Private WithEvents BuscadoresEvents As MailEnable.Core.Bucle.DoBucle
        Public ReadOnly Indexadores As New Concurrent.ConcurrentDictionary(Of String, MailEnable.Core.Bucle.DoBucle)
        Private WithEvents Controlador As MailEnable.Core.Bucle.DoBucle
        Private HandlerEventos_BackGround As New Concurrent.ConcurrentDictionary(Of String, MailEnable.Core.Bucle.DoBucle.BackGroundEventHandler)
        Private HandlerEventos_ForeGround As New Concurrent.ConcurrentDictionary(Of String, MailEnable.Core.Bucle.DoBucle.ForeGroundEventHandler)
        Private HandlerEventos_EndGround As New Concurrent.ConcurrentDictionary(Of String, MailEnable.Core.Bucle.DoBucle.EndGroundEventHandler)

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
            Dim Accion As Action(Of String) =
                Sub(KeyIndex As String)
                    Dim nIndexador As KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle) = CrearIndexador(KeyIndex)
                    If Not IsNothing(nIndexador) Then
                        If Not Indexadores.ContainsKey(nIndexador.Key) Then
                            Indexadores.TryAdd(nIndexador.Key, nIndexador.Value)
                        End If
                    Else
                        Stop
                    End If
                End Sub

            For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
                Dim KeyIndex = i
                If IpBanForm.InvokeRequired Then IpBanForm.Invoke(Sub() Accion(KeyIndex)) Else Accion(KeyIndex)
            Next

            Controlador = MailEnable.Core.Bucle.GetOrCreate("Global100")
            Controlador.Iniciar()
        End Sub

        Private Function CrearIndexador(Optional Index As Integer = -1) As KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle)
            Select Case Index
                Case -1
                    For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
                        'Crear Acciones
                        Dim Id = i
                        Dim Key As String = $"MailBackup{Id}"

                        'Crear Delegados
                        If Not HandlerEventos_BackGround.ContainsKey(Key) Then
                            'Crear la Accion
                            Dim nAction As Action(Of String) = CrearAccion_BackGround()
                            'Crear Delegado
                            Dim cEvent_BackGround As MailEnable.Core.Bucle.DoBucle.BackGroundEventHandler = CrearEvento_BackGround(nAction)
                            HandlerEventos_BackGround.TryAdd(Key, cEvent_BackGround)
                        End If

                        If Not HandlerEventos_ForeGround.ContainsKey(Key) Then
                            Dim cEvent_ForeGround As MailEnable.Core.Bucle.DoBucle.ForeGroundEventHandler = CrearEvento_ForeGround()
                            HandlerEventos_ForeGround.TryAdd(Key, cEvent_ForeGround)
                        End If

                        If Not HandlerEventos_EndGround.ContainsKey(Key) Then
                            Dim cEventEndGround As MailEnable.Core.Bucle.DoBucle.EndGroundEventHandler = CrearEvento_EndGround()
                            HandlerEventos_EndGround.TryAdd(Key, cEventEndGround)
                        End If

                        'Crear Bucle
                        If Not Indexadores.ContainsKey(Key) Then
                            Dim nIndexador As MailEnable.Core.Bucle.DoBucle = MailEnable.Core.Bucle.GetOrCreate($"MailBackup{Id}")
                            nIndexador.Intervalo = Configuracion.ANALIZADORES_BACKUP_TIMER
                            AddHandler nIndexador.BackGround, HandlerEventos_BackGround(Key)
                            AddHandler nIndexador.ForeGround, HandlerEventos_ForeGround(Key)
                            AddHandler nIndexador.EndGround, HandlerEventos_EndGround(Key)
                            Indexadores.TryAdd(nIndexador.Name, nIndexador)
                            Return New KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle)(nIndexador.Name, nIndexador)
                        End If
                    Next

                Case Else
                    Dim Key As String = $"MailBackup{Index}"
                    'Crear Delegados
                    If Not HandlerEventos_BackGround.ContainsKey(Key) Then
                        'Crear la Accion
                        Dim nAction As Action(Of String) = CrearAccion_BackGround()
                        'Crear Delegado
                        Dim cEvent_BackGround As MailEnable.Core.Bucle.DoBucle.BackGroundEventHandler = CrearEvento_BackGround(nAction)
                        HandlerEventos_BackGround.TryAdd(Key, cEvent_BackGround)
                    End If

                    If Not HandlerEventos_ForeGround.ContainsKey(Key) Then
                        Dim cEvent_ForeGround As MailEnable.Core.Bucle.DoBucle.ForeGroundEventHandler = CrearEvento_ForeGround()
                        HandlerEventos_ForeGround.TryAdd(Key, cEvent_ForeGround)
                    End If

                    If Not HandlerEventos_EndGround.ContainsKey(Key) Then
                        Dim cEventEndGround As MailEnable.Core.Bucle.DoBucle.EndGroundEventHandler = CrearEvento_EndGround()
                        HandlerEventos_EndGround.TryAdd(Key, cEventEndGround)
                    End If

                    'Crear el bucle
                    If Not Indexadores.ContainsKey($"MailBackup{Index}") Then
                        Dim nIndexador As MailEnable.Core.Bucle.DoBucle = MailEnable.Core.Bucle.GetOrCreate($"MailBackup{Index}")
                        nIndexador.Intervalo = Configuracion.ANALIZADORES_BACKUP_TIMER
                        AddHandler nIndexador.BackGround, HandlerEventos_BackGround(Key)
                        AddHandler nIndexador.ForeGround, HandlerEventos_ForeGround(Key)
                        AddHandler nIndexador.EndGround, HandlerEventos_EndGround(Key)
                        Indexadores.TryAdd(nIndexador.Name, nIndexador)
                        Return New KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle)(nIndexador.Name, nIndexador)
                    End If
            End Select
            Return Nothing
        End Function
        Private Function CrearEvento_ForeGround() As MailEnable.Core.Bucle.DoBucle.ForeGroundEventHandler
            Dim cEvent As MailEnable.Core.Bucle.DoBucle.ForeGroundEventHandler =
                Sub(sender As Object, e As MailEnable.Core.Bucle.BackgroundEventArgs)
                    'Actualizar Interface
                    IpBanForm.lblMensajesBackup.Text = $"Encontrados ({MAI.Tabla.Rows.Count})"

                    'Comprobar  Límite de Analizadores
                    If Indexadores.Count > Configuracion.ANALIZADORES_BACKUP AndAlso Not Archivos.IsEmpty Then
                        'Extraer Buscadores
                        Dim Buscador As MailEnable.Core.Bucle.DoBucle = Nothing
                        If Indexadores.ContainsKey(CType(sender, MailEnable.Core.Bucle.DoBucle).Name) Then
                            Indexadores.TryRemove(CType(sender, MailEnable.Core.Bucle.DoBucle).Name, Nothing)
                        End If
                    ElseIf Indexadores.Count < Configuracion.ANALIZADORES_BACKUP AndAlso Not Archivos.IsEmpty Then
                        'Añadir  Buscadores
                        Dim Buscador As KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle) = CrearIndexador()
                        If Not IsNothing(Buscador) Then Indexadores.TryAdd(Buscador.Key, Buscador.Value)
                        If Buscador.Value.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Value.Iniciar()
                    End If

                    'Comprobar Buscadores Removidos
                    If Not Indexadores.ContainsKey(CType(sender, MailEnable.Core.Bucle.DoBucle).Name) Then
                        RemoveHandler CType(sender, MailEnable.Core.Bucle.DoBucle).ForeGround, HandlerEventos_ForeGround(CType(sender, MailEnable.Core.Bucle.DoBucle).Name)
                        RemoveHandler CType(sender, MailEnable.Core.Bucle.DoBucle).EndGround, HandlerEventos_EndGround(CType(sender, MailEnable.Core.Bucle.DoBucle).Name)
                        RemoveHandler CType(sender, MailEnable.Core.Bucle.DoBucle).BackGround, HandlerEventos_BackGround(CType(sender, MailEnable.Core.Bucle.DoBucle).Name)
                        If CType(sender, MailEnable.Core.Bucle.DoBucle).Estado = MailEnable.Core.Bucle.DoBucle.EnumEstado.Corriendo Then CType(sender, MailEnable.Core.Bucle.DoBucle).Detener()
                    Else
                        'Comprobar Intervalo General
                        If CType(sender, MailEnable.Core.Bucle.DoBucle).Intervalo <> Configuracion.ANALIZADORES_BACKUP_TIMER Then CType(sender, MailEnable.Core.Bucle.DoBucle).Intervalo = Configuracion.ANALIZADORES_BACKUP_TIMER
                    End If
                End Sub
            Return cEvent
        End Function
        Private Function CrearEvento_EndGround() As MailEnable.Core.Bucle.DoBucle.EndGroundEventHandler
            Dim cEvent As MailEnable.Core.Bucle.DoBucle.EndGroundEventHandler =
                Sub(sender As Object, e As MailEnable.Core.Bucle.BackgroundEventArgs)
                    If Not IsNothing(Archivos) Then If Not Archivos.IsEmpty Then CType(sender, MailEnable.Core.Bucle.DoBucle).Iniciar()
                End Sub
        End Function
        Private Function CrearEvento_BackGround(nAction As Action(Of String)) As MailEnable.Core.Bucle.DoBucle.BackGroundEventHandler
            Dim cEvent As MailEnable.Core.Bucle.DoBucle.BackGroundEventHandler =
                Sub(sender As Object, e As MailEnable.Core.Bucle.BackgroundEventArgs)
                    If Not IsNothing(Archivos) Then
                        If Not Archivos.IsEmpty Then
                            Dim Archivo As String = String.Empty
                            If Archivos.TryDequeue(Archivo) Then
                                If IO.File.Exists(Archivo) Then nAction.Invoke(Archivo)
                            End If
                        Else
                            'Detener = True
                            If BuscadorArchivos.Estado = QueneArchivos.EnumEstado.Analizado Then
                                If Indexadores.ContainsKey(CType(sender, MailEnable.Core.Bucle.DoBucle).Name) Then
                                    If Indexadores.TryRemove(CType(sender, MailEnable.Core.Bucle.DoBucle).Name, Nothing) Then
                                        RemoveHandler CType(sender, MailEnable.Core.Bucle.DoBucle).ForeGround, HandlerEventos_ForeGround(CType(sender, MailEnable.Core.Bucle.DoBucle).Name)
                                        RemoveHandler CType(sender, MailEnable.Core.Bucle.DoBucle).EndGround, HandlerEventos_EndGround(CType(sender, MailEnable.Core.Bucle.DoBucle).Name)
                                        RemoveHandler CType(sender, MailEnable.Core.Bucle.DoBucle).BackGround, HandlerEventos_BackGround(CType(sender, MailEnable.Core.Bucle.DoBucle).Name)
                                    Else
                                        Stop
                                    End If
                                Else
                                    RemoveHandler CType(sender, MailEnable.Core.Bucle.DoBucle).ForeGround, HandlerEventos_ForeGround(CType(sender, MailEnable.Core.Bucle.DoBucle).Name)
                                    RemoveHandler CType(sender, MailEnable.Core.Bucle.DoBucle).EndGround, HandlerEventos_EndGround(CType(sender, MailEnable.Core.Bucle.DoBucle).Name)
                                    RemoveHandler CType(sender, MailEnable.Core.Bucle.DoBucle).BackGround, HandlerEventos_BackGround(CType(sender, MailEnable.Core.Bucle.DoBucle).Name)
                                End If
                            End If
                        End If
                    End If
                End Sub
            Return cEvent
        End Function

        Private Function CrearAccion_ForeGround()

        End Function
        Private Function CrearAccionEndGround()

        End Function
        Private Function CrearAccion_BackGround() As Action(Of String)
            Dim nAction As Action(Of String) = Sub(Archivo As String)
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
                                                                       Dim Analizar As New Email(Archivo)
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
            Return nAction
        End Function

        Public Sub Analizar(Archivos As Concurrent.ConcurrentQueue(Of String))
            Me.Archivos = Archivos

            If Indexadores.IsEmpty Then
                For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
                    Dim Buscador As KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle) = CrearIndexador(i)
                    If Not IsNothing(Buscador) Then
                        Indexadores.TryAdd(Buscador.Key, Buscador.Value)
                    Else
                        Stop
                    End If
                Next
            End If

            For Each Buscador In Indexadores.Values
                If Buscador.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Iniciar()
            Next
            AlFinalizarIndexacionNotificado = False
            Estado = EnumEstado.Analizando
        End Sub
        Public Sub Continuar()
            For Each Buscador In Indexadores.Values
                Try
                    If Buscador.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Iniciar()
                    AlFinalizarIndexacionNotificado = False
                Catch ex As Exception
                    Stop
                End Try
            Next
        End Sub

        Private Function OriginalPath(Archivo As String) As String
            Return Archivo.Replace(MailEnableLog.Configuracion.CARPETA_BACKUP, MailEnableLog.Configuracion.POST_OFFICES)
        End Function


        Private Sub BuscadoresEvents_Foreground(Sender As Object, Detener As MailEnable.Core.Bucle.BackgroundEventArgs) Handles BuscadoresEvents.ForeGround
            'Actualizar Interface
            IpBanForm.lblMensajesBackup.Text = $"Encontrados ({MAI.Tabla.Rows.Count})"

            'Comprobar  Límite de Analizadores
            If Indexadores.Count > Configuracion.ANALIZADORES_BACKUP AndAlso Not Archivos.IsEmpty Then
                'Extraer Buscadores
                Dim Buscador As MailEnable.Core.Bucle.DoBucle = Nothing
                If Indexadores.ContainsKey(CType(Sender, MailEnable.Core.Bucle.DoBucle).Name) Then
                    Indexadores.TryRemove(CType(Sender, MailEnable.Core.Bucle.DoBucle).Name, Nothing)
                End If
            ElseIf Indexadores.Count < Configuracion.ANALIZADORES_BACKUP AndAlso Not Archivos.IsEmpty Then
                'Añadir  Buscadores
                Dim Buscador As KeyValuePair(Of String, MailEnable.Core.Bucle.DoBucle) = CrearIndexador()
                If Not IsNothing(Buscador) Then Indexadores.TryAdd(Buscador.Key, Buscador.Value)
                If Buscador.Value.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Value.Iniciar()
            End If

            'Comprobar Buscadores Removidos
            If Not Indexadores.ContainsKey(CType(Sender, MailEnable.Core.Bucle.DoBucle).Name) Then
                RemoveHandler CType(Sender, MailEnable.Core.Bucle.DoBucle).ForeGround, AddressOf BuscadoresEvents_Foreground
                RemoveHandler CType(Sender, MailEnable.Core.Bucle.DoBucle).EndGround, AddressOf BuscadoresEvents_Endground
                RemoveHandler CType(Sender, MailEnable.Core.Bucle.DoBucle).BackGround, HandlerEventos_BackGround(CType(Sender, MailEnable.Core.Bucle.DoBucle).Name)
                If CType(Sender, MailEnable.Core.Bucle.DoBucle).Estado = MailEnable.Core.Bucle.DoBucle.EnumEstado.Corriendo Then CType(Sender, MailEnable.Core.Bucle.DoBucle).Detener()
            Else
                'Comprobar Intervalo General
                If CType(Sender, MailEnable.Core.Bucle.DoBucle).Intervalo <> Configuracion.ANALIZADORES_BACKUP_TIMER Then CType(Sender, MailEnable.Core.Bucle.DoBucle).Intervalo = Configuracion.ANALIZADORES_BACKUP_TIMER
            End If
        End Sub

        Private Sub BuscadoresEvents_Endground(Sender As Object, Detener As MailEnable.Core.Bucle.BackgroundEventArgs) Handles BuscadoresEvents.EndGround
            If Not IsNothing(Archivos) Then If Not Archivos.IsEmpty Then CType(Sender, MailEnable.Core.Bucle.DoBucle).Iniciar()
        End Sub
        Private Sub Controlador_Foreground(Sender As Object, Detener As MailEnable.Core.Bucle.BackgroundEventArgs) Handles Controlador.ForeGround
            If Estado = EnumEstado.Analizando Then
                If Archivos.IsEmpty Then
                    For Each Buscador In Indexadores.Values
                        If Buscador.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then
                            Buscador.Iniciar()
                        End If
                    Next
                End If

                If Indexadores.IsEmpty AndAlso Archivos.IsEmpty Then
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
                    Indexadores.Clear()
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