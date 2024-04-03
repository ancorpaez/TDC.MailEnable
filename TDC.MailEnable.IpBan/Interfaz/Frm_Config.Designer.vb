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
            Me.CtrlBuscarCarpeta = New System.Windows.Forms.FolderBrowserDialog()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtIMAP = New System.Windows.Forms.TextBox()
            Me.txtSMTP = New System.Windows.Forms.TextBox()
            Me.txtPOP = New System.Windows.Forms.TextBox()
            Me.txtWEB = New System.Windows.Forms.TextBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnCancelar = New System.Windows.Forms.Button()
            Me.BtnGuardarConfig = New System.Windows.Forms.Button()
            Me.CtrlSeparadorPie = New System.Windows.Forms.Panel()
            Me.BtnCargarIMAP = New System.Windows.Forms.Button()
            Me.BtnCargarSMTP = New System.Windows.Forms.Button()
            Me.BtnCargarPOP = New System.Windows.Forms.Button()
            Me.BtnCargarWEB = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtASMTP = New System.Windows.Forms.TextBox()
            Me.BtnCargarASMTP = New System.Windows.Forms.Button()
            Me.CtrlBuscarArchivo = New System.Windows.Forms.OpenFileDialog()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtAPOP = New System.Windows.Forms.TextBox()
            Me.BtnCargarAPOP = New System.Windows.Forms.Button()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtAWEB = New System.Windows.Forms.TextBox()
            Me.BtnCargarAWEB = New System.Windows.Forms.Button()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtImapApp = New System.Windows.Forms.TextBox()
            Me.CmdCargarImapApp = New System.Windows.Forms.Button()
            Me.chkArranqueWindows = New System.Windows.Forms.CheckBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtSpamAssassin = New System.Windows.Forms.TextBox()
            Me.CmdCargarSpamAssassin = New System.Windows.Forms.Button()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtPostOffices = New System.Windows.Forms.TextBox()
            Me.BtnCargarPostOffices = New System.Windows.Forms.Button()
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
            Me.Label17 = New System.Windows.Forms.Label()
            Me.txtMailEnableApp = New System.Windows.Forms.TextBox()
            Me.CmdBuscarMailEnableApp = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            CType(Me.TrackLectura, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TrackPropagacion, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumReposoLectura, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(12, 84)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(94, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Carpeta Log IMAP"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(12, 114)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(98, 13)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Carpeta Log SMTP"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(12, 147)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(90, 13)
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "Carpeta Log POP"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(12, 177)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(93, 13)
            Me.Label4.TabIndex = 0
            Me.Label4.Text = "Carpeta Log WEB"
            '
            'txtIMAP
            '
            Me.txtIMAP.Location = New System.Drawing.Point(116, 81)
            Me.txtIMAP.Name = "txtIMAP"
            Me.txtIMAP.Size = New System.Drawing.Size(571, 20)
            Me.txtIMAP.TabIndex = 1
            '
            'txtSMTP
            '
            Me.txtSMTP.Location = New System.Drawing.Point(116, 111)
            Me.txtSMTP.Name = "txtSMTP"
            Me.txtSMTP.Size = New System.Drawing.Size(571, 20)
            Me.txtSMTP.TabIndex = 1
            '
            'txtPOP
            '
            Me.txtPOP.Location = New System.Drawing.Point(116, 144)
            Me.txtPOP.Name = "txtPOP"
            Me.txtPOP.Size = New System.Drawing.Size(571, 20)
            Me.txtPOP.TabIndex = 1
            '
            'txtWEB
            '
            Me.txtWEB.Location = New System.Drawing.Point(116, 174)
            Me.txtWEB.Name = "txtWEB"
            Me.txtWEB.Size = New System.Drawing.Size(571, 20)
            Me.txtWEB.TabIndex = 1
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.BtnCancelar)
            Me.Panel1.Controls.Add(Me.BtnGuardarConfig)
            Me.Panel1.Controls.Add(Me.CtrlSeparadorPie)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 537)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(780, 40)
            Me.Panel1.TabIndex = 3
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
            'BtnCargarIMAP
            '
            Me.BtnCargarIMAP.Location = New System.Drawing.Point(693, 81)
            Me.BtnCargarIMAP.Name = "BtnCargarIMAP"
            Me.BtnCargarIMAP.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarIMAP.TabIndex = 4
            Me.BtnCargarIMAP.Text = "Buscar"
            Me.BtnCargarIMAP.UseVisualStyleBackColor = True
            '
            'BtnCargarSMTP
            '
            Me.BtnCargarSMTP.Location = New System.Drawing.Point(693, 111)
            Me.BtnCargarSMTP.Name = "BtnCargarSMTP"
            Me.BtnCargarSMTP.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarSMTP.TabIndex = 4
            Me.BtnCargarSMTP.Text = "Buscar"
            Me.BtnCargarSMTP.UseVisualStyleBackColor = True
            '
            'BtnCargarPOP
            '
            Me.BtnCargarPOP.Location = New System.Drawing.Point(693, 144)
            Me.BtnCargarPOP.Name = "BtnCargarPOP"
            Me.BtnCargarPOP.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarPOP.TabIndex = 4
            Me.BtnCargarPOP.Text = "Buscar"
            Me.BtnCargarPOP.UseVisualStyleBackColor = True
            '
            'BtnCargarWEB
            '
            Me.BtnCargarWEB.Location = New System.Drawing.Point(693, 174)
            Me.BtnCargarWEB.Name = "BtnCargarWEB"
            Me.BtnCargarWEB.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarWEB.TabIndex = 4
            Me.BtnCargarWEB.Text = "Buscar"
            Me.BtnCargarWEB.UseVisualStyleBackColor = True
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(12, 207)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(76, 13)
            Me.Label5.TabIndex = 0
            Me.Label5.Text = "Archivo SMTP"
            '
            'txtASMTP
            '
            Me.txtASMTP.Location = New System.Drawing.Point(116, 204)
            Me.txtASMTP.Name = "txtASMTP"
            Me.txtASMTP.Size = New System.Drawing.Size(571, 20)
            Me.txtASMTP.TabIndex = 1
            '
            'BtnCargarASMTP
            '
            Me.BtnCargarASMTP.Location = New System.Drawing.Point(693, 203)
            Me.BtnCargarASMTP.Name = "BtnCargarASMTP"
            Me.BtnCargarASMTP.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarASMTP.TabIndex = 4
            Me.BtnCargarASMTP.Text = "Buscar"
            Me.BtnCargarASMTP.UseVisualStyleBackColor = True
            '
            'CtrlBuscarArchivo
            '
            Me.CtrlBuscarArchivo.FileName = "OpenFileDialog1"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(12, 233)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(68, 13)
            Me.Label6.TabIndex = 0
            Me.Label6.Text = "Archivo POP"
            '
            'txtAPOP
            '
            Me.txtAPOP.Location = New System.Drawing.Point(116, 230)
            Me.txtAPOP.Name = "txtAPOP"
            Me.txtAPOP.Size = New System.Drawing.Size(571, 20)
            Me.txtAPOP.TabIndex = 1
            '
            'BtnCargarAPOP
            '
            Me.BtnCargarAPOP.Location = New System.Drawing.Point(693, 229)
            Me.BtnCargarAPOP.Name = "BtnCargarAPOP"
            Me.BtnCargarAPOP.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarAPOP.TabIndex = 4
            Me.BtnCargarAPOP.Text = "Buscar"
            Me.BtnCargarAPOP.UseVisualStyleBackColor = True
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(12, 259)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(71, 13)
            Me.Label7.TabIndex = 0
            Me.Label7.Text = "Archivo WEB"
            '
            'txtAWEB
            '
            Me.txtAWEB.Location = New System.Drawing.Point(116, 256)
            Me.txtAWEB.Name = "txtAWEB"
            Me.txtAWEB.Size = New System.Drawing.Size(571, 20)
            Me.txtAWEB.TabIndex = 1
            '
            'BtnCargarAWEB
            '
            Me.BtnCargarAWEB.Location = New System.Drawing.Point(693, 255)
            Me.BtnCargarAWEB.Name = "BtnCargarAWEB"
            Me.BtnCargarAWEB.Size = New System.Drawing.Size(75, 22)
            Me.BtnCargarAWEB.TabIndex = 4
            Me.BtnCargarAWEB.Text = "Buscar"
            Me.BtnCargarAWEB.UseVisualStyleBackColor = True
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(12, 285)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(52, 13)
            Me.Label8.TabIndex = 0
            Me.Label8.Text = "Imap App"
            '
            'txtImapApp
            '
            Me.txtImapApp.Location = New System.Drawing.Point(116, 282)
            Me.txtImapApp.Name = "txtImapApp"
            Me.txtImapApp.Size = New System.Drawing.Size(571, 20)
            Me.txtImapApp.TabIndex = 1
            '
            'CmdCargarImapApp
            '
            Me.CmdCargarImapApp.Location = New System.Drawing.Point(693, 281)
            Me.CmdCargarImapApp.Name = "CmdCargarImapApp"
            Me.CmdCargarImapApp.Size = New System.Drawing.Size(75, 22)
            Me.CmdCargarImapApp.TabIndex = 4
            Me.CmdCargarImapApp.Text = "Buscar"
            Me.CmdCargarImapApp.UseVisualStyleBackColor = True
            '
            'chkArranqueWindows
            '
            Me.chkArranqueWindows.AutoSize = True
            Me.chkArranqueWindows.Location = New System.Drawing.Point(12, 460)
            Me.chkArranqueWindows.Name = "chkArranqueWindows"
            Me.chkArranqueWindows.Size = New System.Drawing.Size(134, 17)
            Me.chkArranqueWindows.TabIndex = 5
            Me.chkArranqueWindows.Text = "Arrancar con Windows"
            Me.chkArranqueWindows.UseVisualStyleBackColor = True
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(12, 311)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(78, 13)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Spam Assassin"
            '
            'txtSpamAssassin
            '
            Me.txtSpamAssassin.Location = New System.Drawing.Point(116, 308)
            Me.txtSpamAssassin.Name = "txtSpamAssassin"
            Me.txtSpamAssassin.Size = New System.Drawing.Size(571, 20)
            Me.txtSpamAssassin.TabIndex = 1
            '
            'CmdCargarSpamAssassin
            '
            Me.CmdCargarSpamAssassin.Location = New System.Drawing.Point(693, 307)
            Me.CmdCargarSpamAssassin.Name = "CmdCargarSpamAssassin"
            Me.CmdCargarSpamAssassin.Size = New System.Drawing.Size(75, 22)
            Me.CmdCargarSpamAssassin.TabIndex = 4
            Me.CmdCargarSpamAssassin.Text = "Buscar"
            Me.CmdCargarSpamAssassin.UseVisualStyleBackColor = True
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(13, 25)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(75, 13)
            Me.Label10.TabIndex = 0
            Me.Label10.Text = "Post OFFICES"
            '
            'txtPostOffices
            '
            Me.txtPostOffices.Location = New System.Drawing.Point(117, 22)
            Me.txtPostOffices.Name = "txtPostOffices"
            Me.txtPostOffices.Size = New System.Drawing.Size(571, 20)
            Me.txtPostOffices.TabIndex = 1
            '
            'BtnCargarPostOffices
            '
            Me.BtnCargarPostOffices.Location = New System.Drawing.Point(694, 22)
            Me.BtnCargarPostOffices.Name = "BtnCargarPostOffices"
            Me.BtnCargarPostOffices.Size = New System.Drawing.Size(75, 21)
            Me.BtnCargarPostOffices.TabIndex = 4
            Me.BtnCargarPostOffices.Text = "Buscar"
            Me.BtnCargarPostOffices.UseVisualStyleBackColor = True
            '
            'TrackLectura
            '
            Me.TrackLectura.LargeChange = 100
            Me.TrackLectura.Location = New System.Drawing.Point(116, 334)
            Me.TrackLectura.Maximum = 300
            Me.TrackLectura.Name = "TrackLectura"
            Me.TrackLectura.Size = New System.Drawing.Size(338, 45)
            Me.TrackLectura.SmallChange = 10
            Me.TrackLectura.TabIndex = 8
            Me.TrackLectura.TickFrequency = 10
            Me.TrackLectura.Value = 100
            '
            'TrackPropagacion
            '
            Me.TrackPropagacion.LargeChange = 100
            Me.TrackPropagacion.Location = New System.Drawing.Point(116, 375)
            Me.TrackPropagacion.Maximum = 300
            Me.TrackPropagacion.Name = "TrackPropagacion"
            Me.TrackPropagacion.Size = New System.Drawing.Size(492, 45)
            Me.TrackPropagacion.SmallChange = 10
            Me.TrackPropagacion.TabIndex = 8
            Me.TrackPropagacion.TickFrequency = 10
            Me.TrackPropagacion.Value = 100
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(13, 344)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(101, 13)
            Me.Label11.TabIndex = 9
            Me.Label11.Text = "Lectura de archivos"
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(13, 384)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(80, 13)
            Me.Label12.TabIndex = 10
            Me.Label12.Text = "Propagación IP"
            '
            'txtLecturaArchivos
            '
            Me.txtLecturaArchivos.Location = New System.Drawing.Point(460, 338)
            Me.txtLecturaArchivos.Name = "txtLecturaArchivos"
            Me.txtLecturaArchivos.Size = New System.Drawing.Size(75, 20)
            Me.txtLecturaArchivos.TabIndex = 11
            '
            'txtPropagacionIP
            '
            Me.txtPropagacionIP.Location = New System.Drawing.Point(614, 377)
            Me.txtPropagacionIP.Name = "txtPropagacionIP"
            Me.txtPropagacionIP.Size = New System.Drawing.Size(75, 20)
            Me.txtPropagacionIP.TabIndex = 11
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(558, 341)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(44, 13)
            Me.Label13.TabIndex = 12
            Me.Label13.Text = "Reposo"
            '
            'NumReposoLectura
            '
            Me.NumReposoLectura.Increment = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.NumReposoLectura.Location = New System.Drawing.Point(608, 337)
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
            Me.Label14.Location = New System.Drawing.Point(12, 428)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(44, 13)
            Me.Label14.TabIndex = 0
            Me.Label14.Text = "Backup"
            '
            'txtBackupEmail
            '
            Me.txtBackupEmail.Location = New System.Drawing.Point(116, 425)
            Me.txtBackupEmail.Name = "txtBackupEmail"
            Me.txtBackupEmail.Size = New System.Drawing.Size(571, 20)
            Me.txtBackupEmail.TabIndex = 1
            '
            'CmdCargarCarpetaBackupEmail
            '
            Me.CmdCargarCarpetaBackupEmail.Location = New System.Drawing.Point(693, 424)
            Me.CmdCargarCarpetaBackupEmail.Name = "CmdCargarCarpetaBackupEmail"
            Me.CmdCargarCarpetaBackupEmail.Size = New System.Drawing.Size(75, 22)
            Me.CmdCargarCarpetaBackupEmail.TabIndex = 4
            Me.CmdCargarCarpetaBackupEmail.Text = "Buscar"
            Me.CmdCargarCarpetaBackupEmail.UseVisualStyleBackColor = True
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Location = New System.Drawing.Point(12, 494)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(210, 13)
            Me.Label15.TabIndex = 14
            Me.Label15.Text = "Mantener una ANTIGUEDAD de Emails de"
            '
            'txtAntiguedadEmails
            '
            Me.txtAntiguedadEmails.Location = New System.Drawing.Point(228, 491)
            Me.txtAntiguedadEmails.Name = "txtAntiguedadEmails"
            Me.txtAntiguedadEmails.Size = New System.Drawing.Size(100, 20)
            Me.txtAntiguedadEmails.TabIndex = 15
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(334, 494)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(28, 13)
            Me.Label16.TabIndex = 16
            Me.Label16.Text = "días"
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.Location = New System.Drawing.Point(13, 56)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(83, 13)
            Me.Label17.TabIndex = 17
            Me.Label17.Text = "MailEnable APP"
            '
            'txtMailEnableApp
            '
            Me.txtMailEnableApp.Location = New System.Drawing.Point(117, 53)
            Me.txtMailEnableApp.Name = "txtMailEnableApp"
            Me.txtMailEnableApp.Size = New System.Drawing.Size(570, 20)
            Me.txtMailEnableApp.TabIndex = 18
            '
            'CmdBuscarMailEnableApp
            '
            Me.CmdBuscarMailEnableApp.Location = New System.Drawing.Point(695, 51)
            Me.CmdBuscarMailEnableApp.Name = "CmdBuscarMailEnableApp"
            Me.CmdBuscarMailEnableApp.Size = New System.Drawing.Size(75, 23)
            Me.CmdBuscarMailEnableApp.TabIndex = 19
            Me.CmdBuscarMailEnableApp.Text = "Buscar"
            Me.CmdBuscarMailEnableApp.UseVisualStyleBackColor = True
            '
            'Frm_Config
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(780, 577)
            Me.Controls.Add(Me.CmdBuscarMailEnableApp)
            Me.Controls.Add(Me.txtMailEnableApp)
            Me.Controls.Add(Me.Label17)
            Me.Controls.Add(Me.Label16)
            Me.Controls.Add(Me.txtAntiguedadEmails)
            Me.Controls.Add(Me.Label15)
            Me.Controls.Add(Me.NumReposoLectura)
            Me.Controls.Add(Me.Label13)
            Me.Controls.Add(Me.txtPropagacionIP)
            Me.Controls.Add(Me.txtLecturaArchivos)
            Me.Controls.Add(Me.Label12)
            Me.Controls.Add(Me.Label11)
            Me.Controls.Add(Me.TrackPropagacion)
            Me.Controls.Add(Me.TrackLectura)
            Me.Controls.Add(Me.chkArranqueWindows)
            Me.Controls.Add(Me.CmdCargarCarpetaBackupEmail)
            Me.Controls.Add(Me.CmdCargarSpamAssassin)
            Me.Controls.Add(Me.CmdCargarImapApp)
            Me.Controls.Add(Me.BtnCargarAWEB)
            Me.Controls.Add(Me.BtnCargarAPOP)
            Me.Controls.Add(Me.BtnCargarASMTP)
            Me.Controls.Add(Me.BtnCargarWEB)
            Me.Controls.Add(Me.BtnCargarPOP)
            Me.Controls.Add(Me.BtnCargarSMTP)
            Me.Controls.Add(Me.BtnCargarPostOffices)
            Me.Controls.Add(Me.txtBackupEmail)
            Me.Controls.Add(Me.BtnCargarIMAP)
            Me.Controls.Add(Me.txtSpamAssassin)
            Me.Controls.Add(Me.txtImapApp)
            Me.Controls.Add(Me.txtAWEB)
            Me.Controls.Add(Me.txtAPOP)
            Me.Controls.Add(Me.Label14)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.Label9)
            Me.Controls.Add(Me.txtASMTP)
            Me.Controls.Add(Me.Label8)
            Me.Controls.Add(Me.txtWEB)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.txtPOP)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.txtSMTP)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.txtPostOffices)
            Me.Controls.Add(Me.txtIMAP)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label10)
            Me.Controls.Add(Me.Label1)
            Me.Name = "Frm_Config"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Frm_Config"
            Me.Panel1.ResumeLayout(False)
            CType(Me.TrackLectura, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TrackPropagacion, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumReposoLectura, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents CtrlBuscarCarpeta As FolderBrowserDialog
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents Label4 As Label
        Friend WithEvents txtIMAP As TextBox
        Friend WithEvents txtSMTP As TextBox
        Friend WithEvents txtPOP As TextBox
        Friend WithEvents txtWEB As TextBox
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnGuardarConfig As Button
        Friend WithEvents CtrlSeparadorPie As Panel
        Friend WithEvents BtnCargarIMAP As Button
        Friend WithEvents BtnCargarSMTP As Button
        Friend WithEvents BtnCargarPOP As Button
        Friend WithEvents BtnCargarWEB As Button
        Friend WithEvents BtnCancelar As Button
        Friend WithEvents Label5 As Label
        Friend WithEvents txtASMTP As TextBox
        Friend WithEvents BtnCargarASMTP As Button
        Friend WithEvents CtrlBuscarArchivo As OpenFileDialog
        Friend WithEvents Label6 As Label
        Friend WithEvents txtAPOP As TextBox
        Friend WithEvents BtnCargarAPOP As Button
        Friend WithEvents Label7 As Label
        Friend WithEvents txtAWEB As TextBox
        Friend WithEvents BtnCargarAWEB As Button
        Friend WithEvents Label8 As Label
        Friend WithEvents txtImapApp As TextBox
        Friend WithEvents CmdCargarImapApp As Button
        Friend WithEvents chkArranqueWindows As CheckBox
        Friend WithEvents Label9 As Label
        Friend WithEvents txtSpamAssassin As TextBox
        Friend WithEvents CmdCargarSpamAssassin As Button
        Friend WithEvents Label10 As Label
        Friend WithEvents txtPostOffices As TextBox
        Friend WithEvents BtnCargarPostOffices As Button
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
        Friend WithEvents Label17 As Label
        Friend WithEvents txtMailEnableApp As TextBox
        Friend WithEvents CmdBuscarMailEnableApp As Button
    End Class
End Namespace