Imports System.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class laporan_statement_kredit_model2
    Private Sub laporan_statement_kredit_model2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub laporan_statement_kredit_model2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Private Sub laporan_statement_kredit_model2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent
        Report()
    End Sub

    Public Sub report()
        da = New MySqlDataAdapter()
        ds = New DATASET
        da.SelectCommand = New MySqlCommand("SELECT * FROM v_statement_kredit WHERE kre_stat_no_rekening='" & TextBox1.Text & "'", koneksi)
        da.Fill(ds.Tables("statement_kredit"))

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("statement_kredit")))

        cd = New MySqlCommand("SELECT * FROM data_kantor", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim nama_lembaga As String = rd.Item("kantor_nama_lembaga")
        Dim alamat_lembaga As String = rd.Item("kantor_alamat")
        rd.Close()

        Dim ket(99), nama(99) As String
        ket(0) = "kredit_laporan_pembuat"
        ket(1) = "kredit_laporan_pemeriksa"
        ket(2) = "kredit_laporan_pengesah"
        For i = 0 To 2
            cd = New MySqlCommand("SELECT cari_nama_petugas_pelaporan('" & ket(i) & "') AS nama", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            nama(i) = rd.Item("nama")
            rd.Close()
        Next

        Dim param(25) As ReportParameter
        param(0) = New ReportParameter("alamat_lembaga", alamat_lembaga)
        param(1) = New ReportParameter("nama_lembaga", nama_lembaga)
        param(2) = New ReportParameter("tanggal", "Periode " + Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy"))
        param(3) = New ReportParameter("dibuat", nama(0))
        param(4) = New ReportParameter("diperiksa", nama(1))
        param(5) = New ReportParameter("disahkan", nama(2))
        param(6) = New ReportParameter("waktu", Format(MDIParent1.DateTimePicker1.Value, "dd/MM/yyyy HH:mm:ss"))
        With statement_transaksi
            param(7) = New ReportParameter("no_rekening", .tno_rekening.Text)
            param(8) = New ReportParameter("plafon_akad", .tplafon.Text)
            param(9) = New ReportParameter("suku_bunga", .tsuku_bunga.Text + " %")
            param(10) = New ReportParameter("sistem_bunga", .tsistem_bunga.Text)
            param(11) = New ReportParameter("skim_jenis_kredit", .tskim_kredit.Text)
            param(12) = New ReportParameter("kolek", .tkolek.Text + " ")
            param(13) = New ReportParameter("tgk_pokok", .ttunggakan_pokok.Text + " (" + .ttunggakan_pokok2.Text + ")")
            param(14) = New ReportParameter("tgk_bunga", .ttunggakan_bunga.Text + " (" + .ttunggakan_bunga2.Text + ")")
            param(15) = New ReportParameter("periode_pinjaman", Format(.DateTimePicker1.Value, "dd MMM yyyy") + " | " + .tjkw.Text + " | " + Format(.DateTimePicker2.Value, "dd MMM yyyy"))

            cd = New MySqlCommand("SELECT nasabah_id, nasabah_nama1, rek_kre_nasabah_id, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, nasabah_mobile, nasabah_nik, rek_kre_akad_awal, rek_kre_tanggal1 FROM data_nasabah JOIN data_kredit_rekening ON rek_kre_nasabah_id=nasabah_id WHERE rek_kre_no_rekening='" & .tno_rekening.Text & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            Dim nasabah_id As String = rd.Item("nasabah_id")
            Dim nama_nasabah As String = rd.Item("nasabah_nama1")
            Dim alamat As String = rd.Item("nasabah_alamat") + ", " + rd.Item("nasabah_kelurahan") + ", " + rd.Item("nasabah_kecamatan")
            Dim no_hp As String = rd.Item("nasabah_mobile") + " "
            Dim no_ktp As String = rd.Item("nasabah_nik")
            Dim no_akad_awal As String = rd.Item("rek_kre_akad_awal") + ", Tgl " + Format(rd.Item("rek_kre_tanggal1"), "dd-MM-yyyy")
            param(16) = New ReportParameter("nasabah_id", nasabah_id)
            param(17) = New ReportParameter("nama_nasabah", nama_nasabah)
            param(18) = New ReportParameter("alamat_nasabah", alamat)
            param(19) = New ReportParameter("no_hp", no_hp)
            param(20) = New ReportParameter("no_ktp", no_ktp)
            param(21) = New ReportParameter("no_tgl_akad", no_akad_awal)
            rd.Close()

            cd = New MySqlCommand("SELECT kolektor_nama FROM data_kredit_pelengkap JOIN data_kolektor ON pelengkap_kolektor=kolektor_kode WHERE pelengkap_no_rekening='" & .tno_rekening.Text & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            Dim kolektor As String
            Try
                kolektor = rd.Item("kolektor_nama")
            Catch ex As Exception
                kolektor = " "
            End Try
            param(22) = New ReportParameter("kolektor", kolektor)
            rd.Close()

            cd = New MySqlCommand("SELECT agunan_keterangan, agunan_nilai_jaminan FROM data_kredit_agunan WHERE agunan_no_rekening='" & .tno_rekening.Text & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            Dim agunan As String = rd.Item("agunan_keterangan") + " Nilai : Rp " + FormatNumber(rd.Item("agunan_nilai_jaminan"), 0)
            rd.Close()

            param(23) = New ReportParameter("agunan", agunan)

            cd = New MySqlCommand("SELECT hitung_denda('" & .tno_rekening.Text & "', NOW()) AS denda", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            Dim denda As String = FormatNumber(rd.Item("denda"), 0)
            rd.Close()

            param(24) = New ReportParameter("denda", denda)

            cd = New MySqlCommand("SELECT IFNULL(SUM(kre_stat_tag_bunga), 0) AS sisa_bunga FROM data_kredit_statement WHERE kre_stat_no_rekening='" & .tno_rekening.Text & "' AND kre_stat_waktu>NOW()", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            Dim sisa_bunga As String = FormatNumber(rd.Item("sisa_bunga"), 0)
            rd.Close()

            param(25) = New ReportParameter("sisa_bunga", sisa_bunga)

        End With
        Me.ReportViewer1.LocalReport.SetParameters(param)
        'koneksi.Close()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class