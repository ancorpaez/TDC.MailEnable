Namespace MailEnableLog
    Module Mod_FileMemory
        Public FileMemory As New Concurrent.ConcurrentDictionary(Of String, Cls_FileMemory)
    End Module
    Public Class Cls_FileMemory
        'Establece la Linea de Lectura
        Public Line As Integer = 0
        'Almacena las Ip Logueadas por MailBox
        Public MailBoxLogin As New Cls_MailBoxLogin
        'Almacena las coincidencias por IP la lectura General del Archivo
        Public Coincidentes As New Concurrent.ConcurrentDictionary(Of String, Integer)
        'Almacena las lineas del Archivo
        Public Lines As New Concurrent.ConcurrentDictionary(Of Integer, String)
        'Almacena los Login Correctos por IP (IP,DOMINIO,CUENTAS)
        Public CrossLogin As New Concurrent.ConcurrentDictionary(Of String, Concurrent.ConcurrentDictionary(Of String, Concurrent.ConcurrentBag(Of String)))
        'Registra la IP con sus inicios de sesion Fallidos.
        Public IpLoginsRecords As New Concurrent.ConcurrentDictionary(Of String, MailBoxPasswordsUsedRecords)

    End Class

    Public Class MailBoxPasswordsUsedRecords
        Private Records As New Concurrent.ConcurrentBag(Of MailBoxPasswordsUsedRecord)
        Public Sub Add(Item As MailBoxPasswordsUsedRecord)
            Records.Add(Item)
        End Sub
        Public Function Items() As List(Of MailBoxPasswordsUsedRecord)
            Return Records.ToList
        End Function
    End Class

    Public Class MailBoxPasswordsUsedRecord
            Public MailBox As String
            Public Password As String
        End Class
End Namespace