Imports TDC.MailEnable.IpBan.MailEnableLog
Namespace Backup
    Public Class Cls_BuscadorDeDirectorios
        Implements IDisposable

        Public ReadOnly Property Directorios As New Concurrent.ConcurrentQueue(Of String)
        Public ReadOnly Escaneo As New Concurrent.ConcurrentQueue(Of String)
        Private WithEvents BuscadoresEvents As Core.Bucle.DoBucle
        Public ReadOnly Buscadores As New Concurrent.ConcurrentDictionary(Of String, Core.Bucle.DoBucle)
        Private WithEvents Controlador As Core.Bucle.DoBucle

        Dim disposedValue As Boolean
        Public Event AlFinalizarBusquedaCarpetas(sender As Object)
        Private AlFinalizarBusquedaNotificado As Boolean = False
        Public Event AlIniciarBusquedaDeCarpetas(sender As Object)
        Public Enum EnumEstado
            Iniciando
            Analizando
            Analizado
        End Enum
        Public Property Estado As EnumEstado = EnumEstado.Iniciando

        Public Sub New()
            For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
                IpBanForm.Invoke(Sub()
                                     Dim Buscador As KeyValuePair(Of String, Core.Bucle.DoBucle) = CrearBuscador(i)
                                     If Not IsNothing(Buscador) Then
                                         Buscadores.TryAdd(Buscador.Key, Buscador.Value)
                                     Else
                                         Stop
                                     End If
                                 End Sub)
            Next
            Controlador = Core.Bucle.GetOrCreate("Global100")
            Controlador.Iniciar()
        End Sub
        Public Sub Buscar(Raiz As String)
            BuscarCarpetas(Raiz)

            If Buscadores.IsEmpty Then
                For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
                    Dim Buscador As KeyValuePair(Of String, Core.Bucle.DoBucle) = CrearBuscador(i)
                    If Not IsNothing(Buscador) Then
                        Buscadores.TryAdd(Buscador.Key, Buscador.Value)
                    Else
                        Stop
                    End If
                Next
            End If

            For Each Buscador In Buscadores.Values
                If Buscador.Estado = Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Iniciar()
            Next
            AlFinalizarBusquedaNotificado = False
            Estado = EnumEstado.Analizando
            RaiseEvent AlIniciarBusquedaDeCarpetas(Me)
        End Sub

        Private Sub BuscarCarpetas(Carpeta As String)
            For Each Carpeta In IO.Directory.GetDirectories(Carpeta)
                Directorios.Enqueue(Carpeta)
                Escaneo.Enqueue(Carpeta)
            Next
        End Sub

        Private Function CrearBuscador(Optional Index As Integer = -1) As KeyValuePair(Of String, Core.Bucle.DoBucle)
            Select Case Index
                Case -1
                    For i = 0 To Configuracion.ANALIZADORES_BACKUP - 1
                        If Not Buscadores.ContainsKey($"MailBackup{i}") Then
                            Dim Buscador As Core.Bucle.DoBucle = Core.Bucle.GetOrCreate($"MailBackup{i}")
                            Buscador.Intervalo = Configuracion.ANALIZADORES_BACKUP_TIMER
                            AddHandler Buscador.Background, AddressOf BuscadoresEvents_Background
                            AddHandler Buscador.Foreground, AddressOf BuscadoresEvents_Foreground
                            AddHandler Buscador.Endground, AddressOf BuscadoresEvents_Endground
                            Return New KeyValuePair(Of String, Core.Bucle.DoBucle)(Buscador.Name, Buscador)
                        End If
                    Next
                Case Else
                    If Not Buscadores.ContainsKey($"MailBackup{Index}") Then
                        Dim Buscador As Core.Bucle.DoBucle = Core.Bucle.GetOrCreate($"MailBackup{Index}")
                        Buscador.Intervalo = Configuracion.ANALIZADORES_BACKUP_TIMER
                        AddHandler Buscador.Background, AddressOf BuscadoresEvents_Background
                        AddHandler Buscador.Foreground, AddressOf BuscadoresEvents_Foreground
                        AddHandler Buscador.Endground, AddressOf BuscadoresEvents_Endground
                        Return New KeyValuePair(Of String, Core.Bucle.DoBucle)(Buscador.Name, Buscador)
                    End If
            End Select
            Return Nothing
        End Function
        Private Sub BuscadoresEvents_Background(Sender As Object, Detener As Core.Bucle.BackgroundEventArgs) Handles BuscadoresEvents.BackGround
            If Not Escaneo.IsEmpty Then
                Dim Carpeta As String = String.Empty
                If Escaneo.TryDequeue(Carpeta) Then
                    BuscarCarpetas(Carpeta)
                End If
            Else
                'Detener = True
                If Buscadores.ContainsKey(CType(Sender, Core.Bucle.DoBucle).Name) Then
                    If Buscadores.TryRemove(CType(Sender, Core.Bucle.DoBucle).Name, Nothing) Then
                        RemoveHandler CType(Sender, Core.Bucle.DoBucle).BackGround, AddressOf BuscadoresEvents_Background
                        RemoveHandler CType(Sender, Core.Bucle.DoBucle).ForeGround, AddressOf BuscadoresEvents_Foreground
                        RemoveHandler CType(Sender, Core.Bucle.DoBucle).EndGround, AddressOf BuscadoresEvents_Endground
                    Else
                        Stop
                    End If
                Else
                    RemoveHandler CType(Sender, Core.Bucle.DoBucle).BackGround, AddressOf BuscadoresEvents_Background
                    RemoveHandler CType(Sender, Core.Bucle.DoBucle).ForeGround, AddressOf BuscadoresEvents_Foreground
                    RemoveHandler CType(Sender, Core.Bucle.DoBucle).EndGround, AddressOf BuscadoresEvents_Endground
                End If
            End If
        End Sub

        Private Sub BuscadoresEvents_Foreground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles BuscadoresEvents.ForeGround
            'Comprobar  Límite de Analizadores
            If Buscadores.Count > Configuracion.ANALIZADORES_BACKUP AndAlso Not Escaneo.IsEmpty Then
                If Buscadores.ContainsKey(CType(Sender, Core.Bucle.DoBucle).Name) Then
                    Buscadores.TryRemove(CType(Sender, Core.Bucle.DoBucle).Name, Nothing)
                End If
            ElseIf Buscadores.Count < Configuracion.ANALIZADORES_BACKUP AndAlso Not Escaneo.IsEmpty Then
                Dim Buscador As KeyValuePair(Of String, Core.Bucle.DoBucle) = CrearBuscador()
                If Not IsNothing(Buscador) Then Buscadores.TryAdd(Buscador.Key, Buscador.Value)
                If Buscador.Value.Estado = Core.Bucle.DoBucle.EnumEstado.Detenido Then Buscador.Value.Iniciar()
            End If

            'Comprobar si el Analizador esta Activo
            If Not Buscadores.ContainsKey(CType(Sender, Core.Bucle.DoBucle).Name) Then
                RemoveHandler CType(Sender, Core.Bucle.DoBucle).ForeGround, AddressOf BuscadoresEvents_Foreground
                RemoveHandler CType(Sender, Core.Bucle.DoBucle).EndGround, AddressOf BuscadoresEvents_Endground
                RemoveHandler CType(Sender, Core.Bucle.DoBucle).BackGround, AddressOf BuscadoresEvents_Background
                'CType(Sender, Core.Bucle.DoBucle).Matar()
            Else
                If CType(Sender, Core.Bucle.DoBucle).Intervalo <> Configuracion.ANALIZADORES_BACKUP_TIMER Then CType(Sender, Core.Bucle.DoBucle).Intervalo = Configuracion.ANALIZADORES_BACKUP_TIMER
            End If
        End Sub

        Private Sub BuscadoresEvents_Endground(Sender As Object, Detener As Core.Bucle.BackgroundEventArgs) Handles BuscadoresEvents.EndGround
            If Not Escaneo.IsEmpty AndAlso CType(Sender, Core.Bucle.DoBucle).Cancelar Then CType(Sender, Core.Bucle.DoBucle).Iniciar()
        End Sub
        Private Sub Controlador_Foreground(Sender As Object, Detener As Core.Bucle.BackgroundEventArgs) Handles Controlador.ForeGround
            If Estado = EnumEstado.Analizando Then
                If Escaneo.IsEmpty Then
                    For Each Buscador In Buscadores.Values
                        If Buscador.Estado = Core.Bucle.DoBucle.EnumEstado.Detenido Then
                            Buscador.Iniciar()
                        End If
                    Next
                End If
                If Escaneo.IsEmpty AndAlso Buscadores.IsEmpty Then
                    If Not AlFinalizarBusquedaNotificado Then
                        AlFinalizarBusquedaNotificado = True
                        Estado = EnumEstado.Analizado
                        RaiseEvent AlFinalizarBusquedaCarpetas(Me)
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