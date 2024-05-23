Imports TDC.MailEnable.IpBan.MailEnable
Namespace Backup
    Public Class QueneArchivos
        Implements IDisposable

        Public ReadOnly Property Archivos As New Concurrent.ConcurrentQueue(Of String)
        Private Directorios As Concurrent.ConcurrentQueue(Of String)
        Private WithEvents BuscadoresEvents As TDC.MailEnable.Core.Bucle.DoBucle
        Public ReadOnly Buscadores As New Concurrent.ConcurrentDictionary(Of String, TDC.MailEnable.Core.Bucle.DoBucle)
        Private WithEvents Controlador As TDC.MailEnable.Core.Bucle.DoBucle

        Dim disposedValue As Boolean
        Public Event AlFinalizarBusquedaArchivos(sender As Object)
        Private AlFinalizarBusquedaNotificado As Boolean = False
        Public Event AlIniciarBusquedaDeArchivos(sender As Object)

        Public Property Extensiones As New List(Of String)
        Public Enum EnumEstado
            Iniciando
            Analizando
            Analizado
        End Enum
        Public Property Estado As EnumEstado = EnumEstado.Iniciando


        Public Sub New()
            For i = 0 To MailEnable.Main.Configuracion.ANALIZADORES_BACKUP - 1
                Dim KeyId As Integer = i
                IpBanForm.Invoke(Sub()
                                     Dim Buscador As KeyValuePair(Of String, TDC.MailEnable.Core.Bucle.DoBucle) = CrearBuscador(KeyId)
                                     If Not IsNothing(Buscador) Then
                                         Buscadores.TryAdd(Buscador.Key, Buscador.Value)
                                     Else
                                         Stop
                                     End If
                                 End Sub)
            Next
            Controlador = TDC.MailEnable.Core.Bucle.GetOrCreate("Global100")
            Controlador.Iniciar()
        End Sub

        Private Function CrearBuscador(Optional Index As Integer = -1) As KeyValuePair(Of String, TDC.MailEnable.Core.Bucle.DoBucle)
            Select Case Index
                Case -1
                    For i = 0 To MailEnable.Main.Configuracion.ANALIZADORES_BACKUP - 1
                        If Not Buscadores.ContainsKey($"MailBackup{i}") Then
                            Dim Buscador As TDC.MailEnable.Core.Bucle.DoBucle = TDC.MailEnable.Core.Bucle.GetOrCreate($"MailBackup{i}")
                            Buscador.Intervalo = MailEnable.Main.Configuracion.ANALIZADORES_BACKUP_TIMER
                            AddHandler Buscador.BackGround, AddressOf BuscadoresEvents_Background
                            AddHandler Buscador.ForeGround, AddressOf BuscadoresEvents_Foreground
                            AddHandler Buscador.EndGround, AddressOf BuscadoresEvents_Endground
                            Return New KeyValuePair(Of String, TDC.MailEnable.Core.Bucle.DoBucle)(Buscador.Name, Buscador)
                        End If
                    Next
                Case Else
                    If Not Buscadores.ContainsKey($"MailBackup{Index}") Then
                        Dim Buscador As TDC.MailEnable.Core.Bucle.DoBucle = TDC.MailEnable.Core.Bucle.GetOrCreate($"MailBackup{Index}")
                        Buscador.Intervalo = MailEnable.Main.Configuracion.ANALIZADORES_BACKUP_TIMER
                        AddHandler Buscador.BackGround, AddressOf BuscadoresEvents_Background
                        AddHandler Buscador.ForeGround, AddressOf BuscadoresEvents_Foreground
                        AddHandler Buscador.EndGround, AddressOf BuscadoresEvents_Endground
                        Return New KeyValuePair(Of String, TDC.MailEnable.Core.Bucle.DoBucle)(Buscador.Name, Buscador)
                    End If
            End Select
            Return Nothing
        End Function

        Public Sub Buscar(Carpetas As Concurrent.ConcurrentQueue(Of String))
            If Extensiones.Count = 0 Then Throw New Exception("Sin lista de Extensiones")
            Directorios = Carpetas

            If Buscadores.IsEmpty Then
                For i = 0 To MailEnable.Main.Configuracion.ANALIZADORES_BACKUP - 1
                    Dim Buscador As KeyValuePair(Of String, TDC.MailEnable.Core.Bucle.DoBucle) = CrearBuscador(i)
                    If Not IsNothing(Buscador) Then
                        Buscadores.TryAdd(Buscador.Key, Buscador.Value)
                    Else
                        Stop
                    End If
                Next
            End If

            For Each Buscador In Buscadores.Values
                If Buscador.Estado = TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Iniciar()
            Next
            AlFinalizarBusquedaNotificado = False
            Estado = EnumEstado.Analizando
            RaiseEvent AlIniciarBusquedaDeArchivos(Me)
        End Sub
        Public Sub Continuar()
            For Each Buscador In Buscadores.Values
                Try
                    If Buscador.Estado = TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Iniciar()
                    AlFinalizarBusquedaNotificado = False
                Catch ex As Exception
                    Stop
                End Try
            Next
            Estado = EnumEstado.Analizando
        End Sub
        Private Sub BuscarArchivos(Carpeta As String)
            For Each Extension In Extensiones
                For Each Archivo In IO.Directory.GetFiles(Carpeta, $"*{Extension}", IO.SearchOption.TopDirectoryOnly)
                    If Not IO.File.Exists(OriginalPath(Archivo)) Then Archivos.Enqueue(Archivo)
                Next
            Next
        End Sub
        Private Function OriginalPath(Archivo As String) As String
            Return Archivo.Replace(MailEnable.Main.Configuracion.CARPETA_BACKUP, MailEnable.Main.Configuracion.POST_OFFICES)
        End Function
        Private Sub BuscadoresEvents_Background(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles BuscadoresEvents.BackGround
            If Not IsNothing(Directorios) Then
                If Not Directorios.IsEmpty Then
                    Dim Carpeta As String = String.Empty
                    If Directorios.TryDequeue(Carpeta) Then
                        BuscarArchivos(Carpeta)
                    End If
                Else
                    'Detener = True
                    If BuscadorCarpetas.Estado = QueneDirectorios.EnumEstado.Analizado Then
                        If Buscadores.ContainsKey(CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).Name) Then
                            If Buscadores.TryRemove(CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).Name, Nothing) Then
                                RemoveHandler CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).BackGround, AddressOf BuscadoresEvents_Background
                                RemoveHandler CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).ForeGround, AddressOf BuscadoresEvents_Foreground
                                RemoveHandler CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).EndGround, AddressOf BuscadoresEvents_Endground
                            Else
                                Stop
                            End If
                        Else
                            RemoveHandler CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).BackGround, AddressOf BuscadoresEvents_Background
                            RemoveHandler CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).ForeGround, AddressOf BuscadoresEvents_Foreground
                            RemoveHandler CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).EndGround, AddressOf BuscadoresEvents_Endground
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub BuscadoresEvents_Foreground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles BuscadoresEvents.ForeGround
            'Comprobar  Límite de Analizadores
            If Buscadores.Count > MailEnable.Main.Configuracion.ANALIZADORES_BACKUP AndAlso Not Directorios.IsEmpty Then
                If Buscadores.ContainsKey(CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).Name) Then
                    Buscadores.TryRemove(CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).Name, Nothing)
                End If
            ElseIf Buscadores.Count < MailEnable.Main.Configuracion.ANALIZADORES_BACKUP AndAlso Not Directorios.IsEmpty Then
                Dim Buscador As KeyValuePair(Of String, TDC.MailEnable.Core.Bucle.DoBucle) = CrearBuscador()
                If Not IsNothing(Buscador) Then Buscadores.TryAdd(Buscador.Key, Buscador.Value)
                If Buscador.Value.Estado = Global.TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Value.Iniciar()
            End If

            'Comprobar si el Analizador esta Activo
            If Not Buscadores.ContainsKey(CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).Name) Then
                RemoveHandler CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).ForeGround, AddressOf BuscadoresEvents_Foreground
                RemoveHandler CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).EndGround, AddressOf BuscadoresEvents_Endground
                RemoveHandler CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).BackGround, AddressOf BuscadoresEvents_Background
                'CType(Sender, Core.Bucle.DoBucle).Matar()
            Else
                If CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).Intervalo <> MailEnable.Main.Configuracion.ANALIZADORES_BACKUP_TIMER Then CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).Intervalo = MailEnable.Main.Configuracion.ANALIZADORES_BACKUP_TIMER
            End If
        End Sub

        Private Sub BuscadoresEvents_Endground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles BuscadoresEvents.EndGround
            If Not IsNothing(Directorios) AndAlso Not Directorios.IsEmpty AndAlso CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).Cancelar Then CType(Sender, TDC.MailEnable.Core.Bucle.DoBucle).Iniciar()
        End Sub

        Private Sub Controlador_Foreground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles Controlador.ForeGround
            If Estado = EnumEstado.Analizando Then
                If Directorios.IsEmpty Then
                    For Each Buscador In Buscadores.Values
                        If Buscador.Estado = TDC.MailEnable.Core.Bucle.DoBucle.EnumEstado.Detenido Then
                            Buscador.Iniciar()
                        End If
                    Next
                End If

                If Buscadores.IsEmpty AndAlso Directorios.IsEmpty Then
                    If Not AlFinalizarBusquedaNotificado Then
                        AlFinalizarBusquedaNotificado = True
                        Estado = EnumEstado.Analizado
                        RaiseEvent AlFinalizarBusquedaArchivos(Me)
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