Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Net.Mail

Namespace Backup
    Public Class Email
        Public Archivo As String
        Public Lineas() As String
        Public Remitente As String = " "
        Public Destinatarios As String = " "
        Public ConCopia As String = " "
        Public Asunto As String = " "
        Public Fecha As DateTime = Now


        Private Coincidencias As New List(Of String) From {"Subject:", "From:", "To:", "CC:", "Sent:"}
        Private Banderas As New List(Of Boolean) From {False, False, False, False, False}

        Private Codificadores As New List(Of String) From {"?Q?", "?T?", "?B?", "?U?", "?C?"}

        Public Sub New(archivo As String)
            Me.Archivo = archivo
            Buscar()
        End Sub

        Private Sub Buscar()
            Lineas = IO.File.ReadAllLines(Archivo, System.Text.Encoding.Default)
            Dim Index As Integer = 0

            For Each Linea In Lineas
                If Coincidencias.Any(Function(Coincidencia) Linea.StartsWith(Coincidencia)) Then

                    'Subject
                    If Linea.StartsWith(Coincidencias(0)) AndAlso Not Banderas(0) Then
                        Dim eAsunto As String = BuscarAsunto(Index)
                        If Not String.IsNullOrEmpty(eAsunto) Then Asunto = eAsunto
                        Banderas(0) = True
                    End If

                    'From
                    If Linea.StartsWith(Coincidencias(1)) AndAlso Not Banderas(1) Then
                        Dim eRemitente As String = String.Empty
                        eRemitente = ExtraerEmail(Linea)
                        If Not String.IsNullOrEmpty(eRemitente) Then Remitente = eRemitente
                        Banderas(1) = True
                    End If

                    'To
                    If Linea.StartsWith(Coincidencias(2)) AndAlso Not Banderas(2) Then
                        Dim eContactos As List(Of String) = BuscarContactos(Index, Coincidencias(2))
                        If Not IsNothing(eContactos) Then Destinatarios = String.Join(";", eContactos)
                        Banderas(2) = True
                    End If

                    'CC
                    If Linea.StartsWith(Coincidencias(3)) AndAlso Not Banderas(3) Then
                        Dim eConCopia As List(Of String) = BuscarContactos(Index, Coincidencias(3))
                        If Not IsNothing(eConCopia) Then ConCopia = String.Join(";", eConCopia)
                        Banderas(3) = True
                    End If

                    'Sent
                    If Linea.StartsWith(Coincidencias(4)) AndAlso Not Banderas(4) Then
                        Dim PreliminarFecha As String = String.Empty
                        PreliminarFecha = ExtraerFecha(Linea)
                        If IsDate(PreliminarFecha) Then Fecha = Date.Parse(PreliminarFecha)
                        Banderas(4) = True
                    End If
                    If Banderas.All(Function(Bandera) Bandera) OrElse Index > 300 Then
                        Exit For
                    End If
                End If

                'Avanzamos 1
                Index += 1
            Next
        End Sub
        Private Function ExtraerFecha(contenido As String) As DateTime
            Dim match As Match = Regex.Match(contenido, "Sent: (.+?)(?:\r\n|$)")
            If match.Success Then
                Dim dateString As String = match.Groups(1).Value.Trim()
                Dim fecha As DateTime
                If DateTime.TryParse(dateString, fecha) Then
                    Return fecha
                End If
            End If
            Return DateTime.MinValue
        End Function

        Private Function ExtraerEmail(contenido As String) As String
            Dim Busqueda1 As Match = Regex.Match(contenido, "<([^>]*)>") 'Busca <buzon@email>
            If Busqueda1.Success Then Return Busqueda1.Groups(1).Value.Trim()
            Dim Busqueda2 As Match = Regex.Match(contenido, "(From|To|CC): (.+@.+\..+)") 'Busca buzon@email
            If Busqueda2.Success Then Return Busqueda2.Groups(2).Value.Trim()
            Dim Busqueda3 As Match = Regex.Match(contenido, "(\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\b)")
            If Busqueda3.Success Then Return Busqueda3.Groups(1).Value.Trim()
            Return Nothing
        End Function

        Private Function BuscarContactos(Index As Integer, Key As String) As List(Of String)
            Dim esLista As Boolean = False
            Dim laLista As New List(Of String)
            Dim Contiene As String = "@"
            Dim Empieza As String = Key
            For i = Index To Lineas.Count - 1

                If Lineas(i).StartsWith(Empieza) Then
                    'Comienza la Lista
                    esLista = True
                ElseIf esLista AndAlso Not Lineas(i).StartsWith(vbTab) Then
                    'Termina la lista
                    esLista = False
                End If

                If esLista AndAlso Lineas(i).Contains(Contiene) Then
                    Dim Buscar As String = ExtraerEmail(Lineas(i).Replace("""", ""))
                    If Not String.IsNullOrEmpty(Buscar) AndAlso Not laLista.Contains(Buscar) Then laLista.Add(Buscar)
                Else
                    If Not Lineas(i).StartsWith(vbTab) Then esLista = False
                End If
                'Terminamos la lista
                If Not esLista AndAlso laLista.Count > 0 Then Return laLista
            Next
            Return Nothing
        End Function
        Private Function BuscarAsunto(Index As Integer) As String
            Dim Partes1 As New List(Of String)
            Dim Partes2 As New List(Of String)
            Dim Extraido As Boolean = False
            Dim Trazar As Boolean = False

            For i = Index To Lineas.Count - 1
                If Lineas(i).StartsWith(Coincidencias(0)) Then
                    Partes1.Add(Lineas(i).Replace(Coincidencias(0), "").TrimStart)
                ElseIf Lineas(i).StartsWith(vbTab) Then
                    Partes1.Add(Lineas(i).Replace(vbTab, ""))
                ElseIf Lineas(i).StartsWith(" ") Then
                    Partes1.Add(Lineas(i).Trim)
                Else
                    Extraido = True
                End If
                If Extraido Then Exit For
            Next

            For Each Parte In Partes1
                If esCodificada(Parte) Then
                    If VerificarMultilinea(Parte) Then
                        Dim Codificaciones As List(Of String) = SepararCodificacion(Parte)
                        For Each Codificada In Codificaciones
                            If esCodificada(Codificada) Then
                                'Trazar = True
                                Partes2.Add(Decodificar(Codificada))
                            Else
                                Partes2.Add(Codificada)
                            End If
                        Next
                    Else
                        Partes2.Add(Decodificar(Parte))
                    End If
                Else
                    Partes2.Add(Parte)
                End If
            Next

            Dim Devolver As String = String.Join("", Partes2).Trim
            If Trazar Then Stop
            If String.IsNullOrEmpty(Devolver) Then Devolver = " "
            Return Devolver

            Exit Function
            Dim esAsunto As Boolean = False
            Dim esAnalizadoAsunto As Boolean = False
            Dim Asunto As New List(Of String)
            For Each Linea In Lineas

                If Linea.StartsWith("") Then
                    'Establecer Inicio del Asunto
                    esAsunto = True
                    esAnalizadoAsunto = True
                ElseIf esAsunto AndAlso Not {" ", vbTab}.Any(Function(Empieza) Linea.StartsWith(Empieza)) Then
                    'Finalizar Asunto
                    esAsunto = False
                End If

                'Si la linea es parte del Asunto
                Dim Unilinea As String = String.Empty
                If esAsunto Then
                    If Linea.StartsWith("") Then Unilinea = ExtraerAsunto(Linea)
                    If Not Linea.StartsWith("") Then Unilinea = Linea.Replace(vbTab, "").Trim
                    If String.IsNullOrEmpty(Unilinea) Then Continue For
                End If

                If esAsunto AndAlso Not String.IsNullOrEmpty(Unilinea) Then
                    'Estraer el asunto
                    'Buscar Partes Hexadecimales
                    'If Unilinea.Contains("?q?=") Then
                    '    Unilinea = DecodeHex(Unilinea)
                    'End If
                    'Comprobar si tiene partes codificadas
                    Dim esCodificada As Boolean = {"?Q?", "?T?", "?B?", "?U?", "?C?"}.Any(Function(Codificador) Unilinea.ToUpper.Contains(Codificador))
                    'Comprobar si combina partes no codificas con codificadas
                    Dim esMultilinea As Boolean = If(esCodificada = True, VerificarMultilinea(Unilinea), False)
                    'If esCodificada Then esMultilinea = Not Unilinea.StartsWith("=?") OrElse Not Unilinea.EndsWith("?=")

                    Dim Extraer As String = String.Empty

                    'Asunto sin codificar
                    If Not esCodificada Then Extraer = Unilinea.Trim

                    'Asunto codificado
                    If esCodificada AndAlso Not esMultilinea Then Extraer = Decodificar(Unilinea)

                    'Asunto combinado
                    If esCodificada AndAlso esMultilinea Then
                        Dim Partes3 As List(Of String) = SepararCodificacion(Unilinea)
                        For i = 0 To Partes1.Count - 1
                            If {"?Q?", "?T?", "?B?", "?U?", "?C?"}.Any(Function(Codificador) Partes1(i).ToUpper.Contains(Codificador)) Then
                                Dim Espacio As String = ""
                                If Partes1(i).EndsWith(" ") Then Espacio = " "
                                Partes1(i) = Decodificar(Partes1(i).Trim) & Espacio
                            End If
                        Next
                        Extraer = String.Join("", Partes1)
                    End If

                    If Not String.IsNullOrEmpty(Extraer) Then Asunto.Add(Extraer)
                End If

                'Hemos analizado el Asunto
                If Not esAsunto AndAlso esAnalizadoAsunto Then Exit For
            Next

            'Devolver
            Return String.Join("", Asunto)
        End Function

        Private Function esCodificada(Cadena) As Boolean
            Return Codificadores.Any(Function(Codificador) Cadena.ToUpper.Contains(Codificador))
        End Function
        Private Function ExtraerAsunto(contenido As String) As String
            Dim match As Match = Regex.Match(contenido, "Subject: (.+?)(?:\r\n|$)")
            If match.Success Then
                Return match.Groups(1).Value.Trim()
            Else
                Return String.Empty
            End If
        End Function

        Private Function VerificarMultilinea(Linea As String) As Boolean
            'Empieza sin Parte Codificada
            If Not Linea.StartsWith("=?") Then Return True

            'Termina sin Parte codificada
            If Not Linea.EndsWith("?=") Then Return True

            'Empieza y Termina Codificado (Buscamos si hay más de una codificación)
            If Codificaciones(Linea) Then Return True

            'Solo una codificacion sin partes no codificadas.
            Return False
        End Function
        Private Function Codificaciones(Cadena As String) As Boolean
            Dim Reconstruir As String = String.Empty
            Dim Contar As Integer = 0
            For Each Caracter As String In Cadena
                Reconstruir += Caracter
                If Reconstruir.Count > 1 Then
                    If Reconstruir.Substring(Reconstruir.Count - 2) = "=?" AndAlso Not Cadena.Substring(Reconstruir.Count, 1) = "=" Then Contar += 1
                End If
                If Contar > 1 Then Exit For
            Next
            If Contar > 1 Then Return True Else Return False
        End Function
        Private Function Decodificar(Linea As String)
            Dim Averiguar As New Regex("\=\?([\w\d\-]+)\?([B|Q])\?([^\?]+)\?\=", RegexOptions.IgnoreCase)
            Dim Coincidencias As MatchCollection = Averiguar.Matches(Linea)
            Dim PartesDecodificadas As New List(Of String)
            Dim Devolver As String = String.Empty

            For Each Coincidencia As Match In Coincidencias
                Dim CodificaString As String = Encoding.ASCII.ToString

                Select Case Coincidencia.Groups(1).Value.ToLower
                    Case "utf8"
                        CodificaString = "UTF-8"
                    Case "cp1252"
                        CodificaString = "Windows-1252"
                    Case "iso8859-15"
                        CodificaString = "ISO-8859-15"
                    Case Else
                        CodificaString = Coincidencia.Groups(1).Value.ToUpper
                End Select
                Dim Codificacion As Encoding

                Try
                    Codificacion = Encoding.GetEncoding(CodificaString)
                Catch ex As Exception
                    Stop
                End Try

                Dim TipoCodificacion As String = Coincidencia.Groups(2).Value.ToUpper
                Dim AsuntoCodificado As String = Coincidencia.Groups(3).Value
                If AsuntoCodificado.EndsWith("===") Then AsuntoCodificado = AsuntoCodificado.Substring(0, AsuntoCodificado.Count - 1)
                Select Case TipoCodificacion
                    Case "B"
                        'Base64
                        Dim Limpiar As New List(Of Char)

                        For Each Caracter In AsuntoCodificado
                            If Not Char.IsLetterOrDigit(Caracter) AndAlso Not {"+", "/", "-", "_", "="}.Contains(Caracter) Then
                                Limpiar.Add(Caracter)
                            End If
                        Next

                        For Each Caracter In Limpiar
                            AsuntoCodificado = AsuntoCodificado.Replace(Caracter, "")
                        Next

                        Dim DecodificarBytes As Byte() = Convert.FromBase64String(AsuntoCodificado)
                        Devolver = Codificacion.GetString(DecodificarBytes)
                    Case "C"
                        Devolver = QuotedPrintableToString(AsuntoCodificado)
                    Case "Q"
                        Devolver = QuotedPrintableToString(Linea)
                        If Devolver = Linea Then
                            'Devolver = DecodeHex(Devolver)
                            Devolver = DecodeQuotedPrintables(AsuntoCodificado.Replace("_", " "), CodificaString)
                        End If
                End Select

            Next
            Return Devolver
        End Function

        Private Function QuotedPrintableToString(Cadena As String) As String
            Dim Devolver As String = String.Empty
            Try
                Using Asunto As Attachment = Attachment.CreateAttachmentFromString("", Cadena)
                    Devolver = Asunto.Name
                End Using
            Catch ex As Exception
                Return Cadena
            End Try
            Return Devolver
        End Function

        Private Function DecodeQuotedPrintables(input As String, charSet As String) As String
            If String.IsNullOrEmpty(charSet) Then
                Dim charSetOccurences As New Regex("=\?.*\?Q\?", RegexOptions.IgnoreCase)
                Dim charSetMatches As MatchCollection = charSetOccurences.Matches(input)
                For Each match As Match In charSetMatches
                    charSet = match.Groups(0).Value.Replace("=?", "").Replace("?Q?", "")
                    input = input.Replace(match.Groups(0).Value, "").Replace("?=", "")
                Next
            End If

            Dim enc As Encoding = Encoding.ASCII
            Dim CodificaString As String = Encoding.ASCII.ToString
            Select Case charSet
                Case "UTF8"
                    CodificaString = "UTF-8"
                Case "Cp1252"
                    CodificaString = "Windows-1252"
                Case Else
                    CodificaString = charSet
            End Select

            If Not String.IsNullOrEmpty(CodificaString) Then
                Try
                    enc = Encoding.GetEncoding(CodificaString)
                Catch
                    enc = Encoding.ASCII
                End Try
            End If

            'Decode HEX
            'Dim sections As String() = input.Split("=")
            input = DecodeHex(input)
            ' Initialize the decoded subject
            'Dim decodedSubject As String = ""

            ' Decode iso-8859-[0-9]
            Dim occurences As New Regex("=[0-9A-Z]{2}", RegexOptions.Multiline)
            Dim matches As MatchCollection = occurences.Matches(input)
            For Each match As Match In matches
                Try
                    Dim b() As Byte = {Byte.Parse(match.Groups(0).Value.Substring(1), System.Globalization.NumberStyles.AllowHexSpecifier)}
                    Dim hexChar() As Char = enc.GetChars(b)
                    input = input.Replace(match.Groups(0).Value, hexChar(0).ToString())
                Catch
                End Try
            Next

            ' Decode base64String (utf-8?B?)
            occurences = New Regex("\?utf-8\?B\?.*\?", RegexOptions.IgnoreCase)
            matches = occurences.Matches(input)
            For Each match As Match In matches
                Dim b() As Byte = Convert.FromBase64String(match.Groups(0).Value.Replace("?utf-8?B?", "").Replace("?UTF-8?B?", "").Replace("?", ""))
                Dim temp As String = Encoding.UTF8.GetString(b)
                input = input.Replace(match.Groups(0).Value, temp)
            Next

            input = input.Replace("=\r\n", "").Replace("_", " ")
            Return input
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

        Function SepararCodificacion(input As String) As List(Of String)
            Dim parts As New List(Of String)

            ' Expresión regular para encontrar partes codificadas
            Dim regex As New Regex("(=\?.*?\?=)")

            ' Busca todas las coincidencias de la expresión regular en la cadena de entrada
            Dim matches As MatchCollection = regex.Matches(input)

            ' Índice de inicio de la próxima parte codificada
            Dim startIndex As Integer = 0

            ' Iterar a través de las coincidencias
            For Each match As Match In matches
                ' Obtener el índice de inicio y longitud de la coincidencia actual
                Dim matchIndex As Integer = match.Index
                Dim matchLength As Integer = match.Length

                ' Agregar la parte no codificada entre la parte actual y la anterior
                parts.Add(input.Substring(startIndex, matchIndex - startIndex))

                ' Agregar la parte codificada actual
                parts.Add(match.Value)

                ' Actualizar el índice de inicio para la próxima iteración
                startIndex = matchIndex + matchLength
            Next

            ' Agregar la parte restante de la cadena después de la última parte codificada
            If Not startIndex = input.Length Then parts.Add(input.Substring(startIndex))

            Dim Repair As New List(Of String)
            For i = 0 To parts.Count - 1
                If {"=?windows-1252?q?=", "=?utf-8?q?=", "=?iso-8859-1?q?="}.Any(Function(Codificacion) parts(i).ToLower = Codificacion) Then
                    Repair.Add(parts(i) & parts(i + 1))
                Else
                    If i > 0 Then
                        If Not {"=?windows-1252?q?=", "=?utf-8?q?=", "=?iso-8859-1?q?="}.Any(Function(Codificacion) parts(i - 1).ToLower = Codificacion) Then
                            Repair.Add(parts(i))
                        End If
                    Else
                        Repair.Add(parts(i))
                    End If
                End If
            Next
            If Repair.Count > 0 Then Return Repair
            Return parts
        End Function

    End Class
End Namespace