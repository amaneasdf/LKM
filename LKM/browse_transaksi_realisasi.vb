Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class browse_transaksi_realisasi
    Dim sortcolumn As Integer = -1
    Dim teller As String = ""
    Dim produk As String = ""
    Dim idtransaksi As String
    Dim pencairan, provisi, administrasi, keluaran As String

    Private Sub browse_transaksi_realisasi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub browse_transaksi_realisasi_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub
    Private Sub browse_transaksi_realisasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Browse Transaksi Realisasi [ Teller : " + MDIParent1.nama_lengkap.Text + " / " + Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy") + " ]"
        Me.ResizeRedraw = True
        
        combo()
        tampil()
    End Sub
    Sub combo()
        cd = New MySqlCommand("SELECT concat_ws (' : ', kredit_kode,upper(kredit_nama_produk)) as produkkredit FROM data_kredit_produk", koneksi)
        rd = cd.ExecuteReader
        With cmbproduk.Items
            .Clear()
            .Add("00 : SEMUA ")
            While rd.Read()
                .Add(rd.Item("produkkredit"))
            End While
        End With
        rd.Close()
        cmbproduk.Text = "00 : SEMUA"
    End Sub

    Private Sub browse_transaksi_realisasi_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
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
            .Add("Plafon", 100, HorizontalAlignment.Right) '6
            .Add("Provisi", 100, HorizontalAlignment.Right) '7
            .Add("Adm", 100, HorizontalAlignment.Right) '8
            .Add("Materai", 100, HorizontalAlignment.Right) '9
            .Add("Premi", 100, HorizontalAlignment.Right) '10
            .Add("Notaris", 100, HorizontalAlignment.Right) '11
            .Add("Lain", 100, HorizontalAlignment.Right) '12
            .Add("Jml Terima", 100, HorizontalAlignment.Right) '13
            .Add("Uraian", 300, HorizontalAlignment.Left) '14
            .Add("Teller", 100, HorizontalAlignment.Left) '15
            .Add("Reg Timer", 150, HorizontalAlignment.Left) '16
            .Add("Status", 100, HorizontalAlignment.Center) '17
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
            teller = " AND pencairan_username='" & TextBox1.Text & "'"
        End If
        da = New MySqlDataAdapter("SELECT * FROM v_browse_transaksi_pencairan WHERE (pencairan_tanggal BETWEEN'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "')" + teller + produk + " ORDER BY pencairan_waktu", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
    End Sub
    Sub tampil2()
        da = New MySqlDataAdapter("SELECT jurnal_perkiraan, cari_nama_perkiraan(jurnal_perkiraan) AS namaperkiraan, jurnal_debet, jurnal_kredit, jurnal_uraian FROM data_akuntansi_jurnal WHERE jurnal_jenis='RLS' AND jurnal_trans='" & idtransaksi & "'", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data2()
    End Sub

    Sub data()
        pencairan = "0"
        provisi = "0"
        administrasi = "0"
        keluaran = "0"

        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("pencairan_id_transaksi"))
                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("pencairan_tanggal"), "dd MMM yyyy"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("pencairan_no_kuitansi"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("pencairan_no_rekening"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("namanasabah"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("pencairan_kode_transaksi"))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("pencairan_jml_pencairan"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("pencairan_provisi"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("pencairan_administrasi"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("pencairan_materai"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("pencairan_premi"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("pencairan_notaris"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("pencairan_lain"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("pencairan_jml_terima"), 0))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("uraian") + " " + dt.Rows(i)("pencairan_no_rekening") + " [" + dt.Rows(i)("namanasabah") + "]")
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("pencairan_username"))
                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("pencairan_waktu"), "dd MMM yyyy  HH:mm:ss"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("status"))

                pencairan = Val(pencairan) + Val(dt.Rows(i)("pencairan_jml_pencairan"))
                provisi = Val(provisi) + Val(dt.Rows(i)("pencairan_provisi"))
                administrasi = Val(administrasi) + Val(dt.Rows(i)("pencairan_administrasi"))
                keluaran = Val(keluaran) + Val(dt.Rows(i)("pencairan_jml_terima"))
            Next
        End With
        tjumlahrow.Text = FormatNumber(ListView1.Items.Count, 0)
        tjml_realisasi.Text = FormatNumber(pencairan, 0)
        tprovisi.Text = FormatNumber(provisi, 0)
        tadministrasi.Text = FormatNumber(administrasi, 0)
        tjml_dikeluarkan.Text = FormatNumber(keluaran, 0)
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

        btnvalidasi.Enabled = True

        tampil2()
    End Sub

    Private Sub browse_transaksi_realisasi_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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
            produk = " AND rek_kre_kode_produk='" & cmbproduk.Text.ToString.Split(" :")(0) & "'"
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
                    ElseIf j = 6 Or j = 7 Or j = 8 Or j = 9 Or j = 10 Or j = 11 Or j = 12 Or j = 13 Or j = 14 Then
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

    Private Sub btnvalidasi_Click(sender As Object, e As EventArgs) Handles btnvalidasi.Click
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
                cetakan = "KiriVRealisasi"
            ElseIf ii = 2 Then
                cetakan = "AtasVRealisasi"
            ElseIf ii = 3 Then
                cetakan = "FontVRealisasi"
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

        cd = New MySqlCommand("SELECT pencairan_id_transaksi, pencairan_waktu, pencairan_username, pencairan_kode_transaksi, pencairan_jml_pencairan, pencairan_provisi, pencairan_administrasi, pencairan_premi, pencairan_notaris, pencairan_materai, pencairan_lain, cari_nama_rekening_kredit(pencairan_no_rekening) AS namanasabah, pencairan_no_rekening, cari_teller(pencairan_username) AS kode_teller FROM data_kredit_pencairan WHERE pencairan_id_transaksi='" & idtransaksi & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()

        baris(0) = rd.Item("pencairan_id_transaksi") + " " + Format(rd.Item("pencairan_waktu"), "dd/MM/yy HH:mm:ss").ToString + " [" + rd.Item("kode_teller") + "]"
        baris(1) = rd.Item("pencairan_kode_transaksi").ToString + " CASH IDR " + FormatNumber(rd.Item("pencairan_jml_pencairan"), 0) + " (Rls), " + FormatNumber(rd.Item("pencairan_provisi"), 0) + " (Prv), " + FormatNumber(rd.Item("pencairan_administrasi"), 0) + " (Adm), " + FormatNumber(rd.Item("pencairan_materai"), 0) + " (Mtrai), " + FormatNumber(rd.Item("pencairan_premi"), 0) + " (Premi), " + FormatNumber(rd.Item("pencairan_notaris"), 0) + " (Ntrs), " + FormatNumber(rd.Item("pencairan_lain"), 0) + " (Lain2)"
        baris(2) = rd.Item("namanasabah") + " " + rd.Item("pencairan_no_rekening")

        rd.Close()

        For i = 0 To UBound(baris) ' UBound = batas atas array
            TextToPrint &= baris(i) & Environment.NewLine
        Next i

    End Sub
End Class