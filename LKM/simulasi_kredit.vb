Imports MySql.Data.MySqlClient
Public Class simulasi_kredit
    Dim tp, jkw_min, jkw_max, plafon_akad_min, plafon_akad_max As String
    Dim sb_min, sb_max As Decimal
    Dim total_pokok, tx, bunga, tgl, pokok, total_bunga, nilai_total_bunga As String
    Dim saldo_pokok, saldo_bunga As String
    Private Sub simulasi_kredit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnkeluar.PerformClick()
    End Sub

    Private Sub simulasi_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub simulasi_kredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()

        combo()
        Me.ResizeRedraw = True
    End Sub

    Sub combo()
        cd = New MySqlCommand("SELECT concat_ws (' : ', kredit_kode,upper(kredit_nama_produk)) AS produk FROM data_kredit_produk ORDER BY kredit_kode", koneksi)
        rd = cd.ExecuteReader
        With cmbskim_kredit.Items
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

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub simulasi_kredit_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tprovisi1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tprovisi1.KeyPress, tadministrasi1.KeyPress, tsuku_bunga.KeyPress
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

    Private Sub tskim_kredit_GotFocus(sender As Object, e As EventArgs) Handles tskim_kredit.GotFocus, cmbskim_kredit.GotFocus, tnama_nasabah.GotFocus, talamat.GotFocus, tmobile.GotFocus, tplafon_akad.GotFocus, cmbsistem_angsuran.GotFocus, cmbsistem_bunga.GotFocus, tjkw.GotFocus, tprovisi1.GotFocus, tprovisi2.GotFocus, tadministrasi1.GotFocus, tadministrasi2.GotFocus, tmaterai.GotFocus, tasuransi.GotFocus, tnotaris.GotFocus, tlain.GotFocus, tsuku_bunga.GotFocus

        sender.backcolor = warna_gotfocus
    End Sub

    Private Sub cmbskim_kredit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbskim_kredit.KeyPress, cmbsistem_angsuran.KeyPress, cmbsistem_bunga.KeyPress

        e.KeyChar = Chr(0)
    End Sub

    Private Sub tadministrasi2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tadministrasi2.KeyPress, tplafon_akad.KeyPress, tprovisi2.KeyPress, tjkw.KeyPress, tmaterai.KeyPress, tasuransi.KeyPress, tlain.KeyPress, tmaterai.KeyPress, tmobile.KeyPress

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tnama_nasabah_LostFocus(sender As Object, e As EventArgs) Handles tskim_kredit.LostFocus, cmbskim_kredit.LostFocus, tnama_nasabah.LostFocus, talamat.LostFocus, tmobile.LostFocus, tplafon_akad.LostFocus, cmbsistem_angsuran.LostFocus, cmbsistem_bunga.LostFocus, tjkw.LostFocus, tprovisi1.LostFocus, tprovisi2.LostFocus, tadministrasi1.LostFocus, tadministrasi2.LostFocus, tmaterai.LostFocus, tasuransi.LostFocus, tnotaris.LostFocus, tlain.LostFocus, tsuku_bunga.LostFocus

        sender.backcolor = warna_lostfocus

        If sender.text = tprovisi2.Text Or sender.text = tadministrasi2.Text Then
            rumus2()
        End If
    End Sub
    Private Sub tskim_kredit_LostFocus(sender As Object, e As EventArgs) Handles tskim_kredit.LostFocus
        carikredit()
    End Sub
    Private Sub tskim_kredit_TextChanged(sender As Object, e As EventArgs) Handles tskim_kredit.TextChanged

    End Sub

    Private Sub tplafon_akad_TextChanged(sender As Object, e As EventArgs) Handles tplafon_akad.TextChanged, tprovisi2.TextChanged, tadministrasi2.TextChanged, tnotaris.TextChanged, tasuransi.TextChanged, tlain.TextChanged, tmaterai.TextChanged, tjkw.TextChanged

        Try
            sender.SelectionStart = Len(sender.Text)
            sender.Text = FormatNumber(sender.Text, 0)
        Catch ex As Exception
            sender.Text = "0"
        End Try
        If sender.text = tplafon_akad.Text Then
            rumus()
        End If
    End Sub

    Private Sub tprovisi1_lostfocus(sender As Object, e As EventArgs) Handles tprovisi1.LostFocus, tadministrasi1.LostFocus, tsuku_bunga.LostFocus

        Try
            sender.Text = FormatNumber(sender.Text, 3)
        Catch ex As Exception
            If sender.text = tsuku_bunga.Text Then
                sender.Text = "0,000"
            Else
                sender.Text = "0,00"
            End If
        End Try

        If sender.text = tprovisi1.Text Or sender.text = tadministrasi1.Text Then
            rumus()
        End If
    End Sub

    Private Sub cmbskim_kredit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbskim_kredit.SelectedIndexChanged
        tskim_kredit.Text = cmbskim_kredit.Text.ToString.Split(" :")(0)
        carikredit()
    End Sub

    Sub carikredit()
        Try
            rd.Close()
        Catch ex As Exception

        End Try

        cd = New MySqlCommand("SELECT *,  cari_combo_komponen('22',kredit_periode_angsuran) AS periode, cari_combo_komponen('21',kredit_sistem_bunga) AS sistembunga, (concat_ws (' : ', kredit_kode,UPPER(kredit_nama_produk))) AS produk FROM data_kredit_produk WHERE kredit_kode='" & tskim_kredit.Text & "'", koneksi)
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
            cmbsistem_angsuran.Text = rd.Item("periode")
            cmbsistem_bunga.Text = rd.Item("sistembunga")
            cmbskim_kredit.Text = rd.Item("produk")
            plafon_akad_min = rd.Item("kredit_plafon_min")
            plafon_akad_max = rd.Item("kredit_plafon_max")
            jkw_min = rd.Item("kredit_jkw_min")
            jkw_max = rd.Item("kredit_jkw_max")
            sb_min = rd.Item("kredit_sb_min")
            sb_max = rd.Item("kredit_sb_max")
            pilihsistem()
            selisih()
            rd.Close()
            rumus()
        Catch ex As Exception
            rd.Close()
            'MsgBox(ex.Message)
            cmbsistem_angsuran.Text = ""
            cmbskim_kredit.Text = ""
            cmbsistem_angsuran.Text = ""
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
            DateTimePicker2.Value = Format(DateAdd(tp, Val(Format(tjkw.Text, "General Number")), DateTimePicker1.Value), "dd-MMMM-yyyy")
        Catch ex As Exception
            DateTimePicker2.Value = DateTimePicker1.Value
        End Try
    End Sub

    Sub pilihsistem()

        Select Case cmbsistem_angsuran.Text.ToString.Split(" :")(0)
            Case "1"
                Label22.Text = "hari"
            Case "2"
                Label22.Text = "minggu"
            Case "3"
                Label22.Text = "bulan"
            Case Else
                Label22.Text = ""
        End Select
    End Sub

    Private Sub cmbsistem_angsuran_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsistem_angsuran.SelectedIndexChanged
        pilihsistem()
        selisih()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        selisih()
    End Sub

    Private Sub tjkw_TextChanged(sender As Object, e As EventArgs) Handles tjkw.TextChanged
        selisih()
    End Sub

    Private Sub tprovisi1_TextChanged(sender As Object, e As EventArgs) Handles tprovisi1.TextChanged

    End Sub

    Private Sub btncetak_Click(sender As Object, e As EventArgs) Handles btncetak.Click
        If cmbskim_kredit.Text = "" Then
            MessageBox.Show("Skim Kredit harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbskim_kredit.Focus()
            Exit Sub
        ElseIf Val(Format(tplafon_akad.Text, "General Number")) < Val(plafon_akad_min) Then
            MessageBox.Show("Plafon Induk harus sama atau lebih dari " + FormatNumber(plafon_akad_min, 0) + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tplafon_akad.Focus()
            Exit Sub
        ElseIf Val(Format(tplafon_akad.Text, "General Number")) > Val(plafon_akad_max) Then
            MessageBox.Show("Plafon Induk harus sama atau kurang dari " + FormatNumber(plafon_akad_max, 0) + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tplafon_akad.Focus()
            Exit Sub
        ElseIf tjkw.Text = "0" Then
            MessageBox.Show("Jangka Waktu tidak boleh nol.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjkw.Focus()
            Exit Sub
        ElseIf Val(Format(tjkw.Text, "General Number")) < Val(jkw_min) Then
            MessageBox.Show("Jangka Waktu harus sama atau lebih dari " + Format(jkw_min, "##,##0") + " " + Label22.Text + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjkw.Focus()
            Exit Sub
        ElseIf Val(Format(tjkw.Text, "General Number")) > Val(jkw_max) Then
            MessageBox.Show("Jangka Waktu harus sama atau kurang dari " + Format(jkw_max, "##,##0") + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjkw.Focus()
            Exit Sub
        ElseIf FormatNumber(tsuku_bunga.Text, 2) < sb_min Then
            MessageBox.Show("Suku Bunga harus sama atau lebih dari " + FormatNumber(sb_min, 2) + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tsuku_bunga.Focus()
            Exit Sub
        ElseIf FormatNumber(tsuku_bunga.Text, 2) > sb_max Then
            MessageBox.Show("Suku Bunga harus sama atau kurang dari " + FormatNumber(sb_max, 2) + ".", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tsuku_bunga.Focus()
            Exit Sub
        End If
        buat_simulasi()
    End Sub

    Sub buat_simulasi()
        total_pokok = 0
        total_bunga = 0


        cd = New MySqlCommand("DELETE FROM temp_simulasi_kredit WHERE temp_username='" & MDIParent1.username.Text & "'", koneksi)
        cd.ExecuteNonQuery()


        'saldo_bunga = total bunga
        ' bunga= bunga per bulan

        Select Case cmbsistem_angsuran.Text.ToString.Split(" :")(0)
            Case "1"
                tx = "d"
                nilai_total_bunga = Format(FormatNumber((tsuku_bunga.Text / 100) * (1 / 365) * Val(Format(tjkw.Text, "General Number")) * Val(Format(tplafon_akad.Text, "General Number")), 0), "General Number")
                bunga = Format(FormatNumber((tsuku_bunga.Text / 100) * (1 / 365) * Val(Format(tplafon_akad.Text, "General Number")), 0), "General Number")
            Case "2"
                tx = "ww"
                nilai_total_bunga = Format(FormatNumber((tsuku_bunga.Text / 100) * (1 / 54) * Val(Format(tjkw.Text, "General Number")) * Val(Format(tplafon_akad.Text, "General Number")), 0), "General Number")
                bunga = Format(FormatNumber((tsuku_bunga.Text / 100) * (1 / 54) * Val(Format(tplafon_akad.Text, "General Number")), 0), "General Number")
            Case "3"
                tx = "m"
                nilai_total_bunga = Format(FormatNumber((tsuku_bunga.Text / 100) * (1 / 12) * Val(Format(tjkw.Text, "General Number")) * Val(Format(tplafon_akad.Text, "General Number")), 0), "General Number")
                bunga = Format(FormatNumber((tsuku_bunga.Text / 100) * (1 / 12) * Val(Format(tplafon_akad.Text, "General Number")), 0), "General Number")
        End Select

        saldo_pokok = Format(tplafon_akad.Text, "General Number")
        saldo_bunga = nilai_total_bunga
        TextBox1.Text = nilai_total_bunga

        For i As Integer = 1 To tjkw.Text
            tgl = Format(DateAdd(tx, Val(i), DateTimePicker1.Value), "yyyy-MM-dd")
            If i = tjkw.Text Then
                pokok = Format(FormatNumber(Val(Format(tplafon_akad.Text, "General Number")) - Val(Format(total_pokok, "General Number")), 0), "General Number")
                bunga = Format(FormatNumber(Val(Format(nilai_total_bunga, "General Number")) - Val(Format(total_bunga, "General Number")), 0), "General Number")
                saldo_pokok = Val(Format(tplafon_akad.Text, "General Number")) - Val(total_pokok)
                saldo_bunga = Val(Format(nilai_total_bunga, "General Number")) - Val(total_bunga)
            Else
                pokok = Format(FormatNumber(Val(Format(tplafon_akad.Text, "General Number")) / Val(Format(tjkw.Text, "General Number")), 0), "General Number")

                total_pokok = Val(total_pokok) + Val(pokok)
                total_bunga = Val(total_bunga) + Val(bunga)

                
            End If

            saldo_pokok = Val(saldo_pokok) - Val(pokok)
            saldo_bunga = Val(saldo_bunga) - Val(bunga)

            
            cd = New MySqlCommand("INSERT INTO temp_simulasi_kredit VALUES ('" & Format(i, "0##") & "', '" & tgl & "', '" & pokok & "', '" & bunga & "', '" & saldo_pokok & "', '" & saldo_bunga & "', '" & MDIParent1.username.Text & "')", koneksi)
            cd.ExecuteNonQuery()
        Next
        hitung_jumlah_potongan()
        hitung_jumlah_terima()
        user_pengguna = MDIParent1.username.Text
        uraian = "Membuat simulasi kredit"
        insert_log_user()

        form_simulasi_kredit.ShowDialog()
    End Sub

    Sub hitung_jumlah_potongan()
        TextBox2.Text = Val(Format(tprovisi2.Text, "General Number")) + Val(Format(tadministrasi2.Text, "General Number")) + Val(Format(tnotaris.Text, "General Number")) + Val(Format(tmaterai.Text, "General Number")) + Val(Format(tlain.Text, "General Number")) + Val(Format(tasuransi.Text, "General Number"))
    End Sub
    Sub hitung_jumlah_terima()
        TextBox3.Text = Val(Format(tplafon_akad.Text, "General Number")) - Val(TextBox2.Text)
    End Sub


    Sub rumus()
        Try
            tprovisi2.Text = Format(tplafon_akad.Text, "General Number") * (tprovisi1.Text / 100)
        Catch ex As Exception

        End Try
        Try
            tadministrasi2.Text = Format(tplafon_akad.Text, "General Number") * (tadministrasi1.Text / 100)
        Catch ex As Exception

        End Try
    End Sub

    Sub rumus2()
        Try
            tprovisi1.Text = FormatNumber(Val(Val(Format(tprovisi2.Text, "General Number")) * 100) / Val(Format(tplafon_akad.Text, "General Number")), 2)
        Catch ex As Exception

        End Try
        Try
            tadministrasi1.Text = FormatNumber(Val(Val(Format(tadministrasi2.Text, "General Number")) * 100) / Val(Format(tplafon_akad.Text, "General Number")), 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tadministrasi1_TextChanged(sender As Object, e As EventArgs) Handles tadministrasi1.TextChanged, tprovisi1.TextChanged
        If Val(sender.text) >= 100 Then
            sender.text = "0"
        End If
    End Sub
End Class