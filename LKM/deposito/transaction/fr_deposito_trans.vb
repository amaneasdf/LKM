Public Class fr_deposito_trans
    Private Enum InputState
        Insert
        Edit
    End Enum
    Private _FormState As InputState

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
    Public Sub DoLoadNew()
        LoadForm(InputState.Insert, "", "", True)
    End Sub

    Public Sub DoLoadEdit(TransID As String, TransTypeCode As String)
        LoadForm(InputState.Edit, TransID, TransTypeCode, False)
    End Sub

    Private Sub LoadForm(FormState As InputState, TransID As String, TransTypeCode As String, AllowEdit As Boolean)
        Me.Opacity = 0

        Try
            With cb_trans
                .DataSource = CBDatasource("trans_deposito")
                .ValueMember = "Value"
                .DisplayMember = "Text"
                .SelectedIndex = -1
            End With

            If FormState <> InputState.Insert Then
                Dim _ck = LoadDepositTrans(TransID, TransTypeCode)
                If Not _ck.Key Then
                    MessageBox.Show(_ck.Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            ControlSwitch_Setup(AllowEdit)
            Me.Show()
        Catch ex As Exception
            LogError(ex)
            MessageBox.Show("Terjadi kesalahan saat menampilkan form transaksi simpanan berjangka." & Environment.NewLine & "Error : " & ex.Message,
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub fr_deposito_trans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 100
    End Sub

    'CONTROL SWITCH
    Private Sub ControlSwitch_Setup(AllowEdit As Boolean)
        For Each txt As TextBox In {in_kuitansi, in_nominal, in_nominal1, in_nominal2, in_nominal_akhir}
            txt.ReadOnly = Not AllowEdit
        Next
        cb_trans.Enabled = AllowEdit
        bt_save.Enabled = AllowEdit
    End Sub

    Private Sub ControlSwitch_Trans(SelectedTrans As Integer)
        Dim _nom1enable, _nom2enable As Boolean
        Dim _nom1text, _nom2text As String
        Select Case SelectedTrans
            Case 1, 2
                _nom1enable = True : _nom1text = ""
                _nom2enable = True : _nom2text = ""
            Case 3
                _nom1enable = True : _nom1text = ""
                _nom2enable = False : _nom2text = ""
            Case Else : Exit Sub
        End Select

        in_nominal1.Visible = _nom1enable
        in_nominal2.Visible = _nom2enable
        lbl_nominal1.Visible = _nom1enable : lbl_nominal1.Text = _nom1text
        lbl_nominal2.Visible = _nom2enable : lbl_nominal2.Text = _nom2text
    End Sub

    'LOAD DATA TRANSAKSI DEPOSITO
    Private Function LoadDepositTrans(IDTrans As String, TransTypeCode As String) As KeyValuePair(Of Boolean, String)
        Try
            Dim _IdDeposito As String = ""
            Using x = New MySqlThing()
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = ""
                    Select Case Strings.Left(TransTypeCode, 1)

                    End Select
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using

            Dim _ck = LoadDeposito(_IdDeposito)
            Return _ck
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, "Terjadi kesalahan saat melakukan pengambilan data transaksi." & Environment.NewLine & "Error : " & ex.Message)
        End Try
    End Function

    'LOAD DATA DEPOSITO
    Private Function LoadDeposito(IDDeposit As String) As KeyValuePair(Of Boolean, String)
        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pwd))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = ""
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, "Terjadi kesalahan saat melakukan pengambilan data simpanan." & Environment.NewLine & "Error:" & ex.Message)
        End Try
    End Function

    'SAVE
    Private Sub SaveTrans(TransactType As String)
        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pwd))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = "" : Dim qArr As New List(Of String)
                    If _FormState = InputState.Insert Then
                        Select Case TransactType
                            Case "21.1", "21.2"
                                'INPUT SALDO POKOK DEPOSITO
                                'TRANSACTION
                                q = "INSERT INTO data_deposito_trans_pokok(trans_id, trans_kode, trans_kuitansi, trans_jumlah_masuk, trans_ob_jenis, " _
                                    & " trans_ob_rekening, trans_uraian, trans_status, trans_reg_date, trans_reg_time, trans_reg_alias, trans_reg_ip) " _
                                    & "SELECT CONCAT_WS('.', {0}, DATE_FORMAT(CURDATE(), '%Y%m%d'), LPAD(COUNT(up_id) + 1, 5, 0)), " _
                                    & " {1}, 1, CURDATE(), NOW(), '{2}', '{3}' " _
                                    & "FROM data_deposito_trans_pokok WHERE trans_reg_date=CURDATE()"

                                Dim _uraian As String = ""
                                If TransactType = "21.1" Then
                                    _uraian = String.Format("Setoran Tunai Rek. {0} / {1} ({2})", in_rek1.Text, in_cif.Text, in_nasabah_nama.Text)
                                Else
                                    _uraian = String.Format("Setoran OB dari Tabungan No. Rek. {0} / {1} ({2})", in_rek1.Text, in_cif.Text, in_nasabah_nama.Text)
                                End If
                                qArr.Add(
                                    String.Format(q, TransactType.Split(".")(0),
                                                  String.Join(",", {"'" & TransactType & "'",
                                                                    "'" & in_kuitansi.Text & "'",
                                                                    removeCommaThousand(in_nominal.Text).ToString.Replace(",", "."),
                                                                    TransactType.Split(".")(1),
                                                                    "'" & If(TransactType = "21.2", "", in_rektujuan.Text) & "'",
                                                                    "'" & _uraian & "'"
                                                                   }
                                                               ), LoggedUser.User_Alias, LoggedUser.User_IP
                                                           )
                                                       )

                                'VALUTA & STUFF
                                qArr.Add(String.Format("CALL deposito_inputvaluta('{0}', '{1}')",
                                                       in_rek1.Text, removeCommaThousand(in_nominal.Text).ToString.Replace(",", "."))
                                                   )

                            Case "22.1", "22.2"
                                'PENCAIRAN DEPOSITO
                                'GET NILAI BUNGA
                                Dim _bunga As Decimal = 0

                                'TRANSACTION
                                q = "INSERT INTO data_deposito_trans_pokok(trans_id, trans_kode, trans_kuitansi, trans_jumlah_keluar) " _
                                    & "SELECT CONCAT_WS('.',  {0}, DATE_FORMAT(CURDATE(), '%Y%m%d'), LPAD(COUNT(up_id) + 1, 5, 0)) " _
                                    & "FROM data_deposito_trans_pokok WHERE trans_reg_date=CURDATE()"

                            Case "23.1", "23.2"
                                'PENCAIRAN BUNGA

                        End Select

                        Dim _ck = x.TransactCommand(qArr)
                        If _ck Then
                            MessageBox.Show("Data transaksi berhasil disimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else

                        End If
                    End If
                Else
                    MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            MessageBox.Show("Terjadi kesalahan saat melakukan penyimpanan transaksi." & Environment.NewLine & "Error : " & ex.Message,
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'UI : BUTTON
    Private Sub btnvalidasi_Click(sender As Object, e As EventArgs) Handles bt_save.Click
        'CHECK INPUT
        If String.IsNullOrWhiteSpace(in_rek1.Text) Then
            MessageBox.Show("Rekening simpanan belum dipilih.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            bt_search_deposito.Focus() : Exit Sub
        Else
            'CHECK IF SAVING ACCOUNT DATA PROPERLY RETREIVED

        End If

        Dim _tc = cb_trans.SelectedValue.ToString.Split(".")(0)
        Dim _tc2 = cb_trans.SelectedValue.ToString.Split(".")(1)
        If _tc = "31" Then
            'IF TRANSACTION IS 'SETORAN POKOK(?)'

        ElseIf _tc = "32" Then
            'IF TRANSACTION IS 'PENCAIRAN POKOK'

        ElseIf _tc = "33" Then
            'IF TRANSACTION IS 'PENCAIRAN BUNGA'

        Else : Exit Sub
        End If

    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles bt_new.Click
        Dim x = New fr_deposito_trans
        x.DoLoadNew() : Me.Close()
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub bt_search_tabungan_Click(sender As Object, e As EventArgs) Handles bt_search_deposito.Click, bt_cari_tabungan.Click

    End Sub
End Class