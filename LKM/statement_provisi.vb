Public Class statement_provisi

    Private Sub statement_provisi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = True
    End Sub

    Private Sub statement_provisi_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, Color.PaleTurquoise, Color.DodgerBlue, Drawing2D.LinearGradientMode.Vertical)

        e.Graphics.FillRectangle(d, Me.ClientRectangle)
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub
End Class