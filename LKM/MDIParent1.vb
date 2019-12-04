Imports System.Windows.Forms
Imports System.Net
Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Printing

Public Class MDIParent1
    Dim MainMenu As New MenuStrip
    Dim ParentMenu, ChildMenu, ChildMenu2, MenuLogout, SetupMenu As ToolStripMenuItem
    Dim MenuKode, MenuLabel, MenuText As String

    Public Sub LoadMainControl()
        LoadMainMenu()
    End Sub


    Sub close_menu_child()
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
    End Sub
    Private Sub MenuItemClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        close_menu_child()
        Dim mnName As String = DirectCast(sender, ToolStripItem).Name
        Select Case mnName
            'Case "mn0101"
            '   With login
            '      .ShowDialog()
            '     .Focus()
            'End With
            Case "Setup Menu"
                Dim x As New fr_deposito_form With {.StartPosition = FormStartPosition.Manual,
                                                    .MdiParent = Me}
                x.Show()
                'With setup_menu
                '    .ShowDialog()
                '    .Focus()
                'End With

            Case "mn0101"
                With data_kantor_pusat
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn0102"
                With setup_pegawai
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn0103"
                With petugas_pelaporan
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn0104"
                With master_pengguna
                    .StartPosition = FormStartPosition.Manual
                    .MdiParent = Me
                    .Show()
                    .Focus()
                End With
            Case "mn0105"
                With ganti_password
                    .tnama_alias.Text = username.Text

                    cd = New MySqlCommand("SELECT concat_ws (' : ', grup_akses_kode,grup_akses_nama) AS grupakses FROM data_grup_akses WHERE grup_akses_kode='" & Label1.Text & "'", koneksi)
                    rd = cd.ExecuteReader
                    rd.Read()
                    .cmbgrup_akses.Text = rd.Item("grupakses")
                    rd.Close()

                    .ShowDialog()
                    .Focus()
                End With
            Case "mn0106"
                With master_grup_akses
                    .StartPosition = FormStartPosition.Manual
                    .MdiParent = Me
                    .Show()
                    .Focus()
                End With
            Case "mn0107"
                With setup_kolektor
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn0108"
                With setup_marketing
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn0109"
                With setup_wilayah
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn0110"
                With setup_instansi
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn0111"
                With master_produk_tabungan
                    .StartPosition = FormStartPosition.Manual
                    .MdiParent = Me
                    .Show()
                    .Focus()
                End With
            Case "mn0112"
                With master_produk_kredit
                    .StartPosition = FormStartPosition.Manual
                    .MdiParent = Me
                    .Show()
                    .Focus()
                End With
            Case "mn0113"
                With master_perkiraan
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn0114"
                With pengaturan_perkiraan
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn0115"
                With setup_cetakan
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn0116"
                With backup_restore
                    .ShowDialog()
                    .Focus()
                End With

            Case "mn020101"
                With master_nasabah_perorangan
                    .StartPosition = FormStartPosition.Manual
                    .MdiParent = Me
                    .Show()
                    .Focus()
                End With
            Case "mn020102"
                With daftar_nasabah
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn020201"
                With master_rekening_tabungan
                    .StartPosition = FormStartPosition.Manual
                    .MdiParent = Me
                    .Show()
                    .Focus()
                End With
            Case "mn020301"
                With master_rekening_kredit
                    .StartPosition = FormStartPosition.Manual
                    .MdiParent = Me
                    .Show()
                    .Focus()
                End With
            Case "mn020302"
                With simulasi_kredit
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn030101"
                With transaksi__tabungan
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn030102"
                With browse_transaksi
                    .Label5.Text = "transaksi tabungan"
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn030103"
                With cetak_rekening_koran
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn030201"
                With transaksi_pencairan
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn030202"
                With browse_transaksi
                    .Label5.Text = "transaksi pencairan"
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn030301"
                With transaksi_angsuran_kredit
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn030302"
                With browse_transaksi
                    .Label5.Text = "transaksi angsuran kredit"
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn030401"
                With transaksi_jurnal_kas
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn030402"
                With browse_transaksi
                    .Label5.Text = "transaksi jurnal kas"
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn030501"
                With transaksi_jurnal_non_kas
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn030502"
                With browse_transaksi
                    .Label5.Text = "transaksi jurnal non kas"
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn030601"
                With proses_bunga_tabungan
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn040101"
                With cetak_laporan_transaksi_teller
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn040102"
                With transaksi_verbal_kas
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn040201"
                With cetak_nominatif_tabungan
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn040202"
                With cetak_rincian_transaksi_tabungan
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn040203"
                With cetak_nominatif_bunga_tabungan
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn040301"
                With cetak_nominatif_kredit
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn040302"
                With cetak_rincian_transaksi_kredit
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn040401"
                With browse_transaksi
                    .Label1.Text = "Laporan Buku Besar"
                    .Label5.Text = "laporan buku besar"
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn040402"
                With cetak_neraca
                    .ShowDialog()
                    .Focus()
                End With
            Case "mn040403"
                With cetak_rincian_mutasi_saldo
                    .ShowDialog()
                    .Focus()
                End With

            Case "Logout"
                'login.Close()
                user_pengguna = Me.username.Text
                uraian = "Logout berhasil"
                insert_log_user()

                Me.Hide()
                With login
                    .Label4.Text = "0"
                    .tusername.Clear()
                    .tpassword.Clear()
                    .tusername.Focus()
                    .Show()
                    .Focus()
                End With


        End Select
    End Sub

    Private Sub LoadMainMenu()
        ' MsgBox(Label1.Text)

        If username.Text = "admin" Then
            Dim SetupMn As New ToolStripMenuItem("Setup Menu")
            SetupMenu = SetupMn
            SetupMenu.Name = "Setup Menu"
            'ChildMenu.DropDownItems.Add(SetupMenu)
            MainMenu.Items.Add(SetupMenu)
            AddHandler SetupMenu.Click, AddressOf MenuItemClicked
        End If

        cd = New MySqlCommand("SELECT * FROM kode_menu WHERE menu_group = '" & Label1.Text & "' ORDER BY menu_kode ASC ", koneksi)
        rd = cd.ExecuteReader
        Do While rd.Read
            MenuKode = rd.Item("menu_kode")
            MenuLabel = rd.Item("menu_label").ToString
            MenuText = Mid(MenuKode, 3, 20) & ". " & MenuLabel
            If Len(MenuKode) = 4 Then
                Dim MenuItem As New ToolStripMenuItem(MenuLabel)
                ParentMenu = MenuItem
            End If
            If Len(MenuKode) = 6 Then
                If MenuLabel <> "-" Then
                    Dim MenuItem As New ToolStripMenuItem(MenuText)
                    ChildMenu = MenuItem
                    ChildMenu.Name = MenuKode
                    ParentMenu.DropDownItems.Add(ChildMenu)

                    ' Enable Tombol
                    For Each tsb As ToolStripButton In ToolStrip1.Items
                        If Mid(tsb.Name, 4, 15) = MenuKode Then
                            tsb.Visible = True
                        End If
                    Next
                Else
                    ParentMenu.DropDownItems.Add(New ToolStripSeparator)
                End If
                AddHandler ChildMenu.Click, AddressOf MenuItemClicked
            End If
            If Len(MenuKode) = 8 Then
                If MenuLabel <> "-" Then
                    Dim MenuItem As New ToolStripMenuItem(MenuText)
                    ChildMenu2 = MenuItem
                    ChildMenu2.Name = MenuKode
                    ChildMenu.DropDownItems.Add(ChildMenu2)

                    'Enable Tombol
                    For Each tsb As ToolStripButton In ToolStrip1.Items
                        If Mid(tsb.Name, 4, 15) = MenuKode Then
                            tsb.Visible = True
                        End If
                    Next
                Else
                    ChildMenu.DropDownItems.Add(New ToolStripSeparator)
                End If
                AddHandler ChildMenu2.Click, AddressOf MenuItemClicked
            End If
            MainMenu.Items.Add(ParentMenu)
        Loop
        rd.Close()




        Dim MnLogout As New ToolStripMenuItem("Logout")
        MenuLogout = MnLogout
        MenuLogout.Name = "Logout"
        MainMenu.Items.Add(MenuLogout)
        AddHandler MenuLogout.Click, AddressOf MenuItemClicked


        Controls.Add(MainMenu)
        MainMenu.BackColor = warna2
    End Sub


    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private m_ChildFormNumber As Integer


    Private Sub MDIParent1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        login.Dispose()
        Try
            ganti_password.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MDIParent1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            user_pengguna = Me.username.Text
            uraian = "Keluar dari aplikasi"
            insert_log_user()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ip.Text = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).ToString
        Dim prntDoc As New PrintDocument
        For Each PrinterName In PrinterSettings.InstalledPrinters
            pilihanprinter.Items.Add(PrinterName)
        Next

        pilihanprinter.Text = prntDoc.PrinterSettings.PrinterName

        cd = New MySqlCommand("SELECT * FROM data_kantor", koneksi)
        rd = cd.ExecuteReader
        rd.Read()
        nama_lembaga.Text = rd.Item("kantor_nama_lembaga")
        rd.Close()
        Me.Text = nama_aplikasi
        server_dan_database.Text = server.ToString + " (" + database + ")"

        ToolStrip2.BackColor = warna2
    End Sub

    Private Sub ToolStrip1_Paint(sender As Object, e As PaintEventArgs) Handles ToolStrip1.Paint

        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(ToolStrip1.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)

            e.Graphics.FillRectangle(d, ToolStrip1.ClientRectangle)
        Catch ex As Exception
            
        End Try
       
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateTimePicker1.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        waktu.Text = Format(DateTimePicker1.Value, "dd MMMM yyyy HH:mm:ss")
        hari.Text = Format(DateTimePicker1.Value, "dddd")
    End Sub

    Private Sub pilihanprinter_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.KeyChar = Chr(0)
    End Sub

    Private Sub btnmn0201_Click(sender As Object, e As EventArgs) Handles btnmn020101.Click
        close_menu_child()
        With master_nasabah_perorangan
            .StartPosition = FormStartPosition.Manual
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub btnmn0202_Click(sender As Object, e As EventArgs) Handles btnmn020201.Click
        close_menu_child()
        With master_rekening_tabungan
            .StartPosition = FormStartPosition.Manual
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub btnmn0203_Click(sender As Object, e As EventArgs) Handles btnmn020301.Click
        close_menu_child()
        With master_rekening_kredit
            .StartPosition = FormStartPosition.Manual
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub btnmn0301_Click(sender As Object, e As EventArgs) Handles btnmn030101.Click
        close_menu_child()
        With transaksi__tabungan
            .ShowDialog()
            .Focus()
        End With
    End Sub

    Private Sub btnmn0302_Click(sender As Object, e As EventArgs) Handles btnmn030201.Click
        close_menu_child()
        With transaksi_pencairan
            .ShowDialog()
            .Focus()
        End With
    End Sub

    Private Sub btnmn0303_Click(sender As Object, e As EventArgs) Handles btnmn030301.Click
        close_menu_child()
        With transaksi_angsuran_kredit
            .ShowDialog()
            .Focus()
        End With
    End Sub

    Private Sub btnmn0304_Click(sender As Object, e As EventArgs) Handles btnmn030401.Click
        close_menu_child()
        With transaksi_jurnal_kas
            .ShowDialog()
            .Focus()
        End With
    End Sub

    Private Sub btnmn0305_Click(sender As Object, e As EventArgs) Handles btnmn030501.Click
        close_menu_child()
        With transaksi_jurnal_non_kas
            .ShowDialog()
            .Focus()
        End With
    End Sub

    Private Sub btnmn030103_Click(sender As Object, e As EventArgs) Handles btnmn030103.Click
        close_menu_child()
        With cetak_rekening_koran
            .ShowDialog()
            .Focus()
        End With
    End Sub

   
    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Static currentChar As Integer
        Dim textfont As Font = New Font("Lucida Console", ukuran_font_cetak, FontStyle.Regular)

        Dim h, w As Integer
        Dim left, top As Integer
        With PrintDocument1.DefaultPageSettings
            h = 0
            w = 0
            left = kiri
            top = atas
        End With

        Dim lines As Integer = CInt(Math.Round(h / 1))
        Dim b As New Rectangle(left, top, w, h)
        Dim format As StringFormat
        format = New StringFormat(StringFormatFlags.LineLimit)
        Dim line, chars As Integer

        e.Graphics.MeasureString(Mid(TextToPrint, currentChar + 1), textfont, New SizeF(w, h), format, chars, line)
        e.Graphics.DrawString(TextToPrint.Substring(currentChar, chars), New Font("Lucida Console", ukuran_font_cetak, FontStyle.Regular), Brushes.Black, b, format)

        currentChar = currentChar + chars
        If currentChar < TextToPrint.Length Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            currentChar = 0
        End If
    End Sub

    Private Sub pilihanprinter_Click(sender As Object, e As EventArgs) Handles pilihanprinter.Click
        pilihanprinter.Items.Clear()
        For Each PrinterName In PrinterSettings.InstalledPrinters
            pilihanprinter.Items.Add(PrinterName)
        Next
    End Sub

    Private Sub pilihanprinter_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles pilihanprinter.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub MDIParent1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        For i As Integer = 0 To 5
            Me.Opacity = (i * 20) / 100
            Threading.Thread.Sleep(30)
            Windows.Forms.Application.DoEvents()
        Next
    End Sub

End Class
