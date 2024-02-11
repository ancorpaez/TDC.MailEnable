Namespace MailEnableLog
    Public Class Cls_MailBoxes
        Private MailBoxesDirectory As IO.DirectoryInfo
        Public MailBoxes As New Concurrent.ConcurrentDictionary(Of String, String)
        Private WithEvents MailBoxesScan As New MailEnable.Core.Bucle.Bucle

        Public Sub New(PostOffice As IO.DirectoryInfo)
            If PostOffice.GetDirectories("MAILROOT", IO.SearchOption.TopDirectoryOnly).Count > 0 Then
                MailBoxesDirectory = PostOffice.GetDirectories("MAILROOT", IO.SearchOption.TopDirectoryOnly)(0)

                For Each MailBox In MailBoxesDirectory.GetDirectories
                    If Not MailBoxes.ContainsKey(MailBox.Name) Then MailBoxes.TryAdd(MailBox.Name, MailBox.Name)
                Next
                MailBoxesScan.Intervalo = 10000
                MailBoxesScan.Inicia()
            End If
        End Sub

        Private Sub MailBoxesScan_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles MailBoxesScan.IBucle_Bucle
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
        End Sub
    End Class
End Namespace