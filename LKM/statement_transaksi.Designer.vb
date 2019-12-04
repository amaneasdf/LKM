<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class statement_transaksi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(statement_transaksi))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnmodel1 = New System.Windows.Forms.Button()
        Me.btnmodel2 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tno_rekening = New System.Windows.Forms.TextBox()
        Me.tnama_nasabah = New System.Windows.Forms.TextBox()
        Me.tskim_kredit = New System.Windows.Forms.TextBox()
        Me.tplafon = New System.Windows.Forms.TextBox()
        Me.tbaki_debet = New System.Windows.Forms.TextBox()
        Me.tkolek = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tsuku_bunga = New System.Windows.Forms.TextBox()
        Me.tsistem_bunga = New System.Windows.Forms.TextBox()
        Me.ttunggakan_pokok = New System.Windows.Forms.TextBox()
        Me.ttunggakan_bunga = New System.Windows.Forms.TextBox()
        Me.ttunggakan_pokok2 = New System.Windows.Forms.TextBox()
        Me.ttunggakan_bunga2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tjkw = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.LKM.My.Resources.Resources.header4
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.btnmodel1)
        Me.Panel1.Controls.Add(Me.btnmodel2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.btnkeluar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1022, 49)
        Me.Panel1.TabIndex = 5
        '
        'btnmodel1
        '
        Me.btnmodel1.BackColor = System.Drawing.Color.LightBlue
        Me.btnmodel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmodel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnmodel1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnmodel1.FlatAppearance.BorderSize = 2
        Me.btnmodel1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnmodel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmodel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnmodel1.Location = New System.Drawing.Point(676, 0)
        Me.btnmodel1.Margin = New System.Windows.Forms.Padding(4)
        Me.btnmodel1.Name = "btnmodel1"
        Me.btnmodel1.Size = New System.Drawing.Size(123, 49)
        Me.btnmodel1.TabIndex = 12
        Me.btnmodel1.Text = "Cetak Statement Model 1"
        Me.btnmodel1.UseVisualStyleBackColor = False
        '
        'btnmodel2
        '
        Me.btnmodel2.BackColor = System.Drawing.Color.LightBlue
        Me.btnmodel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmodel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnmodel2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnmodel2.FlatAppearance.BorderSize = 2
        Me.btnmodel2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnmodel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmodel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnmodel2.Location = New System.Drawing.Point(799, 0)
        Me.btnmodel2.Margin = New System.Windows.Forms.Padding(4)
        Me.btnmodel2.Name = "btnmodel2"
        Me.btnmodel2.Size = New System.Drawing.Size(123, 49)
        Me.btnmodel2.TabIndex = 11
        Me.btnmodel2.Text = "Cetak Statement Model 2"
        Me.btnmodel2.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 25)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(296, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Riwayat Transaksi Kredit Pihak Ketiga Non Bank"
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
        Me.btnkeluar.Location = New System.Drawing.Point(922, 0)
        Me.btnkeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(100, 49)
        Me.btnkeluar.TabIndex = 8
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
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(398, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Statement Transaksi Kredit Pihak Ketiga"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(0, 49)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(125, 154)
        Me.Panel2.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(74, 123)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Kolek :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Baki Debet :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(70, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Plafon :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Skim Kredit :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "No Rek /  Nama :"
        '
        'tno_rekening
        '
        Me.tno_rekening.Enabled = False
        Me.tno_rekening.Location = New System.Drawing.Point(128, 57)
        Me.tno_rekening.Name = "tno_rekening"
        Me.tno_rekening.Size = New System.Drawing.Size(150, 22)
        Me.tno_rekening.TabIndex = 5
        '
        'tnama_nasabah
        '
        Me.tnama_nasabah.Enabled = False
        Me.tnama_nasabah.Location = New System.Drawing.Point(284, 57)
        Me.tnama_nasabah.Name = "tnama_nasabah"
        Me.tnama_nasabah.Size = New System.Drawing.Size(200, 22)
        Me.tnama_nasabah.TabIndex = 9
        '
        'tskim_kredit
        '
        Me.tskim_kredit.Enabled = False
        Me.tskim_kredit.Location = New System.Drawing.Point(128, 85)
        Me.tskim_kredit.Name = "tskim_kredit"
        Me.tskim_kredit.Size = New System.Drawing.Size(200, 22)
        Me.tskim_kredit.TabIndex = 10
        '
        'tplafon
        '
        Me.tplafon.Enabled = False
        Me.tplafon.Location = New System.Drawing.Point(128, 113)
        Me.tplafon.Name = "tplafon"
        Me.tplafon.Size = New System.Drawing.Size(150, 22)
        Me.tplafon.TabIndex = 11
        Me.tplafon.Text = "0"
        Me.tplafon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbaki_debet
        '
        Me.tbaki_debet.Enabled = False
        Me.tbaki_debet.Location = New System.Drawing.Point(128, 141)
        Me.tbaki_debet.Name = "tbaki_debet"
        Me.tbaki_debet.Size = New System.Drawing.Size(150, 22)
        Me.tbaki_debet.TabIndex = 12
        Me.tbaki_debet.Text = "0"
        Me.tbaki_debet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tkolek
        '
        Me.tkolek.Enabled = False
        Me.tkolek.Location = New System.Drawing.Point(128, 169)
        Me.tkolek.Name = "tkolek"
        Me.tkolek.Size = New System.Drawing.Size(150, 22)
        Me.tkolek.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(406, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "SB / Sistem Bg :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(384, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 16)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Tunggakan Pokok :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(384, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 16)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Tunggakan Bunga :"
        '
        'tsuku_bunga
        '
        Me.tsuku_bunga.Enabled = False
        Me.tsuku_bunga.Location = New System.Drawing.Point(515, 85)
        Me.tsuku_bunga.Name = "tsuku_bunga"
        Me.tsuku_bunga.Size = New System.Drawing.Size(50, 22)
        Me.tsuku_bunga.TabIndex = 18
        Me.tsuku_bunga.Text = "0,000"
        Me.tsuku_bunga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tsistem_bunga
        '
        Me.tsistem_bunga.Enabled = False
        Me.tsistem_bunga.Location = New System.Drawing.Point(592, 85)
        Me.tsistem_bunga.Name = "tsistem_bunga"
        Me.tsistem_bunga.Size = New System.Drawing.Size(150, 22)
        Me.tsistem_bunga.TabIndex = 19
        '
        'ttunggakan_pokok
        '
        Me.ttunggakan_pokok.Enabled = False
        Me.ttunggakan_pokok.Location = New System.Drawing.Point(515, 116)
        Me.ttunggakan_pokok.Name = "ttunggakan_pokok"
        Me.ttunggakan_pokok.Size = New System.Drawing.Size(150, 22)
        Me.ttunggakan_pokok.TabIndex = 20
        Me.ttunggakan_pokok.Text = "0"
        Me.ttunggakan_pokok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ttunggakan_bunga
        '
        Me.ttunggakan_bunga.Enabled = False
        Me.ttunggakan_bunga.Location = New System.Drawing.Point(515, 144)
        Me.ttunggakan_bunga.Name = "ttunggakan_bunga"
        Me.ttunggakan_bunga.Size = New System.Drawing.Size(150, 22)
        Me.ttunggakan_bunga.TabIndex = 21
        Me.ttunggakan_bunga.Text = "0"
        Me.ttunggakan_bunga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ttunggakan_pokok2
        '
        Me.ttunggakan_pokok2.BackColor = System.Drawing.SystemColors.Window
        Me.ttunggakan_pokok2.Enabled = False
        Me.ttunggakan_pokok2.Location = New System.Drawing.Point(671, 116)
        Me.ttunggakan_pokok2.Name = "ttunggakan_pokok2"
        Me.ttunggakan_pokok2.Size = New System.Drawing.Size(50, 22)
        Me.ttunggakan_pokok2.TabIndex = 23
        Me.ttunggakan_pokok2.Text = "0,00"
        Me.ttunggakan_pokok2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ttunggakan_bunga2
        '
        Me.ttunggakan_bunga2.BackColor = System.Drawing.SystemColors.Window
        Me.ttunggakan_bunga2.Enabled = False
        Me.ttunggakan_bunga2.Location = New System.Drawing.Point(671, 144)
        Me.ttunggakan_bunga2.Name = "ttunggakan_bunga2"
        Me.ttunggakan_bunga2.Size = New System.Drawing.Size(50, 22)
        Me.ttunggakan_bunga2.TabIndex = 24
        Me.ttunggakan_bunga2.Text = "0,00"
        Me.ttunggakan_bunga2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(566, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 16)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "%"
        '
        'tjkw
        '
        Me.tjkw.Enabled = False
        Me.tjkw.Location = New System.Drawing.Point(910, 113)
        Me.tjkw.Name = "tjkw"
        Me.tjkw.Size = New System.Drawing.Size(50, 22)
        Me.tjkw.TabIndex = 30
        Me.tjkw.Text = "0"
        Me.tjkw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(757, 141)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(147, 16)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Tanggal Jatuh Tempo :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(804, 116)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 16)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Jangka Waktu :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(804, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 16)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Tanggal Mulai :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(966, 116)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 16)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "label16"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.GreenYellow
        Me.Panel3.Controls.Add(Me.Label25)
        Me.Panel3.Controls.Add(Me.Label23)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 511)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1022, 47)
        Me.Panel3.TabIndex = 33
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(494, 25)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(161, 16)
        Me.Label25.TabIndex = 45
        Me.Label25.Text = "109 : Pelunasan Dari COA"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(494, 3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(195, 16)
        Me.Label23.TabIndex = 43
        Me.Label23.Text = "107 : Pelunasan Dari Tabungan"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(228, 25)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(139, 16)
        Me.Label22.TabIndex = 42
        Me.Label22.Text = "106 : Pelunasan Tunai"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(228, 3)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(243, 16)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "104 : Angsuran OB Dari ABA / Akuntansi"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(12, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(210, 16)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "102 : Angsuran OB Dari Tabungan"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(12, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(132, 16)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "101 : Angsuran Tunai"
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 222)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1022, 289)
        Me.ListView1.TabIndex = 34
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd-MM-yyyy"
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(910, 85)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(100, 22)
        Me.DateTimePicker1.TabIndex = 35
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd-MM-yyyy"
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(910, 141)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(100, 22)
        Me.DateTimePicker2.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(451, 187)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Label11"
        Me.Label11.Visible = False
        '
        'statement_transaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 558)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.tjkw)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ttunggakan_bunga2)
        Me.Controls.Add(Me.ttunggakan_pokok2)
        Me.Controls.Add(Me.ttunggakan_bunga)
        Me.Controls.Add(Me.ttunggakan_pokok)
        Me.Controls.Add(Me.tsistem_bunga)
        Me.Controls.Add(Me.tsuku_bunga)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tkolek)
        Me.Controls.Add(Me.tbaki_debet)
        Me.Controls.Add(Me.tplafon)
        Me.Controls.Add(Me.tskim_kredit)
        Me.Controls.Add(Me.tnama_nasabah)
        Me.Controls.Add(Me.tno_rekening)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "statement_transaksi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tno_rekening As System.Windows.Forms.TextBox
    Friend WithEvents tnama_nasabah As System.Windows.Forms.TextBox
    Friend WithEvents tskim_kredit As System.Windows.Forms.TextBox
    Friend WithEvents tplafon As System.Windows.Forms.TextBox
    Friend WithEvents tbaki_debet As System.Windows.Forms.TextBox
    Friend WithEvents tkolek As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tsuku_bunga As System.Windows.Forms.TextBox
    Friend WithEvents tsistem_bunga As System.Windows.Forms.TextBox
    Friend WithEvents ttunggakan_pokok As System.Windows.Forms.TextBox
    Friend WithEvents ttunggakan_bunga As System.Windows.Forms.TextBox
    Friend WithEvents ttunggakan_pokok2 As System.Windows.Forms.TextBox
    Friend WithEvents ttunggakan_bunga2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tjkw As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnmodel1 As System.Windows.Forms.Button
    Friend WithEvents btnmodel2 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
