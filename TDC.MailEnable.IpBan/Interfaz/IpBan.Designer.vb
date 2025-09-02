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
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.lblLineasGeneral = New System.Windows.Forms.Label()
            Me.lblGeneralLog = New System.Windows.Forms.Label()
            Me.SalidaCrossDomain = New System.Windows.Forms.RichTextBox()
            Me.Panel5 = New System.Windows.Forms.Panel()
            Me.lblLineasCrossDomain = New System.Windows.Forms.Label()
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
            Me.PanelPaisIpBlanca = New System.Windows.Forms.Panel()
            Me.lblPaisIpBlancaSet = New System.Windows.Forms.Label()
            Me.lblPaisIpBlanca = New System.Windows.Forms.Label()
            Me.PanelBotonesBlanca = New System.Windows.Forms.Panel()
            Me.BtnEliminarBlanca = New System.Windows.Forms.Button()
            Me.BtnAnadirBlanca = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Fondo = New System.Windows.Forms.Panel()
            Me.TabApp = New System.Windows.Forms.TabControl()
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
            Me.RestaurarCalendario = New System.Windows.Forms.ToolStripMenuItem()
            Me.RestaurarTarea = New System.Windows.Forms.ToolStripMenuItem()
            Me.RestaurarContacto = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
            Me.ReindexarEmail = New System.Windows.Forms.ToolStripMenuItem()
            Me.ReindexarCarpeta = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
            Me.VisualizarEnNotepadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.VisualizarEnOutlookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
            Me.ReindexarTodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.IndexarNuevosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
            Me.ExportarAUnArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.BtnRecargarTreeNodePostOffices = New System.Windows.Forms.Button()
            Me.PanelAutoIndex = New System.Windows.Forms.Panel()
            Me.lstAutoIndex = New System.Windows.Forms.ListView()
            Me.cAutoIndexTimeInit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.tlpAutoIndexacion = New System.Windows.Forms.TableLayoutPanel()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.lblAutoindexaciones = New System.Windows.Forms.Label()
            Me.lblPostOffices = New System.Windows.Forms.Label()
            Me.TabBackup = New System.Windows.Forms.TabControl()
            Me.TabPMAI = New System.Windows.Forms.TabPage()
            Me.TablaMailBackupMAI = New System.Windows.Forms.DataGridView()
            Me.PanelFiltroMAIBackup = New System.Windows.Forms.Panel()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtMaiAsunto = New System.Windows.Forms.TextBox()
            Me.txtMaiRemitente = New System.Windows.Forms.TextBox()
            Me.txtMaiDestinatarios = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.BtnLimpiarMai = New System.Windows.Forms.Button()
            Me.TabPCAL = New System.Windows.Forms.TabPage()
            Me.TablaMailBackupCAL = New System.Windows.Forms.DataGridView()
            Me.PanelFiltroCALBackup = New System.Windows.Forms.Panel()
            Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.txtCalDescripcion = New System.Windows.Forms.TextBox()
            Me.txtCalHubicacion = New System.Windows.Forms.TextBox()
            Me.BtnLimpiarCal = New System.Windows.Forms.Button()
            Me.TabPTSK = New System.Windows.Forms.TabPage()
            Me.TablaMailBackupTSK = New System.Windows.Forms.DataGridView()
            Me.PanelFiltroTSK = New System.Windows.Forms.Panel()
            Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.txtTskAsunto = New System.Windows.Forms.TextBox()
            Me.txtTskNotas = New System.Windows.Forms.TextBox()
            Me.BtnLimpiarTSK = New System.Windows.Forms.Button()
            Me.TabPVCF = New System.Windows.Forms.TabPage()
            Me.TablaMailBackupVCF = New System.Windows.Forms.DataGridView()
            Me.PanelFiltroVCFBackup = New System.Windows.Forms.Panel()
            Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.txtVcfNombre = New System.Windows.Forms.TextBox()
            Me.txtVcfCompleto = New System.Windows.Forms.TextBox()
            Me.txtVcfEmail = New System.Windows.Forms.TextBox()
            Me.txtVcfPersonal = New System.Windows.Forms.TextBox()
            Me.txtVcfTrabajo = New System.Windows.Forms.TextBox()
            Me.txtVcfNick = New System.Windows.Forms.TextBox()
            Me.BtnLimpiarVCF = New System.Windows.Forms.Button()
            Me.ImgLBackupTab = New System.Windows.Forms.ImageList(Me.components)
            Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
            Me.lblMailBackupSeleccionados = New System.Windows.Forms.ToolStripStatusLabel()
            Me.ProgresoIndexacion = New System.Windows.Forms.ToolStripProgressBar()
            Me.lblMensajesBackup = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblLimpiadosBackup = New System.Windows.Forms.ToolStripStatusLabel()
            Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblEmails = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblCarpetas = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblAnalizadoresBackup = New System.Windows.Forms.ToolStripStatusLabel()
            Me.TabMigraciones = New System.Windows.Forms.TabPage()
            Me.SplitMigracion = New System.Windows.Forms.SplitContainer()
            Me.lstDominiosMigracion = New System.Windows.Forms.ListView()
            Me.lstDM_Dominio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.lstDM_Estado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.PanelOpcionesDominio = New System.Windows.Forms.Panel()
            Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
            Me.BtnCrearDominioMigracion = New System.Windows.Forms.ToolStripButton()
            Me.BtnEliminarDominioMigracion = New System.Windows.Forms.ToolStripButton()
            Me.BtnActivarMigracionDominio = New System.Windows.Forms.ToolStripButton()
            Me.BtnDesactivarMigracionDominio = New System.Windows.Forms.ToolStripButton()
            Me.SplitProcesoMigracion = New System.Windows.Forms.SplitContainer()
            Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
            Me.PanelColaMigracion = New System.Windows.Forms.Panel()
            Me.lstListaDeEsperaMigracion = New System.Windows.Forms.ListView()
            Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.Label9 = New System.Windows.Forms.Label()
            Me.PanelProgresoMigracion = New System.Windows.Forms.Panel()
            Me.lstMailBoxMigracion = New System.Windows.Forms.ListView()
            Me.lstMM_MailBox = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.lstMM_Trabajado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lstErroneosMigracion = New System.Windows.Forms.ListView()
            Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.Label10 = New System.Windows.Forms.Label()
            Me.PanelOpcionesMigracion = New System.Windows.Forms.Panel()
            Me.ToolMigraciones = New System.Windows.Forms.ToolStrip()
            Me.BtnMigrarCuenta = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.BtnLimpiarMigracionesCompletadas = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.BtnLimpiarErroneosMigracion = New System.Windows.Forms.ToolStripButton()
            Me.BtnCopiarErroneos = New System.Windows.Forms.ToolStripButton()
            Me.PanelServicioMigracion = New System.Windows.Forms.Panel()
            Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.BtnServicioMigracion = New System.Windows.Forms.Button()
            Me.lblEstadoServicioMigracion = New System.Windows.Forms.Label()
            Me.TabCertificados = New System.Windows.Forms.TabPage()
            Me.SplitCertificados = New System.Windows.Forms.SplitContainer()
            Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
            Me.lstCertificados = New System.Windows.Forms.ListView()
            Me.cCertificado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.cCaducaCertificado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.Label12 = New System.Windows.Forms.Label()
            Me.lstLogDescargaCertificado = New System.Windows.Forms.ListView()
            Me.cLogCertificado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.cLogCIntento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.cLogcResultado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.Label13 = New System.Windows.Forms.Label()
            Me.TabNavegadores = New System.Windows.Forms.TabControl()
            Me.TabAutoResponder = New System.Windows.Forms.TabPage()
            Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
            Me.RichAutoResponderMail = New System.Windows.Forms.RichTextBox()
            Me.Label25 = New System.Windows.Forms.Label()
            Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
            Me.RichAutoResponderStatus = New System.Windows.Forms.RichTextBox()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.RichAutoResponderRespuesta = New System.Windows.Forms.RichTextBox()
            Me.Label27 = New System.Windows.Forms.Label()
            Me.SplitterAutoResponderLst = New System.Windows.Forms.Splitter()
            Me.PanellstEmailsColaSMTP = New System.Windows.Forms.Panel()
            Me.lstEmailsReparadosAutoResponder = New System.Windows.Forms.ListBox()
            Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
            Me.BtnEliminarAutoResponder = New System.Windows.Forms.ToolStripButton()
            Me.lblEmailSeleccionadoAutoResponder = New System.Windows.Forms.ToolStripLabel()
            Me.BtnLimpiarMemoriaAutoResponder = New System.Windows.Forms.ToolStripButton()
            Me.Label28 = New System.Windows.Forms.Label()
            Me.IconosTab = New System.Windows.Forms.ImageList(Me.components)
            Me.MenuPrincipal = New System.Windows.Forms.MenuStrip()
            Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.BuclesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.TimerToInterfaceIpBan = New System.Windows.Forms.Timer(Me.components)
            Me.TimerGuiAnalizador = New System.Windows.Forms.Timer(Me.components)
            Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
            Me.lblPrueba = New System.Windows.Forms.ToolStripStatusLabel()
            Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
            Me.iMenuTabla = New System.Windows.Forms.ImageList(Me.components)
            Me.FiltrosMailBox = New System.Windows.Forms.BindingSource(Me.components)
            Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
            Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
            Me.PanelIpBaneadas.SuspendLayout()
            Me.PanelBuscadores.SuspendLayout()
            Me.PanelLogs.SuspendLayout()
            CType(Me.SplitLog, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitLog.Panel1.SuspendLayout()
            Me.SplitLog.Panel2.SuspendLayout()
            Me.SplitLog.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.Panel5.SuspendLayout()
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
            Me.PanelPaisIpBlanca.SuspendLayout()
            Me.PanelBotonesBlanca.SuspendLayout()
            Me.Fondo.SuspendLayout()
            Me.TabApp.SuspendLayout()
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
            Me.PanelAutoIndex.SuspendLayout()
            Me.tlpAutoIndexacion.SuspendLayout()
            Me.TabBackup.SuspendLayout()
            Me.TabPMAI.SuspendLayout()
            CType(Me.TablaMailBackupMAI, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelFiltroMAIBackup.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.TabPCAL.SuspendLayout()
            CType(Me.TablaMailBackupCAL, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelFiltroCALBackup.SuspendLayout()
            Me.TableLayoutPanel5.SuspendLayout()
            Me.TabPTSK.SuspendLayout()
            CType(Me.TablaMailBackupTSK, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelFiltroTSK.SuspendLayout()
            Me.TableLayoutPanel6.SuspendLayout()
            Me.TabPVCF.SuspendLayout()
            CType(Me.TablaMailBackupVCF, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelFiltroVCFBackup.SuspendLayout()
            Me.TableLayoutPanel4.SuspendLayout()
            Me.StatusStrip1.SuspendLayout()
            Me.TabMigraciones.SuspendLayout()
            CType(Me.SplitMigracion, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitMigracion.Panel1.SuspendLayout()
            Me.SplitMigracion.Panel2.SuspendLayout()
            Me.SplitMigracion.SuspendLayout()
            Me.PanelOpcionesDominio.SuspendLayout()
            Me.ToolStrip1.SuspendLayout()
            CType(Me.SplitProcesoMigracion, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitProcesoMigracion.Panel1.SuspendLayout()
            Me.SplitProcesoMigracion.Panel2.SuspendLayout()
            Me.SplitProcesoMigracion.SuspendLayout()
            CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer3.Panel1.SuspendLayout()
            Me.SplitContainer3.Panel2.SuspendLayout()
            Me.SplitContainer3.SuspendLayout()
            Me.PanelColaMigracion.SuspendLayout()
            Me.PanelProgresoMigracion.SuspendLayout()
            Me.PanelOpcionesMigracion.SuspendLayout()
            Me.ToolMigraciones.SuspendLayout()
            Me.PanelServicioMigracion.SuspendLayout()
            Me.TableLayoutPanel3.SuspendLayout()
            Me.TabCertificados.SuspendLayout()
            CType(Me.SplitCertificados, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitCertificados.Panel1.SuspendLayout()
            Me.SplitCertificados.Panel2.SuspendLayout()
            Me.SplitCertificados.SuspendLayout()
            CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer4.Panel1.SuspendLayout()
            Me.SplitContainer4.Panel2.SuspendLayout()
            Me.SplitContainer4.SuspendLayout()
            Me.TabAutoResponder.SuspendLayout()
            CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer5.Panel1.SuspendLayout()
            Me.SplitContainer5.Panel2.SuspendLayout()
            Me.SplitContainer5.SuspendLayout()
            CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer6.Panel1.SuspendLayout()
            Me.SplitContainer6.Panel2.SuspendLayout()
            Me.SplitContainer6.SuspendLayout()
            Me.PanellstEmailsColaSMTP.SuspendLayout()
            Me.ToolStrip2.SuspendLayout()
            Me.MenuPrincipal.SuspendLayout()
            Me.StatusStrip2.SuspendLayout()
            CType(Me.FiltrosMailBox, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.PanelIpBaneadas.Size = New System.Drawing.Size(1362, 421)
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
            Me.PanelBuscadores.Size = New System.Drawing.Size(1022, 415)
            Me.PanelBuscadores.TabIndex = 3
            '
            'PanelLogs
            '
            Me.PanelLogs.Controls.Add(Me.SplitLog)
            Me.PanelLogs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelLogs.Location = New System.Drawing.Point(3, 163)
            Me.PanelLogs.Name = "PanelLogs"
            Me.PanelLogs.Size = New System.Drawing.Size(1016, 249)
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
            Me.SplitLog.Size = New System.Drawing.Size(1016, 249)
            Me.SplitLog.SplitterDistance = 114
            Me.SplitLog.TabIndex = 3
            '
            'SalidaConsola
            '
            Me.SalidaConsola.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SalidaConsola.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.SalidaConsola.Location = New System.Drawing.Point(0, 18)
            Me.SalidaConsola.Name = "SalidaConsola"
            Me.SalidaConsola.Size = New System.Drawing.Size(1016, 96)
            Me.SalidaConsola.TabIndex = 0
            Me.SalidaConsola.Text = ""
            '
            'Panel4
            '
            Me.Panel4.Controls.Add(Me.lblLineasGeneral)
            Me.Panel4.Controls.Add(Me.lblGeneralLog)
            Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel4.Location = New System.Drawing.Point(0, 0)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(1016, 18)
            Me.Panel4.TabIndex = 3
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
            Me.SalidaCrossDomain.Size = New System.Drawing.Size(1016, 80)
            Me.SalidaCrossDomain.TabIndex = 1
            Me.SalidaCrossDomain.Text = ""
            Me.SalidaCrossDomain.WordWrap = False
            '
            'Panel5
            '
            Me.Panel5.Controls.Add(Me.lblLineasCrossDomain)
            Me.Panel5.Controls.Add(Me.lblCrossDomainLog)
            Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel5.Location = New System.Drawing.Point(0, 0)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(1016, 51)
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
            Me.UcWEB.Size = New System.Drawing.Size(1016, 40)
            Me.UcWEB.TabIndex = 0
            '
            'UcIMAPEx
            '
            Me.UcIMAPEx.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcIMAPEx.Location = New System.Drawing.Point(3, 83)
            Me.UcIMAPEx.Name = "UcIMAPEx"
            Me.UcIMAPEx.Size = New System.Drawing.Size(1016, 40)
            Me.UcIMAPEx.TabIndex = 0
            '
            'UcSMTPEx
            '
            Me.UcSMTPEx.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcSMTPEx.Location = New System.Drawing.Point(3, 43)
            Me.UcSMTPEx.Name = "UcSMTPEx"
            Me.UcSMTPEx.Size = New System.Drawing.Size(1016, 40)
            Me.UcSMTPEx.TabIndex = 0
            '
            'UcPOPEx
            '
            Me.UcPOPEx.Dock = System.Windows.Forms.DockStyle.Top
            Me.UcPOPEx.Location = New System.Drawing.Point(3, 3)
            Me.UcPOPEx.Name = "UcPOPEx"
            Me.UcPOPEx.Size = New System.Drawing.Size(1016, 40)
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
            Me.PanelIps.Size = New System.Drawing.Size(334, 415)
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
            Me.PanelListaNegra.Size = New System.Drawing.Size(203, 315)
            Me.PanelListaNegra.TabIndex = 6
            '
            'lstIpBaneadas
            '
            Me.lstIpBaneadas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstIpBaneadas.FormattingEnabled = True
            Me.lstIpBaneadas.IntegralHeight = False
            Me.lstIpBaneadas.Location = New System.Drawing.Point(3, 29)
            Me.lstIpBaneadas.Name = "lstIpBaneadas"
            Me.lstIpBaneadas.Size = New System.Drawing.Size(197, 221)
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
            Me.PanelBotonesListaNegra.Location = New System.Drawing.Point(3, 250)
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
            Me.PanelBusqueda.Location = New System.Drawing.Point(0, 315)
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
            Me.Panel15.Controls.Add(Me.PanelPaisIpBlanca)
            Me.Panel15.Controls.Add(Me.PanelBotonesBlanca)
            Me.Panel15.Controls.Add(Me.Label2)
            Me.Panel15.Dock = System.Windows.Forms.DockStyle.Right
            Me.Panel15.Location = New System.Drawing.Point(203, 0)
            Me.Panel15.Name = "Panel15"
            Me.Panel15.Padding = New System.Windows.Forms.Padding(3)
            Me.Panel15.Size = New System.Drawing.Size(131, 415)
            Me.Panel15.TabIndex = 5
            '
            'lstIpBlancas
            '
            Me.lstIpBlancas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstIpBlancas.FormattingEnabled = True
            Me.lstIpBlancas.IntegralHeight = False
            Me.lstIpBlancas.Location = New System.Drawing.Point(3, 23)
            Me.lstIpBlancas.Name = "lstIpBlancas"
            Me.lstIpBlancas.ScrollAlwaysVisible = True
            Me.lstIpBlancas.Size = New System.Drawing.Size(125, 309)
            Me.lstIpBlancas.TabIndex = 0
            '
            'PanelPaisIpBlanca
            '
            Me.PanelPaisIpBlanca.BackColor = System.Drawing.Color.Black
            Me.PanelPaisIpBlanca.Controls.Add(Me.lblPaisIpBlancaSet)
            Me.PanelPaisIpBlanca.Controls.Add(Me.lblPaisIpBlanca)
            Me.PanelPaisIpBlanca.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelPaisIpBlanca.Location = New System.Drawing.Point(3, 332)
            Me.PanelPaisIpBlanca.Name = "PanelPaisIpBlanca"
            Me.PanelPaisIpBlanca.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
            Me.PanelPaisIpBlanca.Size = New System.Drawing.Size(125, 38)
            Me.PanelPaisIpBlanca.TabIndex = 5
            '
            'lblPaisIpBlancaSet
            '
            Me.lblPaisIpBlancaSet.BackColor = System.Drawing.Color.White
            Me.lblPaisIpBlancaSet.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblPaisIpBlancaSet.Location = New System.Drawing.Point(45, 1)
            Me.lblPaisIpBlancaSet.Name = "lblPaisIpBlancaSet"
            Me.lblPaisIpBlancaSet.Size = New System.Drawing.Size(80, 37)
            Me.lblPaisIpBlancaSet.TabIndex = 1
            Me.lblPaisIpBlancaSet.Text = "..."
            Me.lblPaisIpBlancaSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblPaisIpBlanca
            '
            Me.lblPaisIpBlanca.BackColor = System.Drawing.Color.White
            Me.lblPaisIpBlanca.Dock = System.Windows.Forms.DockStyle.Left
            Me.lblPaisIpBlanca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPaisIpBlanca.Location = New System.Drawing.Point(0, 1)
            Me.lblPaisIpBlanca.Name = "lblPaisIpBlanca"
            Me.lblPaisIpBlanca.Size = New System.Drawing.Size(45, 37)
            Me.lblPaisIpBlanca.TabIndex = 0
            Me.lblPaisIpBlanca.Text = "País:"
            Me.lblPaisIpBlanca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'PanelBotonesBlanca
            '
            Me.PanelBotonesBlanca.Controls.Add(Me.BtnEliminarBlanca)
            Me.PanelBotonesBlanca.Controls.Add(Me.BtnAnadirBlanca)
            Me.PanelBotonesBlanca.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelBotonesBlanca.Location = New System.Drawing.Point(3, 370)
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
            Me.Fondo.Controls.Add(Me.TabApp)
            Me.Fondo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Fondo.Location = New System.Drawing.Point(0, 24)
            Me.Fondo.Name = "Fondo"
            Me.Fondo.Padding = New System.Windows.Forms.Padding(10)
            Me.Fondo.Size = New System.Drawing.Size(1396, 490)
            Me.Fondo.TabIndex = 1
            '
            'TabApp
            '
            Me.TabApp.Controls.Add(Me.TabPIpBan)
            Me.TabApp.Controls.Add(Me.TabSpamAssassin)
            Me.TabApp.Controls.Add(Me.TabMailBackup)
            Me.TabApp.Controls.Add(Me.TabMigraciones)
            Me.TabApp.Controls.Add(Me.TabCertificados)
            Me.TabApp.Controls.Add(Me.TabAutoResponder)
            Me.TabApp.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabApp.ImageList = Me.IconosTab
            Me.TabApp.Location = New System.Drawing.Point(10, 10)
            Me.TabApp.Name = "TabApp"
            Me.TabApp.SelectedIndex = 0
            Me.TabApp.Size = New System.Drawing.Size(1376, 470)
            Me.TabApp.TabIndex = 3
            '
            'TabPIpBan
            '
            Me.TabPIpBan.Controls.Add(Me.PanelIpBaneadas)
            Me.TabPIpBan.ImageIndex = 1
            Me.TabPIpBan.Location = New System.Drawing.Point(4, 39)
            Me.TabPIpBan.Name = "TabPIpBan"
            Me.TabPIpBan.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPIpBan.Size = New System.Drawing.Size(1368, 427)
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
            Me.TabSpamAssassin.Size = New System.Drawing.Size(1368, 427)
            Me.TabSpamAssassin.TabIndex = 1
            Me.TabSpamAssassin.Text = "SpamAssassin"
            Me.TabSpamAssassin.UseVisualStyleBackColor = True
            '
            'txtRichSpamAssassin
            '
            Me.txtRichSpamAssassin.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtRichSpamAssassin.Location = New System.Drawing.Point(3, 43)
            Me.txtRichSpamAssassin.Name = "txtRichSpamAssassin"
            Me.txtRichSpamAssassin.Size = New System.Drawing.Size(1362, 381)
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
            Me.Panel1.Size = New System.Drawing.Size(1362, 40)
            Me.Panel1.TabIndex = 1
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.lblEstadoSpamAssasin)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
            Me.Panel2.Location = New System.Drawing.Point(1247, 3)
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
            Me.TabMailBackup.Size = New System.Drawing.Size(1368, 427)
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
            Me.SplitContainer2.Panel1.Controls.Add(Me.PanelAutoIndex)
            Me.SplitContainer2.Panel1.Controls.Add(Me.lblPostOffices)
            '
            'SplitContainer2.Panel2
            '
            Me.SplitContainer2.Panel2.Controls.Add(Me.TabBackup)
            Me.SplitContainer2.Panel2.Controls.Add(Me.StatusStrip1)
            Me.SplitContainer2.Panel2.Padding = New System.Windows.Forms.Padding(5)
            Me.SplitContainer2.Size = New System.Drawing.Size(1368, 427)
            Me.SplitContainer2.SplitterDistance = 297
            Me.SplitContainer2.TabIndex = 0
            '
            'TreePostOffices
            '
            Me.TreePostOffices.ContextMenuStrip = Me.MenuTablaBackup
            Me.TreePostOffices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TreePostOffices.Location = New System.Drawing.Point(0, 20)
            Me.TreePostOffices.Name = "TreePostOffices"
            Me.TreePostOffices.Size = New System.Drawing.Size(297, 208)
            Me.TreePostOffices.TabIndex = 0
            '
            'MenuTablaBackup
            '
            Me.MenuTablaBackup.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestaurarEmail, Me.RestaurarCalendario, Me.RestaurarTarea, Me.RestaurarContacto, Me.ToolStripMenuItem3, Me.ReindexarEmail, Me.ReindexarCarpeta, Me.ToolStripMenuItem1, Me.VisualizarEnNotepadToolStripMenuItem, Me.VisualizarEnOutlookToolStripMenuItem, Me.ToolStripMenuItem2, Me.ReindexarTodoToolStripMenuItem, Me.IndexarNuevosToolStripMenuItem, Me.ToolStripMenuItem4, Me.ExportarAUnArchivoToolStripMenuItem})
            Me.MenuTablaBackup.Name = "MenuTablaBackup"
            Me.MenuTablaBackup.Size = New System.Drawing.Size(208, 270)
            '
            'RestaurarEmail
            '
            Me.RestaurarEmail.Image = CType(resources.GetObject("RestaurarEmail.Image"), System.Drawing.Image)
            Me.RestaurarEmail.Name = "RestaurarEmail"
            Me.RestaurarEmail.Size = New System.Drawing.Size(207, 22)
            Me.RestaurarEmail.Text = "Restaurar Email"
            '
            'RestaurarCalendario
            '
            Me.RestaurarCalendario.Image = CType(resources.GetObject("RestaurarCalendario.Image"), System.Drawing.Image)
            Me.RestaurarCalendario.Name = "RestaurarCalendario"
            Me.RestaurarCalendario.Size = New System.Drawing.Size(207, 22)
            Me.RestaurarCalendario.Text = "Restaurar Calendario"
            '
            'RestaurarTarea
            '
            Me.RestaurarTarea.Image = CType(resources.GetObject("RestaurarTarea.Image"), System.Drawing.Image)
            Me.RestaurarTarea.Name = "RestaurarTarea"
            Me.RestaurarTarea.Size = New System.Drawing.Size(207, 22)
            Me.RestaurarTarea.Text = "Restaurar Tarea"
            '
            'RestaurarContacto
            '
            Me.RestaurarContacto.Image = CType(resources.GetObject("RestaurarContacto.Image"), System.Drawing.Image)
            Me.RestaurarContacto.Name = "RestaurarContacto"
            Me.RestaurarContacto.Size = New System.Drawing.Size(207, 22)
            Me.RestaurarContacto.Text = "Restaurar Contacto"
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
            'VisualizarEnOutlookToolStripMenuItem
            '
            Me.VisualizarEnOutlookToolStripMenuItem.Image = CType(resources.GetObject("VisualizarEnOutlookToolStripMenuItem.Image"), System.Drawing.Image)
            Me.VisualizarEnOutlookToolStripMenuItem.Name = "VisualizarEnOutlookToolStripMenuItem"
            Me.VisualizarEnOutlookToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
            Me.VisualizarEnOutlookToolStripMenuItem.Text = "Visualizar en Outlook"
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
            'ToolStripMenuItem4
            '
            Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
            Me.ToolStripMenuItem4.Size = New System.Drawing.Size(204, 6)
            '
            'ExportarAUnArchivoToolStripMenuItem
            '
            Me.ExportarAUnArchivoToolStripMenuItem.Name = "ExportarAUnArchivoToolStripMenuItem"
            Me.ExportarAUnArchivoToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
            Me.ExportarAUnArchivoToolStripMenuItem.Text = "Exportar a un Archivo"
            '
            'BtnRecargarTreeNodePostOffices
            '
            Me.BtnRecargarTreeNodePostOffices.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.BtnRecargarTreeNodePostOffices.Location = New System.Drawing.Point(0, 228)
            Me.BtnRecargarTreeNodePostOffices.Name = "BtnRecargarTreeNodePostOffices"
            Me.BtnRecargarTreeNodePostOffices.Size = New System.Drawing.Size(297, 33)
            Me.BtnRecargarTreeNodePostOffices.TabIndex = 1
            Me.BtnRecargarTreeNodePostOffices.Text = "Recargar PostOffices"
            Me.BtnRecargarTreeNodePostOffices.UseVisualStyleBackColor = True
            Me.BtnRecargarTreeNodePostOffices.Visible = False
            '
            'PanelAutoIndex
            '
            Me.PanelAutoIndex.Controls.Add(Me.lstAutoIndex)
            Me.PanelAutoIndex.Controls.Add(Me.tlpAutoIndexacion)
            Me.PanelAutoIndex.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelAutoIndex.Location = New System.Drawing.Point(0, 261)
            Me.PanelAutoIndex.Name = "PanelAutoIndex"
            Me.PanelAutoIndex.Size = New System.Drawing.Size(297, 166)
            Me.PanelAutoIndex.TabIndex = 2
            '
            'lstAutoIndex
            '
            Me.lstAutoIndex.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cAutoIndexTimeInit})
            Me.lstAutoIndex.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstAutoIndex.HideSelection = False
            Me.lstAutoIndex.Location = New System.Drawing.Point(0, 22)
            Me.lstAutoIndex.Name = "lstAutoIndex"
            Me.lstAutoIndex.Size = New System.Drawing.Size(297, 144)
            Me.lstAutoIndex.TabIndex = 0
            Me.lstAutoIndex.UseCompatibleStateImageBehavior = False
            Me.lstAutoIndex.View = System.Windows.Forms.View.Details
            '
            'cAutoIndexTimeInit
            '
            Me.cAutoIndexTimeInit.Text = "Iniciado"
            Me.cAutoIndexTimeInit.Width = 464
            '
            'tlpAutoIndexacion
            '
            Me.tlpAutoIndexacion.ColumnCount = 2
            Me.tlpAutoIndexacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.tlpAutoIndexacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.tlpAutoIndexacion.Controls.Add(Me.Label14, 0, 0)
            Me.tlpAutoIndexacion.Controls.Add(Me.lblAutoindexaciones, 1, 0)
            Me.tlpAutoIndexacion.Dock = System.Windows.Forms.DockStyle.Top
            Me.tlpAutoIndexacion.Location = New System.Drawing.Point(0, 0)
            Me.tlpAutoIndexacion.Name = "tlpAutoIndexacion"
            Me.tlpAutoIndexacion.RowCount = 1
            Me.tlpAutoIndexacion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.tlpAutoIndexacion.Size = New System.Drawing.Size(297, 22)
            Me.tlpAutoIndexacion.TabIndex = 2
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.Black
            Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label14.ForeColor = System.Drawing.Color.White
            Me.Label14.Location = New System.Drawing.Point(0, 0)
            Me.Label14.Margin = New System.Windows.Forms.Padding(0)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(148, 22)
            Me.Label14.TabIndex = 1
            Me.Label14.Text = "Auto indexación"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblAutoindexaciones
            '
            Me.lblAutoindexaciones.BackColor = System.Drawing.Color.Black
            Me.lblAutoindexaciones.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblAutoindexaciones.ForeColor = System.Drawing.Color.White
            Me.lblAutoindexaciones.Location = New System.Drawing.Point(149, 0)
            Me.lblAutoindexaciones.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
            Me.lblAutoindexaciones.Name = "lblAutoindexaciones"
            Me.lblAutoindexaciones.Size = New System.Drawing.Size(148, 22)
            Me.lblAutoindexaciones.TabIndex = 2
            Me.lblAutoindexaciones.Text = "Idexaciones: 0"
            Me.lblAutoindexaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPostOffices
            '
            Me.lblPostOffices.BackColor = System.Drawing.Color.Black
            Me.lblPostOffices.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblPostOffices.ForeColor = System.Drawing.Color.White
            Me.lblPostOffices.Location = New System.Drawing.Point(0, 0)
            Me.lblPostOffices.Name = "lblPostOffices"
            Me.lblPostOffices.Size = New System.Drawing.Size(297, 20)
            Me.lblPostOffices.TabIndex = 3
            Me.lblPostOffices.Text = "PostOffices"
            Me.lblPostOffices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'TabBackup
            '
            Me.TabBackup.Controls.Add(Me.TabPMAI)
            Me.TabBackup.Controls.Add(Me.TabPCAL)
            Me.TabBackup.Controls.Add(Me.TabPTSK)
            Me.TabBackup.Controls.Add(Me.TabPVCF)
            Me.TabBackup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabBackup.ImageList = Me.ImgLBackupTab
            Me.TabBackup.Location = New System.Drawing.Point(5, 5)
            Me.TabBackup.Name = "TabBackup"
            Me.TabBackup.SelectedIndex = 0
            Me.TabBackup.Size = New System.Drawing.Size(1057, 393)
            Me.TabBackup.TabIndex = 3
            '
            'TabPMAI
            '
            Me.TabPMAI.Controls.Add(Me.TablaMailBackupMAI)
            Me.TabPMAI.Controls.Add(Me.PanelFiltroMAIBackup)
            Me.TabPMAI.ImageKey = "iEmail"
            Me.TabPMAI.Location = New System.Drawing.Point(4, 39)
            Me.TabPMAI.Name = "TabPMAI"
            Me.TabPMAI.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPMAI.Size = New System.Drawing.Size(1049, 350)
            Me.TabPMAI.TabIndex = 0
            Me.TabPMAI.Text = "Emails, Notas (*.MAI)"
            Me.TabPMAI.UseVisualStyleBackColor = True
            '
            'TablaMailBackupMAI
            '
            Me.TablaMailBackupMAI.AllowUserToAddRows = False
            Me.TablaMailBackupMAI.AllowUserToDeleteRows = False
            Me.TablaMailBackupMAI.AllowUserToResizeRows = False
            Me.TablaMailBackupMAI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.TablaMailBackupMAI.ContextMenuStrip = Me.MenuTablaBackup
            Me.TablaMailBackupMAI.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TablaMailBackupMAI.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
            Me.TablaMailBackupMAI.Enabled = False
            Me.TablaMailBackupMAI.Location = New System.Drawing.Point(3, 43)
            Me.TablaMailBackupMAI.Name = "TablaMailBackupMAI"
            Me.TablaMailBackupMAI.ReadOnly = True
            Me.TablaMailBackupMAI.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
            Me.TablaMailBackupMAI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.TablaMailBackupMAI.ShowEditingIcon = False
            Me.TablaMailBackupMAI.Size = New System.Drawing.Size(1043, 304)
            Me.TablaMailBackupMAI.TabIndex = 0
            '
            'PanelFiltroMAIBackup
            '
            Me.PanelFiltroMAIBackup.Controls.Add(Me.TableLayoutPanel2)
            Me.PanelFiltroMAIBackup.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelFiltroMAIBackup.Location = New System.Drawing.Point(3, 3)
            Me.PanelFiltroMAIBackup.Name = "PanelFiltroMAIBackup"
            Me.PanelFiltroMAIBackup.Size = New System.Drawing.Size(1043, 40)
            Me.PanelFiltroMAIBackup.TabIndex = 2
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 4
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
            Me.TableLayoutPanel2.Controls.Add(Me.txtMaiAsunto, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.txtMaiRemitente, 1, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.txtMaiDestinatarios, 2, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.Label5, 1, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.Label7, 2, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.BtnLimpiarMai, 3, 1)
            Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 2
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(1043, 40)
            Me.TableLayoutPanel2.TabIndex = 2
            '
            'txtMaiAsunto
            '
            Me.txtMaiAsunto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtMaiAsunto.Location = New System.Drawing.Point(3, 16)
            Me.txtMaiAsunto.Name = "txtMaiAsunto"
            Me.txtMaiAsunto.Size = New System.Drawing.Size(587, 20)
            Me.txtMaiAsunto.TabIndex = 1
            '
            'txtMaiRemitente
            '
            Me.txtMaiRemitente.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtMaiRemitente.Location = New System.Drawing.Point(596, 16)
            Me.txtMaiRemitente.Name = "txtMaiRemitente"
            Me.txtMaiRemitente.Size = New System.Drawing.Size(194, 20)
            Me.txtMaiRemitente.TabIndex = 1
            '
            'txtMaiDestinatarios
            '
            Me.txtMaiDestinatarios.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtMaiDestinatarios.Location = New System.Drawing.Point(796, 16)
            Me.txtMaiDestinatarios.Name = "txtMaiDestinatarios"
            Me.txtMaiDestinatarios.Size = New System.Drawing.Size(194, 20)
            Me.txtMaiDestinatarios.TabIndex = 1
            '
            'Label4
            '
            Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(3, 0)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(43, 13)
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "Asunto:"
            '
            'Label5
            '
            Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(596, 0)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(58, 13)
            Me.Label5.TabIndex = 3
            Me.Label5.Text = "Remitente:"
            '
            'Label7
            '
            Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(796, 0)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(71, 13)
            Me.Label7.TabIndex = 4
            Me.Label7.Text = "Destinatarios:"
            '
            'BtnLimpiarMai
            '
            Me.BtnLimpiarMai.Dock = System.Windows.Forms.DockStyle.Fill
            Me.BtnLimpiarMai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.BtnLimpiarMai.Location = New System.Drawing.Point(996, 16)
            Me.BtnLimpiarMai.Name = "BtnLimpiarMai"
            Me.BtnLimpiarMai.Size = New System.Drawing.Size(44, 21)
            Me.BtnLimpiarMai.TabIndex = 5
            Me.BtnLimpiarMai.Text = "X"
            Me.BtnLimpiarMai.UseVisualStyleBackColor = True
            '
            'TabPCAL
            '
            Me.TabPCAL.Controls.Add(Me.TablaMailBackupCAL)
            Me.TabPCAL.Controls.Add(Me.PanelFiltroCALBackup)
            Me.TabPCAL.ImageKey = "iCalendario"
            Me.TabPCAL.Location = New System.Drawing.Point(4, 39)
            Me.TabPCAL.Name = "TabPCAL"
            Me.TabPCAL.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPCAL.Size = New System.Drawing.Size(1049, 350)
            Me.TabPCAL.TabIndex = 1
            Me.TabPCAL.Text = "Calendario (*.CAL)"
            Me.TabPCAL.UseVisualStyleBackColor = True
            '
            'TablaMailBackupCAL
            '
            Me.TablaMailBackupCAL.AllowUserToAddRows = False
            Me.TablaMailBackupCAL.AllowUserToDeleteRows = False
            Me.TablaMailBackupCAL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.TablaMailBackupCAL.ContextMenuStrip = Me.MenuTablaBackup
            Me.TablaMailBackupCAL.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TablaMailBackupCAL.Location = New System.Drawing.Point(3, 43)
            Me.TablaMailBackupCAL.Name = "TablaMailBackupCAL"
            Me.TablaMailBackupCAL.ReadOnly = True
            Me.TablaMailBackupCAL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.TablaMailBackupCAL.ShowEditingIcon = False
            Me.TablaMailBackupCAL.Size = New System.Drawing.Size(1043, 304)
            Me.TablaMailBackupCAL.TabIndex = 1
            '
            'PanelFiltroCALBackup
            '
            Me.PanelFiltroCALBackup.Controls.Add(Me.TableLayoutPanel5)
            Me.PanelFiltroCALBackup.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelFiltroCALBackup.Location = New System.Drawing.Point(3, 3)
            Me.PanelFiltroCALBackup.Name = "PanelFiltroCALBackup"
            Me.PanelFiltroCALBackup.Size = New System.Drawing.Size(1043, 40)
            Me.PanelFiltroCALBackup.TabIndex = 0
            '
            'TableLayoutPanel5
            '
            Me.TableLayoutPanel5.ColumnCount = 3
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
            Me.TableLayoutPanel5.Controls.Add(Me.Label21, 0, 0)
            Me.TableLayoutPanel5.Controls.Add(Me.Label22, 1, 0)
            Me.TableLayoutPanel5.Controls.Add(Me.txtCalDescripcion, 0, 1)
            Me.TableLayoutPanel5.Controls.Add(Me.txtCalHubicacion, 1, 1)
            Me.TableLayoutPanel5.Controls.Add(Me.BtnLimpiarCal, 2, 1)
            Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
            Me.TableLayoutPanel5.RowCount = 2
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel5.Size = New System.Drawing.Size(1043, 40)
            Me.TableLayoutPanel5.TabIndex = 0
            '
            'Label21
            '
            Me.Label21.AutoSize = True
            Me.Label21.Location = New System.Drawing.Point(3, 0)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(63, 13)
            Me.Label21.TabIndex = 0
            Me.Label21.Text = "Descipción:"
            '
            'Label22
            '
            Me.Label22.AutoSize = True
            Me.Label22.Location = New System.Drawing.Point(499, 0)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(64, 13)
            Me.Label22.TabIndex = 1
            Me.Label22.Text = "Hubicación:"
            '
            'txtCalDescripcion
            '
            Me.txtCalDescripcion.Dock = System.Windows.Forms.DockStyle.Top
            Me.txtCalDescripcion.Location = New System.Drawing.Point(3, 16)
            Me.txtCalDescripcion.Name = "txtCalDescripcion"
            Me.txtCalDescripcion.Size = New System.Drawing.Size(490, 20)
            Me.txtCalDescripcion.TabIndex = 4
            '
            'txtCalHubicacion
            '
            Me.txtCalHubicacion.Dock = System.Windows.Forms.DockStyle.Top
            Me.txtCalHubicacion.Location = New System.Drawing.Point(499, 16)
            Me.txtCalHubicacion.Name = "txtCalHubicacion"
            Me.txtCalHubicacion.Size = New System.Drawing.Size(490, 20)
            Me.txtCalHubicacion.TabIndex = 5
            '
            'BtnLimpiarCal
            '
            Me.BtnLimpiarCal.Dock = System.Windows.Forms.DockStyle.Fill
            Me.BtnLimpiarCal.Location = New System.Drawing.Point(995, 16)
            Me.BtnLimpiarCal.Name = "BtnLimpiarCal"
            Me.BtnLimpiarCal.Size = New System.Drawing.Size(45, 21)
            Me.BtnLimpiarCal.TabIndex = 6
            Me.BtnLimpiarCal.Text = "X"
            Me.BtnLimpiarCal.UseVisualStyleBackColor = True
            '
            'TabPTSK
            '
            Me.TabPTSK.Controls.Add(Me.TablaMailBackupTSK)
            Me.TabPTSK.Controls.Add(Me.PanelFiltroTSK)
            Me.TabPTSK.ImageKey = "iTarea"
            Me.TabPTSK.Location = New System.Drawing.Point(4, 39)
            Me.TabPTSK.Name = "TabPTSK"
            Me.TabPTSK.Size = New System.Drawing.Size(1049, 350)
            Me.TabPTSK.TabIndex = 2
            Me.TabPTSK.Text = "Tareas (*.TSK)"
            Me.TabPTSK.UseVisualStyleBackColor = True
            '
            'TablaMailBackupTSK
            '
            Me.TablaMailBackupTSK.AllowUserToAddRows = False
            Me.TablaMailBackupTSK.AllowUserToDeleteRows = False
            Me.TablaMailBackupTSK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.TablaMailBackupTSK.ContextMenuStrip = Me.MenuTablaBackup
            Me.TablaMailBackupTSK.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TablaMailBackupTSK.Location = New System.Drawing.Point(0, 40)
            Me.TablaMailBackupTSK.Name = "TablaMailBackupTSK"
            Me.TablaMailBackupTSK.ReadOnly = True
            Me.TablaMailBackupTSK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.TablaMailBackupTSK.ShowEditingIcon = False
            Me.TablaMailBackupTSK.Size = New System.Drawing.Size(1049, 310)
            Me.TablaMailBackupTSK.TabIndex = 1
            '
            'PanelFiltroTSK
            '
            Me.PanelFiltroTSK.Controls.Add(Me.TableLayoutPanel6)
            Me.PanelFiltroTSK.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelFiltroTSK.Location = New System.Drawing.Point(0, 0)
            Me.PanelFiltroTSK.Name = "PanelFiltroTSK"
            Me.PanelFiltroTSK.Size = New System.Drawing.Size(1049, 40)
            Me.PanelFiltroTSK.TabIndex = 0
            '
            'TableLayoutPanel6
            '
            Me.TableLayoutPanel6.ColumnCount = 3
            Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
            Me.TableLayoutPanel6.Controls.Add(Me.Label23, 0, 0)
            Me.TableLayoutPanel6.Controls.Add(Me.Label24, 1, 0)
            Me.TableLayoutPanel6.Controls.Add(Me.txtTskAsunto, 0, 1)
            Me.TableLayoutPanel6.Controls.Add(Me.txtTskNotas, 1, 1)
            Me.TableLayoutPanel6.Controls.Add(Me.BtnLimpiarTSK, 2, 1)
            Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
            Me.TableLayoutPanel6.RowCount = 2
            Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel6.Size = New System.Drawing.Size(1049, 40)
            Me.TableLayoutPanel6.TabIndex = 0
            '
            'Label23
            '
            Me.Label23.AutoSize = True
            Me.Label23.Location = New System.Drawing.Point(3, 0)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(43, 13)
            Me.Label23.TabIndex = 0
            Me.Label23.Text = "Asunto:"
            '
            'Label24
            '
            Me.Label24.AutoSize = True
            Me.Label24.Location = New System.Drawing.Point(502, 0)
            Me.Label24.Name = "Label24"
            Me.Label24.Size = New System.Drawing.Size(38, 13)
            Me.Label24.TabIndex = 1
            Me.Label24.Text = "Notas:"
            '
            'txtTskAsunto
            '
            Me.txtTskAsunto.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtTskAsunto.Location = New System.Drawing.Point(3, 16)
            Me.txtTskAsunto.Name = "txtTskAsunto"
            Me.txtTskAsunto.Size = New System.Drawing.Size(493, 20)
            Me.txtTskAsunto.TabIndex = 2
            '
            'txtTskNotas
            '
            Me.txtTskNotas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtTskNotas.Location = New System.Drawing.Point(502, 16)
            Me.txtTskNotas.Name = "txtTskNotas"
            Me.txtTskNotas.Size = New System.Drawing.Size(493, 20)
            Me.txtTskNotas.TabIndex = 3
            '
            'BtnLimpiarTSK
            '
            Me.BtnLimpiarTSK.Location = New System.Drawing.Point(1001, 16)
            Me.BtnLimpiarTSK.Name = "BtnLimpiarTSK"
            Me.BtnLimpiarTSK.Size = New System.Drawing.Size(44, 21)
            Me.BtnLimpiarTSK.TabIndex = 4
            Me.BtnLimpiarTSK.Text = "X"
            Me.BtnLimpiarTSK.UseVisualStyleBackColor = True
            '
            'TabPVCF
            '
            Me.TabPVCF.Controls.Add(Me.TablaMailBackupVCF)
            Me.TabPVCF.Controls.Add(Me.PanelFiltroVCFBackup)
            Me.TabPVCF.ImageKey = "iContacto"
            Me.TabPVCF.Location = New System.Drawing.Point(4, 39)
            Me.TabPVCF.Name = "TabPVCF"
            Me.TabPVCF.Size = New System.Drawing.Size(1049, 350)
            Me.TabPVCF.TabIndex = 3
            Me.TabPVCF.Text = "Contactos (*.VCF)"
            Me.TabPVCF.UseVisualStyleBackColor = True
            '
            'TablaMailBackupVCF
            '
            Me.TablaMailBackupVCF.AllowUserToAddRows = False
            Me.TablaMailBackupVCF.AllowUserToDeleteRows = False
            Me.TablaMailBackupVCF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.TablaMailBackupVCF.ContextMenuStrip = Me.MenuTablaBackup
            Me.TablaMailBackupVCF.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TablaMailBackupVCF.Location = New System.Drawing.Point(0, 40)
            Me.TablaMailBackupVCF.Name = "TablaMailBackupVCF"
            Me.TablaMailBackupVCF.ReadOnly = True
            Me.TablaMailBackupVCF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.TablaMailBackupVCF.ShowEditingIcon = False
            Me.TablaMailBackupVCF.Size = New System.Drawing.Size(1049, 310)
            Me.TablaMailBackupVCF.TabIndex = 1
            '
            'PanelFiltroVCFBackup
            '
            Me.PanelFiltroVCFBackup.Controls.Add(Me.TableLayoutPanel4)
            Me.PanelFiltroVCFBackup.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelFiltroVCFBackup.Location = New System.Drawing.Point(0, 0)
            Me.PanelFiltroVCFBackup.Name = "PanelFiltroVCFBackup"
            Me.PanelFiltroVCFBackup.Size = New System.Drawing.Size(1049, 40)
            Me.PanelFiltroVCFBackup.TabIndex = 0
            '
            'TableLayoutPanel4
            '
            Me.TableLayoutPanel4.ColumnCount = 7
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
            Me.TableLayoutPanel4.Controls.Add(Me.Label15, 0, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.Label16, 1, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.Label17, 2, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.Label18, 3, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.Label19, 4, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.Label20, 5, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.txtVcfNombre, 0, 1)
            Me.TableLayoutPanel4.Controls.Add(Me.txtVcfCompleto, 1, 1)
            Me.TableLayoutPanel4.Controls.Add(Me.txtVcfEmail, 2, 1)
            Me.TableLayoutPanel4.Controls.Add(Me.txtVcfPersonal, 3, 1)
            Me.TableLayoutPanel4.Controls.Add(Me.txtVcfTrabajo, 4, 1)
            Me.TableLayoutPanel4.Controls.Add(Me.txtVcfNick, 5, 1)
            Me.TableLayoutPanel4.Controls.Add(Me.BtnLimpiarVCF, 6, 1)
            Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
            Me.TableLayoutPanel4.RowCount = 2
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel4.Size = New System.Drawing.Size(1049, 40)
            Me.TableLayoutPanel4.TabIndex = 0
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Location = New System.Drawing.Point(3, 0)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(47, 13)
            Me.Label15.TabIndex = 0
            Me.Label15.Text = "Nombre:"
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(201, 0)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(54, 13)
            Me.Label16.TabIndex = 1
            Me.Label16.Text = "Completo:"
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.Location = New System.Drawing.Point(597, 0)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(35, 13)
            Me.Label17.TabIndex = 2
            Me.Label17.Text = "Email:"
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(696, 0)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(51, 13)
            Me.Label18.TabIndex = 3
            Me.Label18.Text = "Personal:"
            '
            'Label19
            '
            Me.Label19.AutoSize = True
            Me.Label19.Location = New System.Drawing.Point(795, 0)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(46, 13)
            Me.Label19.TabIndex = 4
            Me.Label19.Text = "Trabajo:"
            '
            'Label20
            '
            Me.Label20.AutoSize = True
            Me.Label20.Location = New System.Drawing.Point(894, 0)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(32, 13)
            Me.Label20.TabIndex = 5
            Me.Label20.Text = "Nick:"
            '
            'txtVcfNombre
            '
            Me.txtVcfNombre.Dock = System.Windows.Forms.DockStyle.Top
            Me.txtVcfNombre.Location = New System.Drawing.Point(3, 16)
            Me.txtVcfNombre.Name = "txtVcfNombre"
            Me.txtVcfNombre.Size = New System.Drawing.Size(192, 20)
            Me.txtVcfNombre.TabIndex = 6
            '
            'txtVcfCompleto
            '
            Me.txtVcfCompleto.Dock = System.Windows.Forms.DockStyle.Top
            Me.txtVcfCompleto.Location = New System.Drawing.Point(201, 16)
            Me.txtVcfCompleto.Name = "txtVcfCompleto"
            Me.txtVcfCompleto.Size = New System.Drawing.Size(390, 20)
            Me.txtVcfCompleto.TabIndex = 7
            '
            'txtVcfEmail
            '
            Me.txtVcfEmail.Dock = System.Windows.Forms.DockStyle.Top
            Me.txtVcfEmail.Location = New System.Drawing.Point(597, 16)
            Me.txtVcfEmail.Name = "txtVcfEmail"
            Me.txtVcfEmail.Size = New System.Drawing.Size(93, 20)
            Me.txtVcfEmail.TabIndex = 8
            '
            'txtVcfPersonal
            '
            Me.txtVcfPersonal.Dock = System.Windows.Forms.DockStyle.Top
            Me.txtVcfPersonal.Location = New System.Drawing.Point(696, 16)
            Me.txtVcfPersonal.Name = "txtVcfPersonal"
            Me.txtVcfPersonal.Size = New System.Drawing.Size(93, 20)
            Me.txtVcfPersonal.TabIndex = 9
            '
            'txtVcfTrabajo
            '
            Me.txtVcfTrabajo.Dock = System.Windows.Forms.DockStyle.Top
            Me.txtVcfTrabajo.Location = New System.Drawing.Point(795, 16)
            Me.txtVcfTrabajo.Name = "txtVcfTrabajo"
            Me.txtVcfTrabajo.Size = New System.Drawing.Size(93, 20)
            Me.txtVcfTrabajo.TabIndex = 10
            '
            'txtVcfNick
            '
            Me.txtVcfNick.Dock = System.Windows.Forms.DockStyle.Top
            Me.txtVcfNick.Location = New System.Drawing.Point(894, 16)
            Me.txtVcfNick.Name = "txtVcfNick"
            Me.txtVcfNick.Size = New System.Drawing.Size(93, 20)
            Me.txtVcfNick.TabIndex = 11
            '
            'BtnLimpiarVCF
            '
            Me.BtnLimpiarVCF.Location = New System.Drawing.Point(993, 16)
            Me.BtnLimpiarVCF.Name = "BtnLimpiarVCF"
            Me.BtnLimpiarVCF.Size = New System.Drawing.Size(44, 21)
            Me.BtnLimpiarVCF.TabIndex = 12
            Me.BtnLimpiarVCF.Text = "X"
            Me.BtnLimpiarVCF.UseVisualStyleBackColor = True
            '
            'ImgLBackupTab
            '
            Me.ImgLBackupTab.ImageStream = CType(resources.GetObject("ImgLBackupTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImgLBackupTab.TransparentColor = System.Drawing.Color.Transparent
            Me.ImgLBackupTab.Images.SetKeyName(0, "iContacto")
            Me.ImgLBackupTab.Images.SetKeyName(1, "iTarea")
            Me.ImgLBackupTab.Images.SetKeyName(2, "iCalendario")
            Me.ImgLBackupTab.Images.SetKeyName(3, "iEmail")
            '
            'StatusStrip1
            '
            Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblMailBackupSeleccionados, Me.ProgresoIndexacion, Me.lblMensajesBackup, Me.lblLimpiadosBackup, Me.ToolStripStatusLabel2, Me.lblEmails, Me.lblCarpetas, Me.lblAnalizadoresBackup})
            Me.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
            Me.StatusStrip1.Location = New System.Drawing.Point(5, 398)
            Me.StatusStrip1.Name = "StatusStrip1"
            Me.StatusStrip1.Size = New System.Drawing.Size(1057, 24)
            Me.StatusStrip1.SizingGrip = False
            Me.StatusStrip1.TabIndex = 1
            Me.StatusStrip1.Text = "StatusStrip1"
            '
            'lblMailBackupSeleccionados
            '
            Me.lblMailBackupSeleccionados.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
            Me.lblMailBackupSeleccionados.Name = "lblMailBackupSeleccionados"
            Me.lblMailBackupSeleccionados.Size = New System.Drawing.Size(79, 19)
            Me.lblMailBackupSeleccionados.Text = "Analizando..."
            '
            'ProgresoIndexacion
            '
            Me.ProgresoIndexacion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.ProgresoIndexacion.Name = "ProgresoIndexacion"
            Me.ProgresoIndexacion.Size = New System.Drawing.Size(50, 18)
            '
            'lblMensajesBackup
            '
            Me.lblMensajesBackup.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
            Me.lblMensajesBackup.Name = "lblMensajesBackup"
            Me.lblMensajesBackup.Size = New System.Drawing.Size(20, 19)
            Me.lblMensajesBackup.Text = "..."
            '
            'lblLimpiadosBackup
            '
            Me.lblLimpiadosBackup.Name = "lblLimpiadosBackup"
            Me.lblLimpiadosBackup.Size = New System.Drawing.Size(79, 19)
            Me.lblLimpiadosBackup.Text = "Limpiados (0)"
            '
            'ToolStripStatusLabel2
            '
            Me.ToolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
            Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
            Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(4, 19)
            '
            'lblEmails
            '
            Me.lblEmails.Name = "lblEmails"
            Me.lblEmails.Size = New System.Drawing.Size(16, 19)
            Me.lblEmails.Text = "..."
            '
            'lblCarpetas
            '
            Me.lblCarpetas.Name = "lblCarpetas"
            Me.lblCarpetas.Size = New System.Drawing.Size(16, 19)
            Me.lblCarpetas.Text = "..."
            '
            'lblAnalizadoresBackup
            '
            Me.lblAnalizadoresBackup.Name = "lblAnalizadoresBackup"
            Me.lblAnalizadoresBackup.Size = New System.Drawing.Size(16, 19)
            Me.lblAnalizadoresBackup.Text = "..."
            '
            'TabMigraciones
            '
            Me.TabMigraciones.Controls.Add(Me.SplitMigracion)
            Me.TabMigraciones.Controls.Add(Me.PanelOpcionesMigracion)
            Me.TabMigraciones.ImageKey = "MM"
            Me.TabMigraciones.Location = New System.Drawing.Point(4, 39)
            Me.TabMigraciones.Name = "TabMigraciones"
            Me.TabMigraciones.Padding = New System.Windows.Forms.Padding(3)
            Me.TabMigraciones.Size = New System.Drawing.Size(1368, 427)
            Me.TabMigraciones.TabIndex = 3
            Me.TabMigraciones.Text = "Migraciones"
            Me.TabMigraciones.UseVisualStyleBackColor = True
            '
            'SplitMigracion
            '
            Me.SplitMigracion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitMigracion.Location = New System.Drawing.Point(3, 31)
            Me.SplitMigracion.Name = "SplitMigracion"
            '
            'SplitMigracion.Panel1
            '
            Me.SplitMigracion.Panel1.Controls.Add(Me.lstDominiosMigracion)
            Me.SplitMigracion.Panel1.Controls.Add(Me.PanelOpcionesDominio)
            '
            'SplitMigracion.Panel2
            '
            Me.SplitMigracion.Panel2.Controls.Add(Me.SplitProcesoMigracion)
            Me.SplitMigracion.Size = New System.Drawing.Size(1362, 393)
            Me.SplitMigracion.SplitterDistance = 272
            Me.SplitMigracion.TabIndex = 2
            '
            'lstDominiosMigracion
            '
            Me.lstDominiosMigracion.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lstDM_Dominio, Me.lstDM_Estado})
            Me.lstDominiosMigracion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstDominiosMigracion.FullRowSelect = True
            Me.lstDominiosMigracion.GridLines = True
            Me.lstDominiosMigracion.HideSelection = False
            Me.lstDominiosMigracion.Location = New System.Drawing.Point(0, 25)
            Me.lstDominiosMigracion.Name = "lstDominiosMigracion"
            Me.lstDominiosMigracion.Size = New System.Drawing.Size(272, 368)
            Me.lstDominiosMigracion.TabIndex = 0
            Me.lstDominiosMigracion.UseCompatibleStateImageBehavior = False
            Me.lstDominiosMigracion.View = System.Windows.Forms.View.Details
            '
            'lstDM_Dominio
            '
            Me.lstDM_Dominio.Text = "Dominio"
            Me.lstDM_Dominio.Width = 218
            '
            'lstDM_Estado
            '
            Me.lstDM_Estado.Text = "Activo"
            '
            'PanelOpcionesDominio
            '
            Me.PanelOpcionesDominio.Controls.Add(Me.ToolStrip1)
            Me.PanelOpcionesDominio.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelOpcionesDominio.Location = New System.Drawing.Point(0, 0)
            Me.PanelOpcionesDominio.Name = "PanelOpcionesDominio"
            Me.PanelOpcionesDominio.Size = New System.Drawing.Size(272, 25)
            Me.PanelOpcionesDominio.TabIndex = 3
            '
            'ToolStrip1
            '
            Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCrearDominioMigracion, Me.BtnEliminarDominioMigracion, Me.BtnActivarMigracionDominio, Me.BtnDesactivarMigracionDominio})
            Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
            Me.ToolStrip1.Name = "ToolStrip1"
            Me.ToolStrip1.Size = New System.Drawing.Size(272, 25)
            Me.ToolStrip1.TabIndex = 4
            Me.ToolStrip1.Text = "ToolStrip1"
            '
            'BtnCrearDominioMigracion
            '
            Me.BtnCrearDominioMigracion.Image = CType(resources.GetObject("BtnCrearDominioMigracion.Image"), System.Drawing.Image)
            Me.BtnCrearDominioMigracion.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtnCrearDominioMigracion.Name = "BtnCrearDominioMigracion"
            Me.BtnCrearDominioMigracion.Size = New System.Drawing.Size(62, 22)
            Me.BtnCrearDominioMigracion.Text = "Añadir"
            '
            'BtnEliminarDominioMigracion
            '
            Me.BtnEliminarDominioMigracion.Enabled = False
            Me.BtnEliminarDominioMigracion.Image = CType(resources.GetObject("BtnEliminarDominioMigracion.Image"), System.Drawing.Image)
            Me.BtnEliminarDominioMigracion.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtnEliminarDominioMigracion.Name = "BtnEliminarDominioMigracion"
            Me.BtnEliminarDominioMigracion.Size = New System.Drawing.Size(70, 22)
            Me.BtnEliminarDominioMigracion.Text = "Eliminar"
            '
            'BtnActivarMigracionDominio
            '
            Me.BtnActivarMigracionDominio.Enabled = False
            Me.BtnActivarMigracionDominio.Image = CType(resources.GetObject("BtnActivarMigracionDominio.Image"), System.Drawing.Image)
            Me.BtnActivarMigracionDominio.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtnActivarMigracionDominio.Name = "BtnActivarMigracionDominio"
            Me.BtnActivarMigracionDominio.Size = New System.Drawing.Size(64, 22)
            Me.BtnActivarMigracionDominio.Text = "Activar"
            '
            'BtnDesactivarMigracionDominio
            '
            Me.BtnDesactivarMigracionDominio.Enabled = False
            Me.BtnDesactivarMigracionDominio.Image = CType(resources.GetObject("BtnDesactivarMigracionDominio.Image"), System.Drawing.Image)
            Me.BtnDesactivarMigracionDominio.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtnDesactivarMigracionDominio.Name = "BtnDesactivarMigracionDominio"
            Me.BtnDesactivarMigracionDominio.Size = New System.Drawing.Size(81, 20)
            Me.BtnDesactivarMigracionDominio.Text = "Desactivar"
            '
            'SplitProcesoMigracion
            '
            Me.SplitProcesoMigracion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitProcesoMigracion.Location = New System.Drawing.Point(0, 0)
            Me.SplitProcesoMigracion.Name = "SplitProcesoMigracion"
            '
            'SplitProcesoMigracion.Panel1
            '
            Me.SplitProcesoMigracion.Panel1.Controls.Add(Me.SplitContainer3)
            '
            'SplitProcesoMigracion.Panel2
            '
            Me.SplitProcesoMigracion.Panel2.Controls.Add(Me.lstErroneosMigracion)
            Me.SplitProcesoMigracion.Panel2.Controls.Add(Me.Label10)
            Me.SplitProcesoMigracion.Size = New System.Drawing.Size(1086, 393)
            Me.SplitProcesoMigracion.SplitterDistance = 233
            Me.SplitProcesoMigracion.TabIndex = 2
            '
            'SplitContainer3
            '
            Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
            Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer3.Name = "SplitContainer3"
            Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
            '
            'SplitContainer3.Panel1
            '
            Me.SplitContainer3.Panel1.Controls.Add(Me.PanelColaMigracion)
            '
            'SplitContainer3.Panel2
            '
            Me.SplitContainer3.Panel2.Controls.Add(Me.PanelProgresoMigracion)
            Me.SplitContainer3.Size = New System.Drawing.Size(233, 393)
            Me.SplitContainer3.SplitterDistance = 278
            Me.SplitContainer3.TabIndex = 6
            '
            'PanelColaMigracion
            '
            Me.PanelColaMigracion.Controls.Add(Me.lstListaDeEsperaMigracion)
            Me.PanelColaMigracion.Controls.Add(Me.Label9)
            Me.PanelColaMigracion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelColaMigracion.Location = New System.Drawing.Point(0, 0)
            Me.PanelColaMigracion.Name = "PanelColaMigracion"
            Me.PanelColaMigracion.Size = New System.Drawing.Size(233, 278)
            Me.PanelColaMigracion.TabIndex = 4
            '
            'lstListaDeEsperaMigracion
            '
            Me.lstListaDeEsperaMigracion.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
            Me.lstListaDeEsperaMigracion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstListaDeEsperaMigracion.HideSelection = False
            Me.lstListaDeEsperaMigracion.Location = New System.Drawing.Point(0, 22)
            Me.lstListaDeEsperaMigracion.Name = "lstListaDeEsperaMigracion"
            Me.lstListaDeEsperaMigracion.Size = New System.Drawing.Size(233, 256)
            Me.lstListaDeEsperaMigracion.TabIndex = 1
            Me.lstListaDeEsperaMigracion.UseCompatibleStateImageBehavior = False
            Me.lstListaDeEsperaMigracion.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader1
            '
            Me.ColumnHeader1.Text = "Cuenta"
            Me.ColumnHeader1.Width = 174
            '
            'ColumnHeader2
            '
            Me.ColumnHeader2.Text = "Estado"
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Black
            Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(0, 0)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(233, 22)
            Me.Label9.TabIndex = 2
            Me.Label9.Text = "Cola"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'PanelProgresoMigracion
            '
            Me.PanelProgresoMigracion.Controls.Add(Me.lstMailBoxMigracion)
            Me.PanelProgresoMigracion.Controls.Add(Me.Label11)
            Me.PanelProgresoMigracion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelProgresoMigracion.Location = New System.Drawing.Point(0, 0)
            Me.PanelProgresoMigracion.Name = "PanelProgresoMigracion"
            Me.PanelProgresoMigracion.Size = New System.Drawing.Size(233, 111)
            Me.PanelProgresoMigracion.TabIndex = 5
            '
            'lstMailBoxMigracion
            '
            Me.lstMailBoxMigracion.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lstMM_MailBox, Me.lstMM_Trabajado})
            Me.lstMailBoxMigracion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstMailBoxMigracion.HideSelection = False
            Me.lstMailBoxMigracion.Location = New System.Drawing.Point(0, 22)
            Me.lstMailBoxMigracion.Name = "lstMailBoxMigracion"
            Me.lstMailBoxMigracion.Size = New System.Drawing.Size(233, 89)
            Me.lstMailBoxMigracion.TabIndex = 0
            Me.lstMailBoxMigracion.UseCompatibleStateImageBehavior = False
            Me.lstMailBoxMigracion.View = System.Windows.Forms.View.Details
            '
            'lstMM_MailBox
            '
            Me.lstMM_MailBox.Text = "Cuenta"
            Me.lstMM_MailBox.Width = 174
            '
            'lstMM_Trabajado
            '
            Me.lstMM_Trabajado.Text = "Estado"
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Black
            Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(0, 0)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(233, 22)
            Me.Label11.TabIndex = 3
            Me.Label11.Text = "Migrando"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lstErroneosMigracion
            '
            Me.lstErroneosMigracion.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
            Me.lstErroneosMigracion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstErroneosMigracion.FullRowSelect = True
            Me.lstErroneosMigracion.GridLines = True
            Me.lstErroneosMigracion.HideSelection = False
            Me.lstErroneosMigracion.Location = New System.Drawing.Point(0, 22)
            Me.lstErroneosMigracion.Name = "lstErroneosMigracion"
            Me.lstErroneosMigracion.Size = New System.Drawing.Size(849, 371)
            Me.lstErroneosMigracion.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lstErroneosMigracion.TabIndex = 2
            Me.lstErroneosMigracion.UseCompatibleStateImageBehavior = False
            Me.lstErroneosMigracion.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader3
            '
            Me.ColumnHeader3.Text = "Cuenta"
            Me.ColumnHeader3.Width = 174
            '
            'ColumnHeader4
            '
            Me.ColumnHeader4.Text = "Estado"
            Me.ColumnHeader4.Width = 686
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Black
            Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(0, 0)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(849, 22)
            Me.Label10.TabIndex = 3
            Me.Label10.Text = "Erroneos"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'PanelOpcionesMigracion
            '
            Me.PanelOpcionesMigracion.Controls.Add(Me.ToolMigraciones)
            Me.PanelOpcionesMigracion.Controls.Add(Me.PanelServicioMigracion)
            Me.PanelOpcionesMigracion.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelOpcionesMigracion.Location = New System.Drawing.Point(3, 3)
            Me.PanelOpcionesMigracion.Name = "PanelOpcionesMigracion"
            Me.PanelOpcionesMigracion.Size = New System.Drawing.Size(1362, 28)
            Me.PanelOpcionesMigracion.TabIndex = 1
            '
            'ToolMigraciones
            '
            Me.ToolMigraciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ToolMigraciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnMigrarCuenta, Me.ToolStripSeparator1, Me.BtnLimpiarMigracionesCompletadas, Me.ToolStripSeparator2, Me.BtnLimpiarErroneosMigracion, Me.BtnCopiarErroneos})
            Me.ToolMigraciones.Location = New System.Drawing.Point(290, 0)
            Me.ToolMigraciones.Name = "ToolMigraciones"
            Me.ToolMigraciones.Size = New System.Drawing.Size(1072, 25)
            Me.ToolMigraciones.TabIndex = 0
            Me.ToolMigraciones.Text = "Migraciones"
            '
            'BtnMigrarCuenta
            '
            Me.BtnMigrarCuenta.Image = CType(resources.GetObject("BtnMigrarCuenta.Image"), System.Drawing.Image)
            Me.BtnMigrarCuenta.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtnMigrarCuenta.Name = "BtnMigrarCuenta"
            Me.BtnMigrarCuenta.Size = New System.Drawing.Size(103, 22)
            Me.BtnMigrarCuenta.Text = "Migrar Cuenta"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'BtnLimpiarMigracionesCompletadas
            '
            Me.BtnLimpiarMigracionesCompletadas.Image = CType(resources.GetObject("BtnLimpiarMigracionesCompletadas.Image"), System.Drawing.Image)
            Me.BtnLimpiarMigracionesCompletadas.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtnLimpiarMigracionesCompletadas.Name = "BtnLimpiarMigracionesCompletadas"
            Me.BtnLimpiarMigracionesCompletadas.Size = New System.Drawing.Size(139, 22)
            Me.BtnLimpiarMigracionesCompletadas.Text = "Limpiar completados"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'BtnLimpiarErroneosMigracion
            '
            Me.BtnLimpiarErroneosMigracion.Image = CType(resources.GetObject("BtnLimpiarErroneosMigracion.Image"), System.Drawing.Image)
            Me.BtnLimpiarErroneosMigracion.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtnLimpiarErroneosMigracion.Name = "BtnLimpiarErroneosMigracion"
            Me.BtnLimpiarErroneosMigracion.Size = New System.Drawing.Size(116, 22)
            Me.BtnLimpiarErroneosMigracion.Text = "Limpiar erroneos"
            '
            'BtnCopiarErroneos
            '
            Me.BtnCopiarErroneos.Image = CType(resources.GetObject("BtnCopiarErroneos.Image"), System.Drawing.Image)
            Me.BtnCopiarErroneos.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtnCopiarErroneos.Name = "BtnCopiarErroneos"
            Me.BtnCopiarErroneos.Size = New System.Drawing.Size(111, 22)
            Me.BtnCopiarErroneos.Text = "Copiar erroneos"
            '
            'PanelServicioMigracion
            '
            Me.PanelServicioMigracion.Controls.Add(Me.TableLayoutPanel3)
            Me.PanelServicioMigracion.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelServicioMigracion.Location = New System.Drawing.Point(0, 0)
            Me.PanelServicioMigracion.Name = "PanelServicioMigracion"
            Me.PanelServicioMigracion.Size = New System.Drawing.Size(290, 28)
            Me.PanelServicioMigracion.TabIndex = 1
            '
            'TableLayoutPanel3
            '
            Me.TableLayoutPanel3.ColumnCount = 3
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.92135!))
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.07865!))
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201.0!))
            Me.TableLayoutPanel3.Controls.Add(Me.Label8, 0, 0)
            Me.TableLayoutPanel3.Controls.Add(Me.BtnServicioMigracion, 2, 0)
            Me.TableLayoutPanel3.Controls.Add(Me.lblEstadoServicioMigracion, 1, 0)
            Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
            Me.TableLayoutPanel3.RowCount = 1
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel3.Size = New System.Drawing.Size(290, 28)
            Me.TableLayoutPanel3.TabIndex = 3
            '
            'Label8
            '
            Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(4, 7)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(48, 13)
            Me.Label8.TabIndex = 0
            Me.Label8.Text = "Servicio:"
            '
            'BtnServicioMigracion
            '
            Me.BtnServicioMigracion.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnServicioMigracion.Enabled = False
            Me.BtnServicioMigracion.Location = New System.Drawing.Point(92, 3)
            Me.BtnServicioMigracion.Name = "BtnServicioMigracion"
            Me.BtnServicioMigracion.Size = New System.Drawing.Size(99, 22)
            Me.BtnServicioMigracion.TabIndex = 2
            Me.BtnServicioMigracion.Text = "Iniciando..."
            Me.BtnServicioMigracion.UseVisualStyleBackColor = True
            '
            'lblEstadoServicioMigracion
            '
            Me.lblEstadoServicioMigracion.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.lblEstadoServicioMigracion.BackColor = System.Drawing.Color.White
            Me.lblEstadoServicioMigracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblEstadoServicioMigracion.Location = New System.Drawing.Point(62, 4)
            Me.lblEstadoServicioMigracion.Name = "lblEstadoServicioMigracion"
            Me.lblEstadoServicioMigracion.Size = New System.Drawing.Size(21, 20)
            Me.lblEstadoServicioMigracion.TabIndex = 1
            '
            'TabCertificados
            '
            Me.TabCertificados.Controls.Add(Me.SplitCertificados)
            Me.TabCertificados.ImageKey = "CE"
            Me.TabCertificados.Location = New System.Drawing.Point(4, 39)
            Me.TabCertificados.Name = "TabCertificados"
            Me.TabCertificados.Padding = New System.Windows.Forms.Padding(3)
            Me.TabCertificados.Size = New System.Drawing.Size(1368, 427)
            Me.TabCertificados.TabIndex = 4
            Me.TabCertificados.Text = "Certificados"
            Me.TabCertificados.UseVisualStyleBackColor = True
            '
            'SplitCertificados
            '
            Me.SplitCertificados.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitCertificados.Location = New System.Drawing.Point(3, 3)
            Me.SplitCertificados.Name = "SplitCertificados"
            '
            'SplitCertificados.Panel1
            '
            Me.SplitCertificados.Panel1.Controls.Add(Me.SplitContainer4)
            '
            'SplitCertificados.Panel2
            '
            Me.SplitCertificados.Panel2.Controls.Add(Me.TabNavegadores)
            Me.SplitCertificados.Size = New System.Drawing.Size(1362, 421)
            Me.SplitCertificados.SplitterDistance = 454
            Me.SplitCertificados.TabIndex = 0
            '
            'SplitContainer4
            '
            Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer4.Name = "SplitContainer4"
            Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
            '
            'SplitContainer4.Panel1
            '
            Me.SplitContainer4.Panel1.Controls.Add(Me.lstCertificados)
            Me.SplitContainer4.Panel1.Controls.Add(Me.Label12)
            '
            'SplitContainer4.Panel2
            '
            Me.SplitContainer4.Panel2.Controls.Add(Me.lstLogDescargaCertificado)
            Me.SplitContainer4.Panel2.Controls.Add(Me.Label13)
            Me.SplitContainer4.Size = New System.Drawing.Size(454, 421)
            Me.SplitContainer4.SplitterDistance = 159
            Me.SplitContainer4.TabIndex = 1
            '
            'lstCertificados
            '
            Me.lstCertificados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cCertificado, Me.cCaducaCertificado})
            Me.lstCertificados.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstCertificados.FullRowSelect = True
            Me.lstCertificados.GridLines = True
            Me.lstCertificados.HideSelection = False
            Me.lstCertificados.Location = New System.Drawing.Point(0, 25)
            Me.lstCertificados.Name = "lstCertificados"
            Me.lstCertificados.Size = New System.Drawing.Size(454, 134)
            Me.lstCertificados.TabIndex = 0
            Me.lstCertificados.UseCompatibleStateImageBehavior = False
            Me.lstCertificados.View = System.Windows.Forms.View.Details
            '
            'cCertificado
            '
            Me.cCertificado.Text = "Certificado"
            Me.cCertificado.Width = 360
            '
            'cCaducaCertificado
            '
            Me.cCaducaCertificado.Text = "Caduca"
            Me.cCaducaCertificado.Width = 96
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Black
            Me.Label12.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(0, 0)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(454, 25)
            Me.Label12.TabIndex = 1
            Me.Label12.Text = "Certificados Instalados"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lstLogDescargaCertificado
            '
            Me.lstLogDescargaCertificado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cLogCertificado, Me.cLogCIntento, Me.cLogcResultado})
            Me.lstLogDescargaCertificado.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstLogDescargaCertificado.FullRowSelect = True
            Me.lstLogDescargaCertificado.GridLines = True
            Me.lstLogDescargaCertificado.HideSelection = False
            Me.lstLogDescargaCertificado.Location = New System.Drawing.Point(0, 25)
            Me.lstLogDescargaCertificado.Name = "lstLogDescargaCertificado"
            Me.lstLogDescargaCertificado.Size = New System.Drawing.Size(454, 233)
            Me.lstLogDescargaCertificado.TabIndex = 0
            Me.lstLogDescargaCertificado.UseCompatibleStateImageBehavior = False
            Me.lstLogDescargaCertificado.View = System.Windows.Forms.View.Details
            '
            'cLogCertificado
            '
            Me.cLogCertificado.Text = "Certificado"
            Me.cLogCertificado.Width = 193
            '
            'cLogCIntento
            '
            Me.cLogCIntento.Text = "Intento"
            Me.cLogCIntento.Width = 192
            '
            'cLogcResultado
            '
            Me.cLogcResultado.Text = "Resultado"
            Me.cLogcResultado.Width = 78
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.Black
            Me.Label13.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label13.ForeColor = System.Drawing.Color.White
            Me.Label13.Location = New System.Drawing.Point(0, 0)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(454, 25)
            Me.Label13.TabIndex = 1
            Me.Label13.Text = "Descargas Realizadas"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'TabNavegadores
            '
            Me.TabNavegadores.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabNavegadores.ItemSize = New System.Drawing.Size(62, 25)
            Me.TabNavegadores.Location = New System.Drawing.Point(0, 0)
            Me.TabNavegadores.Name = "TabNavegadores"
            Me.TabNavegadores.SelectedIndex = 0
            Me.TabNavegadores.Size = New System.Drawing.Size(904, 421)
            Me.TabNavegadores.TabIndex = 0
            '
            'TabAutoResponder
            '
            Me.TabAutoResponder.Controls.Add(Me.SplitContainer5)
            Me.TabAutoResponder.Controls.Add(Me.SplitterAutoResponderLst)
            Me.TabAutoResponder.Controls.Add(Me.PanellstEmailsColaSMTP)
            Me.TabAutoResponder.ImageKey = "AE"
            Me.TabAutoResponder.Location = New System.Drawing.Point(4, 39)
            Me.TabAutoResponder.Name = "TabAutoResponder"
            Me.TabAutoResponder.Size = New System.Drawing.Size(1368, 427)
            Me.TabAutoResponder.TabIndex = 5
            Me.TabAutoResponder.Text = "Auto responder"
            Me.TabAutoResponder.UseVisualStyleBackColor = True
            '
            'SplitContainer5
            '
            Me.SplitContainer5.BackColor = System.Drawing.Color.Black
            Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer5.Location = New System.Drawing.Point(340, 0)
            Me.SplitContainer5.Name = "SplitContainer5"
            '
            'SplitContainer5.Panel1
            '
            Me.SplitContainer5.Panel1.Controls.Add(Me.RichAutoResponderMail)
            Me.SplitContainer5.Panel1.Controls.Add(Me.Label25)
            '
            'SplitContainer5.Panel2
            '
            Me.SplitContainer5.Panel2.Controls.Add(Me.SplitContainer6)
            Me.SplitContainer5.Size = New System.Drawing.Size(1028, 427)
            Me.SplitContainer5.SplitterDistance = 211
            Me.SplitContainer5.TabIndex = 2
            '
            'RichAutoResponderMail
            '
            Me.RichAutoResponderMail.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RichAutoResponderMail.Location = New System.Drawing.Point(0, 20)
            Me.RichAutoResponderMail.Name = "RichAutoResponderMail"
            Me.RichAutoResponderMail.Size = New System.Drawing.Size(211, 407)
            Me.RichAutoResponderMail.TabIndex = 0
            Me.RichAutoResponderMail.Text = ""
            '
            'Label25
            '
            Me.Label25.BackColor = System.Drawing.Color.Black
            Me.Label25.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label25.ForeColor = System.Drawing.Color.White
            Me.Label25.Location = New System.Drawing.Point(0, 0)
            Me.Label25.Name = "Label25"
            Me.Label25.Size = New System.Drawing.Size(211, 20)
            Me.Label25.TabIndex = 0
            Me.Label25.Text = "Email"
            Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'SplitContainer6
            '
            Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer6.Name = "SplitContainer6"
            '
            'SplitContainer6.Panel1
            '
            Me.SplitContainer6.Panel1.Controls.Add(Me.RichAutoResponderStatus)
            Me.SplitContainer6.Panel1.Controls.Add(Me.Label26)
            '
            'SplitContainer6.Panel2
            '
            Me.SplitContainer6.Panel2.Controls.Add(Me.RichAutoResponderRespuesta)
            Me.SplitContainer6.Panel2.Controls.Add(Me.Label27)
            Me.SplitContainer6.Size = New System.Drawing.Size(813, 427)
            Me.SplitContainer6.SplitterDistance = 268
            Me.SplitContainer6.TabIndex = 2
            '
            'RichAutoResponderStatus
            '
            Me.RichAutoResponderStatus.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RichAutoResponderStatus.Location = New System.Drawing.Point(0, 20)
            Me.RichAutoResponderStatus.Name = "RichAutoResponderStatus"
            Me.RichAutoResponderStatus.Size = New System.Drawing.Size(268, 407)
            Me.RichAutoResponderStatus.TabIndex = 0
            Me.RichAutoResponderStatus.Text = ""
            '
            'Label26
            '
            Me.Label26.BackColor = System.Drawing.Color.Black
            Me.Label26.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label26.ForeColor = System.Drawing.Color.White
            Me.Label26.Location = New System.Drawing.Point(0, 0)
            Me.Label26.Name = "Label26"
            Me.Label26.Size = New System.Drawing.Size(268, 20)
            Me.Label26.TabIndex = 1
            Me.Label26.Text = "Estado"
            Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'RichAutoResponderRespuesta
            '
            Me.RichAutoResponderRespuesta.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RichAutoResponderRespuesta.Location = New System.Drawing.Point(0, 20)
            Me.RichAutoResponderRespuesta.Name = "RichAutoResponderRespuesta"
            Me.RichAutoResponderRespuesta.Size = New System.Drawing.Size(541, 407)
            Me.RichAutoResponderRespuesta.TabIndex = 3
            Me.RichAutoResponderRespuesta.Text = ""
            '
            'Label27
            '
            Me.Label27.BackColor = System.Drawing.Color.Black
            Me.Label27.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label27.ForeColor = System.Drawing.Color.White
            Me.Label27.Location = New System.Drawing.Point(0, 0)
            Me.Label27.Name = "Label27"
            Me.Label27.Size = New System.Drawing.Size(541, 20)
            Me.Label27.TabIndex = 2
            Me.Label27.Text = "Respuesta"
            Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'SplitterAutoResponderLst
            '
            Me.SplitterAutoResponderLst.BackColor = System.Drawing.Color.Black
            Me.SplitterAutoResponderLst.Location = New System.Drawing.Point(336, 0)
            Me.SplitterAutoResponderLst.Name = "SplitterAutoResponderLst"
            Me.SplitterAutoResponderLst.Size = New System.Drawing.Size(4, 427)
            Me.SplitterAutoResponderLst.TabIndex = 1
            Me.SplitterAutoResponderLst.TabStop = False
            '
            'PanellstEmailsColaSMTP
            '
            Me.PanellstEmailsColaSMTP.Controls.Add(Me.lstEmailsReparadosAutoResponder)
            Me.PanellstEmailsColaSMTP.Controls.Add(Me.ToolStrip2)
            Me.PanellstEmailsColaSMTP.Controls.Add(Me.Label28)
            Me.PanellstEmailsColaSMTP.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanellstEmailsColaSMTP.Location = New System.Drawing.Point(0, 0)
            Me.PanellstEmailsColaSMTP.Name = "PanellstEmailsColaSMTP"
            Me.PanellstEmailsColaSMTP.Size = New System.Drawing.Size(336, 427)
            Me.PanellstEmailsColaSMTP.TabIndex = 3
            '
            'lstEmailsReparadosAutoResponder
            '
            Me.lstEmailsReparadosAutoResponder.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstEmailsReparadosAutoResponder.FormattingEnabled = True
            Me.lstEmailsReparadosAutoResponder.IntegralHeight = False
            Me.lstEmailsReparadosAutoResponder.Location = New System.Drawing.Point(0, 45)
            Me.lstEmailsReparadosAutoResponder.Name = "lstEmailsReparadosAutoResponder"
            Me.lstEmailsReparadosAutoResponder.Size = New System.Drawing.Size(336, 382)
            Me.lstEmailsReparadosAutoResponder.TabIndex = 1
            '
            'ToolStrip2
            '
            Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 7.0!)
            Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnEliminarAutoResponder, Me.lblEmailSeleccionadoAutoResponder, Me.BtnLimpiarMemoriaAutoResponder})
            Me.ToolStrip2.Location = New System.Drawing.Point(0, 20)
            Me.ToolStrip2.Name = "ToolStrip2"
            Me.ToolStrip2.Size = New System.Drawing.Size(336, 25)
            Me.ToolStrip2.TabIndex = 3
            Me.ToolStrip2.Text = "MenuColaSMTPAutoResponder"
            '
            'BtnEliminarAutoResponder
            '
            Me.BtnEliminarAutoResponder.Enabled = False
            Me.BtnEliminarAutoResponder.Font = New System.Drawing.Font("Segoe UI", 8.0!)
            Me.BtnEliminarAutoResponder.Image = CType(resources.GetObject("BtnEliminarAutoResponder.Image"), System.Drawing.Image)
            Me.BtnEliminarAutoResponder.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtnEliminarAutoResponder.Name = "BtnEliminarAutoResponder"
            Me.BtnEliminarAutoResponder.Size = New System.Drawing.Size(68, 22)
            Me.BtnEliminarAutoResponder.Text = "Eliminar"
            '
            'lblEmailSeleccionadoAutoResponder
            '
            Me.lblEmailSeleccionadoAutoResponder.Name = "lblEmailSeleccionadoAutoResponder"
            Me.lblEmailSeleccionadoAutoResponder.Size = New System.Drawing.Size(0, 22)
            '
            'BtnLimpiarMemoriaAutoResponder
            '
            Me.BtnLimpiarMemoriaAutoResponder.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.BtnLimpiarMemoriaAutoResponder.Image = CType(resources.GetObject("BtnLimpiarMemoriaAutoResponder.Image"), System.Drawing.Image)
            Me.BtnLimpiarMemoriaAutoResponder.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtnLimpiarMemoriaAutoResponder.Name = "BtnLimpiarMemoriaAutoResponder"
            Me.BtnLimpiarMemoriaAutoResponder.Size = New System.Drawing.Size(87, 22)
            Me.BtnLimpiarMemoriaAutoResponder.Text = "Limpiar Cache"
            Me.BtnLimpiarMemoriaAutoResponder.ToolTipText = "Limpiar"
            '
            'Label28
            '
            Me.Label28.BackColor = System.Drawing.Color.Black
            Me.Label28.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label28.ForeColor = System.Drawing.Color.White
            Me.Label28.Location = New System.Drawing.Point(0, 0)
            Me.Label28.Name = "Label28"
            Me.Label28.Size = New System.Drawing.Size(336, 20)
            Me.Label28.TabIndex = 2
            Me.Label28.Text = "Cola SMTP"
            Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.IconosTab.Images.SetKeyName(5, "MM")
            Me.IconosTab.Images.SetKeyName(6, "CE")
            Me.IconosTab.Images.SetKeyName(7, "AE")
            '
            'MenuPrincipal
            '
            Me.MenuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónToolStripMenuItem, Me.BuclesToolStripMenuItem})
            Me.MenuPrincipal.Location = New System.Drawing.Point(0, 0)
            Me.MenuPrincipal.Name = "MenuPrincipal"
            Me.MenuPrincipal.Size = New System.Drawing.Size(1396, 24)
            Me.MenuPrincipal.TabIndex = 2
            Me.MenuPrincipal.Text = "Menu"
            '
            'ConfiguraciónToolStripMenuItem
            '
            Me.ConfiguraciónToolStripMenuItem.Image = CType(resources.GetObject("ConfiguraciónToolStripMenuItem.Image"), System.Drawing.Image)
            Me.ConfiguraciónToolStripMenuItem.Name = "ConfiguraciónToolStripMenuItem"
            Me.ConfiguraciónToolStripMenuItem.Size = New System.Drawing.Size(111, 20)
            Me.ConfiguraciónToolStripMenuItem.Text = "Configuración"
            '
            'BuclesToolStripMenuItem
            '
            Me.BuclesToolStripMenuItem.Image = CType(resources.GetObject("BuclesToolStripMenuItem.Image"), System.Drawing.Image)
            Me.BuclesToolStripMenuItem.Name = "BuclesToolStripMenuItem"
            Me.BuclesToolStripMenuItem.Size = New System.Drawing.Size(102, 20)
            Me.BuclesToolStripMenuItem.Text = "Subprocesos"
            '
            'TimerToInterfaceIpBan
            '
            Me.TimerToInterfaceIpBan.Enabled = True
            Me.TimerToInterfaceIpBan.Interval = 1000
            '
            'TimerGuiAnalizador
            '
            Me.TimerGuiAnalizador.Enabled = True
            Me.TimerGuiAnalizador.Interval = 1
            '
            'StatusStrip2
            '
            Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPrueba, Me.ToolStripStatusLabel1})
            Me.StatusStrip2.Location = New System.Drawing.Point(0, 514)
            Me.StatusStrip2.Name = "StatusStrip2"
            Me.StatusStrip2.Size = New System.Drawing.Size(1396, 22)
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
            'ImageList2
            '
            Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
            Me.ImageList2.ImageSize = New System.Drawing.Size(16, 16)
            Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
            '
            'IpBan
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1396, 536)
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
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            Me.Panel5.ResumeLayout(False)
            Me.Panel5.PerformLayout()
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
            Me.PanelPaisIpBlanca.ResumeLayout(False)
            Me.PanelBotonesBlanca.ResumeLayout(False)
            Me.Fondo.ResumeLayout(False)
            Me.TabApp.ResumeLayout(False)
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
            Me.PanelAutoIndex.ResumeLayout(False)
            Me.tlpAutoIndexacion.ResumeLayout(False)
            Me.TabBackup.ResumeLayout(False)
            Me.TabPMAI.ResumeLayout(False)
            CType(Me.TablaMailBackupMAI, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelFiltroMAIBackup.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.TabPCAL.ResumeLayout(False)
            CType(Me.TablaMailBackupCAL, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelFiltroCALBackup.ResumeLayout(False)
            Me.TableLayoutPanel5.ResumeLayout(False)
            Me.TableLayoutPanel5.PerformLayout()
            Me.TabPTSK.ResumeLayout(False)
            CType(Me.TablaMailBackupTSK, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelFiltroTSK.ResumeLayout(False)
            Me.TableLayoutPanel6.ResumeLayout(False)
            Me.TableLayoutPanel6.PerformLayout()
            Me.TabPVCF.ResumeLayout(False)
            CType(Me.TablaMailBackupVCF, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelFiltroVCFBackup.ResumeLayout(False)
            Me.TableLayoutPanel4.ResumeLayout(False)
            Me.TableLayoutPanel4.PerformLayout()
            Me.StatusStrip1.ResumeLayout(False)
            Me.StatusStrip1.PerformLayout()
            Me.TabMigraciones.ResumeLayout(False)
            Me.SplitMigracion.Panel1.ResumeLayout(False)
            Me.SplitMigracion.Panel2.ResumeLayout(False)
            CType(Me.SplitMigracion, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitMigracion.ResumeLayout(False)
            Me.PanelOpcionesDominio.ResumeLayout(False)
            Me.PanelOpcionesDominio.PerformLayout()
            Me.ToolStrip1.ResumeLayout(False)
            Me.ToolStrip1.PerformLayout()
            Me.SplitProcesoMigracion.Panel1.ResumeLayout(False)
            Me.SplitProcesoMigracion.Panel2.ResumeLayout(False)
            CType(Me.SplitProcesoMigracion, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitProcesoMigracion.ResumeLayout(False)
            Me.SplitContainer3.Panel1.ResumeLayout(False)
            Me.SplitContainer3.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer3.ResumeLayout(False)
            Me.PanelColaMigracion.ResumeLayout(False)
            Me.PanelProgresoMigracion.ResumeLayout(False)
            Me.PanelOpcionesMigracion.ResumeLayout(False)
            Me.PanelOpcionesMigracion.PerformLayout()
            Me.ToolMigraciones.ResumeLayout(False)
            Me.ToolMigraciones.PerformLayout()
            Me.PanelServicioMigracion.ResumeLayout(False)
            Me.TableLayoutPanel3.ResumeLayout(False)
            Me.TableLayoutPanel3.PerformLayout()
            Me.TabCertificados.ResumeLayout(False)
            Me.SplitCertificados.Panel1.ResumeLayout(False)
            Me.SplitCertificados.Panel2.ResumeLayout(False)
            CType(Me.SplitCertificados, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitCertificados.ResumeLayout(False)
            Me.SplitContainer4.Panel1.ResumeLayout(False)
            Me.SplitContainer4.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer4.ResumeLayout(False)
            Me.TabAutoResponder.ResumeLayout(False)
            Me.SplitContainer5.Panel1.ResumeLayout(False)
            Me.SplitContainer5.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer5.ResumeLayout(False)
            Me.SplitContainer6.Panel1.ResumeLayout(False)
            Me.SplitContainer6.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer6.ResumeLayout(False)
            Me.PanellstEmailsColaSMTP.ResumeLayout(False)
            Me.PanellstEmailsColaSMTP.PerformLayout()
            Me.ToolStrip2.ResumeLayout(False)
            Me.ToolStrip2.PerformLayout()
            Me.MenuPrincipal.ResumeLayout(False)
            Me.MenuPrincipal.PerformLayout()
            Me.StatusStrip2.ResumeLayout(False)
            Me.StatusStrip2.PerformLayout()
            CType(Me.FiltrosMailBox, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents TabApp As TabControl
        Friend WithEvents TabPIpBan As TabPage
        Friend WithEvents TabSpamAssassin As TabPage
        Friend WithEvents IconosTab As ImageList
        Friend WithEvents txtRichSpamAssassin As RichTextBox
        Friend WithEvents TimerToInterfaceIpBan As Timer
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
        Friend WithEvents TablaMailBackupMAI As DataGridView
        Friend WithEvents TreePostOffices As TreeView
        Friend WithEvents StatusStrip1 As StatusStrip
        Friend WithEvents lblMailBackupSeleccionados As ToolStripStatusLabel
        Friend WithEvents lblMensajesBackup As ToolStripStatusLabel
        Friend WithEvents FiltrosMailBox As BindingSource
        Friend WithEvents PanelFiltroMAIBackup As Panel
        Friend WithEvents txtMaiAsunto As TextBox
        Friend WithEvents txtMaiRemitente As TextBox
        Friend WithEvents txtMaiDestinatarios As TextBox
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents Label4 As Label
        Friend WithEvents Label5 As Label
        Friend WithEvents Label7 As Label
        Friend WithEvents BtnLimpiarMai As Button
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
        Friend WithEvents lblLimpiadosBackup As ToolStripStatusLabel
        Friend WithEvents VisualizarEnOutlookToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
        Friend WithEvents lblEmails As ToolStripStatusLabel
        Friend WithEvents TabMigraciones As TabPage
        Friend WithEvents ToolMigraciones As ToolStrip
        Friend WithEvents PanelOpcionesMigracion As Panel
        Friend WithEvents PanelServicioMigracion As Panel
        Friend WithEvents lblEstadoServicioMigracion As Label
        Friend WithEvents Label8 As Label
        Friend WithEvents BtnServicioMigracion As Button
        Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
        Friend WithEvents SplitMigracion As SplitContainer
        Friend WithEvents lstMailBoxMigracion As ListView
        Friend WithEvents lstMM_MailBox As ColumnHeader
        Friend WithEvents lstMM_Trabajado As ColumnHeader
        Friend WithEvents lstDominiosMigracion As ListView
        Friend WithEvents lstDM_Dominio As ColumnHeader
        Friend WithEvents lstDM_Estado As ColumnHeader
        Friend WithEvents BtnMigrarCuenta As ToolStripButton
        Friend WithEvents lstListaDeEsperaMigracion As ListView
        Friend WithEvents ColumnHeader1 As ColumnHeader
        Friend WithEvents ColumnHeader2 As ColumnHeader
        Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
        Friend WithEvents BtnLimpiarMigracionesCompletadas As ToolStripButton
        Friend WithEvents SplitProcesoMigracion As SplitContainer
        Friend WithEvents lstErroneosMigracion As ListView
        Friend WithEvents ColumnHeader3 As ColumnHeader
        Friend WithEvents ColumnHeader4 As ColumnHeader
        Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
        Friend WithEvents BtnLimpiarErroneosMigracion As ToolStripButton
        Friend WithEvents Label9 As Label
        Friend WithEvents PanelProgresoMigracion As Panel
        Friend WithEvents Label11 As Label
        Friend WithEvents PanelColaMigracion As Panel
        Friend WithEvents Label10 As Label
        Friend WithEvents SplitContainer3 As SplitContainer
        Friend WithEvents ImageList2 As ImageList
        Friend WithEvents PanelOpcionesDominio As Panel
        Friend WithEvents ToolStrip1 As ToolStrip
        Friend WithEvents BtnCrearDominioMigracion As ToolStripButton
        Friend WithEvents BtnEliminarDominioMigracion As ToolStripButton
        Friend WithEvents BtnActivarMigracionDominio As ToolStripButton
        Friend WithEvents BtnDesactivarMigracionDominio As ToolStripButton
        Friend WithEvents BtnCopiarErroneos As ToolStripButton
        Friend WithEvents TabCertificados As TabPage
        Friend WithEvents SplitCertificados As SplitContainer
        Friend WithEvents TabNavegadores As TabControl
        Friend WithEvents lstCertificados As ListView
        Friend WithEvents cCertificado As ColumnHeader
        Friend WithEvents cCaducaCertificado As ColumnHeader
        Friend WithEvents SplitContainer4 As SplitContainer
        Friend WithEvents lstLogDescargaCertificado As ListView
        Friend WithEvents cLogCertificado As ColumnHeader
        Friend WithEvents cLogCIntento As ColumnHeader
        Friend WithEvents cLogcResultado As ColumnHeader
        Friend WithEvents Label12 As Label
        Friend WithEvents Label13 As Label
        Friend WithEvents TabBackup As TabControl
        Friend WithEvents TabPMAI As TabPage
        Friend WithEvents TabPCAL As TabPage
        Friend WithEvents TabPTSK As TabPage
        Friend WithEvents TabPVCF As TabPage
        Friend WithEvents lblCarpetas As ToolStripStatusLabel
        Friend WithEvents lblAnalizadoresBackup As ToolStripStatusLabel
        Friend WithEvents PanelAutoIndex As Panel
        Friend WithEvents lstAutoIndex As ListView
        Friend WithEvents cAutoIndexTimeInit As ColumnHeader
        Friend WithEvents Label14 As Label
        Friend WithEvents BuclesToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents PanelFiltroVCFBackup As Panel
        Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
        Friend WithEvents Label15 As Label
        Friend WithEvents Label16 As Label
        Friend WithEvents Label17 As Label
        Friend WithEvents Label18 As Label
        Friend WithEvents Label19 As Label
        Friend WithEvents Label20 As Label
        Friend WithEvents txtVcfNombre As TextBox
        Friend WithEvents txtVcfCompleto As TextBox
        Friend WithEvents txtVcfEmail As TextBox
        Friend WithEvents txtVcfPersonal As TextBox
        Friend WithEvents txtVcfTrabajo As TextBox
        Friend WithEvents txtVcfNick As TextBox
        Friend WithEvents TablaMailBackupVCF As DataGridView
        Friend WithEvents PanelFiltroCALBackup As Panel
        Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
        Friend WithEvents Label21 As Label
        Friend WithEvents Label22 As Label
        Friend WithEvents TablaMailBackupCAL As DataGridView
        Friend WithEvents txtCalDescripcion As TextBox
        Friend WithEvents txtCalHubicacion As TextBox
        Friend WithEvents TablaMailBackupTSK As DataGridView
        Friend WithEvents PanelFiltroTSK As Panel
        Friend WithEvents BtnLimpiarCal As Button
        Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
        Friend WithEvents Label23 As Label
        Friend WithEvents Label24 As Label
        Friend WithEvents txtTskAsunto As TextBox
        Friend WithEvents txtTskNotas As TextBox
        Friend WithEvents BtnLimpiarTSK As Button
        Friend WithEvents BtnLimpiarVCF As Button
        Friend WithEvents RestaurarCalendario As ToolStripMenuItem
        Friend WithEvents RestaurarTarea As ToolStripMenuItem
        Friend WithEvents RestaurarContacto As ToolStripMenuItem
        Friend WithEvents ImgLBackupTab As ImageList
        Friend WithEvents lblPostOffices As Label
        Friend WithEvents TabAutoResponder As TabPage
        Friend WithEvents lstEmailsReparadosAutoResponder As ListBox
        Friend WithEvents Label25 As Label
        Friend WithEvents SplitContainer5 As SplitContainer
        Friend WithEvents RichAutoResponderMail As RichTextBox
        Friend WithEvents RichAutoResponderStatus As RichTextBox
        Friend WithEvents Label26 As Label
        Friend WithEvents SplitContainer6 As SplitContainer
        Friend WithEvents RichAutoResponderRespuesta As RichTextBox
        Friend WithEvents Label27 As Label
        Friend WithEvents PanellstEmailsColaSMTP As Panel
        Friend WithEvents Label28 As Label
        Friend WithEvents SplitterAutoResponderLst As Splitter
        Friend WithEvents PanelPaisIpBlanca As Panel
        Friend WithEvents lblPaisIpBlancaSet As Label
        Friend WithEvents lblPaisIpBlanca As Label
        Friend WithEvents tlpAutoIndexacion As TableLayoutPanel
        Friend WithEvents lblAutoindexaciones As Label
        Friend WithEvents ToolStrip2 As ToolStrip
        Friend WithEvents BtnEliminarAutoResponder As ToolStripButton
        Friend WithEvents lblEmailSeleccionadoAutoResponder As ToolStripLabel
        Friend WithEvents BtnLimpiarMemoriaAutoResponder As ToolStripButton
        Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
        Friend WithEvents ExportarAUnArchivoToolStripMenuItem As ToolStripMenuItem
    End Class
End Namespace
