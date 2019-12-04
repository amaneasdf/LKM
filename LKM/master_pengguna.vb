Imports MySql.Data.MySqlClient
Public Class master_pengguna
    Dim kode, status As String
    Dim sortcolumn As Integer = -1

    Private Sub master_pengguna_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub master_pengguna_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub master_pengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        ukuran()
        data()
        Me.ResizeRedraw = True
        btntambah.Focus()
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Username", 100, HorizontalAlignment.Left)
            .Add("Kode Teller", 100, HorizontalAlignment.Left)
            .Add("Nama Lengkap", 300, HorizontalAlignment.Left)
            .Add("Grup Akses", 200, HorizontalAlignment.Left)
            .Add("Status", 100, HorizontalAlignment.Center)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT *, (SELECT grup_akses_nama FROM data_grup_akses WHERE grup_akses_kode=pengguna_grup_akses) AS grup_akses_nama FROM data_pengguna ORDER BY pengguna_username", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("pengguna_username"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("pengguna_teller"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("pengguna_nama_lengkap"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("grup_akses_nama"))
                Select Case dt.Rows(i)("pengguna_status")
                    Case "0"
                        .Items(.Items.Count - 1).SubItems().Add("NONE")
                    Case "1"
                        .Items(.Items.Count - 1).SubItems().Add("AKTIF")
                End Select
            Next
        End With
        btnhapus.Enabled = False
        btnkoreksi.Enabled = False
    End Sub

    Private Sub master_pengguna_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub master_pengguna_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = MDIParent1.Width - 20
        Me.Height = MDIParent1.Height - 177
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        With data_pengguna
            .kosong()
            .combo()
            .pass()
            .cmbstatus.Text = "0 : NONE"
            .ShowDialog()
        End With
    End Sub
    Sub pilih()
        cd = New MySqlCommand("SELECT *, (SELECT concat_ws (' : ', grup_akses_kode, grup_akses_nama) FROM data_grup_akses WHERE grup_akses_kode=pengguna_grup_akses) AS grupakses FROM data_pengguna WHERE pengguna_username='" & kode & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim array(99) As String
        array(0) = rd.Item("pengguna_username")
        array(1) = rd.Item("pengguna_nama_lengkap")
        array(2) = rd.Item("pengguna_password")
        array(3) = rd.Item("pengguna_grup_akses")
        array(4) = rd.Item("pengguna_status")

        array(5) = rd.Item("grupakses")
        array(6) = rd.Item("pengguna_teller")
        rd.Close()
        With data_pengguna
            .kosong()
            .combo()
            .tnama_alias.Enabled = False
            .tnama_alias.Text = array(0)
            .tkode_teller.Text = array(6)
            .tnama_lengkap.Text = array(1)
            '.tpassword.Text = array(2)
            .cmbgrup_akses.Text = array(5)
            .cmbstatus.Items.Clear()
            Select Case array(4)
                Case "0"
                    .cmbstatus.Enabled = False
                    .cmbstatus.Text = "0 : NONE"
                Case "1"
                    .cmbstatus.Enabled = True
                    .cmbstatus.Text = "1 : AKTIF"
                    .cmbstatus.Items.Add("1 : AKTIF")
                    '.cmbstatus.Items.Add("2 : BLOKIR")
                    '.cmbstatus.Items.Add("3 : EXPIRE")
                    '.cmbstatus.Items.Add("5 : NONAKTIF")
                Case "2"
                    .cmbstatus.Enabled = True
                    .cmbstatus.Text = "2 : BLOKIR"
                    .cmbstatus.Items.Add("1 : AKTIF")
                    .cmbstatus.Items.Add("2 : BLOKIR")
                    .cmbstatus.Items.Add("5 : NONAKTIF")
                Case "3"
                    .cmbstatus.Enabled = False
                    .cmbstatus.Text = "3 : EXPIRE"
                Case "5"
                    .cmbstatus.Enabled = False
                    .cmbstatus.Text = "5 : NONAKTIF"
            End Select
            Try
                cd = New MySqlCommand("SELECT * FROM data_pengguna_gambar WHERE gambar_pengguna_username='" & array(0) & "'", koneksi)
                rd = cd.ExecuteReader
                rd.Read()

                Dim arrImage() As Byte
                arrImage = rd.Item("gambar_file")
                Dim ms As New IO.MemoryStream(CType(arrImage, Byte()))

                rd.Close()
                .PictureBox1.Image = Image.FromStream(ms)
                .Label7.Text = "1"
            Catch ex As Exception
                .Label8.Text = "0"
            End Try
            .ShowDialog()
        End With
        rd.Close()
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

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        cd = New MySqlCommand("SELECT IFNULL(COUNT(*), 0) AS jml FROM log_user WHERE log_username='" & kode & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        If rd.Item("jml") = 0 Then
            rd.Close()
            If MessageBox.Show("Yakin ingin menghapus data Pengguna ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                hapus()
            End If
        Else
            MessageBox.Show("Master Data Pengguna tidak dapat dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        rd.Close()
    End Sub
    Sub hapus()
        Try
            rd.Close()
        Catch ex As Exception

        End Try
        cd = New MySqlCommand("DELETE FROM data_pengguna WHERE pengguna_username='" & kode & "' AND pengguna_status='0'", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Data Pengguna (pengguna_username : " + kode + ")"
        insert_log_user()


        data()
        MessageBox.Show("Master Data Pengguna berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class