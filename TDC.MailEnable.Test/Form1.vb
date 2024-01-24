Imports TDC.MailEnable.Core

Public Class Form1
    'Private Test1 = New TDC.MailEnable.Core.Main

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox(TDC.MailEnable.Core.TestString)
    End Sub
End Class
