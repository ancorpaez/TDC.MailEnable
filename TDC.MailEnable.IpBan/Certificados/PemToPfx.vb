Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows

Namespace Certificados
    Public Class PemToPfx
        Private Command As String = "openssl"
        Private Arguments As String = String.Empty
        Public PemOriginalPath As IO.FileInfo
        Public PemFile As IO.FileInfo
        Public PfxFile As IO.FileInfo
        Private WithEvents OpenSsl As Process
        Private sOutput As String = ""
        Private sInput As StreamWriter

        Public Event AlConvertirPem(sender As Object, File As PemExportEvent)
        Public Sub Convert(Pem As String)
            If IO.File.Exists(Pem) Then
                'Recoger de la Descarga
                PemOriginalPath = New IO.FileInfo(Pem)
                'Asignar destino
                PemFile = New IO.FileInfo(CarpetaCertificadosDescargados.FullName & "\" & PemOriginalPath.Name)
                'Eliminar anterior
                If PemFile.Exists Then PemFile.Delete()
                'Mover archivo
                IO.File.Move(PemOriginalPath.FullName, PemFile.FullName)
                'Crear Exportacion Pfx
                PfxFile = New IO.FileInfo(PemFile.FullName.Replace(PemFile.Extension, ".pfx"))
            End If
            'Actualizar parametros
            Arguments = $" pkcs12 -export -in ""{PemFile.FullName}"" -inkey ""{PemFile.FullName}"" -out ""{PfxFile.FullName}"" -passout pass:"""""
            'Lanzar OpenSsl
            OpenSsl = New Process
            With OpenSsl
                With .StartInfo
                    .FileName = Command
                    .Arguments = Arguments
                    .CreateNoWindow = True
                    .UseShellExecute = False
                    .WindowStyle = ProcessWindowStyle.Hidden
                End With
                .Start()
                .WaitForExit()
            End With
            'Actualizar puntero Pfx
            PfxFile.Refresh()
            If PfxFile.Exists Then RaiseEvent AlConvertirPem(Me, New PemExportEvent With {.Path = PfxFile.FullName})
        End Sub

        Public Class PemExportEvent
            Inherits EventArgs
            Public Path As String
        End Class
    End Class
End Namespace