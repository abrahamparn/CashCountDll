Imports MySql.Data.MySqlClient
Imports CashCountDll.clsFingerPrint
Imports CashCountDll.CashCountClass


Module MainModule
 
    Public MasterMcon As MySqlConnection
    Public isSector As Boolean = True
    Friend a As New IDM.Sector
    Friend MyKey As String = "0C569782377CC6CD61B07C6869C1DC09"
    Public Sub Main()
        Try
            If isSector Then
                MasterMcon = a.GetVersionV2(MyKey, Application.StartupPath & "\CashCountDll.exe", "kasir")
            Else
                'MasterMcon = New MySqlConnection("server=localhost;user id=root;Password=$d3@pr15mata;port=3306;database=pos;Allow User Variables=True;")
            End If
            ' Check if the connection is open before proceeding
            'fingerpintResult = Panggil_CekFingerprintV3("Proses BA", "SO Penanganan Khusus 2") '12/20/2023 -> berubah ke so p. k. 2

            'If fingerpintResult(0) = "" And fingerpintResult(1) = "" And fingerpintResult(2) = "" Then
            '    MsgBox("Verifikasi Fingerprint Gagal!", MsgBoxStyle.Information, "Perhatian")
            '    Exit Sub
            'End If

            'check if cashcounttable exists
            If TestingDatabaseConnection() Then

            Else
                MsgBox("Unable to establish connection to the database.")
            End If
            createTableChasCountOutput()
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






End Module
