Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class browse_transaksi_jurnal_kas
    Dim teller As String = ""
    Dim idtransaksi As String
    Dim kembali, distribusi As String

    Private Sub browse_transaksi_jurnal_kas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        browse_transaksi.Dispose()
    End Sub

    Private Sub browse_transaksi_jurnal_kas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub
    Private Sub browse_transaksi_jurnal_kas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Browse Transaksi Jurnal Kas [ Teller : " + MDIParent1.nama_lengkap.Text + " / " + Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy") + " ]"
        Me.ResizeRedraw = True
        tampil()
    End Sub

    Private Sub browse_transaksi_jurnal_kas_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
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
            .Add("Perkiraan", 100, HorizontalAlignment.Left) '3
            .Add("Pendapatan", 100, HorizontalAlignment.Right) '4
            .Add("Biaya", 100, HorizontalAlignment.Right) '5
            .Add("Uraian", 300, HorizontalAlignment.Left) '6
            .Add("Teller", 100, HorizontalAlignment.Left) '7
            .Add("Reg Time", 150, HorizontalAlignment.Left) '8
            .Add("Status", 100, HorizontalAlignment.Center) '9
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
            teller = " AND kas_username='" & TextBox1.Text & "'"
        End If
        da = New MySqlDataAdapter("SELECT * FROM v_browse_transaksi_jurnal_kas WHERE (kas_tanggal BETWEEN'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "')" + teller + " ORDER BY kas_waktu", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data()
    End Sub
    Sub tampil2()
        da = New MySqlDataAdapter("SELECT jurnal_perkiraan, cari_nama_perkiraan(jurnal_perkiraan) AS namaperkiraan, jurnal_debet, jurnal_kredit, jurnal_uraian FROM data_akuntansi_jurnal WHERE jurnal_jenis='JUR' AND jurnal_trans='" & idtransaksi & "'", koneksi)
        dt = New DataTable
        da.Fill(dt)
        data2()
    End Sub
    Sub data()
        kembali = "0"
        distribusi = "0"
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(dt.Rows(i)("kas_id_transaksi"))
                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("kas_tanggal"), "dd MMM yyyy"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kas_no_kuitansi"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kas_kode_perkiraan"))
                kembali = Val(kembali) + Val(dt.Rows(i)("pendapatan"))
                distribusi = Val(distribusi) + Val(dt.Rows(i)("biaya"))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("pendapatan"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("biaya"), 0))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kas_keterangan"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kas_username"))
                .Items(.Items.Count - 1).SubItems().Add(Format(dt.Rows(i)("kas_waktu"), "dd MMM yyyy  HH:mm:ss"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("status"))
            Next
        End With
        tjumlahrow.Text = FormatNumber(ListView1.Items.Count, 0)
        tjumlah_kembali.Text = FormatNumber(kembali, 0)
        tjumlah_distribusi.Text = FormatNumber(distribusi, 0)
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

    Private Sub browse_transaksi_jurnal_kas_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = MDIParent1.Width - 20
        Me.Height = MDIParent1.Height - 177
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        listselect()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            listselect()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
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
                    If j = 0 Or j = 2 Or j = 3 Then
                        shWorkSheet.Cells(i + 6, j + 1) = "'" + ListView1.Items(i).SubItems(j).Text
                    ElseIf j = 4 Or j = 5 Then
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
                cetakan = "KiriVKas"
            ElseIf ii = 2 Then
                cetakan = "AtasVKas"
            ElseIf ii = 3 Then
                cetakan = "FontVKas"
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

        cd = New MySqlCommand("SELECT kas_id_transaksi, kas_waktu, kas_username, kas_kode_transaksi, kas_jumlah, kas_kode_perkiraan, cari_nama_perkiraan(kas_kode_perkiraan) AS namaperkiraan, cari_teller(kas_username) AS kode_teller FROM data_akuntansi_transaksi_kas WHERE kas_id_transaksi='" & idtransaksi & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()

        baris(0) = rd.Item("kas_id_transaksi") + " " + Format(rd.Item("kas_waktu"), "dd/MM/yy HH:mm:ss").ToString + " [" + rd.Item("kode_teller") + "]"
        baris(1) = rd.Item("kas_kode_transaksi").ToString + " CASH IDR " + FormatNumber(rd.Item("kas_jumlah"), 0)
        baris(2) = rd.Item("kas_kode_perkiraan").ToString + " " + rd.Item("namaperkiraan").ToString

        rd.Close()

        For i = 0 To UBound(baris) ' UBound = batas atas array
            TextToPrint &= baris(i) & Environment.NewLine
        Next i

    End Sub
End Class