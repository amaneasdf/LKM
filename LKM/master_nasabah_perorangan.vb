Imports MySql.Data.MySqlClient
Public Class master_nasabah_perorangan
    Dim nasabahid As String

    Private Sub tfilter_GotFocus(sender As Object, e As EventArgs) Handles tfilter.GotFocus
        tfilter.BackColor = warna_gotfocus
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
    End Sub
    Sub tampil()
        btnhapus.Enabled = False
        btnkoreksi.Enabled = False
        rd.Close()
        da = New MySqlDataAdapter("SELECT *, cari_combo_komponen('09',nasabah_dati2) AS kabkot FROM data_nasabah WHERE nasabah_nama1 LIKE '%" & tfilter.Text & "%' OR nasabah_id LIKE '%" & tfilter.Text & "%' OR nasabah_nik LIKE '%" & tfilter.Text & "%' OR nasabah_alternatif LIKE '%" & tfilter.Text & "%'  ORDER BY nasabah_id", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Nasabah ID", 100, HorizontalAlignment.Left)
            .Add("Alternatif", 100, HorizontalAlignment.Left)
            .Add("Nama Nasabah", 200, HorizontalAlignment.Left)
            .Add("Alamat", 300, HorizontalAlignment.Left)
            .Add("Kelurahan", 150, HorizontalAlignment.Left)
            .Add("Kecamatan", 150, HorizontalAlignment.Left)
            .Add("Kode Pos", 80, HorizontalAlignment.Left)
            .Add("Dati2", 200, HorizontalAlignment.Left)
        End With
    End Sub

    Sub data()
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("nasabah_id"))
                .Items(i).SubItems().Add(dt.Rows(i)("nasabah_alternatif"))
                .Items(i).SubItems().Add(dt.Rows(i)("nasabah_nama1"))
                .Items(i).SubItems().Add(dt.Rows(i)("nasabah_alamat"))
                .Items(i).SubItems().Add(dt.Rows(i)("nasabah_kelurahan"))
                .Items(i).SubItems().Add(dt.Rows(i)("nasabah_kecamatan"))
                .Items(i).SubItems().Add(dt.Rows(i)("nasabah_kode_pos"))
                .Items(i).SubItems().Add(dt.Rows(i)("kabkot"))
            Next
            If .Items.Count = 0 Then
                MessageBox.Show("Data tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End With
    End Sub

    Private Sub master_nasabah_perorangan_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tfilter.Focus()
    End Sub

    Private Sub master_nasabah_perorangan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub master_nasabah_perorangan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        Me.ResizeRedraw = True
        tfilter.Focus()
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        With cek_master_nasabah
            .kosong()
            .ShowDialog()
        End With
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        listselecet()
    End Sub
    Sub listselecet()
        With ListView1.SelectedItems.Item(0)
            nasabahid = .Text
        End With
        btnhapus.Enabled = True
        btnkoreksi.Enabled = True
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        pilih()
    End Sub

    Sub pilih()
        btnkoreksi.Enabled = False
        btnhapus.Enabled = False
        With data_nasabah_perorangan
            .tnasabah_id.Text = nasabahid
            .cekdatanasabah()
            .ShowDialog()
        End With
    End Sub
    Private Sub btnkoreksi_Click(sender As Object, e As EventArgs) Handles btnkoreksi.Click
        pilih()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus Master Nasabah ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then

            cd = New MySqlCommand("SELECT (SELECT IFNULL(COUNT(*), 0) FROM data_tabungan_rekening WHERE rek_tab_nasabah_id='" & nasabahid & "') AS rekening_tabungan, (SELECT IFNULL(COUNT(*), 0) FROM data_kredit_rekening WHERE rek_kre_nasabah_id='" & nasabahid & "') AS rekening_kredit", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            If rd.Item("rekening_tabungan") <> "0" Or rd.Item("rekening_kredit") <> "0" Then
                rd.Close()
                'tidak bisa dihapus
                MessageBox.Show("Master Nasabah ini tidak dapat dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                rd.Close()
                hapus()
            End If
            rd.Close()
        End If
        If Len(tfilter.Text) > 0 Then
            btnfilter.PerformClick()
        End If
    End Sub

    Sub hapus()
        cd = New MySqlCommand("DELETE FROM data_nasabah WHERE nasabah_id='" & nasabahid & "'", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Master Nasabah (nasabah_id : " + nasabahid + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Nasabah berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub master_nasabah_perorangan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub master_nasabah_perorangan_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.TopLevel = False
        Me.ControlBox = False
        Me.Width = MDIParent1.Width - 20
        Me.Height = MDIParent1.Height - 177

    End Sub

    Private Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        If Len(tfilter.Text) < 1 Then
            MessageBox.Show("Karakter minimal 1.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            tampil()
        End If
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            pilih()
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            listselecet()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tfilter_TextChanged(sender As Object, e As EventArgs) Handles tfilter.TextChanged

    End Sub
End Class