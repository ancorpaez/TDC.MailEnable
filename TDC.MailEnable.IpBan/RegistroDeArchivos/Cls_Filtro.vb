Namespace RegistroDeArchivos
    Public Class Cls_Filtro
        Public Enum EnumTipoComparacion
            Cualquiera
            Todo
        End Enum
        Public TrueSi As EnumTipoComparacion = EnumTipoComparacion.Cualquiera
        Public Repeteciones As Integer = 0
        Public VerificarMailBox As Boolean = False
        Public Coincidencias As New List(Of Cls_Coincidencia)
    End Class
End Namespace