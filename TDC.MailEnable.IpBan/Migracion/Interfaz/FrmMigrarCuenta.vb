Namespace Migracion.Interfaz
    Public Class FrmMigrarCuenta
        Public MailBoxes As New Concurrent.ConcurrentDictionary(Of String, Migracion.MailEnable.MailEnableMailBox)
        Public CarpetaDeEspera As IO.DirectoryInfo = Nothing
        Private XmlTemplate As New List(Of String) From {
            "<?xml version=""1.0""?>",
            "<MailboxMigrationOperation xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">",
            "  <Postoffice>{0}</Postoffice>",
            "  <Mailbox>{1}</Mailbox>",
            "  <Username>{2}</Username>",
            "  <Password>{3}</Password>",
            "  <Progress>0</Progress>",
            "  <LastAttemptTime>0001-01-01T00:00:00</LastAttemptTime>",
            "  <LastFailureTime>0001-01-01T00:00:00</LastFailureTime>",
            "</MailboxMigrationOperation>"}

        Private Sub lstDominios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDominios.SelectedIndexChanged
            lstCuentas.Items.Clear()
            chkTodasLasCuentas.Enabled = False
            chkTodasLasCuentas.Checked = False
            BtnAceptar.Enabled = False
            If lstDominios.SelectedItems.Count > 0 Then
                For Each Cuenta In MailBoxes
                    If Cuenta.Key.Contains(lstDominios.SelectedItems.Item(0).Text) Then lstCuentas.Items.Add(Cuenta.Key).Name = Cuenta.Key
                Next
                chkTodasLasCuentas.Enabled = True
            End If
        End Sub

        Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
            Me.Close()
        End Sub

        Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
            For Each Cuenta As ListViewItem In lstCuentas.CheckedItems
                If MailBoxes.ContainsKey(Cuenta.Name) Then
                    With MailBoxes(Cuenta.Name)
                        Dim XmlString As String = String.Join(vbNewLine, XmlTemplate)
                        XmlString = String.Format(XmlString,
                                                .Domain,
                                                Cuenta.Name.Split("@")(0),
                                                Cuenta.Name,
                                                .Pwd)
                        IO.File.WriteAllText(CarpetaDeEspera.FullName & $"\{Cuenta.Name}.xml", XmlString)
                    End With
                End If
            Next
            Me.Close()
        End Sub

        Private Sub lstCuentas_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lstCuentas.ItemChecked
            If lstCuentas.CheckedItems.Count > 0 Then BtnAceptar.Enabled = True Else BtnAceptar.Enabled = False
        End Sub

        Private Sub chkTodasLasCuentas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodasLasCuentas.CheckedChanged
            For Each Item As ListViewItem In lstCuentas.Items
                Item.Checked = chkTodasLasCuentas.Checked
            Next
        End Sub

        Private Sub TabTestCheck_Click(sender As Object, e As EventArgs) Handles TabTestCheck.Click
            If chkTodasLasCuentas.Enabled Then
                chkTodasLasCuentas.Checked = Not chkTodasLasCuentas.Checked
            End If
        End Sub
    End Class
End Namespace