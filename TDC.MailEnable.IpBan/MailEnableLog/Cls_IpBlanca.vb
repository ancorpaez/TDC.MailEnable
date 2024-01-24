Imports System.ComponentModel
Imports TDC.MailEnable.Core

Namespace MailEnableLog
    Public Class Cls_IpBlanca
        Private WithEvents Ips As New Concurrent.ConcurrentBindingList(Of String)
        Public Event OnRefresData()
        Private AddingBackGrundList As Boolean = False

        Public Sub New()
        End Sub
        Public Property Data As BindingList(Of String)
            Get
                Return Ips
            End Get
            Set(value As BindingList(Of String))
                Ips = value
            End Set
        End Property

        Public Function Add(Optional Ip As String = "") As Boolean

            Try
                'No admitir Nulos
                If String.IsNullOrEmpty(Ip) Then Return False
                'No Admitir String que no sean Ips
                Ip = Net.IPAddress.Parse(Ip).ToString
                'Solo Admitir IpV4
                If Not Net.IPAddress.Parse(Ip).AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then Return False

                If Ip = "" Then
                    If Not String.IsNullOrEmpty(Ips.AddNew()) Then Mod_Core.SalvarIpBlanca()
                Else
                    If Not Ips.Contains(Ip) Then
                        AddingBackGrundList = True
                        Ips.Add(Net.IPAddress.Parse(Ip).ToString)
                        Mod_Core.SalvarIpBlanca()
                    End If
                End If
                Return True
            Catch ex As Exception
            End Try
            Return False
        End Function
        Public Function Remove(Ip As String) As Boolean
            Try
                If Ips.Contains(Ip) Then Ips.Remove(Ip)
                Mod_Core.SalvarIpBlanca()
                Return True
            Catch ex As Exception
            End Try
            Return False
        End Function
        Public Function Count() As Integer
            Return Ips.Count
        End Function

        Public Function Contains(IP As String) As Boolean
            Return Ips.Contains(IP)
        End Function
        Private Sub Ips_AddingNew(sender As Object, e As AddingNewEventArgs) Handles Ips.AddingNew
            Try
                Dim NuevaIp = Net.IPAddress.Parse(InputBox("Ip")).ToString
                If Not Ips.Contains(NuevaIp) Then e.NewObject = NuevaIp
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub Ips_ListChanged(sender As Object, e As ListChangedEventArgs) Handles Ips.ListChanged
            If AddingBackGrundList Then
                AddingBackGrundList = False
                RaiseEvent OnRefresData()
            End If
        End Sub
    End Class
End Namespace