Namespace Interfaz
    Public Class Main
        Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Aplicacion.MainForm = Me
            Me.Top = 486
        End Sub
        Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            ' Preguntar al usuario antes de cerrar la ventana
            Dim result As DialogResult = MessageBox.Show($"¿Estás seguro de que quieres cerrar la ventana?{vbNewLine}{vbNewLine}Esta acción dejara a los clientes sin servicio IMAP.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            ' Si el usuario elige "No", cancelar el cierre de la ventana
            If result = DialogResult.No Then
                e.Cancel = True
            End If
        End Sub


    End Class
End Namespace