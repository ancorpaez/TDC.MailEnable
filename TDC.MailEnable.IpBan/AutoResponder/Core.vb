﻿Imports TDC.MailEnable.Core
Imports TDC.MailEnable.Core.Bucle
Imports TDC.MailEnable.IpBan.Backup
Imports TDC.MailEnable.IpBan.MailEnableLog
Namespace AutoResponder
    Module Core
        Private WithEvents AutoResponderRepair As New Bucle.DoBucle("AutoResponder") With {.Intervalo = DateDiff(DateInterval.Second, Now, Now.AddMinutes(1)) * 1000}
        Public ReadOnly Property Modificados As New Collections.Concurrent.ConcurrentBag(Of String)
        Public ReadOnly Property Mensajes As New Collections.Concurrent.ConcurrentDictionary(Of String, String)
        Public ReadOnly Property Estados As New Collections.Concurrent.ConcurrentDictionary(Of String, String)

        Private QueneFolder As IO.DirectoryInfo

        Public Sub Main()
            AutoResponderRepair.Iniciar()
        End Sub

        Private Sub AutoResponderRepair_BackGround(Sender As Object, e As BackgroundEventArgs) Handles AutoResponderRepair.BackGround
            If Not String.IsNullOrEmpty(Configuracion.AUTORESPONDER) Then
                If IO.Directory.Exists(Configuracion.AUTORESPONDER) Then
                    'Establecer Capeta Puntero
                    If IsNothing(QueneFolder) Then QueneFolder = New IO.DirectoryInfo(Configuracion.AUTORESPONDER)

                    'Buscar Mensajes
                    For Each Email In QueneFolder.GetFiles("*.MAI")

                        If Not Modificados.Contains(Email.Name) AndAlso ExistLog(Email) AndAlso isRetry(Email) Then
                            'Registrar Estado
                            Estados.TryAdd(Email.Name, IO.File.ReadAllText($"{QueneFolder.Parent.FullName}\{Email.Name}"))

                            'Modificar Mensaje
                            Dim Lineas() As String = IO.File.ReadAllLines(Email.FullName)
                            IO.File.WriteAllText(Email.FullName, String.Join(vbCrLf, Lineas) & vbCrLf)
                            Modificados.Add(Email.Name)

                            'Registrar Mensaje
                            Mensajes.TryAdd(Email.Name, IO.File.ReadAllText(Email.FullName))
                        End If
                    Next
                End If
            End If
        End Sub

        Private Function isRetry(Mensaje As IO.FileInfo) As Boolean
            Dim File As IO.FileInfo = LogFile(Mensaje)
            If IsNothing(File) Then Return False
            For Each Line In IO.File.ReadAllLines(LogFile(Mensaje).FullName)
                If Line.StartsWith("Retries") Then
                    Dim Intentos As Integer = Line.Split("=")(1)
                    If Intentos > 0 Then Return True
                End If
            Next
            Return False
        End Function

        Private Function ExistLog(Mensaje As IO.FileInfo) As Boolean
            Return IO.File.Exists($"{QueneFolder.Parent.FullName}\{Mensaje.Name}")
        End Function
        Private Function LogFile(Mensaje As IO.FileInfo) As IO.FileInfo
            If ExistLog(Mensaje) Then Return New IO.FileInfo($"{QueneFolder.Parent.FullName}\{Mensaje.Name}") Else Return Nothing
        End Function
    End Module
End Namespace