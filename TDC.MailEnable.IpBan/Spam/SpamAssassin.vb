Namespace Spam
    Public Class SpamAssassin
        Private Declare Function ShowWindow Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
        Private Const SW_HIDE As Integer = 0
        Private Const SW_SHOW As Integer = 5

        Private _Ejecutable As IO.FileInfo
        Public Property Ejecutable As IO.FileInfo
            Get
                Return _Ejecutable
            End Get
            Set(value As IO.FileInfo)
                _Ejecutable = value
                LogFile = New IO.FileInfo(Ejecutable.FullName.Replace("exe", "log"))
            End Set
        End Property
        Public Property LogFile As IO.FileInfo
        Private Log As IO.StreamReader
        Private LogLines As Concurrent.ConcurrentDictionary(Of Integer, String)
        Private LogBag As Concurrent.ConcurrentBag(Of String)

        Private WithEvents _Proceso As Process
        Public Property Proceso As Process
            Get
                Return _Proceso
            End Get
            Set(value As Process)
                _Proceso = value
                If Not IsNothing(value) Then
                    _Proceso.EnableRaisingEvents = True
                    AddHandler _Proceso.Exited, AddressOf _Proceso_Exited
                    _Corriendo = True
                End If
            End Set
        End Property
        Public Salida As RichTextBox
        Private WithEvents Lectura As Core.Bucle.DoBucle

        Private _Corriendo As Boolean = False
        Public ReadOnly Property Corriendo As Boolean
            Get
                Return _Corriendo
            End Get
        End Property

        Public Enum SpamAssassinModoInicio
            Normal
            Oculto
        End Enum
        Public Sub Start(Modo As SpamAssassinModoInicio)
            If Not IsNothing(Ejecutable) Then
                If Ejecutable.Exists Then
                    _Proceso = New Process
                    With _Proceso
                        With .StartInfo
                            .FileName = Ejecutable.FullName
                            .WorkingDirectory = Ejecutable.Directory.FullName
                            .Verb = "runas"
                            .Arguments = "-s file # ./spamd.log"
                            If Modo = SpamAssassinModoInicio.Oculto Then
                                .UseShellExecute = False
                                .CreateNoWindow = True
                            End If
                        End With
                        .EnableRaisingEvents = True
                        AddHandler _Proceso.Exited, AddressOf _Proceso_Exited
                        .Start()
                        _Corriendo = True
                        Read()
                    End With
                End If
            End If
        End Sub
        Public Sub Ocultar()
            ShowWindow(_Proceso.MainWindowHandle, SW_HIDE)
        End Sub
        Public Sub Mostrar()
            ShowWindow(_Proceso.MainWindowHandle, SW_SHOW)
        End Sub
        Public Sub Read()
            Lectura = New Core.Bucle.DoBucle With {.Intervalo = 1000}
            Lectura.Iniciar()
        End Sub
        Public Sub Kill()
            If Not IsNothing(Proceso) Then
                If Not Proceso.HasExited Then
                    Proceso.Kill()
                    Proceso.Close()
                    _Corriendo = False
                End If
            End If
        End Sub


        Private Sub Lectura_IBucle_Bucle(Sender As Object, ByRef Detener As Boolean) Handles Lectura.Background
            If IsNothing(LogFile) Then LogFile = New IO.FileInfo(Ejecutable.FullName.Replace("exe", "log"))
            If Not LogFile.Exists Then
                LogFile.Refresh()
            Else
                Try
                    If IsNothing(Log) Then Log = New IO.StreamReader(IO.File.Open(LogFile.FullName, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite))

                    'Cargar Inicial del Archivo
                    If IsNothing(LogBag) Then
                        LogLines = New Concurrent.ConcurrentDictionary(Of Integer, String)
                        LogBag = New Concurrent.ConcurrentBag(Of String)
                        Dim Linea As String = Log.ReadLine
                        Do While Not String.IsNullOrEmpty(Linea)
                            LogBag.Add(Linea)
                            LogLines.TryAdd(LogLines.Count, Linea)
                            Linea = Log.ReadLine
                        Loop
                        Salida.Invoke(Sub() Salida.Text = String.Join(Environment.NewLine, LogLines.Values))
                    End If

                    'Actualizar Informacion desde Archivo
                    If Not IsNothing(LogBag) Then
                        Dim Linea As String = Log.ReadLine
                        If Not String.IsNullOrEmpty(Linea) Then
                            If Not LogBag.Contains(Linea) Then
                                Lectura.Intervalo = 100
                                LogBag.Add(Linea)
                                LogLines.TryAdd(LogLines.Count, Linea)
                                Salida.Invoke(Sub() Salida.Text += Linea & Environment.NewLine)
                            End If
                        Else
                            Lectura.Intervalo = 6000
                        End If
                    End If
                Catch ex As Exception

                End Try
            End If
        End Sub

        Private Sub _Proceso_Exited(sender As Object, e As EventArgs) Handles _Proceso.Exited
            _Corriendo = False
        End Sub
    End Class
End Namespace