Imports System.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class form_rekening_koran

    Private Sub form_rekening_koran_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub form_rekening_koran_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Private Sub form_rekening_koran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent
        report()
    End Sub
    Public Sub report()
        ' koneksi_localhost()
        'koneksi.Open()
        da = New MySqlDataAdapter()
        ds = New DATASET
        da.SelectCommand = New MySqlCommand("SELECT * FROM v_rekening_koran WHERE tab_stat_no_rekening='" & TextBox1.Text & "' AND (tab_stat_tanggal BETWEEN '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "')", koneksi)
        da.Fill(ds.Tables("rekening_koran"))

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("rekening_koran")))

        cd = New MySqlCommand("SELECT * FROM data_kantor", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim nama_lembaga As String = rd.Item("kantor_nama_lembaga")
        Dim alamat_lembaga As String = rd.Item("kantor_alamat")
        rd.Close()

        cd = New MySqlCommand("SELECT nasabah_nama1, nasabah_nik, nasabah_alamat, nasabah_kelurahan, nasabah_kecamatan,  rek_tab_reg_waktu, rek_tab_status FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id = nasabah_id WHERE rek_tab_no_rekening='" & TextBox1.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim nama1 As String = rd.Item("nasabah_nama1")
        Dim nik As String = rd.Item("nasabah_nik")
        Dim alamat As String = rd.Item("nasabah_alamat") + ", " + rd.Item("nasabah_kelurahan") + ", " + rd.Item("nasabah_kecamatan")
        Dim reg_date As String = Format(rd.Item("rek_tab_reg_waktu"), "dd MMM yyyy")
        Dim status As String = ""
        Select Case rd.Item("rek_tab_status")
            Case "0"
                status = "NONE"
            Case "1"
                status = "AKTIF"
            Case "2"
                status = "BLOKIR"
            Case "4"
                status = "TUTUP"
        End Select
        rd.Close()

        Dim param(8) As ReportParameter
        param(0) = New ReportParameter("tanggal", Format(DateTimePicker1.Value, "dd MMM yyyy") + " - " + Format(DateTimePicker2.Value, "dd MMM yyyy"))
        param(1) = New ReportParameter("no_rekening", TextBox1.Text)
        param(2) = New ReportParameter("nama_nasabah", nama1)
        param(3) = New ReportParameter("alamat", alamat)
        param(4) = New ReportParameter("nik", nik)
        param(5) = New ReportParameter("kantor", nama_lembaga)
        param(6) = New ReportParameter("tgl_registrasi", reg_date)
        param(7) = New ReportParameter("status", status)
        param(8) = New ReportParameter("alamat_lembaga", alamat_lembaga)
        Me.ReportViewer1.LocalReport.SetParameters(param)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class