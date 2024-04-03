Imports System.Xml.Serialization
Imports System.ServiceProcess

Namespace Migracion
    Public Module Core
        Private WithEvents Refresh_Migraciones As New TDC.MailEnable.Core.Bucle.DoBucle("Migraciones")
        Private WithEvents Servicio As ServiceController = Nothing
        Public ReadOnly Dominios As New Concurrent.ConcurrentDictionary(Of String, MailboxMigrationStrategy)
        Public MailBoxes As New Concurrent.ConcurrentDictionary(Of String, MailboxMigrationOperation)
        Public Erroneos As New Concurrent.ConcurrentDictionary(Of String, MailboxMigrationOperation)

        'Parte del Interface
        Public LabelService As System.Windows.Forms.Label = Nothing
        Public BtnService As System.Windows.Forms.Button = Nothing
        Public lstDominiosConfigurados As ListView = Nothing
        Public lstCuentasEnMigracion As ListView = Nothing
        Public lstErroneos As ListView = Nothing

        'Cargar Cuentas y Dominios de MailEnable
        Private MailEnableMailBoxFile As String = "\Config\AUTH.TAB"
        Private MailEnableDomains As New Concurrent.ConcurrentBag(Of String)
        Private MailEnableMailBox As New Concurrent.ConcurrentDictionary(Of String, MailEnable.MailEnableMailBox)

        'Parte Local
        Dim CarpetaLocalMigraciones As New IO.DirectoryInfo(Application.StartupPath & "\Migraciones\Espera")
        Dim XmlTemplate_MailboxMigrationOperation As New List(Of String) From {
            "<?xml version=""1.0""?>",
            "<MailboxMigrationStrategy xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">",
            "  <Postoffice>{0}</Postoffice>",
            "  <Mailbox />",
            "  <Enabled>{1}</Enabled>",
            "  <MigrationStrategy xsi:type=""IMAPMigrationStrategy"">",
            "    <RemoteServerAddress>{2}</RemoteServerAddress>",
            "    <Port>{3}</Port>",
            "    <UseSSL>{4}</UseSSL>",
            "  </MigrationStrategy>",
            "  <SourceDescription>Generic Internet Mail Server</SourceDescription>",
            "</MailboxMigrationStrategy>"
        }
        Dim CarpetaLocalErroneos As New IO.DirectoryInfo(Application.StartupPath & "\Migraciones\Erroneos")
        Dim ListaDeEspera As New Concurrent.ConcurrentDictionary(Of String, MailboxMigrationOperation)
        Public lstListaDeEspera As ListView = Nothing
        Public CarpetaCompletados As IO.DirectoryInfo = Nothing
        Private CarpetaQuened As IO.DirectoryInfo = Nothing
        Private CarpetaProgress As IO.DirectoryInfo = Nothing
        Private CarpetaMigracion As IO.DirectoryInfo = Nothing


        Public Sub CargarMigraciones()

            If Not CarpetaLocalMigraciones.Exists Then CarpetaLocalMigraciones.Create()
            If Not CarpetaLocalErroneos.Exists Then CarpetaLocalErroneos.Create()

            'Cargar Archivo de MailEnable
            Using LeerMailEnableMailBox As IO.StreamReader = New IO.StreamReader(IO.File.Open(MailEnableLog.Configuracion.MAIL_APP & MailEnableMailBoxFile, IO.FileMode.Open, IO.FileAccess.Read))
                Dim Linea As String = String.Empty
                Dim Partes() As String = {}
                Do
                    Linea = LeerMailEnableMailBox.ReadLine
                    If Not String.IsNullOrEmpty(Linea) Then
                        Partes = Linea.Split(vbTab)
                        If Not MailEnableDomains.Contains(Partes(3)) Then MailEnableDomains.Add(Partes(3))
                        If Not MailEnableMailBox.ContainsKey(Partes(0)) Then MailEnableMailBox.TryAdd(Partes(0), New MailEnable.MailEnableMailBox With {.Domain = Partes(3), .Pwd = Partes(2)})
                    End If
                Loop While Not String.IsNullOrEmpty(Linea)
            End Using

            'Controlar el Servicio
            If ServiceController.GetServices.Any(Function(s) s.ServiceName = "MEDMS") Then Servicio = New ServiceController("MEDMS")
            If Not IsNothing(BtnService) Then
                AddHandler BtnService.Click, Sub()
                                                 Select Case BtnService.Text
                                                     Case "Iniciar"
                                                         Try
                                                             If Not ActivarServicio() Then
                                                                 MatarServicio()
                                                             End If
                                                             BtnService.Enabled = False
                                                         Catch ex As Exception
                                                             MsgBox(ex.Message)
                                                         End Try
                                                     Case "Detener"
                                                         MatarServicio()
                                                         'Process.Start("TASKKILL", " /F /IM MEDMS.exe").StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                                                         BtnService.Enabled = False
                                                 End Select
                                             End Sub
            End If

            Refresh_Migraciones.Iniciar()
        End Sub
        Private Function ActivarServicio() As Boolean
            Try
                If Servicio.Status = ServiceControllerStatus.Stopped Then Servicio.Start()
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Private Function MatarServicio() As Boolean
            Try
                If Servicio.Status = ServiceControllerStatus.Running Then
                    Dim Lanzar As New Process
                    With Lanzar
                        With .StartInfo
                            .FileName = "TASKKILL"
                            .Arguments = " /F /IM MEDMS.exe"
                            .WindowStyle = ProcessWindowStyle.Hidden
                        End With
                        .Start()
                    End With
                End If
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Private Sub Refresh_Migraciones_Background(Sender As Object, ByRef Detener As Boolean) Handles Refresh_Migraciones.Background
            If String.IsNullOrEmpty(MailEnableLog.Configuracion.MAIL_APP) Then Throw New Exception("No está configurada la carpeta MailEnable App")
            If Not IO.Directory.Exists(MailEnableLog.Configuracion.MAIL_APP) Then Throw New Exception($"La carpeta configuarada {MailEnableLog.Configuracion.MAIL_APP} no existe o no hay acceso.")

            CarpetaMigracion = New IO.DirectoryInfo(MailEnableLog.Configuracion.MAIL_APP & "\Config\Migration")
            For Each DomFile In IO.Directory.GetFiles(CarpetaMigracion.FullName, "*.xml")
                Try
                    Using Leer As New IO.StreamReader(DomFile)
                        Dim CargarXml As New XmlSerializer(GetType(MailboxMigrationStrategy))
                        Dim DomXml As MailboxMigrationStrategy = CType(CargarXml.Deserialize(Leer), MailboxMigrationStrategy)
                        If Not Dominios.ContainsKey(DomXml.Postoffice) Then
                            Dominios.TryAdd(DomXml.Postoffice, DomXml)
                        Else
                            Dominios(DomXml.Postoffice) = DomXml
                        End If
                    End Using
                Catch ex As Exception
                    'Fallo por posible eliminacion de archivo en caliente
                End Try
            Next

            CarpetaQuened = New IO.DirectoryInfo(MailEnableLog.Configuracion.MAIL_APP & "\Config\Migration\Queued")
            For Each MailFile In IO.Directory.GetFiles(CarpetaQuened.FullName, "*.xml")
                Using Leer As New IO.StreamReader(MailFile)
                    Dim CargarXml As New XmlSerializer(GetType(MailboxMigrationOperation))
                    Dim MailXml As MailboxMigrationOperation = CType(CargarXml.Deserialize(Leer), MailboxMigrationOperation)
                    If Not MailBoxes.ContainsKey(MailXml.Username) Then
                        MailBoxes.TryAdd(MailXml.Username, MailXml)
                    Else
                        MailBoxes(MailXml.Username) = MailXml
                    End If
                End Using
            Next

            CarpetaProgress = New IO.DirectoryInfo(MailEnableLog.Configuracion.MAIL_APP & "\Config\Migration\InProgress")
            For Each MailFile In IO.Directory.GetFiles(CarpetaProgress.FullName, "*.xml")
                Using Leer As New IO.StreamReader(MailFile)
                    Dim CargarXml As New XmlSerializer(GetType(MailboxMigrationOperation))
                    Dim MailXml As MailboxMigrationOperation = CType(CargarXml.Deserialize(Leer), MailboxMigrationOperation)
                    If Not MailBoxes.ContainsKey(MailXml.Username) Then
                        MailBoxes.TryAdd(MailXml.Username, MailXml)
                    Else
                        MailBoxes(MailXml.Username) = MailXml
                    End If
                End Using
            Next

            CarpetaCompletados = New IO.DirectoryInfo(MailEnableLog.Configuracion.MAIL_APP & "\Config\Migration\Completed")
            For Each MailFile In IO.Directory.GetFiles(MailEnableLog.Configuracion.MAIL_APP & "\Config\Migration\Completed", "*.xml")
                Using Leer As New IO.StreamReader(MailFile)
                    Dim CargarXml As New XmlSerializer(GetType(MailboxMigrationOperation))
                    Dim MailXml As MailboxMigrationOperation = CType(CargarXml.Deserialize(Leer), MailboxMigrationOperation)
                    If Not MailBoxes.ContainsKey(MailXml.Username) Then
                        MailBoxes.TryAdd(MailXml.Username, MailXml)
                    Else
                        MailBoxes(MailXml.Username) = MailXml
                    End If
                End Using
            Next

            For Each MailFile In IO.Directory.GetFiles(CarpetaLocalMigraciones.FullName, "*.xml")
                Using Leer As New IO.StreamReader(MailFile)
                    Dim CargarXml As New XmlSerializer(GetType(MailboxMigrationOperation))
                    Dim MailXml As MailboxMigrationOperation = CType(CargarXml.Deserialize(Leer), MailboxMigrationOperation)
                    If Not ListaDeEspera.ContainsKey(MailXml.Username) Then
                        ListaDeEspera.TryAdd(MailXml.Username, MailXml)
                    Else
                        ListaDeEspera(MailXml.Username) = MailXml
                    End If
                End Using
            Next

            For Each MailFile In IO.Directory.GetFiles(CarpetaLocalErroneos.FullName, "*.xml")
                Using Leer As New IO.StreamReader(MailFile)
                    Dim CargarXml As New XmlSerializer(GetType(MailboxMigrationOperation))
                    Dim MailXml As MailboxMigrationOperation = CType(CargarXml.Deserialize(Leer), MailboxMigrationOperation)
                    If Not Erroneos.ContainsKey(MailXml.Username) Then
                        Erroneos.TryAdd(MailXml.Username, MailXml)
                    End If
                End Using
            Next

            If Not IsNothing(Servicio) AndAlso Servicio.Status = ServiceControllerStatus.Running Then
                If MailBoxes.Count = 0 AndAlso ListaDeEspera.Count > 0 Then
                    For Each Cuenta In ListaDeEspera
                        If Dominios.ContainsKey(Cuenta.Value.Postoffice) Then
                            If Dominios(Cuenta.Value.Postoffice).Enabled Then
                                IO.File.Move($"{CarpetaLocalMigraciones.FullName}\{Cuenta.Key}.xml", $"{CarpetaQuened.FullName}\{Cuenta.Key}.xml")
                                ListaDeEspera.TryRemove(Cuenta.Key, Nothing)
                                Servicio.Stop()
                                Servicio.WaitForStatus(ServiceControllerStatus.Stopped)
                                Servicio.Start()
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If MailBoxes.Count > 0 Then
                If MailBoxes.First.Value.Progress = 1 Then
                    lstCuentasEnMigracion.Invoke(Sub() lstCuentasEnMigracion.Items.Clear())
                    IO.File.Delete($"{CarpetaCompletados.FullName}\{MailBoxes.First.Key}.xml")
                    MailBoxes.Clear()
                ElseIf MailBoxes.First.Value.FailureMessage <> "" Then
                    lstCuentasEnMigracion.Invoke(Sub() lstCuentasEnMigracion.Items.Clear())
                    If IO.File.Exists($"{CarpetaLocalErroneos.FullName}\{MailBoxes.First.Key}.xml") Then IO.File.Delete($"{CarpetaLocalErroneos.FullName}\{MailBoxes.First.Key}.xml")
                    IO.File.Move($"{CarpetaProgress.FullName}\{MailBoxes.First.Key}.xml", $"{CarpetaLocalErroneos.FullName}\{MailBoxes.First.Key}.xml")
                    Dim Traspaso As MailboxMigrationOperation = Nothing
                    MailBoxes.TryRemove(MailBoxes.First.Key, Traspaso)
                    Erroneos.TryAdd(Traspaso.Username, Traspaso)
                End If
            End If

        End Sub
        Private Sub Refresh_Migraciones_Foreground(Sender As Object, ByRef Detener As Boolean) Handles Refresh_Migraciones.Foreground
            If IsNothing(Servicio) Then
                LabelService.BackColor = Color.Black
                If Not IsNothing(BtnService) Then BtnService.Text = "No Instalado"
            Else
                If Not IsNothing(LabelService) AndAlso Not IsNothing(BtnService) Then
                    Servicio.Refresh()
                    Select Case Servicio.Status
                        Case ServiceControllerStatus.Running
                            LabelService.BackColor = Color.Green
                            BtnService.Text = "Detener"
                            If Not BtnService.Enabled Then BtnService.Enabled = True
                        Case ServiceControllerStatus.Stopped
                            LabelService.BackColor = Color.Red
                            BtnService.Text = "Iniciar"
                            If Not BtnService.Enabled Then BtnService.Enabled = True
                        Case Else
                            LabelService.BackColor = Color.Yellow
                            BtnService.Text = "Trabajando..."
                            If BtnService.Enabled Then BtnService.Enabled = False
                    End Select
                End If
            End If

            If Not IsNothing(lstDominiosConfigurados) Then
                'lstDominiosConfigurados.Items.Clear()

                For Each Dominio In Dominios
                    If Not lstDominiosConfigurados.Items.ContainsKey(Dominio.Key) Then
                        Dim CrearDominio As New ListViewItem With {.Text = Dominio.Key, .Name = Dominio.Key}
                        lstDominiosConfigurados.Items.Add(CrearDominio)
                        Dim CrearEstado As New ListViewItem.ListViewSubItem With {.Text = Dominio.Value.Enabled, .Name = $"_{Dominio.Key}"}
                        CrearDominio.SubItems.Add(CrearEstado)
                    Else
                        If lstDominiosConfigurados.Items.Find(Dominio.Key, False).First.SubItems(1).Text <> Dominio.Value.Enabled Then
                            lstDominiosConfigurados.Items.Find(Dominio.Key, False).First.SubItems(1).Text = Dominio.Value.Enabled
                        End If
                    End If
                Next
            End If
            'Dominios.Clear()

            If Not IsNothing(lstCuentasEnMigracion) Then
                lstCuentasEnMigracion.Items.Clear()

                For Each Cuenta In MailBoxes
                    If Not lstCuentasEnMigracion.Items.ContainsKey(Cuenta.Key) Then
                        Dim CrearCuenta As New ListViewItem With {.Text = Cuenta.Key, .Name = Cuenta.Key}
                        Dim CrearProgreso As New ListViewItem.ListViewSubItem With {.Text = CInt(Math.Round(Cuenta.Value.Progress * 100)) & "%", .Name = $"_{Cuenta.Value.Progress}"}
                        lstCuentasEnMigracion.Items.Add(CrearCuenta)
                        CrearCuenta.SubItems.Add(CrearProgreso)
                    Else
                        lstCuentasEnMigracion.Items.Find(Cuenta.Key, False).First.SubItems.Item(1).Text = CInt(Math.Round(Cuenta.Value.Progress * 100)) & "%"
                    End If
                Next
            End If
            MailBoxes.Clear()

            If Not IsNothing(lstListaDeEspera) Then
                lstListaDeEspera.Items.Clear()

                For Each Cuenta In ListaDeEspera
                    If Not lstListaDeEspera.Items.ContainsKey(Cuenta.Key) Then
                        Dim CrearCuenta As New ListViewItem With {.Text = Cuenta.Key, .Name = Cuenta.Key}
                        Dim CrearProgreso As New ListViewItem.ListViewSubItem With {.Text = CInt(Math.Round(Cuenta.Value.Progress * 100)) & "%", .Name = $"_{Cuenta.Value.Progress}"}
                        lstListaDeEspera.Items.Add(CrearCuenta)
                        CrearCuenta.SubItems.Add(CrearProgreso)
                    Else
                        lstListaDeEspera.Items.Find(Cuenta.Key, False).First.SubItems.Item(1).Text = CInt(Math.Round(Cuenta.Value.Progress * 100)) & "%"
                    End If
                Next
            End If
            ListaDeEspera.Clear()

            If Not IsNothing(lstErroneos) Then
                For Each Cuenta In Erroneos
                    If Not lstErroneos.Items.ContainsKey(Cuenta.Key) Then
                        Dim CrearCuenta As New ListViewItem With {.Text = Cuenta.Key, .Name = Cuenta.Key}
                        Dim CrearEstado As New ListViewItem.ListViewSubItem With {.Text = Cuenta.Value.FailureMessage, .Name = Cuenta.Key}
                        lstErroneos.Items.Add(CrearCuenta)
                        CrearCuenta.SubItems.Add(CrearEstado)
                    End If
                Next
            End If

            If Refresh_Migraciones.Intervalo <> 3000 Then Refresh_Migraciones.Intervalo = 3000
        End Sub

        Public Sub MigrarCuenta()
            Dim Asistente As New Interfaz.FrmMigrarCuenta With {.Text = "Migrar", .MailBoxes = MailEnableMailBox, .CarpetaDeEspera = CarpetaLocalMigraciones}
            With Asistente.lstDominios
                For Each Dominio In MailEnableDomains
                    .Items.Add(Dominio).Name = Dominio
                Next
            End With
            Asistente.Show(MailEnableLog.IpBanForm)
        End Sub

        Public Sub LimpiarErroneos()
            For Each Archivo In CarpetaLocalErroneos.GetFiles
                Archivo.Delete()
            Next
            Erroneos.Clear()
            lstErroneos.Items.Clear()
        End Sub
        Public Sub HabilitarDominio(Dominio As String)
            Try
                If IO.File.Exists(MailEnableLog.Configuracion.MAIL_APP & $"\Config\Migration\{Dominio}.xml") Then
                    Dominios(Dominio).Enabled = True
                    Dim Guardar As String = String.Join(vbNewLine, XmlTemplate_MailboxMigrationOperation)
                    Guardar = String.Format(Guardar,
                                            Dominios(Dominio).Postoffice,
                                            Dominios(Dominio).Enabled.ToString.ToLower,
                                            Dominios(Dominio).MigrationStrategy.RemoteServerAddress,
                                            Dominios(Dominio).MigrationStrategy.Port,
                                            Dominios(Dominio).MigrationStrategy.UseSSL)
                    IO.File.WriteAllText(MailEnableLog.Configuracion.MAIL_APP & $"\Config\Migration\{Dominio}.xml", Guardar)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Sub DesHabilitarDominio(Dominio As String)
            Try
                If IO.File.Exists(MailEnableLog.Configuracion.MAIL_APP & $"\Config\Migration\{Dominio}.xml") Then
                    If Not Dominios.ContainsKey(Dominio) Then Exit Sub
                    Dominios(Dominio).Enabled = False
                    Dim Guardar As String = String.Join(vbNewLine, XmlTemplate_MailboxMigrationOperation)
                    Guardar = String.Format(Guardar,
                                            Dominios(Dominio).Postoffice,
                                            Dominios(Dominio).Enabled.ToString.ToLower,
                                            Dominios(Dominio).MigrationStrategy.RemoteServerAddress,
                                            Dominios(Dominio).MigrationStrategy.Port,
                                            Dominios(Dominio).MigrationStrategy.UseSSL)
                    IO.File.WriteAllText(MailEnableLog.Configuracion.MAIL_APP & $"\Config\Migration\{Dominio}.xml", Guardar)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Sub CrearDominio()
            Dim Asistente As New Interfaz.FrmActivarDominio With {.Text = "Migrar", .CarpetaMigracion = CarpetaMigracion, .Dominios = Dominios}
            With Asistente.lstDominios
                For Each Dominio In MailEnableDomains
                    .Items.Add(Dominio).Name = Dominio
                Next
            End With
            Asistente.Show(MailEnableLog.IpBanForm)
        End Sub
        Public Sub EliminarDominio(Dominio As String)
            Dim Archivo As String = $"{CarpetaMigracion.FullName}\{Dominio}.xml"
            If IO.File.Exists(Archivo) Then IO.File.Delete(Archivo)
            If lstDominiosConfigurados.Items.ContainsKey(Dominio) Then
                lstDominiosConfigurados.Items.Remove(lstDominiosConfigurados.Items.Find(Dominio, False).First)
            End If
            If Dominios.ContainsKey(Dominio) Then Dominios.TryRemove(Dominio, Nothing)
        End Sub
    End Module

    Namespace MailEnable
        Public Class MailEnableMailBox
            Public Domain As String
            Public Pwd As String
        End Class
    End Namespace

End Namespace