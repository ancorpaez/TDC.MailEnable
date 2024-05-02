Namespace Backup
    Public Class Contact
        Private Contacto As New Concurrent.ConcurrentDictionary(Of String, String)
        Private Keys As New List(Of String) From {
            "EMAIL;PREF;INTERNET",
            "EMAIL;OTHER;INTERNET",
            "EMAIL;WORK;INTERNET",
            "FN",
            "N",
            "NICKNAME"}
        Dim Lineas() As String
        Public Sub New(FileFullName As String)
            For Each key In Keys
                Contacto.TryAdd(key, " ")
            Next
            If IO.File.Exists(FileFullName) Then Lineas = IO.File.ReadAllLines(FileFullName)
        End Sub

        Public Sub Analizar()
            For Each Linea In Lineas
                Dim Key As String = Linea.Split(":")(0)
                Dim Value As String = Linea.Split(":")(1)
                If Contacto.ContainsKey(Key) Then Contacto(Key) = String.Join(" ", Value.Split(";")).Trim
            Next
        End Sub
    End Class
End Namespace