Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar
Imports Microsoft.Web.WebView2.Core

Namespace Certificados.Interfaz
    Public Class Navegador
        Public Domain As Domain
        Private WithEvents DownloadOperation As CoreWebView2DownloadOperation = Nothing
        Private WithEvents DownloadStarting As CoreWebView2DownloadStartingEventArgs = Nothing
        Public Event FileDownloaded(sender As Object, File As FileDownloadedEvent)
        Public Event EndProcess(sender As Object)

        Private isHandler As Boolean = False
        Public esDescargado As Boolean = False
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

            If Not esDescargado Then
                For Each Script In Domain.Scripts
                    If WB.Source.AbsoluteUri.Contains(Script.Key) Then
                        WB.ExecuteScriptAsync(Script.Value)
                        'EjecutarScript(Script.Value).ConfigureAwait(False)
                    End If
                Next

                For Each Nav In Domain.Navigation
                    If WB.Source.AbsoluteUri.Contains(Nav.Key) Then
                        WB.Source = Nav.Value
                    End If
                Next
            Else
                WB.CoreWebView2.CloseDefaultDownloadDialog()
                RaiseEvent EndProcess(Me)
            End If

        End Sub

        Async Function EjecutarScript(Script As String) As Task(Of Boolean)
            Dim resultadoScript = Await WB.ExecuteScriptAsync("alert('Script ejecutado correctamente');")
            If Not IsNothing(resultadoScript) Then
                Return True
            End If
            Return False
        End Function
        Private Sub InicioDescarga(sender As Object, e As CoreWebView2DownloadStartingEventArgs)
            DownloadStarting = e
            DownloadOperation = e.DownloadOperation
            e.Handled = True
        End Sub

        Private Sub TiempoDescarga(sender As Object, e As Object)
            Console.WriteLine(DownloadOperation.EstimatedEndTime)
        End Sub
        Private Sub Recibido(sender As Object, e As Object)
            Console.WriteLine($"{DownloadOperation.BytesReceived.ToString} / {DownloadOperation.TotalBytesToReceive.ToString}")
        End Sub

        Private Sub Cer1_StateChanged(sender As Object, e As Object) Handles DownloadOperation.StateChanged

            If DownloadOperation.State = CoreWebView2DownloadState.Completed Then
                esDescargado = True
                RaiseEvent FileDownloaded(Me, New FileDownloadedEvent With {.Path = DownloadStarting.ResultFilePath})
            End If
        End Sub

    End Class
    Public Class FileDownloadedEvent
        Inherits EventArgs
        Public Path As String
    End Class

End Namespace