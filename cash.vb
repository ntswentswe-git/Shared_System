Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO
Public Class cash
    Dim con As New OdbcConnection("Dsn=nyangara;uid=root")
    Dim cmd As New OdbcCommand
    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DetaillViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetaillViewToolStripMenuItem.Click

    End Sub

    Private Sub cash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.SelectedTab = TabPage6
        Label28.Text = MainMenu.TextBox1.Text.ToString
        Label26.Text = System.DateTime.Now.ToString
        Label27.Text = System.DateTime.Today.ToShortDateString
        recorded_by.Text = Label28.Text
        cashinrecby.Text = Label28.Text
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub CashOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashOutToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub CashInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashInToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage4
    End Sub

    Private Sub CashOutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CashOutToolStripMenuItem1.Click
        TabControl1.SelectedTab = TabPage5
    End Sub

    Private Sub DetailedViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailedViewToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Dim result As String = MsgBox("ARE YOU SURE YOU WANT TO LOG-OUT OF SYSTEM?", +vbQuestion + vbYesNoCancel, "    LOG-OUT")
        If result = vbYes Then
            Application.Exit()
        End If
    End Sub

    Private Sub TabularViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TabularViewToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage7
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cashinform.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cashintype.SelectedIndexChanged

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        savecash()
    End Sub
    Private Sub savecash()
        If transaction_information.Text = "" Or amount.Text = "" Or recorded_by.Text = "" Or transaction_type.Text = "" Or payment_form.Text = "" Then
            MessageBox.Show("Fill in details to save", "Nyangara System..................", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                If con.State = ConnectionState.Closed Then
                    con.ConnectionString = "Dsn=nyangara;uid=root"
                    con.Open()
                End If
                Dim cmd As New OdbcCommand("insert into cash_out(`transaction_date`, `date_recorded`, `transaction_information`, `amount`, `recorded_by`, `transaction_type`,`payment_form`)values('" + transaction_date.Value.ToShortDateString + "','" + Label27.Text.ToString + "','" + transaction_information.Text + "','" + amount.Text + "','" + recorded_by.Text + "','" + transaction_type.Text + "','" + payment_form.Text + "')", con)
                cmd.ExecuteReader(CommandBehavior.CloseConnection)
                MessageBox.Show("Details Saved", "Nyangara System...................", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clearcashout()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub clearcashout()
        transaction_date.Value = DateAndTime.Now
        transaction_information.Clear()
        amount.Clear()
        recorded_by.Clear()
        transaction_type.Text = ""
        payment_form.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        savecashin()
    End Sub
    Private Sub savecashin()
        If cashininfo.Text = "" Or cashinamount.Text = "" Or cashinrecby.Text = "" Or cashintype.Text = "" Or cashinform.Text = "" Then
            MessageBox.Show("Fill in details to save", "Nyangara System..................", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                If con.State = ConnectionState.Closed Then
                    con.ConnectionString = "Dsn=nyangara;uid=root"
                    con.Open()
                End If
                Dim cmd As New OdbcCommand("insert into cash_in(`transaction_date`, `date_recorded`, `transaction_information`, `amount`, `recorded_by`, `transaction_type`,`payment_form`)values('" + DateTimePicker1.Value.ToShortDateString + "','" + Label27.Text.ToString + "','" + cashininfo.Text + "','" + cashinamount.Text + "','" + cashinrecby.Text + "','" + cashintype.Text + "','" + cashinform.Text + "')", con)
                cmd.ExecuteReader(CommandBehavior.CloseConnection)
                MessageBox.Show("Details Saved", "Nyangara System...........................", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clearcashin()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub clearcashin()
        transaction_date.Value = DateAndTime.Now
        cashininfo.Clear()
        cashinamount.Clear()
        cashinrecby.Clear()
        cashintype.Text = ""
        cashinform.Text = ""
    End Sub
    Private Sub AUTO_GENERATE_CASHFLOW()
        If con.State = ConnectionState.Closed Then
            con.ConnectionString = "Dsn=nyangara;uid=root"
            con.Open()
        End If
        Using con
            cmd = New OdbcCommand("select amount from cash_out", con)
            Dim myDA As OdbcDataAdapter = New OdbcDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            Dim a As Integer = 0
            myDA.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("NO RECORDS FOUND")
            Else
                Dim totalSum As Integer
                For i As Integer = 0 To dt.Rows.Count - 1
                    totalSum += dt.Rows(i).Item("amount")
                Next
                totalcashoutttt.Text = totalSum.ToString()
            End If
        End Using
        Using con
            con.ConnectionString = "Dsn=nyangara;uid=root"
            cmd = New OdbcCommand("select amount from cash_in ", con)
            Dim myDA As OdbcDataAdapter = New OdbcDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            Dim a As Integer = 0
            myDA.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("NO RECORDS FOUND")
            Else
                Dim totalSum As Integer
                For i As Integer = 0 To dt.Rows.Count - 1
                    totalSum += dt.Rows(i).Item("amount")
                Next
                totalcashinnnn.Text = totalSum.ToString()
                TextBox13.Text = totalSum.ToString()
                CASHFLOW()
            End If
        End Using
        Using con
            con.ConnectionString = "Dsn=nyangara;uid=root"
            Dim DATETYM As Date = DateAndTime.Now.ToString("dd/MM/yyyy")
            cmd = New OdbcCommand("select amount from cash_in where transaction_date= '" & DATETYM & "' ", con)
            Dim myDA As OdbcDataAdapter = New OdbcDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            Dim a As Integer = 0
            myDA.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No day cash in records found")
            Else
                Dim totalSum As Integer
                For i As Integer = 0 To dt.Rows.Count - 1
                    totalSum += dt.Rows(i).Item("amount")
                Next
                dairlycashin.Text = totalSum.ToString()
                CASHFLOW()
            End If
        End Using
        Using con
            con.ConnectionString = "Dsn=nyangara;uid=root"
            Dim DATETYM As Date = DateAndTime.Now.ToString("dd/MM/yyyy")
            cmd = New OdbcCommand("select amount from cash_out where transaction_date='" & DATETYM & "' ", con)
            Dim myDA As OdbcDataAdapter = New OdbcDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            Dim a As Integer = 0
            myDA.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No day cash out records found")
            Else
                Dim totalSum As Integer
                For i As Integer = 0 To dt.Rows.Count - 1
                    totalSum += dt.Rows(i).Item("amount")
                Next
                dairlycashout.Text = totalSum.ToString()
                CASHFLOW()
            End If
        End Using
    End Sub
    Private Sub CASHFLOW()
        Dim cashin As Single = Val(totalcashinnnn.Text)
        Dim cashout As Single = Val(totalcashoutttt.Text)
        Dim balance As Single = Val(cashbal.Text)
        cashbal.Text = cashin - cashout
        If cashin < cashout Then
            status.Text = "LOSS"
            Randomize()
            Label9.ForeColor = Color.FromArgb(255, Rnd() * 255, Rnd() * 255, Rnd() * 255)
        Else
            status.Text = "PROFIT"
            Randomize()
            Label9.ForeColor = Color.FromArgb(255, Rnd() * 255, Rnd() * 255, Rnd() * 255)
        End If
    End Sub
    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter
        AUTO_GENERATE_CASHFLOW()
        Dim totacashin As Single = Val(totalcashinnnn.Text)
        Dim totalcashot As Single = Val(totalcashoutttt.Text)
        Dim dairycashin As Single = Val(dairlycashin.Text)
        Dim dairlcashout As Single = Val(dairlycashout.Text)
        Dim othecashi As Single
        Dim othecashou As Single
        othecashi = totacashin - dairycashin
        othecashou = totalcashot - dairlcashout
        othercashout.Text = othecashou
        othercashin.Text = othecashi

    End Sub

    Private Sub amount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles amount.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Enter numbers only")
            e.Handled = True
            'for no numbers insert and also not after that flipping 8 kkkkkk ntswentswe ma 1
        End If
    End Sub

    Private Sub cashinamount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cashinamount.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Enter numbers only")
            e.Handled = True
            'for no numbers insert and also not after that flipping 8 kkkkkk ntswentswe ma 1
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        con.ConnectionString = ("Dsn=nyangara;uid=root")
        con.Open()
        Try
            Dim cmdload As OdbcCommand = New OdbcCommand("SELECT * from cash_in", con)
            cmdload.CommandType = CommandType.Text
            Dim adapter As New OdbcDataAdapter
            Dim dt As New DataTable
            adapter.SelectCommand = cmdload
            adapter.Fill(dt)
            RadGridView1.DataSource = dt
            con.Close()
            con.Dispose()
        Catch xx As InvalidOperationException
            MsgBox(xx.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        con.ConnectionString = ("Dsn=nyangara;uid=root")
        con.Open()
        Try
            Dim cmdload As OdbcCommand = New OdbcCommand("SELECT * from cash_out", con)
            cmdload.CommandType = CommandType.Text
            Dim adapter As New OdbcDataAdapter
            Dim dt As New DataTable
            adapter.SelectCommand = cmdload
            adapter.Fill(dt)
            RadGridView2.DataSource = dt
            con.Close()
            con.Dispose()
        Catch xx As InvalidOperationException
            MsgBox(xx.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GroupBox16_Enter(sender As Object, e As EventArgs) Handles GroupBox16.Enter
        Using con
            con.ConnectionString = ("Dsn=nyangara;uid=root")
            cmd = New OdbcCommand("select amount from cash_out ", con)
            Dim myDA As OdbcDataAdapter = New OdbcDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            Dim a As Integer = 0
            myDA.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("FAILED TO OPEN DATABASE")
            Else
                Dim totalSum As Integer
                For i As Integer = 0 To dt.Rows.Count - 1
                    totalSum += dt.Rows(i).Item("amount")
                Next
                lblcashout.Text = totalSum.ToString()
            End If
        End Using
        Using con
            con.ConnectionString = ("Dsn=nyangara;uid=root")
            cmd = New OdbcCommand("select amount from cash_in ", con)
            Dim myDA As OdbcDataAdapter = New OdbcDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            Dim a As Integer = 0
            myDA.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("FAILED TO OPEN DATABASE")
            Else
                Dim totalSum As Integer
                For i As Integer = 0 To dt.Rows.Count - 1
                    totalSum += dt.Rows(i).Item("amount")
                Next
                lblcashin.Text = totalSum.ToString()
                Dim cashin As Single = Val(lblcashin.Text)
                Dim cashout As Single = Val(lblcashout.Text)
                Dim balance As Single = Val(lblcashbalance.Text)
                lblcashbalance.Text = cashin - cashout
                If cashin < cashout Then
                    ' Label9.Text = "LOSS"
                    'CheckBox1.Checked = True
                    'CheckBox2.Checked = False
                    RadGroupBox1.Visible = True
                    Label42.Visible = True
                Else
                    'CheckBox2.Checked = True
                    'CheckBox1.Checked = False
                    RadGroupBox1.Visible = False
                    Label42.Visible = False
                End If
            End If
        End Using
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If RadGridView1.RowCount = Nothing Then
            MessageBox.Show("Sorry nothing to export into excel sheet.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application

        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = RadGridView1.RowCount - 1
            colsTotal = RadGridView1.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = RadGridView1.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = RadGridView1.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If RadGridView1.RowCount = Nothing Then
            MessageBox.Show("Sorry nothing to export into excel sheet.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application

        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = RadGridView1.RowCount - 1
            colsTotal = RadGridView1.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = RadGridView1.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = RadGridView1.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub TabPage6_Enter(sender As Object, e As EventArgs) Handles TabPage6.Enter
        Try

            con.ConnectionString = ("Dsn=nyangara;uid=root")
            con.Open()
            cmd = New OdbcCommand("select   Pay_Slip_Number from payslips where Status like '" & "not approved" & "%' ", con)
            Dim myDA As OdbcDataAdapter = New OdbcDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            Dim a As Integer = 0
            myDA.Fill(dt)
            If dt.Rows.Count = 0 Then
                con.Close()
                GroupBox37.Visible = False
                PictureBox6.Visible = False
                ListBox3.Visible = False
            Else
                Do While a < dt.Rows.Count
                    ListBox3.Items.Add(dt.Rows(a).Item("Pay_Slip_Number"))
                    a += 1
                Loop
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        If con.State = ConnectionState.Closed Then
            con.ConnectionString = "Dsn=nyangara;uid=root"
            con.Open()
        End If
        Using con
            Try
                TabControl1.SelectedTab = TabPage8
                Dim accsearch As String = ListBox3.SelectedItem.ToString
                Dim cmdsearch As OdbcCommand = New OdbcCommand("select * from payslips where  Pay_Slip_Number= ('" + accsearch + "') ", con)
                Dim rd As OdbcDataReader = cmdsearch.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    Me.empnamee.Text = rd("Employee_Name")
                    Me.empnumber.Text = rd("Employee_Number")
                    Me.TextBox4.Text = rd("Position")
                    Me.empaddresspay.Text = rd("Employee_Address")
                    Me.empemail.Text = rd("Email")
                    Me.empcontactpayslip.Text = rd("Employee_Contact")
                    Me.TextBox6.Text = rd("Level")
                    Me.empbasicpay.Text = rd("Basic_Pay")
                    Me.empdeductions.Text = rd("Deductions")
                    Me.empdob.Text = rd("Date_of_birth")
                    Me.empbankk.Text = rd("Bank")
                    Me.empbranch.Text = rd("Branch")
                    Me.empaccnumber.Text = rd("Account_Number")
                    Me.empidnumber.Text = rd("National_Id")
                    Me.emppayslipnum.Text = rd("Pay_Slip_Number")
                    Me.monthofpay.Text = rd("Month")
                    Me.paydatee.Text = rd("Pay_Date")
                    Me.empbasicpay.Text = rd("Basic_Pay")
                    Me.empallowance.Text = rd("Allowance")
                    Me.empmessage.Text = rd("Message")
                    Me.emptotalearnings.Text = rd("Total_Earnings")
                    Me.empnetpay.Text = rd("Net_Pay")
                End If
            Catch ee As OdbcException
                MsgBox(ee.Message)
            End Try

        End Using
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        updateeeapay()
    End Sub
    Private Sub updateeeapay()
        Try
            con.ConnectionString = "Dsn=nyangara;uid=root"
            con.Open()
            cmd = New OdbcCommand("update payslips set status='" & "Approved " & "' WHERE Pay_Slip_Number='" + emppayslipnum.Text + "' ", con)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Approved and debited", MsgBoxStyle.Information, "Update submission")
            Else
                MsgBox("DETAILS UPDATED", MsgBoxStyle.Critical, "Update payslips")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            cmd.Dispose()
            con.Close()

        End Try
    End Sub

    Private Sub RadTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RadTextBox1.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso IsNumeric(e.KeyChar) Then
            MessageBox.Show("Error - Type cannot contain numbers")
            e.Handled = True
        End If
    End Sub

    Private Sub RadTextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RadTextBox2.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso IsNumeric(e.KeyChar) Then
            MessageBox.Show("Error - Type cannot contain numbers")
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub transaction_date_ValueChanged(sender As Object, e As EventArgs) Handles transaction_date.ValueChanged
        If transaction_date.Value > DateTime.Now Then
            MessageBox.Show("Invalid Date")
            transaction_date.Value = DateAndTime.Now
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs)
   
    End Sub

    Private Sub DateTimePicker1_ValueChanged_1(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If transaction_date.Value > DateTime.Now Then
            MessageBox.Show("Invalid Date")
            transaction_date.Value = DateAndTime.Now
        End If
    End Sub

    Private Sub TabPage7_Enter(sender As Object, e As EventArgs) Handles TabPage7.Enter
        Using con
            con.ConnectionString = ("Dsn=nyangara;uid=root")
            cmd = New OdbcCommand("select amount from cash_out ", con)
            Dim myDA As OdbcDataAdapter = New OdbcDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            Dim a As Integer = 0
            myDA.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("FAILED TO OPEN DATABASE")
            Else
                Dim totalSum As Integer
                For i As Integer = 0 To dt.Rows.Count - 1
                    totalSum += dt.Rows(i).Item("amount")
                Next
                lblcashout.Text = totalSum.ToString()
            End If
        End Using
        Using con
            con.ConnectionString = ("Dsn=nyangara;uid=root")
            cmd = New OdbcCommand("select amount from cash_in ", con)
            Dim myDA As OdbcDataAdapter = New OdbcDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            Dim a As Integer = 0
            myDA.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("FAILED TO OPEN DATABASE")
            Else
                Dim totalSum As Integer
                For i As Integer = 0 To dt.Rows.Count - 1
                    totalSum += dt.Rows(i).Item("amount")
                Next
                lblcashin.Text = totalSum.ToString()
                Dim cashin As Single = Val(lblcashin.Text)
                Dim cashout As Single = Val(lblcashout.Text)
                Dim balance As Single = Val(lblcashbalance.Text)
                lblcashbalance.Text = cashin - cashout
                If cashin < cashout Then
                    ' Label9.Text = "LOSS"
                    CheckBox1.Checked = True
                    CheckBox2.Checked = False
                    RadGroupBox1.Visible = True
                    Label42.Visible = True
                Else
                    CheckBox2.Checked = True
                    CheckBox1.Checked = False
                    RadGroupBox1.Visible = False
                    Label42.Visible = False
                End If
            End If
        End Using
    End Sub
End Class