Namespace Interfaz
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class Frm_PublicarIps
        Inherits System.Windows.Forms.Form

        'Form reemplaza a Dispose para limpiar la lista de componentes.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.Progreso = New System.Windows.Forms.ProgressBar()
            Me.BtnCancelar = New System.Windows.Forms.Button()
            Me.Separado = New System.Windows.Forms.Panel()
            Me.SuspendLayout()
            '
            'Progreso
            '
            Me.Progreso.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Progreso.Location = New System.Drawing.Point(2, 2)
            Me.Progreso.Name = "Progreso"
            Me.Progreso.Size = New System.Drawing.Size(425, 48)
            Me.Progreso.TabIndex = 0
            '
            'BtnCancelar
            '
            Me.BtnCancelar.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnCancelar.Location = New System.Drawing.Point(437, 2)
            Me.BtnCancelar.Name = "BtnCancelar"
            Me.BtnCancelar.Size = New System.Drawing.Size(120, 48)
            Me.BtnCancelar.TabIndex = 1
            Me.BtnCancelar.Text = "Cancelar"
            Me.BtnCancelar.UseVisualStyleBackColor = True
            '
            'Separado
            '
            Me.Separado.Dock = System.Windows.Forms.DockStyle.Right
            Me.Separado.Location = New System.Drawing.Point(427, 2)
            Me.Separado.Name = "Separado"
            Me.Separado.Size = New System.Drawing.Size(10, 48)
            Me.Separado.TabIndex = 2
            '
            'Frm_PublicarIps
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(559, 52)
            Me.ControlBox = False
            Me.Controls.Add(Me.Progreso)
            Me.Controls.Add(Me.Separado)
            Me.Controls.Add(Me.BtnCancelar)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Name = "Frm_PublicarIps"
            Me.Padding = New System.Windows.Forms.Padding(2)
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Progreso As ProgressBar
        Friend WithEvents BtnCancelar As Button
        Friend WithEvents Separado As Panel
    End Class

End Namespace