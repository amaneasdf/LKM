<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class transaksi_jurnal_kas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(transaksi_jurnal_kas))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tid_transaksi = New System.Windows.Forms.TextBox()
        Me.tkode_jenis_transaksi = New System.Windows.Forms.TextBox()
        Me.cmb_jenis_transaksi = New System.Windows.Forms.ComboBox()
        Me.tno_kuitansi = New System.Windows.Forms.TextBox()
        Me.tsaldo_kas = New System.Windows.Forms.TextBox()
        Me.tjumlah = New System.Windows.Forms.TextBox()
        Me.tkode_perkiraan = New System.Windows.Forms.TextBox()
        Me.tnama_perkiraan1 = New System.Windows.Forms.TextBox()
        Me.tnama_perkiraan2 = New System.Windows.Forms.TextBox()
        Me.tsaldo1 = New System.Windows.Forms.TextBox()
        Me.tsaldo2 = New System.Windows.Forms.TextBox()
        Me.tketerangan = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.btnvalidasi = New System.Windows.Forms.Button()
        Me.btntambah = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 49)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 305)
        Me.Panel2.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(85, 224)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Nama Perkiraan :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(90, 193)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Kode Perkiraan :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(111, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Jumlah (Rp) :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(121, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Saldo Kas :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(100, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Tgl Transaksi :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(95, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Jenis Tranaksi :"
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
        Me.Label11.Location = New System.Drawing.Point(114, 278)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 16)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Keterangan :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(118, 252)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 16)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Saldo (Rp) :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(113, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "No. Kuitansi :"
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
        Me.Panel1.Size = New System.Drawing.Size(645, 49)
        Me.Panel1.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Transaksi Jurnal Kas"
        '
        'tid_transaksi
        '
        Me.tid_transaksi.Enabled = False
        Me.tid_transaksi.Location = New System.Drawing.Point(208, 56)
        Me.tid_transaksi.Name = "tid_transaksi"
        Me.tid_transaksi.Size = New System.Drawing.Size(300, 22)
        Me.tid_transaksi.TabIndex = 10
        '
        'tkode_jenis_transaksi
        '
        Me.tkode_jenis_transaksi.Location = New System.Drawing.Point(208, 84)
        Me.tkode_jenis_transaksi.MaxLength = 2
        Me.tkode_jenis_transaksi.Name = "tkode_jenis_transaksi"
        Me.tkode_jenis_transaksi.Size = New System.Drawing.Size(50, 22)
        Me.tkode_jenis_transaksi.TabIndex = 11
        Me.tkode_jenis_transaksi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmb_jenis_transaksi
        '
        Me.cmb_jenis_transaksi.DropDownHeight = 100
        Me.cmb_jenis_transaksi.FormattingEnabled = True
        Me.cmb_jenis_transaksi.IntegralHeight = False
        Me.cmb_jenis_transaksi.Location = New System.Drawing.Point(264, 82)
        Me.cmb_jenis_transaksi.Name = "cmb_jenis_transaksi"
        Me.cmb_jenis_transaksi.Size = New System.Drawing.Size(244, 24)
        Me.cmb_jenis_transaksi.TabIndex = 12
        '
        'tno_kuitansi
        '
        Me.tno_kuitansi.Location = New System.Drawing.Point(208, 112)
        Me.tno_kuitansi.MaxLength = 20
        Me.tno_kuitansi.Name = "tno_kuitansi"
        Me.tno_kuitansi.Size = New System.Drawing.Size(150, 22)
        Me.tno_kuitansi.TabIndex = 13
        '
        'tsaldo_kas
        '
        Me.tsaldo_kas.Enabled = False
        Me.tsaldo_kas.Location = New System.Drawing.Point(208, 168)
        Me.tsaldo_kas.MaxLength = 15
        Me.tsaldo_kas.Name = "tsaldo_kas"
        Me.tsaldo_kas.Size = New System.Drawing.Size(150, 22)
        Me.tsaldo_kas.TabIndex = 15
        Me.tsaldo_kas.Text = "0"
        Me.tsaldo_kas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tjumlah
        '
        Me.tjumlah.Location = New System.Drawing.Point(208, 209)
        Me.tjumlah.MaxLength = 15
        Me.tjumlah.Name = "tjumlah"
        Me.tjumlah.Size = New System.Drawing.Size(150, 22)
        Me.tjumlah.TabIndex = 16
        Me.tjumlah.Text = "0"
        Me.tjumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tkode_perkiraan
        '
        Me.tkode_perkiraan.Location = New System.Drawing.Point(208, 237)
        Me.tkode_perkiraan.Name = "tkode_perkiraan"
        Me.tkode_perkiraan.Size = New System.Drawing.Size(150, 22)
        Me.tkode_perkiraan.TabIndex = 16
        '
        'tnama_perkiraan1
        '
        Me.tnama_perkiraan1.Enabled = False
        Me.tnama_perkiraan1.Location = New System.Drawing.Point(208, 265)
        Me.tnama_perkiraan1.Name = "tnama_perkiraan1"
        Me.tnama_perkiraan1.Size = New System.Drawing.Size(250, 22)
        Me.tnama_perkiraan1.TabIndex = 19
        '
        'tnama_perkiraan2
        '
        Me.tnama_perkiraan2.Enabled = False
        Me.tnama_perkiraan2.Location = New System.Drawing.Point(464, 265)
        Me.tnama_perkiraan2.MaxLength = 1
        Me.tnama_perkiraan2.Name = "tnama_perkiraan2"
        Me.tnama_perkiraan2.Size = New System.Drawing.Size(50, 22)
        Me.tnama_perkiraan2.TabIndex = 20
        Me.tnama_perkiraan2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tsaldo1
        '
        Me.tsaldo1.Enabled = False
        Me.tsaldo1.Location = New System.Drawing.Point(208, 293)
        Me.tsaldo1.Name = "tsaldo1"
        Me.tsaldo1.Size = New System.Drawing.Size(150, 22)
        Me.tsaldo1.TabIndex = 21
        Me.tsaldo1.Text = "0"
        Me.tsaldo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tsaldo2
        '
        Me.tsaldo2.Enabled = False
        Me.tsaldo2.Location = New System.Drawing.Point(364, 293)
        Me.tsaldo2.Name = "tsaldo2"
        Me.tsaldo2.Size = New System.Drawing.Size(150, 22)
        Me.tsaldo2.TabIndex = 22
        Me.tsaldo2.Text = "0"
        Me.tsaldo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tketerangan
        '
        Me.tketerangan.Location = New System.Drawing.Point(208, 321)
        Me.tketerangan.MaxLength = 60
        Me.tketerangan.Name = "tketerangan"
        Me.tketerangan.Size = New System.Drawing.Size(425, 22)
        Me.tketerangan.TabIndex = 23
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.btnkeluar)
        Me.GroupBox6.Controls.Add(Me.btnvalidasi)
        Me.GroupBox6.Controls.Add(Me.btntambah)
        Me.GroupBox6.Location = New System.Drawing.Point(520, 56)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(113, 202)
        Me.GroupBox6.TabIndex = 24
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
        Me.btnkeluar.TabIndex = 26
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
        Me.btnvalidasi.TabIndex = 24
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
        Me.btntambah.TabIndex = 25
        Me.btntambah.Text = "Tambah (F7)"
        Me.btntambah.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd-MM-yyyy   HH:mm:ss"
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(208, 140)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 22)
        Me.DateTimePicker1.TabIndex = 14
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightBlue
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.LKM.My.Resources.Resources.Search_16x16
        Me.Button1.Location = New System.Drawing.Point(364, 237)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'transaksi_jurnal_kas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(645, 354)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.tketerangan)
        Me.Controls.Add(Me.tsaldo2)
        Me.Controls.Add(Me.tsaldo1)
        Me.Controls.Add(Me.tnama_perkiraan2)
        Me.Controls.Add(Me.tnama_perkiraan1)
        Me.Controls.Add(Me.tkode_perkiraan)
        Me.Controls.Add(Me.tjumlah)
        Me.Controls.Add(Me.tsaldo_kas)
        Me.Controls.Add(Me.tno_kuitansi)
        Me.Controls.Add(Me.cmb_jenis_transaksi)
        Me.Controls.Add(Me.tkode_jenis_transaksi)
        Me.Controls.Add(Me.tid_transaksi)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "transaksi_jurnal_kas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tid_transaksi As System.Windows.Forms.TextBox
    Friend WithEvents tkode_jenis_transaksi As System.Windows.Forms.TextBox
    Friend WithEvents cmb_jenis_transaksi As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tno_kuitansi As System.Windows.Forms.TextBox
    Friend WithEvents tsaldo_kas As System.Windows.Forms.TextBox
    Friend WithEvents tjumlah As System.Windows.Forms.TextBox
    Friend WithEvents tkode_perkiraan As System.Windows.Forms.TextBox
    Friend WithEvents tnama_perkiraan1 As System.Windows.Forms.TextBox
    Friend WithEvents tnama_perkiraan2 As System.Windows.Forms.TextBox
    Friend WithEvents tsaldo1 As System.Windows.Forms.TextBox
    Friend WithEvents tsaldo2 As System.Windows.Forms.TextBox
    Friend WithEvents tketerangan As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnvalidasi As System.Windows.Forms.Button
    Friend WithEvents btntambah As System.Windows.Forms.Button
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
