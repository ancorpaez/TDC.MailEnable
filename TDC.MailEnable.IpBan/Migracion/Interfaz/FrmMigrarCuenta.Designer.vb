Namespace Migracion.Interfaz
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FrmMigrarCuenta
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
            Me.BtnCancelar = New System.Windows.Forms.Button()
            Me.BtnAceptar = New System.Windows.Forms.Button()
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.lstDominios = New System.Windows.Forms.ListView()
            Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.lstCuentas = New System.Windows.Forms.ListView()
            Me.cCuentas = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.chkTodasLasCuentas = New System.Windows.Forms.CheckBox()
            Me.Label1 = New System.Windows.Forms.Label()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'BtnCancelar
            '
            Me.BtnCancelar.Location = New System.Drawing.Point(659, 10)
            Me.BtnCancelar.Name = "BtnCancelar"
            Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
            Me.BtnCancelar.TabIndex = 2
            Me.BtnCancelar.Text = "Cancelar"
            Me.BtnCancelar.UseVisualStyleBackColor = True
            '
            'BtnAceptar
            '
            Me.BtnAceptar.Enabled = False
            Me.BtnAceptar.Location = New System.Drawing.Point(578, 10)
            Me.BtnAceptar.Name = "BtnAceptar"
            Me.BtnAceptar.Size = New System.Drawing.Size(75, 23)
            Me.BtnAceptar.TabIndex = 3
            Me.BtnAceptar.Text = "Aceptar"
            Me.BtnAceptar.UseVisualStyleBackColor = True
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.lstDominios)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.lstCuentas)
            Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
            Me.SplitContainer1.Size = New System.Drawing.Size(746, 223)
            Me.SplitContainer1.SplitterDistance = 247
            Me.SplitContainer1.TabIndex = 5
            '
            'lstDominios
            '
            Me.lstDominios.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
            Me.lstDominios.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstDominios.FullRowSelect = True
            Me.lstDominios.GridLines = True
            Me.lstDominios.HideSelection = False
            Me.lstDominios.Location = New System.Drawing.Point(0, 0)
            Me.lstDominios.MultiSelect = False
            Me.lstDominios.Name = "lstDominios"
            Me.lstDominios.Size = New System.Drawing.Size(247, 223)
            Me.lstDominios.TabIndex = 1
            Me.lstDominios.UseCompatibleStateImageBehavior = False
            Me.lstDominios.View = System.Windows.Forms.View.Details
            '
            'ColumnHeader1
            '
            Me.ColumnHeader1.Text = "Dominios"
            Me.ColumnHeader1.Width = 239
            '
            'lstCuentas
            '
            Me.lstCuentas.CheckBoxes = True
            Me.lstCuentas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cCuentas})
            Me.lstCuentas.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstCuentas.FullRowSelect = True
            Me.lstCuentas.GridLines = True
            Me.lstCuentas.HideSelection = False
            Me.lstCuentas.Location = New System.Drawing.Point(22, 0)
            Me.lstCuentas.Name = "lstCuentas"
            Me.lstCuentas.Size = New System.Drawing.Size(473, 223)
            Me.lstCuentas.TabIndex = 2
            Me.lstCuentas.UseCompatibleStateImageBehavior = False
            Me.lstCuentas.View = System.Windows.Forms.View.Details
            '
            'cCuentas
            '
            Me.cCuentas.Text = "Cuentas"
            Me.cCuentas.Width = 480
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.BtnCancelar)
            Me.Panel2.Controls.Add(Me.BtnAceptar)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel2.Location = New System.Drawing.Point(0, 223)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(746, 41)
            Me.Panel2.TabIndex = 6
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.chkTodasLasCuentas)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(22, 223)
            Me.Panel1.TabIndex = 3
            '
            'chkTodasLasCuentas
            '
            Me.chkTodasLasCuentas.AutoSize = True
            Me.chkTodasLasCuentas.Enabled = False
            Me.chkTodasLasCuentas.Location = New System.Drawing.Point(4, 7)
            Me.chkTodasLasCuentas.Name = "chkTodasLasCuentas"
            Me.chkTodasLasCuentas.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkTodasLasCuentas.Size = New System.Drawing.Size(15, 14)
            Me.chkTodasLasCuentas.TabIndex = 0
            Me.chkTodasLasCuentas.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Black
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(0, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(1, 223)
            Me.Label1.TabIndex = 1
            '
            'FrmMigrarCuenta
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(746, 264)
            Me.Controls.Add(Me.SplitContainer1)
            Me.Controls.Add(Me.Panel2)
            Me.Name = "FrmMigrarCuenta"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "FrmMigrarCuenta"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents BtnCancelar As Button
        Friend WithEvents BtnAceptar As Button
        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents Panel2 As Panel
        Friend WithEvents lstDominios As ListView
        Friend WithEvents lstCuentas As ListView
        Friend WithEvents ColumnHeader1 As ColumnHeader
        Friend WithEvents cCuentas As ColumnHeader
        Friend WithEvents Panel1 As Panel
        Friend WithEvents chkTodasLasCuentas As CheckBox
        Friend WithEvents Label1 As Label
    End Class
End Namespace