Namespace BDD
    Public Class MailBackup_VCF
        Inherits InheritBdd

        Public Sub New()
            MyBase.New("MailBackup_VCF")
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
            Public Property Nombre As String = String.Empty
            Public Property NombreCompleto As String = String.Empty
            Public Property Email As String = String.Empty
            Public Property EmailTrabajo As String = String.Empty
            Public Property EmailPersonal As String = String.Empty
            Public Property Nick As String = String.Empty

        End Class

        Public Shadows Enum Columnas
            Archivo = 1
            Nombre = 2
            NombreCompleto = 3
            Email = 4
            EmailTrabajo = 5
            EmailPersonal = 6
            Nick = 7
        End Enum
    End Class
End Namespace