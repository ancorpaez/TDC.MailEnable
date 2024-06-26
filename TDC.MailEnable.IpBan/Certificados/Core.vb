﻿Imports System.Runtime.ConstrainedExecution
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml.Serialization
Imports System.IO

Namespace Certificados
    Module Core
        Public Hostings As New Concurrent.ConcurrentDictionary(Of String, PleskHosting)
        Public Domains As New Concurrent.ConcurrentQueue(Of PleskDomain)
        Public ReadOnly Property Guiones As New Concurrent.ConcurrentQueue(Of PleskCertificateDownload)
        Public ReadOnly Property GuionesProcesados As New Concurrent.ConcurrentQueue(Of PleskCertificateDownload)

        Public CarpetaCertificadosDescargados As New IO.DirectoryInfo(Application.StartupPath & "\Certificados")

        Private UiFaceTabControl As TabControl = Nothing
        Private UiFaceListControl As ListView = Nothing
        Private UiFaceListLogDownload As ListView = Nothing

        Private WithEvents Actualizador As New TDC.MailEnable.Core.Bucle.DoBucle("ActualizadorSsl")

        Public Sub Main(TabControl As TabControl, ListControl As ListView, ListDownload As ListView)
            If Not CarpetaCertificadosDescargados.Exists Then CarpetaCertificadosDescargados.Create()

            UiFaceListControl = ListControl
            UiFaceTabControl = TabControl
            UiFaceListLogDownload = ListDownload

            'Ej: Domains.Enqueue(New PleskDomain("midominio.com") With {.DomainId = "100", .CertificateId = "50", .UserName = "myuser", .UserPassword = "mypassword", .HostingKey = "hosting.com"})
            Privado.EnquenePleskDomains()

            'Ej: Dim PleskHostingAntiguo As New PleskHosting("hosting.com") With {.Url = New Uri("https://hosting.com")}
            With Privado.PleskHostingAntiguo
                .Navigation.TryAdd("/view", New Uri($"{ .Url.AbsoluteUri}modules/sslit/index.php/index/proxy?dom_id=[$DomainId]&site_id=[$DomainId]"))
                .Navigation.TryAdd("certificate/id/[$DomainId]", New Uri($"{ .Url.AbsoluteUri}smb/ssl-certificate/list/id/[$DomainId]"))
                .Navigation.TryAdd("list/id/[$DomainId]", New Uri($"{ .Url.AbsoluteUri}smb/ssl-certificate/download/id/[$DomainId]/certificateId/[$CertificateId]"))
                .Scripts.TryAdd("login_up.php", "var formulario = document.getElementById('form-login');
                                    if (formulario) {{
                                        formulario.login_name.value = '[$UserName]';
                                        formulario.passwd.value = '[$UserPassword]';
                                        formulario.submit();
                                    }} else {{
                                        console.error('No se encontró el formulario con el id formulario_prueba');
                                    }}")
            End With
            Hostings.TryAdd(PleskHostingAntiguo.Name, PleskHostingAntiguo)


            With Privado.PleskHostingNuevo
                .Navigation.TryAdd("/web/view", New Uri($"{ .Url.AbsoluteUri}smb/ssl-certificate/list/id/[$DomainId]"))
                .Navigation.TryAdd("ssl-certificate/list/id/[$DomainId]", New Uri($"{ .Url.AbsoluteUri}smb/ssl-certificate/download/id/[$DomainId]/certificateId/[$CertificateId]"))
                .Scripts.TryAdd("login_up.php", "var formulario = document.getElementById('form-login');
                                    if (formulario) {{
                                        formulario.login_name.value = '[$UserName]';
                                        formulario.passwd.value = '[$UserPassword]';
                                        formulario.submit();
                                    }} else {{
                                        console.error('No se encontró el formulario con el id formulario_prueba');
                                    }}")
            End With
            Hostings.TryAdd(PleskHostingNuevo.Name, PleskHostingNuevo)

            For Each Domain In Domains
                Dim EnlaceHosting As New PleskHosting(Domain.HostingKey) With {.Url = Hostings(Domain.HostingKey).Url}
                For Each Navigation In Hostings(Domain.HostingKey).Navigation
                    EnlaceHosting.Navigation.TryAdd(GuionToDomain(Navigation.Key, Domain), New Uri(GuionToDomain(Navigation.Value.AbsoluteUri, Domain)))
                Next
                For Each Script In Hostings(Domain.HostingKey).Scripts
                    EnlaceHosting.Scripts.TryAdd(GuionToDomain(Script.Key, Domain), GuionToDomain(Script.Value, Domain))
                Next
                Guiones.Enqueue(New PleskCertificateDownload With {.Domain = Domain, .Hosting = EnlaceHosting})
            Next

            Actualizador.Iniciar()
        End Sub

        Private Function GuionToDomain(Cadena As String, Dominio As PleskDomain) As String
            Dim nCadena As String = Cadena
            nCadena = nCadena.Replace("[$DomainId]", Dominio.DomainId)
            nCadena = nCadena.Replace("[$CertificateId]", Dominio.CertificateId)
            nCadena = nCadena.Replace("[$UserName]", Dominio.UserName)
            nCadena = nCadena.Replace("[$UserPassword]", Dominio.UserPassword)
            Return nCadena
        End Function
        Public Sub DownloadedFile(sender As Object, File As Interfaz.FileDownloadedEvent)
            CType(sender, Interfaz.Navegador).Guion.LogOut()
            Dim Convertir As New PemToPfx
            AddHandler Convertir.AlConvertirPem, AddressOf Exportador_AlConvertirPem
            Convertir.Convert(File.Path)
            TryGetCertificate()
        End Sub
        Public Sub EndProcessGetCertificate(sender As Object)
            CType(sender, Interfaz.Navegador).esDescargado = False
        End Sub
        Private Sub Exportador_AlConvertirPem(sender As Object, File As PemToPfx.PemExportEvent)
            RemoveHandler CType(sender, PemToPfx).AlConvertirPem, AddressOf Exportador_AlConvertirPem
            Dim cItem As New ListViewItem With {.Text = IO.Path.GetFileName(File.Path)}
            Dim cItemNow As New ListViewItem.ListViewSubItem With {.Text = $"{Now.ToShortDateString} {Now.ToShortTimeString}"}
            Dim cItemResult As ListViewItem.ListViewSubItem = Nothing
            cItem.SubItems.Add(cItemNow)
            If RequiereInstalar(File.Path) Then
                Dim InstalarPxf As New Instalar With {.rutaCertificado = File.Path}
                Dim CertNuevo As X509Certificate2 = New X509Certificate2(File.Path, "")
                Dim CertAntiguo As X509Certificate2 = CertificadoSistema(CertNuevo)
                InstalarPxf.Instalar(CertAntiguo)
                cItemResult = New ListViewItem.ListViewSubItem With {.Text = "True"}
            Else
                cItemResult = New ListViewItem.ListViewSubItem With {.Text = "False"}
            End If
            cItem.SubItems.Add(cItemResult)
            If Not IsNothing(UiFaceListLogDownload) Then UiFaceListLogDownload.Items.Add(cItem)
        End Sub

        Private Sub TryGetCertificate()
            If Guiones.Count > 0 Then
                Dim Guion As PleskCertificateDownload = Nothing
                If Guiones.TryDequeue(Guion) Then
                    If Not UiFaceTabControl.TabPages.ContainsKey(Guion.Domain.Name) Then
                        Dim cTab As New TabPage With {.Name = Guion.Domain.Name, .Text = Guion.Domain.Name}
                        UiFaceTabControl.TabPages.Add(cTab)
                        Guion.Download()
                        cTab.Controls.Add(Guion.Viewer)
                        UiFaceTabControl.SelectTab(UiFaceTabControl.TabPages(Guion.Domain.Name).TabIndex)
                        Guion.Viewer.Dock = DockStyle.Fill
                        AddHandler Guion.Viewer.FileDownloaded, AddressOf DownloadedFile
                        AddHandler Guion.Viewer.EndProcess, AddressOf EndProcessGetCertificate
                    Else
                        UiFaceTabControl.SelectTab(UiFaceTabControl.TabPages(Guion.Domain.Name).TabIndex)
                        Guion.Viewer.esDescargado = False
                        Guion.Viewer.WB.Reload()
                    End If
                    GuionesProcesados.Enqueue(Guion)
                End If
            End If
        End Sub

        Private Sub Actualizador_Foreground(Sender As Object, Detener As TDC.MailEnable.Core.Bucle.BackgroundEventArgs) Handles Actualizador.ForeGround
            'Resetea los Guiones
            If Guiones.Count > 0 AndAlso GuionesProcesados.Count = 0 Then
                TryGetCertificate()
            ElseIf Guiones.Count = 0 AndAlso GuionesProcesados.Count > 0 Then
                Do While GuionesProcesados.Count > 0
                    Dim Guion As PleskCertificateDownload = Nothing
                    If GuionesProcesados.TryDequeue(Guion) Then
                        Guiones.Enqueue(Guion)
                    End If
                Loop
                TryGetCertificate()
            End If

            'Muestra los certificados descargados
            For Each CertificadoPfx In CarpetaCertificadosDescargados.GetFiles("*.pfx")
                Dim aPfx As X509Certificate2 = New X509Certificate2(CertificadoPfx.FullName, "")
                Dim Item As New ListViewItem With {.Name = aPfx.GetNameInfo(X509NameType.SimpleName, False), .Text = aPfx.GetNameInfo(X509NameType.SimpleName, False)}
                Dim sItem As New ListViewItem.ListViewSubItem With {.Name = $"_{aPfx.GetNameInfo(X509NameType.SimpleName, False)}", .Text = CDate(aPfx.GetExpirationDateString).ToShortDateString}
                Item.SubItems.Add(sItem)

                If Not UiFaceListControl.Items.ContainsKey(Item.Name) Then
                    UiFaceListControl.Items.Add(Item)
                Else
                    UiFaceListControl.Items(Item.Name).SubItems($"_{Item.Name}").Text = CDate(aPfx.GetExpirationDateString).ToShortDateString
                End If
            Next

            'Establece el periodo de descarga en 12 Horas
            Actualizador.Intervalo = DateDiff(DateInterval.Second, Now, Now.AddHours(12)) * 1000
        End Sub

        Private Function RequiereInstalar(Pfx As String) As Boolean
            Dim CertPfx As X509Certificate2 = New X509Certificate2(Pfx, "")
            Dim CertLocal As X509Certificate2 = CertificadoSistema(CertPfx)

            'Si no existe en la parte local Instalar
            If IsNothing(CertLocal) Then Return True

            Dim CaducaPfx As Date = Date.Parse(CertPfx.GetExpirationDateString)
            Dim CaducaLocal As Date = Date.Parse(CertLocal.GetExpirationDateString)

            If DateDiff(DateInterval.Second, CaducaLocal, CaducaPfx) > 0 Then
                'Es mas actualizado el Pfx
                Return True
            End If
            'No requiere actualizar
            Return False
        End Function

        Private Function CertificadoSistema(Pfx As X509Certificate2) As X509Certificate2
            Dim store As X509Store = New X509Store(StoreName.My, StoreLocation.LocalMachine)
            store.Open(OpenFlags.ReadOnly)
            Dim certCollection As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, Pfx.Subject, False)
            store.Close()
            'devuelve el primer certificado encontrado
            If certCollection.Count > 0 Then Return certCollection.Item(0)
            'no devuelve nada
            Return Nothing
        End Function

    End Module
End Namespace