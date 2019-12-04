Imports System.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class laporan_verbal_kas

    Private Sub laporan_verbal_kas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub laporan_verbal_kas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub laporan_verbal_kas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent
        Report()
    End Sub

    Public Sub report()
        da = New MySqlDataAdapter()
        ds = New DATASET
        da.SelectCommand = New MySqlCommand("SELECT * FROM verbal_kas WHERE verbal_tanggal='" & Format(transaksi_verbal_kas.DateTimePicker1.Value, "yyyy-MM-dd") & "'", koneksi)
        da.Fill(ds.Tables("verbal_kas"))

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("verbal_kas")))

        cd = New MySqlCommand("SELECT * FROM data_kantor", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim nama_lembaga As String = rd.Item("kantor_nama_lembaga")
        Dim alamat_lembaga As String = rd.Item("kantor_alamat")
        rd.Close()

        Dim ket(99), nama(99) As String
        ket(0) = "akuntansi_laporan_pembuat"
        ket(1) = "akuntansi_laporan_pemeriksa"
        ket(2) = "akuntansi_laporan_pengesah"
        For i = 0 To 2
            cd = New MySqlCommand("SELECT cari_nama_petugas_pelaporan('" & ket(i) & "') AS nama", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            nama(i) = rd.Item("nama")
            rd.Close()
        Next

        Dim param(11) As ReportParameter
        param(0) = New ReportParameter("alamat_lembaga", alamat_lembaga)
        param(1) = New ReportParameter("nama_lembaga", nama_lembaga)
        param(2) = New ReportParameter("tanggal", Format(transaksi_verbal_kas.DateTimePicker1.Value, "dd MMMM yyyy"))
        param(3) = New ReportParameter("dibuat", nama(0))
        param(4) = New ReportParameter("diperiksa", nama(1))
        param(5) = New ReportParameter("disahkan", nama(2))
        param(6) = New ReportParameter("waktu", Format(MDIParent1.DateTimePicker1.Value, "dd/MM/yyyy HH:mm:ss"))
        param(7) = New ReportParameter("saldo_awal_kas", transaksi_verbal_kas.tmodal_awal.Text)
        param(8) = New ReportParameter("penerimaan", transaksi_verbal_kas.tpenerimaan.Text)
        param(9) = New ReportParameter("pengeluaran", transaksi_verbal_kas.tpengeluaran.Text)
        param(10) = New ReportParameter("saldo_akhir", transaksi_verbal_kas.tsaldo_akhir.Text)
        param(11) = New ReportParameter("terbilang", TERBILANG(Val(Format(transaksi_verbal_kas.tsaldo_akhir.Text, "General Number"))))

        Me.ReportViewer1.LocalReport.SetParameters(param)
        'koneksi.Close()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class