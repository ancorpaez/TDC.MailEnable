Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Threading
Imports TDC.MailEnable.IpBan.MailEnableLog
Imports TDC.MailEnable.IpBan.RegistroDeArchivos
Imports TDC.MailEnable.IpBan.RegistroDeArchivos.LecturaDeArchivo
Imports TDC.MailEnable.Core
Imports System.Reflection
Imports System.Net.NetworkInformation

Namespace Interfaz
    Public Class IpBan

        'POP
        'Private WithEvents Trabajador_POP As New Bucle.DoBucle("Trabajador_POP")
        'Private Registro_POP As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_POP))
        Private WithEvents Trabajador_POPW3C As New Bucle.DoBucle("Trabajador_POPW3C")
        Private Registro_POPW3C As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_POPW3C))
        'Private POP_DENY As Cls_MailEnableDeny

        'SMTP
        ' Private WithEvents Trabajador_SMTP As New Bucle.DoBucle("Trabajador_SMTP")
        'Private Registro_SMTP As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_SMTP))
        Private WithEvents Trabajador_SMTPW3C As New Bucle.DoBucle("Trabajador_SMTPW3C")
        Private Registro_SMTPW3C As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_SMTPW3C))
        'Private SMTP_DENY As Cls_MailEnableDeny

        'IMAP
        'Private WithEvents Trabajador_IMAP As New Bucle.DoBucle("Trabajador_IMAP")
        'Private Registro_IMAP As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_IMAP))
        Private WithEvents Trabajador_IMAPW3C As New Bucle.DoBucle("Trabajador_IMAPW3C")
        Private Registro_IMAPW3C As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_IMAPW3C))

        'WEB
        Private WithEvents Trabajador_WEB As New Bucle.DoBucle("Trabajador_WEB")
        Private Registro_WEB As New RegistroDeArchivos.RegistroDeArchivos(NameOf(Registro_WEB))
        'Private ISSServer As Cls_ISS

        'PUBLICAR IP
        Private Publicador As Frm_PublicarIps = Nothing
        Private Shared SyncLockPublicador As New Object

        'CONTROL DE PROGRESO
        Private iFaceControlIndex As New System.Collections.Concurrent.ConcurrentDictionary(Of UcAnalizador, LecturaDeArchivo)
        Private Shared SyncActualizarProgresoArchivo As New Object

        'RElacion Tabs Tablas
        Private CalRelation As KeyValuePair(Of TabPage, DataGridView)
        Private MaiRelation As KeyValuePair(Of TabPage, DataGridView)
        Private VcfRelation As KeyValuePair(Of TabPage, DataGridView)
        Private TskRelation As KeyValuePair(Of TabPage, DataGridView)
        Private Relation As New Collections.Concurrent.ConcurrentDictionary(Of String, KeyValuePair(Of TabPage, DataGridView))

        'Pruebas
        'Private WithEvents MiBucle As New Core.Bucle.DoBucle("MiBucle")

        Private Sub IpBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            '**** TEST****
            'Dim Test As New Core.GeoLocalizacion.MyNsLookUp
            'Dim Tes2 = Test.EsLegitima("104.26.7.164")
            'Dim Tes0 = Test.EsLegitima("185.92.245.33")
            'Dim Tes1 = Test.EsLegitima("129.126.197.254")
            'MiBucle.Intervalo = 1
            'MiBucle.Iniciar()
            '*************
            'Dim test5 = New Threading.Thread(Sub()
            '                                     Dim d5 As New TDC.MailEnable.Core.Bucle.DoBucle("Test5")
            '                                 End Sub)
            'test5.Start()

            'Iniciar Log Temporal
            LOG.Logs.TryAdd(LOG.MemoryLOG.EnumLogs.General, New LOG.LogConfig With {.Salida = SalidaConsola})
            LOG.Logs.TryAdd(LOG.MemoryLOG.EnumLogs.CrossDomain, New LOG.LogConfig With {.Salida = SalidaCrossDomain})
            LOG.Main()

            Mod_Core.IpBanForm = Me
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


            'POP(W3C)
            Registro_POPW3C.Filtro.Add(New Cls_Filtro With {
                                       .Key = FilterKeys.FilterKey.PopLoginFail, .TrueSi = Cls_Filtro.EnumTipoComparacion.Cualquiera, .Repeteciones = 3, .VerificarMailBox = True, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                       New Cls_Coincidencia With {.Filtro = "-ERR+Unable+to+log+on", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})

            EstablecerConcidenciasPais(FilterKeys.FilterKey.PopLoginFail, "PT", 20)
            Trabajador_POPW3C.Intervalo = 100
            Trabajador_POPW3C.Iniciar()

            'SMTP(W3C)
            Registro_SMTPW3C.Filtro.Add(
                New Cls_Filtro With {
                .Key = FilterKeys.FilterKey.SMTPLoginFailMailBox,
                .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo,
                .Repeteciones = 3,
                .VerificarMailBox = True,
                .Coincidencias = New List(Of Cls_Coincidencia) From {
                New Cls_Coincidencia With {.Filtro = "Invalid+Username+or+Password", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                New Cls_Coincidencia With {.Filtro = "@", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}
                }})
            EstablecerConcidenciasPais(FilterKeys.FilterKey.SMTPLoginFailMailBox, "PT", 20)

            Registro_SMTPW3C.Filtro.Add(
                New Cls_Filtro With {
                .Key = FilterKeys.FilterKey.SMTPLoginFailNoMailBox,
                .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo,
                .Repeteciones = 0,
                .VerificarMailBox = False,
                .Coincidencias = New List(Of Cls_Coincidencia) From {
                New Cls_Coincidencia With {.Filtro = "Invalid+Username+or+Password", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                New Cls_Coincidencia With {.Filtro = "@", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene}
                }})
            EstablecerConcidenciasPais(FilterKeys.FilterKey.SMTPLoginFailNoMailBox, "PT", 20)

            Registro_SMTPW3C.Filtro.Add(
                New Cls_Filtro With {
                .Key = FilterKeys.FilterKey.SMTPOutNoLogin,
                .TrueSi = Cls_Filtro.EnumTipoComparacion.Cualquiera,
                .Repeteciones = 0,
                .VerificarMailBox = False,
                .Coincidencias = New List(Of Cls_Coincidencia) From {
                New Cls_Coincidencia With {.Filtro = "This+mail+server+requires+authentication+before+sending+mail",
                .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}
                }})
            EstablecerConcidenciasPais(FilterKeys.FilterKey.SMTPOutNoLogin, "PT", 20)

            Registro_SMTPW3C.Filtro.Add(
                New Cls_Filtro With {
                .Key = FilterKeys.FilterKey.SMTPMultipleDomainLogin,
                .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo,
                .Repeteciones = 0,
                .VerificarMailBox = False,
                .DetectarCrossDomainLogin = True,
                .Coincidencias = New List(Of Cls_Coincidencia) From {
                New Cls_Coincidencia With {.Filtro = "235+Authenticated",
                .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}
                }})

            Trabajador_SMTPW3C.Intervalo = 100
            Trabajador_SMTPW3C.Iniciar()



            'IMAP (W3C)
            Registro_IMAPW3C.Filtro.Add(New Cls_Filtro With {
                                        .Key = FilterKeys.FilterKey.IMAPLoginFail,
                                        .TrueSi = Cls_Filtro.EnumTipoComparacion.Cualquiera,
                                        .Repeteciones = 3,
                                        .VerificarMailBox = True,
                                        .Coincidencias = New List(Of Cls_Coincidencia) From {
                                        New Cls_Coincidencia With {.Filtro = "Invalid+username+or+password",
                                        .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})
            EstablecerConcidenciasPais(FilterKeys.FilterKey.IMAPLoginFail, "PT", 20)

            Registro_IMAPW3C.Filtro.Add(New Cls_Filtro With {
                                        .Key = FilterKeys.FilterKey.IMAPMultipleDomainLogin,
                                        .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo,
                                        .Repeteciones = 0,
                                        .VerificarMailBox = False,
                                        .DetectarCrossDomainLogin = True,
                                        .Coincidencias = New List(Of Cls_Coincidencia) From {
                                        New Cls_Coincidencia With {.Filtro = "LOGIN LOGIN", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                        New Cls_Coincidencia With {.Filtro = "completed", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})

            Registro_IMAPW3C.Filtro.Add(New Cls_Filtro With {
                                        .Key = FilterKeys.FilterKey.IMAPMultipleDomainLogin,
                                        .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo,
                                        .Repeteciones = 0,
                                        .VerificarMailBox = False,
                                        .DetectarCrossDomainLogin = True,
                                        .Coincidencias = New List(Of Cls_Coincidencia) From {
                                        New Cls_Coincidencia With {.Filtro = "AUTHENTICATE AUTHENTICATE", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                        New Cls_Coincidencia With {.Filtro = "completed", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                        New Cls_Coincidencia With {.Filtro = "Unsupported+command", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene}}})
            Trabajador_IMAPW3C.Intervalo = 100
            Trabajador_IMAPW3C.Iniciar()

            'WEB
            Registro_WEB.Filtro.Add(New Cls_Filtro With {
                                    .Key = FilterKeys.FilterKey.WEBPostLogin,
                                    .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo, .Repeteciones = 3, .VerificarMailBox = False, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                    New Cls_Coincidencia With {.Filtro = "POST", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = "Cmd=LOGIN", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})
            EstablecerConcidenciasPais(FilterKeys.FilterKey.WEBPostLogin, "PT", 20)
            Registro_WEB.Filtro.Add(New Cls_Filtro With {
                                    .Key = FilterKeys.FilterKey.WEBGetFail, .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo, .Repeteciones = 0, .VerificarMailBox = False, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                    New Cls_Coincidencia With {.Filtro = "GET", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = " 404 ", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = "favicon.ico", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene},
                                    New Cls_Coincidencia With {.Filtro = "robots.txt", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene},
                                    New Cls_Coincidencia With {.Filtro = "sitemap.xml", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene},
                                    New Cls_Coincidencia With {.Filtro = "BingSiteAuth.xml", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene},
                                    New Cls_Coincidencia With {.Filtro = "google-site-verification", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene}}})
            EstablecerConcidenciasPais(FilterKeys.FilterKey.WEBGetFail, "PT", 20)
            Registro_WEB.Filtro.Add(New Cls_Filtro With {
                                    .Key = FilterKeys.FilterKey.WEBPost404, .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo, .Repeteciones = 0, .VerificarMailBox = False, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                    New Cls_Coincidencia With {.Filtro = "POST", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = " 404 ", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = "POST", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = "/Mobile/Login.aspx", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})
            EstablecerConcidenciasPais(FilterKeys.FilterKey.WEBPost404, "PT", 20)
            Registro_WEB.Filtro.Add(New Cls_Filtro With {
                                    .Key = FilterKeys.FilterKey.WEBHead404, .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo, .Repeteciones = 0, .VerificarMailBox = False, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                    New Cls_Coincidencia With {.Filtro = "HEAD", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = " 404 ", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})
            EstablecerConcidenciasPais(FilterKeys.FilterKey.WEBHead404, "PT", 20)

            Trabajador_WEB.Intervalo = 100
            Trabajador_WEB.Iniciar()

            'Interfaz
            UcPOPEx.Carpeta.Text = "POP (Ex)"
            UcSMTPEx.Carpeta.Text = "SMTP (Ex)"
            UcIMAPEx.Carpeta.Text = "IMAPP (Ex)"
            UcWEB.Carpeta.Text = "WebMail"

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

            'Relacionar Tabs con Tablas
            CalRelation = New KeyValuePair(Of TabPage, DataGridView)(TabPCAL, TablaMailBackupCAL)
            MaiRelation = New KeyValuePair(Of TabPage, DataGridView)(TabPMAI, TablaMailBackupMAI)
            VcfRelation = New KeyValuePair(Of TabPage, DataGridView)(TabPVCF, TablaMailBackupVCF)
            TskRelation = New KeyValuePair(Of TabPage, DataGridView)(TabPTSK, TablaMailBackupTSK)

            Relation.TryAdd(CalRelation.Key.Name, CalRelation)
            Relation.TryAdd(MaiRelation.Key.Name, MaiRelation)
            Relation.TryAdd(VcfRelation.Key.Name, VcfRelation)
            Relation.TryAdd(TskRelation.Key.Name, TskRelation)

            'Indexar los Emails del Backup
            Backup.Main()


            'Comprobar si las Rutas de Backup son Accesibles
            If IO.Directory.Exists(Configuracion.CARPETA_BACKUP) Then
                'Cargar PostOffices del Backup
                Dim Desechar As Task = Task.Run(Sub() LoadFolders(Configuracion.CARPETA_BACKUP, TreePostOffices))
            End If

            'Certificados
            Certificados.Main(MailEnableLog.IpBanForm.TabNavegadores, lstCertificados, lstLogDescargaCertificado)

            'Reparador AutoResponder
            AutoResponder.Main()
        End Sub


        Private Sub LoadFolders(rootPath As String, treeView As TreeView)
            ' Limpia el TreeView
            'treeView.Nodes.Clear()
            Me.Invoke(Sub() treeView.Enabled = False)

            ' Agrega el nodo raíz al TreeView
            Dim rootNode As TreeNode
            If Not treeView.Nodes.ContainsKey(rootPath) Then
                rootNode = New TreeNode(rootPath) With {.Name = rootPath}
                Me.Invoke(Sub() treeView.Nodes.Add(rootNode))
            Else
                rootNode = treeView.Nodes(rootPath)
            End If

            ' Llama a la función recursiva para agregar las subcarpetas
            LoadSubfolders(rootPath, rootNode)
            Me.Invoke(Sub() treeView.Enabled = True)
        End Sub

        Private Sub LoadSubfolders(folderPath As String, parentNode As TreeNode)
            ' Recorre las subcarpetas del directorio dado

            For Each subFolder In IO.Directory.GetDirectories(folderPath, "*", IO.SearchOption.TopDirectoryOnly)
                ' Agrega cada subcarpeta como un nodo hijo
                If Not {"indexroot", "pubroot", "chatroot"}.Any(Function(Carpeta) subFolder.ToLower.Contains(Carpeta)) Then
                    Try
                        Dim subFolderNode As TreeNode
                        If Not parentNode.Nodes.ContainsKey(subFolder) Then
                            subFolderNode = New TreeNode(IO.Path.GetFileName(subFolder)) With {.Name = subFolder}
                            If Not Me.IsDisposed AndAlso Not Me.Disposing Then Me.Invoke(Sub() parentNode.Nodes.Add(subFolderNode))
                        Else
                            subFolderNode = parentNode.Nodes(subFolder)
                        End If
                        ' Llama recursivamente a esta función para agregar subcarpetas de forma recursiva
                        LoadSubfolders(subFolder, subFolderNode)
                    Catch ex As Exception

                    End Try
                End If
            Next
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
        Private Sub EscanearCarpeta(UcCarpeta As UcAnalizador, DelimitadorIp As Func(Of String, String), Trabajador As Bucle.DoBucle, Carpeta As String, ControlCarpeta As RegistroDeArchivos.RegistroDeArchivos, FiltroCarpeta As String)
            'Ordenar los Archivos por FECHA
            Dim Ordenados = From Archivo In New IO.DirectoryInfo(Carpeta).GetFiles(FiltroCarpeta, IO.SearchOption.TopDirectoryOnly)
                            Order By Archivo.LastWriteTime Ascending
                            Select Archivo

            'Actualizar el Interface
            If Not Me.IsDisposed OrElse Me.Disposing Then Me.Invoke(Sub() UcCarpeta.ProgresoCarpeta.Maximum = Ordenados.Count)

            'Analizar cada archvivo
            For Each Archivo In Ordenados

                If Not ControlCarpeta.Contains(Archivo.Name) AndAlso esLegible(Archivo.FullName) Then
                    'Establecer una Memoria de Archivo
                    If Not ArchivosEnMemoria.Archivos.ContainsKey(Archivo.FullName) Then ArchivosEnMemoria.Archivos.TryAdd(Archivo.FullName, New ArchivosEnMemoria.Archivo)
                    'Analizar Archivo
                    Dim EscanearArchivo As New LecturaDeArchivo(Archivo.FullName) With {.ObtenerIp = DelimitadorIp, .Filtros = ControlCarpeta.Filtro, .Index = ArchivosEnMemoria.Archivos(Archivo.FullName).Line}

                    'Actualizar Progreso Archivos
                    Me.Invoke(Sub()
                                  UcCarpeta.ProgresoCarpeta.Value = ControlCarpeta.Count
                                  UcCarpeta.ContadorCarpeta.Text = String.Format("{0} - {1}", ControlCarpeta.Count, UcCarpeta.ProgresoCarpeta.Maximum)
                                  UcCarpeta.Archivo.Text = Archivo.Name
                              End Sub)

                    'Enlazar Archivo al Control para Visualizacion de Progreso de la Lectura del Archivo
                    If Not iFaceControlIndex.ContainsKey(UcCarpeta) Then iFaceControlIndex.TryAdd(UcCarpeta, EscanearArchivo) Else iFaceControlIndex.TryUpdate(UcCarpeta, EscanearArchivo, iFaceControlIndex(UcCarpeta))

                    'Mandar a analizar y esperar
                    EscanearArchivo.Escanear()

                    'Actualizar la lista de Bloqueo si encuentra Ips a Bloquear
                    If EscanearArchivo.FiltroIp.Count > 0 Then BloquearIps(EscanearArchivo.FiltroIp)

                    'Registramos el Archivo Analizado, si no es el LOG Actual(Now) ya que esta en continuo crecimiento.
                    If Archivo.LastWriteTime.Date < Date.Now.Date Then
                        'Registramos el Archivo como Analizado
                        ControlCarpeta.Add(Archivo.Name)

                        'Eliminamos el Control de Valores del Archivo
                        If ArchivosEnMemoria.Archivos.ContainsKey(Archivo.FullName) Then ArchivosEnMemoria.Archivos.TryRemove(Archivo.FullName, Nothing)

                        'Eliminamos el Bucle del archivo
                        Core.Bucle.Remove(Archivo.FullName)
                    End If

                    EscanearArchivo.Dispose()
                End If
            Next
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

        Private Sub Trabajador_POPW3C_Background(Sender As Object, Detener As Bucle.BackgroundEventArgs) Handles Trabajador_POPW3C.BackGround
            'Trabajo en BackGround
            EscanearCarpeta(UcPOPEx, Function(Linea) RecuperarIpSplit(Linea, 2), Trabajador_POPW3C, Mod_Core.Configuracion.POP, Registro_POPW3C, "ex*.log")

            'Propagamos la configuracion de Bloqueo de IP
            BtnPropagarIps_Click(Nothing, New EventArgs)
        End Sub
        Private Sub Trabajador_POPW3C_Foreground(Sender As Object, Detener As Bucle.BackgroundEventArgs) Handles Trabajador_POPW3C.ForeGround
            'Detenemos el procesamiento
            Trabajador_POPW3C.Detener()
        End Sub
        Private Sub Trabajador_POPW3C_Endground(Sender As Object, Detener As Bucle.BackgroundEventArgs) Handles Trabajador_POPW3C.EndGround
            'Relajamos en bucle de Busqueda de Archivos
            Trabajador_POPW3C.Cancelar = False
            Trabajador_POPW3C.Intervalo = Configuracion.LECTURA_REPOSO
        End Sub
        Private Sub Trabajador_SMTPW3C_Background(Sender As Object, Detener As Bucle.BackgroundEventArgs) Handles Trabajador_SMTPW3C.BackGround
            'Trabajo en BackGround
            EscanearCarpeta(UcSMTPEx, Function(Linea) RecuperarIpSplit(Linea, 2), Trabajador_SMTPW3C, Mod_Core.Configuracion.SMTP, Registro_SMTPW3C, "ex*.log")

            'Propagamos la configuracion de Bloqueo de IP
            BtnPropagarIps_Click(Nothing, New EventArgs)
        End Sub
        Private Sub Trabajador_SMTPW3C_Foreground(Sender As Object, Detener As Bucle.BackgroundEventArgs) Handles Trabajador_SMTPW3C.ForeGround
            'Detenemos el procesamiento
            Trabajador_SMTPW3C.Detener()
        End Sub

        Private Sub Trabajador_SMTPW3C_Endground(Sender As Object, Detener As Bucle.BackgroundEventArgs) Handles Trabajador_SMTPW3C.EndGround
            'Relajamos en bucle de Busqueda de Archivos
            Trabajador_SMTPW3C.Cancelar = False
            Trabajador_SMTPW3C.Intervalo = Configuracion.LECTURA_REPOSO
        End Sub
        Private Sub Trabajador_IMAPW3C_Background(Sender As Object, Detener As Bucle.BackgroundEventArgs) Handles Trabajador_IMAPW3C.BackGround
            'Trabajo en BackGround
            EscanearCarpeta(UcIMAPEx, Function(Linea) RecuperarIpSplit(Linea, 2), Trabajador_IMAPW3C, Mod_Core.Configuracion.IMAP, Registro_IMAPW3C, "ex*.log")

            'Propagamos la configuracion de Bloqueo de IP
            BtnPropagarIps_Click(Nothing, New EventArgs)
        End Sub
        Private Sub Trabajador_IMAPW3C_Foreground(Sender As Object, Detener As Bucle.BackgroundEventArgs) Handles Trabajador_IMAPW3C.ForeGround
            'Detenemos el procesamiento
            Trabajador_IMAPW3C.Detener()
        End Sub

        Private Sub Trabajador_IMAPW3C_Endground(Sender As Object, Detener As Bucle.BackgroundEventArgs) Handles Trabajador_IMAPW3C.EndGround
            'Relajamos en bucle de Busqueda de Archivos
            Trabajador_IMAPW3C.Cancelar = False
            Trabajador_IMAPW3C.Intervalo = Configuracion.LECTURA_REPOSO
        End Sub
        Private Sub Trabajador_WEB_Background(Sender As Object, Detener As Bucle.BackgroundEventArgs) Handles Trabajador_WEB.BackGround
            'Trabajo en BackGround
            EscanearCarpeta(UcWEB, Function(Linea) RecuperarIpSplit(Linea, 8), Trabajador_WEB, Mod_Core.Configuracion.WEB, Registro_WEB, "u_ex*.log")

            'Propagamos la configuracion de Bloqueo de IP
            BtnPropagarIps_Click(Nothing, New EventArgs)
        End Sub
        Private Sub Trabajador_WEB_Foreground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles Trabajador_WEB.ForeGround
            'Detenemos el procesamiento
            Trabajador_WEB.Detener()
        End Sub
        Private Sub Trabajador_WEB_Endground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles Trabajador_WEB.EndGround
            'Relajamos en bucle de Busqueda de Archivos
            Trabajador_WEB.Cancelar = False
            Trabajador_WEB.Intervalo = Configuracion.LECTURA_REPOSO
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
                If Monitor.TryEnter(SyncLockPublicador) Then

                    If IsNothing(Publicador) Then
                        'Cerrar Entrada a los otros Trabajadores
                        Using Publicador = New Frm_PublicarIps
                            Using ListaSMTP = New Cls_MailEnableDeny(Mod_Core.Configuracion.SMTP_DENY)
                                If ListaSMTP.Count <> IpBaneadas.Count Then
                                    If Not ChkDetenerPublicacion.Checked Then
                                        With Publicador
                                            .ListaIPBaneadas = IpBaneadas.ToQuene
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
                        Monitor.Exit(SyncLockPublicador)
                    End If
                End If
            Catch ex As Exception
                Monitor.Exit(SyncLockPublicador)
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

        Private Sub TimerGuiAnalizador_Tick(sender As Object, e As EventArgs) Handles TimerGuiAnalizador.Tick
            If Monitor.TryEnter(SyncActualizarProgresoArchivo) Then
                Dim iFace As UcAnalizador
                Dim Lector As LecturaDeArchivo
                For Each iUserControl In iFaceControlIndex
                    Try
                        iFace = iUserControl.Key
                        Lector = iUserControl.Value
                        iFace.ProgresoArchivo.Maximum = Lector.Total
                        If Lector.Index <= iFace.ProgresoArchivo.Maximum Then iFace.ProgresoArchivo.Value = Lector.Index
                        iFace.ContadorArchivo.Text = String.Format("{0} - {1}", Lector.Index, Lector.Total)
                    Catch ex As Exception
                    End Try
                Next
                Monitor.Exit(SyncActualizarProgresoArchivo)
            End If

        End Sub



#Region "Tablas Backup"
        Private Sub TreePostOffices_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreePostOffices.AfterSelect

            'Limpiar Filtros
            Dim Filtradores As New List(Of TextBox) From {
                txtMaiAsunto,
                txtMaiDestinatarios,
                txtMaiRemitente,
                txtCalDescripcion,
                txtCalHubicacion,
                txtTskAsunto,
                txtTskNotas,
                txtVcfCompleto,
                txtVcfEmail,
                txtVcfNick,
                txtVcfNombre,
                txtVcfPersonal,
                txtVcfTrabajo}
            For Each Filtrador In Filtradores
                Filtrador.Text = String.Empty
            Next

            'Filtrar por Carpeta
            Try
                TreePostOffices.Enabled = False

                'MAI
                Dim FiltroMAI() As DataRow = Backup.MAI.Tabla.Select("Archivo LIKE '%" & e.Node.FullPath & "%'")
                Dim DatosMAI As DataTable = Backup.MAI.Tabla.Clone
                For Each Linea In FiltroMAI
                    DatosMAI.ImportRow(Linea)
                Next
                DatosMAI.DefaultView.Sort = "Fecha DESC"
                TablaMailBackupMAI.DataSource = DatosMAI

                'VCF
                Dim FiltroVCF() As DataRow = Backup.VCF.Tabla.Select("Archivo LIKE '%" & e.Node.FullPath & "%'")
                Dim DatosVCF As DataTable = Backup.VCF.Tabla.Clone
                For Each Linea In FiltroVCF
                    DatosVCF.ImportRow(Linea)
                Next
                TablaMailBackupVCF.DataSource = DatosVCF

                'CAL
                Dim FiltroCAL() As DataRow = Backup.CAL.Tabla.Select("Archivo LIKE '%" & e.Node.FullPath & "%'")
                Dim DatosCAL As DataTable = Backup.CAL.Tabla.Clone
                For Each Linea In FiltroCAL
                    DatosCAL.ImportRow(Linea)
                Next
                TablaMailBackupCAL.DataSource = DatosCAL

                'TSK
                Dim FiltroTSK() As DataRow = Backup.TSK.Tabla.Select("Archivo LIKE '%" & e.Node.FullPath & "%'")
                Dim DatosTSK As DataTable = Backup.TSK.Tabla.Clone
                For Each Linea In FiltroTSK
                    DatosTSK.ImportRow(Linea)
                Next
                TablaMailBackupTSK.DataSource = DatosTSK

                TreePostOffices.Enabled = True
                lblMensajesBackup.Text = ""
            Catch ex As Exception
                lblMensajesBackup.Text = ex.Message
                TreePostOffices.Enabled = True
            End Try

        End Sub

        Private Sub TablaMailBackupMAI_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles TablaMailBackupMAI.CellContentDoubleClick
            VisualizarEnOutlookToolStripMenuItem_Click(sender, e)
        End Sub
        Private Sub Tablas_EnabledChanged(sender As Object, e As EventArgs) Handles TablaMailBackupMAI.EnabledChanged, TablaMailBackupVCF.EnabledChanged, TablaMailBackupTSK.EnabledChanged, TablaMailBackupCAL.EnabledChanged
            CType(sender, DataGridView).ForeColor = If(CType(sender, DataGridView).Enabled, Color.Black, Color.LightGray)
        End Sub
        Private Sub TabBackup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabBackup.SelectedIndexChanged
            Tablas_DataSourceChanged(Relation(TabBackup.SelectedTab.Name).Value, e)
        End Sub
        Private Sub Tablas_DataSourceChanged(sender As Object, e As EventArgs) Handles TablaMailBackupMAI.DataSourceChanged, TablaMailBackupCAL.DataSourceChanged, TablaMailBackupTSK.DataSourceChanged, TablaMailBackupVCF.DataSourceChanged
            Try
                If CType(sender, DataGridView).Name = Relation(TabBackup.SelectedTab.Name).Value.Name Then
                    Dim Tabla As DataGridView = sender
                    If Not IsNothing(Tabla.DataSource) Then
                        If Tabla.DataSource.GetType = GetType(DataTable) Then
                            lblMailBackupSeleccionados.Text = $"{CType(Tabla.DataSource, DataTable).Rows.Count} Indexados."
                        Else
                            lblMailBackupSeleccionados.Text = $"{CType(Tabla.DataSource, DataView).Count} Indexados."
                        End If
                        Tabla.Columns("ID").Visible = False
                        Tabla.Columns("Archivo").Visible = False
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub
        Private Sub Tablas_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles TablaMailBackupMAI.RowEnter, TablaMailBackupCAL.RowEnter, TablaMailBackupTSK.RowEnter, TablaMailBackupVCF.RowEnter
            If CType(sender, DataGridView).SelectedRows.Count > 0 Then
                lblMensajesBackup.Text = CType(sender, DataGridView).SelectedRows(0).Cells(1).Value
            End If
        End Sub
        Private Sub BuscarEmail(sender As Object, e As EventArgs) Handles txtMaiAsunto.TextChanged, txtMaiRemitente.TextChanged, txtMaiDestinatarios.TextChanged
            Dim Filtro As DataView
            If TablaMailBackupMAI.DataSource.GetType = GetType(DataTable) Then
                Filtro = New DataView(TablaMailBackupMAI.DataSource)
                TablaMailBackupMAI.DataSource = Filtro
            Else
                Filtro = TablaMailBackupMAI.DataSource
            End If
            Filtro.RowFilter = $"Asunto LIKE '%{txtMaiAsunto.Text}%' 
                                AND Remitente LIKE '%{txtMaiRemitente.Text}%'
                                AND Destinatarios LIKE '%{txtMaiDestinatarios.Text}%'"
            lblMailBackupSeleccionados.Text = $"{CType(TablaMailBackupMAI.DataSource, DataView).Count} Indexados."
        End Sub
        Private Sub BuscarCalendario(sender As Object, e As EventArgs) Handles txtCalDescripcion.TextChanged, txtCalHubicacion.TextChanged
            Dim Filtro As DataView
            If TablaMailBackupCAL.DataSource.GetType = GetType(DataTable) Then
                Filtro = New DataView(TablaMailBackupCAL.DataSource)
                TablaMailBackupCAL.DataSource = Filtro
            Else
                Filtro = TablaMailBackupCAL.DataSource
            End If
            Filtro.RowFilter = $"Descripcion LIKE '%{txtCalDescripcion.Text}%' 
                                AND Hubicacion LIKE '%{txtCalHubicacion.Text}%'"
            lblMailBackupSeleccionados.Text = $"{CType(TablaMailBackupCAL.DataSource, DataView).Count} Indexados."
        End Sub
        Private Sub BuscarTarea(sender As Object, e As EventArgs) Handles txtTskAsunto.TextChanged, txtTskNotas.TextChanged
            Dim Filtro As DataView
            If TablaMailBackupTSK.DataSource.GetType = GetType(DataTable) Then
                Filtro = New DataView(TablaMailBackupTSK.DataSource)
                TablaMailBackupTSK.DataSource = Filtro
            Else
                Filtro = TablaMailBackupTSK.DataSource
            End If
            Filtro.RowFilter = $"Asunto LIKE '%{txtTskAsunto.Text}%' 
                                AND Notas LIKE '%{txtTskNotas.Text}%'"
            lblMailBackupSeleccionados.Text = $"{CType(TablaMailBackupTSK.DataSource, DataView).Count} Indexados."
        End Sub

        Private Sub BuscarContacto(sender As Object, e As EventArgs) Handles txtVcfNombre.TextChanged, txtVcfCompleto.TextChanged, txtVcfPersonal.TextChanged, txtVcfTrabajo.TextChanged, txtVcfNick.TextChanged, txtVcfEmail.TextChanged
            Dim Filtro As DataView
            If TablaMailBackupVCF.DataSource.GetType = GetType(DataTable) Then
                Filtro = New DataView(TablaMailBackupVCF.DataSource)
                TablaMailBackupVCF.DataSource = Filtro
            Else
                Filtro = TablaMailBackupVCF.DataSource
            End If
            Filtro.RowFilter = $"Nombre LIKE '%{txtVcfNombre.Text}%' 
                                AND NombreCompleto LIKE '%{txtVcfCompleto.Text}%'
                                AND Email LIKE '%{txtVcfEmail.Text}%'
                                AND EmailPersonal LIKE '%{txtVcfPersonal.Text}%'
                                AND EmailTrabajo LIKE '%{txtVcfTrabajo.Text}%'
                                AND Nick LIKE '%{txtVcfNick.Text}%'"
            lblMailBackupSeleccionados.Text = $"{CType(TablaMailBackupVCF.DataSource, DataView).Count} Indexados."
        End Sub
        Private Sub BtnLimpiarMai_Click(sender As Object, e As EventArgs) Handles BtnLimpiarMai.Click
            Dim Controles() As TextBox = {txtMaiAsunto, txtMaiDestinatarios, txtMaiRemitente}
            For Each txt In Controles
                txt.Text = String.Empty
            Next
        End Sub
        Private Sub BtnLimpiarCal_Click(sender As Object, e As EventArgs) Handles BtnLimpiarCal.Click
            Dim Controles() As TextBox = {txtCalDescripcion, txtCalHubicacion}
            For Each txt In Controles
                txt.Text = String.Empty
            Next
        End Sub
        Private Sub BtnLimpiarTSK_Click(sender As Object, e As EventArgs) Handles BtnLimpiarTSK.Click
            Dim Controles() As TextBox = {txtTskAsunto, txtTskNotas}
            For Each txt In Controles
                txt.Text = String.Empty
            Next
        End Sub
        Private Sub BtnLimpiarVCF_Click(sender As Object, e As EventArgs) Handles BtnLimpiarVCF.Click
            Dim Controles() As TextBox = {txtVcfCompleto, txtVcfEmail, txtVcfNick, txtVcfNombre, txtVcfPersonal, txtVcfTrabajo}
            For Each txt In Controles
                txt.Text = String.Empty
            Next
        End Sub

        Private Sub TablaMailBackupMAI_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles TablaMailBackupMAI.CellContentClick

        End Sub
        Private Sub ReindexarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReindexarEmail.Click
            If TablaMailBackupMAI.SelectedRows.Count > 0 Then
                Dim mC As New List(Of Control) From {TablaMailBackupMAI, TreePostOffices}
                mC.ForEach(Sub(c) c.Enabled = False)
                Dim Total As Integer = TablaMailBackupMAI.SelectedRows.Count
                lblMensajesBackup.Text = $"Restantes: {Total}"
                Me.Refresh()
                For Each Fila In TablaMailBackupMAI.SelectedRows
                    If IO.File.Exists(Fila.Cells(1).Value) Then
                        Dim Analizar As New Backup.Email(Fila.Cells(1).Value)
                        Dim IdMail = Backup.MAI.GetItemIndex("Archivo", Fila.Cells(1).Value)
                        If Not IsNothing(IdMail) Then
                            Backup.MAI.Update(IdMail, Backup.MAI.GetColString(BDD.MailBackup_MAI.Columnas.Remitente), If(String.IsNullOrEmpty(Analizar.Remitente), "", Analizar.Remitente))
                            Backup.MAI.Update(IdMail, Backup.MAI.GetColString(BDD.MailBackup_MAI.Columnas.Asunto), If(String.IsNullOrEmpty(Analizar.Asunto), "", Analizar.Asunto))
                            Backup.MAI.Update(IdMail, Backup.MAI.GetColString(BDD.MailBackup_MAI.Columnas.Destinatarios), If(IsNothing(Analizar.Destinatarios), "", String.Join(";", Analizar.Destinatarios)))
                            Backup.MAI.Update(IdMail, Backup.MAI.GetColString(BDD.MailBackup_MAI.Columnas.ConCopia), If(IsNothing(Analizar.ConCopia), "", String.Join(";", Analizar.ConCopia)))
                            Backup.MAI.Update(IdMail, Backup.MAI.GetColString(BDD.MailBackup_MAI.Columnas.Fecha), Analizar.Fecha)
                            Fila.Cells(2).Value = Analizar.Remitente
                            Fila.Cells(3).Value = Analizar.Destinatarios
                            Fila.Cells(4).Value = Analizar.ConCopia
                            Fila.Cells(5).Value = Analizar.Asunto
                            Fila.Cells(6).Value = Analizar.Fecha
                            Total -= 1
                            lblMensajesBackup.Text = $"Restantes: {Total}"
                            Me.Refresh()
                        Else
                            Task.Run(Sub()
                                         Me.Invoke(Sub() lblMensajesBackup.Text = "No se pudo indexar el mensaje, inténtelo más tarde.")
                                         Thread.Sleep(3000)
                                         Me.Invoke(Sub() lblMensajesBackup.Text = "")
                                     End Sub)
                        End If
                    End If
                Next
                Backup.MAI.Guardar(Backup.BddMAIFullPath)
                mC.ForEach(Sub(c) c.Enabled = True)
            End If
        End Sub
        Private Sub VisualizarEnNotepadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarEnNotepadToolStripMenuItem.Click
            If TablaMailBackupMAI.SelectedRows.Count > 0 Then
                If IO.File.Exists(TablaMailBackupMAI.SelectedRows(0).Cells(1).Value) Then
                    Process.Start("C:\Program Files\Notepad++\notepad++.exe", $"""{TablaMailBackupMAI.SelectedRows(0).Cells(1).Value}""")
                Else
                    MsgBox("No se encuentra el Archivo", MsgBoxStyle.Information, "Error")
                End If
            End If
        End Sub
        Private Sub VisualizarEnOutlookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarEnOutlookToolStripMenuItem.Click
            If TablaMailBackupMAI.SelectedRows.Count > 0 Then
                If IO.File.Exists(TablaMailBackupMAI.SelectedRows(0).Cells(1).Value) Then
                    Process.Start("C:\Program Files (x86)\Microsoft Office\Office14\OUTLOOK.EXE", $"/eml ""{TablaMailBackupMAI.SelectedRows(0).Cells(1).Value}""")
                Else
                    MsgBox("No se encuentra el Archivo", MsgBoxStyle.Information, "Error")
                End If
            End If
        End Sub

        Private Sub Restaurar(sender As Object, e As EventArgs) Handles RestaurarEmail.Click, RestaurarContacto.Click, RestaurarCalendario.Click, RestaurarTarea.Click
            Select Case (CType(sender, ToolStripMenuItem).Name)
                Case RestaurarEmail.Name
                    RestaurarArchivos(TablaMailBackupMAI)
                Case RestaurarTarea.Name
                    RestaurarArchivos(TablaMailBackupTSK)
                Case RestaurarCalendario.Name
                    RestaurarArchivos(TablaMailBackupCAL)
                Case RestaurarContacto.Name
                    RestaurarArchivos(TablaMailBackupVCF)
            End Select
        End Sub
        Private Sub RestaurarArchivos(Tabla As DataGridView)
            'Deshabilitar Tabs
            For Each iTAB In Relation.Values
                iTAB.Key.Enabled = False
            Next

            'Restaurar Archivos
            For Each Fila As DataGridViewRow In Tabla.SelectedRows
                Try
                    'Restaurar el Archivo
                    If Backup.Restaurar(Fila.Cells(1).Value) Then
                        'Limpiar Tabla
                        Select Case Tabla.Name
                            Case TablaMailBackupMAI.Name
                                Dim mRow As DataRow = Backup.MAI.GetRow("Archivo", Fila.Cells(1).Value)
                                Backup.MAI.Tabla.Rows.Remove(mRow)
                            Case TablaMailBackupCAL.Name
                                Dim mRow As DataRow = Backup.CAL.GetRow("Archivo", Fila.Cells(1).Value)
                                Backup.CAL.Tabla.Rows.Remove(mRow)
                            Case TablaMailBackupTSK.Name
                                Dim mRow As DataRow = Backup.TSK.GetRow("Archivo", Fila.Cells(1).Value)
                                Backup.TSK.Tabla.Rows.Remove(mRow)
                            Case TablaMailBackupVCF.Name
                                Dim mRow As DataRow = Backup.VCF.GetRow("Archivo", Fila.Cells(1).Value)
                                Backup.VCF.Tabla.Rows.Remove(mRow)
                        End Select

                        'Limpiar del Control
                        Tabla.Rows.Remove(Fila)
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next

            'Guardar la Tabla
            Select Case Tabla.Name
                Case TablaMailBackupMAI.Name
                    Backup.MAI.Guardar(Backup.BddMAIFullPath)
                Case TablaMailBackupCAL.Name
                    Backup.CAL.Guardar(Backup.BddCALFullPath)
                Case TablaMailBackupTSK.Name
                    Backup.TSK.Guardar(Backup.BddTSKFullPath)
                Case TablaMailBackupVCF.Name
                    Backup.VCF.Guardar(Backup.BddVCFFullPath)
            End Select

            'Habilitar Tabs
            For Each iTAB In Relation.Values
                iTAB.Key.Enabled = True
            Next
        End Sub
        Private Sub ReindexarTodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReindexarTodoToolStripMenuItem.Click
            If MsgBox("Esto eliminará la Indexación Actual." & vbNewLine & vbNewLine & "Desea continuar?", MsgBoxStyle.YesNo, "Reindexar TODO") = MsgBoxResult.Yes Then
                Backup.MAI.Tabla.Clear()
                IO.File.Delete(Backup.BddMAIFullPath)
                TablaMailBackupMAI.Refresh()
                TablaMailBackupMAI.Enabled = False
                lblMensajesBackup.Text = "Indexando..."
                Backup.BuscadorCarpetas.Buscar(Configuracion.CARPETA_BACKUP)
                'Dim Accion As Action = Async Sub() Await Backup.Indexar()
                'Dim Lanzar As Task = Task.Run(Accion)
            End If
        End Sub
        Private Sub IndexarNuevosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndexarNuevosToolStripMenuItem.Click
            Backup.MAI.Tabla.Clear()
            TablaMailBackupMAI.Enabled = False
            lblMensajesBackup.Text = "Indexando..."
            Backup.BuscadorCarpetas.Buscar(Configuracion.CARPETA_BACKUP)
            'Dim Accion As Action = Async Sub() Await Backup.Indexar()
            'Dim Lanzar As Task = Task.Run(Accion)
        End Sub

        Private Sub MenuTablaBackup_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuTablaBackup.Opening
            RestaurarEmail.Visible = False
            RestaurarCalendario.Visible = False
            RestaurarContacto.Visible = False
            RestaurarTarea.Visible = False
            ReindexarEmail.Visible = False
            VisualizarEnNotepadToolStripMenuItem.Enabled = False
            VisualizarEnOutlookToolStripMenuItem.Enabled = False


            Select Case TabBackup.SelectedTab.Name
                Case TabPCAL.Name
                    RestaurarCalendario.Visible = True

                Case TabPMAI.Name
                    RestaurarEmail.Visible = True
                    ReindexarEmail.Visible = True

                Case TabPTSK.Name
                    RestaurarTarea.Visible = True

                Case TabPVCF.Name
                    RestaurarContacto.Visible = True

            End Select

            If Not IsNothing(TreePostOffices.SelectedNode) Then
                ReindexarCarpeta.Enabled = True
                ReindexarCarpeta.Text = $"Indexar: {TreePostOffices.SelectedNode.Text}"
            Else
                ReindexarCarpeta.Text = "Indexar Carpeta"
                ReindexarCarpeta.Enabled = False
            End If
            Select Case TabBackup.SelectedTab.Name
                Case TabPMAI.Name
                    If TablaMailBackupMAI.SelectedRows.Count > 0 Then
                        ReindexarEmail.Enabled = True
                        RestaurarEmail.Enabled = True
                        VisualizarEnNotepadToolStripMenuItem.Enabled = True
                        VisualizarEnOutlookToolStripMenuItem.Enabled = True

                        If TablaMailBackupMAI.SelectedRows.Count = 1 Then
                            ReindexarEmail.Text = $"Reindexar: {TablaMailBackupMAI.SelectedRows(0).Cells(5).Value}"
                            RestaurarEmail.Text = $"Restaurar: {TablaMailBackupMAI.SelectedRows(0).Cells(5).Value}"
                        Else
                            ReindexarEmail.Text = $"Reindexar: Emails seleccionados."
                            RestaurarEmail.Text = $"Restaurar: Emails seleccionados."
                        End If

                    Else
                        RestaurarEmail.Enabled = False
                        RestaurarEmail.Text = "Restaurar Email"
                        ReindexarEmail.Enabled = False
                        ReindexarEmail.Text = "Reindexar Email"
                        VisualizarEnNotepadToolStripMenuItem.Enabled = False
                        VisualizarEnOutlookToolStripMenuItem.Enabled = False
                    End If

                Case TabPCAL.Name
                    If TablaMailBackupCAL.SelectedRows.Count > 0 Then
                        RestaurarCalendario.Enabled = True
                        If TablaMailBackupCAL.SelectedRows.Count = 1 Then
                            RestaurarCalendario.Text = $"Restaurar: {TablaMailBackupCAL.SelectedRows(0).Cells(2).Value}"
                        Else
                            RestaurarCalendario.Text = $"Restaurar: Calendarios seleccionados."
                        End If
                    Else
                        RestaurarCalendario.Enabled = False
                        RestaurarCalendario.Text = "Restaurar Calendario"
                    End If

                Case TabPTSK.Name
                    If TablaMailBackupTSK.SelectedRows.Count > 0 Then
                        RestaurarTarea.Enabled = True
                        If TablaMailBackupTSK.SelectedRows.Count = 1 Then
                            RestaurarTarea.Text = $"Restaurar: {TablaMailBackupTSK.SelectedRows(0).Cells(2).Value}"
                        Else
                            RestaurarTarea.Text = $"Restaurar: Tareas seleccionados."
                        End If
                    Else
                        RestaurarTarea.Enabled = False
                        RestaurarTarea.Text = "Restaurar Tarea"
                    End If

                Case TabPVCF.Name
                    If TablaMailBackupVCF.SelectedRows.Count > 0 Then
                        RestaurarContacto.Enabled = True
                        If TablaMailBackupVCF.SelectedRows.Count = 1 Then
                            RestaurarContacto.Text = $"Restaurar: {TablaMailBackupVCF.SelectedRows(0).Cells(2).Value}"
                        Else
                            RestaurarContacto.Text = $"Restaurar: Contactos seleccionados."
                        End If
                    Else
                        RestaurarContacto.Enabled = False
                        RestaurarContacto.Text = "Restaurar Contacto"
                    End If
            End Select

        End Sub

        Private Sub ReindexarCarpeta_Click(sender As Object, e As EventArgs) Handles ReindexarCarpeta.Click
            If Not IsNothing(TreePostOffices.SelectedNode) Then
                TablaMailBackupMAI.Enabled = False
                Dim Ruta As String = TreePostOffices.SelectedNode.FullPath
                Backup.BuscadorCarpetas.Buscar(Ruta)
                'Dim Accion As Action = Async Sub() Await Backup.Indexar(Ruta)
                'Dim Lanzar As Task = Task.Run(Accion)
            End If
        End Sub
#End Region 'Tablas MailBackup






        Private Sub BtnRecargarTreeNodePostOffices_Click(sender As Object, e As EventArgs) Handles BtnRecargarTreeNodePostOffices.Click
            Dim Desechar As Task = Task.Run(Sub() LoadFolders(Configuracion.CARPETA_BACKUP, TreePostOffices))
        End Sub

        ' Dim Test1 As Integer = 0
        Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click
            'Test1 += 1
            'MiBucle.Intervalo = 1
            'MiBucle.Iniciar()
        End Sub

        Private Sub SalidaConsola_TextChanged(sender As Object, e As EventArgs) Handles SalidaConsola.TextChanged
            'If SalidaConsola.Lines.Count > 500 Then SalidaConsola.ResetText()
            SalidaConsola.SelectionStart = SalidaConsola.Text.Length
            SalidaConsola.ScrollToCaret()
            lblGeneralLog.Text = $"General ({LOG.Logs(LOG.MemoryLOG.EnumLogs.General).Lineas.Count}) Left"
            lblLineasGeneral.Text = $"Lineas: ({SalidaConsola.Lines.Count})"
        End Sub

        Private Sub SalidaCrossDomain_TextChanged(sender As Object, e As EventArgs) Handles SalidaCrossDomain.TextChanged
            'If SalidaCrossDomain.Lines.Count > 500 Then SalidaCrossDomain.ResetText()
            SalidaCrossDomain.SelectionStart = SalidaCrossDomain.Text.Length
            SalidaCrossDomain.ScrollToCaret()
            lblCrossDomainLog.Text = $"CrossDomain ({LOG.Logs(LOG.MemoryLOG.EnumLogs.CrossDomain).Lineas.Count}) Left"
            lblLineasCrossDomain.Text = $"Lineas: ({SalidaCrossDomain.Lines.Count})"
        End Sub

        Private Sub TabApp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabApp.SelectedIndexChanged
            If TabApp.SelectedTab.Name = TabMigraciones.Name Then
                Migracion.LabelService = lblEstadoServicioMigracion
                Migracion.BtnService = BtnServicioMigracion
                Migracion.lstDominiosConfigurados = lstDominiosMigracion
                Migracion.lstCuentasEnMigracion = lstMailBoxMigracion
                Migracion.lstListaDeEspera = lstListaDeEsperaMigracion
                Migracion.lstErroneos = lstErroneosMigracion
                Migracion.CargarMigraciones()
            End If

            If TabApp.SelectedTab.Name = TabAutoResponder.Name Then
                For Each Email In AutoResponder.Modificados
                    If Not lstEmailsReparadosAutoResponder.Items.Contains(Email) Then
                        lstEmailsReparadosAutoResponder.Items.Add(Email)
                    End If
                Next
            End If
        End Sub

        Private Sub lstDominiosMigracion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDominiosMigracion.SelectedIndexChanged
            Dim Ctrl As New List(Of ToolStripButton) From {BtnActivarMigracionDominio, BtnDesactivarMigracionDominio, BtnEliminarDominioMigracion}
            If lstDominiosMigracion.SelectedItems.Count > 0 Then
                If CBool(lstDominiosMigracion.SelectedItems.Item(0).SubItems(1).Text) Then
                    Ctrl.Item(0).Enabled = False
                    Ctrl.Item(1).Enabled = True
                Else
                    Ctrl.Item(0).Enabled = True
                    Ctrl.Item(1).Enabled = False
                End If
                Ctrl.Item(2).Enabled = True
            Else
                Ctrl.Item(0).Enabled = False
                Ctrl.Item(1).Enabled = False
                Ctrl.Item(2).Enabled = False
                'Ctrl.ForEach(Function(C) C.Enabled = False)
            End If
        End Sub

        Private Sub BtnMigrarCuenta_Click(sender As Object, e As EventArgs) Handles BtnMigrarCuenta.Click
            Migracion.MigrarCuenta()
        End Sub

        Private Sub BtnLimpiarMigracionesCompletadas_Click(sender As Object, e As EventArgs) Handles BtnLimpiarMigracionesCompletadas.Click
            If IsNothing(Migracion.CarpetaCompletados) Then Exit Sub
            Try
                For Each Cuenta In Migracion.MailBoxes
                    If Cuenta.Value.Progress = 1 Then
                        If IO.File.Exists(Migracion.CarpetaCompletados.FullName & $"\{Cuenta.Key}.xml") Then
                            IO.File.Delete(Migracion.CarpetaCompletados.FullName & $"\{Cuenta.Key}.xml")
                            lstMailBoxMigracion.Items.Find(Cuenta.Key, False).First.Remove()
                            Migracion.MailBoxes.TryRemove(Cuenta.Key, Cuenta.Value)
                        End If
                    End If
                Next
            Catch ex As Exception
                Stop
            End Try
        End Sub

        Private Sub BtnLimpiarErroneosMigracion_Click(sender As Object, e As EventArgs) Handles BtnLimpiarErroneosMigracion.Click
            Migracion.LimpiarErroneos()
        End Sub

        Private Sub BtnActivarMigracionDominio_Click_1(sender As Object, e As EventArgs) Handles BtnActivarMigracionDominio.Click
            BtnActivarMigracionDominio.Enabled = False
            Migracion.HabilitarDominio(lstDominiosMigracion.SelectedItems(0).Text)
            BtnDesactivarMigracionDominio.Enabled = True
        End Sub

        Private Sub BtnDesactivarMigracionDominio_Click_1(sender As Object, e As EventArgs) Handles BtnDesactivarMigracionDominio.Click
            If lstDominiosMigracion.SelectedItems.Count > 0 Then
                BtnDesactivarMigracionDominio.Enabled = False
                Migracion.DesHabilitarDominio(lstDominiosMigracion.SelectedItems(0).Text)
                BtnActivarMigracionDominio.Enabled = True
            End If
        End Sub

        Private Sub BtnCrearDominioMigracion_Click_1(sender As Object, e As EventArgs) Handles BtnCrearDominioMigracion.Click
            Migracion.CrearDominio()
        End Sub

        Private Sub BtnEliminarDominioMigracion_Click(sender As Object, e As EventArgs) Handles BtnEliminarDominioMigracion.Click
            BtnEliminarDominioMigracion.Enabled = False
            If lstDominiosMigracion.SelectedItems.Count > 0 Then
                Migracion.EliminarDominio(lstDominiosMigracion.SelectedItems(0).Text)
            End If
        End Sub

        Private Sub BtnCopiarErroneos_Click(sender As Object, e As EventArgs) Handles BtnCopiarErroneos.Click
            Dim toClipBoard As String = String.Empty
            For Each Item As ListViewItem In lstErroneosMigracion.Items
                toClipBoard &= $"{Item.Text}, {Item.SubItems(1).Text}{vbNewLine}"
            Next
            toClipBoard = toClipBoard.Substring(0, toClipBoard.Length - 2)
            Clipboard.SetText(toClipBoard)
        End Sub

        Private Sub BuclesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuclesToolStripMenuItem.Click
            TDC.MailEnable.Core.Bucle.Mod_GlobalDoBucle.View()
        End Sub

        Private Sub lstEmailsReparadosAutoResponder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEmailsReparadosAutoResponder.SelectedIndexChanged
            If lstEmailsReparadosAutoResponder.SelectedItems.Count > 0 Then
                RichAutoResponderMail.Text = AutoResponder.Mensajes(lstEmailsReparadosAutoResponder.SelectedItems.Item(0))
                RichAutoResponderStatus.Text = AutoResponder.Estados(lstEmailsReparadosAutoResponder.SelectedItems.Item(0))
                RichAutoResponderRespuesta.Text = AutoResponder.Respuestas(lstEmailsReparadosAutoResponder.SelectedItems.Item(0))
            Else
                RichAutoResponderMail.Text = String.Empty
                RichAutoResponderStatus.Text = String.Empty
                RichAutoResponderRespuesta.Text = String.Empty
            End If
        End Sub

        Private Sub RichAutoResponderRespuesta_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichAutoResponderRespuesta.LinkClicked
            Try
                Process.Start(e.LinkText)
            Catch ex As Exception
                MessageBox.Show("No se pudo abrir el enlace. Error: " & ex.Message)
            End Try
        End Sub
    End Class
End Namespace