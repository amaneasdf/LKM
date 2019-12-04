Imports MySql.Data.MySqlClient
Public Class setup_menu
    Dim array(99), arr(99), kode As String

    Private Sub setup_menu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tkode_menu.Focus()
    End Sub

    Private Sub setup_menu_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Sub setup_menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        data()
        kosong()
        Me.ResizeRedraw = True
    End Sub
    Sub kosong()
        tmenu_id.Clear()
        tkode_menu.Clear()
        tnama_menu.Clear()
        tparent.Clear()
        btnhapus.Enabled = False
        tkode_menu.Focus()
    End Sub

    Private Sub setup_menu_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Kode", 100, HorizontalAlignment.Center)
            .Add("Nama", 350, HorizontalAlignment.Left)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT * FROM data_menu_master ORDER BY menu_kode", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("menu_kode"))
                .Items(.Items.Count - 1).SubItems().Add(Strings.Space((Len(dt.Rows(i)("menu_kode")) - 4) * 2) + dt.Rows(i)("menu_label"))
            Next
        End With
    End Sub

    Private Sub tnama_menu_GotFocus(sender As Object, e As EventArgs) Handles tnama_menu.GotFocus, tparent.GotFocus, tkode_menu.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tnama_menu_LostFocus(sender As Object, e As EventArgs) Handles tnama_menu.LostFocus, tparent.LostFocus, tkode_menu.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tkode_menu.Text = "" Then
            MessageBox.Show("Kode Menu Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_menu.Focus()
            Exit Sub
        ElseIf Len(tkode_menu.Text) < 4 Then
            MessageBox.Show("Kode Menu minimal 4 karakter.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_menu.Focus()
            Exit Sub
        ElseIf tparent.Text = "" Then
            MessageBox.Show("Kode Parent Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tparent.Focus()
            Exit Sub
        ElseIf tnama_menu.Text = "" Then
            MessageBox.Show("Nama Menu Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_menu.Focus()
            Exit Sub
        End If

        cd = New MySqlCommand("SELECT * FROM data_menu_master WHERE menu_kode='" & tkode_menu.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True And tmenu_id.Text = "" Then
            rd.Close()
            MessageBox.Show("Kode Menu sudah Ada", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_menu.Focus()
        Else
            rd.Close()
            If tmenu_id.Text = "" Then
                simpan()
            Else
                edit()
            End If
        End If
    End Sub

    Sub ar()
        array(0) = tmenu_id.Text
        array(1) = tkode_menu.Text
        array(2) = tparent.Text
        array(3) = tnama_menu.Text
        array(4) = 1
        array(5) = MDIParent1.username.Text
        array(6) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        array(7) = MDIParent1.username.Text
        array(8) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")

        arr(0) = "menu_id='" + array(0) + "'"
        arr(1) = "menu_kode='" + array(1) + "'"
        arr(2) = "menu_parent='" + array(2) + "'"
        arr(3) = "menu_label='" + array(3) + "'"
        arr(4) = "menu_status='" + array(4) + "'"
        arr(5) = "menu_reg_username='" + array(5) + "'"
        arr(6) = "menu_reg_waktu='" + array(6) + "'"
        arr(7) = "menu_update_username='" + array(7) + "'"
        arr(8) = "menu_update_waktu='" + array(8) + "'"

    End Sub

    Sub simpan()
        ar()
        Dim gabung = ""
        For n = 0 To 8
            If n = 0 Then
                gabung += "'" + array(n) + "'"
            Else
                gabung += ",'" + array(n) + "'"
            End If
        Next

        cd = New MySqlCommand("INSERT INTO data_menu_master VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Master Menu (menu_kode : " + array(1) + ")"
        insert_log_user()

        caridata()
        data()
        MessageBox.Show("Master Data Menu berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Sub edit()
        ar()
        Dim gabung = ""
        For n = 1 To 8
            If n = 1 Then
                gabung += arr(n)
            ElseIf n = 4 Or n = 5 Or n = 6 Then

            Else
                gabung += "," + arr(n)
            End If
        Next
        cd = New MySqlCommand("UPDATE data_menu_master SET " & gabung & " WHERE " & arr(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Master Menu (menu_id : " + array(0) + ")"
        insert_log_user()

        data()
        MessageBox.Show("Master Data Menu berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Sub caridata()
        cd = New MySqlCommand("SELECT * FROM data_menu_master WHERE menu_kode='" & tkode_menu.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tmenu_id.Text = rd.Item("menu_id")
        tparent.Text = rd.Item("menu_parent")
        tnama_menu.Text = rd.Item("menu_label")
        rd.Close()
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub

    Private Sub btnbaru_Click(sender As Object, e As EventArgs) Handles btnbaru.Click
        kosong()
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        pilih()
    End Sub
    Sub pilih()
        With ListView1.SelectedItems.Item(0)
            tkode_menu.Text = .Text
        End With
        caridata()
        btnhapus.Enabled = True
    End Sub

    Sub hapus()
        ar()
        cd = New MySqlCommand("DELETE FROM data_menu_master WHERE " & arr(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Master Menu (menu_id : " + array(0) + ")"
        insert_log_user()

        data()
        kosong()
        MessageBox.Show("Master Data Menu berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus data Menu ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            hapus()
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            pilih()
        Catch ex As Exception

        End Try
    End Sub
End Class