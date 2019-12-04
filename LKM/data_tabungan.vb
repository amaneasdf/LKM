Imports MySql.Data.MySqlClient
Public Class data_tabungan
    Dim array(99), arr(99) As String

    Private Sub tpremi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ttanggal_dapet_bunga.KeyPress, tsuku_bunga.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9,]" _
            OrElse KeyAscii = Keys.Back _
             OrElse KeyAscii = Keys.Space _
            OrElse KeyAscii = Keys.Return _
            OrElse KeyAscii = Keys.Delete) Then
            KeyAscii = 0
        End If
        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub tsuku_bunga_LostFocus(sender As Object, e As EventArgs) Handles ttanggal_dapet_bunga.LostFocus, tsuku_bunga.LostFocus
        Try
            sender.Text = FormatNumber(sender.Text, 3)
        Catch ex As Exception
            sender.Text = "0,000"
        End Try
    End Sub

    Private Sub tsuku_bunga_TextChanged(sender As Object, e As EventArgs) Handles tsuku_bunga.TextChanged
        If Val(sender.Text) >= 100 Then
            sender.Text = "0,000"
        End If
    End Sub

    Private Sub tadm_penutupan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tadm_penutupan.KeyPress, tjangka_waktu_tabungan_pasif.KeyPress, tadm_tabungan_pasif.KeyPress, tadm_rekening.KeyPress, tsaldo_minimal.KeyPress, tsaldo_mengendap.KeyPress, tsetoran_minimal.KeyPress, tsaldo_pembukaan.KeyPress, tkode_produk.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tadm_penutupan_TextChanged(sender As Object, e As EventArgs) Handles tadm_penutupan.TextChanged, tjangka_waktu_tabungan_pasif.TextChanged, tadm_tabungan_pasif.TextChanged, tadm_rekening.TextChanged, tsaldo_minimal.TextChanged, tsaldo_mengendap.TextChanged, tsetoran_minimal.TextChanged, tsaldo_pembukaan.TextChanged, ttanggal_dapet_bunga.TextChanged

        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub

    Private Sub cmbstatus_GotFocus(sender As Object, e As EventArgs) Handles cmbstatus.GotFocus, tperk_biaya_bunga1.GotFocus, tperk_tabungan1.GotFocus, tadm_penutupan.GotFocus, tjangka_waktu_tabungan_pasif.GotFocus, tadm_tabungan_pasif.GotFocus, tadm_rekening.GotFocus, ttanggal_dapet_bunga.GotFocus, tsuku_bunga.GotFocus, tsaldo_minimal.GotFocus, cmbmetode_hitung_bunga.GotFocus, tsaldo_mengendap.GotFocus, tsetoran_minimal.GotFocus, tsaldo_pembukaan.GotFocus, cmbjenis_tabungan.GotFocus, tnama_produk.GotFocus, tkode_produk.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbstatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbstatus.KeyPress, cmbmetode_hitung_bunga.KeyPress, cmbjenis_tabungan.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbstatus_LostFocus(sender As Object, e As EventArgs) Handles cmbstatus.LostFocus, tperk_biaya_bunga1.LostFocus, tperk_tabungan1.LostFocus, tadm_penutupan.LostFocus, tjangka_waktu_tabungan_pasif.LostFocus, tadm_tabungan_pasif.LostFocus, tadm_rekening.LostFocus, ttanggal_dapet_bunga.LostFocus, tsuku_bunga.LostFocus, tsaldo_minimal.LostFocus, cmbmetode_hitung_bunga.LostFocus, tsaldo_mengendap.LostFocus, tsetoran_minimal.LostFocus, tsaldo_pembukaan.LostFocus, cmbjenis_tabungan.LostFocus, tnama_produk.LostFocus, tkode_produk.LostFocus
        sender.BackColor = warna_lostfocus

        If sender.text = ttanggal_dapet_bunga.Text Then
            If Val(ttanggal_dapet_bunga.Text) > 31 Or Val(ttanggal_dapet_bunga.Text) = 0 Then
                MessageBox.Show("Tanggal maksimal yang diinputkan adalah 31.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ttanggal_dapet_bunga.Text = "1"
                ttanggal_dapet_bunga.Focus()
            End If
        End If
    End Sub

    Private Sub data_tabungan_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tkode_produk.Focus()
    End Sub

    Private Sub data_tabungan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub data_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub data_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo()
        Me.ResizeRedraw = True
    End Sub
    Sub combo()
        cd = New MySqlCommand("CALL isi_combo('93')", koneksi)
        rd = cd.ExecuteReader
        With cmbjenis_tabungan.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('19')", koneksi)
        rd = cd.ExecuteReader
        With cmbmetode_hitung_bunga.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('94')", koneksi)
        rd = cd.ExecuteReader
        With cmbstatus.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()
    End Sub

    Sub def()
        cd = New MySqlCommand("SELECT cari_combo_komponen('94',(SELECT komp_default FROM sys_komponen WHERE komp_tag='statustabungan')) AS status", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbstatus.Text = rd.Item("status")
        rd.Close()
    End Sub

    Sub kosong()
        tkode_produk.Enabled = True
        tnama_produk.Enabled = True
        tkode_produk.Clear()
        tnama_produk.Clear()
        cmbjenis_tabungan.Text = ""
        tsaldo_pembukaan.Clear()
        tsetoran_minimal.Clear()
        tsaldo_mengendap.Clear()
        cmbmetode_hitung_bunga.Text = ""
        tsaldo_minimal.Clear()
        tsuku_bunga.Text = "0,000"
        ttanggal_dapet_bunga.Text = "0"
        tadm_rekening.Clear()
        tadm_penutupan.Clear()
        tadm_tabungan_pasif.Clear()
        tjangka_waktu_tabungan_pasif.Clear()
        tperk_biaya_bunga1.Clear()
        tperk_biaya_bunga2.Clear()
        tperk_tabungan1.Clear()
        tperk_tabungan2.Clear()
        cmbstatus.Text = ""
        def()
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tkode_produk.Text = "" Then
            MessageBox.Show("Kode Produk Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_produk.Focus()
            Exit Sub
        ElseIf Len(tkode_produk.Text) < 2 Then
            MessageBox.Show("Panjang Kode harus 2.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_produk.Focus()
            Exit Sub
        ElseIf tnama_produk.Text = "" Then
            MessageBox.Show("Nama Produk Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_produk.Focus()
            Exit Sub
        ElseIf cmbjenis_tabungan.Text = "" Then
            MessageBox.Show("Jenis Tanungan harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbjenis_tabungan.Focus()
            Exit Sub
        ElseIf cmbmetode_hitung_bunga.Text = "" Then
            MessageBox.Show("Metode Hitung Bunga harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbmetode_hitung_bunga.Focus()
            Exit Sub
        End If
        cd = New MySqlCommand("SELECT * FROM data_tabungan_produk WHERE tabungan_kode='" & tkode_produk.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True And tkode_produk.Enabled = True Then
            rd.Close()
            MessageBox.Show("Kode Produk Tabungan sudah Ada", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_produk.Focus()
        Else
            rd.Close()
            If tkode_produk.Enabled = True Then
                simpan()
                tkode_produk.Enabled = False
                'tnama_produk.Enabled = False
            Else
                edit()
            End If
            btnriwayat.Enabled = True
        End If
    End Sub
    Sub ar()
        array(0) = tkode_produk.Text
        array(1) = tnama_produk.Text
        array(2) = cmbjenis_tabungan.Text.ToString.Split(" :")(0)
        array(3) = Format(tsaldo_pembukaan.Text, "General Number")
        array(4) = Format(tsetoran_minimal.Text, "General Number")
        array(5) = Format(tsaldo_mengendap.Text, "General Number")
        array(6) = cmbmetode_hitung_bunga.Text.ToString.Split(" :")(0)
        array(7) = Format(tsaldo_minimal.Text, "General Number")
        array(8) = tsuku_bunga.Text.Replace(",", ".")
        array(9) = ttanggal_dapet_bunga.Text
        array(10) = Format(tadm_rekening.Text, "General Number")
        array(11) = Format(tadm_tabungan_pasif.Text, "General Number")
        array(12) = Format(tjangka_waktu_tabungan_pasif.Text, "General Number")
        array(13) = Format(tadm_penutupan.Text, "General Number")
        array(14) = tperk_tabungan1.Text
        array(15) = tperk_biaya_bunga1.Text
        array(16) = cmbstatus.Text.ToString.Split(" :")(0)
        array(17) = MDIParent1.username.Text
        array(18) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        array(19) = MDIParent1.username.Text
        array(20) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")

        arr(0) = "tabungan_kode='" + array(0) + "'"
        arr(1) = "tabungan_nama_produk='" + array(1) + "'"
        arr(2) = "tabungan_jenis_tabungan='" + array(2) + "'"
        arr(3) = "tabungan_saldo_pembukaan='" + array(3) + "'"
        arr(4) = "tabungan_setoran_minimal='" + array(4) + "'"
        arr(5) = "tabungan_saldo_mengendap='" + array(5) + "'"
        arr(6) = "tabungan_metode_hitung_bunga='" + array(6) + "'"
        arr(7) = "tabungan_saldo_minimal_dapat_bunga='" + array(7) + "'"
        arr(8) = "tabungan_suku_bunga='" + array(8) + "'"
        arr(9) = "tabungan_tanggal_dapat_bunga_awal='" + array(9) + "'"
        arr(10) = "tabungan_adm_rekening='" + array(10) + "'"
        arr(11) = "tabungan_adm_tabungan_pasif='" + array(11) + "'"
        arr(12) = "tabungan_jw_tabungan_pasif='" + array(12) + "'"
        arr(13) = "tabungan_adm_penutupan='" + array(13) + "'"
        arr(14) = "tabungan_perk_tabungan='" + array(14) + "'"
        arr(15) = "tabungan_perk_biaya_bunga='" + array(15) + "'"
        arr(16) = "tabungan_status='" + array(16) + "'"
        arr(17) = "tabungan_reg_username='" + array(17) + "'"
        arr(18) = "tabungan_reg_waktu='" + array(18) + "'"
        arr(19) = "tabungan_update_username='" + array(19) + "'"
        arr(20) = "tabungan_update_waktu='" + array(20) + "'"
        
    End Sub
    Sub simpan()
        tperk_tabungan1.Text = "1.210.".ToString + tkode_produk.Text
        tperk_tabungan2.Text = tkode_produk.Text.ToString + ". ".ToString + tnama_produk.Text.ToString

        cd = New MySqlCommand("INSERT INTO kode_perkiraan VALUES ('" & tperk_tabungan1.Text & "', '2', '" & tperk_tabungan2.Text & "', 'KEWAJIBAN', '1.210', 'K', 'R', '1', '0', '3', '1')", koneksi)
        cd.ExecuteNonQuery()

        tperk_biaya_bunga1.Text = "2.171.".ToString + tkode_produk.Text
        tperk_biaya_bunga2.Text = "            - Biaya Bunga - ".ToString + tnama_produk.Text.ToString

        cd = New MySqlCommand("INSERT INTO kode_perkiraan VALUES ('" & tperk_biaya_bunga1.Text & "', '5', '" & tperk_biaya_bunga2.Text & "', 'BIAYA', '2.171', 'D', 'R', '1', '1', '3', '1')", koneksi)
        cd.ExecuteNonQuery()

        ar()
        Dim gabung = ""
        For n = 0 To 20
            If n = 0 Then
                gabung += "'" + array(n) + "'"
            Else
                gabung += ",'" + array(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_tabungan_produk VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()
        simpanriwayattabungan()
        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Setup Tabungan (tabungan_kode : " + array(0) + ")"
        insert_log_user()


        master_produk_tabungan.data()
        MessageBox.Show("Produk Tabungan berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Sub edit()
        tperk_tabungan2.Text = tkode_produk.Text.ToString + ". ".ToString + tnama_produk.Text.ToString

        cd = New MySqlCommand("UPDATE kode_perkiraan SET perkiraan_nama = '" & tperk_tabungan2.Text & "' WHERE perkiraan_kode='" & tperk_tabungan1.Text & "'", koneksi)
        cd.ExecuteNonQuery()

        tperk_biaya_bunga2.Text = "            - Biaya Bunga - ".ToString + tnama_produk.Text.ToString

        cd = New MySqlCommand("UPDATE kode_perkiraan SET perkiraan_nama = '" & tperk_biaya_bunga2.Text & "' WHERE perkiraan_kode='" & tperk_biaya_bunga1.Text & "'", koneksi)
        cd.ExecuteNonQuery()

        ar()
        Dim gabung = ""
        For n = 1 To 20
            If n = 1 Then
                gabung += arr(n)
            ElseIf n = 17 Or n = 18 Then

            Else
                gabung += " ," + arr(n)
            End If
        Next
        cd = New MySqlCommand("UPDATE data_tabungan_produk SET " & gabung & " WHERE " & arr(0) & "", koneksi)
        cd.ExecuteNonQuery()
        simpanriwayattabungan()
        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Setup Tabungan (tabungan_kode : " + array(0) + ")"
        insert_log_user()


        master_produk_tabungan.data()
        MessageBox.Show("Produk Tabungan berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Sub simpanriwayattabungan()
        ar()
        Dim gabung = ""
        For n = 0 To 18
            If n = 0 Then
                gabung += "'" + array(n) + "'"
            Else
                gabung += ",'" + array(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_tabungan_produk_riwayat VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()
    End Sub

    Private Sub data_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncari_perk_tabungan_Click(sender As Object, e As EventArgs)
        With pencarian_perkiraan
            .Label4.Text = "data_tabungan_perk_tabungan"
            .ShowDialog()
        End With
    End Sub
    Sub cariperktabungan()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_tabungan1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_tabungan2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Private Sub tperk_tabungan1_LostFocus(sender As Object, e As EventArgs) Handles tperk_tabungan1.LostFocus
        cariperktabungan()
    End Sub

    Private Sub btncari_perk_biaya_bunga_Click(sender As Object, e As EventArgs)
        With pencarian_perkiraan
            .Label4.Text = "data_tabungan_perk_biaya_bunga"
            .ShowDialog()
        End With
    End Sub
    Sub cariperkbiayabunga()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_biaya_bunga1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_biaya_bunga2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub
    Private Sub tperk_biaya_bunga1_LostFocus(sender As Object, e As EventArgs) Handles tperk_biaya_bunga1.LostFocus
        cariperkbiayabunga()
    End Sub

    Private Sub btnriwayat_Click(sender As Object, e As EventArgs) Handles btnriwayat.Click
        With riwayat_produk_tabungan
            .tkode_produk.Text = tkode_produk.Text
            .tnama_produk.Text = tnama_produk.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub tkode_produk_TextChanged(sender As Object, e As EventArgs) Handles tkode_produk.TextChanged

    End Sub
End Class