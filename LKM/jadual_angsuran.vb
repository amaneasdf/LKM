Imports MySql.Data.MySqlClient
Public Class jadual_angsuran
    Dim tp, tgl, jt, sb_min, sb_max, bunga As String
    Dim total As Integer
    Dim kd_produk As String
    Dim tx, pk, jumlah, kd As String
    Dim jkw_min, jkw_max As String

    Private Sub jadual_angsuran_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub jadual_angsuran_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Sub jadual_angsuran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        combo()
        Me.ResizeRedraw = True
    End Sub

    Private Sub jadual_angsuran_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub
    Sub kosong()
        cmbsistem_angsuran.Enabled = False
        'tsistem_angsuran.Enabled = False
        cmbsistem_bunga.Enabled = False
        tsuku_bunga.Enabled = False
        tjkw.Enabled = False
        btnsimpan.Visible = False
        tno_rekening.Clear()
        tnama_nasabah.Clear()
        tplafond.Clear()
        cmbsistem_angsuran.Text = ""
        cmbsistem_bunga.Text = ""
        'tsistem_angsuran.Clear()
        tsuku_bunga.Text = "0,000"
        tjkw.Clear()
    End Sub

    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Ke", 40, HorizontalAlignment.Center)
            .Add("Jatuh Tempo", 100, HorizontalAlignment.Left)
            .Add("Pokok", 100, HorizontalAlignment.Right)
            .Add("Bunga", 100, HorizontalAlignment.Right)
            .Add("Total", 100, HorizontalAlignment.Right)
        End With
    End Sub

    Sub tampil()
        Dim nilai As Integer = 0

        da = New MySqlDataAdapter("SELECT * FROM data_kredit_statement WHERE kre_stat_jenis='3' AND kre_stat_no_rekening='" & tno_rekening.Text & "'", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(i + 1)
                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("kre_stat_waktu"), "dd-MM-yyyy"))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kre_stat_tag_pokok"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kre_stat_tag_bunga"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kre_stat_tag_pokok") + dt.Rows(i)("kre_stat_tag_bunga"), 0))
                If Format(dt.Rows(i)("kre_stat_waktu"), "yyyy-MM-dd") < Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd") Then
                    .Items(i).BackColor = Color.Pink
                ElseIf Format(dt.Rows(i)("kre_stat_waktu"), "yyyy-MM-dd") = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd") Then
                    .Items(i).BackColor = Color.Yellow
                Else
                    .Items(i).BackColor = Color.White
                End If
            Next
        End With
    End Sub
    Sub combo()
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
    Sub selisih()
        Try
            Select Case Label10.Text
                Case "hari"
                    tp = "d"
                Case "minggu"
                    tp = "ww"
                Case "bulan"
                    tp = "m"
            End Select
            DateTimePicker2.Value = Format(DateAdd(tp, Val(Format(tjkw.Text, "General Number")), DateTimePicker1.Value), "dd-MMMM-yyyy")
        Catch ex As Exception
            DateTimePicker2.Value = DateTimePicker1.Value
        End Try
    End Sub
    
    Private Sub cmbsistem_angsuran_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsistem_angsuran.SelectedIndexChanged
        Select Case cmbsistem_angsuran.Text.ToString.Split(" :")(0)
            Case "1"
                'tsistem_angsuran.Enabled = False
                'tsistem_angsuran.Clear()
                Label10.Text = "hari"
            Case "2"
                'tsistem_angsuran.Enabled = True
                'tsistem_angsuran.Text = "7"
                Label10.Text = "minggu"
            Case "3"
                'tsistem_angsuran.Enabled = False
                'tsistem_angsuran.Clear()
                Label10.Text = "bulan"
            Case Else
                Label10.Text = ""
        End Select
        selisih()
    End Sub

    Private Sub cmbsistem_bunga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbsistem_bunga.KeyPress, cmbsistem_angsuran.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub tsistem_angsuran_TextChanged(sender As Object, e As EventArgs) Handles tplafond.TextChanged, tjkw.TextChanged
        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub

    Private Sub tsuku_bunga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tsuku_bunga.KeyPress
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

    Private Sub tsuku_bunga_LostFocus(sender As Object, e As EventArgs) Handles tsuku_bunga.LostFocus
        Try
            tsuku_bunga.Text = FormatNumber(tsuku_bunga.Text, 3)
        Catch ex As Exception
            tsuku_bunga.Text = "0,000"
        End Try
    End Sub

    Private Sub tjkw_GotFocus(sender As Object, e As EventArgs) Handles tjkw.GotFocus, tsuku_bunga.GotFocus, cmbsistem_bunga.GotFocus, cmbsistem_angsuran.GotFocus

        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tjkw_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tjkw.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tjkw_LostFocus(sender As Object, e As EventArgs) Handles tjkw.LostFocus, tsuku_bunga.LostFocus, cmbsistem_bunga.LostFocus, cmbsistem_angsuran.LostFocus

        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub tjkw_TextChanged(sender As Object, e As EventArgs) Handles tjkw.TextChanged
        selisih()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click

        rd.Close()
        cd = New MySqlCommand("SELECT * FROM data_kredit_produk WHERE kredit_kode='" & kd_produk & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        jkw_min = rd.Item("kredit_jkw_min")
        jkw_max = rd.Item("kredit_jkw_max")
        sb_min = rd.Item("kredit_sb_min")
        sb_max = rd.Item("kredit_sb_max")
        rd.Close()


        If Val(Format(tjkw.Text, "General Number")) < Val(jkw_min) Then
            MessageBox.Show("Jangka Waktu harus sama atau lebih dari " + FormatNumber(jkw_min, 0) + " bulan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        edit()

    End Sub
    Sub edit()
        Dim data_edit(99), data_ke(99) As String
        data_ke(0) = tsuku_bunga.Text.Replace(",", ".")
        data_ke(1) = Format(tjkw.Text, "General Number")
        data_ke(2) = cmbsistem_angsuran.Text.ToString.Split(" :")(0)
        rekening_kredit.cmbsistem_angsuran.Text = cmbsistem_angsuran.Text
        'data_ke(3) = Format(tsistem_angsuran.Text, "General Number")
        data_ke(3) = cmbsistem_bunga.Text.ToString.Split(" :")(0)

        data_edit(0) = "rek_kre_suku_bunga='" + data_ke(0) + "'"
        data_edit(1) = "rek_kre_jangka_waktu='" + data_ke(1) + "'"
        data_edit(2) = "rek_kre_jenis_angsuran='" + data_ke(2) + "'"
        'data_edit(3) = "rek_kre_sistem_angsuran='" + data_ke(3) + "'"
        data_edit(3) = "rek_kre_sistem_bunga='" + data_ke(3) + "'"
        data_edit(4) = "rek_kre_tanggal_jt='" + Format(DateTimePicker2.Value, "yyyy-MM-dd") + "'"
        'data_edit(6) = "rek_kre_status='1'"

        Dim gabung = ""
        For n = 0 To 4
            If n = 0 Then
                gabung += data_edit(n)
            Else
                gabung += "," + data_edit(n)
            End If
        Next
        cd = New MySqlCommand("UPDATE data_kredit_rekening SET " & gabung & " WHERE rek_kre_no_rekening='" & tno_rekening.Text & "'", koneksi)
        cd.ExecuteNonQuery()
        With rekening_kredit
            .cmbsistem_angsuran.Text = cmbsistem_angsuran.Text
            .cmbsistem_bunga.Text = cmbsistem_bunga.Text
            '.tsistem_angsuran.Text = .tsistem_angsuran.Text
            .tsuku_bunga.Text = .tsuku_bunga.Text
            .tjkw.Text = tjkw.Text
            .Label22.Text = Label10.Text
        End With
        btnsimpan.Visible = False
        cmbsistem_angsuran.Enabled = False
        'tsistem_angsuran.Enabled = False
        cmbsistem_bunga.Enabled = False
        tsuku_bunga.Enabled = False
        tjkw.Enabled = False
        cd = New MySqlCommand("DELETE FROM data_kredit_statement WHERE kre_stat_no_rekening='" & tno_rekening.Text & "' AND kre_stat_jenis='3'", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah jadual angsuran (kre_stat_no_rekening : " + tno_rekening.Text + ")"
        insert_log_user()

        buatjadual()
        tampil()
        master_rekening_kredit.btnfilter.PerformClick()
        MessageBox.Show("Rekening Kredit berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Sub buatjadual()

        total = 0
        Select Case cmbsistem_angsuran.Text.ToString.Split(" :")(0)
            Case "1"
                tx = "d"
                bunga = Format(FormatNumber((tsuku_bunga.Text / 100) * (1 / 365) * Val(Format(tplafond.Text, "General Number")), 0), "General Number")
            Case "2"
                tx = "ww"
                bunga = Format(FormatNumber((tsuku_bunga.Text / 100) * (1 / 54) * Val(Format(tplafond.Text, "General Number")), 0), "General Number")
            Case "3"
                tx = "m"
                bunga = Format(FormatNumber((tsuku_bunga.Text / 100) * (1 / 12) * Val(Format(tplafond.Text, "General Number")), 0), "General Number")
        End Select

        For i As Integer = 1 To tjkw.Text
            tgl = Format(DateAdd(tx, Val(i), DateTimePicker1.Value), "yyyy-MM-dd").ToString + " 00:00:01"
            If i = tjkw.Text Then
                pk = Format(FormatNumber(Val(Format(tplafond.Text, "General Number")) - Val(Format(total, "General Number")), 0), "General Number")
            Else
                pk = Format(FormatNumber(Val(Format(tplafond.Text, "General Number")) / Val(Format(tjkw.Text, "General Number")), 0), "General Number")
                total = total + pk
            End If

            kd = tno_rekening.Text + "." + Microsoft.VisualBasic.Right("000" & Microsoft.VisualBasic.Right(i, 3), 3)
            'Microsoft.VisualBasic.Right("00000" & Microsoft.VisualBasic.Right(i, 3), 3)

            cd = New MySqlCommand("INSERT INTO data_kredit_statement VALUES ('" & tgl & "', '3', '', '" & kd & "', '" & tno_rekening.Text & "', '0', '" & pk & "','" & bunga & "', '0', '0', '0', 'Tagihan Ke-" & i & "', '" & MDIParent1.username.Text & "')", koneksi)
            cd.ExecuteNonQuery()
        Next

        user_pengguna = MDIParent1.username.Text
        uraian = "Pembuatan jadual angsuran (kre_stat_no_rekening : " + tno_rekening.Text + ")"
        insert_log_user()

    End Sub
    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        btnsimpan.Visible = True
        cmbsistem_angsuran.Enabled = True
        cmbsistem_bunga.Enabled = True
        tsuku_bunga.Enabled = True
        tjkw.Enabled = True
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        cd = New MySqlCommand("UPDATE data_kredit_rekening SET rek_kre_status='0' WHERE rek_kre_no_rekening='" & tno_rekening.Text & "'", koneksi)
        cd.ExecuteNonQuery()
        cd = New MySqlCommand("DELETE FROM data_kredit_statement WHERE kre_stat_no_rekening='" & tno_rekening.Text & "' AND kre_stat_jenis='3'", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Pembatalan jadual angsuran (kre_stat_no_rekening : " + tno_rekening.Text + ")"
        insert_log_user()

        With rekening_kredit
            .cmbstatus.Text = "0 : NONE"
            .btndata_pelengkap.Enabled = False
            .btndata_agunan.Enabled = False
            .btnbuat_jadual.Text = "Buat Jadual Angsuran"
        End With
        master_rekening_kredit.btnfilter.PerformClick()
        MessageBox.Show("Angsuran sudah dihapus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Sub caridata()
        cd = New MySqlCommand("SELECT nasabah_nama1, rek_kre_plafon_induk, rek_kre_jenis_angsuran, rek_kre_sistem_bunga, rek_kre_suku_bunga, rek_kre_jangka_waktu, rek_kre_status, rek_kre_kode_produk, rek_kre_tanggal_mulai, rek_kre_tanggal_jt, cari_combo_komponen('22',rek_kre_jenis_angsuran) AS jenisangsuran, cari_combo_komponen('21',rek_kre_sistem_bunga) AS sistembunga FROM data_kredit_rekening JOIN data_nasabah ON rek_kre_nasabah_id=nasabah_id WHERE rek_kre_no_rekening='" & tno_rekening.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tnama_nasabah.Text = rd.Item("nasabah_nama1")
        tplafond.Text = rd.Item("rek_kre_plafon_induk")
        ' tsistem_angsuran.Text = rd.Item("rek_kre_sistem_angsuran")
        tsuku_bunga.Text = FormatNumber(rd.Item("rek_kre_suku_bunga"), 3)
        tjkw.Text = rd.Item("rek_kre_jangka_waktu")
        kd_produk = rd.Item("rek_kre_kode_produk")
        DateTimePicker1.Value = rd.Item("rek_kre_tanggal_mulai")
        DateTimePicker2.Value = rd.Item("rek_kre_tanggal_jt")
        Select Case rd.Item("rek_kre_jenis_angsuran")
            Case "1"
                Label10.Text = "hari"
            Case "2"
                Label10.Text = "minggu"
            Case "3"
                Label10.Text = "bulan"
        End Select
        If rd.Item("rek_kre_status") = "2" Or rd.Item("rek_kre_status") = "3" Then
            btncancel.Enabled = False
        Else
            btncancel.Enabled = True
        End If
        If rd.Item("rek_kre_status") = "3" Then
            btnreset.Enabled = False
        Else
            btnreset.Enabled = True
        End If
        cmbsistem_angsuran.Text = rd.Item("jenisangsuran")
        cmbsistem_bunga.Text = rd.Item("sistembunga")
        rd.Close()
    End Sub

    Private Sub btncetak_Click(sender As Object, e As EventArgs) Handles btncetak.Click
        cd = New MySqlCommand("DELETE FROM temp_jadual_angsuran WHERE temp_username='" & MDIParent1.username.Text & "' AND temp_no_rekening='" & tno_rekening.Text & "'", koneksi)
        cd.ExecuteNonQuery()

        cd = New MySqlCommand("SELECT rek_kre_plafon_induk, rek_kre_tanggal_mulai FROM data_kredit_rekening WHERE rek_kre_no_rekening='" & tno_rekening.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim pinjaman As String = rd.Item("rek_kre_plafon_induk")
        Dim tglmulai As String = Format(rd.Item("rek_kre_tanggal_mulai"), "yyyy-MM-dd")
       

        rd.Close()
        cd = New MySqlCommand("INSERT INTO temp_jadual_angsuran VALUES ('" & tno_rekening.Text & "','000', '" & tglmulai & "', '0', '0', '0','" & pinjaman & "', '" & MDIParent1.username.Text & "')", koneksi)
        cd.ExecuteNonQuery()
        

        For i As Integer = 0 To dt.Rows.Count - 1
            Dim total As String = dt.Rows(i)("kre_stat_tag_pokok") + dt.Rows(i)("kre_stat_tag_bunga")
            pinjaman = Val(pinjaman) - Val(dt.Rows(i)("kre_stat_tag_pokok"))

            cd = New MySqlCommand("INSERT INTO temp_jadual_angsuran VALUES ('" & tno_rekening.Text & "','" & Microsoft.VisualBasic.Right("000" & Microsoft.VisualBasic.Right(i + 1, 3), 3) & "', '" & Format(dt.Rows(i)("kre_stat_waktu"), "yyyy-MM-dd") & "', '" & dt.Rows(i)("kre_stat_tag_pokok") & "', '" & dt.Rows(i)("kre_stat_tag_bunga") & "', '" & total & "','" & pinjaman & "', '" & MDIParent1.username.Text & "')", koneksi)
            cd.ExecuteNonQuery()
        Next


        With laporan_jadual_angsuran
            .TextBox1.Text = tno_rekening.Text
            .ShowDialog()
        End With
    End Sub
End Class