Imports MySql.Data.MySqlClient
Public Class setup_pegawai
    Dim data_ke(99), data_edit(99) As String

    Private Sub setup_pegawai_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tkode_pegawai.Focus()
    End Sub

    Private Sub setup_pegawai_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub setup_pegawai_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Sub setup_pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo()
        ukuran()
        data()
        kosong()
        Me.ResizeRedraw = True
        tkode_pegawai.Focus()
    End Sub
    Sub combo()
        cd = New MySqlCommand("CALL isi_combo('92')", koneksi)
        rd = cd.ExecuteReader
        With cmbstruktur.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()
    End Sub
    Sub kosong()
        tkode_pegawai.Clear()
        cmbstruktur.Text = ""
        tjabatan.Clear()
        tnama.Clear()
        talamat.Clear()
        tnik.Clear()
        tmobile.Clear()
        btnhapus.Enabled = False
        tkode_pegawai.Enabled = True
        tkode_pegawai.Focus()
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Kode", 50, HorizontalAlignment.Center)
            .Add("Jabatan", 150, HorizontalAlignment.Left)
            .Add("Nama Lengkap", 250, HorizontalAlignment.Left)
            .Add("NIK", 150, HorizontalAlignment.Left)
            .Add("No. Mobile", 100, HorizontalAlignment.Left)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT * FROM data_pegawai ORDER BY pegawai_kode", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("pegawai_kode"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("pegawai_jabatan"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("pegawai_nama"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("pegawai_nik"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("pegawai_mobile"))
            Next
        End With
    End Sub

    Private Sub setup_pegawai_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub cmbstruktur_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbstruktur.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbstruktur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstruktur.SelectedIndexChanged
        tjabatan.Text = Microsoft.VisualBasic.Right(cmbstruktur.Text, Len(cmbstruktur.Text) - Len(cmbstruktur.Text.ToString.Split(" : ")(0)) - 3)
    End Sub

    Private Sub tmobile_GotFocus(sender As Object, e As EventArgs) Handles tmobile.GotFocus, tnik.GotFocus, talamat.GotFocus, tnama.GotFocus, tjabatan.GotFocus, cmbstruktur.GotFocus, tkode_pegawai.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tmobile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tmobile.KeyPress, tnik.KeyPress, tkode_pegawai.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tmobile_LostFocus(sender As Object, e As EventArgs) Handles tmobile.LostFocus, tnik.LostFocus, talamat.LostFocus, tnama.LostFocus, tjabatan.LostFocus, cmbstruktur.LostFocus, tkode_pegawai.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kosong()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tkode_pegawai.Text = "" Then
            MessageBox.Show("Kode Pegawai Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_pegawai.Focus()
            Exit Sub
        ElseIf cmbstruktur.Text = "" Then
            MessageBox.Show("Truktur Pegawai Harus Dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbstruktur.Focus()
            Exit Sub
        ElseIf tjabatan.Text = "" Then
            MessageBox.Show("Jabatan Pegawai Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjabatan.Focus()
            Exit Sub
        ElseIf tnama.Text = "" Then
            MessageBox.Show("Nama Pegawai Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama.Focus()
            Exit Sub
        ElseIf tnik.Text = "" Then
            MessageBox.Show("NIK Pegawai Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnik.Focus()
            Exit Sub
        End If
        cd = New MySqlCommand("SELECT * FROM data_pegawai WHERE pegawai_kode='" & tkode_pegawai.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True And tkode_pegawai.Enabled = True Then
            rd.Close()
            MessageBox.Show("Kode Instansi sudah Ada", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_pegawai.Focus()
        Else
            rd.Close()
            If tkode_pegawai.Enabled = True Then
                simpan()
            Else
                edit()
            End If
            btnhapus.Enabled = True
        End If
    End Sub

    Sub ar()
        data_ke(0) = tkode_pegawai.Text
        data_ke(1) = cmbstruktur.Text.ToString.Split(" :")(0)
        data_ke(2) = tjabatan.Text
        data_ke(3) = tnama.Text
        data_ke(4) = talamat.Text
        data_ke(5) = tnik.Text
        data_ke(6) = tmobile.Text
        data_ke(7) = "1"
        data_ke(8) = MDIParent1.username.Text
        data_ke(9) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        data_ke(10) = MDIParent1.username.Text
        data_ke(11) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")

        data_edit(0) = "pegawai_kode='" + data_ke(0) + "'"
        data_edit(1) = "pegawai_struktur='" + data_ke(1) + "'"
        data_edit(2) = "pegawai_jabatan='" + data_ke(2) + "'"
        data_edit(3) = "pegawai_nama='" + data_ke(3) + "'"
        data_edit(4) = "pegawai_alamat='" + data_ke(4) + "'"
        data_edit(5) = "pegawai_nik='" + data_ke(5) + "'"
        data_edit(6) = "pegawai_mobile='" + data_ke(6) + "'"
        data_edit(7) = "pegawai_status='" + data_ke(7) + "'"
        data_edit(8) = "pegawai_reg_username='" + data_ke(8) + "'"
        data_edit(9) = "pegawai_reg_waktu='" + data_ke(9) + "'"
        data_edit(10) = "pegawai_update_username='" + data_ke(10) + "'"
        data_edit(11) = "pegawai_update_waktu='" + data_ke(11) + "'"
    End Sub
    Sub simpan()
        ar()
        Dim gabung = ""
        For n = 0 To 11
            If n = 0 Then
                gabung += "'" + data_ke(n) + "'"
            Else
                gabung += ",'" + data_ke(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_pegawai VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Setup Pegawai (pegawai_kode : " + data_ke(0) + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Pegawai berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        tkode_pegawai.Enabled = False
        btntambah.Focus()
    End Sub
    Sub edit()
        ar()
        Dim gabung = ""
        For n = 1 To 6
            If n = 1 Then
                gabung += data_edit(n)
            ElseIf n = 7 Or n = 8 Or n = 9 Then

            Else
                gabung += " ," + data_edit(n)
            End If
        Next
        cd = New MySqlCommand("UPDATE data_pegawai SET " & gabung & " WHERE " & data_edit(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Setup Pegawai (pegawai_kode : " + data_ke(0) + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Pegawai berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Sub hapus()
        ar()
        cd = New MySqlCommand("DELETE FROM data_pegawai WHERE pegawai_kode='" & tkode_pegawai.Text & "'", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Setup Pegawai (pegawai_kode : " + tkode_pegawai.Text + ")"
        insert_log_user()

        data()
        kosong()
        MessageBox.Show("Master Data Pegawai berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        pilih()
    End Sub
    Sub pilih()
        With ListView1.SelectedItems.Item(0)
            tkode_pegawai.Text = .Text
        End With
        caripegawai()
        btnhapus.Enabled = True
        tkode_pegawai.Enabled = False
    End Sub
    Sub caripegawai()
        cd = New MySqlCommand("SELECT *, cari_combo_komponen('92',pegawai_struktur) AS struktur FROM data_pegawai WHERE pegawai_kode='" & tkode_pegawai.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbstruktur.Text = rd.Item("struktur")
        tjabatan.Text = rd.Item("pegawai_jabatan")
        tnama.Text = rd.Item("pegawai_nama")
        talamat.Text = rd.Item("pegawai_alamat")
        tnik.Text = rd.Item("pegawai_nik")
        tmobile.Text = rd.Item("pegawai_mobile")
        rd.Close()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus data Pegawai ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cd = New MySqlCommand("SELECT IFNULL(COUNT(*), 0) AS jml FROM setup_ttd WHERE ttd_pegawai_kode='" & tkode_pegawai.Text & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            If rd.Item("jml") <> "0" Then
                rd.Close()
                'tidak bisa dihapus
                MessageBox.Show("Master Pegawai ini tidak dapat dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                rd.Close()
                hapus()
            End If
            rd.Close()
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            pilih()
        Catch ex As Exception

        End Try
    End Sub
End Class