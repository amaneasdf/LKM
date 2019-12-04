Imports MySql.Data.MySqlClient
Public Class cetak_rekening_koran

    Private Sub cetak_rekening_koran_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tno_rekening.Focus()
    End Sub

    Private Sub cetak_rekening_koran_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnbatal.PerformClick()
    End Sub

    Private Sub cetak_rekening_koran_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cetak_rekening_koran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = True
    End Sub

    Private Sub cetak_rekening_koran_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Me.Dispose()
    End Sub

    Private Sub tno_rekening_GotFocus(sender As Object, e As EventArgs) Handles tno_rekening.GotFocus
        tno_rekening.BackColor = warna_gotfocus
        btnhapus.BackColor = warna_gotfocus
    End Sub

    Private Sub tno_rekening_LostFocus(sender As Object, e As EventArgs) Handles tno_rekening.LostFocus
        tno_rekening.BackColor = warna_lostfocus
        btnhapus.BackColor = warna_lostfocus
        carirekening()
    End Sub

    Private Sub tno_rekening_TextChanged(sender As Object, e As EventArgs) Handles tno_rekening.TextChanged
        If Len(tno_rekening.Text) = 0 Then
            btnhapus.Visible = False
        Else
            btnhapus.Visible = True
        End If
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        tno_rekening.Clear()
        tno_rekening.Focus()
        carirekening()
    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click
        With pencarian_master_tabungan
            .Label4.Text = "rekening koran"
            .ShowDialog()
        End With
    End Sub
    Sub carirekening()
        cd = New MySqlCommand("SELECT cari_nama_rekening_tabungan(rek_tab_no_rekening) AS namanasabah, tab_stat_tanggal FROM data_tabungan_rekening JOIN data_tabungan_statement ON rek_tab_no_rekening=tab_stat_no_rekening WHERE rek_tab_no_rekening='" & tno_rekening.Text & "' GROUP BY rek_tab_no_rekening", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tnama_nasabah.Text = rd.Item("namanasabah")
            DateTimePicker1.Value = rd.Item("tab_stat_tanggal")
            DateTimePicker1.MinDate = Format(rd.Item("tab_stat_tanggal"), "dd/MM/yyyy")
            DateTimePicker2.MinDate = Format(rd.Item("tab_stat_tanggal"), "dd/MM/yyyy")
        Catch ex As Exception
            tnama_nasabah.Text = ""
            DateTimePicker1.Value = MDIParent1.DateTimePicker1.Value
            DateTimePicker2.Value = MDIParent1.DateTimePicker1.Value
            DateTimePicker1.MinDate = "01/01/1753"
            DateTimePicker2.MinDate = "01/01/1753"
        End Try
        rd.Close()
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        If tno_rekening.Text = "" And tnama_nasabah.Text = "" Then
            MessageBox.Show("Nomor Rekening harus diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tno_rekening.Focus()
            Exit Sub
        ElseIf DateTimePicker1.Value > DateTimePicker2.Value Then
            MessageBox.Show("Pilihan tanggal salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
            Exit Sub
        Else
            With form_rekening_koran
                .DateTimePicker1.Value = DateTimePicker1.Value
                .DateTimePicker2.Value = DateTimePicker2.Value
                .TextBox1.Text = tno_rekening.Text
                .TextBox2.Text = MDIParent1.username.Text
                .ShowDialog()
            End With
        End If
    End Sub
End Class