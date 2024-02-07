Imports System.IO
Imports System.Threading
Imports Microsoft.VisualBasic.Logging
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
        Public Filtros As New List(Of Tuple(Of Integer, Integer, List(Of FiltroLectura)))
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
            Try
                Lineas = IO.File.ReadAllLines(Archivo)
            Catch ex As Exception

            End Try

            Try
                If Lineas.Count = 0 Then
                    Using Bloqueado As StreamReader = New IO.StreamReader(IO.File.Open(Archivo, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite))
                        Dim Linea As String = Bloqueado.ReadLine
                        Dim lLineas As New List(Of String)
                        Do While Not String.IsNullOrEmpty(Linea)
                            lLineas.Add(Linea)
                            Linea = Bloqueado.ReadLine
                        Loop
                        Lineas = lLineas.ToArray
                    End Using
                End If
            Catch ex As Exception

            End Try
            Lector.Intervalo = 10
        End Sub

        Private Sub Lector_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Lector.IBucle_Bucle
            If IndexLinea < Lineas.Count Then
                If Not IsNothing(Filtros) Then
                    'Si coincide cualquiera de los Filtros almacenados.
                    If Filtros.Any(Function(Filtro) VerificarFiltro(Filtro, Lineas(IndexLinea))) Then
                        'Solicitar la IP al Nucleo central
                        Dim Ip As String = ObtenerIp(Lineas(IndexLinea))
                        If Ip <> "0.0.0.0" Then
                            Try
                                'Testear que es una IPV4 Real, Si no es IPV4 desecha las comprobaciones
                                Ip = Net.IPAddress.Parse(Ip).ToString
                                If Net.IPAddress.Parse(Ip).AddressFamily = Net.Sockets.AddressFamily.InterNetworkV6 Then Ip = ""
                            Catch ex As Exception
                                Ip = ""
                            End Try
                        Else
                            Ip = ""
                        End If

                        'Geolocalizar  la IP
                        If Ip <> "" Then
                            Dim Geolocalizar As New IpInfo
                            Dim Pais As String = Geolocalizar.Geolocalizar(Ip, Mod_Core.Geolocalizador)
                            Dim GeolocalizarID As Integer = 0
                            If Pais = "ES" OrElse Pais = "ERR" Then GeolocalizarID = 1

                            'Banear la IP (Evita Bloquear Ip[ES][ERR]) Comprueba la Bandera (GeolocalizarID, 0(Bloquea) o 1(No bloquea))
                            If GeolocalizarID = 0 Then If Not FiltroIp.Contains(Ip) Then FiltroIp.Add(Ip)
                        End If
                    End If

                End If

                'Avanza en el conteo de lineas procesadas
                IndexLinea += 1

                'Informa en el avance de lectura
                RaiseEvent Progreso(IndexLinea, Lineas.Count)
            Else
                Lector.Detener()
                Bloqueo.Set()
            End If
        End Sub
        Private Function VerificarFiltro(Filtro As Tuple(Of Integer, Integer, List(Of FiltroLectura)), Linea As String) As Boolean
            Dim TipoComparacion As EnumTipoComparacion = Filtro.Item1
            Dim NumeroCoincidentes As Integer = Filtro.Item2
            Dim Comparaciones As List(Of FiltroLectura) = Filtro.Item3
            Dim Coincide As Boolean
            Select Case TipoComparacion
                Case EnumTipoComparacion.Todo
                    Coincide = True
                    For Each Comparador In Comparaciones
                        Select Case Comparador.Condicion
                            Case FiltroLectura.EnumCondicion.Contiene
                                If Not Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = False
                            Case FiltroLectura.EnumCondicion.NoContiene
                                If Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = False
                        End Select
                    Next

                Case EnumTipoComparacion.Cualquiera
                    Coincide = False
                    For Each Comparador In Comparaciones
                        Select Case Comparador.Condicion
                            Case FiltroLectura.EnumCondicion.Contiene
                                If Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = True
                            Case FiltroLectura.EnumCondicion.NoContiene
                                If Not Linea.ToLower.Contains(Comparador.Filtro.ToLower) Then Coincide = True
                        End Select
                    Next
            End Select

            If Coincide Then
                If NumeroCoincidentes > 0 Then
                    Dim oIp As String = ObtenerIp(Linea)
                    If Not Me.Coincidentes.ContainsKey(oIp) Then Me.Coincidentes.TryAdd(oIp, 1) Else Me.Coincidentes.TryUpdate(oIp, Me.Coincidentes(oIp) + 1, Me.Coincidentes(oIp))
                    If Me.Coincidentes(oIp) > NumeroCoincidentes Then Coincide = True Else Coincide = False
                End If
            End If

            Return Coincide
        End Function

        Public Sub Escanear()
            Lector.Inicia()
            Bloqueo.WaitOne()
        End Sub
    End Class
End Namespace