Imports MySql.Data.MySqlClient
Public Class setup_grup_pengguna

    Sub tabel_list()
        With ListView1.Columns
            .Clear()
            .Add("", 0)
            .Add("Menu", 100)
            .Add("Label", 275)
        End With
    End Sub

    Private Sub setup_grup_pengguna_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tnama_grup.Focus()
    End Sub

    Private Sub setup_grup_pengguna_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub setup_grup_pengguna_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnkeluar.PerformClick()
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Sub setup_grup_pengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabel_list()
        If Label5.Text = "tambah" Then
            TreeAll()
            'Call ClearTB(Me)
        Else
            TreeAll()
            DataMenu()
        End If
        tnama_grup.Focus()
        Me.ResizeRedraw = True
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        Me.Dispose()
    End Sub

    Sub DataMenu()
        cd = New MySqlCommand("SELECT menu_kode, menu_label, IF(CHAR_LENGTH(menu_kode)=6, CONCAT('     ', menu_label), IF(CHAR_LENGTH(menu_kode)=8, CONCAT('          ', menu_label), menu_label)) as Label FROM kode_menu WHERE menu_set = 1 and menu_group='" & tkode_grup.Text & "' ORDER BY menu_kode ASC ", koneksi)
        rd = cd.ExecuteReader
        If rd.HasRows Then
            With ListView1
                .Items.Clear()
                Do While rd.Read
                    Dim ls As New ListViewItem()
                    ls.SubItems.Add(rd.Item("menu_kode").ToString())
                    ls.SubItems.Add(rd.Item("Label").ToString())
                    .Items.Add(ls)
                Loop
            End With
        End If
        rd.Close()

        tjumlah.Text = ListView1.Items.Count
        BoldListview()
        TreeChekBox()

    End Sub
    Sub BoldListview()
        For i = 0 To ListView1.Items.Count - 1
            Dim ls As String = ListView1.Items(i).SubItems(1).Text
            If Len(ls) = 4 Then
                ListView1.Items(i).Font = New Font(ListView1.Font, FontStyle.Bold)
            End If
        Next
    End Sub
    Sub TreeChekBox()
        cd = New MySqlCommand("SELECT menu_kode FROM kode_menu WHERE menu_set = 1 AND menu_group = '" & tkode_grup.Text & "' ORDER BY menu_kode ASC ", koneksi)
        rd = cd.ExecuteReader
        Do While rd.Read
            For Each item As TreeNode In TreeView1.Nodes
                Dim NodeName As String = "mn" & item.Text.ToString.Split(".")(0)
                Dim MenuKode As String = rd.Item("menu_kode").ToString

                If NodeName = MenuKode Then item.Checked = True
                For Each ChildNode As TreeNode In item.Nodes
                    Dim ChildName As String = "mn" & ChildNode.Text.ToString.Split(".")(0)
                    If ChildName = MenuKode Then ChildNode.Checked = True

                    For Each Child2 As TreeNode In ChildNode.Nodes
                        Dim Child2Name As String = "mn" & Child2.Text.ToString.Split(".")(0)
                        If Child2Name = MenuKode Then Child2.Checked = True

                        For Each Child3 As TreeNode In Child2.Nodes
                            Dim Child3Name As String = "mn" & Child3.Text.ToString.Split(".")(0)
                            If Child3Name = MenuKode Then Child3.Checked = True

                        Next
                    Next
                Next
            Next
        Loop
        rd.Close()
    End Sub
    Sub TreeAll()
        Dim ParentNode As New TreeNode
        Dim ChildNode, ChildNode2 As New TreeNode
        Dim MenuKode, MenuLabel As String

        cd = New MySqlCommand("SELECT menu_kode, menu_label FROM data_menu_master ORDER BY menu_kode", koneksi)
        rd = cd.ExecuteReader
        TreeView1.Nodes.Clear()
        Do While rd.Read
            MenuKode = rd.Item("menu_kode").ToString
            MenuLabel = Mid(MenuKode, 3, 20) & ". " & rd.Item("menu_label").ToString

            If Len(MenuKode) = 4 Then
                Dim node1 As New TreeNode(MenuLabel)
                ParentNode = node1
                TreeView1.Nodes.Add(ParentNode)
            End If
            If Len(MenuKode) = 6 Then
                Dim node2 As New TreeNode(MenuLabel)
                ChildNode = node2
                ParentNode.Nodes.Add(ChildNode)
            End If
            If Len(MenuKode) = 8 Then
                Dim node3 As New TreeNode(MenuLabel)
                ChildNode2 = node3
                ChildNode.Nodes.Add(ChildNode2)
            End If
        Loop
        rd.Close()
        TreeView1.ExpandAll()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If Trim(tnama_grup.Text) = "" Then
            MessageBox.Show("Nama group belum diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tnama_grup.Focus()
            Exit Sub
        End If
        If Trim(tketerangan.Text) = "" Then
            MessageBox.Show("Keterangan belum diisi.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tketerangan.Focus()
            Exit Sub
        End If

        If tkode_grup.Text = "" Then
            cd = New MySqlCommand("SELECT IFNULL(MAX(grup_akses_kode), '0') as Kode FROM data_grup_akses", koneksi)
            rd = cd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                tkode_grup.Text = Val(rd.Item("Kode")) + 1
            End If
            rd.Close()

            cd = New MySqlCommand("INSERT INTO data_grup_akses VALUES ( '" & tkode_grup.Text & "', '" & tnama_grup.Text & "', '" & tketerangan.Text & "', '" & MDIParent1.username.Text & "', '" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "', '" & MDIParent1.username.Text & "',  '" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "')", koneksi)
            cd.ExecuteNonQuery()

            user_pengguna = MDIParent1.username.Text
            uraian = "Menambah Grup Akses (grup_akses_kode : " + tkode_grup.Text + ")"
            insert_log_user()

        Else
            cd = New MySqlCommand("UPDATE data_grup_akses SET grup_akses_nama = '" & tnama_grup.Text & "', grup_akses_keterangan = '" & tketerangan.Text & "', grup_akses_update_waktu = '" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "', grup_akses_update_username = '" & MDIParent1.username.Text & "' WHERE grup_akses_kode = '" & tkode_grup.Text & "'", koneksi)
            cd.ExecuteNonQuery()

            user_pengguna = MDIParent1.username.Text
            uraian = "Merubah Grup Akses (grup_akses_kode : " + tkode_grup.Text + ")"
            insert_log_user()

        End If

        cd = New MySqlCommand("DELETE FROM kode_menu WHERE menu_group = '" & tkode_grup.Text & "'", koneksi)
        cd.ExecuteNonQuery()

        TreeviewToListview()
        For i = 0 To ListView1.Items.Count - 1
            Dim ItemKode As String = ListView1.Items(i).SubItems(1).Text
            Dim ItemLabel As String = Trim(ListView1.Items(i).SubItems(2).Text)
            cd = New MySqlCommand("INSERT INTO kode_menu SET menu_kode = '" & ItemKode & "', menu_group = '" & tkode_grup.Text & "', menu_label = '" & ItemLabel & "', menu_set = 1, menu_parent = '" & Microsoft.VisualBasic.Left(ItemKode, 4) & "', menu_reg_username = '" & MDIParent1.username.Text & "', menu_reg_waktu = '" & Format(MDIParent1.DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") & "'", koneksi)
            cd.ExecuteNonQuery()
        Next
        DataMenu()
        master_grup_akses.data()
        MessageBox.Show("Master Grup Akses berhasil disimpan.", nama_aplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Sub TreeviewToListview()
        ListView1.Items.Clear()
        For Each item As TreeNode In TreeView1.Nodes
            Dim MenuKode As String = "mn" & item.Text.ToString.Split(".")(0)
            Dim MenuNama As String = item.Text.ToString.Split(". ")(1)
            'Dim MenuNama As String = item.Text
            'Parent Node
            If item.Checked = True Then
                Dim ls As New ListViewItem()
                ls.SubItems.Add(MenuKode)
                ls.SubItems.Add(MenuNama)
                ListView1.Items.Add(ls)

                'ChildNode - 1
                For Each ChildNode As TreeNode In item.Nodes
                    Dim ChildKode As String = "mn" & ChildNode.Text.ToString.Split(".")(0)
                    Dim ChildNama As String = ChildNode.Text.ToString.Split(". ")(1)
                    If ChildNode.Checked = True Then
                        Dim lsChild As New ListViewItem()
                        lsChild.SubItems.Add(ChildKode)
                        lsChild.SubItems.Add("     " & ChildNama)
                        ListView1.Items.Add(lsChild)
                    End If

                    'ChildNode - 2
                    For Each Child2 As TreeNode In ChildNode.Nodes
                        Dim Child2Kode As String = "mn" & Child2.Text.ToString.Split(".")(0)
                        Dim Child2Nama As String = Child2.Text.ToString.Split(". ")(1)
                        If Child2.Checked = True Then
                            Dim lsChild2 As New ListViewItem()
                            lsChild2.SubItems.Add(Child2Kode)
                            lsChild2.SubItems.Add("     " & Child2Nama)
                            ListView1.Items.Add(lsChild2)
                        End If

                        'ChildNode - 3
                        For Each Child3 As TreeNode In Child2.Nodes
                            Dim Child3Kode As String = "mn" & Child3.Text.ToString.Split(".")(0)
                            Dim Child3Nama As String = Child3.Text.ToString.Split(". ")(1)
                            If Child3.Checked = True Then
                                Dim lsChild3 As New ListViewItem()
                                lsChild3.SubItems.Add(Child3Kode)
                                lsChild3.SubItems.Add("     " & Child3Nama)
                                ListView1.Items.Add(lsChild3)
                            End If
                        Next
                    Next
                Next
            End If
        Next
        tjumlah.Text = ListView1.Items.Count
    End Sub


    Private Sub setup_grup_pengguna_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Try
            Dim d As New System.Drawing.Drawing2D.LinearGradientBrush(Me.ClientRectangle, warna1, warna2, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(d, Me.ClientRectangle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnceksemua_Click(sender As Object, e As EventArgs) Handles btnceksemua.Click
        For Each item As TreeNode In TreeView1.Nodes
            item.Checked = True
            For Each ChildNode As TreeNode In item.Nodes
                ChildNode.Checked = True
                For Each Child2 As TreeNode In ChildNode.Nodes
                    Child2.Checked = True
                Next
            Next
        Next
    End Sub

    Sub kosong()
        tkode_grup.Clear()
        tnama_grup.Clear()
        tketerangan.Clear()
        ListView1.Items.Clear()
        tjumlah.Text = "0"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        TreeviewToListview()
    End Sub

    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        For Each item As TreeNode In TreeView1.Nodes
            item.Checked = False
            For Each ChildNode As TreeNode In item.Nodes
                ChildNode.Checked = False
                For Each Child2 As TreeNode In ChildNode.Nodes
                    Child2.Checked = False
                Next
            Next
        Next
    End Sub
End Class