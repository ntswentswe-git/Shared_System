Imports System.Data.Odbc
Public Class changepass
    Dim con As New OdbcConnection("Dsn=nyangara;uid=root")
    Dim cmd As New OdbcCommand
    Private Sub WindowsUIButtonPanel1_Click(sender As Object, e As EventArgs) Handles WindowsUIButtonPanel1.Click
        savepass()
    End Sub
    Private Sub savepass()
        Try
            If newpassword.Text = "" And confirmpass.Text = "" Then
                MsgBox("PASSWORD CANNOT BE EMPTY")
            ElseIf newpassword.Text.Length < 8 Then
                MsgBox("PASSWORD TOO SHORT")
                clearpass()
            ElseIf newpassword.Text = confirmpass.Text Then
                con.Open()
                cmd = New OdbcCommand("update users set password='" & newpassword.Text & "' where username='" + MainMenu.TextBox2.Text + "' ", con)
                cmd.ExecuteReader(CommandBehavior.CloseConnection)
                MessageBox.Show("New Password Saved")
                con.Close()
                Me.Dispose()
            Else
                MsgBox("Password doesn't match")
                clearpass()
            End If
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub clearpass()
        newpassword.Text = ""
        confirmpass.Text = ""
    End Sub
End Class