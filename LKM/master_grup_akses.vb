Imports MySql.Data.MySqlClient
Public Class master_grup_akses
    Dim kode As String
    Dim sortcolumn As Integer = -1
    Dim array(99) As String

    Private Sub master_grup_akses_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub master_grup_akses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        data()
        Me.ResizeRedraw = True
        btntambah.Focus()
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Kode", 50, HorizontalAlignment.Left)
            .Add("Nama Grup", 200, HorizontalAlignment.Left)
            .Add("Jumlah Menu", 100, HorizontalAlignment.Center)
            .Add("Keterangan", 300, HorizontalAlignment.Left)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT *, (SELECT COUNT(*) FROM kode_menu WHERE menu_group=grup_akses_kode) AS jumlah FROM data_grup_akses ORDER BY grup_akses_kode ASC", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("grup_akses_kode"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("grup_akses_nama"))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("jumlah"), 0))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("grup_akses_keterangan"))
            Next
        End With
        btnhapus.Enabled = False
        btnkoreksi.Enabled = False
    End Sub

    Private Sub master_grup_akses_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub master_grup_akses_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = MDIParent1.Width - 20
        Me.Height = MDIParent1.Height - 177
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        With setup_grup_pengguna
            .kosong()
            .Label5.Text = "tambah"
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

    Sub pilih()
        cd = New MySqlCommand("SELECT * FROM data_grup_akses WHERE grup_akses_kode='" & kode & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Array(0) = rd.Item("grup_akses_kode")
        array(1) = rd.Item("grup_akses_nama")
        array(2) = rd.Item("grup_akses_keterangan")
        rd.Close()
        With setup_grup_pengguna
            .kosong()
            .tkode_grup.Text = array(0)
            .tnama_grup.Text = array(1)
            .tketerangan.Text = array(2)
            .Label5.Text = "edit"
            .ShowDialog()
        End With
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        pilih()
    End Sub

    Private Sub btnkoreksi_Click(sender As Object, e As EventArgs) Handles btnkoreksi.Click
        pilih()
    End Sub
    Sub hapus()
        Try
            rd.Close()
        Catch ex As Exception

        End Try
        cd = New MySqlCommand("DELETE FROM data_grup_akses WHERE grup_akses_kode='" & kode & "'", koneksi)
        cd.ExecuteNonQuery()
        cd = New MySqlCommand("DELETE FROM kode_menu WHERE menu_group='" & kode & "'", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Grup Akses (grup_akses_kode : " + kode + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Setup Grup Akses berhasil dihapus.", "Micro Finance Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus Master Grup Akses ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cd = New MySqlCommand("SELECT IFNULL(COUNT(*), 0) AS jumlah FROM data_pengguna WHERE pengguna_grup_akses='" & kode & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            If rd.Item("jumlah") <> "0" Then
                rd.Close()
                'tidak bisa dihapus
                MessageBox.Show("Master Grup Akses ini tidak dapat dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                rd.Close()
                hapus()
            End If
            rd.Close()
        End If
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