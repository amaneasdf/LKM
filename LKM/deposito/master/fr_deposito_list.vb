Public Class fr_deposito_list
    Private _ListType As String = ""

    Private MaxPageData As Integer = 1
    Private SelectedPageData As Integer = 1
    Private SearchParam As String = String.Empty

    'LOAD USERCONTROL
    Public Sub LoadControl(ParentControl As Control, ListType As String, Title As String)
        _ListType = ListType
        Me.lbl_judul.Text = Title
        Me.Dock = DockStyle.Fill
        ParentControl.Controls.Add(Me)

        PerformRefresh()
    End Sub

    Private Sub PerformRefresh()
        dgv_list.Columns.Clear()
        in_search.Clear() : SearchParam = String.Empty
        SetDataGridColumns(_ListType)
        MaxPageData = 1 : SelectedPageData = 1
        'LoadDataGrid(1, "")
    End Sub

    'SETUP DATAGRID
    Private Sub SetDataGridColumns(Datatype As String)
        Dim x_filler = New DataGridViewColumn
        x_filler = dgvcol_templ_id.Clone()
        x_filler.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Dim x As DataGridViewColumn()

        DataGridView_setDoubleBuffered(dgv_list, True)

        Dim dep_rekening = dgvcol_templ_status.Clone()
        Dim dep_bilyet = dgvcol_templ_status.Clone()
        Dim dep_nasabah = dgvcol_templ_status.Clone()
        Dim dep_nasabah_nm = dgvcol_templ_status.Clone()
        Dim dep_nominal = dgvcol_templ_numeric.Clone()
        Dim dep_tglawal = dgvcol_templ_status.Clone()
        Dim dep_jkw = dgvcol_templ_status.Clone()
        Dim dep_jthtempo = dgvcol_templ_status.Clone()
        Dim dep_status = dgvcol_templ_status.Clone()

        dep_rekening.Name = "dep_rekening" : dep_rekening.DataPropertyName = "dep_rekening" : dep_rekening.HeaderText = "No.Rekening"
        dep_bilyet.Name = "dep_bilyet" : dep_bilyet.DataPropertyName = "dep_bilyet" : dep_bilyet.HeaderText = "No.Bilyet"
        dep_nasabah.Name = "dep_nasabah" : dep_nasabah.DataPropertyName = "dep_nasabah" : dep_nasabah.HeaderText = "ID Nasabah"
        dep_nasabah_nm.Name = "dep_nasabah_nm" : dep_nasabah_nm.DataPropertyName = "nasabah_nama1" : dep_nasabah_nm.HeaderText = "Nama Nasabah"
        dep_nominal.Name = "dep_nominal" : dep_nominal.DataPropertyName = "dep_nominal" : dep_nominal.HeaderText = "Nominal Awal"
        dep_tglawal.Name = "dep_tglawal" : dep_tglawal.DataPropertyName = "dep_tgl_awal" : dep_tglawal.HeaderText = "Tgl. Pembukaan"
        dep_jkw.Name = "dep_jkw" : dep_jkw.DataPropertyName = "dep_jkw" : dep_jkw.HeaderText = "Jangka"
        dep_jthtempo.Name = "dep_jthtempo" : dep_jthtempo.DataPropertyName = "dep_tgl_jthtempo" : dep_jthtempo.HeaderText = "Tgl. Jatuh Tempo"
        dep_status.Name = "dep_status" : dep_status.DataPropertyName = "dep_status" : dep_status.HeaderText = "Status"

        For Each _c As DataGridViewColumn In {dep_rekening, dep_bilyet, dep_nasabah, dep_nominal}
            _c.Width = 150
        Next
        For Each _c As DataGridViewColumn In {dep_tglawal, dep_jthtempo}
            _c.Width = 120
            _c.DefaultCellStyle = dgvstyle_date
        Next
        dep_nasabah_nm.Width = 275
        dep_nominal.DefaultCellStyle = dgvstyle_commathousand

        x = {dep_rekening, dep_bilyet, dep_nasabah, dep_nasabah_nm, dep_nominal, dep_tglawal, dep_jkw, dep_jthtempo, dep_status, x_filler}

        With dgv_list
            For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
            .AutoGenerateColumns = False
            .Columns.AddRange(x)
        End With
    End Sub

    'LOAD DATA TO DATAGRID
    Private Async Sub LoadDataGrid(Page As Integer, Optional Param As String = "")
        Dim dt As New DataTable
        Dim _typedata As String = "rek_" & _ListType
        Dim _limitdata As Integer = LimitDataPerPage
        Dim DataCount As Integer = 0
        Dim PageInfo As String = "{0}-{1} dari {2} data."

        'GETTING DATA FROM DATABASE (ASYNC/BG THREAD)
        Dim done As Boolean = False
        Dim _switchCtrl() As Control = {in_search, bt_search, bt_del, bt_edit, bt_add, bt_cl, pnl_bottom}
        Try
            Me.Cursor = Cursors.WaitCursor : dgv_list.Cursor = Cursors.WaitCursor
            For Each ctr As Control In _switchCtrl : ctr.Enabled = False : Next

            dgv_list.DataSource = New DataTable
            'lbl_pageinfo.Text = String.Empty

            Dim _datalist = Await Task.Run(Function() GetDataListRekening(_typedata, Param, 0, 0))

            If _datalist.Result = True Then
                dgv_list.DataSource = _datalist.Value
                DataCount = _datalist.Value.Rows.Count
                MaxPageData = 1
                SelectedPageData = 1
            Else
                MaxPageData = 1
                SelectedPageData = 1
            End If

            done = True
        Catch ex As Exception
            LogError(ex)
            MessageBox.Show("Terjadi kesalahan saat pengambilan data." & Environment.NewLine & ex.Message,
                            lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            done = True
        Finally
            If done Then
                Me.Cursor = Cursors.Default : dgv_list.Cursor = Cursors.Default
                For Each ctr As Control In _switchCtrl : ctr.Enabled = True : Next
                dgv_list.ClearSelection()
            End If
        End Try
    End Sub

    'CHECK DEPOSITO STATUS
    Private Function CheckDepositoStatus(IdDeposito As String) As KeyValuePair(Of Boolean, String)
        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pwd))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = "SELECT dep_status FROM data_deposito_master WHERE dep_rekening='{0}'"
                    Dim _c = Integer.Parse(x.ExecScalar(String.Format(q, IdDeposito)))
                    Return New KeyValuePair(Of Boolean, String)(True, _c)
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, ex.Message)
        End Try
    End Function

    'DELETE REKENING DEPOSITO
    Private Sub DeleteDeposito(IdDeposito As String, Optional CheckStatus As Boolean = False)
        'CHECK DATA STATUS
        If CheckStatus Then
            Dim _ss = CheckDepositoStatus(IdDeposito)
            If _ss.Key Then
                If _ss.Value > 0 Then
                    MessageBox.Show("Rekening simpanan tidak dapat dihapus. Status rekening telah aktif.", lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                MessageBox.Show("Terjadi kesalahan saat melakukan proses penghapusan data." & Environment.NewLine & _ss.Key,
                                lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        Try
            Using x = New MySqlThing()
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    'UPDATE STATUS
                    Dim q As String = "UPDATE data_deposito_master SET dep_status=9 WHERE dep_rekening='{0}'"
                    x.ExecCommand(String.Format(q, IdDeposito))
                    MessageBox.Show("Data rekening simpanan berhasil dihapus.", lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'REFRESH LIST
                    Dim _param = SearchParam
                    PerformRefresh() : in_search.Text = _param
                    LoadDataGrid(1, _param)
                Else
                    MessageBox.Show("Tidak dapat terhubung ke database.", lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            MessageBox.Show("Terjadi kesalahan saat melakukan proses penghapusan data." & Environment.NewLine & ex.Message,
                                lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'UI :BUTTON
    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.ParentForm.Close()
    End Sub

    Private Sub bt_add_Click(sender As Object, e As EventArgs) Handles bt_add.Click
        Dim x = New fr_deposito_detail
        x.DoLoadNew()
    End Sub

    Private Sub bt_edit_Click(sender As Object, e As EventArgs) Handles bt_edit.Click
        If dgv_list.SelectedRows.Count > 0 Then
            Dim x = New fr_deposito_detail
            x.DoLoadEdit(dgv_list.SelectedRows(0).Cells(0).Value, True)
        End If
    End Sub

    Private Sub bt_del_Click(sender As Object, e As EventArgs) Handles bt_del.Click
        If dgv_list.SelectedRows.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim _kode = dgv_list.SelectedRows(0).Cells(0).Value
            Dim _ss = CheckDepositoStatus(_kode)
            If _ss.Key Then
                If _ss.Value > 0 Then
                    MessageBox.Show("Rekening simpanan tidak dapat dihapus. Status rekening telah aktif.", lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If MessageBox.Show(String.Format("Hapus data rekening simpanan nomor {0}?", _kode), lbl_judul.Text,
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        DeleteDeposito(_kode)
                    End If
                End If
            Else
                MessageBox.Show("Terjadi kesalahan saat melakukan proses penghapusan data." & Environment.NewLine & _ss.Key,
                                lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub bt_search_Click(sender As Object, e As EventArgs) Handles bt_search.Click
        If String.IsNullOrEmpty(in_search.Text) Then
            PerformRefresh()
        Else
            LoadDataGrid(1, in_search.Text)
        End If
    End Sub

    'UI : INPUT
    Private Sub in_search_KeyDown(sender As Object, e As KeyEventArgs) Handles in_search.KeyDown
        If e.KeyCode = Keys.Enter Then
            bt_search.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
End Class
