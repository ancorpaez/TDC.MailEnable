Namespace RouteTable
    Public Class RouteOperation
        Implements IDisposable

        Dim disposedValue As Boolean

        Public Function Add(Entry As RouteEntry) As Boolean
            Using AddCommand As New Process
                With AddCommand
                    With .StartInfo
                        .FileName = "route"
                        .Arguments = $"ADD {Entry.Ip} MASK {Entry.Mask} {Entry.Gateway} IF 13"
                        .RedirectStandardOutput = True
                        .UseShellExecute = False
                    End With
                    .Start()
                    .WaitForExit()
                    If AddCommand.StandardOutput.ReadToEnd.Trim = "Correcto" Then Return True
                End With
            End Using
            Return False
        End Function

        Public Function Remove() As Boolean

        End Function

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: eliminar el estado administrado (objetos administrados)
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
    End Class
End Namespace