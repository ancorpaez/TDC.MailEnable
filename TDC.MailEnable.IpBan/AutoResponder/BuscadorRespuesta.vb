Imports System.IO
Imports System.Text

Namespace AutoResponder
    Public Class BuscadorRespuesta
        Implements IDisposable
        Public Respuesta As String
        Private rutaArchivo As String = String.Empty
        Private cadenaBuscada As String = String.Empty
        Private resultado As New StringBuilder()

        Dim disposedValue As Boolean
        Public Sub New(ArchivoLog As String, Email As String)
            rutaArchivo = ArchivoLog
            cadenaBuscada = Email
            Obtener()
        End Sub

        Private Sub Obtener()
            If IO.File.Exists(rutaArchivo) Then
                Using Cargar As StreamReader = New IO.StreamReader(IO.File.Open(rutaArchivo, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite))
                    Dim Linea As String = String.Empty
                    Dim esCoincidencia As Boolean = False
                    Dim SaltosDeLinea As Integer = 0
                    Do
                        Linea = Cargar.ReadLine
                        If Not String.IsNullOrEmpty(Linea) Then
                            If Linea.Contains(cadenaBuscada) Then
                                resultado.AppendLine(Linea)
                                If Not esCoincidencia Then esCoincidencia = True
                            Else
                                If esCoincidencia AndAlso SaltosDeLinea > 20 Then Exit Do
                                If esCoincidencia Then SaltosDeLinea += 1
                            End If
                        End If
                    Loop While Not String.IsNullOrEmpty(Linea)
                End Using
            End If
            Respuesta = resultado.ToString
        End Sub
#Region "IDisposable"
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: eliminar el estado administrado (objetos administrados)
                    resultado.Clear()
                    resultado = Nothing
                    Respuesta = Nothing
                    cadenaBuscada = Nothing
                    rutaArchivo = Nothing
                End If

                ' TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                ' TODO: establecer los campos grandes como NULL
                disposedValue = True
            End If
        End Sub

        ' ' TODO: reemplazar el finalizador solo si "Dispose(disposing As Boolean)" tiene código para liberar los recursos no administrados
        ' Protected Overrides Sub Finalize()
        '     ' No cambie este código. Coloque el código de limpieza en el método "Dispose(disposing As Boolean)".
        '     Dispose(disposing:=False)
        '     MyBase.Finalize()
        ' End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            ' No cambie este código. Coloque el código de limpieza en el método "Dispose(disposing As Boolean)".
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
End Namespace
