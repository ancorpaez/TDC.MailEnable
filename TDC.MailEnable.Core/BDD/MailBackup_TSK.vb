Namespace BDD
    Public Class MailBackup_TSK
        Inherits InheritBdd

        Public Sub New()
            MyBase.New("MailBackup_TSK")
        End Sub


        Protected Friend Overrides Function Inicializar() As BDD.InheritColumnas
            Return New Rows
        End Function

        Public Overrides Function GetColString(Columnas As BDD.InheritColumnas.Columnas) As Object
            Return CType(Columnas, Columnas).ToString
        End Function

        Public Overrides Function GetColIndex(Columnas As BDD.InheritColumnas.Columnas) As Object
            Return CType(Columnas, Columnas)
        End Function

        Public Class Rows
            Inherits BDD.InheritColumnas
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