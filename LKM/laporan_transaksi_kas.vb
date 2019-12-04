Imports System.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class laporan_transaksi_kas
    Public da1, da2, da3, da4, da5 As MySqlDataAdapter
    Public dt1, dt2, dt3, dt4, dt5 As DataTable

    Dim modal_awal, waktunow, kd As String

    Private Sub laporan_transaksi_kas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub laporan_transaksi_kas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub laporan_transaksi_kas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent
        report()
    End Sub

    Public Sub report()
        da = New MySqlDataAdapter()
        ds = New DATASET
        da.SelectCommand = New MySqlCommand(cetak_laporan_transaksi_teller.TextBox1.Text, koneksi)
        da.Fill(ds.Tables("jurnal_kas"))

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("jurnal_kas")))

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

        Dim param(9) As ReportParameter
        param(0) = New ReportParameter("alamat_lembaga", alamat_lembaga)
        param(1) = New ReportParameter("nama_lembaga", nama_lembaga)
        param(2) = New ReportParameter("tanggal", "Periode " + Format(cetak_laporan_transaksi_teller.DateTimePicker1.Value, "dd MMMM yyyy") + " sd " + Format(cetak_laporan_transaksi_teller.DateTimePicker2.Value, "dd MMMM yyyy"))
        param(3) = New ReportParameter("dibuat", nama(0))
        param(4) = New ReportParameter("diperiksa", nama(1))
        param(5) = New ReportParameter("disahkan", nama(2))
        param(6) = New ReportParameter("waktu", Format(MDIParent1.DateTimePicker1.Value, "dd/MM/yyyy HH:mm:ss"))
        carimodalawal()
        param(7) = New ReportParameter("modal_awal", FormatNumber(modal_awal, 0))
        Dim mutasi As String = 0
        cd = New MySqlCommand("SELECT IFNULL(SUM(masuk-keluar),0) AS mutasi FROM v_jurnal_kas WHERE (jurnal_tanggal BETWEEN '" + Format(cetak_laporan_transaksi_teller.DateTimePicker1.Value, "yyyy-MM-dd") + "' AND '" + Format(cetak_laporan_transaksi_teller.DateTimePicker2.Value, "yyyy-MM-dd") + "')", koneksi)
        rd = cd.ExecuteReader
        rd.Read()

        mutasi = rd.Item("mutasi")
        rd.Close()
        param(8) = New ReportParameter("mutasi", FormatNumber(mutasi, 0))
        param(9) = New ReportParameter("saldo_kas", FormatNumber(Val(modal_awal) + Val(mutasi), 0))

        Me.ReportViewer1.LocalReport.SetParameters(param)
        'koneksi.Close()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Sub carimodalawal()
        'Format(DateAdd("d", 0 - 1, DateTimePicker1.Value), "dd-MMMM-yyyy")
        waktunow = Format(DateAdd("d", 0 - 1, cetak_laporan_transaksi_teller.DateTimePicker1.Value), "yyyy-MM-dd").ToString + " 23:59:59"

        da = New MySqlDataAdapter("SELECT hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS modalawal, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml FROM kode_perkiraan WHERE perkiraan_kode=(SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='Kas')", koneksi)
        dt = New DataTable
        da.Fill(dt)
        For i As Integer = 0 To dt.Rows.Count - 1

            modal_awal = 0
            modal_awal = Val(modal_awal) + Val(dt.Rows(i)("modalawal"))

            If dt.Rows(i)("jml") > 0 Then
                da1 = New MySqlDataAdapter("SELECT hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS modalawal1, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml1 FROM kode_perkiraan WHERE perkiraan_parent='" & dt.Rows(i)("perkiraan_kode") & "'", koneksi)
                dt1 = New DataTable
                da1.Fill(dt1)
                For i1 As Integer = 0 To dt1.Rows.Count - 1
                    modal_awal = Val(modal_awal) + Val(dt1.Rows(i1)("modalawal1"))

                    If dt1.Rows(i1)("jml1") > 0 Then
                        da2 = New MySqlDataAdapter("SELECT  hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS modalawal2,  hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml2 FROM kode_perkiraan WHERE perkiraan_parent='" & dt1.Rows(i1)("perkiraan_kode") & "'", koneksi)
                        dt2 = New DataTable
                        da2.Fill(dt2)
                        For i2 As Integer = 0 To dt2.Rows.Count - 1
                            modal_awal = Val(modal_awal) + Val(dt2.Rows(i2)("modalawal2"))

                            If dt2.Rows(i2)("jml2") > 0 Then
                                da3 = New MySqlDataAdapter("SELECT hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS modalawal3, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml3 FROM kode_perkiraan WHERE perkiraan_parent='" & dt2.Rows(i2)("perkiraan_kode") & "'", koneksi)
                                dt3 = New DataTable
                                da3.Fill(dt3)
                                For i3 As Integer = 0 To dt3.Rows.Count - 1
                                    modal_awal = Val(modal_awal) + dt3.Rows(i3)("modalawal3")

                                    If dt3.Rows(i3)("jml3") > 0 Then
                                        da4 = New MySqlDataAdapter("SELECT hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS modalawal4, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml4 FROM kode_perkiraan WHERE perkiraan_parent='" & dt3.Rows(i3)("perkiraan_kode") & "'", koneksi)
                                        dt4 = New DataTable
                                        da4.Fill(dt4)
                                        For i4 As Integer = 0 To dt4.Rows.Count - 1
                                            modal_awal = Val(modal_awal) + dt4.Rows(i4)("modalawal4")

                                            If dt4.Rows(i4)("jml4") > 0 Then
                                                da5 = New MySqlDataAdapter("SELECT hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS modalawal5 FROM kode_perkiraan WHERE perkiraan_parent='" & dt4.Rows(i4)("perkiraan_kode") & "'", koneksi)
                                                dt5 = New DataTable
                                                da5.Fill(dt5)
                                                For i5 As Integer = 0 To dt5.Rows.Count - 1
                                                    modal_awal = Val(modal_awal) + dt5.Rows(i5)("modalawal5")
                                                Next
                                            End If
                                        Next
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If

        Next
    End Sub
End Class