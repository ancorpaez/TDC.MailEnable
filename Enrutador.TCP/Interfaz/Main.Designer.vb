Namespace Interfaz
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class Main
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
            Me.FlowPanel = New System.Windows.Forms.FlowLayoutPanel()
            Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
            Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblConexiones = New System.Windows.Forms.ToolStripStatusLabel()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lblRechazadas = New System.Windows.Forms.Label()
            Me.lstRechazadas = New System.Windows.Forms.ListView()
            Me.cIP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.cIntentos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.StatusStrip1.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'FlowPanel
            '
            Me.FlowPanel.AutoScroll = True
            Me.FlowPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FlowPanel.Location = New System.Drawing.Point(171, 0)
            Me.FlowPanel.Name = "FlowPanel"
            Me.FlowPanel.Size = New System.Drawing.Size(732, 313)
            Me.FlowPanel.TabIndex = 0
            '
            'StatusStrip1
            '
            Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblConexiones})
            Me.StatusStrip1.Location = New System.Drawing.Point(0, 313)
            Me.StatusStrip1.Name = "StatusStrip1"
            Me.StatusStrip1.Size = New System.Drawing.Size(903, 22)
            Me.StatusStrip1.TabIndex = 0
            Me.StatusStrip1.Text = "StatusStrip1"
            '
            'ToolStripStatusLabel1
            '
            Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
            Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(71, 17)
            Me.ToolStripStatusLabel1.Text = "Conexiones:"
            '
            'lblConexiones
            '
            Me.lblConexiones.Name = "lblConexiones"
            Me.lblConexiones.Size = New System.Drawing.Size(13, 17)
            Me.lblConexiones.Text = "0"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.Black
            Me.Panel1.Controls.Add(Me.lstRechazadas)
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
            Me.Panel1.Size = New System.Drawing.Size(171, 313)
            Me.Panel1.TabIndex = 0
            '
            'lblRechazadas
            '
            Me.lblRechazadas.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblRechazadas.Location = New System.Drawing.Point(76, 0)
            Me.lblRechazadas.Name = "lblRechazadas"
            Me.lblRechazadas.Size = New System.Drawing.Size(93, 23)
            Me.lblRechazadas.TabIndex = 1
            Me.lblRechazadas.Text = "0"
            Me.lblRechazadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lstRechazadas
            '
            Me.lstRechazadas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cIP, Me.cIntentos})
            Me.lstRechazadas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstRechazadas.FullRowSelect = True
            Me.lstRechazadas.GridLines = True
            Me.lstRechazadas.HideSelection = False
            Me.lstRechazadas.Location = New System.Drawing.Point(1, 24)
            Me.lstRechazadas.MultiSelect = False
            Me.lstRechazadas.Name = "lstRechazadas"
            Me.lstRechazadas.Size = New System.Drawing.Size(169, 288)
            Me.lstRechazadas.TabIndex = 2
            Me.lstRechazadas.UseCompatibleStateImageBehavior = False
            Me.lstRechazadas.View = System.Windows.Forms.View.Details
            '
            'cIP
            '
            Me.cIP.Text = "Ip"
            Me.cIP.Width = 101
            '
            'cIntentos
            '
            Me.cIntentos.Text = "Intentos"
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(0, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(67, 23)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "Rechazados"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.SystemColors.Control
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.lblRechazadas)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel2.Location = New System.Drawing.Point(1, 1)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(169, 23)
            Me.Panel2.TabIndex = 4
            '
            'Main
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(903, 335)
            Me.Controls.Add(Me.FlowPanel)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.StatusStrip1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "Main"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Enrutador"
            Me.StatusStrip1.ResumeLayout(False)
            Me.StatusStrip1.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents FlowPanel As FlowLayoutPanel
        Friend WithEvents StatusStrip1 As StatusStrip
        Friend WithEvents lblConexiones As ToolStripStatusLabel
        Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
        Friend WithEvents Panel1 As Panel
        Friend WithEvents lblRechazadas As Label
        Friend WithEvents lstRechazadas As ListView
        Friend WithEvents cIP As ColumnHeader
        Friend WithEvents cIntentos As ColumnHeader
        Friend WithEvents Label1 As Label
        Friend WithEvents Panel2 As Panel
    End Class
End Namespace