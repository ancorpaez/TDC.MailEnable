Namespace Escuchadores
    Module Core
        Public Enum EnumEscuchadores
            Imap
            ImapSSl
        End Enum

        Private Escuchadores As New Concurrent.ConcurrentDictionary(Of String, Escuchador)
        Public Function Existe(Escuchador As EnumEscuchadores) As Boolean
            Return Escuchadores.ContainsKey(Escuchador.ToString)
        End Function
        Public Function Crear(Escuchador As EnumEscuchadores, Puerto As Integer) As Boolean
            Dim CrearEscuchador As New Escuchador(Puerto)
            If CrearEscuchador.Escuchar Then
                If Escuchadores.TryAdd(Escuchador.ToString, CrearEscuchador) Then
                    Return True
                End If
            End If
            Return False
        End Function

        Public Function Obtener(Escuchador As EnumEscuchadores) As Escuchador
            Return Escuchadores(Escuchador.ToString)
        End Function
    End Module
End Namespace