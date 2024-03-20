Imports System.Collections.Concurrent

Namespace RegistroDeArchivos
    Module Core
        Public ReadOnly CoincidenciasPais As New Collections.Concurrent.ConcurrentDictionary(Of String, Concurrent.ConcurrentDictionary(Of FilterKeys.FilterKey, Integer))

        Public ReadOnly Property ExclusionPais As New List(Of String) From {"ES", "ERR"}
        Public Sub EstablecerConcidenciasPais(Filtro As FilterKeys.FilterKey, Pais As String, Coincidencias As Integer)
            If Not CoincidenciasPais.ContainsKey(Pais) Then CoincidenciasPais.TryAdd(Pais, New ConcurrentDictionary(Of FilterKeys.FilterKey, Integer))
            If Not CoincidenciasPais(Pais).ContainsKey(Filtro) Then CoincidenciasPais(Pais).TryAdd(Filtro, Coincidencias)
        End Sub
    End Module
End Namespace