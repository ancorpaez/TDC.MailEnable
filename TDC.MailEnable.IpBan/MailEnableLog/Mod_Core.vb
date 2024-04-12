Imports System.IO
Imports System.Xml.Serialization
Imports TDC.MailEnable.Core.MailEnableLog

Namespace MailEnableLog

    Module Mod_Core
        'ARCHIVO DE CONFIGURACION
        Const File_Config As String = "Config.xml"
        Public Configuracion As New Cls_Config

        'ARCHIVO UNICO IP BAN
        Const File_IpBan As String = "IpBan.xml"
        Public IpBaneadas As New Cls_IpBan
        Const File_IpBlanca As String = "IpBlanca.xml"
        Public IpBlancas As New Cls_IpBlanca

        'ARCHIVO UNICO GEOLOCALIZACION
        Dim File_Geolocalizacion As String = $"{Application.StartupPath}\Geolocalizacion\Geolocalizacion.lst"
        Dim File_GeolocalizacionInfo As New IO.FileInfo(File_Geolocalizacion)
        Public Geolocalizador As Cls_Geolocalizacion = Nothing

        'SPAMASSASSIN

        Public SpamAssassin As Spam.SpamAssassin

        'PIPE BANEADAS
        Private PipeServer As Core.Pipe.ServerPipe

        'POSTOFFICES
        Public PostOfficesCenter As Cls_PostOffices

        Public IpBanForm As Interfaz.IpBan



        Public Sub Mod_Core_Main()
            'PRUEBAS
            'PipeServer = New Core.Pipe.ServerPipe With {.ObtenerLista = Function() IpBaneadas.ToList}
            'MsgBox(Core.PipeServerName)
            'Geolocalizador.Add("0.0.0.3", "ES")
            'Geolocalizador.Add("0.0.0.0", "ES")
            'Geolocalizador.Add("0.0.0.1", "ES")
            'Geolocalizador.Remove("0.0.0.2")
            '******************************************************

            If Not CargarConfiguracion() Then
                MsgBox("Error de carga de la configuración")
                End
            Else
                'Cargar Ips Baneadas
                If Not CargarIpBan() Then
                    MsgBox("Error de carga de la lista de Ip's Baneadas")
                    End
                Else
                    Try
                        If IpBaneadas.Data.First = "" Then IpBaneadas.Data.Remove("")
                    Catch ex As Exception
                    End Try
                End If

                'Cargar Ips Blancas
                If Not CargarIpBlanca() Then
                    MsgBox("Error de carga de la lista de Ip's Blancas")
                    End
                Else
                    Try
                        If IpBlancas.Data.First = "" Then IpBlancas.Data.Remove("")
                    Catch ex As Exception
                    End Try
                End If

                'Cargar PostOffices
                If Not String.IsNullOrEmpty(Configuracion.POST_OFFICES) Then
                    If IO.Directory.Exists(Configuracion.POST_OFFICES) Then
                        PostOfficesCenter = New Cls_PostOffices(Configuracion.POST_OFFICES)
                    End If
                End If

                'Activar Spam Assassin
                If Not String.IsNullOrEmpty(Configuracion.SPAM_SPAMASSASSIN) Then
                    If IO.File.Exists(Configuracion.SPAM_SPAMASSASSIN) Then
                        If New IO.FileInfo(Configuracion.SPAM_SPAMASSASSIN).Extension.ToLower.Contains("exe") Then
                            Dim BuscarProceso As Integer = Process.GetProcessesByName(New IO.FileInfo(Configuracion.SPAM_SPAMASSASSIN).Name.Replace(".exe", "")).Length
                            If BuscarProceso = 0 Then
                                SpamAssassin = New Spam.SpamAssassin With {.Ejecutable = New IO.FileInfo(Configuracion.SPAM_SPAMASSASSIN)}
                            Else
                                SpamAssassin = New Spam.SpamAssassin With {.Proceso = Process.GetProcessesByName(New IO.FileInfo(Configuracion.SPAM_SPAMASSASSIN).Name.Replace(".exe", ""))(0)}
                            End If
                        End If
                    End If
                End If

                'Activar Enrutador IMAP
                'If Not String.IsNullOrEmpty(Configuracion.IMAP_SOCKET_APP) Then
                '    If IO.File.Exists(Configuracion.IMAP_SOCKET_APP) Then
                '        If New IO.FileInfo(Configuracion.IMAP_SOCKET_APP).Extension.ToLower.Contains("exe") Then
                '            Dim BuscarProceso As Integer = Process.GetProcessesByName(New IO.FileInfo(Configuracion.IMAP_SOCKET_APP).Name.Replace(".exe", "")).Length
                '            If BuscarProceso = 0 Then
                '                'SpamAssassin = New Spam.SpamAssassin With {.Ejecutable = New IO.FileInfo(Configuracion.IMAP_SOCKET_APP)}
                '                Process.Start(Configuracion.IMAP_SOCKET_APP)
                '            Else
                '                ' SpamAssassin = New Spam.SpamAssassin With {.Proceso = Process.GetProcessesByName(New IO.FileInfo(Configuracion.IMAP_SOCKET_APP).Name.Replace(".exe", ""))(0)}
                '            End If
                '        End If
                '    End If
                'End If
            End If

            'Activar Lista IpBan compartida en memoria
            PipeServer = New Core.Pipe.ServerPipe With {.ObtenerLista = Function() IpBaneadas.ToList}

            'Establecer Geolocalizador
            If Not File_GeolocalizacionInfo.Directory.Exists Then File_GeolocalizacionInfo.Directory.Create()
            Geolocalizador = New Cls_Geolocalizacion(File_GeolocalizacionInfo.FullName)
        End Sub

        '::::::::: ARCHIVO DE CONFIGURACION
        Private Function CargarConfiguracion() As Boolean
            Try
                'Cargar Archivo
                If Not IO.File.Exists(File_Config) Then
                    Dim Generar As New XmlSerializer(GetType(Cls_Config))
                    Using Crear As New StreamWriter(File_Config)
                        Generar.Serialize(Crear, Configuracion)
                    End Using
                Else
                    Dim Cargar As New XmlSerializer(GetType(Cls_Config))
                    Using Leer As New StreamReader(File_Config)
                        Configuracion = DirectCast(Cargar.Deserialize(Leer), Cls_Config)
                    End Using
                End If

                'Actualizar Registro de Windows
                Try
                    Dim ArranqueWindows As New Cls_ArranqueWindows With {.ArranqueWindows = Configuracion.AutoArranqueWindows}
                    ArranqueWindows.Inicializar()
                Catch ex As Exception
                    MsgBox("No se pudo acceder al registro de windows. (Auto Arranque)")
                End Try

                Return True
            Catch ex As Exception
            End Try
            Return False
        End Function

        Public Function GuardarConfiguracion() As Boolean
            Try
                Dim Guardar As New XmlSerializer(GetType(Cls_Config))
                Using Escribir As New StreamWriter(File_Config)
                    Guardar.Serialize(Escribir, Mod_Core.Configuracion)
                End Using

                'Actualizar Registro de Windows
                Try
                    Dim ArranqueWindows As New Cls_ArranqueWindows With {.ArranqueWindows = Configuracion.AutoArranqueWindows}
                    ArranqueWindows.Inicializar()
                Catch ex As Exception
                    MsgBox("No se pudo acceder al registro de windows. (Auto Arranque)")
                End Try
                Return True
            Catch ex As Exception
            End Try
            Return False
        End Function
        '::::::::::::::::::::::::::::::::::::::::::::::::

        '::::::::: ARCHIVO UNICO DE  IP BAN
        Public Function CargarIpBan() As Boolean
            Try
                If Not IO.File.Exists(File_IpBan) Then
                    Dim Generar As New XmlSerializer(GetType(Cls_IpBan))
                    Using Crear As New StreamWriter(File_IpBan)
                        Generar.Serialize(Crear, IpBaneadas)
                    End Using
                Else
                    Dim Cargar As New XmlSerializer(GetType(Cls_IpBan))
                    Using Leer As New StreamReader(File_IpBan)
                        IpBaneadas = DirectCast(Cargar.Deserialize(Leer), Cls_IpBan)
                    End Using
                End If
                Return True
            Catch ex As Exception
            End Try
            Return False
        End Function

        Public Function SalvarIpBan()
            Try
                Dim Guardar As New XmlSerializer(GetType(Cls_IpBan))
                Using Escribir As New StreamWriter(File_IpBan)
                    Guardar.Serialize(Escribir, Mod_Core.IpBaneadas)
                End Using
                Return True
            Catch ex As Exception
            End Try
            Return False
        End Function
        '::::::::::::::::::::::::::::::::::::::::::::::::
        '::::::::: ARCHIVO UNICO DE  IP BAN
        Public Function CargarIpBlanca() As Boolean
            Try
                If Not IO.File.Exists(File_IpBlanca) Then
                    Dim Generar As New XmlSerializer(GetType(Cls_IpBlanca))
                    Using Crear As New StreamWriter(File_IpBlanca)
                        Generar.Serialize(Crear, IpBlancas)
                    End Using
                Else
                    Dim Cargar As New XmlSerializer(GetType(Cls_IpBlanca))
                    Using Leer As New StreamReader(File_IpBlanca)
                        IpBlancas = DirectCast(Cargar.Deserialize(Leer), Cls_IpBlanca)
                    End Using
                End If
                Return True
            Catch ex As Exception
            End Try
            Return False
        End Function

        Public Function SalvarIpBlanca()
            Try
                Dim Guardar As New XmlSerializer(GetType(Cls_IpBlanca))
                Using Escribir As New StreamWriter(File_IpBlanca)
                    Guardar.Serialize(Escribir, Mod_Core.IpBlancas)
                End Using
                Return True
            Catch ex As Exception
            End Try
            Return False
        End Function
        '::::::::::::::::::::::::::::::::::::::::::::::::
    End Module
End Namespace