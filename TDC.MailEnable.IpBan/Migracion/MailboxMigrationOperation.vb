Imports System.Xml.Serialization
Namespace Migracion
    <XmlRoot("MailboxMigrationOperation")>
    Public Class MailboxMigrationOperation
        Public Property Postoffice As String
        Public Property Mailbox As String
        Public Property Username As String
        Public Property Password As String
        Public Property Progress As Double
        Public Property LastAttemptTime As DateTime
        Public Property MigrationSettings As MigrationSettings
        Public Property FailureMessage As String
        Public Property LastFailureTime As DateTime
    End Class

    Public Class MigrationSettings
        <XmlElement("RemoteServerAddress")>
        Public Property RemoteServerAddress As String

        <XmlElement("Port")>
        Public Property Port As Integer
    End Class
End Namespace