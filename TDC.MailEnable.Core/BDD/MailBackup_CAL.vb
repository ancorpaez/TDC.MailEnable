Namespace BDD
    Public Class MailBackup_CAL
        Inherits Mod_Backup

        Public Sub New()
            MyBase.New("MailBackup_CAL")
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
            Public Property Descripcion As String = String.Empty
            Public Property Hubicacion As String = String.Empty
            Public Property Inicio As String = String.Empty
            Public Property Fin As String = String.Empty

        End Class

        Public Shadows Enum Columnas
            Archivo = 1
            Descripcion = 2
            Hubicacion = 3
            Inicio = 4
            Fin = 5
        End Enum
    End Class
End Namespace