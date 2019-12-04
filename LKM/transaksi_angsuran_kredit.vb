Imports MySql.Data.MySqlClient
Public Class transaksi_angsuran_kredit
    Dim data_ke(99) As String

    Private Sub tnomor_rekening_LostFocus(sender As Object, e As EventArgs) Handles tnomor_rekening.LostFocus
        carikredit()
    End Sub

    Private Sub tkode_transaksi_LostFocus(sender As Object, e As EventArgs) Handles tkode_transaksi.LostFocus
        caritransaksi()
    End Sub

    Private Sub cmb_transaksi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_transaksi.SelectedIndexChanged
        tkode_transaksi.Text = cmb_transaksi.Text.ToString.Split(" :")(0)
        tpokok.Clear()
        tbunga.Clear()
        tsetelah_transaksi.Text = "0"
        tnomor_rekening2.Clear()
        tnama_nasabah2.Clear()
        tsaldo.Text = "0"
        Select Case cmb_transaksi.Text.ToString.Split(" :")(0)
            Case "101" ' angsuran tunai
                tpokok.Enabled = True
                tbunga.Enabled = True
                tnomor_rekening2.Enabled = False
                Button2.Enabled = False
                Label32.Text = "Nomor Rekening :"
                Label33.Text = "Nama Nasabah :"

            Case "102" 'angsuan ob dari tabungan
                tpokok.Enabled = True
                tbunga.Enabled = True
                tnomor_rekening2.Enabled = True
                Button2.Enabled = True
                Label32.Text = "Nomor Rekening :"
                Label33.Text = "Nama Nasabah :"

            Case "104" 'angsuran ob dari coa
                tpokok.Enabled = True
                tbunga.Enabled = True
                tnomor_rekening2.Enabled = True
                Button2.Enabled = True
                Label32.Text = "Kode Perkiraan :"
                Label33.Text = "Nama Perkiraan :"

            Case "106" 'pelunasan tunai
                tpokok.Enabled = False
                tbunga.Enabled = False
                tnomor_rekening2.Enabled = False
                Button2.Enabled = False
                Label32.Text = "Nomor Rekening :"
                Label33.Text = "Nama Nasabah :"

            Case "107" 'pelunasan dari tabungan
                tpokok.Enabled = False
                tbunga.Enabled = False
                tnomor_rekening2.Enabled = True
                Button2.Enabled = True
                Label32.Text = "Nomor Rekening :"
                Label33.Text = "Nama Nasabah :"

            Case "109" ' pelunasan dri coa
                tpokok.Enabled = False
                tbunga.Enabled = False
                tnomor_rekening2.Enabled = True
                Button2.Enabled = True
                Label32.Text = "Kode Perkiraan :"
                Label33.Text = "Nama Perkiraan :"

            Case Else  ' kosonf
                tpokok.Enabled = False
                tbunga.Enabled = False
                tnomor_rekening2.Enabled = False
                Button2.Enabled = False
                Label32.Text = "Nomor Rekening :"
                Label33.Text = "Nama Nasabah :"

        End Select
        transpelunasan()
        tsetelah_transaksi.Text = "0"
    End Sub

    Private Sub tpokok_TextChanged(sender As Object, e As EventArgs) Handles tpokok.TextChanged
        Try
            tpokok.Text = FormatNumber(tpokok.Text, 0)
            tpokok.SelectionStart = Len(tpokok.Text)
        Catch ex As Exception
            tpokok.Text = "0"
        End Try
        tsetelah_transaksi.Text = FormatNumber(Val(Format(tpokok2.Text, "General Number")) - Val(Format(ttot_setoran.Text, "General Number")), 0)
        rumus()
    End Sub

    Private Sub tbunga_TextChanged(sender As Object, e As EventArgs) Handles tbunga.TextChanged
        Try
            tbunga.Text = FormatNumber(tbunga.Text, 0)
            tbunga.SelectionStart = Len(tbunga.Text)
        Catch ex As Exception
            tbunga.Text = "0"
        End Try
        rumus()
    End Sub

    Private Sub tdenda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tdenda.KeyPress, tbunga.KeyPress, tpokok.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tdenda_TextChanged(sender As Object, e As EventArgs) Handles tdenda.TextChanged
        Try
            tdenda.Text = FormatNumber(tdenda.Text, 0)
            tdenda.SelectionStart = Len(tdenda.Text)
        Catch ex As Exception
            tdenda.Text = "0"
        End Try
        rumus()
    End Sub

    Private Sub tnomor_rekening2_GotFocus(sender As Object, e As EventArgs) Handles tnomor_rekening2.GotFocus, tdenda.GotFocus, tbunga.GotFocus, tpokok.GotFocus, cmb_transaksi.GotFocus, tkode_transaksi.GotFocus, tno_kuitansi.GotFocus, tnomor_rekening.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tnomor_rekening2_LostFocus(sender As Object, e As EventArgs) Handles tnomor_rekening2.LostFocus
        If Label32.Text = "Nomor Rekening :" Then
            carirekening()
        ElseIf Label32.Text = "Kode Perkiraan :" Then
            carirekening()
        End If
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub transaksi_angsuran_kredit_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tnomor_rekening.Focus()
    End Sub

    Private Sub transaksi_angsuran_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub transaksi_angsuran_kredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' koneksi_localhost()
        'koneksi.Open()
        Try
            rd.Close()
        Catch ex As Exception

        End Try
        Me.ResizeRedraw = True
        kosong()
        combo()
    End Sub

    Sub kosong()
        tnomor_rekening.Clear()
        carikredit()
        tnomor_rekening.Enabled = True
        Button1.Enabled = True
        tid_transaksi.Clear()
        tkode_transaksi.Clear()
        cmb_transaksi.Text = ""
        tkode_transaksi.Enabled = True
        cmb_transaksi.Enabled = True
        tno_kuitansi.Clear()
        tno_kuitansi.Enabled = True
        Timer1.Enabled = True
        tpokok.Clear()
        tbunga.Clear()
        tdenda.Clear()
        tpokok.Enabled = True
        tbunga.Enabled = True
        tdenda.Enabled = True
        tnomor_rekening2.Enabled = False
        Button2.Enabled = False
        tnomor_rekening2.Clear()
        tnama_nasabah2.Clear()
        tsetelah_transaksi.Text = "0"
        tsaldo.Text = "0"
        btnvalidasi.Enabled = True
        tnomor_rekening.Focus()
    End Sub

    Private Sub transaksi_angsuran_kredit_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Sub combo()
        cd = New MySqlCommand("CALL isi_combo('106')", koneksi)
        rd = cd.ExecuteReader
        With cmb_transaksi.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()
    End Sub

    Private Sub btnvalidasi_Click(sender As Object, e As EventArgs) Handles btnvalidasi.Click
        If tnomor_rekening.Text = "" Then
            MessageBox.Show("Nomor Rekening harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnomor_rekening.Focus()
            Exit Sub
        ElseIf tnama_nasabah.Text = "" And talamat.Text = "" Then
            MessageBox.Show("Nomor Rekening tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnomor_rekening.Focus()
            Exit Sub
        ElseIf cmb_transaksi.Text = "" Then
            MessageBox.Show("Kode Transaksi harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmb_transaksi.Focus()
            Exit Sub
        ElseIf ttot_setoran.Text = "0" Then
            MessageBox.Show("Total Setoran tidak boleh nol.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tpokok.Focus()
            Exit Sub
        ElseIf Val(Format(tpokok.Text, "General Number")) > Val(Format(tpokok2.Text, "General Number")) Then
            MessageBox.Show("Total Setoran Pokok terlalu banyak.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tpokok.Focus()
            Exit Sub
        ElseIf Val(Format(tbunga.Text, "General Number")) > Val(Format(Label23.Text, "General Number")) Then
            MessageBox.Show("Angsuran bunga terlalu besar. " + Chr(10) + "Sisa tagihan bunga sebesar " + FormatNumber(Label23.Text, 0) + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tbunga.Focus()
            Exit Sub
        ElseIf tpokok.Text = tpokok2.Text And (tkode_transaksi.Text = "101" Or tkode_transaksi.Text = "102" Or tkode_transaksi.Text = "104") Then
            MessageBox.Show("Untuk transaksi pelunasan, Gunakan Kode Transaksi Pelunasan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmb_transaksi.Focus()
            Exit Sub
        ElseIf tnama_nasabah2.Text = "" And tnomor_rekening2.Enabled = True Then
            MessageBox.Show("Nomor Rekening tujuan harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnomor_rekening2.Focus()
            Exit Sub
        ElseIf tsaldo.Text = "0" And tnomor_rekening2.Enabled = True Then
            MessageBox.Show("Jumlah saldo tidak boleh nol.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnomor_rekening2.Focus()
            Exit Sub
        ElseIf tnomor_rekening2.Enabled = True And Val(Format(tsaldo.Text, "General Number")) < Val(Format(ttot_setoran.Text, "General Number")) Then
            MessageBox.Show("Jumlah saldo tidak mencukupi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnomor_rekening2.Focus()
            Exit Sub
        End If

        simpan()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateTimePicker1.Text = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With pencarian_kredit_aktif
            .ShowDialog()
        End With
        If tnama_nasabah.Text = "" Then
            Button1.Focus()
        Else
            tkode_transaksi.Focus()
        End If
    End Sub
    Sub caritransaksi()
        rd.Close()
        cd = New MySqlCommand("SELECT cari_combo_komponen('106','" & tkode_transaksi.Text & "') AS transaksi", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmb_transaksi.Text = rd.Item("transaksi")
        Catch ex As Exception
            cmb_transaksi.Text = ""
        End Try
        rd.Close()
    End Sub
    Sub carikredit()
        Try
            rd.Close()
        Catch ex As Exception

        End Try
        cd = New MySqlCommand("SELECT rek_kre_no_rekening, rek_kre_no_alternatif, nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, rek_kre_tanggal_jt, rek_kre_plafon_induk, hitung_total_tunggakan_pokok(rek_kre_no_rekening, NOW()) AS tunggakan_pokok, hitung_total_tunggakan_bunga(rek_kre_no_rekening,NOW()) AS tunggakan_bunga, hitung_frekuensi_tunggakan_pokok(rek_kre_no_rekening,NOW()) AS frek_pokok, hitung_frekuensi_tunggakan_bunga(rek_kre_no_rekening,NOW()) AS frek_bunga, hitung_baki_debet(rek_kre_no_rekening,NOW()) AS bakidebet, hitung_total_pelunasan_bunga(rek_kre_no_rekening,NOW()) AS pelunasanbunga, (SELECT COUNT(*) FROM data_kredit_angsuran WHERE angs_no_rekening=rek_kre_no_rekening) AS jml, hitung_denda_hari(rek_kre_no_rekening, NOW()) AS denda_hari, hitung_denda(rek_kre_no_rekening, NOW()) AS denda FROM data_kredit_rekening JOIN data_nasabah ON rek_kre_nasabah_id=nasabah_id WHERE rek_kre_no_rekening='" & tnomor_rekening.Text & "' AND rek_kre_status IN ('2')", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_nasabah.Text = rd.Item("nasabah_nama1")
            talamat.Text = rd.Item("nasabah_alamat") + ", " + rd.Item("nasabah_kelurahan") + ", " + rd.Item("nasabah_kecamatan")
            ttgl_jatuh_tempo.Text = Format(rd.Item("rek_kre_tanggal_jt"), "dd-MM-yyyy")
            tplafond1.Text = FormatNumber(rd.Item("rek_kre_plafon_induk"), 0)
            ttgk_pokok1.Text = FormatNumber(rd.Item("tunggakan_pokok"), 0)
            ttgk_bunga1.Text = FormatNumber(rd.Item("tunggakan_bunga"), 0)
            ttgk_pokok2.Text = FormatNumber(rd.Item("frek_pokok"), 2)
            ttgk_bunga2.Text = FormatNumber(rd.Item("frek_bunga"), 2)
            tdenda1.Text = FormatNumber(rd.Item("denda"), 0)
            tdenda2.Text = FormatNumber(rd.Item("denda_hari"), 0)
            tplafond2.Text = FormatNumber(rd.Item("bakidebet"), 0)
            tpokok2.Text = FormatNumber(rd.Item("bakidebet"), 0)
            tbunga2.Text = FormatNumber(rd.Item("pelunasanbunga"), 0)
            tangs_ke.Text = rd.Item("jml") + 1

            rd.Close()

            cd = New MySqlCommand("SELECT * FROM data_kredit_statement WHERE kre_stat_jenis='3' AND kre_stat_no_rekening='" & tnomor_rekening.Text & "' AND kre_stat_waktu>='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & " 00:00:00' LIMIT 0,1", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            Try
                tpokok1.Text = FormatNumber(rd.Item("kre_stat_tag_pokok"), 0)
                tbunga1.Text = FormatNumber(rd.Item("kre_stat_tag_bunga"), 0)
            Catch ex As Exception
                tpokok1.Text = "0"
                tbunga1.Text = "0"
            End Try
            rd.Close()

            cd = New MySqlCommand("SELECT IFNULL(hitung_kolek('" & tnomor_rekening.Text & "', '" & Format(DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "'),'-') AS kolek", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            Try
                tkol.Text = rd.Item("kolek")
            Catch ex As Exception
                tkol.Text = "-"
            End Try
            rd.Close()

            cd = New MySqlCommand("SELECT SUM(kre_stat_tag_bunga-kre_stat_angs_bunga) AS sisa_angs_bunga FROM data_kredit_statement WHERE kre_stat_no_rekening = '" & tnomor_rekening.Text & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            Label23.Text = rd.Item("sisa_angs_bunga")
            rd.Close()

        Catch ex As Exception
            'MsgBox(ex.Message)
            tnama_nasabah.Clear()
            talamat.Clear()
            ttgl_jatuh_tempo.Text = "00-00-0000"
            tplafond1.Text = "0"
            tangs_ke.Text = "0"
            tkol.Text = "-"
            ttgk_pokok1.Text = "0"
            ttgk_bunga1.Text = "0"
            ttgk_pokok2.Text = "0,00"
            ttgk_bunga2.Text = "0,00"
            tdenda1.Text = "0"
            tdenda2.Text = "0"
            tplafond2.Text = "0"
            tpokok2.Text = "0"
            tbunga2.Text = "0"
            tangs_ke.Text = "1"
            tpokok1.Text = "0"
            tbunga1.Text = "0"
            tkol.Text = "-"
            Label23.Text = "0"
        End Try
        rd.Close()
        transpelunasan()
        tsetelah_transaksi.Text = "0"
    End Sub

    Sub transpelunasan()
        If cmb_transaksi.Text.ToString.Split(" :")(0) = "106" Or cmb_transaksi.Text.ToString.Split(" :")(0) = "107" Or cmb_transaksi.Text.ToString.Split(" :")(0) = "109" Then
            tpokok.Text = FormatNumber(Format(tpokok2.Text, "General Number"), 0)
            tbunga.Text = FormatNumber(Format(tbunga2.Text, "General Number"), 0)

        End If
    End Sub

    Private Sub tbunga1_TextChanged(sender As Object, e As EventArgs) Handles tbunga1.TextChanged, tpokok1.TextChanged
        rumus_total_tagihan_berjalan()
    End Sub

    Sub rumus_total_tagihan_berjalan()
        ttotal1.Text = FormatNumber(Val(Format(tpokok1.Text, "General Number")) + Val(Format(tbunga1.Text, "General Number")), 0)
    End Sub

    Private Sub tbunga2_TextChanged(sender As Object, e As EventArgs) Handles tbunga2.TextChanged, tpokok2.TextChanged
        rumus_total_pelunasan()
    End Sub

    Sub rumus_total_pelunasan()
        ttotal2.Text = FormatNumber(Val(Format(tpokok2.Text, "General Number")) + Val(Format(tbunga2.Text, "General Number")), 0)
    End Sub
    Sub rumus()
        ttot_setoran.Text = FormatNumber(Val(Format(tpokok.Text, "General Number")) + Val(Format(tbunga.Text, "General Number")) + Val(Format(tdenda.Text, "General Number")), 0)
    End Sub

    Sub notransaksi()
        cd = New MySqlCommand("SELECT IFNULL(MAX(RIGHT(angs_id_transaksi,5)), '0') AS trans FROM data_kredit_angsuran WHERE angs_tanggal='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tid_transaksi.Text = tkode_transaksi.Text + "." + Format(DateTimePicker1.Value, "ddMMyyyy").ToString + "." + Microsoft.VisualBasic.Right("00000" & Microsoft.VisualBasic.Right(rd.Item("trans"), 5) + 1, 5)
        rd.Close()
    End Sub
    Sub simpan()
        notransaksi()
        data_ke(0) = tid_transaksi.Text
        data_ke(1) = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        data_ke(2) = Format(DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        data_ke(3) = tnomor_rekening.Text
        data_ke(4) = tkode_transaksi.Text
        data_ke(5) = tno_kuitansi.Text
        data_ke(6) = cmbmetode.Text.ToString.Split(" :")(0)
        data_ke(7) = Format(ttot_setoran.Text, "General Number")
        data_ke(8) = Format(tpokok.Text, "General Number")
        data_ke(9) = Format(tbunga.Text, "General Number")
        data_ke(10) = Format(tdenda.Text, "General Number")
        data_ke(11) = tnomor_rekening2.Text
        data_ke(12) = "1"
        data_ke(13) = MDIParent1.username.Text
        Dim gabung = ""
        For n = 0 To 13
            If n = 0 Then
                gabung += "'" + data_ke(n) + "'"
            Else
                gabung += ",'" + data_ke(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_kredit_angsuran VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Melakukan Transaksi Angsuran Kredit (angs_id_transaksi : " + data_ke(0) + ")"
        insert_log_user()

        tnomor_rekening.Enabled = False
        Button1.Enabled = False
        tno_kuitansi.Enabled = False
        tkode_transaksi.Enabled = False
        cmb_transaksi.Enabled = False
        Timer1.Enabled = False
        tpokok.Enabled = False
        tbunga.Enabled = False
        tdenda.Enabled = False
        tnomor_rekening2.Enabled = False
        Button2.Enabled = False
        btnvalidasi.Enabled = False
        If MessageBox.Show("Cetak Validasi?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cetakvalidasi()
        End If
        MessageBox.Show("Transaksi berhasil divalidasi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kosong()
    End Sub

    Private Sub ttotal2_TextChanged(sender As Object, e As EventArgs) Handles ttotal2.TextChanged
        tsetelah_transaksi.Text = FormatNumber(Val(Format(tpokok2.Text, "General Number")) - Val(Format(ttot_setoran.Text, "General Number")), 0)
    End Sub
    Sub carirekening()
        cd = New MySqlCommand("SELECT cari_nama_rekening_tabungan(rek_tab_no_rekening) AS nama1,  hitung_saldo_akhir_tabungan(rek_tab_no_rekening, '" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "') AS saldo FROM data_tabungan_rekening WHERE rek_tab_no_rekening = '" & tnomor_rekening2.Text & "' AND rek_tab_status='1'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_nasabah2.Text = rd.Item("nama1")
            tsaldo.Text = FormatNumber(rd.Item("saldo"), 0)
        Catch ex As Exception
            tnama_nasabah2.Clear()
            tsaldo.Text = "0"
        End Try
        rd.Close()
    End Sub
    Sub cariperkiraan()
        cd = New MySqlCommand("SELECT perkiraan_nama, perkiraan_jurnal, hitung_saldo_perkiraan_akhir(perkiraan_kode,NOW()) AS saldo FROM kode_perkiraan WHERE perkiraan_kode='" & tnomor_rekening2.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            If rd.Item("perkiraan_jurnal") = "1" Then
                tnama_nasabah2.Text = rd.Item("perkiraan_nama")
                tsaldo.Text = FormatNumber(rd.Item("saldo"), 0)
            Else
                tnomor_rekening2.Clear()
                tnama_nasabah2.Clear()
                tsaldo.Text = "0"
                MessageBox.Show("Kode Perkiraan tidak dapat dijurnal.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                tnomor_rekening2.Focus()
            End If
        Catch ex As Exception
            tnomor_rekening2.Clear()
            tnama_nasabah2.Clear()
            tsaldo.Text = "0"
        End Try
        rd.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Label32.Text = "Nomor Rekening :" Then
            With pencarian_master_tabungan
                .Label4.Text = "transaksi angsuran kredit"
                .ShowDialog()
            End With
        Else
            With pencarian_perkiraan
                .Label4.Text = "transaksi_angsuran_kredit_kode_perkiraan"
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub tnama_nasabah_TextChanged(sender As Object, e As EventArgs) Handles tnama_nasabah.TextChanged
        If tnama_nasabah.Text = "" Then
            btnjadual_angsuran.Enabled = False
            btnstatement_transaksi.Enabled = False
        Else
            btnjadual_angsuran.Enabled = True
            btnstatement_transaksi.Enabled = True
        End If
    End Sub

    Private Sub btnjadual_angsuran_Click(sender As Object, e As EventArgs) Handles btnjadual_angsuran.Click
        With jadual_angsuran
            .kosong()
            .tno_rekening.Text = tnomor_rekening.Text
            .caridata()
            .tampil()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnstatement_transaksi_Click(sender As Object, e As EventArgs) Handles btnstatement_transaksi.Click
        With statement_transaksi
            .tno_rekening.Text = tnomor_rekening.Text
            .caristatement()
            .ShowDialog()
        End With
    End Sub

    Private Sub tdenda1_TextChanged(sender As Object, e As EventArgs) Handles tdenda1.TextChanged, ttgk_bunga1.TextChanged, ttgk_pokok1.TextChanged
        rumus_kewajibanbayar_total()
        If sender.text = tdenda1.Text Then
            tdenda.Text = Format(tdenda1.Text, "General Number")
        End If
    End Sub

    Sub rumus_kewajibanbayar_total()
        ttotal.Text = FormatNumber(Val(Format(ttgk_pokok1.Text, "General Number")) + Val(Format(ttgk_bunga1.Text, "General Number")) + Val(Format(tdenda1.Text, "General Number")), 0)
    End Sub

    Private Sub tdenda_LostFocus(sender As Object, e As EventArgs) Handles tdenda.LostFocus, tnomor_rekening2.LostFocus, tbunga.LostFocus, tpokok.LostFocus, cmb_transaksi.LostFocus, tkode_transaksi.LostFocus, tno_kuitansi.LostFocus, tnomor_rekening.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub cmb_transaksi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_transaksi.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub tnomor_rekening2_TextChanged(sender As Object, e As EventArgs) Handles tnomor_rekening2.TextChanged

    End Sub
    Sub cetakvalidasi()
        Dim ukuran(99) As String
        Dim cetakan As String = ""
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""

        For ii As Integer = 1 To 3
            If ii = 1 Then
                cetakan = "KiriVAngsuran"
            ElseIf ii = 2 Then
                cetakan = "AtasVAngsuran"
            ElseIf ii = 3 Then
                cetakan = "FontVAngsuran"
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

        cd = New MySqlCommand("SELECT angs_id_transaksi, angs_waktu, angs_username, angs_kode_transaksi, IF(angs_kode_transaksi IN ('101','106'), ' CASH IDR ',' OVERBOOKING IDR ') AS jns, angs_pokok, angs_bunga, angs_denda, kre_stat_uraian, cari_teller(angs_username) AS kode_teller FROM data_kredit_angsuran JOIN data_kredit_statement ON angs_id_transaksi=kre_stat_id_transaksi WHERE angs_id_transaksi='" & tid_transaksi.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()

        baris(0) = rd.Item("angs_id_transaksi") + " " + Format(rd.Item("angs_waktu"), "dd/MM/yy HH:mm:ss").ToString + " [" + rd.Item("kode_teller") + "]"
        baris(1) = rd.Item("angs_kode_transaksi").ToString + rd.Item("jns").ToString + FormatNumber(rd.Item("angs_pokok"), 0) + " (Pokok), " + FormatNumber(rd.Item("angs_bunga"), 0) + " (Bunga), " + FormatNumber(rd.Item("angs_denda"), 0) + " (Denda)"
        baris(2) = rd.Item("kre_stat_uraian")

        rd.Close()

        For i = 0 To UBound(baris) ' UBound = batas atas array
            TextToPrint &= baris(i) & Environment.NewLine
        Next i

    End Sub

    Private Sub tnomor_rekening_TextChanged(sender As Object, e As EventArgs) Handles tnomor_rekening.TextChanged

    End Sub

    Private Sub tdenda2_TextChanged(sender As Object, e As EventArgs) Handles tdenda2.TextChanged

    End Sub
End Class