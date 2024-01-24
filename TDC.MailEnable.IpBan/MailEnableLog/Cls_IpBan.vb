Imports System.ComponentModel
Imports System.Net
Imports TDC.MailEnable.Core

Namespace MailEnableLog
    Public Class Cls_IpBan
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

        Public Function Add(Ip As String) As Boolean
            Try
                If Not String.IsNullOrEmpty(Ip) Then
                    Dim SearchIp4 As IPAddress = Net.IPAddress.Parse(Ip)
                    If SearchIp4.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                        If Not Ips.Contains(SearchIp4.ToString) Then
                            Ips.Add(SearchIp4.ToString)
                            Mod_Core.SalvarIpBan()
                            Return True
                        Else
                            MsgBox("La IP ya está en la lista de bloqueo.")
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return False
        End Function
        Public Function Remove(Ip As String) As Boolean
            Try
                If Ips.Contains(Ip) Then Ips.Remove(Ip)
                Mod_Core.SalvarIpBan()
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

        Public Function ToList() As List(Of String)
            Return Ips.ToList
        End Function
    End Class
End Namespace