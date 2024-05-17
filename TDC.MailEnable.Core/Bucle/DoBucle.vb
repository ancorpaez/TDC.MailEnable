Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms


Namespace Bucle
    Public Class DoBucle

        Private WithEvents Trabajador As BackgroundWorker
        Protected Friend InvokeForm As InvokeForm
        'Para Debug solo, Detiene el Compilador 
        Friend FlagBtnDetenerBackground As Boolean = False
        Friend FlagBtnDetenerForeground As Boolean = False
        Friend FlagBtnDetenerEndground As Boolean = False
        'Detecta si se crea la clase desde un Subproceso
        Private InvokeRequired As Boolean = False
        'Bandera para detectar la Ejecucion
        Public Property Cancelar As Boolean = False
        Public Property Name As String = String.Empty
        Public Property Intervalo As Integer = 100
        'Evento en BackGround
        Public Event BackGround(Sender As Object, e As BackgroundEventArgs)
        'Evento en el ForeGround
        Public Event ForeGround(Sender As Object, e As BackgroundEventArgs)
        'Evento al Terminar Ejecucion
        Public Event EndGround(Sender As Object, e As BackgroundEventArgs)
        'Evento al encontrar un error de codificacion
        Public Event ErrorGround(Sender As Object, e As BackgroundEventArgs)
        Public Property Contador As Integer = 0

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
            If Not Visible Then
                InvokeForm.Visor = InvokeForm.SelectorTipoVisor.Control
            Else
                InvokeForm.Visor = InvokeForm.SelectorTipoVisor.Ventana
            End If

            InvokeForm.Show()

            If InvokeForm.Opacity = 0 Then InvokeForm.Hide() Else InvokeForm.Refresh()

            Trabajador = New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
        End Sub

        Private Function CreateForm() As Form
            Dim NuevoInvokeForm As Form = Nothing
            If InvokeRequired Then Application.OpenForms(0).Invoke(Sub() NuevoInvokeForm = New InvokeForm(Me)) Else NuevoInvokeForm = New InvokeForm(Me)
            Return NuevoInvokeForm
        End Function
        Public Sub Iniciar()
            Cancelar = False
            If Not IsNothing(Trabajador) AndAlso Not Trabajador.IsBusy Then Trabajador.RunWorkerAsync()
            InvokeForm.ToolIntervalo.Text = Intervalo
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
                    'If FlagBtnDetenerBackground Then Stop
                    Dim CancelBackground As New BackgroundEventArgs() With {.Detener = False, .DetenerDepuracion = FlagBtnDetenerBackground}
                    RaiseEvent BackGround(Me, CancelBackground)
                    FlagBtnDetenerBackground = CancelBackground.DetenerDepuracion

                    'Verificamos cancelación
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
                    'If FlagBtnDetenerForeground Then Stop
                    Dim CancelForeground As New BackgroundEventArgs() With {.Detener = False, .DetenerDepuracion = FlagBtnDetenerForeground}
                    If Not IsNothing(InvokeForm) AndAlso InvokeForm.Created Then InvokeForm.Invoke(Sub() RaiseEvent ForeGround(Me, CancelForeground))
                    FlagBtnDetenerForeground = CancelForeground.DetenerDepuracion

                    'Contabilizamos las vuelta para esta sesión
                    Contador += 1

                    'Visualizar el Contador en el Form
                    If InvokeForm.Visible AndAlso InvokeForm.Created AndAlso InvokeForm.Opacity = 1 Then
                        If InvokeForm.InvokeRequired Then InvokeForm.Invoke(Sub() InvokeForm.lblCount.Text = Contador) Else InvokeForm.lblCount.Text = Contador
                        If InvokeForm.InvokeRequired Then InvokeForm.Invoke(Sub() InvokeForm.ToolContador.Text = Contador) Else InvokeForm.ToolContador.Text = Contador
                        If InvokeForm.InvokeRequired Then InvokeForm.Invoke(Sub() InvokeForm.ToolIntervalo.Text = Intervalo) Else InvokeForm.ToolIntervalo.Text = Intervalo
                    End If

                    'Verificamos cancelación
                    If CancelForeground.Detener OrElse Cancelar Then
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
            Loop
        End Sub
        Private Sub Trabajador_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Trabajador.RunWorkerCompleted
            Try
                'If FlagBtnDetenerEndground Then Stop
                Dim CancelarEndground As New BackgroundEventArgs() With {.Detener = False, .DetenerDepuracion = FlagBtnDetenerEndground}
                RaiseEvent EndGround(Me, CancelarEndground)
                FlagBtnDetenerEndground = CancelarEndground.DetenerDepuracion

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
        End Sub
    End Class
    Public Class BackgroundEventArgs
        Inherits EventArgs
        'Especifica si detener el Bucle
        Public Property Detener As Boolean
        'Almacena el Error si se produce
        Public Property Excepcion As Exception
        'Semaforo para indicar al proceso principal el uso de Stop en depuración
        Public Property DetenerDepuracion As Boolean = False
    End Class
End Namespace