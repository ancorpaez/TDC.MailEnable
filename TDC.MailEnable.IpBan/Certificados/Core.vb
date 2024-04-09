Imports System.Runtime.ConstrainedExecution
Imports System.Security.Cryptography.X509Certificates

Namespace Certificados
    Module Core
        Public Domains As New Concurrent.ConcurrentQueue(Of Domain)
        Public CertificateFolder As New IO.DirectoryInfo(Application.StartupPath & "\Certificados")
        Private FaceTabControl As TabControl
        Private WithEvents Exportador As PemToPfx
        Private FaceListControl As ListView

        Private WithEvents Actualizador As New TDC.MailEnable.Core.Bucle.DoBucle("ActualizadorSsl")
        Public Sub Main(TabControl As TabControl, ListControl As ListView)
            If Not CertificateFolder.Exists Then CertificateFolder.Create()

            FaceListControl = ListControl
            FaceTabControl = TabControl

            Actualizador.Iniciar()
        End Sub

        Public Sub DownloadedFile(sender As Object, File As Interfaz.FileDownloadedEvent)
            Console.WriteLine(File.Path)
            Dim Convertir As New PemToPfx
            AddHandler Convertir.AlConvertirPem, AddressOf Exportador_AlConvertirPem
            Convertir.Convert(File.Path)
        End Sub

        Private Sub Exportador_AlConvertirPem(sender As Object, File As PemToPfx.PemExportEvent)
            RemoveHandler CType(sender, PemToPfx).AlConvertirPem, AddressOf Exportador_AlConvertirPem
            If RequiereInstalar(File.Path) Then
                Dim InstalarPxf As New Instalar With {.rutaCertificado = File.Path}
                Dim CertNuevo As X509Certificate2 = New X509Certificate2(File.Path, "")
                Dim CertAntiguo As X509Certificate2 = CertificadoSistema(CertNuevo)
                InstalarPxf.Instalar(CertAntiguo)
            End If
        End Sub

        Private Sub Actualizador_Foreground(Sender As Object, ByRef Detener As Boolean) Handles Actualizador.Foreground
            Domain1()
            Domain2()
            Do While Domains.Count > 0
                Dim eDomain As Domain
                If Domains.TryDequeue(eDomain) Then
                    If Not FaceTabControl.TabPages.ContainsKey(eDomain.Key) Then
                        Dim cTab As New TabPage With {.Name = eDomain.Key, .Text = eDomain.Key}
                        FaceTabControl.TabPages.Add(cTab)
                        eDomain.Download()
                        cTab.Controls.Add(eDomain.Viewer)
                        eDomain.Viewer.Dock = DockStyle.Fill
                        AddHandler eDomain.Viewer.FileDownloaded, AddressOf DownloadedFile
                    Else
                        CType(FaceTabControl.TabPages(eDomain.Key).Controls(eDomain.Key), Interfaz.Navegador).WB.Source = eDomain.Url
                    End If
                End If
            Loop

            For Each CertificadoPfx In CertificateFolder.GetFiles("*.pfx")
                Dim aPfx As X509Certificate2 = New X509Certificate2(CertificadoPfx.FullName, "")
                Dim Item As New ListViewItem With {.Name = aPfx.GetNameInfo(X509NameType.SimpleName, False), .Text = aPfx.GetNameInfo(X509NameType.SimpleName, False)}
                Dim sItem As New ListViewItem.ListViewSubItem With {.Name = $"_{aPfx.GetNameInfo(X509NameType.SimpleName, False)}", .Text = CDate(aPfx.GetExpirationDateString).ToShortDateString}
                Item.SubItems.Add(sItem)

                If Not FaceListControl.Items.ContainsKey(Item.Name) Then
                    FaceListControl.Items.Add(Item)
                Else
                    FaceListControl.Items(Item.Name).SubItems($"_{Item.Name}").Text = CDate(aPfx.GetExpirationDateString).ToShortDateString
                End If
            Next
            Actualizador.Intervalo = DateDiff(DateInterval.Second, Now, Now.AddHours(12)) * 1000
            'Actualizador.Intervalo = 30000
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
            Dim certCollection As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindByThumbprint, Pfx.Thumbprint, False)
            store.Close()
            'devuelve el primer certificado encontrado
            If certCollection.Count > 0 Then Return certCollection.Item(0)
            'no devuelve nada
            Return Nothing
        End Function
    End Module
End Namespace