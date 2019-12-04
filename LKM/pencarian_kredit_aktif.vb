Imports MySql.Data.MySqlClient
Public Class pencarian_kredit_aktif
    Dim kode As String
    Dim sortcolumn As Integer = -1

    Private Sub pencarian_kredit_aktif_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tfilter.Focus()
    End Sub

    Private Sub pencarian_kredit_aktif_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub pencarian_kredit_aktif_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub
    Private Sub pencarian_kredit_aktif_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btninsert.Enabled = False
        tfilter.Clear()
        ukuran()
        Me.ResizeRedraw = True
        tfilter.Focus()
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
    Sub cari()
        btninsert.Enabled = False
        da = New MySqlDataAdapter("SELECT rek_kre_no_rekening, rek_kre_no_alternatif, nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, rek_kre_plafon_induk, rek_kre_jangka_waktu, rek_kre_tanggal_jt, rek_kre_status, hitung_baki_debet(rek_kre_no_rekening,NOW()) AS bakidebet, IFNULL(hitung_kolek(rek_kre_no_rekening, (SELECT kre_stat_waktu FROM data_kredit_statement WHERE kre_stat_no_rekening = rek_kre_no_rekening AND kre_stat_waktu <=NOW() ORDER BY kre_stat_waktu DESC LIMIT 0,1)),'-') AS kolek FROM data_kredit_rekening JOIN data_nasabah ON rek_kre_nasabah_id=nasabah_id WHERE (nasabah_nama1 LIKE '%" & tfilter.Text & "%' OR rek_kre_no_rekening LIKE '%" & tfilter.Text & "%' OR rek_kre_no_alternatif LIKE '%" & tfilter.Text & "%' ) AND rek_kre_status IN ('2','3') ORDER BY rek_kre_no_rekening", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
        If ListView1.Items.Count = 0 Then
            MessageBox.Show("Data tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        btninsert.Enabled = False
    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("No Rekening", 100, HorizontalAlignment.Left)
            .Add("No Alternatif", 100, HorizontalAlignment.Left)
            .Add("Nama Nasabah", 150, HorizontalAlignment.Left)
            .Add("Alamat Nasabah", 300, HorizontalAlignment.Left)
            .Add("Plafond Akad", 100, HorizontalAlignment.Right)
            .Add("Baki Debet", 100, HorizontalAlignment.Right)
            .Add("JKW", 50, HorizontalAlignment.Center)
            .Add("Tgl Jatuh Tempo", 100, HorizontalAlignment.Center)
            .Add("Kol", 50, HorizontalAlignment.Center)
            .Add("Status", 100, HorizontalAlignment.Center)
        End With
    End Sub
    Sub data()
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("rek_kre_no_rekening"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("rek_kre_no_alternatif"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_nama1"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_alamat") + ", " + dt.Rows(i)("nasabah_kelurahan") + ", " + dt.Rows(i)("nasabah_kecamatan"))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("rek_kre_plafon_induk"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("bakidebet"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("rek_kre_jangka_waktu"), 0))
                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("rek_kre_tanggal_jt"), "dd-MM-yyyy"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kolek"))
                Select Case dt.Rows(i)("rek_kre_status")
                    Case "2"
                        .Items(.Items.Count - 1).SubItems().Add("AKTIF")
                        .Items(i).BackColor = Color.LightGreen
                    Case "3"
                        .Items(.Items.Count - 1).SubItems().Add("LUNAS")
                        .Items(i).BackColor = Color.Khaki
                End Select
            Next
        End With
    End Sub

    Private Sub pencarian_kredit_aktif_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
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
        Me.Dispose()
    End Sub
    Sub pilih()
        With transaksi_angsuran_kredit
            .tnomor_rekening.Text = kode
            .carikredit()
        End With
        Me.Close()
    End Sub

    Private Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        pilih()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        pilih()
    End Sub

    Private Sub tfilter_TextChanged(sender As Object, e As EventArgs) Handles tfilter.TextChanged
        If Len(tfilter.Text) = 0 Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tfilter.Clear()
        tfilter.Focus()
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