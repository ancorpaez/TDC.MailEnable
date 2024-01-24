Imports System.ComponentModel
Imports System.Timers
Imports System.UriComponents

Namespace Bucle
    Public Class Bucle
        Implements IBucle

        Private _Detener As Boolean = False
        Private _EstaTrabajando As Boolean = False
        Private WithEvents _TrabajadorDeFondo As New BackgroundWorker
        Private WithEvents _Disparador As New Timers.Timer

        Public Sub New()
            _Disparador.AutoReset = False
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
            If Not _EstaTrabajando Then
                If Not _TrabajadorDeFondo.IsBusy Then _TrabajadorDeFondo.RunWorkerAsync()
            End If
        End Sub

        Private Sub _TrabajadorDeFondo_DoWork(sender As Object, e As DoWorkEventArgs) Handles _TrabajadorDeFondo.DoWork
            RaiseEvent IBucle_Bucle(Me, _Detener)
        End Sub

        Private Sub _TrabajadorDeFondo_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _TrabajadorDeFondo.RunWorkerCompleted
            _EstaTrabajando = False
            If Not _Detener Then _Disparador.Start()
        End Sub
    End Class
End Namespace