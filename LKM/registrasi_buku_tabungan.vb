Imports MySql.Data.MySqlClient
Public Class registrasi_buku_tabungan
    Dim kode As String
    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub registrasi_buku_tabungan_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tno_buku.Focus()
    End Sub

    Private Sub registrasi_buku_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub registrasi_buku_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        Me.ResizeRedraw = True
    End Sub

    Private Sub registrasi_buku_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("No Buku", 100, HorizontalAlignment.Left)
            .Add("Tgl Terbit", 100, HorizontalAlignment.Left)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT * FROM data_tabungan_buku WHERE buku_no_rekening='" & tno_rekening.Text & "' ORDER BY buku_tanggal ASC", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("buku_no"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("buku_tanggal"))
            Next
        End With
    End Sub

    Private Sub tno_buku_GotFocus(sender As Object, e As EventArgs) Handles tno_buku.GotFocus
        tno_buku.BackColor = warna_gotfocus
    End Sub

    Private Sub tno_buku_LostFocus(sender As Object, e As EventArgs) Handles tno_buku.LostFocus
        tno_buku.BackColor = warna_lostfocus
    End Sub

    Private Sub tno_buku_TextChanged(sender As Object, e As EventArgs) Handles tno_buku.TextChanged

    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        If tno_buku.Text = "" Then
            MessageBox.Show("No Buku harus diisi.", "Micro Finance Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tno_buku.Focus()
            Exit Sub
        End If
        cd = New MySqlCommand("SELECT * FROM data_tabungan_buku WHERE buku_no='" & tno_buku.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True Then
            rd.Close()
            MessageBox.Show("Buku Tabungan sudah digunakan", "Micro Finance Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tno_buku.Focus()
        Else
            rd.Close()
            cd = New MySqlCommand("INSERT INTO data_tabungan_buku values ('" & tno_buku.Text & "','" & tno_rekening.Text & "','" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd") & "', '" & MDIParent1.username.Text & "', '" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "', '1')", koneksi)
            cd.ExecuteNonQuery()

            user_pengguna = MDIParent1.username.Text
            uraian = "Menambah Buku Tabungan (buku_no : " + tno_buku.Text + ")"
            insert_log_user()

            bukutabungan()

            data()
            MessageBox.Show("Buku Tabungan berhasil ditambahkan.", "Micro Finance Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tno_buku.Clear()
            tno_buku.Focus()
        End If

    End Sub
    Sub pilih()
        With ListView1.SelectedItems.Item(0)
            kode = .Text
        End With
        btnhapus.Enabled = True
    End Sub
    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        pilih()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            pilih()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus data Buku Tabungan ini?", "Pilihan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            hapus()
        End If
    End Sub
    Sub hapus()
        cd = New MySqlCommand("DELETE FROM data_tabungan_buku WHERE buku_no='" & kode & "'", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Buku Tabungan (buku_no : " + kode + ")"
        insert_log_user()

        data()
        bukutabungan()
        MessageBox.Show("Data Buku Tabungan berhasil dihapus.", "Micro Finance Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information)
        btnhapus.Enabled = False
        tno_buku.Focus()
    End Sub

    Sub bukutabungan()
        cd = New MySqlCommand("SELECT cari_buku_tabungan('" & tno_rekening.Text & "') AS buku_no", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        rekening_tabungan.tno_buku.Text = rd.Item("buku_no")
        rd.Close()
    End Sub
End Class