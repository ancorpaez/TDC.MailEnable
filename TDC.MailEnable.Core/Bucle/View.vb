Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Namespace Bucle
    Public Class View
        Private Visualizador As Bucle.DoBucle
        Private ItemForeColor As Color = Color.Black
        Private ItemTrueColor As Color = Color.DarkGreen
        Private ItemFalseColor As Color = Color.DarkRed

        Private Sub View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            For Each dBucle In GlobalDoBucle.Values.OrderByDescending(Function(v) v.Name)
                If Not dBucle.InvokeForm.TopLevel Then
                    PanelWindows.Controls.Add(dBucle.InvokeForm)
                Else
                    dBucle.InvokeForm.Show()
                End If
                dBucle.InvokeForm.Opacity = 1
                dBucle.InvokeForm.Visible = True
                dBucle.InvokeForm.Show()
            Next
        End Sub
        Private Sub View_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
            For Each dBucle In GlobalDoBucle.Values
                If dBucle.InvokeForm.FormBorderStyle = FormBorderStyle.None Then
                    dBucle.InvokeForm.Opacity = 0
                    dBucle.InvokeForm.Visible = False
                    dBucle.InvokeForm.Hide()
                End If
            Next
            PanelWindows.Controls.Clear()
        End Sub
        Private Sub SetText()
            tlblBucles.Text = $"Procesos ({Core.GlobalDoBucle.Count})"
        End Sub
        Private Sub TrakVisualizador_Scroll(sender As Object, e As EventArgs)
            SetText()
        End Sub


    End Class
End Namespace