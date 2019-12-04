Imports MySql.Data.MySqlClient
Public Class statement_tabungan
    Dim saldo_awal As Long
    Dim jeda, baris_atas, baris_bawah, tampilkan_nomor As String
    Dim kata, kd As String

    Public da_kolom As MySqlDataAdapter
    Public dt_kolom As DataTable

    Private Sub statement_tabungan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub statement_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub statement_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cmbtemplate
            .Items.Clear()
            .Items.Add("1 : TEMPLATE 1")
            .Items.Add("2 : TEMPLATE 2")
            .Items.Add("3 : TEMPLATE 3")
            .SelectedIndex = 0
        End With
        ukuran()
        Me.ResizeRedraw = True
        tampil()
    End Sub

    Private Sub statement_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub tnasabah_id_LostFocus(sender As Object, e As EventArgs) Handles tno_rekening.LostFocus
        caristatement()
        tampil()
    End Sub

    Private Sub cmbtemplate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbtemplate.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbtemplate_LostFocus(sender As Object, e As EventArgs) Handles cmbtemplate.LostFocus, tno_rekening.LostFocus, tjumlah.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub cmbtemplate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtemplate.SelectedIndexChanged
        btnpreview.PerformClick()
    End Sub

    Private Sub tjumlah_GotFocus(sender As Object, e As EventArgs) Handles tjumlah.GotFocus, cmbtemplate.GotFocus, tno_rekening.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tjumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tjumlah.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tjumlah_LostFocus(sender As Object, e As EventArgs) Handles tjumlah.LostFocus
        Dim jm As Long
        jm = tjumlah.Text
        tjumlah.Text = Format(jm, "0#")
    End Sub
    Sub caristatement()
        cd = New MySqlCommand("SELECT nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, nasabah_reg_waktu FROM data_nasabah WHERE nasabah_id=(SELECT rek_tab_nasabah_id FROM data_tabungan_rekening WHERE rek_tab_no_rekening='" & tno_rekening.Text & "')", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_nasabah.Text = rd.Item("nasabah_nama1")
            talamat.Text = rd.Item("nasabah_alamat") + ", " + rd.Item("nasabah_kelurahan") + ", " + rd.Item("nasabah_kecamatan")
            DateTimePicker1.Value = rd.Item("nasabah_reg_waktu")
        Catch ex As Exception
            tnama_nasabah.Clear()
            talamat.Clear()
            DateTimePicker1.Value = Format(MDIParent1.DateTimePicker1.Value, "dd MMM yyyy")
            DateTimePicker2.Value = Format(MDIParent1.DateTimePicker1.Value, "dd MMM yyyy")
        End Try
        rd.Close()
    End Sub
  
    Sub ukuran()
        da_kolom = New MySqlDataAdapter("SELECT * FROM setup_kolom_buku_tabungan WHERE kolom_jenis='" & cmbtemplate.Text & "' ORDER BY kolom_urutan ASC", koneksi)
        dt_kolom = New DataTable
        da_kolom.Fill(dt_kolom)

        With ListView1.Columns
            .Clear()
            .Add("", 0, HorizontalAlignment.Left)
            .Add("", 0, HorizontalAlignment.Left)
            .Add("", 0, HorizontalAlignment.Left)

            For ii As Integer = 0 To dt_kolom.Rows.Count - 1
                If dt_kolom.Rows(ii)("kolom_isian") <> "" Then
                    Select Case dt_kolom.Rows(ii)("kolom_isian").Split(" :")(0)
                        Case "01"
                            .Add("Tanggal", 100, HorizontalAlignment.Left)
                        Case "02"
                            .Add("Kode", 50, HorizontalAlignment.Center)
                        Case "03"
                            .Add("Debet", 100, HorizontalAlignment.Right)
                        Case "04"
                            .Add("Kredit", 100, HorizontalAlignment.Right)
                        Case "05"
                            .Add("Uraian", 250, HorizontalAlignment.Left)
                        Case "06"
                            .Add("Mutasi", 100, HorizontalAlignment.Right)
                        Case "07"
                            .Add("D/K", 50, HorizontalAlignment.Center)
                        Case "08"
                            .Add("Saldo", 100, HorizontalAlignment.Right)
                        Case "09"
                            .Add("Teller", 100, HorizontalAlignment.Left)
                        Case Else
                            .Add("", 0, HorizontalAlignment.Left)
                    End Select
                End If
            Next

        End With
    End Sub
    Sub tampil()
        da = New MySqlDataAdapter("SELECT * FROM v_mutasi_buku_tabungan WHERE tab_stat_no_rekening='" & tno_rekening.Text & "' AND (tab_stat_tanggal BETWEEN'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "') ORDER BY tab_stat_waktu", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("tab_stat_id_transaksi"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("tab_stat_kode"))
                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("tab_stat_waktu"), "yyyy-MM-dd HH:mm:ss"))
                For ii As Integer = 0 To dt_kolom.Rows.Count - 1
                    If dt_kolom.Rows(ii)("kolom_isian") <> "" Then
                        Select Case dt_kolom.Rows(ii)("kolom_isian").Split(" :")(0)
                            Case "01"
                                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("tab_stat_tanggal"), "dd/MM/yy"))
                            Case "02"
                                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("tab_stat_kode"))
                            Case "03"
                                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("tab_stat_debet"), 0))
                            Case "04"
                                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("tab_stat_kredit"), 0))
                            Case "05"
                                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("tab_stat_uraian"))
                            Case "06"
                                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("mutasi"), 0))
                            Case "07"
                                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("d_or_k"))
                            Case "08"
                                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("tab_stat_saldo"), 0))
                            Case "09"
                                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kode_teller"))
                            Case Else
                                .Items(.Items.Count - 1).SubItems().Add("")
                        End Select
                    End If
                Next
            Next
        End With
    End Sub
    Sub cetakcover()
        Dim ukuran(99) As String
        Dim cetakan As String = ""
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""

        For ii As Integer = 1 To 3
            If ii = 1 Then
                cetakan = "KiriCover"
            ElseIf ii = 2 Then
                cetakan = "AtasCover"
            ElseIf ii = 3 Then
                cetakan = "FontCover"
            End If
            cd = New MySqlCommand("SELECT IFNULL(cetakan_ukuran, 0) AS ukuran FROM setup_cetakan WHERE cetakan_nama='" & cetakan & "' ", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            ukuran(ii) = rd.Item("ukuran")
            rd.Close()
        Next
        kiri = ukuran(1)
        atas = ukuran(2)
        ukuran_font_cetak = ukuran(3)

        isicetakcover()
        Dim printControl = New Printing.StandardPrintController
        MDIParent1.PrintDocument1.PrintController = printControl
        Try
            MDIParent1.PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Printer gagal", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Sub cetak()
        Dim ukuran(99) As String
        Dim cetakan As String = ""
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""

        For ii As Integer = 1 To 7
            If ii = 1 Then
                cetakan = "KiriBukuTabungan"
            ElseIf ii = 2 Then
                cetakan = "AtasBukuTabungan"
            ElseIf ii = 3 Then
                cetakan = "FontBukuTabungan"
            ElseIf ii = 4 Then
                cetakan = "JedaBukuTabungan"
            ElseIf ii = 5 Then
                cetakan = "BarisAtasBukuTabungan"
            ElseIf ii = 6 Then
                cetakan = "BarisBawahBukuTabungan"
            ElseIf ii = 7 Then
                cetakan = "TampilkanNomor"
            End If
            cd = New MySqlCommand("SELECT IFNULL(cetakan_ukuran, 0) AS ukuran FROM setup_cetakan WHERE cetakan_nama='" & cetakan & "' ", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            ukuran(ii) = rd.Item("ukuran")
            rd.Close()
        Next
        kiri = ukuran(1)
        atas = ukuran(2)
        ukuran_font_cetak = ukuran(3)
        jeda = ukuran(4)
        baris_atas = ukuran(5)
        baris_bawah = ukuran(6)
        tampilkan_nomor = ukuran(7)

        isicetak()
        Dim printControl = New Printing.StandardPrintController
        MDIParent1.PrintDocument1.PrintController = printControl
        Try
            MDIParent1.PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Printer gagal", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub


    Sub isicetakcover()
        Dim baris(99) As String
        da = New MySqlDataAdapter("SELECT * FROM setup_cover_buku_tabungan ORDER BY cover_urutan ASC", koneksi)
        dt = New DataTable
        da.Fill(dt)

        cd = New MySqlCommand("SELECT nasabah_nik, nasabah_id, rek_tab_no_rekening, nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, nasabah_reg_waktu FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id WHERE rek_tab_no_rekening='" & tno_rekening.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        For ii As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(ii)("cover_isian") <> "" Then
                Select Case dt.Rows(ii)("cover_isian").Split(" :")(0)
                    Case "01"
                        baris(ii) = rd.Item("nasabah_nik")
                    Case "02"
                        baris(ii) = rd.Item("nasabah_id")
                    Case "03"
                        baris(ii) = rd.Item("rek_tab_no_rekening")
                    Case "04"
                        baris(ii) = rd.Item("nasabah_nama1")
                    Case "05"
                        baris(ii) = rd.Item("nasabah_alamat") + ", " + rd.Item("nasabah_kelurahan") + ", " + rd.Item("nasabah_kecamatan")
                    Case "06"
                        baris(ii) = Format(rd.Item("nasabah_reg_waktu"), "dd/MM/yyyy")
                    Case Else
                        baris(ii) = ""
                End Select
            End If
        Next
        rd.Close()

        For i = 0 To UBound(baris) ' UBound = batas atas array
            If baris(i) <> "" Then
                TextToPrint &= baris(i) & Environment.NewLine
            End If
        Next i
    End Sub
    
    Private Sub btncetakcver_Click(sender As Object, e As EventArgs) Handles btncetakcver.Click
        If Len(tnama_nasabah.Text) = 0 Then
            MessageBox.Show("Data Rekening tidak ditemukan", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            cetakcover()
        End If
    End Sub

    Sub isicetak()
        Dim isian(99) As String
        Dim urutan(99) As String
        Dim max_karakter As Integer

        If CheckBox1.Checked = True Then
            cd = New MySqlCommand("SELECT IFNULL(SUM(tab_stat_kredit-tab_stat_debet),0) AS sisa_saldo FROM data_tabungan_statement WHERE tab_stat_no_rekening='" & tno_rekening.Text & "' AND tab_stat_tanggal < '" & ListView1.SelectedItems.Item(0).SubItems(2).Text & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()

            TextToPrint &= (StrDup(10, " ") + "Saldo Pindahan" + StrDup(18 - Len(FormatNumber(rd.Item("sisa_saldo"), 0)), " ") + FormatNumber(rd.Item("sisa_saldo"), 0)) & Environment.NewLine

            rd.Close()
        Else
            TextToPrint &= "" & Environment.NewLine
        End If

        Dim i1 As Integer = 1
        Do Until i1 = Format(tjumlah.Text, "General Number")
            TextToPrint &= "" & Environment.NewLine
            i1 += 1
        Loop

        Dim i2 = i1

        Do Until i1 - 1 = Val(baris_atas) + Val(baris_bawah) Or i1 - i2 = ListView1.SelectedItems.Count

            For kolom As Integer = 1 To 9
                If dt_kolom.Rows(kolom - 1)("kolom_isian") <> "" Then
                    max_karakter = dt_kolom.Rows(kolom - 1)("kolom_ukuran")
                    Dim kolom_isian As String = dt_kolom.Rows(kolom - 1)("kolom_isian").Split(" :")(0)
                    If kolom_isian = "01" Or kolom_isian = "02" Or kolom_isian = "07" Or kolom_isian = "09" Then ' tanggal, kode, d/k, teller
                        isian(kolom - 1) = Microsoft.VisualBasic.Left(ListView1.SelectedItems.Item(i1 - i2).SubItems(kolom + 2).Text.ToString, max_karakter)
                        urutan(kolom - 1) = isian(kolom - 1) + StrDup((max_karakter - Len(isian(kolom - 1))), " ") + " "

                    ElseIf kolom_isian = "03" Or kolom_isian = "04" Or kolom_isian = "06" Or kolom_isian = "08" Then 'debet, kredit, mutasi, saldo
                        isian(kolom - 1) = Microsoft.VisualBasic.Right(ListView1.SelectedItems.Item(i1 - i2).SubItems(kolom + 2).Text.ToString, max_karakter)
                        urutan(kolom - 1) = StrDup((max_karakter - Len(isian(kolom - 1))), " ") + isian(kolom - 1) + "  "

                    ElseIf kolom_isian = "05" Then 'uraian
                        kd = ListView1.SelectedItems.Item(i1 - i2).SubItems(1).Text
                        uraian_transaksi()
                        isian(kolom - 1) = Microsoft.VisualBasic.Left(kata, max_karakter)
                        urutan(kolom - 1) = isian(kolom - 1) + StrDup((max_karakter - Len(isian(kolom - 1))), " ") + " "

                    Else
                        urutan(kolom - 1) = " "
                    End If
                    
                End If
            Next
            
            Dim semuaurutan As String = ""
            For ii = 0 To UBound(urutan) ' UBound = batas atas array
                If urutan(ii) <> "" Then
                    semuaurutan = semuaurutan.ToString + urutan(ii).ToString
                End If
            Next ii

            If tampilkan_nomor = "1" Then
                TextToPrint &= Format(i1, "0#").ToString() + "  " + semuaurutan & Environment.NewLine
            Else
                TextToPrint &= semuaurutan & Environment.NewLine
            End If

            If i1 = baris_atas Then
                For jd As Integer = 1 To jeda
                    TextToPrint &= "" & Environment.NewLine
                Next
            End If

            i1 += 1
        Loop

    End Sub

    Sub uraian_transaksi()
        Select Case kd
            Case "01"
                kata = "Setoran Tunai"
            Case "02"
                kata = "Penarikan Tunai"
            Case "03"
                kata = "Tarik"
            Case "04"
                kata = "Penutupan Tunai"
            Case "05"
                kata = "Setoran ke COA"
            Case "06"
                kata = "Penarikan dari COA"
            Case "07"
                kata = "Bunga Tabungan"
            Case "08"
                kata = "Bea Adm Bulanan"
            Case "09"
                kata = "Bea Rek Pasif"
            Case "10"
                kata = "Pajak Bunga"
            Case "97"
                kata = "Angsuran Kredit"
            Case "98"
                kata = "Penutupan Tunai"
            Case "99"
                kata = "OB Antar Tabungan"
            Case Else
                kata = ""
        End Select
    End Sub

    Private Sub btncetak_Click(sender As Object, e As EventArgs) Handles btncetak.Click
        If Len(tnama_nasabah.Text) = 0 Then
            MessageBox.Show("Data Rekening tidak ditemukan", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If ListView1.SelectedItems.Count = 0 Then
                MessageBox.Show("Pilih data yang akan dicetak", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'If MDIParent1.pilihanprinter.Text = "" Then
                'MessageBox.Show("Printer belum dipilih", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Else
                cetak()
                'End If
            End If
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            tjumlah.Enabled = False
            tjumlah.Text = "01"
        Else
            tjumlah.Enabled = True
        End If
    End Sub

    Private Sub btnpreview_Click(sender As Object, e As EventArgs) Handles btnpreview.Click
        ukuran()
        tampil()
    End Sub

    Private Sub tno_rekening_TextChanged(sender As Object, e As EventArgs) Handles tno_rekening.TextChanged

    End Sub
End Class