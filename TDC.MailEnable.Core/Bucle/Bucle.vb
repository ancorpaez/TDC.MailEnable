Imports System.ComponentModel
Imports System.Timers
Imports System.UriComponents

Namespace Bucle
    Public Class Bucle
        Implements IBucle

        Private _Detener As Boolean = False
        Private WithEvents _TrabajadorDeFondo As New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
        Private WithEvents _Disparador As New Timers.Timer With {.AutoReset = False}
        Private _VidaTimer As DateTime


        Public Sub New()
            _VidaTimer = DateTime.Now
        End Sub
        Public Property Intervalo As Integer Implements IBucle.Intervalo
            Get
                Return _Disparador.Interval
            End Get
            Set(value As Integer)
                _Disparador.Interval = value
            End Set
        End Property

        Private ReadOnly Property IBucle_GetHashCode As Integer Implements IBucle.GetHashCode
            Get
                Return _Disparador.GetHashCode
            End Get
        End Property

        Public Event IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Implements IBucle.Bucle

        Public Sub Inicia() Implements IBucle.Inicia
            _Detener = False
            _Disparador.Start()
        End Sub

        Public Sub Detener() Implements IBucle.Detener
            _Detener = True
            _Disparador.Stop()
        End Sub

        Private Sub _Disparador_Elapsed(sender As Object, e As ElapsedEventArgs) Handles _Disparador.Elapsed
            If Not _TrabajadorDeFondo.IsBusy AndAlso Not _Detener Then _TrabajadorDeFondo.RunWorkerAsync()
            If DateDiff(DateInterval.Hour, _VidaTimer, Now) > 1 Then
                Task.Run(Sub()
                             'Detener el disparador
                             _Disparador.Stop()
                             'Apuntar nueva memoria al Disparador
                             Dim Disipar As Timer = _Disparador
                             'Crear un nuevo Disparador
                             _Disparador = New Timer With {.AutoReset = False, .Interval = Me.Intervalo}
                             'Eliminar el Antiguo disparador
                             Disipar.Dispose()
                             'Reestablecer el conmutador
                             _VidaTimer = DateTime.Now
                             'Iniciar la secuencia
                             _Disparador.Start()
                         End Sub)
            End If
        End Sub

        Private Sub _TrabajadorDeFondo_DoWork(sender As Object, e As DoWorkEventArgs) Handles _TrabajadorDeFondo.DoWork
            RaiseEvent IBucle_Bucle(Me, _Detener)
        End Sub

        Private Sub _TrabajadorDeFondo_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _TrabajadorDeFondo.RunWorkerCompleted
            'If Threading.Monitor.IsEntered(TryMonitorBucle) Then
            '    Threading.Monitor.Exit(TryMonitorBucle)
            'End If
            If Not _Detener AndAlso Not IsNothing(_Disparador) Then _Disparador.Start()

        End Sub

        Private Sub _TrabajadorDeFondo_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles _TrabajadorDeFondo.ProgressChanged

        End Sub
    End Class
End Namespace