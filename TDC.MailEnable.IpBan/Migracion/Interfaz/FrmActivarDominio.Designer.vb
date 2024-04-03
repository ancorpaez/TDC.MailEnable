Namespace Migracion.Interfaz
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmActivarDominio
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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lstDominios = New System.Windows.Forms.ListView()
            Me.cDominios = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.txtPuerto = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtServidorRemoto = New System.Windows.Forms.TextBox()
            Me.btnAceptar = New System.Windows.Forms.Button()
            Me.BtnCancelar = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.chkSSL = New System.Windows.Forms.CheckBox()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.lstDominios)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(348, 312)
            Me.Panel1.TabIndex = 0
            '
            'lstDominios
            '
            Me.lstDominios.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cDominios})
            Me.lstDominios.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstDominios.FullRowSelect = True
            Me.lstDominios.HideSelection = False
            Me.lstDominios.Location = New System.Drawing.Point(0, 0)
            Me.lstDominios.Name = "lstDominios"
            Me.lstDominios.Size = New System.Drawing.Size(348, 312)
            Me.lstDominios.TabIndex = 0
            Me.lstDominios.UseCompatibleStateImageBehavior = False
            Me.lstDominios.View = System.Windows.Forms.View.Details
            '
            'cDominios
            '
            Me.cDominios.Text = "Dominios"
            Me.cDominios.Width = 326
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.chkSSL)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.txtPuerto)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.txtServidorRemoto)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel2.Location = New System.Drawing.Point(0, 312)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(348, 57)
            Me.Panel2.TabIndex = 2
            '
            'txtPuerto
            '
            Me.txtPuerto.Location = New System.Drawing.Point(267, 19)
            Me.txtPuerto.Name = "txtPuerto"
            Me.txtPuerto.Size = New System.Drawing.Size(48, 20)
            Me.txtPuerto.TabIndex = 3
            Me.txtPuerto.Text = "143"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(264, 3)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(38, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Puerto"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(3, 3)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(81, 13)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Servidor remoto"
            '
            'txtServidorRemoto
            '
            Me.txtServidorRemoto.Location = New System.Drawing.Point(6, 19)
            Me.txtServidorRemoto.Name = "txtServidorRemoto"
            Me.txtServidorRemoto.Size = New System.Drawing.Size(255, 20)
            Me.txtServidorRemoto.TabIndex = 0
            '
            'btnAceptar
            '
            Me.btnAceptar.Location = New System.Drawing.Point(182, 375)
            Me.btnAceptar.Name = "btnAceptar"
            Me.btnAceptar.Size = New System.Drawing.Size(73, 23)
            Me.btnAceptar.TabIndex = 3
            Me.btnAceptar.Text = "Aceptar"
            Me.btnAceptar.UseVisualStyleBackColor = True
            '
            'BtnCancelar
            '
            Me.BtnCancelar.Location = New System.Drawing.Point(263, 375)
            Me.BtnCancelar.Name = "BtnCancelar"
            Me.BtnCancelar.Size = New System.Drawing.Size(73, 23)
            Me.BtnCancelar.TabIndex = 4
            Me.BtnCancelar.Text = "Cancelar"
            Me.BtnCancelar.UseVisualStyleBackColor = True
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(318, 3)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(27, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "SSL"
            '
            'chkSSL
            '
            Me.chkSSL.AutoSize = True
            Me.chkSSL.Location = New System.Drawing.Point(321, 22)
            Me.chkSSL.Name = "chkSSL"
            Me.chkSSL.Size = New System.Drawing.Size(15, 14)
            Me.chkSSL.TabIndex = 5
            Me.chkSSL.UseVisualStyleBackColor = True
            '
            'FrmActivarDominio
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(348, 409)
            Me.Controls.Add(Me.BtnCancelar)
            Me.Controls.Add(Me.btnAceptar)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "FrmActivarDominio"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "FrmActivarDominio"
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents lstDominios As ListView
        Friend WithEvents cDominios As ColumnHeader
        Friend WithEvents Panel2 As Panel
        Friend WithEvents txtPuerto As TextBox
        Friend WithEvents Label2 As Label
        Friend WithEvents Label1 As Label
        Friend WithEvents txtServidorRemoto As TextBox
        Friend WithEvents btnAceptar As Button
        Friend WithEvents BtnCancelar As Button
        Friend WithEvents chkSSL As CheckBox
        Friend WithEvents Label3 As Label
    End Class
End Namespace