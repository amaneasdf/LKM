Imports MySql.Data.MySqlClient
Public Class setup_kolektor
    Dim array(99), arr(99) As String

    Private Sub tkode_kolektor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tkode_kolektor.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tnama_kolektor_GotFocus(sender As Object, e As EventArgs) Handles tnama_kolektor.GotFocus, tkode_kolektor.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tnama_kolektor_LostFocus(sender As Object, e As EventArgs) Handles tnama_kolektor.LostFocus, tkode_kolektor.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub setup_kolektor_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tkode_kolektor.Focus()
    End Sub

    Private Sub setup_kolektor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnkeluar.PerformClick()
    End Sub

    Private Sub setup_kolektor_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub setup_kolektor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        data()
        kosong()
        Me.ResizeRedraw = True
    End Sub
    Sub kosong()
        tkode_kolektor.Clear()
        tnama_kolektor.Clear()
        btnafiliasi.Enabled = False
        btnhapus.Enabled = False
        tkode_kolektor.Enabled = True
        tkode_kolektor.Focus()
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Kode", 50, HorizontalAlignment.Center)
            .Add("Nama Kolektor", 450, HorizontalAlignment.Left)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT * FROM data_kolektor ORDER BY kolektor_kode ASC", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("kolektor_kode"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kolektor_nama"))
            Next
        End With
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tkode_kolektor.Text = "" Then
            MessageBox.Show("Kode Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_kolektor.Focus()
            Exit Sub
        ElseIf Len(tkode_kolektor.Text) < 3 Then
            MessageBox.Show("Panjang Kode harus 3.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_kolektor.Focus()
            Exit Sub
        ElseIf tnama_kolektor.Text = "" Then
            MessageBox.Show("Nama Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_kolektor.Focus()
            Exit Sub
        End If
        cd = New MySqlCommand("SELECT * FROM data_kolektor WHERE kolektor_kode='" & tkode_kolektor.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True And tkode_kolektor.Enabled = True Then
            rd.Close()
            MessageBox.Show("Kode Kolektor sudah Ada", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_kolektor.Focus()
        Else
            rd.Close()
            If tkode_kolektor.Enabled = True Then
                simpan()
            Else
                edit()
            End If
            btnhapus.Enabled = True
            btnafiliasi.Enabled = True
        End If
    End Sub
    Sub ar()
        array(0) = tkode_kolektor.Text
        array(1) = tnama_kolektor.Text
        array(2) = 1
        array(3) = MDIParent1.username.Text
        array(4) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        array(5) = MDIParent1.username.Text
        array(6) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")

        arr(0) = "kolektor_kode='" + array(0) + "'"
        arr(1) = "kolektor_nama='" + array(1) + "'"
        arr(2) = "kolektor_status='" + array(2) + "'"
        arr(3) = "kolektor_reg_username='" + array(3) + "'"
        arr(4) = "kolektor_reg_waktu='" + array(4) + "'"
        arr(5) = "kolektor_update_username='" + array(5) + "'"
        arr(6) = "kolektor_update_waktu='" + array(6) + "'"
    End Sub
    Sub simpan()
        ar()
        Dim gabung = ""
        For n = 0 To 6
            If n = 0 Then
                gabung += "'" + array(n) + "'"
            Else
                gabung += ",'" + array(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_kolektor VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Setup Kolektor (kolektor_kode : " + array(0) + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Kolektor berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        tkode_kolektor.Enabled = False
        btntambah.Focus()
    End Sub
    Sub edit()
        ar()
        Dim gabung = ""
        For n = 1 To 6
            If n = 1 Then
                gabung += arr(n)
            ElseIf n = 2 Or n = 3 Or n = 4 Then

            Else
                gabung += "," + arr(n)
            End If
        Next
        cd = New MySqlCommand("UPDATE data_kolektor SET " & gabung & " WHERE " & arr(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Setup Kolektor (kolektor_kode : " + array(0) + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Kolektor berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Sub hapus()
        ar()
        cd = New MySqlCommand("DELETE FROM data_kolektor WHERE " & arr(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Setup Kolektor (kolektor_kode : " + array(0) + ")"
        insert_log_user()

        data()
        kosong()
        MessageBox.Show("Master Data Kolektor berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kosong()
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        pilih()
    End Sub
    Sub pilih()
        With ListView1.SelectedItems.Item(0)
            tkode_kolektor.Text = .Text
            tnama_kolektor.Text = .SubItems(1).Text
        End With
        btnafiliasi.Enabled = True
        btnhapus.Enabled = True
        tkode_kolektor.Enabled = False
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus data Kolektor ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cd = New MySqlCommand("SELECT (SELECT IFNULL(COUNT(*), 0) FROM data_tabungan_rekening WHERE rek_tab_kode_kolektor='" & tkode_kolektor.Text & "') AS rekening_tabungan, (SELECT IFNULL(COUNT(*), 0) FROM data_kredit_pelengkap WHERE pelengkap_kolektor='" & tkode_kolektor.Text & "') AS kredit_pelengkap", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            If rd.Item("rekening_tabungan") <> "0" Or rd.Item("kredit_pelengkap") <> "0" Then
                rd.Close()
                'tidak bisa dihapus
                MessageBox.Show("Master Kolektor ini tidak dapat dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                rd.Close()
                hapus()
            End If
            rd.Close()
        End If
    End Sub

    Private Sub setup_kolektor_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
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
            .Label3.Text = "kolektor"
            .tkode.Text = tkode_kolektor.Text
            .tnama.Text = tnama_kolektor.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub tkode_kolektor_TextChanged(sender As Object, e As EventArgs) Handles tkode_kolektor.TextChanged
        If tkode_kolektor.Enabled = False Then
            btnafiliasi.Enabled = True
        Else
            btnafiliasi.Enabled = False
        End If
    End Sub
End Class