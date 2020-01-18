Public Class fr_list_product
    Private _ListType As String = ""

    Private MaxPageData As Integer = 1
    Private SelectedPageData As Integer = 1
    'Private SearchParam As String = String.Empty

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
        SetDataGridColumns(_ListType)
        LoadDataGrid(1, "")
    End Sub

    Private Sub SetDataGridColumns(Datatype As String)
        Dim x_filler = New DataGridViewColumn
        x_filler = dgvcol_templ_id.Clone()
        x_filler.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Dim x As DataGridViewColumn()

        DataGridView_setDoubleBuffered(dgv_list, True)

        Select Case Datatype
            'Case "deposito"

            Case Else : Exit Sub
        End Select

        With dgv_list
            For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
            .AutoGenerateColumns = False
            .Columns.AddRange(x)
        End With
    End Sub

    'LOAD DATA TO DATAGRID
    Private Async Sub LoadDataGrid(Page As Integer, Optional Param As String = "")
        Dim dt As New DataTable
        Dim _typedata As String = _ListType
        Dim _limitdata As Integer = LimitDataPerPage
        Dim DataCount As Integer = 0
        Dim PageInfo As String = "{0}-{1} dari {2} data."

        'GETTING DATA FROM DATABASE (ASYNC/BG THREAD)
        Dim done As Boolean = False
        'Dim _switchCtrl() As Control = {bt_cl, pnl_top, bt_page_first, bt_page_last, bt_page_next, bt_page_prev}
        Dim _switchCtrl() As Control = {pnl_top, pnl_bottom}
        Try
            Me.Cursor = Cursors.WaitCursor : dgv_list.Cursor = Cursors.WaitCursor
            For Each ctr As Control In _switchCtrl : ctr.Enabled = False : Next

            dgv_list.DataSource = New DataTable
            'lbl_pageinfo.Text = String.Empty

            Dim _datalist = Await Task.Run(Function() GetDataListProduct(_typedata, Param, 0, 0))
            'Dim _datacount = Await Task.Run(Function() GetDataCountForLog(_typedata, _startdate, _enddate, Param))

            If _datalist.Result = True Then
                dgv_list.DataSource = _datalist.Value
                DataCount = _datalist.Value.Rows.Count
                MaxPageData = 1
                SelectedPageData = 1

                'DataCount = _datacount.Value
                'MaxPageData = CInt(Math.Ceiling(DataCount / _limitdata))
                'SelectedPageData = Page
                'PageInfo = String.Format(PageInfo,
                '                         If(dgv_list.RowCount > 0, 1, 0) + (_limitdata * Page) - _limitdata,
                '                         dgv_list.RowCount + (_limitdata * Page) - _limitdata,
                '                         DataCount
                '                         )
                'lbl_pageinfo.Text = PageInfo
            Else
                MaxPageData = 1
                SelectedPageData = 1
                'lbl_pageinfo.Text = String.Format(PageInfo, 0, 0, 0)
            End If

            'in_page.Text = SelectedPageData
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


    'UI :BUTTON
    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.ParentForm.Close()
    End Sub
End Class
