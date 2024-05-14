Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms


Namespace Bucle
    Public Class DoBucle

        Private WithEvents Trabajador As BackgroundWorker
        Private InvokeForm As Form
        Private LabelCount As Label
        Private BtnDetenerBackground As Button, FlagBtnDetenerBackground As Boolean = False
        Private BtnDetenerForeground As Button, FlagBtnDetenerForeground As Boolean = False
        Private BtnDetenerEndground As Button, FlagBtnDetenerEndground As Boolean = False
        Private InvokeRequired As Boolean = False

        Public Property Cancelar As Boolean = False
        Public Property Name As String = String.Empty
        Public Property Intervalo As Integer = 100
        Public Event BackGround(Sender As Object, e As BackgroundEventArgs)
        Public Event ForeGround(Sender As Object, e As BackgroundEventArgs)
        Public Event EndGround(Sender As Object, e As BackgroundEventArgs)
        Public Event ErrorGround(Sender As Object, e As BackgroundEventArgs)
        Public Contador As Integer = 0
        Private _esErroneo As Boolean = False
        Public ReadOnly Property esErroneo As Boolean
            Get
                Return _esErroneo
            End Get
        End Property

        Private _exException As Exception = Nothing
        Private ReadOnly Property exException As Exception
            Get
                Return _exException
            End Get
        End Property

        Private _AsUserCancel As Boolean = False
        Public ReadOnly Property AsUserCancel As Boolean
            Get
                Return _AsUserCancel
            End Get
        End Property

        Public Enum EnumEstado
            Detenido
            Corriendo
        End Enum
        Public Property Estado As EnumEstado = EnumEstado.Detenido

        Public Sub New(Name As String, Optional Visible As Boolean = False)
            'Comprueba que no sea creado desde un subproceso
            If Thread.CurrentThread.ManagedThreadId <> 1 Then If Application.OpenForms.Count > 0 Then InvokeRequired = True Else Throw New Exception("Requiere funcionar en el Hilo Principal")

            'Establecer Key
            Me.Name = Name

            'Registrar el Bucle en el General
            Add(Me)

            'Crear Controles

            InvokeForm = CreateForm()
            With InvokeForm
                If Not Visible Then
                    .Text = Name
                    .Name = Name
                    .ShowInTaskbar = False
                    .Opacity = 0
                    .WindowState = FormWindowState.Minimized
                    'InvokeForm = New Form With {.Text = Name, .Name = Name, .ShowInTaskbar = False, .Opacity = 0, .WindowState = FormWindowState.Minimized}
                Else
                    .Text = Name
                    .Name = Name
                    .Height = 140
                    'InvokeForm = New Form With {.Text = Name, .Name = Name, .Height = 140}
                End If
            End With

            LabelCount = CreateLabel()
            With LabelCount
                .Text = 0
                .Dock = DockStyle.Top
            End With

            If InvokeForm.Opacity <> 0 Then
                BtnDetenerBackground = CreateButton()
                With BtnDetenerBackground
                    .Text = "Stop Background"
                    .Dock = DockStyle.Bottom
                End With

                BtnDetenerForeground = CreateButton()
                With BtnDetenerForeground
                    .Text = "Stop Foreground"
                    .Dock = DockStyle.Bottom
                End With

                BtnDetenerEndground = CreateButton()
                With BtnDetenerEndground
                    .Text = "Stop Endground"
                    .Dock = DockStyle.Bottom
                End With

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

            Trabajador = New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
        End Sub

        Private Function CreateForm() As Form
            Dim nForm As Form = Nothing
            If InvokeRequired Then Application.OpenForms(0).Invoke(Sub() nForm = New Form) Else nForm = New Form
            Return nForm
        End Function
        Private Function CreateButton() As Button
            Dim nButton As Button = Nothing
            If InvokeRequired Then Application.OpenForms(0).Invoke(Sub() nButton = New Button) Else nButton = New Button
            Return nButton
        End Function
        Private Function CreateLabel() As Label
            Dim nlabel As Label = Nothing
            If InvokeRequired Then Application.OpenForms(0).Invoke(Sub() nlabel = New Label) Else nlabel = New Label
            Return nlabel
        End Function
        Public Sub Iniciar()
            Cancelar = False
            If Not IsNothing(Trabajador) AndAlso Not Trabajador.IsBusy Then Trabajador.RunWorkerAsync()
            Estado = EnumEstado.Corriendo
        End Sub
        Public Sub Detener(Optional UserCancel As Boolean = False)
            _AsUserCancel = UserCancel
            Cancelar = True
            Trabajador.CancelAsync()
        End Sub
        Public Sub Matar()
            Trabajador.Dispose()
            Try
                If InvokeForm.Created Then
                    InvokeForm.Invoke(Sub() If Not IsNothing(LabelCount) Then LabelCount.Dispose())
                    InvokeForm.Invoke(Sub() If Not IsNothing(BtnDetenerBackground) Then BtnDetenerBackground.Dispose())
                    InvokeForm.Invoke(Sub() If Not IsNothing(BtnDetenerForeground) Then BtnDetenerForeground.Dispose())
                    InvokeForm.Invoke(Sub() If Not IsNothing(BtnDetenerEndground) Then BtnDetenerEndground.Dispose())
                    If Not InvokeForm.IsDisposed OrElse Not InvokeForm.Disposing Then InvokeForm.Invoke(Sub() InvokeForm.Dispose())
                End If
            Catch ex As Exception
            End Try
        End Sub
        Private Sub Trabajador_DoWork(sender As Object, e As DoWorkEventArgs) Handles Trabajador.DoWork
            Do While Not e.Cancel
                'Iniciamos despues del Intervalo establecido
                Thread.Sleep(Intervalo)

                'Comprobamos si es necesario cancelar la tarea
                If Trabajador.CancellationPending Then
                    e.Cancel = True
                    Cancelar = True
                    Exit Do
                End If

                'Lanzamos el Bucle Background
                Try
                    If FlagBtnDetenerBackground Then Stop
                    Dim CancelBackground As New BackgroundEventArgs() With {.Detener = False}
                    RaiseEvent BackGround(Me, CancelBackground)
                    If CancelBackground.Detener OrElse Cancelar Then
                        e.Cancel = True
                        Cancelar = True
                        Exit Do
                    End If
                Catch ex As Exception
                    _esErroneo = True
                    _exException = ex
                    Dim CancelErrorGround As New BackgroundEventArgs With {.Detener = False, .Excepcion = ex}
                    RaiseEvent ErrorGround(Me, CancelErrorGround)
                    If CancelErrorGround.Detener Then
                        Cancelar = True
                        e.Cancel = True
                        Exit Do
                    End If
                End Try

                'Lanzamos el Bucle Foreground
                Try
                    If FlagBtnDetenerForeground Then Stop
                    Dim CancelForeground As New BackgroundEventArgs() With {.Detener = False}
                    If Not IsNothing(InvokeForm) AndAlso InvokeForm.Created Then InvokeForm.Invoke(Sub() RaiseEvent ForeGround(Me, CancelForeground))
                    If CancelForeground.Detener OrElse Cancelar Then
                        e.Cancel = True
                        Cancelar = True
                        Exit Do
                    End If

                    'Visualizar el Contador del Bucle
                    If InvokeForm.Visible AndAlso InvokeForm.Created Then InvokeForm.Invoke(Sub() LabelCount.Text = CInt(LabelCount.Text) + 1)
                    Contador += 1
                Catch ex As Exception
                    _esErroneo = True
                    _exException = ex
                    Dim CancelErrorGround As New BackgroundEventArgs With {.Detener = False, .Excepcion = ex}
                    RaiseEvent ErrorGround(Me, CancelErrorGround)
                    If CancelErrorGround.Detener Then
                        Cancelar = True
                        e.Cancel = True
                        Exit Do
                    End If
                End Try
            Loop
        End Sub
        Private Sub Trabajador_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Trabajador.RunWorkerCompleted
            Try
                Dim CancelarEndground As New BackgroundEventArgs() With {.Detener = False}
                RaiseEvent EndGround(Me, CancelarEndground)
                If Not CancelarEndground.Detener AndAlso Not Cancelar Then
                    If Not Trabajador.IsBusy Then Trabajador.RunWorkerAsync()
                Else
                    Cancelar = True
                    _AsUserCancel = False
                    Trabajador.CancelAsync()
                    Estado = EnumEstado.Detenido
                End If
            Catch ex As Exception
                _esErroneo = True
                _exException = ex
                Dim CancelErrorGround As New BackgroundEventArgs With {.Detener = False, .Excepcion = ex}
                RaiseEvent ErrorGround(Me, CancelErrorGround)
                If CancelErrorGround.Detener Then
                    Cancelar = True
                End If
            End Try
            If FlagBtnDetenerEndground Then Stop
        End Sub

    End Class
    Public Class BackgroundEventArgs
        Inherits EventArgs
        Public Property Detener As Boolean
        Public Property Excepcion As Exception
    End Class
End Namespace