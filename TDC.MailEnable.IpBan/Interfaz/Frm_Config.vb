Imports TDC.MailEnable.IpBan.MailEnable

Namespace Interfaz
    Public Class Frm_Config
        Private Enum EstadosCarga
            Cargando
            Cargado
        End Enum
        Private Estado As EstadosCarga = EstadosCarga.Cargando
        Private Sub Frm_Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            txtIMAP.Text = Main.Configuracion.IMAP
            txtSMTP.Text = Main.Configuracion.SMTP
            txtPOP.Text = Main.Configuracion.POP
            txtWEB.Text = Main.Configuracion.WEB
            txtASMTP.Text = Main.Configuracion.SMTP_DENY
            txtAPOP.Text = Main.Configuracion.POP_DENY
            txtAWEB.Text = Main.Configuracion.WEB_DENY
            txtImapApp.Text = Main.Configuracion.IMAP_SOCKET_APP
            txtSpamAssassin.Text = Main.Configuracion.SPAM_SPAMASSASSIN
            chkArranqueWindows.Checked = Main.Configuracion.AutoArranqueWindows
            txtPostOffices.Text = Main.Configuracion.POST_OFFICES
            NumReposoLectura.Value = CInt(Main.Configuracion.LECTURA_REPOSO)
            txtBackupEmail.Text = Main.Configuracion.CARPETA_BACKUP
            txtAntiguedadEmails.Text = Main.Configuracion.ANTIGUEDAD_EMAILS
            txtMailEnableApp.Text = Main.Configuracion.MAIL_APP
            txtAnalizadoresEmail.Text = Main.Configuracion.ANALIZADORES_BACKUP
            TrackAnalizadoresMailTimer.Value = Main.Configuracion.ANALIZADORES_BACKUP_TIMER
            txtTimerAnalizadoresEmail.Text = Main.Configuracion.ANALIZADORES_BACKUP_TIMER
            txtAutoResponder.Text = Main.Configuracion.AUTORESPONDER

            If IsNumeric(Main.Configuracion.TIMER_LECTURA) Then
                TrackLectura.Value = CInt(Main.Configuracion.TIMER_LECTURA)
                txtLecturaArchivos.Text = Main.Configuracion.TIMER_LECTURA
            Else
                Main.Configuracion.TIMER_LECTURA = TrackLectura.Value
                txtLecturaArchivos.Text = TrackLectura.Value
            End If
            If IsNumeric(Main.Configuracion.TIMER_PROPAGACION) Then
                TrackPropagacion.Value = CInt(Main.Configuracion.TIMER_PROPAGACION)
                txtPropagacionIP.Text = Main.Configuracion.TIMER_PROPAGACION
            Else
                Main.Configuracion.TIMER_PROPAGACION = TrackPropagacion.Value
                txtPropagacionIP.Text = TrackPropagacion.Value
            End If
        End Sub
        Private Sub BtnGuardarConfig_Click(sender As Object, e As EventArgs) Handles BtnGuardarConfig.Click
            Main.Configuracion.IMAP = txtIMAP.Text
            Main.Configuracion.SMTP = txtSMTP.Text
            Main.Configuracion.POP = txtPOP.Text
            Main.Configuracion.WEB = txtWEB.Text
            Main.Configuracion.SMTP_DENY = txtASMTP.Text
            Main.Configuracion.POP_DENY = txtAPOP.Text
            Main.Configuracion.WEB_DENY = txtAWEB.Text
            Main.Configuracion.IMAP_SOCKET_APP = txtImapApp.Text
            Main.Configuracion.SPAM_SPAMASSASSIN = txtSpamAssassin.Text
            Main.Configuracion.POST_OFFICES = txtPostOffices.Text
            Main.Configuracion.TIMER_LECTURA = TrackLectura.Value
            Main.Configuracion.TIMER_PROPAGACION = TrackPropagacion.Value
            Main.Configuracion.LECTURA_REPOSO = NumReposoLectura.Value
            Main.Configuracion.CARPETA_BACKUP = txtBackupEmail.Text
            Main.Configuracion.AUTORESPONDER = txtAutoResponder.Text

            Main.Configuracion.ANTIGUEDAD_EMAILS = txtAntiguedadEmails.Text
            Main.Configuracion.MAIL_APP = txtMailEnableApp.Text
            Main.Configuracion.ANALIZADORES_BACKUP = CInt(txtAnalizadoresEmail.Text)
            Main.GuardarConfiguracion()
            Me.Close()
        End Sub

        Private Function CargarCarpeta() As String
            With CtrlBuscarCarpeta
                .SelectedPath = ""
                .ShowDialog()
            End With
            Return CtrlBuscarCarpeta.SelectedPath
        End Function

        Private Function CargarArchivo() As String
            With CtrlBuscarArchivo
                .Filter = "Todo|*.*"
                .ValidateNames = False
                .ShowDialog()
            End With
            Return CtrlBuscarArchivo.FileName
        End Function

        Private Sub Frm_Config_Activated(sender As Object, e As EventArgs) Handles Me.Activated
            If Estado = EstadosCarga.Cargando Then Estado = EstadosCarga.Cargado
        End Sub

        Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
            Me.Close()
        End Sub

        Private Sub txtAPOP_TextChanged(sender As Object, e As EventArgs) Handles txtAPOP.TextChanged,
            txtAWEB.TextChanged,
            txtASMTP.TextChanged,
            txtWEB.TextChanged,
            txtPOP.TextChanged,
            txtSMTP.TextChanged,
            txtIMAP.TextChanged,
            txtImapApp.TextChanged,
            txtSpamAssassin.TextChanged,
            txtPostOffices.TextChanged,
            txtBackupEmail.TextChanged,
            txtLecturaArchivos.TextChanged,
            txtPropagacionIP.TextChanged,
            txtAnalizadoresEmail.TextChanged,
            txtTimerAnalizadoresEmail.TextChanged,
            txtAntiguedadEmails.TextChanged,
            txtAutoResponder.TextChanged
            If Estado = EstadosCarga.Cargado Then BtnGuardarConfig.Enabled = True
        End Sub
        Private Sub BtnCargarIMAP_Click(sender As Object, e As EventArgs) Handles BtnCargarIMAP.Click
            CargarCarpeta()
            txtIMAP.Text = CtrlBuscarCarpeta.SelectedPath
        End Sub

        Private Sub BtnCargarSMTP_Click(sender As Object, e As EventArgs) Handles BtnCargarSMTP.Click
            CargarCarpeta()
            txtSMTP.Text = CtrlBuscarCarpeta.SelectedPath
        End Sub

        Private Sub BtnCargarPOP_Click(sender As Object, e As EventArgs) Handles BtnCargarPOP.Click
            CargarCarpeta()
            txtPOP.Text = CtrlBuscarCarpeta.SelectedPath
        End Sub

        Private Sub BtnCargarWEB_Click(sender As Object, e As EventArgs) Handles BtnCargarWEB.Click
            CargarCarpeta()
            txtWEB.Text = CtrlBuscarCarpeta.SelectedPath
        End Sub

        Private Sub BtnCargarASMTP_Click(sender As Object, e As EventArgs) Handles BtnCargarASMTP.Click
            txtASMTP.Text = CargarArchivo()
        End Sub

        Private Sub BtnCargarAPOP_Click(sender As Object, e As EventArgs) Handles BtnCargarAPOP.Click
            txtAPOP.Text = CargarArchivo()
        End Sub

        Private Sub BtnCargarAWEB_Click(sender As Object, e As EventArgs) Handles BtnCargarAWEB.Click
            txtAWEB.Text = CargarArchivo()
        End Sub

        Private Sub CmdCargarImapApp_Click(sender As Object, e As EventArgs) Handles CmdCargarImapApp.Click
            txtImapApp.Text = CargarArchivo()
        End Sub
        Private Sub CmdCargarSpamAssassin_Click(sender As Object, e As EventArgs) Handles CmdCargarSpamAssassin.Click
            txtSpamAssassin.Text = CargarArchivo()
        End Sub
        Private Sub chkArranqueWindows_CheckedChanged(sender As Object, e As EventArgs) Handles chkArranqueWindows.CheckedChanged
            Main.Configuracion.AutoArranqueWindows = chkArranqueWindows.Checked
            BtnGuardarConfig.Enabled = True
        End Sub

        Private Sub BtnCargarPostOffices_Click(sender As Object, e As EventArgs) Handles BtnCargarPostOffices.Click
            CargarCarpeta()
            txtPostOffices.Text = CtrlBuscarCarpeta.SelectedPath
        End Sub

        Private Sub TrackLectura_Scroll(sender As Object, e As EventArgs) Handles TrackLectura.Scroll
            Main.Configuracion.TIMER_LECTURA = TrackLectura.Value
            If CInt(txtLecturaArchivos.Text) <> TrackLectura.Value Then txtLecturaArchivos.Text = TrackLectura.Value
        End Sub

        Private Sub TrackPropagacion_Scroll(sender As Object, e As EventArgs) Handles TrackPropagacion.Scroll
            Main.Configuracion.TIMER_PROPAGACION = TrackPropagacion.Value
            If CInt(txtPropagacionIP.Text) <> TrackPropagacion.Value Then txtPropagacionIP.Text = TrackPropagacion.Value
        End Sub

        Private Sub txtxLecturaArchivos_TextChanged(sender As Object, e As EventArgs) Handles txtLecturaArchivos.TextChanged
            If IsNumeric(txtLecturaArchivos.Text) Then
                If CInt(txtLecturaArchivos.Text) <= TrackLectura.Maximum Then
                    TrackLectura.Value = CInt(txtLecturaArchivos.Text)
                Else
                    TrackLectura.Value = TrackLectura.Maximum
                    txtLecturaArchivos.Text = TrackLectura.Maximum
                End If
            End If
        End Sub

        Private Sub txtPropagacionIP_TextChanged(sender As Object, e As EventArgs) Handles txtPropagacionIP.TextChanged
            If IsNumeric(txtPropagacionIP.Text) Then
                If CInt(txtPropagacionIP.Text) <= TrackPropagacion.Maximum Then
                    TrackPropagacion.Value = CInt(txtPropagacionIP.Text)
                Else
                    TrackPropagacion.Value = TrackPropagacion.Maximum
                    txtPropagacionIP.Text = TrackPropagacion.Maximum
                End If
            End If
        End Sub

        Private Sub CmdCargarCarpetaBackupEmail_Click(sender As Object, e As EventArgs) Handles CmdCargarCarpetaBackupEmail.Click
            CargarCarpeta()
            txtBackupEmail.Text = CtrlBuscarCarpeta.SelectedPath
        End Sub

        Private Sub txtAntiguedadEmails_TextChanged(sender As Object, e As EventArgs) Handles txtAntiguedadEmails.TextChanged
            If IsNumeric(txtAntiguedadEmails.Text) Then
                Main.Configuracion.ANTIGUEDAD_EMAILS = txtAntiguedadEmails.Text
            End If
        End Sub

        Private Sub CmdBuscarMailEnableApp_Click(sender As Object, e As EventArgs) Handles CmdBuscarMailEnableApp.Click
            CargarCarpeta()
            txtMailEnableApp.Text = CtrlBuscarCarpeta.SelectedPath
        End Sub

        Private Sub txtAnalizadoresEmail_TextChanged(sender As Object, e As EventArgs) Handles txtAnalizadoresEmail.TextChanged
            If IsNumeric(txtAnalizadoresEmail.Text) Then
                If CInt(txtAnalizadoresEmail.Text) <= TrackAnalizadoresEmail.Maximum AndAlso CInt(txtAnalizadoresEmail.Text) > 0 Then
                    TrackAnalizadoresEmail.Value = Convert.ToInt32(Math.Round(CInt(txtAnalizadoresEmail.Text)))
                Else
                    TrackAnalizadoresEmail.Value = TrackAnalizadoresEmail.Maximum
                    txtAnalizadoresEmail.Text = TrackAnalizadoresEmail.Maximum
                End If
            End If
        End Sub

        Private Sub TrackAnalizadoresEmail_Scroll(sender As Object, e As EventArgs) Handles TrackAnalizadoresEmail.Scroll
            If CInt(txtAnalizadoresEmail.Text) <> TrackAnalizadoresEmail.Value Then txtAnalizadoresEmail.Text = TrackAnalizadoresEmail.Value
            Main.Configuracion.ANALIZADORES_BACKUP = TrackAnalizadoresEmail.Value
        End Sub

        Private Sub TrackAnalizadoresMailTimer_Scroll(sender As Object, e As EventArgs) Handles TrackAnalizadoresMailTimer.Scroll
            Main.Configuracion.ANALIZADORES_BACKUP_TIMER = TrackAnalizadoresMailTimer.Value
            If CInt(txtTimerAnalizadoresEmail.Text) <> TrackAnalizadoresMailTimer.Value Then txtTimerAnalizadoresEmail.Text = TrackAnalizadoresMailTimer.Value
        End Sub

        Private Sub txtTimerAnalizadoresEmail_TextChanged(sender As Object, e As EventArgs) Handles txtTimerAnalizadoresEmail.TextChanged
            If IsNumeric(txtTimerAnalizadoresEmail.Text) AndAlso txtTimerAnalizadoresEmail.Text <= TrackAnalizadoresMailTimer.Maximum Then
                TrackAnalizadoresMailTimer.Value = txtTimerAnalizadoresEmail.Text
                Main.Configuracion.ANALIZADORES_BACKUP_TIMER = txtTimerAnalizadoresEmail.Text
            Else
                txtTimerAnalizadoresEmail.Text = TrackAnalizadoresMailTimer.Maximum
            End If
        End Sub

        Private Sub CmdBuscarAutoResponder_Click(sender As Object, e As EventArgs) Handles CmdBuscarAutoResponder.Click
            CargarCarpeta()
            txtAutoResponder.Text = CtrlBuscarCarpeta.SelectedPath
        End Sub

    End Class
End Namespace