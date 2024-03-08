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
            Me.tsSeparador1 = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblIpBan = New System.Windows.Forms.ToolStripStatusLabel()
            Me.PanelBaneadas = New System.Windows.Forms.Panel()
            Me.lstRechazadas = New System.Windows.Forms.ListView()
            Me.cIP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.cIntentos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.PanelEstadoBaneadas = New System.Windows.Forms.Panel()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblRechazadas = New System.Windows.Forms.Label()
            Me.StatusStrip1.SuspendLayout()
            Me.PanelBaneadas.SuspendLayout()
            Me.PanelEstadoBaneadas.SuspendLayout()
            Me.SuspendLayout()
            '
            'FlowPanel
            '
            Me.FlowPanel.AutoScroll = True
            Me.FlowPanel.BackColor = System.Drawing.Color.Gray
            Me.FlowPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.FlowPanel.Location = New System.Drawing.Point(197, 0)
            Me.FlowPanel.Name = "FlowPanel"
            Me.FlowPanel.Padding = New System.Windows.Forms.Padding(30)
            Me.FlowPanel.Size = New System.Drawing.Size(706, 311)
            Me.FlowPanel.TabIndex = 0
            '
            'StatusStrip1
            '
            Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblConexiones, Me.tsSeparador1, Me.lblIpBan})
            Me.StatusStrip1.Location = New System.Drawing.Point(0, 311)
            Me.StatusStrip1.Name = "StatusStrip1"
            Me.StatusStrip1.Size = New System.Drawing.Size(903, 24)
            Me.StatusStrip1.TabIndex = 0
            Me.StatusStrip1.Text = "StatusStrip1"
            '
            'ToolStripStatusLabel1
            '
            Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
            Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(71, 19)
            Me.ToolStripStatusLabel1.Text = "Conexiones:"
            '
            'lblConexiones
            '
            Me.lblConexiones.Name = "lblConexiones"
            Me.lblConexiones.Size = New System.Drawing.Size(13, 19)
            Me.lblConexiones.Text = "0"
            '
            'tsSeparador1
            '
            Me.tsSeparador1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
            Me.tsSeparador1.Name = "tsSeparador1"
            Me.tsSeparador1.Size = New System.Drawing.Size(14, 19)
            Me.tsSeparador1.Text = " "
            '
            'lblIpBan
            '
            Me.lblIpBan.Name = "lblIpBan"
            Me.lblIpBan.Size = New System.Drawing.Size(54, 19)
            Me.lblIpBan.Text = "IpBan (0)"
            '
            'PanelBaneadas
            '
            Me.PanelBaneadas.BackColor = System.Drawing.Color.Black
            Me.PanelBaneadas.Controls.Add(Me.lstRechazadas)
            Me.PanelBaneadas.Controls.Add(Me.PanelEstadoBaneadas)
            Me.PanelBaneadas.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelBaneadas.Location = New System.Drawing.Point(0, 0)
            Me.PanelBaneadas.Name = "PanelBaneadas"
            Me.PanelBaneadas.Padding = New System.Windows.Forms.Padding(1)
            Me.PanelBaneadas.Size = New System.Drawing.Size(197, 311)
            Me.PanelBaneadas.TabIndex = 0
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
            Me.lstRechazadas.Size = New System.Drawing.Size(195, 286)
            Me.lstRechazadas.TabIndex = 2
            Me.lstRechazadas.UseCompatibleStateImageBehavior = False
            Me.lstRechazadas.View = System.Windows.Forms.View.Details
            '
            'cIP
            '
            Me.cIP.Text = "Ip"
            Me.cIP.Width = 134
            '
            'cIntentos
            '
            Me.cIntentos.Text = "Intentos"
            Me.cIntentos.Width = 54
            '
            'PanelEstadoBaneadas
            '
            Me.PanelEstadoBaneadas.BackColor = System.Drawing.SystemColors.Control
            Me.PanelEstadoBaneadas.Controls.Add(Me.Label1)
            Me.PanelEstadoBaneadas.Controls.Add(Me.lblRechazadas)
            Me.PanelEstadoBaneadas.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelEstadoBaneadas.Location = New System.Drawing.Point(1, 1)
            Me.PanelEstadoBaneadas.Name = "PanelEstadoBaneadas"
            Me.PanelEstadoBaneadas.Size = New System.Drawing.Size(195, 23)
            Me.PanelEstadoBaneadas.TabIndex = 4
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
            'lblRechazadas
            '
            Me.lblRechazadas.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblRechazadas.Location = New System.Drawing.Point(102, 0)
            Me.lblRechazadas.Name = "lblRechazadas"
            Me.lblRechazadas.Size = New System.Drawing.Size(93, 23)
            Me.lblRechazadas.TabIndex = 1
            Me.lblRechazadas.Text = "0"
            Me.lblRechazadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Main
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(903, 335)
            Me.Controls.Add(Me.FlowPanel)
            Me.Controls.Add(Me.PanelBaneadas)
            Me.Controls.Add(Me.StatusStrip1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "Main"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Enrutador"
            Me.StatusStrip1.ResumeLayout(False)
            Me.StatusStrip1.PerformLayout()
            Me.PanelBaneadas.ResumeLayout(False)
            Me.PanelEstadoBaneadas.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents FlowPanel As FlowLayoutPanel
        Friend WithEvents StatusStrip1 As StatusStrip
        Friend WithEvents lblConexiones As ToolStripStatusLabel
        Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
        Friend WithEvents PanelBaneadas As Panel
        Friend WithEvents lblRechazadas As Label
        Friend WithEvents lstRechazadas As ListView
        Friend WithEvents cIP As ColumnHeader
        Friend WithEvents cIntentos As ColumnHeader
        Friend WithEvents Label1 As Label
        Friend WithEvents PanelEstadoBaneadas As Panel
        Friend WithEvents tsSeparador1 As ToolStripStatusLabel
        Friend WithEvents lblIpBan As ToolStripStatusLabel
    End Class
End Namespace