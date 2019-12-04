Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class laporan_buku_besar

    Private Sub laporan_buku_besar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        browse_transaksi.Dispose()
    End Sub

    Private Sub laporan_buku_besar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        End If
    End Sub

    Private Sub laporan_buku_besar_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ResizeRedraw = True
        tampil()
    End Sub

    Private Sub laporan_buku_besar_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub
    Sub ukuran1()
        With ListView1.Columns
            .Clear()
            .Add("Trans ID", 130, HorizontalAlignment.Left)
            .Add("Kode Perk", 100, HorizontalAlignment.Left)
            .Add("Nama Perk", 250, HorizontalAlignment.Left)
            .Add("Tanggal", 100, HorizontalAlignment.Left)
            .Add("Uraian", 300, HorizontalAlignment.Left)
            .Add("Debet", 100, HorizontalAlignment.Right)
            .Add("Kredit", 100, HorizontalAlignment.Right)
            .Add("Saldo", 100, HorizontalAlignment.Right)
            .Add("D/K", 50, HorizontalAlignment.Center)
            .Add("Register", 150, HorizontalAlignment.Left)
            .Add("Alias", 100, HorizontalAlignment.Left)
        End With
    End Sub
    Sub tampil()
        da = New MySqlDataAdapter("SELECT *, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "') AS saldo_awal FROM kode_perkiraan", koneksi)
        dt = New DataTable
        da.Fill(dt)
        Data()
    End Sub
    Sub data()
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add("")
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("perkiraan_kode"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("perkiraan_nama"))
                .Items(.Items.Count - 1).SubItems().Add(Format(DateTimePicker1.Value, "dd MMM yyyy"))
                .Items(.Items.Count - 1).SubItems().Add("SALDO AWAL")
                If dt.Rows(i)("perkiraan_d_or_k") = "D" Then
                    .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("saldo_awal"), 0))
                    .Items(.Items.Count - 1).SubItems().Add(FormatNumber("0", 0))
                Else
                    .Items(.Items.Count - 1).SubItems().Add(FormatNumber("0", 0))
                    .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("saldo_awal"), 0))
                End If
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("saldo_awal"), 0))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("perkiraan_d_or_k"))
                .Items(.Items.Count - 1).SubItems().Add(Format(DateTimePicker1.Value, "dd MMM yyyy").ToString + " 00:00:00")
                .Items(.Items.Count - 1).SubItems().Add("SYSTEM")

                cd = New MySqlCommand("SELECT *, hitung_saldo_perkiraan_akhir(jurnal_perkiraan,jurnal_waktu) AS saldo_akhir FROM data_akuntansi_jurnal WHERE jurnal_perkiraan='" & dt.Rows(i)("perkiraan_kode") & "' AND (jurnal_tanggal BETWEEN '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "')", koneksi)
                rd = cd.ExecuteReader
                While rd.Read()
                    .Items.Add(rd.Item("jurnal_trans"))
                    .Items(.Items.Count - 1).SubItems().Add(rd.Item("jurnal_perkiraan"))
                    .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("perkiraan_nama"))
                    .Items(.Items.Count - 1).SubItems().Add(Format(rd.Item("jurnal_tanggal"), "dd MMM yyyy"))
                    .Items(.Items.Count - 1).SubItems().Add(rd.Item("jurnal_uraian"))
                    .Items(.Items.Count - 1).SubItems().Add(FormatNumber(rd.Item("jurnal_debet"), 0))
                    .Items(.Items.Count - 1).SubItems().Add(FormatNumber(rd.Item("jurnal_kredit"), 0))
                    .Items(.Items.Count - 1).SubItems().Add(FormatNumber(rd.Item("saldo_akhir"), 0))
                    .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("perkiraan_d_or_k"))
                    .Items(.Items.Count - 1).SubItems().Add(Format(rd.Item("jurnal_waktu"), "dd MMM yyyy  HH:mm:ss"))
                    .Items(.Items.Count - 1).SubItems().Add(rd.Item("jurnal_username"))
                End While
                rd.Close()

            Next
        End With
    End Sub

    Private Sub laporan_buku_besar_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = MDIParent1.Width - 20
        Me.Height = MDIParent1.Height - 177
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
            shWorkSheet.Cells(3, 1) = "Laporan Buku Besar"
            shWorkSheet.Cells(3, 1).font.bold = True
            For i = 0 To ListView1.Columns.Count - 1
                shWorkSheet.Cells(5, i + 1) = ListView1.Columns(i).Text
                shWorkSheet.Cells(5, i + 1).font.bold = True
                'shWorkSheet.Columns.AutoFit() 
            Next

            For i = 0 To ListView1.Items.Count - 1
                For j = 0 To ListView1.Items(i).SubItems.Count - 1
                    If j = 1 Or j = 0 Then
                        shWorkSheet.Cells(i + 6, j + 1) = "'" + ListView1.Items(i).SubItems(j).Text
                    ElseIf j = 5 Or j = 6 Or j = 7 Then
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

End Class