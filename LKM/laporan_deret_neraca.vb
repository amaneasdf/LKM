﻿Imports System.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class laporan_deret_neraca
    Public daa, da1, da2, da3, da4, da5 As MySqlDataAdapter
    Public dtt, dt1, dt2, dt3, dt4, dt5 As DataTable
    Dim bln As String
    Dim tglakhirbulan As Date
    Dim bulan(12) As String


    Dim saldo_awal, saldo_debet, saldo_kredit, saldo_akhir, jenis, kd As String
    Dim tgl1, tgl2, waktunow As String

    Dim waktu_awal1, waktu_awal2 As String
    Dim waktu_dk1, waktu_dk2 As String
    Dim waktu_akhir1, waktu_akhir2 As String
    Dim LR(99) As String
    Dim perhitungan As String

    Private Sub laporan_deret_harian_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub laporan_deret_harian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.Percent

        hapustemp()
        'perhitunglabarugitahunlalu()
        'perhitunglabarugitahunberjalan()
        'If TextBox2.Text = "neraca saldo" Then
        data_neraca()
        update_labarugi()
        'Else
        'data_labarugi()
        'End If
        report()
    End Sub

    Sub update_labarugi()
        Dim bln As String = ""
        For i As Integer = 1 To 12
            If i = 1 Then
                bln = "deret_januari"
            ElseIf i = 2 Then
                bln = "deret_februari"
            ElseIf i = 3 Then
                bln = "deret_maret"
            ElseIf i = 4 Then
                bln = "deret_april"
            ElseIf i = 5 Then
                bln = "deret_mei"
            ElseIf i = 6 Then
                bln = "deret_juni"
            ElseIf i = 7 Then
                bln = "deret_juli"
            ElseIf i = 8 Then
                bln = "deret_agustus"
            ElseIf i = 9 Then
                bln = "deret_september"
            ElseIf i = 10 Then
                bln = "deret_oktober"
            ElseIf i = 11 Then
                bln = "deret_november"
            ElseIf i = 12 Then
                bln = "deret_desember"
            End If
            cd = New MySqlCommand("SELECT IFNULL(SUM(" & bln & "), 0) AS laba_rugi FROM temp_laporan_deret WHERE deret_username='" & MDIParent1.username.Text & "' AND deret_perkiraan_kode IN ('1.307','1.308')", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            Dim laba_rugi As String = rd.Item("laba_rugi")
            rd.Close()

            If laba_rugi > 0 Then
                cd = New MySqlCommand("UPDATE temp_laporan_deret SET " & bln & "='0' WHERE deret_username='" & MDIParent1.username.Text & "' AND deret_perkiraan_kode = '1.308' ", koneksi)
                cd.ExecuteNonQuery()
                cd = New MySqlCommand("UPDATE temp_laporan_deret SET " & bln & "='" & laba_rugi & "' WHERE deret_username='" & MDIParent1.username.Text & "' AND deret_perkiraan_kode = '1.307' ", koneksi)
                cd.ExecuteNonQuery()
            ElseIf laba_rugi < 0 Then
                cd = New MySqlCommand("UPDATE temp_laporan_deret SET " & bln & "='0' WHERE deret_username='" & MDIParent1.username.Text & "' AND deret_perkiraan_kode = '1.307' ", koneksi)
                cd.ExecuteNonQuery()
                cd = New MySqlCommand("UPDATE temp_laporan_deret SET " & bln & "='" & laba_rugi & "' WHERE deret_username='" & MDIParent1.username.Text & "' AND deret_perkiraan_kode = '1.308' ", koneksi)
                cd.ExecuteNonQuery()
            Else
                cd = New MySqlCommand("UPDATE temp_laporan_deret SET " & bln & "='0' WHERE deret_username='" & MDIParent1.username.Text & "' AND deret_perkiraan_kode IN ('1.307', '1.308')", koneksi)
                cd.ExecuteNonQuery()
            End If
        Next
        
    End Sub

    Public Sub report()
        'Data()
        Dim da As New MySqlDataAdapter
        Dim ds As New DATASET

        Dim txt As String = ""
        If TextBox4.Text = "1" Then
            txt = ""
        Else
            txt = " AND (deret_januari <> 0 OR deret_februari <> 0 OR deret_maret <> 0 OR deret_april <> 0 OR deret_mei <> 0 OR deret_juni <> 0 OR deret_juli <> 0 OR deret_agustus <> 0 OR deret_september <> 0 OR deret_oktober <> 0 OR deret_november <> 0 OR deret_desember <> 0)"
        End If

        da.SelectCommand = New MySqlCommand("SELECT * FROM temp_laporan_deret WHERE deret_username='" & MDIParent1.username.Text & "' " & txt & " ORDER BY deret_id ASC", koneksi)
        da.Fill(ds.Tables("temp_deret_harian"))

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("temp_deret_harian")))

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
        param(2) = New ReportParameter("tanggal", "Periode " + Format(DateTimePicker1.Value, "dd MMMM yyyy") + " sd " + Format(DateTimePicker2.Value, "dd MMMM yyyy"))
        param(3) = New ReportParameter("dibuat", nama(0))
        param(4) = New ReportParameter("diperiksa", nama(1))
        param(5) = New ReportParameter("disahkan", nama(2))
        param(6) = New ReportParameter("waktu", Format(MDIParent1.DateTimePicker1.Value, "dd/MM/yyyy HH:mm:ss"))
        param(7) = New ReportParameter("nama_laporan", TextBox1.Text)


        Me.ReportViewer1.LocalReport.SetParameters(param)
        'koneksi.Close()
        Me.ReportViewer1.RefreshReport()
    End Sub



    Sub hapustemp()
        cd = New MySqlCommand("DELETE FROM temp_laporan_deret WHERE deret_username='" & MDIParent1.username.Text & "'", koneksi)
        cd.ExecuteNonQuery()
    End Sub

    Sub perhitunglabarugitahunlalu()
        perhitungan = "tahun lalu"
        Dim waktu_akhir_tahun As String = (Val(Format(DateTimePicker1.Value, "yyyy")) - 1).ToString + "-12-31 23:59:59"

        da = New MySqlDataAdapter("SELECT perkiraan_kode, perkiraan_umum, perkiraan_type, perkiraan_parent, perkiraan_nama, perkiraan_d_or_k,   hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_akhir_tahun & "') AS saldoawal, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml FROM kode_perkiraan WHERE perkiraan_parent='2'", koneksi)
        dt = New DataTable
        da.Fill(dt)
        For i As Integer = 0 To dt.Rows.Count - 1

            saldo_awal = 0
            saldo_debet = 0
            saldo_kredit = 0
            saldo_akhir = 0
            saldo_awal = saldo_awal + dt.Rows(i)("saldoawal")

            If dt.Rows(i)("jml") > 0 Then
                da1 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_akhir_tahun & "') AS saldoawal1, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml1 FROM kode_perkiraan WHERE perkiraan_parent='" & dt.Rows(i)("perkiraan_kode") & "'", koneksi)
                dt1 = New DataTable
                da1.Fill(dt1)
                For i1 As Integer = 0 To dt1.Rows.Count - 1
                    saldo_awal = saldo_awal + dt1.Rows(i1)("saldoawal1")

                    If dt1.Rows(i1)("jml1") > 0 Then
                        da2 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_akhir_tahun & "') AS saldoawal2,  hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml2 FROM kode_perkiraan WHERE perkiraan_parent='" & dt1.Rows(i1)("perkiraan_kode") & "'", koneksi)
                        dt2 = New DataTable
                        da2.Fill(dt2)
                        For i2 As Integer = 0 To dt2.Rows.Count - 1
                            saldo_awal = saldo_awal + dt2.Rows(i2)("saldoawal2")

                            If dt2.Rows(i2)("jml2") > 0 Then
                                da3 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_akhir_tahun & "') AS saldoawal3, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml3 FROM kode_perkiraan WHERE perkiraan_parent='" & dt2.Rows(i2)("perkiraan_kode") & "'", koneksi)
                                dt3 = New DataTable
                                da3.Fill(dt3)
                                For i3 As Integer = 0 To dt3.Rows.Count - 1
                                    saldo_awal = saldo_awal + dt3.Rows(i3)("saldoawal3")

                                    If dt3.Rows(i3)("jml3") > 0 Then
                                        da4 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_akhir_tahun & "') AS saldoawal4, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml4 FROM kode_perkiraan WHERE perkiraan_parent='" & dt3.Rows(i3)("perkiraan_kode") & "'", koneksi)
                                        dt4 = New DataTable
                                        da4.Fill(dt4)
                                        For i4 As Integer = 0 To dt4.Rows.Count - 1
                                            saldo_awal = saldo_awal + dt4.Rows(i4)("saldoawal4")

                                            If dt4.Rows(i4)("jml4") > 0 Then
                                                da5 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_akhir_tahun & "') AS saldoawal5 FROM kode_perkiraan WHERE perkiraan_parent='" & dt4.Rows(i4)("perkiraan_kode") & "'", koneksi)
                                                dt5 = New DataTable
                                                da5.Fill(dt5)
                                                For i5 As Integer = 0 To dt5.Rows.Count - 1
                                                    saldo_awal = saldo_awal + dt5.Rows(i5)("saldoawal5")

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

            kd = dt.Rows(i)("perkiraan_kode")
            pilihan()

        Next
    End Sub

    Sub perhitunglabarugitahunberjalan()
        perhitungan = "tahun berjalan"
        If TextBox2.Text = "neraca saldo" Then
            waktu_awal1 = Format(tglakhirbulan, "yyyy").ToString + "-01-01 00:00:00"
        Else
            waktu_awal1 = Format(tglakhirbulan, "yyyy-MM").ToString + "-01 00:00:00"
        End If

        If Format(tglakhirbulan, "MM dd") = "01 31" Then
            waktu_awal2 = Format(tglakhirbulan, "yyyy").ToString + "-01-01 00:00:00"
        Else
            waktu_awal2 = Format(DateAdd("d", (0 - 1), Format(tglakhirbulan, "yyyy-MM").ToString + "-01"), "yyyy-MM-dd").ToString + " 23:59:59"
        End If
        waktu_dk1 = Format(tglakhirbulan, "yyyy-MM").ToString + "-01 00:00:00"
        waktu_dk2 = Format(tglakhirbulan, "yyyy-MM-dd").ToString + " 23:59:59"
        waktu_akhir1 = Format(tglakhirbulan, "yyyy").ToString + "-01-01 00:00:00"
        waktu_akhir2 = Format(tglakhirbulan, "yyyy-MM-dd").ToString + " 23:59:59"


        da = New MySqlDataAdapter("SELECT perkiraan_kode, perkiraan_umum, perkiraan_type, perkiraan_parent, perkiraan_nama, perkiraan_d_or_k, hitung_saldo_perkiraan_akhir_per_tanggal(perkiraan_kode,'" & waktu_awal1 & "','" & waktu_awal2 & "') AS saldoawal, hitung_saldo_perkiraan_debet_per_tanggal(perkiraan_kode,'" & waktu_dk1 & "','" & waktu_dk2 & "') AS saldodebet, hitung_saldo_perkiraan_kredit_per_tanggal(perkiraan_kode,'" & waktu_dk1 & "','" & waktu_dk2 & "') AS saldokredit, hitung_saldo_perkiraan_akhir_per_tanggal(perkiraan_kode,'" & waktu_akhir1 & "','" & waktu_akhir2 & "') AS saldoakhir, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml FROM kode_perkiraan WHERE perkiraan_parent='2'", koneksi)
        dt = New DataTable
        da.Fill(dt)
        For i As Integer = 0 To dt.Rows.Count - 1
            saldo_awal = 0
            saldo_debet = 0
            saldo_kredit = 0
            saldo_akhir = 0
            saldo_awal = saldo_awal + dt.Rows(i)("saldoawal")
            saldo_debet = saldo_debet + dt.Rows(i)("saldodebet")
            saldo_kredit = saldo_kredit + dt.Rows(i)("saldokredit")
            saldo_akhir = saldo_akhir + dt.Rows(i)("saldoakhir")

            If dt.Rows(i)("jml") > 0 Then
                da1 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir_per_tanggal(perkiraan_kode,'" & waktu_awal1 & "','" & waktu_awal2 & "') AS saldoawal1, hitung_saldo_perkiraan_debet_per_tanggal(perkiraan_kode,'" & waktu_dk1 & "','" & waktu_dk2 & "') AS saldodebet1, hitung_saldo_perkiraan_kredit_per_tanggal(perkiraan_kode,'" & waktu_dk1 & "','" & waktu_dk2 & "') AS saldokredit1, hitung_saldo_perkiraan_akhir_per_tanggal(perkiraan_kode,'" & waktu_akhir1 & "','" & waktu_akhir2 & "') AS saldoakhir1, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml1 FROM kode_perkiraan WHERE perkiraan_parent='" & dt.Rows(i)("perkiraan_kode") & "'", koneksi)
                dt1 = New DataTable
                da1.Fill(dt1)
                For i1 As Integer = 0 To dt1.Rows.Count - 1
                    saldo_awal = saldo_awal + dt1.Rows(i1)("saldoawal1")
                    saldo_debet = saldo_debet + dt1.Rows(i1)("saldodebet1")
                    saldo_kredit = saldo_kredit + dt1.Rows(i1)("saldokredit1")
                    saldo_akhir = saldo_akhir + dt1.Rows(i1)("saldoakhir1")

                    If dt1.Rows(i1)("jml1") > 0 Then
                        da2 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir_per_tanggal(perkiraan_kode,'" & waktu_awal1 & "','" & waktu_awal2 & "') AS saldoawal2, hitung_saldo_perkiraan_debet_per_tanggal(perkiraan_kode,'" & waktu_dk1 & "','" & waktu_dk2 & "') AS saldodebet2, hitung_saldo_perkiraan_kredit_per_tanggal(perkiraan_kode,'" & waktu_dk1 & "','" & waktu_dk2 & "') AS saldokredit2, hitung_saldo_perkiraan_akhir_per_tanggal(perkiraan_kode,'" & waktu_akhir1 & "','" & waktu_akhir2 & "') AS saldoakhir2,  hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml2 FROM kode_perkiraan WHERE perkiraan_parent='" & dt1.Rows(i1)("perkiraan_kode") & "'", koneksi)
                        dt2 = New DataTable
                        da2.Fill(dt2)
                        For i2 As Integer = 0 To dt2.Rows.Count - 1
                            saldo_awal = saldo_awal + dt2.Rows(i2)("saldoawal2")
                            saldo_debet = saldo_debet + dt2.Rows(i2)("saldodebet2")
                            saldo_kredit = saldo_kredit + dt2.Rows(i2)("saldokredit2")
                            saldo_akhir = saldo_akhir + dt2.Rows(i2)("saldoakhir2")

                            If dt2.Rows(i2)("jml2") > 0 Then
                                da3 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir_per_tanggal(perkiraan_kode,'" & waktu_awal1 & "','" & waktu_awal2 & "') AS saldoawal3, hitung_saldo_perkiraan_debet_per_tanggal(perkiraan_kode,'" & waktu_dk1 & "','" & waktu_dk2 & "') AS saldodebet3, hitung_saldo_perkiraan_kredit_per_tanggal(perkiraan_kode,'" & waktu_dk1 & "','" & waktu_dk2 & "') AS saldokredit3, hitung_saldo_perkiraan_akhir_per_tanggal(perkiraan_kode,'" & waktu_akhir1 & "','" & waktu_akhir2 & "') AS saldoakhir3, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml3 FROM kode_perkiraan WHERE perkiraan_parent='" & dt2.Rows(i2)("perkiraan_kode") & "'", koneksi)
                                dt3 = New DataTable
                                da3.Fill(dt3)
                                For i3 As Integer = 0 To dt3.Rows.Count - 1
                                    saldo_awal = saldo_awal + dt3.Rows(i3)("saldoawal3")
                                    saldo_debet = saldo_debet + dt3.Rows(i3)("saldodebet3")
                                    saldo_kredit = saldo_kredit + dt3.Rows(i3)("saldokredit3")
                                    saldo_akhir = saldo_akhir + dt3.Rows(i3)("saldoakhir3")

                                    If dt3.Rows(i3)("jml3") > 0 Then
                                        da4 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir_per_tanggal(perkiraan_kode,'" & waktu_awal1 & "','" & waktu_awal2 & "') AS saldoawal4, hitung_saldo_perkiraan_debet_per_tanggal(perkiraan_kode,'" & waktu_dk1 & "','" & waktu_dk2 & "') AS saldodebet4, hitung_saldo_perkiraan_kredit_per_tanggal(perkiraan_kode,'" & waktu_dk1 & "','" & waktu_dk2 & "') AS saldokredit4, hitung_saldo_perkiraan_akhir_per_tanggal(perkiraan_kode,'" & waktu_akhir1 & "','" & waktu_akhir2 & "') AS saldoakhir4, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml4 FROM kode_perkiraan WHERE perkiraan_parent='" & dt3.Rows(i3)("perkiraan_kode") & "'", koneksi)
                                        dt4 = New DataTable
                                        da4.Fill(dt4)
                                        For i4 As Integer = 0 To dt4.Rows.Count - 1
                                            saldo_awal = saldo_awal + dt4.Rows(i4)("saldoawal4")
                                            saldo_debet = saldo_debet + dt4.Rows(i4)("saldodebet4")
                                            saldo_kredit = saldo_kredit + dt4.Rows(i4)("saldokredit4")
                                            saldo_akhir = saldo_akhir + dt4.Rows(i4)("saldoakhir4")

                                            If dt4.Rows(i4)("jml4") > 0 Then
                                                da5 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir_per_tanggal(perkiraan_kode,'" & waktu_awal1 & "','" & waktu_awal2 & "') AS saldoawal5, hitung_saldo_perkiraan_debet_per_tanggal(perkiraan_kode,'" & waktu_dk1 & "','" & waktu_dk2 & "') AS saldodebet5, hitung_saldo_perkiraan_kredit_per_tanggal(perkiraan_kode,'" & waktu_dk1 & "','" & waktu_dk2 & "') AS saldokredit5, hitung_saldo_perkiraan_akhir_per_tanggal(perkiraan_kode,'" & waktu_akhir1 & "','" & waktu_akhir2 & "') AS saldoakhir5 FROM kode_perkiraan WHERE perkiraan_parent='" & dt4.Rows(i4)("perkiraan_kode") & "'", koneksi)
                                                dt5 = New DataTable
                                                da5.Fill(dt5)
                                                For i5 As Integer = 0 To dt5.Rows.Count - 1
                                                    saldo_awal = saldo_awal + dt5.Rows(i5)("saldoawal5")
                                                    saldo_debet = saldo_debet + dt5.Rows(i5)("saldodebet5")
                                                    saldo_kredit = saldo_kredit + dt5.Rows(i5)("saldokredit5")
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
            kd = dt.Rows(i)("perkiraan_kode")
            pilihan()


        Next
    End Sub

    Sub data_neraca()

        If TextBox3.Text = "harian" Then
            daa = New MySqlDataAdapter("SELECT perkiraan_kode, perkiraan_umum, perkiraan_nama, perkiraan_parent, perkiraan_d_or_k FROM kode_perkiraan WHERE perkiraan_umum IN('1','2','3') AND perkiraan_parent IN('1','1.190','1.160','1.310','1.250','1.280','1.290','1.300','1.301','1.306')", koneksi)
        ElseIf TextBox3.Text = "skontro" Then
            daa = New MySqlDataAdapter("SELECT perkiraan_kode, perkiraan_umum, perkiraan_nama, perkiraan_parent, perkiraan_d_or_k FROM kode_perkiraan WHERE perkiraan_umum IN('1','2','3')", koneksi)
        End If

        dtt = New DataTable
        daa.Fill(dtt)

        For ii As Integer = 0 To dtt.Rows.Count - 1
            jenis = ""
            For b As Integer = 1 To Format(DateTimePicker2.Value, "MM")
                saldo_awal = 0
                saldo_debet = 0
                saldo_kredit = 0
                saldo_akhir = 0

                Dim jm As Long
                jm = b
                bln = Format(jm, "0#")

                tglakhirbulan = DateSerial(Format(DateTimePicker2.Value, "yyyy"), bln + 1, 0) ' mengetahui tanggal pada akhir bulan
                If dtt(ii)("perkiraan_umum") = "2" Or dtt(ii)("perkiraan_umum") = "3" Then
                    For xxx As Integer = 0 To 99
                        LR(xxx) = 0
                    Next
                    perhitunglabarugitahunlalu()
                    perhitunglabarugitahunberjalan()
                End If


                saldo_awal = 0
                saldo_debet = 0
                saldo_kredit = 0
                saldo_akhir = 0
                'End If
                tgl1 = Format(tglakhirbulan, "yyyy").ToString + "-01-01 00:00:00"
                tgl2 = Format(tglakhirbulan, "yyyy-MM-dd").ToString + " 23:59:59"
                waktunow = Format(tglakhirbulan, "yyyy-MM-dd").ToString + " 23:59:59"

                kd = dtt.Rows(ii)("perkiraan_kode")
                If kd = "1.302" Or kd = "1.303" Or kd = "1.307" Or kd = "1.308" Then
                    pilihan()

                Else
                    da = New MySqlDataAdapter("SELECT perkiraan_kode, perkiraan_umum, perkiraan_type, perkiraan_parent, perkiraan_nama, perkiraan_d_or_k,   hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & tgl1 & "') AS saldoawal, hitung_saldo_perkiraan_debet_per_tanggal(perkiraan_kode,'" & tgl1 & "','" & tgl2 & "') AS saldodebet, hitung_saldo_perkiraan_kredit_per_tanggal(perkiraan_kode,'" & tgl1 & "','" & tgl2 & "') AS saldokredit, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS saldoakhir, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml FROM kode_perkiraan WHERE perkiraan_parent='" & dtt.Rows(ii)("perkiraan_kode") & "'", koneksi)
                    dt = New DataTable
                    da.Fill(dt)
                    For i As Integer = 0 To dt.Rows.Count - 1

                        saldo_awal = saldo_awal + dt.Rows(i)("saldoawal")
                        saldo_debet = saldo_debet + dt.Rows(i)("saldodebet")
                        saldo_kredit = saldo_kredit + dt.Rows(i)("saldokredit")
                        saldo_akhir = saldo_akhir + dt.Rows(i)("saldoakhir")

                        kd = dt.Rows(i)("perkiraan_kode")
                        If kd = "1.302" Or kd = "1.303" Or kd = "1.307" Or kd = "1.308" Then
                            pilihan()
                        Else
                            If dt.Rows(i)("jml") > 0 Then
                                da1 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & tgl1 & "') AS saldoawal1, hitung_saldo_perkiraan_debet_per_tanggal(perkiraan_kode,'" & tgl1 & "','" & tgl2 & "') AS saldodebet1, hitung_saldo_perkiraan_kredit_per_tanggal(perkiraan_kode,'" & tgl1 & "','" & tgl2 & "') AS saldokredit1, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS saldoakhir1, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml1 FROM kode_perkiraan WHERE perkiraan_parent='" & dt.Rows(i)("perkiraan_kode") & "'", koneksi)
                                dt1 = New DataTable
                                da1.Fill(dt1)
                                For i1 As Integer = 0 To dt1.Rows.Count - 1
                                    saldo_awal = saldo_awal + dt1.Rows(i1)("saldoawal1")
                                    saldo_debet = saldo_debet + dt1.Rows(i1)("saldodebet1")
                                    saldo_kredit = saldo_kredit + dt1.Rows(i1)("saldokredit1")
                                    saldo_akhir = saldo_akhir + dt1.Rows(i1)("saldoakhir1")

                                    kd = dt1.Rows(i1)("perkiraan_kode")
                                    If kd = "1.302" Or kd = "1.303" Or kd = "1.307" Or kd = "1.308" Then
                                        pilihan()
                                    Else
                                        If dt1.Rows(i1)("jml1") > 0 Then
                                            da2 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & tgl1 & "') AS saldoawal2, hitung_saldo_perkiraan_debet_per_tanggal(perkiraan_kode,'" & tgl1 & "','" & tgl2 & "') AS saldodebet2, hitung_saldo_perkiraan_kredit_per_tanggal(perkiraan_kode,'" & tgl1 & "','" & tgl2 & "') AS saldokredit2, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS saldoakhir2,  hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml2 FROM kode_perkiraan WHERE perkiraan_parent='" & dt1.Rows(i1)("perkiraan_kode") & "'", koneksi)
                                            dt2 = New DataTable
                                            da2.Fill(dt2)
                                            For i2 As Integer = 0 To dt2.Rows.Count - 1
                                                saldo_awal = saldo_awal + dt2.Rows(i2)("saldoawal2")
                                                saldo_debet = saldo_debet + dt2.Rows(i2)("saldodebet2")
                                                saldo_kredit = saldo_kredit + dt2.Rows(i2)("saldokredit2")
                                                saldo_akhir = saldo_akhir + dt2.Rows(i2)("saldoakhir2")
                                                kd = dt2.Rows(i2)("perkiraan_kode")
                                                If kd = "1.302" Or kd = "1.303" Or kd = "1.307" Or kd = "1.308" Then
                                                    pilihan()
                                                Else
                                                    If dt2.Rows(i2)("jml2") > 0 Then
                                                        da3 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & tgl1 & "') AS saldoawal3, hitung_saldo_perkiraan_debet_per_tanggal(perkiraan_kode,'" & tgl1 & "','" & tgl2 & "') AS saldodebet3, hitung_saldo_perkiraan_kredit_per_tanggal(perkiraan_kode,'" & tgl1 & "','" & tgl2 & "') AS saldokredit3, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS saldoakhir3, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml3 FROM kode_perkiraan WHERE perkiraan_parent='" & dt2.Rows(i2)("perkiraan_kode") & "'", koneksi)
                                                        dt3 = New DataTable
                                                        da3.Fill(dt3)
                                                        For i3 As Integer = 0 To dt3.Rows.Count - 1
                                                            saldo_awal = saldo_awal + dt3.Rows(i3)("saldoawal3")
                                                            saldo_debet = saldo_debet + dt3.Rows(i3)("saldodebet3")
                                                            saldo_kredit = saldo_kredit + dt3.Rows(i3)("saldokredit3")
                                                            saldo_akhir = saldo_akhir + dt3.Rows(i3)("saldoakhir3")
                                                            kd = dt3.Rows(i3)("perkiraan_kode")
                                                            If kd = "1.302" Or kd = "1.303" Or kd = "1.307" Or kd = "1.308" Then
                                                                pilihan()
                                                            Else
                                                                If dt3.Rows(i3)("jml3") > 0 Then
                                                                    da4 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & tgl1 & "') AS saldoawal4, hitung_saldo_perkiraan_debet_per_tanggal(perkiraan_kode,'" & tgl1 & "','" & tgl2 & "') AS saldodebet4, hitung_saldo_perkiraan_kredit_per_tanggal(perkiraan_kode,'" & tgl1 & "','" & tgl2 & "') AS saldokredit4, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS saldoakhir4, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml4 FROM kode_perkiraan WHERE perkiraan_parent='" & dt3.Rows(i3)("perkiraan_kode") & "'", koneksi)
                                                                    dt4 = New DataTable
                                                                    da4.Fill(dt4)
                                                                    For i4 As Integer = 0 To dt4.Rows.Count - 1
                                                                        saldo_awal = saldo_awal + dt4.Rows(i4)("saldoawal4")
                                                                        saldo_debet = saldo_debet + dt4.Rows(i4)("saldodebet4")
                                                                        saldo_kredit = saldo_kredit + dt4.Rows(i4)("saldokredit4")
                                                                        saldo_akhir = saldo_akhir + dt4.Rows(i4)("saldoakhir4")
                                                                        kd = dt4.Rows(i4)("perkiraan_kode")
                                                                        If kd = "1.302" Or kd = "1.303" Or kd = "1.307" Or kd = "1.308" Then
                                                                            pilihan()
                                                                        Else
                                                                            If dt4.Rows(i4)("jml4") > 0 Then
                                                                                da5 = New MySqlDataAdapter("SELECT perkiraan_kode, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & tgl1 & "') AS saldoawal5, hitung_saldo_perkiraan_debet_per_tanggal(perkiraan_kode,'" & tgl1 & "','" & tgl2 & "') AS saldodebet5, hitung_saldo_perkiraan_kredit_per_tanggal(perkiraan_kode,'" & tgl1 & "','" & tgl2 & "') AS saldokredit5, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktunow & "') AS saldoakhir5 FROM kode_perkiraan WHERE perkiraan_parent='" & dt4.Rows(i4)("perkiraan_kode") & "'", koneksi)
                                                                                dt5 = New DataTable
                                                                                da5.Fill(dt5)
                                                                                For i5 As Integer = 0 To dt5.Rows.Count - 1
                                                                                    saldo_awal = saldo_awal + dt5.Rows(i5)("saldoawal5")
                                                                                    saldo_debet = saldo_debet + dt5.Rows(i5)("saldodebet5")
                                                                                    saldo_kredit = saldo_kredit + dt5.Rows(i5)("saldokredit5")
                                                                                    saldo_akhir = saldo_akhir + dt5.Rows(i5)("saldoakhir5")
                                                                                Next
                                                                            End If
                                                                        End If
                                                                    Next
                                                                End If
                                                            End If
                                                        Next
                                                    End If
                                                End If
                                            Next
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If

                If kd = "2.270" Or kd = "2.280" Or kd = "2.310" Or kd = "2.320" Or kd = "2.330" Or kd = "2.340" Or kd = "2.360" Or kd = "2.370" Or kd = "1.301" Or kd = "1.302" Or kd = "1.303" Or kd = "1.306" Or kd = "1.307" Or kd = "1.308" Then
                    'If dt.Rows(i)("perkiraan_d_or_k") = "D" Then
                    'saldo_akhir = (Val(saldo_awal) + Val(saldo_debet)) - Val(saldo_kredit)
                    'Else
                    saldo_akhir = (Val(saldo_awal) + Val(saldo_kredit)) - Val(saldo_debet)
                    'End If
                End If
                bulan(b) = saldo_akhir
            Next




            Dim gabunganbulan As String = ""
            For bbb As Integer = 1 To 12
                gabunganbulan = gabunganbulan.ToString + ", '" & bulan(bbb) & "'"
            Next


            If dtt.Rows(ii)("perkiraan_umum") = "1" Then
                jenis = "1. AKTIVA"
            ElseIf dtt.Rows(ii)("perkiraan_umum") = "2" Or (dtt.Rows(ii)("perkiraan_umum") = "3" And Strings.Left(dtt.Rows(ii)("perkiraan_parent"), 1) = "1") Then
                jenis = "2. PASIVA"
            ElseIf dtt.Rows(ii)("perkiraan_umum") = "4" Then
                jenis = "1. PENDAPATAN"
            ElseIf dtt.Rows(ii)("perkiraan_umum") = "5" Then
                jenis = "2. BIAYA"
            ElseIf dtt.Rows(ii)("perkiraan_umum") = "3" Or dtt.Rows(ii)("perkiraan_umum") = "6" Then
                jenis = "3. LABARUGI"
            End If

            cd = New MySqlCommand("INSERT INTO temp_laporan_deret VALUES ('" & ii + 1 & "','" & dtt.Rows(ii)("perkiraan_kode") & "', '" & dtt.Rows(ii)("perkiraan_nama") & "', '" & dtt.Rows(ii)("perkiraan_kode").ToString.Split(".")(1) & "' " & gabunganbulan & " , '0', '" & jenis & "','" & MDIParent1.username.Text & "')", koneksi)
            cd.ExecuteNonQuery()

        Next
    End Sub



    Sub pilihan()
        If perhitungan = "tahun lalu" Then
            Select Case kd
                Case "2.360"
                    If LR(84) >= 0 Then
                        LR(83) = Val(LR(84))
                    End If

                Case "2.370"
                    If LR(84) < 0 Then
                        LR(82) = Val(LR(84))
                    End If
            End Select
        End If

        Select Case kd

            Case "2.100" 'pend op
                LR(1) = saldo_awal
                LR(2) = saldo_debet
                LR(3) = saldo_kredit
                LR(4) = saldo_akhir

            Case "2.150" 'beban op
                LR(5) = saldo_awal
                LR(6) = saldo_debet
                LR(7) = saldo_kredit
                LR(8) = saldo_akhir

                LR(99) = Val(LR(1)) - Val(LR(5)) 'saldo awal laba/rugi ops
                LR(98) = Val(Val(LR(3)) - Val(LR(2))) - Val(Val(LR(6)) - Val(LR(7))) 'debet/kredit ops ((p.kre-p.deb)-(b.deb-k.deb))

                'If LR(99) < 0 Then '-> saldo awal
                LR(97) = LR(99) ' jika rugi ops
                'Else
                'LR(97) = LR(99) 'jika laba ops
                'End If

                If LR(98) < 0 Then
                    LR(96) = LR(98)  'debet laba/rugi ops
                    LR(95) = 0 'kredit laba/rugi ops
                Else
                    LR(96) = 0 'debet laba/rugi ops
                    LR(95) = LR(98) 'kredit laba/rugi ops
                End If
            Case "2.290" 'pend non op
                LR(9) = saldo_awal
                LR(10) = saldo_debet
                LR(11) = saldo_kredit
                LR(12) = saldo_akhir

            Case "2.300" 'beban non op
                LR(13) = saldo_awal
                LR(14) = saldo_debet
                LR(15) = saldo_kredit
                LR(16) = saldo_akhir

                LR(94) = Val(LR(9)) - Val(LR(13)) 'saldo awal laba/rugi non ops
                LR(93) = Val(Val(LR(11)) - Val(LR(10))) - Val(Val(LR(14)) - Val(LR(15))) 'debet/kredit non ops ((p.kre-p.deb)-(b.deb-k.deb))

                'If LR(94) < 0 Then
                LR(92) = LR(94) 'jika rugi non ops
                'Else
                'LR(92) = LR(94) 'jika laba non ops
                'End If

                If LR(93) < 0 Then
                    LR(91) = LR(93) * (0 - 1)  'debet rugi non ops
                    LR(90) = 0 'kredit rugi non ops
                Else
                    LR(91) = 0 'debet laba non ops
                    LR(90) = LR(93) 'kredit laba non ops
                End If


                LR(89) = Val(LR(99)) + Val(LR(94)) ' saldo awal laba/rugi tahun berjalan
                LR(88) = Val(LR(98)) + Val(LR(93)) ' debet/kredit tahun berjalan

                'If LR(89) < 0 Then
                LR(87) = LR(89)  'jika rugi tahun berjalan
                'Else
                'LR(87) = LR(89) 'jika laba tahun berjalan
                'End If

                If LR(88) < 0 Then
                    LR(86) = LR(88)  'debet rugi tahun berjalan
                    LR(85) = 0 'kredit rugi tahun berjalan
                Else
                    LR(86) = 0 'debet laba tahun berjalan
                    LR(85) = LR(88) 'kredit laba thaun berjalan
                End If

            Case "2.270" 'laba operasional
                If LR(99) >= 0 Then
                    saldo_awal = LR(97)
                End If
                If LR(98) >= 0 Then
                    saldo_debet = LR(96)
                    saldo_kredit = LR(95)
                End If

            Case "2.280" ' rugi operasional
                If LR(99) < 0 Then
                    saldo_awal = LR(97)
                End If
                If LR(98) < 0 Then
                    saldo_debet = LR(96) * (0 - 1)
                    saldo_kredit = LR(95)
                End If

            Case "2.310" 'laba non operasional
                If LR(94) >= 0 Then
                    saldo_awal = LR(92)
                End If
                If LR(93) >= 0 Then
                    saldo_debet = LR(91)
                    saldo_kredit = LR(90)
                End If

            Case "2.320" 'rugi non operasional
                If LR(94) < 0 Then
                    saldo_awal = LR(92)
                End If
                If LR(93) < 0 Then
                    saldo_debet = LR(91)
                    saldo_kredit = LR(90)
                End If

            Case "2.330" 'laba tahun berjalan
                If LR(89) >= 0 Then
                    saldo_awal = LR(87)
                End If
                If LR(88) >= 0 Then
                    saldo_debet = LR(86)
                    saldo_kredit = LR(85)
                End If

                LR(21) = saldo_awal
                LR(22) = saldo_debet
                LR(23) = saldo_kredit
                LR(24) = Val(saldo_awal) + Val(saldo_debet) + Val(saldo_kredit)
            Case "2.340" 'rugi tahun berjalan
                If LR(89) < 0 Then
                    saldo_awal = LR(87)
                End If
                If LR(88) < 0 Then
                    saldo_debet = LR(86) * (0 - 1)
                    saldo_kredit = LR(85)
                End If

                LR(25) = saldo_awal
                LR(26) = saldo_debet
                LR(27) = saldo_kredit
                LR(28) = Val(saldo_awal) + Val(saldo_debet) + Val(saldo_kredit)
            Case "2.350" 'taksiran pajak penghasilan
                LR(17) = saldo_awal
                LR(18) = saldo_debet
                LR(19) = saldo_kredit
                LR(20) = saldo_akhir

                If LR(21) > 0 Then
                    LR(84) = LR(21) - LR(17)
                Else
                    LR(84) = LR(25) + LR(17)
                End If

            Case "2.360" 'jumlah laba 2
                If LR(84) >= 0 Then
                    saldo_awal = saldo_awal + Val(LR(84))
                End If
                saldo_kredit = saldo_kredit + Val(LR(19)) + Val(LR(23))

            Case "2.370" 'jumlah rugi 2
                If LR(84) < 0 Then
                    saldo_awal = saldo_awal + Val(LR(84))
                End If
                saldo_debet = saldo_debet + Val(Val(LR(18)) - Val(LR(26)) * (0 - 1))
            Case "1.302" 'laba tahun lalu
                If LR(84) >= 0 Then
                    saldo_awal = saldo_awal + Val(LR(83))
                End If

            Case "1.303" 'rugi tahun lalu
                If LR(84) < 0 Then
                    saldo_awal = saldo_awal + Val(LR(82))
                End If

            Case "1.307" 'laba tahun berjalan
                If LR(84) >= 0 Then
                    saldo_awal = saldo_awal + Val(LR(84))
                End If
                saldo_kredit = saldo_kredit + Val(LR(19)) + Val(LR(23))

            Case "1.308" 'rugi tahun berjalan
                If LR(84) < 0 Then
                    saldo_awal = saldo_awal + LR(84)
                End If
                saldo_debet = saldo_debet + Val(Val(LR(18)) + Val(LR(26)))

        End Select
    End Sub
End Class