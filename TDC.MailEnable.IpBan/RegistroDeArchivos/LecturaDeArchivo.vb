Imports System.IO
Imports System.Threading
Imports TDC.MailEnable.Core
Imports TDC.MailEnable.Core.GeoLocalizacion
Imports TDC.MailEnable.IpBan.MailEnableLog

Namespace RegistroDeArchivos
    Public Class LecturaDeArchivo
        Private WithEvents Lector As New Bucle.Bucle
        Private IndexLinea As Integer = 0
        'Filtros.Add(New Tuple(Of Integer, List(Of String))(EnumTipoComparacion.Cualquiera, New List(Of String) From {"Uno", "Dos"}))
        ''' <summary>
        ''' Integer, Tipo de comparacion (Cualquier coincidencia del List, Todo el List)
        ''' Integer, Numero de Concidencias por IP
        ''' List, Comparaciones del Filtro
        ''' </summary>
        Public Filtros As New List(Of Tuple(Of Integer, Integer, List(Of String)))
        Public Property ObtenerIp As Func(Of String, String)

        Private Coincidentes As New Collections.Concurrent.ConcurrentDictionary(Of String, Integer)

        Private Lineas As String() = {}
        Private Bloqueo As New ManualResetEvent(False)
        Public FiltroIp As New Concurrent.ConcurrentBindingList(Of String)
        Public Event Progreso(Index, Total)
        Public Enum EnumTipoComparacion
            Cualquiera
            Todo
        End Enum

        Public Sub New(Archivo As String)
            Lineas = IO.File.ReadAllLines(Archivo)
            'Try
            '    Using fs As New FileStream(Archivo, FileMode.Open, FileAccess.Read)
            '        Using reader As New StreamReader(fs)
            '            ' Lee el archivo línea por línea hasta el final del archivo
            '            Do While Not reader.EndOfStream
            '                Dim linea As String = reader.ReadLine()
            '                Lineas.Append(linea)
            '            Loop
            '        End Using
            '    End Using
            'Catch ex As Exception
            '    Console.WriteLine("Error al leer el archivo: " & ex.Message)
            'End Try
            Lector.Intervalo = 10
        End Sub

        Private Sub Lector_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Lector.IBucle_Bucle
            If IndexLinea < Lineas.Count Then
                'Si coincide cualquiera de los Filtros almacenados.
                If Filtros.Any(Function(Filtro) VerificarFiltro(Filtro, Lineas(IndexLinea))) Then
                    'Solicitar la IP al Nucleo central
                    Dim Ip As String = ObtenerIp(Lineas(IndexLinea))
                    'RaiseEvent FiltrarLinea(Lineas(IndexLinea), Ip)

                    Try
                        'Testear que es una IPV4 Real
                        Ip = Net.IPAddress.Parse(Ip).ToString
                        If Net.IPAddress.Parse(Ip).AddressFamily = Net.Sockets.AddressFamily.InterNetworkV6 Then Ip = ""
                    Catch ex As Exception
                        Ip = ""
                    End Try

                    'Geolocalizar  la IP
                    Dim Geolocalizar As New IpInfo
                    Dim Pais As String = Geolocalizar.Geolocalizar(Ip, Mod_Core.Geolocalizador)
                    Dim GeolocalizarID As Integer = 0
                    If Pais = "ES" OrElse Pais = "ERR" Then GeolocalizarID = 1

                    'Banear la IP (Evita Bloquear Ip[ES][ERR])
                    If Ip <> "" AndAlso Not FiltroIp.Contains(Ip) AndAlso GeolocalizarID = 0 Then FiltroIp.Add(Ip)
                    End If
                    IndexLinea += 1
                RaiseEvent Progreso(IndexLinea, Lineas.Count)
            Else
                Lector.Detener()
                Bloqueo.Set()
            End If
        End Sub
        Private Function VerificarFiltro(Filtro As Tuple(Of Integer, Integer, List(Of String)), Linea As String) As Boolean
            Dim TipoComparacion As EnumTipoComparacion = Filtro.Item1
            Dim NumeroCoincidentes As Integer = Filtro.Item2
            Dim Comparaciones As List(Of String) = Filtro.Item3

            Select Case TipoComparacion
                Case EnumTipoComparacion.Cualquiera

                    'Si no hay limite de coincidencias
                    If NumeroCoincidentes = 0 Then Return Comparaciones.Any(Function(Flt) Linea.Contains(Flt))

                    'Si hay limite de coincidencas
                    If NumeroCoincidentes > 0 Then
                        If Comparaciones.Any(Function(Flt) Linea.Contains(Flt)) Then
                            'Si hay coincidencia
                            Dim oIp As String = ObtenerIp(Linea)
                            If Not Coincidentes.ContainsKey(oIp) Then
                                'Si es la primera coincidencia
                                Coincidentes.TryAdd(oIp, 1)
                            Else
                                'Sumamos si hay mas coincidencias
                                Coincidentes.TryUpdate(oIp, Coincidentes(oIp) + 1, Coincidentes(oIp))
                            End If

                            'Retornar valor segun nivel de coincidencias
                            If Coincidentes(oIp) >= NumeroCoincidentes Then Return True Else Return False
                        Else
                            'Si no coincide el Filtro
                            Return False
                        End If
                    End If

                    'Si no se solicita comprobar la linea anterior
                    'If Not Filtro.Item2 Then Return Filtro.Item3.Any(Function(Flt) Linea.Contains(Flt))

                    ''Si se solicita contrastar el filtro con la linea anterior
                    'If Filtro.Item3.Any(Function(Flt) Anterior.Contains(Flt)) Then
                    '    'Si concide el filtro con la linea anterior
                    '    Return Filtro.Item3.Any(Function(Flt) Linea.Contains(Flt))
                    'Else
                    '    'Si no coincide el filtro con la linea anterior
                    '    Return False
                    'End If

                Case EnumTipoComparacion.Todo
                    'Si no hay limite de coincidencias
                    If NumeroCoincidentes = 0 Then Return Comparaciones.All(Function(Flt) Linea.Contains(Flt))

                    'Si hay limite de coincidencas
                    If NumeroCoincidentes > 0 Then
                        If Comparaciones.All(Function(Flt) Linea.Contains(Flt)) Then
                            Dim oIp As String = ObtenerIp(Linea)
                            If Not Coincidentes.ContainsKey(oIp) Then
                                'Si es la primera coincidencia
                                Coincidentes.TryAdd(oIp, 1)
                            Else
                                'Sumamos si hay mas coincidencias
                                Coincidentes.TryUpdate(oIp, Coincidentes(oIp) + 1, Coincidentes(oIp))
                            End If

                            'Retornar valor segun nivel de coincidencias
                            If Coincidentes(oIp) = NumeroCoincidentes Then Return True Else Return False
                        Else
                            Return False
                        End If
                    End If
                    'Si se solicita contrastar el filtro con la linea anterior
                    'If Filtro.Item3.All(Function(Flt) Anterior.Contains(Flt)) Then
                    '    Return Filtro.Item3.All(Function(Flt) Linea.Contains(Flt))
                    'Else
                    '    'Si no coincide el filtro con la linea anterior
                    '    Return False
                    'End If
            End Select
            Return False
        End Function
        Public Sub Escanear()
            Lector.Inicia()
            Bloqueo.WaitOne()
        End Sub
    End Class
End Namespace