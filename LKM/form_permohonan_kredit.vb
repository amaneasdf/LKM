Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class form_permohonan_kredit

    Private Sub form_permohonan_kredit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub form_permohonan_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub form_permohonan_kredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent
        report()
    End Sub

    Public Sub report()
        'rd.Close()
        cd = New MySqlCommand("SELECT *, (SELECT combo_text FROM kode_komponen WHERE combo_komponen='05' AND combo_kode=nasabah_status_marital) AS status, (SELECT combo_text FROM kode_komponen WHERE combo_komponen='07' AND combo_kode=nasabah_pendidikan) AS pend, (SELECT combo_text FROM kode_komponen WHERE combo_komponen='04' AND combo_kode=nasabah_agama) AS agama FROM data_nasabah WHERE nasabah_id='" & TextBox1.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim nama1 As String = rd.Item("nasabah_nama1")
        Dim nama2 As String = rd.Item("nasabah_nama2")
        Dim jenis_kelamin As String = rd.Item("nasabah_jenis_kelamin")
        Dim nik As String = rd.Item("nasabah_nik")
        Dim kota As String = rd.Item("nasabah_kota")
        Dim tanggal_lahir As String = Format(rd.Item("nasabah_tanggal_lahir"), "dd/MM/yyyy")
        Dim nama_pasangan As String
        If rd.Item("nasabah_status_marital") = "1" Then
            nama_pasangan = " "
        Else
            nama_pasangan = rd.Item("nasabah_nama_pasangan")
        End If
        Dim nama_ibu As String = rd.Item("nasabah_nama_ibu")

        Dim alamat As String = rd.Item("nasabah_alamat")
        Dim alamat_domisili As String = rd.Item("nasabah_alamat_domisili")
        Dim tanggal_domisili As String = Format(rd.Item("nasabah_tanggal_domisili"), "dd/MM/yyyy")
        Dim kode_area As String = rd.Item("nasabah_kode_area")
        Dim telepon As String = rd.Item("nasabah_telepon")
        Dim mobile As String = rd.Item("nasabah_mobile")
        Dim keterangan_pekerjaan As String = rd.Item("nasabah_keterangan_pekerjaan")
        Dim gaji As String = rd.Item("nasabah_gaji")

        Dim status As String = rd.Item("status")
        Dim pend As String = rd.Item("pend")
        Dim agama As String = rd.Item("agama")
        rd.Close()

        cd = New MySqlCommand("SELECT * FROM data_kantor", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim nama_lembaga As String = rd.Item("kantor_nama_lembaga")
        rd.Close()

        Dim param(16) As ReportParameter
        param(0) = New ReportParameter("nama_lengkap", nama1)
        param(1) = New ReportParameter("nama_alias", nama2)
        If jenis_kelamin = "1" Then
            param(2) = New ReportParameter("jenis_kelamin", "Laki-laki")
        Else
            param(2) = New ReportParameter("jenis_kelamin", "Perempuan")
        End If
        param(3) = New ReportParameter("no_ktp", nik)
        param(4) = New ReportParameter("ttl", kota.ToString + ", " + tanggal_lahir)
        param(5) = New ReportParameter("status", status)
        param(6) = New ReportParameter("nama_pasangan", nama_pasangan)
        param(7) = New ReportParameter("pendidikan", pend)
        param(8) = New ReportParameter("nama_ibu_kandung", nama_ibu)
        param(9) = New ReportParameter("agama", agama)
        param(10) = New ReportParameter("alamat", alamat)
        param(11) = New ReportParameter("domisili", alamat_domisili)
        param(12) = New ReportParameter("sejak", tanggal_domisili)
        param(13) = New ReportParameter("no_telepon", kode_area.ToString + " " + telepon.ToString + " / " + mobile.ToString)
        param(14) = New ReportParameter("pekerjaan", keterangan_pekerjaan)
        param(15) = New ReportParameter("gaji", "Rp " + FormatNumber(gaji, 0))
        param(16) = New ReportParameter("nama_lembaga", nama_lembaga)

        Me.ReportViewer1.LocalReport.SetParameters(param)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class