<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcAnalizador
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ProgresoCarpeta = New System.Windows.Forms.ProgressBar()
        Me.Carpeta = New System.Windows.Forms.Label()
        Me.ContadorCarpeta = New System.Windows.Forms.Label()
        Me.Archivo = New System.Windows.Forms.Label()
        Me.ProgresoArchivo = New System.Windows.Forms.ProgressBar()
        Me.TableCarpeta = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ContadorArchivo = New System.Windows.Forms.Label()
        Me.TableUc = New System.Windows.Forms.TableLayoutPanel()
        Me.TableCarpeta.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableUc.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgresoCarpeta
        '
        Me.TableCarpeta.SetColumnSpan(Me.ProgresoCarpeta, 2)
        Me.ProgresoCarpeta.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgresoCarpeta.Location = New System.Drawing.Point(0, 24)
        Me.ProgresoCarpeta.Margin = New System.Windows.Forms.Padding(0)
        Me.ProgresoCarpeta.Name = "ProgresoCarpeta"
        Me.ProgresoCarpeta.Size = New System.Drawing.Size(199, 10)
        Me.ProgresoCarpeta.TabIndex = 0
        '
        'Carpeta
        '
        Me.Carpeta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Carpeta.Location = New System.Drawing.Point(0, 0)
        Me.Carpeta.Margin = New System.Windows.Forms.Padding(0)
        Me.Carpeta.Name = "Carpeta"
        Me.Carpeta.Size = New System.Drawing.Size(99, 17)
        Me.Carpeta.TabIndex = 1
        Me.Carpeta.Text = "..."
        Me.Carpeta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ContadorCarpeta
        '
        Me.ContadorCarpeta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContadorCarpeta.Location = New System.Drawing.Point(99, 0)
        Me.ContadorCarpeta.Margin = New System.Windows.Forms.Padding(0)
        Me.ContadorCarpeta.Name = "ContadorCarpeta"
        Me.ContadorCarpeta.Size = New System.Drawing.Size(100, 17)
        Me.ContadorCarpeta.TabIndex = 2
        Me.ContadorCarpeta.Text = "0 - 0"
        Me.ContadorCarpeta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Archivo
        '
        Me.Archivo.AutoEllipsis = True
        Me.Archivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Archivo.Location = New System.Drawing.Point(0, 0)
        Me.Archivo.Margin = New System.Windows.Forms.Padding(0)
        Me.Archivo.Name = "Archivo"
        Me.Archivo.Size = New System.Drawing.Size(120, 17)
        Me.Archivo.TabIndex = 3
        Me.Archivo.Text = "..."
        Me.Archivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProgresoArchivo
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.ProgresoArchivo, 2)
        Me.ProgresoArchivo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgresoArchivo.Location = New System.Drawing.Point(0, 24)
        Me.ProgresoArchivo.Margin = New System.Windows.Forms.Padding(0)
        Me.ProgresoArchivo.Name = "ProgresoArchivo"
        Me.ProgresoArchivo.Size = New System.Drawing.Size(200, 10)
        Me.ProgresoArchivo.TabIndex = 4
        '
        'TableCarpeta
        '
        Me.TableCarpeta.ColumnCount = 2
        Me.TableCarpeta.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableCarpeta.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableCarpeta.Controls.Add(Me.ProgresoCarpeta, 0, 1)
        Me.TableCarpeta.Controls.Add(Me.ContadorCarpeta, 1, 0)
        Me.TableCarpeta.Controls.Add(Me.Carpeta, 0, 0)
        Me.TableCarpeta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableCarpeta.Location = New System.Drawing.Point(3, 3)
        Me.TableCarpeta.Name = "TableCarpeta"
        Me.TableCarpeta.RowCount = 2
        Me.TableCarpeta.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableCarpeta.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableCarpeta.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableCarpeta.Size = New System.Drawing.Size(199, 34)
        Me.TableCarpeta.TabIndex = 3
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Archivo, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ProgresoArchivo, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ContadorArchivo, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(208, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(200, 34)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'ContadorArchivo
        '
        Me.ContadorArchivo.AutoSize = True
        Me.ContadorArchivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContadorArchivo.Location = New System.Drawing.Point(120, 0)
        Me.ContadorArchivo.Margin = New System.Windows.Forms.Padding(0)
        Me.ContadorArchivo.Name = "ContadorArchivo"
        Me.ContadorArchivo.Size = New System.Drawing.Size(80, 17)
        Me.ContadorArchivo.TabIndex = 5
        Me.ContadorArchivo.Text = "0 - 0"
        Me.ContadorArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableUc
        '
        Me.TableUc.ColumnCount = 2
        Me.TableUc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableUc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableUc.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableUc.Controls.Add(Me.TableCarpeta, 0, 0)
        Me.TableUc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableUc.Location = New System.Drawing.Point(0, 0)
        Me.TableUc.Name = "TableUc"
        Me.TableUc.RowCount = 1
        Me.TableUc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableUc.Size = New System.Drawing.Size(411, 40)
        Me.TableUc.TabIndex = 7
        '
        'UcAnalizador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableUc)
        Me.Name = "UcAnalizador"
        Me.Size = New System.Drawing.Size(411, 40)
        Me.TableCarpeta.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableUc.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Carpeta As Label
    Public WithEvents ProgresoCarpeta As ProgressBar
    Public WithEvents ContadorCarpeta As Label
    Public WithEvents Archivo As Label
    Public WithEvents ProgresoArchivo As ProgressBar
    Friend WithEvents TableCarpeta As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Public WithEvents ContadorArchivo As Label
    Friend WithEvents TableUc As TableLayoutPanel
End Class
