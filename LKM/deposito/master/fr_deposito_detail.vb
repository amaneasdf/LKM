Public Class fr_deposito_detail
    Private Enum FormState
        Insert
        Edit
    End Enum

    Private _FormState As FormState
    Private _AllowEdit As Boolean

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
    Private Sub DoLoadForm(State As FormState, AllowEdit As Boolean, Optional IdData As String = "")
        _FormState = State : Me.Opacity = 0

        For Each cbo As ComboBox In {cb_status, cb_pemilik, cb_hubungan, cb_jangka, cb_perlakuan_pokok, cb_perlakuan_bunga, cb_perpanjang}
            Dim _type As String = "" : Dim _idx As Integer = -1
            Select Case cbo.Name
                Case cb_status.Name : _type = "rekening_status" : _idx = 0
                Case cb_pemilik.Name : _type = "kode_pemilik"
                Case cb_hubungan.Name : _type = "kode_hubungan"
                Case cb_jangka.Name : _type = "deposito_jangka"
                Case cb_perlakuan_pokok.Name : _type = "deposito_perlakuan_pokok"
                Case cb_perlakuan_bunga.Name : _type = "deposito_perlakuan_bunga"
                Case cb_perpanjang.Name : _type = "deposito_perpanjang"
                Case Else : GoTo NextCbo
            End Select

            cbo.DataSource = CBDatasource(_type)
            cbo.ValueMember = "Value"
            cbo.DisplayMember = "Text"
            If cbo.DisplayMember.Count > 0 Then cbo.SelectedIndex = _idx
            AddHandler cbo.KeyPress, AddressOf cb_bank_KeyPress
            AddHandler cbo.SelectionChangeCommitted, AddressOf cb_pemilik_SelectionChangeCommitted
