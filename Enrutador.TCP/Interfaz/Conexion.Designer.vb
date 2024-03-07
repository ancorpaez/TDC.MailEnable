Namespace Interfaz
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class Conexion
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
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblConexion = New System.Windows.Forms.Label()
            Me.lblTiempo = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.22078!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.77922!))
            Me.TableLayoutPanel1.Controls.Add(Me.lblConexion, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblTiempo, 1, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(1, 1)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 1
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(177, 24)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'lblConexion
            '
            Me.lblConexion.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.lblConexion.AutoSize = True
            Me.lblConexion.Location = New System.Drawing.Point(3, 5)
            Me.lblConexion.Name = "lblConexion"
            Me.lblConexion.Size = New System.Drawing.Size(121, 13)
            Me.lblConexion.TabIndex = 0
            Me.lblConexion.Text = "999.999.999.999:99999"
            '
            'lblTiempo
            '
            Me.lblTiempo.Anchor = System.Windows.Forms.AnchorStyles.Left
            Me.lblTiempo.AutoSize = True
            Me.lblTiempo.Location = New System.Drawing.Point(143, 5)
            Me.lblTiempo.Name = "lblTiempo"
            Me.lblTiempo.Size = New System.Drawing.Size(31, 13)
            Me.lblTiempo.TabIndex = 1
            Me.lblTiempo.Text = "9999"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.Silver
            Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
            Me.Panel1.Size = New System.Drawing.Size(179, 26)
            Me.Panel1.TabIndex = 2
            '
            'Conexion
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(179, 26)
            Me.ControlBox = False
            Me.Controls.Add(Me.Panel1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "Conexion"
            Me.Text = "Conexion"
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents lblConexion As Label
        Friend WithEvents lblTiempo As Label
        Friend WithEvents Panel1 As Panel
    End Class
End Namespace