Imports MySql.Data.MySqlClient
Public Class Form3
    Dim list(5) As String
    Dim itemlist As ListViewItem

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Cetak Validasi?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            'PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
            cetakvalidasi()
        End If
    End Sub

    Sub cetakvalidasi()
        'MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        PrintDocument1.PrinterSettings.PrinterName = "Send To OneNote 2013"
        TextToPrint = ""
        'ukuran_font_cetak = 10
        ukuran_font_cetak = TextBox1.Text
        isivalidasi()
        Dim printControl = New Printing.StandardPrintController
        PrintDocument1.PrintController = printControl
        Try
            PrintDocument1.Print()
        Catch ex As Exception
            MessageBox.Show("Printer gagal", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Sub isivalidasi()
        Dim baris(99) As String

        cd = New MySqlCommand("SELECT trans_tab_id_transaksi, trans_tab_waktu, trans_tab_username, trans_tab_kode_transaksi, (trans_tab_jml_setoran + trans_tab_jml_penarikan) AS total, IF(trans_tab_kode_transaksi IN ('01','02','04'),' CASH ',' OVERBOOKING ') AS jns, trans_tab_nominal_bea, tab_stat_uraian, cari_teller(trans_tab_username) AS kode_teller FROM data_tabungan_statement JOIN data_tabungan_transaksi ON tab_stat_id_transaksi=trans_tab_id_transaksi WHERE tab_stat_id_transaksi='05.15052018.00001'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()

        baris(0) = rd.Item("trans_tab_id_transaksi") + " " + Format(rd.Item("trans_tab_waktu"), "dd/MM/yy HH:mm:ss").ToString + " [" + rd.Item("kode_teller") + "]"
        baris(1) = rd.Item("trans_tab_kode_transaksi").ToString + rd.Item("jns").ToString + "IDR " + FormatNumber(rd.Item("total"), 0) + " Adm " + FormatNumber(rd.Item("trans_tab_nominal_bea"), 0)
        baris(2) = ""
        baris(3) = rd.Item("trans_tab_id_transaksi") + " " + Format(rd.Item("trans_tab_waktu"), "dd/MM/yy HH:mm:ss").ToString + " [" + rd.Item("kode_teller") + "]"
        baris(4) = rd.Item("trans_tab_kode_transaksi").ToString + rd.Item("jns").ToString + "IDR " + FormatNumber(rd.Item("total"), 0) + " Adm " + FormatNumber(rd.Item("trans_tab_nominal_bea"), 0)
        baris(5) = rd.Item("trans_tab_id_transaksi") + " " + Format(rd.Item("trans_tab_waktu"), "dd/MM/yy HH:mm:ss").ToString + " [" + rd.Item("kode_teller") + "]"
        baris(6) = rd.Item("trans_tab_kode_transaksi").ToString + rd.Item("jns").ToString + "IDR " + FormatNumber(rd.Item("total"), 0) + " Adm " + FormatNumber(rd.Item("trans_tab_nominal_bea"), 0)
        
        rd.Close()

        For i = 0 To UBound(baris) ' UBound = batas atas array
            TextToPrint &= baris(i) & Environment.NewLine
        Next i

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi_localhost()
        koneksi.Open()

        ListView1.View = View.Details


        ListView1.Columns.Add("ID", 50, HorizontalAlignment.Left)
        ListView1.Columns.Add("Nama", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("Umur (th)", 70, HorizontalAlignment.Left)
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Static currentChar As Integer
        Dim textfont As Font = New Font("Lucida Console", ukuran_font_cetak, FontStyle.Regular)

        Dim h, w As Integer
        Dim left, top As Integer
        With PrintDocument1.DefaultPageSettings
            h = 0
            w = 0
            left = TextBox4.Text
            top = TextBox5.Text
        End With

        Dim lines As Integer = CInt(Math.Round(h / 1))
        Dim b As New Rectangle(left, top, w, h)
        Dim format As StringFormat
        format = New StringFormat(StringFormatFlags.LineLimit)
        Dim line, chars As Integer

        e.Graphics.MeasureString(Mid(TextToPrint, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(TextToPrint.Substring(currentChar, chars), New Font("Lucida Console", ukuran_font_cetak, FontStyle.Regular), Brushes.Black, b, format)

        currentChar = currentChar + chars
        If currentChar < TextToPrint.Length Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            currentChar = 0
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        list(0) = TextBox2.Text
        list(1) = TextBox3.Text
        list(2) = TextBox6.Text

        itemlist = New ListViewItem(list)
        ListView1.Items.Add(itemlist)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'ListView1.Items(i).SubItems(11).Text = "Simpan dan Valisdasi"
    End Sub
End Class