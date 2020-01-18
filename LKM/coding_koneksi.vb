Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO

Module coding_koneksi
    Public koneksi As MySqlConnection
    Public da As MySqlDataAdapter
    Public dt As DataTable
    Public ds As DataSet
    Public cd As MySqlCommand
    Public rd As MySqlDataReader
    Private server, uid, password, database As String

    Sub koneksi_localhost()
        'baca_config()
        Try
            MainConnData = LoadDataConnection(NetworkSettingName)
            server = MainConnData.host
            database = MainConnData.db
            uid = decryptString(MainConnData.uid)
            password = decryptString(MainConnData.pwd)
            MainConnection = New MySqlThing(server, database, uid, password)

            koneksi = New MySqlConnection("server=" & server & ";uid=" & uid & ";password=" & password & ";database=" & database & "")
            koneksi.Open()
            koneksi.Close()
        Catch ex As Exception
            MsgBox("Koneksi error ke server (" & server & ")")
        End Try
    End Sub

    Sub baca_config()
        Dim sr As New IO.StreamReader("config.ini")
        Dim s As String
        Dim i As Integer = 1
        Do Until sr.EndOfStream
            'tiap baris ditampung di s
            s = sr.ReadLine
            Select Case i
                Case 2
                    server = Replace(s, "server=", "")
                Case 3
                    uid = Replace(s, "uid=", "")
                Case 4
                    password = Replace(s, "password=", "")
                Case 5
                    database = Replace(s, "database=", "")
            End Select
            i = i + 1
        Loop
        sr.Close()
    End Sub

End Module
