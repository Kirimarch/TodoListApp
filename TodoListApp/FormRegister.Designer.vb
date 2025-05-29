<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRegister
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblConfirm = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.lnkLogin = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(142, 24)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(147, 45)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Register"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.Location = New System.Drawing.Point(62, 110)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(94, 23)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username:"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(65, 160)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(91, 23)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "password:"
        '
        'lblConfirm
        '
        Me.lblConfirm.AutoSize = True
        Me.lblConfirm.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirm.Location = New System.Drawing.Point(-3, 213)
        Me.lblConfirm.Name = "lblConfirm"
        Me.lblConfirm.Size = New System.Drawing.Size(159, 23)
        Me.lblConfirm.TabIndex = 3
        Me.lblConfirm.Text = "confirm password:"
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(162, 103)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUsername.Size = New System.Drawing.Size(275, 30)
        Me.txtUsername.TabIndex = 4
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(162, 153)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPassword.Size = New System.Drawing.Size(275, 30)
        Me.txtPassword.TabIndex = 5
        '
        'txtConfirm
        '
        Me.txtConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfirm.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirm.Location = New System.Drawing.Point(162, 206)
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtConfirm.Size = New System.Drawing.Size(275, 30)
        Me.txtConfirm.TabIndex = 6
        '
        'btnRegister
        '
        Me.btnRegister.Font = New System.Drawing.Font("Segoe UI", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegister.Location = New System.Drawing.Point(120, 261)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(189, 49)
        Me.btnRegister.TabIndex = 7
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'lnkLogin
        '
        Me.lnkLogin.AutoSize = True
        Me.lnkLogin.Location = New System.Drawing.Point(159, 331)
        Me.lnkLogin.Name = "lnkLogin"
        Me.lnkLogin.Size = New System.Drawing.Size(88, 16)
        Me.lnkLogin.TabIndex = 8
        Me.lnkLogin.TabStop = True
        Me.lnkLogin.Text = "Back to Login"
        '
        'FormRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 424)
        Me.Controls.Add(Me.lnkLogin)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.txtConfirm)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblConfirm)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "FormRegister"
        Me.Text = "Register"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblConfirm As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtConfirm As TextBox
    Friend WithEvents btnRegister As Button
    Friend WithEvents lnkLogin As LinkLabel
End Class
