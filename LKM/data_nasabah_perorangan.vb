Imports MySql.Data.MySqlClient
Imports System.IO
Public Class data_nasabah_perorangan
    Private PathFile As String
    Dim gambar As Byte
    Dim array(99), arr(99) As String
    Dim y, m, d As Integer
    Dim tanggal As Date

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub data_nasabah_perorangan_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tnama.Focus()
    End Sub

    Private Sub data_nasabah_perorangan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnkeluar.PerformClick()
    End Sub

    Private Sub data_nasabah_perorangan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub data_nasabah_perorangan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo()
        Me.ResizeRedraw = True
        DateTimePicker1.MaxDate = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy")
        DateTimePicker2.MaxDate = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy")
        DateTimePicker3.MaxDate = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy")
        DateTimePicker3.MinDate = Format(DateTimePicker1.Value, "dd MMMM yyyy")
    End Sub
    Sub combo()
        With cmbpph.Items
            .Clear()
            .Add("T")
            .Add("Y")
        End With
       
        rd.Close()
        cd = New MySqlCommand("CALL isi_combo('02')", koneksi)
        rd = cd.ExecuteReader
        With cmbsex.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('14')", koneksi)
        rd = cd.ExecuteReader
        With cmbketerkaitan.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('05')", koneksi)
        rd = cd.ExecuteReader
        With cmbstatus.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('07')", koneksi)
        rd = cd.ExecuteReader
        With cmbpendidikan.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('04')", koneksi)
        rd = cd.ExecuteReader
        With cmbagama.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('09')", koneksi)
        rd = cd.ExecuteReader
        With cmbdaerah.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('08')", koneksi)
        rd = cd.ExecuteReader
        With cmbpekerjaan.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
            rd.Close()
        End With

        cd = New MySqlCommand("CALL isi_combo('29')", koneksi)
        rd = cd.ExecuteReader
        With cmbhubungan.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
            rd.Close()
        End With

        cd = New MySqlCommand("CALL isi_combo('30')", koneksi)
        rd = cd.ExecuteReader
        With cmbmelanggar.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('31')", koneksi)
        rd = cd.ExecuteReader
        With cmbmelampaui.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

    End Sub

    Sub def()
        rd.Close()
        cd = New MySqlCommand("SELECT cari_combo_komponen('05',(SELECT komp_default FROM sys_komponen WHERE komp_tag='StatusMarital')) AS status", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbstatus.Text = rd.Item("status")
        rd.Close()
        tnama_pasangan.Enabled = False
        tnik_pasangan.Enabled = False
        DateTimePicker2.Enabled = False
        cmbpph.Enabled = False

        cd = New MySqlCommand("SELECT combo_kode, text AS hubungandebitur FROM v_combo_komponen WHERE combo_komponen='29' AND combo_kode=(SELECT komp_default FROM sys_komponen WHERE komp_tag='SIDHubunganDebitur')", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tkode_hubungan.Text = rd.Item("combo_kode")
            cmbhubungan.Text = rd.Item("hubungandebitur")
        Catch ex As Exception
            tkode_hubungan.Text = ""
            cmbhubungan.Text = ""
        End Try
        rd.Close()

        cd = New MySqlCommand("SELECT cari_combo_komponen('30',(SELECT komp_default FROM sys_komponen WHERE komp_tag='SIDMelanggarBMPK')) AS melanggar", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbmelanggar.Text = rd.Item("melanggar")
        Catch ex As Exception
            cmbmelanggar.Text = ""
        End Try
        rd.Close()

        cd = New MySqlCommand("SELECT cari_combo_komponen('31',(SELECT komp_default FROM sys_komponen WHERE komp_tag='SIDMelampauiBMPK')) AS melampaui", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbmelampaui.Text = rd.Item("melampaui")
        Catch ex As Exception
            cmbmelampaui.Text = ""
        End Try
        rd.Close()

        cd = New MySqlCommand("SELECT cari_combo_komponen('14',(SELECT komp_default FROM sys_komponen WHERE komp_tag='Keterkaitan')) AS keterkaitan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbketerkaitan.Text = rd.Item("keterkaitan")
        Catch ex As Exception
            cmbketerkaitan.Text = ""
        End Try
        rd.Close()
    End Sub

    Private Sub cmbstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstatus.SelectedIndexChanged
        pilihan_status()
    End Sub
    Sub pilihan_status()
        If cmbstatus.Text.ToString.Split(" :")(0) = "2" Then
            tnama_pasangan.Enabled = True
            tnik_pasangan.Enabled = True
            DateTimePicker2.Enabled = True
            cmbpph.Enabled = True
        Else
            tnama_pasangan.Enabled = False
            tnik_pasangan.Enabled = False
            DateTimePicker2.Enabled = False
            cmbpph.Enabled = False
            tnama_pasangan.Clear()
            tnik_pasangan.Clear()
        End If
    End Sub

    Private Sub cmbpendidikan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbpendidikan.SelectedIndexChanged
        If cmbpendidikan.Text.ToString.Split(" :")(0) = "0100" Then
            tket_pendidikan.Enabled = False
            tket_pendidikan.Clear()
        Else
            tket_pendidikan.Enabled = True
        End If
    End Sub

    Private Sub cmbdaerah_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbdaerah.SelectedIndexChanged
        tkode_daerah.Text = cmbdaerah.Text.ToString.Split(" :")(0)
    End Sub
    Private Sub tpekerjaan_LostFocus(sender As Object, e As EventArgs) Handles tpekerjaan.LostFocus
        caripekerjaan()
    End Sub

    Private Sub cmbpekerjaan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbpekerjaan.SelectedIndexChanged
        tpekerjaan.Text = cmbpekerjaan.Text.ToString.Split(" :")(0)
        pilih_pekerjaan()
    End Sub
    Sub pilih_pekerjaan()
        If cmbpekerjaan.Text.ToString.Split(" :")(0) = "27" Then
            tket_pekerjaan.Enabled = False
            talamat_bekerja.Enabled = False
            tgaji.Enabled = False
            tusaha.Enabled = False
            tket_pekerjaan.Clear()
            talamat_bekerja.Clear()
            tgaji.Clear()
            tusaha.Clear()
        Else
            tket_pekerjaan.Enabled = True
            talamat_bekerja.Enabled = True
            tgaji.Enabled = True
            tusaha.Enabled = True
        End If
    End Sub

    Private Sub tket_pekerjaan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tket_pekerjaan.KeyPress, tkecamatan.KeyPress, tkelurahan.KeyPress, tnama_ibu.KeyPress, tnama_pasangan.KeyPress, tkota.KeyPress, tnama.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z,a-z]" _
            OrElse KeyAscii = Keys.Back _
             OrElse KeyAscii = Keys.Space _
            OrElse KeyAscii = Keys.Return _
            OrElse KeyAscii = Keys.Delete) Then
            KeyAscii = 0
        End If
        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub talamat_bekerja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles talamat_bekerja.KeyPress, talamat.KeyPress, tket_pendidikan.KeyPress, tnama2.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z,a-z,0-9]" _
            OrElse KeyAscii = Keys.Back _
             OrElse KeyAscii = Keys.Space _
            OrElse KeyAscii = Keys.Return _
            OrElse KeyAscii = Keys.Delete) Then
            KeyAscii = 0
        End If
        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub tlain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tlain.KeyPress, tusaha.KeyPress, tgaji.KeyPress, tjml_tanggungan.KeyPress, tpekerjaan.KeyPress, tmobile.KeyPress, ttelepon.KeyPress, tkode_area.KeyPress, tkode_pos.KeyPress, tnik_pasangan.KeyPress, tnpwp.KeyPress, tnik.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tlain_TextChanged(sender As Object, e As EventArgs) Handles tlain.TextChanged, tusaha.TextChanged, tgaji.TextChanged, tjml_tanggungan.TextChanged

        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub

    Private Sub tcari_nik_LostFocus(sender As Object, e As EventArgs) Handles tcari_nik.LostFocus
        If Len(tcari_nik.Text) > 0 Then
            cd = New MySqlCommand("SELECT * FROM data_nasabah WHERE nasabah_nik='" & tcari_nik.Text & "'", koneksi) 'mengecek nik
            rd = cd.ExecuteReader
            rd.Read()
            Try
                tnasabah_id.Text = rd.Item("nasabah_id")
                rd.Close()
                cekdatanasabah()
            Catch ex As Exception
                MessageBox.Show("Data tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                tcari_nik.Focus()
            End Try
            rd.Close()
        End If
    End Sub

    Sub caridaerah()
        cd = New MySqlCommand("SELECT cari_combo_komponen('09','" & tkode_daerah.Text & "') AS kabkot", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbdaerah.Text = rd.Item("kabkot")
        Catch ex As Exception
            cmbdaerah.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub caripekerjaan()
        cd = New MySqlCommand("SELECT cari_combo_komponen('08','" & tpekerjaan.Text & "') AS pekerjaan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbpekerjaan.Text = rd.Item("pekerjaan")
        Catch ex As Exception
            cmbpekerjaan.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carihubungandebitur()
        cd = New MySqlCommand("SELECT cari_combo_komponen('29','" & tkode_hubungan.Text & "') AS hubungan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbhubungan.Text = rd.Item("hubungan")
        Catch ex As Exception
            cmbhubungan.Text = ""
        End Try
        rd.Close()
    End Sub
    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tnama.Text = "" Then
            MessageBox.Show("Nama Nasabah harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama.Focus()
            Exit Sub
        ElseIf tnama2.Text = "" Then
            MessageBox.Show("Nama Alias (1) harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama2.Focus()
            Exit Sub
        ElseIf tnik.Text = "" Then
            MessageBox.Show("Nomor NIK harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnik.Focus()
            Exit Sub
        ElseIf tkota.Text = "" Then
            MessageBox.Show("Tempat Lahir harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkota.Focus()
            Exit Sub
        ElseIf DateTimePicker1.Checked = False Then
            MessageBox.Show("Tanggal Lahir harus dikonfirmasi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
            Exit Sub
        ElseIf cmbstatus.Text = "" Then
            MessageBox.Show("Status Marital harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbstatus.Focus()
            Exit Sub
        ElseIf cmbstatus.Text.ToString.Split(" :")(0) = "2" And tnama_pasangan.Text = "" Then
            MessageBox.Show("Nama Pasangan harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_pasangan.Focus()
            Exit Sub
        ElseIf cmbpendidikan.Text = "" Then
            MessageBox.Show("Status Pendidikan harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbpendidikan.Focus()
            Exit Sub
        ElseIf cmbpendidikan.Text.ToString.Split(" :")(0) <> "0100" And tket_pendidikan.Text = "" Then
            MessageBox.Show("Keterangan Pendidikan harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tket_pendidikan.Focus()
            Exit Sub
        ElseIf tnama_ibu.Text = "" Then
            MessageBox.Show("Nama Ibu Kandung harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_ibu.Focus()
            Exit Sub
        ElseIf talamat.Text = "" Then
            MessageBox.Show("Alamat harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            talamat.Focus()
            Exit Sub
        ElseIf tkelurahan.Text = "" Then
            MessageBox.Show("Kelurahan / Desa harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkelurahan.Focus()
            Exit Sub
        ElseIf tkecamatan.Text = "" Then
            MessageBox.Show("Kecamatan harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkecamatan.Focus()
            Exit Sub
        ElseIf cmbdaerah.Text = "" Then
            MessageBox.Show("Daerah Tingkat II harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbdaerah.Focus()
            Exit Sub
        ElseIf tkode_pos.Text = "" Then
            MessageBox.Show("Kode Pos harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_pos.Focus()
            Exit Sub
        ElseIf talamat_domisili.Text = "" Then
            MessageBox.Show("Alamat Domisili harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            talamat_domisili.Focus()
            Exit Sub
        ElseIf DateTimePicker3.Checked = False Then
            MessageBox.Show("Tanggal Sejak Domisili harus dikonfirmasi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker3.Focus()
            Exit Sub
        ElseIf cmbpekerjaan.Text = "" Then
            MessageBox.Show("Jenis Pekerjaan harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbpekerjaan.Focus()
            Exit Sub
        ElseIf tket_pekerjaan.Text = "" And tket_pekerjaan.Enabled = True Then
            MessageBox.Show("Keterangan Pekerjaan harus diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tket_pekerjaan.Focus()
            Exit Sub
        ElseIf tgaji.Text = 0 And tusaha.Text = 0 And tlain.Text = 0 Then
            MessageBox.Show("Penghasilan belum diisi", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tgaji.Focus()
            Exit Sub
        End If
        rd.Close()
        cd = New MySqlCommand("SELECT * FROM data_nasabah WHERE nasabah_nik='" & tnik.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True And tnik.Enabled = True Then
            rd.Close()
            MessageBox.Show("NIK sudah digunakan", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnik.Focus()
        Else
            rd.Close()
            hitungumur()
            If y < 17 Then
                MessageBox.Show("Umur nasabah kurang dari 17 tahun.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If tnik.Enabled = True Then
                simpan()
                tnik.Enabled = False
                btncetak_form.Enabled = True
                btnprofile.Enabled = True
            Else
                perbaharuidata()
            End If
        End If

        If Len(master_nasabah_perorangan.tfilter.Text) > 0 Then
            master_nasabah_perorangan.btnfilter.PerformClick()
        End If
        Try
            cd = New MySqlCommand("SELECT * FROM data_nasabah WHERE nasabah_nik='" & tnik.Text & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            Label42.Text = rd.Item("nasabah_reg_date")
            Label43.Text = rd.Item("nasabah_reg_alias")
            Label44.Text = rd.Item("nasabah_upd_date")
            Label45.Text = rd.Item("nasabah_upd_alias")
            rd.Close()
        Catch ex As Exception

        End Try
    End Sub
    Sub ar()
        array(0) = tnasabah_id.Text
        array(1) = talternatif.Text
        array(2) = tnama.Text
        array(3) = cmbsex.Text.ToString.Split(" :")(0)
        array(4) = tnama2.Text
        array(5) = cmbketerkaitan.Text.ToString.Split(" :")(0)
        array(6) = tnik.Text
        array(7) = tnpwp.Text
        array(8) = tkota.Text
        array(9) = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        array(10) = cmbstatus.Text.ToString.Split(" :")(0)
        array(11) = tnama_pasangan.Text
        array(12) = tnik_pasangan.Text
        array(13) = Format(DateTimePicker2.Value, "yyyy-MM-dd")
        array(14) = cmbpph.Text.ToString.Split(" :")(0)
        array(15) = cmbpendidikan.Text.ToString.Split(" :")(0)
        array(16) = tket_pendidikan.Text
        array(17) = tnama_ibu.Text
        array(18) = cmbagama.Text.ToString.Split(" :")(0)
        array(19) = talamat.Text
        array(20) = tkelurahan.Text
        array(21) = tkecamatan.Text
        array(22) = cmbdaerah.Text.ToString.Split(" :")(0)
        array(23) = tkode_pos.Text
        array(24) = talamat_domisili.Text
        array(25) = Format(DateTimePicker3.Value, "yyyy-MM-dd")
        array(26) = tkode_area.Text
        array(27) = ttelepon.Text
        array(28) = tmobile.Text
        array(29) = cmbpekerjaan.Text.ToString.Split(" :")(0)
        array(30) = tket_pekerjaan.Text
        array(31) = talamat_bekerja.Text
        array(32) = Format(tjml_tanggungan.Text, "General Number")
        array(33) = Format(tgaji.Text, "General Number")
        array(34) = Format(tusaha.Text, "General Number")
        array(35) = Format(tlain.Text, "General Number")
        array(36) = tkode_hubungan.Text
        array(37) = cmbmelanggar.Text.ToString.Split(" :")(0)
        array(38) = cmbmelampaui.Text.ToString.Split(" :")(0)
        array(39) = 0
        array(40) = MDIParent1.username.Text
        array(41) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        array(42) = MDIParent1.username.Text
        array(43) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")

        arr(0) = "nasabah_id='" + array(0) + "'"
        arr(1) = "nasabah_alternatif='" + array(1) + "'"
        arr(2) = "nasabah_nama1='" + array(2) + "'"
        arr(3) = "nasabah_jenis_kelamin='" + array(3) + "'"
        arr(4) = "nasabah_nama2='" + array(4) + "'"
        arr(5) = "nasabah_keterkaitan='" + array(5) + "'"
        arr(6) = "nasabah_nik='" + array(6) + "'"
        arr(7) = "nasabah_npwp='" + array(7) + "'"
        arr(8) = "nasabah_kota='" + array(8) + "'"
        arr(9) = "nasabah_tanggal_lahir='" + array(9) + "'"
        arr(10) = "nasabah_status_marital='" + array(10) + "'"
        arr(11) = "nasabah_nama_pasangan='" + array(11) + "'"
        arr(12) = "nasabah_nik_pasangan='" + array(12) + "'"
        arr(13) = "nasabah_tanggal_lahir_pasangan='" + array(13) + "'"
        arr(14) = "nasabah_pph_pasangan='" + array(14) + "'"
        arr(15) = "nasabah_pendidikan='" + array(15) + "'"
        arr(16) = "nasabah_keterangan_pendidikan='" + array(16) + "'"
        arr(17) = "nasabah_nama_ibu='" + array(17) + "'"
        arr(18) = "nasabah_agama='" + array(18) + "'"
        arr(19) = "nasabah_alamat='" + array(19) + "'"
        arr(20) = "nasabah_kelurahan='" + array(20) + "'"
        arr(21) = "nasabah_kecamatan='" + array(21) + "'"
        arr(22) = "nasabah_dati2='" + array(22) + "'"
        arr(23) = "nasabah_kode_pos='" + array(23) + "'"
        arr(24) = "nasabah_alamat_domisili='" + array(24) + "'"
        arr(25) = "nasabah_tanggal_domisili='" + array(25) + "'"
        arr(26) = "nasabah_kode_area='" + array(26) + "'"
        arr(27) = "nasabah_telepon='" + array(27) + "'"
        arr(28) = "nasabah_mobile='" + array(28) + "'"
        arr(29) = "nasabah_pekerjaan='" + array(29) + "'"
        arr(30) = "nasabah_keterangan_pekerjaan='" + array(30) + "'"
        arr(31) = "nasabah_alamat_bekerja='" + array(31) + "'"
        arr(32) = "nasabah_jumlah_tanggungan='" + array(32) + "'"
        arr(33) = "nasabah_gaji='" + array(33) + "'"
        arr(34) = "nasabah_usaha='" + array(34) + "'"
        arr(35) = "nasabah_lain='" + array(35) + "'"
        arr(36) = "nasabah_hubungan_debitur='" + array(36) + "'"
        arr(37) = "nasabah_melanggar_bmpk='" + array(37) + "'"
        arr(38) = "nasabah_melampaui_bmpk='" + array(38) + "'"
        arr(39) = "nasabah_status='" + array(39) + "'"
        arr(40) = "nasabah_reg_username='" + array(40) + "'"
        arr(41) = "nasabah_reg_waktu='" + array(41) + "'"
        arr(42) = "nasabah_update_username='" + array(42) + "'"
        arr(43) = "nasabah_update_waktu='" + array(43) + "'"
    End Sub
    Sub simpan()
        nonasabahid()
        ar()
        Dim gabung = ""
        For n = 0 To 43
            If n = 0 Then
                gabung += "'" + array(n) + "'"
            Else
                gabung += ",'" + array(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_nasabah VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()
        simpan_gambar()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Data Nasabah (nasabah_id : " + array(0) + ")"
        insert_log_user()
        rd.Close()
        MessageBox.Show("Master Data Nasabah berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        rd.Close()
    End Sub
    Sub perbaharuidata()
        ar()
        Dim gabung = ""
        For n = 1 To 43
            If n = 1 Then
                gabung += arr(n)
            ElseIf n = 40 Or n = 41 Or n = 39 Then

            Else
                gabung += " ," + arr(n)
            End If
        Next

        cd = New MySqlCommand("UPDATE data_nasabah SET " & gabung & " WHERE " & arr(0) & "", koneksi)
        cd.ExecuteNonQuery()
        simpan_gambar()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Data Nasabah (nasabah_id : " + array(0) + ")"
        insert_log_user()
        rd.Close()
        MessageBox.Show("Master Data Nasabah berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        rd.Close()
    End Sub
    Sub simpan_gambar()
        Dim fileName As String = OpenFileDialog1.FileName
        If Label47.Text = "1" Then
            If Label46.Text = "0" Then
                cd = New MySqlCommand("INSERT INTO data_nasabah_gambar VALUES ('" & tnasabah_id.Text & "', @gambar)", koneksi)
            End If
            If Label46.Text = "1" Then
                cd = New MySqlCommand("UPDATE data_nasabah_gambar SET gambar_file=@gambar WHERE gambar_nasabah_id='" & tnasabah_id.Text & "'", koneksi)
            End If
            With cd
                .Parameters.Clear()
                .Parameters.AddWithValue("@gambar", IO.File.ReadAllBytes(fileName)) ' foto
                .ExecuteNonQuery()
            End With
        End If

        If Label46.Text = "1" And Label47.Text = "0" Then
            'hapus
            cd = New MySqlCommand("DELETE FROM data_nasabah_gambar WHERE gambar_nasabah_id='" & tnasabah_id.Text & "'", koneksi)
            cd.ExecuteNonQuery()
        End If
    End Sub
    Sub kosong()
        talternatif.Clear()
        tnama.Clear()
        tnama2.Clear()
        tnik.Clear()
        tnik.Enabled = True
        tnpwp.Clear()
        tkota.Clear()
        DateTimePicker1.Value = Format(MDIParent1.DateTimePicker1.Value, "dd MM yyyy")
        DateTimePicker1.Checked = False
        tnama_pasangan.Clear()
        tnik_pasangan.Clear()
        DateTimePicker2.Value = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy")
        DateTimePicker2.Checked = False
        cmbpph.Text = ""
        cmbstatus.Text = ""
        cmbpendidikan.Text = ""
        tket_pendidikan.Clear()
        tnama_ibu.Clear()
        cmbagama.Text = ""
        talamat.Clear()
        tkelurahan.Clear()
        tkecamatan.Clear()
        tkode_daerah.Clear()
        cmbdaerah.Text = ""
        tkode_pos.Clear()
        talamat_domisili.Clear()
        DateTimePicker3.Value = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy")
        DateTimePicker3.Checked = False
        tkode_area.Clear()
        ttelepon.Clear()
        tmobile.Clear()
        tpekerjaan.Clear()
        cmbpekerjaan.Text = ""
        tket_pekerjaan.Clear()
        talamat_bekerja.Clear()
        tjml_tanggungan.Clear()
        tgaji.Clear()
        tusaha.Clear()
        tlain.Clear()
        tkode_hubungan.Clear()
        cmbhubungan.Text = ""
        cmbmelanggar.Text = ""
        cmbmelampaui.Text = ""
        tcari_nik.Clear()
        PictureBox1.Image = Nothing
        btnprofile.Enabled = False
        btncetak_form.Enabled = False
        Label42.Text = ""
        Label43.Text = ""
        Label44.Text = ""
        Label45.Text = ""

        Label46.Text = "0"
        Label47.Text = "0"
        def()
    End Sub

    Sub nonasabahid()
        cd = New MySqlCommand("SELECT IFNULL(MAX(nasabah_id),0) AS nas FROM data_nasabah", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tnasabah_id.Text = Microsoft.VisualBasic.Right("00000" & Microsoft.VisualBasic.Right(Val(rd.Item("nas")), 6) + 1, 6)
        rd.Close()
    End Sub

    Private Sub tkode_hubungan_LostFocus(sender As Object, e As EventArgs) Handles tkode_hubungan.LostFocus
        carihubungandebitur()
    End Sub

    Private Sub cmbhubungan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbhubungan.SelectedIndexChanged
        tkode_hubungan.Text = cmbhubungan.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub cmbmelanggar_LostFocus(sender As Object, e As EventArgs) Handles cmbmelanggar.LostFocus, cmbhubungan.LostFocus, tkode_hubungan.LostFocus, tcari_nik.LostFocus, tlain.LostFocus, tusaha.LostFocus, tgaji.LostFocus, tjml_tanggungan.LostFocus, talamat_bekerja.LostFocus, tket_pekerjaan.LostFocus, cmbpekerjaan.LostFocus, tpekerjaan.LostFocus, tmobile.LostFocus, ttelepon.LostFocus, tkode_area.LostFocus, talamat_domisili.LostFocus, tkode_pos.LostFocus, cmbdaerah.LostFocus, tkode_daerah.LostFocus, tkecamatan.LostFocus, tkelurahan.LostFocus, talamat.LostFocus, cmbagama.LostFocus, tnama_ibu.LostFocus, tket_pendidikan.LostFocus, cmbpendidikan.LostFocus, cmbpph.LostFocus, tnik_pasangan.LostFocus, tnama_pasangan.LostFocus, cmbstatus.LostFocus, tkota.LostFocus, tnpwp.LostFocus, tnik.LostFocus, cmbketerkaitan.LostFocus, cmbsex.LostFocus, tnama2.LostFocus, tnama.LostFocus, cmbmelampaui.LostFocus

        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub cmbmelampaui_GotFocus(sender As Object, e As EventArgs) Handles cmbmelampaui.GotFocus, cmbmelanggar.GotFocus, cmbhubungan.GotFocus, tkode_hubungan.GotFocus, tcari_nik.GotFocus, tlain.GotFocus, tusaha.GotFocus, tgaji.GotFocus, tjml_tanggungan.GotFocus, talamat_bekerja.GotFocus, tket_pekerjaan.GotFocus, cmbpekerjaan.GotFocus, tpekerjaan.GotFocus, tmobile.GotFocus, ttelepon.GotFocus, tkode_area.GotFocus, talamat_domisili.GotFocus, tkode_pos.GotFocus, cmbdaerah.GotFocus, tkode_daerah.GotFocus, tkecamatan.GotFocus, tkelurahan.GotFocus, talamat.GotFocus, cmbagama.GotFocus, tnama_ibu.GotFocus, tket_pendidikan.GotFocus, cmbpendidikan.GotFocus, cmbpph.GotFocus, tnik_pasangan.GotFocus, tnama_pasangan.GotFocus, cmbstatus.GotFocus, tkota.GotFocus, tnpwp.GotFocus, tnik.GotFocus, cmbketerkaitan.GotFocus, cmbsex.GotFocus, tnama2.GotFocus, tnama.GotFocus

        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbmelampaui_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbmelampaui.KeyPress, cmbmelanggar.KeyPress, cmbhubungan.KeyPress, cmbpekerjaan.KeyPress, cmbdaerah.KeyPress, cmbagama.KeyPress, cmbpendidikan.KeyPress, cmbpph.KeyPress, cmbstatus.KeyPress, cmbketerkaitan.KeyPress, cmbsex.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub btncarifoto_Click(sender As Object, e As EventArgs) Handles btncarifoto.Click
        ambil_foto.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.PictureBox1.Image = Nothing
        Label47.Text = "0"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.OpenFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files(*.png)|*.png"
        MessageBox.Show("File foto harus JPG/JPEG/PNG", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.PictureBox1.ImageLocation = OpenFileDialog1.FileName
            Label47.Text = "1"
        End If
    End Sub

    Private Sub data_nasabah_perorangan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncetak_form_Click(sender As Object, e As EventArgs) Handles btncetak_form.Click
        Try
            rd.Close()
        Catch ex As Exception

        End Try
        With form_data_nasabah
            .TextBox1.Text = tnasabah_id.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub tnasabah_id_TextChanged(sender As Object, e As EventArgs) Handles tnasabah_id.TextChanged
        If Len(tnasabah_id.Text) = 0 Then
            btncetak_form.Enabled = False
        Else
            btncetak_form.Enabled = True
        End If
    End Sub

    Private Sub btnprofile_Click(sender As Object, e As EventArgs) Handles btnprofile.Click
        With form_profil
            .TextBox1.Text = tnasabah_id.Text
            .ShowDialog()
        End With
    End Sub
    Sub cekdatanasabah()
        kosong()
        cd = New MySqlCommand("SELECT *,  cari_combo_komponen('02',nasabah_jenis_kelamin) AS jk,  cari_combo_komponen('14',nasabah_keterkaitan) AS keterkaitan, cari_combo_komponen('05',nasabah_status_marital) AS status, cari_combo_komponen('07',nasabah_pendidikan) AS pendidikan, cari_combo_komponen('09',nasabah_dati2) AS kabkot, cari_combo_komponen('04',nasabah_agama) AS agama, cari_combo_komponen('08',nasabah_pekerjaan) AS pekerjaan, cari_combo_komponen('29',nasabah_hubungan_debitur) AS hubungandebitur, cari_combo_komponen('30',nasabah_melanggar_bmpk) AS melanggar,  cari_combo_komponen('31',nasabah_melampaui_bmpk) AS melampaui FROM data_nasabah WHERE nasabah_id='" & tnasabah_id.Text & "'", koneksi) 'mengecek nik
        rd = cd.ExecuteReader
        rd.Read()

        tnasabah_id.Text = rd.Item("nasabah_id")
        talternatif.Text = rd.Item("nasabah_alternatif")
        tnama.Text = rd.Item("nasabah_nama1")
        tnama2.Text = rd.Item("nasabah_nama2")
        tnik.Text = rd.Item("nasabah_nik")
        tnik.Enabled = False
        tnpwp.Text = rd.Item("nasabah_npwp")
        tkota.Text = rd.Item("nasabah_kota")
        DateTimePicker1.Checked = True
        DateTimePicker1.Value = rd.Item("nasabah_tanggal_lahir")
        tnama_pasangan.Text = rd.Item("nasabah_nama_pasangan")
        tnik_pasangan.Text = rd.Item("nasabah_nik_pasangan")
        DateTimePicker2.Checked = True
        DateTimePicker2.Value = rd.Item("nasabah_tanggal_lahir_pasangan")
        cmbpph.Text = rd.Item("nasabah_pph_pasangan")
        tket_pendidikan.Text = rd.Item("nasabah_keterangan_pendidikan")
        tnama_ibu.Text = rd.Item("nasabah_nama_ibu")
        talamat.Text = rd.Item("nasabah_alamat")
        tkelurahan.Text = rd.Item("nasabah_kelurahan")
        tkecamatan.Text = rd.Item("nasabah_kecamatan")
        tkode_daerah.Text = rd.Item("nasabah_dati2")
        tkode_pos.Text = rd.Item("nasabah_kode_pos")
        talamat_domisili.Text = rd.Item("nasabah_alamat_domisili")
        DateTimePicker3.Checked = True
        DateTimePicker3.Value = rd.Item("nasabah_tanggal_domisili")
        tkode_area.Text = rd.Item("nasabah_kode_area")
        ttelepon.Text = rd.Item("nasabah_telepon")
        tmobile.Text = rd.Item("nasabah_mobile")
        tpekerjaan.Text = rd.Item("nasabah_pekerjaan")
        tket_pekerjaan.Text = rd.Item("nasabah_keterangan_pekerjaan")
        talamat_bekerja.Text = rd.Item("nasabah_alamat_bekerja")
        tjml_tanggungan.Text = rd.Item("nasabah_jumlah_tanggungan")
        tgaji.Text = rd.Item("nasabah_gaji")
        tusaha.Text = rd.Item("nasabah_usaha")
        tlain.Text = rd.Item("nasabah_lain")
        pilih_pekerjaan()
        tkode_hubungan.Text = rd.Item("nasabah_hubungan_debitur")
        Label42.Text = rd.Item("nasabah_reg_waktu")
        Label43.Text = rd.Item("nasabah_reg_username")
        Label44.Text = rd.Item("nasabah_update_waktu")
        Label45.Text = rd.Item("nasabah_update_username")

        cmbsex.Text = rd.Item("jk")
        cmbketerkaitan.Text = rd.Item("keterkaitan")
        cmbstatus.Text = rd.Item("status")
        pilihan_status()
        cmbpendidikan.Text = rd.Item("pendidikan")
        cmbdaerah.Text = rd.Item("kabkot")
        cmbagama.Text = rd.Item("agama")
        cmbpekerjaan.Text = rd.Item("pekerjaan")
        cmbhubungan.Text = rd.Item("hubungandebitur")
        cmbmelanggar.Text = rd.Item("melanggar")
        cmbmelampaui.Text = rd.Item("melampaui")
        rd.Close()

        Try
            cd = New MySqlCommand("SELECT * FROM data_nasabah_gambar WHERE gambar_nasabah_id='" & tnasabah_id.Text & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()

            Dim arrImage() As Byte
            arrImage = rd.Item("gambar_file")
            Dim ms As New IO.MemoryStream(CType(arrImage, Byte()))

            rd.Close()
            PictureBox1.Image = Image.FromStream(ms)
            Label46.Text = "1"
        Catch ex As Exception
            Label46.Text = "0"
        End Try

        btnprofile.Enabled = True
        btncetak_form.Enabled = True
    End Sub

    
    Private Sub tkode_daerah_LostFocus(sender As Object, e As EventArgs) Handles tkode_daerah.LostFocus
        caridaerah()
    End Sub

    Private Sub tket_pekerjaan_TextChanged(sender As Object, e As EventArgs) Handles tket_pekerjaan.TextChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker3.MinDate = Format(DateTimePicker1.Value, "dd MMMM yyyy")
    End Sub

    Sub hitungumur()
        d = MDIParent1.DateTimePicker1.Value.Day - DateTimePicker1.Value.Day
        m = MDIParent1.DateTimePicker1.Value.Month - DateTimePicker1.Value.Month
        y = MDIParent1.DateTimePicker1.Value.Year - DateTimePicker1.Value.Year

        If Math.Sign(d) = -1 Then
            d = 30 - Math.Abs(d)
            m -= 1
        End If
        If Math.Sign(m) = -1 Then
            m = 12 - Math.Abs(m)
            y -= 1
        End If

        'TextBox1.Text = y & " tahun, " & m & " bulan, " & d & " hari"
    End Sub
End Class