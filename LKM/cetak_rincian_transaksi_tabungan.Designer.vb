<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cetak_rincian_transaksi_tabungan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cetak_rincian_transaksi_tabungan))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.cmbjenis_transaksi = New System.Windows.Forms.ComboBox()
        Me.tkode_jenis_produk = New System.Windows.Forms.TextBox()
        Me.cmbjenis_produk = New System.Windows.Forms.ComboBox()
        Me.tkode_kolektor1 = New System.Windows.Forms.TextBox()
        Me.cmbkolektor1 = New System.Windows.Forms.ComboBox()
        Me.cmbinstansi = New System.Windows.Forms.ComboBox()
        Me.tkode_instansi = New System.Windows.Forms.TextBox()
        Me.cmbwilayah = New System.Windows.Forms.ComboBox()
        Me.tkode_wilayah = New System.Windows.Forms.TextBox()
        Me.cmburutkan = New System.Windows.Forms.ComboBox()
        Me.btnbatal = New System.Windows.Forms.Button()
        Me.btnok = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.cmbmarketing = New System.Windows.Forms.ComboBox()
        Me.tkode_marketing = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 49)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 299)
        Me.Panel2.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(124, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Marketing :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(105, 217)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 16)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Urutkan Data :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(134, 187)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Wilayah :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(138, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Instansi :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(134, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Kolektor :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(105, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Jenis Produk :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(88, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Jenis Transaksi :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(99, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tanggal Buku :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.LKM.My.Resources.Resources.header4
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 49)
        Me.Panel1.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(349, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cetak Rincian Transaksi Tabungan"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(208, 57)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(150, 22)
        Me.DateTimePicker1.TabIndex = 17
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(364, 62)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(23, 16)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "sd"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(393, 58)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(150, 22)
        Me.DateTimePicker2.TabIndex = 23
        '
        'cmbjenis_transaksi
        '
        Me.cmbjenis_transaksi.DropDownHeight = 100
        Me.cmbjenis_transaksi.FormattingEnabled = True
        Me.cmbjenis_transaksi.IntegralHeight = False
        Me.cmbjenis_transaksi.Location = New System.Drawing.Point(208, 85)
        Me.cmbjenis_transaksi.Name = "cmbjenis_transaksi"
        Me.cmbjenis_transaksi.Size = New System.Drawing.Size(335, 24)
        Me.cmbjenis_transaksi.TabIndex = 24
        '
        'tkode_jenis_produk
        '
        Me.tkode_jenis_produk.Location = New System.Drawing.Point(208, 118)
        Me.tkode_jenis_produk.MaxLength = 4
        Me.tkode_jenis_produk.Name = "tkode_jenis_produk"
        Me.tkode_jenis_produk.Size = New System.Drawing.Size(50, 22)
        Me.tkode_jenis_produk.TabIndex = 25
        Me.tkode_jenis_produk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbjenis_produk
        '
        Me.cmbjenis_produk.DropDownHeight = 100
        Me.cmbjenis_produk.FormattingEnabled = True
        Me.cmbjenis_produk.IntegralHeight = False
        Me.cmbjenis_produk.Location = New System.Drawing.Point(264, 115)
        Me.cmbjenis_produk.Name = "cmbjenis_produk"
        Me.cmbjenis_produk.Size = New System.Drawing.Size(279, 24)
        Me.cmbjenis_produk.TabIndex = 26
        '
        'tkode_kolektor1
        '
        Me.tkode_kolektor1.Location = New System.Drawing.Point(208, 147)
        Me.tkode_kolektor1.MaxLength = 4
        Me.tkode_kolektor1.Name = "tkode_kolektor1"
        Me.tkode_kolektor1.Size = New System.Drawing.Size(50, 22)
        Me.tkode_kolektor1.TabIndex = 27
        Me.tkode_kolektor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbkolektor1
        '
        Me.cmbkolektor1.DropDownHeight = 100
        Me.cmbkolektor1.FormattingEnabled = True
        Me.cmbkolektor1.IntegralHeight = False
        Me.cmbkolektor1.Location = New System.Drawing.Point(264, 145)
        Me.cmbkolektor1.Name = "cmbkolektor1"
        Me.cmbkolektor1.Size = New System.Drawing.Size(279, 24)
        Me.cmbkolektor1.TabIndex = 28
        '
        'cmbinstansi
        '
        Me.cmbinstansi.DropDownHeight = 100
        Me.cmbinstansi.FormattingEnabled = True
        Me.cmbinstansi.IntegralHeight = False
        Me.cmbinstansi.Location = New System.Drawing.Point(264, 205)
        Me.cmbinstansi.Name = "cmbinstansi"
        Me.cmbinstansi.Size = New System.Drawing.Size(279, 24)
        Me.cmbinstansi.TabIndex = 32
        '
        'tkode_instansi
        '
        Me.tkode_instansi.Location = New System.Drawing.Point(208, 207)
        Me.tkode_instansi.MaxLength = 4
        Me.tkode_instansi.Name = "tkode_instansi"
        Me.tkode_instansi.Size = New System.Drawing.Size(50, 22)
        Me.tkode_instansi.TabIndex = 31
        Me.tkode_instansi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbwilayah
        '
        Me.cmbwilayah.DropDownHeight = 100
        Me.cmbwilayah.FormattingEnabled = True
        Me.cmbwilayah.IntegralHeight = False
        Me.cmbwilayah.Location = New System.Drawing.Point(264, 235)
        Me.cmbwilayah.Name = "cmbwilayah"
        Me.cmbwilayah.Size = New System.Drawing.Size(279, 24)
        Me.cmbwilayah.TabIndex = 34
        '
        'tkode_wilayah
        '
        Me.tkode_wilayah.Location = New System.Drawing.Point(208, 237)
        Me.tkode_wilayah.MaxLength = 4
        Me.tkode_wilayah.Name = "tkode_wilayah"
        Me.tkode_wilayah.Size = New System.Drawing.Size(50, 22)
        Me.tkode_wilayah.TabIndex = 33
        Me.tkode_wilayah.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmburutkan
        '
        Me.cmburutkan.DropDownHeight = 100
        Me.cmburutkan.FormattingEnabled = True
        Me.cmburutkan.IntegralHeight = False
        Me.cmburutkan.Location = New System.Drawing.Point(208, 265)
        Me.cmburutkan.Name = "cmburutkan"
        Me.cmburutkan.Size = New System.Drawing.Size(335, 24)
        Me.cmburutkan.TabIndex = 35
        '
        'btnbatal
        '
        Me.btnbatal.BackColor = System.Drawing.Color.LightBlue
        Me.btnbatal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnbatal.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnbatal.FlatAppearance.BorderSize = 2
        Me.btnbatal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnbatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbatal.Location = New System.Drawing.Point(443, 295)
        Me.btnbatal.Name = "btnbatal"
        Me.btnbatal.Size = New System.Drawing.Size(100, 45)
        Me.btnbatal.TabIndex = 78
        Me.btnbatal.Text = "Batal"
        Me.btnbatal.UseVisualStyleBackColor = False
        '
        'btnok
        '
        Me.btnok.BackColor = System.Drawing.Color.LightBlue
        Me.btnok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnok.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnok.FlatAppearance.BorderSize = 2
        Me.btnok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnok.Location = New System.Drawing.Point(337, 295)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(100, 45)
        Me.btnok.TabIndex = 77
        Me.btnok.Text = "OK"
        Me.btnok.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(568, 58)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(456, 141)
        Me.TextBox1.TabIndex = 79
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(568, 210)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(456, 111)
        Me.TextBox2.TabIndex = 80
        '
        'cmbmarketing
        '
        Me.cmbmarketing.DropDownHeight = 100
        Me.cmbmarketing.FormattingEnabled = True
        Me.cmbmarketing.IntegralHeight = False
        Me.cmbmarketing.Location = New System.Drawing.Point(264, 175)
        Me.cmbmarketing.Name = "cmbmarketing"
        Me.cmbmarketing.Size = New System.Drawing.Size(279, 24)
        Me.cmbmarketing.TabIndex = 30
        '
        'tkode_marketing
        '
        Me.tkode_marketing.Location = New System.Drawing.Point(208, 177)
        Me.tkode_marketing.MaxLength = 4
        Me.tkode_marketing.Name = "tkode_marketing"
        Me.tkode_marketing.Size = New System.Drawing.Size(50, 22)
        Me.tkode_marketing.TabIndex = 29
        Me.tkode_marketing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cetak_rincian_transaksi_tabungan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 348)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbmarketing)
        Me.Controls.Add(Me.tkode_marketing)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnbatal)
        Me.Controls.Add(Me.btnok)
        Me.Controls.Add(Me.cmburutkan)
        Me.Controls.Add(Me.cmbwilayah)
        Me.Controls.Add(Me.tkode_wilayah)
        Me.Controls.Add(Me.cmbinstansi)
        Me.Controls.Add(Me.tkode_instansi)
        Me.Controls.Add(Me.cmbkolektor1)
        Me.Controls.Add(Me.tkode_kolektor1)
        Me.Controls.Add(Me.cmbjenis_produk)
        Me.Controls.Add(Me.tkode_jenis_produk)
        Me.Controls.Add(Me.cmbjenis_transaksi)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "cetak_rincian_transaksi_tabungan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbjenis_transaksi As System.Windows.Forms.ComboBox
    Friend WithEvents tkode_jenis_produk As System.Windows.Forms.TextBox
    Friend WithEvents cmbjenis_produk As System.Windows.Forms.ComboBox
    Friend WithEvents tkode_kolektor1 As System.Windows.Forms.TextBox
    Friend WithEvents cmbkolektor1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbinstansi As System.Windows.Forms.ComboBox
    Friend WithEvents tkode_instansi As System.Windows.Forms.TextBox
    Friend WithEvents cmbwilayah As System.Windows.Forms.ComboBox
    Friend WithEvents tkode_wilayah As System.Windows.Forms.TextBox
    Friend WithEvents cmburutkan As System.Windows.Forms.ComboBox
    Friend WithEvents btnbatal As System.Windows.Forms.Button
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbmarketing As System.Windows.Forms.ComboBox
    Friend WithEvents tkode_marketing As System.Windows.Forms.TextBox
End Class