NextCbo:
        Next

        If _FormState = FormState.Edit Then
            Dim _x = DoLoadData(IdData)
            If Not _x.Key Then
                MessageBox.Show(_x.Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_status.SelectedValue > 1 Then AllowEdit = False
        End If

        ControlSwitch(AllowEdit)
        Me.Owner = MDIParent1 : Me.Show()
    End Sub

    Public Sub DoLoadNew(Optional AllowEdit As Boolean = True)
        DoLoadForm(FormState.Insert, AllowEdit)
    End Sub

    Public Sub DoLoadEdit(IdData As String, AllowEdit As Boolean)
        DoLoadForm(FormState.Edit, AllowEdit, IdData)
    End Sub

    Private Sub fr_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 100
    End Sub

    'CONTROL SWITCH
    Private Sub ControlSwitch(AllowInput As Boolean)
        _AllowEdit = AllowInput
        If _FormState = FormState.Edit Then
            Dim _enable, _readonly As Boolean
            If cb_status.SelectedValue = 0 And AllowInput Then
                'IF ENTRY STILL INACTIVE AND USER ARE ALLOWED TO EDIT IT
                _enable = True : _readonly = False
            Else
                _enable = False : _readonly = True
            End If

            'UNEDITABLE INPUT
            For Each ctr As Control In {bt_search_nasabah, date_tglmulai, cb_jangka, cb_perlakuan_bunga, cb_perpanjang}
                ctr.Enabled = _enable
            Next
            For Each txt As TextBox In {in_bilyet, in_nasabah_id}
                txt.ReadOnly = _readonly
            Next
            in_nominal_awal.Visible = _enable
            in_nominalawal_view.Visible = Not _enable
            bt_data_nasabah.Enabled = True
            bt_data_pelengkap.Enabled = True
            bt_statement.Enabled = True

            'OTHER INPUT
            For Each _ctr As Control In {in_rek2, in_tujuan, in_ahliwaris, cb_hubungan, cb_perlakuan_pokok}
                _ctr.Enabled = AllowInput
            Next
        Else
            in_nominal_awal.Width = in_nominalawal_view.Width
            in_nominalawal_view.Visible = False

            bt_data_nasabah.Enabled = False
            bt_data_pelengkap.Enabled = False
            bt_statement.Enabled = False
            bt_search_tabungan.Enabled = False
        End If
        bt_save.Enabled = AllowInput
    End Sub

    'LOAD DATA
    Private Function DoLoadData(IdData As String) As KeyValuePair(Of Boolean, String)
        Try
            If String.IsNullOrEmpty(IdData) Then Return New KeyValuePair(Of Boolean, String)(False, "Data ID is empty.")
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pwd))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = "SELECT dep_rekening, dep_alternatif, dep_bilyet, dep_nasabah, dep_kode_pemilik, dep_tujuanpeng, " _
                                      & "dep_waris_nama, dep_waris_hubungan, dep_jkw, dep_tgl_awal, dep_bunga_persen, dep_nominal, " _
                                      & "dep_tgl_jthtempo, dep_perlakuan, dep_perlakuan_bunga, dep_nilai_valuta, CAST(dep_tgl_valuta AS CHAR) dep_tgl_valuta, " _
                                      & "dep_tabungan, dep_ppj_sistem, dep_ppj_jumlah, dep_status, dep_close_date " _
                                      & "FROM data_deposito_master WHERE dep_rekening='{0}'"
                    Using rdx = x.ReadCommand(String.Format(q, IdData))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            'ID
                            in_rek1.Text = rdx.Item("dep_rekening")
                            in_rek2.Text = rdx.Item("dep_alternatif")
                            in_bilyet.Text = rdx.Item("dep_bilyet")

                            'NASABAH
                            in_nasabah_id.Text = rdx.Item("dep_nasabah")
                            cb_pemilik.SelectedValue = rdx.Item("dep_kode_pemilik")
                            in_pemilik_kode.Text = rdx.Item("dep_kode_pemilik")
                            in_tujuan.Text = rdx.Item("dep_tujuanpeng")
                            in_ahliwaris.Text = rdx.Item("dep_waris_nama")
                            cb_hubungan.SelectedValue = rdx.Item("dep_waris_hubungan")

                            'CONFIG / INFO
                            RemoveHandler cb_jangka.SelectionChangeCommitted, AddressOf cb_pemilik_SelectionChangeCommitted
                            in_nominalawal_view.Text = commaThousand(rdx.Item("dep_nominal"))
                            in_nominal_awal.Value = rdx.Item("dep_nominal")
                            cb_jangka.SelectedValue = rdx.Item("dep_jkw")
                            in_bunga.Text = rdx.Item("dep_bunga_persen")
                            cb_perlakuan_pokok.SelectedValue = rdx.Item("dep_perlakuan")
                            in_kode_perlakuan.Text = rdx.Item("dep_perlakuan")
                            cb_perlakuan_bunga.SelectedValue = rdx.Item("dep_perlakuan_bunga")
                            in_kode_perlakuan_b.Text = rdx.Item("dep_perlakuan_bunga")
                            in_tabungantujuan.Text = rdx.Item("dep_tabungan")
                            cb_perpanjang.SelectedValue = rdx.Item("dep_ppj_sistem")
                            in_kode_perpanjang.Text = rdx.Item("dep_ppj_sistem")
                            in_perpanjang_times.Text = rdx.Item("dep_ppj_jumlah")
                            in_tgl_jt.Text = rdx.Item("dep_tgl_jthtempo")
                            in_nilai_valuta.Text = rdx.Item("dep_nilai_valuta")
                            in_tgl_valuta.Text = rdx.Item("dep_tgl_valuta")
                            cb_status.SelectedValue = rdx.Item("dep_status")
                            in_tgl_closing.Text = rdx.Item("dep_close_date")
                            AddHandler cb_jangka.SelectionChangeCommitted, AddressOf cb_pemilik_SelectionChangeCommitted
                        Else
                            Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat menemukan data dengan nomor rekening " & IdData & ".")
                        End If
                    End Using

                    Dim _n = GetNasabahData(in_nasabah_id.Text)
                    Return _n
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, ex.Message)
        End Try
    End Function

    'GET DATA NASABAH
    Private Function GetNasabahData(IdNasabah As String) As KeyValuePair(Of Boolean, String)
        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pwd))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = "SELECT nasabah_nama1, nasabah_nik, nasabah_alamat FROM data_nasabah WHERE nasabah_id='{0}'"
                    Using rdx = x.ReadCommand(String.Format(q, IdNasabah))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            in_nasabah_id.Text = IdNasabah
                            in_nasabah_nama.Text = rdx.Item("nasabah_nama1")
                            in_nasabah_nik.Text = rdx.Item("nasabah_nik")
                            in_nasabah_alamat.Text = rdx.Item("nasabah_alamat")

                        Else
                            Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat menemukan data nasabah " & IdNasabah & ".")
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

    'GET NILAI BUNGA PER JANGKA BULAN
    Private Function GetBunga(JangkaBulan As Integer) As KeyValuePair(Of Boolean, String)
        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pwd))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = "SELECT produk_{0}bln FROM data_deposito_produk WHERE produk_id=1"
                    Dim _s = Decimal.Parse(x.ExecScalar(String.Format(q, JangkaBulan)))

                    Return New KeyValuePair(Of Boolean, String)(True, commaThousand(_s))
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, ex.Message)
        End Try
    End Function

    'CHECK MIN MAX DEPOSITO VALUE
    Private Function CheckMinMaxValueNominal(InputedNominal As Decimal) As KeyValuePair(Of Boolean, String)
        Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pwd))
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _min, _max As Decimal
                Dim q = "SELECT produk_valuta1, produk_valuta2 FROM data_deposito_produk WHERE produk_id=1"
                Using rdx = x.ReadCommand(q)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _min = rdx.Item("produk_valuta1")
                        _max = rdx.Item("produk_valuta2")
                    Else
                        Return New KeyValuePair(Of Boolean, String)(False, "Data produk simpanan berjangka tidak dapat ditemukan")
                    End If
                End Using
                If InputedNominal < _min Then
                    Return New KeyValuePair(Of Boolean, String)(False, "Nilai nominal awal yang dimasukan lebih kecil dari batas minimal simpanan.")
                ElseIf InputedNominal > _max Then
                    Return New KeyValuePair(Of Boolean, String)(False, "Nilai nominal awal yang dimasukan lebih besar dari batas maksimal simpanan.")
                Else
                    Return New KeyValuePair(Of Boolean, String)(True, "")
                End If
            Else

            End If
        End Using
    End Function

    'SAVE
    Private Sub SaveData()
        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pwd))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    'BUILD QUERY
                    Dim q As String = "" : Dim _qArr As New List(Of String)
                    If _FormState = FormState.Insert Then
                        'NEW ENTRY
                        'GENERATE NOMOR REKENING
                        Dim _ct As Integer = 0 : Dim _format As String = "D6"
                        q = "SELECT IFNULL(MAX(SUBSTRING_INDEX(dep_rekening,'.',-1)), 0) FROM data_deposito_master"
                        _ct = Integer.Parse(x.ExecScalar(q)) + 1
                        _format = If(_ct > 999999, "D" & _ct.ToString.Length, "D6")
                        in_rek1.Text = "02.1." & _ct.ToString(_format)

                        'BUILD QUERY
                        q = "INSERT INTO data_deposito_master SET {0}"
                        Dim _kk = {"dep_rekening='" & in_rek1.Text & "'",
                                   "dep_alternatif='" & in_rek2.Text & "'",
                                   "dep_bilyet='" & in_bilyet.Text & "'",
                                   "dep_nasabah='" & in_nasabah_id.Text & "'",
                                   "dep_kode_pemilik=" & cb_pemilik.SelectedValue,
                                   "dep_tujuanpeng='" & mysqlQueryFriendlyStringFeed(in_tujuan.Text) & "'",
                                   "dep_waris_nama='" & mysqlQueryFriendlyStringFeed(in_ahliwaris.Text) & "'",
                                   "dep_waris_hubungan='" & cb_hubungan.SelectedValue & "'",
                                   "dep_tgl_awal='" & date_tglmulai.Value.ToString("yyyy-MM-dd") & "'",
                                   "dep_nominal=" & in_nominal_awal.Value.ToString.Replace(",", "."),
                                   "dep_jkw='" & Integer.Parse(cb_jangka.SelectedValue).ToString("D2") & "'",
                                   "dep_tgl_jthtempo='" & date_tglmulai.Value.AddMonths(cb_jangka.SelectedValue).ToString("yyyy-MM-dd") & "'",
                                   "dep_bunga_persen=" & removeCommaThousand(in_bunga.Text).ToString.Replace(",", "."),
                                   "dep_perlakuan=" & cb_perlakuan_pokok.SelectedValue,
                                   "dep_tabungan='" & in_tabungantujuan.Text & "'",
                                   "dep_perlakuan_bunga=" & cb_perlakuan_bunga.SelectedValue,
                                   "dep_ppj_sistem=" & cb_perpanjang.SelectedValue,
                                   "dep_status=0",
                                   "dep_reg_date=NOW()",
                                   "dep_reg_alias='" & LoggedUser.User_Alias & "'",
                                   "dep_reg_ip='" & LoggedUser.User_IP & "'"
                                  }
                        q = String.Format(q, String.Join(",", _kk))

                    Else
                        'UPDATE ENTRY
                        q = "UPDATE data_deposito_master SET {0} WHERE dep_rekening='{1}'"
                        If cb_status.SelectedValue = 0 Then
                            'IF ENTRY STILL INACTIVE
                            Dim _fk = {"dep_alternatif='" & in_rek2.Text & "'",
                                       "dep_bilyet='" & in_bilyet.Text & "'",
                                       "dep_nasabah='" & in_nasabah_id.Text & "'",
                                       "dep_kode_pemilik=" & cb_pemilik.SelectedValue,
                                       "dep_tujuanpeng='" & mysqlQueryFriendlyStringFeed(in_tujuan.Text) & "'",
                                       "dep_waris_nama='" & mysqlQueryFriendlyStringFeed(in_ahliwaris.Text) & "'",
                                       "dep_waris_hubungan='" & cb_hubungan.SelectedValue & "'",
                                       "dep_tgl_awal='" & date_tglmulai.Value.ToString("yyyy-MM-dd") & "'",
                                       "dep_nominal=" & in_nominal_awal.Value.ToString.Replace(",", "."),
                                       "dep_jkw='" & Integer.Parse(cb_jangka.SelectedValue).ToString("D2") & "'",
                                       "dep_tgl_jthtempo='" & date_tglmulai.Value.AddMonths(cb_jangka.SelectedValue).ToString("yyyy-MM-dd") & "'",
                                       "dep_bunga_persen=" & removeCommaThousand(in_bunga.Text).ToString.Replace(",", "."),
                                       "dep_perlakuan=" & cb_perlakuan_pokok.SelectedValue,
                                       "dep_tabungan='" & in_tabungantujuan.Text & "'",
                                       "dep_perlakuan_bunga=" & cb_perlakuan_bunga.SelectedValue,
                                       "dep_ppj_sistem=" & cb_perpanjang.SelectedValue,
                                       "dep_upd_date=NOW()",
                                       "dep_upd_alias='" & LoggedUser.User_Alias & "'",
                                       "dep_upd_ip='" & LoggedUser.User_IP & "'"
                                      }
                            q = String.Format(q, String.Join(",", _fk), in_rek1.Text)
                        Else
                            'IF ENTRY IS ACTIVE
                            Dim _qf = {"dep_alternatif='" & in_rek2.Text & "'",
                                       "dep_perlakuan=" & cb_perlakuan_pokok.SelectedValue,
                                       "dep_ppj_sistem=" & cb_perpanjang.SelectedValue,
                                       "dep_tujuanpeng='" & mysqlQueryFriendlyStringFeed(in_tujuan.Text) & "'",
                                       "dep_waris_nama='" & mysqlQueryFriendlyStringFeed(in_ahliwaris.Text) & "'",
                                       "dep_waris_hubungan='" & cb_hubungan.SelectedValue & "'",
                                       "dep_upd_date=NOW()",
                                       "dep_upd_alias='" & LoggedUser.User_Alias & "'",
                                       "dep_upd_ip='" & LoggedUser.User_IP & "'"
                                      }
                            q = String.Format(q, String.Join(",", _qf), in_rek1.Text)
                        End If
                    End If

                    Dim _ck = x.ExecCommand(q)
                    If _ck = 1 Then
                        'DO WRITE ACTION LOG
                        MessageBox.Show("Data simpanan berhasil tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If _FormState = FormState.Insert Then
                            _FormState = FormState.Edit
                            ControlSwitch(True)
                        End If
                    Else
                        MessageBox.Show("Data simpanan ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("TIdak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

        Catch ex As Exception
            LogError(ex)
            MessageBox.Show("Terjadi kesalahan saat melakukak penyimpanan data tabungan berjangka." & Environment.NewLine & ex.Message,
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    'UI : DRAG FORM
    Private Sub pnl_top_MouseDown(sender As Object, e As MouseEventArgs) Handles pnl_top.MouseDown, lbl_judul.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub pnl_top_MouseMove(sender As Object, e As MouseEventArgs) Handles pnl_top.MouseMove, lbl_judul.MouseMove
        dragging(Me)
    End Sub

    Private Sub pnl_top_MouseUp(sender As Object, e As MouseEventArgs) Handles pnl_top.MouseUp, lbl_judul.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub pnl_top_DoubleClick(sender As Object, e As EventArgs) Handles pnl_top.DoubleClick, lbl_judul.DoubleClick
        CenterToScreen()
    End Sub

    'UI : FORM / OTHER
    Private Sub fr_beli_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_close.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.S AndAlso e.Control Then
            bt_save.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    'UI : BUTTON
    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub bt_save_Click(sender As Object, e As EventArgs) Handles bt_save.Click
        'CHECK INPUT
        If String.IsNullOrWhiteSpace(in_nasabah_nama.Text) And Not String.IsNullOrWhiteSpace(in_nasabah_id.Text) Then GetNasabahData(in_nasabah_id.Text)

        For Each txt As TextBox In {in_bilyet, in_nasabah_id, in_pemilik_kode, in_ahliwaris, in_kode_perlakuan, in_kode_perlakuan_b}
            Dim _Msg = "" : Dim _Ctr As Control = txt
            Select Case txt.Name
                Case in_bilyet.Name : _Msg = "Nomor bilyet masih kosong."
                Case in_nasabah_nama.Name
                    _Msg = "Nasabah belum dipilih." : _Ctr = in_nasabah_id
                Case in_pemilik_kode.Name
                    _Msg = "Jenis pemilik belum dipilih." : _Ctr = cb_pemilik
                Case in_ahliwaris.Name : _Msg = "Ahli waris masih kosong."
                Case in_kode_perlakuan.Name
                    _Msg = "Perlakuan simpanan belum dipilih." : _Ctr = cb_perlakuan_pokok
                Case in_kode_perlakuan_b.Name
                    _Msg = "Perlakuan bunga simpanan belum dipilih." : _Ctr = cb_perlakuan_bunga
                Case Else : GoTo NextCtr
            End Select

            If String.IsNullOrWhiteSpace(txt.Text) Then
                MessageBox.Show(_Msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                _Ctr.Focus() : Exit Sub
            End If
NextCtr:
        Next

        If _FormState = FormState.Insert Or (_FormState = FormState.Edit And cb_status.SelectedValue = 0) Then
            If in_nominal_awal.Value = 0 Then
                MessageBox.Show("Nilai nominal awal simpanan kosong.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                in_nominal_awal.Focus() : Exit Sub
            Else
                Dim _csss = CheckMinMaxValueNominal(in_nominal_awal.Value)
                If Not _csss.Key Then
                    MessageBox.Show(_csss.Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    in_nominal_awal.Focus() : Exit Sub
                End If
            End If
            'If cb_status.SelectedValue = 0 Then cb_status.SelectedValue = 1
        End If

        'SAVE DATA
        Dim _resp As DialogResult = Windows.Forms.DialogResult.Yes
        If _FormState = FormState.Edit Then _resp = MessageBox.Show("Simpan perubahan data simpanan?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _resp = Windows.Forms.DialogResult.Yes Then SaveData()
    End Sub

    Private Sub bt_search_nasabah_Click(sender As Object, e As EventArgs) Handles bt_search_nasabah.Click, bt_search_tabungan.Click
        Select Case sender.Name
            Case bt_search_nasabah.Name
                If String.IsNullOrWhiteSpace(in_nasabah_id.Text) Then
                    'SEARCH NASABAH
                    Using x = New pencarian_master_nasabah
                        x.ShowDialog()
                        If Not String.IsNullOrWhiteSpace(x.ReturnValue) Then
                            Dim _old = in_nasabah_id.Text
                            If _old <> x.ReturnValue Then cb_pemilik.SelectedIndex = -1
                            Dim _d = GetNasabahData(x.ReturnValue)
                            If Not _d.Key Then
                                MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data nasabah." & Environment.NewLine & _d.Value,
                                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                    End Using
                Else
                    Dim _d = GetNasabahData(in_nasabah_id.Text)
                    If Not _d.Key Then
                        MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data nasabah." & Environment.NewLine & _d.Value,
                                        Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        in_nasabah_id.Clear() : Exit Sub
                    End If
                End If
                bt_data_nasabah.Enabled = Not String.IsNullOrWhiteSpace(in_nasabah_nama.Text)

            Case bt_search_tabungan.Name
                'SEARCH TABUNGAN
                Using x = New pencarian_master_tabungan
                    x.Label4.Text = "cari rekening 1"
                    x.ShowDialog()
                    If Not String.IsNullOrWhiteSpace(x.ReturnValue) Then in_tabungantujuan.Text = x.ReturnValue
                End Using
        End Select
    End Sub

    Private Sub bt_data_nasabah_Click(sender As Object, e As EventArgs) Handles bt_data_nasabah.Click
        Dim x = New data_nasabah_perorangan
        x.tnasabah_id.Text = in_nasabah_id.Text
        x.cekdatanasabah()
        x.ShowDialog()
    End Sub

    Private Sub bt_data_pelengkap_Click(sender As Object, e As EventArgs) Handles bt_data_pelengkap.Click

    End Sub

    Private Sub bt_statement_Click(sender As Object, e As EventArgs) Handles bt_statement.Click

    End Sub

    'UI : COMBOBOX
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_pemilik_SelectionChangeCommitted(sender As Object, e As EventArgs)
        Dim _txt As TextBox = Nothing
        Select Case sender.Name
            Case cb_jangka.Name
                'GET NILAI BUNGA
                Me.Cursor = Cursors.WaitCursor
                Dim _dg = GetBunga(cb_jangka.SelectedValue)
                If _dg.Key Then
                    in_bunga.Text = _dg.Value
                Else
                    MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data bunga jangka simpanan." & Environment.NewLine & _dg.Value,
                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default

            Case cb_pemilik.Name, cb_perlakuan_bunga.Name, cb_perpanjang.Name
                Select Case sender.Name
                    Case cb_pemilik.Name : _txt = in_pemilik_kode
                    Case cb_perlakuan_bunga.Name : _txt = in_kode_perlakuan_b
                    Case cb_perpanjang.Name : _txt = in_kode_perpanjang
                End Select
                If Not IsNothing(_txt) Then _txt.Text = sender.SelectedValue

            Case cb_perlakuan_pokok.Name
                cb_perpanjang.SelectedValue = 1
                If cb_perlakuan_pokok.SelectedValue = 2 Then
                    bt_search_tabungan.Enabled = True
                Else
                    If cb_perlakuan_pokok.SelectedValue = 3 Then cb_perpanjang.SelectedValue = 2
                    in_tabungantujuan.Clear() : bt_search_tabungan.Enabled = False
                End If
                in_kode_perlakuan.Text = sender.SelectedValue
                cb_pemilik_SelectionChangeCommitted(cb_perpanjang, Nothing)
        End Select
    End Sub

    'UI : NUMERIC INPUT
    Private Sub in_nominal_awal_Enter(sender As Object, e As EventArgs) Handles in_nominal_awal.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_nominal_awal_Leave(sender As Object, e As EventArgs) Handles in_nominal_awal.Leave
        numericLostFocus(sender, "N0")
    End Sub

    'UI : INPUT 
    Private Sub in_nasabah_id_TextChanged(sender As Object, e As EventArgs) Handles in_nasabah_id.TextChanged
        If String.IsNullOrWhiteSpace(sender.Text) Then
            For Each txt As TextBox In {in_nasabah_nama, in_nasabah_nik, in_nasabah_alamat}
                txt.Clear()
            Next
        End If
    End Sub
End Class