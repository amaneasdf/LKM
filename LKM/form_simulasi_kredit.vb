Imports System.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class form_simulasi_kredit

    Private Sub form_simulasi_kredit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub form_simulasi_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub form_simulasi_kredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent
        report()
    End Sub

    Public Sub report()
        ' koneksi_localhost()
        'koneksi.Open()
        da = New MySqlDataAdapter()
        ds = New DATASET
        da.SelectCommand = New MySqlCommand("SELECT * FROM temp_simulasi_kredit WHERE temp_username='" & MDIParent1.username.Text & "' ORDER BY temp_tanggal_tagihan ASC", koneksi)
        da.Fill(ds.Tables("simulasi_kredit"))

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("simulasi_kredit")))

        cd = New MySqlCommand("SELECT * FROM data_kantor", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Dim nama_lembaga As String = rd.Item("kantor_nama_lembaga")
        Dim alamat_lembaga As String = rd.Item("kantor_alamat")
        rd.Close()

        Dim param(18) As ReportParameter
        With simulasi_kredit
            param(0) = New ReportParameter("nama_lembaga", nama_lembaga)
            param(1) = New ReportParameter("alamat_lembaga", alamat_lembaga)
            param(2) = New ReportParameter("nama_nasabah", .tnama_nasabah.Text)
            param(3) = New ReportParameter("alamat_nasabah", .talamat.Text)
            param(4) = New ReportParameter("no_telepon", .tmobile.Text)
            param(5) = New ReportParameter("nama_skim", .cmbskim_kredit.Text)
            param(6) = New ReportParameter("plafon_kredit", FormatNumber(.tplafon_akad.Text, 0))
            param(7) = New ReportParameter("sb_thn", .cmbsistem_bunga.Text.ToString + " (" + .tsuku_bunga.Text.ToString + " %)")
            param(8) = New ReportParameter("periode_pinjaman", .DateTimePicker1.Text + " - " + .DateTimePicker2.Text + "(" + .tjkw.Text.ToString + " " + .Label22.Text + ")")
            param(9) = New ReportParameter("jumlah_bunga", FormatNumber(.TextBox1.Text, 0))
            param(10) = New ReportParameter("total_hutang", FormatNumber(Val(Format(.tplafon_akad.Text, "General Number")) + Val(.TextBox1.Text), 0))
            param(11) = New ReportParameter("provisi", .tprovisi2.Text)
            param(12) = New ReportParameter("administrasi", .tadministrasi2.Text)
            param(13) = New ReportParameter("materai", .tmaterai.Text)
            param(14) = New ReportParameter("asuransi", .tasuransi.Text)
            param(15) = New ReportParameter("notaris", .tnotaris.Text)
            param(16) = New ReportParameter("lain", .tlain.Text)
            param(17) = New ReportParameter("jumlah_potongan", FormatNumber(.TextBox2.Text, 0))
            param(18) = New ReportParameter("jumlah_terima", FormatNumber(.TextBox3.Text, 0))
        End With

        Me.ReportViewer1.LocalReport.SetParameters(param)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class