Imports MySql.Data.MySqlClient
Public Class cetak_nominatif_bunga_tabungan

    Private Sub cetak_nominatif_bunga_tabungan_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        btnbatal.PerformClick()
    End Sub

    Private Sub cmbjenis_laporan_GotFocus(sender As Object, e As EventArgs) Handles cmbjenis_laporan.GotFocus, tkode_produk.GotFocus, cmbproduk.GotFocus, tlimit.GotFocus, cmbby.GotFocus, cmburutkan_data.GotFocus, cmbjenis_kelamin.GotFocus, cmbketerkaitan.GotFocus, tbunga2.GotFocus, tbunga1.GotFocus, cmbwilayah.GotFocus, tkode_wilayah.GotFocus, cmbinstansi.GotFocus, tkode_instansi.GotFocus, cmbkolektor.GotFocus, tkode_kolektor.GotFocus, cmbmarketing.GotFocus, tkode_marketing.GotFocus, cmbpemilik.GotFocus, tkode_pemilik.GotFocus

        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbjenis_laporan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbjenis_laporan.KeyPress, cmbby.KeyPress, cmburutkan_data.KeyPress, cmbjenis_kelamin.KeyPress, cmbketerkaitan.KeyPress, cmbwilayah.KeyPress, cmbinstansi.KeyPress, cmbkolektor.KeyPress, cmbmarketing.KeyPress, cmbpemilik.KeyPress, cmbproduk.KeyPress

        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbjenis_laporan_LostFocus(sender As Object, e As EventArgs) Handles cmbjenis_laporan.LostFocus, tkode_produk.LostFocus, cmbproduk.LostFocus, tkode_pemilik.LostFocus, tlimit.LostFocus, cmbby.LostFocus, cmburutkan_data.LostFocus, cmbjenis_kelamin.LostFocus, cmbketerkaitan.LostFocus, tbunga2.LostFocus, tbunga1.LostFocus, cmbwilayah.LostFocus, tkode_wilayah.LostFocus, cmbinstansi.LostFocus, tkode_instansi.LostFocus, cmbkolektor.LostFocus, tkode_kolektor.LostFocus, cmbmarketing.LostFocus, tkode_marketing.LostFocus, cmbpemilik.LostFocus

        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub tkode_produk_LostFocus(sender As Object, e As EventArgs) Handles tkode_produk.LostFocus
        carijenisproduk()
    End Sub
    Private Sub cmbproduk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbproduk.SelectedIndexChanged
        tkode_produk.Text = cmbproduk.Text.ToString.Split(" :")(0)
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

    Private Sub tbunga1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbunga1.KeyPress, tbunga2.KeyPress, tlimit.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tsaldo1_TextChanged(sender As Object, e As EventArgs) Handles tbunga1.TextChanged, tbunga2.TextChanged, tlimit.TextChanged
        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub

    Private Sub cetak_nominatif_bunga_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cetak_nominatif_bunga_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()

        'koneksi.Open()
        Me.ResizeRedraw = True
        combo()
        def()
    End Sub

    Private Sub cetak_nominatif_bunga_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Sub combo()
        With cmbjenis_laporan.Items
            .Clear()
            .Add("01 : BUNGA TABUNGAN - [RINCIAN]")
        End With

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', tabungan_kode,UPPER(tabungan_nama_produk)) AS produktabungan FROM data_tabungan_produk WHERE tabungan_status='1'", koneksi)
        rd = cd.ExecuteReader
        With cmbproduk.Items
            .Clear()
            .Add("")
            While rd.Read()
                .Add(rd.Item("produktabungan"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('15')", koneksi)
        rd = cd.ExecuteReader
        With cmbpemilik.Items
            .Clear()
            .Add("")
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
            .Add("-- : Tidak Teridentifikasikan")
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
            .Add("-- : Tidak Teridentifikasikan")
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
            .Add("-- : Tidak Teridentifikasikan")
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
            .Add("-- : Tidak Teridentifikasikan")
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
            .Add("1 : NOMOR REKENING")
            .Add("2 : NOMOR ALTERNATIF")
            .Add("3 : NAMA NASABAH")
            .Add("4 : SALDO AWAL")
            .Add("5 : BUNGA")
            .Add("7 : SALDO AKHIR")
        End With

        With cmbby.Items
            .Clear()
            .Add("ASC")
            .Add("DESC")
        End With

    End Sub

    Sub def()
        cmbjenis_laporan.Text = "01 : BUNGA TABUNGAN - [RINCIAN]"
        cmburutkan_data.Text = "1 : NOMOR REKENING"
        cmbby.Text = "ASC"
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Me.Dispose()
    End Sub

    Sub carijenisproduk()
        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', tabungan_kode,UPPER(tabungan_nama_produk)) AS produktabungan FROM data_tabungan_produk WHERE tabungan_status='1' AND tabungan_kode='" & tkode_produk.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbproduk.Text = rd.Item("produktabungan")
        Catch ex As Exception
            cmbproduk.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub caripemilik()
        cd = New MySqlCommand("SELECT cari_combo_komponen('15','" & tkode_pemilik.Text & "') AS pemilik", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbpemilik.Text = rd.Item("pemilik")
        Catch ex As Exception
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
            cmbinstansi.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub cariwilayah()
        cd = New MySqlCommand("SELECT CONCAT(wilayah_kode, ' : ', wilayah_nama_kecamatan, ', ', wilayah_nama_desa)  AS wilayah FROM data_wilayah WHERE wilayah_kode='" & tkode_wilayah.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbwilayah.Text = rd.Item("wilayah")
        Catch ex As Exception
            cmbwilayah.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub text_selected()
        Dim data(99), datakel(99) As String

        If Len(cmbproduk.Text) > 0 Then
            data(1) = " rek_tab_kode_produk='" + tkode_produk.Text + "'"
            datakel(1) = " (Produk : " + Microsoft.VisualBasic.Right(cmbproduk.Text, Len(cmbproduk.Text) - Len(cmbproduk.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(1) = ""
            datakel(1) = ""
        End If

        

        If Len(cmbpemilik.Text) > 0 Then
            data(2) = " rek_tab_kode_pemilik='" + tkode_pemilik.Text + "'"
            datakel(2) = " (Pemilik : " + Microsoft.VisualBasic.Right(cmbpemilik.Text, Len(cmbpemilik.Text) - Len(cmbpemilik.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(2) = ""
            datakel(2) = ""
        End If

        If Len(cmbkolektor.Text) > 0 Then
            If cmbkolektor.Text.ToString.Split(" :")(0) = "--" Then
                data(3) = " rek_tab_kode_kolektor=''"
                datakel(3) = " (Kolektor : )"
            Else
                data(3) = " rek_tab_kode_kolektor='" + tkode_kolektor.Text + "'"
                datakel(3) = " (Kolektor : " + Microsoft.VisualBasic.Right(cmbkolektor.Text, Len(cmbkolektor.Text) - Len(cmbkolektor.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(3) = ""
            datakel(3) = ""
        End If

        If Len(cmbinstansi.Text) > 0 Then
            If cmbinstansi.Text.ToString.Split(" :")(0) = "--" Then
                data(4) = " rek_tab_kode_instansi=''"
                datakel(4) = " (Instansi : )"
            Else
                data(4) = " rek_tab_kode_instansi='" + tkode_instansi.Text + "'"
                datakel(4) = " (Instansi : " + Microsoft.VisualBasic.Right(cmbinstansi.Text, Len(cmbinstansi.Text) - Len(cmbinstansi.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(4) = ""
            datakel(4) = ""
        End If

        If Len(cmbwilayah.Text) > 0 Then
            If cmbwilayah.Text.ToString.Split(" :")(0) = "--" Then
                data(5) = " rek_tab_kode_wilayah=''"
                datakel(5) = " (Wilayah : )"
            Else
                data(5) = " rek_tab_kode_wilayah='" + tkode_wilayah.Text + "'"
                datakel(5) = " (Wilayah : " + Microsoft.VisualBasic.Right(cmbwilayah.Text, Len(cmbwilayah.Text) - Len(cmbwilayah.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(5) = ""
            datakel(5) = ""
        End If

        If Len(cmbketerkaitan.Text) > 0 Then
            data(6) = " nasabah_keterkaitan='" + cmbketerkaitan.Text.ToString.Split(" :")(0) + "'"
            datakel(6) = " (Keterkaitan : " + Microsoft.VisualBasic.Right(cmbketerkaitan.Text, Len(cmbketerkaitan.Text) - Len(cmbketerkaitan.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(6) = ""
            datakel(6) = ""
        End If

        If Len(cmbjenis_kelamin.Text) > 0 Then
            data(7) = " nasabah_jenis_kelamin='" + cmbjenis_kelamin.Text.ToString.Split(" :")(0) + "'"
            datakel(7) = " (Jenis Kelamin : " + Microsoft.VisualBasic.Right(cmbjenis_kelamin.Text, Len(cmbjenis_kelamin.Text) - Len(cmbjenis_kelamin.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(7) = ""
            datakel(7) = ""
        End If

        If Val(Format(tbunga1.Text, "General Number")) <> 0 Or Val(Format(tbunga2.Text, "General Number")) <> 0 Then
            data(8) = " (detail_nilai_bunga BETWEEN '" + Format(tbunga1.Text, "General Number") + "' AND '" + Format(tbunga2.Text, "General Number") + "')"
            datakel(8) = " (Bunga : " + tbunga1.Text + " sd " + tbunga2.Text + ")"
        Else
            data(8) = ""
            datakel(8) = ""
        End If

        If Len(cmbmarketing.Text) > 0 Then
            If cmbmarketing.Text.ToString.Split(" :")(0) = "--" Then
                data(9) = " rek_tab_kode_marketing=''"
                datakel(9) = " (Marketing : )"
            Else
                data(9) = " rek_tab_kode_marketing='" + tkode_marketing.Text + "'"
                datakel(9) = " (Marketing : " + Microsoft.VisualBasic.Right(cmbmarketing.Text, Len(cmbmarketing.Text) - Len(cmbmarketing.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(9) = ""
            datakel(9) = ""
        End If
        

        Dim gabung As String = ""
        For i = 1 To 9
            If Len(data(i)) > 0 Then
                gabung = gabung + " AND" + data(i)
            End If
        Next i

        Dim kelompok As String = ""
        For ii = 1 To 9
            If Len(datakel(ii)) > 0 Then
                kelompok = kelompok + " | " + datakel(ii)
            End If
        Next ii

        Dim urutkan As String = ""
        Select Case cmburutkan_data.Text.ToString.Split(" :")(0)
            Case "1"
                urutkan = " detail_no_rekening "
            Case "2"
                urutkan = " rek_tab_no_alternatif "
            Case "3"
                urutkan = " detail_nama_nasabah "
            Case "4"
                urutkan = " detail_saldo_awal "
            Case "5"
                urutkan = " detail_nilai_bunga "
            Case "7"
                urutkan = " detail_saldo_akhir "
        End Select

        Dim limit As String = ""
        If Val(Format(tlimit.Text, "General Number")) <> 0 Then
            limit = " LIMIT 0," + Format(tlimit.Text, "General Number")
        End If

        TextBox1.Text = "SELECT detail_no_rekening, detail_nama_nasabah, detail_bunga, detail_metode_bunga, detail_saldo_awal, detail_nilai_bunga, detail_pajak_tabungan, detail_adm_rekening, detail_adm_tab_pasif, detail_saldo_akhir FROM v_nominatif_bunga_tabungan WHERE DATE_FORMAT(detail_tanggal,'%Y-%m') = '" + Format(DateTimePicker1.Value, "yyyy-MM") + "'" + gabung + " ORDER BY" + urutkan + cmbby.Text + limit

        If Len(kelompok) > 0 Then
            TextBox2.Text = "Pengelompokan = " + Microsoft.VisualBasic.Right(kelompok, Len(kelompok) - 3)
        Else
            TextBox2.Text = " "
        End If
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        text_selected()
        laporan_nominatif_bunga_tabungan.ShowDialog()
    End Sub
End Class