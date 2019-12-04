Imports MySql.Data.MySqlClient

Public Class setup_cetakan
    Dim data_ke(99), data_field(99), dataa(99) As String
    Dim tampilkan_nomor As String
    Private Sub setup_cetakan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub setup_cetakan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        ukuran()
        data_cover()
        data_kolom_buku_tabungan()
        combo()

        caridata()

        Me.ResizeRedraw = True
        'MsgBox(ListView2.Items(0).SubItems(1).Text)
    End Sub

    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Ke", 50, HorizontalAlignment.Left)
            .Add("Isian", 250, HorizontalAlignment.Left)
        End With

        With ListView2.Columns
            .Clear()
            .Add("Ke", 50, HorizontalAlignment.Left)
            .Add("Kolom", 200, HorizontalAlignment.Left)
            .Add("Ukuran", 70, HorizontalAlignment.Left)
        End With
    End Sub

    Sub data_cover()
        da = New MySqlDataAdapter("SELECT * FROM setup_cover_buku_tabungan ORDER BY cover_urutan ASC", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("cover_urutan"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("cover_isian"))
            Next
        End With
    End Sub

    Sub data_kolom_buku_tabungan()
        da = New MySqlDataAdapter("SELECT * FROM setup_kolom_buku_tabungan WHERE kolom_jenis='" & cmbtemplate.Text & "' ORDER BY kolom_urutan ASC", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView2
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("kolom_urutan"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kolom_isian"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kolom_ukuran"))
            Next
        End With
    End Sub

    Sub combo()
        With cmbcover.Items
            .Clear()
            .Add("")
            .Add("01 : NO KTP")
            .Add("02 : ID NASABAH")
            .Add("03 : NO REKENING")
            .Add("04 : NAMA NASABAH")
            .Add("05 : ALAMAT")
            .Add("06 : TANGGAL REGISTRASI")
        End With
        cmbcover.SelectedIndex = 0

        With cmbtemplate.Items
            .Clear()
            .Add("1 : TEMPLATE 1")
            .Add("2 : TEMPLATE 2")
            .Add("3 : TEMPLATE 3")
        End With
        cmbtemplate.SelectedIndex = 0

        With cmbkolom_buku_tabungan.Items
            .Clear()
            .Add("")
            .Add("01 : TANGGAL")
            .Add("02 : KODE")
            .Add("03 : DEBET")
            .Add("04 : KREDIT")
            .Add("05 : URAIAN")
            .Add("06 : MUTASI")
            .Add("07 : D/K")
            .Add("08 : SALDO")
            .Add("09 : TELLER")
        End With
        cmbkolom_buku_tabungan.SelectedIndex = 0
    End Sub

    Private Sub setup_cetakan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub tatas_bukutabungan_GotFocus(sender As Object, e As EventArgs) Handles tkiri_vtabungan.GotFocus, tatas_vtabungan.GotFocus, tfont_vtabungan.GotFocus, tkiri_vrealisasi.GotFocus, tatas_vrealisasi.GotFocus, tfont_vrealisasi.GotFocus, tkiri_vangsuran.GotFocus, tatas_vangsuran.GotFocus, tfont_vangsuran.GotFocus, tkiri_vkas.GotFocus, tatas_vkas.GotFocus, tfont_vkas.GotFocus, tkiri_vnonkas.GotFocus, tatas_vnonkas.GotFocus, tfont_vnonkas.GotFocus, tkiri_cover.GotFocus, tatas_cover.GotFocus, tfont_cover.GotFocus, tkiri_bukutabungan.GotFocus, tatas_bukutabungan.GotFocus, tfont_bukutabungan.GotFocus, tjeda_tengah.GotFocus, cmbcover.GotFocus, cmbtemplate.GotFocus, tukuran_buku_tabungan.GotFocus, cmbkolom_buku_tabungan.GotFocus, tbaris_atas.GotFocus, tbaris_bawah.GotFocus

        sender.backcolor = warna_gotfocus
    End Sub

    Private Sub tatas_bukutabungan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tkiri_vtabungan.KeyPress, tatas_vtabungan.KeyPress, tfont_vtabungan.KeyPress, tkiri_vrealisasi.KeyPress, tatas_vrealisasi.KeyPress, tfont_vrealisasi.KeyPress, tkiri_vangsuran.KeyPress, tatas_vangsuran.KeyPress, tfont_vangsuran.KeyPress, tkiri_vkas.KeyPress, tatas_vkas.KeyPress, tfont_vkas.KeyPress, tkiri_vnonkas.KeyPress, tatas_vnonkas.KeyPress, tfont_vnonkas.KeyPress, tkiri_cover.KeyPress, tatas_cover.KeyPress, tfont_cover.KeyPress, tkiri_bukutabungan.KeyPress, tatas_bukutabungan.KeyPress, tfont_bukutabungan.KeyPress, tjeda_tengah.KeyPress, tukuran_buku_tabungan.KeyPress

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub cmbtemplate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbtemplate.KeyPress, cmbcover.KeyPress, cmbkolom_buku_tabungan.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub tkiri_vtabungan_LostFocus(sender As Object, e As EventArgs) Handles tkiri_vtabungan.LostFocus, tatas_vtabungan.LostFocus, tfont_vtabungan.LostFocus, tkiri_vrealisasi.LostFocus, tatas_vrealisasi.LostFocus, tfont_vrealisasi.LostFocus, tkiri_vangsuran.LostFocus, tatas_vangsuran.LostFocus, tfont_vangsuran.LostFocus, tkiri_vkas.LostFocus, tatas_vkas.LostFocus, tfont_vkas.LostFocus, tkiri_vnonkas.LostFocus, tatas_vnonkas.LostFocus, tfont_vnonkas.LostFocus, tkiri_cover.LostFocus, tatas_cover.LostFocus, tfont_cover.LostFocus, tkiri_bukutabungan.LostFocus, tatas_bukutabungan.LostFocus, tfont_bukutabungan.LostFocus, tjeda_tengah.LostFocus, cmbcover.LostFocus, cmbtemplate.LostFocus, cmbkolom_buku_tabungan.LostFocus, tukuran_buku_tabungan.LostFocus, tbaris_atas.LostFocus, tbaris_bawah.LostFocus

        sender.backcolor = warna_lostfocus

    End Sub

    Private Sub tatas_bukutabungan_TextChanged(sender As Object, e As EventArgs) Handles tkiri_vtabungan.TextChanged, tatas_vtabungan.TextChanged, tfont_vtabungan.TextChanged, tkiri_vrealisasi.TextChanged, tatas_vrealisasi.TextChanged, tfont_vrealisasi.TextChanged, tkiri_vangsuran.TextChanged, tatas_vangsuran.TextChanged, tfont_vangsuran.TextChanged, tkiri_vkas.TextChanged, tatas_vkas.TextChanged, tfont_vkas.TextChanged, tkiri_vnonkas.TextChanged, tatas_vnonkas.TextChanged, tfont_vnonkas.TextChanged, tkiri_cover.TextChanged, tatas_cover.TextChanged, tfont_cover.TextChanged, tkiri_bukutabungan.TextChanged, tatas_bukutabungan.TextChanged, tfont_bukutabungan.TextChanged, tjeda_tengah.TextChanged, tbaris_atas.TextChanged, tbaris_bawah.TextChanged, tukuran_buku_tabungan.TextChanged
        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tfont_vtabungan.Text = "0" Then
            MessageBox.Show("Ukuran font tidak bisa 0", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tfont_vtabungan.Focus()
            Exit Sub
        ElseIf tfont_vrealisasi.Text = "0" Then
            MessageBox.Show("Ukuran font tidak bisa 0", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tfont_vrealisasi.Focus()
            Exit Sub
        ElseIf tfont_vangsuran.Text = "0" Then
            MessageBox.Show("Ukuran font tidak bisa 0", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tfont_vangsuran.Focus()
            Exit Sub
        ElseIf tfont_vkas.Text = "0" Then
            MessageBox.Show("Ukuran font tidak bisa 0", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tfont_vkas.Focus()
            Exit Sub
        ElseIf tfont_vnonkas.Text = "0" Then
            MessageBox.Show("Ukuran font tidak bisa 0", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tfont_vnonkas.Focus()
            Exit Sub
        ElseIf tfont_cover.Text = "0" Then
            MessageBox.Show("Ukuran font tidak bisa 0", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tfont_cover.Focus()
            Exit Sub
        ElseIf tfont_bukutabungan.Text = "0" Then
            MessageBox.Show("Ukuran font tidak bisa 0", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tfont_bukutabungan.Focus()
            Exit Sub
            'ElseIf tmaksimal_baris.Text = "0" Then
            'MessageBox.Show("Maksimal baris tidak bisa 0", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'tmaksimal_baris.Focus()
            'Exit Sub
        End If
        simpan()
    End Sub

    Sub array_data_field()
        data_field(1) = "KiriVTabungan"
        data_field(2) = "AtasVTabungan"
        data_field(3) = "FontVTabungan"
        data_field(4) = "KiriVRealisasi"
        data_field(5) = "AtasVRealisasi"
        data_field(6) = "FontVRealisasi"
        data_field(7) = "KiriVAngsuran"
        data_field(8) = "AtasVAngsuran"
        data_field(9) = "FontVAngsuran"
        data_field(10) = "KiriVKas"
        data_field(11) = "AtasVKas"
        data_field(12) = "FontVKas"
        data_field(13) = "KiriVNonKas"
        data_field(14) = "AtasVNonKas"
        data_field(15) = "FontVNonKas"
        data_field(16) = "KiriCover"
        data_field(17) = "AtasCover"
        data_field(18) = "FontCover"
        data_field(19) = "KiriBukuTabungan"
        data_field(20) = "AtasBukuTabungan"
        data_field(21) = "FontBukuTabungan"
        data_field(22) = "JedaBukuTabungan"
        data_field(23) = "BarisAtasBukuTabungan"
        data_field(24) = "BarisBawahBukuTabungan"
        data_field(25) = "TampilkanNomor"
    End Sub

    Sub array_data_ke()
        data_ke(1) = tkiri_vtabungan.Text
        data_ke(2) = tatas_vtabungan.Text
        data_ke(3) = tfont_vtabungan.Text
        data_ke(4) = tkiri_vrealisasi.Text
        data_ke(5) = tatas_vrealisasi.Text
        data_ke(6) = tfont_vrealisasi.Text
        data_ke(7) = tkiri_vangsuran.Text
        data_ke(8) = tatas_vangsuran.Text
        data_ke(9) = tfont_vangsuran.Text
        data_ke(10) = tkiri_vkas.Text
        data_ke(11) = tatas_vkas.Text
        data_ke(12) = tfont_vkas.Text
        data_ke(13) = tkiri_vnonkas.Text
        data_ke(14) = tatas_vnonkas.Text
        data_ke(15) = tfont_vnonkas.Text
        data_ke(16) = tkiri_cover.Text
        data_ke(17) = tatas_cover.Text
        data_ke(18) = tfont_cover.Text
        data_ke(19) = tkiri_bukutabungan.Text
        data_ke(20) = tatas_bukutabungan.Text
        data_ke(21) = tfont_bukutabungan.Text
        data_ke(22) = tjeda_tengah.Text
        data_ke(23) = tbaris_atas.Text
        data_ke(24) = tbaris_bawah.Text
        If CheckBox1.Checked = True Then
            data_ke(25) = "1"
        Else
            data_ke(25) = "0"
        End If
        'data_ke(23) = tmaksimal_baris.Text
    End Sub
    Sub simpan()
        array_data_field()
        array_data_ke()

        cd = New MySqlCommand("DELETE FROM setup_cetakan", koneksi)
        cd.ExecuteNonQuery()

        For i As Integer = 1 To 25
            cd = New MySqlCommand("INSERT INTO setup_cetakan VALUES ('', '" & data_field(i) & "', '" & data_ke(i) & "')", koneksi)
            cd.ExecuteNonQuery()
            'cd = New MySqlCommand("UPDATE setup_cetakan SET cetakan_ukuran = '" & data_ke(i) & "' WHERE cetakan_nama='" & data_field(i) & "'", koneksi)
            'cd.ExecuteNonQuery()
        Next

        user_pengguna = MDIParent1.username.Text
        uraian = "Melakukan perbaikan pengaturan cetakan"
        insert_log_user()

        MessageBox.Show("Pengaturan Cetakan berhasil diperbaiki.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Sub caridata()
        array_data_field()

        For ii As Integer = 1 To 25
            cd = New MySqlCommand("SELECT IFNULL(cetakan_ukuran, 0) AS ukuran FROM setup_cetakan WHERE cetakan_nama='" & data_field(ii) & "' ", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            dataa(ii) = rd.Item("ukuran")
            rd.Close()
        Next
        tkiri_vtabungan.Text = dataa(1)
        tatas_vtabungan.Text = dataa(2)
        tfont_vtabungan.Text = dataa(3)
        tkiri_vrealisasi.Text = dataa(4)
        tatas_vrealisasi.Text = dataa(5)
        tfont_vrealisasi.Text = dataa(6)
        tkiri_vangsuran.Text = dataa(7)
        tatas_vangsuran.Text = dataa(8)
        tfont_vangsuran.Text = dataa(9)
        tkiri_vkas.Text = dataa(10)
        tatas_vkas.Text = dataa(11)
        tfont_vkas.Text = dataa(12)
        tkiri_vnonkas.Text = dataa(13)
        tatas_vnonkas.Text = dataa(14)
        tfont_vnonkas.Text = dataa(15)
        tkiri_cover.Text = dataa(16)
        tatas_cover.Text = dataa(17)
        tfont_cover.Text = dataa(18)
        tkiri_bukutabungan.Text = dataa(19)
        tatas_bukutabungan.Text = dataa(20)
        tfont_bukutabungan.Text = dataa(21)
        tjeda_tengah.Text = dataa(22)
        tbaris_atas.Text = dataa(23)
        tbaris_bawah.Text = dataa(24)
        If dataa(25) = "1" Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            turutan_cover.Text = ListView1.SelectedItems(0).Text
            cmbcover.Text = ListView1.SelectedItems(0).SubItems(1).Text
        Catch ex As Exception
            turutan_cover.Text = ""
            cmbcover.Text = ""
        End Try

    End Sub

    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btnsimpan_cover.Click
        'ListView1.SelectedItems(0).SubItems(1).Text = cmbcover.Text
        cd = New MySqlCommand("UPDATE setup_cover_buku_tabungan SET cover_isian = '" & cmbcover.Text & "' WHERE cover_urutan='" & turutan_cover.Text & "'", koneksi)
        cd.ExecuteNonQuery()
        data_cover()
        turutan_cover.Clear()
        cmbcover.Text = ""
    End Sub

    Private Sub turutan_cover_TextChanged(sender As Object, e As EventArgs) Handles turutan_cover.TextChanged
        If turutan_cover.Text = "" Then
            btnsimpan_cover.Enabled = False
        Else
            btnsimpan_cover.Enabled = True
        End If
    End Sub

    Private Sub cmbtemplate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtemplate.SelectedIndexChanged
        data_kolom_buku_tabungan()
        turutan_buku_tabungan.Clear()
        cmbkolom_buku_tabungan.Text = ""
        tukuran_buku_tabungan.Clear()
    End Sub


    Private Sub turutan_buku_tabungan_TextChanged(sender As Object, e As EventArgs) Handles turutan_buku_tabungan.TextChanged
        If turutan_buku_tabungan.Text = "" Then
            btnsimpan_kolom_buku_tabungan.Enabled = False
        Else
            btnsimpan_kolom_buku_tabungan.Enabled = True
        End If
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged
        Try
            turutan_buku_tabungan.Text = ListView2.SelectedItems(0).Text
            cmbkolom_buku_tabungan.Text = ListView2.SelectedItems(0).SubItems(1).Text
            tukuran_buku_tabungan.Text = ListView2.SelectedItems(0).SubItems(2).Text
        Catch ex As Exception
            turutan_buku_tabungan.Text = ""
            cmbkolom_buku_tabungan.Text = ""
            tukuran_buku_tabungan.Text = 0
        End Try
    End Sub

    Private Sub btnsimpan_kolom_buku_tabungan_Click(sender As Object, e As EventArgs) Handles btnsimpan_kolom_buku_tabungan.Click
        If tukuran_buku_tabungan.Text = "0" And cmbkolom_buku_tabungan.Text <> "" Then
            MessageBox.Show("Ukuran tidak bisa 0", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tukuran_buku_tabungan.Focus()
            Exit Sub
        End If
        cd = New MySqlCommand("UPDATE setup_kolom_buku_tabungan SET kolom_isian = '" & cmbkolom_buku_tabungan.Text & "', kolom_ukuran='" & tukuran_buku_tabungan.Text & "' WHERE kolom_urutan='" & turutan_buku_tabungan.Text & "' AND kolom_jenis='" & cmbtemplate.Text & "'", koneksi)
        cd.ExecuteNonQuery()
        data_kolom_buku_tabungan()
        turutan_buku_tabungan.Clear()
        cmbkolom_buku_tabungan.Text = ""
        tukuran_buku_tabungan.Clear()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""
        kiri = tkiri_vtabungan.Text
        atas = tatas_vtabungan.Text
        ukuran_font_cetak = tfont_vtabungan.Text
        test_validasi_tabungan()
        Dim printControl = New Printing.StandardPrintController
        MDIParent1.PrintDocument1.PrintController = printControl
        Try
            MDIParent1.PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Printer gagal", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Sub test_validasi_tabungan()
        Dim baris(99) As String

        baris(0) = "00." + Format(Now, "ddMMyyyy") + ".00001 " + Format(Now, "dd/MM/yy HH:mm:ss") + " [000]"
        baris(1) = "00 CASH IDR " + FormatNumber(1000000, 0) + " Adm " + FormatNumber(5000, 0)
        baris(2) = "uraian transaksi tabungan"

        For i = 0 To UBound(baris) ' UBound = batas atas array
            TextToPrint &= baris(i) & Environment.NewLine
        Next i
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""
        kiri = tkiri_vrealisasi.Text
        atas = tatas_vrealisasi.Text
        ukuran_font_cetak = tfont_vrealisasi.Text
        test_validasi_realisasi()
        Dim printControl = New Printing.StandardPrintController
        MDIParent1.PrintDocument1.PrintController = printControl
        Try
            MDIParent1.PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Printer gagal", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Sub test_validasi_realisasi()
        Dim baris(99) As String

        baris(0) = "00." + Format(Now, "ddMMyyyy") + ".00001 " + Format(Now, "dd/MM/yy HH:mm:ss") + " [000]"
        baris(1) = "00 CASH IDR " + FormatNumber(6500000, 0) + " (Rls), " + FormatNumber(100000, 0) + " (Prv), " + FormatNumber(10000, 0) + " (Adm), " + FormatNumber(6000, 0) + " (Mtrai), " + FormatNumber(15000, 0) + " (Premi), " + FormatNumber(17500, 0) + " (Ntrs), " + FormatNumber(5000, 0) + " (Lain2)"
        baris(2) = "nama nasabah 01.010101"

        For i = 0 To UBound(baris) ' UBound = batas atas array
            TextToPrint &= baris(i) & Environment.NewLine
        Next i
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""
        kiri = tkiri_vangsuran.Text
        atas = tatas_vangsuran.Text
        ukuran_font_cetak = tfont_vangsuran.Text
        tes_validasi_angsuran_kredit()
        Dim printControl = New Printing.StandardPrintController
        MDIParent1.PrintDocument1.PrintController = printControl
        Try
            MDIParent1.PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Printer gagal", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Sub tes_validasi_angsuran_kredit()
        Dim baris(99) As String

        baris(0) = "00." + Format(Now, "ddMMyyyy") + ".00001 " + Format(Now, "dd/MM/yy HH:mm:ss") + " [000]"
        baris(1) = "00 CASH " + FormatNumber(250000, 0) + " (Pokok), " + FormatNumber(25000, 0) + " (Bunga), " + FormatNumber(7500, 0) + " (Denda)"
        baris(2) = "uraian transakai angsuran kredit"

        For i = 0 To UBound(baris) ' UBound = batas atas array
            TextToPrint &= baris(i) & Environment.NewLine
        Next i
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""
        kiri = tkiri_vkas.Text
        atas = tatas_vkas.Text
        ukuran_font_cetak = tfont_vkas.Text
        tes_validasi_transaksi_jurnal_kas()
        Dim printControl = New Printing.StandardPrintController
        MDIParent1.PrintDocument1.PrintController = printControl
        Try
            MDIParent1.PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Printer gagal", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Sub tes_validasi_transaksi_jurnal_kas()
        Dim baris(99) As String

        baris(0) = "00." + Format(Now, "ddMMyyyy") + ".00001 " + Format(Now, "dd/MM/yy HH:mm:ss") + " [000]"
        baris(1) = "00 CASH IDR " + FormatNumber(2000000, 0)
        baris(2) = "2.201.03         - BTK - Gaji Pokok"

        For i = 0 To UBound(baris) ' UBound = batas atas array
            TextToPrint &= baris(i) & Environment.NewLine
        Next i
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""
        kiri = tkiri_vnonkas.Text
        atas = tatas_vnonkas.Text
        ukuran_font_cetak = tfont_vnonkas.Text
        tes_validasi_transaksi_jurnal_nonkas()
        Dim printControl = New Printing.StandardPrintController
        MDIParent1.PrintDocument1.PrintController = printControl
        Try
            MDIParent1.PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Printer gagal", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Sub tes_validasi_transaksi_jurnal_nonkas()
        Dim baris(99) As String

        baris(0) = "00." + Format(Now, "ddMMyyyy") + ".00001 " + Format(Now, "dd/MM/yy HH:mm:ss") + " [000]"
        baris(1) = "00 OVERBOOKING IDR " + FormatNumber(500000, 0)
        baris(2) = "D 1.200.30.03,  K 1.200.30.99"

        For i = 0 To UBound(baris) ' UBound = batas atas array
            TextToPrint &= baris(i) & Environment.NewLine
        Next i
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""
        kiri = tkiri_cover.Text
        atas = tatas_cover.Text
        ukuran_font_cetak = tfont_cover.Text
        tes_cover_buku_tabungan()
        Dim printControl = New Printing.StandardPrintController
        MDIParent1.PrintDocument1.PrintController = printControl
        Try
            MDIParent1.PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Printer gagal", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Sub tes_cover_buku_tabungan()
        Dim baris(99) As String

        For ii As Integer = 1 To ListView1.Items.Count
            If ListView1.Items(ii - 1).SubItems(1).Text <> "" Then
                Select Case ListView1.Items(ii - 1).SubItems(1).Text.Split(" :")(0)
                    Case "01"
                        baris(ii - 1) = "3303060101010001"
                    Case "02"
                        baris(ii - 1) = "000001"
                    Case "03"
                        baris(ii - 1) = "01.00001"
                    Case "04"
                        baris(ii - 1) = "NAMA NASABAH"
                    Case "05"
                        baris(ii - 1) = "Alamat, Kelurahan, Kecamatan"
                    Case "06"
                        baris(ii - 1) = Format(Now, "dd/MM/yyyy")
                    Case Else
                        baris(ii - 1) = ""
                End Select
            End If
        Next

        For i = 0 To UBound(baris) ' UBound = batas atas array
            If baris(i) <> "" Then
                TextToPrint &= baris(i) & Environment.NewLine
            End If
        Next i
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""
        kiri = tkiri_bukutabungan.Text
        atas = tatas_bukutabungan.Text
        ukuran_font_cetak = tfont_bukutabungan.Text
        tes_buku_tabungan()
        Dim printControl = New Printing.StandardPrintController
        MDIParent1.PrintDocument1.PrintController = printControl
        Try
            MDIParent1.PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Printer gagal", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Sub tes_buku_tabungan()
        Dim isian(99) As String
        Dim urutan(99) As String
        Dim max_karakter As Integer
        Dim kd, debet, kredit, trans, saldoakhir, mutasi, d_or_k As String
        Dim i As Integer = 1

        debet = 0
        kredit = 0
        saldoakhir = 0
        Do Until i - 1 = Val(tbaris_atas.Text) + Val(tbaris_bawah.Text) 'tmaksimal_baris.Text
            'urutan(0) = Format(i, "0#").ToString

            If Val(i) Mod 2 = 0 Then
                kd = "02"
                debet = 10000
                kredit = 0
                trans = "Penarikan Tunai"
                mutasi = 10000
                d_or_k = "D"
            Else
                kd = "01"
                debet = 0
                kredit = 15000
                trans = "Setoran Tunai"
                mutasi = 15000
                d_or_k = "K"
            End If
            saldoakhir = Val(saldoakhir) + Val(kredit) - Val(debet)

            For kolom As Integer = 1 To ListView2.Items.Count
                If ListView2.Items(kolom - 1).SubItems(1).Text <> "" Then
                    max_karakter = ListView2.Items(kolom - 1).SubItems(2).Text
                    Select Case ListView2.Items(kolom - 1).SubItems(1).Text.Split(" :")(0)
                        Case "01" 'tanggal
                            isian(kolom - 1) = Microsoft.VisualBasic.Left(Format(Now, "dd/MM/yy"), max_karakter)
                            urutan(kolom - 1) = isian(kolom - 1) + StrDup((max_karakter - Len(isian(kolom - 1))), " ") + " "
                        Case "02" 'kode
                            isian(kolom - 1) = Microsoft.VisualBasic.Left(kd, max_karakter)
                            urutan(kolom - 1) = isian(kolom - 1) + StrDup((max_karakter - Len(isian(kolom - 1))), " ") + " "
                        Case "03" 'debet
                            isian(kolom - 1) = Microsoft.VisualBasic.Right(FormatNumber(debet, 0), max_karakter)
                            urutan(kolom - 1) = StrDup((max_karakter - Len(isian(kolom - 1))), " ") + isian(kolom - 1) + "  "
                        Case "04" 'kredit
                            isian(kolom - 1) = Microsoft.VisualBasic.Right(FormatNumber(kredit, 0), max_karakter)
                            urutan(kolom - 1) = StrDup((max_karakter - Len(isian(kolom - 1))), " ") + isian(kolom - 1) + "  "
                        Case "05" 'uraian
                            isian(kolom - 1) = Microsoft.VisualBasic.Left(trans, max_karakter)
                            urutan(kolom - 1) = isian(kolom - 1) + StrDup((max_karakter - Len(isian(kolom - 1))), " ") + " "
                        Case "06" 'mutasi
                            isian(kolom - 1) = Microsoft.VisualBasic.Right(FormatNumber(mutasi, 0), max_karakter)
                            urutan(kolom - 1) = StrDup((max_karakter - Len(isian(kolom - 1))), " ") + isian(kolom - 1) + "  "
                        Case "07" 'd/k
                            isian(kolom - 1) = Microsoft.VisualBasic.Left(d_or_k, max_karakter)
                            urutan(kolom - 1) = isian(kolom - 1) + StrDup((max_karakter - Len(isian(kolom - 1))), " ") + " "
                        Case "08" 'saldo
                            isian(kolom - 1) = Microsoft.VisualBasic.Right(FormatNumber(saldoakhir, 0), max_karakter)
                            urutan(kolom - 1) = StrDup((max_karakter - Len(isian(kolom - 1))), " ") + isian(kolom - 1) + "  "
                        Case "09" 'teller
                            isian(kolom - 1) = Microsoft.VisualBasic.Left("000", max_karakter)
                            urutan(kolom - 1) = isian(kolom - 1) + StrDup((max_karakter - Len(isian(kolom - 1))), " ") + " "
                        Case Else
                            urutan(kolom - 1) = " "
                    End Select
                End If
            Next

            Dim semuaurutan As String = ""
            For ii = 0 To UBound(urutan) ' UBound = batas atas array
                If urutan(ii) <> "" Then
                    semuaurutan = semuaurutan.ToString + urutan(ii).ToString
                End If
            Next ii

            If CheckBox1.Checked = True Then
                TextToPrint &= Format(i, "0#").ToString() + "  " + semuaurutan & Environment.NewLine
            Else
                TextToPrint &= semuaurutan & Environment.NewLine
            End If

            If i = tbaris_atas.Text Then
                For jd As Integer = 1 To tjeda_tengah.Text
                    TextToPrint &= "" & Environment.NewLine
                Next
            End If

            i += 1
        Loop
    End Sub
End Class