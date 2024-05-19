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
            Scroll.SendToBack()
        End Sub
        Private Sub View_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
            Me.Visible = False
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
            tlblBucles.Text = $"SubProcesos ({Core.GlobalDoBucle.Count})"
        End Sub
        Private Sub PanelWindows_ControlAdded(sender As Object, e As ControlEventArgs) Handles PanelWindows.ControlAdded
            SetText()
            If PanelWindows.Controls.Count > 0 Then PanelWindows.Height = (PanelWindows.Controls.Count) * PanelWindows.Controls(0).Height
        End Sub

        Private Sub PanelWindows_ControlRemoved(sender As Object, e As ControlEventArgs) Handles PanelWindows.ControlRemoved
            SetText()
            If PanelWindows.Controls.Count > 0 Then PanelWindows.Height = (PanelWindows.Controls.Count) * PanelWindows.Controls(0).Height
        End Sub


        Private Sub Scroll_Scroll(sender As Object, e As ScrollEventArgs) Handles Scroll.Scroll
            PanelWindows.Top = -e.NewValue
            'lblScroll.Text = e.NewValue
        End Sub

        Private Sub View_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
            PanelWindows.Width = PanelContenedor.Width - Scroll.Width
            CalcularAlto()
        End Sub

        Private Sub PanelWindows_SizeChanged(sender As Object, e As EventArgs) Handles PanelWindows.SizeChanged
            Scroll.Maximum = PanelWindows.Height - PanelContenedor.Height
            Scroll.Minimum = 0
        End Sub

        Private Sub PanelWindows_MouseWheel(sender As Object, e As MouseEventArgs) Handles PanelWindows.MouseWheel
            CalcularAlto()

            Select Case e.Delta
                Case > 0
                    'btnMouse.Text = "Arriba"
                    If (Scroll.Value - Scroll.Minimum) > Scroll.SmallChange Then
                        Scroll.Value -= Scroll.SmallChange
                    Else
                        Scroll.Value = Scroll.Minimum
                    End If
                Case Else
                    'btnMouse.Text = "Abajo"
                    If (Scroll.Maximum - Scroll.Value) > Scroll.SmallChange Then
                        Scroll.Value += Scroll.SmallChange
                    Else
                        Scroll.Value = Scroll.Maximum
                    End If
            End Select
            Scroll_Scroll(Scroll, New ScrollEventArgs(ScrollEventType.SmallIncrement, Scroll.Value))
        End Sub
        Private Sub CalcularAlto()
            Dim Contenedor As Integer = PanelContenedor.Height
            Dim Marco As Integer = PanelWindows.Height - Math.Abs(PanelWindows.Top)
            If Contenedor > Marco Then Scroll_Scroll(Scroll, New ScrollEventArgs(ScrollEventType.SmallIncrement, Scroll.Maximum))
            'lblSeparador.Text = $"CAlto{PanelContenedor.Height},Marco{PanelWindows.Height - Math.Abs(PanelWindows.Top)}"
        End Sub
    End Class
End Namespace
'Imports System.ComponentModel
'Imports System.Windows.Forms
'Imports System.Drawing

'Namespace Bucle
'    Public Class View
'        Private Visualizador As Bucle.DoBucle
'        Private ItemForeColor As Color = Color.Black
'        Private ItemTrueColor As Color = Color.DarkGreen
'        Private ItemFalseColor As Color = Color.DarkRed

'        Private Sub View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'            For Each dBucle In GlobalDoBucle.Values.OrderByDescending(Function(v) v.Name)
'                If Not dBucle.InvokeForm.TopLevel Then
'                    PanelWindows.Controls.Add(dBucle.InvokeForm)
'                Else
'                    dBucle.InvokeForm.Show()
'                End If
'                dBucle.InvokeForm.Opacity = 1
'                dBucle.InvokeForm.Visible = True
'                dBucle.InvokeForm.Show()
'            Next
'            Scroll.SendToBack()
'        End Sub
'        Private Sub View_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
'            Me.Visible = False
'            For Each dBucle In GlobalDoBucle.Values
'                If dBucle.InvokeForm.FormBorderStyle = FormBorderStyle.None Then
'                    dBucle.InvokeForm.Opacity = 0
'                    dBucle.InvokeForm.Visible = False
'                    dBucle.InvokeForm.Hide()
'                End If
'            Next
'            PanelWindows.Controls.Clear()
'        End Sub
'        Private Sub SetText()
'            tlblBucles.Text = $"Procesos ({Core.GlobalDoBucle.Count})"
'        End Sub
'        Private Sub PanelWindows_ControlAdded(sender As Object, e As ControlEventArgs) Handles PanelWindows.ControlAdded
'            SetText()
'            If PanelWindows.Controls.Count > 0 Then PanelWindows.Height = (PanelWindows.Controls.Count) * PanelWindows.Controls(0).Height
'        End Sub

'        Private Sub PanelWindows_ControlRemoved(sender As Object, e As ControlEventArgs) Handles PanelWindows.ControlRemoved
'            SetText()
'            If PanelWindows.Controls.Count > 0 Then PanelWindows.Height = (PanelWindows.Controls.Count) * PanelWindows.Controls(0).Height
'        End Sub


'        Private Sub Scroll_Scroll(sender As Object, e As ScrollEventArgs) Handles Scroll.Scroll
'            PanelWindows.Top = -e.NewValue
'            lblScroll.Text = e.NewValue
'        End Sub

'        Private Sub View_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
'            PanelWindows.Width = PanelContenedor.Width - Scroll.Width
'            CalcularAlto()
'        End Sub

'        Private Sub PanelWindows_SizeChanged(sender As Object, e As EventArgs) Handles PanelWindows.SizeChanged
'            Scroll.Maximum = PanelWindows.Height - PanelContenedor.Height
'            Scroll.Minimum = 0
'        End Sub

'        Private Sub PanelWindows_MouseWheel(sender As Object, e As MouseEventArgs) Handles PanelWindows.MouseWheel
'            CalcularAlto()

'            Select Case e.Delta
'                Case > 0
'                    btnMouse.Text = "Arriba"
'                    If (Scroll.Value - Scroll.Minimum) > Scroll.SmallChange Then
'                        Scroll.Value -= Scroll.SmallChange
'                    Else
'                        Scroll.Value = Scroll.Minimum
'                    End If
'                Case Else
'                    btnMouse.Text = "Abajo"
'                    If (Scroll.Maximum - Scroll.Value) > Scroll.SmallChange Then
'                        Scroll.Value += Scroll.SmallChange
'                    Else
'                        Scroll.Value = Scroll.Maximum
'                    End If
'            End Select
'            Scroll_Scroll(Scroll, New ScrollEventArgs(ScrollEventType.SmallIncrement, Scroll.Value))
'        End Sub
'        Private Sub CalcularAlto()
'            Dim Contenedor As Integer = PanelContenedor.Height
'            Dim Marco As Integer = PanelWindows.Height - Math.Abs(PanelWindows.Top)
'            If Contenedor > Marco Then Scroll_Scroll(Scroll, New ScrollEventArgs(ScrollEventType.SmallIncrement, Scroll.Maximum))
'            lblSeparador.Text = $"CAlto{PanelContenedor.Height},Marco{PanelWindows.Height - Math.Abs(PanelWindows.Top)}"
'        End Sub
'    End Class
'End Namespace