Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Bucle
    Public Class InvokeForm
        Private MainBucle As DoBucle
        Private MainParent As Panel = Nothing
        Private BtnString = {"Detener en ForeGround", "Detener en Background", "Detener en EndGround"}
        Friend Enum SelectorTipoVisor
            Ventana
            Control
        End Enum
        Private _Visor As SelectorTipoVisor = SelectorTipoVisor.Control
        Friend Property Visor As SelectorTipoVisor
            Get
                Return _Visor
            End Get
            Set(value As SelectorTipoVisor)
                _Visor = value
                SetVisor()
            End Set
        End Property
        Public Sub New(Bucle As DoBucle)

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            MainBucle = Bucle

            Me.Text = MainBucle.Name
            lblName.Text = MainBucle.Name
            ToolName.Text = MainBucle.Name
        End Sub
        Private Sub SetVisor()
            If Not IsNothing(Me.Parent) Then MainParent = Me.Parent
            Select Case _Visor
                Case SelectorTipoVisor.Ventana
                    Me.FormBorderStyle = FormBorderStyle.Sizable
                    Me.Visible = True
                    Me.Opacity = 1
                    Me.ShowIcon = True
                    ShowInTaskbar = True
                    TopLevel = True
                    Me.Height = 180
                    Me.Width = 250
                    Me.Dock = DockStyle.None

                    ToolContador.Visible = False
                    lblName.Visible = False
                    BtnDetenerForeground.Width = Me.Width - 20
                    BtnDetenerForeground.Text = $"{BtnString(0)}, {If(MainBucle IsNot Nothing, MainBucle.FlagBtnDetenerForeground.ToString(), "False")}"
                    ToolTip.SetToolTip(BtnDetenerForeground, "Detener en ForeGround")

                    BtnDetenerBackground.Width = Me.Width - 20
                    BtnDetenerBackground.Text = $"{BtnString(1)}, {If(MainBucle IsNot Nothing, MainBucle.FlagBtnDetenerBackground.ToString(), "False")}"
                    ToolTip.SetToolTip(BtnDetenerBackground, "Detener en BackGround")

                    BtnDetenerEndground.Width = Me.Width - 20
                    BtnDetenerEndground.Text = $"{BtnString(2)}, {If(MainBucle IsNot Nothing, MainBucle.FlagBtnDetenerEndground.ToString(), "False")}"
                    ToolTip.SetToolTip(BtnDetenerEndground, "Detener en EndGround")

                    ToolStripOptions.Visible = True
                    Status.Visible = True
                    ToolName.Visible = False

                Case SelectorTipoVisor.Control
                    Me.FormBorderStyle = FormBorderStyle.None
                    Me.Visible = False
                    Me.Opacity = 0
                    Me.ShowIcon = False
                    ShowInTaskbar = False
                    Me.TopLevel = False
                    Me.Padding = New Padding(1)
                    Me.Height = ToolStripOptions.Height + (Me.Padding.All + 1)
                    Me.Dock = DockStyle.Top

                    If Me.TopMost Then
                        Me.TopMost = False
                        ToolOptionsSiempreVisible.BackColor = Color.WhiteSmoke
                    End If

                    ToolContador.Visible = True
                    lblName.Visible = True
                    BtnDetenerForeground.Width = ToolStripOptions.Height
                    BtnDetenerForeground.Height = ToolStripOptions.Height
                    BtnDetenerForeground.Text = "F"
                    BtnDetenerBackground.Width = ToolStripOptions.Height
                    BtnDetenerBackground.Height = ToolStripOptions.Height
                    BtnDetenerBackground.Text = "B"
                    BtnDetenerEndground.Width = ToolStripOptions.Height
                    BtnDetenerEndground.Height = ToolStripOptions.Height
                    BtnDetenerEndground.Text = "E"

                    ToolTip.SetToolTip(BtnDetenerForeground, "Detener en ForeGround")
                    ToolTip.SetToolTip(BtnDetenerEndground, "Detener en EndGround")
                    ToolTip.SetToolTip(BtnDetenerBackground, "Detener en BackGround")



                    ToolStripOptions.Visible = False
                    Status.Visible = False
                    ToolName.Visible = True
            End Select
        End Sub

        Private Sub InvokeForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
            e.Cancel = True
            Me.Visible = False
        End Sub

        Private Sub BtnDetenerBackground_Click(sender As Object, e As EventArgs) Handles BtnDetenerBackground.Click
            With MainBucle
                .FlagBtnDetenerBackground = Not .FlagBtnDetenerBackground
                Select Case .FlagBtnDetenerBackground
                    Case True
                        CType(sender, Button).BackColor = Color.DarkRed
                    Case False
                        CType(sender, Button).BackColor = Color.DarkGreen
                End Select
                If Me.FormBorderStyle = FormBorderStyle.Sizable Then
                    CType(sender, Button).Text = $"{BtnString(1)}, { .FlagBtnDetenerBackground}"
                End If
            End With

        End Sub
        Private Sub BtnDetenerForeground_Click(sender As Object, e As EventArgs) Handles BtnDetenerForeground.Click
            With MainBucle
                .FlagBtnDetenerForeground = Not .FlagBtnDetenerForeground
                Select Case .FlagBtnDetenerForeground
                    Case True
                        CType(sender, Button).BackColor = Color.DarkRed
                    Case False
                        CType(sender, Button).BackColor = Color.DarkGreen
                End Select
                If Me.FormBorderStyle = FormBorderStyle.Sizable Then
                    CType(sender, Button).Text = $"{BtnString(0)}, { .FlagBtnDetenerForeground}"
                End If
            End With

        End Sub

        Private Sub BtnDetenerEndground_Click(sender As Object, e As EventArgs) Handles BtnDetenerEndground.Click
            With MainBucle
                .FlagBtnDetenerEndground = Not .FlagBtnDetenerEndground
                Select Case .FlagBtnDetenerEndground
                    Case True
                        CType(sender, Button).BackColor = Color.DarkRed
                    Case False
                        CType(sender, Button).BackColor = Color.DarkGreen
                End Select
                If Me.FormBorderStyle = FormBorderStyle.Sizable Then
                    CType(sender, Button).Text = $"{BtnString(2)}, { .FlagBtnDetenerEndground}"
                End If
            End With
        End Sub

        Private Sub ToolOptions_Click(sender As Object, e As EventArgs) Handles ToolOptionsClose.Click
            Me.Close()
        End Sub

        Private Sub ToolOptionsChange_Click(sender As Object, e As EventArgs) Handles ToolOptionsChange.Click
            If _Visor = SelectorTipoVisor.Control Then
                _Visor = SelectorTipoVisor.Ventana
                MainParent = Me.Parent
                Me.Parent.Controls.Remove(Me)
                SetVisor()
            Else
                _Visor = SelectorTipoVisor.Control
                SetVisor()
                If Not IsNothing(MainParent) AndAlso Not IsNothing(MainParent.Parent) Then
                    MainParent.Controls.Add(Me)
                    Me.Visible = True
                    Me.Opacity = 1
                    MainParent.ScrollControlIntoView(Me)
                Else
                    Me.Visible = False
                    Me.Opacity = 0
                End If
            End If
        End Sub

        Private Sub lblName_MouseEnter(sender As Object, e As EventArgs) Handles lblName.MouseEnter
            If Me.Height = ToolStripOptions.Height + (Me.Padding.All + 1) Then ToolStripOptions.Visible = True
        End Sub

        Private Sub ToolStripOptions_MouseLeave(sender As Object, e As EventArgs) Handles ToolStripOptions.MouseLeave
            If Me.Height = ToolStripOptions.Height + (Me.Padding.All + 1) Then ToolStripOptions.Visible = False
        End Sub

        Private Sub InvokeForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
            ToolSpace.Width = ((ToolStripOptions.Height * 3) - ToolOptionsClose.Height) + 30
            lblCount.Width = ToolStripOptions.Height * 2
            lblName.Width = Me.Width - ((Me.Height * 5) + (Me.Padding.All + 1))
        End Sub

        Private Sub BtnSiempreVisible_Click(sender As Object, e As EventArgs) Handles ToolOptionsSiempreVisible.Click
            Me.TopMost = Not Me.TopMost
            If Me.TopMost Then ToolOptionsSiempreVisible.BackColor = Color.LightSkyBlue Else ToolOptionsSiempreVisible.BackColor = Color.WhiteSmoke
        End Sub

        Private Sub InvokeForm_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
            If Me.FormBorderStyle = FormBorderStyle.None Then
                ToolOptionsSiempreVisible.Visible = False
                ToolOptionsClose.Visible = False
            Else
                ToolOptionsSiempreVisible.Visible = True
                ToolOptionsClose.Visible = True
            End If
        End Sub

        Private Sub MM(sender As Object, e As MouseEventArgs) Handles Me.MouseMove,
            ToolStripOptions.MouseMove,
            ToolOptionsClose.MouseMove,
            ToolOptionsSiempreVisible.MouseMove,
            ToolOptionsChange.MouseMove,
            ToolContador.MouseMove,
            FlowControls.MouseMove
            If Me.FormBorderStyle <> FormBorderStyle.None AndAlso Not Me.Focused AndAlso Me.CanFocus Then Me.Focus()
        End Sub
    End Class
End Namespace