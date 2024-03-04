Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms


Namespace Bucle
    Public Class DoBucle
        Private WithEvents _Trabajador As BackgroundWorker
        Private InvokeForm As Form
        Private LabelCount As Label
        Private BtnDetenerBackground As Button, FlagBtnDetenerBackground As Boolean = False
        Private BtnDetenerForeground As Button, FlagBtnDetenerForeground As Boolean = False
        Private BtnDetenerEndground As Button, FlagBtnDetenerEndground As Boolean = False

        Public Property Cancelar As Boolean = False
        Public Property Name As String = String.Empty
        Public Property Intervalo As Integer = 100
        Public Event Background(Sender As Object, ByRef Detener As Boolean)
        Public Event Foreground(Sender As Object, ByRef Detener As Boolean)
        Public Event Endground(Sender As Object, ByRef Detener As Boolean)

        Public Sub New(Name As String)
            'If Not {"MailBoxesScan", "PostOfficeSearch", "MiBucle"}.Any(Function(BucleDo) Name = BucleDo) Then Exit Sub
            Me.Name = Name
            LabelCount = New Label With {.Text = 0, .Dock = DockStyle.Top}
            InvokeForm = New Form With {.Text = Name, .Name = Name, .ShowInTaskbar = False, .Opacity = 0}
            'InvokeForm = New Form With {.Text = Name, .Name = Name, .Height = 140}



            If InvokeForm.Opacity <> 0 Then
                BtnDetenerBackground = New Button With {.Text = "Stop Background", .Dock = DockStyle.Bottom}
                BtnDetenerForeground = New Button With {.Text = "Stop Foreground", .Dock = DockStyle.Bottom}
                BtnDetenerEndground = New Button With {.Text = "Stop Endground", .Dock = DockStyle.Bottom}
                AddHandler BtnDetenerBackground.Click, Sub()
                                                           FlagBtnDetenerBackground = Not FlagBtnDetenerBackground
                                                           BtnDetenerBackground.Text = $"Stop Background {FlagBtnDetenerBackground}"
                                                       End Sub
                AddHandler BtnDetenerForeground.Click, Sub()
                                                           FlagBtnDetenerForeground = Not FlagBtnDetenerForeground
                                                           BtnDetenerForeground.Text = $"Stop Foreground {FlagBtnDetenerForeground}"
                                                       End Sub
                AddHandler BtnDetenerEndground.Click, Sub()
                                                          FlagBtnDetenerEndground = Not FlagBtnDetenerEndground
                                                          BtnDetenerEndground.Text = $"Stop Endground {FlagBtnDetenerEndground}"
                                                      End Sub
                AddHandler InvokeForm.FormClosing, Sub(sender As Object, e As FormClosingEventArgs)
                                                       e.Cancel = True
                                                       CType(sender, Form).Hide()
                                                   End Sub
                InvokeForm.Controls.AddRange({LabelCount, BtnDetenerBackground, BtnDetenerForeground, BtnDetenerEndground})

            End If

            InvokeForm.Show()
            If InvokeForm.Opacity = 0 Then InvokeForm.Hide() Else InvokeForm.Refresh()

            _Trabajador = New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
                                               End Sub

        Public Sub Iniciar()
            Cancelar = False
            If Not IsNothing(_Trabajador) AndAlso Not _Trabajador.IsBusy Then _Trabajador.RunWorkerAsync()
        End Sub
        Public Sub Detener()
            Cancelar = True
            _Trabajador.CancelAsync()
        End Sub
        Public Sub Matar()
            _Trabajador.Dispose()
            InvokeForm.Invoke(Sub() LabelCount.Dispose())
            InvokeForm.Invoke(Sub() BtnDetenerBackground.Dispose())
            InvokeForm.Invoke(Sub() BtnDetenerForeground.Dispose())
            InvokeForm.Invoke(Sub() BtnDetenerEndground.Dispose())
            InvokeForm.Invoke(Sub() InvokeForm.Dispose())
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
                    If FlagBtnDetenerBackground Then Stop
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
                    If FlagBtnDetenerForeground Then Stop
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
            If FlagBtnDetenerEndground Then Stop
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