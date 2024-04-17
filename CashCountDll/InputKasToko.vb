Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class InputKasToko
    Dim jumlahStation = 0
    Dim Counter = 0
    Public Shared stationsBrought As New List(Of String)()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Station_label.Text = $"Station {stationsBrought(jumlahStation)}"
        addColumnForGridView()
    End Sub

    Private Sub addColumnForGridView()
        dgv_kas_station.Rows.Clear()
        dgv_kas_station.Columns.Clear()
        dgv_kas_station.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill ' Set the AutoSizeColumnsMode to Fill
        dgv_kas_station.AllowUserToAddRows = False

        Dim col As New DataGridViewTextBoxColumn

        ' STATION Column
        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Regular)
        col.Name = "STATION"
        col.HeaderText = "STATION"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 12, FontStyle.Bold)
        dgv_kas_station.Columns.Add(col)

        ' JUMLAH_KAS Column
        col = New DataGridViewTextBoxColumn
        col.DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Regular)
        col.Name = "JUMLAH_KAS"
        col.HeaderText = "JUMLAH_KAS"
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.ReadOnly = True
        col.Visible = True
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        col.HeaderCell.Style.Font = New Font("Arial", 12, FontStyle.Bold)
        dgv_kas_station.Columns.Add(col)
    End Sub
    Public Sub bringArrayStation(ByVal stations As List(Of String))
        Counter = stations.Count
        stationsBrought = stations
    End Sub

    Private Sub button_accept_kas_Click(sender As Object, e As EventArgs) Handles button_accept_kas.Click
        If jumlahStation <> Counter - 1 Then
            If jumlahStation = Counter Then
                MessageBox.Show("Semua station sudah terisi", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim input As String = kas_text_box.Text.Trim()
            ' Check if the input is empty
            If String.IsNullOrEmpty(input) Then
                MessageBox.Show("Mohon masukan jumlah uang", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                kas_text_box.Clear()
                Exit Sub
            End If

            ' Check if the input is a non-negative number
            Dim number As Integer
            If Not Integer.TryParse(input, number) OrElse number < 0 Then
                MessageBox.Show("Mohon untuk tidak menginput nilai negative", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                kas_text_box.Clear() ' Clear the input
                Exit Sub
            End If

            dgv_kas_station.Rows.Add(stationsBrought(jumlahStation), FormatIndonesianCurrency(Integer.Parse(input)))
            jumlahStation = jumlahStation + 1
            Station_label.Text = $"Station {stationsBrought(jumlahStation)}"
            kas_text_box.Clear()
            kas_text_box.Focus()
        Else
            If jumlahStation = Counter Then
                MessageBox.Show("Semua station sudah terisi", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim input As String = kas_text_box.Text.Trim()
            ' Check if the input is empty
            If String.IsNullOrEmpty(input) Then
                MessageBox.Show("Mohon masukan jumlah uang", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                kas_text_box.Clear()
                Exit Sub
            End If

            ' Check if the input is a non-negative number
            Dim number As Integer
            If Not Integer.TryParse(input, number) OrElse number < 0 Then
                MessageBox.Show("Mohon untuk tidak menginput nilai negative", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                kas_text_box.Clear() ' Clear the input
                Exit Sub
            End If

            dgv_kas_station.Rows.Add(stationsBrought(jumlahStation), FormatIndonesianCurrency(Integer.Parse(input)))
            jumlahStation = jumlahStation + 1
            Station_label.Text = $"Station penuh"
            kas_text_box.Clear()
            button_accept_kas.Enabled = False
        End If
    End Sub

    Private Sub kas_text_box_KeyPress(sender As Object, e As KeyPressEventArgs) Handles kas_text_box.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the entered key is not a digit or the backspace key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub button_hapus_kas_Click(sender As Object, e As EventArgs) Handles button_hapus_kas.Click
        kas_text_box.Clear()
        kas_text_box.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        addColumnForGridView()
        kas_text_box.Clear()
        kas_text_box.Focus()
        jumlahStation = 0
        Station_label.Text = $"Station {stationsBrought(jumlahStation)}"
        button_accept_kas.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If jumlahStation <> Counter Then
            MessageBox.Show($"Mohon untuk menginput semua station", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            kas_text_box.Focus()
            Exit Sub
        End If

        Dim totalCashDiStation = 0
        Try
            Using connection As MySqlConnection = MasterMcon.Clone()
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Using command As New MySqlCommand()
                    command.Connection = connection


                    For Each row As DataGridViewRow In dgv_kas_station.Rows
                        Dim station As String = row.Cells(0).Value.ToString()
                        command.CommandText = $"UPDATE CashCountOutput set jmlh_dana_kas_awal_kasir = {Convert.ToInt32(UnformatIndonesianCurrency(row.Cells(1).Value))} where stationid = '{row.Cells(0).Value.ToString()}'"
                        command.ExecuteNonQuery()
                        totalCashDiStation = totalCashDiStation + Convert.ToInt32(UnformatIndonesianCurrency(row.Cells(1).Value))
                    Next

                    Dim jumlahKasAwalDariSD6 = 5000000 'ini mohon diubah nanti ya
                    command.CommandText = $"UPDATE CashCountOutput set jmlh_dana_kas_awal_kasir = {jumlahKasAwalDariSD6} where stationid = 9999 "
                    command.ExecuteNonQuery()

                    command.CommandText = $"UPDATE CashCountOutput set jmlh_dana_kas_awal_kasir = {jumlahKasAwalDariSD6 - totalCashDiStation} where stationid = 1000 "
                    command.ExecuteNonQuery()
                End Using

                connection.Close()
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        userClosing = True ' Set the flag to indicate programmatic closure
        Me.Close() ' Close the form
    End Sub

    Public Function FormatIndonesianCurrency(value As Integer) As String
        Dim cultureInfo As CultureInfo = CultureInfo.CreateSpecificCulture("id-ID")
        Dim numberFormat As NumberFormatInfo = cultureInfo.NumberFormat

        ' Customize number format
        numberFormat.CurrencyDecimalSeparator = ","
        numberFormat.CurrencyGroupSeparator = "."
        numberFormat.CurrencySymbol = "" ' Remove currency symbol if you don't want "Rp" prefix

        ' Format the number as currency
        Return value.ToString("N0", numberFormat)
    End Function

    Public Function UnformatIndonesianCurrency(formattedValue As String) As Integer
        ' Remove any currency formatting, focusing on Indonesian currency specifics
        ' where "." is the thousand separator and "," might be used for decimal parts.
        Dim numericString As String = formattedValue.Replace(".", "").Replace(",", "")

        ' Convert the cleaned-up string back to an integer.
        Dim result As Integer
        If Integer.TryParse(numericString, result) Then
            Return result
        Else
            Throw New FormatException("Input string is not in a correct format.")
        End If
    End Function


    Private userClosing As Boolean = False

    Private Sub InputKasToko_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If Not userClosing Then
                If MessageBox.Show("Are you sure you want to exit the application?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    userClosing = True ' The user has confirmed they want to exit
                    Application.Exit()
                Else
                    e.Cancel = True ' Prevent the form from closing
                    userClosing = False ' Reset the flag as the closure was canceled
                End If
            End If
        End If
    End Sub
End Class
