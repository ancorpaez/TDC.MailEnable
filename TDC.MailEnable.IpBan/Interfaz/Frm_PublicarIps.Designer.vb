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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PublicarIps))
            Me.Progreso = New System.Windows.Forms.ProgressBar()
            Me.BtnCancelar = New System.Windows.Forms.Button()
            Me.Separado = New System.Windows.Forms.Panel()
            Me.lblIp = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblIndex = New System.Windows.Forms.Label()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.Panel1.SuspendLayout()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Progreso
            '
            Me.Progreso.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Progreso.Location = New System.Drawing.Point(50, 2)
            Me.Progreso.Name = "Progreso"
            Me.Progreso.Size = New System.Drawing.Size(377, 34)
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
            'lblIp
            '
            Me.lblIp.Dock = System.Windows.Forms.DockStyle.Left
            Me.lblIp.Location = New System.Drawing.Point(106, 0)
            Me.lblIp.Name = "lblIp"
            Me.lblIp.Size = New System.Drawing.Size(88, 14)
            Me.lblIp.TabIndex = 3
            Me.lblIp.Text = "255.255.255.255"
            Me.lblIp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.lblIp)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.lblCount)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.lblIndex)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(50, 36)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(377, 14)
            Me.Panel1.TabIndex = 4
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label3.Location = New System.Drawing.Point(194, 0)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(10, 13)
            Me.Label3.TabIndex = 8
            Me.Label3.Text = ")"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(96, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(10, 13)
            Me.Label1.TabIndex = 7
            Me.Label1.Text = "("
            '
            'lblCount
            '
            Me.lblCount.Dock = System.Windows.Forms.DockStyle.Left
            Me.lblCount.Location = New System.Drawing.Point(53, 0)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(43, 14)
            Me.lblCount.TabIndex = 6
            Me.lblCount.Text = "100000"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label2.Location = New System.Drawing.Point(43, 0)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(10, 13)
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "-"
            '
            'lblIndex
            '
            Me.lblIndex.Dock = System.Windows.Forms.DockStyle.Left
            Me.lblIndex.Location = New System.Drawing.Point(0, 0)
            Me.lblIndex.Name = "lblIndex"
            Me.lblIndex.Size = New System.Drawing.Size(43, 14)
            Me.lblIndex.TabIndex = 4
            Me.lblIndex.Text = "100000"
            Me.lblIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'PictureBox1
            '
            Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
            Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
            Me.PictureBox1.Location = New System.Drawing.Point(2, 2)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
            Me.PictureBox1.TabIndex = 5
            Me.PictureBox1.TabStop = False
            '
            'Frm_PublicarIps
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(559, 52)
            Me.ControlBox = False
            Me.Controls.Add(Me.Progreso)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.Separado)
            Me.Controls.Add(Me.BtnCancelar)
            Me.Controls.Add(Me.PictureBox1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "Frm_PublicarIps"
            Me.Padding = New System.Windows.Forms.Padding(2)
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Progreso As ProgressBar
        Friend WithEvents BtnCancelar As Button
        Friend WithEvents Separado As Panel
        Friend WithEvents lblIp As Label
        Friend WithEvents Panel1 As Panel
        Friend WithEvents lblCount As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents lblIndex As Label
        Friend WithEvents Label1 As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents PictureBox1 As PictureBox
    End Class

End Namespace