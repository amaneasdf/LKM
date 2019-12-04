Imports MySql.Data.MySqlClient
Public Class setup_marketing
    Dim array(99), arr(99) As String

    Private Sub setup_marketing_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tkode_markening.Focus()
    End Sub

    Private Sub setup_marketing_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnkeluar.PerformClick()
    End Sub

    Private Sub setup_marketing_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub setup_marketing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        data()
        kosong()
        Me.ResizeRedraw = True
    End Sub

    Sub kosong()
        tkode_markening.Clear()
        tnama_marketing.Clear()
        btnafiliasi.Enabled = False
        btnhapus.Enabled = False
        tkode_markening.Enabled = True
        tkode_markening.Focus()
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Kode", 50, HorizontalAlignment.Center)
            .Add("Nama Marketing", 450, HorizontalAlignment.Left)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT * FROM data_marketing ORDER BY marketing_kode ASC", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("marketing_kode"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("marketing_nama"))
            Next
        End With
    End Sub

    Private Sub tkode_markening_GotFocus(sender As Object, e As EventArgs) Handles tkode_markening.GotFocus, tnama_marketing.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tkode_markening_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tkode_markening.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tkode_markening_LostFocus(sender As Object, e As EventArgs) Handles tkode_markening.LostFocus, tnama_marketing.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub tkode_markening_TextChanged(sender As Object, e As EventArgs) Handles tkode_markening.TextChanged
        If tkode_markening.Enabled = False Then
            btnafiliasi.Enabled = True
        Else
            btnafiliasi.Enabled = False
        End If
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tkode_markening.Text = "" Then
            MessageBox.Show("Kode Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_markening.Focus()
            Exit Sub
        ElseIf Len(tkode_markening.Text) < 3 Then
            MessageBox.Show("Panjang Kode harus 3.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_markening.Focus()
            Exit Sub
        ElseIf tnama_marketing.Text = "" Then
            MessageBox.Show("Nama Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_marketing.Focus()
            Exit Sub
        End If
        cd = New MySqlCommand("SELECT * FROM data_marketing WHERE marketing_kode='" & tkode_markening.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True And tkode_markening.Enabled = True Then
            rd.Close()
            MessageBox.Show("Kode Marketing sudah Ada", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_markening.Focus()
        Else
            rd.Close()
            If tkode_markening.Enabled = True Then
                simpan()
            Else
                edit()
            End If
            btnhapus.Enabled = True
            btnafiliasi.Enabled = True
        End If
    End Sub

    Sub ar()
        array(0) = tkode_markening.Text
        array(1) = tnama_marketing.Text
        array(2) = 1
        array(3) = MDIParent1.username.Text
        array(4) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        array(5) = MDIParent1.username.Text
        array(6) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")

        arr(0) = "marketing_kode='" + array(0) + "'"
        arr(1) = "marketing_nama='" + array(1) + "'"
        arr(2) = "marketing_status='" + array(2) + "'"
        arr(3) = "marketing_reg_username='" + array(3) + "'"
        arr(4) = "marketing_reg_waktu='" + array(4) + "'"
        arr(5) = "marketing_update_username='" + array(5) + "'"
        arr(6) = "marketing_update_waktu='" + array(6) + "'"
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
        cd = New MySqlCommand("INSERT INTO data_marketing VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Setup Marketing (marketing_kode : " + array(0) + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Marketing berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        tkode_markening.Enabled = False
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
        cd = New MySqlCommand("UPDATE data_marketing SET " & gabung & " WHERE " & arr(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Setup Marketing (marketing_kode : " + array(0) + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Marketing berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Sub hapus()
        ar()
        cd = New MySqlCommand("DELETE FROM data_marketing WHERE " & arr(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Setup Marketing (marketing_kode : " + array(0) + ")"
        insert_log_user()

        data()
        kosong()
        MessageBox.Show("Master Data Marketing berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kosong()
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        pilih()
    End Sub

    Sub pilih()
        With ListView1.SelectedItems.Item(0)
            tkode_markening.Text = .Text
            tnama_marketing.Text = .SubItems(1).Text
        End With
        btnafiliasi.Enabled = True
        btnhapus.Enabled = True
        tkode_markening.Enabled = False
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            pilih()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus data Marketing ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cd = New MySqlCommand("SELECT (SELECT IFNULL(COUNT(*), 0) FROM data_tabungan_rekening WHERE rek_tab_kode_marketing='" & tkode_markening.Text & "') AS rekening_tabungan, (SELECT IFNULL(COUNT(*), 0) FROM data_kredit_pelengkap WHERE pelengkap_marketing='" & tkode_markening.Text & "') AS kredit_pelengkap", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            If rd.Item("rekening_tabungan") <> "0" Or rd.Item("kredit_pelengkap") <> "0" Then
                rd.Close()
                'tidak bisa dihapus
                MessageBox.Show("Master Marketing ini tidak dapat dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                rd.Close()
                hapus()
            End If
            rd.Close()
        End If
    End Sub

    Private Sub setup_marketing_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnafiliasi_Click(sender As Object, e As EventArgs) Handles btnafiliasi.Click
        With afiliasi
            .Label3.Text = "marketing"
            .tkode.Text = tkode_markening.Text
            .tnama.Text = tnama_marketing.Text
            .ShowDialog()
        End With
    End Sub
End Class