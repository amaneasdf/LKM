Imports System.Runtime.InteropServices
Public Class ambil_foto
    Const WM_CAP_START = &H400S
    Const WS_CHILD = &H40000000
    Const WS_VISIBLE = &H10000000

    Const WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10
    Const WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11
    Const WM_CAP_EDIT_COPY = WM_CAP_START + 30
    Const WM_CAP_SEQUENCE = WM_CAP_START + 62
    Const WM_CAP_FILE_SAVEAS = WM_CAP_START + 23

    Const WM_CAP_SET_SCALE = WM_CAP_START + 53
    Const WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52
    Const WM_CAP_SET_PREVIEW = WM_CAP_START + 50

    Const SWP_NOMOVE = &H2S
    Const SWP_NOSIZE = 1
    Const SWP_NOZORDER = &H4S
    Const HWND_BOTTOM = 1

    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" _
       (ByVal wDriverIndex As Short, _
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, _
        ByVal cbVer As Integer) As Boolean

    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
       (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWnd As Integer, _
        ByVal nID As Integer) As Integer

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
       (ByVal hwnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, _
       <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" _
       (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Dim VideoSource As Integer
    Dim hWnd As Integer

    Private Sub ambil_foto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub ambil_foto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DriverName As String = Space(80)
        Dim DriverVersion As String = Space(80)
        ListBox1.Items.Clear()
        For i As Integer = 0 To 9
            If capGetDriverDescriptionA(i, DriverName, 80, DriverVersion, 80) Then
                ListBox1.Items.Add(DriverName.Trim)
            End If
        Next
        Me.ResizeRedraw = True
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        Dim pool As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim count = 1
        Dim cc As New Random
        Dim pass = ""

        While count <= 6
            pass = pass & pool(cc.Next(0, pool.Length))
            count = count + 1
        End While

        SaveFileDialog1.Filter = "jpg|*.jpg"

        SaveFileDialog1.FileName = "foto_" + pass.ToString + ".jpg"

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image.Save(SaveFileDialog1.FileName)
            Me.Dispose()
        End If
    End Sub

    Private Sub btnfoto_Click(sender As Object, e As EventArgs) Handles btnfoto.Click
        Dim data As IDataObject
        Dim bmap As Image

        SendMessage(hWnd, WM_CAP_EDIT_COPY, 0, 0)

        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then

            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
            PictureBox1.Image = bmap
            SendMessage(hWnd, WM_CAP_DRIVER_DISCONNECT, VideoSource, 0)
            DestroyWindow(hWnd)
            btnsimpan.Enabled = True
            btnfoto.Enabled = False
            MessageBox.Show("Berhasil", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ambil_foto_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, Color.PaleTurquoise, Color.DodgerBlue, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        SendMessage(hWnd, WM_CAP_DRIVER_DISCONNECT, VideoSource, 0)
        DestroyWindow(hWnd)

        VideoSource = ListBox1.SelectedIndex

        hWnd = capCreateCaptureWindowA(VideoSource, WS_VISIBLE Or WS_CHILD, 0, 0, 0, _
            0, PictureBox1.Handle.ToInt32, 0)
        If SendMessage(hWnd, WM_CAP_DRIVER_CONNECT, VideoSource, 0) Then

            SendMessage(hWnd, WM_CAP_SET_SCALE, True, 0)

            SendMessage(hWnd, WM_CAP_SET_PREVIEWRATE, 30, 0)

            SendMessage(hWnd, WM_CAP_SET_PREVIEW, True, 0)

            SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, _
               PictureBox1.Width, PictureBox1.Height, _
               SWP_NOMOVE Or SWP_NOZORDER)
            btnfoto.Enabled = True
        Else
            DestroyWindow(hWnd)
            btnfoto.Enabled = False
        End If

    End Sub
End Class