Imports MySql.Data.MySqlClient
Public Class data_perkiraan
    Dim data_ke(99), data_edit(99) As String

    Private Sub data_perkiraan_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tkode.Focus()
    End Sub

    Private Sub data_perkiraan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub data_perkiraan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = True
    End Sub

    Private Sub data_perkiraan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub tnama_GotFocus(sender As Object, e As EventArgs) Handles tnama.GotFocus, tkode.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tkode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tkode.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[.0-9]" _
            OrElse KeyAscii = Keys.Back _
             OrElse KeyAscii = Keys.Space _
            OrElse KeyAscii = Keys.Return _
            OrElse KeyAscii = Keys.Delete) Then
            KeyAscii = 0
        End If
        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub tnama_LostFocus(sender As Object, e As EventArgs) Handles tnama.LostFocus, tkode.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tkode.Text = "" Then
            MessageBox.Show("Kode Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode.Focus()
            Exit Sub
        ElseIf tparent.Text = "" Then
            MessageBox.Show("Kode Parent Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tparent.Focus()
            Exit Sub
        ElseIf tnama.Text = "" Then
            MessageBox.Show("Nama Perkiraan Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama.Focus()
            Exit Sub
        End If
        cd = New MySqlCommand("SELECT * FROM kode_perkiraan WHERE perkiraan_kode='" & tkode.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True And tkode.Enabled = True Then
            rd.Close()
            MessageBox.Show("Kode Perkiraan sudah Ada", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tkode.Focus()
        Else
            rd.Close()
            If tkode.Enabled = True Then
                simpan()
            Else
                edit()
            End If
        End If
    End Sub
    Sub ar()
        data_ke(0) = tkode.Text

        data_ke(2) = tnama.Text

        data_ke(4) = tparent.Text
        data_ke(8) = "0"
        data_ke(9) = "1"
        data_ke(10) = "1"

        Try
            cd = New MySqlCommand("SELECT * FROM kode_perkiraan WHERE perkiraan_kode='" & TextBox1.Text & "'", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            data_ke(1) = rd.Item("perkiraan_umum")
            data_ke(3) = rd.Item("perkiraan_type")
            data_ke(5) = rd.Item("perkiraan_d_or_k")
            data_ke(6) = rd.Item("perkiraan_l_or_r")
            data_ke(7) = rd.Item("perkiraan_minus")
            rd.Close()
        Catch ex As Exception

        End Try
        

        data_edit(0) = "perkiraan_kode='" + data_ke(0) + "'"
        'data_edit(1) = "perkiraan_umum='" + data_ke(1) + "'"
        data_edit(2) = "perkiraan_nama='" + data_ke(2) + "'"
        'data_edit(3) = "perkiraan_koreksi='" + data_ke(3) + "'"
        'data_edit(4) = "perkiraan_status='" + data_ke(4) + "'"
        rd.Close()
       


    End Sub
    Sub simpan()
        ar()
        Dim gabung = ""
        For n = 0 To 10
            If n = 0 Then
                gabung += "'" + data_ke(n) + "'"
            Else
                gabung += ",'" + data_ke(n) + "'"
            End If
        Next
        'MsgBox(gabung)
        cd = New MySqlCommand("INSERT INTO kode_perkiraan VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Kode Perkiraan (perkiraan_kode : " + data_ke(0) + ")"
        insert_log_user()

        MessageBox.Show("Kode Perkiraan berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        master_perkiraan.data()
        Me.Dispose()
    End Sub

    Sub edit()
        ar()
        'Dim gabung = ""
        'For n = 1 To 4
        'If n = 1 Then
        'gabung += data_edit(n)
        'Else
        'gabung += "," + data_edit(n)
        'End If
        'Next
        cd = New MySqlCommand("UPDATE kode_perkiraan SET " & data_edit(2) & " WHERE " & data_edit(0) & "", koneksi)
        cd.ExecuteNonQuery()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Kode Perkiraan (perkiraan_kode : " + data_ke(0) + ")"
        insert_log_user()

        MessageBox.Show("Kode Perkiraan berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        master_perkiraan.data()
        Me.Dispose()
    End Sub

    Sub caridataperkiraan()
        
    End Sub
End Class