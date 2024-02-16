Namespace MailEnableLog
    Module Mod_FileMemory
        Public FileMemory As New Concurrent.ConcurrentDictionary(Of String, Cls_FileMemory)
    End Module
    Public Class Cls_FileMemory
        Public Line As Integer = 0
        Public MailBoxLogin As New Cls_MailBoxLogin
        Public Lines As New Concurrent.ConcurrentDictionary(Of Integer, String)
    End Class
End Namespace