Imports MySql.Data.MySqlClient
Public Class login
    Dim data(99) As String

    Private Sub login_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tusername.Focus()
    End Sub

    Private Sub login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnbatal.PerformClick()
    End Sub

    Private Sub login_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetWatermark(tusername, "Username")
        SetWatermark(tpassword, "Password")
        Me.ResizeRedraw = True
        ' Me.TransparencyKey = Color.LightBlue 'background transparan
        '  Me.BackColor = Color.LightBlue   'background transparan


        ' MDIParent1.Opacity = 0.95
        koneksi_localhost()
        koneksi.Open()
        tusername.Focus()
    End Sub

    Private Sub login_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        For i As Integer = 0 To 5
            Me.Opacity = (100 - (i * 20)) / 100
            Threading.Thread.Sleep(30)
            Windows.Forms.Application.DoEvents()
        Next

        Me.Dispose()
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        If tusername.Text = "" Then
            MessageBox.Show("Username harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tusername.Focus()
            Exit Sub
        ElseIf tpassword.Text = "" Then
            MessageBox.Show("Password harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tpassword.Focus()
            Exit Sub
        End If
        cd = New MySqlCommand("SELECT * FROM data_pengguna WHERE pengguna_username='" & tusername.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        If rd.HasRows = False Then
            MessageBox.Show("Username tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tusername.Focus()
            rd.Close()
            Exit Sub
        Else
            data(0) = rd.Item("pengguna_username")
            data(1) = rd.Item("pengguna_nama_lengkap")
            data(2) = rd.Item("pengguna_password")
            data(3) = rd.Item("pengguna_grup_akses")
            data(4) = rd.Item("pengguna_status")
        End If
        rd.Close()

        If computeHash(tpassword.Text) <> data(2) Then

            If Label5.Text = tusername.Text Then
                Label4.Text = Val(Label4.Text) + 1

            Else
                Label4.Text = 1
            End If
            Label5.Text = tusername.Text
            If Label4.Text = "3" Then
                MessageBox.Show("Password salah sebanyak 3x." + Chr(10) + "Aplikasi ditutup.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Close()
            Else
                MessageBox.Show("Password Salah." + Chr(10) + "Kesempatan memasukan password ".ToString + (3 - Val(Label4.Text)).ToString + "x lagi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            tpassword.Clear()
            tpassword.Focus()
            Exit Sub
        End If
        If data(4) = "0" Then
            MessageBox.Show("Data Pengguna belum aktif, lakukan ganti password untuk mengaktifkan Data Pengguna.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            With ganti_password
                .tnama_alias.Text = data(0)
                cd = New MySqlCommand("SELECT concat_ws (' : ', grup_akses_kode, grup_akses_nama) AS grupakses FROM data_grup_akses WHERE grup_akses_kode='" & data(3) & "'", koneksi)
                rd = cd.ExecuteReader
                rd.Read()
                .cmbgrup_akses.Text = rd.Item("grupakses")
                rd.Close()
                .Label4.Text = "aktivasi"
                .ShowDialog()
            End With
            Exit Sub
        ElseIf data(4) = "1" Then
            With MDIParent1
                .username.Text = data(0)
                .nama_lengkap.Text = data(1)
                .Label1.Text = data(3)
                .LoadMainControl()
                Me.Hide()

                user_pengguna = data(0)
                uraian = "Login berhasil"
                insert_log_user()

                .ShowDialog()
                .Focus()
            End With
        End If

        Try
            MDIParent1.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tpassword_GotFocus(sender As Object, e As EventArgs) Handles tpassword.GotFocus, tusername.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tpassword_LostFocus(sender As Object, e As EventArgs) Handles tpassword.LostFocus, tusername.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub login_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        For i As Integer = 0 To 5
            Me.Opacity = (i * 20) / 100
            Threading.Thread.Sleep(30)
            Windows.Forms.Application.DoEvents()
        Next
    End Sub
End Class