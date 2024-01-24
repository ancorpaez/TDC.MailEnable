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
        Me.Progreso = New System.Windows.Forms.ProgressBar()
        Me.Etiqueta = New System.Windows.Forms.Label()
        Me.Contador = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Progreso
        '
        Me.Progreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Progreso.Location = New System.Drawing.Point(68, 0)
        Me.Progreso.Name = "Progreso"
        Me.Progreso.Size = New System.Drawing.Size(85, 139)
        Me.Progreso.TabIndex = 0
        '
        'Etiqueta
        '
        Me.Etiqueta.Dock = System.Windows.Forms.DockStyle.Left
        Me.Etiqueta.Location = New System.Drawing.Point(0, 0)
        Me.Etiqueta.Name = "Etiqueta"
        Me.Etiqueta.Size = New System.Drawing.Size(68, 139)
        Me.Etiqueta.TabIndex = 1
        Me.Etiqueta.Text = "..."
        Me.Etiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Contador
        '
        Me.Contador.Dock = System.Windows.Forms.DockStyle.Right
        Me.Contador.Location = New System.Drawing.Point(153, 0)
        Me.Contador.Name = "Contador"
        Me.Contador.Size = New System.Drawing.Size(158, 139)
        Me.Contador.TabIndex = 2
        Me.Contador.Text = "0"
        Me.Contador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UcAnalizador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Progreso)
        Me.Controls.Add(Me.Etiqueta)
        Me.Controls.Add(Me.Contador)
        Me.Name = "UcAnalizador"
        Me.Size = New System.Drawing.Size(311, 139)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Etiqueta As Label
    Public WithEvents Progreso As ProgressBar
    Public WithEvents Contador As Label
End Class
