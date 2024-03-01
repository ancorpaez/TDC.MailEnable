Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms


Namespace Bucle
    Public Class DoBucle
        Private _Detener As Boolean = False
        Private WithEvents _Trabajador As BackgroundWorker
        Private ContinuarDo As ManualResetEvent
        Private EsperarIntervalo As ManualResetEvent
        Private InvokeForm As Form
        Private LabelCount As Label
        Private Counter As Integer = 0
        Public Property Cancelar As Boolean = False
        Public Property Name As String = String.Empty
        Public Property Intervalo As Integer = 100
        Public Event Background(Sender As Object, ByRef Detener As Boolean)
        Public Event Foreground(Sender As Object, ByRef Detener As Boolean)
        Public Event Endground(Sender As Object, ByRef Detener As Boolean)

        Public Sub New(Name As String)
            'If Not {"MailBoxesScan", "PostOfficeSearch", "MiBucle"}.Any(Function(BucleDo) Name = BucleDo) Then Exit Sub
            Me.Name = Name

            LabelCount = New Label With {.Text = 0}
            InvokeForm = New Form With {.Text = Name, .Name = Name, .ShowInTaskbar = False}
            InvokeForm.Controls.Add(LabelCount)
            InvokeForm.Show()
            InvokeForm.Hide()
            InvokeForm.Visible = False

            _Trabajador = New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
            ContinuarDo = New ManualResetEvent(False)
            EsperarIntervalo = New ManualResetEvent(False)
        End Sub

        Public Sub Iniciar()
            If Not IsNothing(_Trabajador) AndAlso Not _Trabajador.IsBusy Then _Trabajador.RunWorkerAsync()
            Cancelar = False
        End Sub
        Public Sub Detener()
            Cancelar = True
            _Trabajador.CancelAsync()
        End Sub
        Public Sub Matar()
            _Trabajador.Dispose()
            ContinuarDo.Dispose()
            EsperarIntervalo.Dispose()
            InvokeForm.Invoke(Sub() LabelCount.Dispose())
            InvokeForm.Invoke(Sub() InvokeForm.Dispose())
            GC.Collect()
        End Sub
        Private Sub _Trabajador_DoWork(sender As Object, e As DoWorkEventArgs) Handles _Trabajador.DoWork
            Do While Not e.Cancel
                'Iniciamos despues del Intervalo establecido
                Thread.Sleep(Intervalo)
                'Task.Delay(10000)
                'Esperar() : EsperarIntervalo.WaitOne()

                'Comprobamos si es necesario cancelar la tarea
                If _Trabajador.CancellationPending Then
                    e.Cancel = True
                    Exit Do
                End If

                If InvokeForm.Visible AndAlso InvokeForm.Created Then InvokeForm.Invoke(Sub() LabelCount.Text = CInt(LabelCount.Text) + 1)

                'Lanzamos el Bucle Background
                RaiseEvent Background(Me, False)

                'Lanzamos el Bucle Foreground
                If Not IsNothing(InvokeForm) AndAlso InvokeForm.Created Then InvokeForm.Invoke(Sub() RaiseEvent Foreground(Me, False))

                'Resteamos en control ManualResetEvent
                'ContinuarDo.WaitOne()

            Loop
        End Sub
        Private Sub _Trabajador_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _Trabajador.RunWorkerCompleted
            RaiseEvent Endground(Me, False)
            If Not Cancelar Then _Trabajador.RunWorkerAsync()
        End Sub

    End Class
End Namespace