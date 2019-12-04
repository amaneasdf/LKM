Imports MySql.Data.MySqlClient
Public Class pengaturan_perkiraan

    Private Sub pengaturan_perkiraan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub pengaturan_perkiraan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        data()
        Me.ResizeRedraw = True
    End Sub

    Private Sub pengaturan_perkiraan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub


    Sub cariperkkas()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_kas1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_kas2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Sub cariperkpenutupantabungan()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_penutupan_tabungan1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_penutupan_tabungan2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Sub cariperkprovisi()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_provisi1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_provisi2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Sub cariperkadministrasi()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_administrasi1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_administrasi2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Sub cariperkmaterai()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_materai1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_materai2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Sub cariperkpremi()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_premi1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_premi2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Sub cariperknotaris()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_notaris1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_notaris2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Sub cariperklain()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_lain1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_lain2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Sub cariperkadmrekening()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_adm_rek1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_adm_rek2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Sub cariperkpasif()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_pasif1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_pasif2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Sub cariperkpajakbunga()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_pajak_bunga1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_pajak_bunga2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Sub cariperkdendaangsuran()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_denda_angsuran1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_denda_angsuran2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub


    Private Sub btncari_perk_kas_Click(sender As Object, e As EventArgs) Handles btncari_perk_kas.Click
        With pencarian_perkiraan
            .Label4.Text = "perkiraan kas"
            .ShowDialog()
        End With
    End Sub

    Private Sub btncari_perk_penutupan_tabungan_Click(sender As Object, e As EventArgs) Handles btncari_perk_penutupan_tabungan.Click
        With pencarian_perkiraan
            .Label4.Text = "perkiraan penutupan tabungan"
            .ShowDialog()
        End With
    End Sub

    Private Sub btncari_perk_provisi_Click(sender As Object, e As EventArgs) Handles btncari_perk_provisi.Click
        With pencarian_perkiraan
            .Label4.Text = "perkiraan provisi"
            .ShowDialog()
        End With
    End Sub

    Private Sub btncari_perk_administrasi_Click(sender As Object, e As EventArgs) Handles btncari_perk_administrasi.Click
        With pencarian_perkiraan
            .Label4.Text = "perkiraan administrasi"
            .ShowDialog()
        End With
    End Sub

    Private Sub btncari_perk_materai_Click(sender As Object, e As EventArgs) Handles btncari_perk_materai.Click
        With pencarian_perkiraan
            .Label4.Text = "perkiran materai"
            .ShowDialog()
        End With
    End Sub

    Private Sub btncari_perk_premi_Click(sender As Object, e As EventArgs) Handles btncari_perk_premi.Click
        With pencarian_perkiraan
            .Label4.Text = "perkiraan premi"
            .ShowDialog()
        End With
    End Sub

    Private Sub btncari_perk_notaris_Click(sender As Object, e As EventArgs) Handles btncari_perk_notaris.Click
        With pencarian_perkiraan
            .Label4.Text = "perkiraan notaris"
            .ShowDialog()
        End With
    End Sub

    Private Sub btncari_perk_lain_Click(sender As Object, e As EventArgs) Handles btncari_perk_lain.Click
        With pencarian_perkiraan
            .Label4.Text = "perkiraan lain"
            .ShowDialog()
        End With
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        rd.Close()
        Dim data_edit(99) As String
        'Dim tglskrg As String = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH-mm-ss")
        data_edit(0) = "'" + tperk_kas1.Text + "' WHERE perk_nama='Kas'"
        data_edit(1) = "'" + tperk_penutupan_tabungan1.Text + "' WHERE perk_nama='TabunganPendTutup'"
        data_edit(2) = "'" + tperk_provisi1.Text + "' WHERE perk_nama='KreditProvisi'"
        data_edit(3) = "'" + tperk_administrasi1.Text + "' WHERE perk_nama='KreditAdministrasi'"
        data_edit(4) = "'" + tperk_materai1.Text + "' WHERE perk_nama='KreditMaterai'"
        data_edit(5) = "'" + tperk_premi1.Text + "' WHERE perk_nama='KreditPremi'"
        data_edit(6) = "'" + tperk_notaris1.Text + "' WHERE perk_nama='KreditNotaris'"
        data_edit(7) = "'" + tperk_lain1.Text + "' WHERE perk_nama='KreditLain'"
        data_edit(8) = "'" + tperk_adm_rek1.Text + "' WHERE perk_nama='PendAdmRekening'"
        data_edit(9) = "'" + tperk_pasif1.Text + "' WHERE perk_nama='PendRekPasif'"
        data_edit(10) = "'" + tperk_pasif1.Text + "' WHERE perk_nama='PajakBunga'"
        data_edit(11) = "'" + tperk_pasif1.Text + "' WHERE perk_nama='DendaAngsuran'"
        For i = 0 To 11
            cd = New MySqlCommand("UPDATE setup_perkiraan SET perk_kode=" + data_edit(i), koneksi)
            cd.ExecuteNonQuery()
        Next

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Setup Perkiraan"
        insert_log_user()

        MessageBox.Show("Pengaturan Perkiraan berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Sub data()
        cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='Kas'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_kas1.Text = rd.Item("perk_kode")
        rd.Close()
        cariperkkas()

        cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='TabunganPendTutup'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_penutupan_tabungan1.Text = rd.Item("perk_kode")
        rd.Close()
        cariperkpenutupantabungan()

        cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='KreditProvisi'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_provisi1.Text = rd.Item("perk_kode")
        rd.Close()
        cariperkprovisi()

        cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='KreditAdministrasi'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_administrasi1.Text = rd.Item("perk_kode")
        rd.Close()
        cariperkadministrasi()

        cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='KreditMaterai'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_materai1.Text = rd.Item("perk_kode")
        rd.Close()
        cariperkmaterai()

        cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='KreditPremi'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_premi1.Text = rd.Item("perk_kode")
        rd.Close()
        cariperkpremi()

        cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='KreditNotaris'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_notaris1.Text = rd.Item("perk_kode")
        rd.Close()
        cariperknotaris()

        cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='KreditLain'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_lain1.Text = rd.Item("perk_kode")
        rd.Close()
        cariperklain()

        cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='PendAdmRekening'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_adm_rek1.Text = rd.Item("perk_kode")
        rd.Close()
        cariperkadmrekening()

        cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='PendRekPasif'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_pasif1.Text = rd.Item("perk_kode")
        rd.Close()
        cariperkpasif()

        cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='PajakBunga'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_pajak_bunga1.Text = rd.Item("perk_kode")
        rd.Close()
        cariperkpajakbunga()

        cd = New MySqlCommand("SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='DendaAngsuran'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_denda_angsuran1.Text = rd.Item("perk_kode")
        rd.Close()
        cariperkdendaangsuran()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With pencarian_perkiraan
            .Label4.Text = "perkiraan adm rekening"
            .ShowDialog()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With pencarian_perkiraan
            .Label4.Text = "perkiraan rekening pasif"
            .ShowDialog()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With pencarian_perkiraan
            .Label4.Text = "pajak bunga"
            .ShowDialog()
        End With
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With pencarian_perkiraan
            .Label4.Text = "denda angsuran"
            .ShowDialog()
        End With
    End Sub
End Class