<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class transaksi_jurnal_non_kas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(transaksi_jurnal_non_kas))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tno_kuitansi = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbkode_transaksi = New System.Windows.Forms.ComboBox()
        Me.tkode_transaksi = New System.Windows.Forms.TextBox()
        Me.tid_transaksi = New System.Windows.Forms.TextBox()
        Me.tjumlah = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tsaldo2_d = New System.Windows.Forms.TextBox()
        Me.tsaldo1_d = New System.Windows.Forms.TextBox()
        Me.tnama_perkiraan_d = New System.Windows.Forms.TextBox()
        Me.tkode_perkiraan_d = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tsaldo2_k = New System.Windows.Forms.TextBox()
        Me.tsaldo1_k = New System.Windows.Forms.TextBox()
        Me.tnama_perkiraan_k = New System.Windows.Forms.TextBox()
        Me.tkode_perkiraan_k = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tketerangan = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.btnvalidasi = New System.Windows.Forms.Button()
        Me.btntambah = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 49)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 357)
        Me.Panel2.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(100, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Tgl Transaksi :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(88, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Kode Transaksi :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(114, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "ID Tranaksi :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(114, 332)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 16)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Keterangan :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(426, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Jumlah (Rp) :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.LKM.My.Resources.Resources.header4
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(796, 49)
        Me.Panel1.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(259, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Transaksi Jurnal Non Kas"
        '
        'tno_kuitansi
        '
        Me.tno_kuitansi.Location = New System.Drawing.Point(517, 84)
        Me.tno_kuitansi.MaxLength = 20
        Me.tno_kuitansi.Name = "tno_kuitansi"
        Me.tno_kuitansi.Size = New System.Drawing.Size(150, 22)
        Me.tno_kuitansi.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(514, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "No. Kuitansi :"
        '
        'cmbkode_transaksi
        '
        Me.cmbkode_transaksi.DropDownHeight = 100
        Me.cmbkode_transaksi.FormattingEnabled = True
        Me.cmbkode_transaksi.IntegralHeight = False
        Me.cmbkode_transaksi.Location = New System.Drawing.Point(264, 82)
        Me.cmbkode_transaksi.Name = "cmbkode_transaksi"
        Me.cmbkode_transaksi.Size = New System.Drawing.Size(244, 24)
        Me.cmbkode_transaksi.TabIndex = 12
        '
        'tkode_transaksi
        '
        Me.tkode_transaksi.Location = New System.Drawing.Point(208, 84)
        Me.tkode_transaksi.MaxLength = 2
        Me.tkode_transaksi.Name = "tkode_transaksi"
        Me.tkode_transaksi.Size = New System.Drawing.Size(50, 22)
        Me.tkode_transaksi.TabIndex = 11
        Me.tkode_transaksi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tid_transaksi
        '
        Me.tid_transaksi.Enabled = False
        Me.tid_transaksi.Location = New System.Drawing.Point(208, 56)
        Me.tid_transaksi.Name = "tid_transaksi"
        Me.tid_transaksi.Size = New System.Drawing.Size(300, 22)
        Me.tid_transaksi.TabIndex = 10
        '
        'tjumlah
        '
        Me.tjumlah.Location = New System.Drawing.Point(517, 112)
        Me.tjumlah.MaxLength = 15
        Me.tjumlah.Name = "tjumlah"
        Me.tjumlah.Size = New System.Drawing.Size(150, 22)
        Me.tjumlah.TabIndex = 15
        Me.tjumlah.Text = "0"
        Me.tjumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.tsaldo2_d)
        Me.GroupBox1.Controls.Add(Me.tsaldo1_d)
        Me.GroupBox1.Controls.Add(Me.tnama_perkiraan_d)
        Me.GroupBox1.Controls.Add(Me.tkode_perkiraan_d)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(208, 140)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(459, 113)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DEBET"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(329, 26)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(61, 22)
        Me.TextBox1.TabIndex = 77
        Me.TextBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightBlue
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.LKM.My.Resources.Resources.Search_16x16
        Me.Button1.Location = New System.Drawing.Point(281, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.UseVisualStyleBackColor = False
        '
        'tsaldo2_d
        '
        Me.tsaldo2_d.Enabled = False
        Me.tsaldo2_d.Location = New System.Drawing.Point(303, 82)
        Me.tsaldo2_d.Name = "tsaldo2_d"
        Me.tsaldo2_d.Size = New System.Drawing.Size(150, 22)
        Me.tsaldo2_d.TabIndex = 21
        Me.tsaldo2_d.Text = "0"
        Me.tsaldo2_d.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tsaldo1_d
        '
        Me.tsaldo1_d.Enabled = False
        Me.tsaldo1_d.Location = New System.Drawing.Point(125, 82)
        Me.tsaldo1_d.Name = "tsaldo1_d"
        Me.tsaldo1_d.Size = New System.Drawing.Size(150, 22)
        Me.tsaldo1_d.TabIndex = 20
        Me.tsaldo1_d.Text = "0"
        Me.tsaldo1_d.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tnama_perkiraan_d
        '
        Me.tnama_perkiraan_d.Enabled = False
        Me.tnama_perkiraan_d.Location = New System.Drawing.Point(125, 54)
        Me.tnama_perkiraan_d.Name = "tnama_perkiraan_d"
        Me.tnama_perkiraan_d.Size = New System.Drawing.Size(328, 22)
        Me.tnama_perkiraan_d.TabIndex = 19
        '
        'tkode_perkiraan_d
        '
        Me.tkode_perkiraan_d.Location = New System.Drawing.Point(125, 26)
        Me.tkode_perkiraan_d.MaxLength = 18
        Me.tkode_perkiraan_d.Name = "tkode_perkiraan_d"
        Me.tkode_perkiraan_d.Size = New System.Drawing.Size(150, 22)
        Me.tkode_perkiraan_d.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(40, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 16)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Saldo (Rp) :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 16)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Nama Pekiraan :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 16)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Kode Pekiraan :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.tsaldo2_k)
        Me.GroupBox2.Controls.Add(Me.tsaldo1_k)
        Me.GroupBox2.Controls.Add(Me.tnama_perkiraan_k)
        Me.GroupBox2.Controls.Add(Me.tkode_perkiraan_k)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(208, 259)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(459, 113)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "KREDIT"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(329, 23)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(61, 22)
        Me.TextBox2.TabIndex = 78
        Me.TextBox2.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LightBlue
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.LKM.My.Resources.Resources.Search_16x16
        Me.Button2.Location = New System.Drawing.Point(281, 26)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(25, 23)
        Me.Button2.TabIndex = 24
        Me.Button2.UseVisualStyleBackColor = False
        '
        'tsaldo2_k
        '
        Me.tsaldo2_k.Enabled = False
        Me.tsaldo2_k.Location = New System.Drawing.Point(303, 82)
        Me.tsaldo2_k.Name = "tsaldo2_k"
        Me.tsaldo2_k.Size = New System.Drawing.Size(150, 22)
        Me.tsaldo2_k.TabIndex = 27
        Me.tsaldo2_k.Text = "0"
        Me.tsaldo2_k.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tsaldo1_k
        '
        Me.tsaldo1_k.Enabled = False
        Me.tsaldo1_k.Location = New System.Drawing.Point(125, 82)
        Me.tsaldo1_k.Name = "tsaldo1_k"
        Me.tsaldo1_k.Size = New System.Drawing.Size(150, 22)
        Me.tsaldo1_k.TabIndex = 26
        Me.tsaldo1_k.Text = "0"
        Me.tsaldo1_k.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tnama_perkiraan_k
        '
        Me.tnama_perkiraan_k.Enabled = False
        Me.tnama_perkiraan_k.Location = New System.Drawing.Point(125, 54)
        Me.tnama_perkiraan_k.Name = "tnama_perkiraan_k"
        Me.tnama_perkiraan_k.Size = New System.Drawing.Size(328, 22)
        Me.tnama_perkiraan_k.TabIndex = 25
        '
        'tkode_perkiraan_k
        '
        Me.tkode_perkiraan_k.Location = New System.Drawing.Point(125, 26)
        Me.tkode_perkiraan_k.MaxLength = 18
        Me.tkode_perkiraan_k.Name = "tkode_perkiraan_k"
        Me.tkode_perkiraan_k.Size = New System.Drawing.Size(150, 22)
        Me.tkode_perkiraan_k.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(40, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 16)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Saldo (Rp) :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 16)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Nama Pekiraan :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 29)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 16)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Kode Pekiraan :"
        '
        'tketerangan
        '
        Me.tketerangan.Location = New System.Drawing.Point(208, 378)
        Me.tketerangan.MaxLength = 60
        Me.tketerangan.Name = "tketerangan"
        Me.tketerangan.Size = New System.Drawing.Size(459, 22)
        Me.tketerangan.TabIndex = 28
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.btnkeluar)
        Me.GroupBox6.Controls.Add(Me.btnvalidasi)
        Me.GroupBox6.Controls.Add(Me.btntambah)
        Me.GroupBox6.Location = New System.Drawing.Point(673, 56)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(113, 197)
        Me.GroupBox6.TabIndex = 29
        Me.GroupBox6.TabStop = False
        '
        'btnkeluar
        '
        Me.btnkeluar.BackColor = System.Drawing.Color.LightBlue
        Me.btnkeluar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnkeluar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnkeluar.FlatAppearance.BorderSize = 2
        Me.btnkeluar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnkeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnkeluar.Location = New System.Drawing.Point(6, 133)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(100, 50)
        Me.btnkeluar.TabIndex = 32
        Me.btnkeluar.Text = "Keluar (Esc)"
        Me.btnkeluar.UseVisualStyleBackColor = False
        '
        'btnvalidasi
        '
        Me.btnvalidasi.BackColor = System.Drawing.Color.LightBlue
        Me.btnvalidasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnvalidasi.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnvalidasi.FlatAppearance.BorderSize = 2
        Me.btnvalidasi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnvalidasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnvalidasi.Location = New System.Drawing.Point(6, 21)
        Me.btnvalidasi.Name = "btnvalidasi"
        Me.btnvalidasi.Size = New System.Drawing.Size(100, 50)
        Me.btnvalidasi.TabIndex = 30
        Me.btnvalidasi.Text = "Validasi (F5)"
        Me.btnvalidasi.UseVisualStyleBackColor = False
        '
        'btntambah
        '
        Me.btntambah.BackColor = System.Drawing.Color.LightBlue
        Me.btntambah.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btntambah.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btntambah.FlatAppearance.BorderSize = 2
        Me.btntambah.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btntambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btntambah.Location = New System.Drawing.Point(6, 77)
        Me.btntambah.Name = "btntambah"
        Me.btntambah.Size = New System.Drawing.Size(100, 50)
        Me.btntambah.TabIndex = 31
        Me.btntambah.Text = "Tambah (F7)"
        Me.btntambah.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd-MM-yyyy   HH:mm:ss"
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(208, 112)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 22)
        Me.DateTimePicker1.TabIndex = 14
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(396, 27)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(57, 22)
        Me.TextBox3.TabIndex = 78
        Me.TextBox3.Text = "1"
        Me.TextBox3.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(392, 26)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(61, 22)
        Me.TextBox4.TabIndex = 78
        Me.TextBox4.Text = "1"
        Me.TextBox4.Visible = False
        '
        'transaksi_jurnal_non_kas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(796, 406)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.tketerangan)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tjumlah)
        Me.Controls.Add(Me.tno_kuitansi)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbkode_transaksi)
        Me.Controls.Add(Me.tkode_transaksi)
        Me.Controls.Add(Me.tid_transaksi)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "transaksi_jurnal_non_kas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tno_kuitansi As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbkode_transaksi As System.Windows.Forms.ComboBox
    Friend WithEvents tkode_transaksi As System.Windows.Forms.TextBox
    Friend WithEvents tid_transaksi As System.Windows.Forms.TextBox
    Friend WithEvents tjumlah As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tsaldo2_d As System.Windows.Forms.TextBox
    Friend WithEvents tsaldo1_d As System.Windows.Forms.TextBox
    Friend WithEvents tnama_perkiraan_d As System.Windows.Forms.TextBox
    Friend WithEvents tkode_perkiraan_d As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tsaldo2_k As System.Windows.Forms.TextBox
    Friend WithEvents tsaldo1_k As System.Windows.Forms.TextBox
    Friend WithEvents tnama_perkiraan_k As System.Windows.Forms.TextBox
    Friend WithEvents tkode_perkiraan_k As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tketerangan As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents btnvalidasi As System.Windows.Forms.Button
    Friend WithEvents btntambah As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
End Class
