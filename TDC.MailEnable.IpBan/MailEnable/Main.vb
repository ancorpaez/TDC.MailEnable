Imports System.IO
Imports System.Xml.Serialization
Imports TDC.MailEnable.Core.MailEnableLog

Namespace MailEnable

    Module Main

        'ARCHIVO DE CONFIGURACION
        Const ConfiguracionArchivo As String = "Configuracion.xml"
        Public Configuracion As New Configuracion

        'ARCHIVO UNICO IP BAN
        Const IpBaneadasArchivo As String = "IpNegraUnico.xml"
        Public IpBaneadas As New IpNegraUnico
        Public IpBlancas As New IpBlancaSincronizada

        'ARCHIVO UNICO GEOLOCALIZACION
        Dim File_Geolocalizacion As String = $"{Application.StartupPath}\Geolocalizacion\Geolocalizacion.lst"
        Dim File_GeolocalizacionInfo As New IO.FileInfo(File_Geolocalizacion)
        Public Geolocalizador As ArchivoLocal = Nothing

        'SPAMASSASSIN

        Public SpamAssassin As SpamAssassin.Programa

        'PIPE BANEADAS
        Private PipeServer As Core.Pipe.ServerPipe

        'POSTOFFICES
        Public PostOfficesCenter As PostOffices

        Public IpBanForm As Interfaz.IpBan



        Public Sub Mod_Core_Main()
            'PRUEBAS
            'PipeServer = New Core.Pipe.ServerPipe With {.ObtenerLista = Function() IpBaneadas.ToList}
            'MsgBox(Core.PipeServerName)
            'Geolocalizador.Add("0.0.0.3", "ES")
            'Geolocalizador.Add("0.0.0.0", "ES")
            'Geolocalizador.Add("0.0.0.1", "ES")
            'Geolocalizador.Remove("0.0.0.2")
            'System.Threading.Tasks.Task.Run(Sub()
            '                                    Dim d1 As New TDC.MailEnable.Core.Bucle.DoBucle("Test1")
            '                                End Sub)

            'System.Threading.Tasks.Task.Run(Sub()
            '                                    Dim d2 As New TDC.MailEnable.Core.Bucle.DoBucle("Test2")
            '                                End Sub)
            'System.Threading.Tasks.Task.Run(Sub()
            '                                    Dim d3 As New TDC.MailEnable.Core.Bucle.DoBucle("Test3")
            '                                End Sub)
            'System.Threading.Tasks.Task.Run(Sub()
            '                                    Dim d4 As New TDC.MailEnable.Core.Bucle.DoBucle("Test4")
            '                                End Sub)
            'Dim test5 = New Threading.Thread(Sub()
            '                                     Dim d5 As New TDC.MailEnable.Core.Bucle.DoBucle("Test5")
            '                                 End Sub)
            'test5.Start()
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

                ''Cargar Ips Blancas
                'If Not CargarIpBlanca() Then
                '    MsgBox("Error de carga de la lista de Ip's Blancas")
                '    End
                'Else
                '    Try
                '        If IpBlancas.Data.First = "" Then IpBlancas.Data.Remove("")
                '    Catch ex As Exception
                '    End Try
                'End If

                'Cargar PostOffices
                If Not String.IsNullOrEmpty(Configuracion.POST_OFFICES) Then
                    If IO.Directory.Exists(Configuracion.POST_OFFICES) Then
                        PostOfficesCenter = New PostOffices(Configuracion.POST_OFFICES)
                    End If
                End If

                'Activar Spam Assassin
                If Not String.IsNullOrEmpty(Configuracion.SPAM_SPAMASSASSIN) Then
                    If IO.File.Exists(Configuracion.SPAM_SPAMASSASSIN) Then
                        If New IO.FileInfo(Configuracion.SPAM_SPAMASSASSIN).Extension.ToLower.Contains("exe") Then
                            Dim BuscarProceso As Integer = Process.GetProcessesByName(New IO.FileInfo(Configuracion.SPAM_SPAMASSASSIN).Name.Replace(".exe", "")).Length
                            If BuscarProceso = 0 Then
                                SpamAssassin = New SpamAssassin.Programa With {.Ejecutable = New IO.FileInfo(Configuracion.SPAM_SPAMASSASSIN)}
                            Else
                                SpamAssassin = New SpamAssassin.Programa With {.Proceso = Process.GetProcessesByName(New IO.FileInfo(Configuracion.SPAM_SPAMASSASSIN).Name.Replace(".exe", ""))(0)}
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
            Geolocalizador = New ArchivoLocal(File_GeolocalizacionInfo.FullName)
        End Sub

        '::::::::: ARCHIVO DE CONFIGURACION
        Private Function CargarConfiguracion() As Boolean
            Try
                'Cargar Archivo
                If Not IO.File.Exists(ConfiguracionArchivo) Then
                    Dim Generar As New XmlSerializer(GetType(Configuracion))
                    Using Crear As New StreamWriter(ConfiguracionArchivo)
                        Generar.Serialize(Crear, Configuracion)
                    End Using
                Else
                    Dim Cargar As New XmlSerializer(GetType(Configuracion))
                    Using Leer As New StreamReader(ConfiguracionArchivo)
                        Configuracion = DirectCast(Cargar.Deserialize(Leer), Configuracion)
                    End Using
                End If

                'Actualizar Registro de Windows
                Try
                    Dim ArranqueWindows As New ArranqueWindows With {.ArranqueWindows = Configuracion.AutoArranqueWindows}
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
                Dim Guardar As New XmlSerializer(GetType(Configuracion))
                Using Escribir As New StreamWriter(ConfiguracionArchivo)
                    Guardar.Serialize(Escribir, Main.Configuracion)
                End Using

                'Actualizar Registro de Windows
                Try
                    Dim ArranqueWindows As New ArranqueWindows With {.ArranqueWindows = Configuracion.AutoArranqueWindows}
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
                If Not IO.File.Exists(IpBaneadasArchivo) Then
                    Dim Generar As New XmlSerializer(GetType(IpNegraUnico))
                    Using Crear As New StreamWriter(IpBaneadasArchivo)
                        Generar.Serialize(Crear, IpBaneadas)
                    End Using
                Else
                    Dim Cargar As New XmlSerializer(GetType(IpNegraUnico))
                    Using Leer As New StreamReader(IpBaneadasArchivo)
                        IpBaneadas = DirectCast(Cargar.Deserialize(Leer), IpNegraUnico)
                    End Using
                End If
                Return True
            Catch ex As Exception
                Stop
            End Try
            Return False
        End Function

        Public Function SalvarIpBan()
            Try
                Dim Guardar As New XmlSerializer(GetType(IpNegraUnico))
                Using Escribir As New StreamWriter(IpBaneadasArchivo)
                    Guardar.Serialize(Escribir, Main.IpBaneadas)
                End Using
                Return True
            Catch ex As Exception
            End Try
            Return False
        End Function
        '::::::::::::::::::::::::::::::::::::::::::::::::

    End Module
End Namespace