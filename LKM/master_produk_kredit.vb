Imports MySql.Data.MySqlClient
Public Class master_produk_kredit
    Dim kode As String
    Dim sortcolumn As Integer = -1

    Private Sub master_produk_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub master_produk_kredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        Data()
        Me.ResizeRedraw = True
        btntambah.Focus()
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Kode", 50, HorizontalAlignment.Center)
            .Add("Nama Produk", 200, HorizontalAlignment.Left)
            .Add("Jenis", 50, HorizontalAlignment.Center)
            .Add("Plafond", 150, HorizontalAlignment.Left)
            .Add("JKW", 50, HorizontalAlignment.Center)
            .Add("SB (%)", 100, HorizontalAlignment.Center)
            .Add("Prov (%/Rp)", 100, HorizontalAlignment.Center)
            .Add("Adm (%/Rp)", 100, HorizontalAlignment.Center)
            .Add("Sistem", 70, HorizontalAlignment.Center)
            .Add("Bunga", 70, HorizontalAlignment.Center)
            .Add("Status", 100, HorizontalAlignment.Center)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT * FROM data_kredit_produk ORDER BY kredit_kode ASC", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("kredit_kode"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kredit_nama_produk"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kredit_jenis_kredit"))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kredit_plafon_min"), 0) + " - " + FormatNumber(dt.Rows(i)("kredit_plafon_max"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kredit_jkw_min"), 0) + " - " + FormatNumber(dt.Rows(i)("kredit_jkw_max"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kredit_sb_min"), 3).ToString + " - " + FormatNumber(dt.Rows(i)("kredit_sb_max"), 3).ToString)
                Select Case dt.Rows(i)("kredit_pot_provisi")
                    Case "0"
                        .Items(.Items.Count - 1).SubItems().Add("-")
                    Case "1"
                        .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kredit_pot_provisi_p"), 2))
                    Case Else
                        .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kredit_pot_provisi_rp"), 0))
                End Select

                Select Case dt.Rows(i)("kredit_pot_adm")
                    Case "0"
                        .Items(.Items.Count - 1).SubItems().Add("-")
                    Case "1"
                        .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kredit_pot_adm_p"), 2))
                    Case Else
                        .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kredit_pot_adm_rp"), 0))
                End Select

                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kredit_periode_angsuran"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kredit_sistem_bunga"))
                Select Case dt.Rows(i)("kredit_status")
                    Case "1"
                        .Items(.Items.Count - 1).SubItems().Add("AKTIF")
                    Case Else
                        .Items(.Items.Count - 1).SubItems().Add("NON-AKTIF")
                End Select
            Next
        End With
        btnhapus.Enabled = False
        btnkoreksi.Enabled = False
    End Sub

    Private Sub master_produk_kredit_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub master_produk_kredit_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = MDIParent1.Width - 20
        Me.Height = MDIParent1.Height - 177
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        With data_kredit
            .kosong()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
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

    Private Sub btnkoreksi_Click(sender As Object, e As EventArgs) Handles btnkoreksi.Click
        pilih()
    End Sub
    Sub pilih()
        With data_kredit
            .tkode_produk.Text = kode
            .cekdatakredit()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus data Setup Kredit ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cd = New MySqlCommand("SELECT rek_kre_kode_produk FROM data_kredit_rekening WHERE rek_kre_kode_produk='" & kode & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            If rd.HasRows = True Then
                rd.Close()
                'tidak bisa dihapus
                MessageBox.Show("Setup Kredit ini tidak dapat dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                rd.Close()
                hapus()
            End If
            rd.Close()
        End If
    End Sub
    Sub hapus()
        cd = New MySqlCommand("SELECT kredit_perk_kredit, kredit_perk_bunga FROM data_kredit_produk WHERE kredit_kode='" & kode & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Label2.Text = rd.Item("kredit_perk_kredit")
        Label3.Text = rd.Item("kredit_perk_bunga")
        rd.Close()

        cd = New MySqlCommand("DELETE FROM kode_perkiraan WHERE perkiraan_kode IN ('" & Label2.Text & "', '" & Label3.Text & "')", koneksi)
        cd.ExecuteNonQuery()

        cd = New MySqlCommand("DELETE FROM data_kredit_produk WHERE kredit_kode='" & kode & "'", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Setup Kredit (kredit_kode : " + kode + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Setup Kredit berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class