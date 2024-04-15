﻿Imports MySql.Data.MySqlClient
Imports CashCountDll.clsFingerPrint

'Notes untuk project ini
'1. simulasi tanggal hari ini adalah 2024-03-19
'2. Check finger belum diaktifkan karena ada masalah dengan dll imports dari backoff (IDM.Fungsi, IDM.Sector, dan lain lainnya)
'3. Dari sd 6 untuk saat ini ganti saja dengan 5 juta
'4. untuk mempermudah juga, semua tanggal initialnya juga di hari 2024-03-19
'5. untuk nomor 2A rkey nya masih harus di cek lagi, apakah sls_brankas, atau selisih berankas. dan tabel selisih_brankas belum ada.
'6. di tabel cashcount -> 1000 = brankas 9999 = gabungan.
'7. jumlah dana yang di setor itu kan ada brankas, itu kek mana nyeleseinnya? -> kemudian itu kan per hari ya, apa di buat tabel baru aja lah ya
Public Class CashCountClass
    Public Shared tanggalSo As String = "2024-03-19" 'Date.Now()
    Public Shared stations As New List(Of String)()
    Public Shared stationsSended As New List(Of String)()
    Public Shared shiftToShare As New List(Of String)()

    Public Shared Sub TheOne()
        stations.Clear()
        stationsSended.Clear()

        Try
            If isSector Then
                'MasterMcon = a.GetVersionV2(MyKey, Application.StartupPath & "\SoPenangananKhusus.exe", "kasir")
            Else
                MasterMcon = New MySqlConnection("server=localhost;user id=root;Password=$d3@pr15mata;port=3306;database=pos;Allow User Variables=True;")
            End If
            ' Check if the connection is open before proceeding
            'fingerpintResult = Panggil_CekFingerprintV3("Proses BA", "SO Penanganan Khusus 2") '12/20/2023 -> berubah ke so p. k. 2

            'If fingerpintResult(0) = "" And fingerpintResult(1) = "" And fingerpintResult(2) = "" Then
            '    MsgBox("Verifikasi Fingerprint Gagal!", MsgBoxStyle.Information, "Perhatian")
            '    Exit Sub
            'End If
            If TestingDatabaseConnection() Then

            Else
                MsgBox("Unable to establish connection to the database.")
            End If
            'check if cashcounttable exists
            createTableChasCountOutput()
            'get number of stations and add the brankas and all
            initializeJumlahStation()
            jmlh_dana_kas_toko_awal_kasir()
            jmlh_selisih_brankas()
            jmlh_dana_sales_yg_blm_disetor()
            jmlh_dana_sales_hari_h()
            jmlh_dana_sales_yg_disetor_ke_brankas()
            jmlh_dana_sales_yg_disetor_kebrankas_shift_sebelumnya()
            jmlh_dana_sales_disetor_finance_cabang()
            jmlh_fisik_uang_di_toko_idm()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function TestingDatabaseConnection() As Boolean


        Try
            Using connection As MySqlConnection = MasterMcon.Clone()
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Using command As New MySqlCommand()
                    command.Connection = connection


                    ' Correctly use ExecuteScalar() to fetch a single value
                    command.CommandText = "SELECT kdtk FROM toko LIMIT 1" ' Ensure your query is intended to return a single value
                    Dim kode_toko As Object = command.ExecuteScalar()

                    If kode_toko IsNot Nothing Then
                        Return True
                    Else
                        Return False
                    End If

                End Using
            End Using
        Catch ex As Exception

            Throw New Exception(ex.Message)
        End Try
    End Function




    Public Shared Sub initializeJumlahStation()
        Try
            Using connection As MySqlConnection = MasterMcon.Clone()
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Using command As New MySqlCommand("SELECT DISTINCT station FROM initial ORDER BY station ASC", connection)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim station As String = reader("station").ToString()
                            stations.Add(station)
                            stationsSended.Add(station)
                        End While
                    End Using
                End Using

                Using command As New MySqlCommand()
                    command.Connection = connection

                    For Each station As String In stations
                        command.CommandText = $"INSERT INTO CashCountOutput (stationid) VALUES ('{station}')"
                        command.ExecuteNonQuery()
                        command.CommandText = $"SELECT shift FROM initial WHERE tanggal = '{tanggalSo}' AND station ='{station}' ORDER BY ADDTIME DESC LIMIT 1" 'this is to pull the last ongoing shift per station
                        Dim shiftValue As Object = command.ExecuteScalar()
                        If shiftValue IsNot Nothing Then
                            shiftToShare.Add(shiftValue.ToString())
                        Else
                            MsgBox($"Tidak ada shift yang dapat diambil dari tabel initial untuk tanggal {tanggalSo} dan station {station}")
                            Exit Sub
                        End If
                    Next
                    command.CommandText = "INSERT INTO CashCountOutput (stationid) VALUES (1000), (9999)"
                    command.ExecuteNonQuery()
                End Using
                stations.Add(1000.ToString())
                stations.Add(9999.ToString())

                connection.Close()
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub createTableChasCountOutput()
        Try
            Using connection As MySqlConnection = MasterMcon.Clone()
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Using command As New MySqlCommand()
                    command.Connection = connection
                    command.CommandText = "DROP TABLE IF EXISTS CashCountOutput"
                    command.ExecuteNonQuery()
                    command.CommandText = $"
                                CREATE TABLE CashCountOutput (
                                    stationid char(4) PRIMARY KEY,
                                    jmlh_dana_kas_awal_kasir INT,
                                    jmlh_selisih_berankas INT,
                                    jmlh_dana_rrak INT,
                                    jmlh_dana_sales_yg_blm_disetor INT,
                                    jmlh_dana_sales_hari_h INT,
                                    jmlh_dana_sales_yg_telah_disetor_ke_brankas INT,
                                    jmlh_dana_sales_yg_telah_disetor_ke_cabang_shift_sebelumnya INT,
                                    jmlh_dana_sales_yg_telah_disetor_ke_cabang INT,
                                    update_data Date
                                );
                                "
                    command.ExecuteNonQuery()
                    command.CommandText = "DROP TABLE IF EXISTS CashPerStationCashCount"
                    command.ExecuteNonQuery()
                    command.CommandText = $"CREATE TABLE CashPerStationCashCount (
                                            station VARCHAR(20)  PRIMARY KEY,
                                            uang_kertas_100k INT NOT NULL,
                                            uang_kertas_75k INT NOT NULL,
                                            uang_kertas_50k INT NOT NULL,
                                            uang_kertas_20k INT NOT NULL,
                                            uang_kertas_10k INT NOT NULL,
                                            uang_kertas_5k INT NOT NULL,
                                            uang_kertas_2k INT NOT NULL,
                                            uang_kertas_1k INT NOT NULL,
                                            uang_logam_1000 INT NOT NULL,
                                            uang_logam_500 INT NOT NULL,
                                            uang_logam_200 INT NOT NULL,
                                            uang_logam_100 INT NOT NULL,
                                            createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                                        );"
                    command.ExecuteNonQuery()

                End Using

                connection.Close()
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub jmlh_dana_kas_toko_awal_kasir()

        Dim f As New InputKasToko
        f.bringArrayStation(stationsSended)
        f.ShowDialog()

    End Sub

    Public Shared Sub jmlh_selisih_brankas()
        Dim DataGabungan = 0 'Ini didapatkan dari FAD
        Try
            Using connection As MySqlConnection = MasterMcon.Clone()
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Using command As New MySqlCommand()
                    command.Connection = connection
                    For i As Integer = 0 To stations.Count - 1

                        If stations(i) <> 1000 AndAlso stations(i) <> 9999 Then
                            command.CommandText = $"SELECT total FROM closing_detail_sementara WHERE rkey = 'sls_brankas' AND station ='{stations(i)}' AND shift = '{shiftToShare(i)}' ORDER BY tanggal DESC"
                            Dim queryExecution = command.ExecuteScalar()

                            If queryExecution IsNot Nothing Then
                                command.CommandText = $"UPDATE CashCountOutput set jmlh_selisih_berankas = {Convert.ToInt32(queryExecution)} where stationid = '{stations(i)}'"
                                command.ExecuteNonQuery()

                            Else
                                command.CommandText = $"UPDATE CashCountOutput set jmlh_selisih_berankas = {0} where stationid = '{stations(i)}'"
                                command.ExecuteNonQuery()
                            End If
                        End If

                    Next

                    command.CommandText = $"select amount from selisih_brankas where tgl_apprv = null"
                    Dim commadSelisihBerankas = 0.ToString() 'command.ExecuteScalar() need to find selisih_brankas

                    If commadSelisihBerankas IsNot Nothing Then
                        command.CommandText = $"UPDATE CashCountOutput set jmlh_selisih_berankas = {Convert.ToInt32(commadSelisihBerankas)} where stationid = '{1000}'"
                        command.ExecuteNonQuery()
                    Else
                        command.CommandText = $"UPDATE CashCountOutput set jmlh_selisih_berankas = {0} where stationid = '{9999}'"
                        command.ExecuteNonQuery()
                    End If

                    command.CommandText = $"UPDATE CashCountOutput set jmlh_selisih_berankas = {Convert.ToInt32(DataGabungan)} where stationid = '{9999}'"
                    command.ExecuteNonQuery()
                End Using

                connection.Close()
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub jmlh_dana_sales_yg_blm_disetor()

        Dim dt As New DataTable()

        Try
            Using connection As MySqlConnection = MasterMcon.Clone()

                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Using command As New MySqlCommand()
                    command.Connection = connection
                    command.CommandText = "DROP TABLE IF EXISTS ttss_detil_untuk_so_cash"
                    command.ExecuteNonQuery()
                    command.CommandText = "CREATE TABLE ttss_detil_untuk_so_cash (tanggal_ttss DATE, jumlah_sales INT)"
                    command.ExecuteNonQuery()
                    command.CommandText = "SELECT ttss_detil.tgl_ttss AS ts, nilai_sales FROM ttss_detil INNER JOIN history_slp ON ttss_detil.no_ttss = history_slp.no_ttss WHERE history_slp.no_ttkd = '' AND ttss_detil.tgl_ttss < '2024-03-19' ORDER BY ttss_detil.tgl_ttss DESC" ' where tanggal now
                    Using adapter As New MySqlDataAdapter(command)
                        adapter.Fill(dt)
                    End Using
                End Using
                Using command As New MySqlCommand()
                    command.Connection = connection
                    For Each row As DataRow In dt.Rows
                        Dim dating As String
                        If TypeOf row("ts") Is Date Then
                            dating = DirectCast(row("ts"), Date).ToString("yyyy-MM-dd")
                        Else
                            ' Handle the case where row("ts") is not a date.
                            dating = "2000-01-01" ' Example default value. Adjust as necessary.
                        End If

                        command.CommandText = $"INSERT INTO ttss_detil_untuk_so_cash (tanggal_ttss, jumlah_sales) VALUES ('{dating}', {Convert.ToInt32(row("nilai_sales"))})"
                        command.ExecuteNonQuery()
                    Next
                End Using
                connection.Close()
            End Using

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Shared Sub jmlh_dana_sales_hari_h()
        Dim totalNilai = 0
        Using connection As MySqlConnection = MasterMcon.Clone()

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Using command As New MySqlCommand()
                command.Connection = connection
                For Each station As String In stations
                    If station <> 9999 AndAlso station <> 1000 Then
                        command.CommandText = $"SELECT sum(total) FROM closing_detail_sementara WHERE rkey = 'sales' AND tanggal = '{tanggalSo}' AND station='{station}' "
                        Dim nilaiSales = command.ExecuteScalar()
                        totalNilai = totalNilai + Convert.ToInt32(nilaiSales)
                        command.CommandText = $"UPDATE CashCountOutput SET jmlh_dana_sales_hari_h = {Convert.ToInt32(nilaiSales)} WHERE stationid = '{station}'"
                        command.ExecuteNonQuery()
                    End If
                Next
                command.CommandText = $"UPDATE CashCountOutput SET jmlh_dana_sales_hari_h = {Convert.ToInt32(totalNilai)} WHERE stationid = '{9999}'"
                command.ExecuteNonQuery()
            End Using
            connection.Close()
        End Using
    End Sub

    Public Shared Sub jmlh_dana_sales_yg_disetor_ke_brankas()
        Try
            Dim total = 0
            Using connection As MySqlConnection = MasterMcon.Clone()

                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Using command As New MySqlCommand()
                    command.Connection = connection
                    For i As Integer = 0 To stations.Count - 1
                        If stations(i) <> 9999 AndAlso stations(i) <> 1000 Then
                            command.CommandText = $" SELECT kas_aktual FROM initial WHERE recid = 'p' AND station = '{stations(i)}' AND shift = '{Convert.ToInt32(shiftToShare(i))}'"
                            If command.ExecuteScalar() = -1 Then
                                MsgBox("Nilai kas_aktual di table initial masih -1. silahkan ubah terlebih dahulu") 'todo di cek lagi sesuai notes
                                Exit Sub
                            End If

                            command.CommandText = $" SELECT  IFNULL(SUM(kas_aktual + var_lns), 0) FROM initial WHERE recid = 'p' AND station = '{stations(i)}' AND shift = '{Convert.ToInt32(shiftToShare(i))}'"
                            total = total + command.ExecuteScalar()
                            command.CommandText = $"UPDATE CashCountOutput SET jmlh_dana_sales_yg_telah_disetor_ke_brankas = { command.ExecuteScalar()} WHERE stationid = '{stations(i)}'"
                            command.ExecuteNonQuery()
                        End If

                    Next
                    command.CommandText = $"UPDATE CashCountOutput SET jmlh_dana_sales_yg_telah_disetor_ke_brankas = {0} WHERE stationid = '{1000}'"
                    command.ExecuteNonQuery()
                    command.CommandText = $"UPDATE CashCountOutput SET jmlh_dana_sales_yg_telah_disetor_ke_brankas = {total} WHERE stationid = '{9999}'"
                    command.ExecuteNonQuery()

                End Using
                connection.Close()
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Sub jmlh_dana_sales_yg_disetor_kebrankas_shift_sebelumnya()
        Dim total = 0
        Using connection As MySqlConnection = MasterMcon.Clone()

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Using command As New MySqlCommand()
                command.Connection = connection
                For i As Integer = 0 To stations.Count - 1
                    If stations(i) <> 9999 AndAlso stations(i) <> 1000 Then
                        command.CommandText = $" SELECT  IFNULL(SUM(kas_aktual + var_lns), 0) FROM initial WHERE recid = 'p' AND station = '{stations(i)}' AND shift = '{Convert.ToInt32(shiftToShare(i)) - 1}'"
                        total = total + command.ExecuteScalar()
                        command.CommandText = $"UPDATE CashCountOutput SET jmlh_dana_sales_yg_telah_disetor_ke_cabang_shift_sebelumnya = { command.ExecuteScalar()} WHERE stationid = '{stations(i)}'"
                        command.ExecuteNonQuery()
                    End If

                Next
                command.CommandText = $"UPDATE CashCountOutput SET jmlh_dana_sales_yg_telah_disetor_ke_cabang_shift_sebelumnya = {0} WHERE stationid = '{1000}'"
                command.ExecuteNonQuery()
                command.CommandText = $"UPDATE CashCountOutput SET jmlh_dana_sales_yg_telah_disetor_ke_cabang_shift_sebelumnya = {total} WHERE stationid = '{9999}'"
                command.ExecuteNonQuery()

            End Using
            connection.Close()
        End Using
    End Sub

    Public Shared Sub jmlh_dana_sales_disetor_finance_cabang()
        Using connection As MySqlConnection = MasterMcon.Clone()

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Using command As New MySqlCommand()
                command.Connection = connection
                command.CommandText = $"SELECT IFNULL(SUM(total_rp), 0) FROM ttss_detil INNER JOIN history_slp ON ttss_detil.no_ttss
= history_slp.no_ttss WHERE history_slp.no_ttkd IS NOT NULL AND history_slp.no_ttkd <> '' AND ttss_detil.tgl_ttss = '{tanggalSo}'"
                Dim jumlahHariIni = command.ExecuteScalar()
                command.CommandText = $"UPDATE CashCountOutput SET jmlh_dana_sales_yg_telah_disetor_ke_cabang = {jumlahHariIni} WHERE stationid = '{9999}'"
                command.ExecuteNonQuery()
                command.CommandText = $"UPDATE CashCountOutput SET jmlh_dana_sales_yg_telah_disetor_ke_cabang = {jumlahHariIni} WHERE stationid = '{1000}'"
                command.ExecuteNonQuery()
            End Using
            connection.Close()
        End Using
    End Sub

    Public Shared Sub jmlh_fisik_uang_di_toko_idm()
        stationsSended.Add("Brankas")
        Dim f As New InputCashPerStation
        f.bringArrayStation(stationsSended)
        f.ShowDialog()
        stationsSended.Remove("Brankas")
    End Sub

End Class
