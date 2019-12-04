Imports MySql.Data.MySqlClient
Public Class data_kantor_pusat
    Dim data_edit(99) As String

    Private Sub data_kantor_pusat_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tnama_lembaga.Focus()
    End Sub

    Private Sub data_kantor_pusat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub data_kantor_pusat_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Sub data_kantor_pusat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = True
        combo()
        datakantor()
    End Sub
    Sub datakantor()
        cd = New MySqlCommand("SELECT *, cari_combo_komponen('09',kantor_dati2) AS kabkot, cari_combo_komponen('60',kantor_sandi_wil_bi) AS sandi FROM data_kantor", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tid_lembaga.Text = rd.Item("kantor_id")
        tnama_lembaga.Text = rd.Item("kantor_nama_lembaga")
        talamat.Text = rd.Item("kantor_alamat")
        tkecamatan.Text = rd.Item("kantor_kecamatan")
        tkota.Text = rd.Item("kantor_kota")
        tkode_pos.Text = rd.Item("kantor_kode_pos")
        ttelepon.Text = rd.Item("kantor_telepon")
        tfax.Text = rd.Item("kantor_fax")
        temail.Text = rd.Item("kantor_email")
        tjml_direktur.Text = rd.Item("kantor_jumlah_direktur")
        tjml_komisaris.Text = rd.Item("kantor_jumlah_komisaris")
        tpembuat_laporan.Text = rd.Item("kantor_pembuat_laporan")
        tpemeriksa_laporan.Text = rd.Item("kantor_pemeriksa_laporan")
        tnama_pimpinan.Text = rd.Item("kantor_nama_pimpinan")
        tnik1.Text = rd.Item("kantor_nik_pembuat_laporan")
        tnik2.Text = rd.Item("kantor_nik_pemeriksa_laporan")
        tnik3.Text = rd.Item("kantor_nik_nama_pimpinan")
        cmbdaerah.Text = rd.Item("kabkot")
        cmbsandi.Text = rd.Item("sandi")
        rd.Close()
    End Sub
    Sub simpan()
        data_edit(0) = "kantor_id='" + tid_lembaga.Text + "'"
        data_edit(1) = "kantor_nama_lembaga='" + tnama_lembaga.Text + "'"
        data_edit(2) = "kantor_alamat='" + talamat.Text + "'"
        data_edit(3) = "kantor_kecamatan='" + tkecamatan.Text + "'"
        data_edit(4) = "kantor_kota='" + tkota.Text + "'"
        data_edit(5) = "kantor_dati2='" + cmbdaerah.Text.ToString.Split(" :")(0) + "'"
        data_edit(6) = "kantor_sandi_wil_bi='" + cmbsandi.Text.ToString.Split(" :")(0) + "'"
        data_edit(7) = "kantor_kode_pos='" + tkode_pos.Text + "'"
        data_edit(8) = "kantor_telepon='" + ttelepon.Text + "'"
        data_edit(9) = "kantor_fax='" + tfax.Text + "'"
        data_edit(10) = "kantor_email='" + temail.Text + "'"
        data_edit(11) = "kantor_jumlah_direktur='" + tjml_direktur.Text + "'"
        data_edit(12) = "kantor_jumlah_komisaris='" + tjml_komisaris.Text + "'"
        data_edit(13) = "kantor_pembuat_laporan='" + tpembuat_laporan.Text + "'"
        data_edit(14) = "kantor_nik_pembuat_laporan='" + tnik1.Text + "'"
        data_edit(15) = "kantor_pemeriksa_laporan='" + tpemeriksa_laporan.Text + "'"
        data_edit(16) = "kantor_nik_pemeriksa_laporan='" + tnik2.Text + "'"
        data_edit(17) = "kantor_nama_pimpinan='" + tnama_pimpinan.Text + "'"
        data_edit(18) = "kantor_nik_nama_pimpinan='" + tnik3.Text + "'"
        data_edit(19) = "kantor_update_username='" + MDIParent1.username.Text + "'"
        data_edit(20) = "kantor_update_waktu='" + Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") + "'"
        Dim gabung = ""
        For n = 1 To 20
            If n = 1 Then
                gabung += data_edit(n)
            Else
                gabung += ", " + data_edit(n)
            End If
        Next
        cd = New MySqlCommand("UPDATE data_kantor SET " & gabung & " WHERE " & data_edit(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Memperbaharui Identitas data kantor"
        insert_log_user()

        MessageBox.Show("Data Kantor berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub cmbsandi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbsandi.KeyPress, cmbdaerah.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub tjml_direktur_TextChanged(sender As Object, e As EventArgs) Handles tjml_direktur.TextChanged, tjml_komisaris.TextChanged
        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub

    Private Sub tnik3_GotFocus(sender As Object, e As EventArgs) Handles tnik3.GotFocus, tnik2.GotFocus, tnik1.GotFocus, tnama_pimpinan.GotFocus, tpemeriksa_laporan.GotFocus, tpembuat_laporan.GotFocus, tjml_komisaris.GotFocus, tjml_direktur.GotFocus, temail.GotFocus, tfax.GotFocus, ttelepon.GotFocus, cmbsandi.GotFocus, cmbdaerah.GotFocus, tkode_pos.GotFocus, tkota.GotFocus, tkecamatan.GotFocus, talamat.GotFocus, tnama_lembaga.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tnik3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tnik3.KeyPress, tnik2.KeyPress, tnik1.KeyPress, tjml_komisaris.KeyPress, tjml_direktur.KeyPress, tfax.KeyPress, ttelepon.KeyPress, tkode_pos.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tnik3_LostFocus(sender As Object, e As EventArgs) Handles tnik3.LostFocus, tnik2.LostFocus, tnik1.LostFocus, tnama_pimpinan.LostFocus, tpemeriksa_laporan.LostFocus, tpembuat_laporan.LostFocus, tjml_komisaris.LostFocus, tjml_direktur.LostFocus, temail.LostFocus, tfax.LostFocus, ttelepon.LostFocus, cmbsandi.LostFocus, cmbdaerah.LostFocus, tkode_pos.LostFocus, tkota.LostFocus, tkecamatan.LostFocus, talamat.LostFocus, tnama_lembaga.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub data_kantor_pusat_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub
    Sub combo()
        cd = New MySqlCommand("CALL isi_combo('09')", koneksi)
        rd = cd.ExecuteReader
        With cmbdaerah.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('60')", koneksi)
        rd = cd.ExecuteReader
        With cmbsandi.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        simpan()
    End Sub
End Class