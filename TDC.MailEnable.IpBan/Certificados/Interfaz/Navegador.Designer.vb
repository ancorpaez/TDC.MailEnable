Namespace Certificados.Interfaz
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class Navegador
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
            Me.WB = New Microsoft.Web.WebView2.WinForms.WebView2()
            CType(Me.WB, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'WB
            '
            Me.WB.AllowExternalDrop = True
            Me.WB.CreationProperties = Nothing
            Me.WB.DefaultBackgroundColor = System.Drawing.Color.White
            Me.WB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.WB.Location = New System.Drawing.Point(0, 0)
            Me.WB.Name = "WB"
            Me.WB.Size = New System.Drawing.Size(800, 450)
            Me.WB.Source = New System.Uri("about:blank", System.UriKind.Absolute)
            Me.WB.TabIndex = 0
            Me.WB.ZoomFactor = 1.0R
            '
            'Navegador
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(800, 450)
            Me.Controls.Add(Me.WB)
            Me.Name = "Navegador"
            Me.Text = "Navegador"
            CType(Me.WB, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents WB As Microsoft.Web.WebView2.WinForms.WebView2
    End Class
End Namespace