<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class data_pengguna
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(data_pengguna))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tnama_alias = New System.Windows.Forms.TextBox()
        Me.tnama_lengkap = New System.Windows.Forms.TextBox()
        Me.tpassword = New System.Windows.Forms.TextBox()
        Me.cmbgrup_akses = New System.Windows.Forms.ComboBox()
        Me.cmbstatus = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnbuka_folder = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnambil_foto = New System.Windows.Forms.Button()
        Me.btnhapus_foto = New System.Windows.Forms.Button()
        Me.btnlog_user = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnsimpan = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tkode_teller = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(39, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nama Alias :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(16, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Nama Lengkap :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(39, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Grup Akses :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(50, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Password :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(73, 222)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Status :"
        '
        'tnama_alias
        '
        Me.tnama_alias.Location = New System.Drawing.Point(129, 77)
        Me.tnama_alias.MaxLength = 10
        Me.tnama_alias.Name = "tnama_alias"
        Me.tnama_alias.Size = New System.Drawing.Size(121, 22)
        Me.tnama_alias.TabIndex = 10
        '
        'tnama_lengkap
        '
        Me.tnama_lengkap.Location = New System.Drawing.Point(130, 133)
        Me.tnama_lengkap.MaxLength = 30
        Me.tnama_lengkap.Name = "tnama_lengkap"
        Me.tnama_lengkap.Size = New System.Drawing.Size(220, 22)
        Me.tnama_lengkap.TabIndex = 11
        '
        'tpassword
        '
        Me.tpassword.Location = New System.Drawing.Point(130, 191)
        Me.tpassword.Name = "tpassword"
        Me.tpassword.ReadOnly = True
        Me.tpassword.Size = New System.Drawing.Size(121, 22)
        Me.tpassword.TabIndex = 14
        '
        'cmbgrup_akses
        '
        Me.cmbgrup_akses.DropDownHeight = 100
        Me.cmbgrup_akses.FormattingEnabled = True
        Me.cmbgrup_akses.IntegralHeight = False
        Me.cmbgrup_akses.Location = New System.Drawing.Point(130, 161)
        Me.cmbgrup_akses.Name = "cmbgrup_akses"
        Me.cmbgrup_akses.Size = New System.Drawing.Size(220, 24)
        Me.cmbgrup_akses.TabIndex = 13
        '
        'cmbstatus
        '
        Me.cmbstatus.DropDownHeight = 100
        Me.cmbstatus.FormattingEnabled = True
        Me.cmbstatus.IntegralHeight = False
        Me.cmbstatus.Location = New System.Drawing.Point(130, 219)
        Me.cmbstatus.Name = "cmbstatus"
        Me.cmbstatus.Size = New System.Drawing.Size(121, 24)
        Me.cmbstatus.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnbuka_folder)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.btnambil_foto)
        Me.GroupBox1.Controls.Add(Me.btnhapus_foto)
        Me.GroupBox1.Location = New System.Drawing.Point(356, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(163, 295)
        Me.GroupBox1.TabIndex = 64
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Foto"
        '
        'btnbuka_folder
        '
        Me.btnbuka_folder.BackColor = System.Drawing.Color.LightBlue
        Me.btnbuka_folder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnbuka_folder.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnbuka_folder.FlatAppearance.BorderSize = 2
        Me.btnbuka_folder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnbuka_folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbuka_folder.Location = New System.Drawing.Point(6, 259)
        Me.btnbuka_folder.Name = "btnbuka_folder"
        Me.btnbuka_folder.Size = New System.Drawing.Size(150, 30)
        Me.btnbuka_folder.TabIndex = 66
        Me.btnbuka_folder.Text = "Ambil File"
        Me.btnbuka_folder.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(6, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 200)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'btnambil_foto
        '
        Me.btnambil_foto.BackColor = System.Drawing.Color.LightBlue
        Me.btnambil_foto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnambil_foto.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnambil_foto.FlatAppearance.BorderSize = 2
        Me.btnambil_foto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnambil_foto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnambil_foto.Location = New System.Drawing.Point(6, 227)
        Me.btnambil_foto.Name = "btnambil_foto"
        Me.btnambil_foto.Size = New System.Drawing.Size(82, 30)
        Me.btnambil_foto.TabIndex = 64
        Me.btnambil_foto.Text = "Capture"
        Me.btnambil_foto.UseVisualStyleBackColor = False
        '
        'btnhapus_foto
        '
        Me.btnhapus_foto.BackColor = System.Drawing.Color.LightBlue
        Me.btnhapus_foto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnhapus_foto.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnhapus_foto.FlatAppearance.BorderSize = 2
        Me.btnhapus_foto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnhapus_foto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnhapus_foto.Image = Global.LKM.My.Resources.Resources.Delete_small
        Me.btnhapus_foto.Location = New System.Drawing.Point(126, 227)
        Me.btnhapus_foto.Name = "btnhapus_foto"
        Me.btnhapus_foto.Size = New System.Drawing.Size(30, 30)
        Me.btnhapus_foto.TabIndex = 65
        Me.btnhapus_foto.UseVisualStyleBackColor = False
        '
        'btnlog_user
        '
        Me.btnlog_user.BackColor = System.Drawing.Color.LightBlue
        Me.btnlog_user.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnlog_user.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnlog_user.FlatAppearance.BorderSize = 2
        Me.btnlog_user.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnlog_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlog_user.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlog_user.Location = New System.Drawing.Point(238, 250)
        Me.btnlog_user.Margin = New System.Windows.Forms.Padding(4)
        Me.btnlog_user.Name = "btnlog_user"
        Me.btnlog_user.Size = New System.Drawing.Size(110, 49)
        Me.btnlog_user.TabIndex = 65
        Me.btnlog_user.Text = "Log User"
        Me.btnlog_user.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(288, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 16)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "Label7"
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(288, 219)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 16)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Label8"
        Me.Label8.Visible = False
        '
        'btnsimpan
        '
        Me.btnsimpan.BackColor = System.Drawing.Color.LightBlue
        Me.btnsimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsimpan.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnsimpan.FlatAppearance.BorderSize = 2
        Me.btnsimpan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnsimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsimpan.Image = Global.LKM.My.Resources.Resources.Save
        Me.btnsimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsimpan.Location = New System.Drawing.Point(130, 250)
        Me.btnsimpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnsimpan.Name = "btnsimpan"
        Me.btnsimpan.Size = New System.Drawing.Size(100, 49)
        Me.btnsimpan.TabIndex = 16
        Me.btnsimpan.Text = "Simpan"
        Me.btnsimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsimpan.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.LKM.My.Resources.Resources.header4
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.btnkeluar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(531, 49)
        Me.Panel1.TabIndex = 0
        '
        'btnkeluar
        '
        Me.btnkeluar.BackColor = System.Drawing.Color.LightBlue
        Me.btnkeluar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnkeluar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnkeluar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnkeluar.FlatAppearance.BorderSize = 2
        Me.btnkeluar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnkeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnkeluar.Image = Global.LKM.My.Resources.Resources.Close
        Me.btnkeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnkeluar.Location = New System.Drawing.Point(431, 0)
        Me.btnkeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(100, 49)
        Me.btnkeluar.TabIndex = 3
        Me.btnkeluar.Text = "Keluar"
        Me.btnkeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnkeluar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Data Pengguna"
        '
        'tkode_teller
        '
        Me.tkode_teller.Enabled = False
        Me.tkode_teller.Location = New System.Drawing.Point(129, 105)
        Me.tkode_teller.MaxLength = 10
        Me.tkode_teller.Name = "tkode_teller"
        Me.tkode_teller.Size = New System.Drawing.Size(50, 22)
        Me.tkode_teller.TabIndex = 70
        Me.tkode_teller.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(39, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 16)
        Me.Label9.TabIndex = 71
        Me.Label9.Text = "Kode Teller :"
        '
        'data_pengguna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 361)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tkode_teller)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnlog_user)
        Me.Controls.Add(Me.btnsimpan)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbstatus)
        Me.Controls.Add(Me.cmbgrup_akses)
        Me.Controls.Add(Me.tpassword)
        Me.Controls.Add(Me.tnama_lengkap)
        Me.Controls.Add(Me.tnama_alias)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "data_pengguna"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tnama_alias As System.Windows.Forms.TextBox
    Friend WithEvents tnama_lengkap As System.Windows.Forms.TextBox
    Friend WithEvents tpassword As System.Windows.Forms.TextBox
    Friend WithEvents cmbgrup_akses As System.Windows.Forms.ComboBox
    Friend WithEvents cmbstatus As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnbuka_folder As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnambil_foto As System.Windows.Forms.Button
    Friend WithEvents btnhapus_foto As System.Windows.Forms.Button
    Friend WithEvents btnsimpan As System.Windows.Forms.Button
    Friend WithEvents btnlog_user As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tkode_teller As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
