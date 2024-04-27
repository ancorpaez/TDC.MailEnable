Imports System.Net
Imports System.Net.Sockets
Imports TDC.MailEnable.Core


Namespace Escuchadores
    Public Class Escuchador
        Private Escucha As TcpListener
        Private Puerto As Integer
        Private WithEvents Aceptador As Bucle.DoBucle
        Private Aceptadas As New Collections.Concurrent.ConcurrentQueue(Of Socket)

        Public Event ConexionEntrante()
        Public Sub New(Puerto As Integer)
            Me.Puerto = Puerto
            Aceptador = New Bucle.DoBucle("Aceptador " & Puerto, False)
            Aceptador = New Bucle.DoBucle("Avisador " & Puerto, False)
        End Sub

        Private Sub Aceptador_Foreground(Sender As Object,Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles Aceptador.Foreground
            RaiseEvent ConexionEntrante()
        End Sub

        Private Sub Aceptador_Background(Sender As Object,Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles Aceptador.Background
            Aceptadas.Enqueue(Escucha.AcceptSocket)
        End Sub

        Public Function GetFirst() As Socket
            Console.WriteLine($"Left: {Aceptadas.Count}")
            Dim Aceptada As Socket = Nothing
            If Aceptadas.TryDequeue(Aceptada) Then
                Return Aceptada
            End If
            Return Nothing
        End Function
        Public Function QuenedConections() As Boolean
            Return Aceptadas.Count > 0
        End Function
        Public Function Escuchar() As Boolean
            Try
                Escucha = New TcpListener(IPAddress.Any, Puerto)
                Escucha.AllowNatTraversal(True)
                Escucha.Start()
                Aceptador.Iniciar()
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

    End Class
End Namespace