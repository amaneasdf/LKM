Imports MySql.Data.MySqlClient
Public Class browse_transaksi

    Private Sub browse_transaksi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub browse_transaksi_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        End If
    End Sub

    Private Sub browse_transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = True
    End Sub

    Private Sub browse_transaksi_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Me.Dispose()
    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click
        pencarian_teller.ShowDialog()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        tnama_username.Clear()
        tusername.Clear()
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        If Label5.Text = "transaksi tabungan" Then
            With browser_transaksi_tabungan
                .ukuran1()
                .ukuran2()
                .TextBox1.Text = tusername.Text
                .DateTimePicker1.Value = DateTimePicker1.Value
                .DateTimePicker2.Value = DateTimePicker2.Value
                '.tampil()
                .StartPosition = FormStartPosition.Manual
                .MdiParent = MDIParent1
                .Show()
                Me.Dispose()
            End With
        ElseIf Label5.Text = "transaksi pencairan" Then
            With browse_transaksi_realisasi
                .ukuran1()
                .ukuran2()
                .TextBox1.Text = tusername.Text
                .DateTimePicker1.Value = DateTimePicker1.Value
                .DateTimePicker2.Value = DateTimePicker2.Value
                '.tampil()
                .StartPosition = FormStartPosition.Manual
                .MdiParent = MDIParent1
                .Show()
                Me.Dispose()
            End With
        ElseIf Label5.Text = "transaksi angsuran kredit" Then
            With browse_angsuran_kredit
                .ukuran1()
                .ukuran2()
                .TextBox1.Text = tusername.Text
                .DateTimePicker1.Value = DateTimePicker1.Value
                .DateTimePicker2.Value = DateTimePicker2.Value
                '.tampil()
                .StartPosition = FormStartPosition.Manual
                .MdiParent = MDIParent1
                .Show()
                Me.Dispose()
            End With
        ElseIf Label5.Text = "transaksi jurnal kas" Then
            With browse_transaksi_jurnal_kas
                .ukuran1()
                .ukuran2()
                .TextBox1.Text = tusername.Text
                .DateTimePicker1.Value = DateTimePicker1.Value
                .DateTimePicker2.Value = DateTimePicker2.Value
                '.tampil()
                .StartPosition = FormStartPosition.Manual
                .MdiParent = MDIParent1
                .Show()
                Me.Dispose()
            End With
        ElseIf Label5.Text = "transaksi jurnal non kas" Then
            With browse_transaksi_jurnal_non_kas
                .ukuran1()
                .ukuran2()
                .TextBox1.Text = tusername.Text
                .DateTimePicker1.Value = DateTimePicker1.Value
                .DateTimePicker2.Value = DateTimePicker2.Value
                '.tampil()
                .StartPosition = FormStartPosition.Manual
                .MdiParent = MDIParent1
                .Show()
                Me.Dispose()
            End With
        ElseIf Label5.Text = "laporan buku besar" Then
            With laporan_buku_besar
                .ukuran1()
                .TextBox1.Text = tusername.Text
                .DateTimePicker1.Value = DateTimePicker1.Value
                .DateTimePicker2.Value = DateTimePicker2.Value
                ' .tampil()
                .StartPosition = FormStartPosition.Manual
                .MdiParent = MDIParent1
                .Show()
                Me.Dispose()
            End With
        End If
    End Sub
End Class