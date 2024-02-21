Namespace BDD
    Public Class MailBackupIndex
        Inherits Core

        Public Sub New()
            MyBase.New("BackupIndex")
        End Sub


        Protected Friend Overrides Function Inicializar() As BDD.Columnas
            Return New Rows
        End Function

        Public Overrides Function GetColString(Columnas As BDD.Columnas.Columnas) As Object
            Return CType(Columnas, Columnas).ToString
        End Function

        Public Overrides Function GetColIndex(Columnas As BDD.Columnas.Columnas) As Object
            Return CType(Columnas, Columnas)
        End Function

        Public Class Rows
            Inherits BDD.Columnas
            Public Property Archivo As String = UniqueState.Unique.ToString
            Public Property Remitente As String = String.Empty
            Public Property Destinatarios As String = String.Empty
            Public Property ConCopia As String = String.Empty
            Public Property Asunto As String = String.Empty
            Public Property Fecha As DateTime = New Date

        End Class

        Public Shadows Enum Columnas
            Archivo = 1
            Remitente = 2
            Destinatarios = 3
            ConCopia = 4
            Asunto = 5
            Fecha = 6
        End Enum
    End Class
End Namespace