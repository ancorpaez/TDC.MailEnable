﻿Namespace BDD
    Public Class IMAPCorrectas
        Inherits InheritBdd

        Public Sub New()
            MyBase.New("IMAPCorrectas")
        End Sub


        Protected Friend Overrides Function Inicializar() As BDD.InheritColumnas
            Return New Rows
        End Function

        Public Overrides Function GetColString(Columnas As BDD.InheritColumnas.Columnas) As Object
            Return CType(Columnas, Rows.Columnas).ToString
        End Function

        Public Overrides Function GetColIndex(Columnas As BDD.InheritColumnas.Columnas) As Object
            Return CType(Columnas, Rows.Columnas)
        End Function

        Public Class Rows
            Inherits BDD.InheritColumnas
            Public Property IP As String = String.Empty
            Public Property Accesos As Int32 = -1
            Public Property Pais As String = "0"
            'Public Property TimeLeft As Integer = 1000
        End Class

        Public Shadows Enum Columnas
            IP = 1
            Accesos = 2
            Pais = 3
            'TimeLeft = 4
        End Enum
    End Class
End Namespace