Namespace MailEnable
    Public Class MailBoxLoginContador
        'Construccion (MailBox)(Ip,Contraseña)
        Private MailBoxes As New Concurrent.ConcurrentDictionary(Of String, Concurrent.ConcurrentQueue(Of String))

        Public Function Exist(MailBox As String) As Boolean
            Return MailBoxes.ContainsKey(MailBox)
        End Function

        Public Sub Add(MailBox As String)
            MailBoxes.TryAdd(MailBox, New Concurrent.ConcurrentQueue(Of String))
        End Sub
        Public Sub AddIp(MailBox As String, Ip As String)
            If Not MailBoxes(MailBox).Contains(Ip) Then MailBoxes(MailBox).Enqueue(Ip)
        End Sub
        Public Function Count(MailBox As String) As Integer
            Return MailBoxes(MailBox).Count
        End Function

        Public Function [Get](MailBox As String) As List(Of String)
            Return MailBoxes(MailBox).ToList
        End Function
    End Class
End Namespace