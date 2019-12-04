Imports MySql.Data.MySqlClient
Public Class statement_transaksi
    Dim list(99) As String

    Private Sub statement_transaksi_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub statement_transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ukuran()
        Me.ResizeRedraw = True
        tampil()
    End Sub

    Private Sub statement_transaksi_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Sub caristatement()
        Dim t1 As String = ""
        cd = New MySqlCommand("SELECT nasabah_nama1, kredit_nama_produk, rek_kre_plafon_induk, rek_kre_suku_bunga, rek_kre_tanggal_mulai, rek_kre_jangka_waktu, rek_kre_tanggal_jt, rek_kre_sistem_bunga, rek_kre_jenis_angsuran, hitung_total_tunggakan_pokok(rek_kre_no_rekening,NOW()) AS tgk_pokok, hitung_total_tunggakan_bunga(rek_kre_no_rekening,NOW()) AS tgk_bunga, hitung_frekuensi_tunggakan_pokok(rek_kre_no_rekening,NOW()) AS frek_pokok, hitung_frekuensi_tunggakan_bunga(rek_kre_no_rekening,NOW()) AS frek_bunga,  hitung_baki_debet(rek_kre_no_rekening,NOW()) AS bakidebet, cari_combo_komponen('21',rek_kre_sistem_bunga) AS sistembunga, IFNULL(hitung_kolek(rek_kre_no_rekening, (SELECT kre_stat_waktu FROM data_kredit_statement WHERE kre_stat_no_rekening = rek_kre_no_rekening AND kre_stat_waktu <=NOW() ORDER BY kre_stat_waktu DESC LIMIT 0,1)),'-') AS kolek FROM data_kredit_rekening JOIN data_nasabah ON rek_kre_nasabah_id=nasabah_id JOIN data_kredit_produk ON rek_kre_kode_produk=kredit_kode WHERE rek_kre_no_rekening='" & tno_rekening.Text & "' ", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tnama_nasabah.Text = rd.Item("nasabah_nama1")
        tskim_kredit.Text = rd.Item("kredit_nama_produk")
        tplafon.Text = FormatNumber(rd.Item("rek_kre_plafon_induk"), 0)
        tsuku_bunga.Text = FormatNumber(rd.Item("rek_kre_suku_bunga"), 3)
        DateTimePicker1.Value = Format(rd.Item("rek_kre_tanggal_mulai"), "dd-MM-yyyy")
        tjkw.Text = FormatNumber(rd.Item("rek_kre_jangka_waktu"), 0)
        DateTimePicker2.Value = Format(rd.Item("rek_kre_tanggal_jt"), "dd-MM-yyyy")
        Dim sisbung As String = rd.Item("rek_kre_sistem_bunga")
        Select Case rd.Item("rek_kre_jenis_angsuran")
            Case "1"
                Label16.Text = "hari"
            Case "2"
                Label16.Text = "minggu"
            Case "3"
                Label16.Text = "bulan"
            Case Else
                Label16.Text = ""
        End Select
        ttunggakan_pokok.Text = FormatNumber(rd.Item("tgk_pokok"), 0)
        ttunggakan_pokok2.Text = FormatNumber(rd.Item("frek_pokok"), 2)
        ttunggakan_bunga.Text = FormatNumber(rd.Item("tgk_bunga"), 0)
        ttunggakan_bunga2.Text = FormatNumber(rd.Item("frek_bunga"), 2)
        tbaki_debet.Text = FormatNumber(rd.Item("bakidebet"), 0)
        tsistem_bunga.Text = rd.Item("sistembunga")
        Label11.Text = rd.Item("kolek")
        rd.Close()

    End Sub
    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Tanggal", 100, HorizontalAlignment.Left)
            .Add("Kode", 50, HorizontalAlignment.Center)
            .Add("Uraian", 250, HorizontalAlignment.Left)
            .Add("Realisasi", 100, HorizontalAlignment.Right)
            .Add("Tagihan Pokok", 100, HorizontalAlignment.Right)
            .Add("Tagihan Bunga", 100, HorizontalAlignment.Right)
            .Add("Angs Pokok", 100, HorizontalAlignment.Right)
            .Add("Angs Bunga", 100, HorizontalAlignment.Right)
            .Add("Denda", 100, HorizontalAlignment.Right)
            .Add("Baki Debet", 100, HorizontalAlignment.Right)
            .Add("Kolek", 50, HorizontalAlignment.Center)
        End With
    End Sub
    Sub tampil()
        Dim bd As String = Format(tplafon.Text, "General Number")
        rd.Close()
        da = New MySqlDataAdapter("SELECT * FROM v_statement_kredit WHERE kre_stat_no_rekening='" & tno_rekening.Text & "' AND kre_stat_waktu<=IFNULL((SELECT angs_waktu FROM data_kredit_angsuran WHERE angs_no_rekening='" & tno_rekening.Text & "' AND angs_kode_transaksi IN ('106','107','109') limit 0,1), NOW())", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(Format(dt.Rows(i)("kre_stat_waktu"), "dd-MM-yyyy"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kre_stat_kode"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kre_stat_uraian"))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kre_stat_realisasi"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kre_stat_tag_pokok"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kre_stat_tag_bunga"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kre_stat_angs_pokok"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kre_stat_angs_bunga"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("kre_stat_denda"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("bakidebet"), 0))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("kolek"))
            Next
            If .Items.Count > 0 Then
                .Items.Add(Format(MDIParent1.DateTimePicker1.Value, "dd-MM-yyyy"))
                .Items(.Items.Count - 1).SubItems().Add("-")
                .Items(.Items.Count - 1).SubItems().Add("Saldo Akhir")
                .Items(.Items.Count - 1).SubItems().Add("0")
                .Items(.Items.Count - 1).SubItems().Add("0")
                .Items(.Items.Count - 1).SubItems().Add("0")
                .Items(.Items.Count - 1).SubItems().Add("0")
                .Items(.Items.Count - 1).SubItems().Add("0")
                .Items(.Items.Count - 1).SubItems().Add("0")
                .Items(.Items.Count - 1).SubItems().Add(.Items.Item(.Items.Count - 2).SubItems(9).Text)
                .Items(.Items.Count - 1).SubItems().Add("")
            End If
        End With
    End Sub

    Private Sub btnmodel1_Click(sender As Object, e As EventArgs) Handles btnmodel1.Click
        With laporan_statement_kredit_model1
            .TextBox1.Text = tno_rekening.Text
            .ShowDialog()
        End With

    End Sub

    Private Sub btnmodel2_Click(sender As Object, e As EventArgs) Handles btnmodel2.Click
        With laporan_statement_kredit_model2
            .TextBox1.Text = tno_rekening.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub Label11_TextChanged(sender As Object, e As EventArgs) Handles Label11.TextChanged
        Select Case Label11.Text
            Case "L"
                tkolek.Text = "L - LANCAR"
            Case "KL"
                tkolek.Text = "KL - KURANG LANCAR"
            Case "D"
                tkolek.Text = "D - DIRAGUKAN"
            Case "M"
                tkolek.Text = "M - MACET"
        End Select
    End Sub
End Class