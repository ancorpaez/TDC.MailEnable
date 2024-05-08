Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Namespace Bucle
    Public Class View
        Private Visualizador As Bucle.DoBucle
        Private ItemForeColor As Color = Color.Black
        Private ItemTrueColor As Color = Color.DarkGreen
        Private ItemFalseColor As Color = Color.DarkRed

        Private Sub View_Load(sender As Object, e As EventArgs) Handles MyBase.Load

            Visualizador = GetOrCreate("VisualizadorDoBucle")
            AddHandler Visualizador.BackGround, AddressOf Visualizador_BackGround
            AddHandler Visualizador.ForeGround, AddressOf Visualizador_ForeGround
            AddHandler Visualizador.EndGround, AddressOf Visualizador_EndGround
            AddHandler Visualizador.ErrorGround, AddressOf Visualizador_ErrorGround


            'Inicializar lo que encuentre
            Visualizador_ForeGround(Nothing, Nothing)

            'Establecer textos iniciales
            SetText()
            TrakVisualizador.Value = Visualizador.Intervalo

            'Iniciar el Controlador
            Visualizador.Iniciar()
        End Sub
        Private Sub View_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
            RemoveHandler Visualizador.BackGround, AddressOf Visualizador_BackGround
            RemoveHandler Visualizador.ForeGround, AddressOf Visualizador_ForeGround
            RemoveHandler Visualizador.EndGround, AddressOf Visualizador_EndGround
            RemoveHandler Visualizador.ErrorGround, AddressOf Visualizador_ErrorGround
        End Sub
        Private Sub View_Activated(sender As Object, e As EventArgs) Handles Me.Activated
            SetColumns()
            SetText()
        End Sub

        Private Sub View_Resize(sender As Object, e As EventArgs) Handles Me.Resize
            SetColumns()
        End Sub
        Private Sub Visualizador_BackGround(Sender As Object, e As BackgroundEventArgs)

        End Sub

        Private Sub Visualizador_ForeGround(Sender As Object, e As BackgroundEventArgs)
            For Each B In GlobalDoBucle
                If Not IsNothing(B) Then
                    If Not lstBucles.Items.ContainsKey(B.Key) Then
                        Dim Visualizar As New Windows.Forms.ListViewItem With {.Name = B.Key, .Text = B.Key}
                        lstBucles.Items.Add(Visualizar)
                        Dim Contador As New Windows.Forms.ListViewItem.ListViewSubItem With {.Name = "c" & B.Key, .Text = B.Value.Contador}
                        Visualizar.SubItems.Add(Contador)
                        Dim Intervalo As New Windows.Forms.ListViewItem.ListViewSubItem With {.Name = "i" & B.Key, .Text = B.Value.Intervalo}
                        Visualizar.SubItems.Add(Intervalo)
                        Dim Activo As New Windows.Forms.ListViewItem.ListViewSubItem With {.Name = "a" & B.Key, .Text = Not B.Value.Cancelar}
                        Visualizar.SubItems.Add(Activo)
                    Else
                        Dim Visualizar As Windows.Forms.ListViewItem = lstBucles.Items.Find(B.Key, False).First
                        Visualizar.SubItems.Item(1).Text = B.Value.Contador
                        Visualizar.SubItems.Item(2).Text = B.Value.Intervalo
                        Visualizar.SubItems.Item(3).Text = Not B.Value.Cancelar
                    End If
                Else
                    Dim Visualizar As Windows.Forms.ListViewItem = lstBucles.Items.Find(B.Key, False).First
                    Visualizar.SubItems.Item(1).Text = "Nothing"
                    Visualizar.SubItems.Item(2).Text = "0"
                    Visualizar.SubItems.Item(3).Text = "0"
                    Visualizar.SubItems.Item(4).Text = "False"

                End If

            Next
            SetColumns()
        End Sub

        Private Sub Visualizador_EndGround(Sender As Object, e As BackgroundEventArgs)

        End Sub

        Private Sub Visualizador_ErrorGround(Sender As Object, e As BackgroundEventArgs)

        End Sub

        Private Sub SetColumns()
            If Not Me.IsDisposed AndAlso Not Me.Disposing Then
                lstBucles.Columns(1).Width = 75
                lstBucles.Columns(2).Width = 75
                lstBucles.Columns(3).Width = 75
                lstBucles.Columns(0).Width = Me.Width - 250
            Else
                Visualizador.Detener()
                Visualizador.Matar()
            End If
        End Sub

        Private Sub SetText()
            If Not IsNothing(Visualizador) Then
                Visualizador.Intervalo = TrakVisualizador.Value
                tlblVisualizador.Text = $"Refresco ({Visualizador.Intervalo})"
                tlblBucles.Text = $"Procesos ({lstBucles.Items.Count})"
            End If
        End Sub
        Private Sub TrakVisualizador_Scroll(sender As Object, e As EventArgs) Handles TrakVisualizador.Scroll
            SetText()
        End Sub

        Private Sub tBtnManual_Click(sender As Object, e As EventArgs) Handles tBtnManual.Click
            Visualizador_ForeGround(Nothing, Nothing)
        End Sub


    End Class
End Namespace