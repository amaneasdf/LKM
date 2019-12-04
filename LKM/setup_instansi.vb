Imports MySql.Data.MySqlClient
Public Class setup_instansi
    Dim array(99), arr(99) As String
    Dim sortcolumn As Integer = -1

    Private Sub tkode_instansi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tkode_instansi.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tjuru_bayar_GotFocus(sender As Object, e As EventArgs) Handles tjuru_bayar.GotFocus, tnama_instansi.GotFocus, tkode_instansi.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tjuru_bayar_LostFocus(sender As Object, e As EventArgs) Handles tjuru_bayar.LostFocus, tkode_instansi.LostFocus, tnama_instansi.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub setup_instansi_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tkode_instansi.Focus()
    End Sub

    Private Sub setup_instansi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub setup_instansi_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub setup_instansi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        data()
        kosong()
        Me.ResizeRedraw = True
    End Sub

    Sub kosong()
        tkode_instansi.Clear()
        tnama_instansi.Clear()
        tjuru_bayar.Clear()
        btnafiliasi.Enabled = False
        btnhapus.Enabled = False
        tkode_instansi.Enabled = True
        tkode_instansi.Focus()
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Kode", 50, HorizontalAlignment.Center)
            .Add("Nama Instansi", 250, HorizontalAlignment.Left)
            .Add("Juru Bayar", 200, HorizontalAlignment.Left)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT * FROM data_instansi ORDER BY instansi_kode ASC", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("instansi_kode"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("instansi_nama"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("instansi_juru_bayar"))
            Next
        End With
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tkode_instansi.Text = "" Then
            MessageBox.Show("Kode Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_instansi.Focus()
            Exit Sub
        ElseIf Len(tkode_instansi.Text) < 3 Then
            MessageBox.Show("Panjang Kode harus 3.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_instansi.Focus()
            Exit Sub
        ElseIf tnama_instansi.Text = "" Then
            MessageBox.Show("Nama Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_instansi.Focus()
            Exit Sub
        ElseIf tjuru_bayar.Text = "" Then
            MessageBox.Show("juru Bayar Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjuru_bayar.Focus()
            Exit Sub
        End If
        cd = New MySqlCommand("SELECT * FROM data_instansi WHERE instansi_kode='" & tkode_instansi.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True And tkode_instansi.Enabled = True Then
            rd.Close()
            MessageBox.Show("Kode Instansi sudah Ada", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_instansi.Focus()
        Else
            rd.Close()
            If tkode_instansi.Enabled = True Then
                simpan()
            Else
                edit()
            End If
            btnhapus.Enabled = True
            btnafiliasi.Enabled = True
        End If
    End Sub
    Sub ar()
        array(0) = tkode_instansi.Text
        array(1) = tnama_instansi.Text
        array(2) = tjuru_bayar.Text
        array(3) = 1
        array(4) = MDIParent1.username.Text
        array(5) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        array(6) = MDIParent1.username.Text
        array(7) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")

        arr(0) = "instansi_kode='" + array(0) + "'"
        arr(1) = "instansi_nama='" + array(1) + "'"
        arr(2) = "instansi_juru_bayar='" + array(2) + "'"
        arr(3) = "instansi_status='" + array(3) + "'"
        arr(4) = "instansi_reg_username='" + array(4) + "'"
        arr(5) = "instansi_reg_waktu='" + array(5) + "'"
        arr(6) = "instansi_update_username='" + array(6) + "'"
        arr(7) = "instansi_update_waktu='" + array(7) + "'"
    End Sub
    Sub simpan()
        ar()
        Dim gabung = ""
        For n = 0 To 7
            If n = 0 Then
                gabung += "'" + array(n) + "'"
            Else
                gabung += ",'" + array(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_instansi VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Setup Instansi (instansi_kode : " + array(0) + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Instansi berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        tkode_instansi.Enabled = False
        btntambah.Focus()
    End Sub
    Sub edit()
        ar()
        Dim gabung = ""
        For n = 1 To 7
            If n = 1 Then
                gabung += arr(n)
            ElseIf n = 3 Or n = 4 Or n = 5 Then

            Else
                gabung += "," + arr(n)
            End If
        Next
        cd = New MySqlCommand("UPDATE data_instansi SET " & gabung & " WHERE " & arr(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Setup Instansi (instansi_kode : " + array(0) + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Instansi berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Sub hapus()
        ar()
        cd = New MySqlCommand("DELETE FROM data_instansi WHERE " & arr(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Setup Instansi (instansi_kode : " + array(0) + ")"
        insert_log_user()

        data()
        kosong()
        MessageBox.Show("Master Data Instansi berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kosong()
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        pilih()
    End Sub
    Sub pilih()
        With ListView1.SelectedItems.Item(0)
            tkode_instansi.Text = .Text
            tnama_instansi.Text = .SubItems(1).Text
            tjuru_bayar.Text = .SubItems(2).Text
        End With
        btnafiliasi.Enabled = True
        btnhapus.Enabled = True
        tkode_instansi.Enabled = False
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus data Instansi ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cd = New MySqlCommand("SELECT (SELECT IFNULL(COUNT(*), 0) FROM data_tabungan_rekening WHERE rek_tab_kode_instansi='" & tkode_instansi.Text & "') AS rekening_tabungan, (SELECT IFNULL(COUNT(*), 0) FROM data_kredit_pelengkap WHERE pelengkap_instansi='" & tkode_instansi.Text & "') AS kredit_pelengkap", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            If rd.Item("rekening_tabungan") <> "0" Or rd.Item("kredit_pelengkap") <> "0" Then
                rd.Close()
                'tidak bisa dihapus
                MessageBox.Show("Master Instansi ini tidak dapat dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                rd.Close()
                hapus()
            End If
            rd.Close()
        End If
    End Sub

    Private Sub setup_instansi_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
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

    Private Sub tkode_instansi_TextChanged(sender As Object, e As EventArgs) Handles tkode_instansi.TextChanged
        If tkode_instansi.Enabled = False Then
            btnafiliasi.Enabled = True
        Else
            btnafiliasi.Enabled = False
        End If
    End Sub

    Private Sub btnafiliasi_Click(sender As Object, e As EventArgs) Handles btnafiliasi.Click
        With afiliasi
            .Label3.Text = "instansi"
            .tkode.Text = tkode_instansi.Text
            .tnama.Text = tnama_instansi.Text
            .ShowDialog()
        End With
    End Sub
End Class