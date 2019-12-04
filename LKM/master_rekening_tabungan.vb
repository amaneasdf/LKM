Imports MySql.Data.MySqlClient
Public Class master_rekening_tabungan
    Dim kode As String
    Dim sortcolumn As Integer = -1
    Private Sub tfilter_GotFocus(sender As Object, e As EventArgs) Handles tfilter.GotFocus
        tfilter.BackColor = warna_gotfocus
        Button1.BackColor = warna_gotfocus
    End Sub

    Private Sub tfilter_KeyDown(sender As Object, e As KeyEventArgs) Handles tfilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnfilter.PerformClick()
        ElseIf e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            Try
                ListView1.Items(0).Selected = True
            Catch ex As Exception

            End Try
            ListView1.Focus()
        End If
    End Sub

    Private Sub tfilter_LostFocus(sender As Object, e As EventArgs) Handles tfilter.LostFocus
        tfilter.BackColor = warna_lostfocus
        Button1.BackColor = warna_lostfocus
    End Sub
    Sub tampil()
        Try
            rd.Close()
        Catch ex As Exception

        End Try

        da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, rek_tab_no_alternatif, tabungan_nama_produk, nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, rek_tab_status FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id JOIN data_tabungan_produk ON rek_tab_kode_produk=tabungan_kode WHERE rek_tab_status='0' ORDER BY rek_tab_no_rekening", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
    End Sub
    Sub cari()
        btnhapus.Enabled = False
        btnkoreksi.Enabled = False
        da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, rek_tab_no_alternatif, tabungan_nama_produk, nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, rek_tab_status FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id JOIN data_tabungan_produk ON rek_tab_kode_produk=tabungan_kode WHERE nasabah_nama1 LIKE '%" & tfilter.Text & "%' OR rek_tab_no_rekening LIKE '%" & tfilter.Text & "%' OR rek_tab_no_alternatif LIKE '%" & tfilter.Text & "%' ORDER BY rek_tab_no_rekening", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
        If ListView1.Items.Count = 0 Then
            MessageBox.Show("Data tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("No Rekening", 100, HorizontalAlignment.Left)
            .Add("No Alternatif", 100, HorizontalAlignment.Left)
            .Add("Produk", 250, HorizontalAlignment.Left)
            .Add("Nama Nasabah", 300, HorizontalAlignment.Left)
            .Add("Alamat Nasabah", 500, HorizontalAlignment.Left)
            .Add("Status", 80, HorizontalAlignment.Center)
        End With
    End Sub
    Sub data()
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("rek_tab_no_rekening"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("rek_tab_no_alternatif"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("tabungan_nama_produk"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_nama1"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_alamat") + ", " + dt.Rows(i)("nasabah_kelurahan") + ", " + dt.Rows(i)("nasabah_kecamatan"))
                Select Case dt.Rows(i)("rek_tab_status")
                    Case "0"
                        .Items(.Items.Count - 1).SubItems().Add("NONE")
                        .Items(i).BackColor = Color.Silver
                    Case "1"
                        .Items(.Items.Count - 1).SubItems().Add("AKTIF")
                        .Items(i).BackColor = Color.LightGreen
                    Case "2"
                        .Items(.Items.Count - 1).SubItems().Add("BLOKIR")
                        .Items(i).BackColor = Color.Pink
                    Case "4"
                        .Items(.Items.Count - 1).SubItems().Add("TUTUP")
                        .Items(i).BackColor = Color.Khaki
                End Select
            Next
        End With
    End Sub

    Private Sub master_rekening_tabungan_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tfilter.Focus()
    End Sub

    Private Sub master_rekening_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub master_rekening_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()

        ukuran()
        tampil()
        Me.ResizeRedraw = True
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        With rekening_tabungan
            .kosong()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnkoreksi_Click(sender As Object, e As EventArgs) Handles btnkoreksi.Click
        pilih()
    End Sub

    Private Sub master_rekening_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub master_rekening_tabungan_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = MDIParent1.Width - 20
        Me.Height = MDIParent1.Height - 177
    End Sub

    Private Sub tfilter_TextChanged(sender As Object, e As EventArgs) Handles tfilter.TextChanged
        If Len(tfilter.Text) = 0 Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
    End Sub

    Private Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        If Len(tfilter.Text) < 1 Then
            tampil()
        Else
            cari()
        End If
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

    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        If e.Column <> sortcolumn Then
            sortcolumn = e.Column
            ListView1.Sorting = SortOrder.Ascending
        Else
            If ListView1.Sorting = SortOrder.Ascending Then
                ListView1.Sorting = SortOrder.Descending
            Else
                ListView1.Sorting = SortOrder.Ascending
            End If
        End If

        ' Me.ListView1.ListViewItemSorter = New listviewcomparer(e.Column, ListView1.Sorting)
        'ListView1.Sort()


        
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        pilih()
    End Sub
    Sub pilih()
        With rekening_tabungan
            .kosong()
            .tno_rekening1.Text = kode
            Try
                rd.Close()
            Catch ex As Exception

            End Try

            .cekdatarekening()
            .ShowDialog()
        End With
    End Sub
    Sub hapus()
        cd = New MySqlCommand("DELETE FROM data_tabungan_rekening WHERE rek_tab_no_rekening ='" & kode & "'", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Master Rekening Tabungan (rek_tab_no_rekening : " + kode + ")"
        insert_log_user()

        btnfilter.PerformClick()
        btnhapus.Enabled = False
        btnkoreksi.Enabled = False
        MessageBox.Show("Master Rekening Tabungan berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus Master Rekening Tabungan ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cd = New MySqlCommand("SELECT rek_tab_status FROM data_tabungan_rekening WHERE rek_tab_no_rekening='" & kode & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            If rd.Item("rek_tab_status") <> "0" Then
                rd.Close()
                'tidak bisa dihapus
                MessageBox.Show("Master Rekening Tabungan ini tidak dapat dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                rd.Close()
                hapus()
            End If
            rd.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tfilter.Clear()
        tfilter.Focus()
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
End Class