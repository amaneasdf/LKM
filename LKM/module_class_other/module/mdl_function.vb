Imports System.IO
Imports System.Management
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports MadMilkman.Ini

Module mdl_function
    '================================================================================================================
    'GET USER NETWORK, HARDWARE AND OS DATA
    Declare Function SendARP Lib "iphlpapi.dll" Alias "SendARP" (ByVal DestIP As Int32, ByVal SrcIP As Int32, ByVal pMacAddr() As Byte, ByRef PhyAddrLen As Int32) As Int32
    <DllImport("dwmapi.dll")>
    Function DwmIsCompositionEnabled(ByRef pfEnabled As Integer) As Integer
    End Function
    <DllImport("dwmapi.dll")>
    Function DwmSetWindowAttribute(hwnd As IntPtr, attr As Int32, ByRef attrValue As Int32, attrSize As Int32) As Integer
    End Function
    <DllImport("dwmapi.dll")>
    Function DwmExtendFrameIntoClientArea(hWnd As IntPtr, ByRef pMarInset As Margins) As Integer
    End Function
    <DllImport("gdi32.dll", EntryPoint:="AddFontResourceW", SetLastError:=True)>
    Function AddFontResource(<[In]> <MarshalAs(UnmanagedType.LPWStr)> lpFileName As String) As Integer
    End Function
    <DllImport("gdi32.dll", EntryPoint:="RemoveFontResourceW", SetLastError:=True)>
    Function RemoveFontResource(<[In]> <MarshalAs(UnmanagedType.LPWStr)> lpFileName As String) As Integer
    End Function

    Public Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                Return ipheal.ToString()
            End If
        Next
    End Function

    Public Function GetMac(ByVal ipAddr As String) As String
        Dim macAddress As String = String.Empty
        Try
            Dim destIP As Net.IPAddress = Net.IPAddress.Parse(ipAddr)
            Dim IP() As Byte = destIP.GetAddressBytes()
            Dim IPInt As Int32 = BitConverter.ToInt32(IP, 0)
            Dim mac() As Byte = New Byte(5) {}
            SendARP(IPInt, 0, mac, mac.Length)
            macAddress = BitConverter.ToString(mac, 0, mac.Length)
        Catch ex As Exception
            LogError(ex)
            Debug.Write(ex.Message)
        End Try
        Return macAddress
    End Function

    Public Function GetHWID() As String
        Dim _HWID As String = ""
        Dim mboardstr As String = "" : Dim cpuID As String = ""
        Dim query As String = ""

        'GET MAINBOARD SERIALNUMBER
        query = "Select SerialNumber From Win32_BaseBoard"
        Using mbs = New ManagementObjectSearcher(query)
            For Each mo As ManagementObject In mbs.Get
                For Each pd As PropertyData In mo.Properties
                    ' should be only one
                    If LCase(pd.Name) = "serialnumber" Then
                        ' value is object, test for Nothing
                        If pd.Value IsNot Nothing Then mboardstr = pd.Value.ToString
                        Exit For
                    End If
                Next
            Next
        End Using

        'GET PROCESSOR ID
        query = "Select ProcessorID From Win32_Processor"
        Using mbs = New ManagementObjectSearcher(query)
            For Each mo As ManagementObject In mbs.Get
                For Each pd As PropertyData In mo.Properties
                    ' should be only one
                    If LCase(pd.Name) = "processorid" Then
                        ' value is object, test for Nothing
                        If pd.Value IsNot Nothing Then cpuID = pd.Value.ToString
                        Exit For
                    End If
                Next
            Next
        End Using

        Return mboardstr & ":" & cpuID
    End Function

    Public Function CheckAeroEnabled() As Boolean
        If Environment.OSVersion.Version.Major >= 6 Then
            Dim enabled As Integer = 0
            DwmIsCompositionEnabled(enabled)
            Return If(enabled = 1, True, False)
        End If
        Return False
    End Function

    'CHECK FONT
    Public Function IsFontInstalled(ByVal FontName As String) As Boolean
        Using TestFont As Font = New Font(FontName, 10)
            Return CBool(String.Compare(FontName, TestFont.Name, StringComparison.InvariantCultureIgnoreCase) = 0)
        End Using
    End Function

    '================================================================================================================
    'split string into two string and the nth string
    Function SplitText(ByVal text As String, ByVal separator As String, ByVal ke As Double)
        Dim SplitStr As String = text
        Dim SplitArr As String()

        SplitArr = SplitStr.Split(separator)
        Return Trim(SplitArr(ke))

    End Function

    'string format
    Public Function stringCurrency(x As Decimal) As String
        Dim s As String = ""
        s = x.ToString("C2", System.Globalization.CultureInfo.CreateSpecificCulture("id-ID"))
        Return s
    End Function

    Public Function commaThousand(x As Decimal) As String
        Dim s As String = ""
        s = x.ToString("N2", System.Globalization.CultureInfo.CreateSpecificCulture("id-ID"))
        Return s
    End Function

    Public Function removeCommaThousand(x As String) As Decimal
        If x = Nothing Then
            Return 0 : Exit Function
        End If

        Dim retval As Decimal = Decimal.Parse(x, System.Globalization.CultureInfo.CreateSpecificCulture("id-ID"))

        Return retval
    End Function

    ''' <summary>
    ''' Convert number to  <see cref="String" />s of words.
    ''' </summary>
    ''' <param name="NumAmount">
    ''' Number to be descripted.
    ''' </param>
    ''' <returns>
    ''' A formated <see cref="String"/> of the input.
    ''' </returns>
    Public Function AmountToString(NumAmount As Long) As String
        If Not IsNumeric(NumAmount) Then Throw New InvalidDataException

        Dim _nilai As String() = {"", "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", "Delapan", "Sembilan", "Sepuluh", "Sebelas"}

        If NumAmount < 12 Then
            Return _nilai(NumAmount)
        ElseIf NumAmount < 20 Then
            Return _nilai(NumAmount - 10) & " Belas "
        ElseIf NumAmount < 100 Then
            Return AmountToString(Math.Floor(NumAmount / 10)) & " Puluh " & AmountToString(NumAmount Mod 10)
        ElseIf NumAmount < 200 Then
            Return " Seratus " & AmountToString(NumAmount - 100)
        ElseIf NumAmount < 1000 Then
            Return AmountToString(Math.Floor(NumAmount / 100)) & " Ratus " & AmountToString(NumAmount Mod 100)
        ElseIf NumAmount < 2000 Then
            Return " Seribu " & AmountToString(NumAmount - 1000)
        ElseIf NumAmount < 1000000 Then
            Return AmountToString(Math.Floor(NumAmount / 1000)) & " Ribu " & AmountToString(NumAmount Mod 1000)
        ElseIf NumAmount < 1000000000 Then
            Return AmountToString(Math.Floor(NumAmount / 1000000)) & " Juta " & AmountToString(NumAmount Mod 1000000)
        ElseIf NumAmount < 1000000000000 Then
            Return AmountToString(Math.Floor(NumAmount / 1000000000)) & " Milyar " & AmountToString(NumAmount Mod 1000000000)
        ElseIf NumAmount < 1000000000000000 Then
            Return AmountToString(Math.Floor(NumAmount / 1000000000000)) & " Trilyun " & AmountToString(NumAmount Mod 1000000000000)
        Else
            Return NumAmount
        End If
    End Function

    ''' <summary>
    ''' Returns a MYSQL query friendly <see cref="String" />.
    ''' </summary>
    ''' <param name="text">
    ''' The input <see cref="String" />.
    ''' </param>
    ''' <returns>
    ''' A formated <see cref="String"/> for MSYQL CRUD query.
    ''' </returns>
    Public Function mysqlQueryFriendlyStringFeed(text As String) As String
        Return text.Replace("\", "\\").Replace("'", "\'").Replace("%", "\%").Replace("_", "\_")
    End Function

    ''' <summary>
    ''' Verify inputed email address format.
    ''' </summary>
    ''' <param name="email">
    ''' Inputed <see cref="String" /> of email address needed to checked.
    ''' </param>
    ''' <returns>
    ''' Returns true if the <see cref="String" /> contains a valid email address and false if it does not.
    ''' </returns>
    Public Function IsValidEmail(email As String) As Boolean

        If String.IsNullOrWhiteSpace(email) Then Return False

        ' Use IdnMapping class to convert Unicode domain names.
        Try
            'Examines the domain part of the email and normalizes it.
            Dim DomainMapper =
                Function(match As Match) As String

                    'Use IdnMapping class to convert Unicode domain names.
                    Dim idn = New IdnMapping

                    'Pull out and process domain name (throws ArgumentException on invalid)
                    Dim domainName As String = idn.GetAscii(match.Groups(2).Value)

                    Return match.Groups(1).Value & domainName

                End Function

            'Normalize the domain
            email = Regex.Replace(email, "(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200))

        Catch e As RegexMatchTimeoutException
            Return False

        Catch e As ArgumentException
            Return False

        End Try

        Try
            Return Regex.IsMatch(email,
                                 "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                 "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                                 RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))

        Catch e As RegexMatchTimeoutException
            Return False

        End Try

    End Function
    '================================================================================================================

    '================================================================================================================
    'FORM & CONTROL MANIPULATION
    'FORM DRAGGING FUNCTION
    Private drag As Boolean
    Private mousex As Integer
    Private mousey As Integer

    Public Sub startdrag(fr As Form, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            drag = True
            mousex = Windows.Forms.Cursor.Position.X - fr.Left
            mousey = Windows.Forms.Cursor.Position.Y - fr.Top
            fr.Cursor = Cursors.SizeAll
        End If
    End Sub

    Public Sub dragging(fr As Form)
        If drag Then
            fr.Top = Windows.Forms.Cursor.Position.Y - mousey
            fr.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Public Sub stopdrag(fr As Form)
        drag = False
        fr.Cursor = Cursors.Default
    End Sub

    'DARKEN BACKGROUND FOR MODAL FORM
    Public Sub DarkenParentForm(Switch As Boolean, ByRef FormParent As Form, ByRef PanelParent As Panel)
        If Switch Then
            Dim bmp = New Bitmap(FormParent.ClientRectangle.Width, FormParent.ClientRectangle.Height)
            Using G = Graphics.FromImage(bmp)
                G.CompositingMode = Drawing2D.CompositingMode.SourceOver
                G.CopyFromScreen(FormParent.PointToScreen(New Point(0, 0)), New Point(0, 0), FormParent.ClientRectangle.Size)
                Dim percent As Double = 0.6
                Dim darken As Color = Color.FromArgb(Int(255 * percent), Color.Black)
                Using brsh = New SolidBrush(darken)
                    G.FillRectangle(brsh, FormParent.ClientRectangle)
                End Using
            End Using

            Dim _panel As New Panel With {
                .Location = New Point(0, 0),
                .Size = FormParent.ClientRectangle.Size,
                .BackgroundImage = bmp
                }
            FormParent.Controls.Add(_panel)
            _panel.BringToFront()
            PanelParent = _panel
        Else
            FormParent.Controls.Remove(PanelParent)
        End If
    End Sub

    'NUMERIC INPUT
    Public Sub numericGotFocus(sender As NumericUpDown)
        If sender.Value = 0 Then
            sender.ResetText()
        Else
            sender.Controls.Item(1).Text = sender.Value
        End If
    End Sub

    Public Sub numericLostFocus(x As NumericUpDown, Optional format As String = "N2")
        x.Controls.Item(1).Text = x.Value.ToString(format)
    End Sub

    'DGV
    Public Sub DataGridView_setDoubleBuffered(dgv As DataGridView, x As Boolean)
        Dim type As Type = dgv.[GetType]()
        Dim PI As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        PI.SetValue(dgv, True, Nothing)
        consoleWriteLine(dgv.Name & " " & "DoubleBuffered:" & x.ToString)
    End Sub

    'TREE VIEW
    'TICK/UNTICK ALL NODES INSIDE TREENODE
    Public Sub CheckAllNodes(Tree As TreeNode, state As Boolean)
        For Each item As TreeNode In Tree.Nodes
            item.Checked = state
            If item.Nodes.Count > 0 Then CheckAllNodes(item, state)
        Next
    End Sub

    'TICK ALL CHILDNODES INSIDE TREENODE
    Public Sub CheckAllChildNodes(ByVal parentNode As TreeNode)
        For Each childNode As TreeNode In parentNode.Nodes
            childNode.Checked = parentNode.Checked
            CheckAllChildNodes(childNode)
        Next
    End Sub

    Public Sub IsEveryChildChecked(ByVal parentNode As TreeNode, ByRef checkValue As Boolean)
        For Each node As TreeNode In parentNode.Nodes
            IsEveryChildChecked(node, checkValue)
            If Not node.Checked Then checkValue = False
        Next
    End Sub

    Public Sub IsSomeChildChecked(ByVal parentNode As TreeNode, ByRef checkValue As Boolean)
        For Each node As TreeNode In parentNode.Nodes
            If node.Checked Then
                checkValue = True : Exit For
            Else
                IsSomeChildChecked(node, checkValue)
            End If
        Next
    End Sub

    'Public Sub ShouldParentsBeChecked(ByVal startNode As TreeNode)
    '    If startNode.Parent Is Nothing = False Then
    '        Dim allChecked As Boolean = True
    '        IsEveryChildChecked(startNode.Parent, allChecked)
    '        If allChecked Then
    '            startNode.Parent.Checked = True
    '            ShouldParentsBeChecked(startNode.Parent)
    '        End If
    '    End If
    'End Sub
    '================================================================================================================

    '================================================================================================================
    'IO FILE/DIR
    'CREATE TEXT FILE
    Private Sub CreateTextFile(FileDirectory As String, FileName As String, Contents As List(Of String), Optional AppendFile As Boolean = True)
        Dim _FileName As String = FileDirectory & FileName

        'CHECK AND CREATING NEW FILE AND DIRECTORY
        If Not Directory.Exists(FileDirectory) Then Directory.CreateDirectory(FileDirectory)
        If Not File.Exists(FileName) Then File.Create(FileName).Dispose()

        'WRITE FILE
        Dim writer As New StreamWriter(_FileName, AppendFile)
        For Each x As String In Contents
            writer.WriteLine(x)
        Next
        writer.Close()
    End Sub

    'GET INI CONFIG FILE LOCATION/FILENAME
    Public Function getConfigFile() As String
        Dim fileloc As String = ""

        If File.Exists(AppDir_Document & "bin\config") Then
            fileloc = AppDir_Document & "bin\config"
        ElseIf File.Exists(Application.StartupPath & "\config") = True Then
            fileloc = Application.StartupPath & "\config"
        ElseIf File.Exists(Application.StartupPath & "\bin\config") = True Then
            fileloc = Application.StartupPath & "\bin\config"
        Else
            If Not Directory.Exists(AppDir_Document & "bin\") Then
                Directory.CreateDirectory(AppDir_Document & "bin\")
            End If
            File.WriteAllText(AppDir_Document & "bin\config", My.Resources.ResourceManager.GetObject("config").ToString)
            fileloc = AppDir_Document & "bin\config"
        End If

        Return fileloc
    End Function

    'GET INI SECTION FROM INI CONFIG FILE
    Public Function getSetting(SettingName As String, Optional ByRef Msg As String = Nothing) As IniSection
        If String.IsNullOrWhiteSpace(SettingName) Then
            Throw New ArgumentNullException("Setting name cannot be empty")
        End If

        Dim _retval As IniSection = Nothing
        Dim options As New IniOptions() With {.SectionNameCaseSensitive = True, .KeyNameCaseSensitive = True}
        Dim inifile As New IniFile(options)

        Try
            inifile.Load(getConfigFile)
            If Not inifile.Sections.Contains(SettingName) Then
                Throw New IndexOutOfRangeException("Config section named [" & SettingName & "] cannot be found")
            End If
            _retval = inifile.Sections(SettingName)
            Msg = "SUCCESS"

        Catch ex As Exception
            LogError(ex)
            Msg = "ERROR : " & ex.Message
        End Try

        Return _retval
    End Function

    'LOAD DATABASE CONNECTION SETTING
    Public Function LoadDataConnection(ConnectionName As String, Optional ByRef RespMsg As String = "") As ConnectionData
        Dim _option As New IniOptions
        Dim _inifile As New IniFile(_option)
        Dim x As New ConnectionData
        Try
            _inifile.Load(getConfigFile)
            With _inifile.Sections(ConnectionName)
                x.host = .Keys("Host").Value
                x.uid = .Keys("UID").Value
                x.pwd = .Keys("Pass").Value
                x.db = .Keys("DB").Value
            End With
        Catch ex As Exception
            LogError(ex)
            RespMsg = ex.Message
        End Try
        Return x
    End Function

    'OPEN WEBPAGE IN SPECIFIC WEB BROWSER
    Public Sub NavigateWebURL(ByVal URL As String, Optional browser As String = "default")

        If Not (browser = "default") Then
            Try
                '// try set browser if there was an error (browser not installed)
                Process.Start(browser, URL)
            Catch ex As Exception
                '// use default browser
                Process.Start(URL)
            End Try

        Else
            '// use default browser
            Process.Start(URL)
        End If
    End Sub
    '================================================================================================================

    '================================================================================================================
    'CRYPTOGRAPHY
    Private KEY_128 As Byte() = {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}
    Private IV_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}
    Private symmetricKey As RijndaelManaged = New RijndaelManaged() With {.Mode = CipherMode.CBC}
    Private enc As New System.Text.UTF8Encoding
    Private encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(KEY_128, IV_128)
    Private decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(KEY_128, IV_128)

    Public Function encryptString(ByVal inputString As String) As String
        Dim _retString As String = ""

        If Not String.IsNullOrEmpty(inputString) Then
            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
            cryptoStream.Write(enc.GetBytes(inputString), 0, inputString.Length)
            cryptoStream.FlushFinalBlock()
            _retString = Convert.ToBase64String(memoryStream.ToArray())
            memoryStream.Close()
            cryptoStream.Close()
        End If

        Return _retString
    End Function

    Public Function decryptString(ByVal cypherText As String) As String
        Dim _retString As String = ""

        If Not String.IsNullOrWhiteSpace(cypherText) Then
            Dim cypherTextBytes As Byte() = Convert.FromBase64String(cypherText)
            Dim memoryStream As MemoryStream = New MemoryStream(cypherTextBytes)
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
            Dim plainTextBytes(cypherTextBytes.Length) As Byte
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            memoryStream.Close()
            cryptoStream.Close()
            _retString = enc.GetString(plainTextBytes, 0, decryptedByteCount)
        End If

        Return _retString
    End Function

    'MODIFIED CAESAR ENCRYPTION
    Public Function CEncrypt(InputString As String, Optional CharJump As Integer = 1) As String
        If String.IsNullOrEmpty(InputString) Then Return ""

        Dim _output As String = ""
        For i = 1 To InputString.Length
            Dim _chr = Strings.Mid(InputString, i, 1)
            _output += Chr(Asc(_chr) + CharJump)
        Next
        Return _output
    End Function

    Public Function CDecrypt(ChyperText As String, Optional CharJump As Integer = 1) As String
        If String.IsNullOrEmpty(ChyperText) Then Return ""

        Dim _output As String = ""
        For i = 1 To ChyperText.Length
            Dim _chr = Strings.Mid(ChyperText, i, 1)
            _output += Chr(Asc(_chr) - CharJump)
        Next
        Return _output
    End Function

    'MD5
    ''' <summary>
    ''' Generate MD5 from a <see cref="String"/>
    ''' </summary>
    ''' <param name="inputstring"><see cref="String"/> that need tobe hashed</param>
    ''' <returns>Generated MD5 <see cref="String"/></returns>
    ''' <remarks></remarks>
    Public Function computeHash(ByVal inputstring As String) As String
        Dim _retval As String = ""

        If Not String.IsNullOrEmpty(inputstring) Then
            Dim md5 As New MD5CryptoServiceProvider
            Dim hasByte() As Byte = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(inputstring))

            For Each s In hasByte
                _retval += s.ToString("x2")
            Next
        End If

        Return _retval
    End Function
    '================================================================================================================

    '================================================================================================================
    'LOGGING
    'CONSOLE WRITING
    Public Sub consoleWriteLine(text As String)
#If DEBUG Then
        Console.WriteLine(text)
#End If
    End Sub

    'ERROR LOGGING
    Public Sub LogError(ex As Exception)
        Dim _ErrorListStr As New List(Of String)
        Dim _Exe As Exception = ex
        Dim _filename As String = "LOG_ERROR" & Today.ToString("yyyyMMdd") & ".log"
        Dim _ct As Integer = 0

        consoleWriteLine("ERROR:" & Date.Now.ToString("yyyyMMdd-hhmmss") & ":" & ex.Message & ":" & ex.StackTrace & ":" & ex.TargetSite.ToString)

        While Not IsNothing(_Exe)
            If _ct = 0 Then
                _ErrorListStr.Add(String.Format("{0:yyyyMMdd-hhmmss}:ERROR:{1}", Now, _Exe.Message))
            Else
                _ErrorListStr.Add(String.Format("IE_{0}:{1}", _ct, _Exe.Message))
            End If
            _ErrorListStr.Add(String.Format("--{0}:{1}", _Exe.GetType, _Exe.TargetSite.ToString))
            _ErrorListStr.Add(String.Format("--ST_TRACE:{0}", _Exe.StackTrace))

            If IsNothing(_Exe.InnerException) Then
                Exit While
            Else
                _Exe = _Exe.InnerException : _ct += 1
            End If
        End While

        'WRITE LOG FILE
        CreateTextFile(AppDir_Document & "bin\errorlog\", _filename, _ErrorListStr, True)
        'INSERT LOG TO DB
        'HERE
    End Sub
    '================================================================================================================
End Module
