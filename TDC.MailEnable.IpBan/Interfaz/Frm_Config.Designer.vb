Namespace Interfaz
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class Frm_Config
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Config))
            Me.CtrlBuscarCarpeta = New System.Windows.Forms.FolderBrowserDialog()
            Me.PanelBotonesForm = New System.Windows.Forms.Panel()
            Me.BtnCancelar = New System.Windows.Forms.Button()
            Me.BtnGuardarConfig = New System.Windows.Forms.Button()
            Me.CtrlSeparadorPie = New System.Windows.Forms.Panel()
            Me.CtrlBuscarArchivo = New System.Windows.Forms.OpenFileDialog()
            Me.chkArranqueWindows = New System.Windows.Forms.CheckBox()
            Me.TrackLectura = New System.Windows.Forms.TrackBar()
            Me.TrackPropagacion = New System.Windows.Forms.TrackBar()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtLecturaArchivos = New System.Windows.Forms.TextBox()
            Me.txtPropagacionIP = New System.Windows.Forms.TextBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.NumReposoLectura = New System.Windows.Forms.NumericUpDown()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtBackupEmail = New System.Windows.Forms.TextBox()
            Me.CmdCargarCarpetaBackupEmail = New System.Windows.Forms.Button()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.txtAntiguedadEmails = New System.Windows.Forms.TextBox()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.txtAnalizadoresEmail = New System.Windows.Forms.TextBox()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.TrackAnalizadoresEmail = New System.Windows.Forms.TrackBar()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.TrackAnalizadoresMailTimer = New System.Windows.Forms.TrackBar()
            Me.txtTimerAnalizadoresEmail = New System.Windows.Forms.TextBox()
            Me.TabConfiguracion = New System.Windows.Forms.TabControl()
            Me.TabPRutas = New System.Windows.Forms.TabPage()
            Me.CmdBuscarAutoResponder = New System.Windows.Forms.Button()
            Me.txtAutoResponder = New System.Windows.Forms.TextBox()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtIMAP = New System.Windows.Forms.TextBox()
            Me.txtPostOffices = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.CmdBuscarMailEnableApp = New System.Windows.Forms.Button()
            Me.txtSMTP = New System.Windows.Forms.TextBox()
            Me.txtMailEnableApp = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.txtPOP = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtWEB = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtASMTP = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtAPOP = New System.Windows.Forms.TextBox()
            Me.txtAWEB = New System.Windows.Forms.TextBox()
            Me.txtImapApp = New System.Windows.Forms.TextBox()
            Me.txtSpamAssassin = New System.Windows.Forms.TextBox()
            Me.BtnCargarIMAP = New System.Windows.Forms.Button()
            Me.BtnCargarPostOffices = New System.Windows.Forms.Button()
            Me.BtnCargarSMTP = New System.Windows.Forms.Button()
            Me.BtnCargarPOP = New System.Windows.Forms.Button()
            Me.CmdCargarSpamAssassin = New System.Windows.Forms.Button()
            Me.BtnCargarWEB = New System.Windows.Forms.Button()
            Me.CmdCargarImapApp = New System.Windows.Forms.Button()
            Me.BtnCargarASMTP = New System.Windows.Forms.Button()
            Me.BtnCargarAWEB = New System.Windows.Forms.Button()
            Me.BtnCargarAPOP = New System.Windows.Forms.Button()
            Me.TabPLogs = New System.Windows.Forms.TabPage()
            Me.TabPBackup = New System.Windows.Forms.TabPage()
            Me.PanelBotonesForm.SuspendLayout()
            CType(Me.TrackLectura, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TrackPropagacion, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumReposoLectura, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TrackAnalizadoresEmail, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TrackAnalizadoresMailTimer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabConfiguracion.SuspendLayout()
            Me.TabPRutas.SuspendLayout()
            Me.TabPLogs.SuspendLayout()
            Me.TabPBackup.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelBotonesForm
            '
            Me.PanelBotonesForm.Controls.Add(Me.BtnCancelar)
            Me.PanelBotonesForm.Controls.Add(Me.BtnGuardarConfig)
            Me.PanelBotonesForm.Controls.Add(Me.CtrlSeparadorPie)
            Me.PanelBotonesForm.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelBotonesForm.Location = New System.Drawing.Point(0, 435)
            Me.PanelBotonesForm.Name = "PanelBotonesForm"
            Me.PanelBotonesForm.Size = New System.Drawing.Size(780, 40)
            Me.PanelBotonesForm.TabIndex = 3
            '
            'BtnCancelar
            '
            Me.BtnCancelar.Location = New System.Drawing.Point(695, 5)
            Me.BtnCancelar.Name = "BtnCancelar"
            Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
            Me.BtnCancelar.TabIndex = 1
            Me.BtnCancelar.Text = "Cancelar"
            Me.BtnCancelar.UseVisualStyleBackColor = True
            '
            'BtnGuardarConfig
            '
            Me.BtnGuardarConfig.Enabled = False
            Me.BtnGuardarConfig.Location = New System.Drawing.Point(614, 5)
            Me.BtnGuardarConfig.Name = "BtnGuardarConfig"
            Me.BtnGuardarConfig.Size = New System.Drawing.Size(75, 23)
            Me.BtnGuardarConfig.TabIndex = 1
            Me.BtnGuardarConfig.Text = "Guardar"
            Me.BtnGuardarConfig.UseVisualStyleBackColor = True
            '
            'CtrlSeparadorPie
            '
            Me.CtrlSeparadorPie.BackColor = System.Drawing.Color.Silver
            Me.CtrlSeparadorPie.Dock = System.Windows.Forms.DockStyle.Top
            Me.CtrlSeparadorPie.Location = New System.Drawing.Point(0, 0)
            Me.CtrlSeparadorPie.Name = "CtrlSeparadorPie"
            Me.CtrlSeparadorPie.Size = New System.Drawing.Size(780, 1)
            Me.CtrlSeparadorPie.TabIndex = 0
            '
            'CtrlBuscarArchivo
            '
            Me.CtrlBuscarArchivo.FileName = "OpenFileDialog1"
            '
            'chkArranqueWindows
            '
            Me.chkArranqueWindows.AutoSize = True
            Me.chkArranqueWindows.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.chkArranqueWindows.Location = New System.Drawing.Point(0, 418)
            Me.chkArranqueWindows.Name = "chkArranqueWindows"
            Me.chkArranqueWindows.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
            Me.chkArranqueWindows.Size = New System.Drawing.Size(780, 17)
            Me.chkArranqueWindows.TabIndex = 5
            Me.chkArranqueWindows.Text = "Arrancar con Windows"
            Me.chkArranqueWindows.UseVisualStyleBackColor = True
            '
            'TrackLectura
            '
            Me.TrackLectura.BackColor = System.Drawing.Color.White
            Me.TrackLectura.LargeChange = 100
            Me.TrackLectura.Location = New System.Drawing.Point(117, 14)
            Me.TrackLectura.Maximum = 300
            Me.TrackLectura.Name = "TrackLectura"
            Me.TrackLectura.Size = New System.Drawing.Size(479, 45)
            Me.TrackLectura.SmallChange = 10
            Me.TrackLectura.TabIndex = 8
            Me.TrackLectura.TickFrequency = 10
            Me.TrackLectura.TickStyle = System.Windows.Forms.TickStyle.Both
            Me.TrackLectura.Value = 100
            '
            'TrackPropagacion
            '
            Me.TrackPropagacion.BackColor = System.Drawing.Color.White
            Me.TrackPropagacion.LargeChange = 100
            Me.TrackPropagacion.Location = New System.Drawing.Point(117, 60)
            Me.TrackPropagacion.Maximum = 300
            Me.TrackPropagacion.Name = "TrackPropagacion"
            Me.TrackPropagacion.Size = New System.Drawing.Size(568, 45)
            Me.TrackPropagacion.SmallChange = 10
            Me.TrackPropagacion.TabIndex = 8
            Me.TrackPropagacion.TickFrequency = 10
            Me.TrackPropagacion.TickStyle = System.Windows.Forms.TickStyle.Both
            Me.TrackPropagacion.Value = 100
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(10, 28)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(101, 13)
            Me.Label11.TabIndex = 9
            Me.Label11.Text = "Lectura de archivos"
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(31, 74)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(80, 13)
            Me.Label12.TabIndex = 10
            Me.Label12.Text = "Propagación IP"
            '
            'txtLecturaArchivos
            '
            Me.txtLecturaArchivos.Location = New System.Drawing.Point(602, 25)
            Me.txtLecturaArchivos.Name = "txtLecturaArchivos"
            Me.txtLecturaArchivos.Size = New System.Drawing.Size(75, 20)
            Me.txtLecturaArchivos.TabIndex = 11
            '
            'txtPropagacionIP
            '
            Me.txtPropagacionIP.Location = New System.Drawing.Point(691, 71)
            Me.txtPropagacionIP.Name = "txtPropagacionIP"
            Me.txtPropagacionIP.Size = New System.Drawing.Size(75, 20)
            Me.txtPropagacionIP.TabIndex = 11
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(688, 7)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(44, 13)
            Me.Label13.TabIndex = 12
            Me.Label13.Text = "Reposo"
            '
            'NumReposoLectura
            '
            Me.NumReposoLectura.Increment = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.NumReposoLectura.Location = New System.Drawing.Point(683, 23)
            Me.NumReposoLectura.Maximum = New Decimal(New Integer() {600000, 0, 0, 0})
            Me.NumReposoLectura.Minimum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.NumReposoLectura.Name = "NumReposoLectura"
            Me.NumReposoLectura.Size = New System.Drawing.Size(81, 20)
            Me.NumReposoLectura.TabIndex = 13
            Me.NumReposoLectura.Value = New Decimal(New Integer() {1000, 0, 0, 0})
            '
            'Label14
            '
            Me.Label14.AutoSize = True
            Me.Label14.Location = New System.Drawing.Point(8, 28)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(44, 13)
            Me.Label14.TabIndex = 0
            Me.Label14.Text = "Backup"
            '
            'txtBackupEmail
            '
            Me.txtBackupEmail.Location = New System.Drawing.Point(112, 25)
            Me.txtBackupEmail.Name = "txtBackupEmail"
            Me.txtBackupEmail.Size = New System.Drawing.Size(562, 20)
            Me.txtBackupEmail.TabIndex = 1
            '
            'CmdCargarCarpetaBackupEmail
            '
            Me.CmdCargarCarpetaBackupEmail.Location = New System.Drawing.Point(689, 25)
            Me.CmdCargarCarpetaBackupEmail.Name = "CmdCargarCarpetaBackupEmail"
            Me.CmdCargarCarpetaBackupEmail.Size = New System.Drawing.Size(75, 22)
            Me.CmdCargarCarpetaBackupEmail.TabIndex = 4
            Me.CmdCargarCarpetaBackupEmail.Text = "Buscar"
            Me.CmdCargarCarpetaBackupEmail.UseVisualStyleBackColor = True
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Location = New System.Drawing.Point(8, 185)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(210, 13)
            Me.Label15.TabIndex = 14
            Me.Label15.Text = "Mantener una ANTIGUEDAD de Emails de"
            '
            'txtAntiguedadEmails
            '
            Me.txtAntiguedadEmails.Location = New System.Drawing.Point(224, 178)
            Me.txtAntiguedadEmails.Name = "txtAntiguedadEmails"
            Me.txtAntiguedadEmails.Size = New System.Drawing.Size(40, 20)
            Me.txtAntiguedadEmails.TabIndex = 15
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(270, 185)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(28, 13)
            Me.Label16.TabIndex = 16
            Me.Label16.Text = "días"
            '
            'txtAnalizadoresEmail
            '
            Me.txtAnalizadoresEmail.Location = New System.Drawing.Point(689, 53)
            Me.txtAnalizadoresEmail.Name = "txtAnalizadoresEmail"
            Me.txtAnalizadoresEmail.Size = New System.Drawing.Size(75, 20)
            Me.txtAnalizadoresEmail.TabIndex = 22
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(10, 60)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(95, 13)
            Me.Label18.TabIndex = 21
            Me.Label18.Text = "Analizadores Email"
            '
            'TrackAnalizadoresEmail
            '
            Me.TrackAnalizadoresEmail.BackColor = System.Drawing.Color.White
            Me.TrackAnalizadoresEmail.Cursor = System.Windows.Forms.Cursors.Default
            Me.TrackAnalizadoresEmail.LargeChange = 100
            Me.TrackAnalizadoresEmail.Location = New System.Drawing.Point(113, 51)
            Me.TrackAnalizadoresEmail.Maximum = 1000
            Me.TrackAnalizadoresEmail.Minimum = 1
            Me.TrackAnalizadoresEmail.Name = "TrackAnalizadoresEmail"
            Me.TrackAnalizadoresEmail.Size = New System.Drawing.Size(561, 45)
            Me.TrackAnalizadoresEmail.SmallChange = 5
            Me.TrackAnalizadoresEmail.TabIndex = 20
            Me.TrackAnalizadoresEmail.TickFrequency = 10
            Me.TrackAnalizadoresEmail.TickStyle = System.Windows.Forms.TickStyle.Both
            Me.TrackAnalizadoresEmail.Value = 5
            '
            'Label19
            '
            Me.Label19.AutoSize = True
            Me.Label19.Location = New System.Drawing.Point(56, 109)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(54, 13)
            Me.Label19.TabIndex = 23
            Me.Label19.Text = "Velocidad"
            '
            'TrackAnalizadoresMailTimer
            '
            Me.TrackAnalizadoresMailTimer.BackColor = System.Drawing.Color.White
            Me.TrackAnalizadoresMailTimer.LargeChange = 100
            Me.TrackAnalizadoresMailTimer.Location = New System.Drawing.Point(112, 102)
            Me.TrackAnalizadoresMailTimer.Maximum = 1000
            Me.TrackAnalizadoresMailTimer.Name = "TrackAnalizadoresMailTimer"
            Me.TrackAnalizadoresMailTimer.Size = New System.Drawing.Size(562, 45)
            Me.TrackAnalizadoresMailTimer.SmallChange = 5
            Me.TrackAnalizadoresMailTimer.TabIndex = 24
            Me.TrackAnalizadoresMailTimer.TickFrequency = 10
            Me.TrackAnalizadoresMailTimer.TickStyle = System.Windows.Forms.TickStyle.Both
            Me.TrackAnalizadoresMailTimer.Value = 5
            '
            'txtTimerAnalizadoresEmail
            '
            Me.txtTimerAnalizadoresEmail.Location = New System.Drawing.Point(689, 102)
            Me.txtTimerAnalizadoresEmail.Name = "txtTimerAnalizadoresEmail"
            Me.txtTimerAnalizadoresEmail.Size = New System.Drawing.Size(75, 20)
            Me.txtTimerAnalizadoresEmail.TabIndex = 26
            '
            'TabConfiguracion
            '
            Me.TabConfiguracion.Controls.Add(Me.TabPRutas)
            Me.TabConfiguracion.Controls.Add(Me.TabPLogs)
            Me.TabConfiguracion.Controls.Add(Me.TabPBackup)
            Me.TabConfiguracion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabConfiguracion.Location = New System.Drawing.Point(0, 0)
            Me.TabConfiguracion.Name = "TabConfiguracion"
            Me.TabConfiguracion.SelectedIndex = 0
            Me.TabConfiguracion.Size = New System.Drawing.Size(780, 418)
            Me.TabConfiguracion.TabIndex = 27
            '
            'TabPRutas
            '
            Me.TabPRutas.Controls.Add(Me.CmdBuscarAutoResponder)
            Me.TabPRutas.Controls.Add(Me.txtAutoResponder)
            Me.TabPRutas.Controls.Add(Me.Label20)
            Me.TabPRutas.Controls.Add(Me.Label10)
            Me.TabPRutas.Controls.Add(Me.Label1)
            Me.TabPRutas.Controls.Add(Me.Label2)
            Me.TabPRutas.Controls.Add(Me.Label3)
            Me.TabPRutas.Controls.Add(Me.Label4)
            Me.TabPRutas.Controls.Add(Me.txtIMAP)
            Me.TabPRutas.Controls.Add(Me.txtPostOffices)
            Me.TabPRutas.Controls.Add(Me.Label5)
            Me.TabPRutas.Controls.Add(Me.CmdBuscarMailEnableApp)
            Me.TabPRutas.Controls.Add(Me.txtSMTP)
            Me.TabPRutas.Controls.Add(Me.txtMailEnableApp)
            Me.TabPRutas.Controls.Add(Me.Label6)
            Me.TabPRutas.Controls.Add(Me.Label17)
            Me.TabPRutas.Controls.Add(Me.txtPOP)
            Me.TabPRutas.Controls.Add(Me.Label7)
            Me.TabPRutas.Controls.Add(Me.txtWEB)
            Me.TabPRutas.Controls.Add(Me.Label8)
            Me.TabPRutas.Controls.Add(Me.txtASMTP)
            Me.TabPRutas.Controls.Add(Me.Label9)
            Me.TabPRutas.Controls.Add(Me.txtAPOP)
            Me.TabPRutas.Controls.Add(Me.txtAWEB)
            Me.TabPRutas.Controls.Add(Me.txtImapApp)
            Me.TabPRutas.Controls.Add(Me.txtSpamAssassin)
            Me.TabPRutas.Controls.Add(Me.BtnCargarIMAP)
            Me.TabPRutas.Controls.Add(Me.BtnCargarPostOffices)
            Me.TabPRutas.Controls.Add(Me.BtnCargarSMTP)
            Me.TabPRutas.Controls.Add(Me.BtnCargarPOP)
            Me.TabPRutas.Controls.Add(Me.CmdCargarSpamAssassin)
            Me.TabPRutas.Controls.Add(Me.BtnCargarWEB)
            Me.TabPRutas.Controls.Add(Me.CmdCargarImapApp)
            Me.TabPRutas.Controls.Add(Me.BtnCargarASMTP)
            Me.TabPRutas.Controls.Add(Me.BtnCargarAWEB)
            Me.TabPRutas.Controls.Add(Me.BtnCargarAPOP)
            Me.TabPRutas.Location = New System.Drawing.Point(4, 22)
            Me.TabPRutas.Name = "TabPRutas"
            Me.TabPRutas.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPRutas.Size = New System.Drawing.Size(772, 392)
            Me.TabPRutas.TabIndex = 0
            Me.TabPRutas.Text = "Rutas"
            Me.TabPRutas.UseVisualStyleBackColor = True
            '
            'CmdBuscarAutoResponder
            '
            Me.CmdBuscarAutoResponder.Location = New System.Drawing.Point(687, 321)
            Me.CmdBuscarAutoResponder.Name = "CmdBuscarAutoResponder"
            Me.CmdBuscarAutoResponder.Size = New System.Drawing.Size(75, 22)
            Me.CmdBuscarAutoResponder.TabIndex = 22
            Me.CmdBuscarAutoResponder.Text = "Buscar"
            Me.CmdBuscarAutoResponder.UseVisualStyleBackColor = True
            '
            'txtAutoResponder
            '
            Me.txtAutoResponder.Location = New System.Drawing.Point(110, 323)
            Me.txtAutoResponder.Name = "txtAutoResponder"
            Me.txtAutoResponder.Size = New System.Drawing.Size(571, 20)
            Me.txtAutoResponder.TabIndex = 21
            '
            'Label20
            '
            Me.Label20.AutoSize = True
            Me.Label20.Location = New System.Drawing.Point(6, 330)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(79, 13)
            Me.Label20.TabIndex = 20
            Me.Label20.Text = "Auto responder"
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(7, 14)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(75, 13)
            Me.Label10.TabIndex = 0
            Me.Label10.Text = "Post OFFICES"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(6, 73)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(94, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Carpeta Log IMAP"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(6, 103)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(98, 13)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Carpeta Log SMTP"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(6, 136)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(90, 13)
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "Carpeta Log POP"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(6, 166)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(93, 13)
            Me.Label4.TabIndex = 0
            Me.Label4.Text = "Carpeta Log WEB"
            '
            'txtIMAP
            '
            Me.txtIMAP.Location = New System.Drawing.Point(110, 70)
            Me.txtIMAP.Name = "txtIMAP"
            Me.txtIMAP.Size = New System.Drawing.Size(571, 20)
            Me.txtIMAP.TabIndex = 1
            '
            'txtPostOffices
            '
            Me.txtPostOffices.Location = New System.Drawing.Point(111, 11)
            Me.txtPostOffices.Name = "txtPostOffices"
            Me.txtPostOffices.Size = New System.Drawing.Size(571, 20)
            Me.txtPostOffices.TabIndex = 1
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(6, 196)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(76, 13)
            Me.Label5.TabIndex = 0
            Me.Label5.Text = "Archivo SMTP"
            '
            'CmdBuscarMailEnableApp
            '
            Me.CmdBuscarMailEnableApp.Location = New System.Drawing.Point(689, 40)
            Me.CmdBuscarMailEnableApp.Name = "CmdBuscarMailEnableApp"
            Me.CmdBuscarMailEnableApp.Size = New System.Drawing.Size(75, 23)
            Me.CmdBuscarMailEnableApp.TabIndex = 19
            Me.CmdBuscarMailEnableApp.Text = "Buscar"
            Me.CmdBuscarMailEnableApp.UseVisualStyleBackColor = True
            '
            'txtSMTP
            '
            Me.txtSMTP.Location = New System.Drawing.Point(110, 100)
            Me.txtSMTP.Name = "txtSMTP"
            Me.txtSMTP.Size = New System.Drawing.Size(571, 20)
            Me.txtSMTP.TabIndex = 1
            '
            'txtMailEnableApp
            '
            Me.txtMailEnableApp.Location = New System.Drawing.Point(111, 42)
            Me.txtMailEnableApp.Name = "txtMailEnableApp"
            Me.txtMailEnableApp.Size = New System.Drawing.Size(570, 20)
            Me.txtMailEnableApp.TabIndex = 18
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(6, 222)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(68, 13)
            Me.Label6.TabIndex = 0
            Me.Label6.Text = "Archivo POP"
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.Location = New System.Drawing.Point(7, 45)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(83, 13)
            Me.Label17.TabIndex = 17
            Me.Label17.Text = "MailEnable APP"
            '
            'txtPOP
            '
            Me.txtPOP.Location = New System.Drawing.Point(110, 133)
            Me.txtPOP.Name = "txtPOP"
            Me.txtPOP.Size = New System.Drawing.Size(571, 20)
            Me.txtPOP.TabIndex = 1
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(6, 248)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(71, 13)
            Me.Label7.TabIndex = 0
            Me.Label7.Text = "Archivo WEB"
            '
            'txtWEB
            '
            Me.txtWEB.Location = New System.Drawing.Point(110, 163)
            Me.txtWEB.Name = "txtWEB"
            Me.txtWEB.Size = New System.Drawing.Size(571, 20)
            Me.txtWEB.TabIndex = 1
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(6, 274)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(52, 13)
            Me.Label8.TabIndex = 0
            Me.Label8.Text = "Imap App"
            '
            'txtASMTP
            '
            Me.txtASMTP.Location = New System.Drawing.Point(110, 193)
            Me.txtASMTP.Name = "txtASMTP"
            Me.txtASMTP.Size = New System.Drawing.Size(571, 20)
            Me.txtASMTP.TabIndex = 1
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(6, 300)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(78, 13)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Spam Assassin"
            '
            'txtAPOP
            '
            Me.txtAPOP.Location = New System.Drawing.Point(110, 219)
            Me.txtAPOP.Name = "txtAPOP"
            Me.txtAPOP.Size = New System.Drawing.Size(571, 20)
            Me.txtAPOP.TabIndex = 1
            '
            'txtAWEB
            '
            Me.txtAWEB.Location = New System.Drawing.Point(110, 245)
            Me.txtAWEB.Name = "txtAWEB"
            Me.txtAWEB.Size = New System.Drawing.Size(571, 20)
            Me.txtAWEB.TabIndex = 1
            '
            'txtImapApp
            '
            Me.txtImapApp.Location = New System.Drawing.Point(110, 271)
            Me.txtImapApp.Name = "txtImapApp"
            Me.txtImapApp.Size = New System.Drawing.Size(571, 20)
            Me.txtImapApp.TabIndex = 1
            '
            'txtSpamAssassin
            '
            Me.txtSpamAssassin.Location = New System.Drawing.Point(110, 297)
            Me.txtSpamAssassin.Name = "txtSpamAssassin"
            Me.txtSpamAssassin.Size = New System.Drawing.Size(571, 20)
            Me.txtSpamAssassin.TabIndex = 1
            '
            'BtnCargarIMAP
            '
            Me.BtnCargarIMAP.Location = New System.Drawing.Point(687, 70)
            Me.BtnCargarIMAP.Name = "BtnCargarIMAP"
            Me.BtnCargarIMAP.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarIMAP.TabIndex = 4
            Me.BtnCargarIMAP.Text = "Buscar"
            Me.BtnCargarIMAP.UseVisualStyleBackColor = True
            '
            'BtnCargarPostOffices
            '
            Me.BtnCargarPostOffices.Location = New System.Drawing.Point(688, 11)
            Me.BtnCargarPostOffices.Name = "BtnCargarPostOffices"
            Me.BtnCargarPostOffices.Size = New System.Drawing.Size(75, 21)
            Me.BtnCargarPostOffices.TabIndex = 4
            Me.BtnCargarPostOffices.Text = "Buscar"
            Me.BtnCargarPostOffices.UseVisualStyleBackColor = True
            '
            'BtnCargarSMTP
            '
            Me.BtnCargarSMTP.Location = New System.Drawing.Point(687, 100)
            Me.BtnCargarSMTP.Name = "BtnCargarSMTP"
            Me.BtnCargarSMTP.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarSMTP.TabIndex = 4
            Me.BtnCargarSMTP.Text = "Buscar"
            Me.BtnCargarSMTP.UseVisualStyleBackColor = True
            '
            'BtnCargarPOP
            '
            Me.BtnCargarPOP.Location = New System.Drawing.Point(687, 133)
            Me.BtnCargarPOP.Name = "BtnCargarPOP"
            Me.BtnCargarPOP.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarPOP.TabIndex = 4
            Me.BtnCargarPOP.Text = "Buscar"
            Me.BtnCargarPOP.UseVisualStyleBackColor = True
            '
            'CmdCargarSpamAssassin
            '
            Me.CmdCargarSpamAssassin.Location = New System.Drawing.Point(687, 296)
            Me.CmdCargarSpamAssassin.Name = "CmdCargarSpamAssassin"
            Me.CmdCargarSpamAssassin.Size = New System.Drawing.Size(75, 22)
            Me.CmdCargarSpamAssassin.TabIndex = 4
            Me.CmdCargarSpamAssassin.Text = "Buscar"
            Me.CmdCargarSpamAssassin.UseVisualStyleBackColor = True
            '
            'BtnCargarWEB
            '
            Me.BtnCargarWEB.Location = New System.Drawing.Point(687, 163)
            Me.BtnCargarWEB.Name = "BtnCargarWEB"
            Me.BtnCargarWEB.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarWEB.TabIndex = 4
            Me.BtnCargarWEB.Text = "Buscar"
            Me.BtnCargarWEB.UseVisualStyleBackColor = True
            '
            'CmdCargarImapApp
            '
            Me.CmdCargarImapApp.Location = New System.Drawing.Point(687, 270)
            Me.CmdCargarImapApp.Name = "CmdCargarImapApp"
            Me.CmdCargarImapApp.Size = New System.Drawing.Size(75, 22)
            Me.CmdCargarImapApp.TabIndex = 4
            Me.CmdCargarImapApp.Text = "Buscar"
            Me.CmdCargarImapApp.UseVisualStyleBackColor = True
            '
            'BtnCargarASMTP
            '
            Me.BtnCargarASMTP.Location = New System.Drawing.Point(687, 192)
            Me.BtnCargarASMTP.Name = "BtnCargarASMTP"
            Me.BtnCargarASMTP.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarASMTP.TabIndex = 4
            Me.BtnCargarASMTP.Text = "Buscar"
            Me.BtnCargarASMTP.UseVisualStyleBackColor = True
            '
            'BtnCargarAWEB
            '
            Me.BtnCargarAWEB.Location = New System.Drawing.Point(687, 244)
            Me.BtnCargarAWEB.Name = "BtnCargarAWEB"
            Me.BtnCargarAWEB.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarAWEB.TabIndex = 4
            Me.BtnCargarAWEB.Text = "Buscar"
            Me.BtnCargarAWEB.UseVisualStyleBackColor = True
            '
            'BtnCargarAPOP
            '
            Me.BtnCargarAPOP.Location = New System.Drawing.Point(687, 218)
            Me.BtnCargarAPOP.Name = "BtnCargarAPOP"
            Me.BtnCargarAPOP.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarAPOP.TabIndex = 4
            Me.BtnCargarAPOP.Text = "Buscar"
            Me.BtnCargarAPOP.UseVisualStyleBackColor = True
            '
            'TabPLogs
            '
            Me.TabPLogs.Controls.Add(Me.Label11)
            Me.TabPLogs.Controls.Add(Me.TrackLectura)
            Me.TabPLogs.Controls.Add(Me.TrackPropagacion)
            Me.TabPLogs.Controls.Add(Me.Label12)
            Me.TabPLogs.Controls.Add(Me.txtLecturaArchivos)
            Me.TabPLogs.Controls.Add(Me.txtPropagacionIP)
            Me.TabPLogs.Controls.Add(Me.Label13)
            Me.TabPLogs.Controls.Add(Me.NumReposoLectura)
            Me.TabPLogs.Location = New System.Drawing.Point(4, 22)
            Me.TabPLogs.Name = "TabPLogs"
            Me.TabPLogs.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPLogs.Size = New System.Drawing.Size(772, 392)
            Me.TabPLogs.TabIndex = 1
            Me.TabPLogs.Text = "LOG'S"
            Me.TabPLogs.UseVisualStyleBackColor = True
            '
            'TabPBackup
            '
            Me.TabPBackup.Controls.Add(Me.Label14)
            Me.TabPBackup.Controls.Add(Me.txtTimerAnalizadoresEmail)
            Me.TabPBackup.Controls.Add(Me.Label16)
            Me.TabPBackup.Controls.Add(Me.txtBackupEmail)
            Me.TabPBackup.Controls.Add(Me.txtAntiguedadEmails)
            Me.TabPBackup.Controls.Add(Me.CmdCargarCarpetaBackupEmail)
            Me.TabPBackup.Controls.Add(Me.Label15)
            Me.TabPBackup.Controls.Add(Me.TrackAnalizadoresMailTimer)
            Me.TabPBackup.Controls.Add(Me.TrackAnalizadoresEmail)
            Me.TabPBackup.Controls.Add(Me.Label19)
            Me.TabPBackup.Controls.Add(Me.Label18)
            Me.TabPBackup.Controls.Add(Me.txtAnalizadoresEmail)
            Me.TabPBackup.Location = New System.Drawing.Point(4, 22)
            Me.TabPBackup.Name = "TabPBackup"
            Me.TabPBackup.Size = New System.Drawing.Size(772, 392)
            Me.TabPBackup.TabIndex = 2
            Me.TabPBackup.Text = "BACKUP"
            Me.TabPBackup.UseVisualStyleBackColor = True
            '
            'Frm_Config
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(780, 475)
            Me.Controls.Add(Me.TabConfiguracion)
            Me.Controls.Add(Me.chkArranqueWindows)
            Me.Controls.Add(Me.PanelBotonesForm)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "Frm_Config"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Configuración"
            Me.PanelBotonesForm.ResumeLayout(False)
            CType(Me.TrackLectura, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TrackPropagacion, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumReposoLectura, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TrackAnalizadoresEmail, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TrackAnalizadoresMailTimer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabConfiguracion.ResumeLayout(False)
            Me.TabPRutas.ResumeLayout(False)
            Me.TabPRutas.PerformLayout()
            Me.TabPLogs.ResumeLayout(False)
            Me.TabPLogs.PerformLayout()
            Me.TabPBackup.ResumeLayout(False)
            Me.TabPBackup.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents CtrlBuscarCarpeta As FolderBrowserDialog
        Friend WithEvents PanelBotonesForm As Panel
        Friend WithEvents BtnGuardarConfig As Button
        Friend WithEvents CtrlSeparadorPie As Panel
        Friend WithEvents BtnCancelar As Button
        Friend WithEvents CtrlBuscarArchivo As OpenFileDialog
        Friend WithEvents chkArranqueWindows As CheckBox
        Friend WithEvents TrackLectura As TrackBar
        Friend WithEvents TrackPropagacion As TrackBar
        Friend WithEvents Label11 As Label
        Friend WithEvents Label12 As Label
        Friend WithEvents txtLecturaArchivos As TextBox
        Friend WithEvents txtPropagacionIP As TextBox
        Friend WithEvents Label13 As Label
        Friend WithEvents NumReposoLectura As NumericUpDown
        Friend WithEvents Label14 As Label
        Friend WithEvents txtBackupEmail As TextBox
        Friend WithEvents CmdCargarCarpetaBackupEmail As Button
        Friend WithEvents Label15 As Label
        Friend WithEvents txtAntiguedadEmails As TextBox
        Friend WithEvents Label16 As Label
        Friend WithEvents txtAnalizadoresEmail As TextBox
        Friend WithEvents Label18 As Label
        Friend WithEvents TrackAnalizadoresEmail As TrackBar
        Friend WithEvents Label19 As Label
        Friend WithEvents TrackAnalizadoresMailTimer As TrackBar
        Friend WithEvents txtTimerAnalizadoresEmail As TextBox
        Friend WithEvents TabConfiguracion As TabControl
        Friend WithEvents TabPRutas As TabPage
        Friend WithEvents TabPLogs As TabPage
        Friend WithEvents TabPBackup As TabPage
        Friend WithEvents Label10 As Label
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents Label4 As Label
        Friend WithEvents txtIMAP As TextBox
        Friend WithEvents txtPostOffices As TextBox
        Friend WithEvents Label5 As Label
        Friend WithEvents CmdBuscarMailEnableApp As Button
        Friend WithEvents txtSMTP As TextBox
        Friend WithEvents txtMailEnableApp As TextBox
        Friend WithEvents Label6 As Label
        Friend WithEvents Label17 As Label
        Friend WithEvents txtPOP As TextBox
        Friend WithEvents Label7 As Label
        Friend WithEvents txtWEB As TextBox
        Friend WithEvents Label8 As Label
        Friend WithEvents txtASMTP As TextBox
        Friend WithEvents Label9 As Label
        Friend WithEvents txtAPOP As TextBox
        Friend WithEvents txtAWEB As TextBox
        Friend WithEvents txtImapApp As TextBox
        Friend WithEvents txtSpamAssassin As TextBox
        Friend WithEvents BtnCargarIMAP As Button
        Friend WithEvents BtnCargarPostOffices As Button
        Friend WithEvents BtnCargarSMTP As Button
        Friend WithEvents BtnCargarPOP As Button
        Friend WithEvents CmdCargarSpamAssassin As Button
        Friend WithEvents BtnCargarWEB As Button
        Friend WithEvents CmdCargarImapApp As Button
        Friend WithEvents BtnCargarASMTP As Button
        Friend WithEvents BtnCargarAWEB As Button
        Friend WithEvents BtnCargarAPOP As Button
        Friend WithEvents CmdBuscarAutoResponder As Button
        Friend WithEvents txtAutoResponder As TextBox
        Friend WithEvents Label20 As Label
    End Class
End Namespace