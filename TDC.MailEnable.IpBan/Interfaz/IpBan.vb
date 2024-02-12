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
            Me.Top = 50
            'Arrancar Modulo Principal
            Mod_Core.Mod_Core_Main()

            'Iniciar configuracion
            If Mod_Core.Configuracion.IMAP = "" Then
                Dim CrearConfigUsuario As New Frm_Config
                CrearConfigUsuario.ShowDialog(Me)
            End If

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
            Registro_POP.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Todo, 5, False, New List(Of FiltroLectura) From {
                                                                                            New FiltroLectura With {.Filtro = "-ERR Unable to log on", .Condicion = FiltroLectura.EnumCondicion.Contiene}
                                                                                            }))
            Trabajador_POP.Intervalo = 1000
            Trabajador_POP.Inicia()

            'POP(W3C)
            Registro_POPW3C.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Cualquiera, 5, False, New List(Of FiltroLectura) From {
                                                                                               New FiltroLectura With {.Filtro = "-ERR+Unable+to+log+on", .Condicion = FiltroLectura.EnumCondicion.Contiene}
                                                                                               }))
            Trabajador_POPW3C.Intervalo = 1000
            Trabajador_POPW3C.Inicia()

            'SMTP (Actividad)
            Registro_SMTP.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Cualquiera, 0, False, New List(Of FiltroLectura) From {
                                                                                              New FiltroLectura With {.Filtro = "This mail server requires authentication before sending mail", .Condicion = FiltroLectura.EnumCondicion.Contiene}}))
            Registro_SMTP.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Todo, 0, False, New List(Of FiltroLectura) From {
                                                                                            New FiltroLectura With {.Filtro = "Invalid Username or Password", .Condicion = FiltroLectura.EnumCondicion.Contiene},
                                                                                            New FiltroLectura With {.Filtro = "@", .Condicion = FiltroLectura.EnumCondicion.NoContiene}
                                                                                            }))
            Registro_SMTP.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Todo, 5, True, New List(Of FiltroLectura) From {
                                                                                            New FiltroLectura With {.Filtro = "Invalid Username or Password", .Condicion = FiltroLectura.EnumCondicion.Contiene},
                                                                                            New FiltroLectura With {.Filtro = "@", .Condicion = FiltroLectura.EnumCondicion.Contiene}
                                                                                            }))
            Trabajador_SMTP.Intervalo = 1000
            Trabajador_SMTP.Inicia()

            'SMTP(W3C)
            Registro_SMTPW3C.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Todo, 5, True, New List(Of FiltroLectura) From {
                                                                                                New FiltroLectura With {.Filtro = "Invalid+Username+or+Password", .Condicion = FiltroLectura.EnumCondicion.Contiene},
                                                                                                New FiltroLectura With {.Filtro = "@", .Condicion = FiltroLectura.EnumCondicion.Contiene}
                                                                                                }))
            Registro_SMTPW3C.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Todo, 0, False, New List(Of FiltroLectura) From {
                                                                                                New FiltroLectura With {.Filtro = "Invalid+Username+or+Password", .Condicion = FiltroLectura.EnumCondicion.Contiene},
                                                                                                New FiltroLectura With {.Filtro = "@", .Condicion = FiltroLectura.EnumCondicion.NoContiene}
                                                                                                }))
            Registro_SMTPW3C.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Cualquiera, 0, False, New List(Of FiltroLectura) From {
                                                                                               New FiltroLectura With {.Filtro = "This+mail+server+requires+authentication+before+sending+mail", .Condicion = FiltroLectura.EnumCondicion.Contiene}
                                                                                               }))

            Trabajador_SMTPW3C.Intervalo = 1000
            Trabajador_SMTPW3C.Inicia()

            'IMAP(Actividad)
            Registro_IMAP.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Cualquiera, 5, False, New List(Of FiltroLectura) From {
                                                                                             New FiltroLectura With {.Filtro = "Invalid username or password", .Condicion = FiltroLectura.EnumCondicion.Contiene}
                                                                                             }))
            Trabajador_IMAP.Intervalo = 1000
            Trabajador_IMAP.Inicia()

            'IMAP (W3C)
            Registro_IMAPW3C.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Cualquiera, 5, False, New List(Of FiltroLectura) From {
                                                                                                New FiltroLectura With {.Filtro = "Invalid+username+or+password", .Condicion = FiltroLectura.EnumCondicion.Contiene}
                                                                                                }))
            Trabajador_IMAPW3C.Intervalo = 1000
            Trabajador_IMAPW3C.Inicia()

            'WEB
            Registro_WEB.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Todo, 5, False, New List(Of FiltroLectura) From {
                                                                                            New FiltroLectura With {.Filtro = "POST", .Condicion = FiltroLectura.EnumCondicion.Contiene},
                                                                                            New FiltroLectura With {.Filtro = "Cmd=LOGIN", .Condicion = FiltroLectura.EnumCondicion.Contiene}
                                                                                            }))
            Registro_WEB.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Todo, 5, False, New List(Of FiltroLectura) From {
                                                                                            New FiltroLectura With {.Filtro = "POST", .Condicion = FiltroLectura.EnumCondicion.Contiene},
                                                                                            New FiltroLectura With {.Filtro = "/Mobile/Login.aspx", .Condicion = FiltroLectura.EnumCondicion.Contiene}
                                                                                            }))
            Registro_WEB.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Todo, 0, False, New List(Of FiltroLectura) From {
                                                                                            New FiltroLectura With {.Filtro = "GET", .Condicion = FiltroLectura.EnumCondicion.Contiene},
                                                                                            New FiltroLectura With {.Filtro = " 404 ", .Condicion = FiltroLectura.EnumCondicion.Contiene},
                                                                                            New FiltroLectura With {.Filtro = "favicon.ico", .Condicion = FiltroLectura.EnumCondicion.NoContiene},
                                                                                            New FiltroLectura With {.Filtro = "robots.txt", .Condicion = FiltroLectura.EnumCondicion.NoContiene},
                                                                                            New FiltroLectura With {.Filtro = "sitemap.xml", .Condicion = FiltroLectura.EnumCondicion.NoContiene},
                                                                                            New FiltroLectura With {.Filtro = "BingSiteAuth.xml", .Condicion = FiltroLectura.EnumCondicion.NoContiene},
                                                                                            New FiltroLectura With {.Filtro = "google-site-verification", .Condicion = FiltroLectura.EnumCondicion.NoContiene}
                                                                                            }))
            Registro_WEB.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Todo, 0, False, New List(Of FiltroLectura) From {
                                                                                            New FiltroLectura With {.Filtro = "POST", .Condicion = FiltroLectura.EnumCondicion.Contiene},
                                                                                            New FiltroLectura With {.Filtro = " 404 ", .Condicion = FiltroLectura.EnumCondicion.Contiene}
                                                                                            }))
            Registro_WEB.Filtro.Add(New Tuple(Of Integer, Integer, Boolean, List(Of FiltroLectura))(EnumTipoComparacion.Todo, 0, False, New List(Of FiltroLectura) From {
                                                                                            New FiltroLectura With {.Filtro = "HEAD", .Condicion = FiltroLectura.EnumCondicion.Contiene},
                                                                                            New FiltroLectura With {.Filtro = " 404 ", .Condicion = FiltroLectura.EnumCondicion.Contiene}
                                                                                            }))
            Trabajador_WEB.Intervalo = 1000
            Trabajador_WEB.Inicia()

            'Interfaz
            UcPOPEx.Carpeta.Text = "POP (Ex)"
            UcPOPAct.Carpeta.Text = "POP (Act)"
            UcSMTPEx.Carpeta.Text = "SMTP (Ex)"
            UcSMTPAct.Carpeta.Text = "SMTP (Act)"
            UcIMAPAct.Carpeta.Text = "IMAPP (Act)"
            UcIMAPEx.Carpeta.Text = "IMAPP (Ex)"
            UcWEB.Carpeta.Text = "WEB"

            'ACTIVAR SPAM ASSASIN
            If Not IsNothing(Mod_Core.SpamAssassin) AndAlso Not IsNothing(SpamAssassin.Ejecutable) Then
                'No está Iniciado SpamAssassin
                If SpamAssassin.LogFile.Exists Then SpamAssassin.LogFile.Delete()
                Mod_Core.SpamAssassin.Salida = txtRichSpamAssassin
                Mod_Core.SpamAssassin.Start(Spam.SpamAssassin.SpamAssassinModoInicio.Oculto)
            ElseIf Not IsNothing(SpamAssassin) AndAlso Not IsNothing(SpamAssassin.Proceso) Then
                'Ya está Iniciado SpamAssasin
                SpamAssassin.Ejecutable = New IO.FileInfo(Configuracion.SPAM_SPAMASSASSIN)
                Mod_Core.SpamAssassin.Salida = txtRichSpamAssassin
                SpamAssassin.Read()
            End If
        End Sub

        Private Function RecuperarIpSplit(Linea, Index) As String
            Try
                Return Linea.Split(" ")(Index)
            Catch ex As Exception
                Return "0.0.0.0"
            End Try
        End Function
        Private Function RecuperarIpTab(Linea, Index) As String
            Try
                Return Linea.Split(vbTab)(Index)
            Catch ex As Exception
                Return "0.0.0.0"
            End Try
        End Function

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
            Dim Devolver As Boolean = False
            Try
                Using OpenFile As New IO.FileStream(Archivo, IO.FileMode.Open, IO.FileAccess.Read)
                    'Intenta abrir el archivo en modo lectura y cierra.
                End Using
                Devolver = True
            Catch ex As Exception
                Devolver = False
            End Try
            Try
                If Not Devolver Then
                    Using Acceso = New IO.StreamReader(IO.File.Open(Archivo, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite))
                        'Intenta abrir el archivo bloqueado en modo lectura y cierra.
                    End Using
                    Devolver = True
                End If
            Catch ex As Exception
                Devolver = False
            End Try
            Return Devolver
        End Function
        Private Sub EscanearCarpeta(UcCarpeta As UcAnalizador, DelimitadorIp As Func(Of String, String), Trabajador As Bucle.Bucle, Carpeta As String, ControlCarpeta As RegistroDeArchivos.RegistroDeArchivos, FiltroCarpeta As String)
            'Marcador para evitar analizar los archivos del Dia
            'Dim Ahora As String = Now.Year.ToString("00").Substring(2) & Now.Month.ToString("00") & Now.Day.ToString("00")

            'Actualizar el Interface
            Me.Invoke(Sub() UcCarpeta.ProgresoCarpeta.Maximum = New IO.DirectoryInfo(Carpeta).GetFiles(FiltroCarpeta, IO.SearchOption.TopDirectoryOnly).Count)
            If Not UcCarpeta.Archivo.Text.Contains("-") Then Me.Invoke(Sub() UcCarpeta.Archivo.Text = "0 - 0")
            'Buscar Archivos en la Carpeta
            'Dim Archivos As IO.FileInfo() = New IO.DirectoryInfo(Carpeta).GetFiles(FiltroCarpeta, IO.SearchOption.TopDirectoryOnly)
            'Dim Ordenados = Archivos.OrderBy(Function(file) file.CreationTime)
            Dim Ordenados = From Archivo In New IO.DirectoryInfo(Carpeta).GetFiles(FiltroCarpeta, IO.SearchOption.TopDirectoryOnly)
                            Order By Archivo.LastWriteTime Ascending
                            Select Archivo

            'For Each Archivo In New IO.DirectoryInfo(Carpeta).GetFiles(FiltroCarpeta, IO.SearchOption.TopDirectoryOnly)
            For Each Archivo In Ordenados
                'Actualizar Interface
                Me.Invoke(Sub()
                              'Progreso
                              UcCarpeta.ProgresoCarpeta.Value = ControlCarpeta.Count
                              'Label
                              UcCarpeta.ContadorCarpeta.Text = String.Format("{0} - {1}", ControlCarpeta.Count, UcCarpeta.ProgresoCarpeta.Maximum)
                              'Archivo
                              UcCarpeta.Archivo.Text = Archivo.Name
                          End Sub)

                If Not ControlCarpeta.Contains(Archivo.Name) AndAlso esLegible(Archivo.FullName) Then
                    'Analizar Archivo
                    Dim EscanearArchivo As New LecturaDeArchivo(Archivo.FullName) With {.ObtenerIp = DelimitadorIp, .Filtros = ControlCarpeta.Filtro}
                    'Enlazar con el Evento para visualizar el progreso de la lectura
                    AddHandler EscanearArchivo.Progreso, Sub(Index, Total)
                                                             'Actualizar el Interface
                                                             Me.Invoke(Sub()
                                                                           UcCarpeta.ProgresoArchivo.Maximum = Total
                                                                           UcCarpeta.ProgresoArchivo.Value = Index
                                                                           UcCarpeta.ContadorArchivo.Text = String.Format("{0} - {1}", Index, Total)
                                                                       End Sub)
                                                         End Sub
                    'Mandar a analizar y esperar
                    EscanearArchivo.Escanear()

                    'Actualizar la lista de Bloqueo si encuentra Ips a Bloquear
                    If EscanearArchivo.FiltroIp.Count > 0 Then BloquearIps(EscanearArchivo.FiltroIp)

                    'Registramos el Archivo Analizado, si no es el LOG Actual(Now) ya que esta en continuo crecimiento.
                    If Archivo.LastWriteTime.Date < Date.Now.Date Then ControlCarpeta.Add(Archivo.Name)
                    'If DateDiff(DateInterval.Hour, Archivo.LastWriteTime, Now) > 8 Then ControlCarpeta.Add(Archivo.Name)
                End If
            Next

            'Mandamos a analizar Cada Minuto
            Trabajador.Intervalo = 60000

            'Propagamos la configuracion
            BtnPropagarIps_Click(Nothing, New EventArgs)

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
            EscanearCarpeta(UcPOPAct, Function(Linea) RecuperarIpTab(Linea, 3), Trabajador_POP, Mod_Core.Configuracion.POP, Registro_POP, "POP-Activity*.log")
        End Sub

        Private Sub Trabajador_POPW3C_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_POPW3C.IBucle_Bucle
            'Trabajo en BackGround
            EscanearCarpeta(UcPOPEx, Function(Linea) RecuperarIpSplit(Linea, 2), Trabajador_POPW3C, Mod_Core.Configuracion.POP, Registro_POPW3C, "ex*.log")
        End Sub

        Private Sub Trabajador_SMTP_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_SMTP.IBucle_Bucle
            'Trabajo en BackGround
            EscanearCarpeta(UcSMTPAct, Function(linea) RecuperarIpTab(linea, 4), Trabajador_SMTP, Mod_Core.Configuracion.SMTP, Registro_SMTP, "SMTP-Activity*.log")
        End Sub
        Private Sub Trabajador_SMTPW3C_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_SMTPW3C.IBucle_Bucle
            'Trabajo en BackGround
            'EscanearCarpeta(UcSMTPEx, Function(Linea) Linea.Split(" ")(2), Trabajador_SMTPW3C, Mod_Core.Configuracion.SMTP, Registro_SMTPW3C, "ex*.log")
            EscanearCarpeta(UcSMTPEx, Function(Linea) RecuperarIpSplit(Linea, 2), Trabajador_SMTPW3C, Mod_Core.Configuracion.SMTP, Registro_SMTPW3C, "ex*.log")
        End Sub
        Private Sub Trabajador_IMAP_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_IMAP.IBucle_Bucle
            'Trabajo en BackGround
            EscanearCarpeta(UcIMAPAct, Function(Linea) RecuperarIpTab(Linea, 4), Trabajador_IMAP, Mod_Core.Configuracion.IMAP, Registro_IMAP, "IMAP-Activity*.log")
        End Sub
        Private Sub Trabajador_IMAPW3C_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_IMAPW3C.IBucle_Bucle
            'Trabajo en BackGround
            EscanearCarpeta(UcIMAPEx, Function(Linea) RecuperarIpSplit(Linea, 2), Trabajador_IMAPW3C, Mod_Core.Configuracion.IMAP, Registro_IMAPW3C, "ex*.log")
        End Sub

        Private Sub Trabajador_WEB_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_WEB.IBucle_Bucle
            'Trabajo en BackGround
            EscanearCarpeta(UcWEB, Function(Linea) RecuperarIpSplit(Linea, 8), Trabajador_WEB, Mod_Core.Configuracion.WEB, Registro_WEB, "u_ex*.log")
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
                                            If InvokeRequired Then
                                                Invoke(Sub() .Location = New Point(Me.Location.X + (Me.Width - .Width) \ 2, Me.Location.Y + (Me.Height - .Height) \ 2))
                                                Invoke(Sub() .ShowDialog(Me))
                                            Else
                                                .Location = New Point(Me.Location.X + (Me.Width - .Width) \ 2, Me.Location.Y + (Me.Height - .Height) \ 2)
                                                .ShowDialog(Me)
                                            End If

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

        Private Sub txtRichSpamAssassin_TextChanged(sender As Object, e As EventArgs) Handles txtRichSpamAssassin.TextChanged
            txtRichSpamAssassin.SelectionStart = txtRichSpamAssassin.Text.Length
            txtRichSpamAssassin.ScrollToCaret()
        End Sub

        Private Sub TimerIpBan_Tick(sender As Object, e As EventArgs) Handles TimerIpBan.Tick
            If Not IsNothing(SpamAssassin) Then
                If Not IsNothing(SpamAssassin.Proceso) Then
                    If SpamAssassin.Corriendo Then
                        lblEstadoSpamAssasin.BackColor = Color.Green
                        TSMIniciarSpamAssassin.Visible = False
                        TSMDetener.Visible = True
                    Else
                        lblEstadoSpamAssasin.BackColor = Color.Red
                        TSMIniciarSpamAssassin.Visible = True
                        TSMDetener.Visible = False
                    End If

                End If
            End If
        End Sub

        Private Sub TSMDetener_Click(sender As Object, e As EventArgs) Handles TSMDetener.Click
            If Not IsNothing(Mod_Core.SpamAssassin) Then Mod_Core.SpamAssassin.Kill()
        End Sub

        Private Sub TSMIniciarSmapAssassinNormal_Click(sender As Object, e As EventArgs) Handles TSMIniciarSmapAssassinNormal.Click
            SpamAssassin.Start(Spam.SpamAssassin.SpamAssassinModoInicio.Normal)
        End Sub

        Private Sub TSMIniciarSmapAssassinOculto_Click(sender As Object, e As EventArgs) Handles TSMIniciarSmapAssassinOculto.Click
            SpamAssassin.Start(Spam.SpamAssassin.SpamAssassinModoInicio.Oculto)
        End Sub
    End Class
End Namespace