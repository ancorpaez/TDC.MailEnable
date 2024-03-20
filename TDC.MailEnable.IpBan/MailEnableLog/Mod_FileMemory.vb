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
    End Class
End Namespace