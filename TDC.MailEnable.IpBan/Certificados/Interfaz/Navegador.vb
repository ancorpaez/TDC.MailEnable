Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar
Imports Microsoft.Web.WebView2.Core

Namespace Certificados.Interfaz
    Public Class Navegador
        Public Domain As Domain
        Private WithEvents DownloadOperation As CoreWebView2DownloadOperation = Nothing
        Private WithEvents DownloadStarting As CoreWebView2DownloadStartingEventArgs = Nothing
        Public Event FileDownloaded(sender As Object, File As FileDownloadedEvent)

        Private isHandler As Boolean = False

        Public Sub New(Domain As Domain)

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            Me.Domain = Domain
            WB.Source = Domain.Url
        End Sub
        Private Sub WB_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WB.NavigationCompleted
            If Not isHandler Then
                isHandler = True
                AddHandler WB.CoreWebView2.DownloadStarting, AddressOf InicioDescarga
            End If

            For Each Script In Domain.Scripts
                If WB.Source.AbsoluteUri.Contains(Script.Key) Then
                    WB.ExecuteScriptAsync(Script.Value)
                End If
            Next

            For Each Nav In Domain.Navigation
                If WB.Source.AbsoluteUri.Contains(Nav.Key) Then
                    WB.Source = Nav.Value
                End If
            Next
        End Sub

        Private Sub InicioDescarga(sender As Object, e As CoreWebView2DownloadStartingEventArgs)
            DownloadStarting = e
            DownloadOperation = e.DownloadOperation
        End Sub

        Private Sub TiempoDescarga(sender As Object, e As Object)
            Console.WriteLine(DownloadOperation.EstimatedEndTime)
        End Sub
        Private Sub Recibido(sender As Object, e As Object)
            Console.WriteLine($"{DownloadOperation.BytesReceived.ToString} / {DownloadOperation.TotalBytesToReceive.ToString}")
        End Sub

        Private Sub Cer1_StateChanged(sender As Object, e As Object) Handles DownloadOperation.StateChanged
            Console.WriteLine(DownloadStarting.ResultFilePath)
            Console.WriteLine(DownloadOperation.State)
            Console.WriteLine(DownloadOperation.Uri)
            If DownloadOperation.State = CoreWebView2DownloadState.Completed Then
                RaiseEvent FileDownloaded(Me, New FileDownloadedEvent With {.Path = DownloadStarting.ResultFilePath})
            End If
        End Sub

    End Class
    Public Class FileDownloadedEvent
        Inherits EventArgs
        Public Path As String
    End Class
End Namespace