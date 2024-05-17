Namespace Windows
    Namespace Registro

        Public Class Acceso
            Public Enum Ramas
                HKEY_LOCAL_MACHINE
                HKEY_CURRENT_USER
                HKEY_CLASSES_ROOT
                HKEY_USERS
                HKEY_CURRENT_CONFIG
            End Enum
            Public Class Convertir
                Public Shared Function FromDWORD(Valor As Integer) As Integer?
                    Try
                        Return System.Convert.ToInt32(Valor, 16)
                    Catch ex As Exception
                        Return Nothing
                    End Try
                End Function
            End Class
        End Class

        Public Class Acciones
            Public Shared Function ObtenerCadena(Rama As Acceso.Ramas, Ruta As String, Clave As String) As String
                Try
                    Return My.Computer.Registry.GetValue($"{Rama.ToString}\{Ruta.Trim("\"c)}", Clave, Nothing)
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function
            Public Shared Function ObtenerEntero(Rama As Acceso.Ramas, Ruta As String, Clave As String) As Integer?
                Try
                    Dim Valor As Object = My.Computer.Registry.GetValue($"{Rama.ToString}\{Ruta.Trim("\"c)}", Clave, Nothing)
                    If IsNumeric(Valor) Then Return CInt(Valor) Else Return Nothing
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function
            Public Shared Function ObtenerDWORD(Rama As Acceso.Ramas, Ruta As String, Clave As String) As Integer?
                Try
                    Dim Valor As Object = My.Computer.Registry.GetValue($"{Rama.ToString}\{Ruta.Trim("\"c)}", Clave, Nothing)
                    If IsNumeric(Valor) Then Return CInt(Valor).ToString("X") Else Return Nothing
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function
            Public Shared Function ObtenerDWORD(Carpeta As Microsoft.Win32.RegistryKey, Clave As String) As Integer?
                Try
                    Dim Valor As Object = Carpeta.GetValue(Clave, Nothing)
                    If IsNumeric(Valor) Then Return CInt(Valor).ToString("X") Else Return Nothing
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function
            Public Shared Function ObtenerCarpeta(Rama As Acceso.Ramas, Ruta As String) As Microsoft.Win32.RegistryKey
                Try
                    Dim KeyPath() As String = $"{Ruta.Trim("\"c)}".Split("\")
                    Dim RegistryFolder As Microsoft.Win32.RegistryKey = Nothing

                    Select Case Rama
                        Case Acceso.Ramas.HKEY_LOCAL_MACHINE
                            RegistryFolder = My.Computer.Registry.LocalMachine.OpenSubKey(KeyPath.First, True)

                        Case Acceso.Ramas.HKEY_CURRENT_USER
                            RegistryFolder = My.Computer.Registry.CurrentUser.OpenSubKey(KeyPath.First, True)

                        Case Acceso.Ramas.HKEY_CLASSES_ROOT
                            RegistryFolder = My.Computer.Registry.ClassesRoot.OpenSubKey(KeyPath.First, True)

                        Case Acceso.Ramas.HKEY_CURRENT_CONFIG
                            RegistryFolder = My.Computer.Registry.CurrentConfig.OpenSubKey(KeyPath.First, True)

                        Case Acceso.Ramas.HKEY_USERS
                            RegistryFolder = My.Computer.Registry.Users.OpenSubKey(KeyPath.First, True)

                    End Select

                    For iFolder = 1 To KeyPath.Count - 1
                        If Not IsNothing(RegistryFolder) Then RegistryFolder = RegistryFolder.OpenSubKey(KeyPath(iFolder), True)
                    Next

                    Return RegistryFolder
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function
            Public Shared Function ExisteClave(Carpeta As Microsoft.Win32.RegistryKey, Clave As String) As Boolean
                Try
                    Dim Claves() As String = Carpeta.GetValueNames
                    Return Claves.Any(Function(ClaveExistente) ClaveExistente = Clave)
                Catch ex As Exception
                    Return False
                End Try
            End Function
            Public Shared Function ObtenerClaves(Rama As Acceso.Ramas, Ruta As String) As String()
                Try
                    Dim RegistryFolder As Microsoft.Win32.RegistryKey = ObtenerCarpeta(Rama, Ruta)
                    If Not IsNothing(RegistryFolder) Then Return RegistryFolder.GetValueNames() Else Return Nothing
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function
            Public Shared Function ObtenerClaves(Carpeta As Microsoft.Win32.RegistryKey) As String()
                Try
                    Return Carpeta.GetValueNames
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function

            Public Shared Function EstablecerCadena(Carpeta As Microsoft.Win32.RegistryKey, Clave As String, Valor As String) As Boolean
                Try
                    'Establecer Valor
                    Carpeta.SetValue(Clave, Valor, Microsoft.Win32.RegistryValueKind.String)

                    'Recuperar Valor
                    Dim ObtenerValor As String = Carpeta.GetValue(Clave)
                    Return ObtenerValor = Valor
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Public Shared Function EstablecerDWORD(Carpeta As Microsoft.Win32.RegistryKey, Clave As String, Valor As Integer) As Boolean
                Try
                    'Establecer Valor
                    Carpeta.SetValue(Clave, Valor, Microsoft.Win32.RegistryValueKind.DWord)

                    'Recuperar Valor
                    Dim ObtenerValor As Integer = Carpeta.GetValue(Clave)
                    Return ObtenerValor = Valor
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Public Shared Function ObtenerBinario(Rama As Acceso.Ramas, Ruta As String, Clave As String) As Byte()
                Try
                    Return DirectCast(My.Computer.Registry.GetValue($"{Rama.ToString}\{Ruta.Trim("\"c)}", Clave, Nothing), Byte())
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function

            Public Shared Function EstablecerBinario(Carpeta As Microsoft.Win32.RegistryKey, Clave As String, Valor As Byte()) As Boolean
                Try
                    'Establecer Valor
                    Carpeta.SetValue(Clave, Valor, Microsoft.Win32.RegistryValueKind.Binary)

                    'Recuperar Valor
                    Dim ObtenerValor As Byte() = DirectCast(Carpeta.GetValue(Clave), Byte())
                    Return ObtenerValor.SequenceEqual(Valor)
                Catch ex As Exception
                    Return False
                End Try
            End Function
            Public Shared Function ObtenerFloat(Rama As Acceso.Ramas, Ruta As String, Clave As String) As Single?
                Try
                    Dim Valor As Object = My.Computer.Registry.GetValue($"{Rama.ToString}\{Ruta.Trim("\"c)}", Clave, Nothing)
                    Dim floatValor As Single
                    If Single.TryParse(Valor, floatValor) Then Return floatValor Else Return Nothing
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function

            Public Shared Function EstablecerFloat(KeyFolder As Microsoft.Win32.RegistryKey, Name As String, Value As Single) As Boolean
                Try
                    Dim GetValue As Single
                    KeyFolder.SetValue(Name, Value, Microsoft.Win32.RegistryValueKind.Binary)
                    GetValue = Single.Parse(KeyFolder.GetValue(Name).ToString())
                    Return GetValue = Value
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function
            Public Shared Function ObtenerMultiString(Key As Acceso.Ramas, Path As String, Name As String) As String()
                Try
                    Dim MultiStringValues As String() = DirectCast(My.Computer.Registry.GetValue($"{Key.ToString}\{Path.Trim("\"c)}", Name, Nothing), String())
                    If MultiStringValues IsNot Nothing Then
                        Return MultiStringValues
                    Else
                        Return Nothing
                    End If
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function

            Public Shared Function EstablecerMultiString(KeyFolder As Microsoft.Win32.RegistryKey, Name As String, Values As String()) As Boolean
                Try
                    KeyFolder.SetValue(Name, Values, Microsoft.Win32.RegistryValueKind.MultiString)
                    Dim GetValues As String() = DirectCast(KeyFolder.GetValue(Name), String())
                    Return GetValues.SequenceEqual(Values)
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Public Shared Function ObtenerExpandString(Key As Acceso.Ramas, Path As String, Name As String) As String
                Try
                    Dim ExpandStringValues As String = My.Computer.Registry.GetValue($"{Key.ToString}\{Path.Trim("\"c)}", Name, Nothing)
                    If Not IsNothing(ExpandStringValues) Then
                        Return ExpandStringValues
                    Else
                        Return Nothing
                    End If
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function
            Public Shared Function EstablecerExpandString(KeyFolder As Microsoft.Win32.RegistryKey, Name As String, Value As String) As Boolean
                Try
                    KeyFolder.SetValue(Name, Value, Microsoft.Win32.RegistryValueKind.ExpandString)
                    Dim GetValues As String = KeyFolder.GetValue(Name)
                    If GetValues = Environment.ExpandEnvironmentVariables(Value) Then
                        Return True
                    Else
                        Return False
                    End If
                Catch ex As Exception
                    Return False
                End Try
            End Function


            Public Shared Function EliminarClave(Carpeta As Microsoft.Win32.RegistryKey, Clave As String) As Boolean
                Try
                    Carpeta.DeleteValue(Clave)
                    Return Not Carpeta.GetValueNames.ToList.Any(Function(ClavesExistentes) ClavesExistentes = Clave)
                Catch ex As Exception
                    Return False
                End Try
            End Function
        End Class
    End Namespace
End Namespace

