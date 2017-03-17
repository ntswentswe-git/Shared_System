Imports System.Data.Odbc
Public Class MainMenu
    Dim cmd As New OdbcCommand
    Dim con As New OdbcConnection("Dsn=nyangara;uid=root")
    Private Sub NavLogOut_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles NavLogOut.ElementClick
        reportselection.ShowDialog()
    End Sub

    Private Sub TileItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem1.ItemClick
        Dim result As String = MsgBox("ARE YOU SURE YOU WANT TO LOG-OUT OF SYSTEM?", +vbQuestion + vbYesNoCancel, "    LOG-OUT")
        If result = vbYes Then
            Application.Exit()
        End If
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox6.Text = System.DateTime.Now.ToString

    End Sub

    Private Sub NavPurchases_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles NavPurchases.ElementClick
        Purchases.Show()
        Me.Hide()
    End Sub

    Private Sub NavSales_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles NavSales.ElementClick
        sales.Show()
        Me.Hide()
    End Sub

    Private Sub NavCash_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles NavCash.ElementClick
        Authentication.ShowDialog()
    End Sub

    Private Sub TileItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem2.ItemClick
        changepass.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.ReadOnly = False Then
            TextBox1.ReadOnly = True
            TextBox3.ReadOnly = False
            TextBox2.ReadOnly = True
            TextBox4.ReadOnly = True
        Else
            TextBox1.ReadOnly = False
            TextBox2.ReadOnly = False
            TextBox4.ReadOnly = False
        End If
    End Sub

    Private Sub NavEmployees_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles NavEmployees.ElementClick
        employees.Show()
        Me.Hide()
    End Sub

    Private Sub NavSettings_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles NavSettings.ElementClick
        users.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ShapedForm1.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            System.Diagnostics.Process.Start("Calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            System.Diagnostics.Process.Start("Notepad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            System.Diagnostics.Process.Start("TaskMgr.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            System.Diagnostics.Process.Start("wordpad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If con.State = ConnectionState.Closed Then
            con.ConnectionString = "Dsn=nyangara;uid=root"
            con.Open()
        Else
            Try

                cmd = New OdbcCommand("update users set username ='" & TextBox2.Text & "', password= '" & TextBox3.Text & "', contact ='" & TextBox4.Text & "' WHERE full_name='" + sessionlogged.Text + "' ", con)
                Dim i As Integer
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("submission Updated", MsgBoxStyle.Information, "Update submission")
                Else
                    MsgBox("DETAILS UPDATED", MsgBoxStyle.Critical, "Update clients")

                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                cmd.Dispose()
                con.Close()

            End Try
        End If
        con.Close()
    End Sub

    Private Sub NavInvoices_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles NavInvoices.ElementClick
        stocks.Show()
        Me.Hide()
    End Sub

    Private Sub NavFinancialStatements_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles NavFinancialStatements.ElementClick
        employees.Show()
        Me.Hide()
    End Sub
End Class