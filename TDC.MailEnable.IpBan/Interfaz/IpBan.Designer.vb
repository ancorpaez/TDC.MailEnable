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
            Me.Panel13 = New System.Windows.Forms.Panel()
            Me.Panel12 = New System.Windows.Forms.Panel()
            Me.Panel11 = New System.Windows.Forms.Panel()
            Me.Panel10 = New System.Windows.Forms.Panel()
            Me.Panel9 = New System.Windows.Forms.Panel()
            Me.Panel8 = New System.Windows.Forms.Panel()
            Me.Panel7 = New System.Windows.Forms.Panel()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.Panel5 = New System.Windows.Forms.Panel()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.PanelPOPEx = New System.Windows.Forms.Panel()
            Me.PanelPOPAct = New System.Windows.Forms.Panel()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.Splitter1 = New System.Windows.Forms.Splitter()
            Me.PanelIps = New System.Windows.Forms.Panel()
            Me.PanelListaNegra = New System.Windows.Forms.Panel()
            Me.lstIpBaneadas = New System.Windows.Forms.ListBox()
            Me.lblIpsCount = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.PanelBotonesListaNegra = New System.Windows.Forms.Panel()
            Me.BtnAñadirIp = New System.Windows.Forms.Button()
            Me.BtnEliminarIp = New System.Windows.Forms.Button()
            Me.BtnPropagarIps = New System.Windows.Forms.Button()
            Me.ChkDetenerPublicacion = New System.Windows.Forms.CheckBox()
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
            Me.TabPage2 = New System.Windows.Forms.TabPage()
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
            Me.IconosTab = New System.Windows.Forms.ImageList(Me.components)
            Me.MenuPrincipal = New System.Windows.Forms.MenuStrip()
            Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.TimerIpBan = New System.Windows.Forms.Timer(Me.components)
            Me.UcArchivoWEB = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcWEB = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcArchivoIMAPEx = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcIMAPEx = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcArchivoIMAPAct = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcIMAPAct = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcArchivoSMTPEx = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcSMTPEx = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcArchivoSMTPAct = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcSMTPAct = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcArchivoPOPEx = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcPOPEx = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcArchivoPOPAct = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.UcPOPAct = New TDC.MailEnable.IpBan.UcAnalizador()
            Me.PanelIpBaneadas.SuspendLayout()
            Me.PanelBuscadores.SuspendLayout()
            Me.Panel13.SuspendLayout()
            Me.Panel11.SuspendLayout()
            Me.Panel9.SuspendLayout()
            Me.Panel7.SuspendLayout()
            Me.Panel5.SuspendLayout()
            Me.PanelPOPEx.SuspendLayout()
            Me.PanelPOPAct.SuspendLayout()
            Me.PanelIps.SuspendLayout()
            Me.PanelListaNegra.SuspendLayout()
            Me.PanelBotonesListaNegra.SuspendLayout()
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
            Me.TabPage2.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.MenuSpamAssassin.SuspendLayout()
            Me.MenuPrincipal.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelIpBaneadas
            '
            Me.PanelIpBaneadas.Controls.Add(Me.PanelBuscadores)
            Me.PanelIpBaneadas.Controls.Add(Me.Splitter1)
            Me.PanelIpBaneadas.Controls.Add(Me.PanelIps)
            Me.PanelIpBaneadas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelIpBaneadas.Location = New System.Drawing.Point(3, 3)
            Me.PanelIpBaneadas.Name = "PanelIpBaneadas"
            Me.PanelIpBaneadas.Padding = New System.Windows.Forms.Padding(3)
            Me.PanelIpBaneadas.Size = New System.Drawing.Size(797, 300)
            Me.PanelIpBaneadas.TabIndex = 1
            '
            'PanelBuscadores
            '
            Me.PanelBuscadores.BackColor = System.Drawing.Color.Gainsboro
            Me.PanelBuscadores.Controls.Add(Me.Panel13)
            Me.PanelBuscadores.Controls.Add(Me.Panel12)
            Me.PanelBuscadores.Controls.Add(Me.Panel11)
            Me.PanelBuscadores.Controls.Add(Me.Panel10)
            Me.PanelBuscadores.Controls.Add(Me.Panel9)
            Me.PanelBuscadores.Controls.Add(Me.Panel8)
            Me.PanelBuscadores.Controls.Add(Me.Panel7)
            Me.PanelBuscadores.Controls.Add(Me.Panel6)
            Me.PanelBuscadores.Controls.Add(Me.Panel5)
            Me.PanelBuscadores.Controls.Add(Me.Panel4)
            Me.PanelBuscadores.Controls.Add(Me.PanelPOPEx)
            Me.PanelBuscadores.Controls.Add(Me.PanelPOPAct)
            Me.PanelBuscadores.Controls.Add(Me.Panel3)
            Me.PanelBuscadores.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelBuscadores.Location = New System.Drawing.Point(347, 3)
            Me.PanelBuscadores.Name = "PanelBuscadores"
            Me.PanelBuscadores.Padding = New System.Windows.Forms.Padding(3)
            Me.PanelBuscadores.Size = New System.Drawing.Size(447, 294)
            Me.PanelBuscadores.TabIndex = 3
            '
            'Panel13
            '
            Me.Panel13.Controls.Add(Me.UcArchivoWEB)
            Me.Panel13.Controls.Add(Me.UcWEB)
            Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel13.Location = New System.Drawing.Point(3, 249)
            Me.Panel13.Name = "Panel13"
            Me.Panel13.Size = New System.Drawing.Size(441, 31)
            Me.Panel13.TabIndex = 13
            '
            'Panel12
            '
            Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel12.Location = New System.Drawing.Point(3, 239)
            Me.Panel12.Name = "Panel12"
            Me.Panel12.Size = New System.Drawing.Size(441, 10)
            Me.Panel12.TabIndex = 12
            '
            'Panel11
            '
            Me.Panel11.Controls.Add(Me.UcArchivoIMAPEx)
            Me.Panel11.Controls.Add(Me.UcIMAPEx)
            Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel11.Location = New System.Drawing.Point(3, 208)
            Me.Panel11.Name = "Panel11"
            Me.Panel11.Size = New System.Drawing.Size(441, 31)
            Me.Panel11.TabIndex = 11
            '
            'Panel10
            '
            Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel10.Location = New System.Drawing.Point(3, 198)
            Me.Panel10.Name = "Panel10"
            Me.Panel10.Size = New System.Drawing.Size(441, 10)
            Me.Panel10.TabIndex = 10
            '
            'Panel9
            '
            Me.Panel9.Controls.Add(Me.UcArchivoIMAPAct)
            Me.Panel9.Controls.Add(Me.UcIMAPAct)
            Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel9.Location = New System.Drawing.Point(3, 167)
            Me.Panel9.Name = "Panel9"
            Me.Panel9.Size = New System.Drawing.Size(441, 31)
            Me.Panel9.TabIndex = 9
            '
            'Panel8
            '
            Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel8.Location = New System.Drawing.Point(3, 157)
            Me.Panel8.Name = "Panel8"
            Me.Panel8.Size = New System.Drawing.Size(441, 10)
            Me.Panel8.TabIndex = 8
            '
            'Panel7
            '
            Me.Panel7.Controls.Add(Me.UcArchivoSMTPEx)
            Me.Panel7.Controls.Add(Me.UcSMTPEx)
            Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel7.Location = New System.Drawing.Point(3, 126)
            Me.Panel7.Name = "Panel7"
            Me.Panel7.Size = New System.Drawing.Size(441, 31)
            Me.Panel7.TabIndex = 7
            '
            'Panel6
            '
            Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel6.Location = New System.Drawing.Point(3, 116)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(441, 10)
            Me.Panel6.TabIndex = 6
            '
            'Panel5
            '
            Me.Panel5.Controls.Add(Me.UcArchivoSMTPAct)
            Me.Panel5.Controls.Add(Me.UcSMTPAct)
            Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel5.Location = New System.Drawing.Point(3, 85)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(441, 31)
            Me.Panel5.TabIndex = 5
            '
            'Panel4
            '
            Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel4.Location = New System.Drawing.Point(3, 75)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(441, 10)
            Me.Panel4.TabIndex = 4
            '
            'PanelPOPEx
            '
            Me.PanelPOPEx.Controls.Add(Me.UcArchivoPOPEx)
            Me.PanelPOPEx.Controls.Add(Me.UcPOPEx)
            Me.PanelPOPEx.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelPOPEx.Location = New System.Drawing.Point(3, 44)
            Me.PanelPOPEx.Name = "PanelPOPEx"
            Me.PanelPOPEx.Size = New System.Drawing.Size(441, 31)
            Me.PanelPOPEx.TabIndex = 3
            '
            'PanelPOPAct
            '
            Me.PanelPOPAct.Controls.Add(Me.UcArchivoPOPAct)
            Me.PanelPOPAct.Controls.Add(Me.UcPOPAct)
            Me.PanelPOPAct.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelPOPAct.Location = New System.Drawing.Point(3, 13)
            Me.PanelPOPAct.Name = "PanelPOPAct"
            Me.PanelPOPAct.Size = New System.Drawing.Size(441, 31)
            Me.PanelPOPAct.TabIndex = 1
            '
            'Panel3
            '
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel3.Location = New System.Drawing.Point(3, 3)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(441, 10)
            Me.Panel3.TabIndex = 2
            '
            'Splitter1
            '
            Me.Splitter1.Location = New System.Drawing.Point(337, 3)
            Me.Splitter1.Name = "Splitter1"
            Me.Splitter1.Size = New System.Drawing.Size(10, 294)
            Me.Splitter1.TabIndex = 2
            Me.Splitter1.TabStop = False
            '
            'PanelIps
            '
            Me.PanelIps.Controls.Add(Me.PanelListaNegra)
            Me.PanelIps.Controls.Add(Me.PanelBusqueda)
            Me.PanelIps.Controls.Add(Me.Panel15)
            Me.PanelIps.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelIps.Location = New System.Drawing.Point(3, 3)
            Me.PanelIps.Name = "PanelIps"
            Me.PanelIps.Size = New System.Drawing.Size(334, 294)
            Me.PanelIps.TabIndex = 1
            '
            'PanelListaNegra
            '
            Me.PanelListaNegra.Controls.Add(Me.lstIpBaneadas)
            Me.PanelListaNegra.Controls.Add(Me.lblIpsCount)
            Me.PanelListaNegra.Controls.Add(Me.Label1)
            Me.PanelListaNegra.Controls.Add(Me.PanelBotonesListaNegra)
            Me.PanelListaNegra.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelListaNegra.Location = New System.Drawing.Point(0, 0)
            Me.PanelListaNegra.Name = "PanelListaNegra"
            Me.PanelListaNegra.Padding = New System.Windows.Forms.Padding(3)
            Me.PanelListaNegra.Size = New System.Drawing.Size(203, 194)
            Me.PanelListaNegra.TabIndex = 6
            '
            'lstIpBaneadas
            '
            Me.lstIpBaneadas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstIpBaneadas.FormattingEnabled = True
            Me.lstIpBaneadas.IntegralHeight = False
            Me.lstIpBaneadas.Location = New System.Drawing.Point(3, 54)
            Me.lstIpBaneadas.Name = "lstIpBaneadas"
            Me.lstIpBaneadas.Size = New System.Drawing.Size(197, 75)
            Me.lstIpBaneadas.TabIndex = 2
            '
            'lblIpsCount
            '
            Me.lblIpsCount.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblIpsCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIpsCount.Location = New System.Drawing.Point(3, 23)
            Me.lblIpsCount.Name = "lblIpsCount"
            Me.lblIpsCount.Size = New System.Drawing.Size(197, 31)
            Me.lblIpsCount.TabIndex = 1
            Me.lblIpsCount.Text = "999"
            Me.lblIpsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Black
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(3, 3)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(197, 20)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Lista NEGRA"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'PanelBotonesListaNegra
            '
            Me.PanelBotonesListaNegra.BackColor = System.Drawing.Color.Black
            Me.PanelBotonesListaNegra.Controls.Add(Me.BtnAñadirIp)
            Me.PanelBotonesListaNegra.Controls.Add(Me.BtnEliminarIp)
            Me.PanelBotonesListaNegra.Controls.Add(Me.BtnPropagarIps)
            Me.PanelBotonesListaNegra.Controls.Add(Me.ChkDetenerPublicacion)
            Me.PanelBotonesListaNegra.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelBotonesListaNegra.Location = New System.Drawing.Point(3, 129)
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
            'PanelBusqueda
            '
            Me.PanelBusqueda.Controls.Add(Me.SplitContainer1)
            Me.PanelBusqueda.Controls.Add(Me.PanelTexto)
            Me.PanelBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelBusqueda.Location = New System.Drawing.Point(0, 194)
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
            Me.Panel15.Size = New System.Drawing.Size(131, 294)
            Me.Panel15.TabIndex = 5
            '
            'lstIpBlancas
            '
            Me.lstIpBlancas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstIpBlancas.FormattingEnabled = True
            Me.lstIpBlancas.IntegralHeight = False
            Me.lstIpBlancas.Location = New System.Drawing.Point(3, 23)
            Me.lstIpBlancas.Name = "lstIpBlancas"
            Me.lstIpBlancas.Size = New System.Drawing.Size(125, 226)
            Me.lstIpBlancas.TabIndex = 0
            '
            'PanelBotonesBlanca
            '
            Me.PanelBotonesBlanca.Controls.Add(Me.BtnEliminarBlanca)
            Me.PanelBotonesBlanca.Controls.Add(Me.BtnAnadirBlanca)
            Me.PanelBotonesBlanca.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelBotonesBlanca.Location = New System.Drawing.Point(3, 249)
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
            Me.Fondo.Size = New System.Drawing.Size(831, 369)
            Me.Fondo.TabIndex = 1
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPIpBan)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.ImageList = Me.IconosTab
            Me.TabControl1.Location = New System.Drawing.Point(10, 10)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(811, 349)
            Me.TabControl1.TabIndex = 3
            '
            'TabPIpBan
            '
            Me.TabPIpBan.Controls.Add(Me.PanelIpBaneadas)
            Me.TabPIpBan.ImageIndex = 1
            Me.TabPIpBan.Location = New System.Drawing.Point(4, 39)
            Me.TabPIpBan.Name = "TabPIpBan"
            Me.TabPIpBan.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPIpBan.Size = New System.Drawing.Size(803, 306)
            Me.TabPIpBan.TabIndex = 0
            Me.TabPIpBan.Text = "IpBan"
            Me.TabPIpBan.UseVisualStyleBackColor = True
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.txtRichSpamAssassin)
            Me.TabPage2.Controls.Add(Me.Panel1)
            Me.TabPage2.ImageIndex = 0
            Me.TabPage2.Location = New System.Drawing.Point(4, 39)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(803, 306)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "SpamAssassin"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'txtRichSpamAssassin
            '
            Me.txtRichSpamAssassin.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtRichSpamAssassin.Location = New System.Drawing.Point(3, 43)
            Me.txtRichSpamAssassin.Name = "txtRichSpamAssassin"
            Me.txtRichSpamAssassin.Size = New System.Drawing.Size(797, 260)
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
            Me.Panel1.Size = New System.Drawing.Size(797, 40)
            Me.Panel1.TabIndex = 1
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.lblEstadoSpamAssasin)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
            Me.Panel2.Location = New System.Drawing.Point(682, 3)
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
            Me.MenuSpamAssassin.Size = New System.Drawing.Size(128, 34)
            Me.MenuSpamAssassin.TabIndex = 2
            Me.MenuSpamAssassin.Text = "MenuStrip1"
            '
            'TSMDetener
            '
            Me.TSMDetener.Enabled = False
            Me.TSMDetener.Name = "TSMDetener"
            Me.TSMDetener.Size = New System.Drawing.Size(60, 30)
            Me.TSMDetener.Text = "Detener"
            '
            'TSMIniciarSpamAssassin
            '
            Me.TSMIniciarSpamAssassin.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMIniciarSmapAssassinNormal, Me.TSMIniciarSmapAssassinOculto})
            Me.TSMIniciarSpamAssassin.Enabled = False
            Me.TSMIniciarSpamAssassin.Name = "TSMIniciarSpamAssassin"
            Me.TSMIniciarSpamAssassin.Size = New System.Drawing.Size(51, 30)
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
            'IconosTab
            '
            Me.IconosTab.ImageStream = CType(resources.GetObject("IconosTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.IconosTab.TransparentColor = System.Drawing.Color.Transparent
            Me.IconosTab.Images.SetKeyName(0, "SA")
            Me.IconosTab.Images.SetKeyName(1, "ME")
            '
            'MenuPrincipal
            '
            Me.MenuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónToolStripMenuItem})
            Me.MenuPrincipal.Location = New System.Drawing.Point(0, 0)
            Me.MenuPrincipal.Name = "MenuPrincipal"
            Me.MenuPrincipal.Size = New System.Drawing.Size(831, 24)
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
            'UcArchivoWEB
            '
            Me.UcArchivoWEB.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.UcArchivoWEB.Location = New System.Drawing.Point(0, 19)
            Me.UcArchivoWEB.Name = "UcArchivoWEB"
            Me.UcArchivoWEB.Size = New System.Drawing.Size(441, 12)
            Me.UcArchivoWEB.TabIndex = 1
            '
            'UcWEB
            '
            Me.UcWEB.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcWEB.Location = New System.Drawing.Point(0, 0)
            Me.UcWEB.Name = "UcWEB"
            Me.UcWEB.Size = New System.Drawing.Size(441, 20)
            Me.UcWEB.TabIndex = 0
            '
            'UcArchivoIMAPEx
            '
            Me.UcArchivoIMAPEx.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.UcArchivoIMAPEx.Location = New System.Drawing.Point(0, 19)
            Me.UcArchivoIMAPEx.Name = "UcArchivoIMAPEx"
            Me.UcArchivoIMAPEx.Size = New System.Drawing.Size(441, 12)
            Me.UcArchivoIMAPEx.TabIndex = 1
            '
            'UcIMAPEx
            '
            Me.UcIMAPEx.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcIMAPEx.Location = New System.Drawing.Point(0, 0)
            Me.UcIMAPEx.Name = "UcIMAPEx"
            Me.UcIMAPEx.Size = New System.Drawing.Size(441, 20)
            Me.UcIMAPEx.TabIndex = 0
            '
            'UcArchivoIMAPAct
            '
            Me.UcArchivoIMAPAct.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.UcArchivoIMAPAct.Location = New System.Drawing.Point(0, 19)
            Me.UcArchivoIMAPAct.Name = "UcArchivoIMAPAct"
            Me.UcArchivoIMAPAct.Size = New System.Drawing.Size(441, 12)
            Me.UcArchivoIMAPAct.TabIndex = 1
            '
            'UcIMAPAct
            '
            Me.UcIMAPAct.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcIMAPAct.Location = New System.Drawing.Point(0, 0)
            Me.UcIMAPAct.Name = "UcIMAPAct"
            Me.UcIMAPAct.Size = New System.Drawing.Size(441, 20)
            Me.UcIMAPAct.TabIndex = 0
            '
            'UcArchivoSMTPEx
            '
            Me.UcArchivoSMTPEx.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.UcArchivoSMTPEx.Location = New System.Drawing.Point(0, 19)
            Me.UcArchivoSMTPEx.Name = "UcArchivoSMTPEx"
            Me.UcArchivoSMTPEx.Size = New System.Drawing.Size(441, 12)
            Me.UcArchivoSMTPEx.TabIndex = 1
            '
            'UcSMTPEx
            '
            Me.UcSMTPEx.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcSMTPEx.Location = New System.Drawing.Point(0, 0)
            Me.UcSMTPEx.Name = "UcSMTPEx"
            Me.UcSMTPEx.Size = New System.Drawing.Size(441, 20)
            Me.UcSMTPEx.TabIndex = 0
            '
            'UcArchivoSMTPAct
            '
            Me.UcArchivoSMTPAct.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.UcArchivoSMTPAct.Location = New System.Drawing.Point(0, 19)
            Me.UcArchivoSMTPAct.Name = "UcArchivoSMTPAct"
            Me.UcArchivoSMTPAct.Size = New System.Drawing.Size(441, 12)
            Me.UcArchivoSMTPAct.TabIndex = 1
            '
            'UcSMTPAct
            '
            Me.UcSMTPAct.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcSMTPAct.Location = New System.Drawing.Point(0, 0)
            Me.UcSMTPAct.Name = "UcSMTPAct"
            Me.UcSMTPAct.Size = New System.Drawing.Size(441, 20)
            Me.UcSMTPAct.TabIndex = 0
            '
            'UcArchivoPOPEx
            '
            Me.UcArchivoPOPEx.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.UcArchivoPOPEx.Location = New System.Drawing.Point(0, 19)
            Me.UcArchivoPOPEx.Name = "UcArchivoPOPEx"
            Me.UcArchivoPOPEx.Size = New System.Drawing.Size(441, 12)
            Me.UcArchivoPOPEx.TabIndex = 1
            '
            'UcPOPEx
            '
            Me.UcPOPEx.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcPOPEx.Location = New System.Drawing.Point(0, 0)
            Me.UcPOPEx.Name = "UcPOPEx"
            Me.UcPOPEx.Size = New System.Drawing.Size(441, 20)
            Me.UcPOPEx.TabIndex = 0
            '
            'UcArchivoPOPAct
            '
            Me.UcArchivoPOPAct.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.UcArchivoPOPAct.Location = New System.Drawing.Point(0, 19)
            Me.UcArchivoPOPAct.Name = "UcArchivoPOPAct"
            Me.UcArchivoPOPAct.Size = New System.Drawing.Size(441, 12)
            Me.UcArchivoPOPAct.TabIndex = 1
            '
            'UcPOPAct
            '
            Me.UcPOPAct.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcPOPAct.Location = New System.Drawing.Point(0, 0)
            Me.UcPOPAct.Name = "UcPOPAct"
            Me.UcPOPAct.Size = New System.Drawing.Size(441, 20)
            Me.UcPOPAct.TabIndex = 0
            '
            'IpBan
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(831, 393)
            Me.Controls.Add(Me.Fondo)
            Me.Controls.Add(Me.MenuPrincipal)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MainMenuStrip = Me.MenuSpamAssassin
            Me.Name = "IpBan"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "IpBan"
            Me.PanelIpBaneadas.ResumeLayout(False)
            Me.PanelBuscadores.ResumeLayout(False)
            Me.Panel13.ResumeLayout(False)
            Me.Panel11.ResumeLayout(False)
            Me.Panel9.ResumeLayout(False)
            Me.Panel7.ResumeLayout(False)
            Me.Panel5.ResumeLayout(False)
            Me.PanelPOPEx.ResumeLayout(False)
            Me.PanelPOPAct.ResumeLayout(False)
            Me.PanelIps.ResumeLayout(False)
            Me.PanelListaNegra.ResumeLayout(False)
            Me.PanelBotonesListaNegra.ResumeLayout(False)
            Me.PanelBotonesListaNegra.PerformLayout()
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
            Me.TabPage2.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.MenuSpamAssassin.ResumeLayout(False)
            Me.MenuSpamAssassin.PerformLayout()
            Me.MenuPrincipal.ResumeLayout(False)
            Me.MenuPrincipal.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Fondo As Panel
        Friend WithEvents PanelIpBaneadas As Panel
        Friend WithEvents lstIpBaneadas As ListBox
        Friend WithEvents BtnAñadirIp As Button
        Friend WithEvents BtnEliminarIp As Button
        Friend WithEvents PanelBuscadores As Panel
        Friend WithEvents Splitter1 As Splitter
        Friend WithEvents PanelIps As Panel
        Friend WithEvents UcPOPEx As UcAnalizador
        Friend WithEvents UcSMTPAct As UcAnalizador
        Friend WithEvents UcSMTPEx As UcAnalizador
        Friend WithEvents UcPOPAct As UcAnalizador
        Friend WithEvents PanelPOPAct As Panel
        Friend WithEvents UcArchivoPOPAct As UcAnalizador
        Friend WithEvents PanelPOPEx As Panel
        Friend WithEvents Panel3 As Panel
        Friend WithEvents UcArchivoPOPEx As UcAnalizador
        Friend WithEvents Panel5 As Panel
        Friend WithEvents UcArchivoSMTPAct As UcAnalizador
        Friend WithEvents Panel4 As Panel
        Friend WithEvents Panel7 As Panel
        Friend WithEvents UcArchivoSMTPEx As UcAnalizador
        Friend WithEvents Panel6 As Panel
        Friend WithEvents lblIpsCount As Label
        Friend WithEvents Panel9 As Panel
        Friend WithEvents UcArchivoIMAPAct As UcAnalizador
        Friend WithEvents UcIMAPAct As UcAnalizador
        Friend WithEvents Panel8 As Panel
        Friend WithEvents Panel11 As Panel
        Friend WithEvents UcArchivoIMAPEx As UcAnalizador
        Friend WithEvents UcIMAPEx As UcAnalizador
        Friend WithEvents Panel10 As Panel
        Friend WithEvents Panel13 As Panel
        Friend WithEvents UcArchivoWEB As UcAnalizador
        Friend WithEvents UcWEB As UcAnalizador
        Friend WithEvents Panel12 As Panel
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
        Friend WithEvents TabPage2 As TabPage
        Friend WithEvents IconosTab As ImageList
        Friend WithEvents txtRichSpamAssassin As RichTextBox
        Friend WithEvents Panel1 As Panel
        Friend WithEvents TimerIpBan As Timer
        Friend WithEvents Panel2 As Panel
        Friend WithEvents lblEstadoSpamAssasin As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents MenuSpamAssassin As MenuStrip
        Friend WithEvents TSMDetener As ToolStripMenuItem
        Friend WithEvents TSMIniciarSpamAssassin As ToolStripMenuItem
        Friend WithEvents TSMIniciarSmapAssassinNormal As ToolStripMenuItem
        Friend WithEvents TSMIniciarSmapAssassinOculto As ToolStripMenuItem
    End Class
End Namespace
