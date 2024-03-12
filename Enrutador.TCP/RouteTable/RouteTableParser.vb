Imports System.Text.RegularExpressions

Namespace RouteTable
    Public Class RouteTableParser
        Implements IDisposable

        Public Route As Concurrent.ConcurrentDictionary(Of String, RouteEntry) = ParseIPv4Routes(RoutePrint)
        Dim disposedValue As Boolean

        Public Sub New()

        End Sub
        Private Function RoutePrint() As String
            Using RouteCommand As New Process
                With RouteCommand
                    With .StartInfo
                        .FileName = "route"
                        .Arguments = "PRINT"
                        .RedirectStandardOutput = True
                        .UseShellExecute = False
                    End With
                    .Start()
                    .WaitForExit()
                    Return .StandardOutput.ReadToEnd
                End With
            End Using
        End Function

        Private Function ParseIPv4Routes(routePrintOutput As String) As Concurrent.ConcurrentDictionary(Of String, RouteEntry)
            Dim routes As New Concurrent.ConcurrentDictionary(Of String, RouteEntry)

            ' Expresión regular para encontrar la tabla de enrutamiento IPv4
            Dim ipv4TableRegex As New Regex("IPv4 Tabla de enrutamiento\s+(?:=+\s+Rutas activas:.*?Rutas persistentes:.*?)+", RegexOptions.Singleline)
            Dim ipv4TableMatch As Match = ipv4TableRegex.Match(routePrintOutput)

            If ipv4TableMatch.Success Then
                ' Extraer líneas de la tabla de enrutamiento IPv4
                Dim ipv4TableLines As String() = ipv4TableMatch.Value.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

                ' Iterar sobre las líneas para extraer las rutas
                For i As Integer = 2 To ipv4TableLines.Length - 1 ' Empezar desde la línea 2 para omitir el encabezado
                    Dim parts As String() = ipv4TableLines(i).Split(New String() {" "}, StringSplitOptions.RemoveEmptyEntries)
                    If parts.Length >= 6 AndAlso Not parts(0) = "Destino" Then
                        Dim GetRoute As New RouteEntry()
                        GetRoute.Ip = parts(0)
                        GetRoute.Mask = parts(1)
                        GetRoute.Gateway = parts(4)
                        routes.TryAdd(GetRoute.Ip, GetRoute)
                    End If
                Next
            End If

            Return routes
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