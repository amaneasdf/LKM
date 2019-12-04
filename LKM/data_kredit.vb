Imports MySql.Data.MySqlClient
Public Class data_kredit
    Dim data_ke(99), data_edit(99) As String

    Private Sub data_kredit_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tkode_produk.Focus()
    End Sub

    Private Sub data_kredit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub data_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub data_kredit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            btnkeluar.PerformClick()
        End If
    End Sub
    Private Sub data_kredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo()
        Me.ResizeRedraw = True
    End Sub
    Sub combo()

        cd = New MySqlCommand("CALL isi_combo('95')", koneksi)
        rd = cd.ExecuteReader
        With cmbjenis_kredit.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('96')", koneksi)
        rd = cd.ExecuteReader
        cmbpot_provisi.Items.Clear()
        cmbpot_adm.Items.Clear()
        While rd.Read()
            cmbpot_provisi.Items.Add(rd.Item("text"))
            cmbpot_adm.Items.Add(rd.Item("text"))
        End While
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('22')", koneksi)
        rd = cd.ExecuteReader
        With cmbperiode.Items()
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('21')", koneksi)
        rd = cd.ExecuteReader
        With cmbsistem_bunga.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('97')", koneksi)
        rd = cd.ExecuteReader
        With cmbsistem_jasa.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        With cmbstatus.Items
            .Clear()
            .Add("1 : AKTIF")
            .Add("2 : NON-AKTIF")
        End With
    End Sub
    Sub def()
        cd = New MySqlCommand("SELECT cari_combo_komponen('95',(SELECT komp_default FROM sys_komponen WHERE komp_tag='JenisKredit')) AS jeniskredit", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbjenis_kredit.Text = rd.Item("jeniskredit")
        rd.Close()

        cd = New MySqlCommand("SELECT cari_combo_komponen('96',(SELECT komp_default FROM sys_komponen WHERE komp_tag='PotonganProvisi')) AS potprovisi", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbpot_provisi.Text = rd.Item("potprovisi")
        rd.Close()

        cd = New MySqlCommand("SELECT cari_combo_komponen('96',(SELECT komp_default FROM sys_komponen WHERE komp_tag='PotonganAdministrasi')) AS potadm", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbpot_adm.Text = rd.Item("potadm")
        rd.Close()

        cd = New MySqlCommand("SELECT cari_combo_komponen('97',(SELECT komp_default FROM sys_komponen WHERE komp_tag='SistemJasa')) AS sistemjasa", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        cmbsistem_jasa.Text = rd.Item("sistemjasa")
        rd.Close()
    End Sub
    Sub kosong()
        tkode_produk.Clear()
        tkode_produk.Enabled = True
        tnama_produk.Clear()
        cmbjenis_kredit.Text = ""
        tplafon1.Clear()
        tplafon2.Clear()
        cmbpot_provisi.Text = ""
        cmbpot_adm.Text = ""
        cmbperiode.Text = ""
        Label26.Text = ""
        cmbsistem_bunga.Text = ""
        cmbsistem_jasa.Text = ""
        tjkw1.Clear()
        tjkw2.Clear()
        tsb1.Text = "0,000"
        tsb2.Text = "0,000"
        tdenda.Text = "0,00"
        tspelling.Text = "0,00"
        tperk_kredit1.Clear()
        tperk_bunga1.Clear()

        cmbstatus.Text = "1 : AKTIF"
        def()
    End Sub
    Private Sub data_kredit_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbpot_provisi_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cmbpot_provisi.SelectedIndexChanged
        Select Case cmbpot_provisi.Text.ToString.Split(" :")(0)
            Case "0"
                tpot_provisi1.Text = "0,00"
                tpot_provisi2.Clear()
                tpot_provisi1.Enabled = False
                tpot_provisi2.Enabled = False
            Case "1"
                tpot_provisi1.Text = "0,00"
                tpot_provisi2.Clear()
                tpot_provisi1.Enabled = True
                tpot_provisi2.Enabled = False
            Case "2"
                tpot_provisi1.Text = "0,00"
                tpot_provisi2.Clear()
                tpot_provisi1.Enabled = False
                tpot_provisi2.Enabled = True
        End Select
    End Sub

    Private Sub cmbpot_adm_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cmbpot_adm.SelectedIndexChanged
        Select Case cmbpot_adm.Text.ToString.Split(" :")(0)
            Case "0"
                tpot_adm1.Text = "0,00"
                tpot_adm2.Clear()
                tpot_adm1.Enabled = False
                tpot_adm2.Enabled = False

            Case "1"
                tpot_adm1.Text = "0,00"
                tpot_adm2.Clear()
                tpot_adm1.Enabled = True
                tpot_adm2.Enabled = False

            Case "2"
                tpot_adm1.Text = "0,00"
                tpot_adm2.Clear()
                tpot_adm1.Enabled = False
                tpot_adm2.Enabled = True

        End Select
    End Sub

    Private Sub cmbperiode_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cmbperiode.SelectedIndexChanged
        Select Case cmbperiode.Text.ToString.Split(" :")(0)
            Case "1"
                Label26.Text = "hari"
                Label12.Text = "JKW (hari) :"
            Case "2"
                Label26.Text = "minggu"
                Label12.Text = "JKW (minggu) :"
            Case "3"
                Label26.Text = "bulan"
                Label12.Text = "JKW (bulan) :"
        End Select
    End Sub

    Private Sub cmbsistem_jasa_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cmbsistem_jasa.SelectedIndexChanged
        Select Case cmbsistem_jasa.Text.ToString.Split(" :")(0)
            Case "1"
                tsb1.Text = "0,000"
                tsb2.Text = "0,000"
                tsb1.Enabled = True
                tsb2.Enabled = True
            Case "2"
                tsb1.Text = "0,000"
                tsb2.Text = "0,000"
                tsb1.Enabled = False
                tsb2.Enabled = False
        End Select
    End Sub

    Private Sub tsb1_TextChanged(sender As Object, e As EventArgs) Handles tsb1.TextChanged, tsb2.TextChanged, tdenda.TextChanged
        If Val(sender.Text) > 100 Then
            sender.Clear()
        End If
    End Sub

    Private Sub tjkw_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tjkw2.KeyPress, tjkw1.KeyPress, tpot_adm2.KeyPress, tpot_provisi2.KeyPress, tplafon2.KeyPress, tplafon1.KeyPress, tspelling.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tjkw_TextChanged(sender As Object, e As EventArgs) Handles tjkw2.TextChanged, tjkw1.TextChanged, tpot_adm2.TextChanged, tpot_provisi2.TextChanged, tplafon2.TextChanged, tplafon1.TextChanged, tspelling.TextChanged
        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub

    Private Sub tdenda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tdenda.KeyPress, tsb2.KeyPress, tsb1.KeyPress, tpot_adm1.KeyPress, tpot_provisi1.KeyPress
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

    Private Sub tspelling_LostFocus(sender As Object, e As EventArgs) Handles tdenda.LostFocus, tsb2.LostFocus, tsb1.LostFocus, tpot_adm1.LostFocus, tpot_provisi1.LostFocus
        Try
            sender.Text = FormatNumber(sender.Text, 3)
        Catch ex As Exception
            sender.Text = "0,000"
        End Try
    End Sub

    Private Sub tspelling_TextChanged(sender As Object, e As EventArgs) Handles tspelling.TextChanged
        If Val(tspelling.Text) > 30 Then
            tspelling.Clear()
        End If
    End Sub

    Private Sub cmbstatus_GotFocus(sender As Object, e As EventArgs) Handles cmbstatus.GotFocus, tperk_bunga1.GotFocus, tperk_kredit1.GotFocus, tspelling.GotFocus, tdenda.GotFocus, tsb2.GotFocus, tsb1.GotFocus, tjkw2.GotFocus, tjkw1.GotFocus, cmbsistem_jasa.GotFocus, cmbsistem_bunga.GotFocus, cmbperiode.GotFocus, tpot_adm2.GotFocus, tpot_adm1.GotFocus, cmbpot_adm.GotFocus, tpot_provisi2.GotFocus, tpot_provisi1.GotFocus, cmbpot_provisi.GotFocus, tplafon2.GotFocus, tplafon1.GotFocus, cmbjenis_kredit.GotFocus, tnama_produk.GotFocus, tkode_produk.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbstatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbstatus.KeyPress, cmbsistem_jasa.KeyPress, cmbsistem_bunga.KeyPress, cmbperiode.KeyPress, cmbpot_adm.KeyPress, cmbpot_provisi.KeyPress, cmbjenis_kredit.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbstatus_LostFocus(sender As Object, e As EventArgs) Handles cmbstatus.LostFocus, tperk_bunga1.LostFocus, tperk_kredit1.LostFocus, tspelling.LostFocus, tdenda.LostFocus, tsb2.LostFocus, tsb1.LostFocus, tjkw2.LostFocus, tjkw1.LostFocus, cmbsistem_jasa.LostFocus, cmbsistem_bunga.LostFocus, cmbperiode.LostFocus, tpot_adm2.LostFocus, tpot_adm1.LostFocus, cmbpot_adm.LostFocus, tpot_provisi2.LostFocus, tpot_provisi1.LostFocus, cmbpot_provisi.LostFocus, tplafon2.LostFocus, tplafon1.LostFocus,
    cmbjenis_kredit.LostFocus, tnama_produk.LostFocus, tkode_produk.LostFocus

        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tkode_produk.Text = "" Then
            MessageBox.Show("Kode Produk harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_produk.Focus()
            Exit Sub
        ElseIf Len(tkode_produk.Text) < 2 Then
            MessageBox.Show("Panjang Kode harus 2.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_produk.Focus()
            Exit Sub
        ElseIf tnama_produk.Text = "" Then
            MessageBox.Show("Nama Produk harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_produk.Focus()
            Exit Sub
        ElseIf tplafon1.Text = "0" Then
            MessageBox.Show("Plafon Minimal harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tplafon1.Focus()
            Exit Sub
        ElseIf tplafon2.Text = "0" Then
            MessageBox.Show("Plafon Maksimal harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tplafon2.Focus()
            Exit Sub
        ElseIf cmbperiode.Text = "" Then
            MessageBox.Show("Jenis Periode angsuran harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbperiode.Focus()
            Exit Sub
        ElseIf cmbsistem_bunga.Text = "" Then
            MessageBox.Show("Sistem Bunga harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbsistem_bunga.Focus()
            Exit Sub
        ElseIf tjkw1.Text = "0" Then
            MessageBox.Show("JKW minimal harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjkw1.Focus()
            Exit Sub
        ElseIf tjkw2.Text = "0" Then
            MessageBox.Show("JKW maksimal harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjkw2.Focus()
            Exit Sub
        ElseIf tsb1.Text = "0,000" Then
            MessageBox.Show("Suku Bunga minimal harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tsb1.Focus()
            Exit Sub
        ElseIf tsb2.Text = "0,000" Then
            MessageBox.Show("Suku Bunga maksimal harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tsb2.Focus()
            Exit Sub
        End If
        cd = New MySqlCommand("SELECT * FROM data_kredit_produk WHERE kredit_kode='" & tkode_produk.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True And tkode_produk.Enabled = True Then
            rd.Close()
            MessageBox.Show("Kode Produk Kredit sudah Ada", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_produk.Focus()
        Else
            rd.Close()
            If tkode_produk.Enabled = True Then
                simpan()
            Else
                edit()
            End If
        End If
    End Sub
    Sub ar()
        data_ke(0) = tkode_produk.Text
        data_ke(1) = tnama_produk.Text
        data_ke(2) = cmbjenis_kredit.Text.ToString.Split(" :")(0)
        data_ke(3) = Format(tplafon1.Text, "General Number")
        data_ke(4) = Format(tplafon2.Text, "General Number")
        data_ke(5) = cmbpot_provisi.Text.ToString.Split(" :")(0)
        data_ke(6) = tpot_provisi1.Text.Replace(",", ".")
        data_ke(7) = Format(tpot_provisi2.Text, "General Number")
        data_ke(8) = cmbpot_adm.Text.ToString.Split(" :")(0)
        data_ke(9) = tpot_adm1.Text.Replace(",", ".")
        data_ke(10) = Format(tpot_adm2.Text, "General Number")
        data_ke(11) = cmbperiode.Text.ToString.Split(" :")(0)
        data_ke(12) = cmbsistem_bunga.Text.ToString.Split(" :")(0)
        data_ke(13) = cmbsistem_jasa.Text.ToString.Split(" :")(0)
        data_ke(14) = Format(tjkw1.Text, "General Number")
        data_ke(15) = Format(tjkw2.Text, "General Number")
        data_ke(16) = tsb1.Text.Replace(",", ".")
        data_ke(17) = tsb2.Text.Replace(",", ".")
        data_ke(18) = tdenda.Text.Replace(",", ".")
        data_ke(19) = tspelling.Text
        data_ke(20) = tperk_kredit1.Text
        data_ke(21) = tperk_bunga1.Text
        data_ke(22) = cmbstatus.Text.ToString.Split(" :")(0)
        data_ke(23) = MDIParent1.username.Text
        data_ke(24) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        data_ke(25) = MDIParent1.username.Text
        data_ke(26) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")

        data_edit(0) = "kredit_kode='" + data_ke(0) + "'"
        data_edit(1) = "kredit_nama_produk='" + data_ke(1) + "'"
        data_edit(2) = "kredit_jenis_kredit='" + data_ke(2) + "'"
        data_edit(3) = "kredit_plafon_min='" + data_ke(3) + "'"
        data_edit(4) = "kredit_plafon_max='" + data_ke(4) + "'"
        data_edit(5) = "kredit_pot_provisi='" + data_ke(5) + "'"
        data_edit(6) = "kredit_pot_provisi_p='" + data_ke(6) + "'"
        data_edit(7) = "kredit_pot_provisi_rp='" + data_ke(7) + "'"
        data_edit(8) = "kredit_pot_adm='" + data_ke(8) + "'"
        data_edit(9) = "kredit_pot_adm_p='" + data_ke(9) + "'"
        data_edit(10) = "kredit_pot_adm_rp='" + data_ke(10) + "'"
        data_edit(11) = "kredit_periode_angsuran='" + data_ke(11) + "'"
        data_edit(12) = "kredit_sistem_bunga='" + data_ke(12) + "'"
        data_edit(13) = "kredit_sistem_jasa='" + data_ke(13) + "'"
        data_edit(14) = "kredit_jkw_min='" + data_ke(14) + "'"
        data_edit(15) = "kredit_jkw_max='" + data_ke(15) + "'"
        data_edit(16) = "kredit_sb_min='" + data_ke(16) + "'"
        data_edit(17) = "kredit_sb_max='" + data_ke(17) + "'"
        data_edit(18) = "kredit_denda='" + data_ke(18) + "'"
        data_edit(19) = "kredit_spelling='" + data_ke(19) + "'"
        data_edit(20) = "kredit_perk_kredit='" + data_ke(20) + "'"
        data_edit(21) = "kredit_perk_bunga='" + data_ke(21) + "'"
        data_edit(22) = "kredit_status='" + data_ke(22) + "'"
        data_edit(23) = "kredit_reg_username='" + data_ke(23) + "'"
        data_edit(24) = "kredit_reg_waktu='" + data_ke(24) + "'"
        data_edit(25) = "kredit_update_username='" + data_ke(25) + "'"
        data_edit(26) = "kredit_update_waktu='" + data_ke(26) + "'"
    End Sub
    Sub simpan()
        tperk_kredit1.Text = "1.130.".ToString + tkode_produk.Text
        tperk_kredit2.Text = tkode_produk.Text.ToString + ". " + tnama_produk.Text.ToString

        cd = New MySqlCommand("INSERT INTO kode_perkiraan VALUES ('" & tperk_kredit1.Text & "', '1', '" & tperk_kredit2.Text & "', 'HARTA', '1.130', 'D', 'L', '1', '0', '3', '1')", koneksi)
        cd.ExecuteNonQuery()

        tperk_bunga1.Text = "2.120.".ToString + tkode_produk.Text
        tperk_bunga2.Text = "        i. Pend. Bg. Kredit : Baki Debet ".ToString + tnama_produk.Text.ToString

        cd = New MySqlCommand("INSERT INTO kode_perkiraan VALUES ('" & tperk_bunga1.Text & "', '4', '" & tperk_bunga2.Text & "', 'PENDAPATAN', '2.120', 'K', 'L', '1', '0', '3', '1')", koneksi)
        cd.ExecuteNonQuery()

        ar()
        Dim gabung = ""
        For n = 0 To 26
            If n = 0 Then
                gabung += "'" + data_ke(n) + "'"
            Else
                gabung += ",'" + data_ke(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_kredit_produk values (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Setup Kredit (kredit_kode : " + data_ke(0) + ")"
        insert_log_user()

        master_produk_kredit.data()
        tkode_produk.Enabled = False
        MessageBox.Show("Produk Kredit berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Sub edit()
        tperk_kredit2.Text = tkode_produk.Text.ToString + ". " + tnama_produk.Text.ToString

        cd = New MySqlCommand("UPDATE kode_perkiraan SET perkiraan_nama = '" & tperk_kredit2.Text & "' WHERE perkiraan_kode='" & tperk_kredit1.Text & "'", koneksi)
        cd.ExecuteNonQuery()

        tperk_bunga2.Text = "        i. Pend. Bg. Kredit : Baki Debet ".ToString + tnama_produk.Text.ToString

        cd = New MySqlCommand("UPDATE kode_perkiraan SET perkiraan_nama = '" & tperk_bunga2.Text & "' WHERE perkiraan_kode='" & tperk_bunga1.Text & "'", koneksi)
        cd.ExecuteNonQuery()

        ar()
        Dim gabung = ""
        For n = 1 To 26
            If n = 1 Then
                gabung += data_edit(n)
            ElseIf n = 23 Or n = 24 Then

            Else
                gabung += " ," + data_edit(n)
            End If
        Next
        cd = New MySqlCommand("UPDATE data_kredit_produk SET " & gabung & " WHERE " & data_edit(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Setup Kredit (kredit_kode : " + data_ke(0) + ")"
        insert_log_user()

        master_produk_kredit.data()
        MessageBox.Show("Produk Kredit berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Sub cekdatakredit()
        cd = New MySqlCommand("SELECT *,  cari_combo_komponen('95',kredit_jenis_kredit) AS jeniskredit, cari_combo_komponen('96',kredit_pot_provisi) AS provisi, cari_combo_komponen('96',kredit_pot_adm) AS adm,  cari_combo_komponen('22',kredit_periode_angsuran) AS periode, cari_combo_komponen('21',kredit_sistem_bunga) AS sistembunga, cari_combo_komponen('97',kredit_sistem_jasa) AS sistemjasa FROM data_kredit_produk WHERE kredit_kode='" & tkode_produk.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tkode_produk.Enabled = False
        tnama_produk.Text = rd.Item("kredit_nama_produk")
        
        tplafon1.Text = rd.Item("kredit_plafon_min")
        tplafon2.Text = rd.Item("kredit_plafon_max")
        tpot_provisi1.Text = FormatNumber(rd.Item("kredit_pot_provisi_p"), 2)
        tpot_provisi2.Text = rd.Item("kredit_pot_provisi_rp")
        tpot_adm1.Text = FormatNumber(rd.Item("kredit_pot_adm_p"), 2)
        tpot_adm2.Text = rd.Item("kredit_pot_adm_rp")
        tjkw1.Text = rd.Item("kredit_jkw_min")
        tjkw2.Text = rd.Item("kredit_jkw_max")
        tsb1.Text = FormatNumber(rd.Item("kredit_sb_min"), 3)
        tsb2.Text = FormatNumber(rd.Item("kredit_sb_max"), 3)
        tdenda.Text = FormatNumber(rd.Item("kredit_denda"), 2)
        tspelling.Text = rd.Item("kredit_spelling")
        tperk_kredit1.Text = rd.Item("kredit_perk_kredit")
        tperk_bunga1.Text = rd.Item("kredit_perk_bunga")

        

        If rd.Item("kredit_status") = "1" Then
            cmbstatus.Text = "1 : AKTIF"
            tnama_produk.Enabled = False
        Else
            cmbstatus.Text = "2 : NON-AKTIF"
            tnama_produk.Enabled = True
        End If

        cmbjenis_kredit.Text = rd.Item("jeniskredit")
        cmbpot_provisi.Text = rd.Item("provisi")
        cmbpot_adm.Text = rd.Item("adm")
        cmbperiode.Text = rd.Item("periode")

        Select Case cmbperiode.Text.ToString.Split(" :")(0)
            Case "1"
                Label26.Text = "hari"
                Label12.Text = "JKW (hari) :"
            Case "2"
                Label26.Text = "minggu"
                Label12.Text = "JKW (minggu) :"
            Case "3"
                Label26.Text = "bulan"
                Label12.Text = "JKW (bulan) :"
        End Select

        cmbsistem_bunga.Text = rd.Item("sistembunga")
        cmbsistem_jasa.Text = rd.Item("sistemjasa")
        rd.Close()

        cariperkkredit()
        cariperkbunga()
    End Sub

    Private Sub btncari_perk_kredit_Click(sender As Object, e As EventArgs)
        With pencarian_perkiraan
            .Label4.Text = "data_kredit_perk_kredit"
            .ShowDialog()
        End With
    End Sub
    Sub cariperkkredit()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_kredit1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_kredit2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub

    Private Sub btncari_perk_pyad_Click(sender As Object, e As EventArgs)
        With pencarian_perkiraan
            .Label4.Text = "data_kredit_perk_pyad"
            .ShowDialog()
        End With
    End Sub

    Private Sub btncari_perk_pyd_Click(sender As Object, e As EventArgs)
        With pencarian_perkiraan
            .Label4.Text = "data_kredit_perk_pyd"
            .ShowDialog()
        End With
    End Sub

    Private Sub btncari_perk_bunga_Click(sender As Object, e As EventArgs)
        With pencarian_perkiraan
            .Label4.Text = "data_kredit_perk_bunga"
            .ShowDialog()
        End With
    End Sub
    Sub cariperkbunga()
        cd = New MySqlCommand("SELECT cari_nama_perkiraan('" & tperk_bunga1.Text & "') AS nama_perkiraan", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tperk_bunga2.Text = rd.Item("nama_perkiraan")
        rd.Close()
    End Sub
    Private Sub tperk_kredit1_LostFocus(sender As Object, e As EventArgs) Handles tperk_kredit1.LostFocus
        cariperkkredit()
    End Sub
   
    Private Sub tperk_bunga1_LostFocus(sender As Object, e As EventArgs) Handles tperk_bunga1.LostFocus
        cariperkbunga()
    End Sub

    Private Sub tperk_kredit1_TextChanged(sender As Object, e As EventArgs) Handles tperk_kredit1.TextChanged

    End Sub

    Private Sub tpot_provisi1_TextChanged(sender As Object, e As EventArgs) Handles tpot_provisi1.TextChanged

    End Sub

    Private Sub tkode_produk_TextChanged(sender As Object, e As EventArgs) Handles tkode_produk.TextChanged

    End Sub
End Class