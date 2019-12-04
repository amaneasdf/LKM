Imports System.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class form_data_nasabah
    Dim data_array(99) As String
    Dim kd As String
    Private Sub form_data_nasabah_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub form_data_nasabah_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub form_data_nasabah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent
        report()
    End Sub

    Public Sub report()
        da = New MySqlDataAdapter()
        ds = New DATASET

        da.SelectCommand = New MySqlCommand("SELECT * FROM data_nasabah_gambar WHERE gambar_nasabah_id='" & TextBox1.Text & "'", koneksi)
        da.Fill(ds.Tables("gambar_nasabah"))

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("gambar_nasabah")))


        cd = New MySqlCommand("SELECT * FROM data_nasabah WHERE nasabah_id='" & TextBox1.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        data_array(0) = rd.Item("nasabah_id")
        data_array(1) = rd.Item("nasabah_alternatif")
        data_array(2) = rd.Item("nasabah_nama1")
        data_array(3) = rd.Item("nasabah_nama2")
        data_array(4) = rd.Item("nasabah_jenis_kelamin")
        data_array(5) = rd.Item("nasabah_keterkaitan")
        data_array(6) = rd.Item("nasabah_nik")
        data_array(7) = rd.Item("nasabah_npwp")
        data_array(8) = rd.Item("nasabah_kota")
        data_array(9) = Format(rd.Item("nasabah_tanggal_lahir"), "dd MMM yyyy")
        data_array(10) = rd.Item("nasabah_status_marital")
        data_array(11) = rd.Item("nasabah_nama_pasangan")
        data_array(12) = rd.Item("nasabah_nik_pasangan")
        data_array(13) = Format(rd.Item("nasabah_tanggal_lahir_pasangan"), "dd MMM yyyy")
        If rd.Item("nasabah_pph_pasangan") = "T" Then
            data_array(14) = "TIDAK"
        Else
            data_array(14) = "YA"
        End If
        data_array(15) = rd.Item("nasabah_pendidikan")
        data_array(16) = rd.Item("nasabah_keterangan_pendidikan")
        data_array(17) = rd.Item("nasabah_nama_ibu")
        data_array(18) = rd.Item("nasabah_agama")
        data_array(19) = rd.Item("nasabah_alamat")
        data_array(20) = rd.Item("nasabah_kelurahan")
        data_array(21) = rd.Item("nasabah_kecamatan")
        data_array(22) = rd.Item("nasabah_dati2")
        data_array(23) = rd.Item("nasabah_kode_pos")
        data_array(24) = rd.Item("nasabah_alamat_domisili")
        data_array(25) = Format(rd.Item("nasabah_tanggal_domisili"), "dd MMM yyyy")
        data_array(26) = rd.Item("nasabah_kode_area")
        data_array(27) = rd.Item("nasabah_telepon")
        data_array(28) = rd.Item("nasabah_mobile")
        data_array(29) = rd.Item("nasabah_pekerjaan")
        data_array(30) = rd.Item("nasabah_keterangan_pekerjaan")
        data_array(31) = rd.Item("nasabah_alamat_bekerja")
        data_array(32) = FormatNumber(rd.Item("nasabah_jumlah_tanggungan"), 0)
        data_array(33) = FormatNumber(rd.Item("nasabah_gaji"), 0)
        data_array(34) = FormatNumber(rd.Item("nasabah_usaha"), 0)
        data_array(35) = FormatNumber(rd.Item("nasabah_lain"), 0)
        data_array(36) = rd.Item("nasabah_hubungan_debitur")
        data_array(37) = rd.Item("nasabah_melanggar_bmpk")
        data_array(38) = rd.Item("nasabah_melampaui_bmpk")
        rd.Close()

        cd = New MySqlCommand("SELECT * FROM data_kantor", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim nama_lembaga As String = rd.Item("kantor_nama_lembaga")
        rd.Close()


        For i As Integer = 0 To 38
            If i = 4 Or i = 5 Or i = 10 Or i = 15 Or i = 18 Or i = 22 Or i = 29 Or i = 36 Or i = 37 Or i = 38 Then
                kd = ""
                If i = 4 Then
                    kd = "02"
                ElseIf i = 5 Then
                    kd = "14"
                ElseIf i = 10 Then
                    kd = "05"
                ElseIf i = 15 Then
                    kd = "07"
                ElseIf i = 18 Then
                    kd = "04"
                ElseIf i = 22 Then
                    kd = "09"
                ElseIf i = 29 Then
                    kd = "08"
                ElseIf i = 36 Then
                    kd = "29"
                ElseIf i = 37 Then
                    kd = "30"
                ElseIf i = 38 Then
                    kd = "31"
                End If
                cd = New MySqlCommand("SELECT IFNULL(combo_text, '-') AS combo_text FROM kode_komponen WHERE combo_komponen='" & kd & "' AND combo_kode='" & data_array(i) & "' AND combo_pakai='1'", koneksi)
                rd = cd.ExecuteReader
                rd.Read()
                data_array(i) = rd.Item("combo_text")
                rd.Close()
            End If
            '    
        Next


        Dim param(40) As ReportParameter
        param(0) = New ReportParameter("nasabah_id", data_array(0) + " ")
        param(1) = New ReportParameter("alternatif", data_array(1) + " ")
        param(2) = New ReportParameter("nama_lengkap", data_array(2) + " ")
        param(3) = New ReportParameter("nama_alias", data_array(3) + " ")
        param(4) = New ReportParameter("jenis_kelamin", data_array(4) + " ")
        param(5) = New ReportParameter("keterkaitan", data_array(5) + " ")
        param(6) = New ReportParameter("nik", data_array(6) + " ")
        param(7) = New ReportParameter("npwp", data_array(7) + " ")
        param(8) = New ReportParameter("kota_lahir", data_array(8) + " ")
        param(9) = New ReportParameter("tanggal_lahir", data_array(9) + " ")
        param(10) = New ReportParameter("status_marital", data_array(10) + " ")
        If data_array(10) = "Menikah" Then
            param(11) = New ReportParameter("nama_pasangan", data_array(11) + " ")
            param(12) = New ReportParameter("nik_pasangan", data_array(12) + " ")
            param(13) = New ReportParameter("tanggal_lahir_pasangan", data_array(13) + " ")
            param(14) = New ReportParameter("pph_pasangan", data_array(14) + " ")
        Else
            param(11) = New ReportParameter("nama_pasangan", "-")
            param(12) = New ReportParameter("nik_pasangan", "-")
            param(13) = New ReportParameter("tanggal_lahir_pasangan", "-")
            param(14) = New ReportParameter("pph_pasangan", "-")
        End If
        param(15) = New ReportParameter("pendidikan", data_array(15) + " ")
        param(16) = New ReportParameter("keterangan_pendidikan", data_array(16) + " ")
        param(17) = New ReportParameter("nama_ibu_kandung", data_array(17) + " ")
        param(18) = New ReportParameter("agama", data_array(18) + " ")
        param(19) = New ReportParameter("alamat", data_array(19) + " ")
        param(20) = New ReportParameter("desa", data_array(20) + " ")
        param(21) = New ReportParameter("kecamatan", data_array(21) + " ")
        param(22) = New ReportParameter("dati2", data_array(22) + " ")
        param(23) = New ReportParameter("kode_pos", data_array(23) + " ")
        param(24) = New ReportParameter("alamat_domisili", data_array(24) + " ")
        param(25) = New ReportParameter("tanggal_domisili", data_array(25) + " ")
        param(26) = New ReportParameter("telepon1", data_array(26) + " ")
        param(27) = New ReportParameter("telepon2", data_array(27) + " ")
        param(28) = New ReportParameter("mobile", data_array(28) + " ")
        param(29) = New ReportParameter("pekerjaan1", data_array(29) + " ")
        param(30) = New ReportParameter("pekerjaan2", data_array(30) + " ")
        param(31) = New ReportParameter("alamat_bekerja", data_array(31) + " ")
        param(32) = New ReportParameter("jml_tanggungan", data_array(32) + " ")
        param(33) = New ReportParameter("gaji", data_array(33) + " ")
        param(34) = New ReportParameter("usaha", data_array(34) + " ")
        param(35) = New ReportParameter("lain", data_array(35) + " ")
        param(36) = New ReportParameter("hubungan_debitur", data_array(36) + " ")
        param(37) = New ReportParameter("melanggar_bmpk", data_array(37) + " ")
        param(38) = New ReportParameter("melampaui_bmpk", data_array(38) + " ")
        param(39) = New ReportParameter("nama_lembaga", nama_lembaga + " ")
        param(40) = New ReportParameter("waktu", Format(MDIParent1.DateTimePicker1.Value, "dd/MM/yyyy HH:mm:ss"))

        Me.ReportViewer1.LocalReport.SetParameters(param)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class