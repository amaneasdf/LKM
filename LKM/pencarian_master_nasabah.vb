Imports MySql.Data.MySqlClient
Public Class pencarian_master_nasabah
    Dim kode As String
    Dim sortcolumn As Integer = -1

    Private Sub pencarian_master_nasabah_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tfilter.Focus()
    End Sub

    Private Sub pencarian_master_nasabah_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub pencarian_master_nasabah_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub
    Private Sub pencarian_master_nasabah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        btninsert.Enabled = False
        ListView1.Items.Clear()
        tfilter.Clear()
        Me.ResizeRedraw = True
        Label2.Text = MDIParent1.nama_lembaga.Text
    End Sub

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
    Sub tampil()
        da = New MySqlDataAdapter("SELECT *, (SELECT cari_combo_komponen('09',nasabah_dati2)) AS kabkot FROM data_nasabah WHERE nasabah_nama1 LIKE '%" & tfilter.Text & "%' OR nasabah_id LIKE '%" & tfilter.Text & "%' OR nasabah_nik LIKE '%" & tfilter.Text & "%' OR nasabah_alternatif LIKE '%" & tfilter.Text & "%' ORDER BY nasabah_id", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
    End Sub
    Sub ukuran()
        With ListView1
            .Columns.Clear()
            .Items.Clear()
            .Columns.Add("Nasabah ID", 100, HorizontalAlignment.Left)
            .Columns.Add("Alternatif", 100, HorizontalAlignment.Left)
            .Columns.Add("Nama Nasabah", 200, HorizontalAlignment.Left)
            .Columns.Add("Alamat", 300, HorizontalAlignment.Left)
            .Columns.Add("Kelurahan", 150, HorizontalAlignment.Left)
            .Columns.Add("Kecamatan", 150, HorizontalAlignment.Left)
            .Columns.Add("Kode Pos", 80, HorizontalAlignment.Left)
            .Columns.Add("Dati2", 200, HorizontalAlignment.Left)
        End With
    End Sub

    Sub data()
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("nasabah_id"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_alternatif"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_nama1"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_alamat"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_kelurahan"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_kecamatan"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_kode_pos"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kabkot"))
            Next
            If .Items.Count = 0 Then
                MessageBox.Show("Data tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            If .Items.Count > 0 Then
                btninsert.Enabled = True
            Else
                btninsert.Enabled = False
            End If
        End With
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        pilih()
    End Sub
    Sub pilih()
        If Label4.Text = "rekening tabungan" Then
            With rekening_tabungan
                .tnasabah_id.Text = kode
                .carinasabah()
            End With
        ElseIf Label4.Text = "rekening kredit" Then
            With rekening_kredit
                .tnasabah_id.Text = kode
                .carinasabah()
            End With
        End If
        Me.Close()
    End Sub

    Private Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        If Len(tfilter.Text) < 1 Then
            MessageBox.Show("Karakter minimal 1.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            tampil()
        End If
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

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        pilih()
    End Sub

    Sub listselect()
        With ListView1.SelectedItems.Item(0)
            kode = .Text
        End With
        btninsert.Enabled = True
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

    Private Sub pencarian_master_nasabah_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tfilter.Clear()
        tfilter.Focus()
    End Sub
End Class