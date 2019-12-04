Imports MySql.Data.MySqlClient
Public Class data_pengguna
    Dim data_ke(99), data_edit(99) As String
    Dim gambar As Byte

    Private Sub data_pengguna_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tnama_alias.Focus()
    End Sub

    Private Sub data_pengguna_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub data_pengguna_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub data_pengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = True
        If tnama_alias.Enabled = True Then
            btnlog_user.Enabled = False
        Else
            btnlog_user.Enabled = True
        End If
    End Sub

    Private Sub data_pengguna_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try      
    End Sub

    Sub pass()
        Dim pool As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim count = 1
        Dim cc As New Random
        tpassword.Text = ""

        While count <= 6
            tpassword.Text = tpassword.Text & pool(cc.Next(0, pool.Length))
            count = count + 1
        End While
    End Sub
    Sub combo()
        cd = New MySqlCommand("SELECT CONCAT_WS(' : ', grup_akses_kode, UPPER(grup_akses_nama)) AS jenis FROM data_grup_akses ORDER BY grup_akses_kode", koneksi)
        rd = cd.ExecuteReader
        cmbgrup_akses.Items.Clear()
        While rd.Read()
            cmbgrup_akses.Items.Add(rd.Item("jenis"))
        End While
        rd.Close()
    End Sub
    Sub kosong()
        tnama_alias.Clear()
        tnama_alias.Enabled = True
        tnama_lengkap.Clear()
        cmbgrup_akses.Text = ""
        tpassword.Clear()
        cmbstatus.Text = ""
        cmbstatus.Enabled = False
        PictureBox1.Image = Nothing
        Label7.Text = "0"
        Label8.Text = "0"
    End Sub
    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub cmbstatus_GotFocus(sender As Object, e As EventArgs) Handles cmbstatus.GotFocus, cmbgrup_akses.GotFocus, tnama_lengkap.GotFocus, tnama_alias.GotFocus
        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub cmbstatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbstatus.KeyPress, cmbgrup_akses.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbstatus_LostFocus(sender As Object, e As EventArgs) Handles cmbstatus.LostFocus, cmbgrup_akses.LostFocus, tnama_lengkap.LostFocus, tnama_alias.LostFocus
        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If tnama_alias.Text = "" Then
            MessageBox.Show("Nama Alias Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_alias.Focus()
            Exit Sub
        ElseIf tnama_lengkap.Text = "" Then
            MessageBox.Show("Nama lengkap Harus Diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_lengkap.Focus()
            Exit Sub
        ElseIf cmbgrup_akses.Text = "" Then
            MessageBox.Show("Grup Akses Harus dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbgrup_akses.Focus()
            Exit Sub
        End If
        rd.Close()
        cd = New MySqlCommand("SELECT * FROM data_pengguna WHERE pengguna_username='" & tnama_alias.Text & "'", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows = True And tnama_alias.Enabled = True Then
            rd.Close()
            MessageBox.Show("Data Pengguna sudah Ada", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_alias.Focus()
        Else
            rd.Close()
            If tnama_alias.Enabled = True Then
                simpan()
                tnama_alias.Enabled = False
            Else
                edit()
            End If
        End If
        If tnama_alias.Text = MDIParent1.username.Text Then
            MDIParent1.nama_lengkap.Text = tnama_lengkap.Text
        End If
    End Sub
    Sub ar()
        data_ke(0) = tnama_alias.Text
        data_ke(1) = tkode_teller.Text
        data_ke(2) = tnama_lengkap.Text
        data_ke(3) = computeHash(tpassword.Text)
        data_ke(4) = cmbgrup_akses.Text.ToString.Split(" :")(0)
        data_ke(5) = cmbstatus.Text.ToString.Split(" :")(0)
        data_ke(6) = MDIParent1.username.Text
        data_ke(7) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")
        data_ke(8) = MDIParent1.username.Text
        data_ke(9) = Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss")

        data_edit(0) = "pengguna_username='" + data_ke(0) + "'"
        data_edit(1) = "pengguna_teller='" + data_ke(1) + "'"
        data_edit(2) = "pengguna_nama_lengkap='" + data_ke(2) + "'"
        data_edit(3) = "pengguna_password='" + data_ke(3) + "'"
        data_edit(4) = "pengguna_grup_akses='" + data_ke(4) + "'"
        data_edit(5) = "pengguna_status='" + data_ke(5) + "'"
        data_edit(6) = "pengguna_reg_username='" + data_ke(6) + "'"
        data_edit(7) = "pengguna_reg_waktu='" + data_ke(7) + "'"
        data_edit(8) = "pengguna_update_username='" + data_ke(8) + "'"
        data_edit(9) = "pengguna_update_waktu='" + data_ke(9) + "'"
    End Sub
    Sub simpan()
        noteller()
        ar()
        Dim gabung = ""
        For n = 0 To 9
            If n = 0 Then
                gabung += "'" + data_ke(n) + "'"
            Else
                gabung += ",'" + data_ke(n) + "'"
            End If
        Next
        cd = New MySqlCommand("INSERT INTO data_pengguna VALUES (" & gabung & ")", koneksi)
        cd.ExecuteNonQuery()
        simpan_gambar()

        user_pengguna = MDIParent1.username.Text
        uraian = "Menambah Data Pengguna (pengguna_username : " + data_ke(0) + ")"
        insert_log_user()

        master_pengguna.data()
        MessageBox.Show("Data Pengguna berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Sub edit()
        ar()
        Dim gabung = ""
        For n = 1 To 9
            If n = 1 Then
                gabung += data_edit(n)
            ElseIf n = 3 Or n = 6 Or n = 7 Then

            Else
                gabung += " ," + data_edit(n)
            End If
        Next
        cd = New MySqlCommand("UPDATE data_pengguna SET " & gabung & " WHERE " & data_edit(0) & "", koneksi)
        cd.ExecuteNonQuery()
        simpan_gambar()

        user_pengguna = MDIParent1.username.Text
        uraian = "Merubah Data Pengguna (pengguna_username : " + data_ke(0) + ")"
        insert_log_user()

        master_pengguna.data()
        MessageBox.Show("Data Pengguna berhasil diperbaharui.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Sub simpan_gambar()
        Dim fileName As String = OpenFileDialog1.FileName
        If Label8.Text = "1" Then
            If Label7.Text = "0" Then
                cd = New MySqlCommand("INSERT INTO data_pengguna_gambar VALUES ('" & tnama_alias.Text & "', @gambar)", koneksi)
            ElseIf Label7.Text = "1" Then
                cd = New MySqlCommand("UPDATE data_pengguna_gambar SET gambar_file=@gambar WHERE gambar_pengguna_username='" & tnama_alias.Text & "'", koneksi)
            End If
            With cd
                .Parameters.Clear()
                .Parameters.AddWithValue("@gambar", IO.File.ReadAllBytes(fileName)) ' foto
                .ExecuteNonQuery()
            End With
        End If
        If Label7.Text = "1" And Label8.Text = "0" Then
            'hapus
            cd = New MySqlCommand("DELETE FROM data_pengguna_gambar WHERE gambar_pengguna_username='" & tnama_alias.Text & "'", koneksi)
            cd.ExecuteNonQuery()
        End If
    End Sub
    Private Sub btnambil_foto_Click(sender As Object, e As EventArgs) Handles btnambil_foto.Click
        ambil_foto.ShowDialog()
    End Sub

    Private Sub btnbuka_folder_Click(sender As Object, e As EventArgs) Handles btnbuka_folder.Click
        Me.OpenFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files(*.png)|*.png"
        MessageBox.Show("File foto harus JPG/JPEG/PNG", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.PictureBox1.ImageLocation = OpenFileDialog1.FileName
            Label8.Text = "1"
        End If
    End Sub

    Private Sub btnhapus_foto_Click(sender As Object, e As EventArgs) Handles btnhapus_foto.Click
        Me.PictureBox1.Image = Nothing
        Label8.Text = "0"
    End Sub

    Private Sub cmbgrup_akses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbgrup_akses.SelectedIndexChanged

    End Sub

    Private Sub btnlog_user_Click(sender As Object, e As EventArgs) Handles btnlog_user.Click
        rd.Close()
        With log_user
            .Label3.Text = tnama_alias.Text
            .ShowDialog()
        End With
    End Sub

    Sub noteller()
        cd = New MySqlCommand("SELECT IFNULL(MAX(RIGHT(pengguna_teller,3)), '0') AS no_teller FROM data_pengguna", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        tkode_teller.Text = Microsoft.VisualBasic.Right("000" & Microsoft.VisualBasic.Right(rd.Item("no_teller"), 3) + 1, 3)
        rd.Close()
    End Sub
End Class