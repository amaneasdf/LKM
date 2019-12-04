Imports MySql.Data.MySqlClient
Public Class data_pelengkap
    Dim data_ke(99), data_edit(99), array(99) As String

    Private Sub data_pelengkap_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub data_pelengkap_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Sub data_pelengkap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        'tno_rekening1.Text = "01.00001"
        combo()
        Me.ResizeRedraw = True
        caridatakredit()
        caridatapelengkap()
    End Sub

    Private Sub tkode_jenis_fasilitas_LostFocus(sender As Object, e As EventArgs) Handles tkode_jenis_fasilitas.LostFocus
        carijenisfasilitas()
    End Sub

    Private Sub cmbjenis_fasilitas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjenis_fasilitas.SelectedIndexChanged
        tkode_jenis_fasilitas.Text = cmbjenis_fasilitas.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_sifat_kredit_LostFocus(sender As Object, e As EventArgs) Handles tkode_sifat_kredit.LostFocus
        carisifatkredit1()
    End Sub

    Private Sub cmb_sifat_kredit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_sifat_kredit.SelectedIndexChanged
        tkode_sifat_kredit.Text = cmb_sifat_kredit.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_golongan_kredit_LostFocus(sender As Object, e As EventArgs) Handles tkode_golongan_kredit.LostFocus
        carigolongankredit()
    End Sub

    Private Sub cmbgolongan_kredit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbgolongan_kredit.SelectedIndexChanged
        tkode_golongan_kredit.Text = cmbgolongan_kredit.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_jenis_penggunaan_LostFocus(sender As Object, e As EventArgs) Handles tkode_jenis_penggunaan.LostFocus
        carijenispenggunaan1()
    End Sub

    Private Sub cmbjenis_penggunaan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjenis_penggunaan.SelectedIndexChanged
        tkode_jenis_penggunaan.Text = cmbjenis_penggunaan.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_orientasi_penggunaan_LostFocus(sender As Object, e As EventArgs) Handles tkode_orientasi_penggunaan.LostFocus
        With cmborientasi_penggunaan
            Select Case tkode_orientasi_penggunaan.Text
                Case "1"
                    .Text = "1 : EXPORT"
                Case "2"
                    .Text = "2 : IMPORT"
                Case "3"
                    .Text = "3 : LAINNYA"
                Case Else
                    tkode_orientasi_penggunaan.Clear()
                    .Text = ""
            End Select
        End With
    End Sub

    Private Sub cmborientasi_penggunaan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmborientasi_penggunaan.SelectedIndexChanged
        tkode_orientasi_penggunaan.Text = cmborientasi_penggunaan.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_sifat_kredit2_LostFocus(sender As Object, e As EventArgs) Handles tkode_sifat_kredit2.LostFocus
        carisifatkredit2()
    End Sub

    Private Sub cmbsifat_kredit2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsifat_kredit2.SelectedIndexChanged
        tkode_sifat_kredit2.Text = cmbsifat_kredit2.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_golongan_debitur_LostFocus(sender As Object, e As EventArgs) Handles tkode_golongan_debitur.LostFocus
        carigolongandebitur()
    End Sub

    Private Sub cmbgolongan_debitur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbgolongan_debitur.SelectedIndexChanged
        tkode_golongan_debitur.Text = cmbgolongan_debitur.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_jenis_penggunaan2_LostFocus(sender As Object, e As EventArgs) Handles tkode_jenis_penggunaan2.LostFocus
        carijenispenggunaan2()
    End Sub

    Private Sub cmbjenis_penggunaan2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjenis_penggunaan2.SelectedIndexChanged
        tkode_jenis_penggunaan2.Text = cmbjenis_penggunaan2.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_sektor_ekonomi_LostFocus(sender As Object, e As EventArgs) Handles tkode_sektor_ekonomi.LostFocus
        carisektorekonomi()
    End Sub

    Private Sub cmbsektor_ekonomi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsektor_ekonomi.SelectedIndexChanged
        tkode_sektor_ekonomi.Text = cmbsektor_ekonomi.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_jenis_usaha_LostFocus(sender As Object, e As EventArgs) Handles tkode_jenis_usaha.LostFocus
        With cmb_jenis_usaha
            Select Case tkode_jenis_usaha.Text
                Case "1"
                    .Text = "1 : MIKRO"
                Case "2"
                    .Text = "2 : KECIL"
                Case "3"
                    .Text = "3 : MENENGAH"
                Case "4"
                    .Text = "4 : SELAIN USAHA MICRO, KECIL DAN MENENGAH"
                Case Else
                    tkode_jenis_usaha.Clear()
                    .Text = ""
            End Select
        End With
    End Sub

    Private Sub cmb_jenis_usaha_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_jenis_usaha.SelectedIndexChanged
        tkode_jenis_usaha.Text = cmb_jenis_usaha.Text.ToString.Split(" :")(0)
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

    Private Sub cmbwilayah_GotFocus(sender As Object, e As EventArgs) Handles cmbwilayah.GotFocus, tkode_wilayah.GotFocus, cmbinstansi.GotFocus, tkode_instansi.GotFocus, cmbkolektor.GotFocus, tkode_kolektor.GotFocus, cmbmarketing.GotFocus, tkode_marketing.GotFocus, cmbsumberdana.GotFocus, cmb_jenis_usaha.GotFocus, tkode_jenis_usaha.GotFocus, cmbsektor_ekonomi.GotFocus, tkode_sektor_ekonomi.GotFocus, cmbjenis_penggunaan2.GotFocus, tkode_jenis_penggunaan2.GotFocus, cmbgolongan_debitur.GotFocus, tkode_golongan_debitur.GotFocus, cmbsifat_kredit2.GotFocus, tkode_sifat_kredit2.GotFocus, tkode_sebab_macet.GotFocus, tsebab_macet.GotFocus, cmbsebab_macet.GotFocus, cmborientasi_penggunaan.GotFocus, tkode_orientasi_penggunaan.GotFocus, cmbjenis_penggunaan.GotFocus, tkode_jenis_penggunaan.GotFocus, cmbgolongan_kredit.GotFocus, tkode_golongan_kredit.GotFocus, cmb_sifat_kredit.GotFocus, tkode_sifat_kredit.GotFocus, cmbjenis_fasilitas.GotFocus, tkode_jenis_fasilitas.GotFocus, tjkw.GotFocus, tno_dokumen.GotFocus, tcatatan.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbwilayah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbwilayah.KeyPress, cmbinstansi.KeyPress, cmbkolektor.KeyPress, cmbmarketing.KeyPress, cmbsumberdana.KeyPress, cmb_jenis_usaha.KeyPress, cmbsektor_ekonomi.KeyPress, cmbjenis_penggunaan2.KeyPress, cmbgolongan_debitur.KeyPress, cmbsifat_kredit2.KeyPress, cmbsebab_macet.KeyPress, cmborientasi_penggunaan.KeyPress, cmbjenis_penggunaan.KeyPress, cmbgolongan_kredit.KeyPress, cmb_sifat_kredit.KeyPress, cmbjenis_fasilitas.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbwilayah_LostFocus(sender As Object, e As EventArgs) Handles cmbwilayah.LostFocus, tkode_wilayah.LostFocus, tkode_instansi.LostFocus, cmbkolektor.LostFocus, tkode_kolektor.LostFocus, cmbmarketing.LostFocus, tkode_marketing.LostFocus, cmbsumberdana.LostFocus, cmb_jenis_usaha.LostFocus, tkode_jenis_usaha.LostFocus, cmbsektor_ekonomi.LostFocus, tkode_sektor_ekonomi.LostFocus, cmbjenis_penggunaan2.LostFocus, tkode_jenis_penggunaan2.LostFocus, cmbgolongan_debitur.LostFocus, tkode_golongan_debitur.LostFocus, cmbsifat_kredit2.LostFocus, tkode_sifat_kredit2.LostFocus, tsebab_macet.LostFocus, cmbsebab_macet.LostFocus, cmborientasi_penggunaan.LostFocus, tkode_orientasi_penggunaan.LostFocus, cmbjenis_penggunaan.LostFocus, tkode_jenis_penggunaan.LostFocus, tkode_jenis_penggunaan.LostFocus, cmbgolongan_kredit.LostFocus, tkode_golongan_kredit.LostFocus, cmb_sifat_kredit.LostFocus, tkode_sifat_kredit.LostFocus, cmbjenis_fasilitas.LostFocus, tkode_jenis_fasilitas.LostFocus, tjkw.LostFocus, tno_dokumen.LostFocus, cmbinstansi.LostFocus, tcatatan.LostFocus, tkode_sebab_macet.LostFocus

        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub cmbwilayah_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbwilayah.SelectedIndexChanged
        tkode_wilayah.Text = cmbwilayah.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub data_pelengkap_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub
    Sub combo()
        cd = New MySqlCommand("CALL isi_combo('36')", koneksi)
        rd = cd.ExecuteReader
        With cmbjenis_fasilitas.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('34')", koneksi)
        rd = cd.ExecuteReader
        With cmb_sifat_kredit.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('33')", koneksi)
        rd = cd.ExecuteReader
        With cmbgolongan_kredit.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('35')", koneksi)
        rd = cd.ExecuteReader
        With cmbjenis_penggunaan.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        With cmborientasi_penggunaan.Items
            .Clear()
            .Add("1 : EXPORT")
            .Add("2 : IMPORT")
            .Add("3 : LAINNYA")
        End With

        cd = New MySqlCommand("CALL isi_combo('82')", koneksi)
        rd = cd.ExecuteReader
        With cmbsebab_macet.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('38')", koneksi)
        rd = cd.ExecuteReader
        With cmbsifat_kredit2.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('40')", koneksi)
        rd = cd.ExecuteReader
        With cmbgolongan_debitur.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('41')", koneksi)
        rd = cd.ExecuteReader
        With cmbjenis_penggunaan2.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('39')", koneksi)
        rd = cd.ExecuteReader
        With cmbsektor_ekonomi.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        With cmb_jenis_usaha.Items
            .Clear()
            .Add("1 : MIKRO")
            .Add("2 : KECIL")
            .Add("3 : MENENGAH")
            .Add("4 : SELAIN USAHA MICRO, KECIL DAN MENENGAH")
        End With

        cd = New MySqlCommand("CALL isi_combo('78')", koneksi)
        rd = cd.ExecuteReader
        With cmbsumberdana.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', kolektor_kode,UPPER(kolektor_nama)) AS kolektor FROM data_kolektor", koneksi)
        rd = cd.ExecuteReader
        With cmbkolektor.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("kolektor"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', marketing_kode,UPPER(marketing_nama)) AS marketing FROM data_marketing", koneksi)
        rd = cd.ExecuteReader
        With cmbmarketing.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("marketing"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', instansi_kode,UPPER(instansi_nama)) AS instansi FROM data_instansi", koneksi)
        rd = cd.ExecuteReader
        With cmbinstansi.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("instansi"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT_WS (' , ',CONCAT_WS (' : ', wilayah_kode,UPPER(wilayah_nama_kecamatan)),UPPER(wilayah_nama_desa)) AS WILAYAH FROM data_wilayah", koneksi)
        rd = cd.ExecuteReader
        With cmbwilayah.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("wilayah"))
            End While
        End With
        rd.Close()
    End Sub

    Sub carijenisfasilitas()
        cd = New MySqlCommand("SELECT cari_combo_komponen('36','" & tkode_jenis_fasilitas.Text & "') AS jenis_fasilitas", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbjenis_fasilitas.Text = rd.Item("jenis_fasilitas")
        Catch ex As Exception
            tkode_jenis_fasilitas.Clear()
            cmbjenis_fasilitas.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carisifatkredit1()
        cd = New MySqlCommand("SELECT cari_combo_komponen('34','" & tkode_sifat_kredit.Text & "') AS sifatkredit", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmb_sifat_kredit.Text = rd.Item("sifatkredit")
        Catch ex As Exception
            tkode_sifat_kredit.Clear()
            cmb_sifat_kredit.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carigolongankredit()
        cd = New MySqlCommand("SELECT cari_combo_komponen('33','" & tkode_golongan_kredit.Text & "') AS golongankredit", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbgolongan_kredit.Text = rd.Item("golongankredit")
        Catch ex As Exception
            tkode_golongan_kredit.Clear()
            cmbgolongan_kredit.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carijenispenggunaan1()
        cd = New MySqlCommand("SELECT cari_combo_komponen('35','" & tkode_jenis_penggunaan.Text & "') AS jenispenggunaan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbjenis_penggunaan.Text = rd.Item("jenispenggunaan")
        Catch ex As Exception
            tkode_jenis_penggunaan.Clear()
            cmbjenis_penggunaan.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carisifatkredit2()
        cd = New MySqlCommand("SELECT cari_combo_komponen('38','" & tkode_sifat_kredit2.Text & "') AS sifatkredit2", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbsifat_kredit2.Text = rd.Item("sifatkredit2")
        Catch ex As Exception
            tkode_sifat_kredit2.Clear()
            cmbsifat_kredit2.Text = ""
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
            tkode_golongan_debitur.Clear()
            cmbgolongan_debitur.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carijenispenggunaan2()
        cd = New MySqlCommand("SELECT cari_combo_komponen('41','" & tkode_jenis_penggunaan2.Text & "') AS jenispenggunaan2", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbjenis_penggunaan2.Text = rd.Item("jenispenggunaan2")
        Catch ex As Exception
            tkode_jenis_penggunaan2.Clear()
            cmbjenis_penggunaan2.Text = ""
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
            tkode_sektor_ekonomi.Clear()
            cmbsektor_ekonomi.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carisebabmacet()
        cd = New MySqlCommand("SELECT cari_combo_komponen('82','" & tkode_sebab_macet.Text & "') AS sebabmacet", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbsebab_macet.Text = rd.Item("sebabmacet")
        Catch ex As Exception
            tkode_sebab_macet.Clear()
            cmbsebab_macet.Text = ""
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

    Sub caridatakredit()
        cd = New MySqlCommand("SELECT rek_kre_no_alternatif, rek_kre_jenis_angsuran, rek_kre_jangka_waktu, rek_kre_tanggal_jt FROM data_kredit_rekening WHERE rek_kre_no_rekening='" & tno_rekening1.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tno_rekening2.Text = rd.Item("rek_kre_no_alternatif")
        tjkw.Text = FormatNumber(rd.Item("rek_kre_jangka_waktu"), 0)

        Select Case rd.Item("rek_kre_jenis_angsuran")
            Case "1"
                Label8.Text = "Hari"
            Case "2"
                Label8.Text = "Minggu"
            Case "3"
                Label8.Text = "Bulan"
            Case Else
                Label8.Text = ""
        End Select

        DateTimePicker1.Value = rd.Item("rek_kre_tanggal_jt")
        rd.Close()
    End Sub
    Sub caridatapelengkap()
        cd = New MySqlCommand("SELECT * FROM data_kredit_pelengkap WHERE pelengkap_no_rekening='" & tno_rekening1.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            array(0) = rd.Item("pelengkap_no_rekening")
            tno_dokumen.Text = rd.Item("pelengkap_nomor_dokumen")
            tkode_jenis_fasilitas.Text = rd.Item("pelengkap_sidjenis_fasilitas")
            tkode_sifat_kredit.Text = rd.Item("pelengkap_sidsifat_kredit")
            tkode_golongan_kredit.Text = rd.Item("pelengkap_sidgolongan_kredit")
            tkode_jenis_penggunaan.Text = rd.Item("pelengkap_sidjenis_penggunaan")
            tkode_orientasi_penggunaan.Text = rd.Item("pelengkap_sidorientasi_penggunaan")
            With cmborientasi_penggunaan
                Select Case tkode_orientasi_penggunaan.Text
                    Case "1"
                        .Text = "1 : EXPORT"
                    Case "2"
                        .Text = "2 : IMPORT"
                    Case "3"
                        .Text = "3 : LAINNYA"
                    Case Else
                        tkode_orientasi_penggunaan.Clear()
                        .Text = ""
                End Select
            End With
            tkode_sebab_macet.Text = rd.Item("pelengkap_sidsebab_macet")
            tsebab_macet.Text = rd.Item("pelengkap_sidketerangan_macet")
            tkode_sifat_kredit2.Text = rd.Item("pelengkap_labulsifat_kredit")
            tkode_golongan_debitur.Text = rd.Item("pelengkap_labulgolongan_debitur")
            tkode_jenis_penggunaan2.Text = rd.Item("pelengkap_labuljenis_penggunaan")
            tkode_sektor_ekonomi.Text = rd.Item("pelengkap_labulsektor_ekonomi")
            tkode_jenis_usaha.Text = rd.Item("pelengkap_labuljenis_usaha")
            With cmb_jenis_usaha
                Select Case tkode_jenis_usaha.Text
                    Case "1"
                        .Text = "1 : MIKRO"
                    Case "2"
                        .Text = "2 : KECIL"
                    Case "3"
                        .Text = "3 : MENENGAH"
                    Case "4"
                        .Text = "4 : SELAIN USAHA MICRO, KECIL DAN MENENGAH"
                    Case Else
                        tkode_jenis_usaha.Clear()
                        .Text = ""
                End Select
            End With

            cmbsumberdana.Text = rd.Item("pelengkap_labulsumber_dana")
            tkode_kolektor.Text = rd.Item("pelengkap_kolektor")
            tkode_marketing.Text = rd.Item("pelengkap_marketing")
            tkode_instansi.Text = rd.Item("pelengkap_instansi")
            tkode_wilayah.Text = rd.Item("pelengkap_wilayah")
            tcatatan.Text = rd.Item("pelengkap_catatan")
            Label30.Text = Format(rd.Item("pelengkap_update_waktu"), "dd MMM yyyy, HH:mm:ss")
            rd.Close()

            cd = New MySqlCommand("SELECT text FROM v_combo_komponen WHERE combo_komponen='78' AND combo_kode='" & cmbsumberdana.Text & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            cmbsumberdana.Text = rd.Item("text")
            rd.Close()

            carisebabmacet()
            carijenisfasilitas()
            carisifatkredit1()
            carigolongankredit()
            carijenispenggunaan1()
            carisifatkredit2()
            carigolongandebitur()
            carijenispenggunaan2()
            carisektorekonomi()

            carikolektor()
            carimarketing()
            cariinstansi()
            cariwilayah()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        rd.Close()

    End Sub

    Sub kosong()
        def()
    End Sub

    Sub def()
        cd = New MySqlCommand("SELECT komp_default FROM sys_komponen WHERE komp_tag='SIDJenisFasilitas'", koneksi) 'menampilkan defaultnya
        rd = cd.ExecuteReader
        rd.Read()
        tkode_jenis_fasilitas.Text = rd.Item("komp_default")
        rd.Close()
        carijenisfasilitas()

        cd = New MySqlCommand("SELECT komp_default FROM sys_komponen WHERE komp_tag='SIDSifatKredit'", koneksi) 'menampilkan defaultnya
        rd = cd.ExecuteReader
        rd.Read()
        tkode_sifat_kredit.Text = rd.Item("komp_default")
        rd.Close()
        carisifatkredit1()

        cd = New MySqlCommand("SELECT komp_default FROM sys_komponen WHERE komp_tag='SIDGolonganKredit'", koneksi) 'menampilkan defaultnya
        rd = cd.ExecuteReader
        rd.Read()
        tkode_golongan_kredit.Text = rd.Item("komp_default")
        rd.Close()
        carigolongankredit()

        cd = New MySqlCommand("SELECT komp_default FROM sys_komponen WHERE komp_tag='SIDJenisPenggunaan'", koneksi) 'menampilkan defaultnya
        rd = cd.ExecuteReader
        rd.Read()
        tkode_jenis_penggunaan.Text = rd.Item("komp_default")
        rd.Close()
        carijenispenggunaan1()

        cd = New MySqlCommand("SELECT komp_default FROM sys_komponen WHERE komp_tag='BISifatKredit'", koneksi) 'menampilkan defaultnya
        rd = cd.ExecuteReader
        rd.Read()
        tkode_sifat_kredit2.Text = rd.Item("komp_default")
        rd.Close()
        carisifatkredit2()

        cd = New MySqlCommand("SELECT komp_default FROM sys_komponen WHERE komp_tag='BIGolonganDebitur'", koneksi) 'menampilkan defaultnya
        rd = cd.ExecuteReader
        rd.Read()
        tkode_golongan_debitur.Text = rd.Item("komp_default")
        rd.Close()
        carigolongandebitur()

        cd = New MySqlCommand("SELECT komp_default FROM sys_komponen WHERE komp_tag='BIJenisPenggunaan'", koneksi) 'menampilkan defaultnya
        rd = cd.ExecuteReader
        rd.Read()
        tkode_jenis_penggunaan2.Text = rd.Item("komp_default")
        rd.Close()
        carijenispenggunaan2()

        cd = New MySqlCommand("SELECT komp_default FROM sys_komponen WHERE komp_tag='BISektorEkonomi'", koneksi) 'menampilkan defaultnya
        rd = cd.ExecuteReader
        rd.Read()
        tkode_sektor_ekonomi.Text = rd.Item("komp_default")
        rd.Close()
        carisektorekonomi()


    End Sub
    Sub ar()
        data_ke(0) = tno_rekening1.Text
        data_ke(1) = tno_dokumen.Text
        data_ke(2) = tkode_jenis_fasilitas.Text
        data_ke(3) = tkode_sifat_kredit.Text
        data_ke(4) = tkode_golongan_kredit.Text
        data_ke(5) = tkode_jenis_penggunaan.Text
        data_ke(6) = tkode_orientasi_penggunaan.Text
        data_ke(7) = cmbsebab_macet.Text.ToString.Split(" :")(0)
        data_ke(8) = tsebab_macet.Text
        data_ke(9) = tkode_sifat_kredit2.Text
        data_ke(10) = tkode_golongan_debitur.Text
        data_ke(11) = tkode_jenis_penggunaan2.Text
        data_ke(12) = tkode_sektor_ekonomi.Text
        data_ke(13) = tkode_jenis_usaha.Text
        data_ke(14) = cmbsumberdana.Text.ToString.Split(" :")(0)
        data_ke(15) = tkode_kolektor.Text
        data_ke(16) = tkode_marketing.Text
        data_ke(17) = tkode_instansi.Text
        data_ke(18) = tkode_wilayah.Text
        data_ke(19) = tcatatan.Text
        data_ke(20) = MDIParent1.username.Text
        data_ke(21) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        data_ke(22) = MDIParent1.username.Text
        data_ke(23) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")

        data_edit(0) = "pelengkap_no_rekening='" + data_ke(0) + "'"
        data_edit(1) = "pelengkap_nomor_dokumen='" + data_ke(1) + "'"
        data_edit(2) = "pelengkap_sidjenis_fasilitas='" + data_ke(2) + "'"
        data_edit(3) = "pelengkap_sidsifat_kredit='" + data_ke(3) + "'"
        data_edit(4) = "pelengkap_sidgolongan_kredit='" + data_ke(4) + "'"
        data_edit(5) = "pelengkap_sidjenis_penggunaan='" + data_ke(5) + "'"
        data_edit(6) = "pelengkap_sidorientasi_penggunaan='" + data_ke(6) + "'"
        data_edit(7) = "pelengkap_sidsebab_macet='" + data_ke(7) + "'"
        data_edit(8) = "pelengkap_sidketerangan_macet='" + data_ke(8) + "'"
        data_edit(9) = "pelengkap_labulsifat_kredit='" + data_ke(9) + "'"
        data_edit(10) = "pelengkap_labulgolongan_debitur='" + data_ke(10) + "'"
        data_edit(11) = "pelengkap_labuljenis_penggunaan='" + data_ke(11) + "'"
        data_edit(12) = "pelengkap_labulsektor_ekonomi='" + data_ke(12) + "'"
        data_edit(13) = "pelengkap_labuljenis_usaha='" + data_ke(13) + "'"
        data_edit(14) = "pelengkap_labulsumber_dana='" + data_ke(14) + "'"
        data_edit(15) = "pelengkap_kolektor='" + data_ke(15) + "'"
        data_edit(16) = "pelengkap_marketing='" + data_ke(16) + "'"
        data_edit(17) = "pelengkap_instansi='" + data_ke(17) + "'"
        data_edit(18) = "pelengkap_wilayah='" + data_ke(18) + "'"
        data_edit(19) = "pelengkap_catatan='" + data_ke(19) + "'"
        data_edit(20) = "pelengkap_reg_username='" + data_ke(20) + "'"
        data_edit(21) = "pelengkap_reg_waktu='" + data_ke(21) + "'"
        data_edit(22) = "pelengkap_update_username='" + data_ke(22) + "'"
        data_edit(23) = "pelengkap_update_waktu='" + data_ke(23) + "'"

    End Sub

    Sub simpan()
        ar()
        Dim gabung = ""
        For n = 0 To 23
            If n = 0 Then
                gabung += "'" + data_ke(n) + "'"
            Else
                gabung += ",'" + data_ke(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_kredit_pelengkap VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Data Pelengkap (pelengkap_no_rekening : " + data_ke(0) + ")"
        insert_log_user()

        MessageBox.Show("Data Pelengkap berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Sub edit()
        ar()
        Dim gabung = ""
        For n = 1 To 23
            If n = 1 Then
                gabung += data_edit(n)
            ElseIf n = 20 Or n = 21 Then

            Else
                gabung += "," + data_edit(n)
            End If
        Next
        cd = New MySqlCommand("UPDATE data_kredit_pelengkap SET " & gabung & " WHERE " & data_edit(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Data Pelengkap (pelengkap_no_rekening : " + data_ke(0) + ")"
        insert_log_user()

        MessageBox.Show("Data Pelengkap berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        Label30.Text = Format(MDIParent1.DateTimePicker1.Value, "dd MMM yyyy, HH:mm:ss")
        cd = New MySqlCommand("SELECT * FROM data_kredit_pelengkap WHERE pelengkap_no_rekening='" & tno_rekening1.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True Then
            rd.Close()
            edit()
        Else
            rd.Close()
            simpan()
        End If
    End Sub

    Private Sub tkode_orientasi_penggunaan_TextChanged(sender As Object, e As EventArgs) Handles tkode_orientasi_penggunaan.TextChanged

    End Sub

    Private Sub cmbsebab_macet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsebab_macet.SelectedIndexChanged
        tkode_sebab_macet.Text = cmbsebab_macet.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_sebab_macet_lostfocus(sender As Object, e As EventArgs) Handles tkode_sebab_macet.LostFocus

        carisebabmacet()
    End Sub
End Class