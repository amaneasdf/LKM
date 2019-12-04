Imports MySql.Data.MySqlClient
Public Class transaksi_jurnal_non_kas
    Dim data_ke(99) As String
   
    Private Sub tketerangan_GotFocus(sender As Object, e As EventArgs) Handles tketerangan.GotFocus, tkode_perkiraan_k.GotFocus, tkode_perkiraan_d.GotFocus, tjumlah.GotFocus, tno_kuitansi.GotFocus, cmbkode_transaksi.GotFocus, tkode_transaksi.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbkode_transaksi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbkode_transaksi.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub tjumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tjumlah.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tketerangan_LostFocus(sender As Object, e As EventArgs) Handles tketerangan.LostFocus, tkode_perkiraan_k.LostFocus, tkode_perkiraan_d.LostFocus, tjumlah.LostFocus, tno_kuitansi.LostFocus, cmbkode_transaksi.LostFocus, tkode_transaksi.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub transaksi_jurnal_non_kas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub transaksi_jurnal_non_kas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            btnvalidasi.PerformClick()
        ElseIf e.KeyCode = Keys.F7 Then
            btntambah.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub transaksi_jurnal_non_kas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        combo()
        kosong()
    End Sub
    Sub combo()
        With cmbkode_transaksi.Items
            .Clear()
            .Add("11 : JURNAL UMUM")
            '.Add("12 : JURNAL KOREKSI")
            '.Add("13 : KOREKSI REK. ADMINISTRATIF")
        End With
    End Sub
    Sub kosong()
        tid_transaksi.Clear()
        tkode_transaksi.Clear()
        cmbkode_transaksi.Text = ""
        tno_kuitansi.Clear()
        tjumlah.Clear()
        tkode_perkiraan_d.Clear()
        cariperkiraandebet()
        tkode_perkiraan_k.Clear()
        cariperkiraankredit()
        tketerangan.Clear()

        Timer1.Enabled = True
        tkode_transaksi.Enabled = True
        cmbkode_transaksi.Enabled = True
        tno_kuitansi.Enabled = True
        tjumlah.Enabled = True
        tkode_perkiraan_d.Enabled = True
        Button1.Enabled = True
        tkode_perkiraan_k.Enabled = True
        Button2.Enabled = True
        tketerangan.Enabled = True
        btnvalidasi.Enabled = True
        tkode_transaksi.Focus()
    End Sub
    Private Sub tkode_transaksi_LostFocus(sender As Object, e As EventArgs) Handles tkode_transaksi.LostFocus
        carijenistransaksi()
    End Sub

    Sub carijenistransaksi()
        Select Case tkode_transaksi.Text
            Case "11"
                cmbkode_transaksi.Text = "11 : JURNAL UMUM"
                'Case "12"
                '   cmbkode_transaksi.Text = "12 : JURNAL KOREKSI"
                'Case "13"
                '   cmbkode_transaksi.Text = "13 : KOREKSI REK. ADMINISTRATIF"
            Case Else
                cmbkode_transaksi.Text = ""
        End Select
    End Sub

    Private Sub transaksi_jurnal_non_kas_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbkode_transaksi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbkode_transaksi.SelectedIndexChanged
        tkode_transaksi.Text = cmbkode_transaksi.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tjumlah_TextChanged(sender As Object, e As EventArgs) Handles tjumlah.TextChanged
        Try
            tjumlah.Text = FormatNumber(tjumlah.Text, 0)
            tjumlah.SelectionStart = Len(tjumlah.Text)
        Catch ex As Exception
            tjumlah.Text = "0"
        End Try
        hitung1()
        hitung2()
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateTimePicker1.Text = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With pencarian_perkiraan
            .Label4.Text = "transaksi_jurnal_nonkas_debet"
            .ShowDialog()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With pencarian_perkiraan
            .Label4.Text = "transaksi_jurnal_nonkas_kredit"
            .ShowDialog()
        End With
    End Sub
    Sub cariperkiraandebet()
        cd = New MySqlCommand("SELECT perkiraan_kode, perkiraan_nama, perkiraan_d_or_k, perkiraan_minus, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "') AS saldo_akhir FROM kode_perkiraan WHERE perkiraan_kode='" & tkode_perkiraan_d.Text & "' AND perkiraan_jurnal='1'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_perkiraan_d.Text = rd.Item("perkiraan_nama")
            TextBox1.Text = rd.Item("perkiraan_d_or_k")
            TextBox3.Text = rd.Item("perkiraan_minus")
            tsaldo1_d.Text = FormatNumber(rd.Item("saldo_akhir") * rd.Item("perkiraan_minus"), 0)
        Catch ex As Exception
            'MsgBox(ex.Message)
            tnama_perkiraan_d.Clear()
            TextBox1.Clear()
            TextBox3.Text = "1"
            tsaldo1_d.Text = "0"
        End Try
        rd.Close()
        hitung1()
    End Sub

    Sub cariperkiraankredit()
        cd = New MySqlCommand("SELECT perkiraan_kode, perkiraan_nama, perkiraan_d_or_k, perkiraan_minus, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "') AS saldo_akhir FROM kode_perkiraan WHERE perkiraan_kode='" & tkode_perkiraan_k.Text & "' AND perkiraan_jurnal='1'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_perkiraan_k.Text = rd.Item("perkiraan_nama")
            TextBox2.Text = rd.Item("perkiraan_d_or_k")
            TextBox4.Text = rd.Item("perkiraan_minus")
            tsaldo1_k.Text = FormatNumber(rd.Item("saldo_akhir") * rd.Item("perkiraan_minus"), 0)
        Catch ex As Exception
            tnama_perkiraan_k.Clear()
            TextBox2.Clear()
            TextBox4.Text = "1"
            tsaldo1_k.Text = "0"
        End Try
        rd.Close()
        hitung2()
    End Sub

    Sub hitung1()
        If tnama_perkiraan_d.Text <> "" And TextBox1.Text <> "" Then
            If TextBox1.Text = "D" Then
                tsaldo2_d.Text = FormatNumber(Val(Format(tsaldo1_d.Text, "General Number")) + Val(Format(tjumlah.Text, "General Number") * Val(TextBox3.Text)), 0)
            Else
                tsaldo2_d.Text = FormatNumber(Val(Format(tsaldo1_d.Text, "General Number")) - Val(Format(tjumlah.Text, "General Number") * Val(TextBox3.Text)), 0)
            End If
        Else
            tsaldo2_d.Text = "0"
        End If
    End Sub

    Sub hitung2()
        If tnama_perkiraan_k.Text <> "" And TextBox2.Text <> "" Then
            If TextBox2.Text = "K" Then
                tsaldo2_k.Text = FormatNumber(Val(Format(tsaldo1_k.Text, "General Number")) + Val(Format(tjumlah.Text, "General Number") * Val(TextBox4.Text)), 0)
            Else
                tsaldo2_k.Text = FormatNumber(Val(Format(tsaldo1_k.Text, "General Number")) - Val(Format(tjumlah.Text, "General Number") * Val(TextBox4.Text)), 0)
            End If
        Else
            tsaldo2_k.Text = "0"
        End If
    End Sub
    Private Sub tkode_perkiraan_d_LostFocus(sender As Object, e As EventArgs) Handles tkode_perkiraan_d.LostFocus
        cariperkiraandebet()
    End Sub
    Private Sub tkode_perkiraan_k_LostFocus(sender As Object, e As EventArgs) Handles tkode_perkiraan_k.LostFocus
        cariperkiraankredit()
    End Sub

    Sub notransaksi()
        cd = New MySqlCommand("SELECT IFNULL(MAX(RIGHT(nonkas_id_transaksi,5)), '0') AS trans FROM data_akuntansi_transaksi_nonkas WHERE nonkas_tanggal='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tid_transaksi.Text = tkode_transaksi.Text + "." + Format(DateTimePicker1.Value, "ddMMyyyy").ToString + "." + Microsoft.VisualBasic.Right("00000" & Microsoft.VisualBasic.Right(rd.Item("trans"), 5) + 1, 5)
        rd.Close()
    End Sub
    Sub simpan()
        notransaksi()
        data_ke(0) = tid_transaksi.Text
        data_ke(1) = cmbkode_transaksi.Text.ToString.Split(" :")(0)
        data_ke(2) = tno_kuitansi.Text
        data_ke(3) = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        data_ke(4) = Format(DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        data_ke(5) = Format(tjumlah.Text, "General Number")
        data_ke(6) = tkode_perkiraan_d.Text
        data_ke(7) = tkode_perkiraan_k.Text
        data_ke(8) = tketerangan.Text
        data_ke(9) = "1"
        data_ke(10) = MDIParent1.username.Text
        Dim gabung = ""
        For n = 0 To 10
            If n = 0 Then
                gabung += "'" + data_ke(n) + "'"
            Else
                gabung += ",'" + data_ke(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_akuntansi_transaksi_nonkas VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Melakukan Transaksi Jurnal Non Kas (nonkas_id_transaksi : " + data_ke(0) + ")"
        insert_log_user()

        Timer1.Enabled = False
        tkode_transaksi.Enabled = False
        cmbkode_transaksi.Enabled = False
        tno_kuitansi.Enabled = False
        tjumlah.Enabled = False
        tkode_perkiraan_d.Enabled = False
        Button1.Enabled = False
        tkode_perkiraan_k.Enabled = False
        Button2.Enabled = False
        tketerangan.Enabled = False
        btnvalidasi.Enabled = False
        If MessageBox.Show("Cetak Validasi?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cetakvalidasi()
        End If
        MessageBox.Show("Transaksi berhasil divalidasi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        btntambah.Focus()
    End Sub

    Private Sub btnvalidasi_Click(sender As Object, e As EventArgs) Handles btnvalidasi.Click
        If cmbkode_transaksi.Text = "" Then
            MessageBox.Show("Jenis transaksi harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbkode_transaksi.Focus()
            Exit Sub
        ElseIf tjumlah.Text = "0" Then
            MessageBox.Show("Jumlah transaksi harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjumlah.Focus()
            Exit Sub
        ElseIf tkode_perkiraan_d.Text = "" And tnama_perkiraan_d.Text = "" And TextBox1.Text = "" Then
            MessageBox.Show("Kode perkiraan Debet harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_perkiraan_d.Focus()
            Exit Sub
        ElseIf tkode_perkiraan_k.Text = "" And tnama_perkiraan_k.Text = "" And TextBox2.Text = "" Then
            MessageBox.Show("Kode perkiraan Kredit harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_perkiraan_k.Focus()
            Exit Sub
        ElseIf tkode_perkiraan_d.Text <> "" And tnama_perkiraan_d.Text = "" And TextBox1.Text = "" Then
            MessageBox.Show("Kode perkiraan Debet tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_perkiraan_d.Focus()
            Exit Sub
        ElseIf tkode_perkiraan_k.Text <> "" And tnama_perkiraan_k.Text = "" And TextBox2.Text = "" Then
            MessageBox.Show("Kode perkiraan Kredit tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_perkiraan_k.Focus()
            Exit Sub
        ElseIf tketerangan.Text = "" Then
            MessageBox.Show("Keterangan transaksi harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tketerangan.Focus()
            Exit Sub
        ElseIf Val(Replace(tsaldo2_d.Text, ".", "")) < 0 Then
            MessageBox.Show("Saldo akhir perkiraan Debet (" + tkode_perkiraan_d.Text + " " + tnama_perkiraan_d.Text + ") minus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_perkiraan_d.Focus()
            Exit Sub
        ElseIf Val(Replace(tsaldo2_k.Text, ".", "")) < 0 Then
            MessageBox.Show("Saldo akhir perkiraan Kredit (" + tkode_perkiraan_k.Text + " " + tnama_perkiraan_k.Text + ") minus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_perkiraan_k.Focus()
            Exit Sub
        End If
        simpan()
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kosong()
    End Sub

    Sub cetakvalidasi()
        Dim ukuran(99) As String
        Dim cetakan As String = ""
        MDIParent1.PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
        TextToPrint = ""

        For ii As Integer = 1 To 3
            If ii = 1 Then
                cetakan = "KiriVNonKas"
            ElseIf ii = 2 Then
                cetakan = "AtasVNonKas"
            ElseIf ii = 3 Then
                cetakan = "FontVNonKas"
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

        cd = New MySqlCommand("SELECT nonkas_id_transaksi, nonkas_waktu, nonkas_username, nonkas_kode_transaksi, nonkas_jumlah, nonkas_perkiraan_debet, nonkas_perkiraan_kredit, cari_teller(nonkas_username) AS kode_teller FROM data_akuntansi_transaksi_nonkas WHERE nonkas_id_transaksi='" & tid_transaksi.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()

        baris(0) = rd.Item("nonkas_id_transaksi") + " " + Format(rd.Item("nonkas_waktu"), "dd/MM/yy HH:mm:ss").ToString + " [" + rd.Item("kode_teller") + "]"
        baris(1) = rd.Item("nonkas_kode_transaksi").ToString + " OVERBOOKING IDR " + FormatNumber(rd.Item("nonkas_jumlah"), 0)
        baris(2) = "D " + rd.Item("nonkas_perkiraan_debet").ToString + ",  K " + rd.Item("nonkas_perkiraan_kredit").ToString

        rd.Close()

        For i = 0 To UBound(baris) ' UBound = batas atas array
            TextToPrint &= baris(i) & Environment.NewLine
        Next i

    End Sub

    Private Sub tkode_perkiraan_d_TextChanged(sender As Object, e As EventArgs) Handles tkode_perkiraan_d.TextChanged

    End Sub
End Class