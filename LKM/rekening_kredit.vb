Imports MySql.Data.MySqlClient
Public Class rekening_kredit
    Dim tp, s, p As String
    Dim data_ke(99), data_edit(99) As String
    Dim sb_min, sb_max As Decimal
    Dim total As Integer
    Dim bunga, tgl, pk, jumlah, tx As String
    Dim kd As String
    Dim plafon_akad_min, plafon_akad_max, jkw_min, jkw_max As String

    Private Sub tkode_skim_LostFocus(sender As Object, e As EventArgs) Handles tkode_skim.LostFocus
        cariproduk()
    End Sub

    Private Sub cmbskim_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbskim.SelectedIndexChanged
        tkode_skim.Text = cmbskim.Text.ToString.Split(" :")(0)
        cariproduk()
    End Sub

    Private Sub tnasabah_id_LostFocus(sender As Object, e As EventArgs) Handles tnasabah_id.LostFocus
        carinasabah()
    End Sub

    Private Sub tno_akad_awal_TextChanged(sender As Object, e As EventArgs) Handles tno_akad_awal.TextChanged
        tno_akad_akhir.Text = tno_akad_awal.Text
    End Sub

    Private Sub tplafon_induk_TextChanged(sender As Object, e As EventArgs) Handles tplafon_induk.TextChanged
        rumus()
    End Sub

    Private Sub tjkw_TextChanged(sender As Object, e As EventArgs) Handles tjkw.TextChanged
        selisih()
    End Sub

    Private Sub cmbsistem_angsuran_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsistem_angsuran.SelectedIndexChanged
        pilihsistem()
        selisih()
    End Sub
    Sub pilihsistem()

        Select Case cmbsistem_angsuran.Text.ToString.Split(" :")(0)
            Case "1"
                'tsistem_angsuran.Enabled = False
                'tsistem_angsuran.Clear()
                Label22.Text = "hari"
            Case "2"
                'tsistem_angsuran.Enabled = True
                'tsistem_angsuran.Text = "7"
                Label22.Text = "minggu"
            Case "3"
                'tsistem_angsuran.Enabled = False
                'tsistem_angsuran.Clear()
                Label22.Text = "bulan"
            Case Else
                Label22.Text = ""
        End Select
    End Sub

    Private Sub tadministrasi1_TextChanged(sender As Object, e As EventArgs) Handles tadministrasi1.TextChanged
        rumus()
    End Sub

    Private Sub ttabungan1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tadministrasi1.KeyPress, tprovisi1.KeyPress, tsuku_bunga.KeyPress
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

    Private Sub ttabungan1_LostFocus(sender As Object, e As EventArgs) Handles tadministrasi1.LostFocus, tprovisi1.LostFocus, tsuku_bunga.LostFocus
        Try
            sender.Text = FormatNumber(sender.Text, 3)
        Catch ex As Exception
            sender.Text = "0,000"
        End Try
    End Sub

    Private Sub tlain_GotFocus(sender As Object, e As EventArgs) Handles tlain.GotFocus, tnotaris.GotFocus, tasuransi.GotFocus, tmaterai.GotFocus, tadministrasi2.GotFocus, tadministrasi1.GotFocus, tprovisi2.GotFocus, tprovisi1.GotFocus, tkolek.GotFocus, cmbsistem_bunga.GotFocus, cmbsistem_angsuran.GotFocus, tjkw.GotFocus, tsuku_bunga.GotFocus, tplafon_induk.GotFocus, tno_akad_akhir.GotFocus, tno_akad_awal.GotFocus, tno_rekening2.GotFocus, tnasabah_id.GotFocus, cmbskim.GotFocus, tkode_skim.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tlain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tlain.KeyPress, tnotaris.KeyPress, tasuransi.KeyPress, tmaterai.KeyPress, tadministrasi2.KeyPress, tprovisi2.KeyPress, tjkw.KeyPress, tplafon_induk.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tlain_LostFocus(sender As Object, e As EventArgs) Handles tlain.LostFocus, tnotaris.LostFocus, tasuransi.LostFocus, tmaterai.LostFocus, tadministrasi2.LostFocus, tadministrasi1.LostFocus, tprovisi2.LostFocus, tprovisi1.LostFocus, tkolek.LostFocus, cmbsistem_bunga.LostFocus, cmbsistem_angsuran.LostFocus, tjkw.LostFocus, tsuku_bunga.LostFocus, tplafon_induk.LostFocus, tno_akad_akhir.LostFocus, tno_akad_awal.LostFocus, tno_rekening2.LostFocus, tnasabah_id.LostFocus, cmbskim.LostFocus, tkode_skim.LostFocus
        sender.BackColor = warna_lostfocus

        If sender.text = tprovisi2.Text Or sender.text = tadministrasi2.Text Then
            rumus2()
        End If
    End Sub

    Private Sub tlain_TextChanged(sender As Object, e As EventArgs) Handles tlain.TextChanged, tnotaris.TextChanged, tasuransi.TextChanged, tmaterai.TextChanged, tadministrasi2.TextChanged, tprovisi2.TextChanged, tjkw.TextChanged, tplafon_induk.TextChanged
        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub

    Private Sub btndata_agunan_Click(sender As Object, e As EventArgs) Handles btndata_agunan.Click
        With agunan_kredit
            .kosong()
            .Label21.Text = Format(tplafon_induk.Text, "General Number")
            .tno_rekening.Text = tno_rekening1.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btndata_pelengkap_Click(sender As Object, e As EventArgs) Handles btndata_pelengkap.Click

        Try
            rd.Close()
        Catch ex As Exception

        End Try

        With data_pelengkap
            .kosong()
            .tno_rekening1.Text = tno_rekening1.Text
            .caridatapelengkap()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub cmbstatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbstatus.KeyPress, cmbsistem_bunga.KeyPress, cmbsistem_angsuran.KeyPress, cmbskim.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub btnbuat_jadual_Click(sender As Object, e As EventArgs) Handles btnbuat_jadual.Click
        If btnbuat_jadual.Text = "Jadual Angsuran" Then
            With jadual_angsuran
                .kosong()
                .tno_rekening.Text = tno_rekening1.Text
                .caridata()

                .tampil()
                .ShowDialog()
            End With
        Else
            cmbstatus.Text = "1 : SETUP"
            ar()
            cd = New MySqlCommand("UPDATE data_kredit_rekening SET " & data_edit(23) & " WHERE " & data_edit(0) & "", koneksi)
            cd.ExecuteNonQuery()
            With jadual_angsuran
                .tno_rekening.Text = tno_rekening1.Text
                .caridata()
                .buatjadual()
            End With
            MessageBox.Show("Bunga Kredit berhasil dibuat.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            btndata_pelengkap.Enabled = True
            btndata_agunan.Enabled = True
            btnbuat_jadual.Text = "Jadual Angsuran"
            master_rekening_kredit.btnfilter.PerformClick()
        End If
        tombol()
    End Sub

    Sub buatjadual()

        total = 0
        If cmbsistem_angsuran.Text.ToString.Split(" :")(0) = "1" Then
            tx = "d"
            bunga = Format(FormatNumber((tsuku_bunga.Text / 100) * (1 / Val(Format(tjkw.Text, "General Number"))) * Val(Format(tplafon_induk.Text, "General Number")), 0), "General Number")
        End If
        If cmbsistem_angsuran.Text.ToString.Split(" :")(0) = "2" Then
            tx = "ww"
            bunga = Format(FormatNumber((tsuku_bunga.Text / 100) * (1 / Val(Format(tjkw.Text, "General Number"))) * Val(Format(tplafon_induk.Text, "General Number")), 0), "General Number")
        End If
        If cmbsistem_angsuran.Text.ToString.Split(" :")(0) = "3" Then
            tx = "m"
            bunga = Format(FormatNumber((tsuku_bunga.Text / 100) * (1 / 12) * Val(Format(tplafon_induk.Text, "General Number")), 0), "General Number")
        End If

        For i As Integer = 1 To tjkw.Text
            tgl = Format(DateAdd(tx, Val(i), DateTimePicker3.Value), "yyyy-MM-dd")
            If i = tjkw.Text Then
                pk = Format(FormatNumber(Val(Format(tplafon_induk.Text, "General Number")) - Val(Format(total, "General Number")), 0), "General Number")
            Else
                pk = Format(FormatNumber(Val(Format(tplafon_induk.Text, "General Number")) / Val(Format(tjkw.Text, "General Number")), 0), "General Number")
                total = total + pk
            End If
            jumlah = Format(FormatNumber(Val(Format(pk, "General Number")) + Val(Format(bunga, "General Number")), 0), "General Number")

            kd = tno_rekening1.Text + "." + Microsoft.VisualBasic.Right("000" & Microsoft.VisualBasic.Right(i, 3), 3)

            cd = New MySqlCommand("INSERT INTO data_jadual_angsuran VALUES ('','" & kd & "','" & tno_rekening1.Text & "','" & i & "','" & tgl & "','" & pk & "','" & bunga & "','" & jumlah & "')", koneksi)
            cd.ExecuteNonQuery()
        Next
    End Sub

    Private Sub rekening_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub rekening_kredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo()
        Me.ResizeRedraw = True
        tkode_skim.Focus()
    End Sub

    Private Sub rekening_kredit_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub
    Sub combo()
        cd = New MySqlCommand("SELECT concat_ws (' : ', kredit_kode,upper(kredit_nama_produk)) AS produk FROM data_kredit_produk ORDER BY kredit_kode", koneksi)
        rd = cd.ExecuteReader
        With cmbskim.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("produk"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('22')", koneksi)
        rd = cd.ExecuteReader
        With cmbsistem_angsuran.Items
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
    End Sub
    Sub kosong()
        btndata_debitur.Enabled = False
        btndata_pelengkap.Enabled = False
        btndata_agunan.Enabled = False
        btnbuat_jadual.Enabled = False
        btnbuat_jadual.Text = "Jadual Angsuran"

        btnstatement_transaksi.Enabled = False
        ' btnstatement_ppap.Enabled = False
        'btnstatement_provisi.Enabled = False
        
        tnasabah_id.Enabled = True
        tplafon_induk.Enabled = True
        tsuku_bunga.Enabled = True
        tjkw.Enabled = True
        cmbsistem_angsuran.Enabled = True
        cmbsistem_bunga.Enabled = True
        tkode_skim.Enabled = True
        cmbskim.Enabled = True
        tkode_skim.Clear()
        cmbskim.Text = ""
        tno_rekening1.Clear()
        tno_rekening2.Clear()
        treg_alias.Text = MDIParent1.username.Text
        tnasabah_id.Clear()
        tnama_nasabah.Clear()
        tnik.Clear()
        talamat.Clear()
        cidentitas_pasangan.Checked = False
        cpenghasilan.Checked = False
        tno_akad_awal.Clear()
        tno_akad_akhir.Clear()
        DateTimePicker1.Checked = True
        DateTimePicker3.Enabled = True
        DateTimePicker1.Value = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy")
        DateTimePicker3.Value = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy")
        ttanggal.Text = Format(DateTimePicker1.Value, "dd MMMM yyyy")
        tplafon_induk.Clear()
        tsuku_bunga.Text = "0,000"
        tjkw.Clear()
        cmbsistem_angsuran.Text = ""
        cmbsistem_bunga.Text = ""
        'tsistem_angsuran.Clear()
        'tsistem_angsuran.Enabled = False
        tkolek.Clear()
        'tadj1.Clear()
        'tadj2.Clear()
        tprovisi1.Text = "0,00"
        tprovisi2.Clear()
        tadministrasi1.Text = "0,00"
        tadministrasi2.Clear()
        tmaterai.Clear()
        tasuransi.Clear()
        tnotaris.Clear()
        tlain.Clear()

        Label22.Text = ""
        cmbstatus.Text = "0 : NONE"
    End Sub
    Sub cariproduk()
        rd.Close()

        cd = New MySqlCommand("SELECT *,  cari_combo_komponen('22',kredit_periode_angsuran) AS periode, cari_combo_komponen('21',kredit_sistem_bunga) AS sistembunga, (concat_ws (' : ', kredit_kode,UPPER(kredit_nama_produk))) AS produk FROM data_kredit_produk WHERE kredit_kode='" & tkode_skim.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try

            tprovisi1.Text = "0,00"
            tprovisi2.Clear()
            tadministrasi1.Text = "0,00"
            tadministrasi2.Clear()
            Select Case rd.Item("kredit_pot_provisi")
                Case "0"
                    tprovisi1.Enabled = False
                    tprovisi2.Enabled = False
                Case "1"
                    tprovisi1.Enabled = True
                    tprovisi2.Enabled = False
                Case "2"
                    tprovisi1.Enabled = False
                    tprovisi2.Enabled = True
            End Select
            Select Case rd.Item("kredit_pot_adm")
                Case "0"
                    tadministrasi1.Enabled = False
                    tadministrasi2.Enabled = False
                Case "1"
                    tadministrasi1.Enabled = True
                    tadministrasi2.Enabled = False
                Case "2"
                    tadministrasi1.Enabled = False
                    tadministrasi2.Enabled = True
            End Select
            tprovisi1.Text = rd.Item("kredit_pot_provisi_p")
            tprovisi2.Text = rd.Item("kredit_pot_provisi_rp")
            tadministrasi1.Text = rd.Item("kredit_pot_adm_p")
            tadministrasi2.Text = rd.Item("kredit_pot_adm_rp")
            
            plafon_akad_min = rd.Item("kredit_plafon_min")
            plafon_akad_max = rd.Item("kredit_plafon_max")
            jkw_min = rd.Item("kredit_jkw_min")
            jkw_max = rd.Item("kredit_jkw_max")
            sb_min = rd.Item("kredit_sb_min")
            sb_max = rd.Item("kredit_sb_max")
            cmbsistem_angsuran.Text = rd.Item("periode")
            cmbsistem_bunga.Text = rd.Item("sistembunga")
            cmbskim.Text = rd.Item("produk")

            rumus()
            rd.Close()
        Catch ex As Exception
            cmbsistem_angsuran.Text = ""
            cmbskim.Text = ""
            cmbsistem_angsuran.Text = ""
            'tsistem_angsuran.Enabled = False
            'tsistem_angsuran.Clear()
            Label22.Text = ""
            selisih()
            cmbsistem_bunga.Text = ""
            tjkw.Clear()
            tprovisi1.Enabled = False
            tprovisi2.Enabled = False
            tadministrasi1.Enabled = False
            tadministrasi2.Enabled = False
            tprovisi1.Text = "0,00"
            tprovisi2.Clear()
            tadministrasi1.Text = "0,00"
            tadministrasi2.Clear()
        End Try
        rd.Close()
    End Sub

    Private Sub btncarinasabah_Click(sender As Object, e As EventArgs) Handles btncarinasabah.Click
        With pencarian_master_nasabah
            .Label4.Text = "rekening kredit"
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
        If tnama_nasabah.Text = "" Then
            btncarinasabah.Focus()
        Else
            tno_akad_awal.Focus()
        End If
    End Sub
    Sub carinasabah()
        rd.Close()
        cd = New MySqlCommand("SELECT * FROM data_nasabah WHERE nasabah_id='" & tnasabah_id.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_nasabah.Text = rd.Item("nasabah_nama1")
            talamat.Text = rd.Item("nasabah_alamat") + ", " + rd.Item("nasabah_kelurahan") + ", " + rd.Item("nasabah_kecamatan")
            tnik.Text = rd.Item("nasabah_nik")
            If Val(rd.Item("nasabah_gaji")) + Val(rd.Item("nasabah_usaha")) + Val(rd.Item("nasabah_lain")) > 0 Then
                cpenghasilan.Checked = True
            End If
            If rd.Item("nasabah_status_marital") = "1" Or (rd.Item("nasabah_status_marital") = "2" And Len(rd.Item("nasabah_nama_pasangan")) > 1 And Len(rd.Item("nasabah_nik_pasangan")) > 1) Then
                cidentitas_pasangan.Checked = True
            End If
        Catch ex As Exception
            tnama_nasabah.Clear()
            tnik.Clear()
            talamat.Clear()
            cpenghasilan.Checked = False
            cidentitas_pasangan.Checked = False
        End Try
        rd.Close()
    End Sub
    Sub selisih()
        Try
            Select Case Label22.Text
                Case "hari"
                    tp = "d"
                Case "minggu"
                    tp = "ww"
                Case "bulan"
                    tp = "m"
            End Select
            DateTimePicker4.Value = Format(DateAdd(tp, Val(Format(tjkw.Text, "General Number")), DateTimePicker3.Value), "dd-MMMM-yyyy")
        Catch ex As Exception
            DateTimePicker4.Value = DateTimePicker3.Value
        End Try
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        selisih()
    End Sub

    Private Sub Label22_TextChanged(sender As Object, e As EventArgs) Handles Label22.TextChanged
        selisih()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker1.Checked = True Then
            ttanggal.Text = DateTimePicker1.Text
        Else
            ttanggal.Clear()
        End If
    End Sub
    Sub rumus()
        Try
            tprovisi2.Text = Format(tplafon_induk.Text, "General Number") * (tprovisi1.Text / 100)
        Catch ex As Exception

        End Try
        Try
            tadministrasi2.Text = Format(tplafon_induk.Text, "General Number") * (tadministrasi1.Text / 100)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If cmbskim.Text = "" Then
            MessageBox.Show("Skim Kredit harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbskim.Focus()
            Exit Sub
        ElseIf tnama_nasabah.Text = "" And tnik.Text = "" And talamat.Text = "" Then
            MessageBox.Show("Nasabah ID harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnasabah_id.Focus()
            Exit Sub
        ElseIf tno_akad_awal.Text = "" Then
            MessageBox.Show("No Akad awal harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tno_akad_awal.Focus()
            Exit Sub
        ElseIf tplafon_induk.Text = "0" Then
            MessageBox.Show("Plafon Induk tidak boleh nol.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tplafon_induk.Focus()
            Exit Sub
        ElseIf Val(Format(tplafon_induk.Text, "General Number")) < Val(plafon_akad_min) Then
            MessageBox.Show("Plafon Induk harus sama atau lebih dari " + FormatNumber(plafon_akad_min, 0) + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tplafon_induk.Focus()
            Exit Sub
        ElseIf Val(Format(tplafon_induk.Text, "General Number")) > Val(plafon_akad_max) Then
            MessageBox.Show("Plafon Induk harus sama atau kurang dari " + FormatNumber(plafon_akad_max, 0) + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tplafon_induk.Focus()
            Exit Sub
        ElseIf tjkw.Text = "0" Then
            MessageBox.Show("Jangka Waktu tidak boleh nol.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjkw.Focus()
            Exit Sub
        ElseIf Val(Format(tjkw.Text, "General Number")) < Val(jkw_min) Then
            MessageBox.Show("Jangka Waktu harus sama atau lebih dari " + FormatNumber(jkw_min, 0) + " " + Label22.Text + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjkw.Focus()
            Exit Sub
        ElseIf Val(Format(tjkw.Text, "General Number")) > Val(jkw_max) Then
            MessageBox.Show("Jangka Waktu harus sama atau kurang dari " + FormatNumber(jkw_max, 0) + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjkw.Focus()
            Exit Sub
        ElseIf FormatNumber(tsuku_bunga.Text, 3) < sb_min Then
            MessageBox.Show("Suku Bunga harus sama atau lebih dari " + FormatNumber(sb_min, 3) + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tsuku_bunga.Focus()
            Exit Sub
        ElseIf FormatNumber(tsuku_bunga.Text, 3) > sb_max Then
            MessageBox.Show("Suku Bunga harus sama atau kurang dari " + FormatNumber(sb_max, 3) + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tsuku_bunga.Focus()
            Exit Sub
        End If

        If tno_rekening1.Text = "" Then
            simpan()
        Else
            edit()
        End If

    End Sub
    Sub ar()
        Timer1.Enabled = False
        data_ke(0) = tno_rekening1.Text
        data_ke(1) = tno_rekening2.Text
        data_ke(2) = tkode_skim.Text
        data_ke(3) = tnasabah_id.Text
        data_ke(4) = tno_akad_awal.Text
        data_ke(5) = tno_akad_akhir.Text
        data_ke(6) = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        data_ke(7) = ttanggal.Text
        data_ke(8) = Format(tplafon_induk.Text, "General Number")
        data_ke(9) = tsuku_bunga.Text.Replace(",", ".")
        data_ke(10) = Format(tjkw.Text, "General Number")
        data_ke(11) = cmbsistem_angsuran.Text.ToString.Split(" :")(0)
        data_ke(12) = cmbsistem_bunga.Text.ToString.Split(" :")(0)
        data_ke(13) = Format(DateTimePicker3.Value, "yyyy-MM-dd")
        data_ke(14) = Format(DateTimePicker4.Value, "yyyy-MM-dd")
        data_ke(15) = tprovisi1.Text.Replace(",", ".")
        data_ke(16) = Format(tprovisi2.Text, "General Number")
        data_ke(17) = tadministrasi1.Text.Replace(",", ".")
        data_ke(18) = Format(tadministrasi2.Text, "General Number")
        data_ke(19) = Format(tmaterai.Text, "General Number")
        data_ke(20) = Format(tasuransi.Text, "General Number")
        data_ke(21) = Format(tnotaris.Text, "General Number")
        data_ke(22) = Format(tlain.Text, "General Number")
        data_ke(23) = cmbstatus.Text.ToString.Split(" :")(0)
        data_ke(24) = treg_alias.Text
        data_ke(25) = Format(DateTimePicker2.Value, "yyyy-MM-dd HH:mm:ss")
        data_ke(26) = treg_alias.Text
        data_ke(27) = Format(DateTimePicker2.Value, "yyyy-MM-dd HH:mm:ss")

        data_edit(0) = "rek_kre_no_rekening='" + data_ke(0) + "'"
        data_edit(1) = "rek_kre_no_alternatif='" + data_ke(1) + "'"
        data_edit(2) = "rek_kre_kode_produk='" + data_ke(2) + "'"
        data_edit(3) = "rek_kre_nasabah_id='" + data_ke(3) + "'"
        data_edit(4) = "rek_kre_akad_awal='" + data_ke(4) + "'"
        data_edit(5) = "rek_kre_akad_akhir='" + data_ke(5) + "'"
        data_edit(6) = "rek_kre_tanggal1='" + data_ke(6) + "'"
        data_edit(7) = "rek_kre_tanggal2='" + data_ke(7) + "'"
        data_edit(8) = "rek_kre_plafon_induk='" + data_ke(8) + "'"
        data_edit(9) = "rek_kre_suku_bunga='" + data_ke(9) + "'"
        data_edit(10) = "rek_kre_jangka_waktu='" + data_ke(10) + "'"
        data_edit(11) = "rek_kre_jenis_angsuran='" + data_ke(11) + "'"
        data_edit(12) = "rek_kre_sistem_bunga='" + data_ke(12) + "'"
        data_edit(13) = "rek_kre_tanggal_mulai='" + data_ke(13) + "'"
        data_edit(14) = "rek_kre_tanggal_jt='" + data_ke(14) + "'"
        data_edit(15) = "rek_kre_provisi_p='" + data_ke(15) + "'"
        data_edit(16) = "rek_kre_provisi_rp='" + data_ke(16) + "'"
        data_edit(17) = "rek_kre_administrasi_p='" + data_ke(17) + "'"
        data_edit(18) = "rek_kre_administrasi_rp='" + data_ke(18) + "'"
        data_edit(19) = "rek_kre_materai='" + data_ke(19) + "'"
        data_edit(20) = "rek_kre_asuransi='" + data_ke(20) + "'"
        data_edit(21) = "rek_kre_notaris='" + data_ke(21) + "'"
        data_edit(22) = "rek_kre_lain='" + data_ke(22) + "'"
        data_edit(23) = "rek_kre_status='" + data_ke(23) + "'"
        data_edit(24) = "rek_kre_reg_username='" + data_ke(24) + "'"
        data_edit(25) = "rek_kre_reg_waktu='" + data_ke(25) + "'"
        data_edit(26) = "rek_kre_update_username='" + data_ke(26) + "'"
        data_edit(27) = "rek_kre_update_waktu='" + data_ke(27) + "'"
        Timer1.Enabled = True
    End Sub
    Sub norekening()
        cd = New MySqlCommand("SELECT IFNULL(MAX(RIGHT(rek_kre_no_rekening,5)), '0') AS rek FROM data_kredit_rekening WHERE rek_kre_kode_produk='" & tkode_skim.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tno_rekening1.Text = tkode_skim.Text.ToString + "." + Microsoft.VisualBasic.Right("00000" & Microsoft.VisualBasic.Right(Val(rd.Item("rek").ToString), 5) + 1, 5)
        rd.Close()
    End Sub
    Sub simpan()
        norekening()
        ar()
        Dim gabung = ""
        For n = 0 To 27
            If n = 0 Then
                gabung += "'" + data_ke(n) + "'"
            Else
                gabung += ",'" + data_ke(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_kredit_rekening VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Rekening Kredit (rek_kre_no_rekening : " + data_ke(0) + ")"
        insert_log_user()

        tombol()
        master_rekening_kredit.btnfilter.PerformClick()
        MessageBox.Show("Rekening Kredit berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)


        With btnbuat_jadual
            .Text = "Buat Jadual Angsuran"
            .Enabled = True
            .PerformClick()
        End With
        

    End Sub

    Sub tombol()
        If cmbstatus.Text.ToString.Split(" :")(0) = "0" Then
            tnasabah_id.Enabled = True
            btncarinasabah.Enabled = True
            tplafon_induk.Enabled = True
            tsuku_bunga.Enabled = True
            tjkw.Enabled = True
            cmbsistem_angsuran.Enabled = True
            cmbsistem_bunga.Enabled = True
            DateTimePicker3.Enabled = True
        Else
            tnasabah_id.Enabled = False
            btncarinasabah.Enabled = False
            tplafon_induk.Enabled = False
            tsuku_bunga.Enabled = False
            tjkw.Enabled = False
            cmbsistem_angsuran.Enabled = False
            cmbsistem_bunga.Enabled = False
            DateTimePicker3.Enabled = False
        End If
        
    End Sub
    Sub edit()
        ar()
        Dim gabung = ""
        For n = 1 To 27
            If n = 1 Then
                gabung += data_edit(n)
            Else
                If n = 24 Or n = 25 Then
                    gabung += ""
                Else
                    gabung += " ," + data_edit(n)
                End If
            End If
        Next
        cd = New MySqlCommand("UPDATE data_kredit_rekening SET " & gabung & " WHERE " & data_edit(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Rekening Kredit (rek_kre_no_rekening : " + data_ke(0) + ")"
        insert_log_user()

        master_rekening_kredit.btnfilter.PerformClick()
        MessageBox.Show("Rekening Kredit berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btndata_debitur_Click(sender As Object, e As EventArgs) Handles btndata_debitur.Click
        cd = New MySqlCommand("SELECT rek_kre_nasabah_id FROM data_kredit_rekening WHERE rek_kre_no_rekening='" & tno_rekening1.Text & "'", koneksi) 'mengecek nik
        rd = cd.ExecuteReader
        rd.Read()
        With data_nasabah_perorangan
            .tnasabah_id.Text = rd.Item("rek_kre_nasabah_id")
            rd.Close()
            .cekdatanasabah()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnstatement_transaksi_Click(sender As Object, e As EventArgs) Handles btnstatement_transaksi.Click
        With statement_transaksi
            .tno_rekening.Text = tno_rekening1.Text
            .caristatement()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnstatement_ppap_Click(sender As Object, e As EventArgs)
        With statement_provisi
            .ShowDialog()
        End With
    End Sub

    Private Sub btnstatement_provisi_Click(sender As Object, e As EventArgs)
        With statement_provisi
            .ShowDialog()
        End With
    End Sub

    Private Sub btnautodebet_angsuran_Click(sender As Object, e As EventArgs)
        With autodebet_angsuran
            .ShowDialog()
        End With
    End Sub

    Private Sub tnama_nasabah_TextChanged(sender As Object, e As EventArgs) Handles tnama_nasabah.TextChanged
        If tnama_nasabah.Text = "" Then
            btndata_debitur.Enabled = False
        Else
            btndata_debitur.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateTimePicker2.Text = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub tprovisi1_TextChanged(sender As Object, e As EventArgs) Handles tprovisi1.TextChanged, tadministrasi1.TextChanged
        If Val(sender.text) >= 100 Then
            sender.text = "0"
        End If
    End Sub


    Sub rumus2()
        Try
            tprovisi1.Text = FormatNumber(Val(Val(Format(tprovisi2.Text, "General Number")) * 100) / Val(Format(tplafon_induk.Text, "General Number")), 2)
        Catch ex As Exception

        End Try
        Try
            tadministrasi1.Text = FormatNumber(Val(Val(Format(tadministrasi2.Text, "General Number")) * 100) / Val(Format(tplafon_induk.Text, "General Number")), 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstatus.SelectedIndexChanged
        tombol()
    End Sub
End Class