Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class browser_transaksi_tabungan
    Dim sortcolumn As Integer = -1
    Dim teller As String = ""
    Dim produk As String = ""
    Dim idtransaksi As String
    Dim setor_t, setor_o, tarik_t, tarik_o As String
    Private Sub browser_transaksi_tabungan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        browse_transaksi.Dispose()
    End Sub

    Private Sub browser_transaksi_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub browser_transaksi_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Browse Transaksi Tabungan [ Teller : " + MDIParent1.nama_lengkap.Text + " / " + Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy") + " ]"
        Me.ResizeRedraw = True
        combo()
        tampil()
    End Sub

    Sub combo()
        cd = New MySqlCommand("SELECT tabungan_kode, concat_ws (' : ', tabungan_kode,upper(tabungan_nama_produk)) as produktabungan FROM data_tabungan_produk", koneksi)
        rd = cd.ExecuteReader
        With cmbproduk.Items
            .Clear()
            .Add("00 : SEMUA ")
            While rd.Read()
                .Add(rd.Item("produktabungan"))
            End While
        End With
        rd.Close()
        cmbproduk.Text = "00 : SEMUA"
    End Sub

    Private Sub browser_transaksi_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub
    Sub ukuran1()
        With ListView1.Columns
            .Clear()
            .Add("Trans ID", 130, HorizontalAlignment.Left) '0
            .Add("Tanggal", 100, HorizontalAlignment.Left) '1
            .Add("No Kuitansi", 100, HorizontalAlignment.Left) '2
            .Add("No Rekening", 100, HorizontalAlignment.Left) '3
            .Add("Nama Nasabah", 200, HorizontalAlignment.Left) '4
            .Add("Kode", 50, HorizontalAlignment.Center) '5
            .Add("Setor", 100, HorizontalAlignment.Right) '6
            .Add("Tarik", 100, HorizontalAlignment.Right) '7
            .Add("Adm", 100, HorizontalAlignment.Right) '8
            .Add("T/O", 50, HorizontalAlignment.Center) '9
            .Add("Uraian", 300, HorizontalAlignment.Left) '10
            .Add("Ket Adm", 100, HorizontalAlignment.Left) '11
            .Add("Teller", 100, HorizontalAlignment.Left) '12
            .Add("Reg Time", 150, HorizontalAlignment.Left) '13
            .Add("Status", 100, HorizontalAlignment.Center) '14
        End With
    End Sub
    Sub ukuran2()
        With ListView2.Columns
            .Clear()
            .Add("Kode Perk", 100, HorizontalAlignment.Left)
            .Add("Nama Perk", 300, HorizontalAlignment.Left)
            .Add("Debet", 100, HorizontalAlignment.Right)
            .Add("Kredit", 100, HorizontalAlignment.Right)
            .Add("Uraian", 400, HorizontalAlignment.Left)
        End With
    End Sub

    Sub tampil()
        If TextBox1.Text <> "" Then
            teller = " AND trans_tab_username='" & TextBox1.Text & "'"
        End If
        da = New MySqlDataAdapter("SELECT * FROM v_browse_transaksi_tabungan WHERE (trans_tab_tanggal BETWEEN'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "')" + teller + produk + " ORDER BY trans_tab_waktu", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
    End Sub
    Sub tampil2()
        da = New MySqlDataAdapter("SELECT jurnal_perkiraan, cari_nama_perkiraan(jurnal_perkiraan) AS namaperkiraan, jurnal_debet, jurnal_kredit, jurnal_uraian FROM data_akuntansi_jurnal WHERE jurnal_jenis='TAB' AND jurnal_trans='" & idtransaksi & "'", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data2()
    End Sub
    Sub data()
        setor_o = "0"
        setor_t = "0"
        tarik_o = "0"
        tarik_t = "0"
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("trans_tab_id_transaksi"))
                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("trans_tab_tanggal"), "dd MMM yyyy"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("trans_tab_no_kuitansi"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("trans_tab_no_rekening"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("namanasabah"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("trans_tab_kode_transaksi"))
                If dt.Rows(i)("jenis") = "O" Then
                    setor_o = Val(setor_o) + Val(dt.Rows(i)("trans_tab_jml_setoran")) '6
                    tarik_o = Val(tarik_o) + Val(dt.Rows(i)("trans_tab_jml_penarikan")) '7
                Else
                    setor_t = Val(setor_t) + Val(dt.Rows(i)("trans_tab_jml_setoran")) '6
                    tarik_t = Val(tarik_t) + Val(dt.Rows(i)("trans_tab_jml_penarikan")) '7
                End If
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("trans_tab_jml_setoran"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("trans_tab_jml_penarikan"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("trans_tab_nominal_bea"), 0))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("jenis"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("uraian"))
                .Items(.Items.Count - 1).SubItems().Add("") 'ket_adm
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("trans_tab_username"))
                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("trans_tab_waktu"), "dd MMM yyyy  HH:mm:ss"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("status"))
            Next
        End With
        tjumlahrow.Text = FormatNumber(ListView1.Items.Count, 0)
        tsetor_t.Text = FormatNumber(setor_t, 0)
        tsetor_o.Text = FormatNumber(setor_o, 0)

        ttarik_t.Text = FormatNumber(tarik_t, 0)
        ttarik_o.Text = FormatNumber(tarik_o, 0)
    End Sub

    Sub data2()
        With ListView2
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("jurnal_perkiraan"))
                If dt.Rows(i)("jurnal_debet") = "0" Then
                    .Items(.Items.Count - 1).SubItems().Add("     " + dt.Rows(i)("namaperkiraan"))
                Else
                    .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("namaperkiraan"))
                End If
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("jurnal_debet"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("jurnal_kredit"), 0))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("jurnal_uraian"))
            Next
        End With
    End Sub
    Sub listselect()
        With ListView1.SelectedItems.Item(0)
            idtransaksi = .Text
        End With

        cd = New MySqlCommand("SELECT trans_tab_status FROM data_tabungan_transaksi WHERE trans_tab_id_transaksi='" & ListView1.SelectedItems.Item(0).Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()

        If ListView1.SelectedItems.Item(0).SubItems(1).Text = Format(MDIParent1.DateTimePicker1.Value, "dd MMM yyyy") And Strings.Right(ListView1.SelectedItems.Item(0).Text, 1) <> "R" And rd.Item("trans_tab_status") = "1" And ListView1.SelectedItems.Item(0).SubItems(5).Text <> "04" Then
            'If Strings.Right(ListView1.SelectedItems.Item(0).Text, 1) <> "R" And rd.Item("trans_tab_status") = "1" And ListView1.SelectedItems.Item(0).SubItems(5).Text <> "04" Then
            btnreversal.Enabled = True
        Else
            btnreversal.Enabled = False
        End If

        rd.Close()

        btnvalidasi.Enabled = True

        tampil2()
    End Sub

    Private Sub browser_transaksi_tabungan_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = MDIParent1.Width - 20
        Me.Height = MDIParent1.Height - 177

        cmbproduk.Location = New Point(Me.Width - 218, 6)
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        listselect()
    End Sub

    Private Sub cmbproduk_GotFocus(sender As Object, e As EventArgs) Handles cmbproduk.GotFocus
        cmbproduk.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbproduk_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbproduk.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbproduk_LostFocus(sender As Object, e As EventArgs) Handles cmbproduk.LostFocus
        cmbproduk.BackColor = warna_lostfocus
    End Sub

    Private Sub cmbproduk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbproduk.SelectedIndexChanged
        If cmbproduk.Text.ToString.Split(" :")(0) <> "00" Then
            produk = " AND rek_tab_kode_produk='" & cmbproduk.Text.ToString.Split(" :")(0) & "'"
        Else
            produk = ""
        End If
        tampil()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            listselect()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        tampil()
    End Sub

    Private Sub btnexport_Click(sender As Object, e As EventArgs) Handles btnexport.Click
        Try
            Dim objExcel As New Excel.Application
            Dim bkWorkBook As Excel.Workbook
            Dim shWorkSheet As Excel.Worksheet
            Dim i As Integer
            Dim j As Integer

            objExcel = New Excel.Application
            bkWorkBook = objExcel.Workbooks.Add
            shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)

            shWorkSheet.Cells(1, 1) = "MICRO FINANCE SYSTEM"
            shWorkSheet.Cells(1, 1).font.bold = True
            shWorkSheet.Cells(2, 1) = MDIParent1.nama_lembaga.Text
            shWorkSheet.Cells(2, 1).font.bold = True
            shWorkSheet.Cells(3, 1) = Label1.Text
            shWorkSheet.Cells(3, 1).font.bold = True
            For i = 0 To ListView1.Columns.Count - 1
                shWorkSheet.Cells(5, i + 1) = ListView1.Columns(i).Text
                shWorkSheet.Cells(5, i + 1).font.bold = True
                'shWorkSheet.Columns.AutoFit() 
            Next

            For i = 0 To ListView1.Items.Count - 1
                For j = 0 To ListView1.Items(i).SubItems.Count - 1
                    If j = 0 Or j = 2 Or j = 3 Or j = 5 Then
                        shWorkSheet.Cells(i + 6, j + 1) = "'" + ListView1.Items(i).SubItems(j).Text
                    ElseIf j = 6 Or j = 7 Or j = 8 Then
                        shWorkSheet.Cells(i + 6, j + 1) = ListView1.Items(i).SubItems(j).Text.Replace(".", "")
                    Else
                        shWorkSheet.Cells(i + 6, j + 1) = ListView1.Items(i).SubItems(j).Text
                    End If
                Next
            Next
            objExcel.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnreversal_Click(sender As Object, e As EventArgs) Handles btnreversal.Click
        If MessageBox.Show("Yakin akan mengoreksi transaksi ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            prosesreversal()
        End If
    End Sub

    Sub prosesreversal()
        Dim data_ke(99) As String
        data_ke(0) = ListView1.SelectedItems.Item(0).Text.ToString + "R" 'id trans
        data_ke(1) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd") 'tgl
        data_ke(2) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") ' waktu
        data_ke(3) = ListView1.SelectedItems.Item(0).SubItems(3).Text 'no rekening
        data_ke(4) = "" 'no buku
        Select Case ListView1.SelectedItems.Item(0).SubItems(5).Text
            Case "01"
                data_ke(5) = "02" 'kode transaksi
            Case "02"
                data_ke(5) = "01" 'kode transaksi
            Case "03"
                data_ke(5) = "03" 'kode transaksi
            Case "05"
                data_ke(5) = "06" 'kode transaksi
            Case "06"
                data_ke(5) = "05" 'kode transaksi

        End Select
        data_ke(6) = "" 'no kuitansi
        data_ke(7) = "" 'penyetor1
        data_ke(8) = "" 'penyetor2
        data_ke(9) = "" 'penyetor3
        data_ke(10) = Format(ListView1.SelectedItems.Item(0).SubItems(7).Text, "General Number") 'setoran
        data_ke(11) = Format(ListView1.SelectedItems.Item(0).SubItems(6).Text, "General Number") 'penarikan
        data_ke(12) = "" 'bea

        cd = New MySqlCommand("SELECT trans_tab_rekening_tujuan FROM data_tabungan_transaksi WHERE trans_tab_id_transaksi='" & ListView1.SelectedItems.Item(0).Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        data_ke(13) = rd.Item("trans_tab_rekening_tujuan") 'tnomor_rekening_tujuan
        rd.Close()

        data_ke(14) = "" 'sumber dana
        data_ke(15) = "" 'sumber dana
        data_ke(16) = "" 'keterngan
        data_ke(17) = "1" 'status
        data_ke(18) = MDIParent1.username.Text 'username

        Dim gabung = ""
        For n = 0 To 18
            If n = 0 Then
                gabung += "'" + data_ke(n) + "'"
            Else
                gabung += ",'" + data_ke(n) + "'"
            End If
        Next

        cd = New MySqlCommand("INSERT INTO data_tabungan_transaksi VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        cd = New MySqlCommand("UPDATE data_tabungan_transaksi SET trans_tab_status='2' WHERE trans_tab_id_transaksi='" & ListView1.SelectedItems.Item(0).Text & "'", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Melakukan Transaksi Reversal Tabungan (trans_tab_id_transaksi : " + data_ke(0) + ")"
        insert_log_user()

        tampil()
        btnreversal.Enabled = False
    End Sub

    Private Sub btvalidasi_Click(sender As Object, e As EventArgs) Handles btnvalidasi.Click
        If MessageBox.Show("Cetak Validasi?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            'PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
            cetakvalidasi()
        End If
        btnvalidasi.Enabled = False
    End Sub

    Sub cetakvalidasi()
        Dim ukuran(99) As String
        Dim cetakan As String = ""
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""

        For ii As Integer = 1 To 3
            If ii = 1 Then
                cetakan = "KiriVTabungan"
            ElseIf ii = 2 Then
                cetakan = "AtasVTabungan"
            ElseIf ii = 3 Then
                cetakan = "FontVTabungan"
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

        isivalidasi()
        Dim printControl = New Printing.StandardPrintController
        MDIParent1.PrintDocument1.PrintController = printControl
        Try
            MDIParent1.PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Printer gagal", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Sub isivalidasi()
        Dim baris(99) As String

        cd = New MySqlCommand("SELECT trans_tab_id_transaksi, trans_tab_waktu, trans_tab_username, trans_tab_kode_transaksi, (trans_tab_jml_setoran + trans_tab_jml_penarikan) AS total, IF(trans_tab_kode_transaksi IN ('01','02','04'),' CASH ',' OVERBOOKING ') AS jns, trans_tab_nominal_bea, tab_stat_uraian, cari_teller(trans_tab_username) AS kode_teller FROM data_tabungan_statement JOIN data_tabungan_transaksi ON tab_stat_id_transaksi=trans_tab_id_transaksi WHERE tab_stat_id_transaksi='" & idtransaksi & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()

        baris(0) = rd.Item("trans_tab_id_transaksi") + " " + Format(rd.Item("trans_tab_waktu"), "dd/MM/yy HH:mm:ss").ToString + " [" + rd.Item("kode_teller") + "]"
        baris(1) = rd.Item("trans_tab_kode_transaksi").ToString + rd.Item("jns").ToString + "IDR " + FormatNumber(rd.Item("total"), 0) + " Adm " + FormatNumber(rd.Item("trans_tab_nominal_bea"), 0)
        baris(2) = rd.Item("tab_stat_uraian")

        rd.Close()

        For i = 0 To UBound(baris) ' UBound = batas atas array
            TextToPrint &= baris(i) & Environment.NewLine
        Next i

    End Sub

End Class