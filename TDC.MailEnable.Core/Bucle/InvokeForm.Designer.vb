Namespace Bucle
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InvokeForm
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvokeForm))
            Me.BtnDetenerBackground = New System.Windows.Forms.Button()
            Me.BtnDetenerForeground = New System.Windows.Forms.Button()
            Me.BtnDetenerEndground = New System.Windows.Forms.Button()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.lblName = New System.Windows.Forms.Label()
            Me.FlowControls = New System.Windows.Forms.FlowLayoutPanel()
            Me.Status = New System.Windows.Forms.StatusStrip()
            Me.ToolStripOptions = New System.Windows.Forms.ToolStrip()
            Me.ToolOptionsChange = New System.Windows.Forms.ToolStripButton()
            Me.ToolOptionsClose = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.ToolName = New System.Windows.Forms.ToolStripLabel()
            Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.ToolContador = New System.Windows.Forms.ToolStripLabel()
            Me.ToolSpace = New System.Windows.Forms.ToolStripLabel()
            Me.ToolIntervalo = New System.Windows.Forms.ToolStripLabel()
            Me.FlowControls.SuspendLayout()
            Me.ToolStripOptions.SuspendLayout()
            Me.SuspendLayout()
            '
            'BtnDetenerBackground
            '
            Me.BtnDetenerBackground.BackColor = System.Drawing.Color.DarkGreen
            Me.BtnDetenerBackground.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
            Me.BtnDetenerBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.BtnDetenerBackground.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.BtnDetenerBackground.ForeColor = System.Drawing.Color.White
            Me.BtnDetenerBackground.Location = New System.Drawing.Point(408, 0)
            Me.BtnDetenerBackground.Margin = New System.Windows.Forms.Padding(0)
            Me.BtnDetenerBackground.Name = "BtnDetenerBackground"
            Me.BtnDetenerBackground.Size = New System.Drawing.Size(25, 25)
            Me.BtnDetenerBackground.TabIndex = 0
            Me.BtnDetenerBackground.TabStop = False
            Me.BtnDetenerBackground.Text = "BtnDetenerBackground"
            Me.ToolTip.SetToolTip(Me.BtnDetenerBackground, "Detener en BackGround")
            Me.BtnDetenerBackground.UseVisualStyleBackColor = False
            '
            'BtnDetenerForeground
            '
            Me.BtnDetenerForeground.BackColor = System.Drawing.Color.DarkGreen
            Me.BtnDetenerForeground.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
            Me.BtnDetenerForeground.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.BtnDetenerForeground.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.BtnDetenerForeground.ForeColor = System.Drawing.Color.White
            Me.BtnDetenerForeground.Location = New System.Drawing.Point(383, 0)
            Me.BtnDetenerForeground.Margin = New System.Windows.Forms.Padding(0)
            Me.BtnDetenerForeground.Name = "BtnDetenerForeground"
            Me.BtnDetenerForeground.Size = New System.Drawing.Size(25, 25)
            Me.BtnDetenerForeground.TabIndex = 1
            Me.BtnDetenerForeground.TabStop = False
            Me.BtnDetenerForeground.Text = "BtnDetenerForeground"
            Me.ToolTip.SetToolTip(Me.BtnDetenerForeground, "Detener en ForeGround")
            Me.BtnDetenerForeground.UseVisualStyleBackColor = False
            '
            'BtnDetenerEndground
            '
            Me.BtnDetenerEndground.BackColor = System.Drawing.Color.DarkGreen
            Me.BtnDetenerEndground.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
            Me.BtnDetenerEndground.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.BtnDetenerEndground.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.BtnDetenerEndground.ForeColor = System.Drawing.Color.White
            Me.BtnDetenerEndground.Location = New System.Drawing.Point(358, 0)
            Me.BtnDetenerEndground.Margin = New System.Windows.Forms.Padding(0)
            Me.BtnDetenerEndground.Name = "BtnDetenerEndground"
            Me.BtnDetenerEndground.Size = New System.Drawing.Size(25, 25)
            Me.BtnDetenerEndground.TabIndex = 2
            Me.BtnDetenerEndground.TabStop = False
            Me.BtnDetenerEndground.Text = "BtnDetenerEndground"
            Me.ToolTip.SetToolTip(Me.BtnDetenerEndground, "Detener en EndGround")
            Me.BtnDetenerEndground.UseVisualStyleBackColor = False
            '
            'lblCount
            '
            Me.lblCount.BackColor = System.Drawing.Color.LightGray
            Me.lblCount.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblCount.Location = New System.Drawing.Point(318, 0)
            Me.lblCount.Margin = New System.Windows.Forms.Padding(0)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(40, 20)
            Me.lblCount.TabIndex = 3
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblName
            '
            Me.lblName.BackColor = System.Drawing.Color.LightGray
            Me.lblName.Location = New System.Drawing.Point(0, 0)
            Me.lblName.Margin = New System.Windows.Forms.Padding(0)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(318, 20)
            Me.lblName.TabIndex = 4
            Me.lblName.Text = "Name"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'FlowControls
            '
            Me.FlowControls.BackColor = System.Drawing.Color.LightGray
            Me.FlowControls.Controls.Add(Me.lblName)
            Me.FlowControls.Controls.Add(Me.lblCount)
            Me.FlowControls.Controls.Add(Me.BtnDetenerEndground)
            Me.FlowControls.Controls.Add(Me.BtnDetenerForeground)
            Me.FlowControls.Controls.Add(Me.BtnDetenerBackground)
            Me.FlowControls.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FlowControls.Location = New System.Drawing.Point(0, 25)
            Me.FlowControls.Name = "FlowControls"
            Me.FlowControls.Size = New System.Drawing.Size(434, 64)
            Me.FlowControls.TabIndex = 5
            '
            'Status
            '
            Me.Status.Location = New System.Drawing.Point(0, 89)
            Me.Status.Name = "Status"
            Me.Status.Size = New System.Drawing.Size(434, 22)
            Me.Status.TabIndex = 6
            Me.Status.Text = "StatusStrip1"
            '
            'ToolStripOptions
            '
            Me.ToolStripOptions.BackColor = System.Drawing.Color.WhiteSmoke
            Me.ToolStripOptions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ToolStripOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolOptionsChange, Me.ToolIntervalo, Me.ToolOptionsClose, Me.ToolStripSeparator1, Me.ToolName, Me.ToolSpace, Me.ToolContador})
            Me.ToolStripOptions.Location = New System.Drawing.Point(0, 0)
            Me.ToolStripOptions.Name = "ToolStripOptions"
            Me.ToolStripOptions.Size = New System.Drawing.Size(434, 25)
            Me.ToolStripOptions.TabIndex = 7
            '
            'ToolOptionsChange
            '
            Me.ToolOptionsChange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ToolOptionsChange.Image = CType(resources.GetObject("ToolOptionsChange.Image"), System.Drawing.Image)
            Me.ToolOptionsChange.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.ToolOptionsChange.Name = "ToolOptionsChange"
            Me.ToolOptionsChange.Size = New System.Drawing.Size(23, 22)
            Me.ToolOptionsChange.Text = "Cambiar"
            '
            'ToolOptionsClose
            '
            Me.ToolOptionsClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.ToolOptionsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ToolOptionsClose.Image = CType(resources.GetObject("ToolOptionsClose.Image"), System.Drawing.Image)
            Me.ToolOptionsClose.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.ToolOptionsClose.Name = "ToolOptionsClose"
            Me.ToolOptionsClose.Size = New System.Drawing.Size(23, 22)
            Me.ToolOptionsClose.Text = "Close"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'ToolName
            '
            Me.ToolName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.ToolName.Name = "ToolName"
            Me.ToolName.Size = New System.Drawing.Size(74, 22)
            Me.ToolName.Text = "Bucle Name"
            '
            'ToolContador
            '
            Me.ToolContador.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.ToolContador.AutoSize = False
            Me.ToolContador.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.ToolContador.Name = "ToolContador"
            Me.ToolContador.Size = New System.Drawing.Size(50, 22)
            Me.ToolContador.Text = "0"
            '
            'ToolSpace
            '
            Me.ToolSpace.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.ToolSpace.AutoSize = False
            Me.ToolSpace.Name = "ToolSpace"
            Me.ToolSpace.Size = New System.Drawing.Size(10, 22)
            '
            'ToolIntervalo
            '
            Me.ToolIntervalo.Name = "ToolIntervalo"
            Me.ToolIntervalo.Size = New System.Drawing.Size(13, 22)
            Me.ToolIntervalo.Text = "0"
            '
            'InvokeForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(434, 111)
            Me.Controls.Add(Me.FlowControls)
            Me.Controls.Add(Me.ToolStripOptions)
            Me.Controls.Add(Me.Status)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "InvokeForm"
            Me.Text = "InvokeForm"
            Me.FlowControls.ResumeLayout(False)
            Me.ToolStripOptions.ResumeLayout(False)
            Me.ToolStripOptions.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents BtnDetenerBackground As Windows.Forms.Button
        Friend WithEvents BtnDetenerForeground As Windows.Forms.Button
        Friend WithEvents BtnDetenerEndground As Windows.Forms.Button
        Friend WithEvents lblCount As Windows.Forms.Label
        Friend WithEvents lblName As Windows.Forms.Label
        Friend WithEvents FlowControls As Windows.Forms.FlowLayoutPanel
        Friend WithEvents Status As Windows.Forms.StatusStrip
        Friend WithEvents ToolStripOptions As Windows.Forms.ToolStrip
        Friend WithEvents ToolOptionsClose As Windows.Forms.ToolStripButton
        Friend WithEvents ToolOptionsChange As Windows.Forms.ToolStripButton
        Friend WithEvents ToolTip As Windows.Forms.ToolTip
        Friend WithEvents ToolName As Windows.Forms.ToolStripLabel
        Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolContador As Windows.Forms.ToolStripLabel
        Friend WithEvents ToolSpace As Windows.Forms.ToolStripLabel
        Friend WithEvents ToolIntervalo As Windows.Forms.ToolStripLabel
    End Class
End Namespace