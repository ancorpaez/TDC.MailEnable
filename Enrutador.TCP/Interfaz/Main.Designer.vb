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
            Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
            Me.lblIpBan = New System.Windows.Forms.ToolStripStatusLabel()
            Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblImap = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblImapSsl = New System.Windows.Forms.ToolStripStatusLabel()
            Me.PanelBaneadas = New System.Windows.Forms.Panel()
            Me.lstRechazadas = New System.Windows.Forms.ListView()
            Me.cIP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.cIntentos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.PanelEstadoBaneadas = New System.Windows.Forms.Panel()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblRechazadas = New System.Windows.Forms.Label()
            Me.PanelAceptadas = New System.Windows.Forms.Panel()
            Me.lstAceptadas = New System.Windows.Forms.ListView()
            Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblAceptadas = New System.Windows.Forms.Label()
            Me.PanelConexiones = New System.Windows.Forms.Panel()
            Me.lstConexiones = New System.Windows.Forms.ListView()
            Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblConexiones = New System.Windows.Forms.Label()
            Me.StatusStrip1.SuspendLayout()
            Me.PanelBaneadas.SuspendLayout()
            Me.PanelEstadoBaneadas.SuspendLayout()
            Me.PanelAceptadas.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.PanelConexiones.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.SuspendLayout()
            '
            'StatusStrip1
            '
            Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblIpBan, Me.ToolStripStatusLabel2, Me.lblImap, Me.lblImapSsl})
            Me.StatusStrip1.Location = New System.Drawing.Point(0, 311)
            Me.StatusStrip1.Name = "StatusStrip1"
            Me.StatusStrip1.Size = New System.Drawing.Size(721, 24)
            Me.StatusStrip1.TabIndex = 0
            Me.StatusStrip1.Text = "StatusStrip1"
            '
            'lblIpBan
            '
            Me.lblIpBan.Name = "lblIpBan"
            Me.lblIpBan.Size = New System.Drawing.Size(54, 19)
            Me.lblIpBan.Text = "IpBan (0)"
            '
            'ToolStripStatusLabel2
            '
            Me.ToolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
            Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
            Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(519, 19)
            Me.ToolStripStatusLabel2.Spring = True
            Me.ToolStripStatusLabel2.Text = " "
            '
            'lblImap
            '
            Me.lblImap.BackColor = System.Drawing.SystemColors.Control
            Me.lblImap.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
            Me.lblImap.Name = "lblImap"
            Me.lblImap.Size = New System.Drawing.Size(75, 19)
            Me.lblImap.Text = "Imap (False)"
            '
            'lblImapSsl
            '
            Me.lblImapSsl.BackColor = System.Drawing.SystemColors.Control
            Me.lblImapSsl.Name = "lblImapSsl"
            Me.lblImapSsl.Size = New System.Drawing.Size(58, 19)
            Me.lblImapSsl.Text = "Ssl (False)"
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
            'PanelAceptadas
            '
            Me.PanelAceptadas.BackColor = System.Drawing.Color.Black
            Me.PanelAceptadas.Controls.Add(Me.lstAceptadas)
            Me.PanelAceptadas.Controls.Add(Me.Panel2)
            Me.PanelAceptadas.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelAceptadas.Location = New System.Drawing.Point(197, 0)
            Me.PanelAceptadas.Name = "PanelAceptadas"
            Me.PanelAceptadas.Padding = New System.Windows.Forms.Padding(1)
            Me.PanelAceptadas.Size = New System.Drawing.Size(236, 311)
            Me.PanelAceptadas.TabIndex = 1
            '
            'lstAceptadas
            '
            Me.lstAceptadas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
            Me.lstAceptadas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstAceptadas.FullRowSelect = True
            Me.lstAceptadas.GridLines = True
            Me.lstAceptadas.HideSelection = False
            Me.lstAceptadas.Location = New System.Drawing.Point(1, 24)
            Me.lstAceptadas.MultiSelect = False
            Me.lstAceptadas.Name = "lstAceptadas"
            Me.lstAceptadas.Size = New System.Drawing.Size(234, 286)
            Me.lstAceptadas.TabIndex = 2
            Me.lstAceptadas.UseCompatibleStateImageBehavior = False
            Me.lstAceptadas.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader1
            '
            Me.ColumnHeader1.Text = "Ip"
            Me.ColumnHeader1.Width = 134
            '
            'ColumnHeader2
            '
            Me.ColumnHeader2.Text = "Concurrentes"
            Me.ColumnHeader2.Width = 87
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.SystemColors.Control
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.lblAceptadas)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel2.Location = New System.Drawing.Point(1, 1)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(234, 23)
            Me.Panel2.TabIndex = 4
            '
            'Label2
            '
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label2.Location = New System.Drawing.Point(0, 0)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(67, 23)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Aceptadas"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblAceptadas
            '
            Me.lblAceptadas.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblAceptadas.Location = New System.Drawing.Point(141, 0)
            Me.lblAceptadas.Name = "lblAceptadas"
            Me.lblAceptadas.Size = New System.Drawing.Size(93, 23)
            Me.lblAceptadas.TabIndex = 1
            Me.lblAceptadas.Text = "0"
            Me.lblAceptadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'PanelConexiones
            '
            Me.PanelConexiones.BackColor = System.Drawing.Color.Black
            Me.PanelConexiones.Controls.Add(Me.lstConexiones)
            Me.PanelConexiones.Controls.Add(Me.Panel3)
            Me.PanelConexiones.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelConexiones.Location = New System.Drawing.Point(433, 0)
            Me.PanelConexiones.Name = "PanelConexiones"
            Me.PanelConexiones.Padding = New System.Windows.Forms.Padding(1)
            Me.PanelConexiones.Size = New System.Drawing.Size(288, 311)
            Me.PanelConexiones.TabIndex = 2
            '
            'lstConexiones
            '
            Me.lstConexiones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
            Me.lstConexiones.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstConexiones.FullRowSelect = True
            Me.lstConexiones.GridLines = True
            Me.lstConexiones.HideSelection = False
            Me.lstConexiones.Location = New System.Drawing.Point(1, 24)
            Me.lstConexiones.MultiSelect = False
            Me.lstConexiones.Name = "lstConexiones"
            Me.lstConexiones.Size = New System.Drawing.Size(286, 286)
            Me.lstConexiones.TabIndex = 2
            Me.lstConexiones.UseCompatibleStateImageBehavior = False
            Me.lstConexiones.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader3
            '
            Me.ColumnHeader3.Text = "Conexion"
            Me.ColumnHeader3.Width = 158
            '
            'ColumnHeader4
            '
            Me.ColumnHeader4.Text = "Tiempo"
            Me.ColumnHeader4.Width = 88
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.SystemColors.Control
            Me.Panel3.Controls.Add(Me.Label4)
            Me.Panel3.Controls.Add(Me.lblConexiones)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel3.Location = New System.Drawing.Point(1, 1)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(286, 23)
            Me.Panel3.TabIndex = 4
            '
            'Label4
            '
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label4.Location = New System.Drawing.Point(0, 0)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(67, 23)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "Conexiones"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblConexiones
            '
            Me.lblConexiones.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblConexiones.Location = New System.Drawing.Point(193, 0)
            Me.lblConexiones.Name = "lblConexiones"
            Me.lblConexiones.Size = New System.Drawing.Size(93, 23)
            Me.lblConexiones.TabIndex = 1
            Me.lblConexiones.Text = "0"
            Me.lblConexiones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Main
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(721, 335)
            Me.Controls.Add(Me.PanelConexiones)
            Me.Controls.Add(Me.PanelAceptadas)
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
            Me.PanelAceptadas.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.PanelConexiones.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents StatusStrip1 As StatusStrip
        Friend WithEvents PanelBaneadas As Panel
        Friend WithEvents lblRechazadas As Label
        Friend WithEvents lstRechazadas As ListView
        Friend WithEvents cIP As ColumnHeader
        Friend WithEvents cIntentos As ColumnHeader
        Friend WithEvents Label1 As Label
        Friend WithEvents PanelEstadoBaneadas As Panel
        Friend WithEvents lblIpBan As ToolStripStatusLabel
        Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
        Friend WithEvents lblImap As ToolStripStatusLabel
        Friend WithEvents lblImapSsl As ToolStripStatusLabel
        Friend WithEvents PanelAceptadas As Panel
        Friend WithEvents lstAceptadas As ListView
        Friend WithEvents ColumnHeader1 As ColumnHeader
        Friend WithEvents ColumnHeader2 As ColumnHeader
        Friend WithEvents Panel2 As Panel
        Friend WithEvents Label2 As Label
        Friend WithEvents lblAceptadas As Label
        Friend WithEvents PanelConexiones As Panel
        Friend WithEvents lstConexiones As ListView
        Friend WithEvents ColumnHeader3 As ColumnHeader
        Friend WithEvents ColumnHeader4 As ColumnHeader
        Friend WithEvents Panel3 As Panel
        Friend WithEvents Label4 As Label
        Friend WithEvents lblConexiones As Label
    End Class
End Namespace