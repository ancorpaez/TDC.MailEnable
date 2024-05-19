Imports System.Windows.Forms

Namespace Bucle
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class View
        Inherits System.Windows.Forms.Form

        'Form reemplaza a Dispose para limpiar la lista de componentes.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Requerido por el Diseñador de Windows Forms
        Private components As System.ComponentModel.IContainer

        'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        'Se puede modificar usando el Diseñador de Windows Forms.  
        'No lo modifique con el editor de código.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(View))
            Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
            Me.tlblBucles = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblSeparador = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblScroll = New System.Windows.Forms.ToolStripStatusLabel()
            Me.btnMouse = New System.Windows.Forms.ToolStripDropDownButton()
            Me.PanelWindows = New System.Windows.Forms.Panel()
            Me.Scroll = New System.Windows.Forms.VScrollBar()
            Me.PanelContenedor = New System.Windows.Forms.Panel()
            Me.StatusStrip1.SuspendLayout()
            Me.PanelContenedor.SuspendLayout()
            Me.SuspendLayout()
            '
            'StatusStrip1
            '
            Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlblBucles, Me.lblSeparador, Me.lblScroll, Me.btnMouse})
            Me.StatusStrip1.Location = New System.Drawing.Point(0, 237)
            Me.StatusStrip1.Name = "StatusStrip1"
            Me.StatusStrip1.Size = New System.Drawing.Size(659, 24)
            Me.StatusStrip1.TabIndex = 1
            Me.StatusStrip1.Text = "Bucles"
            '
            'tlblBucles
            '
            Me.tlblBucles.Name = "tlblBucles"
            Me.tlblBucles.Size = New System.Drawing.Size(58, 19)
            Me.tlblBucles.Text = "Bucles (0)"
            '
            'lblSeparador
            '
            Me.lblSeparador.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
            Me.lblSeparador.Name = "lblSeparador"
            Me.lblSeparador.Size = New System.Drawing.Size(463, 19)
            Me.lblSeparador.Spring = True
            Me.lblSeparador.Visible = False
            '
            'lblScroll
            '
            Me.lblScroll.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
            Me.lblScroll.Name = "lblScroll"
            Me.lblScroll.Size = New System.Drawing.Size(17, 19)
            Me.lblScroll.Text = "0"
            Me.lblScroll.Visible = False
            '
            'btnMouse
            '
            Me.btnMouse.Image = CType(resources.GetObject("btnMouse.Image"), System.Drawing.Image)
            Me.btnMouse.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnMouse.Name = "btnMouse"
            Me.btnMouse.ShowDropDownArrow = False
            Me.btnMouse.Size = New System.Drawing.Size(75, 22)
            Me.btnMouse.Text = "Refrescar"
            Me.btnMouse.Visible = False
            '
            'PanelWindows
            '
            Me.PanelWindows.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.PanelWindows.BackColor = System.Drawing.Color.Black
            Me.PanelWindows.Location = New System.Drawing.Point(1, 1)
            Me.PanelWindows.Name = "PanelWindows"
            Me.PanelWindows.Size = New System.Drawing.Size(365, 147)
            Me.PanelWindows.TabIndex = 4
            '
            'Scroll
            '
            Me.Scroll.Cursor = System.Windows.Forms.Cursors.Cross
            Me.Scroll.Dock = System.Windows.Forms.DockStyle.Right
            Me.Scroll.LargeChange = 50
            Me.Scroll.Location = New System.Drawing.Point(641, 0)
            Me.Scroll.Name = "Scroll"
            Me.Scroll.Size = New System.Drawing.Size(18, 237)
            Me.Scroll.SmallChange = 10
            Me.Scroll.TabIndex = 0
            '
            'PanelContenedor
            '
            Me.PanelContenedor.Controls.Add(Me.Scroll)
            Me.PanelContenedor.Controls.Add(Me.PanelWindows)
            Me.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelContenedor.Location = New System.Drawing.Point(0, 0)
            Me.PanelContenedor.Name = "PanelContenedor"
            Me.PanelContenedor.Size = New System.Drawing.Size(659, 237)
            Me.PanelContenedor.TabIndex = 5
            '
            'View
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(659, 261)
            Me.Controls.Add(Me.PanelContenedor)
            Me.Controls.Add(Me.StatusStrip1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "View"
            Me.Text = "Back Ground View Bucles"
            Me.StatusStrip1.ResumeLayout(False)
            Me.StatusStrip1.PerformLayout()
            Me.PanelContenedor.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents StatusStrip1 As StatusStrip
        Friend WithEvents lblScroll As ToolStripStatusLabel
        Friend WithEvents tlblBucles As ToolStripStatusLabel
        Friend WithEvents lblSeparador As ToolStripStatusLabel
        Friend WithEvents btnMouse As ToolStripDropDownButton
        Friend WithEvents PanelWindows As Panel
        Friend WithEvents Scroll As VScrollBar
        Friend WithEvents PanelContenedor As Panel
    End Class
End Namespace