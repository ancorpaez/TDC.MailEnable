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
            Me.lstBucles = New System.Windows.Forms.ListView()
            Me.CHBucles = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.CHContador = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.CHIntervalo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.CHActivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
            Me.tlblBucles = New System.Windows.Forms.ToolStripStatusLabel()
            Me.tlblSeparador1 = New System.Windows.Forms.ToolStripStatusLabel()
            Me.tlblVisualizador = New System.Windows.Forms.ToolStripStatusLabel()
            Me.tBtnManual = New System.Windows.Forms.ToolStripDropDownButton()
            Me.TrakVisualizador = New System.Windows.Forms.TrackBar()
            Me.StatusStrip1.SuspendLayout()
            CType(Me.TrakVisualizador, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lstBucles
            '
            Me.lstBucles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CHBucles, Me.CHContador, Me.CHIntervalo, Me.CHActivo})
            Me.lstBucles.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstBucles.FullRowSelect = True
            Me.lstBucles.GridLines = True
            Me.lstBucles.HideSelection = False
            Me.lstBucles.Location = New System.Drawing.Point(0, 0)
            Me.lstBucles.MultiSelect = False
            Me.lstBucles.Name = "lstBucles"
            Me.lstBucles.Size = New System.Drawing.Size(404, 381)
            Me.lstBucles.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lstBucles.TabIndex = 0
            Me.lstBucles.UseCompatibleStateImageBehavior = False
            Me.lstBucles.View = System.Windows.Forms.View.Details
            '
            'CHBucles
            '
            Me.CHBucles.Text = "Bucles"
            '
            'CHContador
            '
            Me.CHContador.Text = "Contador"
            '
            'CHIntervalo
            '
            Me.CHIntervalo.Text = "Intervalo"
            '
            'CHActivo
            '
            Me.CHActivo.Text = "Activo"
            '
            'StatusStrip1
            '
            Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlblBucles, Me.tlblSeparador1, Me.tlblVisualizador, Me.tBtnManual})
            Me.StatusStrip1.Location = New System.Drawing.Point(0, 400)
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
            Me.tlblSeparador1.Name = "tlblSeparador1"
            Me.tlblSeparador1.Size = New System.Drawing.Size(167, 17)
            Me.tlblSeparador1.Spring = True
            Me.tlblSeparador1.Text = "|"
            '
            'tlblVisualizador
            '
            Me.tlblVisualizador.Name = "tlblVisualizador"
            Me.tlblVisualizador.Size = New System.Drawing.Size(73, 17)
            Me.tlblVisualizador.Text = "Visualizar (0)"
            '
            'tBtnManual
            '
            Me.tBtnManual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.tBtnManual.Image = CType(resources.GetObject("tBtnManual.Image"), System.Drawing.Image)
            Me.tBtnManual.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tBtnManual.Name = "tBtnManual"
            Me.tBtnManual.Size = New System.Drawing.Size(60, 20)
            Me.tBtnManual.Text = "Manual"
            '
            'TrakVisualizador
            '
            Me.TrakVisualizador.AutoSize = False
            Me.TrakVisualizador.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.TrakVisualizador.LargeChange = 10
            Me.TrakVisualizador.Location = New System.Drawing.Point(0, 381)
            Me.TrakVisualizador.Maximum = 1000
            Me.TrakVisualizador.Minimum = 10
            Me.TrakVisualizador.Name = "TrakVisualizador"
            Me.TrakVisualizador.Size = New System.Drawing.Size(404, 19)
            Me.TrakVisualizador.TabIndex = 2
            Me.TrakVisualizador.TickStyle = System.Windows.Forms.TickStyle.TopLeft
            Me.TrakVisualizador.Value = 1000
            '
            'View
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(404, 422)
            Me.Controls.Add(Me.lstBucles)
            Me.Controls.Add(Me.TrakVisualizador)
            Me.Controls.Add(Me.StatusStrip1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "View"
            Me.Text = "View"
            Me.StatusStrip1.ResumeLayout(False)
            Me.StatusStrip1.PerformLayout()
            CType(Me.TrakVisualizador, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents lstBucles As Windows.Forms.ListView
        Friend WithEvents CHBucles As Windows.Forms.ColumnHeader
        Friend WithEvents CHContador As Windows.Forms.ColumnHeader
        Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
        Friend WithEvents TrakVisualizador As Windows.Forms.TrackBar
        Friend WithEvents tlblVisualizador As Windows.Forms.ToolStripStatusLabel
        Friend WithEvents CHIntervalo As Windows.Forms.ColumnHeader
        Friend WithEvents tlblBucles As Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tlblSeparador1 As Windows.Forms.ToolStripStatusLabel
        Friend WithEvents CHActivo As Windows.Forms.ColumnHeader
        Friend WithEvents tBtnManual As Windows.Forms.ToolStripDropDownButton
    End Class
End Namespace