Public Class Form1
    Inherits Windows.Forms.Form

    Dim WithEvents vList1, vList2 As New ListBox
    Dim WithEvents vNUDBelah, vNUDRotasi As New NumericUpDown
    Dim WithEvents tombol As New Button

    Dim vArrayList() As ListBox = {vList1, vList2}
    Dim vArrayControl() As Control = {vList1, vList2, vNUDBelah, vNUDRotasi}
    Dim vArrayButton() As Button = {tombol}
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Controls.AddRange(Me.vArrayControl)
        Me.Controls.AddRange(Me.vArrayButton)

        Me.vList1.Location = New Point(10, 10)
        Me.vList2.Location = New Point(Me.vList1.Right + 10, 10)

        Me.vNUDBelah.Location = New Point(10, Me.vList1.Bottom + 10)
        Me.vNUDRotasi.Location = New Point(Me.vNUDBelah.Right + 10, Me.vNUDBelah.Top)

        For a As Integer = 1 To [Enum].GetValues(GetType(Drawing.KnownColor)).Length
            For b As Integer = 0 To Me.vArrayList.Length - 1
                Dim Warna As KnownColor = a
                Me.vArrayList(b).Items.Add(Warna.ToString)
            Next
        Next

        Me.vList1.SelectedIndex = 0
        Me.vList2.SelectedIndex = 0

        Me.vNUDRotasi.Maximum = 360
        Me.tombol.Location = New Point(200, 200)
        Me.tombol.Text = "lallalaa"
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Using Warna As New Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, Color.FromKnownColor(Me.vList1.SelectedIndex + 1), Color.FromKnownColor(Me.vList2.SelectedIndex + 1), Me.vNUDRotasi.Value, True)
            Warna.SetSigmaBellShape(Me.vNUDBelah.Value / 100)
            e.Graphics.FillRectangle(Warna, Me.ClientRectangle)
        End Using
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize, vList1.SelectedIndexChanged, vList2.SelectedIndexChanged, vNUDBelah.ValueChanged, vNUDRotasi.ValueChanged
        Me.Refresh()
    End Sub
End Class