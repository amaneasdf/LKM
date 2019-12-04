Imports MySql.Data.MySqlClient
Public Class master_rekening_kredit
    Dim kode As String
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
            .Add("No Rekening", 100, HorizontalAlignment.Left)
            .Add("No Alternatif", 100, HorizontalAlignment.Left)
            .Add("Nama Nasabah", 200, HorizontalAlignment.Left)
            .Add("Alamat Nasabah", 300, HorizontalAlignment.Left)
            .Add("Plafon Akad", 100, HorizontalAlignment.Right)
            .Add("Tgl Mulai", 100, HorizontalAlignment.Center)
            .Add("JKW", 50, HorizontalAlignment.Center)
            .Add("Tgl Jth Tempo", 100, HorizontalAlignment.Center)
            .Add("SB (%)", 70, HorizontalAlignment.Center)
            .Add("Kol", 50, HorizontalAlignment.Center)
            .Add("Status", 100, HorizontalAlignment.Center)
        End With
    End Sub
    Sub data()
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("rek_kre_no_rekening"))
                '.Items(.Items.Count - 1).UseItemStyleForSubItems = False 'koding warna subitems listview
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("rek_kre_no_alternatif"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_nama1"))
                ' .Font = New Font(ListView1.Font, FontStyle.Bold)  ' cara bold dalam list view
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_alamat") + ", " + dt.Rows(i)("nasabah_kelurahan") + ", " + dt.Rows(i)("nasabah_kecamatan"))
                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("rek_kre_plafon_induk"), "##,###,###"))
                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("rek_kre_tanggal_mulai"), "dd MMM yyyy"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("rek_kre_jangka_waktu"))
                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("rek_kre_tanggal_jt"), "dd MMM yyyy"))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("rek_kre_suku_bunga"), 3))
                '.Items(.Items.Count - 1).SubItems().Add("").BackColor = Color.Red 'merah
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kolek"))
                Select Case dt.Rows(i)("rek_kre_status")
                    Case "0"
                        .Items(.Items.Count - 1).SubItems().Add("NONE")
                        .Items(i).BackColor = Color.Silver
                    Case "1"
                        .Items(.Items.Count - 1).SubItems().Add("SETUP")
                        .Items(i).BackColor = Color.Lavender
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

    Private Sub master_rekening_kredit_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tfilter.Focus()
    End Sub

    Private Sub master_rekening_kredit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub master_rekening_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub master_rekening_kredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        Try
            rd.Close()
        Catch ex As Exception

        End Try
        ukuran()
        tampil()
        Me.ResizeRedraw = True
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        With rekening_kredit
            .kosong()
            .ShowDialog()
        End With
    End Sub

    Private Sub master_rekening_kredit_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub master_rekening_kredit_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = MDIParent1.Width - 20
        Me.Height = MDIParent1.Height - 177
    End Sub

    Private Sub btnkoreksi_Click(sender As Object, e As EventArgs) Handles btnkoreksi.Click
        pilih()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If MessageBox.Show("Yakin ingin menghapus Master Rekening Kredit ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cd = New MySqlCommand("SELECT rek_kre_status FROM data_kredit_rekening WHERE rek_kre_no_rekening='" & kode & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            If rd.Item("rek_kre_status") <> "0" Then
                rd.Close()
                'tidak bisa dihapus
                MessageBox.Show("Master Rekening Kredit ini tidak dapat dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                rd.Close()
                hapus()
            End If
            rd.Close()
        End If
    End Sub

    Sub tampil()
        da = New MySqlDataAdapter("SELECT rek_kre_no_rekening, rek_kre_no_alternatif, nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, rek_kre_plafon_induk, rek_kre_tanggal_mulai, rek_kre_jangka_waktu, rek_kre_tanggal_jt, rek_kre_suku_bunga, rek_kre_status, IFNULL(hitung_kolek(rek_kre_no_rekening, (SELECT kre_stat_waktu FROM data_kredit_statement WHERE kre_stat_no_rekening = rek_kre_no_rekening AND kre_stat_waktu <=NOW() ORDER BY kre_stat_waktu DESC LIMIT 0,1)),'-') AS kolek FROM data_kredit_rekening JOIN data_nasabah ON rek_kre_nasabah_id=nasabah_id WHERE rek_kre_status in ('0','1') ORDER BY rek_kre_no_rekening", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
    End Sub
    Sub cari()
        btnhapus.Enabled = False
        btnkoreksi.Enabled = False
        da = New MySqlDataAdapter("SELECT rek_kre_no_rekening, rek_kre_no_alternatif, nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, rek_kre_plafon_induk, rek_kre_tanggal_mulai, rek_kre_jangka_waktu, rek_kre_tanggal_jt, rek_kre_suku_bunga, rek_kre_status, IFNULL(hitung_kolek(rek_kre_no_rekening, (SELECT kre_stat_waktu FROM data_kredit_statement WHERE kre_stat_no_rekening = rek_kre_no_rekening AND kre_stat_waktu <=NOW() ORDER BY kre_stat_waktu DESC LIMIT 0,1)),'-') AS kolek FROM data_kredit_rekening JOIN data_nasabah ON rek_kre_nasabah_id = nasabah_id WHERE nasabah_nama1 LIKE '%" & tfilter.Text & "%' OR rek_kre_no_alternatif LIKE '%" & tfilter.Text & "%' OR rek_kre_no_rekening LIKE '%" & tfilter.Text & "%'  ORDER BY rek_kre_no_rekening", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
        If ListView1.Items.Count = 0 Then
            MessageBox.Show("Data tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
   Sub pilih()
        cd = New MySqlCommand("SELECT *, IFNULL(hitung_kolek(rek_kre_no_rekening, (SELECT kre_stat_waktu FROM data_kredit_statement WHERE kre_stat_no_rekening = rek_kre_no_rekening AND kre_stat_waktu <=NOW() ORDER BY kre_stat_waktu DESC LIMIT 0,1)),'-') AS kolek FROM data_kredit_rekening WHERE rek_kre_no_rekening='" & kode & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim array(99) As String
        array(0) = rd.Item("rek_kre_no_rekening")
        array(1) = rd.Item("rek_kre_no_alternatif")
        array(2) = rd.Item("rek_kre_kode_produk")
        array(3) = rd.Item("rek_kre_nasabah_id")
        array(4) = rd.Item("rek_kre_akad_awal")
        array(5) = rd.Item("rek_kre_akad_akhir")
        array(6) = rd.Item("rek_kre_tanggal1")
        array(7) = rd.Item("rek_kre_tanggal2")
        array(8) = rd.Item("rek_kre_plafon_induk")
        array(9) = rd.Item("rek_kre_suku_bunga")
        array(10) = rd.Item("rek_kre_jangka_waktu")
        array(11) = rd.Item("rek_kre_jenis_angsuran")
        'array(12) = rd.Item("rek_kre_sistem_angsuran")
        array(13) = rd.Item("rek_kre_sistem_bunga")
        array(14) = rd.Item("rek_kre_tanggal_mulai")
        array(15) = rd.Item("rek_kre_tanggal_jt")
        'array(16) = rd.Item("rek_kre_kolek")
        'array(17) = rd.Item("rek_kre_adj1")
        'array(18) = rd.Item("rek_kre_adj2")
        array(19) = rd.Item("rek_kre_provisi_p")
        array(20) = rd.Item("rek_kre_provisi_rp")
        array(21) = rd.Item("rek_kre_administrasi_p")
        array(22) = rd.Item("rek_kre_administrasi_rp")
        'array(23) = rd.Item("rek_kre_tabungan_p")
        'array(24) = rd.Item("rek_kre_tabungan_rp")
        array(25) = rd.Item("rek_kre_materai")
        array(26) = rd.Item("rek_kre_asuransi")
        array(27) = rd.Item("rek_kre_notaris")
        array(28) = rd.Item("rek_kre_lain")
        array(29) = rd.Item("rek_kre_status")
        array(30) = rd.Item("kolek")
        rd.Close()
        With rekening_kredit
            .kosong()
            .combo()
            .tkode_skim.Enabled = False
            .cmbskim.Enabled = False
            .tno_rekening1.Text = array(0)
            .tno_rekening2.Text = array(1)
            .tkode_skim.Text = array(2)
            .cariproduk()
            .tnasabah_id.Text = array(3)
            '.tnasabah_id.Enabled = False
            '.btncarinasabah.Enabled = False
            .carinasabah()
            
            .tno_akad_awal.Text = array(4)
            .tno_akad_akhir.Text = array(5)
            .DateTimePicker1.Value = array(6)
            .ttanggal.Text = array(7)
            .tplafon_induk.Text = array(8)
            '.tplafon_induk.Enabled = False
            .tsuku_bunga.Text = FormatNumber(array(9), 3)
            '.tsuku_bunga.Enabled = False
            .tjkw.Text = array(10)
            '.tjkw.Enabled = False
            '.DateTimePicker3.Enabled = False

            Try
                cd = New MySqlCommand("SELECT cari_combo_komponen('22','" & array(11) & "') AS sistemangsuran", koneksi)
                rd = cd.ExecuteReader
                rd.Read()
                .cmbsistem_angsuran.Text = rd.Item("sistemangsuran")
                '.cmbsistem_angsuran.Enabled = False
                rd.Close()
            Catch ex As Exception
                .cmbsistem_angsuran.Text = ""
                .cmbsistem_angsuran.Enabled = True
            End Try
            .pilihsistem()
            '.tsistem_angsuran.Text = array(12)

            Try
                cd = New MySqlCommand("SELECT cari_combo_komponen('21','" & array(13) & "') AS sistembunga", koneksi)
                rd = cd.ExecuteReader
                rd.Read()
                .cmbsistem_bunga.Text = rd.Item("sistembunga")
                '.cmbsistem_bunga.Enabled = False
                rd.Close()
            Catch ex As Exception
                .cmbsistem_bunga.Text = ""
                .cmbsistem_bunga.Enabled = True
            End Try

            .DateTimePicker3.Value = array(14)
            .DateTimePicker4.Value = array(15)
            .tkolek.Text = array(16)
            ' .tadj1.Text = array(17)
            ' .tadj2.Text = array(18)
            .tprovisi1.Text = FormatNumber(array(19), 2)
            .tprovisi2.Text = array(20)
            .tadministrasi1.Text = FormatNumber(array(21), 2)
            .tadministrasi2.Text = array(22)
            .tmaterai.Text = array(25)
            .tasuransi.Text = array(26)
            .tnotaris.Text = array(27)
            .tlain.Text = array(28)

            Select Case array(29)
                Case "0"
                    .cmbstatus.Text = "0 : NONE"
                    .btnbuat_jadual.Text = "Buat Jadual Angsuran"
                    .btndata_pelengkap.Enabled = False
                    .btndata_agunan.Enabled = False
                Case "1"
                    .cmbstatus.Text = "1 : SETUP"
                    .btnbuat_jadual.Text = "Jadual Angsuran"
                    .btndata_pelengkap.Enabled = True
                    .btndata_agunan.Enabled = True
                Case "2"
                    .cmbstatus.Text = "2 : AKTIF"
                    .btnbuat_jadual.Text = "Jadual Angsuran"
                    .btndata_pelengkap.Enabled = True
                    .btndata_agunan.Enabled = True

                    .btnstatement_transaksi.Enabled = True
                    '.btnstatement_ppap.Enabled = True
                    '.btnstatement_provisi.Enabled = True
                Case "3"
                    .cmbstatus.Text = "3 : LUNAS"
                    .btnbuat_jadual.Text = "Jadual Angsuran"
                    .btndata_pelengkap.Enabled = True
                    .btndata_agunan.Enabled = True

                    .btnstatement_transaksi.Enabled = True
                    '.btnstatement_ppap.Enabled = True
                    '.btnstatement_provisi.Enabled = True
            End Select
            Select Case array(30)
                Case "L"
                    .tkolek.Text = "L - LANCAR"
                Case "KL"
                    .tkolek.Text = "KL - KURANG LANCAR"
                Case "D"
                    .tkolek.Text = "D - DIRAGUKAN"
                Case "M"
                    .tkolek.Text = "M - MACET"
                Case Else
                    .tkolek.Text = ""
            End Select
            .tombol()
            .btnbuat_jadual.Enabled = True
            .ShowDialog()
        End With
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        listselect()
    End Sub

    Sub listselect()
        With ListView1.SelectedItems.Item(0)
            kode = .Text
        End With
        btnhapus.Enabled = True
        btnkoreksi.Enabled = True
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

    Private Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        btnhapus.Enabled = False
        btnkoreksi.Enabled = False
        If Len(tfilter.Text) < 1 Then
            tampil()
        Else
            cari()
        End If
    End Sub
    Sub hapus()
       cd = New MySqlCommand("DELETE FROM data_kredit_rekening WHERE rek_kre_no_rekening='" & kode & "'", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menghapus Master Rekening Kredit (rek_kre_no_rekening : " + kode + ")"
        insert_log_user()

        btnfilter.PerformClick()
        btnhapus.Enabled = False
        btnkoreksi.Enabled = False
        MessageBox.Show("Master Rekening Kredit berhasil dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

End Class