Imports System.ComponentModel

Namespace Concurrent
    Public Class ConcurrentBindingList(Of T)
        Inherits BindingList(Of T)

        Private _SyncObject As Object = New Object

        Protected Overrides Sub OnAddingNew(e As AddingNewEventArgs)
            SyncLock _SyncObject
                MyBase.OnAddingNew(e)
            End SyncLock
        End Sub

        Protected Overrides Sub OnListChanged(e As ListChangedEventArgs)
            SyncLock _SyncObject
                MyBase.OnListChanged(e)
            End SyncLock
        End Sub

        Public Function ToQuene() As Collections.Concurrent.ConcurrentQueue(Of T)
            Dim Resultado As New Collections.Concurrent.ConcurrentQueue(Of T)
            For Each iItem In Me
                Resultado.Enqueue(iItem)
            Next
            Return Resultado
        End Function
    End Class
End Namespace