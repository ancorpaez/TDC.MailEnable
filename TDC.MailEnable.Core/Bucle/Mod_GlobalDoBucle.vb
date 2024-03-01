Namespace Bucle
    Public Module Mod_GlobalDoBucle
        Private GlobalDoBucle As New System.Collections.Concurrent.ConcurrentDictionary(Of String, DoBucle)

        Public Function GetOrCreate(Bucle As String) As DoBucle
            If GlobalDoBucle.ContainsKey(Bucle) Then Return GlobalDoBucle(Bucle)

            Dim CreateDobucle As New DoBucle(Bucle)
            GlobalDoBucle.TryAdd(Bucle, CreateDobucle)
            Return CreateDobucle
        End Function

        Public Sub Remove(Bucle As String)
            If GlobalDoBucle.ContainsKey(Bucle) Then
                GlobalDoBucle(Bucle).Matar()
                GlobalDoBucle.TryRemove(Bucle, Nothing)
            End If
        End Sub
    End Module
End Namespace