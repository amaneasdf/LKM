Imports System.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class laporan_rekening_administrasi
    Public da1, da2, da3, da4, da5 As MySqlDataAdapter
    Public dt1, dt2, dt3, dt4, dt5 As DataTable

    Dim saldo_akhir As String
    Dim tgl1, tgl2, waktunow As String

    Dim LR(99) As String
    Dim perhitungan As String

    Private Sub laporan_rekening_administrasi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub laporan_rekening_administrasi_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub laporan_rekening_administrasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent

        hapustemp()
        data()
        Report()
    End Sub

    Public Sub report()
        Dim da As New MySqlDataAdapter
        Dim ds As New DATASET

        da.SelectCommand = New MySqlCommand("SELECT * FROM temp_neraca WHERE temp_username='" & MDIParent1.username.Text & "'  ORDER BY  temp_perkiraan_kode ASC", koneksi)
        da.Fill(ds.Tables("temp_neraca"))

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("temp_neraca")))

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


        Dim param(7) As ReportParameter
        param(0) = New ReportParameter("alamat_lembaga", alamat_lembaga)
        param(1) = New ReportParameter("nama_lembaga", nama_lembaga)
        param(7) = New ReportParameter("nama_laporan", TextBox1.Text)
        param(2) = New ReportParameter("tanggal", "Periode " + Format(DateTimePicker1.Value, "dd MMMM yyyy") + " sd " + Format(DateTimePicker2.Value, "dd MMMM yyyy"))
        param(3) = New ReportParameter("dibuat", nama(0))
        param(4) = New ReportParameter("diperiksa", nama(1))
        param(5) = New ReportParameter("disahkan", nama(2))
        param(6) = New ReportParameter("waktu", Format(MDIParent1.DateTimePicker1.Value, "dd/MM/yyyy HH:mm:ss"))

        Me.ReportViewer1.LocalReport.SetParameters(param)
        'koneksi.Close()
        Me.ReportViewer1.RefreshReport()
    End Sub


    Sub hapustemp()
        cd = New MySqlCommand("DELETE FROM temp_neraca WHERE temp_username='" & MDIParent1.username.Text & "'", koneksi)
        cd.ExecuteNonQuery()
    End Sub



    Sub data()
        da = New MySqlDataAdapter("SELECT perkiraan_kode, perkiraan_umum, perkiraan_type, perkiraan_parent, perkiraan_nama, perkiraan_d_or_k, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & Format(DateTimePicker2.Value, "yyyy-MM-dd HH:mm:ss") & "') AS saldoakhir, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml FROM kode_perkiraan WHERE perkiraan_umum='7'", koneksi)
        dt = New DataTable
        da.Fill(dt)

        waktunow = Format(DateTimePicker2.Value, "yyyy-MM-dd HH:mm:ss")
        For i As Integer = 0 To dt.Rows.Count - 1
            saldo_akhir = 0
            saldo_akhir = saldo_akhir + dt.Rows(i)("saldoakhir")




            If dt.Rows(i)("jml") > 0 Then
                da1 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS saldoakhir1, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml1 FROM kode_perkiraan WHERE perkiraan_parent='" & dt.Rows(i)("perkiraan_kode") & "'", koneksi)
                dt1 = New DataTable
                da1.Fill(dt1)
                For i1 As Integer = 0 To dt1.Rows.Count - 1
                    saldo_akhir = saldo_akhir + dt1.Rows(i1)("saldoakhir1")

                    If dt1.Rows(i1)("jml1") > 0 Then
                        da2 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS saldoakhir2,  hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml2 FROM kode_perkiraan WHERE perkiraan_parent='" & dt1.Rows(i1)("perkiraan_kode") & "'", koneksi)
                        dt2 = New DataTable
                        da2.Fill(dt2)
                        For i2 As Integer = 0 To dt2.Rows.Count - 1
                            saldo_akhir = saldo_akhir + dt2.Rows(i2)("saldoakhir2")

                            If dt2.Rows(i2)("jml2") > 0 Then
                                da3 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS saldoakhir3, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml3 FROM kode_perkiraan WHERE perkiraan_parent='" & dt2.Rows(i2)("perkiraan_kode") & "'", koneksi)
                                dt3 = New DataTable
                                da3.Fill(dt3)
                                For i3 As Integer = 0 To dt3.Rows.Count - 1
                                    saldo_akhir = saldo_akhir + dt3.Rows(i3)("saldoakhir3")

                                    If dt3.Rows(i3)("jml3") > 0 Then
                                        da4 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS saldoakhir4, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml4 FROM kode_perkiraan WHERE perkiraan_parent='" & dt3.Rows(i3)("perkiraan_kode") & "'", koneksi)
                                        dt4 = New DataTable
                                        da4.Fill(dt4)
                                        For i4 As Integer = 0 To dt4.Rows.Count - 1
                                            saldo_akhir = saldo_akhir + dt4.Rows(i4)("saldoakhir4")

                                            If dt4.Rows(i4)("jml4") > 0 Then
                                                da5 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS saldoakhir5 FROM kode_perkiraan WHERE perkiraan_parent='" & dt4.Rows(i4)("perkiraan_kode") & "'", koneksi)
                                                dt5 = New DataTable
                                                da5.Fill(dt5)
                                                For i5 As Integer = 0 To dt5.Rows.Count - 1
                                                    saldo_akhir = saldo_akhir + dt5.Rows(i5)("saldoakhir5")
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


            cd = New MySqlCommand("INSERT INTO temp_neraca VALUES ('" & i + 1 & "','" & dt.Rows(i)("perkiraan_kode") & "','" & dt.Rows(i)("perkiraan_umum") & "', '" & dt.Rows(i)("perkiraan_nama") & "', '0', '0', '0', '0', '" & saldo_akhir & "', '', '" & MDIParent1.username.Text & "')", koneksi)
            cd.ExecuteNonQuery()
        Next
    End Sub

End Class