﻿Namespace MailEnable
    Public Class Configuracion
        Public POST_OFFICES As String = ""
        Public MAIL_APP As String = ""
        Public IMAP As String = ""
        Public SMTP As String = ""
        Public POP As String = ""
        Public WEB As String = ""
        Public SMTP_DENY As String = ""
        Public POP_DENY As String = ""
        Public WEB_DENY As String = ""
        Public IMAP_SOCKET_APP As String = ""
        Public SPAM_SPAMASSASSIN As String = ""
        Public AutoArranqueWindows As Boolean = True
        Public TIMER_LECTURA As String = ""
        Public TIMER_PROPAGACION As String = ""
        Public LECTURA_REPOSO As String = "60000"
        Public CARPETA_BACKUP As String = ""
        Public ANTIGUEDAD_EMAILS As String = (30 * 6)
        Public ANALIZADORES_BACKUP As Integer = 10
        Public ANALIZADORES_BACKUP_TIMER As Integer = 1000
        Public AUTORESPONDER As String = ""
    End Class
End Namespace