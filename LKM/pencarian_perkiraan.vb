Imports MySql.Data.MySqlClient
Public Class pencarian_perkiraan
    Dim kode As String

    Private Sub pencarian_perkiraan_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tfilter.Focus()
    End Sub

    Private Sub pencarian_perkiraan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub pencarian_perkiraan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btninsert.Enabled = False
        tfilter.Clear()
        ukuran()
        tampil()
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
        da = New MySqlDataAdapter("SELECT perkiraan_kode, perkiraan_nama, perkiraan_d_or_k, if(perkiraan_jurnal='1', 'YA', '') AS perkiraan_jurnal FROM kode_perkiraan WHERE perkiraan_status='1'", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
    End Sub
    Sub cari()
        btninsert.Enabled = False
        da = New MySqlDataAdapter("SELECT perkiraan_kode, perkiraan_nama, perkiraan_d_or_k, if(perkiraan_jurnal='1', 'YA', '') AS perkiraan_jurnal FROM kode_perkiraan WHERE perkiraan_status='1' AND (perkiraan_kode LIKE '%" & tfilter.Text & "%' OR perkiraan_nama LIKE '%" & tfilter.Text & "%')", koneksi)
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
            .Add("Kode Perkiraan", 110, HorizontalAlignment.Left)
            .Add("Nama Perkiraan", 400, HorizontalAlignment.Left)
            .Add("D/K", 50, HorizontalAlignment.Center)
            .Add("Jurnal", 70, HorizontalAlignment.Center)
        End With
    End Sub
    Sub data()
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("perkiraan_kode"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("perkiraan_nama"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("perkiraan_d_or_k"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("perkiraan_jurnal"))
            Next
        End With
    End Sub

    Private Sub pencarian_perkiraan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        If Len(tfilter.Text) < 1 Then
            tampil()
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
        If Label4.Text = "data_tabungan_perk_tabungan" Then
            With data_tabungan
                .tperk_tabungan1.Text = kode
                .cariperktabungan()
            End With
        ElseIf Label4.Text = "data_tabungan_perk_biaya_bunga" Then
            With data_tabungan
                .tperk_biaya_bunga1.Text = kode
                .cariperkbiayabunga()
            End With
        ElseIf Label4.Text = "transaksi_tabungan_kode_perkiraan" Then
            With transaksi__tabungan
                .tnomor_rekening.Text = kode
                .cariperkiraan()
            End With
        ElseIf Label4.Text = "data_kredit_perk_kredit" Then
            With data_kredit
                .tperk_kredit1.Text = kode
                .cariperkkredit()
            End With
        ElseIf Label4.Text = "data_kredit_perk_bunga" Then
            With data_kredit
                .tperk_bunga1.Text = kode
                .cariperkbunga()
            End With
        ElseIf Label4.Text = "transaksi_jurnal_kas" Then
            With transaksi_jurnal_kas
                .tkode_perkiraan.Text = kode
                .cariperkiraan()
            End With
        ElseIf Label4.Text = "transaksi_jurnal_nonkas_debet" Then
            With transaksi_jurnal_non_kas
                .tkode_perkiraan_d.Text = kode
                .cariperkiraandebet()
            End With
        ElseIf Label4.Text = "transaksi_jurnal_nonkas_kredit" Then
            With transaksi_jurnal_non_kas
                .tkode_perkiraan_k.Text = kode
                .cariperkiraankredit()
            End With
        ElseIf Label4.Text = "cetak_rincian_mutasi_saldo" Then
            With cetak_rincian_mutasi_saldo
                .tkode_perkiraan.Text = kode
                .cariperkiraan()
            End With
        ElseIf Label4.Text = "transaksi_angsuran_kredit_kode_perkiraan" Then
            With transaksi_angsuran_kredit
                .tnomor_rekening2.Text = kode
                .cariperkiraan()
            End With
        ElseIf Label4.Text = "perkiraan kas" Then
            With pengaturan_perkiraan
                .tperk_kas1.Text = kode
                .cariperkkas()
            End With
        ElseIf Label4.Text = "perkiraan penutupan tabungan" Then
            With pengaturan_perkiraan
                .tperk_penutupan_tabungan1.Text = kode
                .cariperkpenutupantabungan()
            End With
        ElseIf Label4.Text = "perkiraan provisi" Then
            With pengaturan_perkiraan
                .tperk_provisi1.Text = kode
                .cariperkprovisi()
            End With
        ElseIf Label4.Text = "perkiraan administrasi" Then
            With pengaturan_perkiraan
                .tperk_administrasi1.Text = kode
                .cariperkadministrasi()
            End With
        ElseIf Label4.Text = "perkiran materai" Then
            With pengaturan_perkiraan
                .tperk_materai1.Text = kode
                .cariperkmaterai()
            End With
        ElseIf Label4.Text = "perkiraan premi" Then
            With pengaturan_perkiraan
                .tperk_premi1.Text = kode
                .cariperkpremi()
            End With
        ElseIf Label4.Text = "perkiraan notaris" Then
            With pengaturan_perkiraan
                .tperk_notaris1.Text = kode
                .cariperknotaris()
            End With
        ElseIf Label4.Text = "perkiraan lain" Then
            With pengaturan_perkiraan
                .tperk_lain1.Text = kode
                .cariperklain()
            End With
        ElseIf Label4.Text = "perkiraan adm rekening" Then
            With pengaturan_perkiraan
                .tperk_adm_rek1.Text = kode
                .cariperkadmrekening()
            End With
        ElseIf Label4.Text = "perkiraan rekening pasif" Then
            With pengaturan_perkiraan
                .tperk_pasif1.Text = kode
                .cariperkpasif()
            End With
        ElseIf Label4.Text = "pajak bunga" Then
            With pengaturan_perkiraan
                .tperk_pajak_bunga1.Text = kode
                .cariperkpajakbunga()
            End With
        ElseIf Label4.Text = "denda angsuran" Then
            With pengaturan_perkiraan
                .tperk_denda_angsuran1.Text = kode
                .cariperkdendaangsuran()
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