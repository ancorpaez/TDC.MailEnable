Namespace Interfaz
    Module ToInterfaz
        Public ReadOnly Rechazadas As New Concurrent.ConcurrentDictionary(Of String, ListViewItem)
        Public ReadOnly Aceptadas As New Concurrent.ConcurrentDictionary(Of String, ListViewItem)
        Public ReadOnly Conexiones As New Concurrent.ConcurrentDictionary(Of String, ListViewItem)
        Public ListViewRechazadas As ListView
        Public ListViewAceptadas As ListView
        Public ListViewConexiones As ListView


        Public Sub ToRechazadas(Item As ListViewItem)
            With ListViewRechazadas
                If Not .Items.ContainsKey(Item.Name) Then
                    .Items.Add(Item)
                Else
                    .Items(Item.Name).SubItems($"c{Item.Name}").Text += 1
                End If
            End With
        End Sub
        Public Sub ToAddAceptadas(Item As ListViewItem)
            With ListViewAceptadas
                If Not .Items.ContainsKey(Item.Name) Then
                    .Items.Add(Item)
                Else
                    .Items(Item.Name).SubItems($"c{Item.Name}").Text += 1
                End If
            End With
        End Sub
        Public Sub ToRemoveAceptadas(Cliente As String)
            With ListViewAceptadas
                If .Items.ContainsKey(Cliente) Then
                    .Items(Cliente).SubItems($"c{Cliente}").Text -= 1
                    If .Items(Cliente).SubItems($"c{Cliente}").Text = 0 Then
                        .Items.Remove(.Items(Cliente))
                    End If
                End If
            End With
        End Sub
        Public Function FromConcurrentConnections(Cliente As String) As Integer
            If IsNothing(ListViewAceptadas) Then Return 0
            With ListViewAceptadas
                If .Items.ContainsKey(Cliente) Then
                    Return CInt(.Items(Cliente).SubItems($"c{Cliente}").Text)
                Else
                    Return 0
                End If
            End With
        End Function

        Public Sub ToAddConexiones(Item As ListViewItem)
            With ListViewConexiones
                If Not .Items.ContainsKey(Item.Name) Then
                    .Items.Add(Item)
                End If
            End With
        End Sub
        Public Sub ToRemoveConexiones(Enrutador As String)
            With ListViewConexiones
                If .Items.ContainsKey(Enrutador) Then
                    .Items.Remove(.Items(Enrutador))
                End If
            End With
        End Sub
        Public Sub ToContadorEnrutador(Enrutador As String, Tiempo As Integer)
            With ListViewConexiones
                If .Items.ContainsKey(Enrutador) Then
                    .Items(Enrutador).SubItems($"c{Enrutador}").Text = Tiempo
                End If
            End With
        End Sub
    End Module
End Namespace