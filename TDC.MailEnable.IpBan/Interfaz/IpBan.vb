Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Threading
Imports TDC.MailEnable.IpBan.MailEnableLog
Imports TDC.MailEnable.IpBan.RegistroDeArchivos
Imports TDC.MailEnable.IpBan.RegistroDeArchivos.LecturaDeArchivo
Imports TDC.MailEnable.Core

Namespace Interfaz
    Public Class IpBan

        'POP
        Private WithEvents Trabajador_POP As New Bucle.Bucle
        Private Registro_POP As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_POP))
        Private WithEvents Trabajador_POPW3C As New Bucle.Bucle
        Private Registro_POPW3C As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_POPW3C))
        'Private POP_DENY As Cls_MailEnableDeny

        'SMTP
        Private WithEvents Trabajador_SMTP As New Bucle.Bucle
        Private Registro_SMTP As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_SMTP))
        Private WithEvents Trabajador_SMTPW3C As New Bucle.Bucle
        Private Registro_SMTPW3C As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_SMTPW3C))
        'Private SMTP_DENY As Cls_MailEnableDeny

        'IMAP
        Private WithEvents Trabajador_IMAP As New Bucle.Bucle
        Private Registro_IMAP As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_IMAP))
        Private WithEvents Trabajador_IMAPW3C As New Bucle.Bucle
        Private Registro_IMAPW3C As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_IMAPW3C))

        'WEB
        Private WithEvents Trabajador_WEB As New Bucle.Bucle
        Private Registro_WEB As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_WEB))
        'Private ISSServer As Cls_ISS

        'PUBLICAR IP
        Private Publicador As Frm_PublicarIps = Nothing
        Private Shared SyncLockPublicador As New Object()

        Private Sub IpBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

            'Posicionar Ventana
            Me.Top = 0
            'Arrancar Modulo Principal
            Mod_Core.Mod_Core_Main()

            'Iniciar configuracion
            If Mod_Core.Configuracion.IMAP = "" Then
                Dim CrearConfigUsuario As New Frm_Config
                CrearConfigUsuario.ShowDialog(Me)
            End If
            'MsgBox(IO.File.ReadAllText(Configuracion.WEB_DENY))
            'Cargar Ip Baneadas
            lstIpBaneadas.DataSource = Mod_Core.IpBaneadas.Data
            lstIpBaneadas.DisplayMember = "Item"
            AddHandler Mod_Core.IpBaneadas.OnRefresData, AddressOf RefrescarDatosBaneadas

            'Cargar Ip Blancas
            lstIpBlancas.DataSource = Mod_Core.IpBlancas.Data
            lstIpBlancas.DisplayMember = "Item"
            AddHandler Mod_Core.IpBlancas.OnRefresData, AddressOf RefrescarDatosBlancas

            'Enlazar co nel archivo ISS
            'ISSServer = New Cls_ISS

            'Enlazar con SMTP-DENY
            'SMTP_DENY = New Cls_MailEnableDeny(Configuracion.SMTP_DENY)

            'Enlazar POP-DENY
            'POP_DENY = New Cls_MailEnableDeny(Configuracion.POP_DENY)

            '::::::: PRUEBAS :::::::
            'Añadir
            'For i = 0 To 10
            '    If Not POP_DENY.Contais(IpBaneadas.Data.Item(i)) Then
            '        POP_DENY.Add(IpBaneadas.Data.Item(i))
            '    End If
            'Next
            'POP_DENY.Guardar()

            'Eliminar
            'For i = 0 To 10
            '    If POP_DENY.Contais(IpBaneadas.Data.Item(i)) Then
            '        POP_DENY.Remove(IpBaneadas.Data.Item(i))
            '    End If
            'Next
            'POP_DENY.Guardar()

            'Añadir
            'For i = 0 To 10
            '    If Not ISSServer.Contains(IpBaneadas.Data.Item(i)) Then
            '        ISSServer.Add(IpBaneadas.Data.Item(i))
            '    End If
            'Next
            'ISSServer.Save()

            'Eliminar
            'For i = 0 To 10
            '    If ISSServer.Contains(IpBaneadas.Data.Item(i)) Then
            '        ISSServer.Remove(IpBaneadas.Data.Item(i))
            '    End If
            'Next
            'ISSServer.Save()
            ':::::::::::::::::::::::

            'Empezar a Trabajar
            'POP(Actividad)
            Registro_POP.Filtro.Add(New Tuple(Of Integer, Integer, List(Of String))(EnumTipoComparacion.Cualquiera, 20, New List(Of String) From {"-ERR Unable to log on"}))
            Trabajador_POP.Intervalo = 1000
            Trabajador_POP.Inicia()

            'POP(W3C)
            Registro_POPW3C.Filtro.Add(New Tuple(Of Integer, Integer, List(Of String))(EnumTipoComparacion.Cualquiera, 20, New List(Of String) From {"-ERR+Unable+to+log+on"}))
            Trabajador_POPW3C.Intervalo = 1000
            Trabajador_POPW3C.Inicia()

            'SMTP (Actividad)
            Registro_SMTP.Filtro.Add(New Tuple(Of Integer, Integer, List(Of String))(EnumTipoComparacion.Cualquiera, 20, New List(Of String) From {"Invalid Username or Password"}))
            Registro_SMTP.Filtro.Add(New Tuple(Of Integer, Integer, List(Of String))(EnumTipoComparacion.Cualquiera, 20, New List(Of String) From {"This mail server requires authentication before sending mail"}))
            Trabajador_SMTP.Intervalo = 1000
            Trabajador_SMTP.Inicia()

            'SMTP(W3C)
            Registro_SMTPW3C.Filtro.Add(New Tuple(Of Integer, Integer, List(Of String))(EnumTipoComparacion.Cualquiera, 20, New List(Of String) From {"Invalid+Username+or+Password"}))
            Registro_SMTPW3C.Filtro.Add(New Tuple(Of Integer, Integer, List(Of String))(EnumTipoComparacion.Cualquiera, 20, New List(Of String) From {"This+mail+server+requires+authentication+before+sending+mail"}))
            Trabajador_SMTPW3C.Intervalo = 1000
            Trabajador_SMTPW3C.Inicia()

            'IMAP(Actividad)
            Registro_IMAP.Filtro.Add(New Tuple(Of Integer, Integer, List(Of String))(EnumTipoComparacion.Cualquiera, 20, New List(Of String) From {"Invalid username or password"}))
            Trabajador_IMAP.Intervalo = 1000
            Trabajador_IMAP.Inicia()

            'IMAP (W3C)
            Registro_IMAPW3C.Filtro.Add(New Tuple(Of Integer, Integer, List(Of String))(EnumTipoComparacion.Cualquiera, 20, New List(Of String) From {"Invalid+username+or+password"}))
            Trabajador_IMAPW3C.Intervalo = 1000
            Trabajador_IMAPW3C.Inicia()

            'WEB
            Registro_WEB.Filtro.Add(New Tuple(Of Integer, Integer, List(Of String))(EnumTipoComparacion.Todo, 10, New List(Of String) From {"POST", "Cmd=LOGIN"}))
            Registro_WEB.Filtro.Add(New Tuple(Of Integer, Integer, List(Of String))(EnumTipoComparacion.Todo, 10, New List(Of String) From {"POST", "/Mobile/Login.aspx"}))
            Registro_WEB.Filtro.Add(New Tuple(Of Integer, Integer, List(Of String))(EnumTipoComparacion.Todo, 0, New List(Of String) From {"POST", " 404 "}))
            Registro_WEB.Filtro.Add(New Tuple(Of Integer, Integer, List(Of String))(EnumTipoComparacion.Todo, 0, New List(Of String) From {"GET", " 404 "}))
            Trabajador_WEB.Intervalo = 1000
            Trabajador_WEB.Inicia()

            'Interfaz
            UcPOPEx.Etiqueta.Text = "POP (Ex)"
            UcPOPAct.Etiqueta.Text = "POP (Act)"
            UcSMTPEx.Etiqueta.Text = "SMTP (Ex)"
            UcSMTPAct.Etiqueta.Text = "SMTP (Act)"
            UcIMAPAct.Etiqueta.Text = "IMAPP (Act)"
            UcIMAPEx.Etiqueta.Text = "IMAPP (Ex)"
            UcWEB.Etiqueta.Text = "WEB"

        End Sub

        Private Sub RefrescarDatosBaneadas()
            lstIpBaneadas.Invoke(Sub()
                                     lstIpBaneadas.DataSource = Nothing
                                     lstIpBaneadas.DataSource = Mod_Core.IpBaneadas.Data
                                 End Sub)
        End Sub

        Private Sub RefrescarDatosBlancas()
            lstIpBlancas.Invoke(Sub()
                                    lstIpBlancas.DataSource = Nothing
                                    lstIpBlancas.DataSource = Mod_Core.IpBlancas.Data
                                End Sub)
        End Sub

        Private Sub BloquearIps(Ips As Concurrent.ConcurrentBindingList(Of String))
            'Funcion Unica para bloquear las Ips y Llevar un mejor control en depuración
            For Each Ip In Ips
                If Not IpBlancas.Data.Contains(Ip) Then
                    If Not IpBaneadas.Contains(Ip) Then Mod_Core.IpBaneadas.Add(Ip)
                End If
            Next
        End Sub

        Private Function esLegible(Archivo As String) As Boolean
            Try
                Using OpenFile As New IO.FileStream(Archivo, IO.FileMode.Open, IO.FileAccess.Read)
                    'Intenta abrir el archivo en modo lectura y cierra.
                End Using
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
        Private Sub EscanearCarpeta(UcCarpeta As UcAnalizador, UcArchivo As UcAnalizador, DelimitadorIp As Func(Of String, String), Trabajador As Bucle.Bucle, Carpeta As String, ControlCarpeta As RegistroDeArchivos.RegistroDeArchivos, FiltroCarpeta As String)
            'Marcador para evitar analizar los archivos del Dia
            'Dim Ahora As String = Now.Year.ToString("00").Substring(2) & Now.Month.ToString("00") & Now.Day.ToString("00")

            'Actualizar el Interface
            Me.Invoke(Sub() UcCarpeta.Progreso.Maximum = New IO.DirectoryInfo(Carpeta).GetFiles(FiltroCarpeta, IO.SearchOption.TopDirectoryOnly).Count)
            If Not UcArchivo.Etiqueta.Text.Contains("-") Then Me.Invoke(Sub() UcArchivo.Etiqueta.Text = "0 - 0")
            'Buscar Archivos en la Carpeta
            For Each Archivo In New IO.DirectoryInfo(Carpeta).GetFiles(FiltroCarpeta, IO.SearchOption.TopDirectoryOnly)
                'Actualizar Interface
                Me.Invoke(Sub()
                              'Progreso
                              UcCarpeta.Progreso.Value = ControlCarpeta.Count
                              'Label
                              UcCarpeta.Contador.Text = String.Format("{0} - {1}", ControlCarpeta.Count, UcCarpeta.Progreso.Maximum)
                          End Sub)

                If Not ControlCarpeta.Contains(Archivo.Name) AndAlso esLegible(Archivo.FullName) Then
                    'Analizar Archivo
                    Dim EscanearArchivo As New LecturaDeArchivo(Archivo.FullName) With {.ObtenerIp = DelimitadorIp, .Filtros = ControlCarpeta.Filtro}
                    'Enlazar con el Evento para visualizar el progreso de la lectura
                    AddHandler EscanearArchivo.Progreso, Sub(Index, Total)
                                                             'Actualizar el Interface
                                                             Me.Invoke(Sub()
                                                                           UcArchivo.Progreso.Maximum = Total
                                                                           UcArchivo.Progreso.Value = Index
                                                                           UcArchivo.Contador.Text = String.Format("{0} - {1}", Index, Total)
                                                                       End Sub)
                                                         End Sub
                    'Mandar a analizar y esperar
                    EscanearArchivo.Escanear()

                    'Actualizar la lista de Bloqueo si encuentra Ips a Bloquear
                    If EscanearArchivo.FiltroIp.Count > 0 Then
                        BloquearIps(EscanearArchivo.FiltroIp)

                        'Actualizar el Interface
                        Me.Invoke(Sub()
                                      Dim Total As Integer = CInt(UcArchivo.Etiqueta.Text.Split("-")(0).Trim) + EscanearArchivo.FiltroIp.Count
                                      Dim Ultimas As Integer = EscanearArchivo.FiltroIp.Count.ToString
                                      UcArchivo.Etiqueta.Text = String.Format("{0} - {1}", Total, Ultimas)
                                  End Sub)
                    End If

                    'Registramos el Archivo Analizado
                    ControlCarpeta.Add(Archivo.Name)
                End If
            Next

            'Mandamos a analizar Cada Minuto
            Trabajador.Intervalo = 60000

            'Propagamos la configuracion
            BtnPropagarIps_Click(Nothing, New EventArgs)

            'Detenemos el escaneo
            'Trabajador.Detener()
        End Sub

        Private Sub BtnAñadirIp_Click(sender As Object, e As EventArgs) Handles BtnAñadirIp.Click
            Dim AddBloqueoIp As String = InputBox("Añadir", "Ip Baneada", String.Empty)
            If Not IpBlancas.Contains(AddBloqueoIp) Then
                IpBaneadas.Add(AddBloqueoIp)
            Else
                MsgBox("La IP se encuentra en la lista Blanca")
            End If
        End Sub

        Private Sub BtnEliminarIp_Click(sender As Object, e As EventArgs) Handles BtnEliminarIp.Click
            If Not String.IsNullOrEmpty(lstBusqueda.Text) Then
                Mod_Core.IpBaneadas.Remove(lstBusqueda.Text)
                lstBusqueda.Items.Clear()
            Else
                MsgBox("Selecciona una IP del Filtro")
            End If
        End Sub


        Private Sub Trabajador_POP_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_POP.IBucle_Bucle
            'Trabajo en BackGround
            EscanearCarpeta(UcPOPAct, UcArchivoPOPAct, Function(Linea) Linea.Split(vbTab)(3), Trabajador_POP, Mod_Core.Configuracion.POP, Registro_POP, "POP*.log")
        End Sub

        Private Sub Trabajador_POPW3C_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_POPW3C.IBucle_Bucle
            'Trabajo en BackGround
            EscanearCarpeta(UcPOPEx, UcArchivoPOPEx, Function(Linea) Linea.Split(" ")(2), Trabajador_POPW3C, Mod_Core.Configuracion.POP, Registro_POPW3C, "ex*.log")
        End Sub

        Private Sub Trabajador_SMTP_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_SMTP.IBucle_Bucle
            'Trabajo en BackGround
            EscanearCarpeta(UcSMTPAct, UcArchivoSMTPAct, Function(linea) linea.Split(vbTab)(4), Trabajador_SMTP, Mod_Core.Configuracion.SMTP, Registro_SMTP, "SMTP*.log")
        End Sub
        Private Sub Trabajador_SMTPW3C_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_SMTPW3C.IBucle_Bucle
            'Trabajo en BackGround
            EscanearCarpeta(UcSMTPEx, UcArchivoSMTPEx, Function(Linea) Linea.Split(" ")(2), Trabajador_SMTPW3C, Mod_Core.Configuracion.SMTP, Registro_SMTPW3C, "ex*.log")
        End Sub
        Private Sub Trabajador_IMAP_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_IMAP.IBucle_Bucle
            'Trabajo en BackGround
            EscanearCarpeta(UcIMAPAct, UcArchivoIMAPAct, Function(Linea) Linea.Split(vbTab)(4), Trabajador_IMAP, Mod_Core.Configuracion.IMAP, Registro_IMAP, "IMAP*.log")
        End Sub
        Private Sub Trabajador_IMAPW3C_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_IMAPW3C.IBucle_Bucle
            'Trabajo en BackGround
            EscanearCarpeta(UcIMAPEx, UcArchivoIMAPEx, Function(Linea) Linea.Split(" ")(2), Trabajador_IMAPW3C, Mod_Core.Configuracion.IMAP, Registro_IMAPW3C, "ex*.log")
        End Sub

        Private Sub Trabajador_WEB_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_WEB.IBucle_Bucle
            'Trabajo en BackGround
            EscanearCarpeta(UcWEB, UcArchivoWEB, Function(Linea) Linea.Split(" ")(8), Trabajador_WEB, Mod_Core.Configuracion.WEB, Registro_WEB, "u_ex*.log")
        End Sub
        Private Sub lstIpBaneadas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstIpBaneadas.SelectedIndexChanged
            lblIpsCount.Text = lstIpBaneadas.Items.Count
        End Sub

        Private Sub lstIpBaneadas_BindingContextChanged(sender As Object, e As EventArgs) Handles lstIpBaneadas.BindingContextChanged
            lblIpsCount.Text = lstIpBaneadas.Items.Count
        End Sub

        Private Sub txtBuscarIp_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarIp.TextChanged
            Dim Buscar As String = txtBuscarIp.Text
            'lstIpBaneadas.ClearSelected()
            lstBusqueda.Items.Clear()
            'Si se limpia la busqueda no continuar
            If String.IsNullOrEmpty(Buscar) Then Exit Sub

            For i = 0 To lstIpBaneadas.Items.Count - 1
                Dim lstItem As String = IpBaneadas.Data.Item(i)
                If lstItem.Contains(Buscar) Then
                    'lstIpBaneadas.SetSelected(i, True)
                    lstBusqueda.Items.Add(lstItem)
                    'Exit For
                End If
            Next
        End Sub

        Private Sub BtnAñadirBlanca_Click(sender As Object, e As EventArgs) Handles BtnAñadirBlanca.Click
            IpBlancas.Add(lstBusqueda.Text)
            IpBaneadas.Remove(lstBusqueda.Text)
        End Sub

        Private Sub BtnEliminarBlanca_Click(sender As Object, e As EventArgs) Handles BtnEliminarBlanca.Click
            IpBlancas.Remove(lstIpBlancas.SelectedItem)
        End Sub
        Private Sub BtnAnadirBlanca_Click(sender As Object, e As EventArgs) Handles BtnAnadirBlanca.Click
            IpBlancas.Add(InputBox("Ip Blanca", "Añadir", String.Empty))
        End Sub
        Private Sub ConfiguraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraciónToolStripMenuItem.Click
            Dim CrearConfigUsuario As New Frm_Config
            CrearConfigUsuario.ShowDialog(Me)
        End Sub

        Private Sub BtnPropagarIps_Click(sender As Object, e As EventArgs) Handles BtnPropagarIps.Click
            Try
                If Monitor.TryEnter(syncLockPublicador) Then

                    If IsNothing(Publicador) Then
                        'Cerrar Entrada a los otros Trabajadores
                        Using Publicador = New Frm_PublicarIps
                            Using ListaSMTP = New Cls_MailEnableDeny(Mod_Core.Configuracion.SMTP_DENY)
                                If ListaSMTP.Count <> IpBaneadas.Count Then
                                    If Not ChkDetenerPublicacion.Checked Then
                                        With Publicador
                                            .Lista = IpBaneadas.ToList
                                            If InvokeRequired Then Invoke(Sub() .ShowDialog(Me)) Else .ShowDialog(Me)
                                            Me.Invoke(Sub() ChkDetenerPublicacion.BackColor = Color.Black)
                                        End With
                                    Else
                                        Me.Invoke(Sub() ChkDetenerPublicacion.BackColor = Color.DarkRed)
                                    End If
                                Else
                                    Me.Invoke(Sub() ChkDetenerPublicacion.BackColor = Color.Black)
                                End If
                            End Using
                        End Using
                        Publicador = Nothing
                        Monitor.Exit(syncLockPublicador)
                    End If
                End If
            Catch ex As Exception
                Stop
            End Try
        End Sub

        Private Sub lstBusqueda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBusqueda.SelectedIndexChanged
            txtBuscarIp.Text = lstBusqueda.Text
            lstBusqueda.SelectedIndex = 0
        End Sub

        Private Sub GridImapClientes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
            e.ThrowException = False
        End Sub

        Private Sub GridImapRechazados_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
            e.ThrowException = False
        End Sub
    End Class
End Namespace