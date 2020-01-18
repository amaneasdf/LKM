Public Class fr_deposito_product_det
    Private _DataID As String = ""

    'STYLE
    Private m_aeroEnabled As Boolean = False
    Private Const CS_DROPSHADOW As Int32 = &H20000
    Private Const WM_NCPAINT As Int32 = 133
    Private Const WM_ACTIVATEAPP As Int32 = 28

    Private Const WM_NCHITTEST As Int32 = &H84
    Private Const HTCLIENT As Int32 = &H1
    Private Const HTCAPTION As Int32 = &H2

    'DROP SHADOW
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            m_aeroEnabled = CheckAeroEnabled()

            Dim parameters As CreateParams = MyBase.CreateParams
            If Not m_aeroEnabled Then parameters.ClassStyle += CS_DROPSHADOW
            Return parameters
        End Get
    End Property

    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case WM_NCPAINT
                If m_aeroEnabled Then
                    Dim v = 2
                    DwmSetWindowAttribute(Me.Handle, 2, v, 4)
                    Dim margins As New Margins With {
                        .bottomHeight = 1,
                        .leftWidth = 0,
                        .rightWidth = 0,
                        .topHeight = 0
                        }
                    DwmExtendFrameIntoClientArea(Me.Handle, margins)
                End If
        End Select
        MyBase.WndProc(m)
        If (m.Msg = WM_NCHITTEST AndAlso m.Result.ToInt32 = HTCLIENT) Then m.Result = HTCAPTION
    End Sub

    'LOAD FORM
    Public Sub DoLoadForm(ProductId As String, AllowEdit As Boolean)
        Me.Opacity = 0
        ControlSwitch(AllowEdit)

        Dim _Lo = DoLoadData(ProductId)
        If Not _Lo.Key Then
            MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data produk." & Environment.NewLine & _Lo.Value,
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Me.Show()
        End If
    End Sub

    Private Sub fr_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 100
    End Sub

    'CONTROL SWITCH
    Private Sub ControlSwitch(AllowEdit As Boolean)
        bt_save.Enabled = AllowEdit
        For Each _num As NumericUpDown In {}
            _num.Enabled = AllowEdit
            If AllowEdit Then
                AddHandler _num.Enter, AddressOf in_qty_Enter
                AddHandler _num.Leave, AddressOf in_qty_Leave
            End If
        Next
    End Sub

    'LOAD DATA
    Private Function DoLoadData(ProductID As String) As KeyValuePair(Of Boolean, String)
        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pwd))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    _DataID = ProductID
                    Dim q As String = "SELECT produk_valuta1, produk_valuta2, produk_1bln, produk_2bln, produk_3bln, produk_4bln, produk_5bln, " _
                                      & "produk_6bln, produk_7bln, produk_8bln, produk_9bln, produk_10bln, produk_11bln, produk_12bln, produk_24bln, " _
                                      & "produk_upd_date, produk_upd_alias " _
                                      & "FROM data_deposito_produk WHERE produk_id = '{0}'"
                    Using rdx = x.ReadCommand(String.Format(q, ProductID))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            in_valuta1.Value = rdx.Item("produk_valuta1")
                            in_valuta2.Value = rdx.Item("produk_valuta2")
                            For i = 1 To 12
                                Dim _col As String = String.Format("produk_{0}bln", i)
                                Dim _cont = pnl_content.Controls.Find(String.Format("in_{0}bln", i), False)
                                DirectCast(_cont(0), NumericUpDown).Value = rdx.Item(_col)
                            Next
                            in_24bln.Value = rdx.Item("produk_24bln")
                        End If
                    End Using

                    Return New KeyValuePair(Of Boolean, String)(True, "")
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, ex.Message)
        End Try
    End Function

    'SAVE DATA
    Private Function SaveData() As KeyValuePair(Of Boolean, String)
        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pwd))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = ""

                    'INSERT HISTORY
                    q = "INSERT INTO data_deposito_produk_riwayat(produk_master_id, produk_valuta1, produk_valuta2, produk_1bln, produk_2bln, produk_3bln, " _
                        & " produk_4bln, produk_5bln, produk_6bln, produk_7bln, produk_8bln, produk_9bln, produk_10bln, produk_11bln, produk_12bln, produk_24bln, " _
                        & " produk_autoupdate, produk_reg_date, produk_reg_ip, produk_reg_alias) " _
                        & "SELECT produk_id, produk_valuta1, produk_valuta2, produk_1bln, produk_2bln, produk_3bln, produk_4bln, produk_5bln, " _
                        & " produk_6bln, produk_7bln, produk_8bln, produk_9bln, produk_10bln, produk_11bln, produk_12bln, produk_24bln, " _
                        & " produk_autoupdate, produk_upd_date, produk_upd_ip, produk_upd_alias " _
                        & "FROM data_deposito_produk WHERE produk_id='{0}'"
                    x.ExecCommand(String.Format(q, _DataID))

                    'UPDATE DATA
                    q = "UPDATE data_deposito_produk SET {0} WHERE produk_id='{1}'"
                    Dim _df = New List(Of String) From {"produk_valuta1=" & in_valuta1.Value.ToString.Replace(",", "."),
                                                        "produk_valuta2=" & in_valuta2.Value.ToString.Replace(",", "."),
                                                        "produk_upd_date=CURDATE()",
                                                        "produk_upd_ip='" & LoggedUser.User_IP & "'",
                                                        "produk_upd_alias='" & LoggedUser.User_Alias & "'"
                                                       }
                    For i = 1 To 12
                        Dim _cont = pnl_content.Controls.Find(String.Format("in_{0}bln", i), False)
                        _df.Add(String.Format(
                                "produk_{0}bln={1}",
                                i, DirectCast(_cont(0), NumericUpDown).Value.ToString.Replace(",", ".")
                                )
                            )
                    Next
                    _df.Add("produk_24bln=" & in_24bln.Value.ToString.Replace(",", "."))
                    x.ExecCommand(String.Format(q, String.Join(",", _df), _DataID))

                    Return New KeyValuePair(Of Boolean, String)(True, "")
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, ex.Message)
        End Try
    End Function

    'SHOW DATA CHANGE HISTORY
    Private Sub ShowHistoire(ProductID As String)

    End Sub

    'UI : DRAG FORM
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles pnl_top.MouseDown, lbl_judul.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles pnl_top.MouseMove, lbl_judul.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles pnl_top.MouseUp, lbl_judul.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles pnl_top.DoubleClick, lbl_judul.DoubleClick
        CenterToScreen()
    End Sub

    'UI : FORM
    Private Sub fr_beli_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_close.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            bt_save.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    'UI : BUTTON
    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub bt_save_Click(sender As Object, e As EventArgs) Handles bt_save.Click
        If in_valuta2.Value = 0 Then
            MessageBox.Show("Nilai maksimum simpanan tidak boleh 0.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_valuta2.Focus() : Exit Sub
        ElseIf in_valuta2.Value < in_valuta1.Value Then
            MessageBox.Show("Nilai maksimum simpanan tidak boleh kurang dari nilai minimum.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_valuta2.Focus() : Exit Sub
        End If

        Dim _x = SaveData()
        If Not _x.Key Then
            MessageBox.Show("Tidak dapat menyimpan pengaturan produk." & Environment.NewLine & _x.Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("Pengaturan produk tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub bt_history_Click(sender As Object, e As EventArgs) Handles bt_history.Click
        ShowHistoire(_DataID)
    End Sub

    'UI : NUMERIC INPUT
    Private Sub in_qty_Enter(sender As Object, e As EventArgs)
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs)
        numericLostFocus(sender)
    End Sub
End Class