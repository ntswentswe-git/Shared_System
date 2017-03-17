Imports System.Data.Odbc
Public Class Authentication
    Dim con As New OdbcConnection("Dsn=nyangara;uid=root")
    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        If RadTextBox1.Text = "" Or RadTextBox2.Text = "" Then
            MessageBox.Show("Enter Credentials to login")
        Else
            login()
        End If
    End Sub
    Public Sub messagee()
        MsgBox("oops")
    End Sub
    Private Sub login()
        Try
            con.Open()
            Dim password As String
            Dim cmd As New OdbcCommand
            password = RadTextBox2.Text
            cmd = New OdbcCommand("Select user_role from users where username='" + RadTextBox1.Text + "' and password = '" + password + "'", con)
            Dim result As String = cmd.ExecuteScalar
            con.Close()
            If result = "ADMINISTRATOR" Then
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
                MessageBox.Show("WELCOME TO CASH SECTION: ADMINISTRATOR", "NYANGARA SYSTEM.........................", MessageBoxButtons.OK, MessageBoxIcon.Information)
                RadTextBox1.Clear()
                RadTextBox2.Clear()
                cash.Show()
                Me.Hide()
            Else
                MessageBox.Show("Invalid Login: >> You don't have rights to view this section", "NYANGARA SYSTEM.........................", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
            End If
        Catch EX As OdbcException
            MsgBox(EX.Message)
        End Try
    End Sub

    Private Sub Authentication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadButton1.Focus()
    End Sub
End Class
