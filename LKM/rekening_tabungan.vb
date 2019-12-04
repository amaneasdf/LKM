Imports MySql.Data.MySqlClient
Imports System.IO

Public Class rekening_tabungan
    Dim data_ke(99), data_edit(99) As String

    Private Sub tkode_produk_LostFocus(sender As Object, e As EventArgs) Handles tkode_produk.LostFocus
        caritabungan()
    End Sub

    Private Sub cmbproduk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbproduk.SelectedIndexChanged
        tkode_produk.Text = cmbproduk.Text.ToString.Split(" :")(0)
        caritabungan()
    End Sub

    Private Sub tnasabah_id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tnasabah_id.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9,.]" _
            OrElse KeyAscii = Keys.Back _
             OrElse KeyAscii = Keys.Space _
            OrElse KeyAscii = Keys.Return _
            OrElse KeyAscii = Keys.Delete) Then
            KeyAscii = 0
        End If
        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub tnasabah_id_LostFocus(sender As Object, e As EventArgs) Handles tnasabah_id.LostFocus
        carinasabah()
    End Sub

    Private Sub tnama_nasabah_TextChanged(sender As Object, e As EventArgs) Handles tnama_nasabah.TextChanged
        If Len(tnama_nasabah.Text) = 0 Then
            btndata_nasabah.Enabled = False
            btnstatement.Enabled = False
            btnlogbuku.Enabled = False
        Else
            btndata_nasabah.Enabled = True
            btnstatement.Enabled = True
            btnlogbuku.Enabled = True
        End If
    End Sub

    Private Sub tpenghasilan_TextChanged(sender As Object, e As EventArgs) Handles tpenghasilan.TextChanged, tsaldo_minimal_dapat_bunga.TextChanged, tadm_bulanan.TextChanged, tsaldo_minimal.TextChanged, tsetoran_minimal.TextChanged, tsaldo_akhir.TextChanged
        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub

    Private Sub tkode_pemilik_LostFocus(sender As Object, e As EventArgs) Handles tkode_pemilik.LostFocus
        caripemilik()
    End Sub

    Private Sub cmbpemilik_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbpemilik.SelectedIndexChanged
        tkode_pemilik.Text = cmbpemilik.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_kolektor_LostFocus(sender As Object, e As EventArgs) Handles tkode_kolektor.LostFocus
        carikolektor()
    End Sub

    Private Sub cmbkolektor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbkolektor.SelectedIndexChanged
        tkode_kolektor.Text = cmbkolektor.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_marketing_LostFocus(sender As Object, e As EventArgs) Handles tkode_marketing.LostFocus
        carimarketing()
    End Sub

    Private Sub cmbmarketing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmarketing.SelectedIndexChanged
        tkode_marketing.Text = cmbmarketing.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_instansi_LostFocus(sender As Object, e As EventArgs) Handles tkode_instansi.LostFocus
        cariinstansi()
    End Sub

    Private Sub cmbinstansi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbinstansi.SelectedIndexChanged
        tkode_instansi.Text = cmbinstansi.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_wilayah_LostFocus(sender As Object, e As EventArgs) Handles tkode_wilayah.LostFocus
        cariwilayah()
    End Sub

    Private Sub cmbwilayah_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbwilayah.SelectedIndexChanged
        tkode_wilayah.Text = cmbwilayah.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tadm_bulanan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tadm_bulanan.KeyPress, tsaldo_minimal.KeyPress, tsetoran_minimal.KeyPress, tsaldo_minimal_dapat_bunga.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub cmbstatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbstatus.KeyPress, cmbmetode_hitung_bunga.KeyPress, cmbhubungan.KeyPress, cmbwilayah.KeyPress, cmbinstansi.KeyPress, cmbkolektor.KeyPress, cmbmarketing.KeyPress, cmbpemilik.KeyPress, cmbproduk.KeyPress, cmbmetode_hitung_bunga.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub rekening_tabungan_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tkode_produk.Focus()
    End Sub

    Private Sub rekening_tabungan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub rekening_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub rekening_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()

        'tno_rekening1.Text = "01.00001"
        ' cekdatarekening()
        combo()
        Me.ResizeRedraw = True
    End Sub

    Sub combo()
        cd = New MySqlCommand("SELECT tabungan_kode, concat_ws (' : ', tabungan_kode,upper(tabungan_nama_produk)) as produktabungan FROM data_tabungan_produk WHERE tabungan_status='1'", koneksi)
        rd = cd.ExecuteReader
        With cmbproduk.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("produktabungan"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('15')", koneksi)
        rd = cd.ExecuteReader
        With cmbpemilik.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', kolektor_kode,upper(kolektor_nama)) AS kolektor FROM data_kolektor", koneksi)
        rd = cd.ExecuteReader
        With cmbkolektor.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("kolektor"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', marketing_kode,upper(marketing_nama)) AS marketing FROM data_marketing", koneksi)
        rd = cd.ExecuteReader
        With cmbmarketing.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("marketing"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', instansi_kode,upper(instansi_nama)) AS instansi FROM data_instansi", koneksi)
        rd = cd.ExecuteReader
        With cmbinstansi.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("instansi"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT_WS (' , ',CONCAT_WS (' : ', wilayah_kode,upper(wilayah_nama_kecamatan)),upper(wilayah_nama_desa)) AS wilayah, wilayah_nama_kecamatan FROM data_wilayah", koneksi)
        rd = cd.ExecuteReader
        With cmbwilayah.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("wilayah"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('06')", koneksi)
        rd = cd.ExecuteReader
        With cmbhubungan.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('19')", koneksi)
        rd = cd.ExecuteReader
        With cmbmetode_hitung_bunga.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()
    End Sub

    Sub kosong()
        treg_alias.Text = MDIParent1.username.Text


        tkode_produk.Enabled = True
        cmbproduk.Enabled = True
        tkode_produk.Clear()
        cmbproduk.Text = ""
        tno_rekening1.Clear()
        tno_rekening2.Clear()
        tnasabah_id.Clear()
        tnama_nasabah.Clear()
        tjenis_kelamin.Clear()
        talamat.Clear()
        tnik.Clear()
        tttl.Clear()
        tpenghasilan.Clear()
        tqq.Clear()
        tno_buku.Clear()
        tkode_pemilik.Clear()
        cmbpemilik.Text = ""
        tkode_kolektor.Clear()
        cmbkolektor.Text = ""
        tkode_marketing.Clear()
        cmbmarketing.Text = ""
        tkode_wilayah.Clear()
        cmbwilayah.Text = ""
        tkode_instansi.Clear()
        cmbinstansi.Text = ""
        ttujuan_penggunaan.Clear()
        tahliwaris.Clear()
        cmbhubungan.Text = ""
        tsaldo_akhir.Clear()
        tsetoran_minimal.Clear()
        tsaldo_minimal.Clear()
        tadm_bulanan.Clear()
        cmbmetode_hitung_bunga.Text = ""
        tsaldo_minimal_dapat_bunga.Clear()
        tsuku_bunga.Text = "0,000"
        cmbstatus.Enabled = False
        cmbstatus.Text = "0 : NONE"
        tkode_pemilik.Enabled = True
        cmbpemilik.Enabled = True
        btndata_nasabah.Enabled = False
        btnstatement.Enabled = False
        btnlogbuku.Enabled = False
    End Sub

    Sub norekening()
        cd = New MySqlCommand("SELECT IFNULL(MAX(right(rek_tab_no_rekening,5)), '0') AS rek FROM data_tabungan_rekening WHERE rek_tab_kode_produk='" & tkode_produk.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()

        tno_rekening1.Text = tkode_produk.Text.ToString + "." + Microsoft.VisualBasic.Right("00000" & Microsoft.VisualBasic.Right(rd.Item("rek"), 5) + 1, 5)
        rd.Close()
    End Sub
    Sub caritabungan()
        rd.Close()
        Try
            If tkode_produk.Enabled = True Then
                cd = New MySqlCommand("SELECT tabungan_kode, CONCAT_WS (' : ', tabungan_kode,UPPER(tabungan_nama_produk)) AS produk FROM data_tabungan_produk WHERE tabungan_status='1' AND tabungan_kode='" & tkode_produk.Text & "'", koneksi)
            Else
                cd = New MySqlCommand("SELECT tabungan_kode, CONCAT_WS (' : ', tabungan_kode,UPPER(tabungan_nama_produk)) AS produk FROM data_tabungan_produk WHERE tabungan_kode='" & tkode_produk.Text & "'", koneksi)
            End If

            rd = cd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then
                cmbproduk.Text = rd.Item("produk")
            Else
                cmbproduk.Text = ""
            End If
        Catch ex As Exception

        End Try
        rd.Close()

        If tno_rekening1.Text = "" Then
            cd = New MySqlCommand("SELECT *,  cari_combo_komponen('19',tabungan_metode_hitung_bunga) AS metode_hitung_bunga FROM data_tabungan_produk WHERE tabungan_kode='" & tkode_produk.Text & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            Try
                tsetoran_minimal.Text = rd.Item("tabungan_setoran_minimal")
                tsaldo_minimal.Text = rd.Item("tabungan_saldo_mengendap")
                tadm_bulanan.Text = rd.Item("tabungan_adm_rekening")
                tsaldo_minimal_dapat_bunga.Text = rd.Item("tabungan_saldo_minimal_dapat_bunga")
                tsuku_bunga.Text = FormatNumber(rd.Item("tabungan_suku_bunga"), 3)
                cmbmetode_hitung_bunga.Text = rd.Item("metode_hitung_bunga")
            Catch ex As Exception
                tsetoran_minimal.Clear()
                tsaldo_minimal.Clear()
                tadm_bulanan.Clear()
                tsaldo_minimal_dapat_bunga.Clear()
                tsuku_bunga.Text = "0,000"
                cmbmetode_hitung_bunga.Text = ""
            End Try
            rd.Close()
        End If
    End Sub
    Sub carinasabah()
        Dim jk As String
        cd = New MySqlCommand("SELECT *, (SELECT combo_text FROM kode_komponen WHERE combo_komponen='02' AND combo_pakai='1' AND combo_kode=nasabah_jenis_kelamin) AS jk FROM data_nasabah WHERE nasabah_id='" & tnasabah_id.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_nasabah.Text = rd.Item("nasabah_nama1")
            jk = rd.Item("nasabah_jenis_kelamin")
            talamat.Text = rd.Item("nasabah_alamat") + ", " + rd.Item("nasabah_kelurahan") + ", " + rd.Item("nasabah_kecamatan")
            tnik.Text = rd.Item("nasabah_nik")
            tttl.Text = rd.Item("nasabah_kota") + ", " + rd.Item("nasabah_tanggal_lahir")
            tpenghasilan.Text = Val(rd.Item("nasabah_gaji")) + Val(rd.Item("nasabah_usaha")) + Val(rd.Item("nasabah_lain"))
            tjenis_kelamin.Text = Strings.Left(rd.Item("jk"), 1)
        Catch ex As Exception
            tnasabah_id.Clear()
            tnama_nasabah.Clear()
            tjenis_kelamin.Clear()
            talamat.Clear()
            tnik.Clear()
            tttl.Clear()
            tpenghasilan.Clear()
        End Try
        rd.Close()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If cmbproduk.Text = "" Then
            MessageBox.Show("Produk Tabungan harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbproduk.Focus()
            Exit Sub
        ElseIf tnama_nasabah.Text = "" Then
            MessageBox.Show("Nasabah ID harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnasabah_id.Focus()
            Exit Sub
        ElseIf cmbpemilik.Text = "" Then
            MessageBox.Show("Pemilik harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbpemilik.Focus()
            Exit Sub
        ElseIf ttujuan_penggunaan.Text = "" Then
            MessageBox.Show("Tujuan Penggunaa harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ttujuan_penggunaan.Focus()
            Exit Sub
        ElseIf tahliwaris.Text = "" Then
            MessageBox.Show("Ahli Waris harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tahliwaris.Focus()
            Exit Sub
        ElseIf cmbhubungan.Text = "" Then
            MessageBox.Show("Hubungan dengan Ahli Waris harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbhubungan.Focus()
            Exit Sub
        End If
        If tno_rekening1.Text = "" Then
            cd = New MySqlCommand("SELECT * FROM data_tabungan_rekening WHERE rek_tab_kode_produk='" & tkode_produk.Text & "' AND rek_tab_nasabah_id='" & tnasabah_id.Text & "'", koneksi)
            rd = cd.ExecuteReader
            If rd.HasRows = True Then
                rd.Close()
                If MessageBox.Show("Nasabah sudah memiliki rekening tabungan dengan produk yang sama. Anda yakin ingin membuat rekening baru?", "Pilihan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    simpan()
                End If
            Else
                rd.Close()
                simpan()
            End If
        Else
            edit()
        End If
        master_rekening_tabungan.btnfilter.PerformClick()
    End Sub
    Sub ar()
        Timer1.Enabled = False
        data_ke(0) = tno_rekening1.Text
        data_ke(1) = tno_rekening2.Text
        data_ke(2) = tkode_produk.Text
        data_ke(3) = tnasabah_id.Text
        data_ke(4) = tqq.Text
        data_ke(5) = tkode_pemilik.Text
        data_ke(6) = tkode_kolektor.Text
        data_ke(7) = tkode_marketing.Text
        data_ke(8) = tkode_instansi.Text
        data_ke(9) = tkode_wilayah.Text
        data_ke(10) = ttujuan_penggunaan.Text
        data_ke(11) = tahliwaris.Text
        data_ke(12) = cmbhubungan.Text.ToString.Split(" :")(0)
        data_ke(13) = Format(tsetoran_minimal.Text, "General Number")
        data_ke(14) = Format(tsaldo_minimal.Text, "General Number")
        data_ke(15) = Format(tadm_bulanan.Text, "General Number")
        data_ke(16) = cmbmetode_hitung_bunga.Text.ToString.Split(" :")(0)
        data_ke(17) = Format(tsaldo_minimal_dapat_bunga.Text, "General Number")
        data_ke(18) = tsuku_bunga.Text.Replace(",", ".")
        If CheckBox1.Checked = True Then
            data_ke(19) = "1"
        Else
            data_ke(19) = "0"
        End If
        data_ke(20) = cmbstatus.Text.ToString.Split(" :")(0)
        data_ke(21) = treg_alias.Text
        data_ke(22) = Format(DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        data_ke(23) = treg_alias.Text
        data_ke(24) = Format(DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")

        data_edit(0) = "rek_tab_no_rekening='" + data_ke(0) + "'"
        data_edit(1) = "rek_tab_no_alternatif='" + data_ke(1) + "'"
        data_edit(2) = "rek_tab_kode_produk='" + data_ke(2) + "'"
        data_edit(3) = "rek_tab_nasabah_id='" + data_ke(3) + "'"
        data_edit(4) = "rek_tab_qq='" + data_ke(4) + "'"
        data_edit(5) = "rek_tab_kode_pemilik='" + data_ke(5) + "'"
        data_edit(6) = "rek_tab_kode_kolektor='" + data_ke(6) + "'"
        data_edit(7) = "rek_tab_kode_marketing='" + data_ke(7) + "'"
        data_edit(8) = "rek_tab_kode_instansi='" + data_ke(8) + "'"
        data_edit(9) = "rek_tab_kode_wilayah='" + data_ke(9) + "'"
        data_edit(10) = "rek_tab_tujuan_penggunaan='" + data_ke(10) + "'"
        data_edit(11) = "rek_tab_ahli_waris='" + data_ke(11) + "'"
        data_edit(12) = "rek_tab_hubungan='" + data_ke(12) + "'"
        data_edit(13) = "rek_tab_setoran_minimal='" + data_ke(13) + "'"
        data_edit(14) = "rek_tab_saldo_minimal='" + data_ke(14) + "'"
        data_edit(15) = "rek_tab_adm_bulanan='" + data_ke(15) + "'"
        data_edit(16) = "rek_tab_metode_hitung_bunga='" + data_ke(16) + "'"
        data_edit(17) = "rek_tab_saldo_minimal_dapat_bunga='" + data_ke(17) + "'"
        data_edit(18) = "rek_tab_suku_bunga='" + data_ke(18) + "'"
        data_edit(19) = "rek_tab_special_rate='" + data_ke(19) + "'"
        data_edit(20) = "rek_tab_status='" + data_ke(20) + "'"
        data_edit(21) = "rek_tab_reg_username='" + data_ke(21) + "'"
        data_edit(22) = "rek_tab_reg_waktu='" + data_ke(22) + "'"
        data_edit(23) = "rek_tab_update_username='" + data_ke(23) + "'"
        data_edit(24) = "rek_tab_update_waktu='" + data_ke(24) + "'"
        Timer1.Enabled = True
    End Sub
    Sub simpan()
        norekening()
        ar()
        Dim gabung = ""
        For n = 0 To 24
            If n = 0 Then
                gabung += "'" + data_ke(n) + "'"
            Else
                gabung += ",'" + data_ke(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_tabungan_rekening VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Rekening Tabungan (rek_tab_no_rekening : " + data_ke(0) + ")"
        insert_log_user()

        MessageBox.Show("Rekening Tabungan berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        btndata_nasabah.Enabled = True
        btnstatement.Enabled = True
        btnlogbuku.Enabled = True
        'tsuku_bunga.Enabled = False
        'CheckBox1.Enabled = False
    End Sub

    Sub edit()
        ar()
        Dim gabung = ""
        For n = 1 To 24
            If n = 1 Then
                gabung += data_edit(n)
            ElseIf n = 21 Or n = 22 Then

            Else
                gabung += " ," + data_edit(n)
            End If
        Next
        cd = New MySqlCommand("UPDATE data_tabungan_rekening SET " & gabung & " WHERE " & data_edit(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Rekening Tabungan (rek_tab_no_rekening : " + data_ke(0) + ")"
        insert_log_user()

        With master_rekening_tabungan
            .btnfilter.PerformClick()
        End With
        MessageBox.Show("Rekening Tabungan berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btndata_nasabah_Click(sender As Object, e As EventArgs) Handles btndata_nasabah.Click
       
        With data_nasabah_perorangan
            .tnasabah_id.Text = tnasabah_id.Text
            .cekdatanasabah()
            .ShowDialog()
        End With
    End Sub

    Private Sub rekening_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub
    Sub caripemilik()
        cd = New MySqlCommand("SELECT text As pemilik FROM v_combo_komponen WHERE combo_komponen='15' AND combo_kode='" & tkode_pemilik.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbpemilik.Text = rd.Item("pemilik")
        Catch ex As Exception
            tkode_pemilik.Clear()
            cmbpemilik.Text = ""
        End Try
        rd.Close()
    End Sub
    Sub carikolektor()
        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', kolektor_kode,UPPER(kolektor_nama)) AS kolektor FROM data_kolektor WHERE kolektor_kode='" & tkode_kolektor.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbkolektor.Text = rd.Item("kolektor")
        Catch ex As Exception
            tkode_kolektor.Clear()
            cmbkolektor.Text = ""
        End Try
        rd.Close()
    End Sub
    Sub carimarketing()
        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', marketing_kode,UPPER(marketing_nama)) AS marketing FROM data_marketing WHERE marketing_kode='" & tkode_marketing.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbmarketing.Text = rd.Item("marketing")
        Catch ex As Exception
            tkode_marketing.Clear()
            cmbmarketing.Text = ""
        End Try
        rd.Close()
    End Sub
    Sub cariinstansi()
        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', instansi_kode,UPPER(instansi_nama)) AS instansi FROM data_instansi WHERE instansi_kode='" & tkode_instansi.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbinstansi.Text = rd.Item("instansi")
        Catch ex As Exception
            tkode_instansi.Clear()
            cmbinstansi.Text = ""
        End Try
        rd.Close()
    End Sub
    Sub cariwilayah()
        cd = New MySqlCommand("SELECT CONCAT_WS (' , ',CONCAT_WS (' : ', wilayah_kode,UPPER(wilayah_nama_kecamatan)),UPPER(wilayah_nama_desa)) AS wilayah FROM data_wilayah WHERE wilayah_kode='" & tkode_wilayah.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbwilayah.Text = rd.Item("wilayah")
        Catch ex As Exception
            tkode_wilayah.Clear()
            cmbwilayah.Text = ""
        End Try
        rd.Close()
    End Sub

    Private Sub btncarinasabah_Click(sender As Object, e As EventArgs) Handles btncarinasabah.Click
        With pencarian_master_nasabah
            .Label4.Text = "rekening tabungan"
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
        If tnama_nasabah.Text = "" Then
            btncarinasabah.Focus()
        Else
            tno_buku.Focus()
        End If
    End Sub

    Private Sub tno_buku_GotFocus(sender As Object, e As EventArgs) Handles tno_buku.GotFocus, tsuku_bunga.GotFocus, tsaldo_minimal_dapat_bunga.GotFocus, cmbmetode_hitung_bunga.GotFocus, tadm_bulanan.GotFocus, tsaldo_minimal.GotFocus, tsetoran_minimal.GotFocus, tsaldo_akhir.GotFocus, cmbhubungan.GotFocus, tahliwaris.GotFocus, ttujuan_penggunaan.GotFocus, cmbwilayah.GotFocus, tkode_wilayah.GotFocus, cmbinstansi.GotFocus, tkode_instansi.GotFocus, cmbkolektor.GotFocus, tkode_kolektor.GotFocus, cmbmarketing.GotFocus, tkode_marketing.GotFocus, cmbpemilik.GotFocus, tkode_pemilik.GotFocus, tqq.GotFocus, tpenghasilan.GotFocus, tttl.GotFocus, tnik.GotFocus, talamat.GotFocus, tjenis_kelamin.GotFocus, tnama_nasabah.GotFocus, treg_alias.GotFocus, tnasabah_id.GotFocus, tno_rekening2.GotFocus, tno_rekening1.GotFocus, cmbproduk.GotFocus, tkode_produk.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tno_buku_LostFocus(sender As Object, e As EventArgs) Handles tno_buku.LostFocus, tsuku_bunga.LostFocus, tsaldo_minimal_dapat_bunga.LostFocus, cmbmetode_hitung_bunga.LostFocus, tadm_bulanan.LostFocus, tsaldo_minimal.LostFocus, tsetoran_minimal.LostFocus, tsaldo_akhir.LostFocus, cmbhubungan.LostFocus, tahliwaris.LostFocus, ttujuan_penggunaan.LostFocus, cmbwilayah.LostFocus, tkode_wilayah.LostFocus, cmbinstansi.LostFocus, tkode_instansi.LostFocus, cmbmarketing.LostFocus, tkode_marketing.LostFocus, cmbkolektor.LostFocus, tkode_kolektor.LostFocus, cmbpemilik.LostFocus, tkode_pemilik.LostFocus, tqq.LostFocus, tpenghasilan.LostFocus, tttl.LostFocus, tnik.LostFocus, talamat.LostFocus, tjenis_kelamin.LostFocus, tnama_nasabah.LostFocus, tnasabah_id.LostFocus, tno_rekening2.LostFocus, tno_rekening1.LostFocus, cmbproduk.LostFocus, tkode_produk.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub
    Private Sub tno_suku_bunga_LostFocus(sender As Object, e As EventArgs) Handles tsuku_bunga.LostFocus
        tsuku_bunga.Text = FormatNumber(tsuku_bunga.Text, 3)
    End Sub


    Private Sub btnstatement_Click(sender As Object, e As EventArgs) Handles btnstatement.Click
        With statement_tabungan
            .tno_rekening.Text = tno_rekening1.Text
            .caristatement()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnlogbuku_Click(sender As Object, e As EventArgs) Handles btnlogbuku.Click
        With registrasi_buku_tabungan
            .tno_rekening.Text = tno_rekening1.Text
            .tnama_nasabah.Text = tnama_nasabah.Text
            .data()
            .ShowDialog()
        End With
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateTimePicker1.Text = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Sub cekdatarekening()
        Try
            rd.Close()
        Catch ex As Exception

        End Try
        cd = New MySqlCommand("SELECT *,  cari_combo_komponen('06',rek_tab_hubungan) AS hubungan,  hitung_saldo_akhir_tabungan(rek_tab_no_rekening, '" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "') AS saldo, cari_combo_komponen('19',rek_tab_metode_hitung_bunga) AS metode_hitung_bunga FROM data_tabungan_rekening WHERE rek_tab_no_rekening='" & tno_rekening1.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tkode_produk.Enabled = False
        cmbproduk.Enabled = False
        tno_rekening1.Text = rd.Item("rek_tab_no_rekening")
        tno_rekening2.Text = rd.Item("rek_tab_no_alternatif")
        tkode_produk.Text = rd.Item("rek_tab_kode_produk")
        tnasabah_id.Text = rd.Item("rek_tab_nasabah_id")
        tqq.Text = rd.Item("rek_tab_qq")
        tkode_pemilik.Text = rd.Item("rek_tab_kode_pemilik")
        tkode_kolektor.Text = rd.Item("rek_tab_kode_kolektor")
        tkode_marketing.Text = rd.Item("rek_tab_kode_marketing")
        tkode_instansi.Text = rd.Item("rek_tab_kode_instansi")
        tkode_wilayah.Text = rd.Item("rek_tab_kode_wilayah")
        ttujuan_penggunaan.Text = rd.Item("rek_tab_tujuan_penggunaan")
        tahliwaris.Text = rd.Item("rek_tab_ahli_waris")
        tsaldo_akhir.Text = rd.Item("saldo")
        tsetoran_minimal.Text = rd.Item("rek_tab_setoran_minimal")
        tsaldo_minimal.Text = rd.Item("rek_tab_saldo_minimal")
        tadm_bulanan.Text = rd.Item("rek_tab_adm_bulanan")
        cmbstatus.Items.Clear()
        cmbstatus.Enabled = True
        If rd.Item("rek_tab_status") = "0" Then
            cmbstatus.Items.Add("0 : NONE")
            cmbstatus.Text = "0 : NONE"
        End If

        If rd.Item("rek_tab_status") = "1" Or rd.Item("rek_tab_status") = "2" Then
            cmbstatus.Items.Add("1 : AKTIF")
            cmbstatus.Items.Add("2 : BLOKIR")
            If rd.Item("rek_tab_status") = "1" Then
                cmbstatus.Text = "1 : AKTIF"
            Else
                cmbstatus.Text = "2 : BLOKIR"
            End If
        End If

        If rd.Item("rek_tab_status") = "4" Then
            cmbstatus.Items.Add("1 : AKTIF")
            cmbstatus.Items.Add("4 : TUTUP")
            If rd.Item("rek_tab_status") = "1" Then
                cmbstatus.Text = "1 : AKTIF"
            Else
                cmbstatus.Text = "4 : TUTUP"
            End If
        End If

        Try
            cmbhubungan.Text = rd.Item("hubungan")
        Catch ex As Exception
            cmbhubungan.Text = ""
        End Try
        tsaldo_akhir.Text = rd.Item("saldo")

        cmbmetode_hitung_bunga.Text = rd.Item("metode_hitung_bunga")
        tsaldo_minimal_dapat_bunga.Text = rd.Item("rek_tab_saldo_minimal_dapat_bunga")
        tsuku_bunga.Text = FormatNumber(rd.Item("rek_tab_suku_bunga"), 3)
        If rd.Item("rek_tab_special_rate") = "1" Then
            CheckBox1.Checked = True
            tsuku_bunga.Enabled = True
        Else
            CheckBox1.Checked = False
            tsuku_bunga.Enabled = False
        End If
        'CheckBox1.Enabled = False
        'tsuku_bunga.Enabled = False
        rd.Close()

        cd = New MySqlCommand("SELECT cari_buku_tabungan('" & tno_rekening1.Text & "') AS buku_no", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tno_buku.Text = rd.Item("buku_no")
        rd.Close()

        caritabungan()
        carinasabah()
        caripemilik()
        carikolektor()
        carimarketing()
        cariinstansi()
        cariwilayah()
        tkode_pemilik.Enabled = False
        cmbpemilik.Enabled = False
        btndata_nasabah.Enabled = True
        btnstatement.Enabled = True
        btnlogbuku.Enabled = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            tsuku_bunga.Enabled = True
        Else
            tsuku_bunga.Enabled = False
        End If
    End Sub

    Private Sub tsuku_bunga_TextChanged(sender As Object, e As EventArgs) Handles tsuku_bunga.TextChanged

    End Sub
End Class