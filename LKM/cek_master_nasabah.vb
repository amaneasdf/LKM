Imports MySql.Data.MySqlClient
Public Class cek_master_nasabah

    Private Sub tnik_GotFocus(sender As Object, e As EventArgs) Handles tnik.GotFocus, tnama.GotFocus, cmbsex.GotFocus, tkode_kota.GotFocus, cmbkota.GotFocus, tnama_ibu.GotFocus

        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tnama_KeyDown(sender As Object, e As KeyEventArgs) Handles tnama.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbsex.Focus()
        End If
    End Sub

    Private Sub tkode_kota_KeyDown(sender As Object, e As KeyEventArgs) Handles tkode_kota.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbkota.Focus()
        End If
    End Sub

    Private Sub cmbkota_LostFocus(sender As Object, e As EventArgs) Handles cmbkota.LostFocus, tnama.LostFocus, tnik.LostFocus, cmbsex.LostFocus, tkode_kota.LostFocus, tnama_ibu.LostFocus

        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        kosong()
        Me.Dispose()
    End Sub
    Sub combo()
        rd.Close()
        cd = New MySqlCommand("CALL isi_combo('02')", koneksi)
        rd = cd.ExecuteReader
        With cmbsex.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()

        cd = New MySqlCommand("CALL isi_combo('09')", koneksi)
        rd = cd.ExecuteReader
        With cmbkota.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("text"))
            End While
        End With
        rd.Close()
    End Sub
    Sub def()
        cd = New MySqlCommand("SELECT * FROM sys_komponen WHERE komp_tag='Dati2'", koneksi) 'menampilkan defaultnya
        rd = cd.ExecuteReader
        rd.Read()
        tkode_kota.Text = rd.Item("komp_default")
        rd.Close()
        carikode()
    End Sub

    Private Sub cek_master_nasabah_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tnik.Focus()
    End Sub

    Private Sub cek_master_nasabah_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        End If
    End Sub


    Private Sub cek_master_nasabah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        kosong()
        combo()
        def()
        Me.ResizeRedraw = True
        tanggal.MaxDate = Format(MDIParent1.DateTimePicker1.Value, "dd MMMM yyyy")
    End Sub

    Private Sub tnik_KeyDown(sender As Object, e As KeyEventArgs) Handles tnik.KeyDown
        If e.KeyCode = Keys.Enter Then
            ceknik()
        End If
    End Sub

    Sub ceknik()
        cd = New MySqlCommand("SELECT * FROM data_nasabah WHERE nasabah_nik='" & tnik.Text & "'", koneksi) 'mengecek nik
        rd = cd.ExecuteReader
        rd.Read()
        If rd.HasRows = True Then
            With data_nasabah_perorangan
                .tnasabah_id.Text = rd.Item("nasabah_id")
                rd.Close()
                .cekdatanasabah()
                .ShowDialog()
            End With
        Else
            rd.Close()
            If Len(tnik.Text) > 0 And Len(tnik.Text) < 16 Then
                MessageBox.Show("NIK tidak valid. Periksa kembali format NIK atau kosongkan NIK.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                tnik.Enabled = False
                tnama.Enabled = True
                cmbsex.Enabled = True
                tkode_kota.Enabled = True
                cmbkota.Enabled = True
                tanggal.Enabled = True
                tnama_ibu.Enabled = True
                'tnama.Focus()
                tnama.Focus()
            End If
        End If
    End Sub

    Private Sub tnik_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tnik.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub tnama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tnama_ibu.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z,a-z]" _
            OrElse KeyAscii = Keys.Back _
            OrElse KeyAscii = Keys.Space _
            OrElse KeyAscii = Keys.Return _
            OrElse KeyAscii = Keys.Delete) Then
            KeyAscii = 0
        End If
        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub tkode_kota_LostFocus(sender As Object, e As EventArgs) Handles tkode_kota.LostFocus
        carikode()
    End Sub

    Private Sub cmbkota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbkota.KeyPress, cmbsex.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbkota_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbkota.SelectedIndexChanged
        tkode_kota.Text = cmbkota.Text.ToString.Split(" :")(0)
        Try
            carikode()
        Catch ex As Exception

        End Try
        'carikode()
    End Sub

    Private Sub btnbaru_Click(sender As Object, e As EventArgs) Handles btnbaru.Click
        kosong()
        def()
    End Sub
    Sub kosong()
        tnik.Clear()
        tnama.Clear()
        cmbsex.Text = ""
        tkode_kota.Clear()
        tnama_kota.Clear()
        tnama_ibu.Clear()
        tnik.Enabled = True
        tnama.Enabled = False
        cmbsex.Enabled = False
        tkode_kota.Enabled = False
        cmbkota.Enabled = False
        tanggal.Enabled = False
        tanggal.Checked = False
        tnama_ibu.Enabled = False
        tnik.Focus()
    End Sub
    Sub carikode()
        cd = New MySqlCommand("SELECT text AS kabkot, combo_text FROM v_combo_komponen WHERE combo_komponen='09' AND combo_kode='" & tkode_kota.Text & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            cmbkota.Text = rd.Item("kabkot")
            tnama_kota.Text = rd.Item("combo_text").ToString.Split(",")(0)
        Catch ex As Exception
            cmbkota.Text = ""
            tnama_kota.Text = ""
        End Try
        rd.Close()
    End Sub

    Private Sub cek_master_nasabah_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnlanjut_Click(sender As Object, e As EventArgs) Handles btnlanjut.Click
        If tnik.Text = "" And tnik.Enabled = True Then
            MessageBox.Show("NIK harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnik.Focus()
        Else
            If tnama.Text = "" Or cmbsex.Text = "" Or tnama_kota.Text = "" Or tnama_ibu.Text = "" Or tanggal.Checked = False Then
                If tnama.Text = "" Then
                    MessageBox.Show("Nama Nasabah harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    tnama.Focus()
                    Exit Sub
                ElseIf cmbsex.Text = "" Then
                    MessageBox.Show("Jenis Kelamin harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    cmbsex.Focus()
                    Exit Sub
                ElseIf tnama_kota.Text = "" Then
                    MessageBox.Show("Tempat lahir harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    cmbkota.Focus()
                    Exit Sub
                ElseIf tanggal.Checked = False Then
                    MessageBox.Show("Tanggal lahir belum dikonfirmasi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    tanggal.Focus()
                    Exit Sub
                ElseIf tnama_ibu.Text = "" Then
                    MessageBox.Show("Nama Gadis Ibu Kandung harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    tnama_ibu.Focus()
                    Exit Sub
                End If
            Else
                With data_nasabah_perorangan
                    .kosong()
                    .tnama.Text = tnama.Text
                    .cmbsex.Text = cmbsex.Text
                    .tnik.Text = tnik.Text
                    .tkota.Text = tnama_kota.Text
                    .tnama_ibu.Text = tnama_ibu.Text
                    .DateTimePicker1.Value = tanggal.Value
                    .DateTimePicker1.Checked = True
                    rd.Close()

                    .ShowDialog()
                    Hide()
                End With
            End If
        End If
    End Sub

    Private Sub cmbsex_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbsex.KeyDown
        If e.KeyCode = Keys.Enter Then
            tkode_kota.Focus()
        End If
    End Sub

    Private Sub tanggal_KeyDown(sender As Object, e As KeyEventArgs) Handles tanggal.KeyDown
        If e.KeyCode = Keys.Enter Then
            tnama_ibu.Focus()
        End If
    End Sub

    Private Sub tnama_ibu_KeyDown(sender As Object, e As KeyEventArgs) Handles tnama_ibu.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnlanjut.Focus()
        End If
    End Sub

    Private Sub cmbkota_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbkota.KeyDown
        If e.KeyCode = Keys.Enter Then
            tanggal.Focus()
        End If
    End Sub

    Private Sub tkode_kota_TextChanged(sender As Object, e As EventArgs) Handles tkode_kota.TextChanged

    End Sub
End Class