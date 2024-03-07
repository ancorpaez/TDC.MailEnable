Namespace Interfaz
    Public Class Main
        Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Aplicacion.MainForm = Me
            Me.Top = 486
        End Sub

        Private Sub FlowPanel_ControlChange(sender As Object, e As ControlEventArgs) Handles FlowPanel.ControlAdded, FlowPanel.ControlRemoved
            lblConexiones.Text = FlowPanel.Controls.Count
        End Sub
    End Class
End Namespace