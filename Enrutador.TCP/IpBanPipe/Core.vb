Imports TDC.MailEnable.Core
Imports System.Threading
Namespace IpBanPipe
    Module Core
        Private IpBaneadas As Concurrent.ConcurrentBindingList(Of String) = Nothing
        Private WithEvents IpBaneadasPipe As Pipe.ClientPipe
        Private WaitPipe As New ManualResetEvent(False)
        Private SyncContains As New Object

        Public Enum EnumEstadoIpBanPipe
            Esperando
            Iniciando
            Iniciada
            Actualizando
            [Error]
        End Enum
        Public Property Estado As EnumEstadoIpBanPipe = EnumEstadoIpBanPipe.Iniciando

        Public ReadOnly Property Pipe As Pipe.ClientPipe
            Get
                Return IpBaneadasPipe
            End Get
        End Property

        Public Sub Main()
            IpBaneadasPipe = New Pipe.ClientPipe
        End Sub
        Public Function Contains(Ip As String) As Boolean
            SyncLock SyncContains
                If Estado = EnumEstadoIpBanPipe.Iniciada OrElse Estado = EnumEstadoIpBanPipe.Esperando Then Return IpBaneadas.Contains(Ip)
                If Estado = EnumEstadoIpBanPipe.Error OrElse Estado = EnumEstadoIpBanPipe.Iniciando Then Return False
                If Estado = EnumEstadoIpBanPipe.Actualizando Then
                    WaitPipe.WaitOne()
                    Return IpBaneadas.Contains(Ip)
                End If
                Return False
            End SyncLock
        End Function
        Private Sub IpBaneadasPipe_AlObtenerLaLista(Lista As List(Of String)) Handles IpBaneadasPipe.AlObtenerLaLista
            'Inicalizar Variable
            If IsNothing(IpBaneadas) Then
                Estado = EnumEstadoIpBanPipe.Iniciando
                IpBaneadas = New Concurrent.ConcurrentBindingList(Of String)
            Else
                WaitPipe.Reset()
                Estado = EnumEstadoIpBanPipe.Actualizando
            End If

            'Actualizar Variable
            Try
                'Actualizar la lista
                For Each Ip In Lista
                    If Not IpBaneadas.Contains(Ip) Then IpBaneadas.Add(Ip)
                Next

                'Buscar Eliminaciones en caliente
                Dim NoCoincidentes As New List(Of String)
                For Each Ip In IpBaneadas
                    If Not Lista.Contains(Ip) Then
                        NoCoincidentes.Add(Ip)
                    End If
                Next

                'Eliminar Ip no Baneadas en Caliente
                If NoCoincidentes.Count > 0 Then
                    For Each Ip In NoCoincidentes
                        IpBaneadas.Remove(Ip)
                    Next
                End If

                Estado = EnumEstadoIpBanPipe.Iniciada
            Catch ex As Exception
                Estado = EnumEstadoIpBanPipe.Error
                IpBaneadas = Nothing
            End Try
            WaitPipe.Set()
        End Sub
    End Module
End Namespace