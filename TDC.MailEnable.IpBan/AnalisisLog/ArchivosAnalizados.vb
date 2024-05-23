Imports System.IO
Imports System.Xml.Serialization
Imports TDC.MailEnable.Core

Namespace AnalisisLog
    Public Class ArchivosAnalizados
        Public Property Archivos As New Concurrent.ConcurrentBindingList(Of String)
        Public Property Filtro As New List(Of Filtro)
        Private File_Registro As String = ""
        Private SyncGuardar As New Object()

        Public Sub New(Contenedor As String)
            File_Registro = Contenedor & ".xml"
            If Not IO.File.Exists(File_Registro) Then Guardar() Else Cargar()
        End Sub

        Private Sub Cargar()
            Dim Cargar As New XmlSerializer(GetType(Concurrent.ConcurrentBindingList(Of String)))
            Using Leer As New StreamReader(File_Registro)
                Archivos = DirectCast(Cargar.Deserialize(Leer), Concurrent.ConcurrentBindingList(Of String))
            End Using
        End Sub
        Public Sub Guardar()
            SyncLock SyncGuardar
                Dim [Error] As Boolean = False
                Dim Crear As XmlSerializer
                Do
                    Try
                        Crear = New XmlSerializer(GetType(Concurrent.ConcurrentBindingList(Of String)))
                        Using Guardar As New StreamWriter(IO.File.Open(File_Registro, IO.FileMode.OpenOrCreate, IO.FileAccess.Write, IO.FileShare.ReadWrite))
                            Crear.Serialize(Guardar, Archivos)
                        End Using
                        [Error] = False
                    Catch ex As Exception
                        [Error] = True
                    End Try
                Loop While [Error]
            End SyncLock
        End Sub

        Public Sub Add(Archivo As String)
            If Not Archivos.Contains(Archivo) Then
                Archivos.Add(Archivo)
                Guardar()
            End If
        End Sub
        Public Function Contains(Archivo As String) As Boolean
            Return Archivos.Contains(Archivo)
        End Function

        Public Function Count()
            Return Archivos.Count
        End Function
    End Class


End Namespace