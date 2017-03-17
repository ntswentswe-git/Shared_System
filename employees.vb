Imports System.Data.Odbc
Public Class employees
    Dim con As New OdbcConnection
    Dim cmd As OdbcCommand
    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If empfullname.Text = "" Or empsex.Text = "" Or empadress.Text = "" Or empposition.Text = "" Or empgmail.Text = "" Or empcontact.Text = "" Or ComboBox3.Text = "" Or salary.Text = "" Or ComboBox4.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MessageBox.Show("CHECK IF YOU HAVE FILLED ALL THE FIELDS")
        Else
            con.ConnectionString = "Dsn=nyangara;uid=root"
            con.Open()

            cmd = New OdbcCommand("insert into employees(Employee_id,Fullname,Sex,Address,Position,Email,Contact,Start_date,Level,Salary_entitled,Deductions,Id_Number,Date_of_birth,Bank,Branch,Account_Number) values ('" + IDEMP.Text + "','" + empfullname.Text + "','" + empsex.Text + "','" + empadress.Text + "','" + empposition.Text + "','" + empgmail.Text + "','" + empcontact.Text + "','" + DateTimePicker1.Value.ToShortDateString + "','" + ComboBox3.Text + "','" + salary.Text + "','" + deductions.Text + "','" + national_id.Text + "','" + DateTimePicker2.Value.ToShortDateString + "','" + ComboBox4.Text + "','" + TextBox3.Text + "','" + TextBox2.Text + "')", con)
            cmd.ExecuteReader(CommandBehavior.CloseConnection)
            MessageBox.Show("Details saved", "Nyangara System..........................................")
            clearemployeefields()
            con.Close()
        End If
    End Sub
    Private Sub clearemployeefields()
        empfullname.Text = ""
        IDEMP.Text = ""
        empsex.Text = ""
        empadress.Text = ""
        empposition.Text = ""
        empgmail.Text = ""
        empcontact.Text = ""
        salary.Text = ""
        DateTimePicker1.ResetText()
        DateTimePicker2.ResetText()
        ComboBox3.Text = ""
        nett.Clear()
        ComboBox4.Text = ""
        TextBox2.Clear()
        TextBox3.Clear()
        deductions.Clear()
        national_id.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clearemployeefields()
    End Sub
    Private Sub CCLEAR()
        empfullname.Clear()
        IDEMP.Text = ""
        empsex.SelectedItem = Nothing
        empadress.Clear()
        empposition.Clear()
        empgmail.Clear()
        empcontact.Clear()
        salary.Clear()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If empfullname.Text = "" Or empadress.Text = "" Or IDEMP.Text = "0" Or empgmail.Text = "" Then
            MessageBox.Show("SEARCH CLIENT FIRST")
        Else
            Try
                con.ConnectionString = "Dsn=nyangara;uid=root"
                con.Open()
                cmd = New OdbcCommand("delete from employees where fullname =('" & empfullname.Text.ToString.Replace("'", "''") & "')", con)
                cmd.ExecuteReader(CommandBehavior.CloseConnection)
                MsgBox("EMPLOYEE Deleted", MsgBoxStyle.Information, "Nyangara System")
                CCLEAR()
                ListBox1.Items.Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cmd.Dispose()
                con.Close()
            End Try
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If empadress.Text = "" Or empcontact.Text = "" Or empgmail.Text = "" Or empfullname.Text = "" Or IDEMP.Text = "0" Or empposition.Text = "" Then
            MessageBox.Show("SEARCH CLIENT FIRST TO UPDATE DETAILS")
        Else
            Try
                con.ConnectionString = "Dsn=nyangara;uid=root"
                con.Open()
                cmd = New OdbcCommand("Update employees set  fullname='" & empfullname.Text & "', sex= '" & empsex.Text & "', address ='" & empadress.Text & "', position='" & empposition.Text & "' ,salary_entitled='" & salary.Text & "', gmail_acc='" & empgmail.Text & "', contact='" + empcontact.Text + "' WHERE id ='" & IDEMP.Text & "'", con)
                Dim i As Integer
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("submission Updated", MsgBoxStyle.Information, "Update submission")
                    CCLEAR()
                Else
                    MsgBox("Failed to update settings", MsgBoxStyle.Critical, "Update submission")

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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox16.Visible = True
        ListBox1.Visible = True
    End Sub

    Private Sub txtsearchclient_TextChanged(sender As Object, e As EventArgs) Handles txtsearchclient.TextChanged
        If IsNumeric(txtsearchclient.Text) = True Then
            MessageBox.Show("SEARCH USING EMPLOYEE NAME")
            txtsearchclient.Clear()
        Else
            Try
                con.ConnectionString = ("Dsn=nyangara;uid=root")
                con.Open()
                cmd = New OdbcCommand("select fullname from employees where fullname like '" & txtsearchclient.Text & "%' ", con)
                Dim myDA As OdbcDataAdapter = New OdbcDataAdapter(cmd)
                Dim dt As DataTable = New DataTable()
                Dim a As Integer = 0
                myDA.Fill(dt)
                If dt.Rows.Count = 0 Then
                    MsgBox("USER NOT FOUND")
                    con.Close()
                Else

                    Do While a < dt.Rows.Count
                        ListBox1.Items.Add(dt.Rows(a).Item("fullname"))
                        a += 1
                    Loop
                    con.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If con.State = ConnectionState.Closed Then
            con.ConnectionString = "Dsn=nyangara;uid=root"
            con.Open()
        End If
        Using con
            Dim accsearch As String = ListBox1.SelectedItem.ToString
            Dim cmdsearch As OdbcCommand = New OdbcCommand("select * from employees where Fullname= ('" + accsearch + "') ", con)
            Dim rd As OdbcDataReader = cmdsearch.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Me.empfullname.Text = rd("Fullname")
                Me.IDEMP.Text = Val(rd("Employee_id"))
                Me.empsex.Text = rd("Sex")
                Me.empadress.Text = rd("Address")
                Me.empposition.Text = rd("Position")
                Me.empgmail.Text = rd("Email")
                Me.empcontact.Text = rd("Contact")
                Me.salary.Text = rd("Salary_entitled")
            End If
            con.Close()
        End Using
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        con.ConnectionString = ("Dsn=nyangara;uid=root")
        con.Open()
        Try
            Dim cmdload As OdbcCommand = New OdbcCommand("SELECT * from employees", con)
            cmdload.CommandType = CommandType.Text
            Dim adapter As New OdbcDataAdapter
            Dim dt As New DataTable
            adapter.SelectCommand = cmdload
            adapter.Fill(dt)
            dataGridView1.DataSource = dt
            con.Close()
            con.Dispose()
        Catch xx As InvalidOperationException
            MsgBox(xx.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub EmployeeOptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeOptionsToolStripMenuItem.Click
        ListBox1.Visible = True
        GroupBox16.Visible = True
        Button4.Visible = True
        Button5.Visible = True
        Button6.Visible = True
    End Sub
    Private Sub employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.Visible = False
        GroupBox16.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        Button6.Visible = False
        Label17.Text = System.DateTime.Now.ToShortDateString
        Label16.Text = System.DateTime.Now.ToShortTimeString
        TabControl1.SelectedTab = TabPage3
        Label20.Text = MainMenu.TextBox1.Text.ToString
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub GridViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GridViewToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim result As String = MsgBox("ARE YOU SURE YOU WANT TO LOG-OUT OF SYSTEM?", +vbQuestion + vbYesNoCancel, "    LOG-OUT")
        If result = vbYes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        deductions.Text = "20"
        If ComboBox3.Text = "LEVEL 1 [CEO]" Then
            salary.Text = "1600"
        ElseIf ComboBox3.Text = "LEVEL 1 [DIRECTORS]" Then
            salary.Text = "1100"
        ElseIf ComboBox3.Text = "LEVEL 1 [MANAGERS]" Then
            salary.Text = "900"
        ElseIf ComboBox3.Text = "LEVEL 1 [FLOOR WORKERS]" Then
            salary.Text = "450"
        End If
    End Sub

    Private Sub salary_TextChanged(sender As Object, e As EventArgs) Handles salary.TextChanged
        Dim aa As Single = Val(salary.Text)
        Dim bb As Single = Val(deductions.Text)
        Dim cc As Single
        cc = aa - bb
        nett.Text = cc
    End Sub

    Private Sub TabPage4_Enter(sender As Object, e As EventArgs) Handles TabPage4.Enter
        emppaydate.Text = DateTimePicker4.Text
        generatepayslipnum()

        Try

            con.ConnectionString = ("Dsn=nyangara;uid=root")
            con.Open()
            cmd = New OdbcCommand("select   Fullname from employees ", con)
            Dim myDA As OdbcDataAdapter = New OdbcDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            Dim a As Integer = 0
            myDA.Fill(dt)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No Employee in database", "Nyangara System........................", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                con.Close()
            Else

                Do While a < dt.Rows.Count
                    ComboBox1.Items.Add(dt.Rows(a).Item("Fullname"))
                    a += 1
                Loop
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        retrieveempdetails()
        emppaydate.Text = DateTimePicker4.Value.ToShortDateString
    End Sub
    Private Sub retrieveempdetails()
        If con.State = ConnectionState.Closed Then
            con.ConnectionString = "Dsn=nyangara;uid=root"
            con.Open()
        End If
        Using con
            Try
                Dim accsearch As String = ComboBox1.Text.ToString
                Dim cmdsearch As OdbcCommand = New OdbcCommand("select * from employees where  Fullname= ('" + accsearch + "') ", con)
                Dim rd As OdbcDataReader = cmdsearch.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    Me.empnamee.Text = rd("Fullname")
                    Me.empnumber.Text = rd("Employee_id")
                    Me.TextBox5.Text = rd("Sex")
                    Me.TextBox4.Text = rd("Position")
                    Me.empaddresspay.Text = rd("Address")
                    Me.empemail.Text = rd("Email")
                    Me.empcontactpayslip.Text = rd("Contact")
                    Me.TextBox6.Text = rd("Level")
                    Me.empbasicpay.Text = rd("Salary_entitled")
                    Me.empdeductions.Text = rd("Deductions")
                    Me.empdob.Text = rd("Date_of_birth")
                    Me.empbankk.Text = rd("Bank")
                    Me.empbranch.Text = rd("Branch")
                    Me.empaccnumber.Text = rd("Account_Number")
                    Me.empidnumber.Text = rd("Id_Number")
                End If
            Catch ee As OdbcException
                MsgBox(ee.Message)
            End Try

        End Using
    End Sub

    Private Sub calcincentive_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub incentive_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub emptotalearnings_TextChanged(sender As Object, e As EventArgs) Handles emptotalearnings.TextChanged
        Dim a As Single = Val(empbasicpay.Text)
        Dim b As Single = Val(empallowance.Text)
        Dim c As Single = Val(emptotalearnings.Text)
        Dim net As Single = Val(empnetpay.Text)
        Dim deduction As Single = Val(empdeductions.Text)
        Dim d As Single
        d = a + b
        emptotalearnings.Text = d
        empnetpay.Text = c - deduction
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        If NumericUpDown3.Value = "0" Or NumericUpDown4.Text = "0" Then
            MessageBox.Show("Fill in the hours and rate fields")
        Else
            Dim aa As Single = Val(NumericUpDown3.Value.ToString)
            Dim bb As Single = Val(NumericUpDown4.Text.ToString)
            Dim cc As Single
            cc = aa * bb
            incentive.Text = cc
            empallowance.Text = cc
        End If
    End Sub

    Private Sub Label25_TextChanged(sender As Object, e As EventArgs)
        Me.Text = empallowance.Text
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles incentive.TextChanged
        empallowance.Text = Me.Text
    End Sub

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter
        autogenerateid()
    End Sub
    Private Sub autogenerateid()
        Try
            Dim Num As Integer = 0
            con = New OdbcConnection("Dsn=nyangara;uid=root")
            con.Open()
            Dim Sql As String = ("SELECT MAX(Employee_id) FROM Employees")
            cmd = New OdbcCommand(Sql)
            cmd.Connection = con
            If (IsDBNull(cmd.ExecuteScalar)) Then
                Num = 1
                IDEMP.Text = Num.ToString
                IDEMP.Text = "101" + Num.ToString ' employee code for nyangara...ese ma employees code inotanga na 101 nthus the employee code
            Else
                Num = cmd.ExecuteScalar + 1
                IDEMP.Text = Num.ToString
                IDEMP.Text = "101" + Num.ToString
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If ComboBox1.Text = "" Or empaddresspay.Text = "" Or TextBox5.Text = "" Or empcontactpayslip.Text = "" Or empaccnumber.Text = "" Or NumericUpDown3.Text = "" Or NumericUpDown4.Text = "" Then
            MessageBox.Show("Retrieve employee first")
        Else
            Try
                con.ConnectionString = "Dsn=nyangara;uid=root"
                con.Open()
                cmd = New OdbcCommand(" INSERT INTO `payslips`(`Pay_Slip_Number`, `Employee_Name`, `Employee_Number`, `National_Id`, `Employee_Address`, `Employee_Contact`, `Month`, `Pay_Date`, `Level`, `Position`, `Date_of_Birth`, `Email`, `Bank`, `Branch`, `Account_Number`, `Basic_Pay`, `Allowance`, `Message`, `Total_Earnings`, `Deductions`, `Net_Pay`, `Status`) VALUES ('" + emppayslipnum.Text + "','" + empnamee.Text + "','" + empnumber.Text + "','" + empidnumber.Text + "','" + empaddresspay.Text + "','" + empcontactpayslip.Text + "','" + monthhofpay.Text + "','" + emppaydate.Text + "','" + TextBox6.Text + "','" + TextBox4.Text + "','" + empdob.Text + "','" + empemail.Text + "','" + empbankk.Text + "','" + empbranch.Text + "','" + empaccnumber.Text + "','" + empbasicpay.Text + "','" + empallowance.Text + "','" + empmessage.Text + "','" + emptotalearnings.Text + "','" + empdeductions.Text + "','" + empnetpay.Text + "','" + "not approved" + "')", con)
                cmd.ExecuteReader(CommandBehavior.CloseConnection)
                MessageBox.Show("Pay Slip proposed", "Nyangara System..........................................")
                clearemployeefields()
                con.Close()
            Catch es As OdbcException
                MsgBox(es.Message)
            End Try
        End If
    End Sub
    Private Sub generatepayslipnum()
        Try
            Dim Num As Integer = 0
            con = New OdbcConnection("Dsn=nyangara;uid=root")
            con.Open()
            Dim Sql As String = ("SELECT MAX(Pay_Slip_Number) FROM payslips")
            cmd = New OdbcCommand(Sql)
            cmd.Connection = con
            If (IsDBNull(cmd.ExecuteScalar)) Then
                Num = 1
                emppayslipnum.Text = Num.ToString
                emppayslipnum.Text = "3003" + Num.ToString ' payslip code for nyangara...ese ma payslips code inotanga na3003 nthus the employee code
            Else
                Num = cmd.ExecuteScalar + 1
                emppayslipnum.Text = Num.ToString
                emppayslipnum.Text = "3003" + Num.ToString
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub empdeductions_TextChanged(sender As Object, e As EventArgs) Handles empdeductions.TextChanged
        Dim bb As Single = Val(empbasicpay.Text)
        Dim cc As Single = Val(empdeductions.Text)
        Dim dd As Single
        dd = bb - cc
        TextBox7.Text = dd
    End Sub
    Private Sub empallowance_TextChanged(sender As Object, e As EventArgs) Handles empallowance.TextChanged
        Dim aa As Single = Val(empbasicpay.Text)
        Dim bb As Single = Val(empallowance.Text)
        Dim cc As Single
        cc = aa + bb
        emptotalearnings.Text = cc
    End Sub
    Private Sub BackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackToolStripMenuItem.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged

    End Sub

    Private Sub NumericUpDown4_TextChanged(sender As Object, e As EventArgs) Handles NumericUpDown4.TextChanged

    End Sub

    Private Sub NumericUpDown4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumericUpDown4.KeyPress
        
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso IsNumeric(e.KeyChar) Then
            MessageBox.Show("Invalid Name")
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso IsNumeric(e.KeyChar) Then
            MessageBox.Show("Invalid Name")
            e.Handled = True
        End If
    End Sub

    Private Sub empfullname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles empfullname.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso IsNumeric(e.KeyChar) Then
            MessageBox.Show("Invalid Name- Name cannot contain Numbers")
            e.Handled = True
        End If
    End Sub

    Private Sub txtsearchclient_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsearchclient.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso IsNumeric(e.KeyChar) Then
            MessageBox.Show("Invalid Name")
            e.Handled = True
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub DetaillViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetaillViewToolStripMenuItem.Click

    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
End Class