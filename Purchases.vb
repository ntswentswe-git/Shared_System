Imports System.Data.Odbc
Public Class Purchases
    Dim con As New OdbcConnection("Dsn=nyangara;uid=root")
    Dim cmd As New OdbcCommand
    Public rdr As System.Data.Odbc.OdbcDataReader
    Private Sub Purchases_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.SelectedTab = TabPage3
        GroupBox4.Visible = False
        GroupBox5.Visible = True
        Label10.Text = MainMenu.TextBox1.Text.ToString
        Label12.Text = System.DateTime.Now.ToString
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim result As String = MsgBox("ARE YOU SURE YOU WANT TO LOG-OUT OF SYSTEM?", +vbQuestion + vbYesNoCancel, "    LOG-OUT")
        If result = vbYes Then
            Application.Exit()
        End If
    End Sub

    Private Sub BackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackToolStripMenuItem.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub GridViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GridViewToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub date_purchased_ValueChanged(sender As Object, e As EventArgs) Handles date_purchased.ValueChanged

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub WindowsUIButtonPanel4_Click(sender As Object, e As EventArgs) Handles WindowsUIButtonPanel4.Click
        GroupBox4.Visible = False
    End Sub

    Private Sub WindowsUIButtonPanel1_Click(sender As Object, e As EventArgs) Handles WindowsUIButtonPanel1.Click
        savepurchase()
    End Sub
    Private Sub savepurchase()
        If product_name.Text = "" Or product_price.Text = "" Or product_barcode.Text = "" Or quantity.Value.ToString = "0" Or total_purchase_price.Text = "" Or supplier_name.Text = "" Or supplier_code.Text = "" Or supplier_status.Text = "" Or discount_received.Text = "" Or recorded_by.Text = "" Then
            MessageBox.Show("fill in all fields", "Nyangara System...............")
        Else
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                Dim cmd As New OdbcCommand("insert into purchases (`id`, `date_purchased`, `product_name`, `product_price`, `product_barcode`, `quantity`, `total_purchase_price`, `supplier_name`, `supplier_code`, `supplier_description`, `discount_received`, `recorded_by`) values('" + date_purchased.Value.ToShortDateString + "','" + product_name.Text + "','" + product_price.Text + "','" + product_barcode.Text + "','" + quantity.Value.ToString + "','" + total_purchase_price.Text + "','" + supplier_name.Text + "','" + supplier_code.Text + "','" + supplier_status.Text + "','" + discount_received.Text + "','" + recorded_by.Text + "')", con)
                cmd.ExecuteReader(CommandBehavior.CloseConnection)
                MessageBox.Show("Details Saved", "Nyangara System............", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub clear()
        product_name.Clear()
        product_price.Clear()
        product_barcode.Clear()
        quantity.ResetText()
        supplier_name.Clear()
        supplier_code.Clear()
        supplier_status.Clear()
        discount_received.Clear()
        recorded_by.Clear()
    End Sub

    Private Sub WindowsUIButtonPanel2_Click(sender As Object, e As EventArgs) Handles WindowsUIButtonPanel2.Click
        clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GroupBox5.Visible = True
    End Sub

    Private Sub InvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InvoiceToolStripMenuItem.Click

    End Sub
    Public Function autogenerateid()
        con = New OdbcConnection("Dsn=nyangara;uid=root")
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New OdbcCommand("SELECT TOP 1 Inv_ID FROM InvoiceInfo ORDER BY Inv_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("Inv_ID")
            End If
            rdr.Close()
            ' Increase the ID by 1
            value += 1
            ' Because incrementing a string with an integer removes 0's
            ' we need to replace them. If necessary.
            If value <= 9 Then 'Value is between 0 and 10
                value = "000" & value
            ElseIf value <= 99 Then 'Value is between 9 and 100
                value = "00" & value
            ElseIf value <= 999 Then 'Value is between 999 and 1000
                value = "0" & value
            End If
        Catch ex As Exception
            ' If an error occurs, check the connection state and close it if necessary.
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            value = "0000"
        End Try
        Return value
    End Function

    Private Sub product_name_KeyPress(sender As Object, e As KeyPressEventArgs) Handles product_name.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso IsNumeric(e.KeyChar) Then
            MessageBox.Show("Invalid Name ")
            e.Handled = True
        End If
    End Sub

    Private Sub product_price_KeyPress(sender As Object, e As KeyPressEventArgs) Handles product_price.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim amount As Single = TextBox2.Text
        Dim percentage As Single = ComboBox1.Text
        Dim result As Single
        result = amount * percentage
        discount_received.Text = result
    End Sub

    Private Sub supplier_name_KeyPress(sender As Object, e As KeyPressEventArgs) Handles supplier_name.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso IsNumeric(e.KeyChar) Then
            MessageBox.Show("Invalid Name- Name cannot contain Numbers")
            e.Handled = True
        End If
    End Sub

    Private Sub DetaillViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetaillViewToolStripMenuItem.Click

    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If con.State = ConnectionState.Closed Then
            con.ConnectionString = "Dsn=nyangara;uid=root"
            con.Open()
        End If
        Using con
            Dim cmdload As OdbcCommand = New OdbcCommand("SELECT * from purchases", con)
            cmdload.CommandType = CommandType.Text
            Dim adapter As New OdbcDataAdapter
            Dim dt As New DataTable
            adapter.SelectCommand = cmdload
            adapter.Fill(dt)
            RadGridView1.DataSource = dt
            con.Close()
            con.Dispose()
        End Using
    End Sub

    Private Sub TileItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem1.ItemClick
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub WindowsUIButtonPanel5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub WindowsUIButtonPanel3_Click(sender As Object, e As EventArgs) Handles WindowsUIButtonPanel3.Click
        MainMenu.Show()
        Me.Hide()

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class