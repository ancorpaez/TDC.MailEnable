Imports System.IO
Imports TDC.MailEnable.IpBan.MailEnable

Namespace AnalisisLog
    Namespace ArchivosEnMemoria
        Module Core
            Public Archivos As New Concurrent.ConcurrentDictionary(Of String, Archivo)
        End Module

        Public Class Archivo
            'Establece la Linea de Lectura
            Public Property Line As Integer = 0
            'Almacena las Ip Logueadas por MailBox
            Public MailBoxLogin As New MailBoxLoginContador
            'Almacena las coincidencias por IP la lectura General del Archivo
            Public Coincidentes As New Concurrent.ConcurrentDictionary(Of String, Integer)
            'Almacena las lineas del Archivo
            Public Lines As New Concurrent.ConcurrentDictionary(Of Integer, String)
            'Almacena los Login Correctos por IP (IP,DOMINIO,CUENTAS)
            Public CrossLogin As New Concurrent.ConcurrentDictionary(Of String, Concurrent.ConcurrentDictionary(Of String, Concurrent.ConcurrentBag(Of String)))
            'Registra la IP con sus inicios de sesion Fallidos.
            Public IpLoginsRecords As New Concurrent.ConcurrentDictionary(Of String, MailBoxLogins)
        End Class

        'Almacena los Logins encontrados por Usuario (correo@correo.com)
        Public Class MailBoxLogins
            Private Registros As New Concurrent.ConcurrentBag(Of MailBoxLogin)
            Public Sub Add(Item As MailBoxLogin)
                Registros.Add(Item)
            End Sub
            Public Function Items() As List(Of MailBoxLogin)
                Return Registros.ToList
            End Function
        End Class

        Public Class MailBoxLogin
            Public MailBox As String
            Public Password As String
        End Class
    End Namespace
End Namespace