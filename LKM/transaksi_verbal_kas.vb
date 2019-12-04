Imports MySql.Data.MySqlClient
Public Class transaksi_verbal_kas
    Dim waktu_awal, waktu_akhir As String
    Dim modal_awal, saldo_akhir As String

    Public da1, da2, da3, da4, da5 As MySqlDataAdapter
    Public dt1, dt2, dt3, dt4, dt5 As DataTable
    Dim pecahan(99), fisik(99), nominal(99) As String

    Private Sub transaksi_verbal_kas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub transaksi_verbal_kas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        Me.ResizeRedraw = True
        combo()
        kosong()
        carimodalawal_dan_saldoakhir()
        caripenerimaan_dan_pengeluaran()
        cek()
    End Sub

    Sub combo()
        With cmbjenis_transaksi.Items
            .Clear()
            .Add("01 : Kas")
        End With
        cmbjenis_transaksi.SelectedIndex = 0

        With cmbmodel_entry.Items
            .Clear()
            .Add("01 : ENTRY JUMLAH FISIK")
            .Add("02 : ENTRY NOMINAL")
        End With
        cmbmodel_entry.SelectedIndex = 0

    End Sub

    Sub logam_fisik_on()
        t1000_logam1.Enabled = True
        t500_logam1.Enabled = True
        t200_logam1.Enabled = True
        t100_logam1.Enabled = True
        t50_logam1.Enabled = True
        t25_logam1.Enabled = True
        t10_logam1.Enabled = True
        t5_logam1.Enabled = True
        t1_logam1.Enabled = True
    End Sub

    Sub logam_fisik_off()
        t1000_logam1.Enabled = False
        t500_logam1.Enabled = False
        t200_logam1.Enabled = False
        t100_logam1.Enabled = False
        t50_logam1.Enabled = False
        t25_logam1.Enabled = False
        t10_logam1.Enabled = False
        t5_logam1.Enabled = False
        t1_logam1.Enabled = False
    End Sub

    Sub logam_nominal_on()
        t1000_logam2.Enabled = True
        t500_logam2.Enabled = True
        t200_logam2.Enabled = True
        t100_logam2.Enabled = True
        t50_logam2.Enabled = True
        t25_logam2.Enabled = True
        t10_logam2.Enabled = True
        t5_logam2.Enabled = True
        t1_logam2.Enabled = True
    End Sub

    Sub logam_nominal_off()
        t1000_logam2.Enabled = False
        t500_logam2.Enabled = False
        t200_logam2.Enabled = False
        t100_logam2.Enabled = False
        t50_logam2.Enabled = False
        t25_logam2.Enabled = False
        t10_logam2.Enabled = False
        t5_logam2.Enabled = False
        t1_logam2.Enabled = False
    End Sub

    Sub kertas_fisik_on()
        t100000_kertas1.Enabled = True
        t50000_kertas1.Enabled = True
        t20000_kertas1.Enabled = True
        t10000_kertas1.Enabled = True
        t5000_kertas1.Enabled = True
        t2000_kertas1.Enabled = True
        t1000_kertas1.Enabled = True
        t500_kertas1.Enabled = True
        t100_kertas1.Enabled = True
    End Sub

    Sub kertas_fisik_off()
        t100000_kertas1.Enabled = False
        t50000_kertas1.Enabled = False
        t20000_kertas1.Enabled = False
        t10000_kertas1.Enabled = False
        t5000_kertas1.Enabled = False
        t2000_kertas1.Enabled = False
        t1000_kertas1.Enabled = False
        t500_kertas1.Enabled = False
        t100_kertas1.Enabled = False
    End Sub

    Sub kertas_nominal_on()
        t100000_kertas2.Enabled = True
        t50000_kertas2.Enabled = True
        t20000_kertas2.Enabled = True
        t10000_kertas2.Enabled = True
        t5000_kertas2.Enabled = True
        t2000_kertas2.Enabled = True
        t1000_kertas2.Enabled = True
        t500_kertas2.Enabled = True
        t100_kertas2.Enabled = True
    End Sub

    Sub kertas_nominal_off()
        t100000_kertas2.Enabled = False
        t50000_kertas2.Enabled = False
        t20000_kertas2.Enabled = False
        t10000_kertas2.Enabled = False
        t5000_kertas2.Enabled = False
        t2000_kertas2.Enabled = False
        t1000_kertas2.Enabled = False
        t500_kertas2.Enabled = False
        t100_kertas2.Enabled = False
    End Sub

    Private Sub transaksi_verbal_kas_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Me.Dispose()
    End Sub

    Private Sub cmbjenis_transaksi_GotFocus(sender As Object, e As EventArgs) Handles cmbjenis_transaksi.GotFocus, cmbmodel_entry.GotFocus, t1000_logam1.GotFocus, t1000_logam2.GotFocus, t500_logam1.GotFocus, t500_logam2.GotFocus, t200_logam1.GotFocus, t200_logam2.GotFocus, t100_logam1.GotFocus, t100_logam2.GotFocus, t50_logam1.GotFocus, t50_logam2.GotFocus, t25_logam1.GotFocus, t25_logam2.GotFocus, t10_logam1.GotFocus, t10_logam2.GotFocus, t5_logam1.GotFocus, t5_logam2.GotFocus, t1_logam1.GotFocus, t1_logam2.GotFocus, t100000_kertas1.GotFocus, t100000_kertas2.GotFocus, t50000_kertas1.GotFocus, t50000_kertas2.GotFocus, t20000_kertas1.GotFocus, t20000_kertas2.GotFocus, t10000_kertas1.GotFocus, t10000_kertas2.GotFocus, t5000_kertas1.GotFocus, t5000_kertas2.GotFocus, t2000_kertas1.GotFocus, t2000_kertas2.GotFocus, t1000_kertas1.GotFocus, t1000_kertas2.GotFocus, t500_kertas1.GotFocus, t500_kertas2.GotFocus, t100_kertas1.GotFocus, t100_kertas2.GotFocus

        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub t1000_logam1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t1000_logam1.KeyPress, t500_logam1.KeyPress, t200_logam1.KeyPress, t100_logam1.KeyPress, t50_logam1.KeyPress, t25_logam1.KeyPress, t10_logam1.KeyPress, t5_logam1.KeyPress, t1_logam1.KeyPress, t100000_kertas1.KeyPress, t50000_kertas1.KeyPress, t20000_kertas1.KeyPress, t10000_kertas1.KeyPress, t5000_kertas1.KeyPress, t2000_kertas1.KeyPress, t1000_kertas1.KeyPress, t500_kertas1.KeyPress, t100_kertas1.KeyPress, t1000_logam2.KeyPress, t500_logam2.KeyPress, t200_logam2.KeyPress, t100_logam2.KeyPress, t50_logam2.KeyPress, t25_logam2.KeyPress, t10_logam2.KeyPress, t5_logam2.KeyPress, t1_logam2.KeyPress, t100000_kertas2.KeyPress, t50000_kertas2.KeyPress, t20000_kertas2.KeyPress, t10000_kertas2.KeyPress, t5000_kertas2.KeyPress, t2000_kertas2.KeyPress, t1000_kertas2.KeyPress, t500_kertas2.KeyPress, t100_kertas2.KeyPress

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub cmbjenis_transaksi_LostFocus(sender As Object, e As EventArgs) Handles cmbjenis_transaksi.LostFocus, cmbmodel_entry.LostFocus, t1000_logam1.LostFocus, t1000_logam2.LostFocus, t500_logam1.LostFocus, t500_logam2.LostFocus, t200_logam1.LostFocus, t200_logam2.LostFocus, t100_logam1.LostFocus, t100_logam2.LostFocus, t50_logam1.LostFocus, t50_logam2.LostFocus, t25_logam1.LostFocus, t25_logam2.LostFocus, t10_logam1.LostFocus, t10_logam2.LostFocus, t5_logam1.LostFocus, t5_logam2.LostFocus, t1_logam1.LostFocus, t1_logam2.LostFocus, t100000_kertas1.LostFocus, t100000_kertas2.LostFocus, t50000_kertas1.LostFocus, t50000_kertas2.LostFocus, t20000_kertas1.LostFocus, t20000_kertas2.LostFocus, t10000_kertas1.LostFocus, t10000_kertas2.LostFocus, t5000_kertas1.LostFocus, t5000_kertas2.LostFocus, t2000_kertas1.LostFocus, t2000_kertas2.LostFocus, t1000_kertas1.LostFocus, t1000_kertas2.LostFocus, t500_kertas1.LostFocus, t500_kertas2.LostFocus, t100_kertas1.LostFocus, t100_kertas2.LostFocus

        sender.BackColor = warna_lostfocus

        If sender.text = t1000_logam2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 1000) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t500_logam2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 500) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t200_logam2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 200) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t100_logam2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 100) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t50_logam2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 50) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t25_logam2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 25) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t10_logam2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 10) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t5_logam2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 5) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t1_logam2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 1) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If

        If sender.text = t100000_kertas2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 100000) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t50000_kertas2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 50000) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t20000_kertas2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 20000) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t10000_kertas2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 10000) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t5000_kertas2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 5000) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t2000_kertas2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 2000) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t1000_kertas2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 1000) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t500_kertas2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 500) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
        If sender.text = t100_kertas2.Text Then
            If (Val(Format(sender.Text, "General Number")) Mod 100) <> 0 Then
                MessageBox.Show("Nominal yang diinputkan salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        End If
    End Sub

    Private Sub cmbjenis_transaksi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbjenis_transaksi.KeyPress, cmbmodel_entry.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbmodel_entry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmodel_entry.SelectedIndexChanged
        If cmbmodel_entry.Text.ToString.Split(" :")(0) = "01" Then
            logam_fisik_on()
            logam_nominal_off()
            kertas_fisik_on()
            kertas_nominal_off()
        Else
            logam_fisik_off()
            logam_nominal_on()
            kertas_fisik_off()
            kertas_nominal_on()
        End If
    End Sub



    Private Sub cmbjenis_transaksi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjenis_transaksi.SelectedIndexChanged

    End Sub

    Private Sub t1000_logam1_TextChanged(sender As Object, e As EventArgs) Handles t1000_logam1.TextChanged, t500_logam1.TextChanged, t200_logam1.TextChanged, t100_logam1.TextChanged, t50_logam1.TextChanged, t25_logam1.TextChanged, t10_logam1.TextChanged, t5_logam1.TextChanged, t1_logam1.TextChanged

        If sender.enabled = True Then
            Try
                sender.text = FormatNumber(sender.Text, 0)
                sender.SelectionStart = Len(sender.Text)
            Catch ex As Exception
                sender.Text = "0"
            End Try
            If sender.text = t1000_logam1.Text Then
                t1000_logam2.Text = FormatNumber(1000 * Format(t1000_logam1.Text, "General Number"), 0)
            End If
            If sender.text = t500_logam1.Text Then
                t500_logam2.Text = FormatNumber(500 * Format(t500_logam1.Text, "General Number"), 0)
            End If
            If sender.text = t200_logam1.Text Then
                t200_logam2.Text = FormatNumber(200 * Format(t200_logam1.Text, "General Number"), 0)
            End If
            If sender.text = t100_logam1.Text Then
                t100_logam2.Text = FormatNumber(100 * Format(t100_logam1.Text, "General Number"), 0)
            End If
            If sender.text = t50_logam1.Text Then
                t50_logam2.Text = FormatNumber(50 * Format(t50_logam1.Text, "General Number"), 0)
            End If
            If sender.text = t25_logam1.Text Then
                t25_logam2.Text = FormatNumber(25 * Format(t25_logam1.Text, "General Number"), 0)
            End If
            If sender.text = t10_logam1.Text Then
                t10_logam2.Text = FormatNumber(10 * Format(t10_logam1.Text, "General Number"), 0)
            End If
            If sender.text = t5_logam1.Text Then
                t5_logam2.Text = FormatNumber(5 * Format(t5_logam1.Text, "General Number"), 0)
            End If
            If sender.text = t1_logam1.Text Then
                t1_logam2.Text = FormatNumber(1 * Format(t1_logam1.Text, "General Number"), 0)
            End If
        End If


    End Sub

    Private Sub t1000_logam2_TextChanged(sender As Object, e As EventArgs) Handles t1000_logam2.TextChanged, t500_logam2.TextChanged, t200_logam2.TextChanged, t100_logam2.TextChanged, t50_logam2.TextChanged, t25_logam2.TextChanged, t10_logam2.TextChanged, t5_logam2.TextChanged, t1_logam2.TextChanged

        If sender.enabled = True Then
            Try
                sender.Text = FormatNumber(sender.Text, 0)
                sender.SelectionStart = Len(sender.Text)
            Catch ex As Exception
                sender.Text = "0"
            End Try
            If sender.text = t1000_logam2.Text Then
                t1000_logam1.Text = FormatNumber(Format(t1000_logam2.Text, "General Number") / 1000, 0)
            End If
            If sender.text = t500_logam2.Text Then
                t500_logam1.Text = FormatNumber(Format(t500_logam2.Text, "General Number") / 500, 0)
            End If
            If sender.text = t200_logam2.Text Then
                t200_logam1.Text = FormatNumber(Format(t200_logam2.Text, "General Number") / 200, 0)
            End If
            If sender.text = t100_logam2.Text Then
                t100_logam1.Text = FormatNumber(Format(t100_logam2.Text, "General Number") / 100, 0)
            End If
            If sender.text = t50_logam2.Text Then
                t50_logam1.Text = FormatNumber(Format(t50_logam2.Text, "General Number") / 50, 0)
            End If
            If sender.text = t25_logam2.Text Then
                t25_logam1.Text = FormatNumber(Format(t25_logam2.Text, "General Number") / 25, 0)
            End If
            If sender.text = t10_logam2.Text Then
                t10_logam1.Text = FormatNumber(Format(t10_logam2.Text, "General Number") / 10, 0)
            End If
            If sender.text = t5_logam2.Text Then
                t5_logam1.Text = FormatNumber(Format(t5_logam2.Text, "General Number") / 5, 0)
            End If
            If sender.text = t1_logam2.Text Then
                t1_logam1.Text = FormatNumber(Format(t1_logam2.Text, "General Number") / 1, 0)
            End If
        End If

        total_uang_logam()
    End Sub

    Private Sub t100000_kertas1_TextChanged(sender As Object, e As EventArgs) Handles t100000_kertas1.TextChanged, t50000_kertas1.TextChanged, t20000_kertas1.TextChanged, t10000_kertas1.TextChanged, t5000_kertas1.TextChanged, t2000_kertas1.TextChanged, t1000_kertas1.TextChanged, t500_kertas1.TextChanged, t100_kertas1.TextChanged

        If sender.enabled = True Then
            Try
                sender.text = FormatNumber(sender.Text, 0)
                sender.SelectionStart = Len(sender.Text)
            Catch ex As Exception
                sender.Text = "0"
            End Try
            If sender.text = t100000_kertas1.Text Then
                t100000_kertas2.Text = FormatNumber(100000 * Format(t100000_kertas1.Text, "General Number"), 0)
            End If
            If sender.text = t50000_kertas1.Text Then
                t50000_kertas2.Text = FormatNumber(50000 * Format(t50000_kertas1.Text, "General Number"), 0)
            End If
            If sender.text = t20000_kertas1.Text Then
                t20000_kertas2.Text = FormatNumber(20000 * Format(t20000_kertas1.Text, "General Number"), 0)
            End If
            If sender.text = t10000_kertas1.Text Then
                t10000_kertas2.Text = FormatNumber(10000 * Format(t10000_kertas1.Text, "General Number"), 0)
            End If
            If sender.text = t5000_kertas1.Text Then
                t5000_kertas2.Text = FormatNumber(5000 * Format(t5000_kertas1.Text, "General Number"), 0)
            End If
            If sender.text = t2000_kertas1.Text Then
                t2000_kertas2.Text = FormatNumber(2000 * Format(t2000_kertas1.Text, "General Number"), 0)
            End If
            If sender.text = t1000_kertas1.Text Then
                t1000_kertas2.Text = FormatNumber(1000 * Format(t1000_kertas1.Text, "General Number"), 0)
            End If
            If sender.text = t500_kertas1.Text Then
                t500_kertas2.Text = FormatNumber(500 * Format(t500_kertas1.Text, "General Number"), 0)
            End If
            If sender.text = t100_kertas1.Text Then
                t100_kertas2.Text = FormatNumber(100 * Format(t100_kertas1.Text, "General Number"), 0)
            End If
        End If

    End Sub

    Private Sub t100000_kertas2_TextChanged(sender As Object, e As EventArgs) Handles t100000_kertas2.TextChanged, t50000_kertas2.TextChanged, t20000_kertas2.TextChanged, t10000_kertas2.TextChanged, t5000_kertas2.TextChanged, t2000_kertas2.TextChanged, t1000_kertas2.TextChanged, t500_kertas2.TextChanged, t100_kertas2.TextChanged

        If sender.enabled = True Then
            Try
                sender.text = FormatNumber(sender.Text, 0)
                sender.SelectionStart = Len(sender.Text)
            Catch ex As Exception
                sender.Text = "0"
            End Try
            If sender.text = t100000_kertas2.Text Then
                t100000_kertas1.Text = FormatNumber(Format(t100000_kertas2.Text, "General Number") / 100000, 0)
            End If
            If sender.text = t50000_kertas2.Text Then
                t50000_kertas1.Text = FormatNumber(Format(t50000_kertas2.Text, "General Number") / 50000, 0)
            End If
            If sender.text = t20000_kertas2.Text Then
                t20000_kertas1.Text = FormatNumber(Format(t20000_kertas2.Text, "General Number") / 20000, 0)
            End If
            If sender.text = t10000_kertas2.Text Then
                t10000_kertas1.Text = FormatNumber(Format(t10000_kertas2.Text, "General Number") / 10000, 0)
            End If
            If sender.text = t5000_kertas2.Text Then
                t5000_kertas1.Text = FormatNumber(Format(t5000_kertas2.Text, "General Number") / 5000, 0)
            End If
            If sender.text = t2000_kertas2.Text Then
                t2000_kertas1.Text = FormatNumber(Format(t2000_kertas2.Text, "General Number") / 2000, 0)
            End If
            If sender.text = t1000_kertas2.Text Then
                t1000_kertas1.Text = FormatNumber(Format(t1000_kertas2.Text, "General Number") / 1000, 0)
            End If
            If sender.text = t500_kertas2.Text Then
                t500_kertas1.Text = FormatNumber(Format(t500_kertas2.Text, "General Number") / 500, 0)
            End If
            If sender.text = t100_kertas2.Text Then
                t100_kertas1.Text = FormatNumber(Format(t100_kertas2.Text, "General Number") / 100, 0)
            End If
        End If

        total_uang_kertas()
    End Sub

    Sub total_uang_logam()
        Dim l1, l2, l3, l4, l5, l6, l7, l8, l9 As String
        l1 = Format(t1000_logam2.Text, "General Number")
        l2 = Format(t500_logam2.Text, "General Number")
        l3 = Format(t200_logam2.Text, "General Number")
        l4 = Format(t100_logam2.Text, "General Number")
        l5 = Format(t50_logam2.Text, "General Number")
        l6 = Format(t25_logam2.Text, "General Number")
        l7 = Format(t10_logam2.Text, "General Number")
        l8 = Format(t5_logam2.Text, "General Number")
        l9 = Format(t1_logam2.Text, "General Number")

        ttotal_uang_logam.Text = FormatNumber(Val(l1) + Val(l2) + Val(l3) + Val(l4) + Val(l5) + Val(l6) + Val(l7) + Val(l8) + Val(l9), 0)
        ttotal_kas_fisik.Text = FormatNumber(Val(Format(ttotal_uang_logam.Text, "General Number")) + Val(Format(ttotal_uang_kertas.Text, "General Number")), 0)
    End Sub

    Sub total_uang_kertas()
        Dim k1, k2, k3, k4, k5, k6, k7, k8, k9 As String

        k1 = Format(t100000_kertas2.Text, "General Number")
        k2 = Format(t50000_kertas2.Text, "General Number")
        k3 = Format(t20000_kertas2.Text, "General Number")
        k4 = Format(t10000_kertas2.Text, "General Number")
        k5 = Format(t5000_kertas2.Text, "General Number")
        k6 = Format(t2000_kertas2.Text, "General Number")
        k7 = Format(t1000_kertas2.Text, "General Number")
        k8 = Format(t500_kertas2.Text, "General Number")
        k9 = Format(t100_kertas2.Text, "General Number")

        ttotal_uang_kertas.Text = FormatNumber(Val(k1) + Val(k2) + Val(k3) + Val(k4) + Val(k5) + Val(k6) + Val(k7) + Val(k8) + Val(k9), 0)
        ttotal_kas_fisik.Text = FormatNumber(Val(Format(ttotal_uang_logam.Text, "General Number")) + Val(Format(ttotal_uang_kertas.Text, "General Number")), 0)
    End Sub

    Sub carimodalawal_dan_saldoakhir()
        Try
            rd.Close()
        Catch ex As Exception

        End Try
        waktu_awal = Format(DateAdd("d", 0 - 1, DateTimePicker1.Value), "yyyy-MM-dd").ToString + " 23:59:59"
        waktu_akhir = Format(DateTimePicker1.Value, "yyyy-MM-dd").ToString + " 23:59:59"

        da = New MySqlDataAdapter("SELECT hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_awal & "') AS modalawal, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_akhir & "') AS saldoakhir, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml FROM kode_perkiraan WHERE perkiraan_kode=(SELECT perk_kode FROM setup_perkiraan WHERE perk_nama='Kas')", koneksi)
        dt = New DataTable
        da.Fill(dt)
        For i As Integer = 0 To dt.Rows.Count - 1

            modal_awal = 0
            saldo_akhir = 0
            modal_awal = Val(modal_awal) + Val(dt.Rows(i)("modalawal"))
            saldo_akhir = Val(saldo_akhir) + Val(dt.Rows(i)("saldoakhir"))

            If dt.Rows(i)("jml") > 0 Then
                da1 = New MySqlDataAdapter("SELECT hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_awal & "') AS modalawal1, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_akhir & "') AS saldoakhir1, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml1 FROM kode_perkiraan WHERE perkiraan_parent='" & dt.Rows(i)("perkiraan_kode") & "'", koneksi)
                dt1 = New DataTable
                da1.Fill(dt1)
                For i1 As Integer = 0 To dt1.Rows.Count - 1
                    modal_awal = Val(modal_awal) + Val(dt1.Rows(i1)("modalawal1"))
                    saldo_akhir = Val(saldo_akhir) + Val(dt1.Rows(i1)("saldoakhir1"))

                    If dt1.Rows(i1)("jml1") > 0 Then
                        da2 = New MySqlDataAdapter("SELECT  hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_awal & "') AS modalawal2, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_akhir & "') AS saldoakhir2,  hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml2 FROM kode_perkiraan WHERE perkiraan_parent='" & dt1.Rows(i1)("perkiraan_kode") & "'", koneksi)
                        dt2 = New DataTable
                        da2.Fill(dt2)
                        For i2 As Integer = 0 To dt2.Rows.Count - 1
                            modal_awal = Val(modal_awal) + Val(dt2.Rows(i2)("modalawal2"))
                            saldo_akhir = Val(saldo_akhir) + Val(dt2.Rows(i2)("saldoakhir2"))

                            If dt2.Rows(i2)("jml2") > 0 Then
                                da3 = New MySqlDataAdapter("SELECT hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_awal & "') AS modalawal3, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_akhir & "') AS saldoakhir3, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml3 FROM kode_perkiraan WHERE perkiraan_parent='" & dt2.Rows(i2)("perkiraan_kode") & "'", koneksi)
                                dt3 = New DataTable
                                da3.Fill(dt3)
                                For i3 As Integer = 0 To dt3.Rows.Count - 1
                                    modal_awal = Val(modal_awal) + dt3.Rows(i3)("modalawal3")
                                    saldo_akhir = Val(saldo_akhir) + dt3.Rows(i3)("saldoakhir3")

                                    If dt3.Rows(i3)("jml3") > 0 Then
                                        da4 = New MySqlDataAdapter("SELECT hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_awal & "') AS modalawal4, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_akhir & "') AS saldoakhir4, hitung_jumlah_perkiraan_anak(perkiraan_kode) AS jml4 FROM kode_perkiraan WHERE perkiraan_parent='" & dt3.Rows(i3)("perkiraan_kode") & "'", koneksi)
                                        dt4 = New DataTable
                                        da4.Fill(dt4)
                                        For i4 As Integer = 0 To dt4.Rows.Count - 1
                                            modal_awal = Val(modal_awal) + dt4.Rows(i4)("modalawal4")
                                            saldo_akhir = Val(saldo_akhir) + dt4.Rows(i4)("saldoakhir4")

                                            If dt4.Rows(i4)("jml4") > 0 Then
                                                da5 = New MySqlDataAdapter("SELECT hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_awal & "') AS modalawal5, hitung_saldo_perkiraan_akhir(perkiraan_kode,'" & waktu_akhir & "') AS saldoakhir5 FROM kode_perkiraan WHERE perkiraan_parent='" & dt4.Rows(i4)("perkiraan_kode") & "'", koneksi)
                                                dt5 = New DataTable
                                                da5.Fill(dt5)
                                                For i5 As Integer = 0 To dt5.Rows.Count - 1
                                                    modal_awal = Val(modal_awal) + dt5.Rows(i5)("modalawal5")
                                                    saldo_akhir = Val(saldo_akhir) + dt5.Rows(i5)("saldoakhir5")
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

            tmodal_awal.Text = FormatNumber(modal_awal, 0)
            tsaldo_akhir.Text = FormatNumber(saldo_akhir, 0)
            ttotal_akhir_di_buku.Text = FormatNumber(saldo_akhir, 0)

        Next
    End Sub

    Sub caripenerimaan_dan_pengeluaran()
        cd = New MySqlCommand("SELECT IFNULL(SUM(masuk) ,0) AS masuk, IFNULL(SUM(keluar), 0) AS keluar FROM v_jurnal_kas WHERE jurnal_tanggal='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Try
            tpenerimaan.Text = FormatNumber(rd.Item("masuk"), 0)
            tpengeluaran.Text = FormatNumber(rd.Item("keluar"), 0)
        Catch ex As Exception
            tpenerimaan.Text = "0"
            tpengeluaran.Text = "0"
        End Try

        rd.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        carimodalawal_dan_saldoakhir()
        caripenerimaan_dan_pengeluaran()
        cek()
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs)
        carimodalawal_dan_saldoakhir()
        caripenerimaan_dan_pengeluaran()
    End Sub


    Sub cek()
        cd = New MySqlCommand("SELECT COUNT(*) AS jumlah FROM verbal_kas WHERE verbal_tanggal='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        Label31.Text = rd.Item("jumlah")
        rd.Close()
        If Label31.Text = 0 Then
            btncetak.Enabled = False
            kosong()
        Else
            btncetak.Enabled = True
            caridata()
        End If

        
    End Sub

    Sub caridata()
        array_pecahan()
        Dim fisik(99), nominal(99) As String
        Dim jenis As String
        For i As Integer = 0 To 17
            If i <= 8 Then
                jenis = "01 : Uang Logam"
            Else
                jenis = "02 : Uang Kertas"
            End If
            cd = New MySqlCommand("SELECT IFNULL(verbal_fisik, 0) AS verbal_fisik, IFNULL(verbal_nominal, 0) AS verbal_nominal FROM verbal_kas WHERE verbal_tanggal='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' AND verbal_pecahan='" & pecahan(i) & "' AND verbal_jenis='" & jenis & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            fisik(i) = rd.Item("verbal_fisik")
            nominal(i) = rd.Item("verbal_nominal")
            rd.Close()
        Next

        If cmbmodel_entry.Text.ToString.Split(" :")(0) = "01" Then
            t1000_logam1.Text = fisik(0)
            t500_logam1.Text = fisik(1)
            t200_logam1.Text = fisik(2)
            t100_logam1.Text = fisik(3)
            t50_logam1.Text = fisik(4)
            t25_logam1.Text = fisik(5)
            t10_logam1.Text = fisik(6)
            t5_logam1.Text = fisik(7)
            t1_logam1.Text = fisik(8)

            t100000_kertas1.Text = fisik(9)
            t50000_kertas1.Text = fisik(10)
            t20000_kertas1.Text = fisik(11)
            t10000_kertas1.Text = fisik(12)
            t5000_kertas1.Text = fisik(13)
            t2000_kertas1.Text = fisik(14)
            t1000_kertas1.Text = fisik(15)
            t500_kertas1.Text = fisik(16)
            t100_kertas1.Text = fisik(17)
        Else
            t1000_logam2.Text = nominal(0)
            t500_logam2.Text = nominal(1)
            t200_logam2.Text = nominal(2)
            t100_logam2.Text = nominal(3)
            t50_logam2.Text = nominal(4)
            t25_logam2.Text = nominal(5)
            t10_logam2.Text = nominal(6)
            t5_logam2.Text = nominal(7)
            t1_logam2.Text = nominal(8)

            t100000_kertas2.Text = nominal(9)
            t50000_kertas2.Text = nominal(10)
            t20000_kertas2.Text = nominal(11)
            t10000_kertas2.Text = nominal(12)
            t5000_kertas2.Text = nominal(13)
            t2000_kertas2.Text = nominal(14)
            t1000_kertas2.Text = nominal(15)
            t500_kertas2.Text = nominal(16)
            t100_kertas2.Text = nominal(17)
        End If
        

        
    End Sub
    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If ttotal_kas_fisik.Text <> ttotal_akhir_di_buku.Text Then
            MessageBox.Show("Total kas fisik tidak sama dengan kas akhir di buku.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        'cek()
        If Label31.Text = 0 Then
            simpan()
        Else
            edit()
        End If



    End Sub

    Sub array_pecahan()
        pecahan(0) = "1000"
        pecahan(1) = "500"
        pecahan(2) = "200"
        pecahan(3) = "100"
        pecahan(4) = "50"
        pecahan(5) = "25"
        pecahan(6) = "10"
        pecahan(7) = "5"
        pecahan(8) = "1"

        pecahan(9) = "100000"
        pecahan(10) = "50000"
        pecahan(11) = "20000"
        pecahan(12) = "10000"
        pecahan(13) = "5000"
        pecahan(14) = "2000"
        pecahan(15) = "1000"
        pecahan(16) = "500"
        pecahan(17) = "100"
    End Sub
    Sub array_fisik()
        fisik(0) = Format(t1000_logam1.Text, "General Number")
        fisik(1) = Format(t500_logam1.Text, "General Number")
        fisik(2) = Format(t200_logam1.Text, "General Number")
        fisik(3) = Format(t100_logam1.Text, "General Number")
        fisik(4) = Format(t50_logam1.Text, "General Number")
        fisik(5) = Format(t25_logam1.Text, "General Number")
        fisik(6) = Format(t10_logam1.Text, "General Number")
        fisik(7) = Format(t5_logam1.Text, "General Number")
        fisik(8) = Format(t1_logam1.Text, "General Number")

        fisik(9) = Format(t100000_kertas1.Text, "General Number")
        fisik(10) = Format(t50000_kertas1.Text, "General Number")
        fisik(11) = Format(t20000_kertas1.Text, "General Number")
        fisik(12) = Format(t10000_kertas1.Text, "General Number")
        fisik(13) = Format(t5000_kertas1.Text, "General Number")
        fisik(14) = Format(t2000_kertas1.Text, "General Number")
        fisik(15) = Format(t1000_kertas1.Text, "General Number")
        fisik(16) = Format(t500_kertas1.Text, "General Number")
        fisik(17) = Format(t100_kertas1.Text, "General Number")

        nominal(0) = Format(t1000_logam2.Text, "General Number")
        nominal(1) = Format(t500_logam2.Text, "General Number")
        nominal(2) = Format(t200_logam2.Text, "General Number")
        nominal(3) = Format(t100_logam2.Text, "General Number")
        nominal(4) = Format(t50_logam2.Text, "General Number")
        nominal(5) = Format(t25_logam2.Text, "General Number")
        nominal(6) = Format(t10_logam2.Text, "General Number")
        nominal(7) = Format(t5_logam2.Text, "General Number")
        nominal(8) = Format(t1_logam2.Text, "General Number")

        nominal(9) = Format(t100000_kertas2.Text, "General Number")
        nominal(10) = Format(t50000_kertas2.Text, "General Number")
        nominal(11) = Format(t20000_kertas2.Text, "General Number")
        nominal(12) = Format(t10000_kertas2.Text, "General Number")
        nominal(13) = Format(t5000_kertas2.Text, "General Number")
        nominal(14) = Format(t2000_kertas2.Text, "General Number")
        nominal(15) = Format(t1000_kertas2.Text, "General Number")
        nominal(16) = Format(t500_kertas2.Text, "General Number")
        nominal(17) = Format(t100_kertas2.Text, "General Number")

    End Sub

    Sub kosong()
        If cmbmodel_entry.Text.ToString.Split(" :")(0) = "01" Then
            t1000_logam1.Clear()
            t500_logam1.Clear()
            t200_logam1.Clear()
            t100_logam1.Clear()
            t50_logam1.Clear()
            t25_logam1.Clear()
            t10_logam1.Clear()
            t5_logam1.Clear()
            t1_logam1.Clear()

            t100000_kertas1.Clear()
            t50000_kertas1.Clear()
            t20000_kertas1.Clear()
            t10000_kertas1.Clear()
            t5000_kertas1.Clear()
            t2000_kertas1.Clear()
            t1000_kertas1.Clear()
            t500_kertas1.Clear()
            t100_kertas1.Clear()
        Else
            t1000_logam2.Clear()
            t500_logam2.Clear()
            t200_logam2.Clear()
            t100_logam2.Clear()
            t50_logam2.Clear()
            t25_logam2.Clear()
            t10_logam2.Clear()
            t5_logam2.Clear()
            t1_logam2.Clear()

            t100000_kertas2.Clear()
            t50000_kertas2.Clear()
            t20000_kertas2.Clear()
            t10000_kertas2.Clear()
            t5000_kertas2.Clear()
            t2000_kertas2.Clear()
            t1000_kertas2.Clear()
            t500_kertas2.Clear()
            t100_kertas2.Clear()
        End If
    End Sub

    Sub simpan()
        array_pecahan()
        array_fisik()
        Dim jenis = ""
        Dim waktu As String = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:dd")
        Dim username = MDIParent1.username.Text
        For n = 0 To 17
            If n <= 8 Then
                jenis = "01 : Uang Logam"
            Else
                jenis = "02 : Uang Kertas"
            End If
            cd = New MySqlCommand("INSERT INTO verbal_kas VALUES ('', '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', '" & jenis & "', '" & pecahan(n) & "', '" & fisik(n) & "', '" & nominal(n) & "', '" & username & "', '" & waktu & "', '" & username & "', '" & waktu & "')", koneksi)
            cd.ExecuteNonQuery()
        Next

        user_pengguna = MDIParent1.username.Text
        uraian = "Melakukan Transaksi Verbal Kas (Tanggal : " + DateTimePicker1.Text + ")"
        insert_log_user()
        btncetak.Enabled = True
        MessageBox.Show("Transaksi Verbal Kas berhasil.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Sub edit()
        array_fisik()
        array_pecahan()
        Dim jenis = ""
        Dim waktu As String = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:dd")
        Dim username = MDIParent1.username.Text
        For n = 0 To 17
            If n <= 8 Then
                jenis = "01 : Uang Logam"
            Else
                jenis = "02 : Uang Kertas"
            End If
            cd = New MySqlCommand("UPDATE verbal_kas SET verbal_fisik = '" & fisik(n) & "', verbal_nominal = '" & nominal(n) & "', verbal_update_username = '" & username & "', verbal_update_waktu = '" & waktu & "' WHERE verbal_tanggal = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' AND verbal_jenis = '" & jenis & "' AND verbal_pecahan = '" & pecahan(n) & "'", koneksi)
            cd.ExecuteNonQuery()
        Next

        user_pengguna = MDIParent1.username.Text
        uraian = "Melakukan Perbaharuan Verbal Kas (Tanggal : " + DateTimePicker1.Text + ")"
        insert_log_user()

        MessageBox.Show("Transaksi pembaharuan Verbal Kas berhasil.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btncetak_Click(sender As Object, e As EventArgs) Handles btncetak.Click
        laporan_verbal_kas.ShowDialog()
    End Sub
End Class