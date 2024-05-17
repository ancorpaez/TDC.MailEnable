Imports System.ComponentModel
Imports TDC.MailEnable.Core
Imports TDC.MailEnable.Core.Windows.Registro

Namespace MailEnableLog
    Public Class IpBlancaSincronizada
        Private WithEvents Ips As New Concurrent.ConcurrentBindingList(Of String)
        Public Event AlActualizarLista()
        Private Property EsAccionDeUsuario As Boolean = False
        Private CarpetaRegistro As Microsoft.Win32.RegistryKey = Acciones.ObtenerCarpeta(Acceso.Ramas.HKEY_LOCAL_MACHINE, "\SOFTWARE\WOW6432Node\Mail Enable\Mail Enable\Connectors\SMTP\White List")
        Private IpsRegistro As List(Of String) = Nothing
        Private WithEvents MonitorClaves As MonitorDeCambiosDeClavesDelRegistro
        Public Sub New()
            If IsNothing(CarpetaRegistro) Then Throw New Exception("No se encuentra la lista blanca en el registro")
            ActualizarDesdeElRegistro()
            MonitorClaves = New MonitorDeCambiosDeClavesDelRegistro(CarpetaRegistro, CarpetaRegistro.GetValueNames)
        End Sub
        Public Property Data As BindingList(Of String)
            Get
                'Actualizar desde el Registro
                Return Ips
            End Get
            Set(value As BindingList(Of String))
                Ips = value
            End Set
        End Property

        Public Function Add(Optional Ip As String = "") As Boolean

            Try
                'Renovar la Lista
                ActualizarDesdeElRegistro()
                'No admitir Nulos
                If String.IsNullOrEmpty(Ip.Trim) Then Return False

                'Solo Admitir IpV4
                If Not Net.IPAddress.Parse(Ip.Trim).AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then Return False

                If Not Ips.Contains(Ip.Trim) Then
                    EsAccionDeUsuario = True
                    Ips.Add(Ip.Trim)
                    If Not Acciones.ExisteClave(CarpetaRegistro, Ip.Trim) Then Return Acciones.EstablecerDWORD(CarpetaRegistro, Ip.Trim, 0)
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
            Return False
        End Function
        Public Function Remove(Ip As String) As Boolean
            Try
                'Renovar la Lista
                ActualizarDesdeElRegistro()

                'Eliminar
                EsAccionDeUsuario = True
                If Ips.Contains(Ip) Then Ips.Remove(Ip)
                If Acciones.ExisteClave(CarpetaRegistro, Ip) Then Return Acciones.EliminarClave(CarpetaRegistro, Ip)
                Return True
            Catch ex As Exception
                Return False
            End Try
            Return False
        End Function
        Public Function Count() As Integer
            Return Ips.Count
        End Function

        Public Function Contains(IP As String) As Boolean
            Return Ips.Contains(IP)
        End Function
        Private Sub Ips_ListChanged(sender As Object, e As ListChangedEventArgs) Handles Ips.ListChanged
            'Verfica que la adicion de Ips es por parte del Usuario
            If EsAccionDeUsuario Then
                EsAccionDeUsuario = False
                RaiseEvent AlActualizarLista()
            End If
        End Sub

        Private Sub ActualizarDesdeElRegistro()
            IpsRegistro = Acciones.ObtenerClaves(CarpetaRegistro).ToList
            For Each Ip In IpsRegistro
                If Not Ips.Contains(Ip) Then
                    Ips.Add(Ip)
                    RaiseEvent AlActualizarLista()
                End If
            Next
        End Sub

        Private Sub MonitorClaves_AlAñadirClave(sender As Object, Clave As String) Handles MonitorClaves.AlAñadirClave
            Add(Clave)
        End Sub

        Private Sub MonitorClaves_AlEliminarClave(sender As Object, Clave As String) Handles MonitorClaves.AlEliminarClave
            Remove(Clave)
        End Sub
    End Class
End Namespace