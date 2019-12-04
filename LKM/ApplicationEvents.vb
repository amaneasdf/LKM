Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        'One of the global exceptions we are catching is not thread safe, so we need to make it thread safe first.
        Private Delegate Sub SafeApplicationThreadException(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup

            'There are three places to catch all global unhandled exceptions:
            'AppDomain.CurrentDomain.UnhandledException event.
            'System.Windows.Forms.Application.ThreadException event.
            'MyApplication.UnhandledException event.
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf AppDomain_UnhandledException
            AddHandler System.Windows.Forms.Application.ThreadException, AddressOf app_ThreadException

            'CHECK FONT
            For Each _font As String In {"Open Sans", "Source Sans Pro"}
                If Not IsFontInstalled(_font) Then
                    Dim _idx As Integer = 0
                    Select Case _font
                        Case "Open Sans"
                            _idx = 1 : OpenSans_Self = True
                        Case "Source Sans Pro"
                            _idx = 2 : SourceSans_Self = True
                        Case Else : GoTo NextFont
                    End Select

                    'TODO : CHECK FILE AVALIABILITY

                    'REGISTER FONT FILES
                    For Each _file As String In IO.Directory.GetFiles(AppDir_SystemFile & "font\" & _idx & "\")
                        If _file.Split(".").Last = "ttf" Then AddFontResource(_file)
                    Next
                End If
NextFont:
            Next
        End Sub

        'ERROR HANDLING
        Private Sub MyApplication_UnhandledException(sender As Object, e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            GlobalExceptionHandler(e.Exception)
        End Sub

        Private Sub app_ThreadException(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)
            'This is not thread safe, so make it thread safe.
            If MainForm.InvokeRequired Then
                ' Invoke back to the main thread
                MainForm.Invoke(New SafeApplicationThreadException(AddressOf app_ThreadException), New Object() {sender, e})
            Else
                GlobalExceptionHandler(e.Exception)
            End If
        End Sub

        Private Sub AppDomain_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
            GlobalExceptionHandler(DirectCast(e.ExceptionObject, Exception))
        End Sub

        Private Sub GlobalExceptionHandler(ByVal ex As Exception)
            LogError(ex)
            MessageBox.Show("An unexcpected error occured. Application will be terminated." & Environment.NewLine & "Error : " & ex.Message,
                            "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Sub


    End Class


End Namespace

