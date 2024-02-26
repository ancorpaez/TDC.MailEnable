Imports System.IO
Imports System.Net.WebRequestMethods
Imports System.Threading.Tasks

Namespace Backup
    Public Class Cls_IndexMailScan
        Public Event AnalizarArchivo(FullName As String)

        Public Async Function EscanerCarpeta(Carpeta As String) As Task
            Try
                'Obtener SubDirectorios
                Dim Directorios As String() = Directory.GetDirectories(Carpeta)

                ' Recorrer carpetas de forma asíncrona
                For Each Directorio As String In Directorios
                    Await EscanerCarpeta(Directorio)
                Next

                ' Obtener archivos del directorio actual
                Dim Archivos As String() = Directory.GetFiles(Carpeta, "*.MAI")

                ' Invocar evento para cada archivo encontrado
                For Each Archivo As String In Archivos
                    If Not IO.File.Exists(OriginalPath(Archivo)) AndAlso Not Indexacion.Contains(Core.BDD.MailBackupIndex.Columnas.Archivo.ToString, Archivo) Then RaiseEvent AnalizarArchivo(Archivo)
                Next
            Catch ex As Exception
                ' Manejar excepciones si es necesario
                Console.WriteLine($"Error al escanear directorio {Carpeta}: {ex.Message}")
            End Try
        End Function

        Private Function OriginalPath(Archivo As String) As String
            Return Archivo.Replace(MailEnableLog.Configuracion.CARPETA_BACKUP, MailEnableLog.Configuracion.POST_OFFICES)
        End Function
    End Class
End Namespace