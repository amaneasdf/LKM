Imports MySql.Data.MySqlClient
Public Class transaksi_jurnal_kas
    Dim data_ke(99) As String

    Private Sub tketerangan_GotFocus(sender As Object, e As EventArgs) Handles tketerangan.GotFocus, tkode_perkiraan.GotFocus, tjumlah.GotFocus, tno_kuitansi.GotFocus, cmb_jenis_transaksi.GotFocus, tkode_jenis_transaksi.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmb_jenis_transaksi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_jenis_transaksi.KeyPress
        e.KeyChar = Chr(0)
    End Sub
    
    Private Sub tketerangan_LostFocus(sender As Object, e As EventArgs) Handles tketerangan.LostFocus, tkode_perkiraan.LostFocus, tjumlah.LostFocus, tno_kuitansi.LostFocus, cmb_jenis_transaksi.LostFocus, tkode_jenis_transaksi.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub transaksi_jurnal_kas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub transaksi_jurnal_kas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            btnvalidasi.PerformClick()
        ElseIf e.KeyCode = Keys.F7 Then
            btntambah.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub transaksi_jurnal_kas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo()
        kosong()
    End Sub

    Sub carisaldokas()
        cd = New MySqlCommand("SELECT hitung_saldo_perkiraan_akhir(cari_setup_perkiraan('Kas'),'" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd") & "') AS saldokas", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tsaldo_kas.Text = FormatNumber(rd.Item("saldokas"), 0)
        rd.Close()
    End Sub

    Sub combo()
        With cmb_jenis_transaksi.Items
            .Clear()
            .Add("01 : KAS MASUK")
            .Add("02 : KAS KELUAR")
        End With
    End Sub

    Private Sub transaksi_jurnal_kas_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub
    Sub kosong()
        tid_transaksi.Clear()
        tkode_jenis_transaksi.Clear()
        cmb_jenis_transaksi.Text = ""
        tno_kuitansi.Clear()
        carisaldokas()
        tjumlah.Clear()
        tkode_perkiraan.Clear()
        cariperkiraan()
        tketerangan.Clear()

        Timer1.Enabled = True
        tkode_jenis_transaksi.Enabled = True
        cmb_jenis_transaksi.Enabled = True
        tno_kuitansi.Enabled = True
        tjumlah.Enabled = True
        tkode_perkiraan.Enabled = True
        Button1.Enabled = True
        tketerangan.Enabled = True
        btnvalidasi.Enabled = True
        tkode_jenis_transaksi.Focus()
    End Sub

    Sub simpan()
        notransaksi()
        data_ke(0) = tid_transaksi.Text
        data_ke(1) = cmb_jenis_transaksi.Text.ToString.Split(" :")(0)
        data_ke(2) = tno_kuitansi.Text
        data_ke(3) = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        data_ke(4) = Format(DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        data_ke(5) = Format(tjumlah.Text, "General Number")
        data_ke(6) = tkode_perkiraan.Text
        data_ke(7) = tketerangan.Text
        data_ke(8) = "1"
        data_ke(9) = MDIParent1.username.Text
        Dim gabung = ""
        For n = 0 To 9
            If n = 0 Then
                gabung += "'" + data_ke(n) + "'"
            Else
                gabung += ",'" + data_ke(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_akuntansi_transaksi_kas VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Melakukan Transaksi Jurnal Kas (kas_id_transaksi : " + data_ke(0) + ")"
        insert_log_user()

        Timer1.Enabled = False
        tkode_jenis_transaksi.Enabled = False
        cmb_jenis_transaksi.Enabled = False
        tno_kuitansi.Enabled = False
        tjumlah.Enabled = False
        tkode_perkiraan.Enabled = False
        Button1.Enabled = False
        tketerangan.Enabled = False
        btnvalidasi.Enabled = False
        If MessageBox.Show("Cetak Validasi?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cetakvalidasi()
        End If
        MessageBox.Show("Transaksi berhasil divalidasi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        btntambah.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateTimePicker1.Text = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub tjumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tjumlah.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tjumlah_TextChanged(sender As Object, e As EventArgs) Handles tjumlah.TextChanged
        Try
            tjumlah.Text = FormatNumber(tjumlah.Text, 0)
            tjumlah.SelectionStart = Len(tjumlah.Text)
        Catch ex As Exception
            tjumlah.Text = "0"
        End Try
        hitung()
    End Sub
    Private Sub tkode_jenis_transaksi_LostFocus(sender As Object, e As EventArgs) Handles tkode_jenis_transaksi.LostFocus
        carijenistransaksi()
    End Sub
    Sub carijenistransaksi()
        Select Case tkode_jenis_transaksi.Text
            Case "01"
                cmb_jenis_transaksi.Text = "01 : TELLER MASUK"
            Case "02"
                cmb_jenis_transaksi.Text = "02 : TELLER KELUAR"
            Case Else
                cmb_jenis_transaksi.Text = ""
        End Select
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kosong()
    End Sub

    Private Sub btnvalidasi_Click(sender As Object, e As EventArgs) Handles btnvalidasi.Click
        If cmb_jenis_transaksi.Text = "" Then
            MessageBox.Show("Jenis transaksi harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmb_jenis_transaksi.Focus()
            Exit Sub
        ElseIf tjumlah.Text = "0" Then
            MessageBox.Show("Jumlah transaksi harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjumlah.Focus()
            Exit Sub
        ElseIf tkode_perkiraan.Text = "" And tnama_perkiraan1.Text = "" And tnama_perkiraan2.Text = "" Then
            MessageBox.Show("Kode perkiraan harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_perkiraan.Focus()
            Exit Sub
        ElseIf tkode_perkiraan.Text <> "" And tnama_perkiraan1.Text = "" And tnama_perkiraan2.Text = "" Then
            MessageBox.Show("Kode perkiraan tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_perkiraan.Focus()
            Exit Sub
        ElseIf tketerangan.Text = "" Then
            MessageBox.Show("Keterangan transaksi harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tketerangan.Focus()
            Exit Sub
        ElseIf Val(Replace(tsaldo2.Text, ".", "")) < 0 Then
            MessageBox.Show("Saldo akhir perkiraan (" + tkode_perkiraan.Text + " " + tnama_perkiraan1.Text + ") minus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_perkiraan.Focus()
            Exit Sub
        End If
        simpan()
    End Sub
    Sub notransaksi()
        cd = New MySqlCommand("SELECT IFNULL(MAX(RIGHT(kas_id_transaksi,5)), '0') AS trans FROM data_akuntansi_transaksi_kas WHERE kas_tanggal='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tid_transaksi.Text = tkode_jenis_transaksi.Text + "." + Format(DateTimePicker1.Value, "ddMMyyyy").ToString + "." + Microsoft.VisualBasic.Right("00000" & Microsoft.VisualBasic.Right(rd.Item("trans"), 5) + 1, 5)
        rd.Close()
    End Sub

    Private Sub cmb_jenis_transaksi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_jenis_transaksi.SelectedIndexChanged
        tkode_jenis_transaksi.Text = cmb_jenis_transaksi.Text.ToString.Split(" :")(0)
        hitung()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With pencarian_perkiraan
            .Label4.Text = "transaksi_jurnal_kas"
            .ShowDialog()
        End With
    End Sub

    Sub cariperkiraan()
        cd = New MySqlCommand("SELECT perkiraan_kode, perkiraan_nama, perkiraan_d_or_k, hitung_saldo_perkiraan_akhir(perkiraan_kode,NOW()) AS saldo_akhir FROM kode_perkiraan WHERE perkiraan_kode='" & tkode_perkiraan.Text & "' AND perkiraan_jurnal='1'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_perkiraan1.Text = rd.Item("perkiraan_nama")
            tnama_perkiraan2.Text = rd.Item("perkiraan_d_or_k")
            tsaldo1.Text = FormatNumber(rd.Item("saldo_akhir"), 0)
        Catch ex As Exception
            tnama_perkiraan1.Clear()
            tnama_perkiraan2.Clear()
            tsaldo1.Text = "0"
        End Try
        rd.Close()
        hitung()
    End Sub
    Private Sub tkode_perkiraan_LostFocus(sender As Object, e As EventArgs) Handles tkode_perkiraan.LostFocus
        cariperkiraan()
    End Sub
    Sub hitung()
        If cmb_jenis_transaksi.Text <> "" And tnama_perkiraan1.Text <> "" And tnama_perkiraan2.Text <> "" Then
            If (cmb_jenis_transaksi.Text.ToString.Split(" :")(0) = "01" And tnama_perkiraan2.Text = "K") Or (cmb_jenis_transaksi.Text.ToString.Split(" :")(0) = "02" And tnama_perkiraan2.Text = "D") Then
                tsaldo2.Text = FormatNumber(Val(Format(tsaldo1.Text, "General Number")) + Val(Format(tjumlah.Text, "General Number")), 0)
            Else
                tsaldo2.Text = FormatNumber(Val(Format(tsaldo1.Text, "General Number")) - Val(Format(tjumlah.Text, "General Number")), 0)
            End If
        Else
            tsaldo2.Text = "0"
        End If
    End Sub

    Private Sub tkode_perkiraan_TextChanged(sender As Object, e As EventArgs) Handles tkode_perkiraan.TextChanged

    End Sub

    Sub cetakvalidasi()
        Dim ukuran(99) As String
        Dim cetakan As String = ""
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""

        For ii As Integer = 1 To 3
            If ii = 1 Then
                cetakan = "KiriVKas"
            ElseIf ii = 2 Then
                cetakan = "AtasVKas"
            ElseIf ii = 3 Then
                cetakan = "FontVKas"
            End If
            cd = New MySqlCommand("SELECT IFNULL(cetakan_ukuran, 0) AS ukuran FROM setup_cetakan WHERE cetakan_nama='" & cetakan & "' ", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            ukuran(ii) = rd.Item("ukuran")
            rd.Close()
        Next
        kiri = ukuran(1)
        atas = ukuran(2)
        ukuran_font_cetak = ukuran(3)

        isivalidasi()
        Dim printControl = New Printing.StandardPrintController
        MDIParent1.PrintDocument1.PrintController = printControl
        Try
            MDIParent1.PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Printer gagal", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub
    Sub isivalidasi()
        Dim baris(99) As String

        cd = New MySqlCommand("SELECT kas_id_transaksi, kas_waktu, kas_username, kas_kode_transaksi, kas_jumlah, kas_kode_perkiraan, cari_nama_perkiraan(kas_kode_perkiraan) AS namaperkiraan, cari_teller(kas_username) AS kode_teller FROM data_akuntansi_transaksi_kas WHERE kas_id_transaksi='" & tid_transaksi.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()

        baris(0) = rd.Item("kas_id_transaksi") + " " + Format(rd.Item("kas_waktu"), "dd/MM/yy HH:mm:ss").ToString + " [" + rd.Item("kode_teller") + "]"
        baris(1) = rd.Item("kas_kode_transaksi").ToString + " CASH IDR " + FormatNumber(rd.Item("kas_jumlah"), 0)
        baris(2) = rd.Item("kas_kode_perkiraan").ToString + " " + rd.Item("namaperkiraan").ToString

        rd.Close()

        For i = 0 To UBound(baris) ' UBound = batas atas array
            TextToPrint &= baris(i) & Environment.NewLine
        Next i

    End Sub
End Class