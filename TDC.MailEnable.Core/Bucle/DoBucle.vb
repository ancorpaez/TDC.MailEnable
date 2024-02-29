Imports System.ComponentModel
Imports System.Threading

Namespace Bucle
    Public Class DoBucle
        Private _Detener As Boolean = False
        Private WithEvents _Trabajador As BackgroundWorker
        Private ContinuarDo As ManualResetEvent

        Public Property Intervalo As Integer = 100
        Public Event Background(Sender As Object, ByRef Detener As Boolean)
        Public Event Foreground(Sender As Object, ByRef Detener As Boolean)

        Public Sub New()
            _Trabajador = New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
            ContinuarDo = New ManualResetEvent(False)
        End Sub

        Public Sub Iniciar()
            If Not _Trabajador.IsBusy Then _Trabajador.RunWorkerAsync()
        End Sub
        Public Sub Detener()
            If _Trabajador.IsBusy Then _Trabajador.CancelAsync()
        End Sub

        Private Sub _Trabajador_DoWork(sender As Object, e As DoWorkEventArgs) Handles _Trabajador.DoWork
            Do While Not e.Cancel
                'Iniciamos despues del Intervalo establecido
                Thread.Sleep(Intervalo)

                'Comprobamos si es necesario cancelar la tarea
                If _Trabajador.CancellationPending Then
                    e.Cancel = True
                    Exit Do
                End If

                'Lanzamos el Bucle
                RaiseEvent Background(Me, e.Cancel)

                'Reportamos para lanzar el Evento
                _Trabajador.ReportProgress(e.Cancel)

                'Resteamos en control ManualResetEvent
                ContinuarDo.WaitOne()
            Loop
        End Sub

        Private Sub _Trabajador_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles _Trabajador.ProgressChanged

            If Not e.ProgressPercentage Then RaiseEvent Foreground(Me, e.ProgressPercentage) Else Me.Detener()

            ContinuarDo.Set()
        End Sub

        Private Sub _Trabajador_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _Trabajador.RunWorkerCompleted

        End Sub
    End Class
End Namespace