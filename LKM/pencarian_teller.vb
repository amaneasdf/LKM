Imports MySql.Data.MySqlClient
Public Class pencarian_teller
    Dim username, nama, status As String
    Dim sortcolumn As Integer = -1
    Private Sub tfilter_GotFocus(sender As Object, e As EventArgs) Handles tfilter.GotFocus
        tfilter.BackColor = warna_gotfocus
        Button1.BackColor = warna_gotfocus
    End Sub

    Private Sub tfilter_KeyDown(sender As Object, e As KeyEventArgs) Handles tfilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnfilter.PerformClick()
        ElseIf e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            Try
                ListView1.Items(0).Selected = True
            Catch ex As Exception

            End Try
            ListView1.Focus()
        End If
    End Sub

    Private Sub tfilter_LostFocus(sender As Object, e As EventArgs) Handles tfilter.LostFocus
        tfilter.BackColor = warna_lostfocus
        Button1.BackColor = warna_lostfocus
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Nama Alias", 100, HorizontalAlignment.Left)
            .Add("Nama Lengkap", 300, HorizontalAlignment.Left)
            .Add("Grup Akses", 200, HorizontalAlignment.Left)
            .Add("Status", 100, HorizontalAlignment.Center)
        End With
    End Sub

    Sub data()
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("pengguna_username"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("pengguna_nama_lengkap"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("grup_akses_nama"))
                Select Case dt.Rows(i)("pengguna_status")
                    Case "0"
                        status = "NONE"
                    Case "1"
                        status = "AKTIF"
                End Select
                .Items(.Items.Count - 1).SubItems().Add(status)
            Next
        End With
    End Sub
    Sub tampil()
        da = New MySqlDataAdapter("SELECT pengguna_username, pengguna_nama_lengkap, grup_akses_nama, pengguna_status FROM data_pengguna JOIN data_grup_akses ON pengguna_grup_akses=grup_akses_kode WHERE pengguna_status<>0", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
    End Sub

    Sub cari()
        da = New MySqlDataAdapter("SELECT pengguna_username, pengguna_nama_lengkap, grup_akses_nama FROM data_pengguna JOIN data_grup_akses ON pengguna_grup_akses=grup_akses_kode WHERE pengguna_status<>0 AND (pengguna_username LIKE '%" & tfilter.Text & "%' OR pengguna_nama_lengkap LIKE '%" & tfilter.Text & "%')", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
        If ListView1.Items.Count = 0 Then
            MessageBox.Show("Data tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        btninsert.Enabled = False
    End Sub

    Private Sub pencarian_teller_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tfilter.Focus()
    End Sub

    Private Sub pencarian_teller_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub pencarian_teller_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub pencarian_teller_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        tampil()
        Me.ResizeRedraw = True
        btninsert.Enabled = False
        Label2.Text = MDIParent1.nama_lembaga.Text
    End Sub

    Private Sub pencarian_teller_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        cari()
    End Sub

    Private Sub tfilter_TextChanged(sender As Object, e As EventArgs) Handles tfilter.TextChanged
        If Len(tfilter.Text) = 0 Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        listselect()
    End Sub
    Sub listselect()
        With ListView1.SelectedItems.Item(0)
            username = .Text
            nama = .SubItems(1).Text
        End With
        btninsert.Enabled = True
    End Sub
    Sub pilih()
        With browse_transaksi
            .tusername.Text = username
            .tnama_username.Text = nama
        End With
        Me.Dispose()
    End Sub

    Private Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        pilih()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tfilter.Clear()
        tfilter.Focus()
    End Sub
End Class