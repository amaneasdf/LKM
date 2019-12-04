Imports MySql.Data.MySqlClient
Public Class cetak_nominatif_kredit

    Private Sub cmbjenis_laporan_GotFocus(sender As Object, e As EventArgs) Handles cmbjenis_laporan.GotFocus, tkode_skim_kredit.GotFocus, cmbskim_kredit.GotFocus, tkode_jenis_kredit.GotFocus, cmbjenis_kredit.GotFocus, tjkw.GotFocus, tkode_sistem_bunga.GotFocus, tsuku_bunga.GotFocus, cmbsistem_bunga.GotFocus, tkode_sistem_angsuran.GotFocus, cmbsistem_angsuran.GotFocus, cmbkolektibilitas.GotFocus, tplafon1.GotFocus, tplafon2.GotFocus, tbaki_debet1.GotFocus, tbaki_debet2.GotFocus, tkode_golongan_debitur.GotFocus, cmbgolongan_debitur.GotFocus, tkode_jenis_penggunaan.GotFocus, cmbjenis_penggunaan.GotFocus, tkode_sektor_ekonomi.GotFocus, cmbsektor_ekonomi.GotFocus, tkode_jenis_usaha.GotFocus, cmbjenis_usaha.GotFocus, tkode_jenis_agunan.GotFocus, cmbjenis_agunan.GotFocus, tkode_sumber_dana_angs.GotFocus, cmbsumber_dana_angs.GotFocus, cmbkolektor.GotFocus, cmbmarketing.GotFocus, cmbwilayah.GotFocus, tkecamatan.GotFocus, tkelurahan.GotFocus, cmbketerkaitan.GotFocus, cmbjenis_kelamin.GotFocus, cmburutkan_data.GotFocus, cmbby.GotFocus, tlimit.GotFocus, cmbinstansi.GotFocus

        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbjenis_laporan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbjenis_laporan.KeyPress, cmbskim_kredit.KeyPress, cmbjenis_kredit.KeyPress, cmbsistem_bunga.KeyPress, cmbsistem_angsuran.KeyPress, cmbkolektibilitas.KeyPress, cmbgolongan_debitur.KeyPress, cmbjenis_penggunaan.KeyPress, cmbsektor_ekonomi.KeyPress, cmbjenis_usaha.KeyPress, cmbjenis_agunan.KeyPress, cmbsumber_dana_angs.KeyPress, cmbkolektor.KeyPress, cmbmarketing.KeyPress, cmbwilayah.KeyPress, cmbketerkaitan.KeyPress, cmbjenis_kelamin.KeyPress, cmburutkan_data.KeyPress, cmbby.KeyPress, cmbinstansi.KeyPress

        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbjenis_laporan_LostFocus(sender As Object, e As EventArgs) Handles cmbjenis_laporan.LostFocus, tkode_skim_kredit.LostFocus, cmbskim_kredit.LostFocus, tkode_jenis_kredit.LostFocus, cmbjenis_kredit.LostFocus, tjkw.LostFocus, tsuku_bunga.LostFocus, tkode_sistem_bunga.LostFocus, cmbsistem_bunga.LostFocus, tkode_sistem_angsuran.LostFocus, cmbsistem_angsuran.LostFocus, cmbkolektibilitas.LostFocus, tplafon1.LostFocus, tplafon2.LostFocus, tbaki_debet1.LostFocus, tbaki_debet2.LostFocus, tkode_golongan_debitur.LostFocus, cmbgolongan_debitur.LostFocus, tkode_jenis_penggunaan.LostFocus, cmbjenis_penggunaan.LostFocus, tkode_sektor_ekonomi.LostFocus, cmbsektor_ekonomi.LostFocus, tkode_jenis_usaha.LostFocus, cmbjenis_usaha.LostFocus, tkode_jenis_agunan.LostFocus, cmbjenis_agunan.LostFocus, tkode_sumber_dana_angs.LostFocus, cmbsumber_dana_angs.LostFocus, cmbkolektor.LostFocus, cmbmarketing.LostFocus, cmbwilayah.LostFocus, tkecamatan.LostFocus, tkelurahan.LostFocus, cmbketerkaitan.LostFocus, cmbjenis_kelamin.LostFocus, cmburutkan_data.LostFocus, cmbby.LostFocus, tlimit.LostFocus, cmbinstansi.LostFocus

        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub cetak_nominatif_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cetak_nominatif_kredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        combo()
        def()
        Me.ResizeRedraw = True
    End Sub

    Private Sub cetak_nominatif_kredit_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Me.Dispose()
    End Sub

    Private Sub tkode_skim_kredit_LostFocus(sender As Object, e As EventArgs) Handles tkode_skim_kredit.LostFocus
        cariskimkredit()
    End Sub

    Private Sub cmbskim_kredit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbskim_kredit.SelectedIndexChanged
        tkode_skim_kredit.Text = cmbskim_kredit.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_jenis_kredit_LostFocus(sender As Object, e As EventArgs) Handles tkode_jenis_kredit.LostFocus
        carijeniskredit()
    End Sub

    Private Sub cmbjenis_kredit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjenis_kredit.SelectedIndexChanged
        tkode_jenis_kredit.Text = cmbjenis_kredit.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tjkw_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tjkw.KeyPress, tplafon1.KeyPress, tplafon2.KeyPress, tbaki_debet1.KeyPress, tbaki_debet2.KeyPress, tlimit.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tjkw_TextChanged(sender As Object, e As EventArgs) Handles tjkw.TextChanged, tplafon1.TextChanged, tplafon2.TextChanged, tbaki_debet1.TextChanged, tbaki_debet2.TextChanged, tlimit.TextChanged

        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub

    Private Sub tsuku_bunga_LostFocus(sender As Object, e As EventArgs) Handles tsuku_bunga.LostFocus
        Try
            tsuku_bunga.Text = FormatNumber(tsuku_bunga.Text, 3)
        Catch ex As Exception
            tsuku_bunga.Text = "0,000"
        End Try
    End Sub

    Private Sub tsuku_bunga_TextChanged(sender As Object, e As EventArgs) Handles tsuku_bunga.TextChanged
        If Val(tsuku_bunga.Text) > 100 Then
            tsuku_bunga.Clear()
        End If
    End Sub

    Private Sub tkode_sistem_bunga_LostFocus(sender As Object, e As EventArgs) Handles tkode_sistem_bunga.LostFocus
        carisistembunga()
    End Sub

    Private Sub cmbsistem_bunga_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsistem_bunga.SelectedIndexChanged
        tkode_sistem_bunga.Text = cmbsistem_bunga.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_sistem_angsuran_LostFocus(sender As Object, e As EventArgs) Handles tkode_sistem_angsuran.LostFocus
        carisistemangsuran()
    End Sub

    Private Sub cmbsistem_angsuran_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsistem_angsuran.SelectedIndexChanged
        tkode_sistem_angsuran.Text = cmbsistem_angsuran.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_golongan_debitur_LostFocus(sender As Object, e As EventArgs) Handles tkode_golongan_debitur.LostFocus
        carigolongandebitur()
    End Sub

    Private Sub cmbgolongan_debitur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbgolongan_debitur.SelectedIndexChanged
        tkode_golongan_debitur.Text = cmbgolongan_debitur.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_jenis_penggunaan_LostFocus(sender As Object, e As EventArgs) Handles tkode_jenis_penggunaan.LostFocus
        carijenispenggunaan()
    End Sub

    Private Sub cmbjenis_penggunaan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjenis_penggunaan.SelectedIndexChanged
        tkode_jenis_penggunaan.Text = cmbjenis_penggunaan.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_sektor_ekonomi_LostFocus(sender As Object, e As EventArgs) Handles tkode_sektor_ekonomi.LostFocus
        carisektorekonomi()
    End Sub

    Private Sub cmbsektor_ekonomi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsektor_ekonomi.SelectedIndexChanged
        tkode_sektor_ekonomi.Text = cmbsektor_ekonomi.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_jenis_usaha_LostFocus(sender As Object, e As EventArgs) Handles tkode_jenis_usaha.LostFocus
        carijenisusaha()
    End Sub

    Private Sub cmbjenis_usaha_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjenis_usaha.SelectedIndexChanged
        tkode_jenis_usaha.Text = cmbjenis_usaha.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_jenis_agunan_LostFocus(sender As Object, e As EventArgs) Handles tkode_jenis_agunan.LostFocus
        carijenisagunan()
    End Sub

    Private Sub cmbjenis_agunan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjenis_agunan.SelectedIndexChanged
        tkode_jenis_agunan.Text = cmbjenis_agunan.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_sumber_dana_angs_LostFocus(sender As Object, e As EventArgs) Handles tkode_sumber_dana_angs.LostFocus
        carisumberdana()
    End Sub

    Private Sub cmbsumber_dana_angs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsumber_dana_angs.SelectedIndexChanged
        tkode_sumber_dana_angs.Text = cmbsumber_dana_angs.Text.ToString.Split(" :")(0)
    End Sub

    Sub combo()
        With cmbjenis_laporan.Items
            .Clear()
            .Add("01 : KREDIT - RINCIAN")
            '.Add("02 : KREDIT - SALDO PINJAMAN")
            '.Add("03 : KREDIT - DLM PENGAWASAN KHUSU (DPK)")
            '.Add("04 : KREDIT - TERLAMBAT (BULAN)")
            '.Add("05 : KREDIT - TEMLAMBAT (HARI)")
            '.Add("06 : KREDIT - DAFTAR TUNGGAKAN")
            '.Add("07 : KREDIT - TIDAK SETOR SEJAK REALISASI")
            '.Add("08 : KREDIT - LUNAS")
            '.Add("09 : KREDIT - ADENDUM")
            '.Add("10 : KREDIT - (REKAP KANTOR)")
            '.Add("11 : KREDIT - (REKAP SUBKANTOR)")
            '.Add("12 : KREDIT - (REKAP SKJM)")
            '.Add("14 : KREDIT - (REKAP JANGKA WAKTU)")
            '.Add("15 : KREDIT - (REKAP SUKU BUNGA)")
            '.Add("16 : KREDIT - (REKAP PLAFOND PINJAMAN)")
            '.Add("17 : KREDIT - (REKAP BAKI DEBET)")
            '.Add("18 : KREDIT - (REKAP SISTEM BUNGA)")
            '.Add("19 : KREDIT - (REKAP PERIODE ANGSURAN)")
            '.Add("20 : KREDIT - (REKAP SIFAT PINJAMAN)")
            '.Add("21 : KREDIT - (REKAP GOLONGAN)")
            '.Add("22 : KREDIT - (REKAP SEKTOR EKONOMI)")
            '.Add("23 : KREDIT - (REKAP JENIS PENGGUNAAN)")
            '.Add("24 : KREDIT - (REKAP JENIS USAHA)")
            '.Add("25 : KREDIT - (REKAP KETERKAITAN)")
            '.Add("26 : KREDIT - (REKAP JENIS KELAMIN")
            '.Add("27 : KREDIT - (REKAP KOLEKTOR)")
            '.Add("28 : KREDIT - (REKAP INSTANSI)")
            '.Add("29 : KREDIT - (REKAP WILAYAH)")
            '.Add("30 : KREDIT - (REKAP AVALIS)")
            '.Add("31 : KREDIT - (REKAP DATI2)")
            '.Add("32 : KREDIT - (REKAP KECAMATAN)")
            '.Add("33 : KREDIT - (REKAP KELURAHAN)")
            '.Add("34 : KREDIT - (REKAP SUMBER DANA ANGSURAN)")
            '.Add("35 : KREDIT - (REKAP SUMBER DANA PINJAMAN)")
            '.Add("36 : KREDIT - (REKAP KELOMPOK ATMR)")
        End With

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', kredit_kode,UPPER(kredit_nama_produk)) AS produkkredit FROM data_kredit_produk WHERE kredit_status='1'", koneksi)
        rd = cd.ExecuteReader
        With cmbskim_kredit.Items
            .Clear()
            .Add("")
            While rd.Read()
                .Add(rd.Item("produkkredit"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('95')", koneksi)
        rd = cd.ExecuteReader
        With cmbjenis_kredit.Items
            .Clear()
            .Add("")
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('21')", koneksi)
        rd = cd.ExecuteReader
        With cmbsistem_bunga.Items
            .Clear()
            .Add("")
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('22')", koneksi)
        rd = cd.ExecuteReader
        With cmbsistem_angsuran.Items
            .Clear()
            .Add("")
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        With cmbkolektibilitas.Items
            .Clear()
            .Add("")
            .Add("L : LANCAR")
            .Add("KL : KURANG LANCAR")
            .Add("D : DIRAGUKAN")
            .Add("M : MACET")
        End With
        cmbkolektibilitas.SelectedIndex = 0

        cd = New MySqlCommand("CALL isi_combo('40')", koneksi)
        rd = cd.ExecuteReader
        With cmbgolongan_debitur.Items
            .Clear()
            .Add("")
            .Add("-- : TIDAK TERIDENTIFIKASI")
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('41')", koneksi)
        rd = cd.ExecuteReader
        With cmbjenis_penggunaan.Items
            .Clear()
            .Add("")
            .Add("-- : TIDAK TERIDENTIFIKASI")
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('39')", koneksi)
        rd = cd.ExecuteReader
        With cmbsektor_ekonomi.Items
            .Clear()
            .Add("")
            .Add("-- : TIDAK TERIDENTIFIKASI")
            While rd.Read()
                cmbsektor_ekonomi.Items.Add(rd.Item("text"))
            End While
            rd.Close()
        End With

        With cmbjenis_usaha.Items
            .Clear()
            .Add("1 : MIKRO")
            .Add("2 : KECIL")
            .Add("3 : MENENGAH")
            .Add("4 : SELAIN USAHA MICRO, KECIL DAN MENENGAH")
        End With

        cd = New MySqlCommand("SELECT text AS jenisagunan FROM v_combo_komponen WHERE combo_komponen in ('43','50') ORDER BY combo_kode", koneksi)
        rd = cd.ExecuteReader
        With cmbjenis_agunan.Items
            .Clear()
            .Add("")
            While rd.Read()
                .Add(rd.Item("jenisagunan"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('78')", koneksi)
        rd = cd.ExecuteReader
        With cmbsumber_dana_angs.Items
            .Clear()
            .Add("")
            .Add("-- : TIDAK TERIDENTIFIKASI")
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()


        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', kolektor_kode,UPPER(kolektor_nama)) AS kolektor FROM data_kolektor", koneksi)
        rd = cd.ExecuteReader
        With cmbkolektor.Items
            .Clear()
            .Add("")
            .Add("-- : TIDAK TERIDENTIFIKASI")
            While rd.Read()
                .Add(rd.Item("kolektor"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', marketing_kode,UPPER(marketing_nama)) AS marketing FROM data_marketing", koneksi)
        rd = cd.ExecuteReader
        With cmbmarketing.Items
            .Clear()
            .Add("")
            .Add("-- : TIDAK TERIDENTIFIKASI")
            While rd.Read()
                .Add(rd.Item("marketing"))
            End While
        End With
        rd.Close()


        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', instansi_kode,UPPER(instansi_nama)) AS instansi FROM data_instansi", koneksi)
        rd = cd.ExecuteReader
        With cmbinstansi.Items
            .Clear()
            .Add("")
            .Add("-- : TIDAK TERIDENTIFIKASI")
            While rd.Read()
                .Add(rd.Item("instansi"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT(wilayah_kode, ' : ', wilayah_nama_kecamatan, ', ', wilayah_nama_desa)  AS wilayah FROM data_wilayah", koneksi)
        rd = cd.ExecuteReader
        With cmbwilayah.Items
            .Clear()
            .Add("")
            .Add("-- : TIDAK TERIDENTIFIKASI")
            While rd.Read()
                .Add(rd.Item("wilayah"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('14')", koneksi)
        rd = cd.ExecuteReader
        With cmbketerkaitan.Items
            .Clear()
            .Add("")
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('02')", koneksi)
        rd = cd.ExecuteReader
        With cmbjenis_kelamin.Items
            .Clear()
            .Add("")
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        With cmburutkan_data.Items
            .Clear()
            .Add("01 : NOMOR REKENING")
            .Add("02 : NOMOR ALTERNATIF")
            .Add("03 : NAMA NASABAH + NO REKENING")
            .Add("04 : NAMA NASABAH + NO ALTERNATIF")
            .Add("05 : TANGGAL REALISASI")
            .Add("06 : TANGGAL JATUH TEWPO")
            .Add("07 : PLAFOND")
            .Add("08 : BAKI DEBET")
        End With

        With cmbby.Items
            .Clear()
            .Add("ASC")
            .Add("DESC")
        End With
    End Sub

    Sub def()
        cmbjenis_laporan.Text = "01 :KREDIT - RINCIAN"
        cmburutkan_data.Text = "01 : NOMOR REKENING"
        cmbby.Text = "ASC"
    End Sub

    Sub cariskimkredit()
        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', kredit_kode,UPPER(kredit_nama_produk)) AS produkkredit FROM data_kredit_produk WHERE kredit_status='1' AND kredit_kode='" & tkode_skim_kredit.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbskim_kredit.Text = rd.Item("produkkredit")
        Catch ex As Exception
            cmbskim_kredit.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carijeniskredit()
        cd = New MySqlCommand("SELECT cari_combo_komponen('95','" & tkode_jenis_kredit.Text & "') AS jeniskredit2", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbjenis_kredit.Text = rd.Item("jeniskredit2")
        Catch ex As Exception
            cmbjenis_kredit.Text = ""
        End Try
        rd.Close()
    End Sub
    Sub carisistembunga()
        cd = New MySqlCommand("SELECT cari_combo_komponen('21','" & tkode_sistem_bunga.Text & "') AS sistembunga", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbsistem_bunga.Text = rd.Item("sistembunga")
        Catch ex As Exception
            cmbsistem_bunga.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carisistemangsuran()
        cd = New MySqlCommand("SELECT cari_combo_komponen('22','" & tkode_sistem_angsuran.Text & "') AS sistemangsuran", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbsistem_angsuran.Text = rd.Item("sistemangsuran")
        Catch ex As Exception
            cmbsistem_angsuran.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carigolongandebitur()
        cd = New MySqlCommand("SELECT cari_combo_komponen('40','" & tkode_golongan_debitur.Text & "') AS golongandebitur", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbgolongan_debitur.Text = rd.Item("golongandebitur")
        Catch ex As Exception
            cmbgolongan_debitur.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carijenispenggunaan()
        cd = New MySqlCommand("SELECT cari_combo_komponen('41','" & tkode_jenis_penggunaan.Text & "') AS jenispenggunaan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbjenis_penggunaan.Text = rd.Item("jenispenggunaan")
        Catch ex As Exception
            cmbjenis_penggunaan.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carisektorekonomi()
        cd = New MySqlCommand("SELECT cari_combo_komponen('39','" & tkode_sektor_ekonomi.Text & "') AS sektorekonomi", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbsektor_ekonomi.Text = rd.Item("sektorekonomi")
        Catch ex As Exception
            cmbsektor_ekonomi.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carijenisusaha()
        Select Case tkode_jenis_usaha.Text
            Case "1"
                cmbjenis_usaha.Text = "1 : MIKRO"
            Case "2"
                cmbjenis_usaha.Text = "2 : KECIL"
            Case "3"
                cmbjenis_usaha.Text = "3 : MENENGAH"
            Case "4"
                cmbjenis_usaha.Text = "4 : SELAIN USAHA MICRO, KECIL DAN MENENGAH"
            Case Else
                cmbjenis_usaha.Text = ""
        End Select
    End Sub

    Sub carijenisagunan()
        cd = New MySqlCommand("SELECT text AS jenisagunan FROM v_combo_komponen WHERE combo_komponen IN ('43','50') AND combo_kode='" & tkode_jenis_agunan.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbjenis_agunan.Text = rd.Item("jenisagunan")
        Catch ex As Exception
            cmbjenis_agunan.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carisumberdana()
        cd = New MySqlCommand("SELECT cari_combo_komponen('78','" & tkode_sumber_dana_angs.Text & "') AS sumberdana", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbsumber_dana_angs.Text = rd.Item("sumberdana")
        Catch ex As Exception
            cmbsumber_dana_angs.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub text_selected()
        Dim data(99), datakel(99) As String
        If Len(cmbskim_kredit.Text) > 0 Then
            data(0) = " temp_kode_produk='" + cmbskim_kredit.Text.ToString.Split(" : ")(0) + "'"
            datakel(0) = " (Skim Kredit : " + Microsoft.VisualBasic.Right(cmbskim_kredit.Text, Len(cmbskim_kredit.Text) - Len(cmbskim_kredit.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(0) = ""
            datakel(0) = ""
        End If

        If Len(cmbjenis_kredit.Text) > 0 Then
            data(1) = " temp_jenis_kredit='" + cmbjenis_kredit.Text.ToString.Split(" : ")(0) + "'"
            datakel(1) = " (Jenis Kredit : " + Microsoft.VisualBasic.Right(cmbjenis_kredit.Text, Len(cmbjenis_kredit.Text) - Len(cmbjenis_kredit.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(1) = ""
            datakel(1) = ""
        End If

        If tjkw.Text <> 0 Then
            data(2) = " temp_jangka_waktu='" + Format(tjkw.Text, "General Number") + "'"
            datakel(2) = " (Jangka Waktu : " + tjkw.Text + ")"
        Else
            data(2) = ""
            datakel(2) = ""
        End If

        If tsuku_bunga.Text <> "0,000" Then
            data(3) = " temp_suku_bunga='" + tsuku_bunga.Text + "'"
            datakel(3) = " (Suku Bunga : " + tsuku_bunga.Text + ")"
        Else
            data(3) = ""
            datakel(3) = ""
        End If

        If Len(cmbsistem_bunga.Text) > 0 Then
            data(4) = " temp_sistem_bunga='" + cmbsistem_bunga.Text.ToString.Split(" : ")(0) + "'"
            datakel(4) = " (Sistem Bunga : " + Microsoft.VisualBasic.Right(cmbsistem_bunga.Text, Len(cmbsistem_bunga.Text) - Len(cmbsistem_bunga.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(4) = ""
            datakel(4) = ""
        End If

        If Len(cmbsistem_angsuran.Text) > 0 Then
            data(5) = " temp_sistem_angsuran='" + cmbsistem_angsuran.Text.ToString.Split(" : ")(0) + "'"
            datakel(5) = " (Sistem Angsuran : " + Microsoft.VisualBasic.Right(cmbsistem_angsuran.Text, Len(cmbsistem_angsuran.Text) - Len(cmbsistem_angsuran.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(5) = ""
            datakel(5) = ""
        End If

        If Val(Format(tplafon1.Text, "General Number")) <> 0 Or Val(Format(tplafon2.Text, "General Number")) <> 0 Then
            data(6) = "  (temp_plafon_induk BETWEEN '" + Format(tplafon1.Text, "General Number") + "' AND '" + Format(tplafon2.Text, "General Number") + "')"
            datakel(6) = " (Plafon Induk : " + tplafon1.Text + " sd " + tplafon2.Text + ")"
        Else
            data(6) = ""
            datakel(6) = ""
        End If

        If Len(cmbgolongan_debitur.Text) > 0 Then
            If cmbgolongan_debitur.Text.ToString.Split(" : ")(0) = "--" Then
                data(7) = " temp_golongan_debitur=''"
                datakel(7) = " (golongan_debitur : )"
            Else
                data(7) = " temp_golongan_debitur='" + cmbgolongan_debitur.Text.ToString.Split(" : ")(0) + "'"
                datakel(7) = " (golongan_debitur : " + Microsoft.VisualBasic.Right(cmbgolongan_debitur.Text, Len(cmbgolongan_debitur.Text) - Len(cmbgolongan_debitur.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If

        Else
            data(7) = ""
            datakel(7) = ""
        End If

        If Len(cmbjenis_penggunaan.Text) > 0 Then
            If cmbjenis_penggunaan.Text.ToString.Split(" : ")(0) = "--" Then
                data(8) = " temp_jenis_penggunaan=''"
                datakel(8) = " (Jenis Penggunaan : )"
            Else
                data(8) = " temp_jenis_penggunaan='" + cmbjenis_penggunaan.Text.ToString.Split(" : ")(0) + "'"
                datakel(8) = " (Jenis Penggunaan : " + Microsoft.VisualBasic.Right(cmbjenis_penggunaan.Text, Len(cmbjenis_penggunaan.Text) - Len(cmbjenis_penggunaan.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(8) = ""
            datakel(8) = ""
        End If

        If Len(cmbsektor_ekonomi.Text) > 0 Then
            If cmbsektor_ekonomi.Text.ToString.Split(" : ")(0) = "--" Then
                data(9) = " temp_sektor_ekonomi=''"
                datakel(9) = " (Sektor Ekonomi : )"
            Else
                data(9) = " temp_sektor_ekonomi='" + cmbsektor_ekonomi.Text.ToString.Split(" : ")(0) + "'"
                datakel(9) = " (Sektor Ekonomi : " + Microsoft.VisualBasic.Right(cmbsektor_ekonomi.Text, Len(cmbsektor_ekonomi.Text) - Len(cmbsektor_ekonomi.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(9) = ""
            datakel(9) = ""
        End If

        If Len(cmbjenis_usaha.Text) > 0 Then
            data(10) = " temp_jenis_usaha='" + cmbjenis_usaha.Text.ToString.Split(" : ")(0) + "'"
            datakel(10) = " (Jenis Usaha : " + Microsoft.VisualBasic.Right(cmbjenis_usaha.Text, Len(cmbjenis_usaha.Text) - Len(cmbjenis_usaha.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(10) = ""
            datakel(10) = ""
        End If

        If Len(cmbjenis_agunan.Text) > 0 Then
            data(11) = " temp_agunan like '%" + cmbjenis_agunan.Text.ToString.Split(" : ")(0) + "%'"
            datakel(11) = " (Jenis Agunan : " + Microsoft.VisualBasic.Right(cmbjenis_agunan.Text, Len(cmbjenis_agunan.Text) - Len(cmbjenis_agunan.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(11) = ""
            datakel(11) = ""
        End If

        If Len(cmbsumber_dana_angs.Text) > 0 Then
            If cmbsumber_dana_angs.Text.ToString.Split(" : ")(0) = "--" Then
                data(12) = " temp_sumber_dana=''"
                datakel(12) = " (Sumber Dana Angs : )"
            Else
                data(12) = " temp_sumber_dana='" + cmbsumber_dana_angs.Text.ToString.Split(" : ")(0) + "'"
                datakel(12) = " (Sumber Dana Angs : " + Microsoft.VisualBasic.Right(cmbsumber_dana_angs.Text, Len(cmbsumber_dana_angs.Text) - Len(cmbsumber_dana_angs.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(12) = ""
            datakel(12) = ""
        End If

        If Len(cmbkolektor.Text) > 0 Then
            If cmbkolektor.Text.ToString.Split(" : ")(0) = "--" Then
                data(13) = " temp_kolektor=''"
                datakel(13) = " (Kolektor : )"
            Else
                data(13) = " temp_kolektor='" + cmbkolektor.Text.ToString.Split(" : ")(0) + "'"
                datakel(13) = " (Kolektor : " + Microsoft.VisualBasic.Right(cmbkolektor.Text, Len(cmbkolektor.Text) - Len(cmbkolektor.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(13) = ""
            datakel(13) = ""
        End If

        If Len(cmbinstansi.Text) > 0 Then
            If cmbinstansi.Text.ToString.Split(" : ")(0) = "--" Then
                data(14) = " temp_instansi=''"
                datakel(14) = " (Instansi : )"
            Else
                data(14) = " temp_instansi='" + cmbinstansi.Text.ToString.Split(" : ")(0) + "'"
                datakel(14) = " (Instansi : " + Microsoft.VisualBasic.Right(cmbinstansi.Text, Len(cmbinstansi.Text) - Len(cmbinstansi.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(14) = ""
            datakel(14) = ""
        End If

        If Len(cmbwilayah.Text) > 0 Then
            If cmbwilayah.Text.ToString.Split(" : ")(0) = "--" Then
                data(15) = " temp_wilayah=''"
                datakel(15) = " (Wilayah : )"
            Else
                data(15) = " temp_wilayah='" + cmbwilayah.Text.ToString.Split(" : ")(0) + "'"
                datakel(15) = " (Wilayah : " + Microsoft.VisualBasic.Right(cmbwilayah.Text, Len(cmbwilayah.Text) - Len(cmbwilayah.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(15) = ""
            datakel(15) = ""
        End If

        If Len(tkecamatan.Text) > 0 Then
            data(16) = " temp_kecamatan LIKE '%" + tkecamatan.Text + "%'"
            datakel(16) = " (Kecamatan : " + tkecamatan.Text + ")"
        Else
            data(16) = ""
            datakel(16) = ""
        End If

        If Len(tkelurahan.Text) > 0 Then
            data(17) = " temp_kelurahan LIKE '%" + tkelurahan.Text + "%'"
            datakel(17) = " (Kelurahan : " + tkelurahan.Text + ")"
        Else
            data(17) = ""
            datakel(17) = ""
        End If

        If Len(cmbketerkaitan.Text) > 0 Then
            data(18) = " temp_keterkaitan='" + cmbketerkaitan.Text.ToString.Split(" : ")(0) + "'"
            datakel(18) = " (Keterkaitan : " + Microsoft.VisualBasic.Right(cmbketerkaitan.Text, Len(cmbketerkaitan.Text) - Len(cmbketerkaitan.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(18) = ""
            datakel(18) = ""
        End If

        If Len(cmbjenis_kelamin.Text) > 0 Then
            data(19) = " temp_jenis_kelamin='" + cmbjenis_kelamin.Text.ToString.Split(" : ")(0) + "'"
            datakel(19) = " (Jenis Kelamin : " + Microsoft.VisualBasic.Right(cmbjenis_kelamin.Text, Len(cmbjenis_kelamin.Text) - Len(cmbjenis_kelamin.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(19) = ""
            datakel(19) = ""
        End If

        Dim bakidebet As String = ""
        If Val(Format(tbaki_debet1.Text, "General Number")) <> 0 Or Val(Format(tbaki_debet2.Text, "General Number")) <> 0 Then
            bakidebet = " (temp_baki_debet between '" + Format(tbaki_debet1.Text, "General Number") + "' AND '" + Format(tbaki_debet2.Text, "General Number") + "')"
            datakel(20) = " (bakidebet : " + tbaki_debet1.Text + " sd " + tbaki_debet2.Text + ")"
        Else
            datakel(20) = ""
        End If

        If Len(cmbkolektibilitas.Text) > 0 Then
            data(21) = " temp_kolek='" + cmbkolektibilitas.Text.ToString.Split(" : ")(0) + "'"
            datakel(21) = " (Kolektibilitas : " + cmbkolektibilitas.Text + ")"
        Else
            data(21) = ""
            datakel(21) = ""
        End If

        If Len(cmbmarketing.Text) > 0 Then
            If cmbmarketing.Text.ToString.Split(" : ")(0) = "--" Then
                data(22) = " temp_marketing=''"
                datakel(22) = " (Marketing : )"
            Else
                data(22) = " temp_marketing='" + cmbmarketing.Text.ToString.Split(" : ")(0) + "'"
                datakel(22) = " (Marketing : " + Microsoft.VisualBasic.Right(cmbmarketing.Text, Len(cmbmarketing.Text) - Len(cmbmarketing.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(22) = ""
            datakel(22) = ""
        End If

        Dim gabung As String = ""
        For i = 0 To 22
            If Len(data(i)) > 0 Then
                gabung = gabung + " AND" + data(i)
            End If
        Next i

        Dim kelompok As String = ""
        For ii = 0 To 22
            If Len(datakel(ii)) > 0 Then
                If Len(kelompok) > 0 Then
                    kelompok = kelompok + " | " + datakel(ii)
                Else
                    kelompok = kelompok + datakel(ii)
                End If
            End If
        Next ii

        Dim urutkan As String = ""
        Select Case cmburutkan_data.Text.ToString.Split(" :")(0)
            Case "01"
                urutkan = " temp_no_rekening "
            Case "02"
                urutkan = " temp_no_alternatif "
            Case "03"
                urutkan = " temp_nama_nasabah, temp_no_rekening "
            Case "04"
                urutkan = " temp_nama_nasabah, temp_no_alternatif "
            Case "05"
                urutkan = " temp_waktu_pencairan "
            Case "06"
                urutkan = " temp_tanggal_jt "
            Case "07"
                urutkan = " temp_plafon_induk "
            Case "08"
                urutkan = " temp_baki_debet "
        End Select

        Dim limit As String = ""
        If Val(Format(tlimit.Text, "General Number")) <> 0 Then
            limit = " LIMIT 0," + Format(tlimit.Text, "General Number")
        End If


        cd = New MySqlCommand("DELETE FROM temp_nominatif_kredit WHERE temp_username='" & MDIParent1.username.Text & "'", koneksi)
        cd.ExecuteNonQuery()

        da = New MySqlDataAdapter("CALL cek_nominatif_kredit('" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & " 23:59:59')", koneksi)
        dt = New DataTable
        da.Fill(dt)

        For i As Integer = 0 To dt.Rows.Count - 1
            '.Items.Add(dt.Rows(i)("rek_tab_no_rekening")) '0
            cd = New MySqlCommand("INSERT INTO temp_nominatif_kredit VALUES ('" & dt.Rows(i)("rek_kre_no_rekening") & "', '" & dt.Rows(i)("rek_kre_no_alternatif") & "', '" & dt.Rows(i)("rek_kre_kode_produk") & "', '" & dt.Rows(i)("rek_kre_jenis_angsuran") & "', '" & dt.Rows(i)("rek_kre_jangka_waktu") & "', '" & Format(dt.Rows(i)("rek_kre_tanggal_jt"), "yyyy-MM-dd") & "', '" & dt.Rows(i)("rek_kre_sistem_bunga") & "', '" & dt.Rows(i)("rek_kre_suku_bunga").Replace(".", ".") & "', '" & dt.Rows(i)("rek_kre_plafon_induk") & "', '" & dt.Rows(i)("rek_kre_status") & "', '" & Format(dt.Rows(i)("pencairan_tanggal"), "yyyy-MM-dd") & "', '" & dt.Rows(i)("kredit_jenis_kredit") & "', '" & dt.Rows(i)("pelengkap_labulgolongan_debitur") & "', '" & dt.Rows(i)("pelengkap_labuljenis_penggunaan") & "', '" & dt.Rows(i)("pelengkap_labulsektor_ekonomi") & "', '" & dt.Rows(i)("pelengkap_labuljenis_usaha") & "', '" & dt.Rows(i)("pelengkap_labulsumber_dana") & "', '" & dt.Rows(i)("pelengkap_kolektor") & "', '" & dt.Rows(i)("pelengkap_marketing") & "', '" & dt.Rows(i)("pelengkap_instansi") & "', '" & dt.Rows(i)("pelengkap_wilayah") & "', '" & dt.Rows(i)("agunan") & "', '" & dt.Rows(i)("nasabah_kecamatan") & "', '" & dt.Rows(i)("nasabah_kelurahan") & "', '" & dt.Rows(i)("nasabah_keterkaitan") & "', '" & dt.Rows(i)("nasabah_jenis_kelamin") & "', '" & dt.Rows(i)("nasabah_nama1") & "', '" & dt.Rows(i)("alamat") & "', '" & Format(dt.Rows(i)("pencairan_waktu"), "yyyy-MM-dd HH:mm:ss") & "', '" & dt.Rows(i)("bakidebet") & "', '" & dt.Rows(i)("tgk_pokok") & "', '" & dt.Rows(i)("frek_pokok").Replace(".", ".") & "', '" & dt.Rows(i)("tgk_bunga") & "', '" & dt.Rows(i)("frek_bunga").Replace(".", ".") & "', '" & dt.Rows(i)("jml_hari") & "', '" & dt.Rows(i)("kolek") & "', '" & MDIParent1.username.Text & "')", koneksi)
            cd.ExecuteNonQuery()

        Next



        '(no rekening), (nama nasabah), (alamat), (realisasi), (jkw), (jatuh tempo), (sistem bunga), (suku bunga), (plafond), (baki debet), pokok, bunga, hari, kol
        TextBox1.Text = "SELECT * FROM temp_nominatif_kredit WHERE temp_username = '" + MDIParent1.username.Text + "'" + gabung + " ORDER BY" + urutkan + cmbby.Text + limit

        TextBox2.Text = "Pengelompokan = " + kelompok.ToString
    End Sub
    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        text_selected()
        laporan_nominatif_kredit.ShowDialog()
    End Sub
   
End Class