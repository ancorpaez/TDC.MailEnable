Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading

Namespace ENAT
    Module Core
        Private ENATS As New Concurrent.ConcurrentDictionary(Of String, ENATIP)
        Public Property Tarjeta As String = String.Empty
        Public IpProtegidas As New Concurrent.ConcurrentBag(Of IPAddress)
        Private SyncCrear, SyncEliminar As New Object
        Private WaitCrear As New ManualResetEvent(True)

        Public Function Existe(Ip As String) As Boolean
            WaitCrear.WaitOne()
            Return ENATS.ContainsKey(Ip)
        End Function
        Public Function Crear(Ip As String) As Boolean
            SyncLock SyncCrear
                WaitCrear.Reset()
                If String.IsNullOrEmpty(Tarjeta) Then Throw New ArgumentException("No se ha especificado la Tarjeta")
                Dim CrearENAT As New ENATIP(Ip, Tarjeta)
                If IsNothing(CrearENAT.Tarjeta) OrElse CrearENAT.Ip.ToString = IPAddress.Any.ToString Then
                    WaitCrear.Set()
                    Return False
                End If
                If ENATS.TryAdd(Ip, CrearENAT) Then
                    WaitCrear.Set()
                    Return CrearENAT.Crear
                End If
                WaitCrear.Set()
                Return False
            End SyncLock
        End Function
        Public Function Eliminar(Ip As String) As Boolean
            SyncLock SyncEliminar
                If String.IsNullOrEmpty(Tarjeta) Then Throw New ArgumentException("No se ha especificado la Tarjeta")
                If ENATS.ContainsKey(Ip) Then
                    Dim EliminarEnat As ENATIP = ENATS(Ip)
                    If EliminarEnat.Eliminar AndAlso ENATS.TryRemove(Ip, EliminarEnat) Then
                        Return True
                    End If
                End If
                Return False
            End SyncLock
        End Function
        Public Function Clear() As Boolean
            Dim unicastIPs As UnicastIPAddressInformationCollection
            Try
                If ENATS.Count > 0 Then Throw New ArgumentException("Implosible Limpiar cuando se está usando")
                If String.IsNullOrEmpty(Tarjeta) Then Throw New ArgumentException("No se ha especificado la Tarjeta")
                If IpProtegidas.Count = 0 Then Throw New ArgumentException("No se han espcificado Ip Protegidas.")
                Dim tRed As NetworkInterface = ENATIP.ObtenerTarjeta(Tarjeta)
                Dim ipProperties As IPInterfaceProperties = tRed.GetIPProperties()
                unicastIPs = ipProperties.UnicastAddresses
            Catch ex As Exception
                unicastIPs = Nothing
            End Try

            If Not IsNothing(unicastIPs) Then
                For Each Ip In unicastIPs
                    Try
                        If Ip.Address.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                            If Not IpProtegidas.Contains(Ip.Address) Then
                                Dim LimpiarENAT As New ENATIP(Ip.Address.ToString, Tarjeta)
                                If Not IsNothing(LimpiarENAT) Then
                                    If LimpiarENAT.Eliminar Then
                                        Continue For
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        Return False
                    End Try
                Next
            End If
            If IsNothing(unicastIPs) Then Throw New ArgumentException("No se pudo obtener la direcciones Ip de la Tarjeta.")
            Return True
        End Function

    End Module
End Namespace