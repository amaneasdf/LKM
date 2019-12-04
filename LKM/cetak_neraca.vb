Public Class cetak_neraca

    Private Sub cetak_neraca_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnbatal.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cetak_neraca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        Me.ResizeRedraw = True
        combo()
        DateTimePicker2.MinDate = DateTimePicker1.Value
    End Sub

    Sub combo()
        With cmbjenis_laporan.Items
            .Clear()
            .Add("1 : NERACA SALDO")
            .Add("2 : LABA / RUGI")
            .Add("3 : REKENING ADMINISTRATIF")
        End With

        With cmbbentuk_laporan.Items
            .Clear()
            '.Add("01 : LAPORAN MUTASI (AKRUAL BASIS)")
            .Add("02 : LAPORAN MUTASI")
            '.Add("03 : LAPORAN MUTASI (LABUL)")
            .Add("05 : LAPORAN HARIAN")
            '.Add("06 : LAPORAN HARIAN (LABUL)")
            .Add("08 : LAPORAN SKONTRO")
            '.Add("09 : LAPORAN SKONTRO (LABUL)")
            .Add("11 : LAPORAN DERET HARIAN")
            '.Add("12 : LAPORAN DERET HARIAN (LABUL)")
            .Add("14 : LAPORAN DERET SKONTRO")
            '.Add("15 : LAPORAN DERET SKONTRO (LABUL)")
            '.Add("16 : LAPORAN PENCAPAIAN (CASH BASIS)")
            '.Add("17 : LAPORAN PENCAPAIAN (LABUL)")
        End With
    End Sub

    Private Sub cetak_neraca_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        Me.Dispose()
    End Sub

    Private Sub cmbbentuk_laporan_GotFocus(sender As Object, e As EventArgs) Handles cmbbentuk_laporan.GotFocus, cmbjenis_laporan.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbjenis_laporan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbjenis_laporan.KeyPress, cmbbentuk_laporan.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbjenis_laporan_LostFocus(sender As Object, e As EventArgs) Handles cmbjenis_laporan.LostFocus, cmbbentuk_laporan.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub cmbjenis_laporan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjenis_laporan.SelectedIndexChanged
        With cmbbentuk_laporan
            If cmbjenis_laporan.Text.ToString.Split(" :")(0) = "3" Then
                .Enabled = False
                .Text = ""
            Else
                .Enabled = True
            End If
        End With

        cek()
    End Sub
    Sub cek()

        CheckBox1.Checked = False
        CheckBox2.Checked = False

        Dim bntk As String = cmbbentuk_laporan.Text.ToString.Split(" :")(0)
        If bntk = "02" Then
            CheckBox1.Enabled = True
            CheckBox2.Enabled = True
        ElseIf bntk = "05" Or bntk = "11" Or bntk = "17" Then
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
        ElseIf bntk = "08" Or bntk = "14" Then
            CheckBox1.Enabled = True
            CheckBox2.Enabled = False
        Else
            CheckBox1.Enabled = False
            CheckBox1.Checked = False
            CheckBox2.Enabled = False
            CheckBox2.Checked = False
        End If

    End Sub
    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        If cmbjenis_laporan.Text = "" Then
            MessageBox.Show("Jenis Laporan harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbjenis_laporan.Focus()
            Exit Sub
        ElseIf cmbbentuk_laporan.Text = "" And cmbjenis_laporan.Text.ToString.Split(" :")(0) <> "3" Then
            MessageBox.Show("Bentuk Laporan harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbbentuk_laporan.Focus()
            Exit Sub
        ElseIf cmbbentuk_laporan.Enabled = True And cmbbentuk_laporan.Text.ToString.Split(" :")(0) <> "02" Then
            If Format(DateTimePicker1.Value, "dd mm yyyy") <> Format(DateTimePicker2.Value, "dd mm yyyy") Then
                MessageBox.Show("Tanggal buku harus sama.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
                DateTimePicker1.Focus()
                Exit Sub
            End If
        ElseIf DateTimePicker1.Value > DateTimePicker2.Value Or DateTimePicker2.Value < DateTimePicker1.Value Then
            MessageBox.Show("Format tanggal salah.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
            Exit Sub
        End If
        pilih()

    End Sub

    Sub pilih()
        Dim c1, c2 As String
        If CheckBox1.Checked = True Then
            c1 = "1"
        Else
            c1 = "0"
        End If

        If CheckBox2.Checked = True Then
            c2 = "1"
        Else
            c2 = "0"
        End If

        If cmbjenis_laporan.Text.ToString.Split(" :")(0) = "1" Then
            Select Case cmbbentuk_laporan.Text.ToString.Split(" :")(0)
                Case "02"
                    If c2 = "1" Then
                        With laporan_rekonsiliasi_mutasi
                            .DateTimePicker1.Value = DateTimePicker1.Value
                            .DateTimePicker2.Value = DateTimePicker2.Value
                            .TextBox1.Text = "MUTASI NERACA HARIAN"
                            .TextBox2.Text = "neraca saldo"
                            .TextBox3.Text = c1
                            .ShowDialog()
                        End With
                    ElseIf c2 = "0" Then
                        With laporan_mutasi
                            .DateTimePicker1.Value = DateTimePicker1.Value
                            .DateTimePicker2.Value = DateTimePicker2.Value
                            .TextBox1.Text = "MUTASI NERACA HARIAN"
                            .TextBox2.Text = "neraca saldo"
                            .TextBox3.Text = c1
                            .ShowDialog()
                        End With
                    End If

                Case "05"
                    With laporan_harian
                        .DateTimePicker1.Value = DateTimePicker1.Value
                        .DateTimePicker2.Value = DateTimePicker2.Value
                        .TextBox1.Text = "LAPORAN NERACA"
                        .TextBox2.Text = "neraca saldo"
                        .ShowDialog()
                    End With
                Case "08"
                    With laporan_skontro
                        .DateTimePicker1.Value = DateTimePicker1.Value
                        .DateTimePicker2.Value = DateTimePicker2.Value
                        .TextBox1.Text = "LAPORAN NERACA"
                        .TextBox2.Text = "neraca saldo"
                        .TextBox3.Text = c1
                        .ShowDialog()
                    End With
                Case "11"
                    With laporan_deret_neraca
                        .DateTimePicker1.Value = DateTimePicker1.Value
                        .DateTimePicker2.Value = DateTimePicker2.Value
                        .TextBox1.Text = "LAPORAN NERACA DERET"
                        .TextBox2.Text = "neraca saldo"
                        .TextBox3.Text = "harian"
                        .ShowDialog()
                    End With
                Case "14"
                    With laporan_deret_neraca
                        .DateTimePicker1.Value = DateTimePicker1.Value
                        .DateTimePicker2.Value = DateTimePicker2.Value
                        .TextBox1.Text = "LAPORAN NERACA DERET"
                        .TextBox2.Text = "neraca saldo"
                        .TextBox3.Text = "skontro"
                        .TextBox4.Text = c1
                        .ShowDialog()
                    End With
            End Select
        ElseIf cmbjenis_laporan.Text.ToString.Split(" :")(0) = "2" Then
            Select Case cmbbentuk_laporan.Text.ToString.Split(" :")(0)
                Case "02"
                    If c2 = "1" Then
                        With laporan_rekonsiliasi_mutasi
                            .DateTimePicker1.Value = DateTimePicker1.Value
                            .DateTimePicker2.Value = DateTimePicker2.Value
                            .TextBox1.Text = "MUTASI LABA/RUGI HARIAN"
                            .TextBox2.Text = "labarugi"
                            .TextBox3.Text = c1
                            .ShowDialog()
                        End With
                    ElseIf c2 = "0" Then
                        With laporan_mutasi
                            .DateTimePicker1.Value = DateTimePicker1.Value
                            .DateTimePicker2.Value = DateTimePicker2.Value
                            .TextBox1.Text = "MUTASI LABA/RUGI HARIAN"
                            .TextBox2.Text = "labarugi"
                            .TextBox3.Text = c1
                            .ShowDialog()
                        End With
                    End If

                Case "05"
                    With laporan_harian
                        .DateTimePicker1.Value = DateTimePicker1.Value
                        .DateTimePicker2.Value = DateTimePicker2.Value
                        .TextBox1.Text = "LAPORAN LABA/RUGI"
                        .TextBox2.Text = "labarugi"
                        .ShowDialog()
                    End With
                Case "08"
                    With laporan_skontro
                        .DateTimePicker1.Value = DateTimePicker1.Value
                        .DateTimePicker2.Value = DateTimePicker2.Value
                        .TextBox1.Text = "LAPORAN LABA/RUGI"
                        .TextBox2.Text = "labarugi"
                        .TextBox3.Text = c1
                        .ShowDialog()
                    End With
                Case "11"
                    With laporan_deret_labarugi
                        .DateTimePicker1.Value = DateTimePicker1.Value
                        .DateTimePicker2.Value = DateTimePicker2.Value
                        .TextBox1.Text = "LAPORAN LABA/RUGI DERET"
                        .TextBox2.Text = "labarugi"
                        .TextBox3.Text = "harian"
                        .ShowDialog()
                    End With
                Case "14"
                    With laporan_deret_labarugi
                        .DateTimePicker1.Value = DateTimePicker1.Value
                        .DateTimePicker2.Value = DateTimePicker2.Value
                        .TextBox1.Text = "LAPORAN LABA/RUGI DERET"
                        .TextBox2.Text = "labarugi"
                        .TextBox3.Text = "skontro"
                        .TextBox4.Text = c1
                        .ShowDialog()
                    End With
            End Select

        ElseIf cmbjenis_laporan.Text.ToString.Split(" :")(0) = "3" Then
            With laporan_rekening_administrasi
                .DateTimePicker1.Value = DateTimePicker1.Value
                .DateTimePicker2.Value = DateTimePicker2.Value
                .TextBox1.Text = "LAPORAN REKENING ADMINISTRATIF"
                .ShowDialog()
            End With
        End If

    End Sub

    Private Sub cmbbentuk_laporan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbentuk_laporan.SelectedIndexChanged
        cek()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker2.MinDate = DateTimePicker1.Value
    End Sub
End Class