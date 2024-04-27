Imports System.IO
Imports System.Net.WebRequestMethods
Imports System.Threading.Tasks

Namespace Backup
    Public Class Cls_IndexMailScan
        Public Event AnalizarArchivo(FullName As String)
        Public Event NuevaCarpeta(FullDirectory As String)

        Public Async Function ObtenerCarpetas(Carpeta As String) As Task
            Dim Carpetas As String() = Directory.GetDirectories(Carpeta)
            For Each C As String In Carpetas
                RaiseEvent NuevaCarpeta(C)
                Await ObtenerCarpetas(C)
            Next
            Await Task.Delay(0)
        End Function
        Public Sub EscanerCarpeta(Carpeta As String) 'As Task
            Try
                'Obtener SubDirectorios
                Dim Directorios As String() = Directory.GetDirectories(Carpeta)

                ' Recorrer carpetas de forma asíncrona
                'For Each Directorio As String In Directorios
                '    Await EscanerCarpeta(Directorio)
                'Next

                ' Obtener archivos del directorio actual
                Dim ArchivosMAI As String() = Directory.GetFiles(Carpeta, "*.MAI")
                For Each Archivo As String In ArchivosMAI
                    If Not IO.File.Exists(OriginalPath(Archivo)) Then RaiseEvent AnalizarArchivo(Archivo)
                Next

                Dim ArchivosVCF As String() = Directory.GetFiles(Carpeta, "*.VCF")
                For Each Archivo As String In ArchivosVCF
                    If Not IO.File.Exists(OriginalPath(Archivo)) Then RaiseEvent AnalizarArchivo(Archivo)
                Next

                Dim ArchivosTSK As String() = Directory.GetFiles(Carpeta, "*.TSK")
                For Each Archivo As String In ArchivosTSK
                    If Not IO.File.Exists(OriginalPath(Archivo)) Then RaiseEvent AnalizarArchivo(Archivo)
                Next

                Dim ArchivosCAL As String() = Directory.GetFiles(Carpeta, "*.CAL")
                For Each Archivo As String In ArchivosCAL
                    If Not IO.File.Exists(OriginalPath(Archivo)) Then RaiseEvent AnalizarArchivo(Archivo)
                Next

            Catch ex As Exception
                ' Manejar excepciones si es necesario
                Console.WriteLine($"Error al escanear directorio {Carpeta}: {ex.Message}")
            End Try
        End Sub

        Private Function OriginalPath(Archivo As String) As String
            Return Archivo.Replace(MailEnableLog.Configuracion.CARPETA_BACKUP, MailEnableLog.Configuracion.POST_OFFICES)
        End Function
    End Class
End Namespace