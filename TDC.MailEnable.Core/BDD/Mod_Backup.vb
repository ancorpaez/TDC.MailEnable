Namespace BDD
    Public MustInherit Class Mod_Backup
        Public Property Tabla As DataTable
        Protected Friend Fila As DataRow
        Public Columnas As Columnas
        Protected Friend MustOverride Function Inicializar() As Columnas
        Public MustOverride Function GetColString(Columnas As Columnas.Columnas)
        Public MustOverride Function GetColIndex(Columnas As Columnas.Columnas)
        Public Enum EnumGuardado
            Guardando
            Guardado
        End Enum

        'Bandera de Guardado de Archivo
        Private GuardarEstado As EnumGuardado = EnumGuardado.Guardado


        'Operaciones Asincronas
        Private Shared SyncLockAction As New Object()

        Public Sub New(Name As String)
            Tabla = New DataTable(Name)
            Columnas = Inicializar()
            Tabla.Columns.Add(CrearID)
            For Each Propiedad In Columnas.GetType.GetProperties
                If IsNothing(Propiedad.GetValue(Columnas)) AndAlso Not String.IsNullOrEmpty(Propiedad.GetValue(Columnas)) Then
                    Dim esUnique As Boolean = False
                    Select Case Propiedad.GetMethod.ReturnType
                        Case GetType(System.String)
                            If Propiedad.GetValue(Columnas) = UniqueState.Unique.ToString Then esUnique = True
                        Case GetType(System.Int32)
                            If Propiedad.GetValue(Columnas) = CInt(UniqueState.Unique) Then esUnique = True
                    End Select
                    If esUnique Then
                        Tabla.Columns.Add(CrearColumna(Propiedad.Name, Propiedad.GetMethod.ReturnType, True))
                    Else
                        Tabla.Columns.Add(CrearColumna(Propiedad.Name, Propiedad.GetMethod.ReturnType, False))
                    End If
                Else
                    Tabla.Columns.Add(CrearColumna(Propiedad.Name, Propiedad.GetMethod.ReturnType, False))
                End If
            Next
        End Sub

        Public Sub Guardar(Name)
            SyncLock SyncLockAction
                If GuardarEstado = EnumGuardado.Guardado Then
                    GuardarEstado = EnumGuardado.Guardando
                    Tabla.WriteXml(Name)
                    GuardarEstado = EnumGuardado.Guardado
                End If
            End SyncLock
        End Sub
        Public Function Add(Valor As Columnas) As Integer
            SyncLock SyncLockAction
                Fila = Tabla.NewRow
                Try
                    For Each Propiedad In Valor.GetType.GetProperties
                        Fila(Propiedad.Name) = Propiedad.GetValue(Valor)
                    Next
                    Tabla.Rows.Add(Fila)
                Catch ex As Exception
                End Try
                Return Fila("ID")
            End SyncLock
        End Function

        Public Sub Clear()
            Tabla.Clear()
        End Sub

        Public Function Contains(Columna As String, Valor As String) As Boolean
            SyncLock SyncLockAction
                Try
                    Dim Objeto As DataRow() = Tabla.Select(String.Format(Columna & "='{0}'", Valor))
                    If Objeto.Count > 0 Then Return True Else Return False
                Catch ex As Exception
                    Return False
                End Try
            End SyncLock
        End Function

        Public Sub Update(Id As Int32, Columna As String, Valor As String)
            SyncLock SyncLockAction
                Try
                    Dim Actualizar As DataRow() = Tabla.Select("ID='" & Id & "'")
                    If Actualizar.Count > 0 Then
                        Actualizar.First.Item(Columna) = Valor
                    End If
                Catch ex As Exception
                End Try
            End SyncLock
        End Sub
        Public Function [Get](Id As Int32, Columna As String) As Object
            SyncLock SyncLockAction
                Try
                    Dim Devolver As DataRow() = Tabla.Select("ID='" & Id & "'")
                    If Devolver.Count > 0 Then
                        Return Devolver.First.Item(Columna)
                    End If
                Catch ex As Exception
                    Return Nothing
                End Try
                Return Nothing
            End SyncLock
        End Function
        Public Function GetItemIndex(Columna As String, Valor As Object) As Integer?
            SyncLock SyncLockAction
                Try
                    Dim Devolucion As DataRow() = Tabla.Select(String.Format(Columna & "='{0}'", Valor))
                    If Not IsNothing(Devolucion) Then
                        If Devolucion.Count > 0 Then
                            Return Devolucion.First.Item("ID")
                        End If
                    End If
                Catch ex As Exception
                    Return Nothing
                End Try
                Return Nothing
            End SyncLock
        End Function

        Public Function GetRow(Columna As String, Valor As Object) As DataRow
            Try
                Dim Devolucion As DataRow() = Tabla.Select(String.Format(Columna & "='{0}'", Valor))
                If Not IsNothing(Devolucion) Then Return Devolucion.First
            Catch ex As Exception

            End Try
            Return Nothing
        End Function
        Protected Friend Function CrearID() As DataColumn
            Dim Columna As New DataColumn With {
                .DataType = GetType(Int32),
                .ColumnName = "ID",
                .Caption = "ID",
                .AutoIncrement = True,
                .[ReadOnly] = True,
                .Unique = True}
            Return Columna
        End Function

        Private Function CrearColumna(Name As String, Tipo As Type, Unico As Boolean) As DataColumn
            Dim Columna As New DataColumn With {
                .DataType = Tipo,
                .ColumnName = Name,
                .Caption = Name,
                .AutoIncrement = False,
                .[ReadOnly] = False,
                .Unique = Unico}
            Return Columna
        End Function
        Protected Friend Enum UniqueState
            Unique = -1
        End Enum
    End Class
End Namespace