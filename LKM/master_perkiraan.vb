Imports MySql.Data.MySqlClient
Public Class master_perkiraan
    Dim kode_perkiraan As String
    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub master_perkiraan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub master_perkiraan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()

        ukuran()
        data()
        Me.ResizeRedraw = True
        btntambah.Enabled = False
        btnkoreksi.Enabled = False
        btnhapus.Enabled = False
    End Sub

    Private Sub master_perkiraan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub master_perkiraan_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ' Me.Width = MDIParent1.Width - 20
        'Me.Height = MDIParent1.Height - 180
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Kode", 100, HorizontalAlignment.Left)
            .Add("Nama Perkiraan", 300, HorizontalAlignment.Left)
            .Add("Parent", 100, HorizontalAlignment.Left)
            .Add("Jurnal", 70, HorizontalAlignment.Center)
            .Add("Koreksi", 70, HorizontalAlignment.Center)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT * FROM kode_perkiraan ORDER BY perkiraan_kode", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("perkiraan_kode"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("perkiraan_nama"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("perkiraan_parent"))
                If dt.Rows(i)("perkiraan_jurnal") = "1" Then
                    .Items(.Items.Count - 1).SubItems().Add("YA")
                Else
                    .Items(.Items.Count - 1).SubItems().Add("")
                End If
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("perkiraan_koreksi"))
            Next
        End With
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        'data_perkiraan.ShowDialog()
        With data_perkiraan
            .tparent.Text = ListView1.SelectedItems.Item(0).Text
            .TextBox1.Text = ListView1.SelectedItems.Item(0).Text
            .ShowDialog()
        End With
    End Sub
    Sub listselect()
        Select Case ListView1.SelectedItems.Item(0).SubItems(4).Text
            Case "1"
                btntambah.Enabled = False
                btnkoreksi.Enabled = True
                btnhapus.Enabled = True
            Case "2"
                btntambah.Enabled = True
                btnkoreksi.Enabled = False
                btnhapus.Enabled = False
            Case "3"
                btntambah.Enabled = False
                btnkoreksi.Enabled = False
                btnhapus.Enabled = False
        End Select
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        listselect()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Item(0).SubItems(2).Text = "4" Then
            pilih()
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            listselect()
        Catch ex As Exception

        End Try
    End Sub
    Sub pilih()
        With data_perkiraan
            .tkode.Text = ListView1.SelectedItems.Item(0).Text
            .tkode.Enabled = False
            .tnama.Text = ListView1.SelectedItems.Item(0).SubItems(1).Text
            .tparent.Text = ListView1.SelectedItems.Item(0).SubItems(2).Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnkoreksi_Click(sender As Object, e As EventArgs) Handles btnkoreksi.Click
        pilih()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Dim kd_perk As String = ListView1.SelectedItems.Item(0).Text
        If MessageBox.Show("Yakin ingin menghapus data Perkiraan (" + kd_perk + " : " + ListView1.SelectedItems.Item(0).SubItems(1).Text + ") ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cd = New MySqlCommand("SELECT * FROM data_akuntansi_jurnal WHERE jurnal_perkiraan='" & kd_perk & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()

            If rd.HasRows = False Then
                rd.Close()
                cd = New MySqlCommand("DELETE FROM kode_perkiraan WHERE perkiraan_kode='" & kd_perk & "'", koneksi)
                cd.ExecuteNonQuery()

                user_pengguna = MDIParent1.username.Text
                uraian = "Menghapus Kode Perkiraan (perkiraan_kode : " + kd_perk + ")"
                insert_log_user()

                data()
                MessageBox.Show("Master Data Perkiraan berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Data perkiraan (" + kd_perk + " : " + ListView1.SelectedItems.Item(0).SubItems(1).Text + ") tidak dapat dihapus", "Micro Finance Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            rd.Close()
        End If
    End Sub
End Class