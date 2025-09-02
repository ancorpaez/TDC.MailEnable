Imports TDC.MailEnable.Core.Bucle
Imports TDC.MailEnable.IpBan.MailEnable
Namespace Backup
    Public Class Indexador

        Private Archivos As Concurrent.ConcurrentQueue(Of String)
        'Subprocesos únicos almacenados para indexar los archivos de Email
        Public ReadOnly Indexadores As New Concurrent.ConcurrentDictionary(Of String, DoBucle)

        'Cerciora que se han procesado todos los archivos antes de activar el evento AlFinalizarIndexacionDeArchivos
        'Indexa el las colas en sus tablas
        Private WithEvents Controlador As DoBucle
        Private QueneToTable As Boolean = False

        'Almacena los delegados de los procesos BackGroundEventHandler creados por CrearIndexador
        Private ReadOnly HandlerEventos_BackGround As New Concurrent.ConcurrentDictionary(Of String, DoBucle.BackGroundEventHandler)
        'Almacena los delegados de los procesos ForeGroundEventHandler creados por CrearIndexador
        Private ReadOnly HandlerEventos_ForeGround As New Concurrent.ConcurrentDictionary(Of String, DoBucle.ForeGroundEventHandler)
        'Almacena los delegados de los procesos EndGroundEventHandler creados por CrearIndexador
        Private ReadOnly HandlerEventos_EndGround As New Concurrent.ConcurrentDictionary(Of String, DoBucle.EndGroundEventHandler)

        Private ReadOnly Property QueneEmails As New Concurrent.ConcurrentQueue(Of Email)
        Private ReadOnly QueneCalendar As New Concurrent.ConcurrentQueue(Of Calendar)
        Private ReadOnly QueneTask As New Concurrent.ConcurrentQueue(Of Task)
        Private ReadOnly QueneContact As New Concurrent.ConcurrentQueue(Of Contact)


        Dim disposedValue As Boolean
        Public Event AlFinalizarIndexacionDeArchivos(sender As Object)
        Private AlFinalizarIndexacionNotificado As Boolean = False

        'Estados del Indexador
        Public Enum EnumEstado
            Iniciando
            Analizando
            Analizado
        End Enum

        'Indica el estado actual del Indexador
        Public Property Estado As EnumEstado = EnumEstado.Iniciando

        Public Sub New()
            Dim Accion As New Action(Of String)(
                Sub(KeyIndex As String)
                    Dim nIndexador As KeyValuePair(Of String, DoBucle) = CrearIndexador(KeyIndex)
                    If IsNothing(nIndexador) Then
                        Throw New Exception("No se pudo crear el Indexador")
                    End If
                End Sub)

            For i = 0 To MailEnable.Main.Configuracion.ANALIZADORES_BACKUP - 1
                Dim KeyIndex = i
                If IpBanForm.InvokeRequired Then IpBanForm.Invoke(Sub() Accion.Invoke(KeyIndex)) Else Accion.Invoke(KeyIndex)
            Next

            Controlador = GetOrCreate("QuenedIndexToTable")
        End Sub
        Public Sub Continuar()
            For Each Buscador In Indexadores.Values
                Try
                    If Buscador.Estado = DoBucle.EnumEstado.Detenido Then Buscador.Iniciar()
                    AlFinalizarIndexacionNotificado = False
                Catch ex As Exception
                    Stop
                End Try
            Next
        End Sub
        Public Sub Analizar(Archivos As Concurrent.ConcurrentQueue(Of String))
            Me.Archivos = Archivos

            If Indexadores.IsEmpty Then
                For i = 0 To MailEnable.Main.Configuracion.ANALIZADORES_BACKUP - 1
                    Dim Buscador As KeyValuePair(Of String, DoBucle) = CrearIndexador(i)
                    If Not IsNothing(Buscador) Then
                        Indexadores.TryAdd(Buscador.Key, Buscador.Value)
                    Else
                        Stop
                    End If
                Next
            End If

            For Each Buscador In Indexadores.Values
                If Buscador.Estado = DoBucle.EnumEstado.Detenido Then Buscador.Iniciar()
            Next

            AlFinalizarIndexacionNotificado = False
            Estado = EnumEstado.Analizando
            QueneToTable = False

            Controlador.Iniciar()
        End Sub
        Public Function Quened() As Integer
            Dim Q As Integer = 0
            Q += QueneEmails.Count
            Q += QueneContact.Count
            Q += QueneCalendar.Count
            Q += QueneTask.Count
            Return Q
        End Function
        Private Function CrearIndexador(Optional Index As Integer = -1) As KeyValuePair(Of String, DoBucle)
            Select Case Index
                Case -1
                    'Crea todos los Indexadores establecidos en ANALIZADORES_BACKUP
                    For i = 0 To MailEnable.Main.Configuracion.ANALIZADORES_BACKUP - 1
                        Dim nIndexador = NuevoIndexador(i)
                        If Not IsNothing(nIndexador.Value) Then Return nIndexador
                    Next

                Case Else
                    Return NuevoIndexador(Index)
            End Select
            Return Nothing
        End Function
        Private Function NuevoIndexador(Index As Integer) As KeyValuePair(Of String, DoBucle)
            'Crear Acciones
            Dim Id = Index
            Dim Key As String = $"MailBackup{Id}"

            'Crear Delegados
            If Not HandlerEventos_BackGround.ContainsKey(Key) Then
                'Crear Delegado BackGround con su Action
                Dim cEvent_BackGround As DoBucle.BackGroundEventHandler = CrearEvento_BackGround(CrearAccion_BackGround)
                HandlerEventos_BackGround.TryAdd(Key, cEvent_BackGround)
            End If

            If Not HandlerEventos_ForeGround.ContainsKey(Key) Then
                'Crear Delegado ForeGround con su Action
                Dim cEvent_ForeGround As DoBucle.ForeGroundEventHandler = CrearEvento_ForeGround()
                HandlerEventos_ForeGround.TryAdd(Key, cEvent_ForeGround)
            End If

            If Not HandlerEventos_EndGround.ContainsKey(Key) Then
                'Crear Delegado EndGround con su Action
                Dim cEventEndGround As DoBucle.EndGroundEventHandler = CrearEvento_EndGround()
                HandlerEventos_EndGround.TryAdd(Key, cEventEndGround)
            End If

            'Crear Bucle
            If Not Indexadores.ContainsKey(Key) Then
                'Crear el Indexador (DoBucle)
                Dim nIndexador As DoBucle = GetOrCreate($"MailBackup{Id}")
                nIndexador.Intervalo = MailEnable.Main.Configuracion.ANALIZADORES_BACKUP_TIMER
                AddHandler nIndexador.BackGround, HandlerEventos_BackGround(Key)
                AddHandler nIndexador.ForeGround, HandlerEventos_ForeGround(Key)
                AddHandler nIndexador.EndGround, HandlerEventos_EndGround(Key)
                Indexadores.TryAdd(nIndexador.Name, nIndexador)
                Return New KeyValuePair(Of String, DoBucle)(nIndexador.Name, nIndexador)
            End If

            Return Nothing
        End Function
        Private Function CrearEvento_BackGround(Analizador As Action(Of String)) As DoBucle.BackGroundEventHandler
            Return New DoBucle.BackGroundEventHandler(
                Sub(sender As Object, e As BackgroundEventArgs)
                    If Not IsNothing(Archivos) Then
                        If Not Archivos.IsEmpty Then
                            Dim Archivo As String = String.Empty
                            If Archivos.TryDequeue(Archivo) Then
                                If IO.File.Exists(Archivo) Then Analizador.Invoke(Archivo)
                            End If
                        Else
                            'Detener = True
                            If BuscadorArchivos.Estado = QueneArchivos.EnumEstado.Analizado Then
                                If Indexadores.ContainsKey(CType(sender, DoBucle).Name) Then
                                    If Not Indexadores.TryRemove(CType(sender, DoBucle).Name, Nothing) Then
                                        Throw New Exception("No se pudo desenlazar el Indexador.")
                                    End If
                                End If
                            End If
                        End If
                    End If
                End Sub)
        End Function
        Private Function CrearEvento_ForeGround() As DoBucle.ForeGroundEventHandler
            Return New DoBucle.ForeGroundEventHandler(
                  Sub(sender As Object, e As BackgroundEventArgs)
                      Dim Value As DoBucle = sender
                      Dim Key As String = Value.Name

                      'Actualizar el Interface con los Eliminados
                      IpBanForm.lblLimpiadosBackup.Text = $"Eliminados ({Eliminados})"

                      'Comprobar  Límite de Analizadores
                      If Indexadores.Count > MailEnable.Main.Configuracion.ANALIZADORES_BACKUP AndAlso Not Archivos.IsEmpty Then
                          'Extraer Buscadores
                          Dim Buscador As DoBucle = Nothing
                          If Indexadores.ContainsKey(Key) Then
                              Indexadores.TryRemove(Key, Nothing)
                          End If
                      ElseIf Indexadores.Count < MailEnable.Main.Configuracion.ANALIZADORES_BACKUP AndAlso Not Archivos.IsEmpty Then
                          'Añadir  Buscadores
                          Dim Buscador As KeyValuePair(Of String, DoBucle) = CrearIndexador()
                          If Not IsNothing(Buscador.Value) Then
                              If Indexadores.ContainsKey(Buscador.Key) Then
                                  Indexadores.TryAdd(Buscador.Key, Buscador.Value)
                                  If Buscador.Value.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Value.Iniciar()
                              End If
                          End If
                      End If

                      'Comprobar Buscadores Removidos
                      If Not Indexadores.ContainsKey(Key) Then
                          RemoveHandler Value.BackGround, HandlerEventos_BackGround(Key)
                          RemoveHandler Value.ForeGround, HandlerEventos_ForeGround(Key)
                          RemoveHandler Value.EndGround, HandlerEventos_EndGround(Key)
                          If Value.Estado = DoBucle.EnumEstado.Corriendo Then Value.Detener()
                      Else
                          'Comprobar Intervalo General
                          If Value.Intervalo <> MailEnable.Main.Configuracion.ANALIZADORES_BACKUP_TIMER Then Value.Intervalo = MailEnable.Main.Configuracion.ANALIZADORES_BACKUP_TIMER
                      End If
                  End Sub)
        End Function
        Private Function CrearEvento_EndGround() As DoBucle.EndGroundEventHandler
            Return New DoBucle.EndGroundEventHandler(
                Sub(sender As Object, e As BackgroundEventArgs)
                    If Not IsNothing(Archivos) Then If Not Archivos.IsEmpty Then CType(sender, DoBucle).Iniciar()
                End Sub)
        End Function

        'Variable de paso entre el BackGround y el ForeGround
        Private Eliminados As Integer = 0
        Private Function CrearAccion_BackGround() As Action(Of String)
            Return New Action(Of String)(
                Sub(Archivo As String)
                    If Not IO.File.Exists(OriginalPath(Archivo)) Then
#Region "Email"
                        'Emails
                        Try
                            If IO.Path.GetExtension(Archivo).ToUpper = $".{NameOf(MAI)}" Then
                                'Comprobar la Antiguedad
                                Dim Fecha As Date
                                If Cleaner.Contains(Cleaner.GetColString(TDC.MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo) Then
                                    Dim Item As Integer = Cleaner.GetItemIndex(Cleaner.GetColString(TDC.MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo)
                                    Fecha = Cleaner.Get(Item, Cleaner.GetColString(TDC.MailEnable.Core.BDD.MailBackupCleaner.Columnas.Registrado))
                                Else
                                    Fecha = Now
                                End If
                                Dim Antiguedad As Integer = DateDiff(DateInterval.Day, Fecha, Now)

                                'Banderas 
                                Dim Indexar As Boolean = False
                                Dim Eliminar As Boolean = False
                                Dim Limpiar As Boolean = False

                                'Si no supera la Antiguedad ni Esta Indexado (Indexar)
                                If Not Antiguedad > MailEnable.Main.Configuracion.ANTIGUEDAD_EMAILS AndAlso Not MAI.Contains(TDC.MailEnable.Core.BDD.MailBackup_MAI.Columnas.Archivo.ToString, Archivo) Then Indexar = True

                                'Si no se Indexa y Supera la Antiguedad (Eliminar)
                                If Not Indexar AndAlso Antiguedad > MailEnable.Main.Configuracion.ANTIGUEDAD_EMAILS Then Eliminar = True

                                'Si hay que eliminar y esta Indexado (Limpiar)
                                If Eliminar AndAlso MAI.Contains(TDC.MailEnable.Core.BDD.MailBackup_MAI.Columnas.Archivo.ToString, Archivo) Then Limpiar = True

                                'Limpiamos de la BDD
                                If Limpiar Then
                                    'Si hay que limpiar
                                    Dim Fila As DataRow = MAI.GetRow("Archivo", Archivo)
                                    If Not IsNothing(Fila) Then MAI.Remove(Fila)
                                End If

                                'Eliminamos el archivo del Backup
                                If Eliminar Then
                                    'Si hay que Eliminar
                                    IO.File.Delete(Archivo)
                                    Eliminados += 1
                                End If

                                'Indexamos el Archivo
                                If Indexar Then
                                    'Si hay que indexar
                                    If IO.File.Exists(Archivo) Then QueneEmails.Enqueue(New Email(Archivo))
                                End If

                                'Ajuste para Actualizar la Tabla MAI con la Fecha de la Indexación
                                'If Not Indexar AndAlso Not Eliminar AndAlso Not Limpiar Then
                                '    'Si no realizamos ninguna acción, Significa que está Vigente y debo Comprobar si Detectado está Vacío
                                '    Dim MAIRow As DataRow = MAI.GetRow("Archivo", Archivo)
                                '    If IsDBNull(MAIRow("Detectado")) Then
                                '        MAI.Update(MAIRow("ID"), "Detectado", Fecha)
                                '    End If
                                'End If
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
                                If Cleaner.Contains(Cleaner.GetColString(TDC.MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo) Then
                                    Dim Item As Integer = Cleaner.GetItemIndex(Cleaner.GetColString(TDC.MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo)
                                    Fecha = Cleaner.Get(Item, Cleaner.GetColString(TDC.MailEnable.Core.BDD.MailBackupCleaner.Columnas.Registrado))
                                Else
                                    Fecha = Now
                                End If
                                Dim Antiguedad As Integer = DateDiff(DateInterval.Day, Fecha, Now)

                                'Banderas 
                                Dim Indexar As Boolean = False
                                Dim Eliminar As Boolean = False
                                Dim Limpiar As Boolean = False

                                'Si no supera la Antiguedad ni Esta Indexado (Indexar)
                                If Not Antiguedad > MailEnable.Main.Configuracion.ANTIGUEDAD_EMAILS AndAlso Not CAL.Contains(TDC.MailEnable.Core.BDD.MailBackup_CAL.Columnas.Archivo.ToString, Archivo) Then Indexar = True


                                'Si no se Indexa y Supera la Antiguedad (Eliminar)
                                If Not Indexar AndAlso Antiguedad > MailEnable.Main.Configuracion.ANTIGUEDAD_EMAILS Then Eliminar = True


                                'Si hay que eliminar y esta Indexado (Limpiar)
                                If Eliminar AndAlso CAL.Contains(TDC.MailEnable.Core.BDD.MailBackup_CAL.Columnas.Archivo.ToString, Archivo) Then Limpiar = True


                                'Limpiamos de la BDD
                                If Limpiar Then
                                    'Si hay que limpiar
                                    Dim Fila As DataRow = CAL.GetRow("Archivo", Archivo)
                                    If Not IsNothing(Fila) Then CAL.Remove(Fila)
                                End If

                                'Eliminamos el archivo del Backup
                                If Eliminar Then
                                    'Si hay que Eliminar
                                    IO.File.Delete(Archivo)
                                    Eliminados += 1
                                End If


                                'Si hay que Indexar
                                If Indexar Then QueneCalendar.Enqueue(New Calendar(Archivo))

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
                                If Cleaner.Contains(Cleaner.GetColString(TDC.MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo) Then
                                    Dim Item As Integer = Cleaner.GetItemIndex(Cleaner.GetColString(TDC.MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo)
                                    Fecha = Cleaner.Get(Item, Cleaner.GetColString(TDC.MailEnable.Core.BDD.MailBackupCleaner.Columnas.Registrado))
                                Else
                                    Fecha = Now
                                End If
                                Dim Antiguedad As Integer = DateDiff(DateInterval.Day, Fecha, Now)

                                'Banderas 
                                Dim Indexar As Boolean = False
                                Dim Eliminar As Boolean = False
                                Dim Limpiar As Boolean = False

                                'Si no supera la Antiguedad ni Esta Indexado (Indexar)
                                If Not Antiguedad > MailEnable.Main.Configuracion.ANTIGUEDAD_EMAILS AndAlso Not VCF.Contains(TDC.MailEnable.Core.BDD.MailBackup_VCF.Columnas.Archivo.ToString, Archivo) Then Indexar = True


                                'Si no se Indexa y Supera la Antiguedad (Eliminar)
                                If Not Indexar AndAlso Antiguedad > MailEnable.Main.Configuracion.ANTIGUEDAD_EMAILS Then Eliminar = True


                                'Si hay que eliminar y esta Indexado (Limpiar)
                                If Eliminar AndAlso VCF.Contains(TDC.MailEnable.Core.BDD.MailBackup_VCF.Columnas.Archivo.ToString, Archivo) Then Limpiar = True


                                'Limpiamos de la BDD
                                If Limpiar Then
                                    'Si hay que limpiar
                                    Dim Fila As DataRow = VCF.GetRow("Archivo", Archivo)
                                    If Not IsNothing(Fila) Then VCF.Remove(Fila)
                                End If

                                'Eliminamos el archivo del Backup
                                If Eliminar Then
                                    'Si hay que Eliminar
                                    IO.File.Delete(Archivo)
                                    Eliminados += 1
                                    'Dim Contar As Integer = CInt(IpBanForm.lblLimpiadosBackup.Text.Split(" ")(1).Replace("(", "").Replace(")", ""))
                                    'Contar += 1
                                    'MailEnable.IpBanForm.Invoke(Sub() IpBanForm.lblLimpiadosBackup.Text = $"Limpiados ({Contar})")
                                End If


                                'Si hay que indexar
                                If Indexar Then QueneContact.Enqueue(New Contact(Archivo))

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
                                If Cleaner.Contains(Cleaner.GetColString(TDC.MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo) Then
                                    Dim Item As Integer = Cleaner.GetItemIndex(Cleaner.GetColString(TDC.MailEnable.Core.BDD.MailBackupCleaner.Columnas.Archivo), Archivo)
                                    Fecha = Cleaner.Get(Item, Cleaner.GetColString(TDC.MailEnable.Core.BDD.MailBackupCleaner.Columnas.Registrado))
                                Else
                                    Fecha = Now
                                End If
                                Dim Antiguedad As Integer = DateDiff(DateInterval.Day, Fecha, Now)

                                'Banderas 
                                Dim Indexar As Boolean = False
                                Dim Eliminar As Boolean = False
                                Dim Limpiar As Boolean = False

                                'Si no supera la Antiguedad ni Esta Indexado (Indexar)
                                If Not Antiguedad > MailEnable.Main.Configuracion.ANTIGUEDAD_EMAILS AndAlso Not TSK.Contains(TDC.MailEnable.Core.BDD.MailBackup_TSK.Columnas.Archivo.ToString, Archivo) Then Indexar = True


                                'Si no se Indexa y Supera la Antiguedad (Eliminar)
                                If Not Indexar AndAlso Antiguedad > MailEnable.Main.Configuracion.ANTIGUEDAD_EMAILS Then Eliminar = True


                                'Si hay que eliminar y esta Indexado (Limpiar)
                                If Eliminar AndAlso TSK.Contains(TDC.MailEnable.Core.BDD.MailBackup_TSK.Columnas.Archivo.ToString, Archivo) Then Limpiar = True


                                'Limpiamos de la BDD
                                If Limpiar Then
                                    'Si hay que limpiar
                                    Dim Fila As DataRow = TSK.GetRow("Archivo", Archivo)
                                    If Not IsNothing(Fila) Then TSK.Remove(Fila)
                                End If

                                'Eliminamos el archivo del Backup
                                If Eliminar Then
                                    'Si hay que Eliminar
                                    IO.File.Delete(Archivo)
                                    Eliminados += 1
                                    'Dim Contar As Integer = CInt(IpBanForm.lblLimpiadosBackup.Text.Split(" ")(1).Replace("(", "").Replace(")", ""))
                                    'Contar += 1
                                    'MailEnable.IpBanForm.Invoke(Sub() IpBanForm.lblLimpiadosBackup.Text = $"Limpiados ({Contar})")
                                End If


                                'Si hay que indexar
                                If Indexar Then QueneTask.Enqueue(New Task(Archivo))

                            End If
                        Catch ex As Exception

                        End Try

                    End If
#End Region
                End Sub)
        End Function
        Private Sub Controlador_BackGround(Sender As Object, e As BackgroundEventArgs) Handles Controlador.BackGround
            If QueneToTable Then

                'Arreglo para actializar registros desde añadir el campo Detectado a la tabla
                'For Each Email As DataRow In MAI.Tabla.Rows
                '    If IsDBNull(Email("Detectado")) Then
                '        Dim rCleaner As DataRow = Cleaner.GetRow("Archivo", Email("Archivo"))
                '        If Not IsNothing(rCleaner) Then
                '            MAI.Update(Email("ID"), "Detectado", rCleaner("Registrado"))
                '        End If
                '    End If
                'Next

                'Indexar Emails
                Do While Not QueneEmails.IsEmpty
                    Dim MaiQuene As Email = Nothing
                    If QueneEmails.TryDequeue(MaiQuene) Then

                        MAI.Add(New TDC.MailEnable.Core.BDD.MailBackup_MAI.Rows With {
                                                      .Archivo = If(MaiQuene.Archivo = String.Empty, "", MaiQuene.Archivo),
                                                      .Asunto = If(MaiQuene.Asunto = String.Empty, "", MaiQuene.Asunto),
                                                      .Remitente = If(MaiQuene.Remitente = String.Empty, "", MaiQuene.Remitente),
                                                      .Destinatarios = If(IsNothing(MaiQuene.Destinatarios), "", String.Join(";", MaiQuene.Destinatarios)),
                                                      .Fecha = MaiQuene.Fecha,
                                                      .ConCopia = If(IsNothing(MaiQuene.ConCopia), "", String.Join(";", MaiQuene.ConCopia)),
                                                      .Detectado = Now.ToShortDateString})

                        'Registra el archivo en el Cleaner
                        Cleaner.Add(New TDC.MailEnable.Core.BDD.MailBackupCleaner.Rows With {
                                                                  .Archivo = If(MaiQuene.Archivo = String.Empty, "", MaiQuene.Archivo),
                                                                  .Registrado = CDate(Now.ToShortDateString)})
                    End If
                Loop

                'Indexar Calendario
                Do While Not QueneCalendar.IsEmpty
                    Dim CalQuene As Calendar = Nothing
                    If QueneCalendar.TryDequeue(CalQuene) Then
                        CAL.Add(New TDC.MailEnable.Core.BDD.MailBackup_CAL.Rows With {
                                                      .Archivo = If(CalQuene.Archivo = String.Empty, "", CalQuene.Archivo),
                                                      .Descripcion = If(CalQuene.Descricion = String.Empty, "", CalQuene.Descricion),
                                                      .Hubicacion = If(CalQuene.Hubicacion = String.Empty, "", CalQuene.Hubicacion),
                                                      .Inicio = If(CalQuene.Inicio = String.Empty, "", CalQuene.Inicio),
                                                      .Fin = If(CalQuene.Fin = String.Empty, "", CalQuene.Fin)})

                        'Registra el archivo en el Cleaner
                        Cleaner.Add(New TDC.MailEnable.Core.BDD.MailBackupCleaner.Rows With {
                                                                  .Archivo = If(CalQuene.Archivo = String.Empty, "", CalQuene.Archivo),
                                                                  .Registrado = CDate(Now.ToShortDateString)})
                    End If
                Loop

                'Indexar Tareas
                Do While Not QueneTask.IsEmpty
                    Dim TskQuene As Task = Nothing
                    If QueneTask.TryDequeue(TskQuene) Then
                        TSK.Add(New TDC.MailEnable.Core.BDD.MailBackup_TSK.Rows With {
                              .Archivo = If(TskQuene.Archivo = String.Empty, "", TskQuene.Archivo),
                              .Asunto = If(TskQuene.Asunto = String.Empty, "", TskQuene.Asunto),
                              .Notas = If(TskQuene.Notas = String.Empty, "", TskQuene.Notas)})

                        'Registra el archivo en el Cleaner
                        Cleaner.Add(New TDC.MailEnable.Core.BDD.MailBackupCleaner.Rows With {
                                                                  .Archivo = If(TskQuene.Archivo = String.Empty, "", TskQuene.Archivo),
                                                                  .Registrado = CDate(Now.ToShortDateString)})
                    End If
                Loop

                'Indexar Contactos
                Do While Not QueneContact.IsEmpty
                    Dim VcfQuene As Contact = Nothing
                    If QueneContact.TryDequeue(VcfQuene) Then
                        VCF.Add(New TDC.MailEnable.Core.BDD.MailBackup_VCF.Rows With {
                                                      .Archivo = If(VcfQuene.Archivo = String.Empty, "", VcfQuene.Archivo),
                                                      .Nombre = If(VcfQuene.Nombre = String.Empty, "", VcfQuene.Nombre),
                                                      .NombreCompleto = If(VcfQuene.NombreCompleto = String.Empty, "", VcfQuene.NombreCompleto),
                                                      .Email = If(IsNothing(VcfQuene.Email), "", String.Join(";", VcfQuene.Email)),
                                                      .EmailPersonal = If(IsNothing(VcfQuene.EmailPersonal), "", String.Join(";", VcfQuene.EmailPersonal)),
                                                      .EmailTrabajo = If(IsNothing(VcfQuene.EmailTrabajo), "", String.Join(";", VcfQuene.EmailTrabajo)),
                                                      .Nick = If(IsNothing(VcfQuene.Nick), "", String.Join(";", VcfQuene.Nick))})

                        'Registra el archivo en el Cleaner
                        Cleaner.Add(New TDC.MailEnable.Core.BDD.MailBackupCleaner.Rows With {
                                                                  .Archivo = If(VcfQuene.Archivo = String.Empty, "", VcfQuene.Archivo),
                                                                  .Registrado = CDate(Now.ToShortDateString)})
                    End If
                Loop
            End If
        End Sub
        Private Sub Controlador_Foreground(Sender As Object, Detener As BackgroundEventArgs) Handles Controlador.ForeGround
            If Estado = EnumEstado.Analizando Then
                If Archivos.IsEmpty Then
                    For Each Buscador In Indexadores.Values
                        If Buscador.Estado = DoBucle.EnumEstado.Detenido Then
                            Buscador.Iniciar()
                        End If
                    Next
                End If

                If Indexadores.IsEmpty AndAlso Archivos.IsEmpty Then
                    If Not AlFinalizarIndexacionNotificado Then
                        If Not QueneToTable Then
                            QueneToTable = True
                        Else
                            AlFinalizarIndexacionNotificado = True
                            Estado = EnumEstado.Analizado
                            RaiseEvent AlFinalizarIndexacionDeArchivos(Me)
                            Detener.Detener = True
                        End If
                    End If
                End If
            End If
        End Sub
        Private Function OriginalPath(Archivo As String) As String
            Return Archivo.Replace(MailEnable.Main.Configuracion.CARPETA_BACKUP, MailEnable.Main.Configuracion.POST_OFFICES)
        End Function


    End Class
End Namespace