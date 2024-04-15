Imports MySql.Data.MySqlClient

Public Class InputCashPerStation
    Dim jumlahStation = 0
    Dim Counter = 0
    Public Shared stationsBrought As New List(Of String)()
    Public Sub bringArrayStation(ByVal stations As List(Of String))
        Counter = stations.Count
        stationsBrought = stations
    End Sub

    Private Sub InputCashPerStation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        uang_kertas_lbl.Text = $"Uang Kertas Station {stationsBrought(jumlahStation)}"
        uang_logam_label.Text = $"Uang Logam Station {stationsBrought(jumlahStation)}"
        addColumnForGridView()
    End Sub

    Private Sub addColumnForGridView()
        dgv_uang.Rows.Clear()
        dgv_uang.Columns.Clear()
        dgv_uang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill ' Set the AutoSizeColumnsMode to Fill
        dgv_uang.AllowUserToAddRows = False

        Dim col As New DataGridViewTextBoxColumn

        ' STATION Column
        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "STATION"
        col.HeaderText = "STATION"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)


        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "IDR100.000"
        col.HeaderText = "IDR100.000"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "IDR75.000"
        col.HeaderText = "IDR75.000"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "IDR50.000"
        col.HeaderText = "IDR50.000"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "IDR20.000"
        col.HeaderText = "IDR20.000"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "IDR10.000"
        col.HeaderText = "IDR10.000"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "IDR5.000"
        col.HeaderText = "IDR5.000"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "IDR2.000"
        col.HeaderText = "IDR2.000"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "IDR1.000"
        col.HeaderText = "IDR1.000"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "IDR1000"
        col.HeaderText = "IDR1000"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "IDR500"
        col.HeaderText = "IDR500"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "IDR200"
        col.HeaderText = "IDR200"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Regular)
        col.Name = "IDR100"
        col.HeaderText = "IDR100"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 8, FontStyle.Bold)
        dgv_uang.Columns.Add(col)
    End Sub


    Private Sub uang_kertas_100k_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang_kertas_100k.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub uang_kertas_75k_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang_kertas_75k.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub uang_kertas_50k_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang_kertas_50k.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub uang_kertas_20k_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang_kertas_20k.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub uang_kertas_10k_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang_kertas_10k.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub uang_kertas_5k_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang_kertas_5k.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub uang_kertas_2k_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang_kertas_2k.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub uang_kertas_1k_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang_kertas_1k.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub uang_logam_1000_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang_logam_1000.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub uang_logam_500_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang_logam_500.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub uang_logam_200_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang_logam_200.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub uang_logam_100_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang_logam_100.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub button_ulangi_Click(sender As Object, e As EventArgs) Handles button_ulangi.Click
        resetTestInput()
    End Sub

    ' validation for all inputs
    Private Sub resetTestInput()
        uang_kertas_100k.Text = ""
        uang_kertas_75k.Text = ""
        uang_kertas_50k.Text = ""
        uang_kertas_20k.Text = ""
        uang_kertas_10k.Text = ""
        uang_kertas_5k.Text = ""
        uang_kertas_2k.Text = ""
        uang_kertas_1k.Text = ""
        uang_logam_1000.Text = ""
        uang_logam_500.Text = ""
        uang_logam_200.Text = ""
        uang_logam_100.Text = ""
    End Sub

    Function ValidateCurrencyInputs() As Boolean
        ' List of TextBox controls for validation
        Dim textBoxes As TextBox() = {
        uang_kertas_100k, uang_kertas_75k, uang_kertas_50k,
        uang_kertas_20k, uang_kertas_10k, uang_kertas_5k,
        uang_kertas_2k, uang_kertas_1k, uang_logam_1000,
        uang_logam_500, uang_logam_200, uang_logam_100
        }

        Dim allInputsValid As Boolean = True

        For Each textBox As TextBox In textBoxes
            ' Set the text to "0" if the TextBox is empty
            If String.IsNullOrEmpty(textBox.Text) Then
                textBox.Text = "0"
            End If

            Dim value As Integer
            ' Try to parse the text as an integer and validate it
            If Integer.TryParse(textBox.Text, value) Then
                If value < 0 Then
                    ' Indicate error (this could be changing the background color, showing a label, etc.)
                    textBox.BackColor = Color.Red ' This is just an example, adapt it to your needs
                    allInputsValid = False
                Else
                    ' Reset the background color if the input is valid
                    textBox.BackColor = Color.White ' Reset to default or valid color
                End If
            Else
                ' This block may be redundant now since we're setting empty fields to "0",
                ' but it's kept for cases where the text is not a valid number.
                textBox.BackColor = Color.Yellow ' Indicate a different kind of error, for example
                allInputsValid = False
            End If
        Next

        Return allInputsValid
    End Function

    Private Sub button_simpan_Click(sender As Object, e As EventArgs) Handles button_simpan.Click
        If jumlahStation <> Counter - 1 Then
            If jumlahStation = Counter Then
                MessageBox.Show("Semua station sudah terisi", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            If ValidateCurrencyInputs() = False Then
                MessageBox.Show("Error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            Dim valuesToAdd As New List(Of String)
            valuesToAdd.AddRange({stationsBrought(jumlahStation).ToString(),
            uang_kertas_100k.Text, uang_kertas_75k.Text, uang_kertas_50k.Text,
            uang_kertas_20k.Text, uang_kertas_10k.Text, uang_kertas_5k.Text,
            uang_kertas_2k.Text, uang_kertas_1k.Text, uang_logam_1000.Text,
            uang_logam_500.Text, uang_logam_200.Text, uang_logam_100.Text
        })

            ' Add the new row to dgv_uang.
            dgv_uang.Rows.Add(valuesToAdd.ToArray())
            jumlahStation = jumlahStation + 1
            uang_kertas_lbl.Text = $"Uang Kertas Station {stationsBrought(jumlahStation)}"
            uang_logam_label.Text = $"Uang Logam Station {stationsBrought(jumlahStation)}"
            resetTestInput()
        Else
            If jumlahStation = Counter Then
                MessageBox.Show("Semua station sudah terisi", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            If ValidateCurrencyInputs() = False Then
                MessageBox.Show("Error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            Dim valuesToAdd As New List(Of String)
            valuesToAdd.AddRange({stationsBrought(jumlahStation).ToString(),
            uang_kertas_100k.Text, uang_kertas_75k.Text, uang_kertas_50k.Text,
            uang_kertas_20k.Text, uang_kertas_10k.Text, uang_kertas_5k.Text,
            uang_kertas_2k.Text, uang_kertas_1k.Text, uang_logam_1000.Text,
            uang_logam_500.Text, uang_logam_200.Text, uang_logam_100.Text
        })
            dgv_uang.Rows.Add(valuesToAdd.ToArray())

            uang_kertas_lbl.Text = $"Station penuh"
            uang_logam_label.Text = $"Station penuh"
            resetTestInput()
            button_simpan.Enabled = False
            jumlahStation = jumlahStation + 1
        End If
    End Sub

    Private Sub button_batal_Click(sender As Object, e As EventArgs) Handles button_batal.Click
        addColumnForGridView()
        resetTestInput()
        jumlahStation = 0
        uang_kertas_lbl.Text = $"Uang Kertas Station {stationsBrought(jumlahStation)}"
        uang_logam_label.Text = $"Uang Logam Station {stationsBrought(jumlahStation)}"
        button_simpan.Enabled = True
    End Sub

    Private Sub button_terima_Click(sender As Object, e As EventArgs) Handles button_terima.Click
        If jumlahStation <> Counter Then
            MessageBox.Show($"Mohon untuk menginput semua station", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Try
            Using connection As MySqlConnection = MasterMcon.Clone()
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Using command As New MySqlCommand()
                    command.Connection = connection


                    For Each row As DataGridViewRow In dgv_uang.Rows
                        command.CommandText = $"INSERT INTO CashPerStationCashCount 
                    (station, uang_kertas_100k, uang_kertas_75k, uang_kertas_50k, uang_kertas_20k, uang_kertas_10k, uang_kertas_5k, 
                    uang_kertas_2k, uang_kertas_1k, uang_logam_1000, uang_logam_500, uang_logam_200, uang_logam_100) 
                    VALUES (
                    '{row.Cells(0).Value.ToString()}',
                    {Convert.ToInt32(row.Cells(1).Value)}, 
                    {Convert.ToInt32(row.Cells(2).Value)}, 
                    {Convert.ToInt32(row.Cells(3).Value)}, 
                    {Convert.ToInt32(row.Cells(4).Value)},
                    {Convert.ToInt32(row.Cells(5).Value)}, 
                    {Convert.ToInt32(row.Cells(6).Value)}, 
                    {Convert.ToInt32(row.Cells(7).Value)}, 
                    {Convert.ToInt32(row.Cells(8).Value)}, 
                    {Convert.ToInt32(row.Cells(9).Value)}, 
                    {Convert.ToInt32(row.Cells(10).Value)}, 
                    {Convert.ToInt32(row.Cells(11).Value)}, 
                    {Convert.ToInt32(row.Cells(12).Value)})"
                        command.ExecuteNonQuery()
                    Next
                End Using

                connection.Close()
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class