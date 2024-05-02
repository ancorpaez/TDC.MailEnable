Imports System.Text
Imports System.Net.Mail
Imports System.Text.RegularExpressions

Namespace Backup
    Public Class Calendar
        Private Contacto As New Concurrent.ConcurrentDictionary(Of String, String)
        Private Keys As New List(Of String) From {
            "Subject:",
            "X-Location:",
            "X-StartTime:",
            "X-FinishTime:"}
        Private Lineas() As String

        Public Archivo As String = String.Empty
        Public Nombre As String = " "
        Public NombreCompleto As String = " "
        Public Email As String = " "
        Public EmailTrabajo As String = " "
        Public EmailPersonal As String = " "
        Public Nick As String = " "
        Public Sub New(FileFullName As String)
            Archivo = FileFullName
            For Each key In Keys
                Contacto.TryAdd(key, " ")
            Next
            If IO.File.Exists(FileFullName) Then Lineas = IO.File.ReadAllLines(FileFullName)
        End Sub

        Public Sub Analizar()
            For Each Linea In Lineas
                Dim Key As String = Linea.Split(":")(0)
                Dim EncodingKey As String = Linea.Split("=")(0)
                Dim Value As String = Linea.Split(":")(1)
                If Contacto.ContainsKey(Key) Then Contacto(Key) = String.Join(" ", Value.Split(";")).Trim
                If Contacto.ContainsKey(EncodingKey) Then
                    Select Case EncodingKey
                        Case "FN;ENCODING", "N;ENCODING"
                            If Key.StartsWith("N") Then
                                Contacto("N") = String.Join(" ", DecodeHex(ExtraerNombreQuotedPrintable(Linea)).Split(";")).Trim
                            ElseIf Key.StartsWith("FN") Then
                                Contacto("FN") = DecodeHex(ExtraerNombreQuotedPrintable(Linea))
                            End If
                        Case "N:"
                            Contacto("N") = ExtraerYDecodificarNombre(Linea)
                    End Select
                End If
            Next
            Nombre = Contacto("N")
            NombreCompleto = Contacto("FN")
            Email = Contacto("EMAIL;PREF;INTERNET")
            EmailTrabajo = Contacto("EMAIL;WORK;INTERNET")
            EmailPersonal = Contacto("EMAIL;OTHER;INTERNET")
            Nick = Contacto("NICKNAME")
        End Sub

        Private Function ExtraerNombreQuotedPrintable(texto As String) As String
            ' Buscar el inicio de la cadena de nombre, asumiendo que siempre comienza después de "UTF-8:"
            Dim inicioNombre As Integer = texto.IndexOf("UTF-8:") + "UTF-8:".Length
            If inicioNombre = -1 + "UTF-8:".Length Then
                Return "Formato de texto no reconocido"
            End If

            ' Extraer la cadena codificada
            Dim nombreCodificado As String = texto.Substring(inicioNombre).Trim()

            ' Decodificar de Quoted-Printable a bytes
            Dim bytesDecodificados As Byte() = DecodificarQuotedPrintableENCODING(nombreCodificado)

            ' Convertir bytes a string usando UTF-8
            Return Encoding.UTF8.GetString(bytesDecodificados)
        End Function

        Private Function DecodificarQuotedPrintableENCODING(input As String) As Byte()
            ' Utilizar Attachment para hacer la decodificación Quoted-Printable
            Using client As New SmtpClient() ' Se necesita solo para acceder a ciertos métodos
                Dim data As New Attachment(New System.IO.MemoryStream(Encoding.ASCII.GetBytes(input)), "dummy")
                Dim stream As System.IO.Stream = data.ContentStream
                Dim buffer As New List(Of Byte)
                Dim b As Integer = stream.ReadByte()
                While b <> -1
                    buffer.Add(CByte(b))
                    b = stream.ReadByte()
                End While
                Return buffer.ToArray()
            End Using
        End Function
        Private Function DecodeHex(input As String) As String
            ' Reemplazar "_" con " " y decodificar secuencias de escape
            Dim Convertir As String = input
            Convertir = Regex.Replace(Convertir, "=\r\n", "", RegexOptions.Multiline)
            Convertir = Regex.Replace(Convertir, "_=", " ", RegexOptions.Multiline)
            Convertir = Regex.Replace(Convertir, "=", "%")

            ' Decodificar el texto
            Dim Testear As String = System.Web.HttpUtility.UrlDecode(Convertir)
            If Not Testear.Contains("�") Then Return Testear
            Return input
        End Function

        Function ExtraerYDecodificarNombre(texto As String) As String
            ' Regex para encontrar partes codificadas según el formato MIME Encoded-Word
            Dim pattern As String = "=\?UTF-8\?Q\?(.*?)\?="
            Dim decodedFullName As New StringBuilder()

            ' Extraemos los componentes del nombre, separados por ";" en tu ejemplo
            Dim partes As String() = texto.Split(";"c)
            For Each parte As String In partes
                ' Verificar si la parte está codificada
                If Regex.IsMatch(parte, pattern) Then
                    ' Extraer la parte codificada y decodificarla
                    Dim match As Match = Regex.Match(parte, pattern)
                    Dim encodedPart As String = match.Groups(1).Value.Replace("_", " ") ' Reemplazar guiones bajos por espacios
                    Dim decodedBytes As Byte() = DecodificarQuotedPrintableQ(encodedPart)
                    Dim decodedPart As String = Encoding.UTF8.GetString(decodedBytes)
                    decodedFullName.Append(decodedPart)
                Else
                    ' Si no está codificada, simplemente añadirla
                    decodedFullName.Append(parte)
                End If
                decodedFullName.Append(" ") ' Agregar espacio entre partes del nombre
            Next

            Return decodedFullName.ToString().Trim()
        End Function

        Function DecodificarQuotedPrintableQ(input As String) As Byte()
            Dim output As New List(Of Byte)()
            Dim i As Integer = 0

            While i < input.Length
                If input(i) = "=" And i + 2 < input.Length Then
                    Dim hex As String = input.Substring(i + 1, 2)
                    output.Add(Convert.ToByte(hex, 16))
                    i += 3
                Else
                    output.Add(Convert.ToByte(input(i)))
                    i += 1
                End If
            End While

            Return output.ToArray()
        End Function

    End Class
End Namespace