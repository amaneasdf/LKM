Imports MySql.Data.MySqlClient
Imports System.IO
Public Class backup_restore
    Dim SqlConnection As MySqlConnection
    Dim dtseCt As Integer

    Private Sub backup_restore_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tserver.Focus()
    End Sub

    Private Sub backup_restore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnkeluar.PerformClick()
    End Sub

    Private Sub backup_restore_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub backup_restore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'koneksi_localhost()
        'koneksi.Open()
        'cmbdatabase.Text = database
    End Sub

    Private Sub backup_restore_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbdatabase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbdatabase.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbdatabase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbdatabase.SelectedIndexChanged

    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btnbackup_Click(sender As Object, e As EventArgs) Handles btnbackup.Click
        If cmbdatabase.Text = "" Then
            MessageBox.Show("Database belum dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbdatabase.Focus()
            Exit Sub
        ElseIf MessageBox.Show("Anda yakin akan melakukan backup database?" + Chr(10) + "Server=" + tserver.Text + Chr(10) + "Username=" + tuser_id.Text + Chr(10) + "Password=" + tpassword.Text + Chr(10) + "Database=" + cmbdatabase.Text + "", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            prosesbackup()
        End If
    End Sub

    Sub prosesbackup()
        ' we will backup a mysql database and save it into our local server
        Dim DbFile As String
        Try
            ' create svaFileDialog and OpenFileDialog Component to our project
            SaveFileDialog1.Filter = "SQL Dump File (*.sql)|*.sql|All files (*.*)|*.*"
            SaveFileDialog1.FileName = "Database Backup " + cmbdatabase.Text + " " + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".sql"
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then

                conn()
                DbFile = SaveFileDialog1.FileName
                Dim BackupProccess As New Process
                BackupProccess.StartInfo.FileName = "cmd.exe"
                BackupProccess.StartInfo.UseShellExecute = False
                BackupProccess.StartInfo.WorkingDirectory = "mysql\bin\"
                'BackupProccess.StartInfo.WorkingDirectory = "C:\xampp\mysql\bin\"
                BackupProccess.StartInfo.RedirectStandardInput = True
                BackupProccess.StartInfo.RedirectStandardOutput = True
                BackupProccess.Start()

                Dim BackupStream As StreamWriter = BackupProccess.StandardInput
                Dim myStreamReader As StreamReader = BackupProccess.StandardOutput
               BackupStream.WriteLine("mysqldump --user=" & tuser_id.Text & " --password=" & tpassword.Text & "  " & cmbdatabase.Text & " -E -R > """ + DbFile + """")

                BackupStream.Close()
                BackupProccess.WaitForExit()
                BackupProccess.Close()
                SqlConnection.Close()

                user_pengguna = MDIParent1.username.Text
                uraian = "Melakukan Backup Database (" + cmbdatabase.Text + ") menjadi -> " + DbFile.ToString
                insert_log_user()

                MessageBox.Show("Proses Backup database berhasil.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Proses gagal.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnrestore_Click(sender As Object, e As EventArgs) Handles btnrestore.Click
        If cmbdatabase.Text = "" Then
            MessageBox.Show("Database belum dipilih.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbdatabase.Focus()
            Exit Sub
        End If
        prosesrestore()
    End Sub

    Sub prosesrestore()
        ' now we will create for restore our database, just copy the source for backup our database before
        Dim DbFile As String
        Try
            ' create svaFileDialog and OpenFileDialog Component to our project
            OpenFileDialog1.Filter = "SQL Dump File (*.sql)|*.sql|All files (*.*)|*.*"
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then

                If MessageBox.Show("Anda yakin akan melakukan Restore database?" + Chr(10) + "Server=" + tserver.Text + Chr(10) + "Username=" + tuser_id.Text + Chr(10) + "Password=" + tpassword.Text + Chr(10) + "Database=" + cmbdatabase.Text + "", nama_aplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    conn()
                    DbFile = OpenFileDialog1.FileName
                    Dim BackupProccess As New Process
                    BackupProccess.StartInfo.FileName = "cmd.exe"
                    BackupProccess.StartInfo.UseShellExecute = False
                    BackupProccess.StartInfo.WorkingDirectory = "mysql\bin\"
                    'BackupProccess.StartInfo.WorkingDirectory = "C:\xampp\mysql\bin\"
                    BackupProccess.StartInfo.RedirectStandardInput = True
                    BackupProccess.StartInfo.RedirectStandardOutput = True
                    BackupProccess.Start()

                    Dim BackupStream As StreamWriter = BackupProccess.StandardInput
                    Dim myStreamReader As StreamReader = BackupProccess.StandardOutput
                    BackupStream.WriteLine("mysql --user=" & tuser_id.Text & " --password=" & tpassword.Text & "  " & cmbdatabase.Text & " < """ + DbFile + """")

                    BackupStream.Close()
                    BackupProccess.WaitForExit()
                    BackupProccess.Close()
                    SqlConnection.Close()

                    user_pengguna = MDIParent1.username.Text
                    uraian = "Melakukan Restore Database (" + cmbdatabase.Text + ") dari file " + DbFile.ToString
                    insert_log_user()

                    MessageBox.Show("Proses Restore ke database " + cmbdatabase.Text + " berhasil.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Proses Restore database gagal.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tserver_GotFocus(sender As Object, e As EventArgs) Handles tserver.GotFocus, tuser_id.GotFocus, tpassword.GotFocus, cmbdatabase.GotFocus

        sender.BackColor = warna_gotfocus
    End Sub

    Private Sub tserver_LostFocus(sender As Object, e As EventArgs) Handles tserver.LostFocus, tuser_id.LostFocus, tpassword.LostFocus, cmbdatabase.LostFocus

        sender.BackColor = warna_lostfocus
    End Sub

    Private Sub tserver_TextChanged(sender As Object, e As EventArgs) Handles tserver.TextChanged

    End Sub

    Sub conn()
        SqlConnection = New MySqlConnection("Server=" & tserver.Text & "; uid=" & tuser_id.Text & "; password=" & tpassword.Text & ";")

        If SqlConnection.State = ConnectionState.Closed Then
            SqlConnection.Open()
        End If
    End Sub
    Private Sub btnconnect_Click(sender As Object, e As EventArgs) Handles btnconnect.Click
        cmbdatabase.Items.Clear()
        Try
            conn()

            MessageBox.Show("Koneksi Berhasil.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            da = New MySqlDataAdapter("SELECT DISTINCT TABLE_SCHEMA FROM information_schema.TABLES", SqlConnection)
            dt = New DataTable
            da.Fill(dt)
            dtseCt = 0

            While dtseCt < dt.Rows.Count
                cmbdatabase.Items.Add(dt.Rows(dtseCt)(0).ToString())
                dtseCt = dtseCt + 1
            End While
            cmbdatabase.SelectedIndex = 0

            tserver.Enabled = False
            tuser_id.Enabled = False
            tpassword.Enabled = False
            btnconnect.Enabled = False
            cmbdatabase.Enabled = True
            btnbackup.Enabled = True
            btnrestore.Enabled = True
            SqlConnection.Clone()
            dt.Dispose()
            da.Dispose()

        Catch ex As Exception
            tserver.Enabled = True
            tuser_id.Enabled = True
            tpassword.Enabled = True
            btnconnect.Enabled = True
            cmbdatabase.Enabled = False
            btnbackup.Enabled = False
            btnrestore.Enabled = False
            MessageBox.Show("Koneksi gagal.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class