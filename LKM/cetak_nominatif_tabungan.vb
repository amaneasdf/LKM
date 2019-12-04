Imports MySql.Data.MySqlClient
Public Class cetak_nominatif_tabungan

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Me.Dispose()
    End Sub

    Private Sub cmbjenis_laporan_GotFocus(sender As Object, e As EventArgs) Handles cmbjenis_laporan.GotFocus, cmbstatus_rekening.GotFocus, tkode_produk.GotFocus, cmbproduk.GotFocus, tlimit.GotFocus, cmbby.GotFocus, cmburutkan_data.GotFocus, tnama_nasabah.GotFocus, cmbjenis_kelamin.GotFocus, cmbketerkaitan.GotFocus, tsaldo2.GotFocus, tsaldo1.GotFocus, cmbwilayah.GotFocus, tkode_wilayah.GotFocus, cmbinstansi.GotFocus, tkode_instansi.GotFocus, cmbkolektor.GotFocus, tkode_kolektor.GotFocus, cmbmarketing.GotFocus, tkode_marketing.GotFocus, cmbpemilik.GotFocus, tkode_pemilik.GotFocus

        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbjenis_laporan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbjenis_laporan.KeyPress, cmbby.KeyPress, cmburutkan_data.KeyPress, cmbjenis_kelamin.KeyPress, cmbketerkaitan.KeyPress, cmbwilayah.KeyPress, cmbinstansi.KeyPress, cmbkolektor.KeyPress, cmbmarketing.KeyPress, cmbpemilik.KeyPress, cmbstatus_rekening.KeyPress, cmbproduk.KeyPress

        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbjenis_laporan_LostFocus(sender As Object, e As EventArgs) Handles cmbjenis_laporan.LostFocus, cmbstatus_rekening.LostFocus, tkode_produk.LostFocus, cmbproduk.LostFocus, tkode_pemilik.LostFocus, tlimit.LostFocus, cmbby.LostFocus, cmburutkan_data.LostFocus, tnama_nasabah.LostFocus, cmbjenis_kelamin.LostFocus, cmbketerkaitan.LostFocus, tsaldo2.LostFocus, tsaldo1.LostFocus, cmbwilayah.LostFocus, tkode_wilayah.LostFocus, cmbinstansi.LostFocus, tkode_instansi.LostFocus, cmbkolektor.LostFocus, tkode_kolektor.LostFocus, cmbmarketing.LostFocus, tkode_marketing.LostFocus, cmbpemilik.LostFocus

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

    Private Sub tsaldo1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tsaldo1.KeyPress, tsaldo2.KeyPress, tlimit.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tsaldo1_TextChanged(sender As Object, e As EventArgs) Handles tsaldo1.TextChanged, tsaldo2.TextChanged, tlimit.TextChanged
        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub

    Private Sub cetak_nominatif_tabungan_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        btnbatal.PerformClick()
    End Sub

    Private Sub cetak_nominatif_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cetak_nominatif_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        Me.ResizeRedraw = True
        combo()
        def()
    End Sub

    Private Sub cetak_nominatif_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub
    Sub combo()
        With cmbjenis_laporan.Items
            .Clear()
            .Add("01 : TABUNGAN - [RINCIAN - SIMPLE]")
            '.Add("02 : TABUNGAN - [RINCIAN - SIMPLE + LOG BUKU")
            '.Add("11 : TABUNGAN - [REKAP KANTOR]")
            '.Add("12 : TABUNGAN - [REKAP SUBKANTOR]")
            '.Add("13 : TABUNGAN - [REKAP PRODUK]")
            '.Add("14 : TABUNGAN - [REKAP KODE PEMILIK]")
            '.Add("15 : TABUNGAN - [REKAP KOLEKTOR]")
            '.Add("16 : TABUNGAN - [REKAP INSTANSI]")
            '.Add("17 : TABUNGAN - [REKAP WILAYAH]")
            '.Add("18 : TABUNGAN - [REKAP KETERKAITAN]")
            '.Add("19 : TABUNGAN - [REKAP JENIS KELAMIN]")
            '.Add("21 : TABUNGAN - [REKAP SALDO DEFAULT]")
            '.Add("22 : TABUNGAN - [REKAP SALDO LPS]")
            '.Add("23 : TABUNGAN - [REKAP SALDO LAPBUL]")
        End With

        With cmbstatus_rekening.Items
            .Clear()
            .Add("1 : AKTIF")
            .Add("2 : BLOKIR")
            .Add("4 : TUTUP")
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
            .Add("3 : NAMA NASABAH + NO REKENING")
            .Add("4 : NAMA NASABAH + NO ALTERNATIF")
            .Add("5 : SALDO AKHIR")
        End With

        With cmbby.Items
            .Clear()
            .Add("ASC")
            .Add("DESC")
        End With

    End Sub

    Sub def()
        cmbjenis_laporan.Text = "01 : TABUNGAN - [RINCIAN - SIMPLE]"
        cmbstatus_rekening.Text = "1 : AKTIF"
        cmburutkan_data.Text = "1 : NOMOR REKENING"
        cmbby.Text = "ASC"
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
        If Len(cmbstatus_rekening.Text) > 0 Then
            data(0) = " temp_status_tabungan='" + cmbstatus_rekening.Text.ToString.Split(" : ")(0) + "'"
            datakel(0) = " (Status : " + Microsoft.VisualBasic.Right(cmbstatus_rekening.Text, Len(cmbstatus_rekening.Text) - Len(cmbstatus_rekening.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(0) = ""
            datakel(0) = ""
        End If

        If Len(cmbproduk.Text) > 0 Then
            data(1) = " temp_kode_produk='" + tkode_produk.Text + "'"
            datakel(1) = " (Produk : " + Microsoft.VisualBasic.Right(cmbproduk.Text, Len(cmbproduk.Text) - Len(cmbproduk.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(1) = ""
            datakel(1) = ""
        End If

        If Len(cmbpemilik.Text) > 0 Then
            data(2) = " temp_kode_pemilik='" + tkode_pemilik.Text + "'"
            datakel(2) = " (Pemilik : " + Microsoft.VisualBasic.Right(cmbpemilik.Text, Len(cmbpemilik.Text) - Len(cmbpemilik.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(2) = ""
            datakel(2) = ""
        End If

        If Len(cmbkolektor.Text) > 0 Then
            If cmbkolektor.Text.ToString.Split(" :")(0) = "--" Then
                data(3) = " temp_kode_kolektor=''"
                datakel(3) = " (Kolektor : )"
            Else
                data(3) = " temp_kode_kolektor='" + tkode_kolektor.Text + "'"
                datakel(3) = " (Kolektor : " + Microsoft.VisualBasic.Right(cmbkolektor.Text, Len(cmbkolektor.Text) - Len(cmbkolektor.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(3) = ""
            datakel(3) = ""
        End If

        If Len(cmbinstansi.Text) > 0 Then
            If cmbinstansi.Text.ToString.Split(" :")(0) = "--" Then
                data(4) = " temp_kode_instansi=''"
                datakel(4) = " (Instansi : )"
            Else
                data(4) = " temp_kode_instansi='" + tkode_instansi.Text + "'"
                datakel(4) = " (Instansi : " + Microsoft.VisualBasic.Right(cmbinstansi.Text, Len(cmbinstansi.Text) - Len(cmbinstansi.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(4) = ""
            datakel(4) = ""
        End If

        If Len(cmbwilayah.Text) > 0 Then
            If cmbwilayah.Text.ToString.Split(" :")(0) = "--" Then
                data(5) = " temp_kode_wilayah=''"
                datakel(5) = " (Wilayah : )"
            Else
                data(5) = " temp_kode_wilayah='" + tkode_wilayah.Text + "'"
                datakel(5) = " (Wilayah : " + Microsoft.VisualBasic.Right(cmbwilayah.Text, Len(cmbwilayah.Text) - Len(cmbwilayah.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(5) = ""
            datakel(5) = ""
        End If

        If Len(cmbketerkaitan.Text) > 0 Then
            data(6) = " temp_keterkaitan='" + cmbketerkaitan.Text.ToString.Split(" :")(0) + "'"
            datakel(6) = " (Keterkaitan : " + Microsoft.VisualBasic.Right(cmbketerkaitan.Text, Len(cmbketerkaitan.Text) - Len(cmbketerkaitan.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(6) = ""
            datakel(6) = ""
        End If

        If Len(cmbjenis_kelamin.Text) > 0 Then
            data(7) = " temp_jenis_kelamin='" + cmbjenis_kelamin.Text.ToString.Split(" :")(0) + "'"
            datakel(7) = " (Jenis Kelamin : " + Microsoft.VisualBasic.Right(cmbjenis_kelamin.Text, Len(cmbjenis_kelamin.Text) - Len(cmbjenis_kelamin.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(7) = ""
            datakel(7) = ""
        End If

        If Len(tnama_nasabah.Text) > 0 Then
            data(8) = " temp_nama_nasabah like '%" + tnama_nasabah.Text + "%'"
            datakel(8) = " (Nama : " + tnama_nasabah.Text + ")"
        Else
            data(8) = ""
            datakel(8) = ""
        End If

        If Val(Format(tsaldo1.Text, "General Number")) <> 0 Or Val(Format(tsaldo2.Text, "General Number")) <> 0 Then
            data(9) = " (temp_saldo_akhir BETWEEN '" + Format(tsaldo1.Text, "General Number") + "' AND '" + Format(tsaldo2.Text, "General Number") + "')"
            datakel(9) = " (Saldo : " + tsaldo1.Text + " sd " + tsaldo2.Text + ")"
        Else
            data(9) = ""
            datakel(9) = ""
        End If

        If Len(cmbmarketing.Text) > 0 Then
            If cmbmarketing.Text.ToString.Split(" :")(0) = "--" Then
                data(10) = " temp_kode_marketing=''"
                datakel(10) = " (Marketing : )"
            Else
                data(10) = " temp_kode_marketing='" + tkode_marketing.Text + "'"
                datakel(10) = " (Marketing : " + Microsoft.VisualBasic.Right(cmbmarketing.Text, Len(cmbmarketing.Text) - Len(cmbmarketing.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(10) = ""
            datakel(10) = ""
        End If

        Dim gabung As String = ""
        For i = 0 To 10
            If Len(data(i)) > 0 Then
                gabung = gabung + " AND" + data(i)
            End If
        Next i

        Dim kelompok As String = ""
        For ii = 0 To 10
            If Len(datakel(ii)) > 0 Then
                kelompok = kelompok + " | " + datakel(ii)
            End If
        Next ii

        Dim urutkan As String = ""
        Select Case cmburutkan_data.Text.ToString.Split(" :")(0)
            Case "1"
                urutkan = " temp_no_rekening "
            Case "2"
                urutkan = " temp_no_alternatif "
            Case "3"
                urutkan = " temp_nama_nasabah, temp_no_rekening "
            Case "4"
                urutkan = " temp_nama_nasabah, temp_no_alternatif "
            Case "5"
                urutkan = " temp_saldo_akhir "
        End Select

        Dim limit As String = ""
        If Val(Format(tlimit.Text, "General Number")) <> 0 Then
            limit = " LIMIT 0," + Format(tlimit.Text, "General Number")
        End If


        cd = New MySqlCommand("DELETE FROM temp_nominatif_tabungan WHERE temp_username='" & MDIParent1.username.Text & "'", koneksi)
        cd.ExecuteNonQuery()

        da = New MySqlDataAdapter("CALL cek_nominatif_tabungan('" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')", koneksi)
        dt = New DataTable
        da.Fill(dt)

        For i As Integer = 0 To dt.Rows.Count - 1
            '.Items.Add(dt.Rows(i)("rek_tab_no_rekening")) '0
            cd = New MySqlCommand("INSERT INTO temp_nominatif_tabungan VALUES ('" & dt.Rows(i)("riwayat_no_rekening") & "','" & dt.Rows(i)("rek_tab_no_alternatif") & "','" & dt.Rows(i)("nasabah_nama1") & "','" & dt.Rows(i)("nasabah_jenis_kelamin") & "','" & dt.Rows(i)("alamat") & "','" & Format(dt.Rows(i)("rek_tab_reg_waktu"), "yyyy-MM-dd HH:mm:ss") & "','" & dt.Rows(i)("nasabah_keterkaitan") & "','" & dt.Rows(i)("status") & "','" & dt.Rows(i)("rek_tab_kode_produk") & "','" & dt.Rows(i)("rek_tab_kode_pemilik") & "','" & dt.Rows(i)("rek_tab_kode_kolektor") & "','" & dt.Rows(i)("rek_tab_kode_marketing") & "','" & dt.Rows(i)("rek_tab_kode_instansi") & "','" & dt.Rows(i)("rek_tab_kode_wilayah") & "','" & dt.Rows(i)("saldo") & "','" & MDIParent1.username.Text & "')", koneksi)
            cd.ExecuteNonQuery()

        Next


        TextBox1.Text = "SELECT * FROM temp_nominatif_tabungan WHERE temp_username = '" + MDIParent1.username.Text + "'" + gabung + " ORDER BY" + urutkan + cmbby.Text + limit

        TextBox2.Text = "Pengelompokan = " + Microsoft.VisualBasic.Right(kelompok, Len(kelompok) - 3)
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        text_selected()
        laporan_nominatif_tabungan.ShowDialog()
    End Sub
End Class