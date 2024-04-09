Imports System.Xml.Serialization

Namespace Migracion.Interfaz
    Public Class FrmActivarDominio
        Public Dominios As Concurrent.ConcurrentDictionary(Of String, MailboxMigrationStrategy)
        Public CarpetaMigracion As IO.DirectoryInfo = Nothing
        Private XmlTemplate As New List(Of String) From {
            "<?xml version=""1.0""?>",
            "<MailboxMigrationStrategy xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">",
            "  <Postoffice>{0}</Postoffice>",
            "  <Mailbox />",
            "  <Enabled>false</Enabled>",
            "  <MigrationStrategy xsi:type=""IMAPMigrationStrategy"">",
            "    <RemoteServerAddress>{1}</RemoteServerAddress>",
            "    <Port>{2}</Port>",
            "    <UseSSL>{3}</UseSSL>",
            "  </MigrationStrategy>",
            "  <SourceDescription>Generic Internet Mail Server</SourceDescription>",
            "</MailboxMigrationStrategy>"}

        Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
            Me.Close()
        End Sub

        Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
            If Not IsNothing(Dominios) AndAlso Not IsNothing(CarpetaMigracion) Then
                If lstDominios.SelectedItems.Count > 0 AndAlso
                    Not String.IsNullOrEmpty(txtServidorRemoto.Text) AndAlso
                    txtServidorRemoto.Text.Count(Function(c) c = ".") >= 2 AndAlso
                    Not String.IsNullOrEmpty(txtPuerto.Text) AndAlso
                    IsNumeric(txtPuerto.Text) Then

                    Dim XmlString As String = String.Join(vbNewLine, XmlTemplate)
                    XmlString = String.Format(XmlString,
                                              lstDominios.SelectedItems.Item(0).Text,
                                              txtServidorRemoto.Text,
                                              txtPuerto.Text,
                                              chkSSL.Checked.ToString.ToLower)
                    Dim f As String = $"{CarpetaMigracion.FullName}\{lstDominios.SelectedItems.Item(0).Text}.xml"
                    If IO.File.Exists(f) Then IO.File.Delete(f)
                    IO.File.WriteAllText(f, XmlString)
                    Me.Close()
                End If
            End If
        End Sub

        Private Sub chkSSL_CheckedChanged(sender As Object, e As EventArgs) Handles chkSSL.CheckedChanged
            If chkSSL.Checked Then txtPuerto.Text = 993 Else txtPuerto.Text = 143
        End Sub

        Private Sub lstDominios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDominios.SelectedIndexChanged
            txtServidorRemoto.Text = String.Empty
            chkSSL.Checked = False
            txtPuerto.Text = String.Empty
            If Not IsNothing(CarpetaMigracion) AndAlso lstDominios.SelectedItems.Count > 0 Then
                Dim f As String = $"{CarpetaMigracion.FullName}\{lstDominios.SelectedItems.Item(0).Text}.xml"
                If IO.File.Exists(f) Then
                    Using Leer As New IO.StreamReader(f)
                        Dim CargarXml As New XmlSerializer(GetType(MailboxMigrationStrategy))
                        Dim DomXml As MailboxMigrationStrategy = CType(CargarXml.Deserialize(Leer), MailboxMigrationStrategy)
                        txtPuerto.Text = DomXml.MigrationStrategy.Port
                        txtServidorRemoto.Text = DomXml.MigrationStrategy.RemoteServerAddress
                        If String.IsNullOrEmpty(DomXml.MigrationStrategy.UseSSL) Then
                            chkSSL.Checked = False
                        Else
                            chkSSL.Checked = CBool(DomXml.MigrationStrategy.UseSSL)
                        End If
                    End Using
                End If
            End If
        End Sub
    End Class
End Namespace