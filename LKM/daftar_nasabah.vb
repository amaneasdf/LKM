Imports MySql.Data.MySqlClient
Public Class daftar_nasabah
    
    Private Sub daftar_nasabah_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub daftar_nasabah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()

        Me.ResizeRedraw = True
        combo()
    End Sub

    Sub combo()
        With cmbrekening.Items
            .Clear()
            .Add("1 : SEMUA REKENING")
            .Add("2 : HANYA REK TABUNGAN")
            '.Add("3 : HANYA REK DEPOSITO")
            .Add("4 : HANYA REK KREDIT")
            '.Add("5 : HANYA REK TAB & DEP")
            '.Add("6 : HANYA REK TAB & KRE")
            '.Add("7 : HANYA REK DEP & KRE")
            '.Add("8 : PUNYA SEMUA REK")
        End With
        cmbrekening.SelectedIndex = 0

        With cmburutkan_data.Items
            .Clear()
            .Add("1 : NASABAH ID")
            .Add("2 : NAMA NASABAH")
        End With
        cmburutkan_data.SelectedIndex = 0

    End Sub

    Private Sub daftar_nasabah_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Me.Dispose()
    End Sub

    Private Sub cmbrekening_GotFocus(sender As Object, e As EventArgs) Handles cmbrekening.GotFocus, cmburutkan_data.GotFocus
        sender.backcolor = warna_gotfocus
    End Sub

    Private Sub cmbrekening_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbrekening.KeyPress, cmburutkan_data.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbrekening_LostFocus(sender As Object, e As EventArgs) Handles cmbrekening.LostFocus, cmburutkan_data.LostFocus
        sender.backcolor = warna_lostfocus
    End Sub

    Private Sub cmbrekening_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbrekening.SelectedIndexChanged

    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        If DateTimePicker1.Checked = False Then
            MessageBox.Show("Tanggal harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
            Exit Sub
        End If
        laporan_daftar_nasabah.ShowDialog()
    End Sub

    
End Class