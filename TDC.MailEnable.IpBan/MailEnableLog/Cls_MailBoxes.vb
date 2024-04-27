Namespace MailEnableLog
    Public Class Cls_MailBoxes
        Private MailBoxesDirectory As IO.DirectoryInfo
        Public MailBoxes As New Concurrent.ConcurrentDictionary(Of String, String)
        'Private WithEvents MailBoxesScan As New MailEnable.Core.Bucle.DoBucle("MailBoxesScan")
        Private WithEvents MailBoxesScan As Core.Bucle.DoBucle

        Public Sub New(PostOffice As IO.DirectoryInfo)
            MailBoxesScan = Core.Bucle.GetOrCreate("MailBoxesScan")
            If PostOffice.GetDirectories("MAILROOT", IO.SearchOption.TopDirectoryOnly).Count > 0 Then
                MailBoxesDirectory = PostOffice.GetDirectories("MAILROOT", IO.SearchOption.TopDirectoryOnly)(0)
                If MailBoxesDirectory.Exists Then
                    For Each MailBox In MailBoxesDirectory.GetDirectories
                        If Not MailBoxes.ContainsKey(MailBox.Name) Then MailBoxes.TryAdd(MailBox.Name, MailBox.Name)
                    Next
                    MailBoxesScan.Intervalo = 10000
                    MailBoxesScan.Iniciar()
                End If
            End If
        End Sub

        Public Sub Detener()
            MailBoxesScan.Detener()
        End Sub
        Private Sub MailBoxesScan_Background(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles MailBoxesScan.Background
            If Not IsNothing(MailBoxesDirectory) Then
                Try
                    MailBoxesDirectory.Refresh()
                Catch ex As Exception
                    MailBoxesDirectory = New IO.DirectoryInfo(MailBoxesDirectory.FullName)
                End Try

                If MailBoxesDirectory.Exists Then
                    'Añadir
                    For Each MailBox In MailBoxesDirectory.GetDirectories
                        If Not MailBoxes.ContainsKey(MailBox.Name) Then MailBoxes.TryAdd(MailBox.Name, MailBox.Name)
                    Next

                    'Eliminar
                    For Each MailBox In MailBoxes.Keys
                        If MailBoxesDirectory.GetDirectories(MailBox).Count = 0 Then
                            MailBoxes.TryRemove(MailBox, Nothing)
                        End If
                    Next
                End If
            End If
        End Sub
    End Class
End Namespace