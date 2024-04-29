Namespace Bucle
    Public Module Mod_GlobalDoBucle
        Friend GlobalDoBucle As New System.Collections.Concurrent.ConcurrentDictionary(Of String, DoBucle)

        Public Sub View()
            Dim v As New View With {.TopMost = True}
            v.Show()
        End Sub
        Friend Sub Add(iBucle As DoBucle)
            If Not GlobalDoBucle.ContainsKey(iBucle.Name) Then
                GlobalDoBucle.TryAdd(iBucle.Name, iBucle)
            Else
                Throw New Exception("El Bucle ya está registrado en el sistema.")
            End If
        End Sub

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