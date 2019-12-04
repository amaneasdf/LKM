Imports MySql.Data.MySqlClient
Public Class setup_wilayah
    Dim array(99), arr(99) As String
    Dim sortcolumn As Integer = -1

    Private Sub ttelepon_GotFocus(sender As Object, e As EventArgs) Handles ttelepon.GotFocus, talamat_koordinator.GotFocus,  tkoordinator_wilayah.GotFocus, tnama_kecamatan.GotFocus, tnama_desa.GotFocus, tkode_wilayah.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub ttelepon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ttelepon.KeyPress, tkode_wilayah.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub ttelepon_LostFocus(sender As Object, e As EventArgs) Handles ttelepon.LostFocus, talamat_koordinator.LostFocus, tkoordinator_wilayah.LostFocus, tnama_kecamatan.LostFocus, tnama_desa.LostFocus, tkode_wilayah.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub setup_wilayah_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tkode_wilayah.Focus()
    End Sub

    Private Sub setup_wilayah_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub setup_wilayah_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub setup_wilayah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        data()
        kosong()
        Me.ResizeRedraw = True
    End Sub
    Sub kosong()
        tkode_wilayah.Clear()
        tnama_desa.Clear()
        tnama_kecamatan.Clear()
        tkoordinator_wilayah.Clear()
        talamat_koordinator.Clear()
        ttelepon.Clear()
        btnafiliasi.Enabled = False
        btnhapus.Enabled = False
        tkode_wilayah.Enabled = True
        tkode_wilayah.Focus()
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Kode", 50, HorizontalAlignment.Center)
            .Add("Nama Desa", 150, HorizontalAlignment.Left)
            .Add("Nama Kec.", 150, HorizontalAlignment.Left)
            .Add("Koor Wil", 150, HorizontalAlignment.Left)
            .Add("Alamat Koor", 250, HorizontalAlignment.Left)
            .Add("Telepon", 100, HorizontalAlignment.Left)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT * FROM data_wilayah ORDER BY wilayah_kode ASC", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("wilayah_kode"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("wilayah_nama_desa"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("wilayah_nama_kecamatan"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("wilayah_koordinator_wilayah"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("wilayah_alamat_koordinator"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("wilayah_telepon"))
            Next
        End With
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tkode_wilayah.Text = "" Then
            MessageBox.Show("Kode Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_wilayah.Focus()
            Exit Sub
        ElseIf Len(tkode_wilayah.Text) < 3 Then
            MessageBox.Show("Panjang Kode harus 3.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_wilayah.Focus()
            Exit Sub
        ElseIf tnama_desa.Text = "" Then
            MessageBox.Show("Nama Desa Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_desa.Focus()
            Exit Sub
        ElseIf tnama_kecamatan.Text = "" Then
            MessageBox.Show("Nama Kecamatan Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_kecamatan.Focus()
            Exit Sub
        ElseIf tkoordinator_wilayah.Text = "" Then
            MessageBox.Show("Koordinator Wilayah Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkoordinator_wilayah.Focus()
            Exit Sub
        End If
        cd = New MySqlCommand("SELECT * FROM data_wilayah WHERE wilayah_kode='" & tkode_wilayah.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True And tkode_wilayah.Enabled = True Then
            rd.Close()
            MessageBox.Show("Kode Wilayah sudah Ada", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_wilayah.Focus()
        Else
            rd.Close()
            If tkode_wilayah.Enabled = True Then
                simpan()
            Else
                edit()
            End If
            btnhapus.Enabled = True
            btnafiliasi.Enabled = True
        End If
    End Sub
    Sub ar()
        array(0) = tkode_wilayah.Text
        array(1) = tnama_desa.Text
        array(2) = tnama_kecamatan.Text
        array(3) = tkoordinator_wilayah.Text
        array(4) = talamat_koordinator.Text
        array(5) = ttelepon.Text
        array(6) = 1
        array(7) = MDIParent1.username.Text
        array(8) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        array(9) = MDIParent1.username.Text
        array(10) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")

        arr(0) = "wilayah_kode='" + array(0) + "'"
        arr(1) = "wilayah_nama_desa='" + array(1) + "'"
        arr(2) = "wilayah_nama_kecamatan='" + array(2) + "'"
        arr(3) = "wilayah_koordinator_wilayah='" + array(3) + "'"
        arr(4) = "wilayah_alamat_koordinator='" + array(4) + "'"
        arr(5) = "wilayah_telepon='" + array(5) + "'"
        arr(6) = "wilayah_status='" + array(6) + "'"
        arr(7) = "wilayah_reg_username='" + array(7) + "'"
        arr(8) = "wilayah_reg_waktu='" + array(8) + "'"
        arr(9) = "wilayah_update_username='" + array(9) + "'"
        arr(10) = "wilayah_update_waktu='" + array(10) + "'"
    End Sub
    Sub simpan()
        ar()
        Dim gabung = ""
        For n = 0 To 10
            If n = 0 Then
                gabung += "'" + array(n) + "'"
            Else
                gabung += ",'" + array(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_wilayah VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Setup Wilayah (wilayah_kode : " + array(0) + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Wilayah berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        tkode_wilayah.Enabled = False
        tkode_wilayah.Focus()
    End Sub
    Sub edit()
        ar()
        Dim gabung = ""
        For n = 1 To 10
            If n = 1 Then
                gabung += arr(n)
            ElseIf n = 6 Or n = 7 Or n = 8 Then

            Else
                gabung += "," + arr(n)
            End If
        Next
        cd = New MySqlCommand("UPDATE data_wilayah SET " & gabung & " WHERE " & arr(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Setup Wilayah (wilayah_kode : " + array(0) + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Wilayah berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Sub hapus()
        ar()
        cd = New MySqlCommand("DELETE FROM data_wilayah WHERE " & arr(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Setup Wilayah (wilayah_kode : " + array(0) + ")"
        insert_log_user()

        data()
        kosong()
        MessageBox.Show("Master Data Wilayah berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kosong()
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        pilih()
    End Sub

    Sub pilih()
        With ListView1.SelectedItems.Item(0)
            tkode_wilayah.Text = .Text
            tnama_desa.Text = .SubItems(1).Text
            tnama_kecamatan.Text = .SubItems(2).Text
            tkoordinator_wilayah.Text = .SubItems(3).Text
            talamat_koordinator.Text = .SubItems(4).Text
            ttelepon.Text = .SubItems(5).Text
        End With
        btnafiliasi.Enabled = True
        btnhapus.Enabled = True
        tkode_wilayah.Enabled = False
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus data Wilayah ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cd = New MySqlCommand("SELECT (SELECT IFNULL(COUNT(*), 0) FROM data_tabungan_rekening WHERE rek_tab_kode_wilayah='" & tkode_wilayah.Text & "') AS rekening_tabungan, (SELECT IFNULL(COUNT(*), 0) FROM data_kredit_pelengkap WHERE pelengkap_wilayah='" & tkode_wilayah.Text & "') AS kredit_pelengkap", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            If rd.Item("rekening_tabungan") <> "0" Or rd.Item("kredit_pelengkap") <> "0" Then
                rd.Close()
                'tidak bisa dihapus
                MessageBox.Show("Master Wilayah ini tidak dapat dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                rd.Close()
                hapus()
            End If
            rd.Close()
        End If
    End Sub

    Private Sub setup_wilayah_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            pilih()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnafiliasi_Click(sender As Object, e As EventArgs) Handles btnafiliasi.Click
        With afiliasi
            .Label3.Text = "wilayah"
            .tkode.Text = tkode_wilayah.Text
            .tnama.Text = tnama_desa.Text.ToString + ", " + tnama_kecamatan.Text.ToString
            .ShowDialog()
        End With
    End Sub
End Class