Imports TDC.MailEnable.Core
Imports TDC.MailEnable.Core.Bucle
Imports TDC.MailEnable.IpBan.MailEnableLog
Namespace AutoResponder
    Module Core
        Private WithEvents AutoResponderRepair As New Bucle.DoBucle("AutoResponder") With {.Intervalo = DateDiff(DateInterval.Second, Now, Now.AddMinutes(1)) * 1000}
        Private Modificados As New Collections.Concurrent.ConcurrentBag(Of String)
        Private QueneFolder As IO.DirectoryInfo

        Public Sub Main()
            AutoResponderRepair.Iniciar()
        End Sub

        Private Sub AutoResponderRepair_BackGround(Sender As Object, e As BackgroundEventArgs) Handles AutoResponderRepair.BackGround
            If Not String.IsNullOrEmpty(Configuracion.AUTORESPONDER) Then
                If IO.Directory.Exists(Configuracion.AUTORESPONDER) Then
                    If IsNothing(QueneFolder) Then QueneFolder = New IO.DirectoryInfo(Configuracion.AUTORESPONDER)
                    For Each Email In QueneFolder.GetFiles("*.MAI")
                            If IO.File.Exists($"{QueneFolder.Parent.FullName}\{Email.Name}") AndAlso Not Modificados.Contains(Email.Name) Then
                                Dim Lineas() As String = IO.File.ReadAllLines(Email.FullName)
                                IO.File.WriteAllText(Email.FullName, String.Join(vbCrLf, Lineas) & vbCrLf)
                                Modificados.Add(Email.Name)
                            End If
                        Next
                    End If
            End If
        End Sub
    End Module
End Namespace