Imports TDC.MailEnable.IpBan.MailEnableLog

Namespace Interfaz
    Public Class Frm_Config
        Private Enum EstadosCarga
            Cargando
            Cargado
        End Enum
        Private Estado As EstadosCarga = EstadosCarga.Cargando
        Private Sub Frm_Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            txtIMAP.Text = Mod_Core.Configuracion.IMAP
            txtSMTP.Text = Mod_Core.Configuracion.SMTP
            txtPOP.Text = Mod_Core.Configuracion.POP
            txtWEB.Text = Mod_Core.Configuracion.WEB
            txtASMTP.Text = Mod_Core.Configuracion.SMTP_DENY
            txtAPOP.Text = Mod_Core.Configuracion.POP_DENY
            txtAWEB.Text = Mod_Core.Configuracion.WEB_DENY
            txtImapApp.Text = Mod_Core.Configuracion.IMAP_SOCKET_APP
            txtSpamAssassin.Text = Mod_Core.Configuracion.SPAM_SPAMASSASSIN
            chkArranqueWindows.Checked = Mod_Core.Configuracion.AutoArranqueWindows
            txtPostOffices.Text = Mod_Core.Configuracion.POST_OFFICES
            If IsNumeric(Mod_Core.Configuracion.TIMER_LECTURA) Then
                TrackLectura.Value = CInt(Configuracion.TIMER_LECTURA)
                lblTimerLectura.Text = Configuracion.TIMER_LECTURA
            Else
                Configuracion.TIMER_LECTURA = TrackLectura.Value
                lblTimerLectura.Text = TrackLectura.Value
            End If
            If IsNumeric(Mod_Core.Configuracion.TIMER_PROPAGACION) Then
                TrackPropagacion.Value = CInt(Configuracion.TIMER_PROPAGACION)
                lblTimerPropagacion.Text = Configuracion.TIMER_PROPAGACION
            Else
                Configuracion.TIMER_PROPAGACION = TrackPropagacion.Value
                lblTimerPropagacion.Text = TrackPropagacion.Value
            End If
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

        Private Sub BtnGuardarConfig_Click(sender As Object, e As EventArgs) Handles BtnGuardarConfig.Click
            Mod_Core.Configuracion.IMAP = txtIMAP.Text
            Mod_Core.Configuracion.SMTP = txtSMTP.Text
            Mod_Core.Configuracion.POP = txtPOP.Text
            Mod_Core.Configuracion.WEB = txtWEB.Text
            Mod_Core.Configuracion.SMTP_DENY = txtASMTP.Text
            Mod_Core.Configuracion.POP_DENY = txtAPOP.Text
            Mod_Core.Configuracion.WEB_DENY = txtAWEB.Text
            Mod_Core.Configuracion.IMAP_SOCKET_APP = txtImapApp.Text
            Mod_Core.Configuracion.SPAM_SPAMASSASSIN = txtSpamAssassin.Text
            Mod_Core.Configuracion.POST_OFFICES = txtPostOffices.Text
            Mod_Core.Configuracion.TIMER_LECTURA = TrackLectura.Value
            Mod_Core.Configuracion.TIMER_PROPAGACION = TrackPropagacion.Value
            Mod_Core.GuardarConfiguracion()
            Me.Close()
        End Sub

        Private Sub txtAPOP_TextChanged(sender As Object, e As EventArgs) Handles txtAPOP.TextChanged, txtAWEB.TextChanged, txtASMTP.TextChanged, txtWEB.TextChanged, txtPOP.TextChanged, txtSMTP.TextChanged, txtIMAP.TextChanged, txtImapApp.TextChanged, txtSpamAssassin.TextChanged, txtPostOffices.TextChanged
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
            Configuracion.AutoArranqueWindows = chkArranqueWindows.Checked
            BtnGuardarConfig.Enabled = True
        End Sub

        Private Sub BtnCargarPostOffices_Click(sender As Object, e As EventArgs) Handles BtnCargarPostOffices.Click
            CargarCarpeta()
            txtPostOffices.Text = CtrlBuscarCarpeta.SelectedPath
        End Sub

        Private Sub TrackLectura_Scroll(sender As Object, e As EventArgs) Handles TrackLectura.Scroll
            Configuracion.TIMER_LECTURA = TrackLectura.Value
            lblTimerLectura.Text = TrackLectura.Value
        End Sub

        Private Sub TrackPropagacion_Scroll(sender As Object, e As EventArgs) Handles TrackPropagacion.Scroll
            Configuracion.TIMER_PROPAGACION = TrackPropagacion.Value
            lblTimerPropagacion.Text = TrackPropagacion.Value
        End Sub
    End Class
End Namespace