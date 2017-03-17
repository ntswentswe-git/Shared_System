<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class changepass
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.WindowsUIButtonPanel2 = New DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel()
        Me.WindowsUIButtonPanel1 = New DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel()
        Me.confirmpass = New System.Windows.Forms.TextBox()
        Me.newpassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.BackColor = System.Drawing.Color.Transparent
        Me.label9.ForeColor = System.Drawing.SystemColors.InfoText
        Me.label9.Location = New System.Drawing.Point(181, 317)
        Me.label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(478, 17)
        Me.label9.TabIndex = 276
        Me.label9.Text = "All rights reserved ::: This system is mantained by ICT--Simbarashe Hlanya"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.Location = New System.Drawing.Point(-1, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(887, 10)
        Me.Panel1.TabIndex = 275
        '
        'WindowsUIButtonPanel2
        '
        Me.WindowsUIButtonPanel2.Buttons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraBars.Docking2010.WindowsUIButton("back", DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton), New DevExpress.XtraBars.Docking2010.WindowsUIButton()})
        Me.WindowsUIButtonPanel2.Location = New System.Drawing.Point(560, 235)
        Me.WindowsUIButtonPanel2.Name = "WindowsUIButtonPanel2"
        Me.WindowsUIButtonPanel2.Size = New System.Drawing.Size(75, 64)
        Me.WindowsUIButtonPanel2.TabIndex = 274
        Me.WindowsUIButtonPanel2.Text = "WindowsUIButtonPanel2"
        '
        'WindowsUIButtonPanel1
        '
        Me.WindowsUIButtonPanel1.Buttons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraBars.Docking2010.WindowsUIButton("save", DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton), New DevExpress.XtraBars.Docking2010.WindowsUIButton()})
        Me.WindowsUIButtonPanel1.Location = New System.Drawing.Point(393, 235)
        Me.WindowsUIButtonPanel1.Name = "WindowsUIButtonPanel1"
        Me.WindowsUIButtonPanel1.Size = New System.Drawing.Size(75, 64)
        Me.WindowsUIButtonPanel1.TabIndex = 273
        Me.WindowsUIButtonPanel1.Text = "WindowsUIButtonPanel1"
        '
        'confirmpass
        '
        Me.confirmpass.Location = New System.Drawing.Point(393, 192)
        Me.confirmpass.Name = "confirmpass"
        Me.confirmpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.confirmpass.Size = New System.Drawing.Size(242, 22)
        Me.confirmpass.TabIndex = 272
        '
        'newpassword
        '
        Me.newpassword.Location = New System.Drawing.Point(393, 135)
        Me.newpassword.Name = "newpassword"
        Me.newpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.newpassword.Size = New System.Drawing.Size(242, 22)
        Me.newpassword.TabIndex = 271
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 198)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(199, 17)
        Me.Label2.TabIndex = 270
        Me.Label2.Text = "RE-ENTER NEW PASSWORD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 17)
        Me.Label1.TabIndex = 269
        Me.Label1.Text = "ENTER NEW PASSWORD"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(267, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(351, 46)
        Me.Label3.TabIndex = 277
        Me.Label3.Text = "Nyangara System"
        '
        'changepass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 343)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.WindowsUIButtonPanel2)
        Me.Controls.Add(Me.WindowsUIButtonPanel1)
        Me.Controls.Add(Me.confirmpass)
        Me.Controls.Add(Me.newpassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "changepass"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents WindowsUIButtonPanel2 As DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel
    Friend WithEvents WindowsUIButtonPanel1 As DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel
    Friend WithEvents confirmpass As System.Windows.Forms.TextBox
    Friend WithEvents newpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
