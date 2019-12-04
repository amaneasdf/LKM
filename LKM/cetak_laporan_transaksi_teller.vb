Imports MySql.Data.MySqlClient
Public Class cetak_laporan_transaksi_teller

    Private Sub cetak_laporan_transaksi_teller_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        DateTimePicker1.Focus()
    End Sub

    Private Sub cetak_laporan_transaksi_teller_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnbatal.PerformClick()
    End Sub

    Private Sub cetak_laporan_transaksi_teller_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cetak_laporan_transaksi_teller_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        combo()
        text_selected()
        Me.ResizeRedraw = True
        DateTimePicker1.MaxDate = DateTimePicker2.Value
        DateTimePicker2.MinDate = DateTimePicker1.Value
    End Sub

    Private Sub cetak_laporan_transaksi_teller_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Me.Dispose()
    End Sub

    Private Sub cmbjenis_laporan_GotFocus(sender As Object, e As EventArgs) Handles cmbjenis_transaksi.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbjenis_laporan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbjenis_transaksi.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbjenis_laporan_LostFocus(sender As Object, e As EventArgs) Handles cmbjenis_transaksi.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub cmbjenis_laporan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjenis_transaksi.SelectedIndexChanged
        text_selected()
    End Sub

    Sub combo()
        With cmbjenis_transaksi.Items
            .Clear()
            .Add("01 : JURNAL KAS")
            .Add("02 : JURNAL NON KAS")
        End With
    End Sub

    Sub text_selected()
        Dim jenis_laporan As String = ""
        If cmbjenis_transaksi.Text.ToString.Split(" : ")(0) = "01" Then
            jenis_laporan = " v_jurnal_kas "
        Else
            jenis_laporan = " v_jurnal_nonkas "
        End If

        TextBox1.Text = "SELECT * FROM ".ToString + jenis_laporan.ToString + " WHERE (jurnal_tanggal BETWEEN '" + Format(DateTimePicker1.Value, "yyyy-MM-dd") + "' AND '" + Format(DateTimePicker2.Value, "yyyy-MM-dd") + "') ORDER BY jurnal_waktu ASC"
    End Sub

    Private Sub cmbusername_SelectedIndexChanged(sender As Object, e As EventArgs)
        text_selected()

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        text_selected()
        DateTimePicker1.MaxDate = DateTimePicker2.Value
        DateTimePicker2.MinDate = DateTimePicker1.Value
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        text_selected()
        DateTimePicker1.MaxDate = DateTimePicker2.Value
        DateTimePicker2.MinDate = DateTimePicker1.Value
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        If cmbjenis_transaksi.Text = "" Then
            MessageBox.Show("Jenis Transaksi harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbjenis_transaksi.Focus()
            Exit Sub
        End If
        If cmbjenis_transaksi.Text.ToString.Split(" : ")(0) = "01" Then
            laporan_transaksi_kas.ShowDialog()
        ElseIf cmbjenis_transaksi.Text.ToString.Split(" : ")(0) = "02" Then
            laporan_transaksi_nonkas.ShowDialog()
        End If
    End Sub
End Class