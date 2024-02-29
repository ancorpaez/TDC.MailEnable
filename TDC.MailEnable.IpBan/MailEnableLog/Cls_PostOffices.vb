Namespace MailEnableLog
    Public Class Cls_PostOffices
        Private PostOfficesPath As String = ""
        Private PostOfficesDirectory As IO.DirectoryInfo
        Private WithEvents PostOfficeSearch As MailEnable.Core.Bucle.DoBucle
        Private PostOfficesIndex As New Concurrent.ConcurrentDictionary(Of String, Cls_MailBoxes)

        Public Sub New(PostOffices As String)
            PostOfficesPath = PostOffices
            If IO.Directory.Exists(PostOffices) Then PostOfficesDirectory = New IO.DirectoryInfo(PostOffices)

            If Not IsNothing(PostOfficesDirectory) Then
                PostOfficeSearch = New Core.Bucle.DoBucle
                PostOfficeSearch.Intervalo = 10
                PostOfficeSearch.Iniciar()
            End If
        End Sub

        Private Sub PostOfficeSearch_Background(Sender As Object, ByRef Detener As Boolean) Handles PostOfficeSearch.Background
            PostOfficeSearch.Intervalo = 10000
            'Añadir
            For Each iPostOffice In PostOfficesDirectory.GetDirectories("*.*", IO.SearchOption.TopDirectoryOnly)
                PostOfficesIndex.TryAdd(iPostOffice.Name, New Cls_MailBoxes(iPostOffice))
            Next

            'Eliminar
            For Each iPostOffice In PostOfficesIndex.Keys
                If PostOfficesDirectory.GetDirectories(iPostOffice).Count = 0 Then
                    'Detener es escaneo de MailBoxes
                    PostOfficesIndex(iPostOffice).Detener()
                    PostOfficesIndex.TryRemove(iPostOffice, Nothing)
                End If
            Next
        End Sub
        Public Function PostOffices() As List(Of String)
            Return PostOfficesIndex.Keys.ToList
        End Function
        Public Function PostOffice(Index As String) As Cls_MailBoxes
            Return PostOfficesIndex(Index)
        End Function
    End Class

End Namespace