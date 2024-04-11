Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates

Namespace Certificados
    Public Class Instalar

        ' Ruta del archivo .pfx
        Public rutaCertificado As String = String.Empty

        ' Contraseña del archivo .pfx (si la tiene)
        Dim contraseñaCertificado As String = ""

        ' Crear un objeto X509Store para el almacén "Personal"
        Dim Almacen As X509Store = New X509Store(StoreName.My, StoreLocation.LocalMachine)

        Public Sub Instalar(Antiguo As X509Certificate2)

            ' Abrir el almacén
            Almacen.Open(OpenFlags.ReadWrite)

            'Elimina el antiguo
            If Not IsNothing(Antiguo) Then Almacen.Remove(Antiguo)

            ' Importar el Nuevo
            Dim CertProcess As New Process
            With CertProcess
                With .StartInfo
                    .FileName = "certutil"
                    .Arguments = $"-p """" -importpfx ""{rutaCertificado}"" NoExport"
                    .CreateNoWindow = True
                    .WindowStyle = ProcessWindowStyle.Hidden
                End With
                .Start()
                .WaitForExit()
            End With
            'Almacen.Add(New X509Certificate2(rutaCertificado, contraseñaCertificado))

            ' Cerrar el almacén
            Almacen.Close()

            'Libera el Almacen
            Almacen.Dispose()
        End Sub
    End Class
End Namespace