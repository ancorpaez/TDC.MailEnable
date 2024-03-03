Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms


Namespace Bucle
    Public Class DoBucle
        Private WithEvents _Trabajador As BackgroundWorker
        Private InvokeForm As Form
        Private LabelCount As Label
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
            InvokeForm = New Form With {.Text = Name, .Name = Name, .ShowInTaskbar = False, .Opacity = 0}
            InvokeForm.Controls.Add(LabelCount)
            InvokeForm.Show()
            InvokeForm.Hide()
            _Trabajador = New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
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
            InvokeForm.Invoke(Sub() LabelCount.Dispose())
            InvokeForm.Invoke(Sub() InvokeForm.Dispose())
            GC.Collect()
        End Sub
        Private Sub _Trabajador_DoWork(sender As Object, e As DoWorkEventArgs) Handles _Trabajador.DoWork
            Do While Not e.Cancel
                'Iniciamos despues del Intervalo establecido
                Thread.Sleep(Intervalo)

                'Comprobamos si es necesario cancelar la tarea
                If _Trabajador.CancellationPending Then
                    e.Cancel = True
                    Cancelar = True
                    Exit Do
                End If

                'Visualizar el Bucle
                If InvokeForm.Visible AndAlso InvokeForm.Created Then InvokeForm.Invoke(Sub() LabelCount.Text = CInt(LabelCount.Text) + 1)

                'Lanzamos el Bucle Background
                Try
                    Dim CancelBackground As Boolean = False
                    RaiseEvent Background(Me, CancelBackground)
                    If CancelBackground OrElse Cancelar Then
                        e.Cancel = True
                        Cancelar = True
                        Exit Do
                    End If
                Catch ex As Exception
                    Cancelar = True
                    e.Cancel = True
                    Exit Do
                End Try

                'Lanzamos el Bucle Foreground
                Try
                    Dim CancelForeground As Boolean = False
                    If Not IsNothing(InvokeForm) AndAlso InvokeForm.Created Then InvokeForm.Invoke(Sub() RaiseEvent Foreground(Me, CancelForeground))
                    If CancelForeground OrElse Cancelar Then
                        e.Cancel = True
                        Cancelar = True
                        Exit Do
                    End If
                Catch ex As Exception
                    Cancelar = True
                    e.Cancel = True
                    Exit Do
                End Try
            Loop
        End Sub
        Private Sub _Trabajador_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _Trabajador.RunWorkerCompleted
            Dim CancelarEndground As Boolean = False
            RaiseEvent Endground(Me, CancelarEndground)
            If Not CancelarEndground AndAlso Not Cancelar Then
                _Trabajador.RunWorkerAsync()
            Else
                Cancelar = True
                _Trabajador.CancelAsync()
            End If
        End Sub

    End Class
End Namespace