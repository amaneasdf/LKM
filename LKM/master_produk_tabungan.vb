Imports MySql.Data.MySqlClient
Public Class master_produk_tabungan
    Dim kode As String
    Dim sortcolumn As Integer = -1

    Private Sub master_produk_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub
    Private Sub master_produk_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        data()
        Me.ResizeRedraw = True
        btntambah.Focus()
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Kode", 50, HorizontalAlignment.Center)
            .Add("Nama Produk", 200, HorizontalAlignment.Left)
            .Add("Saldo Pembukaan", 150, HorizontalAlignment.Right)
            .Add("Setoran Minimal", 150, HorizontalAlignment.Right)
            .Add("Saldo Mengendap", 150, HorizontalAlignment.Right)
            .Add("Bunga", 100, HorizontalAlignment.Right)
            .Add("Min Saldo Bunga", 150, HorizontalAlignment.Right)
            .Add("Metode Hitung Bunga", 300, HorizontalAlignment.Left)
            .Add("Status", 100, HorizontalAlignment.Left)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT *, (SELECT cari_combo_komponen('19',tabungan_metode_hitung_bunga)) AS metode_hitung_bunga, (SELECT cari_combo_komponen('94',tabungan_status)) AS status FROM data_tabungan_produk ORDER BY tabungan_kode", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("tabungan_kode"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("tabungan_nama_produk"))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("tabungan_saldo_pembukaan"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("tabungan_setoran_minimal"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("tabungan_saldo_mengendap"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("tabungan_suku_bunga"), 3).ToString + "%")
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("tabungan_saldo_minimal_dapat_bunga"), 0))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("metode_hitung_bunga"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("status"))
            Next
        End With
        btnhapus.Enabled = False
        btnkoreksi.Enabled = False
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        With data_tabungan
            .kosong()
            .ShowDialog()
        End With
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        listselect()
    End Sub
    Sub listselect()
        With ListView1.SelectedItems.Item(0)
            kode = .Text
        End With
        btnhapus.Enabled = True
        btnkoreksi.Enabled = True
    End Sub

    Private Sub btnkoreksi_Click(sender As Object, e As EventArgs) Handles btnkoreksi.Click
        pilih()
    End Sub
    Sub pilih()
        With data_tabungan
            .combo()
            cd = New MySqlCommand("SELECT *, cari_combo_komponen('93',tabungan_jenis_tabungan) AS jenis_tabungan, cari_combo_komponen('19',tabungan_metode_hitung_bunga) AS metode_hitung_bunga, cari_combo_komponen('94',tabungan_status) AS status, (SELECT COUNT(rek_tab_no_rekening) FROM data_tabungan_rekening WHERE rek_tab_kode_produk=tabungan_kode) AS jumlahrekening FROM data_tabungan_produk WHERE tabungan_kode='" & kode & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            .tkode_produk.Enabled = False
            .tnama_produk.Enabled = False
            .tkode_produk.Text = rd.Item("tabungan_kode")
            .tnama_produk.Text = rd.Item("tabungan_nama_produk")
            .tsaldo_pembukaan.Text = rd.Item("tabungan_saldo_pembukaan")
            .tsetoran_minimal.Text = rd.Item("tabungan_setoran_minimal")
            .tsaldo_mengendap.Text = rd.Item("tabungan_saldo_mengendap")
            .tsaldo_minimal.Text = rd.Item("tabungan_saldo_minimal_dapat_bunga")
            .tsuku_bunga.Text = FormatNumber(rd.Item("tabungan_suku_bunga"), 3)
            .ttanggal_dapet_bunga.Text = rd.Item("tabungan_tanggal_dapat_bunga_awal")
            .tadm_rekening.Text = rd.Item("tabungan_adm_rekening")
            .tadm_tabungan_pasif.Text = rd.Item("tabungan_adm_tabungan_pasif")
            .tjangka_waktu_tabungan_pasif.Text = rd.Item("tabungan_jw_tabungan_pasif")
            .tadm_penutupan.Text = rd.Item("tabungan_adm_penutupan")
            .tperk_tabungan1.Text = rd.Item("tabungan_perk_tabungan")
            .tperk_biaya_bunga1.Text = rd.Item("tabungan_perk_biaya_bunga")
            .cmbjenis_tabungan.Text = rd.Item("jenis_tabungan")
            .cmbmetode_hitung_bunga.Text = rd.Item("metode_hitung_bunga")
            .cmbstatus.Text = rd.Item("status")
            If rd.Item("tabungan_status") = "1" And rd.Item("jumlahrekening") > 0 Then
                .cmbstatus.Enabled = False
                .tnama_produk.Enabled = False
            Else
                .cmbstatus.Enabled = True
                .tnama_produk.Enabled = True
            End If
            rd.Close()
            .btnriwayat.Enabled = True
            .cariperktabungan()
            .cariperkbiayabunga()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus data Setup Tabungan ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cd = New MySqlCommand("SELECT rek_tab_kode_produk FROM data_tabungan_rekening WHERE rek_tab_kode_produk='" & kode & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then
                rd.Close()
                'tidak bisa dihapus
                MessageBox.Show(" Setup Tabungan ini tidak dapat dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                rd.Close()
                hapus()
            End If
            rd.Close()
        End If
    End Sub
    Sub hapus()
        cd = New MySqlCommand("SELECT tabungan_perk_tabungan, tabungan_perk_biaya_bunga FROM data_tabungan_produk WHERE tabungan_kode='" & kode & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Label2.Text = rd.Item("tabungan_perk_tabungan")
        Label3.Text = rd.Item("tabungan_perk_biaya_bunga")
        rd.Close()

        cd = New MySqlCommand("DELETE FROM kode_perkiraan WHERE perkiraan_kode IN ('" & Label2.Text & "', '" & Label3.Text & "')", koneksi)
        cd.ExecuteNonQuery()

        cd = New MySqlCommand("DELETE FROM data_tabungan_produk WHERE tabungan_kode='" & kode & "'", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Setup Tabungan (tabungan_kode : " + kode + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Setup Tabungan berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        pilih()
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            pilih()
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            listselect()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub master_produk_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub master_produk_tabungan_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = MDIParent1.Width - 20
        Me.Height = MDIParent1.Height - 177
    End Sub
End Class