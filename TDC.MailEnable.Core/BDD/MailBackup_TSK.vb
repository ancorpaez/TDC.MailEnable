Namespace BDD
    Public Class MailBackup_TSK
        Inherits Mod_Backup

        Public Sub New()
            MyBase.New("MailBackup_TSK")
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
            Public Property Asunto As String = String.Empty
            Public Property Notas As String = String.Empty

        End Class

        Public Shadows Enum Columnas
            Archivo = 1
            Asunto = 2
            Notas = 3
        End Enum
    End Class
End Namespace