Namespace Interfaz
    Public Class Conexion
        Private WithEvents Enrutador As Enrutadores.Enrutador
        Public Sub New(Enrutador As Enrutadores.Enrutador)

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            Me.Enrutador = Enrutador
            lblConexion.Text = Enrutador.Conexion.RemoteEndPoint.ToString
        End Sub

        Private Sub Enrutador_Actividad(Activo As Integer, Enrutador As Enrutadores.Enrutador) Handles Enrutador.Actividad
            lblTiempo.Text = Activo
        End Sub

        Private Sub Enrutador_AlCerrarEnrutador(Enrutador As Enrutadores.Enrutador) Handles Enrutador.AlCerrarEnrutador
            If Aplicacion.VC.TryTake(Me) Then
                Me.Close()
            Else
                lblConexion.Text = "ERROR"
            End If
        End Sub
    End Class
End Namespace