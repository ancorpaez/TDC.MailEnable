Namespace Interfaz
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class IpBan
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IpBan))
            Me.PanelIpBaneadas = New System.Windows.Forms.Panel()
            Me.PanelBuscadores = New System.Windows.Forms.Panel()
            Me.PanelLogs = New System.Windows.Forms.Panel()
            Me.SplitLog = New System.Windows.Forms.SplitContainer()
            Me.SalidaConsola = New System.Windows.Forms.RichTextBox()
            Me.lblGeneralLog = New System.Windows.Forms.Label()
            Me.SalidaCrossDomain = New System.Windows.Forms.RichTextBox()
            Me.lblCrossDomainLog = New System.Windows.Forms.Label()
            Me.UcWEB = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcIMAPEx = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcSMTPEx = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcPOPEx = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.PanelIps = New System.Windows.Forms.Panel()
            Me.PanelListaNegra = New System.Windows.Forms.Panel()
            Me.lstIpBaneadas = New System.Windows.Forms.ListBox()
            Me.PanelBotonesListaNegra = New System.Windows.Forms.Panel()
            Me.BtnAñadirIp = New System.Windows.Forms.Button()
            Me.BtnEliminarIp = New System.Windows.Forms.Button()
            Me.BtnPropagarIps = New System.Windows.Forms.Button()
            Me.ChkDetenerPublicacion = New System.Windows.Forms.CheckBox()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblIpsCount = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.PanelBusqueda = New System.Windows.Forms.Panel()
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.lstBusqueda = New System.Windows.Forms.ListBox()
            Me.BtnAñadirBlanca = New System.Windows.Forms.Button()
            Me.PanelTexto = New System.Windows.Forms.Panel()
            Me.txtBuscarIp = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Panel15 = New System.Windows.Forms.Panel()
            Me.lstIpBlancas = New System.Windows.Forms.ListBox()
            Me.PanelBotonesBlanca = New System.Windows.Forms.Panel()
            Me.BtnEliminarBlanca = New System.Windows.Forms.Button()
            Me.BtnAnadirBlanca = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Fondo = New System.Windows.Forms.Panel()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPIpBan = New System.Windows.Forms.TabPage()
            Me.TabSpamAssassin = New System.Windows.Forms.TabPage()
            Me.txtRichSpamAssassin = New System.Windows.Forms.RichTextBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblEstadoSpamAssasin = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.MenuSpamAssassin = New System.Windows.Forms.MenuStrip()
            Me.TSMDetener = New System.Windows.Forms.ToolStripMenuItem()
            Me.TSMIniciarSpamAssassin = New System.Windows.Forms.ToolStripMenuItem()
            Me.TSMIniciarSmapAssassinNormal = New System.Windows.Forms.ToolStripMenuItem()
            Me.TSMIniciarSmapAssassinOculto = New System.Windows.Forms.ToolStripMenuItem()
            Me.TabMailBackup = New System.Windows.Forms.TabPage()
            Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
            Me.TreePostOffices = New System.Windows.Forms.TreeView()
            Me.MenuTablaBackup = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.RestaurarEmail = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
            Me.ReindexarEmail = New System.Windows.Forms.ToolStripMenuItem()
            Me.ReindexarCarpeta = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
            Me.VisualizarEnNotepadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
            Me.ReindexarTodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.IndexarNuevosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.BtnRecargarTreeNodePostOffices = New System.Windows.Forms.Button()
            Me.TablaMailBackup = New System.Windows.Forms.DataGridView()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtFAsunto = New System.Windows.Forms.TextBox()
            Me.txtFRemitente = New System.Windows.Forms.TextBox()
            Me.txtFDestinatarios = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.BtnLimpiarFiltro = New System.Windows.Forms.Button()
            Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
            Me.LabelCorreosEliminados = New System.Windows.Forms.ToolStripStatusLabel()
            Me.ProgresoIndexacion = New System.Windows.Forms.ToolStripProgressBar()
            Me.LabelErroresDataTable = New System.Windows.Forms.ToolStripStatusLabel()
            Me.IconosTab = New System.Windows.Forms.ImageList(Me.components)
            Me.MenuPrincipal = New System.Windows.Forms.MenuStrip()
            Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.TimerIpBan = New System.Windows.Forms.Timer(Me.components)
            Me.TimerGuiAnalizador = New System.Windows.Forms.Timer(Me.components)
            Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
            Me.lblPrueba = New System.Windows.Forms.ToolStripStatusLabel()
            Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
            Me.iMenuTabla = New System.Windows.Forms.ImageList(Me.components)
            Me.FiltrosMailBox = New System.Windows.Forms.BindingSource(Me.components)
            Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
            Me.lblLineasGeneral = New System.Windows.Forms.Label()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.Panel5 = New System.Windows.Forms.Panel()
            Me.lblLineasCrossDomain = New System.Windows.Forms.Label()
            Me.PanelIpBaneadas.SuspendLayout()
            Me.PanelBuscadores.SuspendLayout()
            Me.PanelLogs.SuspendLayout()
            CType(Me.SplitLog, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitLog.Panel1.SuspendLayout()
            Me.SplitLog.Panel2.SuspendLayout()
            Me.SplitLog.SuspendLayout()
            Me.PanelIps.SuspendLayout()
            Me.PanelListaNegra.SuspendLayout()
            Me.PanelBotonesListaNegra.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.PanelBusqueda.SuspendLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.PanelTexto.SuspendLayout()
            Me.Panel15.SuspendLayout()
            Me.PanelBotonesBlanca.SuspendLayout()
            Me.Fondo.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPIpBan.SuspendLayout()
            Me.TabSpamAssassin.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.MenuSpamAssassin.SuspendLayout()
            Me.TabMailBackup.SuspendLayout()
            CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer2.Panel1.SuspendLayout()
            Me.SplitContainer2.Panel2.SuspendLayout()
            Me.SplitContainer2.SuspendLayout()
            Me.MenuTablaBackup.SuspendLayout()
            CType(Me.TablaMailBackup, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.StatusStrip1.SuspendLayout()
            Me.MenuPrincipal.SuspendLayout()
            Me.StatusStrip2.SuspendLayout()
            CType(Me.FiltrosMailBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel4.SuspendLayout()
            Me.Panel5.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelIpBaneadas
            '
            Me.PanelIpBaneadas.Controls.Add(Me.PanelBuscadores)
            Me.PanelIpBaneadas.Controls.Add(Me.PanelIps)
            Me.PanelIpBaneadas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelIpBaneadas.Location = New System.Drawing.Point(3, 3)
            Me.PanelIpBaneadas.Name = "PanelIpBaneadas"
            Me.PanelIpBaneadas.Padding = New System.Windows.Forms.Padding(3)
            Me.PanelIpBaneadas.Size = New System.Drawing.Size(1434, 415)
            Me.PanelIpBaneadas.TabIndex = 1
            '
            'PanelBuscadores
            '
            Me.PanelBuscadores.BackColor = System.Drawing.Color.Gainsboro
            Me.PanelBuscadores.Controls.Add(Me.PanelLogs)
            Me.PanelBuscadores.Controls.Add(Me.UcWEB)
            Me.PanelBuscadores.Controls.Add(Me.UcIMAPEx)
            Me.PanelBuscadores.Controls.Add(Me.UcSMTPEx)
            Me.PanelBuscadores.Controls.Add(Me.UcPOPEx)
            Me.PanelBuscadores.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelBuscadores.Location = New System.Drawing.Point(337, 3)
            Me.PanelBuscadores.Name = "PanelBuscadores"
            Me.PanelBuscadores.Padding = New System.Windows.Forms.Padding(3)
            Me.PanelBuscadores.Size = New System.Drawing.Size(1094, 409)
            Me.PanelBuscadores.TabIndex = 3
            '
            'PanelLogs
            '
            Me.PanelLogs.Controls.Add(Me.SplitLog)
            Me.PanelLogs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelLogs.Location = New System.Drawing.Point(3, 163)
            Me.PanelLogs.Name = "PanelLogs"
            Me.PanelLogs.Size = New System.Drawing.Size(1088, 243)
            Me.PanelLogs.TabIndex = 1
            '
            'SplitLog
            '
            Me.SplitLog.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitLog.Location = New System.Drawing.Point(0, 0)
            Me.SplitLog.Name = "SplitLog"
            Me.SplitLog.Orientation = System.Windows.Forms.Orientation.Horizontal
            '
            'SplitLog.Panel1
            '
            Me.SplitLog.Panel1.Controls.Add(Me.SalidaConsola)
            Me.SplitLog.Panel1.Controls.Add(Me.Panel4)
            '
            'SplitLog.Panel2
            '
            Me.SplitLog.Panel2.Controls.Add(Me.SalidaCrossDomain)
            Me.SplitLog.Panel2.Controls.Add(Me.Panel5)
            Me.SplitLog.Size = New System.Drawing.Size(1088, 243)
            Me.SplitLog.SplitterDistance = 112
            Me.SplitLog.TabIndex = 3
            '
            'SalidaConsola
            '
            Me.SalidaConsola.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SalidaConsola.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.SalidaConsola.Location = New System.Drawing.Point(0, 18)
            Me.SalidaConsola.Name = "SalidaConsola"
            Me.SalidaConsola.Size = New System.Drawing.Size(1088, 94)
            Me.SalidaConsola.TabIndex = 0
            Me.SalidaConsola.Text = ""
            '
            'lblGeneralLog
            '
            Me.lblGeneralLog.Dock = System.Windows.Forms.DockStyle.Left
            Me.lblGeneralLog.Location = New System.Drawing.Point(0, 0)
            Me.lblGeneralLog.Name = "lblGeneralLog"
            Me.lblGeneralLog.Size = New System.Drawing.Size(200, 18)
            Me.lblGeneralLog.TabIndex = 1
            Me.lblGeneralLog.Text = "General (0)"
            '
            'SalidaCrossDomain
            '
            Me.SalidaCrossDomain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SalidaCrossDomain.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.SalidaCrossDomain.Location = New System.Drawing.Point(0, 51)
            Me.SalidaCrossDomain.Name = "SalidaCrossDomain"
            Me.SalidaCrossDomain.Size = New System.Drawing.Size(1088, 76)
            Me.SalidaCrossDomain.TabIndex = 1
            Me.SalidaCrossDomain.Text = ""
            Me.SalidaCrossDomain.WordWrap = False
            '
            'lblCrossDomainLog
            '
            Me.lblCrossDomainLog.Dock = System.Windows.Forms.DockStyle.Left
            Me.lblCrossDomainLog.Location = New System.Drawing.Point(0, 0)
            Me.lblCrossDomainLog.Name = "lblCrossDomainLog"
            Me.lblCrossDomainLog.Size = New System.Drawing.Size(200, 51)
            Me.lblCrossDomainLog.TabIndex = 2
            Me.lblCrossDomainLog.Text = "CrossDomain (0)"
            '
            'UcWEB
            '
            Me.UcWEB.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcWEB.Location = New System.Drawing.Point(3, 123)
            Me.UcWEB.Name = "UcWEB"
            Me.UcWEB.Size = New System.Drawing.Size(1088, 40)
            Me.UcWEB.TabIndex = 0
            '
            'UcIMAPEx
            '
            Me.UcIMAPEx.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcIMAPEx.Location = New System.Drawing.Point(3, 83)
            Me.UcIMAPEx.Name = "UcIMAPEx"
            Me.UcIMAPEx.Size = New System.Drawing.Size(1088, 40)
            Me.UcIMAPEx.TabIndex = 0
            '
            'UcSMTPEx
            '
            Me.UcSMTPEx.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcSMTPEx.Location = New System.Drawing.Point(3, 43)
            Me.UcSMTPEx.Name = "UcSMTPEx"
            Me.UcSMTPEx.Size = New System.Drawing.Size(1088, 40)
            Me.UcSMTPEx.TabIndex = 0
            '
            'UcPOPEx
            '
            Me.UcPOPEx.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcPOPEx.Location = New System.Drawing.Point(3, 3)
            Me.UcPOPEx.Name = "UcPOPEx"
            Me.UcPOPEx.Size = New System.Drawing.Size(1088, 40)
            Me.UcPOPEx.TabIndex = 0
            '
            'PanelIps
            '
            Me.PanelIps.Controls.Add(Me.PanelListaNegra)
            Me.PanelIps.Controls.Add(Me.PanelBusqueda)
            Me.PanelIps.Controls.Add(Me.Panel15)
            Me.PanelIps.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelIps.Location = New System.Drawing.Point(3, 3)
            Me.PanelIps.Name = "PanelIps"
            Me.PanelIps.Size = New System.Drawing.Size(334, 409)
            Me.PanelIps.TabIndex = 1
            '
            'PanelListaNegra
            '
            Me.PanelListaNegra.Controls.Add(Me.lstIpBaneadas)
            Me.PanelListaNegra.Controls.Add(Me.PanelBotonesListaNegra)
            Me.PanelListaNegra.Controls.Add(Me.TableLayoutPanel1)
            Me.PanelListaNegra.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelListaNegra.Location = New System.Drawing.Point(0, 0)
            Me.PanelListaNegra.Name = "PanelListaNegra"
            Me.PanelListaNegra.Padding = New System.Windows.Forms.Padding(3)
            Me.PanelListaNegra.Size = New System.Drawing.Size(203, 309)
            Me.PanelListaNegra.TabIndex = 6
            '
            'lstIpBaneadas
            '
            Me.lstIpBaneadas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstIpBaneadas.FormattingEnabled = True
            Me.lstIpBaneadas.IntegralHeight = False
            Me.lstIpBaneadas.Location = New System.Drawing.Point(3, 29)
            Me.lstIpBaneadas.Name = "lstIpBaneadas"
            Me.lstIpBaneadas.Size = New System.Drawing.Size(197, 215)
            Me.lstIpBaneadas.TabIndex = 2
            '
            'PanelBotonesListaNegra
            '
            Me.PanelBotonesListaNegra.BackColor = System.Drawing.Color.Black
            Me.PanelBotonesListaNegra.Controls.Add(Me.BtnAñadirIp)
            Me.PanelBotonesListaNegra.Controls.Add(Me.BtnEliminarIp)
            Me.PanelBotonesListaNegra.Controls.Add(Me.BtnPropagarIps)
            Me.PanelBotonesListaNegra.Controls.Add(Me.ChkDetenerPublicacion)
            Me.PanelBotonesListaNegra.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelBotonesListaNegra.Location = New System.Drawing.Point(3, 244)
            Me.PanelBotonesListaNegra.Name = "PanelBotonesListaNegra"
            Me.PanelBotonesListaNegra.Padding = New System.Windows.Forms.Padding(1)
            Me.PanelBotonesListaNegra.Size = New System.Drawing.Size(197, 62)
            Me.PanelBotonesListaNegra.TabIndex = 1
            '
            'BtnAñadirIp
            '
            Me.BtnAñadirIp.Dock = System.Windows.Forms.DockStyle.Fill
            Me.BtnAñadirIp.Location = New System.Drawing.Point(1, 1)
            Me.BtnAñadirIp.Name = "BtnAñadirIp"
            Me.BtnAñadirIp.Size = New System.Drawing.Size(47, 37)
            Me.BtnAñadirIp.TabIndex = 0
            Me.BtnAñadirIp.Text = "Añadir"
            Me.BtnAñadirIp.UseVisualStyleBackColor = True
            '
            'BtnEliminarIp
            '
            Me.BtnEliminarIp.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnEliminarIp.Location = New System.Drawing.Point(48, 1)
            Me.BtnEliminarIp.Name = "BtnEliminarIp"
            Me.BtnEliminarIp.Size = New System.Drawing.Size(74, 37)
            Me.BtnEliminarIp.TabIndex = 1
            Me.BtnEliminarIp.Text = "Eliminar"
            Me.BtnEliminarIp.UseVisualStyleBackColor = True
            '
            'BtnPropagarIps
            '
            Me.BtnPropagarIps.BackColor = System.Drawing.Color.YellowGreen
            Me.BtnPropagarIps.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnPropagarIps.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.BtnPropagarIps.Location = New System.Drawing.Point(122, 1)
            Me.BtnPropagarIps.Name = "BtnPropagarIps"
            Me.BtnPropagarIps.Size = New System.Drawing.Size(74, 37)
            Me.BtnPropagarIps.TabIndex = 2
            Me.BtnPropagarIps.Text = "Propagar"
            Me.BtnPropagarIps.UseVisualStyleBackColor = False
            '
            'ChkDetenerPublicacion
            '
            Me.ChkDetenerPublicacion.AutoSize = True
            Me.ChkDetenerPublicacion.BackColor = System.Drawing.Color.Black
            Me.ChkDetenerPublicacion.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.ChkDetenerPublicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ChkDetenerPublicacion.ForeColor = System.Drawing.Color.White
            Me.ChkDetenerPublicacion.Location = New System.Drawing.Point(1, 38)
            Me.ChkDetenerPublicacion.Name = "ChkDetenerPublicacion"
            Me.ChkDetenerPublicacion.Padding = New System.Windows.Forms.Padding(3)
            Me.ChkDetenerPublicacion.Size = New System.Drawing.Size(195, 23)
            Me.ChkDetenerPublicacion.TabIndex = 5
            Me.ChkDetenerPublicacion.Text = "Pausar Propagación"
            Me.ChkDetenerPublicacion.UseVisualStyleBackColor = False
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.lblIpsCount, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 1
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(197, 26)
            Me.TableLayoutPanel1.TabIndex = 3
            '
            'lblIpsCount
            '
            Me.lblIpsCount.BackColor = System.Drawing.Color.Black
            Me.lblIpsCount.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIpsCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIpsCount.ForeColor = System.Drawing.Color.White
            Me.lblIpsCount.Location = New System.Drawing.Point(137, 0)
            Me.lblIpsCount.Margin = New System.Windows.Forms.Padding(0)
            Me.lblIpsCount.Name = "lblIpsCount"
            Me.lblIpsCount.Size = New System.Drawing.Size(60, 26)
            Me.lblIpsCount.TabIndex = 1
            Me.lblIpsCount.Text = "999"
            Me.lblIpsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Black
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(0, 0)
            Me.Label1.Margin = New System.Windows.Forms.Padding(0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(137, 26)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Lista NEGRA"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'PanelBusqueda
            '
            Me.PanelBusqueda.Controls.Add(Me.SplitContainer1)
            Me.PanelBusqueda.Controls.Add(Me.PanelTexto)
            Me.PanelBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelBusqueda.Location = New System.Drawing.Point(0, 309)
            Me.PanelBusqueda.Name = "PanelBusqueda"
            Me.PanelBusqueda.Size = New System.Drawing.Size(203, 100)
            Me.PanelBusqueda.TabIndex = 7
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 30)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.lstBusqueda)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.BtnAñadirBlanca)
            Me.SplitContainer1.Size = New System.Drawing.Size(203, 70)
            Me.SplitContainer1.SplitterDistance = 151
            Me.SplitContainer1.TabIndex = 5
            '
            'lstBusqueda
            '
            Me.lstBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstBusqueda.FormattingEnabled = True
            Me.lstBusqueda.IntegralHeight = False
            Me.lstBusqueda.Location = New System.Drawing.Point(0, 0)
            Me.lstBusqueda.Name = "lstBusqueda"
            Me.lstBusqueda.Size = New System.Drawing.Size(151, 70)
            Me.lstBusqueda.TabIndex = 4
            '
            'BtnAñadirBlanca
            '
            Me.BtnAñadirBlanca.Dock = System.Windows.Forms.DockStyle.Top
            Me.BtnAñadirBlanca.Location = New System.Drawing.Point(0, 0)
            Me.BtnAñadirBlanca.Name = "BtnAñadirBlanca"
            Me.BtnAñadirBlanca.Size = New System.Drawing.Size(48, 31)
            Me.BtnAñadirBlanca.TabIndex = 0
            Me.BtnAñadirBlanca.Text = ">>>"
            Me.BtnAñadirBlanca.UseVisualStyleBackColor = True
            '
            'PanelTexto
            '
            Me.PanelTexto.Controls.Add(Me.txtBuscarIp)
            Me.PanelTexto.Controls.Add(Me.Label6)
            Me.PanelTexto.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelTexto.Location = New System.Drawing.Point(0, 0)
            Me.PanelTexto.Name = "PanelTexto"
            Me.PanelTexto.Padding = New System.Windows.Forms.Padding(3)
            Me.PanelTexto.Size = New System.Drawing.Size(203, 30)
            Me.PanelTexto.TabIndex = 3
            '
            'txtBuscarIp
            '
            Me.txtBuscarIp.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtBuscarIp.Location = New System.Drawing.Point(46, 3)
            Me.txtBuscarIp.Multiline = True
            Me.txtBuscarIp.Name = "txtBuscarIp"
            Me.txtBuscarIp.Size = New System.Drawing.Size(154, 24)
            Me.txtBuscarIp.TabIndex = 2
            '
            'Label6
            '
            Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label6.Location = New System.Drawing.Point(3, 3)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(43, 24)
            Me.Label6.TabIndex = 3
            Me.Label6.Text = "Buscar:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Panel15
            '
            Me.Panel15.Controls.Add(Me.lstIpBlancas)
            Me.Panel15.Controls.Add(Me.PanelBotonesBlanca)
            Me.Panel15.Controls.Add(Me.Label2)
            Me.Panel15.Dock = System.Windows.Forms.DockStyle.Right
            Me.Panel15.Location = New System.Drawing.Point(203, 0)
            Me.Panel15.Name = "Panel15"
            Me.Panel15.Padding = New System.Windows.Forms.Padding(3)
            Me.Panel15.Size = New System.Drawing.Size(131, 409)
            Me.Panel15.TabIndex = 5
            '
            'lstIpBlancas
            '
            Me.lstIpBlancas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstIpBlancas.FormattingEnabled = True
            Me.lstIpBlancas.IntegralHeight = False
            Me.lstIpBlancas.Location = New System.Drawing.Point(3, 23)
            Me.lstIpBlancas.Name = "lstIpBlancas"
            Me.lstIpBlancas.Size = New System.Drawing.Size(125, 341)
            Me.lstIpBlancas.TabIndex = 0
            '
            'PanelBotonesBlanca
            '
            Me.PanelBotonesBlanca.Controls.Add(Me.BtnEliminarBlanca)
            Me.PanelBotonesBlanca.Controls.Add(Me.BtnAnadirBlanca)
            Me.PanelBotonesBlanca.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelBotonesBlanca.Location = New System.Drawing.Point(3, 364)
            Me.PanelBotonesBlanca.Name = "PanelBotonesBlanca"
            Me.PanelBotonesBlanca.Size = New System.Drawing.Size(125, 42)
            Me.PanelBotonesBlanca.TabIndex = 4
            '
            'BtnEliminarBlanca
            '
            Me.BtnEliminarBlanca.Dock = System.Windows.Forms.DockStyle.Fill
            Me.BtnEliminarBlanca.Location = New System.Drawing.Point(0, 0)
            Me.BtnEliminarBlanca.Name = "BtnEliminarBlanca"
            Me.BtnEliminarBlanca.Size = New System.Drawing.Size(62, 42)
            Me.BtnEliminarBlanca.TabIndex = 1
            Me.BtnEliminarBlanca.Text = "Eliminar"
            Me.BtnEliminarBlanca.UseVisualStyleBackColor = True
            '
            'BtnAnadirBlanca
            '
            Me.BtnAnadirBlanca.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnAnadirBlanca.Location = New System.Drawing.Point(62, 0)
            Me.BtnAnadirBlanca.Name = "BtnAnadirBlanca"
            Me.BtnAnadirBlanca.Size = New System.Drawing.Size(63, 42)
            Me.BtnAnadirBlanca.TabIndex = 3
            Me.BtnAnadirBlanca.Text = "Añadir"
            Me.BtnAnadirBlanca.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Black
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(3, 3)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(125, 20)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Lista BLANCA"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Fondo
            '
            Me.Fondo.Controls.Add(Me.TabControl1)
            Me.Fondo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Fondo.Location = New System.Drawing.Point(0, 24)
            Me.Fondo.Name = "Fondo"
            Me.Fondo.Padding = New System.Windows.Forms.Padding(10)
            Me.Fondo.Size = New System.Drawing.Size(1468, 484)
            Me.Fondo.TabIndex = 1
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPIpBan)
            Me.TabControl1.Controls.Add(Me.TabSpamAssassin)
            Me.TabControl1.Controls.Add(Me.TabMailBackup)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.ImageList = Me.IconosTab
            Me.TabControl1.Location = New System.Drawing.Point(10, 10)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1448, 464)
            Me.TabControl1.TabIndex = 3
            '
            'TabPIpBan
            '
            Me.TabPIpBan.Controls.Add(Me.PanelIpBaneadas)
            Me.TabPIpBan.ImageIndex = 1
            Me.TabPIpBan.Location = New System.Drawing.Point(4, 39)
            Me.TabPIpBan.Name = "TabPIpBan"
            Me.TabPIpBan.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPIpBan.Size = New System.Drawing.Size(1440, 421)
            Me.TabPIpBan.TabIndex = 0
            Me.TabPIpBan.Text = "IpBan"
            Me.TabPIpBan.UseVisualStyleBackColor = True
            '
            'TabSpamAssassin
            '
            Me.TabSpamAssassin.Controls.Add(Me.txtRichSpamAssassin)
            Me.TabSpamAssassin.Controls.Add(Me.Panel1)
            Me.TabSpamAssassin.ImageIndex = 0
            Me.TabSpamAssassin.Location = New System.Drawing.Point(4, 39)
            Me.TabSpamAssassin.Name = "TabSpamAssassin"
            Me.TabSpamAssassin.Padding = New System.Windows.Forms.Padding(3)
            Me.TabSpamAssassin.Size = New System.Drawing.Size(1440, 421)
            Me.TabSpamAssassin.TabIndex = 1
            Me.TabSpamAssassin.Text = "SpamAssassin"
            Me.TabSpamAssassin.UseVisualStyleBackColor = True
            '
            'txtRichSpamAssassin
            '
            Me.txtRichSpamAssassin.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtRichSpamAssassin.Location = New System.Drawing.Point(3, 43)
            Me.txtRichSpamAssassin.Name = "txtRichSpamAssassin"
            Me.txtRichSpamAssassin.Size = New System.Drawing.Size(1434, 375)
            Me.txtRichSpamAssassin.TabIndex = 0
            Me.txtRichSpamAssassin.Text = ""
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Panel2)
            Me.Panel1.Controls.Add(Me.MenuSpamAssassin)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(3, 3)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(3)
            Me.Panel1.Size = New System.Drawing.Size(1434, 40)
            Me.Panel1.TabIndex = 1
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.lblEstadoSpamAssasin)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
            Me.Panel2.Location = New System.Drawing.Point(1319, 3)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(112, 34)
            Me.Panel2.TabIndex = 1
            '
            'lblEstadoSpamAssasin
            '
            Me.lblEstadoSpamAssasin.BackColor = System.Drawing.Color.Red
            Me.lblEstadoSpamAssasin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblEstadoSpamAssasin.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblEstadoSpamAssasin.Location = New System.Drawing.Point(60, 0)
            Me.lblEstadoSpamAssasin.Name = "lblEstadoSpamAssasin"
            Me.lblEstadoSpamAssasin.Size = New System.Drawing.Size(52, 34)
            Me.lblEstadoSpamAssasin.TabIndex = 1
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(3, 11)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(54, 13)
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "ESTADO:"
            '
            'MenuSpamAssassin
            '
            Me.MenuSpamAssassin.AutoSize = False
            Me.MenuSpamAssassin.BackColor = System.Drawing.Color.White
            Me.MenuSpamAssassin.Dock = System.Windows.Forms.DockStyle.Left
            Me.MenuSpamAssassin.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMDetener, Me.TSMIniciarSpamAssassin})
            Me.MenuSpamAssassin.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
            Me.MenuSpamAssassin.Location = New System.Drawing.Point(3, 3)
            Me.MenuSpamAssassin.Name = "MenuSpamAssassin"
            Me.MenuSpamAssassin.Size = New System.Drawing.Size(167, 34)
            Me.MenuSpamAssassin.TabIndex = 2
            Me.MenuSpamAssassin.Text = "MenuStrip1"
            '
            'TSMDetener
            '
            Me.TSMDetener.Image = CType(resources.GetObject("TSMDetener.Image"), System.Drawing.Image)
            Me.TSMDetener.Name = "TSMDetener"
            Me.TSMDetener.Size = New System.Drawing.Size(76, 30)
            Me.TSMDetener.Text = "Detener"
            '
            'TSMIniciarSpamAssassin
            '
            Me.TSMIniciarSpamAssassin.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMIniciarSmapAssassinNormal, Me.TSMIniciarSmapAssassinOculto})
            Me.TSMIniciarSpamAssassin.Image = CType(resources.GetObject("TSMIniciarSpamAssassin.Image"), System.Drawing.Image)
            Me.TSMIniciarSpamAssassin.Name = "TSMIniciarSpamAssassin"
            Me.TSMIniciarSpamAssassin.Size = New System.Drawing.Size(67, 30)
            Me.TSMIniciarSpamAssassin.Text = "Iniciar"
            '
            'TSMIniciarSmapAssassinNormal
            '
            Me.TSMIniciarSmapAssassinNormal.Name = "TSMIniciarSmapAssassinNormal"
            Me.TSMIniciarSmapAssassinNormal.Size = New System.Drawing.Size(114, 22)
            Me.TSMIniciarSmapAssassinNormal.Text = "Normal"
            '
            'TSMIniciarSmapAssassinOculto
            '
            Me.TSMIniciarSmapAssassinOculto.Name = "TSMIniciarSmapAssassinOculto"
            Me.TSMIniciarSmapAssassinOculto.Size = New System.Drawing.Size(114, 22)
            Me.TSMIniciarSmapAssassinOculto.Text = "Oculto"
            '
            'TabMailBackup
            '
            Me.TabMailBackup.Controls.Add(Me.SplitContainer2)
            Me.TabMailBackup.ImageKey = "MB"
            Me.TabMailBackup.Location = New System.Drawing.Point(4, 39)
            Me.TabMailBackup.Name = "TabMailBackup"
            Me.TabMailBackup.Size = New System.Drawing.Size(1440, 421)
            Me.TabMailBackup.TabIndex = 2
            Me.TabMailBackup.Text = "MAIL BACKUP"
            Me.TabMailBackup.UseVisualStyleBackColor = True
            '
            'SplitContainer2
            '
            Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer2.Name = "SplitContainer2"
            '
            'SplitContainer2.Panel1
            '
            Me.SplitContainer2.Panel1.Controls.Add(Me.TreePostOffices)
            Me.SplitContainer2.Panel1.Controls.Add(Me.BtnRecargarTreeNodePostOffices)
            '
            'SplitContainer2.Panel2
            '
            Me.SplitContainer2.Panel2.Controls.Add(Me.TablaMailBackup)
            Me.SplitContainer2.Panel2.Controls.Add(Me.Panel3)
            Me.SplitContainer2.Panel2.Controls.Add(Me.StatusStrip1)
            Me.SplitContainer2.Size = New System.Drawing.Size(1440, 421)
            Me.SplitContainer2.SplitterDistance = 478
            Me.SplitContainer2.TabIndex = 0
            '
            'TreePostOffices
            '
            Me.TreePostOffices.ContextMenuStrip = Me.MenuTablaBackup
            Me.TreePostOffices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TreePostOffices.Location = New System.Drawing.Point(0, 0)
            Me.TreePostOffices.Name = "TreePostOffices"
            Me.TreePostOffices.Size = New System.Drawing.Size(478, 388)
            Me.TreePostOffices.TabIndex = 0
            '
            'MenuTablaBackup
            '
            Me.MenuTablaBackup.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestaurarEmail, Me.ToolStripMenuItem3, Me.ReindexarEmail, Me.ReindexarCarpeta, Me.ToolStripMenuItem1, Me.VisualizarEnNotepadToolStripMenuItem, Me.ToolStripMenuItem2, Me.ReindexarTodoToolStripMenuItem, Me.IndexarNuevosToolStripMenuItem})
            Me.MenuTablaBackup.Name = "MenuTablaBackup"
            Me.MenuTablaBackup.Size = New System.Drawing.Size(208, 154)
            '
            'RestaurarEmail
            '
            Me.RestaurarEmail.Image = CType(resources.GetObject("RestaurarEmail.Image"), System.Drawing.Image)
            Me.RestaurarEmail.Name = "RestaurarEmail"
            Me.RestaurarEmail.Size = New System.Drawing.Size(207, 22)
            Me.RestaurarEmail.Text = "Restaurar Email"
            '
            'ToolStripMenuItem3
            '
            Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
            Me.ToolStripMenuItem3.Size = New System.Drawing.Size(204, 6)
            '
            'ReindexarEmail
            '
            Me.ReindexarEmail.Image = Global.TDC.MailEnable.IpBan.My.Resources.Resources.ReindexEmail
            Me.ReindexarEmail.Name = "ReindexarEmail"
            Me.ReindexarEmail.Size = New System.Drawing.Size(207, 22)
            Me.ReindexarEmail.Text = "Reindexar Email"
            '
            'ReindexarCarpeta
            '
            Me.ReindexarCarpeta.Image = Global.TDC.MailEnable.IpBan.My.Resources.Resources.ReindexCarpeta
            Me.ReindexarCarpeta.Name = "ReindexarCarpeta"
            Me.ReindexarCarpeta.Size = New System.Drawing.Size(207, 22)
            Me.ReindexarCarpeta.Text = "Indexar Carpeta"
            '
            'ToolStripMenuItem1
            '
            Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
            Me.ToolStripMenuItem1.Size = New System.Drawing.Size(204, 6)
            '
            'VisualizarEnNotepadToolStripMenuItem
            '
            Me.VisualizarEnNotepadToolStripMenuItem.Image = CType(resources.GetObject("VisualizarEnNotepadToolStripMenuItem.Image"), System.Drawing.Image)
            Me.VisualizarEnNotepadToolStripMenuItem.Name = "VisualizarEnNotepadToolStripMenuItem"
            Me.VisualizarEnNotepadToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
            Me.VisualizarEnNotepadToolStripMenuItem.Text = "Visualizar en Notepad ++"
            '
            'ToolStripMenuItem2
            '
            Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
            Me.ToolStripMenuItem2.Size = New System.Drawing.Size(204, 6)
            '
            'ReindexarTodoToolStripMenuItem
            '
            Me.ReindexarTodoToolStripMenuItem.Image = CType(resources.GetObject("ReindexarTodoToolStripMenuItem.Image"), System.Drawing.Image)
            Me.ReindexarTodoToolStripMenuItem.Name = "ReindexarTodoToolStripMenuItem"
            Me.ReindexarTodoToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
            Me.ReindexarTodoToolStripMenuItem.Text = "Reindexar Todo"
            '
            'IndexarNuevosToolStripMenuItem
            '
            Me.IndexarNuevosToolStripMenuItem.Image = CType(resources.GetObject("IndexarNuevosToolStripMenuItem.Image"), System.Drawing.Image)
            Me.IndexarNuevosToolStripMenuItem.Name = "IndexarNuevosToolStripMenuItem"
            Me.IndexarNuevosToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
            Me.IndexarNuevosToolStripMenuItem.Text = "Indexar Nuevos"
            '
            'BtnRecargarTreeNodePostOffices
            '
            Me.BtnRecargarTreeNodePostOffices.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.BtnRecargarTreeNodePostOffices.Location = New System.Drawing.Point(0, 388)
            Me.BtnRecargarTreeNodePostOffices.Name = "BtnRecargarTreeNodePostOffices"
            Me.BtnRecargarTreeNodePostOffices.Size = New System.Drawing.Size(478, 33)
            Me.BtnRecargarTreeNodePostOffices.TabIndex = 1
            Me.BtnRecargarTreeNodePostOffices.Text = "Recargar PostOffices"
            Me.BtnRecargarTreeNodePostOffices.UseVisualStyleBackColor = True
            '
            'TablaMailBackup
            '
            Me.TablaMailBackup.AllowUserToAddRows = False
            Me.TablaMailBackup.AllowUserToDeleteRows = False
            Me.TablaMailBackup.AllowUserToResizeRows = False
            Me.TablaMailBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.TablaMailBackup.ContextMenuStrip = Me.MenuTablaBackup
            Me.TablaMailBackup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TablaMailBackup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
            Me.TablaMailBackup.Enabled = False
            Me.TablaMailBackup.Location = New System.Drawing.Point(0, 48)
            Me.TablaMailBackup.Name = "TablaMailBackup"
            Me.TablaMailBackup.ReadOnly = True
            Me.TablaMailBackup.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
            Me.TablaMailBackup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.TablaMailBackup.ShowEditingIcon = False
            Me.TablaMailBackup.Size = New System.Drawing.Size(958, 349)
            Me.TablaMailBackup.TabIndex = 0
            '
            'Panel3
            '
            Me.Panel3.Controls.Add(Me.TableLayoutPanel2)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel3.Location = New System.Drawing.Point(0, 0)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 0, 3, 3)
            Me.Panel3.Size = New System.Drawing.Size(958, 48)
            Me.Panel3.TabIndex = 2
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 4
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
            Me.TableLayoutPanel2.Controls.Add(Me.txtFAsunto, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.txtFRemitente, 1, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.txtFDestinatarios, 2, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.Label5, 1, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.Label7, 2, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.BtnLimpiarFiltro, 3, 0)
            Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 2
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(955, 45)
            Me.TableLayoutPanel2.TabIndex = 2
            '
            'txtFAsunto
            '
            Me.txtFAsunto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtFAsunto.Location = New System.Drawing.Point(3, 25)
            Me.txtFAsunto.Name = "txtFAsunto"
            Me.txtFAsunto.Size = New System.Drawing.Size(499, 20)
            Me.txtFAsunto.TabIndex = 1
            '
            'txtFRemitente
            '
            Me.txtFRemitente.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtFRemitente.Location = New System.Drawing.Point(508, 25)
            Me.txtFRemitente.Name = "txtFRemitente"
            Me.txtFRemitente.Size = New System.Drawing.Size(194, 20)
            Me.txtFRemitente.TabIndex = 1
            '
            'txtFDestinatarios
            '
            Me.txtFDestinatarios.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtFDestinatarios.Location = New System.Drawing.Point(708, 25)
            Me.txtFDestinatarios.Name = "txtFDestinatarios"
            Me.txtFDestinatarios.Size = New System.Drawing.Size(194, 20)
            Me.txtFDestinatarios.TabIndex = 1
            '
            'Label4
            '
            Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(3, 4)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(43, 13)
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "Asunto:"
            '
            'Label5
            '
            Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(508, 4)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(58, 13)
            Me.Label5.TabIndex = 3
            Me.Label5.Text = "Remitente:"
            '
            'Label7
            '
            Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(708, 4)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(71, 13)
            Me.Label7.TabIndex = 4
            Me.Label7.Text = "Destinatarios:"
            '
            'BtnLimpiarFiltro
            '
            Me.BtnLimpiarFiltro.Dock = System.Windows.Forms.DockStyle.Fill
            Me.BtnLimpiarFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.BtnLimpiarFiltro.Location = New System.Drawing.Point(905, 0)
            Me.BtnLimpiarFiltro.Margin = New System.Windows.Forms.Padding(0)
            Me.BtnLimpiarFiltro.Name = "BtnLimpiarFiltro"
            Me.TableLayoutPanel2.SetRowSpan(Me.BtnLimpiarFiltro, 2)
            Me.BtnLimpiarFiltro.Size = New System.Drawing.Size(50, 45)
            Me.BtnLimpiarFiltro.TabIndex = 5
            Me.BtnLimpiarFiltro.Text = "X"
            Me.BtnLimpiarFiltro.UseVisualStyleBackColor = True
            '
            'StatusStrip1
            '
            Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelCorreosEliminados, Me.ProgresoIndexacion, Me.LabelErroresDataTable})
            Me.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
            Me.StatusStrip1.Location = New System.Drawing.Point(0, 397)
            Me.StatusStrip1.Name = "StatusStrip1"
            Me.StatusStrip1.Size = New System.Drawing.Size(958, 24)
            Me.StatusStrip1.SizingGrip = False
            Me.StatusStrip1.TabIndex = 1
            Me.StatusStrip1.Text = "StatusStrip1"
            '
            'LabelCorreosEliminados
            '
            Me.LabelCorreosEliminados.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
            Me.LabelCorreosEliminados.Name = "LabelCorreosEliminados"
            Me.LabelCorreosEliminados.Size = New System.Drawing.Size(17, 19)
            Me.LabelCorreosEliminados.Text = "0"
            '
            'ProgresoIndexacion
            '
            Me.ProgresoIndexacion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.ProgresoIndexacion.Name = "ProgresoIndexacion"
            Me.ProgresoIndexacion.Size = New System.Drawing.Size(100, 18)
            '
            'LabelErroresDataTable
            '
            Me.LabelErroresDataTable.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
            Me.LabelErroresDataTable.Name = "LabelErroresDataTable"
            Me.LabelErroresDataTable.Size = New System.Drawing.Size(20, 19)
            Me.LabelErroresDataTable.Text = "..."
            '
            'IconosTab
            '
            Me.IconosTab.ImageStream = CType(resources.GetObject("IconosTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.IconosTab.TransparentColor = System.Drawing.Color.Transparent
            Me.IconosTab.Images.SetKeyName(0, "SA")
            Me.IconosTab.Images.SetKeyName(1, "ME")
            Me.IconosTab.Images.SetKeyName(2, "play")
            Me.IconosTab.Images.SetKeyName(3, "stop")
            Me.IconosTab.Images.SetKeyName(4, "MB")
            '
            'MenuPrincipal
            '
            Me.MenuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónToolStripMenuItem})
            Me.MenuPrincipal.Location = New System.Drawing.Point(0, 0)
            Me.MenuPrincipal.Name = "MenuPrincipal"
            Me.MenuPrincipal.Size = New System.Drawing.Size(1468, 24)
            Me.MenuPrincipal.TabIndex = 2
            Me.MenuPrincipal.Text = "Menu"
            '
            'ConfiguraciónToolStripMenuItem
            '
            Me.ConfiguraciónToolStripMenuItem.Name = "ConfiguraciónToolStripMenuItem"
            Me.ConfiguraciónToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
            Me.ConfiguraciónToolStripMenuItem.Text = "Configuración"
            '
            'TimerIpBan
            '
            Me.TimerIpBan.Enabled = True
            Me.TimerIpBan.Interval = 1000
            '
            'TimerGuiAnalizador
            '
            Me.TimerGuiAnalizador.Enabled = True
            Me.TimerGuiAnalizador.Interval = 1
            '
            'StatusStrip2
            '
            Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPrueba, Me.ToolStripStatusLabel1})
            Me.StatusStrip2.Location = New System.Drawing.Point(0, 508)
            Me.StatusStrip2.Name = "StatusStrip2"
            Me.StatusStrip2.Size = New System.Drawing.Size(1468, 22)
            Me.StatusStrip2.TabIndex = 1
            Me.StatusStrip2.Text = "StatusStrip2"
            '
            'lblPrueba
            '
            Me.lblPrueba.Name = "lblPrueba"
            Me.lblPrueba.Size = New System.Drawing.Size(13, 17)
            Me.lblPrueba.Text = "0"
            '
            'ToolStripStatusLabel1
            '
            Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
            Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 17)
            Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
            '
            'iMenuTabla
            '
            Me.iMenuTabla.ImageStream = CType(resources.GetObject("iMenuTabla.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.iMenuTabla.TransparentColor = System.Drawing.Color.Transparent
            Me.iMenuTabla.Images.SetKeyName(0, "ReindexarNuevos.png")
            Me.iMenuTabla.Images.SetKeyName(1, "ReindexarTodo.png")
            Me.iMenuTabla.Images.SetKeyName(2, "RestaurarEmail.png")
            Me.iMenuTabla.Images.SetKeyName(3, "ReindexEmail.png")
            Me.iMenuTabla.Images.SetKeyName(4, "ReindexCarpeta.png")
            '
            'ImageList1
            '
            Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
            Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
            Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
            '
            'lblLineasGeneral
            '
            Me.lblLineasGeneral.AutoSize = True
            Me.lblLineasGeneral.Dock = System.Windows.Forms.DockStyle.Left
            Me.lblLineasGeneral.Location = New System.Drawing.Point(200, 0)
            Me.lblLineasGeneral.Name = "lblLineasGeneral"
            Me.lblLineasGeneral.Size = New System.Drawing.Size(56, 13)
            Me.lblLineasGeneral.TabIndex = 2
            Me.lblLineasGeneral.Text = "Lineas: (0)"
            '
            'Panel4
            '
            Me.Panel4.Controls.Add(Me.lblLineasGeneral)
            Me.Panel4.Controls.Add(Me.lblGeneralLog)
            Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel4.Location = New System.Drawing.Point(0, 0)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(1088, 18)
            Me.Panel4.TabIndex = 3
            '
            'Panel5
            '
            Me.Panel5.Controls.Add(Me.lblLineasCrossDomain)
            Me.Panel5.Controls.Add(Me.lblCrossDomainLog)
            Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel5.Location = New System.Drawing.Point(0, 0)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(1088, 51)
            Me.Panel5.TabIndex = 3
            '
            'lblLineasCrossDomain
            '
            Me.lblLineasCrossDomain.AutoSize = True
            Me.lblLineasCrossDomain.Dock = System.Windows.Forms.DockStyle.Left
            Me.lblLineasCrossDomain.Location = New System.Drawing.Point(200, 0)
            Me.lblLineasCrossDomain.Name = "lblLineasCrossDomain"
            Me.lblLineasCrossDomain.Size = New System.Drawing.Size(56, 13)
            Me.lblLineasCrossDomain.TabIndex = 3
            Me.lblLineasCrossDomain.Text = "Lineas: (0)"
            '
            'IpBan
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1468, 530)
            Me.Controls.Add(Me.Fondo)
            Me.Controls.Add(Me.MenuPrincipal)
            Me.Controls.Add(Me.StatusStrip2)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MainMenuStrip = Me.MenuSpamAssassin
            Me.Name = "IpBan"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "IpBan"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.PanelIpBaneadas.ResumeLayout(False)
            Me.PanelBuscadores.ResumeLayout(False)
            Me.PanelLogs.ResumeLayout(False)
            Me.SplitLog.Panel1.ResumeLayout(False)
            Me.SplitLog.Panel2.ResumeLayout(False)
            CType(Me.SplitLog, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitLog.ResumeLayout(False)
            Me.PanelIps.ResumeLayout(False)
            Me.PanelListaNegra.ResumeLayout(False)
            Me.PanelBotonesListaNegra.ResumeLayout(False)
            Me.PanelBotonesListaNegra.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.PanelBusqueda.ResumeLayout(False)
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            Me.PanelTexto.ResumeLayout(False)
            Me.PanelTexto.PerformLayout()
            Me.Panel15.ResumeLayout(False)
            Me.PanelBotonesBlanca.ResumeLayout(False)
            Me.Fondo.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPIpBan.ResumeLayout(False)
            Me.TabSpamAssassin.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.MenuSpamAssassin.ResumeLayout(False)
            Me.MenuSpamAssassin.PerformLayout()
            Me.TabMailBackup.ResumeLayout(False)
            Me.SplitContainer2.Panel1.ResumeLayout(False)
            Me.SplitContainer2.Panel2.ResumeLayout(False)
            Me.SplitContainer2.Panel2.PerformLayout()
            CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer2.ResumeLayout(False)
            Me.MenuTablaBackup.ResumeLayout(False)
            CType(Me.TablaMailBackup, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.StatusStrip1.ResumeLayout(False)
            Me.StatusStrip1.PerformLayout()
            Me.MenuPrincipal.ResumeLayout(False)
            Me.MenuPrincipal.PerformLayout()
            Me.StatusStrip2.ResumeLayout(False)
            Me.StatusStrip2.PerformLayout()
            CType(Me.FiltrosMailBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.Panel5.ResumeLayout(False)
            Me.Panel5.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Fondo As Panel
        Friend WithEvents PanelIpBaneadas As Panel
        Friend WithEvents lstIpBaneadas As ListBox
        Friend WithEvents BtnAñadirIp As Button
        Friend WithEvents BtnEliminarIp As Button
        Friend WithEvents PanelBuscadores As Panel
        Friend WithEvents PanelIps As Panel
        Friend WithEvents UcPOPEx As UcAnalizador
        Friend WithEvents UcSMTPEx As UcAnalizador
        Friend WithEvents lblIpsCount As Label
        Friend WithEvents UcIMAPEx As UcAnalizador
        Friend WithEvents UcWEB As UcAnalizador
        Friend WithEvents txtBuscarIp As TextBox
        Friend WithEvents PanelTexto As Panel
        Friend WithEvents lstBusqueda As ListBox
        Friend WithEvents Panel15 As Panel
        Friend WithEvents lstIpBlancas As ListBox
        Friend WithEvents PanelListaNegra As Panel
        Friend WithEvents PanelBotonesListaNegra As Panel
        Friend WithEvents PanelBusqueda As Panel
        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents BtnAñadirBlanca As Button
        Friend WithEvents BtnEliminarBlanca As Button
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents MenuPrincipal As MenuStrip
        Friend WithEvents ConfiguraciónToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents BtnPropagarIps As Button
        Friend WithEvents BtnAnadirBlanca As Button
        Friend WithEvents PanelBotonesBlanca As Panel
        Friend WithEvents ChkDetenerPublicacion As CheckBox
        Friend WithEvents Label6 As Label
        Friend WithEvents TabControl1 As TabControl
        Friend WithEvents TabPIpBan As TabPage
        Friend WithEvents TabSpamAssassin As TabPage
        Friend WithEvents IconosTab As ImageList
        Friend WithEvents txtRichSpamAssassin As RichTextBox
        Friend WithEvents TimerIpBan As Timer
        Friend WithEvents lblEstadoSpamAssasin As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents MenuSpamAssassin As MenuStrip
        Friend WithEvents TSMDetener As ToolStripMenuItem
        Friend WithEvents TSMIniciarSpamAssassin As ToolStripMenuItem
        Friend WithEvents TSMIniciarSmapAssassinNormal As ToolStripMenuItem
        Friend WithEvents TSMIniciarSmapAssassinOculto As ToolStripMenuItem
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents TimerGuiAnalizador As Timer
        Friend WithEvents TabMailBackup As TabPage
        Friend WithEvents SplitContainer2 As SplitContainer
        Friend WithEvents TablaMailBackup As DataGridView
        Friend WithEvents TreePostOffices As TreeView
        Friend WithEvents StatusStrip1 As StatusStrip
        Friend WithEvents LabelCorreosEliminados As ToolStripStatusLabel
        Friend WithEvents LabelErroresDataTable As ToolStripStatusLabel
        Friend WithEvents FiltrosMailBox As BindingSource
        Friend WithEvents Panel3 As Panel
        Friend WithEvents txtFAsunto As TextBox
        Friend WithEvents txtFRemitente As TextBox
        Friend WithEvents txtFDestinatarios As TextBox
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents Label4 As Label
        Friend WithEvents Label5 As Label
        Friend WithEvents Label7 As Label
        Friend WithEvents BtnLimpiarFiltro As Button
        Friend WithEvents MenuTablaBackup As ContextMenuStrip
        Friend WithEvents ReindexarEmail As ToolStripMenuItem
        Friend WithEvents VisualizarEnNotepadToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
        Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
        Friend WithEvents ReindexarTodoToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents ProgresoIndexacion As ToolStripProgressBar
        Friend WithEvents IndexarNuevosToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
        Friend WithEvents RestaurarEmail As ToolStripMenuItem
        Friend WithEvents ReindexarCarpeta As ToolStripMenuItem
        Friend WithEvents StatusStrip2 As StatusStrip
        Friend WithEvents iMenuTabla As ImageList
        Friend WithEvents ImageList1 As ImageList
        Friend WithEvents BtnRecargarTreeNodePostOffices As Button
        Friend WithEvents lblPrueba As ToolStripStatusLabel
        Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
        Friend WithEvents PanelLogs As Panel
        Public WithEvents SalidaConsola As RichTextBox
        Public WithEvents SalidaCrossDomain As RichTextBox
        Friend WithEvents SplitLog As SplitContainer
        Friend WithEvents Panel1 As Panel
        Friend WithEvents Panel2 As Panel
        Friend WithEvents lblGeneralLog As Label
        Friend WithEvents lblCrossDomainLog As Label
        Friend WithEvents lblLineasGeneral As Label
        Friend WithEvents Panel4 As Panel
        Friend WithEvents Panel5 As Panel
        Friend WithEvents lblLineasCrossDomain As Label
    End Class
End Namespace
