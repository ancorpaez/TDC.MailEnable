Imports System.ComponentModel
Imports Microsoft.Win32
Namespace MailEnableLog
    Public Class Cls_ArranqueWindows
#Region "AutoConfigurador"

        Public ReadOnly DisplayName As String = "Windows (Opciones Generales)"
        Public ReadOnly Description As String = "Acceso a las opciones generales del Cliente"

        <DisplayName("Arranque,Arranque en el inicio")>
        <Description("Habilita el arranque del programa en el Inicio de Windows.")>
        Public Property ArranqueWindows As Boolean
            Get
                Return ArranqueWindowsGetSet
            End Get
            Set(value As Boolean)
                ArranqueWindowsGetSet = value
                Select Case value
                    Case True
                        GenererarTareaArranqueWindows()
                    Case False
                        EliminarTareaArranqueWindows()
                End Select
            End Set
        End Property
        Private ArranqueWindowsGetSet As Boolean = True
#End Region

        Public KeyUser As RegistryKey
        Private KeySOFTWARE As RegistryKey
        Private KeyMicrosoft As RegistryKey
        Private KeyWindows As RegistryKey
        Private KeyCurrentVersion As RegistryKey
        Public KeyRun As RegistryKey

        Public Sub New()
        End Sub

        Public Sub Inicializar()
            Try
                KeyUser = My.Computer.Registry.CurrentUser
                If Not IsNothing(KeyUser) Then KeySOFTWARE = KeyUser.OpenSubKey("SOFTWARE")
                If Not IsNothing(KeySOFTWARE) Then KeyMicrosoft = KeySOFTWARE.OpenSubKey("Microsoft")
                If Not IsNothing(KeyMicrosoft) Then KeyWindows = KeyMicrosoft.OpenSubKey("Windows")
                If Not IsNothing(KeyWindows) Then KeyCurrentVersion = KeyWindows.OpenSubKey("CurrentVersion")
                If Not IsNothing(KeyCurrentVersion) Then KeyRun = KeyCurrentVersion.OpenSubKey("Run", True)
                'Para asegurarnos de que Windows apunta correctamente al Programa
                'Ya sea por actualizaciones de ClickOnce
                'U otros elementos
                If ArranqueWindows Then
                    EliminarTareaArranqueWindows()
                    GenererarTareaArranqueWindows()
                End If

            Catch ex As Exception
            End Try
        End Sub

        Public Sub GenererarTareaArranqueWindows()
            With Me
                If Not IsNothing(.KeyRun) Then
                    .KeyRun.SetValue("TdcanMailEnableImap", My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".exe")
                End If
            End With
        End Sub

        Public Sub EliminarTareaArranqueWindows()
            With Me
                If Not IsNothing(.KeyRun) Then
                    Try
                        If Not IsNothing(.KeyRun.GetValue("TdcanMailEnableImap")) Then
                            .KeyRun.DeleteValue("TdcanMailEnableImap", True)
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End With
        End Sub

    End Class
End Namespace