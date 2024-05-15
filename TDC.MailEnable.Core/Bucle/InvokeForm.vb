Imports System.ComponentModel
Imports System.Drawing

Namespace Bucle
    Public Class InvokeForm
        Private MainBucle As DoBucle
        Private originalBackColor As Color
        Public Sub New(Bucle As DoBucle)

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            MainBucle = Bucle

            Me.Text = MainBucle.Name
            lblName.Text = MainBucle.Name
            ToolName.Text = MainBucle.Name
        End Sub
        Private Sub InvokeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub

        Private Sub InvokeForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
            If Me.Height < 40 Then
                Me.Height = 22
                Me.Padding = New Windows.Forms.Padding(1)
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                lblName.Visible = True
                BtnDetenerForeground.Width = 20
                BtnDetenerBackground.Width = 20
                BtnDetenerEndground.Width = 20
                lblCount.Width = 40

                lblName.Visible = True
                lblName.Width = Me.Width - 102

                ToolStripOptions.Visible = False
                Status.Visible = False
                ToolName.Visible = True
            Else
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                lblName.Visible = False
                BtnDetenerForeground.Width = Me.Width - 20
                BtnDetenerBackground.Width = Me.Width - 20
                BtnDetenerEndground.Width = Me.Width - 20

                ToolStripOptions.Visible = True
                ToolName.Visible = False
                Status.Visible = True
                Status.Enabled = True
                Status.Refresh()
            End If
            'Me.Margin = New Windows.Forms.Padding(0)
        End Sub

        Private Sub InvokeForm_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
            'Me.BackColor = originalBackColor
        End Sub

        Private Sub InvokeForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
            e.Cancel = True
            Me.Visible = False
        End Sub

        Private Sub BtnDetenerBackground_Click(sender As Object, e As EventArgs) Handles BtnDetenerBackground.Click
            With MainBucle
                .Detener(True)
                .FlagBtnDetenerBackground = Not .FlagBtnDetenerBackground
                CType(sender, Windows.Forms.Button).Text = $"Stop Background { .FlagBtnDetenerBackground}"
            End With
        End Sub
        Private Sub BtnDetenerForeground_Click(sender As Object, e As EventArgs) Handles BtnDetenerForeground.Click
            With MainBucle
                .Detener(True)
                .FlagBtnDetenerForeground = Not .FlagBtnDetenerForeground
                CType(sender, Windows.Forms.Button).Text = $"Stop Foreground { .FlagBtnDetenerForeground}"
            End With
        End Sub

        Private Sub BtnDetenerEndground_Click(sender As Object, e As EventArgs) Handles BtnDetenerEndground.Click
            With MainBucle
                .Detener(True)
                .FlagBtnDetenerEndground = Not .FlagBtnDetenerEndground
                CType(sender, Windows.Forms.Button).Text = $"Stop Endground { .FlagBtnDetenerEndground}"
            End With
        End Sub

        Private Sub ToolOptions_Click(sender As Object, e As EventArgs) Handles ToolOptionsClose.Click
            Me.Close()
        End Sub

        Private Sub ToolOptionsChange_Click(sender As Object, e As EventArgs) Handles ToolOptionsChange.Click
            If Me.Height > 40 Then
                Me.Height = 20
                Me.Visible = False
                Me.ShowInTaskbar = False
                Me.TopLevel = False
                Me.Opacity = 0
                Me.Dock = Windows.Forms.DockStyle.Top
            Else
                Me.Parent.Controls.Remove(Me)
                Me.TopLevel = True
                Me.Height = 170
            End If
        End Sub

        Private Sub lblName_MouseEnter(sender As Object, e As EventArgs) Handles lblName.MouseEnter
            If Me.Height < 40 Then ToolStripOptions.Visible = True
        End Sub

        Private Sub ToolStripOptions_MouseLeave(sender As Object, e As EventArgs) Handles ToolStripOptions.MouseLeave
            If Me.Height < 40 Then ToolStripOptions.Visible = False
        End Sub
    End Class
End Namespace