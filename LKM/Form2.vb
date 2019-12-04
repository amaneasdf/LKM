Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Console.Beep()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Start()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Console.Beep()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Dim pool As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim count = 0
        TextBox1.Text = ""
        Dim cc As New Random
        Dim strpos = ""
        While count <= 18
            strpos = cc.Next(0, pool.Length)
            TextBox1.Text = TextBox1.Text & pool(strpos)
            count = count + 1
        End While
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.BackColor = ColorDialog1.Color
            TextBox2.Text = ColorDialog1.Color.Name
        End If
    End Sub
End Class