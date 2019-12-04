Public Class fr_deposito_product
    Private _ListType As String = ""

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

    End Sub


    'UI :BUTTON
    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.ParentForm.Close()
    End Sub
End Class
