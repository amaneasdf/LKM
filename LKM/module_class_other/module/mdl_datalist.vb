Module mdl_datalist
    Public Structure DataListReturn
        Public Result As Boolean
        Public Value As DataTable
        Public DataCount As Integer
        Public Msg As String
        Public DialogIcon As MessageBoxIcon
    End Structure

    Public Function GetDataListProduct(ProductType As String, Optional ParamString As String = "",
                                       Optional PageNum As Integer = 0, Optional PageLimit As Integer = 0) As DataListReturn
        If MainConnData.IsEmpty Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim q, qlimit As String

        ProductType = LCase(ProductType)
        If Not String.IsNullOrWhiteSpace(ParamString) Then
            ParamString = mysqlQueryFriendlyStringFeed(ParamString)
            ParamString = Trim(ParamString).Replace(" ", ".+").Replace("(", "[(]").Replace(")", "[)]")
        End If

        If PageNum > 0 And PageLimit > 0 Then
            Dim _start As Integer = (PageNum - 1) * PageLimit
            qlimit = String.Format("LIMIT {0}, {1}", _start, PageLimit)
        Else
            qlimit = ""
        End If

        Try
            Using x = New MySqlThing()
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim _dt As New DataTable
                    Select Case ProductType
                        'Case "deposito"
                        '    q = "SELECT product_id, product_valuta1, product_valuta2, "

                        Case Else
                            Return New DataListReturn With {.Result = False, .Msg = "Wrong product type input.", .DialogIcon = MessageBoxIcon.Error}
                    End Select

                    Return New DataListReturn With {.Result = True, .Value = _dt, .DialogIcon = MessageBoxIcon.None}
                Else
                    Return New DataListReturn With {.Result = False, .Msg = "Tidak dapat terhubung ke database.", .DialogIcon = MessageBoxIcon.Error}
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New DataListReturn With {.Result = False, .Msg = ex.Message, .DialogIcon = MessageBoxIcon.Error}
        End Try
    End Function

    'GET DATA REKENING
    Public Function GetDataListRekening(ProductType As String, Optional ParamString As String = "",
                                       Optional PageNum As Integer = 0, Optional PageLimit As Integer = 0) As DataListReturn
        If MainConnData.IsEmpty Then
            Return New DataListReturn With {.Result = False, .Msg = "Main db connection setting is empty.", .DialogIcon = MessageBoxIcon.Error}
        End If

        ProductType = LCase(ProductType)

        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pwd))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim _dt As New DataTable : Dim _ct As Integer = 0

                    'CREATE PARAMETER DICTIONARY FOR QUERY BUILDER
                    Dim _ParamDict As New Dictionary(Of String, String)
                    _ParamDict.Add("search", ParamString)

                    _dt = x.GetDataTable(QueryBuilder_Datalist(ProductType, _ParamDict, PageNum, PageLimit))
                    _ct = x.ExecScalar(QueryBuilder_Datacount(ProductType, _ParamDict))

                    Return New DataListReturn With {.Result = True, .Value = _dt, .DataCount = _ct, .DialogIcon = MessageBoxIcon.None}
                Else
                    Return New DataListReturn With {.Result = False, .Msg = "Tidak dapat terhubung ke database.", .DialogIcon = MessageBoxIcon.Error}
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New DataListReturn With {.Result = False, .Msg = ex.Message, .DialogIcon = MessageBoxIcon.Error}
        End Try
    End Function

    'BUILD QUERY FOR DATATABLE
    Private Function QueryBuilder_Datalist(DataType As String, ParamDict As Dictionary(Of String, String), PageNum As Integer, Rowlimit As Integer) As String
        Dim q, qwhere, qlimit As String

        If PageNum > 0 And Rowlimit > 0 Then
            Dim _start As Integer = (PageNum - 1) * Rowlimit
            qlimit = String.Format("LIMIT {0},{1}", _start, Rowlimit)
        Else
            qlimit = ""
        End If

        Select Case DataType
            Case "rek_deposito"
                Dim _SearchParam = ParamDict("search").ToString

                q = "SELECT dep_rekening, dep_bilyet, dep_nasabah, nasabah_nama1, dep_nominal, dep_tgl_awal, dep_jkw, dep_tgl_jthtempo, dep_status " _
                    & "FROM data_deposito_master " _
                    & "LEFT JOIN data_nasabah ON nasabah_id = dep_nasabah " _
                    & "WHERE dep_rekening < 9 {0} {1}"

                If String.IsNullOrWhiteSpace(_SearchParam) Then
                    qwhere = ""
                Else
                    _SearchParam = mysqlQueryFriendlyStringFeed(_SearchParam)
                    _SearchParam = _SearchParam.Trim.Replace(" ", ".+").Replace("(", "[(]").Replace(")", "[)]")

                    qwhere = String.Join("'" & _SearchParam & "'", {"AND(dep_rekening REGEXP ", " OR dep_bilyet REGEXP ",
                                                                    " OR dep_nasabah REGEXP ", " OR nasabah_nama1 REGEXP ", ")"})
                End If

                Return String.Format(q, qwhere, qlimit)
            Case Else
                Return String.Empty
        End Select
    End Function

    'BUILD QUERY FOR DATACOUNT
    Private Function QueryBuilder_Datacount(DataType As String, ParamDict As Dictionary(Of String, String)) As String
        Dim q, qwhere As String

        Select Case DataType
            Case "rek_deposito"
                Dim _SearchParam = ParamDict("search").ToString

                q = "SELECT COUNT(dep_rekening) FROM data_deposito_master{0}" _
                    & "WHERE dep_rekening < 9{1}"

                If String.IsNullOrWhiteSpace(_SearchParam) Then
                    q = String.Format(q, "", "{0}")
                    qwhere = ""
                Else
                    q = String.Format(q, " LEFT JOIN data_nasabah ON nasabah_id = dep_nasabah ", "{0}")
                    _SearchParam = mysqlQueryFriendlyStringFeed(_SearchParam)
                    _SearchParam = _SearchParam.Trim.Replace(" ", ".+").Replace("(", "[(]").Replace(")", "[)]")

                    qwhere = String.Join("'" & _SearchParam & "'", {" AND(dep_rekening REGEXP ", " OR dep_bilyet REGEXP ",
                                                                    " OR dep_nasabah REGEXP ", " OR nasabah_nama1 REGEXP ", ")"})
                End If

                Return String.Format(q, qwhere)
            Case Else
                Return String.Empty
        End Select
    End Function
End Module
