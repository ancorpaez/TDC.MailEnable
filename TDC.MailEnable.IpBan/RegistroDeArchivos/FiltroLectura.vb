Namespace RegistroDeArchivos
    Public Class FiltroLectura
        Public Enum EnumCondicion
            Contiene
            NoContiene
        End Enum
        Public Filtro As String
        Public Condicion As EnumCondicion
        Public ContrastarMailBox As Boolean = False
    End Class
End Namespace