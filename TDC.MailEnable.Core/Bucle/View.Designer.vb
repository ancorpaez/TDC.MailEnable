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
            Me.tlblSeparador1 = New System.Windows.Forms.ToolStripStatusLabel()
            Me.tlblVisualizador = New System.Windows.Forms.ToolStripStatusLabel()
            Me.tBtnManual = New System.Windows.Forms.ToolStripDropDownButton()
            Me.PanelWindows = New System.Windows.Forms.Panel()
            Me.StatusStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'StatusStrip1
            '
            Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlblBucles, Me.tlblSeparador1, Me.tlblVisualizador, Me.tBtnManual})
            Me.StatusStrip1.Location = New System.Drawing.Point(0, 405)
            Me.StatusStrip1.Name = "StatusStrip1"
            Me.StatusStrip1.Size = New System.Drawing.Size(404, 22)
            Me.StatusStrip1.TabIndex = 1
            Me.StatusStrip1.Text = "Bucles"
            '
            'tlblBucles
            '
            Me.tlblBucles.Name = "tlblBucles"
            Me.tlblBucles.Size = New System.Drawing.Size(58, 17)
            Me.tlblBucles.Text = "Bucles (0)"
            '
            'tlblSeparador1
            '
            Me.tlblSeparador1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
            Me.tlblSeparador1.Name = "tlblSeparador1"
            Me.tlblSeparador1.Size = New System.Drawing.Size(331, 17)
            Me.tlblSeparador1.Spring = True
            '
            'tlblVisualizador
            '
            Me.tlblVisualizador.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
            Me.tlblVisualizador.Name = "tlblVisualizador"
            Me.tlblVisualizador.Size = New System.Drawing.Size(77, 19)
            Me.tlblVisualizador.Text = "Visualizar (0)"
            Me.tlblVisualizador.Visible = False
            '
            'tBtnManual
            '
            Me.tBtnManual.Image = CType(resources.GetObject("tBtnManual.Image"), System.Drawing.Image)
            Me.tBtnManual.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tBtnManual.Name = "tBtnManual"
            Me.tBtnManual.ShowDropDownArrow = False
            Me.tBtnManual.Size = New System.Drawing.Size(75, 20)
            Me.tBtnManual.Text = "Refrescar"
            Me.tBtnManual.Visible = False
            '
            'PanelWindows
            '
            Me.PanelWindows.AutoScroll = True
            Me.PanelWindows.BackColor = System.Drawing.Color.Black
            Me.PanelWindows.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelWindows.Location = New System.Drawing.Point(0, 0)
            Me.PanelWindows.Name = "PanelWindows"
            Me.PanelWindows.Size = New System.Drawing.Size(404, 405)
            Me.PanelWindows.TabIndex = 4
            '
            'View
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(404, 427)
            Me.Controls.Add(Me.PanelWindows)
            Me.Controls.Add(Me.StatusStrip1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "View"
            Me.Text = "Back Ground View Bucles"
            Me.StatusStrip1.ResumeLayout(False)
            Me.StatusStrip1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
        Friend WithEvents tlblVisualizador As Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tlblBucles As Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tlblSeparador1 As Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tBtnManual As Windows.Forms.ToolStripDropDownButton
        Friend WithEvents PanelWindows As Windows.Forms.Panel
    End Class
End Namespace