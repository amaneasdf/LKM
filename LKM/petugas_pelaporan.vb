Imports MySql.Data.MySqlClient
Public Class petugas_pelaporan

    Private Sub petugas_pelaporan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub petugas_pelaporan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub petugas_pelaporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo()
        combotext()
    End Sub

    Sub combo()
        cd = New MySqlCommand("SELECT CONCAT(pegawai_kode, ' : (', cari_struktur_jabatan(pegawai_struktur), '), ', pegawai_nama) AS pilihan FROM data_pegawai", koneksi)
        rd = cd.ExecuteReader
        cmbtab_pembuat.Items.Clear()
        cmbtab_pemeriksa.Items.Clear()
        cmbtab_pengesah.Items.Clear()
        cmbkre_pembuat.Items.Clear()
        cmbkre_pemeriksa.Items.Clear()
        cmbkre_pengesah.Items.Clear()
        cmbakt_pembuat.Items.Clear()
        cmbakt_pemeriksa.Items.Clear()
        cmbakt_pengesah.Items.Clear()
        While rd.Read()
            cmbtab_pembuat.Items.Add(rd.Item("pilihan"))
            cmbtab_pemeriksa.Items.Add(rd.Item("pilihan"))
            cmbtab_pengesah.Items.Add(rd.Item("pilihan"))
            cmbkre_pembuat.Items.Add(rd.Item("pilihan"))
            cmbkre_pemeriksa.Items.Add(rd.Item("pilihan"))
            cmbkre_pengesah.Items.Add(rd.Item("pilihan"))
            cmbakt_pembuat.Items.Add(rd.Item("pilihan"))
            cmbakt_pemeriksa.Items.Add(rd.Item("pilihan"))
            cmbakt_pengesah.Items.Add(rd.Item("pilihan"))
        End While
        rd.Close()
    End Sub

    Sub combotext()
        cd = New MySqlCommand("SELECT IFNULL(cari_petugas_pelaporan('tabungan_laporan_pembuat'),'') AS petugas", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbtab_pembuat.Text = rd.Item("petugas")
        rd.Close()

        cd = New MySqlCommand("SELECT IFNULL(cari_petugas_pelaporan('tabungan_laporan_pemeriksa'),'') AS petugas", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbtab_pemeriksa.Text = rd.Item("petugas")
        rd.Close()

        cd = New MySqlCommand("SELECT IFNULL(cari_petugas_pelaporan('tabungan_laporan_pengesah'),'') AS petugas", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbtab_pengesah.Text = rd.Item("petugas")
        rd.Close()



        cd = New MySqlCommand("SELECT IFNULL(cari_petugas_pelaporan('kredit_laporan_pembuat'),'') AS petugas", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbkre_pembuat.Text = rd.Item("petugas")
        rd.Close()

        cd = New MySqlCommand("SELECT IFNULL(cari_petugas_pelaporan('kredit_laporan_pemeriksa'),'') AS petugas", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbkre_pemeriksa.Text = rd.Item("petugas")
        rd.Close()

        cd = New MySqlCommand("SELECT IFNULL(cari_petugas_pelaporan('kredit_laporan_pengesah'),'') AS petugas", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbkre_pengesah.Text = rd.Item("petugas")
        rd.Close()


        cd = New MySqlCommand("SELECT IFNULL(cari_petugas_pelaporan('akuntansi_laporan_pembuat'),'') AS petugas", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbakt_pembuat.Text = rd.Item("petugas")
        rd.Close()

        cd = New MySqlCommand("SELECT IFNULL(cari_petugas_pelaporan('akuntansi_laporan_pemeriksa'),'') AS petugas", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbakt_pemeriksa.Text = rd.Item("petugas")
        rd.Close()

        cd = New MySqlCommand("SELECT IFNULL(cari_petugas_pelaporan('akuntansi_laporan_pengesah'),'') AS petugas", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbakt_pengesah.Text = rd.Item("petugas")
        rd.Close()

    End Sub

    Private Sub cmbkre_pengesah_GotFocus(sender As Object, e As EventArgs) Handles cmbkre_pengesah.GotFocus, cmbkre_pemeriksa.GotFocus, cmbkre_pembuat.GotFocus, cmbtab_pengesah.GotFocus, cmbtab_pemeriksa.GotFocus, cmbtab_pembuat.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbkre_pengesah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbkre_pengesah.KeyPress, cmbkre_pemeriksa.KeyPress, cmbkre_pembuat.KeyPress, cmbtab_pengesah.KeyPress, cmbtab_pemeriksa.KeyPress, cmbtab_pembuat.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbkre_pengesah_LostFocus(sender As Object, e As EventArgs) Handles cmbkre_pengesah.LostFocus, cmbkre_pemeriksa.LostFocus, cmbkre_pembuat.LostFocus, cmbtab_pengesah.LostFocus, cmbtab_pemeriksa.LostFocus, cmbtab_pembuat.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub petugas_pelaporan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        rd.Close()
        Dim data_edit(99) As String
        Dim tglskrg As String = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH-mm-ss")
        data_edit(0) = "'" + cmbtab_pembuat.Text.ToString.Split(" :")(0) + "' WHERE ttd_keterangan='tabungan_laporan_pembuat'"
        data_edit(1) = "'" + cmbtab_pemeriksa.Text.ToString.Split(" :")(0) + "' WHERE ttd_keterangan='tabungan_laporan_pemeriksa'"
        data_edit(2) = "'" + cmbtab_pengesah.Text.ToString.Split(" :")(0) + "' WHERE ttd_keterangan='tabungan_laporan_pengesah'"

        data_edit(3) = "'" + cmbkre_pembuat.Text.ToString.Split(" :")(0) + "' WHERE ttd_keterangan='kredit_laporan_pembuat'"
        data_edit(4) = "'" + cmbkre_pemeriksa.Text.ToString.Split(" :")(0) + "' WHERE ttd_keterangan='kredit_laporan_pemeriksa'"
        data_edit(5) = "'" + cmbkre_pengesah.Text.ToString.Split(" :")(0) + "' WHERE ttd_keterangan='kredit_laporan_pengesah'"

        data_edit(6) = "'" + cmbakt_pembuat.Text.ToString.Split(" :")(0) + "' WHERE ttd_keterangan='akuntansi_laporan_pembuat'"
        data_edit(7) = "'" + cmbakt_pemeriksa.Text.ToString.Split(" :")(0) + "' WHERE ttd_keterangan='akuntansi_laporan_pemeriksa'"
        data_edit(8) = "'" + cmbakt_pengesah.Text.ToString.Split(" :")(0) + "' WHERE ttd_keterangan='akuntansi_laporan_pengesah'"
        For i = 0 To 8
            cd = New MySqlCommand("UPDATE setup_ttd SET ttd_update_waktu='" & tglskrg & "', ttd_update_username='" & MDIParent1.username.Text & "', ttd_pegawai_kode=" + data_edit(i), koneksi)
            cd.ExecuteNonQuery()
        Next

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Setup Petugas Pelaporan"
        insert_log_user()

        MessageBox.Show("Petugas Pelaporan berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class