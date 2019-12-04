Imports MySql.Data.MySqlClient
Public Class afiliasi
    Public norek, nama As String
    Private Sub afiliasi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnkeluar.PerformClick()
    End Sub

    Private Sub afiliasi_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.F9 Then
            datakosong()
        End If
    End Sub

    Private Sub afiliasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = True
        ukuran()

        data()
    End Sub

    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Jenis", 100, HorizontalAlignment.Left)
            .Add("No Rekening", 100, HorizontalAlignment.Left)
            .Add("Nama", 100, HorizontalAlignment.Left)
            .Add("Alamat", 100, HorizontalAlignment.Left)
            .Add("Status", 100, HorizontalAlignment.Left)
        End With
    End Sub
    Sub data()
        If Label3.Text = "kolektor" Then
            da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, nasabah_nama1, nasabah_alamat, rek_tab_status FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id WHERE rek_tab_kode_kolektor='" & tkode.Text & "'", koneksi)
        ElseIf Label3.Text = "marketing" Then
            da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, nasabah_nama1, nasabah_alamat, rek_tab_status FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id WHERE rek_tab_kode_marketing='" & tkode.Text & "'", koneksi)
        ElseIf Label3.Text = "instansi" Then
            da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, nasabah_nama1, nasabah_alamat, rek_tab_status FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id WHERE rek_tab_kode_instansi='" & tkode.Text & "'", koneksi)
        ElseIf Label3.Text = "wilayah" Then
            da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, nasabah_nama1, nasabah_alamat, rek_tab_status FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id WHERE rek_tab_kode_wilayah='" & tkode.Text & "'", koneksi)
        End If

        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add("TAB")
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("rek_tab_no_rekening"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_nama1"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_alamat"))
                Select Case dt.Rows(i)("rek_tab_status")
                    Case "0"
                        .Items(.Items.Count - 1).SubItems().Add("NONE")
                    Case "1"
                        .Items(.Items.Count - 1).SubItems().Add("AKTIF")
                    Case "2"
                        .Items(.Items.Count - 1).SubItems().Add("BLOKIR")
                    Case "4"
                        .Items(.Items.Count - 1).SubItems().Add("TUTUP")
                End Select

            Next
        End With
    End Sub

    Sub datakosong()
        If Label3.Text = "kolektor" Then
            da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, nasabah_nama1, nasabah_alamat, rek_tab_status FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id WHERE rek_tab_kode_kolektor=''", koneksi)
        ElseIf Label3.Text = "marketing" Then
            da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, nasabah_nama1, nasabah_alamat, rek_tab_status FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id WHERE rek_tab_kode_marketing=''", koneksi)
        ElseIf Label3.Text = "instansi" Then
            da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, nasabah_nama1, nasabah_alamat, rek_tab_status FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id WHERE rek_tab_kode_instansi=''", koneksi)
        ElseIf Label3.Text = "wilayah" Then
            da = New MySqlDataAdapter("SELECT rek_tab_no_rekening, nasabah_nama1, nasabah_alamat, rek_tab_status FROM data_tabungan_rekening JOIN data_nasabah ON rek_tab_nasabah_id=nasabah_id WHERE rek_tab_kode_wilayah=''", koneksi)
        End If

        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add("TAB")
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("rek_tab_no_rekening"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_nama1"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("nasabah_alamat"))
                Select Case dt.Rows(i)("rek_tab_status")
                    Case "0"
                        .Items(.Items.Count - 1).SubItems().Add("NONE")
                    Case "1"
                        .Items(.Items.Count - 1).SubItems().Add("AKTIF")
                    Case "2"
                        .Items(.Items.Count - 1).SubItems().Add("BLOKIR")
                    Case "4"
                        .Items(.Items.Count - 1).SubItems().Add("TUTUP")
                End Select

            Next
        End With
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub afiliasi_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        listselect()
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown

        If e.KeyCode = Keys.F3 Then
            With pindah_afiliasi
                If Label3.Text = "kolektor" Then
                    .Label3.Text = "kolektor"
                ElseIf Label3.Text = "marketing" Then
                    .Label3.Text = "marketing"
                ElseIf Label3.Text = "instansi" Then
                    .Label3.Text = "instansi"
                ElseIf Label3.Text = "wilayah" Then
                    .Label3.Text = "wilayah"
                End If
                .tno_rekening.Text = norek
                .tnama_nasabah.Text = nama
                .ShowDialog()
            End With
        ElseIf e.KeyCode = Keys.F4 Then

            If MessageBox.Show("Yakin ingin menghapus data Afiliasi ini?", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                If Label3.Text = "kolektor" Then
                    cd = New MySqlCommand("UPDATE data_tabungan_rekening SET rek_tab_kode_kolektor='' WHERE rek_tab_no_rekening='" & norek & "' ", koneksi)
                    cd.ExecuteNonQuery()
                    uraian = "Memindahkan data Kolektor (rek_tab_no_rekening : " + norek + ")"
                ElseIf Label3.Text = "marketing" Then
                    cd = New MySqlCommand("UPDATE data_tabungan_rekening SET rek_tab_kode_marketing='' WHERE rek_tab_no_rekening='" & norek & "' ", koneksi)
                    cd.ExecuteNonQuery()
                    uraian = "Memindahkan data Marketing (rek_tab_no_rekening : " + norek + ")"
                ElseIf Label3.Text = "instansi" Then
                    cd = New MySqlCommand("UPDATE data_tabungan_rekening SET rek_tab_kode_instansi='' WHERE rek_tab_no_rekening='" & norek & "' ", koneksi)
                    cd.ExecuteNonQuery()
                    uraian = "Memindahkan data Instansi (rek_tab_no_rekening : " + norek + ")"
                ElseIf Label3.Text = "wilayah" Then
                    cd = New MySqlCommand("UPDATE data_tabungan_rekening SET rek_tab_kode_wilayah='' WHERE rek_tab_no_rekening='" & norek & "' ", koneksi)
                    cd.ExecuteNonQuery()
                    uraian = "Memindahkan data Wilayah (rek_tab_no_rekening : " + norek + ")"
                End If
                data()
                user_pengguna = MDIParent1.username.Text
                insert_log_user()
            End If
            
        ElseIf e.KeyCode = Keys.F9 Then
            datakosong()
        End If

    End Sub

    Sub listselect()
        With ListView1.SelectedItems.Item(0)
            norek = .SubItems(1).Text
            nama = .SubItems(2).Text
        End With
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            listselect()
        Catch ex As Exception

        End Try
    End Sub
End Class