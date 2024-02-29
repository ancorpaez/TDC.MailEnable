Namespace MailEnableLog
    Public Class Cls_MailBoxes
        Private MailBoxesDirectory As IO.DirectoryInfo
        Public MailBoxes As New Concurrent.ConcurrentDictionary(Of String, String)
        Private WithEvents MailBoxesScan As New MailEnable.Core.Bucle.DoBucle

        Public Sub New(PostOffice As IO.DirectoryInfo)
            If PostOffice.GetDirectories("MAILROOT", IO.SearchOption.TopDirectoryOnly).Count > 0 Then
                MailBoxesDirectory = PostOffice.GetDirectories("MAILROOT", IO.SearchOption.TopDirectoryOnly)(0)
                If MailBoxesDirectory.Exists Then
                    For Each MailBox In MailBoxesDirectory.GetDirectories
                        If Not MailBoxes.ContainsKey(MailBox.Name) Then MailBoxes.TryAdd(MailBox.Name, MailBox.Name)
                    Next
                    MailBoxesScan.Intervalo = 10000
                    MailBoxesScan.Iniciar()
                End if
            End If
        End Sub

        Public Sub Detener()
            MailBoxesScan.Detener()
        End Sub
        Private Sub MailBoxesScan_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles MailBoxesScan.Background
            MailBoxesDirectory.Refresh()

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
        End Sub
    End Class
End Namespace