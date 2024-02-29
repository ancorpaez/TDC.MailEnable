Imports System.IO
Imports System.Xml.Serialization
Imports TDC.MailEnable.Core

Namespace RegistroDeArchivos
    Public Class RegistroDeArchivos
        Public Property Archivos As New Concurrent.ConcurrentBindingList(Of String)
        Public Filtro As New List(Of Cls_Filtro)
        Private File_Registro As String = ""
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
            Dim Crear As New XmlSerializer(GetType(Concurrent.ConcurrentBindingList(Of String)))
            Using Guardar As New StreamWriter(File_Registro)
                Crear.Serialize(Guardar, Archivos)
            End Using
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