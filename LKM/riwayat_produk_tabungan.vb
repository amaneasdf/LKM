Imports MySql.Data.MySqlClient
Public Class riwayat_produk_tabungan

    Private Sub riwayat_produk_tabungan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnkeluar.PerformClick()
    End Sub

    Private Sub riwayat_produk_tabungan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub riwayat_produk_tabungan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ResizeRedraw = True
        ukuran()
        data()
    End Sub

    Sub ukuran()
        With ListView1.Columns
            .Clear()
            .Add("Waktu", 100, HorizontalAlignment.Left)
            .Add("Saldo Pembukaan", 100, HorizontalAlignment.Right)
            .Add("Setoran Minimal", 100, HorizontalAlignment.Right)
            .Add("Saldo Mengendap", 100, HorizontalAlignment.Right)
            .Add("SB %", 100, HorizontalAlignment.Right)
            .Add("Min Saldo Bunga", 100, HorizontalAlignment.Right)
            .Add("Metode Hitung Bunga", 100, HorizontalAlignment.Left)
            .Add("Adm Bulanan", 100, HorizontalAlignment.Right)
            .Add("Adm Tab Pasif", 100, HorizontalAlignment.Right)
            .Add("Adm Penutupan", 100, HorizontalAlignment.Right)
        End With
    End Sub
    Sub data()
        da = New MySqlDataAdapter("SELECT *, (SELECT text FROM v_combo_komponen WHERE combo_komponen='19' AND combo_kode=riwayat_metode_hitung_bunga) AS text FROM data_tabungan_produk_riwayat WHERE riwayat_kode='" & tkode_produk.Text & "' ORDER BY riwayat_update_waktu ASC", koneksi)
        dt = New DataTable
        da.Fill(dt)
        With ListView1
            .Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                .Items.Add(Format(dt.Rows(i)("riwayat_update_waktu"), "dd-MM-yyyy"))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("riwayat_saldo_pembukaan"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("riwayat_setoran_minimal"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("riwayat_saldo_mengendap"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("riwayat_suku_bunga"), 3).ToString + " %")
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("riwayat_saldo_minimal_dapat_bunga"), 0))
                .Items(.Items.Count - 1).SubItems().Add(dt.Rows(i)("text"))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("riwayat_adm_rekening"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("riwayat_adm_tabungan_pasif"), 0))
                .Items(.Items.Count - 1).SubItems().Add(FormatNumber(dt.Rows(i)("riwayat_adm_penutupan"), 0))
            Next
        End With
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub riwayat_produk_tabungan_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub
End Class