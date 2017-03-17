<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Authentication
    Inherits Telerik.WinControls.UI.ShapedForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Authentication))
        Me.RoundRectShapeForm = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.RoundRectShapeTitle = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.RadTitleBar1 = New Telerik.WinControls.UI.RadTitleBar()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadTextBox1 = New Telerik.WinControls.UI.RadTextBox()
        Me.RadTextBox2 = New Telerik.WinControls.UI.RadTextBox()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.RadTitleBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadTextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadTextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RoundRectShapeTitle
        '
        Me.RoundRectShapeTitle.BottomLeftRounded = False
        Me.RoundRectShapeTitle.BottomRightRounded = False
        '
        'RadTitleBar1
        '
        Me.RadTitleBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadTitleBar1.Location = New System.Drawing.Point(1, 1)
        Me.RadTitleBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.RadTitleBar1.Name = "RadTitleBar1"
        '
        '
        '
        Me.RadTitleBar1.RootElement.ApplyShapeToControl = True
        Me.RadTitleBar1.RootElement.Shape = Me.RoundRectShapeTitle
        Me.RadTitleBar1.Size = New System.Drawing.Size(817, 28)
        Me.RadTitleBar1.TabIndex = 0
        Me.RadTitleBar1.TabStop = False
        Me.RadTitleBar1.Text = resources.GetString("RadTitleBar1.Text")
        '
        'RadLabel1
        '
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI", 12.25!)
        Me.RadLabel1.Location = New System.Drawing.Point(188, 78)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(390, 32)
        Me.RadLabel1.TabIndex = 1
        Me.RadLabel1.Text = "Administrator Account Required to Login"
        '
        'RadTextBox1
        '
        Me.RadTextBox1.Location = New System.Drawing.Point(208, 128)
        Me.RadTextBox1.Name = "RadTextBox1"
        Me.RadTextBox1.NullText = "Enter Username"
        Me.RadTextBox1.Size = New System.Drawing.Size(331, 24)
        Me.RadTextBox1.TabIndex = 2
        '
        'RadTextBox2
        '
        Me.RadTextBox2.Location = New System.Drawing.Point(208, 175)
        Me.RadTextBox2.Name = "RadTextBox2"
        Me.RadTextBox2.NullText = "Enter Password"
        Me.RadTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.RadTextBox2.Size = New System.Drawing.Size(331, 24)
        Me.RadTextBox2.TabIndex = 3
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(297, 222)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(164, 35)
        Me.RadButton1.TabIndex = 4
        Me.RadButton1.Text = "Sign In"
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(176, 291)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(475, 22)
        Me.RadLabel2.TabIndex = 2
        Me.RadLabel2.Text = "All rights reserved: These system is being mantained by Simbarashe Hlanya"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(654, 94)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 84)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(684, 128)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(48, 22)
        Me.TextBox1.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Authentication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 314)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.RadButton1)
        Me.Controls.Add(Me.RadTextBox2)
        Me.Controls.Add(Me.RadTextBox1)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.RadTitleBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "Authentication"
        Me.Shape = Me.RoundRectShapeForm
        Me.Text = resources.GetString("$this.Text")
        CType(Me.RadTitleBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadTextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadTextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RoundRectShapeForm As Telerik.WinControls.RoundRectShape
    Friend WithEvents RoundRectShapeTitle As Telerik.WinControls.RoundRectShape
    Friend WithEvents RadTitleBar1 As Telerik.WinControls.UI.RadTitleBar
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadTextBox1 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadTextBox2 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class

