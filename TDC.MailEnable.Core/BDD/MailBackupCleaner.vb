Namespace BDD
    Public Class MailBackupCleaner
        Inherits Mod_Backup

        Public Sub New()
            MyBase.New("MailBackupCleaner")
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
            Public Property Registrado As DateTime = New Date

        End Class

        Public Shadows Enum Columnas
            Archivo = 1
            Registrado = 2
        End Enum
    End Class
End Namespace