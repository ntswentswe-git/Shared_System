Imports System.Data.Odbc
Imports Telerik.WinControls
Public Class Form1
    Dim con As New OdbcConnection("Dsn=nyangara;uid=root")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadTextBox1.Focus()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        login()
    End Sub
    Private Sub login()
        Try
            con.Open()
            Dim password As String
            Dim cmd As New OdbcCommand
            password = txtPassword.Text
            cmd = New OdbcCommand("Select user_role, full_name from users where username='" + RadTextBox1.Text + "' and password = '" + txtPassword.Text + "'", con)
            Dim result As String = cmd.ExecuteScalar
            con.Close()
            Timer1.Interval = 1000
            Timer1.Start()
            If result = "ADMINISTRATOR" Then
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
                MessageBox.Show("LOGIN SUCCESSFUL : ADMINISTRATOR", "NYANGARA SYSTEM.........................", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MainMenu.TextBox1.Text = Me.txtUsername.Text.ToString
                filltxtboxes()
                RadTextBox1.Clear()
                txtPassword.Clear()
                MainMenu.Show()
                Me.Hide()
            ElseIf result = "PRODUCTION AND SALES" Then
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
                MessageBox.Show("LOGIN SUCCESSFUL : PRODUCTION AND SALES MANAGER ", "NYANGARA SYSTEM.............................", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MainMenu.TextBox1.Text = Me.txtUsername.Text.ToString
                filltxtboxes()
                RadTextBox1.Clear()
                txtPassword.Clear()
                MainMenu.NavCash.Tile.Visible = False
                MainMenu.NavSettings.Tile.Visible = False
                MainMenu.NavEmployees.Tile.Visible = False
                MainMenu.Show()
                Me.Hide()
            ElseIf result = "HR MANAGER" Then
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
                MessageBox.Show("LOGIN SUCCESSFUL : HR MANAGER", "NYANGARA SYSTEM.............................", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MainMenu.TextBox1.Text = Me.txtUsername.Text.ToString
                filltxtboxes()
                RadTextBox1.Clear()
                txtPassword.Clear()
                MainMenu.NavCash.Tile.Visible = False
                MainMenu.NavSettings.Tile.Visible = False
                MainMenu.NavPurchases.Tile.Visible = False
                MainMenu.NavSales.Tile.Visible = False
                MainMenu.NavInvoices.Tile.Visible = False
                MainMenu.Show()
                Me.Hide()
            ElseIf RadTextBox1.Text = "" Or txtPassword.Text = "" Then
                MessageBox.Show("ENTER CREDENTIALS", "NYANGARA SYSTEM.........................", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("INVALID LOGIN ! : ", "NYANGARA  SYSTEM.............................", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                lblerror.Visible = True
            End If
        Catch ex As OdbcException
            con.Close()
            MsgBox(ex.Message)
        End Try
        con.Close()
        'End If
    End Sub
    Private Sub filltxtboxes()
        con.Open()
        Using con
            Dim accsearch As String = RadTextBox1.Text()
            Dim cmdsearch As OdbcCommand = New OdbcCommand("select * from users where username='" + RadTextBox1.Text + "' and password = '" + txtPassword.Text + "'", con)
            Dim rd As OdbcDataReader = cmdsearch.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                MainMenu.TextBox1.Text = rd("full_name")
                MainMenu.TextBox2.Text = rd("username")
                MainMenu.TextBox3.Text = rd("password")
                MainMenu.sessionlogged.Text = rd("user_role")
            End If
        End Using
        con.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub WindowsUIButtonPanel1_Click(sender As Object, e As EventArgs) Handles WindowsUIButtonPanel1.Click
        Try
            con.Open()
        Catch ES As OdbcException
            RadMessageBox.SetThemeName("Desert")
            Dim ds As DialogResult = RadMessageBox.Show(Me, "NOT CONNECTED TO SERVER....please go to programs and open Xampp then start Apache and MySql service and try again", "GoLocal", MessageBoxButtons.OK, RadMessageIcon.Info)
            Me.Text = ds.ToString()
            Application.Exit()
        End Try
        CHECKSERVER()
    End Sub
    Private Sub CHECKSERVER()
        If con.State = ConnectionState.Open Then
            RadMessageBox.Show("CONNECTED")
            con.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MainMenu.Show()
        Me.Hide()
    End Sub
End Class
