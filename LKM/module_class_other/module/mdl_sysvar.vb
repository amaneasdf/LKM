Imports System.IO

Module mdl_sysvar
    'SYSTEM CONFIG VARIABLE
    Private _LimitPerPage As Integer = 2000
    Private _ScreenLock As Integer = 10
    Private _NetworkSetting As String = "localhost"

    'STRUCTURE FOR MARGINS
    Public Structure Margins
        Public leftWidth As Integer
        Public rightWidth As Integer
        Public topHeight As Integer
        Public bottomHeight As Integer
    End Structure

    'STRUCTURE FOR DATA CONNECTION
    Public Structure ConnectionData
        Public host As String
        Public port As Integer
        Public db As String
        Public uid As String
        Public pwd As String

        Public ReadOnly Property IsEmpty As Boolean
            Get
                Dim _isEmpty As Boolean = False
                For Each _str As String In {host, db, uid}
                    If String.IsNullOrWhiteSpace(_str) Then
                        _isEmpty = True : Exit For
                    End If
                Next
                Return _isEmpty
            End Get
        End Property
    End Structure

    'STRUCTURE FOR DATA USER
    Public Structure UserData
        Public User_Alias As String
        Public User_Nama As String
        Public User_Session As String

        Public ReadOnly Property User_Version As String
            Get
                Return Application.ProductVersion
            End Get
        End Property

        'COMPUTER VERSION
        Public ReadOnly Property User_IP() As String
            Get
                Return GetIPv4Address()
            End Get
        End Property
        Public ReadOnly Property User_MAC() As String
            Get
                Return GetMac(User_IP)
            End Get
        End Property
        Public ReadOnly Property User_Host() As String
            Get
                Return System.Net.Dns.GetHostName()
            End Get
        End Property
        Public ReadOnly Property User_HWID() As String
            Get
                Return GetHWID()
            End Get
        End Property

        'OTHER
        Public ReadOnly Property IsEmpty As Boolean
            Get
                Dim _ret As Boolean = False
                If String.IsNullOrWhiteSpace(User_Alias) Then _ret = True
                Return _ret
            End Get
        End Property

        'FUNCTION
        'Public Function GetNama() As String
        '    If Me.IsEmpty Then Return String.Empty
        '    If MainConnData.IsEmpty Then Return String.Empty

        '    Try
        '        Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pwd))
        '            x.Open() : If x.ConnectionState = ConnectionState.Open Then
        '                Dim q As String = "SELECT user_nama FROM data_pengguna_alias WHERE user_alias='{0}'"
        '                Dim _nama = x.ExecScalar(String.Format(q, User_Alias))
        '                User_Nama = _nama
        '                Return _nama
        '            Else
        '                Return String.Empty
        '            End If
        '        End Using
        '    Catch ex As Exception
        '        LogError(ex) : consoleWriteLine(ex.Message)
        '        Return String.Empty
        '    End Try
        'End Function
    End Structure

    'DIRECTORY
    Public ReadOnly Property AppDir_Document As String
        Get
            Return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.Create) & "\" & Application.ProductName & "\"
        End Get
    End Property
    Public ReadOnly AppDir_SystemFile As String = Path.GetDirectoryName(Application.ExecutablePath) & "\dat\"

    'MYSQL CONNECTION SETTING
    Public ReadOnly Property NetworkSettingName As String
        Get
            Try
                _NetworkSetting = getSetting("App").Keys("Conn").Value
                Return _NetworkSetting
            Catch ex As Exception
                LogError(ex)
                Return "network"
            End Try
        End Get
    End Property
    'Public MainConnection As New MySqlThing
    Public MainConnData As New ConnectionData

    'USER DATA
    Public LoggedUser As New UserData

    'DATA LIST PROPERTY
    Public ReadOnly Property LimitDataPerPage As Integer
        Get
            Try
                _LimitPerPage = getSetting("App").Keys("LimitPerPage").Value
                Return _LimitPerPage
            Catch ex As Exception
                LogError(ex)
                Return 1000
            End Try
        End Get
    End Property

    'SCREEN LOCK LIMIT(IN MINUTES)
    Public ReadOnly Property ScreenLockTimer As Integer
        Get
            Try
                _ScreenLock = getSetting("App").Keys("ScreenLock").Value
                Return 60000 * _ScreenLock
            Catch ex As Exception
                LogError(ex)
                Return 60000 * 10
            End Try
        End Get
    End Property

    'FONT
    Public OpenSans_Self As Boolean = False
    Public SourceSans_Self As Boolean = False


    'DATAGRID COLUMNS LIST
    Public dgvcol_temp_ck = New DataGridViewCheckBoxColumn With {
        .ReadOnly = False,
        .Width = 50,
        .FalseValue = 0,
        .TrueValue = 1,
        .IndeterminateValue = 0
        }
    Public dgvcol_temp_cb = New DataGridViewComboBoxColumn With {
        .ReadOnly = False,
        .Width = 100,
        .DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        }
    Public dgvcol_templ_id = New DataGridViewTextBoxColumn With {
        .ReadOnly = True,
        .MinimumWidth = 25,
        .Width = 50
        }
    Public dgvcol_templ_status = New DataGridViewTextBoxColumn With {
        .ReadOnly = True,
        .MinimumWidth = 25,
        .Width = 75
        }
    Public dgvcol_templ_alamat = New DataGridViewTextBoxColumn With {
        .ReadOnly = True,
        .MinimumWidth = 25,
        .Width = 200,
        .DefaultCellStyle = dgvstyle_multiline
        }
    Public dgvcol_templ_numeric = New DataGridViewTextBoxColumn With {
        .ReadOnly = True,
        .MinimumWidth = 25,
        .DefaultCellStyle = dgvstyle_commathousand
        }

    'DATAGRID CELLSTYLE LIST
    Public dgvstyle_commathousand As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .Format = "N0",
        .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
        .NullValue = "-",
        .Alignment = DataGridViewContentAlignment.MiddleRight
    }
    Public dgvstyle_currency As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .Format = "N2",
        .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
        .NullValue = "-",
        .Alignment = DataGridViewContentAlignment.MiddleRight
    }

    Public dgvstyle_multiline As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .WrapMode = DataGridViewTriState.True
    }

    Public dgvstyle_date As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .Format = "dd/MM/yyyy",
        .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
        .NullValue = "-"
    }
    Public dgvstyle_time As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .Format = "HH:mm:ss",
        .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
        .NullValue = "-"
    }
    Public dgvstyle_datetime As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
       .Format = "dd/MM/yyyy hh:mm:ss",
       .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
       .NullValue = "-"
   }

End Module
