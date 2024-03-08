Imports System.IO
Imports System.IO.Pipes

Namespace Pipe
    Public Class ClientPipe
        Private WithEvents BucleDatos As New Bucle.DoBucle("ClientPipe")
        Private Lista As List(Of String) = Nothing
        Public Event AlObtenerLaLista(Lista As List(Of String))
        Public Enum EnumEstadoPipe
            Esperando
            Conectando
            Conectado
        End Enum
        Public EstadoPipe As EnumEstadoPipe = EnumEstadoPipe.Esperando

        Public Sub New()
            BucleDatos.Intervalo = 100
            BucleDatos.Iniciar()
        End Sub

        Private Sub BucleDatos_Background(Sender As Object, ByRef Detener As Boolean) Handles BucleDatos.Background

            'Pasar el Bucle a 10 Minutos de Interaccion
            If BucleDatos.Intervalo = 100 Then BucleDatos.Intervalo = 6000

            'Conectar con el Servidor y Obtener la Lista
            Using Cliente = New NamedPipeClientStream(PipeServerName)
                With Cliente
                    Try
                        'Conectar al Servidor
                        EstadoPipe = EnumEstadoPipe.Conectando
                        .Connect()
                        EstadoPipe = EnumEstadoPipe.Conectado
                        'Generar la lista
                        Using Reader As New StreamReader(Cliente)
                            Lista = New List(Of String)(Reader.ReadToEnd.Split(","))
                        End Using

                        EstadoPipe = EnumEstadoPipe.Esperando
                    Catch ex As Exception
                        Lista = Nothing
                    End Try
                End With
            End Using
        End Sub

        Private Sub BucleDatos_Foreground(Sender As Object, ByRef Detener As Boolean) Handles BucleDatos.Foreground
            'Enviar la lista al proceso principal
            RaiseEvent AlObtenerLaLista(Lista)
        End Sub
    End Class
End Namespace