Imports System.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class laporan_jadual_angsuran

    Private Sub laporan_jadual_angsuran_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub laporan_jadual_angsuran_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub laporan_jadual_angsuran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent
        report()
    End Sub

    Public Sub report()
        da = New MySqlDataAdapter()
        ds = New DATASET
        da.SelectCommand = New MySqlCommand("SELECT * FROM temp_jadual_angsuran WHERE temp_username='" & MDIParent1.username.Text & "' AND temp_no_rekening='" & jadual_angsuran.tno_rekening.Text & "' ORDER BY temp_tanggal_tagihan", koneksi)
        da.Fill(ds.Tables("temp_jadual"))

        '
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("temp_jadual")))

        cd = New MySqlCommand("SELECT * FROM data_kantor", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim nama_lembaga As String = rd.Item("kantor_nama_lembaga")
        Dim alamat_lembaga As String = rd.Item("kantor_alamat")
        rd.Close()

        Dim data(99) As String

        Dim param(12) As ReportParameter
        param(0) = New ReportParameter("alamat_lembaga", alamat_lembaga)
        param(1) = New ReportParameter("nama_lembaga", nama_lembaga)
        param(2) = New ReportParameter("waktu", Format(MDIParent1.DateTimePicker1.Value, "dd/MM/yyyy HH:mm:ss"))

        cd = New MySqlCommand("SELECT rek_kre_no_rekening, rek_kre_akad_awal, nasabah_nama1, nasabah_alamat, rek_kre_plafon_induk, rek_kre_suku_bunga, rek_kre_tanggal_mulai, rek_kre_tanggal_jt FROM data_kredit_rekening JOIN data_nasabah ON rek_kre_nasabah_id=nasabah_id WHERE rek_kre_no_rekening='" & TextBox1.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        data(0) = rd.Item("rek_kre_no_rekening")
        data(1) = rd.Item("rek_kre_akad_awal")
        data(2) = rd.Item("nasabah_nama1")
        data(3) = rd.Item("nasabah_alamat")
        data(4) = FormatNumber(rd.Item("rek_kre_plafon_induk"), 0)
        data(5) = FormatNumber(rd.Item("rek_kre_suku_bunga"), 2)
        data(6) = Format(rd.Item("rek_kre_tanggal_mulai"), "dd MMM yyyy")
        data(7) = Format(rd.Item("rek_kre_tanggal_jt"), "dd MMMM yyyy")
        rd.Close()

        param(3) = New ReportParameter("no_rekening", data(0))
        param(4) = New ReportParameter("no_akad", data(1))
        param(5) = New ReportParameter("nama_nasabah", data(2))
        param(6) = New ReportParameter("alamat_nasabah", data(3))
        param(7) = New ReportParameter("plafon_kredit", data(4))
        param(8) = New ReportParameter("suku_bunga", data(5))
        param(9) = New ReportParameter("mulai_dari", data(6))
        param(10) = New ReportParameter("sampai_dengan", data(7))

        cd = New MySqlCommand("SELECT SUM(kre_stat_tag_bunga) AS total_bunga, SUM(kre_stat_tag_bunga + kre_stat_tag_pokok) AS total_hutang FROM data_kredit_statement WHERE kre_stat_no_rekening='" & TextBox1.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        data(8) = FormatNumber(rd.Item("total_bunga"), 0)
        data(9) = FormatNumber(rd.Item("total_hutang"), 0)
        rd.Close()
        param(11) = New ReportParameter("jumlah_bunga", data(8))
        param(12) = New ReportParameter("total_hutang", data(9))


        Me.ReportViewer1.LocalReport.SetParameters(param)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class