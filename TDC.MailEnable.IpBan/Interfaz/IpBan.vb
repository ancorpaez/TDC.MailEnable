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

        'Pruebas
        Private WithEvents MiBucle As New Core.Bucle.DoBucle("MiBucle")

        Private Sub IpBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            '**** TEST****
            'Dim Test As New Core.GeoLocalizacion.MyNsLookUp
            'Dim Tes2 = Test.EsLegitima("104.26.7.164")
            'Dim Tes0 = Test.EsLegitima("185.92.245.33")
            'Dim Tes1 = Test.EsLegitima("129.126.197.254")
            MiBucle.Intervalo = 1
            'MiBucle.Iniciar()
            '*************

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

            'POP(W3C)
            Registro_POPW3C.Filtro.Add(New Cls_Filtro With {
                                       .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo, .Repeteciones = 5, .VerificarMailBox = False, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                       New Cls_Coincidencia With {.Filtro = "-ERR+Unable+to+log+on", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})
            Trabajador_POPW3C.Intervalo = 100
            Trabajador_POPW3C.Iniciar()

            'SMTP(W3C)
            Registro_SMTPW3C.Filtro.Add(New Cls_Filtro With {
                                        .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo, .Repeteciones = 3, .VerificarMailBox = True, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                        New Cls_Coincidencia With {.Filtro = "Invalid+Username+or+Password", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                        New Cls_Coincidencia With {.Filtro = "@", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})
            Registro_SMTPW3C.Filtro.Add(New Cls_Filtro With {
                                        .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo, .Repeteciones = 0, .VerificarMailBox = False, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                        New Cls_Coincidencia With {.Filtro = "Invalid+Username+or+Password", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                        New Cls_Coincidencia With {.Filtro = "@", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene}}})
            Registro_SMTPW3C.Filtro.Add(New Cls_Filtro With {
                                        .TrueSi = Cls_Filtro.EnumTipoComparacion.Cualquiera, .Repeteciones = 0, .VerificarMailBox = False, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                        New Cls_Coincidencia With {.Filtro = "This+mail+server+requires+authentication+before+sending+mail", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})
            Trabajador_SMTPW3C.Intervalo = 100
            Trabajador_SMTPW3C.Iniciar()



            'IMAP (W3C)
            Registro_IMAPW3C.Filtro.Add(New Cls_Filtro With {
                                        .TrueSi = Cls_Filtro.EnumTipoComparacion.Cualquiera, .Repeteciones = 3, .VerificarMailBox = False, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                        New Cls_Coincidencia With {.Filtro = "Invalid+username+or+password", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})
            Trabajador_IMAPW3C.Intervalo = 100
            Trabajador_IMAPW3C.Iniciar()

            'WEB
            Registro_WEB.Filtro.Add(New Cls_Filtro With {
                                    .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo, .Repeteciones = 3, .VerificarMailBox = False, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                    New Cls_Coincidencia With {.Filtro = "POST", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = "Cmd=LOGIN", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})
            Registro_WEB.Filtro.Add(New Cls_Filtro With {
                                    .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo, .Repeteciones = 0, .VerificarMailBox = False, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                    New Cls_Coincidencia With {.Filtro = "GET", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = " 404 ", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = "favicon.ico", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene},
                                    New Cls_Coincidencia With {.Filtro = "robots.txt", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene},
                                    New Cls_Coincidencia With {.Filtro = "sitemap.xml", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene},
                                    New Cls_Coincidencia With {.Filtro = "BingSiteAuth.xml", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene},
                                    New Cls_Coincidencia With {.Filtro = "google-site-verification", .Condicion = Cls_Coincidencia.EnumCondicion.NoContiene}}})
            Registro_WEB.Filtro.Add(New Cls_Filtro With {
                                    .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo, .Repeteciones = 0, .VerificarMailBox = False, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                    New Cls_Coincidencia With {.Filtro = "POST", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = " 404 ", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = "POST", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = "/Mobile/Login.aspx", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})
            Registro_WEB.Filtro.Add(New Cls_Filtro With {
                                    .TrueSi = Cls_Filtro.EnumTipoComparacion.Todo, .Repeteciones = 0, .VerificarMailBox = False, .Coincidencias = New List(Of Cls_Coincidencia) From {
                                    New Cls_Coincidencia With {.Filtro = "HEAD", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene},
                                    New Cls_Coincidencia With {.Filtro = " 404 ", .Condicion = Cls_Coincidencia.EnumCondicion.Contiene}}})
            Trabajador_WEB.Intervalo = 100
            Trabajador_WEB.Iniciar()

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

            'Indexar los Emails del Backup
            Dim Accion As Action = Async Sub() Await Backup.Indexar()
            Dim Lanzar As Task = Task.Run(Accion)


            'Comprobar si las Rutas de Backup son Accesibles
            If IO.Directory.Exists(Configuracion.CARPETA_BACKUP) Then
                'Cargar PostOffices del Backup
                Dim Desechar As Task = Task.Run(Sub() LoadFolders(Configuracion.CARPETA_BACKUP, TreePostOffices))
            End If
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
                If Not {"indexroot", "pubroot", "fileroot", "calendar", "contacts", "notes", "tasks"}.Any(Function(Carpeta) subFolder.ToLower.Contains(Carpeta)) Then
                    Try
                        Dim subFolderNode As TreeNode
                        If Not parentNode.Nodes.ContainsKey(subFolder) Then
                            subFolderNode = New TreeNode(IO.Path.GetFileName(subFolder)) With {.Name = subFolder}
                            Me.Invoke(Sub() parentNode.Nodes.Add(subFolderNode))
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
            Me.Invoke(Sub() UcCarpeta.ProgresoCarpeta.Maximum = Ordenados.Count)

            'Analizar cada archvivo
            For Each Archivo In Ordenados

                If Not ControlCarpeta.Contains(Archivo.Name) AndAlso esLegible(Archivo.FullName) Then
                    'Establecer una Memoria de Archivo
                    If Not FileMemory.ContainsKey(Archivo.FullName) Then FileMemory.TryAdd(Archivo.FullName, New Cls_FileMemory)
                    'Analizar Archivo
                    Dim EscanearArchivo As New LecturaDeArchivo(Archivo.FullName) With {.ObtenerIp = DelimitadorIp, .Filtros = ControlCarpeta.Filtro, .Index = FileMemory(Archivo.FullName).Line}

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
                        If FileMemory.ContainsKey(Archivo.FullName) Then FileMemory.TryRemove(Archivo.FullName, Nothing)

                        'Eliminamos el Bucle del archivo
                        Core.Bucle.Remove(Archivo.FullName)
                    End If

                End If
            Next

            'Relajamos en bucle de Busqueda de Archivos
            Trabajador.Intervalo = Configuracion.LECTURA_REPOSO

            'Propagamos la configuracion de Bloqueo de IP
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


        'Private Sub Trabajador_POP_Background(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_POP.Background
        '    'Trabajo en BackGround
        '    EscanearCarpeta(UcPOPAct, Function(Linea) RecuperarIpTab(Linea, 3), Trabajador_POP, Mod_Core.Configuracion.POP, Registro_POP, "POP-Activity*.log")
        'End Sub

        Private Sub Trabajador_POPW3C_Background(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_POPW3C.Background
            'Trabajo en BackGround
            EscanearCarpeta(UcPOPEx, Function(Linea) RecuperarIpSplit(Linea, 2), Trabajador_POPW3C, Mod_Core.Configuracion.POP, Registro_POPW3C, "ex*.log")
        End Sub

        'Private Sub Trabajador_SMTP_Background(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_SMTP.Background
        '    'Trabajo en BackGround
        '    EscanearCarpeta(UcSMTPAct, Function(linea) RecuperarIpTab(linea, 4), Trabajador_SMTP, Mod_Core.Configuracion.SMTP, Registro_SMTP, "SMTP-Activity*.log")
        'End Sub
        Private Sub Trabajador_SMTPW3C_Background(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_SMTPW3C.Background
            'Trabajo en BackGround
            'EscanearCarpeta(UcSMTPEx, Function(Linea) Linea.Split(" ")(2), Trabajador_SMTPW3C, Mod_Core.Configuracion.SMTP, Registro_SMTPW3C, "ex*.log")
            EscanearCarpeta(UcSMTPEx, Function(Linea) RecuperarIpSplit(Linea, 2), Trabajador_SMTPW3C, Mod_Core.Configuracion.SMTP, Registro_SMTPW3C, "ex*.log")
        End Sub
        'Private Sub Trabajador_IMAP_Background(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_IMAP.Background
        '    'Trabajo en BackGround
        '    EscanearCarpeta(UcIMAPAct, Function(Linea) RecuperarIpTab(Linea, 4), Trabajador_IMAP, Mod_Core.Configuracion.IMAP, Registro_IMAP, "IMAP-Activity*.log")
        'End Sub
        Private Sub Trabajador_IMAPW3C_Background(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_IMAPW3C.Background
            'Trabajo en BackGround
            EscanearCarpeta(UcIMAPEx, Function(Linea) RecuperarIpSplit(Linea, 2), Trabajador_IMAPW3C, Mod_Core.Configuracion.IMAP, Registro_IMAPW3C, "ex*.log")
        End Sub

        Private Sub Trabajador_WEB_Background(Sender As Object, ByRef Detener As Boolean) Handles Trabajador_WEB.Background
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
                If Monitor.TryEnter(SyncLockPublicador) Then

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

        Private Sub TreePostOffices_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreePostOffices.AfterSelect
            txtFAsunto.Text = String.Empty
            txtFRemitente.Text = String.Empty
            txtFDestinatarios.Text = String.Empty

            Try
                TreePostOffices.Enabled = False

                Dim Filtro() As DataRow = Backup.Indexacion.Tabla.Select("Archivo LIKE '%" & e.Node.FullPath & "%'")
                Dim Datos As DataTable = Backup.Indexacion.Tabla.Clone
                For Each Linea In Filtro
                    Datos.ImportRow(Linea)
                Next
                TablaMailBackup.DataSource = Datos
                TreePostOffices.Enabled = True
                LabelErroresDataTable.Text = ""
            Catch ex As Exception
                LabelErroresDataTable.Text = ex.Message
                TreePostOffices.Enabled = True
            End Try

        End Sub

        Private Sub TablaMailBackup_DataSourceChanged(sender As Object, e As EventArgs) Handles TablaMailBackup.DataSourceChanged
            Try
                If TablaMailBackup.DataSource.GetType = GetType(DataTable) Then
                    LabelCorreosEliminados.Text = $"{CType(TablaMailBackup.DataSource, DataTable).Rows.Count} Correos eliminados."
                Else
                    LabelCorreosEliminados.Text = $"{CType(TablaMailBackup.DataSource, DataView).Count} Encontrados."
                End If
                TablaMailBackup.Columns("ID").Visible = False
                TablaMailBackup.Columns("Archivo").Visible = False
                'TablaMailBackup.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill)
            Catch ex As Exception

            End Try
        End Sub

        Private Sub txtFAsunto_TextChanged(sender As Object, e As EventArgs) Handles txtFAsunto.TextChanged, txtFRemitente.TextChanged, txtFDestinatarios.TextChanged
            Dim Filtro As DataView
            If TablaMailBackup.DataSource.GetType = GetType(DataTable) Then
                Filtro = New DataView(TablaMailBackup.DataSource)
                TablaMailBackup.DataSource = Filtro
            Else
                Filtro = TablaMailBackup.DataSource
            End If
            Filtro.RowFilter = $"Asunto LIKE '%{txtFAsunto.Text}%' 
                                AND Remitente LIKE '%{txtFRemitente.Text}%'
                                AND Destinatarios LIKE '%{txtFDestinatarios.Text}%'"
            LabelCorreosEliminados.Text = $"{CType(TablaMailBackup.DataSource, DataView).Count} Encontrados."
        End Sub

        Private Sub TablaMailBackup_Resize(sender As Object, e As EventArgs) Handles TablaMailBackup.Resize
            If Not IsNothing(TablaMailBackup.Columns) AndAlso TablaMailBackup.Columns.Contains("Asunto") Then TablaMailBackup.Columns("Asunto").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Sub

        Private Sub BtnLimpiarFiltro_Click(sender As Object, e As EventArgs) Handles BtnLimpiarFiltro.Click
            Dim Controles() As TextBox = {txtFAsunto, txtFDestinatarios, txtFRemitente}
            For Each txt In Controles
                txt.Text = String.Empty
            Next
        End Sub

        Private Sub ReindexarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReindexarEmail.Click
            If TablaMailBackup.SelectedRows.Count > 0 Then
                'MsgBox(TablaMailBackup.SelectedRows(0).Cells(1).Value)
                For Each Fila In TablaMailBackup.SelectedRows
                    Dim Analizar As New Backup.Email(Fila.Cells(1).Value)
                    Dim IdMail = Backup.Indexacion.GetItemIndex("Archivo", Fila.Cells(1).Value)
                    If Not IsNothing(IdMail) Then
                        TablaMailBackup.Enabled = False
                        Backup.Indexacion.Update(IdMail, Backup.Indexacion.GetColString(BDD.MailBackupIndex.Columnas.Remitente), If(String.IsNullOrEmpty(Analizar.Remitente), "", Analizar.Remitente))
                        Backup.Indexacion.Update(IdMail, Backup.Indexacion.GetColString(BDD.MailBackupIndex.Columnas.Asunto), If(String.IsNullOrEmpty(Analizar.Remitente), "", Analizar.Asunto))
                        Backup.Indexacion.Update(IdMail, Backup.Indexacion.GetColString(BDD.MailBackupIndex.Columnas.Destinatarios), If(IsNothing(Analizar.Destinatarios), "", String.Join(";", Analizar.Destinatarios)))
                        Backup.Indexacion.Update(IdMail, Backup.Indexacion.GetColString(BDD.MailBackupIndex.Columnas.ConCopia), If(IsNothing(Analizar.ConCopia), "", String.Join(";", Analizar.ConCopia)))
                        Backup.Indexacion.Update(IdMail, Backup.Indexacion.GetColString(BDD.MailBackupIndex.Columnas.Fecha), Analizar.Fecha)
                        Backup.Indexacion.Tabla.WriteXml("Indexacion.xml")
                    Else
                        Task.Run(Sub()
                                     Me.Invoke(Sub() LabelErroresDataTable.Text = "No se pudo indexar el mensaje, inténtelo más tarde.")
                                     Thread.Sleep(3000)
                                     Me.Invoke(Sub() LabelErroresDataTable.Text = "")
                                 End Sub)
                    End If
                Next
                TablaMailBackup.Enabled = True
            End If
        End Sub

        Private Sub VisualizarEnNotepadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizarEnNotepadToolStripMenuItem.Click
            If TablaMailBackup.SelectedRows.Count > 0 Then
                Process.Start("C:\Program Files\Notepad++\notepad++.exe", TablaMailBackup.SelectedRows(0).Cells(1).Value)
            End If
        End Sub
        Private Sub RestaurarEmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestaurarEmail.Click
            For Each Fila As DataGridViewRow In TablaMailBackup.SelectedRows
                Backup.Restaurar(Fila.Cells(1).Value)
            Next
        End Sub
        Private Sub ReindexarTodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReindexarTodoToolStripMenuItem.Click
            Backup.Indexacion.Tabla.Clear()
            IO.File.Delete("Indexacion.xml")
            TablaMailBackup.Refresh()
            TablaMailBackup.Enabled = False
            LabelErroresDataTable.Text = "Indexando..."
            Dim Accion As Action = Async Sub() Await Backup.Indexar()
            Dim Lanzar As Task = Task.Run(Accion)
        End Sub
        Private Sub IndexarNuevosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndexarNuevosToolStripMenuItem.Click
            Backup.Indexacion.Tabla.Clear()
            TablaMailBackup.Enabled = False
            LabelErroresDataTable.Text = "Indexando..."
            Dim Accion As Action = Async Sub() Await Backup.Indexar()
            Dim Lanzar As Task = Task.Run(Accion)
        End Sub
        Private Sub TablaMailBackup_EnabledChanged(sender As Object, e As EventArgs) Handles TablaMailBackup.EnabledChanged
            TablaMailBackup.ForeColor = If(TablaMailBackup.Enabled, Color.Black, Color.LightGray)
        End Sub


        Private Sub TablaMailBackup_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles TablaMailBackup.RowEnter
            If TablaMailBackup.SelectedRows.Count > 0 Then
                LabelErroresDataTable.Text = TablaMailBackup.SelectedRows(0).Cells(1).Value
            End If
        End Sub

        Private Sub MenuTablaBackup_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuTablaBackup.Opening

            If Not IsNothing(TreePostOffices.SelectedNode) Then
                ReindexarCarpeta.Enabled = True
                ReindexarCarpeta.Text = $"Indexar: {TreePostOffices.SelectedNode.Text}"
            Else
                ReindexarCarpeta.Text = "Indexar Carpeta"
                ReindexarCarpeta.Enabled = False
            End If

            If TablaMailBackup.SelectedRows.Count > 0 Then
                ReindexarEmail.Enabled = True
                RestaurarEmail.Enabled = True
                VisualizarEnNotepadToolStripMenuItem.Enabled = True

                If TablaMailBackup.SelectedRows.Count = 1 Then
                    ReindexarEmail.Text = $"Reindexar: {TablaMailBackup.SelectedRows(0).Cells(5).Value}"
                    RestaurarEmail.Text = $"Restaurar: {TablaMailBackup.SelectedRows(0).Cells(5).Value}"
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
            End If
        End Sub

        Private Sub ReindexarCarpeta_Click(sender As Object, e As EventArgs) Handles ReindexarCarpeta.Click
            If Not IsNothing(TreePostOffices.SelectedNode) Then
                TablaMailBackup.Enabled = False
                Dim Ruta As String = TreePostOffices.SelectedNode.FullPath
                Dim Accion As Action = Async Sub() Await Backup.Indexar(Ruta)
                Dim Lanzar As Task = Task.Run(Accion)
                'TablaMailBackup.Enabled = True
            End If
        End Sub

        Private Sub TablaMailBackup_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles TablaMailBackup.CellContentClick

        End Sub

        Private Sub TablaMailBackup_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles TablaMailBackup.CellContentDoubleClick
            VisualizarEnNotepadToolStripMenuItem_Click(sender, e)
        End Sub

        Private Sub BtnRecargarTreeNodePostOffices_Click(sender As Object, e As EventArgs) Handles BtnRecargarTreeNodePostOffices.Click
            Dim Desechar As Task = Task.Run(Sub() LoadFolders(Configuracion.CARPETA_BACKUP, TreePostOffices))
        End Sub

        Dim Test1 As Integer = 0
        Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click
            Test1 += 1
            MiBucle.Intervalo = 1
            'MiBucle.Iniciar()
        End Sub

        Private Sub MiBucle_Background(Sender As Object, ByRef Detener As Boolean) Handles MiBucle.Background
            'Thread.Sleep(1000)
            Test1 += 1
            If Test1 = 1000 Then MiBucle.Detener()
        End Sub

        Private Sub MiBucle_Foreground(Sender As Object, ByRef Detener As Boolean) Handles MiBucle.Foreground
            'Thread.Sleep(1000)
            lblPrueba.Text = Test1
            'If Test1 = 1000 Then Detener = True
        End Sub

        Private Sub MiBucle_Endground(Sender As Object, ByRef Detener As Boolean) Handles MiBucle.Endground
            lblPrueba.Text = $"End {Test1}"
            'MiBucle.Matar()
            'MiBucle = Nothing
        End Sub
    End Class
End Namespace