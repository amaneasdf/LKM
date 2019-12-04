Imports MySql.Data.MySqlClient
Public Class log_user

    Private Sub log_user_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnkeluar.PerformClick()
    End Sub

    Private Sub log_user_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub log_user_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combo()
        Me.ResizeRedraw = True
        ukuran()
        data()
    End Sub

    Sub combo()
        With ComboBox1.Items
            .Clear()
            .Add("ASC")
            .Add("DESC")
        End With
        ComboBox1.SelectedIndex = 0
    End Sub

    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Waktu", 150, HorizontalAlignment.Left)
            .Add("Keterangan", 350, HorizontalAlignment.Left)
        End With
    End Sub
    Sub data()

        da = New MySqlDataAdapter("SELECT * FROM log_user WHERE log_username='" & Label3.Text & "' AND (log_waktu BETWEEN '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & " 00:00:00' AND '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & " 23:59:59') ORDER BY log_waktu " & ComboBox1.Text & "", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(Format(dt.Rows(i)("log_waktu"), "dd-MM-yyyy HH:mm:ss"))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("log_keterangan"))
            Next
        End With
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub log_user_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        data()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        data()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        data()
    End Sub
End Class