Imports System.Runtime.Remoting.Metadata.W3cXsd2001
Namespace MailEnable
    Public Class MailEnableDenyIp
        Implements IDisposable

        Public ArchivoDeBloqueo As String = ""
        Private Ips As New System.Collections.Concurrent.ConcurrentDictionary(Of String, String)
        Private disposedValue As Boolean

        Public Sub New(ArchivoDeBloqueo As String)
            Me.ArchivoDeBloqueo = ArchivoDeBloqueo
            Cargar()
        End Sub

        Private Sub Cargar()
            For Each Linea In IO.File.ReadAllLines(ArchivoDeBloqueo)
                Ips.TryAdd(Linea.Split(vbTab)(0), Linea)
            Next
        End Sub

        Public Function Contais(Ip As String) As Boolean
            Return Ips.ContainsKey(Ip)
        End Function
        Public Function Remove(Ip As String) As Boolean
            Return Ips.TryRemove(Ip, Nothing)
        End Function
        Public Function Add(Ip As String) As Boolean
            Return Ips.TryAdd(Ip, String.Format("{0}{1}1{1}CONNECT{1}SYSTEM", Ip, vbTab))
        End Function

        Public Sub Clear()
            Ips.Clear()
        End Sub

        Public Function Count() As Integer
            Return Ips.Count
        End Function

        Public Sub Guardar()
            Try
                IO.File.WriteAllLines(ArchivoDeBloqueo, Ips.Values)
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: eliminar el estado administrado (objetos administrados)
                    Ips.Clear()
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