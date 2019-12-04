<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class data_kantor_pusat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(data_kantor_pusat))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnsimpan = New System.Windows.Forms.Button()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tid_lembaga = New System.Windows.Forms.TextBox()
        Me.tnama_lembaga = New System.Windows.Forms.TextBox()
        Me.talamat = New System.Windows.Forms.TextBox()
        Me.tkecamatan = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tkota = New System.Windows.Forms.TextBox()
        Me.cmbdaerah = New System.Windows.Forms.ComboBox()
        Me.cmbsandi = New System.Windows.Forms.ComboBox()
        Me.tkode_pos = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ttelepon = New System.Windows.Forms.TextBox()
        Me.tfax = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.temail = New System.Windows.Forms.TextBox()
        Me.tjml_direktur = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tjml_komisaris = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tpembuat_laporan = New System.Windows.Forms.TextBox()
        Me.tpemeriksa_laporan = New System.Windows.Forms.TextBox()
        Me.tnama_pimpinan = New System.Windows.Forms.TextBox()
        Me.tnik3 = New System.Windows.Forms.TextBox()
        Me.tnik2 = New System.Windows.Forms.TextBox()
        Me.tnik1 = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.LKM.My.Resources.Resources.header4
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.btnsimpan)
        Me.Panel1.Controls.Add(Me.btnkeluar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(715, 49)
        Me.Panel1.TabIndex = 0
        '
        'btnsimpan
        '
        Me.btnsimpan.BackColor = System.Drawing.Color.LightBlue
        Me.btnsimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsimpan.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnsimpan.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnsimpan.FlatAppearance.BorderSize = 2
        Me.btnsimpan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnsimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsimpan.Image = Global.LKM.My.Resources.Resources.Save
        Me.btnsimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsimpan.Location = New System.Drawing.Point(515, 0)
        Me.btnsimpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnsimpan.Name = "btnsimpan"
        Me.btnsimpan.Size = New System.Drawing.Size(100, 49)
        Me.btnsimpan.TabIndex = 29
        Me.btnsimpan.Text = "Simpan"
        Me.btnsimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsimpan.UseVisualStyleBackColor = False
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
        Me.btnkeluar.Location = New System.Drawing.Point(615, 0)
        Me.btnkeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(100, 49)
        Me.btnkeluar.TabIndex = 30
        Me.btnkeluar.Text = "Keluar"
        Me.btnkeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnkeluar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Setup Lembaga"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 49)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 380)
        Me.Panel2.TabIndex = 14
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(85, 354)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(110, 16)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "Nama Pimpinan :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(63, 326)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(132, 16)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Pemeriksa Laporan :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(74, 298)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 16)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Pembuat Laporan :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(111, 241)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 16)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Jml Direktur :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(147, 213)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 16)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Email :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(130, 185)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 16)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Telepon :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(109, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 16)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Sandi Wil BI :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(79, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 16)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Daerah Tingkat II :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(113, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Kecamatan :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(139, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Alamat :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(83, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Nama Lembaga :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(107, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "ID Lembaga :"
        '
        'tid_lembaga
        '
        Me.tid_lembaga.Enabled = False
        Me.tid_lembaga.Location = New System.Drawing.Point(208, 59)
        Me.tid_lembaga.MaxLength = 3
        Me.tid_lembaga.Name = "tid_lembaga"
        Me.tid_lembaga.Size = New System.Drawing.Size(50, 22)
        Me.tid_lembaga.TabIndex = 10
        Me.tid_lembaga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tnama_lembaga
        '
        Me.tnama_lembaga.Location = New System.Drawing.Point(208, 87)
        Me.tnama_lembaga.MaxLength = 60
        Me.tnama_lembaga.Name = "tnama_lembaga"
        Me.tnama_lembaga.Size = New System.Drawing.Size(500, 22)
        Me.tnama_lembaga.TabIndex = 11
        '
        'talamat
        '
        Me.talamat.Location = New System.Drawing.Point(208, 115)
        Me.talamat.MaxLength = 60
        Me.talamat.Name = "talamat"
        Me.talamat.Size = New System.Drawing.Size(500, 22)
        Me.talamat.TabIndex = 12
        '
        'tkecamatan
        '
        Me.tkecamatan.Location = New System.Drawing.Point(208, 143)
        Me.tkecamatan.MaxLength = 20
        Me.tkecamatan.Name = "tkecamatan"
        Me.tkecamatan.Size = New System.Drawing.Size(175, 22)
        Me.tkecamatan.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(486, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Kota :"
        '
        'tkota
        '
        Me.tkota.Location = New System.Drawing.Point(533, 143)
        Me.tkota.MaxLength = 20
        Me.tkota.Name = "tkota"
        Me.tkota.Size = New System.Drawing.Size(175, 22)
        Me.tkota.TabIndex = 14
        '
        'cmbdaerah
        '
        Me.cmbdaerah.DropDownHeight = 100
        Me.cmbdaerah.FormattingEnabled = True
        Me.cmbdaerah.IntegralHeight = False
        Me.cmbdaerah.Location = New System.Drawing.Point(208, 171)
        Me.cmbdaerah.Name = "cmbdaerah"
        Me.cmbdaerah.Size = New System.Drawing.Size(250, 24)
        Me.cmbdaerah.TabIndex = 15
        '
        'cmbsandi
        '
        Me.cmbsandi.DropDownHeight = 100
        Me.cmbsandi.FormattingEnabled = True
        Me.cmbsandi.IntegralHeight = False
        Me.cmbsandi.Location = New System.Drawing.Point(208, 201)
        Me.cmbsandi.Name = "cmbsandi"
        Me.cmbsandi.Size = New System.Drawing.Size(250, 24)
        Me.cmbsandi.TabIndex = 17
        '
        'tkode_pos
        '
        Me.tkode_pos.Location = New System.Drawing.Point(608, 171)
        Me.tkode_pos.MaxLength = 5
        Me.tkode_pos.Name = "tkode_pos"
        Me.tkode_pos.Size = New System.Drawing.Size(100, 22)
        Me.tkode_pos.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(530, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 16)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Kode Pos :"
        '
        'ttelepon
        '
        Me.ttelepon.Location = New System.Drawing.Point(208, 231)
        Me.ttelepon.MaxLength = 15
        Me.ttelepon.Name = "ttelepon"
        Me.ttelepon.Size = New System.Drawing.Size(175, 22)
        Me.ttelepon.TabIndex = 18
        '
        'tfax
        '
        Me.tfax.Location = New System.Drawing.Point(533, 231)
        Me.tfax.MaxLength = 15
        Me.tfax.Name = "tfax"
        Me.tfax.Size = New System.Drawing.Size(175, 22)
        Me.tfax.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(491, 234)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 16)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Fax :"
        '
        'temail
        '
        Me.temail.Location = New System.Drawing.Point(208, 259)
        Me.temail.Name = "temail"
        Me.temail.Size = New System.Drawing.Size(500, 22)
        Me.temail.TabIndex = 20
        '
        'tjml_direktur
        '
        Me.tjml_direktur.Location = New System.Drawing.Point(208, 287)
        Me.tjml_direktur.MaxLength = 2
        Me.tjml_direktur.Name = "tjml_direktur"
        Me.tjml_direktur.Size = New System.Drawing.Size(50, 22)
        Me.tjml_direktur.TabIndex = 21
        Me.tjml_direktur.Text = "0"
        Me.tjml_direktur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(430, 290)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 16)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Jml Komisaris :"
        '
        'tjml_komisaris
        '
        Me.tjml_komisaris.Location = New System.Drawing.Point(533, 287)
        Me.tjml_komisaris.MaxLength = 2
        Me.tjml_komisaris.Name = "tjml_komisaris"
        Me.tjml_komisaris.Size = New System.Drawing.Size(50, 22)
        Me.tjml_komisaris.TabIndex = 22
        Me.tjml_komisaris.Text = "0"
        Me.tjml_komisaris.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(492, 347)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(35, 16)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "NIK :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(492, 375)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 16)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "NIK :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(492, 403)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 16)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "NIK :"
        '
        'tpembuat_laporan
        '
        Me.tpembuat_laporan.Location = New System.Drawing.Point(208, 344)
        Me.tpembuat_laporan.MaxLength = 30
        Me.tpembuat_laporan.Name = "tpembuat_laporan"
        Me.tpembuat_laporan.Size = New System.Drawing.Size(250, 22)
        Me.tpembuat_laporan.TabIndex = 23
        '
        'tpemeriksa_laporan
        '
        Me.tpemeriksa_laporan.Location = New System.Drawing.Point(208, 372)
        Me.tpemeriksa_laporan.MaxLength = 30
        Me.tpemeriksa_laporan.Name = "tpemeriksa_laporan"
        Me.tpemeriksa_laporan.Size = New System.Drawing.Size(250, 22)
        Me.tpemeriksa_laporan.TabIndex = 25
        '
        'tnama_pimpinan
        '
        Me.tnama_pimpinan.Location = New System.Drawing.Point(208, 400)
        Me.tnama_pimpinan.MaxLength = 30
        Me.tnama_pimpinan.Name = "tnama_pimpinan"
        Me.tnama_pimpinan.Size = New System.Drawing.Size(250, 22)
        Me.tnama_pimpinan.TabIndex = 27
        '
        'tnik3
        '
        Me.tnik3.Location = New System.Drawing.Point(533, 400)
        Me.tnik3.MaxLength = 30
        Me.tnik3.Name = "tnik3"
        Me.tnik3.Size = New System.Drawing.Size(175, 22)
        Me.tnik3.TabIndex = 28
        '
        'tnik2
        '
        Me.tnik2.Location = New System.Drawing.Point(533, 372)
        Me.tnik2.MaxLength = 30
        Me.tnik2.Name = "tnik2"
        Me.tnik2.Size = New System.Drawing.Size(175, 22)
        Me.tnik2.TabIndex = 26
        '
        'tnik1
        '
        Me.tnik1.Location = New System.Drawing.Point(533, 344)
        Me.tnik1.MaxLength = 30
        Me.tnik1.Name = "tnik1"
        Me.tnik1.Size = New System.Drawing.Size(175, 22)
        Me.tnik1.TabIndex = 24
        '
        'data_kantor_pusat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 429)
        Me.ControlBox = False
        Me.Controls.Add(Me.tnik3)
        Me.Controls.Add(Me.tnik2)
        Me.Controls.Add(Me.tnik1)
        Me.Controls.Add(Me.tnama_pimpinan)
        Me.Controls.Add(Me.tpemeriksa_laporan)
        Me.Controls.Add(Me.tpembuat_laporan)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.tjml_komisaris)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tjml_direktur)
        Me.Controls.Add(Me.temail)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tfax)
        Me.Controls.Add(Me.ttelepon)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tkode_pos)
        Me.Controls.Add(Me.cmbsandi)
        Me.Controls.Add(Me.cmbdaerah)
        Me.Controls.Add(Me.tkota)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tkecamatan)
        Me.Controls.Add(Me.talamat)
        Me.Controls.Add(Me.tnama_lembaga)
        Me.Controls.Add(Me.tid_lembaga)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "data_kantor_pusat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tid_lembaga As System.Windows.Forms.TextBox
    Friend WithEvents tnama_lembaga As System.Windows.Forms.TextBox
    Friend WithEvents talamat As System.Windows.Forms.TextBox
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents btnsimpan As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tkecamatan As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tkota As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbdaerah As System.Windows.Forms.ComboBox
    Friend WithEvents cmbsandi As System.Windows.Forms.ComboBox
    Friend WithEvents tkode_pos As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ttelepon As System.Windows.Forms.TextBox
    Friend WithEvents tfax As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents temail As System.Windows.Forms.TextBox
    Friend WithEvents tjml_direktur As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tjml_komisaris As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tpembuat_laporan As System.Windows.Forms.TextBox
    Friend WithEvents tpemeriksa_laporan As System.Windows.Forms.TextBox
    Friend WithEvents tnama_pimpinan As System.Windows.Forms.TextBox
    Friend WithEvents tnik3 As System.Windows.Forms.TextBox
    Friend WithEvents tnik2 As System.Windows.Forms.TextBox
    Friend WithEvents tnik1 As System.Windows.Forms.TextBox
End Class
