Imports MySql.Data.MySqlClient
Public Class proses_bunga_tabungan
    Dim tanggal, waktu, bulan_dan_tahun As String

    Dim data_proses(99) As String
    Dim bunga, pajak, adm_rekening, adm_tab_pasif As String
    Private Sub proses_bunga_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub proses_bunga_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        ukuran()
        Me.ResizeRedraw = True
    End Sub

    Private Sub proses_bunga_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("No Rekening", 100, HorizontalAlignment.Left) '0
            .Add("Nama Nasabah", 200, HorizontalAlignment.Left) '1
            .Add("Produk", 70, HorizontalAlignment.Center) '2
            .Add("Metode Bunga", 70, HorizontalAlignment.Center) '3
            .Add("Bunga %", 70, HorizontalAlignment.Center) '4
            .Add("Saldo", 100, HorizontalAlignment.Right) '5
            .Add("Bunga", 100, HorizontalAlignment.Right) '6
            .Add("Pajak", 100, HorizontalAlignment.Right) '7
            .Add("Adm. Rekening", 100, HorizontalAlignment.Right) '8
            .Add("Adm. Tab Pasif", 100, HorizontalAlignment.Right) '9
            .Add("Saldo Akhir", 100, HorizontalAlignment.Right) '10
            .Add("Status", 100, HorizontalAlignment.Center) '11
            .Add("", 0, HorizontalAlignment.Center) '12
            .Add("", 0, HorizontalAlignment.Center) '13
        End With
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub


    Private Sub btnhitung_Click(sender As Object, e As EventArgs) Handles btnhitung.Click
        cd = New MySqlCommand("SELECT IFNULL(COUNT(*), 0) AS jml FROM data_tabungan_proses_bunga WHERE proses_bulan='" & Format(DateTimePicker1.Value, "MM") & "' AND proses_tahun='" & Format(DateTimePicker1.Value, "yyyy") & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Label7.Text = rd.Item("jml")
        rd.Close()

        If Label7.Text <> "0" Then
            MessageBox.Show("Proses Bunga Tabungan Bulan " + DateTimePicker1.Text + " sudah pernah dilakukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
            ListView1.Items.Clear()
            Exit Sub
        ElseIf Format(DateTimePicker1.Value, "yyyy-MM") <> Format(DateTimePicker2.Value, "yyyy-MM") Then
            MessageBox.Show("Tanggal Buku harus ada dalam bulan yang sama dengan tanggal hitung.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
            ListView1.Items.Clear()
            Exit Sub
        End If
        hitung()
    End Sub

    Sub hitung()



        tanggal = Format(DateTimePicker2.Value, "yyyy-MM-dd")
        waktu = Format(DateTimePicker2.Value, "yyyy-MM-dd").ToString + " 23:59:59"
        bulan_dan_tahun = Format(DateTimePicker2.Value, "MMM yyyy")


        da = New MySqlDataAdapter("CALL hitung_proses_bulanan('" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("rek_tab_no_rekening")) '0
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("namanasabah")) '1
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("rek_tab_kode_produk")) '2
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("rek_tab_metode_hitung_bunga")) '3
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("rek_tab_suku_bunga"), 3)) '4
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("saldo_akhir"), 0)) '5
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("dapat_bunga"), 0)) '6
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("pajak_bunga"), 0)) '7
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("adm_bulanan"), 0)) '8
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("potongan_tabungan_pasif"), 0)) '9
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber((dt.Rows(i)("saldo_akhir") + dt.Rows(i)("dapat_bunga") - dt.Rows(i)("pajak_bunga")) - (dt.Rows(i)("adm_bulanan") + dt.Rows(i)("potongan_tabungan_pasif")), 0)) '10
                .Items(.Items.Count - 1).SubItems().Add("Hitung") '11
                .Items(.Items.Count - 1).SubItems().Add(tanggal) '12
                .Items(.Items.Count - 1).SubItems().Add(waktu) '13

                bunga = Val(bunga) + Val(dt.Rows(i)("dapat_bunga"))
                pajak = Val(pajak) + Val(dt.Rows(i)("pajak_bunga"))
                adm_rekening = Val(adm_rekening) + Val(dt.Rows(i)("adm_bulanan"))
                adm_tab_pasif = Val(adm_tab_pasif) + Val(dt.Rows(i)("potongan_tabungan_pasif"))

            Next
        End With

        tjml_rekening.Text = FormatNumber(ListView1.Items.Count, 0)
        tbunga.Text = FormatNumber(bunga, 0)
        tpajak.Text = FormatNumber(pajak, 0)
        tadm_rekening.Text = FormatNumber(adm_rekening, 0)
        tadm_pasif.Text = FormatNumber(adm_tab_pasif, 0)

    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        Dim tgl2, notranstab, notransjurnal As String
        Dim daa As MySqlDataAdapter
        Dim dtt As DataTable

        Dim jenis_produk(99), nama_produk(99) As String
        Dim perk_tabungan(99), perk_bunga(99), perk_pajak_bunga(99), perk_adm_rekening(99), perk_rek_pasif(99) As String

        Dim total_bunga(99), total_pajak_bunga(99), total_adm_rekening(99), total_adm_rekening_pasif(99) As String

        tgl2 = Format(DateTimePicker2.Value, "ddMMyyyy")

        daa = New MySqlDataAdapter("SELECT DISTINCT(tabungan_kode) AS kd FROM data_tabungan_produk", koneksi)
        dtt = New DataTable
        daa.Fill(dtt)
        For ii As Integer = 0 To dtt.Rows.Count - 1
            jenis_produk(dtt.Rows(ii)("kd")) = dtt.Rows(ii)("kd")

            cd = New MySqlCommand("SELECT tabungan_perk_tabungan, tabungan_perk_biaya_bunga, tabungan_nama_produk FROM data_tabungan_produk WHERE tabungan_kode='" & dtt.Rows(ii)("kd") & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            perk_tabungan(dtt.Rows(ii)("kd")) = rd.Item("tabungan_perk_tabungan")
            perk_bunga(dtt.Rows(ii)("kd")) = rd.Item("tabungan_perk_biaya_bunga")
            nama_produk(dtt.Rows(ii)("kd")) = rd.Item("tabungan_nama_produk")
            rd.Close()

            cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='PajakBunga'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            perk_pajak_bunga(dtt.Rows(ii)("kd")) = rd.Item("perk_kode")
            rd.Close()

            cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='PendAdmRekening'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            perk_adm_rekening(dtt.Rows(ii)("kd")) = rd.Item("perk_kode")
            rd.Close()

            cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='PendRekPasif'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            perk_rek_pasif(dtt.Rows(ii)("kd")) = rd.Item("perk_kode")
            rd.Close()

            total_bunga(dtt.Rows(ii)("kd")) = 0
            total_pajak_bunga(dtt.Rows(ii)("kd")) = 0
            total_adm_rekening(dtt.Rows(ii)("kd")) = 0
            total_adm_rekening_pasif(dtt.Rows(ii)("kd")) = 0

        Next

        For i As Integer = 0 To ListView1.Items.Count - 1
            With ListView1.Items(i)

                notranstab = "." + Format(DateTimePicker1.Value, "ddMMyyyy").ToString + "." + Microsoft.VisualBasic.Right("00000" & Microsoft.VisualBasic.Right(i, 5) + 1, 5)

                'insert detail
                cd = New MySqlCommand("INSERT INTO data_tabungan_proses_bunga_detail VALUES ('', '" & tanggal & "', '" & dt.Rows(i)("rek_tab_no_rekening") & "', '" & dt.Rows(i)("namanasabah") & "', '" & dt.Rows(i)("rek_tab_metode_hitung_bunga") & "', '" & dt.Rows(i)("rek_tab_suku_bunga") & "', '" & dt.Rows(i)("saldo_akhir") & "', '" & dt.Rows(i)("dapat_bunga") & "', '" & dt.Rows(i)("pajak_bunga") & "', '" & dt.Rows(i)("adm_bulanan") & "', '" & dt.Rows(i)("potongan_tabungan_pasif") & "', '" & (dt.Rows(i)("saldo_akhir") + dt.Rows(i)("dapat_bunga") - dt.Rows(i)("pajak_bunga")) - (dt.Rows(i)("adm_bulanan") + dt.Rows(i)("potongan_tabungan_pasif")) & "', '1', '" & MDIParent1.username.Text & "', '" & waktu & "')", koneksi)
                cd.ExecuteNonQuery()

                If Format(.SubItems(6).Text, "General Number") > 0 Then 'bunga
                    cd = New MySqlCommand("INSERT INTO data_tabungan_statement VALUES ('', '" & .SubItems(12).Text & "','" & .SubItems(13).Text & "', '07', '07" & notranstab & "', '" & .Text & "', '0', '" & Format(.SubItems(6).Text, "General Number") & "', (hitung_saldo_akhir_tabungan('" & .Text & "') + '" & Format(.SubItems(6).Text, "General Number") & "'), 'Bunga Tabungan', '" & MDIParent1.username.Text & "')", koneksi)
                    cd.ExecuteNonQuery()
                End If

                total_bunga(.SubItems(2).Text) = Val(total_bunga(.SubItems(2).Text)) + Val(Format(.SubItems(6).Text, "General Number"))


                If Format(.SubItems(7).Text, "General Number") > 0 Then 'pajak
                    cd = New MySqlCommand("INSERT INTO data_tabungan_statement VALUES ('', '" & .SubItems(12).Text & "','" & .SubItems(13).Text & "', '10', '10" & notranstab & "', '" & .Text & "', '" & Format(.SubItems(7).Text, "General Number") & "', '0', (hitung_saldo_akhir_tabungan('" & .Text & "') - '" & Format(.SubItems(7).Text, "General Number") & "'), 'Pajak Bunga', '" & MDIParent1.username.Text & "')", koneksi)
                    cd.ExecuteNonQuery()
                End If

                total_pajak_bunga(.SubItems(2).Text) = Val(total_pajak_bunga(.SubItems(2).Text)) + Val(Format(.SubItems(7).Text, "General Number"))



                If Format(.SubItems(7).Text, "General Number") > 0 Then 'adm bulanan
                    cd = New MySqlCommand("INSERT INTO data_tabungan_statement VALUES ('', '" & .SubItems(12).Text & "','" & .SubItems(13).Text & "', '08', '08" & notranstab & "', '" & .Text & "', '" & Format(.SubItems(8).Text, "General Number") & "', '0', (hitung_saldo_akhir_tabungan('" & .Text & "') - '" & Format(.SubItems(8).Text, "General Number") & "'), 'Administrasi Tabungan', '" & MDIParent1.username.Text & "')", koneksi)
                    cd.ExecuteNonQuery()
                End If

                total_adm_rekening(.SubItems(2).Text) = Val(total_adm_rekening(.SubItems(2).Text)) + Val(Format(.SubItems(8).Text, "General Number"))

                If Format(.SubItems(9).Text, "General Number") > 0 Then
                    cd = New MySqlCommand("INSERT INTO data_tabungan_statement VALUES ('', '" & .SubItems(12).Text & "','" & .SubItems(13).Text & "', '09', '09" & notranstab & "', '" & .Text & "', '" & Format(.SubItems(9).Text, "General Number") & "', '0', (hitung_saldo_akhir_tabungan('" & .Text & "') - '" & Format(.SubItems(9).Text, "General Number") & "'), 'Administrasi Tabungan Pasif', '" & MDIParent1.username.Text & "')", koneksi)
                    cd.ExecuteNonQuery()
                End If

                total_adm_rekening_pasif(.SubItems(2).Text) = Val(total_adm_rekening_pasif(.SubItems(2).Text)) + Val(Format(.SubItems(9).Text, "General Number"))

                If Format(.SubItems(10).Text, "General Number") = 0 Then
                    cd = New MySqlCommand("UPDATE data_tabungan_rekening SET rek_tab_status='4' WHERE rek_tab_no_rekening=" & .Text & "", koneksi)
                    cd.ExecuteNonQuery()
                End If

                .SubItems(11).Text = "Simpan dan Valisdasi"
            End With
        Next


        For ii As Integer = 0 To dtt.Rows.Count - 1
            notransjurnal = Format(DateTimePicker1.Value, "ddMMyyyy").ToString + "." + Microsoft.VisualBasic.Right("00000" & Microsoft.VisualBasic.Right(ii, 5) + 1, 5)

            If Val(total_bunga(dtt.Rows(ii)("kd"))) > 0 Then
                cd = New MySqlCommand("INSERT INTO data_akuntansi_jurnal VALUES ('', '" & tanggal & "', '07', '" & MDIParent1.username.Text & "', '" & waktu & "', 'TAB', '" & perk_bunga(dtt.Rows(ii)("kd")) & "', '" & notransjurnal & "', 'Biaya Bunga " & nama_produk(dtt.Rows(ii)("kd")) & " bln " & bulan_dan_tahun.ToString & "','" & total_bunga(dtt.Rows(ii)("kd")) & "', '0', '1')", koneksi)
                cd.ExecuteNonQuery()

                cd = New MySqlCommand("INSERT INTO data_akuntansi_jurnal VALUES ('', '" & tanggal & "', '07', '" & MDIParent1.username.Text & "', '" & waktu & "', 'TAB', '" & perk_tabungan(dtt.Rows(ii)("kd")) & "', '" & notransjurnal & "', 'Biaya Bunga " & nama_produk(dtt.Rows(ii)("kd")) & " bln " & bulan_dan_tahun.ToString & "', '0', '" & total_bunga(dtt.Rows(ii)("kd")) & "', '1')", koneksi)
                cd.ExecuteNonQuery()
            End If

            If Val(total_pajak_bunga(dtt.Rows(ii)("kd"))) > 0 Then
                cd = New MySqlCommand("INSERT INTO data_akuntansi_jurnal VALUES ('', '" & tanggal & "', '10', '" & MDIParent1.username.Text & "', '" & waktu & "', 'TAB', '" & perk_pajak_bunga(dtt.Rows(ii)("kd")) & "', '" & notransjurnal & "', 'Pajak Bunga " & nama_produk(dtt.Rows(ii)("kd")) & " bln " & bulan_dan_tahun.ToString & "','" & total_pajak_bunga(dtt.Rows(ii)("kd")) & "', '0', '1')", koneksi)
                cd.ExecuteNonQuery()

                cd = New MySqlCommand("INSERT INTO data_akuntansi_jurnal VALUES ('', '" & tanggal & "', '10', '" & MDIParent1.username.Text & "', '" & waktu & "', 'TAB', '" & perk_tabungan(dtt.Rows(ii)("kd")) & "', '" & notransjurnal & "', 'Pajak Bunga " & nama_produk(dtt.Rows(ii)("kd")) & " bln " & bulan_dan_tahun.ToString & "', '0', '" & total_pajak_bunga(dtt.Rows(ii)("kd")) & "', '1')", koneksi)
                cd.ExecuteNonQuery()
            End If


            If Val(total_adm_rekening(dtt.Rows(ii)("kd"))) > 0 Then
                cd = New MySqlCommand("INSERT INTO data_akuntansi_jurnal VALUES ('', '" & tanggal & "', '08', '" & MDIParent1.username.Text & "', '" & waktu & "', 'TAB', '" & perk_tabungan(dtt.Rows(ii)("kd")) & "', '" & notransjurnal & "', 'Adm Rek " & nama_produk(dtt.Rows(ii)("kd")) & " bln " & bulan_dan_tahun.ToString & "','" & total_adm_rekening(dtt.Rows(ii)("kd")) & "', '0', '1')", koneksi)
                cd.ExecuteNonQuery()

                cd = New MySqlCommand("INSERT INTO data_akuntansi_jurnal VALUES ('', '" & tanggal & "', '08', '" & MDIParent1.username.Text & "', '" & waktu & "', 'TAB', '" & perk_adm_rekening(dtt.Rows(ii)("kd")) & "', '" & notransjurnal & "', 'Pend. Adm " & nama_produk(dtt.Rows(ii)("kd")) & " bln " & bulan_dan_tahun.ToString & "', '0', '" & total_adm_rekening(dtt.Rows(ii)("kd")) & "', '1')", koneksi)
                cd.ExecuteNonQuery()
            End If


            If Val(total_adm_rekening_pasif(dtt.Rows(ii)("kd"))) > 0 Then
                cd = New MySqlCommand("INSERT INTO data_akuntansi_jurnal VALUES ('', '" & tanggal & "', '08', '" & MDIParent1.username.Text & "', '" & waktu & "', 'TAB', '" & perk_tabungan(dtt.Rows(ii)("kd")) & "', '" & notransjurnal & "', 'Adm Pasif " & nama_produk(dtt.Rows(ii)("kd")) & " bln " & bulan_dan_tahun.ToString & "','" & total_adm_rekening_pasif(dtt.Rows(ii)("kd")) & "', '0', '1')", koneksi)
                cd.ExecuteNonQuery()

                cd = New MySqlCommand("INSERT INTO data_akuntansi_jurnal VALUES ('', '" & tanggal & "', '08', '" & MDIParent1.username.Text & "', '" & waktu & "', 'TAB', '" & perk_rek_pasif(dtt.Rows(ii)("kd")) & "', '" & notransjurnal & "', 'Pend. Adm Pasif " & nama_produk(dtt.Rows(ii)("kd")) & " bln " & bulan_dan_tahun.ToString & "', '0', '" & total_adm_rekening_pasif(dtt.Rows(ii)("kd")) & "', '1')", koneksi)
                cd.ExecuteNonQuery()
            End If
        Next

        'insert ke data tabungan proses bunga
        cd = New MySqlCommand("INSERT INTO data_tabungan_proses_bunga VALUES ('', '" & Format(DateTimePicker1.Value, "MM") & "','" & Format(DateTimePicker1.Value, "yyyy") & "', '" & Format(tjml_rekening.Text, "General Number") & "', '" & Format(tbunga.Text, "General Number") & "', '" & Format(tpajak.Text, "General Number") & "', '" & Format(tadm_rekening.Text, "General Number") & "', '" & Format(tadm_pasif.Text, "General Number") & "', '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "', '" & MDIParent1.username.Text & "', '" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "')", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Melakukan perhitungan bunga tabungan bln " + bulan_dan_tahun.ToString
        insert_log_user()

        
        btnsimpan.Enabled = False
        MessageBox.Show("Proses Bunga Tabungan berhasil disimpan dan divalidasi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub tjml_rekening_TextChanged(sender As Object, e As EventArgs) Handles tjml_rekening.TextChanged
        If tjml_rekening.Text = "0" Then
            btnsimpan.Enabled = False
        Else
            btnsimpan.Enabled = True
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class