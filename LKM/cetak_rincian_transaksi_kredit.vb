Imports MySql.Data.MySqlClient
Public Class cetak_rincian_transaksi_kredit

    Private Sub cetak_rincian_transaksi_kredit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub cetak_rincian_transaksi_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cetak_rincian_transaksi_kredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()

        combo()
        Me.ResizeRedraw = True
    End Sub

    Private Sub cetak_rincian_transaksi_kredit_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Sub combo()
        With cmbjenis_laporan.Items
            .Clear()
            .Add("01 : REALISASI")
            '.Add("02 : REALISASI [TUNAI]")
            '.Add("03 : REALISASI [OVERBOOKING]")
            '.Add("04 : REALISASI [ANTAR KANTOR]")
            '.Add("05a : BEBAN BUNGA KE POKOK")
            '.Add("05b : BEBAN BUNGA KE POKOK [ADM]")
            .Add("06 : ANGSURAN [SEMUA]")
            '.Add("07 : ANGSURAN [TUNAI]")
            '.Add("08 : ANGSURAN [OVERBOOKING]")
            '.Add("09 : ANGSURAN [ANTAR KANTOR]")
            .Add("10 : ANGSURAN [HNY POKOK]")
            .Add("11 : ANGSURAN [HNY BUNGA]")
            '.Add("12 : ANGSURAN [HNY PELUNASAN]")
            '.Add("13 : ANGSURAN [AUTODEBET TITIPAN]")
            '.Add("14 : ANGSURAN [AUTODEBET TAB]")
            '.Add("15 : ANGSURAN [GAGAL DEBET TAB]")
            '.Add("16 : RESTRUKTURISASI")
            '.Add("17 : PENGHAPUSBUKUAN")
            '.Add("18 : ANGS PH [SEMUA]")
            '.Add("19 : ANGS PH [TUNAI]")
            '.Add("20 : ANGS PH [OVERBOOKING]")
            '.Add("21 : ANGS PH [ANTAR KANTOR]")
            '.Add("22 : MUTASI HAPUS TAGIH")
            '.Add("23 : MUTASI PROVISI & ADM")
            '.Add("24 : MUTASI PYAD & KONTINJENSI")
            '.Add("25 : MUTASI PYD")
            '.Add("26 : MUTASI GABUNGAN KREDIT")
            '.Add("27 : MUTASI GABUNGAN HAPUS BUKU")
            '.Add("28 : TRANSAKSI CHANNELING")
            '.Add("30 : KREDIT LUNAS -> REALISASI BARU")
        End With
        cmbjenis_laporan.SelectedIndex = 0

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

        With cmbkolekbilitas.Items
            .Clear()
            .Add("")
            .Add("L : LANCAR")
            .Add("KL : KURANG LANCAR")
            .Add("D : DIRAGUKAN")
            .Add("M : MACET")
        End With
        cmbkolekbilitas.SelectedIndex = 0

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', kolektor_kode,UPPER(kolektor_nama)) AS kolektor FROM data_kolektor", koneksi)
        rd = cd.ExecuteReader
        With cmbkolektor
            .Items.Clear()
            .Items.Add("")
            .Items.Add("-- : Tidak Teridentifikasikan")
            While rd.Read()
                .Items.Add(rd.Item("kolektor"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', marketing_kode,UPPER(marketing_nama)) AS marketing FROM data_marketing", koneksi)
        rd = cd.ExecuteReader
        With cmbmarketing
            .Items.Clear()
            .Items.Add("")
            .Items.Add("-- : Tidak Teridentifikasikan")
            While rd.Read()
                .Items.Add(rd.Item("marketing"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', instansi_kode,UPPER(instansi_nama)) AS instansi FROM data_instansi", koneksi)
        rd = cd.ExecuteReader
        With cmbinstansi
            .Items.Clear()
            .Items.Add("")
            .Items.Add("-- : Tidak Teridentifikasikan")
            While rd.Read()
                .Items.Add(rd.Item("instansi"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT(wilayah_kode, ' : ', UPPER(wilayah_nama_kecamatan), ', ', UPPER(wilayah_nama_desa)) AS wilayah FROM data_wilayah", koneksi)
        rd = cd.ExecuteReader
        With cmbwilayah
            .Items.Clear()
            .Items.Add("")
            .Items.Add("-- : Tidak Teridentifikasikan")
            While rd.Read()
                .Items.Add(rd.Item("wilayah"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT DISTINCT(nasabah_kecamatan) FROM data_nasabah ORDER BY nasabah_kecamatan ASC", koneksi)
        rd = cd.ExecuteReader
        With cmbkecamatan
            .Items.Clear()
            .Items.Add("")
            While rd.Read()
                .Items.Add(rd.Item("nasabah_kecamatan"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT DISTINCT(nasabah_kelurahan) FROM data_nasabah ORDER BY nasabah_kelurahan ASC", koneksi)
        rd = cd.ExecuteReader
        With cmbkelurahan
            .Items.Clear()
            .Items.Add("")
            While rd.Read()
                .Items.Add(rd.Item("nasabah_kelurahan"))
            End While
        End With
        rd.Close()
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
        cd = New MySqlCommand("SELECT CONCAT(wilayah_kode, ' : ', UPPER(wilayah_nama_kecamatan), ', ', UPPER(wilayah_nama_desa)) AS wilayah FROM data_wilayah WHERE wilayah_kode='" & tkode_wilayah.Text & "'", koneksi)
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
        If Len(cmbskim_kredit.Text) > 0 Then
            data(0) = " rek_kre_kode_produk='" + cmbskim_kredit.Text.ToString.Split(" : ")(0) + "'"
            datakel(0) = " (Skim Kredit : " + Microsoft.VisualBasic.Right(cmbskim_kredit.Text, Len(cmbskim_kredit.Text) - Len(cmbskim_kredit.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(0) = ""
            datakel(0) = ""
        End If

        If Len(cmbkolektor.Text) > 0 Then
            If cmbkolektor.Text.ToString.Split(" : ")(0) = "--" Then
                data(1) = " pelengkap_kolektor=''"
                datakel(1) = " (Kolektor : )"
            Else
                data(1) = " pelengkap_kolektor='" + cmbkolektor.Text.ToString.Split(" : ")(0) + "'"
                datakel(1) = " (Kolektor : " + Microsoft.VisualBasic.Right(cmbkolektor.Text, Len(cmbkolektor.Text) - Len(cmbkolektor.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(1) = ""
            datakel(1) = ""
        End If

        If Len(cmbinstansi.Text) > 0 Then
            If cmbinstansi.Text.ToString.Split(" : ")(0) = "--" Then
                data(2) = " pelengkap_instansi=''"
                datakel(2) = " (Instansi : )"
            Else
                data(2) = " pelengkap_instansi='" + cmbinstansi.Text.ToString.Split(" : ")(0) + "'"
                datakel(2) = " (Instansi : " + Microsoft.VisualBasic.Right(cmbinstansi.Text, Len(cmbinstansi.Text) - Len(cmbinstansi.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(2) = ""
            datakel(2) = ""
        End If

        If Len(cmbwilayah.Text) > 0 Then
            If cmbwilayah.Text.ToString.Split(" : ")(0) = "--" Then
                data(3) = " pelengkap_wilayah=''"
                datakel(3) = " (Wilayah : )"
            Else
                data(3) = " pelengkap_wilayah='" + cmbwilayah.Text.ToString.Split(" : ")(0) + "'"
                datakel(3) = " (Wilayah : " + Microsoft.VisualBasic.Right(cmbwilayah.Text, Len(cmbwilayah.Text) - Len(cmbwilayah.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(3) = ""
            datakel(3) = ""
        End If

        If Len(cmbkecamatan.Text) > 0 Then
            data(4) = " nasabah_kecamatan='" + cmbkecamatan.Text + "'"
            datakel(4) = " (Kecamatan : " + cmbkecamatan.Text + ")"
        Else
            data(4) = ""
            datakel(4) = ""
        End If

        If Len(cmbkelurahan.Text) > 0 Then
            data(5) = " nasabah_kelurahan='" + cmbkelurahan.Text + "'"
            datakel(5) = " (Kelurahan : " + cmbkelurahan.Text + ")"
        Else
            data(5) = ""
            datakel(5) = ""
        End If

        If Len(cmbmarketing.Text) > 0 Then
            If cmbmarketing.Text.ToString.Split(" : ")(0) = "--" Then
                data(6) = " pelengkap_marketing=''"
                datakel(6) = " (Marketing : )"
            Else
                data(6) = " pelengkap_marketing='" + cmbmarketing.Text.ToString.Split(" : ")(0) + "'"
                datakel(6) = " (Marketing : " + Microsoft.VisualBasic.Right(cmbmarketing.Text, Len(cmbmarketing.Text) - Len(cmbmarketing.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(6) = ""
            datakel(6) = ""
        End If

        If Len(cmbkolekbilitas.Text) > 0 Then
            data(7) = " kolek='" + cmbkolekbilitas.Text.ToString.Split(" : ")(0) + "'"
            datakel(7) = " (Kolektibiltas : " + cmbkolekbilitas.Text + ")"
        Else
            data(7) = ""
            datakel(7) = ""
        End If

        

        Dim gabung As String = ""
        Dim str As Integer = 0

        If cmbjenis_laporan.Text.ToString.Split(" : ")(0) = "01" Then
            str = 6
        Else
            str = 7
        End If

        For i = 0 To str
            If Len(data(i)) > 0 Then
                gabung = gabung + " AND" + data(i)
            End If
        Next i

        Dim kelompok As String = ""
        For ii = 0 To str
            If Len(datakel(ii)) > 0 Then
                If Len(kelompok) > 0 Then
                    kelompok = kelompok + " | " + datakel(ii)
                Else
                    kelompok = kelompok + datakel(ii)
                End If
            End If
        Next ii

        If cmbjenis_laporan.Text.ToString.Split(" : ")(0) = "01" Then
            TextBox1.Text = "SELECT pencairan_no_rekening, nasabah_nama1, nasabah_tanggal_lahir, pencairan_waktu, rek_kre_jangka_waktu, rek_kre_suku_bunga, pencairan_kode_transaksi, pencairan_jml_pencairan, pencairan_provisi, pencairan_administrasi, pencairan_premi, pencairan_notaris, pencairan_materai, pencairan_lain FROM v_rincian_transaksi_kredit WHERE (pencairan_waktu BETWEEN '" + Format(DateTimePicker1.Value, "yyyy-MM-dd") + "' AND '" + Format(DateTimePicker2.Value, "yyyy-MM-dd") + "') " + gabung + " ORDER BY pencairan_no_rekening"
        Else
            Select Case cmbjenis_laporan.Text.ToString.Split(" : ")(0)
                Case "06"

                Case "10"
                    gabung = gabung.ToString + " AND angs_pokok > 0 AND angs_bunga <= 0"
                Case "11"
                    gabung = gabung.ToString + " AND angs_bunga > 0 AND angs_pokok <= 0"
            End Select

            TextBox1.Text = "SELECT angs_no_rekening,  nasabah_nama1, nasabah_alamat,tgl_pencairan, angs_tanggal, angs_kode_transaksi, angs_pokok, angs_bunga, angs_denda, angs_total_setoran, bakidebet, jenis, kolek FROM v_rincian_transaksi_kredit2 WHERE (angs_tanggal BETWEEN '" + Format(DateTimePicker1.Value, "yyyy-MM-dd") + "' AND '" + Format(DateTimePicker2.Value, "yyyy-MM-dd") + "') " + gabung + " ORDER BY angs_waktu"
        End If

        If Len(kelompok) > 0 Then
            TextBox2.Text = "Pengelompokan = " + kelompok.ToString
        Else
            TextBox2.Text = " "
        End If

    End Sub

    Private Sub tkode_skim_kredit_LostFocus(sender As Object, e As EventArgs) Handles tkode_skim_kredit.LostFocus
        cariskimkredit()
    End Sub

    Private Sub cmbskim_kredit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbskim_kredit.SelectedIndexChanged
        tkode_skim_kredit.Text = cmbskim_kredit.Text.ToString.Split(" :")(0)
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

    Private Sub cmbkelurahan_GotFocus(sender As Object, e As EventArgs) Handles cmbkelurahan.GotFocus, cmbkecamatan.GotFocus, cmbwilayah.GotFocus, tkode_wilayah.GotFocus, cmbinstansi.GotFocus, tkode_instansi.GotFocus, cmbkolektor.GotFocus, tkode_kolektor.GotFocus, tkode_marketing.GotFocus, cmbmarketing.GotFocus, cmbkolekbilitas.GotFocus, cmbskim_kredit.GotFocus, tkode_skim_kredit.GotFocus, cmbjenis_laporan.GotFocus

        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbkelurahan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbkelurahan.KeyPress, cmbkecamatan.KeyPress, cmbwilayah.KeyPress, cmbinstansi.KeyPress, cmbkolektor.KeyPress, cmbmarketing.KeyPress, cmbkolekbilitas.KeyPress, cmbskim_kredit.KeyPress, cmbjenis_laporan.KeyPress

        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbkelurahan_LostFocus(sender As Object, e As EventArgs) Handles cmbkelurahan.LostFocus, cmbkecamatan.LostFocus, cmbwilayah.LostFocus, tkode_wilayah.LostFocus, cmbinstansi.LostFocus, tkode_instansi.LostFocus, cmbkolektor.LostFocus, tkode_kolektor.LostFocus, cmbmarketing.LostFocus, tkode_marketing.LostFocus, cmbkolekbilitas.LostFocus, cmbskim_kredit.LostFocus, tkode_skim_kredit.LostFocus, cmbjenis_laporan.LostFocus

        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Me.Dispose()
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        text_selected()
        If cmbjenis_laporan.Text.ToString.Split(" : ")(0) = "01" Then
            laporan_rincian_transaksi_kredit.ShowDialog()
        Else
            laporan_rincian_transaksi_kredit2.ShowDialog()
        End If

    End Sub
End Class