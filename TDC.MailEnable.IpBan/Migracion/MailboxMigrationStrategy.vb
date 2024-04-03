Imports System.Xml.Serialization
Imports System.Runtime.Serialization

Namespace Migracion
    <XmlRoot("MailboxMigrationStrategy")>
    Public Class MailboxMigrationStrategy
        Public Property Postoffice As String
        Public Property Mailbox As String
        Public Property Enabled As Boolean
        Public Property MigrationStrategy As IMAPMigrationStrategy
        Public Property SourceDescription As String
    End Class

    Public Class IMAPMigrationStrategy
        <XmlElement("RemoteServerAddress")>
        Public Property RemoteServerAddress As String

        <XmlElement("Port")>
        Public Property Port As Integer
        <XmlElement("UseSSL")>
        Public Property UseSSL As String
    End Class
End Namespace