Imports MySql.Data.MySqlClient
Imports IDM.Fungsi

Public Class clsFingerPrint
    'Public Shared Function Panggil_CekFingerprintV3(ByVal nmFrm As String, ByVal nmTransaksi As String) As String()
    '    Panggil_CekFingerprintV3 = New String() {"", "", ""}
    '    Dim Scon As New MySqlConnection
    '    Dim Scom As New MySqlCommand("", Scon)

    '    Try
    '        If isSector Then
    '            Scon = a.GetVersionV2(MyKey, Application.StartupPath & "\SoPenangananKhusus.exe", "kasir")
    '        Else
    '            Scon = New MySqlConnection("server=localhost;user id=root;Password=$d3@pr15mata;port=3306;database=pos;Allow User Variables=True;")
    '        End If

    '        Scom = New MySqlCommand("", Scon)

    '        If Scon.State = ConnectionState.Closed Then
    '            Scon.Open()
    '        End If

    '        nmTransaksi = nmTransaksi.ToUpper

    '        Scom.CommandText = "show tables like 'OtorisasiOperasional';"

    '        If Scom.ExecuteScalar = "" Then
    '            Scom.CommandText = "CREATE TABLE `OtorisasiOperasional` ("
    '            Scom.CommandText &= " `isAktif` CHAR(1) DEFAULT NULL,"
    '            Scom.CommandText &= " `TipeID` INT(11) NOT NULL AUTO_INCREMENT,"
    '            Scom.CommandText &= " `Jenis` VARCHAR(50) DEFAULT NULL,"
    '            Scom.CommandText &= " `isDoubleApproval` CHAR(1) DEFAULT 'Y',"
    '            Scom.CommandText &= " `Jabatan1` VARCHAR(200) DEFAULT NULL,"
    '            Scom.CommandText &= " `Jabatan2` VARCHAR(200) DEFAULT NULL,"
    '            Scom.CommandText &= " PRIMARY KEY (`TipeID`)"
    '            Scom.CommandText &= " ) ENGINE=INNODB AUTO_INCREMENT=0 DEFAULT CHARSET=latin1;"
    '            Scom.ExecuteNonQuery()
    '        End If

    '        Scom.CommandText = "show tables like 'LogScanFinger';"

    '        If Scom.ExecuteScalar = "" Then
    '            Scom.CommandText = "CREATE TABLE `LogScanFinger` ("
    '            Scom.CommandText &= " `TANGGAL` datetime DEFAULT NULL,"
    '            Scom.CommandText &= " `NIK` varchar(15) NOT NULL,"
    '            Scom.CommandText &= " `NAMA` varchar(30) NOT NULL,"
    '            Scom.CommandText &= " `SHIFT` CHAR(2) NOT NULL DEFAULT '',"
    '            Scom.CommandText &= " `STATION` CHAR(2) NOT NULL DEFAULT '',"
    '            Scom.CommandText &= " `KETERANGAN` VARCHAR(200) DEFAULT '',"
    '            Scom.CommandText &= " `STATUS` VARCHAR(30) DEFAULT '',"
    '            Scom.CommandText &= " `PROGRAM` VARCHAR(40) DEFAULT ''"
    '            Scom.CommandText &= " ) ENGINE=INNODB AUTO_INCREMENT=0 DEFAULT CHARSET=latin1;"
    '            Scom.ExecuteNonQuery()
    '        End If

    '        insertTipeTransKeOtorOper(nmTransaksi)

    '        TraceLog(nmFrm & " : cek program scan finger")

    '        If IO.File.Exists(Application.StartupPath & "\ScanFinger.dll") Then
    '            TraceLog(nmFrm & " : ada program scan finger, scan finger/input password - mulai")
    '            Dim sNIK As String = "", sNama As String = "", sStation As String = Environment.GetEnvironmentVariable("STATION")
    '            Scom.CommandText = "SELECT shift FROM initial WHERE RECID='' AND tanggal=CURDATE() AND Station='" & sStation & "'"
    '            Dim sShift As String = Scom.ExecuteScalar() & ""
    '            Dim tess() As String, coba As Integer = 0, kirimData As String = ""

    '            If insertVirBacaprod("MULAI_FINGERSCAN_SO", "ON", "Khusus main finger SO") = "ON" Then
    '                Dim tes As New ScanFinger.ClsScan
    '                tess = tes.Otorisasi_New(nmTransaksi, "Scan Finger Otorisasi untuk proses " & nmTransaksi, sShift, sStation, False)
    '                TraceLog("CekFinger (" & nmTransaksi & ") : " & tess(0) & ", " & tess(1) & ", " & tess(2))
    '            Else
    '                tess = New String() {"1", "sukses", "2013089191|pria|YA|046||DRIVER|JABATAN1"}
    '            End If

    '            If tess(1).ToUpper <> "SUKSES" Then
    '                Insert_LogScanFinger(Scom, "Unknown", "Unknown", "GAGAL - Validasi " & nmTransaksi & " : " & tess(2), "ScanFinger", sShift, sStation)
    '                TraceLog("Cek_Fingerprint : gagal scan finger " & nmTransaksi & " jabatan1 3x")
    '                MsgBox("Data Tidak Ada, NIK tidak ditemukan")
    '            Else
    '                Insert_LogScanFinger(Scom, tess(2).Split("|")(0), "" & Scom.ExecuteScalar(), "Berhasil - Validasi " & nmTransaksi, "ScanFinger", sShift, sStation)
    '                TraceLog("Cek_Fingerprint : berhasil validasi data finger driver")
    '                Panggil_CekFingerprintV3 = tess
    '            End If
    '        Else
    '            TraceLog(nmFrm & " : scan finger/input password - Finger tidak ada & Selesai")
    '            MsgBox("tidak ada program scan finger")
    '        End If
    '        TraceLog(nmFrm & " : scan finger/input password - Selesai")
    '    Catch ex As Exception
    '        TraceLog("Error Panggil_CekFingerprintV3 = " & ex.Message & ex.StackTrace & vbCrLf & "Last Query : " & Scom.CommandText)
    '        ShowError("SO Penanganan Khusus Error Panggil_CekFingerprintV3 = ", ex.Message & ex.StackTrace)
    '    End Try

    '    TraceLog(nmFrm & " : Panggil_CekFingerprintV3 : Selesai ")

    '    Return Panggil_CekFingerprintV3
    'End Function

    'Public Shared Function insertTipeTransKeOtorOper(ByVal sTrans As String) As Boolean
    '    insertTipeTransKeOtorOper = False
    '    Dim Scon As New MySqlConnection
    '    Dim Scom As New MySqlCommand("", Scon)

    '    Try
    '        If isSector Then
    '            Scon = a.GetVersionV2(MyKey, Application.StartupPath & "\SoPenangananKhusus.exe", "kasir")
    '        Else
    '            Scon = New MySqlConnection("server=localhost;user id=root;Password=$d3@pr15mata;port=3306;database=pos;Allow User Variables=True;")
    '        End If

    '        Scom = New MySqlCommand("", Scon)

    '        If Scon.State = ConnectionState.Closed Then
    '            Scon.Open()
    '        End If

    '        Dim listPKomplit As String = "KASIR,KASIR (SS),MERCHANDISER,MERCHANDISER (SS),ASISTEN KEPALA TOKO," &
    '                                     "ASISTEN KEPALA TOKO (SS),KEPALA TOKO,KEPALA TOKO (SS),Chief Of Store (Ss),Store Sr. Leader (Ss)," &
    '                                     "Store Jr. Leader (Ss)"
    '        Dim listPPmpinan As String = "KEPALA TOKO,KEPALA TOKO (SS),ASISTEN KEPALA TOKO,ASISTEN KEPALA TOKO (SS)," &
    '                                     "MERCHANDISER,MERCHANDISER (SS),Chief Of Store (Ss),Store Sr. Leader (Ss),Store Jr. Leader (Ss)"
    '        Dim listPPmpinanArea As String = "Act. Jr. Supervisor,Act. Jr. Manager,Act. Senior Manager,Area Act. Jr. Manager,Area Jr. Manager," &
    '                                            "Area Manager,Junior Manager,Junior Supervisor,Manager,MDP Trainee," &
    '                                            "MDP Specialist Trainee,Supervisor,Supervisor Trainee"

    '        listPKomplit = listPKomplit.ToUpper : listPPmpinan = listPPmpinan.ToUpper : listPPmpinanArea = listPPmpinanArea.ToUpper

    '        Return cekDetailFinger(sTrans, "1", "N", listPPmpinan, listPPmpinan)

    '    Catch ex As Exception
    '        TraceLog("Eror insertTipeTransKeOtorOper " & ex.Message & ex.StackTrace & vbCrLf & "Last query : " & Scom.CommandText)
    '    End Try
    '    Return insertTipeTransKeOtorOper
    'End Function

    'Public Shared Function Insert_LogScanFinger(ByVal objcmd As MySqlCommand, ByVal nik As String, ByVal nama As String, ByVal keterangan As String, ByVal status As String, ByVal shift As String, ByVal station As String) As Boolean
    '    Try
    '        TraceLog("Insert_LogScanFinger : Mulai ")
    '        objcmd.CommandText = "insert into LogScanFinger ("
    '        objcmd.CommandText &= "tanggal,nik,nama,shift,station,keterangan,status,program"
    '        objcmd.CommandText &= ") values ("
    '        objcmd.CommandText &= " '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "',"
    '        objcmd.CommandText &= " '" & nik & "',"
    '        objcmd.CommandText &= " '" & nama & "',"
    '        objcmd.CommandText &= " '" & shift & "',"
    '        objcmd.CommandText &= " '" & station & "',"
    '        objcmd.CommandText &= " '" & keterangan & "',"
    '        objcmd.CommandText &= " '" & status & "',"
    '        objcmd.CommandText &= " 'BA.exe " & Application.ProductVersion & "'"
    '        objcmd.CommandText &= ");"
    '        TraceLog("Insert_LogScanFinger : query  " & objcmd.CommandText)
    '        objcmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        ShowError("SO Penangan Khusus Error Insert_LogScanFinger = ", ex.Message & ex.StackTrace)
    '        TraceLog("Insert_LogScanFinger : Error  " & ex.Message & ex.StackTrace)
    '    End Try
    '    TraceLog("Insert_LogScanFinger : Selesai ")
    'End Function

    'Public Shared Function insertVirBacaprod(ByVal sJenis As String, ByVal sFilter As String, ByVal sKet As String,
    '                                        Optional ByVal sProg As String = "SO.Net", Optional ByVal butuhUpper As Boolean = True)
    '    Dim Scon As New MySqlConnection
    '    Dim Scom As New MySqlCommand("", Scon)

    '    TraceLog("Mulai Scan Finger")

    '    Try
    '        If isSector Then
    '            Scon = MasterMcon.Clone
    '            Scom = New MySqlCommand("", Scon)
    '        Else
    '            Scon = New MySqlConnection("server=localhost;user id=root;Password=$d3@pr15mata;port=3306;database=pos;Allow User Variables=True;")
    '            Scom.Connection = Scon
    '        End If

    '        If Scon.State = ConnectionState.Closed Then
    '            Scon.Open()
    '        End If

    '        Scom.CommandText = "SELECT COUNT(*) FROM vir_bacaprod WHERE program='" & sProg & "' AND jenis='" & sJenis & "'"
    '        TraceLog("insertVirBacaprod-Q1: " & Scom.CommandText)

    '        If Scom.ExecuteScalar() > 0 Then
    '            TraceLog("insertVirBacaprod: Program Ditemukan")
    '            Scom.CommandText = "SELECT ifnull(`FILTER`,'') FROM VIR_BACAPROD WHERE program='" & sProg & "' AND jenis='" & sJenis & "'"
    '            TraceLog("insertVirBacaprod-Q2: " & Scom.CommandText)
    '            If butuhUpper Then
    '                Return Scom.ExecuteScalar().ToString.ToUpper.Trim
    '            Else
    '                Return Scom.ExecuteScalar().ToString.Trim
    '            End If
    '        Else

    '            'rvs HBR 4.1.7 (16-9-19) 'req P'Benny krn fungsi tarik data akan mati kalau addtime toko lebih baru dr addtime server
    '            TraceLog("insertVirBacaprod: Program Tidak Ditemukan")
    '            Scom.CommandText = "Insert Into Vir_BacaProd(jenis,`filter`,KET,program,updid) Values "
    '            TraceLog("insertVirBacaprod-Q2: " & Scom.CommandText)

    '            If sFilter.Contains("'") Then
    '                Scom.CommandText &= "('" & sJenis & "'," & Chr(34) & sFilter & Chr(34) & ","
    '            Else
    '                Scom.CommandText &= "('" & sJenis & "','" & sFilter & "',"
    '            End If

    '            Scom.CommandText &= "'" & sKet & "','" & sProg & "','SO.Net.EXE')"
    '            TraceLog("insertVirBacaprod-Q3: " & Scom.CommandText)
    '            Scom.ExecuteNonQuery()

    '            Scom.CommandText = "SELECT ifnull(`FILTER`,'') FROM VIR_BACAPROD WHERE program='" & sProg & "' AND jenis='" & sJenis & "'"
    '            TraceLog("insertVirBacaprod-Q4: " & Scom.CommandText)
    '            If butuhUpper Then
    '                Return Scom.ExecuteScalar().ToString.ToUpper.Trim
    '            Else
    '                Return Scom.ExecuteScalar().ToString.Trim
    '            End If
    '        End If
    '    Catch ex As Exception
    '        TraceLog("SO Penanganan Khusus Error insertVirBacaprod: " & ex.Message)
    '    End Try
    'End Function

    'Public Shared Function cekDetailFinger(ByVal Transaksi As String, ByVal isAktif As String, ByVal isDA As String,
    '                                        ByVal list1 As String, ByVal list2 As String, Optional ByVal sAbsLok As String = "") As Boolean
    '    cekDetailFinger = False
    '    Dim sMainAbsenLokal As Boolean = False
    '    Dim Scon As New MySqlConnection
    '    Dim Scom As New MySqlCommand("", Scon)

    '    Try
    '        If isSector Then
    '            Scon = a.GetVersionV2(MyKey, Application.StartupPath & "\SoPenangananKhusus.exe", "kasir")
    '        Else
    '            Scon = New MySqlConnection("server=localhost;user id=root;Password=$d3@pr15mata;port=3306;database=pos;Allow User Variables=True;")
    '        End If

    '        Scom = New MySqlCommand("", Scon)

    '        If Scon.State = ConnectionState.Closed Then
    '            Scon.Open()
    '        End If

    '        Transaksi = Transaksi.ToUpper
    '        Scom.CommandText = "SELECT COUNT(*) FROM Information_schema.Columns WHERE TABLE_SCHEMA='pos' "
    '        Scom.CommandText &= "AND Table_Name='OtorisasiOperasional' AND Column_Name='AbsensiLokal';"
    '        sMainAbsenLokal = Scom.ExecuteScalar > 0

    '        TraceLog("Cek_Fingerprint : cek tabel OtorisasiOperasional dan jenis " & Transaksi)
    '        Scom.CommandText = "SELECT COUNT(*) FROM OtorisasiOperasional WHERE jenis='" & Transaksi & "';"
    '        If Scom.ExecuteScalar > 0 Then
    '        Else
    '            Scom.CommandText = "INSERT INTO OtorisasiOperasional (isAktif, Jenis, isDoubleApproval, Jabatan1, Jabatan2"
    '            If sMainAbsenLokal Then
    '                Scom.CommandText &= ",AbsensiLokal"
    '            End If

    '            Scom.CommandText &= ") VALUES ('" & isAktif & "', '" & Transaksi & "', '" & isDA & "', '" & list1 & "', '" & list2 & "'"

    '            If sMainAbsenLokal Then
    '                Scom.CommandText &= ",'" & sAbsLok & "'"
    '            End If

    '            Scom.CommandText &= ");"
    '            TraceLog("Cek_Fingerprint : insert tabel OtorisasiOperasional dan jenis " & Transaksi & " -> " & Scom.CommandText)
    '            Scom.ExecuteNonQuery()
    '        End If
    '        cekDetailFinger = True
    '    Catch ex As Exception
    '        cekDetailFinger = False
    '        ShowError("SO Penanganan Khusus Error cekDetailFinger = ", ex.Message & ex.StackTrace)
    '    End Try
    'End Function

End Class
