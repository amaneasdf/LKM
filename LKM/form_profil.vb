Imports System.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class form_profil

    Private Sub form_profil_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub form_profil_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Private Sub form_profil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent
        report()
    End Sub
    Public Sub report()
        da = New MySqlDataAdapter()
        ds = New DATASET

        da.SelectCommand = New MySqlCommand("SELECT * FROM v_profil_nasabah_tabungan WHERE rek_tab_nasabah_id='" & TextBox1.Text & "'", koneksi)
        da.Fill(ds.Tables("profil_nasabah_tabungan"))

        da.SelectCommand = New MySqlCommand("SELECT * FROM v_profil_nasabah_kredit WHERE rek_kre_nasabah_id='" & TextBox1.Text & "'", koneksi)
        da.Fill(ds.Tables("profil_nasabah_kredit"))
        

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        'ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Report1.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("profil_nasabah_tabungan")))
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", ds.Tables("profil_nasabah_kredit")))
        
        cd = New MySqlCommand("SELECT nasabah_nama1, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan, nasabah_nik, nasabah_npwp, nasabah_keterangan_pekerjaan, nasabah_alamat_bekerja, (SELECT combo_text FROM v_combo_komponen WHERE combo_komponen='08' AND combo_kode=nasabah_pekerjaan) AS pekerjaan, (SELECT IFNULL(SUM(saldo_efektif),0) FROM v_profil_nasabah_tabungan WHERE rek_tab_nasabah_id=nasabah_id) AS tot_simp, (SELECT IFNULL(SUM(hitung_baki_debet(rek_kre_no_rekening,curdate())),0) FROM data_kredit_rekening WHERE rek_kre_nasabah_id=nasabah_id) AS tot_pinj FROM data_nasabah WHERE nasabah_id='" & TextBox1.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim nama1 As String = rd.Item("nasabah_nama1") + " "
        Dim alamat As String = rd.Item("nasabah_alamat") + ", " + rd.Item("nasabah_kelurahan") + ", " + rd.Item("nasabah_kecamatan") + " "
        Dim nik As String = rd.Item("nasabah_nik") + " "
        Dim npwp As String = rd.Item("nasabah_npwp") + " "
        Dim pekerjaan As String = rd.Item("pekerjaan") + " "
        Dim tempat_pekerjaan As String = rd.Item("nasabah_keterangan_pekerjaan") + ", " + rd.Item("nasabah_alamat_bekerja")
        Dim total_simpanan As String = "Rp " + FormatNumber(rd.Item("tot_simp"), 0)
        Dim total_pinjaman As String = "Rp " + FormatNumber(rd.Item("tot_pinj"), 0)
        rd.Close()

        cd = New MySqlCommand("SELECT * FROM data_kantor", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim nama_lembaga As String = rd.Item("kantor_nama_lembaga")
        Dim kota As String = rd.Item("kantor_kota")
        rd.Close()

        Dim param(10) As ReportParameter
        param(0) = New ReportParameter("nasabah_id", TextBox1.Text)
        param(1) = New ReportParameter("nama_nasabah", nama1)
        param(2) = New ReportParameter("alamat_nasabah", alamat)
        param(3) = New ReportParameter("no_ktp", nik)
        param(4) = New ReportParameter("no_npwp", npwp)
        param(5) = New ReportParameter("pekerjaan", pekerjaan)
        param(6) = New ReportParameter("tempat_pekerjaan", tempat_pekerjaan)
        param(7) = New ReportParameter("total_simpanan", total_simpanan)
        param(8) = New ReportParameter("total_pinjaman", total_pinjaman)
        param(9) = New ReportParameter("lokasi", kota + ", " + Format(MDIParent1.DateTimePicker1.Value, "dd MMM yyyy"))
        param(10) = New ReportParameter("nama_lembaga", nama_lembaga)
        Me.ReportViewer1.LocalReport.SetParameters(param)
        'koneksi.Close()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class