Imports MySql.Data.MySqlClient
Public Class ganti_password
    Dim array(99) As String

    Private Sub ganti_password_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ganti_password_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub ganti_password_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = True
    End Sub

    Private Sub ganti_password_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tpassword_lama.Text = "" Then
            MessageBox.Show("Password Lama harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tpassword_lama.Focus()
            Exit Sub
        ElseIf tpassword_baru.Text = "" Then
            MessageBox.Show("Password Baru harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tpassword_baru.Focus()
            Exit Sub
        ElseIf tulangi_password.Text = "" Then
            MessageBox.Show("Ulangi Password Baru harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tulangi_password.Focus()
            Exit Sub
        End If
        cd = New MySqlCommand("SELECT * FROM data_pengguna WHERE pengguna_username='" & tnama_alias.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        array(0) = rd.Item("pengguna_username")
        array(1) = rd.Item("pengguna_nama_lengkap")
        array(2) = rd.Item("pengguna_password")
        array(3) = rd.Item("pengguna_grup_akses")
        array(4) = rd.Item("pengguna_status")
        rd.Close()
        If computeHash(tpassword_lama.Text) <> array(2) Then
            MessageBox.Show("Password Lama salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tpassword_lama.Focus()
            Exit Sub
        ElseIf computeHash(tpassword_baru.Text) <> computeHash(tulangi_password.Text) Then
            MessageBox.Show("Ulangi Password harus sama dengan Password Baru.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tulangi_password.Focus()
            Exit Sub
        ElseIf Label4.Text = "aktivasi" Then
            cd = New MySqlCommand("UPDATE data_pengguna SET pengguna_status='1', pengguna_password='" & computeHash(tpassword_baru.Text) & "', pengguna_update_username='" & MDIParent1.username.Text & "', pengguna_update_waktu='" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "' WHERE pengguna_username='" & tnama_alias.Text & "'", koneksi)
            cd.ExecuteNonQuery()
            MessageBox.Show("Aktivasi dan Ganti Password Data Pengguna berhasil.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)

            user_pengguna = array(0)
            uraian = "Melakukan aktivasi pengguna"
            insert_log_user()

            MessageBox.Show("Ganti Password Data Pengguna berhasil.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            MessageBox.Show("Silahkan Login kembali.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)

            MDIParent1.Dispose()
            login.Dispose()
        Else
            cd = New MySqlCommand("UPDATE data_pengguna SET pengguna_password='" & computeHash(tpassword_baru.Text) & "', pengguna_update_username='" & MDIParent1.username.Text & "', pengguna_update_waktu='" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "' WHERE pengguna_username='" & tnama_alias.Text & "'", koneksi)
            cd.ExecuteNonQuery()

            user_pengguna = array(0)
            uraian = "Melakukan ganti password pengguna"
            insert_log_user()

            MessageBox.Show("Ganti Password Data Pengguna berhasil.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            MessageBox.Show("Silahkan Login kembali.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)

            MDIParent1.Dispose()
            login.Dispose()
            Me.Dispose()
        End If
        
    End Sub

    Private Sub tulangi_password_GotFocus(sender As Object, e As EventArgs) Handles tulangi_password.GotFocus, tpassword_baru.GotFocus, tpassword_lama.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tulangi_password_LostFocus(sender As Object, e As EventArgs) Handles tulangi_password.LostFocus, tpassword_baru.LostFocus, tpassword_lama.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub
End Class