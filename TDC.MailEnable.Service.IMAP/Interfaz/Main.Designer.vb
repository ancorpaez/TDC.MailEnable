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
            Me.components = New System.ComponentModel.Container()
            Me.SplitIMAPConexiones = New System.Windows.Forms.SplitContainer()
            Me.lstConexionesImapActivas = New System.Windows.Forms.ListBox()
            Me.lblConexionesActivas = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.SplitIMAPTables = New System.Windows.Forms.SplitContainer()
            Me.GridImapClientes = New System.Windows.Forms.DataGridView()
            Me.MenuGridClientes = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.GridImapRechazados = New System.Windows.Forms.DataGridView()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.tmiFace = New System.Windows.Forms.Timer(Me.components)
            Me.SplitListeners = New System.Windows.Forms.SplitContainer()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblImapSsl = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.PanelImapListener = New System.Windows.Forms.Panel()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblImap = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            CType(Me.SplitIMAPConexiones, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitIMAPConexiones.Panel1.SuspendLayout()
            Me.SplitIMAPConexiones.Panel2.SuspendLayout()
            Me.SplitIMAPConexiones.SuspendLayout()
            CType(Me.SplitIMAPTables, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitIMAPTables.Panel1.SuspendLayout()
            Me.SplitIMAPTables.Panel2.SuspendLayout()
            Me.SplitIMAPTables.SuspendLayout()
            CType(Me.GridImapClientes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.MenuGridClientes.SuspendLayout()
            CType(Me.GridImapRechazados, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SplitListeners, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitListeners.Panel1.SuspendLayout()
            Me.SplitListeners.Panel2.SuspendLayout()
            Me.SplitListeners.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.PanelImapListener.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitIMAPConexiones
            '
            Me.SplitIMAPConexiones.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitIMAPConexiones.Location = New System.Drawing.Point(0, 0)
            Me.SplitIMAPConexiones.Name = "SplitIMAPConexiones"
            '
            'SplitIMAPConexiones.Panel1
            '
            Me.SplitIMAPConexiones.Panel1.Controls.Add(Me.lstConexionesImapActivas)
            Me.SplitIMAPConexiones.Panel1.Controls.Add(Me.lblConexionesActivas)
            Me.SplitIMAPConexiones.Panel1.Controls.Add(Me.Label5)
            '
            'SplitIMAPConexiones.Panel2
            '
            Me.SplitIMAPConexiones.Panel2.Controls.Add(Me.SplitIMAPTables)
            Me.SplitIMAPConexiones.Size = New System.Drawing.Size(745, 432)
            Me.SplitIMAPConexiones.SplitterDistance = 157
            Me.SplitIMAPConexiones.TabIndex = 2
            '
            'lstConexionesImapActivas
            '
            Me.lstConexionesImapActivas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstConexionesImapActivas.FormattingEnabled = True
            Me.lstConexionesImapActivas.IntegralHeight = False
            Me.lstConexionesImapActivas.Location = New System.Drawing.Point(0, 49)
            Me.lstConexionesImapActivas.Name = "lstConexionesImapActivas"
            Me.lstConexionesImapActivas.Size = New System.Drawing.Size(157, 383)
            Me.lstConexionesImapActivas.TabIndex = 2
            '
            'lblConexionesActivas
            '
            Me.lblConexionesActivas.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblConexionesActivas.Location = New System.Drawing.Point(0, 25)
            Me.lblConexionesActivas.Name = "lblConexionesActivas"
            Me.lblConexionesActivas.Size = New System.Drawing.Size(157, 24)
            Me.lblConexionesActivas.TabIndex = 3
            Me.lblConexionesActivas.Text = "0"
            Me.lblConexionesActivas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Green
            Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(0, 0)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(157, 25)
            Me.Label5.TabIndex = 1
            Me.Label5.Text = "CONEXIONES"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'SplitIMAPTables
            '
            Me.SplitIMAPTables.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitIMAPTables.Location = New System.Drawing.Point(0, 0)
            Me.SplitIMAPTables.Name = "SplitIMAPTables"
            '
            'SplitIMAPTables.Panel1
            '
            Me.SplitIMAPTables.Panel1.Controls.Add(Me.GridImapClientes)
            Me.SplitIMAPTables.Panel1.Controls.Add(Me.Label3)
            '
            'SplitIMAPTables.Panel2
            '
            Me.SplitIMAPTables.Panel2.Controls.Add(Me.GridImapRechazados)
            Me.SplitIMAPTables.Panel2.Controls.Add(Me.Label4)
            Me.SplitIMAPTables.Size = New System.Drawing.Size(584, 432)
            Me.SplitIMAPTables.SplitterDistance = 272
            Me.SplitIMAPTables.TabIndex = 0
            '
            'GridImapClientes
            '
            Me.GridImapClientes.AllowUserToAddRows = False
            Me.GridImapClientes.AllowUserToDeleteRows = False
            Me.GridImapClientes.AllowUserToResizeColumns = False
            Me.GridImapClientes.AllowUserToResizeRows = False
            Me.GridImapClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.GridImapClientes.ContextMenuStrip = Me.MenuGridClientes
            Me.GridImapClientes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GridImapClientes.Location = New System.Drawing.Point(0, 25)
            Me.GridImapClientes.MultiSelect = False
            Me.GridImapClientes.Name = "GridImapClientes"
            Me.GridImapClientes.ReadOnly = True
            Me.GridImapClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.GridImapClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.GridImapClientes.Size = New System.Drawing.Size(272, 407)
            Me.GridImapClientes.TabIndex = 1
            '
            'MenuGridClientes
            '
            Me.MenuGridClientes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarToolStripMenuItem})
            Me.MenuGridClientes.Name = "MenuGridClientes"
            Me.MenuGridClientes.Size = New System.Drawing.Size(110, 26)
            '
            'CopiarToolStripMenuItem
            '
            Me.CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
            Me.CopiarToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
            Me.CopiarToolStripMenuItem.Text = "Copiar"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(0, 0)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(272, 25)
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "CLIENTES"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'GridImapRechazados
            '
            Me.GridImapRechazados.AllowUserToAddRows = False
            Me.GridImapRechazados.AllowUserToDeleteRows = False
            Me.GridImapRechazados.AllowUserToResizeColumns = False
            Me.GridImapRechazados.AllowUserToResizeRows = False
            Me.GridImapRechazados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.GridImapRechazados.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GridImapRechazados.Location = New System.Drawing.Point(0, 25)
            Me.GridImapRechazados.MultiSelect = False
            Me.GridImapRechazados.Name = "GridImapRechazados"
            Me.GridImapRechazados.ReadOnly = True
            Me.GridImapRechazados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.GridImapRechazados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.GridImapRechazados.Size = New System.Drawing.Size(308, 407)
            Me.GridImapRechazados.TabIndex = 1
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(0, 0)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(308, 25)
            Me.Label4.TabIndex = 0
            Me.Label4.Text = "RECHAZADOS"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'tmiFace
            '
            Me.tmiFace.Enabled = True
            '
            'SplitListeners
            '
            Me.SplitListeners.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitListeners.Location = New System.Drawing.Point(0, 0)
            Me.SplitListeners.Name = "SplitListeners"
            '
            'SplitListeners.Panel1
            '
            Me.SplitListeners.Panel1.Controls.Add(Me.Panel1)
            Me.SplitListeners.Panel1.Controls.Add(Me.PanelImapListener)
            '
            'SplitListeners.Panel2
            '
            Me.SplitListeners.Panel2.Controls.Add(Me.SplitIMAPConexiones)
            Me.SplitListeners.Size = New System.Drawing.Size(874, 432)
            Me.SplitListeners.SplitterDistance = 125
            Me.SplitListeners.TabIndex = 3
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 33)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(125, 33)
            Me.Panel1.TabIndex = 1
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 2
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
            Me.TableLayoutPanel2.Controls.Add(Me.lblImapSsl, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.Label6, 1, 0)
            Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 1
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(123, 31)
            Me.TableLayoutPanel2.TabIndex = 0
            '
            'lblImapSsl
            '
            Me.lblImapSsl.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.lblImapSsl.AutoSize = True
            Me.lblImapSsl.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.lblImapSsl.Location = New System.Drawing.Point(4, 2)
            Me.lblImapSsl.Name = "lblImapSsl"
            Me.lblImapSsl.Size = New System.Drawing.Size(16, 26)
            Me.lblImapSsl.TabIndex = 0
            Me.lblImapSsl.Text = "      "
            '
            'Label6
            '
            Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(27, 9)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(65, 13)
            Me.Label6.TabIndex = 1
            Me.Label6.Text = "IMAP  (SSL)"
            '
            'PanelImapListener
            '
            Me.PanelImapListener.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.PanelImapListener.Controls.Add(Me.TableLayoutPanel1)
            Me.PanelImapListener.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelImapListener.Location = New System.Drawing.Point(0, 0)
            Me.PanelImapListener.Name = "PanelImapListener"
            Me.PanelImapListener.Size = New System.Drawing.Size(125, 33)
            Me.PanelImapListener.TabIndex = 0
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.lblImap, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 1
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(123, 31)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'lblImap
            '
            Me.lblImap.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.lblImap.AutoSize = True
            Me.lblImap.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.lblImap.Location = New System.Drawing.Point(4, 2)
            Me.lblImap.Name = "lblImap"
            Me.lblImap.Size = New System.Drawing.Size(16, 26)
            Me.lblImap.TabIndex = 0
            Me.lblImap.Text = "      "
            '
            'Label1
            '
            Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(27, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(36, 13)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "IMAP "
            '
            'Main
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(874, 432)
            Me.Controls.Add(Me.SplitListeners)
            Me.Name = "Main"
            Me.Text = "IMAP"
            Me.SplitIMAPConexiones.Panel1.ResumeLayout(False)
            Me.SplitIMAPConexiones.Panel2.ResumeLayout(False)
            CType(Me.SplitIMAPConexiones, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitIMAPConexiones.ResumeLayout(False)
            Me.SplitIMAPTables.Panel1.ResumeLayout(False)
            Me.SplitIMAPTables.Panel2.ResumeLayout(False)
            CType(Me.SplitIMAPTables, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitIMAPTables.ResumeLayout(False)
            CType(Me.GridImapClientes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.MenuGridClientes.ResumeLayout(False)
            CType(Me.GridImapRechazados, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitListeners.Panel1.ResumeLayout(False)
            Me.SplitListeners.Panel2.ResumeLayout(False)
            CType(Me.SplitListeners, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitListeners.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.PanelImapListener.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents SplitIMAPConexiones As SplitContainer
        Friend WithEvents lstConexionesImapActivas As ListBox
        Friend WithEvents lblConexionesActivas As Label
        Friend WithEvents Label5 As Label
        Friend WithEvents SplitIMAPTables As SplitContainer
        Friend WithEvents GridImapClientes As DataGridView
        Friend WithEvents Label3 As Label
        Friend WithEvents GridImapRechazados As DataGridView
        Friend WithEvents Label4 As Label
        Friend WithEvents tmiFace As Timer
        Friend WithEvents SplitListeners As SplitContainer
        Friend WithEvents PanelImapListener As Panel
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents lblImap As Label
        Friend WithEvents Label1 As Label
        Friend WithEvents Panel1 As Panel
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents lblImapSsl As Label
        Friend WithEvents Label6 As Label
        Friend WithEvents MenuGridClientes As ContextMenuStrip
        Friend WithEvents CopiarToolStripMenuItem As ToolStripMenuItem
    End Class

End Namespace