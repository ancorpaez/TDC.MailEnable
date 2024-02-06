Imports System.Net.Sockets
Imports System.Threading

Namespace Interfaz
    Public Class Main
        Private IpBaneadas
        Private SyncLockActualizarConexiones As New Object()
        Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            'PRUEBAS

            '*****************************************************

            ' Obtener las dimensiones de la pantalla
            Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width
            Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height

            ' Definir las nuevas coordenadas para la esquina inferior derecha
            'Dim newLeft As Integer = screenWidth - Me.Width
            Dim newTop As Integer = screenHeight - Me.Height

            ' Establecer las nuevas coordenadas
            Me.Left = 0
            Me.Width = screenWidth
            Me.Top = newTop

            'Iniciar Lista IpBan
            Routing.IpBaneadasPipe = New Core.Pipe.ClientPipe

            'Inicializar el Enrutador IMAP
            Routing.Main()
            GridImapRechazados.DataSource = Routing.Rechazados.Tabla
            GridImapRechazados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            GridImapRechazados.Columns(0).Visible = False
            GridImapClientes.DataSource = Routing.Clientes.Tabla
            GridImapClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            GridImapClientes.Columns(0).Visible = False
            Routing.ActualizarConexionesActivas = Function() ActualizarConexiones()

        End Sub

        Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            ' Preguntar al usuario antes de cerrar la ventana
            Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que quieres cerrar la ventana?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            ' Si el usuario elige "No", cancelar el cierre de la ventana
            If result = DialogResult.No Then
                e.Cancel = True
            End If
        End Sub

        Private Function ActualizarConexiones() As String
            If Monitor.TryEnter(SyncLockActualizarConexiones) Then
                Me.Invoke(Sub()
                              Try
                                  lstConexionesImapActivas.Items.Clear()
                                  For Each Cliente In Routing.Conexiones
                                      lstConexionesImapActivas.Items.Add(Cliente.Key)
                                  Next
                                  lblConexionesActivas.Text = lstConexionesImapActivas.Items.Count
                                  'GridImapClientes.Refresh()
                                  'GridImapRechazados.Refresh()
                              Catch ex As Exception
                                  Stop
                              End Try
                          End Sub)
            End If
            Return Nothing
        End Function

        Private Sub tmiFace_Tick(sender As Object, e As EventArgs) Handles tmiFace.Tick

            'Lista de Ip Banedas & Pipe
            Dim StringCaption As String = "IMAP - Ip's {0} | PIPE {1}"
            If Not IsNothing(Routing.IpBaneadas) Then
                StringCaption = String.Format(StringCaption, Routing.IpBaneadas.Count, Routing.IpBaneadasPipe.EstadoPipe.ToString)
            Else
                StringCaption = String.Format(StringCaption, "0", Routing.IpBaneadasPipe.EstadoPipe.ToString)
            End If
            Me.Text = StringCaption

            If Not IsNothing(Routing.imapListener) AndAlso Not IsNothing(Routing.imapListener.LocalEndpoint) Then
                lblImap.BackColor = Color.Green
            Else
                lblImap.BackColor = Color.Red
            End If

            If Not IsNothing(Routing.imapSslListener) AndAlso Not IsNothing(Routing.imapSslListener.LocalEndpoint) Then
                lblImapSsl.BackColor = Color.Green
            Else
                lblImapSsl.BackColor = Color.Red
            End If
        End Sub

        Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click
            Try
                If GridImapClientes.SelectedRows.Count > 0 Then
                    Clipboard.SetText(GridImapClientes.SelectedRows.Item(0).Cells.Item(1).Value)
                End If
            Catch ex As Exception

            End Try

        End Sub
    End Class
End Namespace