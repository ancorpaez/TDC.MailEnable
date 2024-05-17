Imports TDC.MailEnable.Core.Bucle
Namespace Windows
    Namespace Registro
        Public Class MonitorDeCambiosDeClavesDelRegistro
            Private WithEvents Monitor As New DoBucle("MonitorRegistroIpBlancas") With {.Intervalo = 1000}
            Private Carpeta As Microsoft.Win32.RegistryKey = Nothing
            Private ClavesGuardadas As String() = {}
            Private ClavesConsultadas As String() = {}

            Public Event AlAñadirClave(sender As Object, Clave As String)
            Public Event AlEliminarClave(sender As Object, Clave As String)


            Public Sub New(Carpeta As Microsoft.Win32.RegistryKey, Claves As String())
                Me.Carpeta = Carpeta
                ClavesGuardadas = Claves
                ClavesConsultadas = Me.Carpeta.GetValueNames
                Monitor.Iniciar()
            End Sub

            Private Sub Monitor_BackGround(Sender As Object, e As BackgroundEventArgs) Handles Monitor.BackGround
                If Not IsNothing(Carpeta) Then
                    ClavesConsultadas = Carpeta.GetValueNames
                    If Not ClavesConsultadas.SequenceEqual(ClavesGuardadas) Then
                        If ClavesConsultadas.Count > ClavesGuardadas.Count Then
                            'Añadir
                            For Each Ip In ClavesConsultadas
                                If Not ClavesGuardadas.Contains(Ip) Then RaiseEvent AlAñadirClave(Me, Ip)
                            Next
                        Else
                            'Eliminar
                            For Each Ip In ClavesGuardadas
                                If Not ClavesConsultadas.Contains(Ip) Then RaiseEvent AlEliminarClave(Me, Ip)
                            Next
                        End If
                        ClavesGuardadas = ClavesConsultadas
                    End If
                End If
            End Sub
        End Class
    End Namespace
End Namespace