Imports System.IO
Imports System.IO.Pipes

Namespace Pipe
    Public Class ServerPipe
        'Private Server As NamedPipeServerStream
        Private WithEvents BucleDatos As New Bucle.DoBucle
        Private Csv As String = String.Empty
        Public ObtenerLista As Func(Of List(Of String)) = Nothing

        Public Sub New()
            'Server = New NamedPipeServerStream(PipeServerName)
            BucleDatos.Intervalo = 100
            BucleDatos.Iniciar()
        End Sub

        Private Sub BucleDatos_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles BucleDatos.Background
            Using Server = New NamedPipeServerStream(PipeServerName)
                With Server

                    'Generar el Csv
                    If Not IsNothing(ObtenerLista) Then
                        Try
                            Csv = String.Join(",", ObtenerLista())
                        Catch ex As Exception
                            Csv = String.Empty
                        End Try
                    End If

                    If Not String.IsNullOrEmpty(Csv) Then
                        'Esperar Conexion
                        .WaitForConnection()

                        'Enviar el Csv
                        Using Escribir As New StreamWriter(Server)
                            Escribir.Write(Csv)
                        End Using
                    End If

                End With
            End Using
        End Sub
    End Class
End Namespace