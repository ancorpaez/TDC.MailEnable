Namespace RegistroDeArchivos
    Public Class Cls_Filtro
        Public Enum EnumTipoComparacion
            Cualquiera
            Todo
        End Enum
        Public Key As FilterKeys.FilterKey
        Public TrueSi As EnumTipoComparacion = EnumTipoComparacion.Cualquiera
        Public Repeteciones As Integer = 0
        Public VerificarMailBox As Boolean = False
        Public DetectarCrossDomainLogin As Boolean = False
        Public Coincidencias As New List(Of Cls_Coincidencia)
    End Class
    Public Class FilterKeys
        Public Enum FilterKey
            PopLoginFail
            SMTPLoginFailMailBox
            SMTPLoginFailNoMailBox
            SMTPOutNoLogin
            IMAPLoginFail
            IMAPMultipleDomainLogin
            WEBPostLogin
            WEBGetFail
            WEBPost404
            WEBHead404
        End Enum
    End Class
    Public Class FilterCount
        Public Nombre As String
        Public Coincidencias As Integer
    End Class

End Namespace