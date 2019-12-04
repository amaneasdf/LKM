Imports MySql.Data.MySqlClient
Module informasi_aplikasi
    Public versi As String = "Versi 1.0"
    Public nama_aplikasi As String = "Micro Finance System ".ToString + versi
    Public uraian, user_pengguna, TextToPrint As String
    Public ukuran_font_cetak As Integer
    Public kiri, atas As Integer
    Public warna1 As Color = Color.White
    Public warna2 As Color = Color.DodgerBlue
    Public warna_gotfocus As Color = Color.Yellow
    Public warna_lostfocus As Color = Color.White


    Sub insert_log_user()
        cd = New MySqlCommand("INSERT INTO log_user VALUES ('', NOW(), '" & user_pengguna & "', '" & uraian & "')", koneksi)
        cd.ExecuteNonQuery()
    End Sub
End Module
