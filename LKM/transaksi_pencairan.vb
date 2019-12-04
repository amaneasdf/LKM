Imports MySql.Data.MySqlClient
Public Class transaksi_pencairan

    Dim data_ke(99) As String

    Private Sub transaksi_pencairan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub transaksi_pencairan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        kosong()
        combo()
        Me.ResizeRedraw = True
    End Sub
    Sub combo()
        cd = New MySqlCommand("SELECT text AS jenistransaksi FROM v_combo_komponen WHERE combo_komponen='105'", koneksi)
        rd = cd.ExecuteReader
        With cmbkode_transaksi.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("jenistransaksi"))
            End While
        End With
        rd.Close()
    End Sub

    Private Sub tnomor_rekening_LostFocus(sender As Object, e As EventArgs) Handles tnomor_rekening.LostFocus
        carikredit()
    End Sub

    Private Sub tkode_transaksi_LostFocus(sender As Object, e As EventArgs) Handles tkode_transaksi.LostFocus
        caritransaksi()
    End Sub

    Private Sub cmbkode_transaksi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbkode_transaksi.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbkode_transaksi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbkode_transaksi.SelectedIndexChanged
        tkode_transaksi.Text = cmbkode_transaksi.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tjumlah_terima_TextChanged(sender As Object, e As EventArgs) Handles tjumlah_terima.TextChanged
        If Val(Format(tjumlah_terima.Text, "General Number")) < 0 Then
            tjumlah_terima.BackColor = Color.Pink
        Else
            tjumlah_terima.BackColor = Color.White
        End If
    End Sub

    Private Sub tlain_GotFocus(sender As Object, e As EventArgs) Handles tlain.GotFocus, tmaterai.GotFocus, tby_notaris.GotFocus, tby_premi.GotFocus, tadministrasi.GotFocus, tprovisi.GotFocus, tno_kuitansi.GotFocus, cmbkode_transaksi.GotFocus, tkode_transaksi.GotFocus, tnomor_rekening.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tlain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tlain.KeyPress, tmaterai.KeyPress, tby_notaris.KeyPress, tby_premi.KeyPress, tadministrasi.KeyPress, tprovisi.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tlain_LostFocus(sender As Object, e As EventArgs) Handles tlain.LostFocus, tmaterai.LostFocus, tby_notaris.LostFocus, tby_premi.LostFocus, tadministrasi.LostFocus, tprovisi.LostFocus, tno_kuitansi.LostFocus, cmbkode_transaksi.LostFocus, tkode_transaksi.LostFocus, tnomor_rekening.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub tlain_TextChanged(sender As Object, e As EventArgs) Handles tlain.TextChanged, tmaterai.TextChanged, tby_notaris.TextChanged, tby_premi.TextChanged, tadministrasi.TextChanged, tprovisi.TextChanged, tjml_pencairan.TextChanged
        rumus()
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub transaksi_pencairan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateTimePicker2.Text = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With pencarian_kredit
            .ShowDialog()
        End With
        If tnama_nasabah.Text = "" Then
            Button1.Focus()
        Else
            tkode_transaksi.Focus()
        End If
    End Sub
    Sub carikredit()
        rd.Close()
        tprovisi.Clear()
        tadministrasi.Clear()
        tby_premi.Clear()
        tby_notaris.Clear()
        tmaterai.Clear()
        tlain.Clear()
        cd = New MySqlCommand("SELECT nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, rek_kre_kode_produk, kredit_nama_produk, rek_kre_tanggal_mulai, rek_kre_jangka_waktu, rek_kre_jenis_angsuran, rek_kre_suku_bunga, rek_kre_sistem_bunga, rek_kre_plafon_induk, nasabah_id, rek_kre_provisi_rp, rek_kre_administrasi_rp, rek_kre_materai, rek_kre_asuransi, rek_kre_notaris, rek_kre_lain,  cari_combo_komponen('21',rek_kre_sistem_bunga) AS sistembunga FROM data_kredit_rekening JOIN data_nasabah ON rek_kre_nasabah_id=nasabah_id JOIN data_kredit_produk ON rek_kre_kode_produk=kredit_kode JOIN data_kredit_pelengkap ON rek_kre_no_rekening=pelengkap_no_rekening JOIN data_kredit_agunan ON rek_kre_no_rekening=agunan_no_rekening WHERE rek_kre_status='1' AND rek_kre_no_rekening='" & tnomor_rekening.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_nasabah.Text = rd.Item("nasabah_nama1")
            talamat.Text = rd.Item("nasabah_alamat") + ", " + rd.Item("nasabah_kelurahan") + ", " + rd.Item("nasabah_kecamatan")
            tkode_produk.Text = rd.Item("rek_kre_kode_produk")
            cmbkode_produk.Text = rd.Item("kredit_nama_produk")
            ttgl_mulai.Text = Format(rd.Item("rek_kre_tanggal_mulai"), "dd-MM-yyyy")
            tjangka_waktu.Text = rd.Item("rek_kre_jangka_waktu")
            Select Case rd.Item("rek_kre_jenis_angsuran")
                Case "1"
                    Label15.Text = "hari"
                Case "2"
                    Label15.Text = "minggu"
                Case Else
                    Label15.Text = "bulan"
            End Select
            tbunga.Text = FormatNumber(rd.Item("rek_kre_suku_bunga"), 3)
            tplafon_induk.Text = rd.Item("rek_kre_plafon_induk")
            tjml_pencairan.Text = rd.Item("rek_kre_plafon_induk")
            Dim nsbh As String = rd.Item("nasabah_id")
            tprovisi.Text = rd.Item("rek_kre_provisi_rp")
            tadministrasi.Text = rd.Item("rek_kre_administrasi_rp")
            tby_notaris.Text = rd.Item("rek_kre_notaris")
            tby_premi.Text = rd.Item("rek_kre_asuransi")
            tmaterai.Text = rd.Item("rek_kre_materai")
            tlain.Text = rd.Item("rek_kre_lain")
            cmbbunga.Text = rd.Item("sistembunga")
            rd.Close()

            Try
                cd = New MySqlCommand("SELECT * FROM data_nasabah_gambar WHERE gambar_nasabah_id='" & nsbh & "'", koneksi)
                rd = cd.ExecuteReader
                rd.Read()

                Dim arrImage() As Byte
                arrImage = rd.Item("gambar_file")
                Dim ms As New IO.MemoryStream(CType(arrImage, Byte()))

                rd.Close()
                PictureBox1.Image = Image.FromStream(ms)
            Catch ex As Exception
                PictureBox1.Image = Nothing
            End Try
        Catch ex As Exception
            tnama_nasabah.Clear()
            talamat.Clear()
            tkode_produk.Clear()
            cmbkode_produk.Text = ""
            ttgl_mulai.Clear()
            tjangka_waktu.Text = "0"
            tbunga.Text = "0,000"
            cmbbunga.Text = ""
            tplafon_induk.Clear()
            PictureBox1.Image = Nothing
            tjml_pencairan.Clear()

        End Try
        rd.Close()
    End Sub

    Private Sub tplafon_induk_TextChanged(sender As Object, e As EventArgs) Handles tplafon_induk.TextChanged, tlain.TextChanged, tmaterai.TextChanged, tby_notaris.TextChanged, tby_premi.TextChanged, tadministrasi.TextChanged, tprovisi.TextChanged, tjumlah_terima.TextChanged, tjml_pencairan.TextChanged
        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub
    Sub rumus()
        Dim n3, n4, n5, n7, n8, n9, n10 As String
        n3 = Format(tjml_pencairan.Text, "General Number")
        n4 = Format(tprovisi.Text, "General Number")
        n5 = Format(tadministrasi.Text, "General Number")
        n7 = Format(tby_premi.Text, "General Number")
        n8 = Format(tby_notaris.Text, "General Number")
        n9 = Format(tmaterai.Text, "General Number")
        n10 = Format(tlain.Text, "General Number")

        tjumlah_terima.Text = Val(n3) - (Val(n4) + Val(n5) + Val(n7) + Val(n8) + Val(n9) + Val(n10))
    End Sub
    Sub caritransaksi()
        rd.Close()
        Try
            cd = New MySqlCommand("SELECT cari_combo_komponen('105','" & tkode_transaksi.Text & "') AS transaksi", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            cmbkode_transaksi.Text = rd.Item("transaksi")
        Catch ex As Exception
            cmbkode_transaksi.Text = ""
        End Try
        rd.Close()
    End Sub

    Private Sub btnvalidasi_Click(sender As Object, e As EventArgs) Handles btnvalidasi.Click
        If tnomor_rekening.Text = "" Then
            MessageBox.Show("Nomor Rekening harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnomor_rekening.Focus()
            Exit Sub
        ElseIf tnama_nasabah.Text = "" And talamat.Text = "" And tkode_produk.Text = "" Then
            MessageBox.Show("Nomor Rekening tidak ditemukan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnomor_rekening.Focus()
            Exit Sub
        ElseIf cmbkode_transaksi.Text = "" Then
            MessageBox.Show("Kode Transaksi harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbkode_transaksi.Focus()
            Exit Sub
        ElseIf tjml_pencairan.Text = "0" Then
            MessageBox.Show("Jumlah Pencairan harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjml_pencairan.Focus()
            Exit Sub
        End If
        simpan()
    End Sub

    Sub notransaksi()
        cd = New MySqlCommand("SELECT IFNULL(MAX(RIGHT(pencairan_id_transaksi,5)), '0') AS trans FROM data_kredit_pencairan WHERE pencairan_tanggal='" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tid_transaksi.Text = tkode_transaksi.Text + "." + Format(DateTimePicker2.Value, "ddMMyyyy").ToString + "." + Microsoft.VisualBasic.Right("00000" & Microsoft.VisualBasic.Right(rd.Item("trans"), 5) + 1, 5)
        rd.Close()
    End Sub

    Sub kosong()
        tnomor_rekening.Clear()
        carikredit()
        tnomor_rekening.Enabled = True
        Button1.Enabled = True
        tid_transaksi.Clear()
        tkode_transaksi.Clear()
        cmbkode_transaksi.Text = ""
        tkode_transaksi.Enabled = True
        cmbkode_transaksi.Enabled = True
        tno_kuitansi.Clear()
        tno_kuitansi.Enabled = True
        Timer1.Enabled = True
        tplafon_induk.Clear()
        tjml_pencairan.Clear()
        tprovisi.Clear()
        tadministrasi.Clear()
        tby_premi.Clear()
        tby_notaris.Clear()
        tmaterai.Clear()
        tlain.Clear()
        tprovisi.Enabled = True
        tadministrasi.Enabled = True
        tby_premi.Enabled = True
        tby_notaris.Enabled = True
        tmaterai.Enabled = True
        tlain.Enabled = True
        PictureBox1.Image = Nothing
        btnvalidasi.Enabled = True
        tnomor_rekening.Focus()
    End Sub

    Sub simpan()
        notransaksi()
        data_ke(0) = tid_transaksi.Text
        data_ke(1) = Format(DateTimePicker2.Value, "yyyy-MM-dd")
        data_ke(2) = Format(DateTimePicker2.Value, "yyyy-MM-dd HH:mm:ss")
        data_ke(3) = tnomor_rekening.Text
        data_ke(4) = tkode_transaksi.Text
        data_ke(5) = tno_kuitansi.Text
        data_ke(6) = Format(tjml_pencairan.Text, "General Number")
        data_ke(7) = Format(tprovisi.Text, "General Number")
        data_ke(8) = Format(tadministrasi.Text, "General Number")
        data_ke(9) = Format(tby_premi.Text, "General Number")
        data_ke(10) = Format(tby_notaris.Text, "General Number")
        data_ke(11) = Format(tmaterai.Text, "General Number")
        data_ke(12) = Format(tlain.Text, "General Number")
        data_ke(13) = Format(tjumlah_terima.Text, "General Number")
        data_ke(14) = "1"
        data_ke(15) = MDIParent1.username.Text
        Dim gabung = ""
        For n = 0 To 15
            If n = 0 Then
                gabung += "'" + data_ke(n) + "'"
            Else
                gabung += ",'" + data_ke(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_kredit_pencairan VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Melakukan Transaksi Pencairan Kredit (pencairan_id_transaksi : " + data_ke(0) + ")"
        insert_log_user()

        tnomor_rekening.Enabled = False
        Button1.Enabled = False
        tno_kuitansi.Enabled = False
        tkode_transaksi.Enabled = False
        cmbkode_transaksi.Enabled = False
        Timer1.Enabled = False
        tprovisi.Enabled = False
        tadministrasi.Enabled = False
        tby_premi.Enabled = False
        tby_notaris.Enabled = False
        tmaterai.Enabled = False
        tlain.Enabled = False
        btnvalidasi.Enabled = False
        If MessageBox.Show("Cetak Validasi?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            cetakvalidasi()
        End If
        MessageBox.Show("Transaksi berhasil divalidasi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        cd = New MySqlCommand("SELECT pencairan_id_transaksi, pencairan_waktu, pencairan_username, pencairan_kode_transaksi, pencairan_jml_pencairan, pencairan_provisi, pencairan_administrasi, pencairan_premi, pencairan_notaris, pencairan_materai, pencairan_lain, cari_nama_rekening_kredit(pencairan_no_rekening) AS namanasabah, pencairan_no_rekening, cari_teller(pencairan_username) AS kode_teller FROM data_kredit_pencairan WHERE pencairan_id_transaksi='" & tid_transaksi.Text & "'", koneksi)
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

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kosong()
    End Sub
End Class