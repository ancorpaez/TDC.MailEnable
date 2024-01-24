Namespace Bucle
    Public Interface IBucle
        Sub Inicia()
        Sub Detener()
        Property Intervalo As Integer
        ReadOnly Property GetHashCode As Integer
        Event Bucle(Sender As Object, ByRef Detener As Boolean)
    End Interface
End Namespace