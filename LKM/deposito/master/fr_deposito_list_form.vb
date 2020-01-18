Public Class fr_deposito_list_form

    Private Sub fr_deposito_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = True
        Dim x As New fr_deposito_list With {.Dock = DockStyle.Fill}
        x.LoadControl(pnl_content, "deposito", "Master Produk Simpanan Berjangka")
    End Sub

    Private Sub form_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception
            LogError(ex)
            MessageBox.Show("Terjadi kesalahan saat menampilkan jendela " & Me.Text & "." & Environment.NewLine & ex.Message,
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub master_rekening_tabungan_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = MDIParent1.Width - 21
        Me.Height = MDIParent1.Height - 180
    End Sub

End Class