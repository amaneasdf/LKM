Imports MySql.Data.MySqlClient
Public Class pindah_afiliasi

    Private Sub ComboBox1_GotFocus(sender As Object, e As EventArgs) Handles ComboBox1.GotFocus
        ComboBox1.BackColor = warna_gotfocus
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub ComboBox1_LostFocus(sender As Object, e As EventArgs) Handles ComboBox1.LostFocus
        ComboBox1.BackColor = warna_lostfocus
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub pindah_afiliasi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnkeluar.PerformClick()
    End Sub

    Private Sub pindah_afiliasi_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub pindah_afiliasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = True
        combo()
    End Sub

    Sub combo()
        If Label3.Text = "kolektor" Then
            cd = New MySqlCommand("SELECT CONCAT_WS (' : ', kolektor_kode,upper(kolektor_nama)) AS combo FROM data_kolektor", koneksi)
        ElseIf Label3.Text = "instansi" Then
            cd = New MySqlCommand("SELECT CONCAT_WS (' : ', instansi_kode,upper(instansi_nama)) AS combo FROM data_instansi", koneksi)
        ElseIf Label3.Text = "wilayah" Then
            cd = New MySqlCommand("SELECT CONCAT (wilayah_kode, ' : ', wilayah_nama_desa, ', ', wilayah_nama_kecamatan) AS combo FROM data_wilayah", koneksi)
        ElseIf Label3.Text = "marketing" Then
            cd = New MySqlCommand("SELECT CONCAT_WS (' : ', marketing_kode,upper(marketing_nama)) AS combo FROM data_marketing", koneksi)
        End If

        rd = cd.ExecuteReader
        With ComboBox1.Items
            .Clear()
            While rd.Read()
                .Add(rd.Item("combo"))
            End While
        End With
        rd.Close()
    End Sub

    Private Sub pindah_afiliasi_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btnpindah_Click(sender As Object, e As EventArgs) Handles btnpindah.Click
        If ComboBox1.Text = "" Then
            MessageBox.Show("Data belum dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        Else
            If Label3.Text = "kolektor" Then
                cd = New MySqlCommand("UPDATE data_tabungan_rekening SET rek_tab_kode_kolektor='" & ComboBox1.Text.ToString.Split(" :")(0) & "' WHERE rek_tab_no_rekening='" & tno_rekening.Text & "' ", koneksi)
                cd.ExecuteNonQuery()

                uraian = "Memindahkan data Kolektor (rek_tab_kode_kolektor : " + tno_rekening.Text + ")"

            ElseIf Label3.Text = "marketing" Then
                cd = New MySqlCommand("UPDATE data_tabungan_rekening SET rek_tab_kode_marketing='" & ComboBox1.Text.ToString.Split(" :")(0) & "' WHERE rek_tab_no_rekening='" & tno_rekening.Text & "' ", koneksi)
                cd.ExecuteNonQuery()

                uraian = "Memindahkan data Marketing (rek_tab_kode_marketing : " + tno_rekening.Text + ")"

            ElseIf Label3.Text = "instansi" Then
                cd = New MySqlCommand("UPDATE data_tabungan_rekening SET rek_tab_kode_instansi='" & ComboBox1.Text.ToString.Split(" :")(0) & "' WHERE rek_tab_no_rekening='" & tno_rekening.Text & "' ", koneksi)
                cd.ExecuteNonQuery()

                uraian = "Memindahkan data Instansi (rek_tab_kode_instansi : " + tno_rekening.Text + ")"
            ElseIf Label3.Text = "wilayah" Then
                cd = New MySqlCommand("UPDATE data_tabungan_rekening SET rek_tab_kode_wilayah='" & ComboBox1.Text.ToString.Split(" :")(0) & "' WHERE rek_tab_no_rekening='" & tno_rekening.Text & "' ", koneksi)
                cd.ExecuteNonQuery()

                uraian = "Memindahkan data Wilayah (rek_tab_kode_wilayah : " + tno_rekening.Text + ")"
            End If

            afiliasi.data()
            user_pengguna = MDIParent1.username.Text
            insert_log_user()

            Me.Dispose()
        End If
    End Sub
End Class