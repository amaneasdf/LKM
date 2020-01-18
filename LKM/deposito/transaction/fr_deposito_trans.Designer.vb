<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_deposito_trans
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
        Me.pnl_top = New System.Windows.Forms.Panel()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_rek1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_bilyet = New System.Windows.Forms.TextBox()
        Me.in_nasabah_alamat = New System.Windows.Forms.TextBox()
        Me.bt_search_deposito = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.in_nasabah_nama = New System.Windows.Forms.TextBox()
        Me.in_nasabah_nik = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.in_pemilik_kode = New System.Windows.Forms.TextBox()
        Me.cb_trans = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.date_tgl_trans = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.bt_save = New System.Windows.Forms.Button()
        Me.bt_new = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.in_cif = New System.Windows.Forms.TextBox()
        Me.in_nominal2 = New System.Windows.Forms.TextBox()
        Me.in_nominal1 = New System.Windows.Forms.TextBox()
        Me.in_nominal_akhir = New System.Windows.Forms.TextBox()
        Me.in_nominal = New System.Windows.Forms.TextBox()
        Me.in_bunga = New System.Windows.Forms.TextBox()
        Me.in_pokok = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.in_rektujuan = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.in_kuitansi = New System.Windows.Forms.TextBox()
        Me.in_valuta = New System.Windows.Forms.TextBox()
        Me.lbl_nominal2 = New System.Windows.Forms.Label()
        Me.lbl_nominal1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbl_re = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bt_cari_tabungan = New System.Windows.Forms.Button()
        Me.pnl_top.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_top
        '
        Me.pnl_top.BackColor = System.Drawing.Color.Azure
        Me.pnl_top.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnl_top.Controls.Add(Me.lbl_judul)
        Me.pnl_top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_top.Location = New System.Drawing.Point(0, 0)
        Me.pnl_top.Margin = New System.Windows.Forms.Padding(4)
        Me.pnl_top.Name = "pnl_top"
        Me.pnl_top.Size = New System.Drawing.Size(799, 49)
        Me.pnl_top.TabIndex = 37
        '
        'lbl_judul
        '
        Me.lbl_judul.AutoSize = True
        Me.lbl_judul.BackColor = System.Drawing.Color.Transparent
        Me.lbl_judul.Font = New System.Drawing.Font("Open Sans", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.ForeColor = System.Drawing.Color.Black
        Me.lbl_judul.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_judul.Location = New System.Drawing.Point(4, 11)
        Me.lbl_judul.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(301, 26)
        Me.lbl_judul.TabIndex = 1
        Me.lbl_judul.Text = "Transaksi Simpanan Berjangka"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Azure
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 501)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(799, 6)
        Me.Panel2.TabIndex = 38
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 15)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "No Rekening"
        '
        'in_rek1
        '
        Me.in_rek1.Enabled = False
        Me.in_rek1.Location = New System.Drawing.Point(129, 14)
        Me.in_rek1.Name = "in_rek1"
        Me.in_rek1.ReadOnly = True
        Me.in_rek1.Size = New System.Drawing.Size(183, 22)
        Me.in_rek1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "No. Bilyet"
        '
        'in_bilyet
        '
        Me.in_bilyet.Location = New System.Drawing.Point(129, 40)
        Me.in_bilyet.Name = "in_bilyet"
        Me.in_bilyet.ReadOnly = True
        Me.in_bilyet.Size = New System.Drawing.Size(183, 22)
        Me.in_bilyet.TabIndex = 2
        '
        'in_nasabah_alamat
        '
        Me.in_nasabah_alamat.Location = New System.Drawing.Point(129, 118)
        Me.in_nasabah_alamat.Name = "in_nasabah_alamat"
        Me.in_nasabah_alamat.ReadOnly = True
        Me.in_nasabah_alamat.Size = New System.Drawing.Size(509, 22)
        Me.in_nasabah_alamat.TabIndex = 6
        '
        'bt_search_deposito
        '
        Me.bt_search_deposito.BackColor = System.Drawing.Color.LightBlue
        Me.bt_search_deposito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_search_deposito.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.bt_search_deposito.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.bt_search_deposito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_search_deposito.Image = Global.LKM.My.Resources.Resources.Search_16x16
        Me.bt_search_deposito.Location = New System.Drawing.Point(318, 14)
        Me.bt_search_deposito.Name = "bt_search_deposito"
        Me.bt_search_deposito.Size = New System.Drawing.Size(27, 22)
        Me.bt_search_deposito.TabIndex = 1
        Me.bt_search_deposito.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 15)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Alamat :"
        '
        'in_nasabah_nama
        '
        Me.in_nasabah_nama.Location = New System.Drawing.Point(129, 92)
        Me.in_nasabah_nama.Name = "in_nasabah_nama"
        Me.in_nasabah_nama.ReadOnly = True
        Me.in_nasabah_nama.Size = New System.Drawing.Size(306, 22)
        Me.in_nasabah_nama.TabIndex = 4
        '
        'in_nasabah_nik
        '
        Me.in_nasabah_nik.Location = New System.Drawing.Point(441, 92)
        Me.in_nasabah_nik.Name = "in_nasabah_nik"
        Me.in_nasabah_nik.ReadOnly = True
        Me.in_nasabah_nik.Size = New System.Drawing.Size(197, 22)
        Me.in_nasabah_nik.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 15)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Nama Nasabah :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 178)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 15)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Kode Transaksi"
        '
        'in_pemilik_kode
        '
        Me.in_pemilik_kode.BackColor = System.Drawing.Color.Gainsboro
        Me.in_pemilik_kode.Font = New System.Drawing.Font("Open Sans", 8.275!)
        Me.in_pemilik_kode.Location = New System.Drawing.Point(129, 174)
        Me.in_pemilik_kode.MaxLength = 4
        Me.in_pemilik_kode.Name = "in_pemilik_kode"
        Me.in_pemilik_kode.ReadOnly = True
        Me.in_pemilik_kode.Size = New System.Drawing.Size(50, 23)
        Me.in_pemilik_kode.TabIndex = 9
        Me.in_pemilik_kode.TabStop = False
        Me.in_pemilik_kode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cb_trans
        '
        Me.cb_trans.DropDownHeight = 100
        Me.cb_trans.FormattingEnabled = True
        Me.cb_trans.IntegralHeight = False
        Me.cb_trans.Location = New System.Drawing.Point(182, 174)
        Me.cb_trans.Name = "cb_trans"
        Me.cb_trans.Size = New System.Drawing.Size(292, 23)
        Me.cb_trans.TabIndex = 10
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(961, 535)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(183, 22)
        Me.TextBox1.TabIndex = 79
        '
        'pnl_content
        '
        Me.pnl_content.BackColor = System.Drawing.Color.White
        Me.pnl_content.Controls.Add(Me.date_tgl_trans)
        Me.pnl_content.Controls.Add(Me.GroupBox6)
        Me.pnl_content.Controls.Add(Me.TextBox1)
        Me.pnl_content.Controls.Add(Me.cb_trans)
        Me.pnl_content.Controls.Add(Me.in_pemilik_kode)
        Me.pnl_content.Controls.Add(Me.Label10)
        Me.pnl_content.Controls.Add(Me.Label11)
        Me.pnl_content.Controls.Add(Me.Label9)
        Me.pnl_content.Controls.Add(Me.Label7)
        Me.pnl_content.Controls.Add(Me.in_cif)
        Me.pnl_content.Controls.Add(Me.in_nasabah_nik)
        Me.pnl_content.Controls.Add(Me.in_nasabah_nama)
        Me.pnl_content.Controls.Add(Me.Label8)
        Me.pnl_content.Controls.Add(Me.bt_cari_tabungan)
        Me.pnl_content.Controls.Add(Me.bt_search_deposito)
        Me.pnl_content.Controls.Add(Me.in_nasabah_alamat)
        Me.pnl_content.Controls.Add(Me.in_nominal2)
        Me.pnl_content.Controls.Add(Me.in_nominal1)
        Me.pnl_content.Controls.Add(Me.in_nominal_akhir)
        Me.pnl_content.Controls.Add(Me.in_nominal)
        Me.pnl_content.Controls.Add(Me.in_bunga)
        Me.pnl_content.Controls.Add(Me.in_pokok)
        Me.pnl_content.Controls.Add(Me.TextBox2)
        Me.pnl_content.Controls.Add(Me.in_rektujuan)
        Me.pnl_content.Controls.Add(Me.TextBox3)
        Me.pnl_content.Controls.Add(Me.in_kuitansi)
        Me.pnl_content.Controls.Add(Me.in_valuta)
        Me.pnl_content.Controls.Add(Me.in_bilyet)
        Me.pnl_content.Controls.Add(Me.lbl_nominal2)
        Me.pnl_content.Controls.Add(Me.lbl_nominal1)
        Me.pnl_content.Controls.Add(Me.Label15)
        Me.pnl_content.Controls.Add(Me.Label6)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.Label12)
        Me.pnl_content.Controls.Add(Me.lbl_re)
        Me.pnl_content.Controls.Add(Me.Label13)
        Me.pnl_content.Controls.Add(Me.Label14)
        Me.pnl_content.Controls.Add(Me.Label2)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.in_rek1)
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 49)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(799, 452)
        Me.pnl_content.TabIndex = 39
        '
        'date_tgl_trans
        '
        Me.date_tgl_trans.Enabled = False
        Me.date_tgl_trans.Location = New System.Drawing.Point(451, 147)
        Me.date_tgl_trans.Name = "date_tgl_trans"
        Me.date_tgl_trans.Size = New System.Drawing.Size(187, 22)
        Me.date_tgl_trans.TabIndex = 8
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.bt_cl)
        Me.GroupBox6.Controls.Add(Me.bt_save)
        Me.GroupBox6.Controls.Add(Me.bt_new)
        Me.GroupBox6.Location = New System.Drawing.Point(674, 7)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(113, 184)
        Me.GroupBox6.TabIndex = 80
        Me.GroupBox6.TabStop = False
        '
        'bt_cl
        '
        Me.bt_cl.BackColor = System.Drawing.Color.LightBlue
        Me.bt_cl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_cl.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.bt_cl.FlatAppearance.BorderSize = 2
        Me.bt_cl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.bt_cl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cl.Location = New System.Drawing.Point(6, 123)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(100, 45)
        Me.bt_cl.TabIndex = 38
        Me.bt_cl.Text = "Keluar (Esc)"
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'bt_save
        '
        Me.bt_save.BackColor = System.Drawing.Color.LightBlue
        Me.bt_save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_save.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.bt_save.FlatAppearance.BorderSize = 2
        Me.bt_save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.bt_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_save.Location = New System.Drawing.Point(6, 21)
        Me.bt_save.Name = "bt_save"
        Me.bt_save.Size = New System.Drawing.Size(100, 45)
        Me.bt_save.TabIndex = 36
        Me.bt_save.Text = "Validasi (F5)"
        Me.bt_save.UseVisualStyleBackColor = False
        '
        'bt_new
        '
        Me.bt_new.BackColor = System.Drawing.Color.LightBlue
        Me.bt_new.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_new.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.bt_new.FlatAppearance.BorderSize = 2
        Me.bt_new.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.bt_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_new.Location = New System.Drawing.Point(6, 72)
        Me.bt_new.Name = "bt_new"
        Me.bt_new.Size = New System.Drawing.Size(100, 45)
        Me.bt_new.TabIndex = 37
        Me.bt_new.Text = "Tambah (F7)"
        Me.bt_new.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(369, 151)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 15)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Tgl. Transaksi"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 15)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "ID Nasabah :"
        '
        'in_cif
        '
        Me.in_cif.Location = New System.Drawing.Point(129, 66)
        Me.in_cif.Name = "in_cif"
        Me.in_cif.ReadOnly = True
        Me.in_cif.Size = New System.Drawing.Size(306, 22)
        Me.in_cif.TabIndex = 3
        '
        'in_nominal2
        '
        Me.in_nominal2.Font = New System.Drawing.Font("Open Sans", 9.25!, System.Drawing.FontStyle.Bold)
        Me.in_nominal2.Location = New System.Drawing.Point(492, 372)
        Me.in_nominal2.Name = "in_nominal2"
        Me.in_nominal2.Size = New System.Drawing.Size(216, 24)
        Me.in_nominal2.TabIndex = 19
        Me.in_nominal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_nominal2.Visible = False
        '
        'in_nominal1
        '
        Me.in_nominal1.Font = New System.Drawing.Font("Open Sans", 9.25!, System.Drawing.FontStyle.Bold)
        Me.in_nominal1.Location = New System.Drawing.Point(492, 344)
        Me.in_nominal1.Name = "in_nominal1"
        Me.in_nominal1.Size = New System.Drawing.Size(216, 24)
        Me.in_nominal1.TabIndex = 18
        Me.in_nominal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_nominal1.Visible = False
        '
        'in_nominal_akhir
        '
        Me.in_nominal_akhir.Font = New System.Drawing.Font("Open Sans", 9.25!, System.Drawing.FontStyle.Bold)
        Me.in_nominal_akhir.Location = New System.Drawing.Point(129, 404)
        Me.in_nominal_akhir.Name = "in_nominal_akhir"
        Me.in_nominal_akhir.ReadOnly = True
        Me.in_nominal_akhir.Size = New System.Drawing.Size(216, 24)
        Me.in_nominal_akhir.TabIndex = 20
        Me.in_nominal_akhir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_nominal
        '
        Me.in_nominal.Font = New System.Drawing.Font("Open Sans", 9.25!, System.Drawing.FontStyle.Bold)
        Me.in_nominal.Location = New System.Drawing.Point(129, 344)
        Me.in_nominal.Name = "in_nominal"
        Me.in_nominal.Size = New System.Drawing.Size(216, 24)
        Me.in_nominal.TabIndex = 17
        Me.in_nominal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_bunga
        '
        Me.in_bunga.Location = New System.Drawing.Point(441, 279)
        Me.in_bunga.Name = "in_bunga"
        Me.in_bunga.ReadOnly = True
        Me.in_bunga.Size = New System.Drawing.Size(197, 22)
        Me.in_bunga.TabIndex = 15
        '
        'in_pokok
        '
        Me.in_pokok.Location = New System.Drawing.Point(441, 251)
        Me.in_pokok.Name = "in_pokok"
        Me.in_pokok.ReadOnly = True
        Me.in_pokok.Size = New System.Drawing.Size(197, 22)
        Me.in_pokok.TabIndex = 14
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(129, 147)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(216, 22)
        Me.TextBox2.TabIndex = 7
        '
        'in_rektujuan
        '
        Me.in_rektujuan.Location = New System.Drawing.Point(129, 312)
        Me.in_rektujuan.Name = "in_rektujuan"
        Me.in_rektujuan.ReadOnly = True
        Me.in_rektujuan.Size = New System.Drawing.Size(216, 22)
        Me.in_rektujuan.TabIndex = 16
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(129, 225)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(216, 22)
        Me.TextBox3.TabIndex = 12
        '
        'in_kuitansi
        '
        Me.in_kuitansi.Location = New System.Drawing.Point(129, 200)
        Me.in_kuitansi.Name = "in_kuitansi"
        Me.in_kuitansi.Size = New System.Drawing.Size(216, 22)
        Me.in_kuitansi.TabIndex = 11
        '
        'in_valuta
        '
        Me.in_valuta.Location = New System.Drawing.Point(129, 251)
        Me.in_valuta.Name = "in_valuta"
        Me.in_valuta.ReadOnly = True
        Me.in_valuta.Size = New System.Drawing.Size(216, 22)
        Me.in_valuta.TabIndex = 13
        '
        'lbl_nominal2
        '
        Me.lbl_nominal2.AutoSize = True
        Me.lbl_nominal2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nominal2.Location = New System.Drawing.Point(369, 376)
        Me.lbl_nominal2.Name = "lbl_nominal2"
        Me.lbl_nominal2.Size = New System.Drawing.Size(105, 15)
        Me.lbl_nominal2.TabIndex = 60
        Me.lbl_nominal2.Text = "Nilai Bunga Trans."
        Me.lbl_nominal2.Visible = False
        '
        'lbl_nominal1
        '
        Me.lbl_nominal1.AutoSize = True
        Me.lbl_nominal1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nominal1.Location = New System.Drawing.Point(369, 348)
        Me.lbl_nominal1.Name = "lbl_nominal1"
        Me.lbl_nominal1.Size = New System.Drawing.Size(92, 15)
        Me.lbl_nominal1.TabIndex = 60
        Me.lbl_nominal1.Text = "Nominal Pinalti"
        Me.lbl_nominal1.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 408)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 15)
        Me.Label15.TabIndex = 60
        Me.Label15.Text = "Nominal Akhir"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 348)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 15)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Nominal Transaksi"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(369, 282)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 15)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Nilai Bunga"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(369, 254)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 15)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Nilai Pokok"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 151)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 15)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "ID Transaksi"
        '
        'lbl_re
        '
        Me.lbl_re.AutoSize = True
        Me.lbl_re.Location = New System.Drawing.Point(6, 315)
        Me.lbl_re.Name = "lbl_re"
        Me.lbl_re.Size = New System.Drawing.Size(94, 15)
        Me.lbl_re.TabIndex = 60
        Me.lbl_re.Text = "Rekening Tujuan"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 228)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 15)
        Me.Label13.TabIndex = 60
        Me.Label13.Text = "Nilai awal Simpanan"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 203)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 15)
        Me.Label14.TabIndex = 60
        Me.Label14.Text = "No. Kuitansi"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 15)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Valuta Simpanan"
        '
        'bt_cari_tabungan
        '
        Me.bt_cari_tabungan.BackColor = System.Drawing.Color.LightBlue
        Me.bt_cari_tabungan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_cari_tabungan.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.bt_cari_tabungan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.bt_cari_tabungan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cari_tabungan.Image = Global.LKM.My.Resources.Resources.Search_16x16
        Me.bt_cari_tabungan.Location = New System.Drawing.Point(351, 312)
        Me.bt_cari_tabungan.Name = "bt_cari_tabungan"
        Me.bt_cari_tabungan.Size = New System.Drawing.Size(27, 22)
        Me.bt_cari_tabungan.TabIndex = 1
        Me.bt_cari_tabungan.UseVisualStyleBackColor = False
        '
        'fr_deposito_trans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 507)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnl_top)
        Me.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fr_deposito_trans"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaksi Simpanan Berjangka"
        Me.pnl_top.ResumeLayout(False)
        Me.pnl_top.PerformLayout()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_top As System.Windows.Forms.Panel
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_rek1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_bilyet As System.Windows.Forms.TextBox
    Friend WithEvents in_nasabah_alamat As System.Windows.Forms.TextBox
    Friend WithEvents bt_search_deposito As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents in_nasabah_nama As System.Windows.Forms.TextBox
    Friend WithEvents in_nasabah_nik As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents in_pemilik_kode As System.Windows.Forms.TextBox
    Friend WithEvents cb_trans As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents in_bunga As System.Windows.Forms.TextBox
    Friend WithEvents in_pokok As System.Windows.Forms.TextBox
    Friend WithEvents in_valuta As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents bt_save As System.Windows.Forms.Button
    Friend WithEvents bt_new As System.Windows.Forms.Button
    Friend WithEvents in_nominal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents in_cif As System.Windows.Forms.TextBox
    Friend WithEvents date_tgl_trans As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents in_kuitansi As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents in_nominal2 As System.Windows.Forms.TextBox
    Friend WithEvents in_nominal1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_nominal2 As System.Windows.Forms.Label
    Friend WithEvents lbl_nominal1 As System.Windows.Forms.Label
    Friend WithEvents in_nominal_akhir As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents in_rektujuan As System.Windows.Forms.TextBox
    Friend WithEvents lbl_re As System.Windows.Forms.Label
    Friend WithEvents bt_cari_tabungan As System.Windows.Forms.Button
End Class
