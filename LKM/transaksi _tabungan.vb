Imports MySql.Data.MySqlClient

Public Class transaksi__tabungan
    Dim data_ke(99) As String

    Private Sub tno_rekening_LostFocus(sender As Object, e As EventArgs) Handles tno_rekening.LostFocus
        caritabungan()
    End Sub

    Private Sub tkode_transaksi_LostFocus(sender As Object, e As EventArgs) Handles tkode_transaksi.LostFocus
        caritransaksi()
        cektransaksi()
    End Sub

    Private Sub cmbtransaksi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtransaksi.SelectedIndexChanged
        tkode_transaksi.Text = cmbtransaksi.Text.ToString.Split(" :")(0)
        cektransaksi()
    End Sub

    Sub cektransaksi()
        Select Case cmbtransaksi.Text.ToString.Split(" :")(0)
            Case "01"
                tjumlah_setoran.Enabled = True
                tjumlah_penarikan.Enabled = False
                tnominal_bea.Enabled = False

                GroupBox2.Text = "Rekening Tabungan Tujuan"
                Label24.Text = "Rekening Tabungan :"
                Label25.Text = "Nama Nasabah :"

                tnomor_rekening.Clear()
                tnama_nasabah2.Clear()
                tnomor_rekening.Enabled = False
                Button2.Enabled = False
                cmbsumber_dana.Text = ""
                cmbsumber_dana.Enabled = True

                Label26.Visible = False
                tsaldo.Visible = False
                tsaldo.Clear()

            Case "02"
                tjumlah_setoran.Enabled = False
                tjumlah_penarikan.Enabled = True
                tnominal_bea.Enabled = False

                GroupBox2.Text = "Rekening Tabungan Tujuan"
                Label24.Text = "Rekening Tabungan :"
                Label25.Text = "Nama Nasabah :"

                tnomor_rekening.Clear()
                tnama_nasabah2.Clear()
                tnomor_rekening.Enabled = False
                Button2.Enabled = False
                cmbsumber_dana.Text = ""
                cmbsumber_dana.Enabled = False

                Label26.Visible = False
                tsaldo.Visible = False
                tsaldo.Clear()

            Case "03"
                tjumlah_setoran.Enabled = False
                tjumlah_penarikan.Enabled = True
                tnominal_bea.Enabled = False

                GroupBox2.Text = "Rekening Tabungan Tujuan"
                Label24.Text = "Rekening Tabungan :"
                Label25.Text = "Nama Nasabah :"

                tnomor_rekening.Clear()
                tnama_nasabah2.Clear()
                tnomor_rekening.Enabled = True
                Button2.Enabled = True
                cmbsumber_dana.Text = ""
                cmbsumber_dana.Enabled = False

                Label26.Visible = False
                tsaldo.Visible = False
                tsaldo.Clear()

            Case "04"
                tjumlah_setoran.Enabled = False
                tjumlah_penarikan.Enabled = False
                tnominal_bea.Enabled = True

                GroupBox2.Text = "Rekening Tabungan Tujuan"
                Label24.Text = "Rekening Tabungan :"
                Label25.Text = "Nama Nasabah :"

                tnomor_rekening.Clear()
                tnama_nasabah2.Clear()
                tnomor_rekening.Enabled = False
                Button2.Enabled = False
                cmbsumber_dana.Text = ""
                cmbsumber_dana.Enabled = False

                Label26.Visible = False
                tsaldo.Visible = False
                tsaldo.Clear()



            Case "05"
                tjumlah_setoran.Enabled = True
                tjumlah_penarikan.Enabled = False
                tnominal_bea.Enabled = False

                GroupBox2.Text = "Rekening Akuntansi"
                Label24.Text = "Kode Perkiraan :"
                Label25.Text = "Nama Perkiraan :"

                tnomor_rekening.Clear()
                tnama_nasabah2.Clear()
                tnomor_rekening.Enabled = True
                Button2.Enabled = True
                cmbsumber_dana.Text = ""
                cmbsumber_dana.Enabled = False

                Label26.Visible = True
                tsaldo.Visible = True
                tsaldo.Clear()

            Case "06"
                tjumlah_setoran.Enabled = False
                tjumlah_penarikan.Enabled = True
                tnominal_bea.Enabled = False

                GroupBox2.Text = "Rekening Akuntansi"
                Label24.Text = "Kode Perkiraan :"
                Label25.Text = "Nama Perkiraan :"

                tnomor_rekening.Clear()
                tnama_nasabah2.Clear()
                tnomor_rekening.Enabled = True
                Button2.Enabled = True
                cmbsumber_dana.Text = ""
                cmbsumber_dana.Enabled = False

                Label26.Visible = True
                tsaldo.Visible = True
                tsaldo.Clear()

            Case ""
                tjumlah_setoran.Enabled = False
                tjumlah_penarikan.Enabled = False
                tnominal_bea.Enabled = False

                GroupBox2.Text = "Rekening Tabungan Tujuan"
                Label24.Text = "Rekening Tabungan :"
                Label25.Text = "Nama Nasabah :"

                tnomor_rekening.Clear()
                tnama_nasabah2.Clear()
                tnomor_rekening.Enabled = False
                Button2.Enabled = False
                cmbsumber_dana.Text = ""
                cmbsumber_dana.Enabled = False

                Label26.Visible = True
                tsaldo.Visible = True
                tsaldo.Clear()
        End Select

        tjumlah_setoran.Clear()
        tjumlah_penarikan.Clear()
        tnominal_bea.Clear()
        tsaldo_akhir.Clear()
        tsumber_dana.Clear()
        tsumber_dana.Enabled = False

        cariadmpenutupan()
    End Sub

    Private Sub tpenyetor1_TextChanged(sender As Object, e As EventArgs) Handles tpenyetor1.TextChanged
        If Len(tpenyetor1.Text) > 0 Then
            tpenyetor2.Enabled = True
            tpenyetor3.Enabled = True
        Else
            tpenyetor2.Enabled = False
            tpenyetor3.Enabled = False
            tpenyetor2.Clear()
            tpenyetor3.Clear()
        End If
    End Sub

    Private Sub tjumlah_setoran_TextChanged(sender As Object, e As EventArgs) Handles tjumlah_setoran.TextChanged
        If tjumlah_setoran.Enabled = True Then
            penjumlahan()
        End If
    End Sub

    Private Sub tjumlah_penarikan_TextChanged(sender As Object, e As EventArgs) Handles tjumlah_penarikan.TextChanged
        If tjumlah_penarikan.Enabled = True Then
            penjumlahan()
        End If
    End Sub

    Private Sub tnominal_bea_TextChanged(sender As Object, e As EventArgs) Handles tnominal_bea.TextChanged
        If tnominal_bea.Enabled = True Then
            tjumlah_penarikan.Text = Val(Format(tsaldo_awal.Text, "General Number")) - Val(Format(tnominal_bea.Text, "General Number"))
        End If
    End Sub

    Private Sub tsaldo_akhir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tsaldo_akhir.KeyPress, tnominal_bea.KeyPress, tjumlah_penarikan.KeyPress, tsaldo_minimal.KeyPress, tjumlah_setoran.KeyPress, tsetoran_minimal.KeyPress, tsaldo_awal.KeyPress, tpenyetor3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tsaldo_akhir_TextChanged(sender As Object, e As EventArgs) Handles tsaldo_akhir.TextChanged, tnominal_bea.TextChanged, tjumlah_penarikan.TextChanged, tsaldo_minimal.TextChanged, tjumlah_setoran.TextChanged, tsetoran_minimal.TextChanged, tsaldo_awal.TextChanged, tsaldo_pembukaan.TextChanged
        Try
            sender.Text = FormatNumber(sender.Text, 0)
            sender.SelectionStart = Len(sender.Text)
        Catch ex As Exception
            sender.Text = "0"
        End Try
    End Sub

    Private Sub tnomor_rekening_LostFocus(sender As Object, e As EventArgs) Handles tnomor_rekening.LostFocus
        If Label24.Text = "Rekening Tabungan :" Then
            carirekening()
        Else
            cariperkiraan()
        End If
    End Sub

    Private Sub cmbsumber_dana_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbsumber_dana.KeyPress, cmbtransaksi.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbsumber_dana_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsumber_dana.SelectedIndexChanged
        If cmbsumber_dana.Text.ToString.Split(" :")(0) = "99" Then
            tsumber_dana.Enabled = True
        Else
            tsumber_dana.Enabled = False
            tsumber_dana.Clear()
        End If
    End Sub


    Private Sub tketerangan_GotFocus(sender As Object, e As EventArgs) Handles tketerangan.GotFocus, tsumber_dana.GotFocus, cmbsumber_dana.GotFocus, tnomor_rekening.GotFocus, tsaldo_akhir.GotFocus, tnominal_bea.GotFocus, tjumlah_penarikan.GotFocus, tsaldo_minimal.GotFocus, tjumlah_setoran.GotFocus, tsetoran_minimal.GotFocus, tsaldo_awal.GotFocus, tpenyetor3.GotFocus, tpenyetor2.GotFocus, tpenyetor1.GotFocus, tno_kuitansi.GotFocus, cmbtransaksi.GotFocus, tkode_transaksi.GotFocus, tno_rekening.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tketerangan_LostFocus(sender As Object, e As EventArgs) Handles tketerangan.LostFocus, tsumber_dana.LostFocus, cmbsumber_dana.LostFocus, tnomor_rekening.LostFocus, tsaldo_akhir.LostFocus, tnominal_bea.LostFocus, tjumlah_penarikan.LostFocus, tsaldo_minimal.LostFocus, tjumlah_setoran.LostFocus, tsetoran_minimal.LostFocus, tsaldo_awal.LostFocus, tpenyetor3.LostFocus, tpenyetor2.LostFocus, tpenyetor1.LostFocus, tno_kuitansi.LostFocus, cmbtransaksi.LostFocus, tkode_transaksi.LostFocus, tno_rekening.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub transaksi__tabungan_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tno_rekening.Focus()
    End Sub

    Private Sub transaksi__tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            btnvalidasi.PerformClick()
        ElseIf e.KeyCode = Keys.F6 Then
            btntambah.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub transaksi__tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        kosong()
        combo()
        Me.ResizeRedraw = True
    End Sub

    Private Sub transaksi__tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With pencarian_master_tabungan
            .Label4.Text = "cari rekening 1"
            .ShowDialog()
        End With
        If tnama_nasabah.Text = "" Then
            Button1.Focus()
        Else
            tkode_transaksi.Focus()
        End If
    End Sub
    Sub caritabungan()
        Try
            rd.Close()
        Catch ex As Exception

        End Try
        cd = New MySqlCommand("SELECT nasabah_nama1, nasabah_jenis_kelamin, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, nasabah_nik, nasabah_kota, nasabah_tanggal_lahir, rek_tab_kode_produk, tabungan_nama_produk, tabungan_saldo_pembukaan, rek_tab_setoran_minimal, rek_tab_saldo_minimal, nasabah_id, hitung_saldo_akhir_tabungan(rek_tab_no_rekening, '" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "') AS saldo FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id JOIN data_tabungan_produk ON rek_tab_kode_produk= tabungan_kode WHERE rek_tab_status IN ('0','1') AND rek_tab_no_rekening='" & tno_rekening.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_nasabah.Text = rd.Item("nasabah_nama1")
            If rd.Item("nasabah_jenis_kelamin") = "1" Then
                tjenis_kelamin.Text = "L"
            Else
                tjenis_kelamin.Text = "P"
            End If
            talamat.Text = rd.Item("nasabah_alamat") + ", " + rd.Item("nasabah_kelurahan") + ", " + rd.Item("nasabah_kecamatan")
            tno_ktp.Text = rd.Item("nasabah_nik")
            tttl.Text = rd.Item("nasabah_kota") + ", " + rd.Item("nasabah_tanggal_lahir")
            tkode_produk.Text = rd.Item("rek_tab_kode_produk")
            cmbproduk.Text = rd.Item("tabungan_nama_produk")
            tsaldo_pembukaan.Text = rd.Item("tabungan_saldo_pembukaan")
            tsetoran_minimal.Text = rd.Item("rek_tab_setoran_minimal")
            tsaldo_minimal.Text = rd.Item("rek_tab_saldo_minimal")
            tsaldo_awal.Text = rd.Item("saldo")
            Dim nsbh As String = rd.Item("nasabah_id")
            rd.Close()

            cd = New MySqlCommand("SELECT cari_buku_tabungan('" & tno_rekening.Text & "') AS buku_no", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            tno_buku.Text = rd.Item("buku_no")
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
            btncetak_buku.Enabled = True
        Catch ex As Exception
            tnama_nasabah.Clear()
            tjenis_kelamin.Clear()
            tno_buku.Clear()
            talamat.Clear()
            tno_ktp.Clear()
            tno_buku.Clear()
            tttl.Clear()
            tkode_produk.Clear()
            cmbproduk.Text = ""
            tsaldo_awal.Clear()
            tsaldo_pembukaan.Clear()
            tsetoran_minimal.Clear()
            tsaldo_minimal.Clear()
            PictureBox1.Image = Nothing
            btncetak_buku.Enabled = False
        End Try
        rd.Close()

        cd = New MySqlCommand("SELECT IFNULL(COUNT(*), 0) AS jml_transaksi FROM data_tabungan_transaksi WHERE trans_tab_no_rekening='" & tno_rekening.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Label23.Text = rd.Item("jml_transaksi")
        rd.Close()

        penjumlahan()
        cariadmpenutupan()
    End Sub

    Sub carirekening()
        rd.Close()
        cd = New MySqlCommand("SELECT nasabah_nama1 FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id WHERE rek_tab_status IN ('1') AND rek_tab_no_rekening='" & tnomor_rekening.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_nasabah2.Text = rd.Item("nasabah_nama1")
        Catch ex As Exception
            tnama_nasabah2.Clear()
        End Try
        rd.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateTimePicker1.Text = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy HH:mm:ss")
    End Sub
    Sub combo()
        cd = New MySqlCommand("CALL isi_combo('99')", koneksi)
        rd = cd.ExecuteReader
        With cmbtransaksi.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('83')", koneksi)
        rd = cd.ExecuteReader
        With cmbsumber_dana.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()
    End Sub
    Sub caritransaksi()
        rd.Close()
        cd = New MySqlCommand("SELECT cari_combo_komponen('99','" & tkode_transaksi.Text & "') AS transaksi", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbtransaksi.Text = rd.Item("transaksi")
        Catch ex As Exception
            cmbtransaksi.Text = ""
        End Try
        rd.Close()

        cariadmpenutupan()
    End Sub
    Sub cariadmpenutupan()
        rd.Close()
        If tkode_transaksi.Text = "04" Then
            cd = New MySqlCommand("SELECT tabungan_adm_penutupan FROM data_tabungan_produk WHERE tabungan_kode='" & tkode_produk.Text & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            Try
                tnominal_bea.Text = rd.Item("tabungan_adm_penutupan")
            Catch ex As Exception
                tnominal_bea.Text = "0"
            End Try
            rd.Close()
            tsaldo_akhir.Clear()
        End If
    End Sub
    Sub kosong()
        tno_rekening.Clear()
        caritabungan()
        tkode_transaksi.Clear()
        caritransaksi()
        tid_transaksi.Clear()
        tno_kuitansi.Clear()
        tpenyetor1.Clear()
        tsaldo_awal.Clear()
        tjumlah_setoran.Clear()
        tjumlah_penarikan.Clear()
        tnominal_bea.Clear()
        tsaldo_akhir.Clear()
        tsetoran_minimal.Clear()
        tsaldo_minimal.Clear()
        tnomor_rekening.Clear()
        tnama_nasabah2.Clear()
        tsaldo.Clear()
        cmbsumber_dana.Text = ""
        tsumber_dana.Clear()
        tketerangan.Clear()

        tsaldo_awal.Enabled = False
        tjumlah_setoran.Enabled = False
        tjumlah_penarikan.Enabled = False
        tnominal_bea.Enabled = False
        tsaldo_akhir.Enabled = False
        GroupBox2.Text = "Rekening Pemindahbukuan"
        Label24.Text = "Rekening Tabungan :"
        Label25.Text = "Nama Nasabah :"
        Label26.Visible = True
        tsaldo.Visible = True
        tsaldo.Clear()


        btnvalidasi.Enabled = True
        btntambah.Enabled = True
        btncetak_buku.Enabled = False
        btnkeluar.Enabled = True

        tno_rekening.Enabled = True
        Button1.Enabled = True
        tkode_transaksi.Enabled = True
        cmbtransaksi.Enabled = True
        tno_kuitansi.Enabled = True
        tpenyetor1.Enabled = True
        cmbsumber_dana.Enabled = True
        tketerangan.Enabled = True
        tnomor_rekening.Enabled = False
        Button2.Enabled = False
        Timer1.Enabled = True
        tno_rekening.Focus()
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        kosong()
        tno_rekening.Focus()
    End Sub

    Private Sub btnvalidasi_Click(sender As Object, e As EventArgs) Handles btnvalidasi.Click
        If tno_rekening.Text = "" Then
            MessageBox.Show("Nomor Rekening harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tno_rekening.Focus()
            Exit Sub
        ElseIf tkode_transaksi.Text = "" Then
            MessageBox.Show("Kode Transaksi harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_transaksi.Focus()
            Exit Sub
        ElseIf Len(tpenyetor1.Text) > 0 Then
            If tpenyetor2.Text = "" Then
                MessageBox.Show("Jika menggunakan kuasa, alamat penerima kuasa harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                tpenyetor2.Focus()
                Exit Sub
            ElseIf tpenyetor3.Text = "" Then
                MessageBox.Show("Jika menggunakan kuasa, No KTP/NIK penerima kuasa harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                tpenyetor3.Focus()
                Exit Sub
            End If
        ElseIf tjumlah_setoran.Text = "0" And tjumlah_setoran.Enabled = True Then
            MessageBox.Show("Jumlah setoran harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjumlah_setoran.Focus()
            Exit Sub
        ElseIf Val(Format(tjumlah_setoran.Text, "General Number")) < Val(Format(tsetoran_minimal.Text, "General Number")) And tjumlah_setoran.Enabled = True Then
            MessageBox.Show("Jumlah setoran kurang dari batas minimal.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjumlah_setoran.Focus()
            Exit Sub
        ElseIf Val(Format(tjumlah_setoran.Text, "General Number")) < Val(Format(tsaldo_pembukaan.Text, "General Number")) And tjumlah_setoran.Enabled = True And Label23.Text = "0" Then
            MessageBox.Show("Jumlah setoran kurang dari saldo pembukaan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjumlah_setoran.Focus()
            Exit Sub
        ElseIf tjumlah_penarikan.Text = "0" And tjumlah_penarikan.Enabled = True Then
            MessageBox.Show("Jumlah penarikan harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjumlah_penarikan.Focus()
            Exit Sub
        ElseIf Val(Format(tsaldo_minimal.Text, "General Number")) > Val(Format(tsaldo_akhir.Text, "General Number")) And tjumlah_penarikan.Enabled = True Then
            MessageBox.Show("Jumlah saldo akhir kurang dari saldo minimal mengendap.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tjumlah_penarikan.Focus()
            Exit Sub
        ElseIf tnominal_bea.Text = "0" And tnominal_bea.Enabled = True Then
            MessageBox.Show("Jumlah nominal bea harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnominal_bea.Focus()
            Exit Sub
        ElseIf tjumlah_penarikan.Text = "0" And tnominal_bea.Enabled = True Then
            MessageBox.Show("Jumlah penarikan tidak boleh nol.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnominal_bea.Focus()
            Exit Sub
        ElseIf Val(Format(tjumlah_penarikan.Text, "General Number")) < "0" And tnominal_bea.Enabled = True Then
            MessageBox.Show("Jumlah penarikan tidak boleh minus.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnominal_bea.Focus()
            Exit Sub
        ElseIf tnomor_rekening.Text = "" And tnomor_rekening.Enabled = True Then
            MessageBox.Show("Rekening tujuan harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnomor_rekening.Focus()
            Exit Sub
        ElseIf tkode_transaksi.Text = "05" And Label29.Text = "K" And Val(Format(tsaldo.Text, "General Number")) < Val(Format(tjumlah_setoran.Text, "General Number")) And tjumlah_setoran.Enabled = True Then
            MessageBox.Show("Saldo perkiraan tidak cukup.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnomor_rekening.Focus()
            Exit Sub
        ElseIf tkode_transaksi.Text = "06" And Label29.Text = "D" And Val(Format(tsaldo.Text, "General Number")) < Val(Format(tjumlah_penarikan.Text, "General Number")) And tjumlah_penarikan.Enabled = True Then
            MessageBox.Show("Saldo perkiraan tidak cukup.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnomor_rekening.Focus()
            Exit Sub
        ElseIf cmbsumber_dana.Text = "" And cmbsumber_dana.Enabled = True Then
            MessageBox.Show("Sumber dana harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbsumber_dana.Focus()
            Exit Sub
        ElseIf tsumber_dana.Text = "" And tsumber_dana.Enabled = True Then
            MessageBox.Show("Keterangan sumber dana harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tsumber_dana.Focus()
            Exit Sub
        ElseIf tketerangan.Enabled = True And tketerangan.Text = "" And (tkode_transaksi.Text = "05" Or tkode_transaksi.Text = "06") Then
            MessageBox.Show("Uraian/Keterangan harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tketerangan.Focus()
            Exit Sub
        ElseIf tno_rekening.Text = tnomor_rekening.Text And tnama_nasabah.Text = tnama_nasabah2.Text Then
            MessageBox.Show("Pemindahbukuan tidak bisa dilakukan di rekening yang sama.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnomor_rekening.Focus()
            Exit Sub
        End If
        rd.Close()

        cd = New MySqlCommand("SELECT * FROM data_tabungan_transaksi WHERE trans_tab_no_rekening='" & tno_rekening.Text & "' AND trans_tab_tanggal ='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True Then
            rd.Close()
            If MessageBox.Show("Transaksi atas nama nasabah ini sudah pernah dilakukan hari ini." + Chr(10) + "Anda yakin ingin melanjutkan transaksi?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                simpan()
            End If
        Else
            rd.Close()
            simpan()
        End If
    End Sub
    Sub penjumlahan()
        Dim na, nb, nc, nd As String
        na = Format(tsaldo_awal.Text, "General Number")
        nb = Format(tjumlah_setoran.Text, "General Number")
        nc = Format(tjumlah_penarikan.Text, "General Number")
        nd = Format(tnominal_bea.Text, "General Number")

        tsaldo_akhir.Text = Val(na) + Val(nb) - Val(nc) + Val(nd)
    End Sub

    Sub notransaksi()
        cd = New MySqlCommand("SELECT IFNULL(MAX(RIGHT(trans_tab_id_transaksi,5)), '0') AS trans FROM data_tabungan_transaksi WHERE trans_tab_tanggal='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' AND RIGHT(trans_tab_id_transaksi,1) <> 'R'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tid_transaksi.Text = tkode_transaksi.Text + "." + Format(DateTimePicker1.Value, "ddMMyyyy").ToString + "." + Microsoft.VisualBasic.Right("00000" & Microsoft.VisualBasic.Right(rd.Item("trans"), 5) + 1, 5)
        rd.Close()
    End Sub
    Sub simpan()
        Timer1.Enabled = False
        notransaksi()
        data_ke(0) = tid_transaksi.Text
        data_ke(1) = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        data_ke(2) = Format(DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        data_ke(3) = tno_rekening.Text
        data_ke(4) = tno_buku.Text
        data_ke(5) = tkode_transaksi.Text
        data_ke(6) = tno_kuitansi.Text
        data_ke(7) = tpenyetor1.Text
        data_ke(8) = tpenyetor2.Text
        data_ke(9) = tpenyetor3.Text
        data_ke(10) = Format(tjumlah_setoran.Text, "General Number")
        data_ke(11) = Format(tjumlah_penarikan.Text, "General Number")
        data_ke(12) = Format(tnominal_bea.Text, "General Number")
        data_ke(13) = tnomor_rekening.Text
        data_ke(14) = cmbsumber_dana.Text.ToString.Split(" :")(0)
        data_ke(15) = tsumber_dana.Text
        data_ke(16) = tketerangan.Text
        data_ke(17) = "1"
        data_ke(18) = MDIParent1.username.Text
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

        user_pengguna = MDIParent1.username.Text
        uraian = "Melakukan Transaksi Tabungan (trans_tab_id_transaksi : " + data_ke(0) + ")"
        insert_log_user()

        btnvalidasi.Enabled = False
        btntambah.Enabled = True
        btncetak_buku.Enabled = True
        btnkeluar.Enabled = True

        tno_rekening.Enabled = False
        Button1.Enabled = False
        tkode_transaksi.Enabled = False
        cmbtransaksi.Enabled = False
        tno_kuitansi.Enabled = False
        tpenyetor1.Enabled = False
        tpenyetor2.Enabled = False
        tpenyetor3.Enabled = False
        tjumlah_penarikan.Enabled = False
        tjumlah_setoran.Enabled = False
        tnominal_bea.Enabled = False
        cmbsumber_dana.Enabled = False
        tsumber_dana.Enabled = False
        tketerangan.Enabled = False
        tnomor_rekening.Enabled = False
        Button2.Enabled = False
        If MessageBox.Show("Cetak Validasi?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            'PrintDocument1.PrinterSettings.PrinterName = MDIParent1.pilihanprinter.Text
            cetakvalidasi()
        End If
        MessageBox.Show("Transaksi berhasil divalidasi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btncetak_buku_Click(sender As Object, e As EventArgs) Handles btncetak_buku.Click
        With statement_tabungan
            .tno_rekening.Text = tno_rekening.Text
            .caristatement()
            .ShowDialog()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Label24.Text = "Rekening Tabungan :" Then
            With pencarian_master_tabungan
                .Label4.Text = "cari rekening 2"
                .ShowDialog()
            End With
        Else
            With pencarian_perkiraan
                .Label4.Text = "transaksi_tabungan_kode_perkiraan"
                .ShowDialog()
            End With
        End If
        If tnama_nasabah2.Text <> "" Then
            If cmbsumber_dana.Enabled = True Then
                cmbsumber_dana.Focus()
            Else
                tketerangan.Focus()
            End If
        Else
            Button2.Focus()
        End If
    End Sub
    Sub cariperkiraan()
        cd = New MySqlCommand("SELECT perkiraan_nama, perkiraan_d_or_k, perkiraan_jurnal, hitung_saldo_perkiraan_akhir(perkiraan_kode,NOW()) AS saldo FROM kode_perkiraan WHERE perkiraan_kode='" & tnomor_rekening.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            If rd.Item("perkiraan_jurnal") = "1" Then
                tnama_nasabah2.Text = rd.Item("perkiraan_nama")
                Label29.Text = rd.Item("perkiraan_d_or_k")
                tsaldo.Text = FormatNumber(rd.Item("saldo"), 0)
            Else
                tnomor_rekening.Clear()
                tnama_nasabah2.Clear()
                tsaldo.Text = "0"
                MessageBox.Show("Kode Perkiraan tidak dapat dijurnal.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                tnomor_rekening.Focus()
            End If
        Catch ex As Exception
            tnomor_rekening.Clear()
            tnama_nasabah2.Clear()
            Label29.Text = "-"
            tsaldo.Text = "0"
        End Try
        rd.Close()
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


        cd = New MySqlCommand("SELECT trans_tab_id_transaksi, trans_tab_waktu, trans_tab_username, trans_tab_kode_transaksi, (trans_tab_jml_setoran + trans_tab_jml_penarikan) AS total, IF(trans_tab_kode_transaksi IN ('01','02','04'),' CASH ',' OVERBOOKING ') AS jns, trans_tab_nominal_bea, tab_stat_uraian, cari_teller(trans_tab_username) AS kode_teller FROM data_tabungan_statement JOIN data_tabungan_transaksi ON tab_stat_id_transaksi=trans_tab_id_transaksi WHERE tab_stat_id_transaksi='" & tid_transaksi.Text & "'", koneksi)
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

    Private Sub cmbproduk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbproduk.SelectedIndexChanged
        tkode_produk.Text = cmbproduk.Text.ToString.Split(" :")(0)
    End Sub

    Private Sub tnomor_rekening_TextChanged(sender As Object, e As EventArgs) Handles tnomor_rekening.TextChanged

    End Sub

    Private Sub tno_rekening_TextChanged(sender As Object, e As EventArgs) Handles tno_rekening.TextChanged

    End Sub
End Class