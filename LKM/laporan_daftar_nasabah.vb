Imports System.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class laporan_daftar_nasabah
    Dim sort_rekening, urutkan As String
    Dim data_ke(99) As String

    Private Sub laporan_daftar_nasabah_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub laporan_daftar_nasabah_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub laporan_daftar_nasabah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent
        data()
        report()
    End Sub

    Public Sub report()
        Dim da As New MySqlDataAdapter
        Dim ds As New DATASET
        Dim param(4) As ReportParameter

        Select Case daftar_nasabah.cmbrekening.Text.ToString.Split(" : ")(0)
            Case "1"
                sort_rekening = "  AND temp_jml_tabungan > 0 AND temp_jml_kredit > 0"
                param(4) = New ReportParameter("laporan", "1")
            Case "2"
                sort_rekening = " AND temp_jml_tabungan > 0 AND temp_jml_kredit = 0"
                param(4) = New ReportParameter("laporan", "2")
            Case "4"
                sort_rekening = " AND temp_jml_kredit > 0 AND temp_jml_tabungan = 0"
                param(4) = New ReportParameter("laporan", "4")
                'Case "6"
                'sort_rekening = " AND temp_jml_tabungan > 0 AND temp_jml_kredit > 0"
        End Select

        Select Case daftar_nasabah.cmburutkan_data.Text.ToString.Split(" : ")(0)
            Case "1"
                urutkan = " ORDER BY temp_nasabah_id ASC"
            Case "2"
                urutkan = " ORDER BY temp_nama_nasabah ASC"

        End Select

        da.SelectCommand = New MySqlCommand("SELECT * FROM temp_daftar_nasabah WHERE temp_username='" & MDIParent1.username.Text & "' " + sort_rekening + urutkan, koneksi)
        da.Fill(ds.Tables("daftar_nasabah"))

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("daftar_nasabah")))

        cd = New MySqlCommand("SELECT * FROM data_kantor", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim nama_lembaga As String = rd.Item("kantor_nama_lembaga")
        Dim alamat_lembaga As String = rd.Item("kantor_alamat")
        rd.Close()


        param(0) = New ReportParameter("alamat_lembaga", alamat_lembaga)
        param(1) = New ReportParameter("nama_lembaga", nama_lembaga)
        param(2) = New ReportParameter("tanggal", "Per " + Format(daftar_nasabah.DateTimePicker1.Value, "dd MMMM yyyy"))
        param(3) = New ReportParameter("waktu", Format(MDIParent1.DateTimePicker1.Value, "dd/MM/yyyy HH:mm:ss"))


        Me.ReportViewer1.LocalReport.SetParameters(param)
        'koneksi.Close()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Sub data()
        cd = New MySqlCommand("DELETE FROM temp_daftar_nasabah WHERE temp_username='" & MDIParent1.username.Text & "'", koneksi)
        cd.ExecuteNonQuery()

        da = New MySqlDataAdapter("SELECT nasabah_id, nasabah_nama1, IF(nasabah_jenis_kelamin='1', 'L','P') AS jeniskelamin, nasabah_tanggal_lahir, nasabah_nik, (SELECT IFNULL(COUNT(*),0) FROM data_tabungan_rekening WHERE rek_tab_nasabah_id=nasabah_id AND rek_tab_reg_waktu<='" & Format(daftar_nasabah.DateTimePicker1.Value, "yyyy-MM-dd") & " 23:59:59') AS jml_tabungan, (SELECT IFNULL(COUNT(*),0) FROM data_kredit_rekening WHERE rek_kre_nasabah_id=nasabah_id AND rek_kre_reg_waktu<='" & Format(daftar_nasabah.DateTimePicker1.Value, "yyyy-MM-dd") & " 23:59:59') AS jml_kredit FROM data_nasabah ", koneksi)
        dt = New DataTable
        da.Fill(dt)
        For i As Integer = 0 To dt.Rows.Count - 1
            data_ke(0) = dt.Rows(i)("nasabah_id")
            data_ke(1) = dt.Rows(i)("nasabah_nama1")
            data_ke(2) = dt.Rows(i)("jeniskelamin")
            data_ke(3) = Format(dt.Rows(i)("nasabah_tanggal_lahir"), "yyyy-MM-dd")
            data_ke(4) = dt.Rows(i)("nasabah_nik")
            data_ke(5) = dt.Rows(i)("jml_tabungan")
            data_ke(6) = dt.Rows(i)("jml_kredit")
            data_ke(7) = MDIParent1.username.Text

            Dim gabungan As String = ""
            For ii As Integer = 0 To 7
                If ii = 0 Then
                    gabungan = "'" + data_ke(ii) + "'"
                Else
                    gabungan = gabungan + ", '" + data_ke(ii) + "'"
                End If
            Next

            cd = New MySqlCommand("INSERT INTO temp_daftar_nasabah VALUES (" + gabungan + ")", koneksi)
            cd.ExecuteNonQuery()
        Next
    End Sub
End Class