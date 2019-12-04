Imports MySql.Data.MySqlClient
Public Class cetak_rincian_mutasi_saldo

    Private Sub cetak_rincian_mutasi_saldo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnbatal.PerformClick()
    End Sub

    Private Sub cetak_rincian_mutasi_saldo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cetak_rincian_mutasi_saldo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        Me.ResizeRedraw = True
        DateTimePicker1.Value = Format(Now, "yyyy").ToString + "-01-01"
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Me.Dispose()
    End Sub

    Private Sub tkode_perkiraan_GotFocus(sender As Object, e As EventArgs) Handles tkode_perkiraan.GotFocus
        tkode_perkiraan.BackColor = warna_gotfocus
    End Sub

    Private Sub tkode_perkiraan_LostFocus(sender As Object, e As EventArgs) Handles tkode_perkiraan.LostFocus
        tkode_perkiraan.BackColor = warna_lostfocus
        cariperkiraan()
    End Sub

    Private Sub cetak_rincian_mutasi_saldo_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click
        With pencarian_perkiraan
            .Label4.Text = "cetak_rincian_mutasi_saldo"
            .ShowDialog()
        End With
    End Sub
    Sub cariperkiraan()
        cd = New MySqlCommand("SELECT perkiraan_nama FROM kode_perkiraan WHERE perkiraan_kode='" & tkode_perkiraan.Text & "' AND perkiraan_status='1'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_perkiraan.Text = rd.Item("perkiraan_nama")
        Catch ex As Exception
            tnama_perkiraan.Clear()
        End Try
        rd.Close()
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        If tnama_perkiraan.Text = "" Then
            MessageBox.Show("Nama Perkiraan belum diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode_perkiraan.Focus()
            Exit Sub
        End If
        pilih()
    End Sub
    Sub pilih()
        With laporan_rincian_mutasi
            .DateTimePicker1.Value = DateTimePicker1.Value
            .DateTimePicker2.Value = DateTimePicker2.Value
            .TextBox1.Text = "LAPORAN MUTASI (" + tkode_perkiraan.Text + " : " + tnama_perkiraan.Text + ") PER PERIODE"
            .TextBox2.Text = tkode_perkiraan.Text
            .ShowDialog()
        End With
    End Sub
End Class