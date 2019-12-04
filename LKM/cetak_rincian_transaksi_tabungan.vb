Imports MySql.Data.MySqlClient
Public Class cetak_rincian_transaksi_tabungan

    Private Sub cetak_rincian_transaksi_tabungan_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub cetak_rincian_transaksi_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cetak_rincian_transaksi_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        combo()
        def()
        Me.ResizeRedraw = True
    End Sub

    Private Sub tkode_jenis_produk_LostFocus(sender As Object, e As EventArgs) Handles tkode_jenis_produk.LostFocus
        carijenisproduk()
    End Sub

    Private Sub cmbjenis_produk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjenis_produk.SelectedIndexChanged
        tkode_jenis_produk.Text = cmbjenis_produk.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_kolektor1_LostFocus(sender As Object, e As EventArgs) Handles tkode_kolektor1.LostFocus
        carikolektor1()
    End Sub

    Private Sub cmbkolektor1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbkolektor1.SelectedIndexChanged
        tkode_kolektor1.Text = cmbkolektor1.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_instansi_LostFocus(sender As Object, e As EventArgs) Handles tkode_instansi.LostFocus
        cariinstansi()
    End Sub

    Private Sub cmbinstansi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbinstansi.SelectedIndexChanged
        tkode_instansi.Text = cmbinstansi.Text.ToString.Split(" :")(0)
    End Sub
    Private Sub tkode_marketing_LostFocus(sender As Object, e As EventArgs) Handles tkode_marketing.LostFocus
        carimarketing()
    End Sub

    Private Sub cmbmarketing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmarketing.SelectedIndexChanged
        tkode_marketing.Text = cmbmarketing.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tkode_wilayah_LostFocus(sender As Object, e As EventArgs) Handles tkode_wilayah.LostFocus
        cariwilayah()
    End Sub

    Private Sub cmbwilayah_LostFocus(sender As Object, e As EventArgs) Handles cmbwilayah.LostFocus, tkode_wilayah.LostFocus, cmbinstansi.LostFocus, tkode_instansi.LostFocus, tkode_marketing.LostFocus, cmbmarketing.LostFocus, cmbkolektor1.LostFocus, tkode_kolektor1.LostFocus, cmbjenis_produk.LostFocus, tkode_jenis_produk.LostFocus, cmbjenis_transaksi.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub cmbwilayah_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbwilayah.SelectedIndexChanged
        tkode_wilayah.Text = cmbwilayah.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub cmburutkan_GotFocus(sender As Object, e As EventArgs) Handles cmburutkan.GotFocus, cmbwilayah.GotFocus, tkode_wilayah.GotFocus, cmbinstansi.GotFocus, tkode_instansi.GotFocus, cmbmarketing.GotFocus, tkode_marketing.GotFocus, cmbkolektor1.GotFocus, tkode_kolektor1.GotFocus, cmbjenis_produk.GotFocus, tkode_jenis_produk.GotFocus, cmbjenis_transaksi.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmburutkan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmburutkan.KeyPress, cmbwilayah.KeyPress, cmbinstansi.KeyPress, cmbmarketing.KeyPress, cmbkolektor1.KeyPress, cmbjenis_produk.KeyPress, cmbjenis_transaksi.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmburutkan_LostFocus(sender As Object, e As EventArgs) Handles cmburutkan.LostFocus
        cmburutkan.BackColor = warna_lostfocus
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Me.Dispose()
    End Sub

    Private Sub cetak_rincian_transaksi_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Sub combo()
        With cmbjenis_transaksi.Items
            .Clear()
            .Add("0 : SEMUA TRANSAKSI")
            .Add("1 : TRANSAKSI TUNAI")
            .Add("2 : TRANSAKSI OVERBOOKING")
            '.Add("3 : TRANSAKSI ANTAR KANTOR")
            .Add("4 : TRANSAKSI PEMBUKAAN")
            .Add("5 : TRANSAKSI PENUTUPAN")
            .Add("6 : TRANSAKSI SETORAN")
            .Add("7 : TRANSAKSI PENARIKAN")
            '.Add("8 : TRANSAKSI ATM")
            '.Add("9 : TRANSAKSI EDC/mTAB")
        End With

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', tabungan_kode,UPPER(tabungan_nama_produk)) AS produktabungan FROM data_tabungan_produk WHERE tabungan_status='1'", koneksi)
        rd = cd.ExecuteReader
        With cmbjenis_produk.Items
            .Clear()
            .Add("")
            While rd.Read()
                .Add(rd.Item("produktabungan"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', kolektor_kode,UPPER(kolektor_nama)) AS kolektor FROM data_kolektor", koneksi)
        rd = cd.ExecuteReader
        With cmbkolektor1
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

        cd = New MySqlCommand("SELECT CONCAT(wilayah_kode, ' : ', UPPER(wilayah_nama_desa), ', ', UPPER(wilayah_nama_kecamatan)) AS wilayah FROM data_wilayah", koneksi)
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

        With cmburutkan.Items
            .Clear()
            .Add("1 : NOMOR REKENING")
            .Add("2 : NOMOR ALTERNATIF")
            .Add("3 : NAMA NASABAH")
            '.Add("4 : MEMORIAL")
        End With
    End Sub

    Sub def()
        cmbjenis_transaksi.Text = "0 : SEMUA TRANSAKSI"
        cmburutkan.Text = "1 : NOMOR REKENING"
    End Sub

    Sub carijenisproduk()
        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', tabungan_kode,UPPER(tabungan_nama_produk)) AS produktabungan FROM data_tabungan_produk WHERE tabungan_status='1' AND tabungan_kode='" & tkode_jenis_produk.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbjenis_produk.Text = rd.Item("produktabungan")
        Catch ex As Exception
            cmbjenis_produk.Text = ""
        End Try
        rd.Close()
    End Sub

    Sub carikolektor1()
        cd = New MySqlCommand("SELECT CONCAT_WS (' : ', kolektor_kode,UPPER(kolektor_nama)) AS kolektor FROM data_kolektor WHERE kolektor_kode='" & tkode_kolektor1.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbkolektor1.Text = rd.Item("kolektor")
        Catch ex As Exception
            cmbkolektor1.Text = ""
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
        cd = New MySqlCommand("SELECT CONCAT(wilayah_kode, ' : ', UPPER(wilayah_nama_desa), ', ', UPPER(wilayah_nama_kecamatan)) AS wilayah FROM data_wilayah WHERE wilayah_kode='" & tkode_wilayah.Text & "'", koneksi)
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
        If Len(cmbjenis_produk.Text) > 0 Then
            data(0) = " rek_tab_kode_produk='" + cmbjenis_produk.Text.ToString.Split(" : ")(0) + "'"
            datakel(0) = " (Jenis Produk : " + Microsoft.VisualBasic.Right(cmbjenis_produk.Text, Len(cmbjenis_produk.Text) - Len(cmbjenis_produk.Text.ToString.Split(" : ")(0)) - 3) + ")"
        Else
            data(0) = ""
            datakel(0) = ""
        End If

        If Len(cmbkolektor1.Text) > 0 Then
            If cmbkolektor1.Text.ToString.Split(" : ")(0) = "--" Then
                data(1) = " rek_tab_kode_kolektor=''"
                datakel(1) = " (Kolektor(master) : )"
            Else
                data(1) = " rek_tab_kode_kolektor='" + cmbkolektor1.Text.ToString.Split(" : ")(0) + "'"
                datakel(1) = " (Kolektor(master) : " + Microsoft.VisualBasic.Right(cmbkolektor1.Text, Len(cmbkolektor1.Text) - Len(cmbkolektor1.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(1) = ""
            datakel(1) = ""
        End If

        If Len(cmbinstansi.Text) > 0 Then
            If cmbinstansi.Text.ToString.Split(" : ")(0) = "--" Then
                data(2) = " rek_tab_kode_instansi=''"
                datakel(2) = " (Instansi : )"
            Else
                data(2) = " rek_tab_kode_instansi='" + cmbinstansi.Text.ToString.Split(" : ")(0) + "'"
                datakel(2) = " (Instansi : " + Microsoft.VisualBasic.Right(cmbinstansi.Text, Len(cmbinstansi.Text) - Len(cmbinstansi.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(2) = ""
            datakel(2) = ""
        End If

        If Len(cmbwilayah.Text) > 0 Then
            If cmbwilayah.Text.ToString.Split(" : ")(0) = "--" Then
                data(3) = " rek_tab_kode_wilayah=''"
                datakel(3) = " (Wilayah : )"
            Else
                data(3) = " rek_tab_kode_wilayah='" + cmbwilayah.Text.ToString.Split(" : ")(0) + "'"
                datakel(3) = " (Wilayah : " + Microsoft.VisualBasic.Right(cmbwilayah.Text, Len(cmbwilayah.Text) - Len(cmbwilayah.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(3) = ""
            datakel(3) = ""
        End If

        Dim aaa As String = ""
        Select Case cmbjenis_transaksi.Text.ToString.Split(" : ")(0)
            Case "0"
                data(4) = ""
            Case "1"
                data(4) = " jenis='T'"
            Case "2"
                data(4) = " jenis='O'"
            Case "4"
                data(4) = " pembukaan='1'"
            Case "5"
                data(4) = " tab_stat_kode IN ('04','98')" 'penutupan
                aaa = "penutupan"
            Case "6"
                data(4) = " tab_stat_kode IN ('01','05')" 'setor
            Case "7"
                data(4) = " tab_stat_kode IN ('02','06')" 'tarik
        End Select


        datakel(4) = " (" + Microsoft.VisualBasic.Right(cmbjenis_transaksi.Text, Len(cmbjenis_transaksi.Text) - Len(cmbjenis_transaksi.Text.ToString.Split(" : ")(0)) - 3) + ")"


        If Len(cmbmarketing.Text) > 0 Then
            If cmbmarketing.Text.ToString.Split(" : ")(0) = "--" Then
                data(5) = " rek_tab_kode_marketing=''"
                datakel(5) = " (Marketing : )"
            Else
                data(5) = " rek_tab_kode_marketing='" + cmbmarketing.Text.ToString.Split(" : ")(0) + "'"
                datakel(5) = " (Marketing : " + Microsoft.VisualBasic.Right(cmbmarketing.Text, Len(cmbmarketing.Text) - Len(cmbmarketing.Text.ToString.Split(" : ")(0)) - 3) + ")"
            End If
        Else
            data(5) = ""
            datakel(5) = ""
        End If



        Dim gabung As String = ""
        For i = 0 To 5
            If Len(data(i)) > 0 Then
                gabung = gabung + " AND" + data(i)
            End If
        Next i
        '        MsgBox(gabung)

        Dim kelompok As String = ""
        For ii = 0 To 5
            If Len(datakel(ii)) > 0 Then
                If Len(kelompok) > 0 Then
                    kelompok = kelompok + " | " + datakel(ii)
                Else
                    kelompok = kelompok + datakel(ii)
                End If
            End If
        Next ii

        Dim urutkan As String = ""
        Select Case cmburutkan.Text.ToString.Split(" :")(0)
            Case "1" 'nomor rekening
                urutkan = ", tab_stat_no_rekening "
            Case "2" 'nomor alternatif
                urutkan = ", rek_tab_no_alternatif "
            Case "3" 'nama nasabah
                urutkan = ", namanasabah "
            
        End Select


        'no rekening, nama nasabah, tanggal trans, kode_trasn, setor, tarik, saldo akhir hari, t/o
        TextBox1.Text = "SELECT tab_stat_no_rekening, namanasabah, tab_stat_tanggal, tab_stat_kode, tab_stat_debet, tab_stat_kredit, tab_stat_saldo, jenis FROM v_rincian_transaksi_tabungan WHERE (tab_stat_tanggal BETWEEN '" + Format(DateTimePicker1.Value, "yyyy-MM-dd") + "' AND '" + Format(DateTimePicker2.Value, "yyyy-MM-dd") + "') " + gabung + " ORDER BY tab_stat_waktu " + urutkan

        TextBox2.Text = "Pengelompokan = " + kelompok.ToString
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        text_selected()
        'MsgBox(TextBox1.Text)
        laporan_rincian_transaksi_tabungan.ShowDialog()
    End Sub
End Class