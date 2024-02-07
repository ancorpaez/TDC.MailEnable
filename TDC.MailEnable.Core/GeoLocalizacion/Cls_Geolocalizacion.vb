Imports System.Net
Imports System.Collections.Concurrent
Namespace MailEnableLog
    Public Class Cls_Geolocalizacion
        '(IP,PAIS)
        Private WithEvents Almacen As New ConcurrentDictionary(Of String, String)
        Private Path As String
        Private ProtegerArchivo As Object = New Object

        Public Sub New(Almacen As String)
            Path = Almacen
            Cargar()
        End Sub

        Private Sub Remover(Linea As String)
            Try
                SyncLock ProtegerArchivo
                    Dim Archivo As String = IO.File.ReadAllText(Path).Replace(Linea, "")
                    IO.File.WriteAllText(Path, Archivo)
                End SyncLock
            Catch ex As Exception

            End Try
        End Sub
        Private Sub Salvar(Ip As String, Pais As String)
            Try
                SyncLock ProtegerArchivo
                    If Not IO.File.Exists(Path) Then IO.File.Create(Path).Close()
                    Dim Linea As String = String.Format("{0}|{1}", Ip, Pais) ' & vbCrLf
                    Dim Archivo As String = IO.File.ReadAllText(Path)
                    If Not Archivo.Contains(Linea) Then
                        Using Escribir = IO.File.AppendText(Path)
                            Escribir.WriteLine(String.Format(Linea))
                        End Using
                    End If
                End SyncLock
            Catch ex As Exception
            End Try
        End Sub
        Private Sub Cargar()
            Try
                SyncLock ProtegerArchivo
                    If IO.File.Exists(Path) Then
                        Dim Lineas As String() = IO.File.ReadAllLines(Path)
                        For Each Linea In Lineas
                            Dim Partes As String() = Linea.Replace(vbCrLf, "").Split("|")
                            Dim Ip As String = Partes(0)
                            Dim Pais As String = Partes(1)
                            If Not Almacen.ContainsKey(Ip) Then
                                Almacen.TryAdd(Ip, Pais)
                            End If
                        Next
                    End If
                End SyncLock
            Catch ex As Exception
            End Try
        End Sub

        Public Function Add(Ip As String, Pais As String) As Boolean
            Try
                If Not String.IsNullOrEmpty(Ip) AndAlso Not String.IsNullOrEmpty(Pais) Then
                    Dim SearchIp4 As IPAddress = Net.IPAddress.Parse(Ip)
                    If SearchIp4.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                        If Not Almacen.ContainsKey(SearchIp4.ToString) Then
                            Salvar(Ip, Pais)
                            Almacen.TryAdd(SearchIp4.ToString, Pais)
                            Return True
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
            Return False
        End Function
        Public Function Remove(Ip As String) As Boolean
            Try
                Dim Linea As String = ""
                If Almacen.ContainsKey(Ip) Then
                    Linea = String.Format("{0}|{1}" & vbCrLf, Ip, Almacen(Ip))
                    Remover(Linea)
                    Almacen.TryRemove(Ip, Nothing)
                End If
                Return True
            Catch ex As Exception
            End Try
            Return False
        End Function

        Public Function [Get](Ip As String) As String
            Try
                Return Almacen(Ip)
            Catch ex As Exception
            End Try
            Return "ERR"
        End Function

        Public Function Count() As Integer
            Return Almacen.Count
        End Function

        Public Function Contains(IP As String) As Boolean
            Return Almacen.ContainsKey(IP)
        End Function

    End Class
End Namespace