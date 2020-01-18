Imports MySql.Data.MySqlClient
Public Class pencarian_master_tabungan
    Public ReturnValue As String = ""
    Dim kode As String
    Dim sortcolumn As Integer = -1

    Private Sub pencarian_master_tabungan_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tfilter.Focus()
    End Sub

    Private Sub pencarian_master_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub pencarian_master_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btninsert.Enabled = False
        tfilter.Clear()
        ukuran()
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
            ListView1.Items(0).Selected = True
            ListView1.Focus()
        End If
    End Sub

    Private Sub tfilter_LostFocus(sender As Object, e As EventArgs) Handles tfilter.LostFocus
        tfilter.BackColor = warna_lostfocus
        Button1.BackColor = warna_lostfocus
    End Sub
    Sub tampil()
        rd.Close()
        da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, rek_tab_no_alternatif, rek_tab_kode_produk, rek_tab_status, nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, tabungan_nama_produk FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id JOIN data_tabungan_produk ON rek_tab_kode_produk=tabungan_kode WHERE rek_tab_status='0'", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
    End Sub
    Sub cari()
        'rd.Close()
        btninsert.Enabled = False
        If Label4.Text = "cari rekening 1" Then
            da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, rek_tab_no_alternatif, rek_tab_kode_produk, rek_tab_status, nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, tabungan_nama_produk FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id JOIN data_tabungan_produk ON rek_tab_kode_produk=tabungan_kode WHERE rek_tab_status IN ('0','1') AND (nasabah_nama1 LIKE'%" & tfilter.Text & "%' OR rek_tab_no_rekening LIKE'%" & tfilter.Text & "%' OR rek_tab_no_alternatif LIKE'%" & tfilter.Text & "%' ) ORDER BY rek_tab_no_rekening", koneksi)
        End If
        If Label4.Text = "cari rekening 2" Or Label4.Text = "transaksi angsuran kredit" Or Label4.Text = "agunan kredit" Then
            da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, rek_tab_no_alternatif, rek_tab_kode_produk, rek_tab_status, nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, tabungan_nama_produk FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id JOIN data_tabungan_produk ON rek_tab_kode_produk=tabungan_kode WHERE rek_tab_status IN ('1') AND (nasabah_nama1 LIKE'%" & tfilter.Text & "%' OR rek_tab_no_rekening LIKE'%" & tfilter.Text & "%' OR rek_tab_no_alternatif LIKE'%" & tfilter.Text & "%' ) ORDER BY rek_tab_no_rekening", koneksi)
        End If
        If Label4.Text = "rekening koran" Then
            da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, rek_tab_no_alternatif, rek_tab_kode_produk, rek_tab_status, nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, tabungan_nama_produk FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id JOIN data_tabungan_produk ON rek_tab_kode_produk=tabungan_kode WHERE rek_tab_status <> 0 AND (nasabah_nama1 LIKE'%" & tfilter.Text & "%' OR rek_tab_no_rekening LIKE'%" & tfilter.Text & "%' OR rek_tab_no_alternatif LIKE'%" & tfilter.Text & "%' ) ORDER BY rek_tab_no_rekening", koneksi)
        End If

        dt = New DataTable
        da.Fill(dt)
        data()
        If ListView1.Items.Count = 0 Then
            MessageBox.Show("Data tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("No Rekening", 100, HorizontalAlignment.Left)
            .Add("No Alternatif", 100, HorizontalAlignment.Left)
            .Add("Produk", 250, HorizontalAlignment.Left)
            .Add("Nama Nasabah", 300, HorizontalAlignment.Left)
            .Add("Alamat Nasabah", 500, HorizontalAlignment.Left)
            .Add("Status", 80, HorizontalAlignment.Center)
            If Label4.Text = "cari rekening 1" Then
                tampil()
            End If
        End With
    End Sub
    Sub data()
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("rek_tab_no_rekening"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("rek_tab_no_alternatif"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("tabungan_nama_produk"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_nama1"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_alamat") + ", " + dt.Rows(i)("nasabah_kelurahan") + ", " + dt.Rows(i)("nasabah_kecamatan"))
                Select Case dt.Rows(i)("rek_tab_status")
                    Case "0"
                        .Items(.Items.Count - 1).SubItems().Add("NONE")
                        .Items(i).BackColor = Color.Silver
                    Case "1"
                        .Items(.Items.Count - 1).SubItems().Add("AKTIF")
                        .Items(i).BackColor = Color.LightGreen
                    Case "2"
                        .Items(.Items.Count - 1).SubItems().Add("BLOKIR")
                        .Items(i).BackColor = Color.Pink
                    Case "4"
                        .Items(.Items.Count - 1).SubItems().Add("TUTUP")
                        .Items(i).BackColor = Color.Khaki
                End Select
            Next
        End With
    End Sub

    Private Sub pencarian_master_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        If Len(tfilter.Text) < 1 Then
            MessageBox.Show("Karakter minimal 1.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            cari()
        End If
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        listselect()
    End Sub
    Sub listselect()
        With ListView1.SelectedItems.Item(0)
            kode = .Text
        End With
        btninsert.Enabled = True
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub
    Sub pilih()
        With transaksi__tabungan
            If Label4.Text = "cari rekening 1" Then
                .tno_rekening.Text = kode
                .caritabungan()
            End If
            If Label4.Text = "cari rekening 2" Then
                .tnomor_rekening.Text = kode
                .carirekening()
            End If
        End With
        If Label4.Text = "transaksi angsuran kredit" Then
            With transaksi_angsuran_kredit
                .tnomor_rekening2.Text = kode
                .carirekening()
            End With
        End If
        If Label4.Text = "rekening koran" Then
            With cetak_rekening_koran
                .tno_rekening.Text = kode
                .carirekening()
            End With
        End If
        If Label4.Text = "agunan kredit" Then
            With agunan_kredit
                .tstatus.Text = kode
                .carirekening()
            End With
        End If
        Me.Close()
    End Sub

    Private Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        pilih()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        pilih()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tfilter.Clear()
        tfilter.Focus()
    End Sub

    Private Sub tfilter_TextChanged(sender As Object, e As EventArgs) Handles tfilter.TextChanged
        If Len(tfilter.Text) = 0 Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
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
End Class