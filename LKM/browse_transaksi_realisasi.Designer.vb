<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class browse_transaksi_realisasi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(browse_transaksi_realisasi))
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnexport = New System.Windows.Forms.Button()
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.btnvalidasi = New System.Windows.Forms.Button()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbproduk = New System.Windows.Forms.ComboBox()
        Me.tadministrasi = New System.Windows.Forms.TextBox()
        Me.tjml_dikeluarkan = New System.Windows.Forms.TextBox()
        Me.tprovisi = New System.Windows.Forms.TextBox()
        Me.tjml_realisasi = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tjumlahrow = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView2
        '
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(0, 368)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(1073, 163)
        Me.ListView2.TabIndex = 10
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.btnexport)
        Me.Panel3.Controls.Add(Me.btnrefresh)
        Me.Panel3.Controls.Add(Me.btnvalidasi)
        Me.Panel3.Controls.Add(Me.btnkeluar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 319)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1073, 49)
        Me.Panel3.TabIndex = 12
        '
        'btnexport
        '
        Me.btnexport.BackColor = System.Drawing.Color.LightBlue
        Me.btnexport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexport.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnexport.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnexport.FlatAppearance.BorderSize = 2
        Me.btnexport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnexport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexport.Image = CType(resources.GetObject("btnexport.Image"), System.Drawing.Image)
        Me.btnexport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnexport.Location = New System.Drawing.Point(673, 0)
        Me.btnexport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnexport.Name = "btnexport"
        Me.btnexport.Size = New System.Drawing.Size(100, 49)
        Me.btnexport.TabIndex = 12
        Me.btnexport.Text = "Export"
        Me.btnexport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnexport.UseVisualStyleBackColor = False
        '
        'btnrefresh
        '
        Me.btnrefresh.BackColor = System.Drawing.Color.LightBlue
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnrefresh.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnrefresh.FlatAppearance.BorderSize = 2
        Me.btnrefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrefresh.Image = CType(resources.GetObject("btnrefresh.Image"), System.Drawing.Image)
        Me.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefresh.Location = New System.Drawing.Point(773, 0)
        Me.btnrefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(100, 49)
        Me.btnrefresh.TabIndex = 11
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'btnvalidasi
        '
        Me.btnvalidasi.BackColor = System.Drawing.Color.LightBlue
        Me.btnvalidasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnvalidasi.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnvalidasi.Enabled = False
        Me.btnvalidasi.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnvalidasi.FlatAppearance.BorderSize = 2
        Me.btnvalidasi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnvalidasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnvalidasi.Image = CType(resources.GetObject("btnvalidasi.Image"), System.Drawing.Image)
        Me.btnvalidasi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnvalidasi.Location = New System.Drawing.Point(873, 0)
        Me.btnvalidasi.Margin = New System.Windows.Forms.Padding(4)
        Me.btnvalidasi.Name = "btnvalidasi"
        Me.btnvalidasi.Size = New System.Drawing.Size(100, 49)
        Me.btnvalidasi.TabIndex = 9
        Me.btnvalidasi.Text = "Cetak Validasi"
        Me.btnvalidasi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnvalidasi.UseVisualStyleBackColor = False
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
        Me.btnkeluar.Location = New System.Drawing.Point(973, 0)
        Me.btnkeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(100, 49)
        Me.btnkeluar.TabIndex = 8
        Me.btnkeluar.Text = "Keluar"
        Me.btnkeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnkeluar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.cmbproduk)
        Me.Panel2.Controls.Add(Me.tadministrasi)
        Me.Panel2.Controls.Add(Me.tjml_dikeluarkan)
        Me.Panel2.Controls.Add(Me.tprovisi)
        Me.Panel2.Controls.Add(Me.tjml_realisasi)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.tjumlahrow)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 257)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1073, 62)
        Me.Panel2.TabIndex = 13
        '
        'cmbproduk
        '
        Me.cmbproduk.BackColor = System.Drawing.SystemColors.Window
        Me.cmbproduk.DropDownHeight = 100
        Me.cmbproduk.FormattingEnabled = True
        Me.cmbproduk.IntegralHeight = False
        Me.cmbproduk.Location = New System.Drawing.Point(861, 6)
        Me.cmbproduk.Name = "cmbproduk"
        Me.cmbproduk.Size = New System.Drawing.Size(200, 24)
        Me.cmbproduk.TabIndex = 22
        '
        'tadministrasi
        '
        Me.tadministrasi.BackColor = System.Drawing.SystemColors.Window
        Me.tadministrasi.Enabled = False
        Me.tadministrasi.Location = New System.Drawing.Point(456, 34)
        Me.tadministrasi.Name = "tadministrasi"
        Me.tadministrasi.Size = New System.Drawing.Size(150, 22)
        Me.tadministrasi.TabIndex = 21
        Me.tadministrasi.Text = "0"
        Me.tadministrasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tjml_dikeluarkan
        '
        Me.tjml_dikeluarkan.BackColor = System.Drawing.SystemColors.Window
        Me.tjml_dikeluarkan.Enabled = False
        Me.tjml_dikeluarkan.Location = New System.Drawing.Point(456, 6)
        Me.tjml_dikeluarkan.Name = "tjml_dikeluarkan"
        Me.tjml_dikeluarkan.Size = New System.Drawing.Size(150, 22)
        Me.tjml_dikeluarkan.TabIndex = 20
        Me.tjml_dikeluarkan.Text = "0"
        Me.tjml_dikeluarkan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tprovisi
        '
        Me.tprovisi.BackColor = System.Drawing.SystemColors.Window
        Me.tprovisi.Enabled = False
        Me.tprovisi.Location = New System.Drawing.Point(166, 34)
        Me.tprovisi.Name = "tprovisi"
        Me.tprovisi.Size = New System.Drawing.Size(150, 22)
        Me.tprovisi.TabIndex = 19
        Me.tprovisi.Text = "0"
        Me.tprovisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tjml_realisasi
        '
        Me.tjml_realisasi.BackColor = System.Drawing.SystemColors.Window
        Me.tjml_realisasi.Enabled = False
        Me.tjml_realisasi.Location = New System.Drawing.Point(166, 6)
        Me.tjml_realisasi.Name = "tjml_realisasi"
        Me.tjml_realisasi.Size = New System.Drawing.Size(150, 22)
        Me.tjml_realisasi.TabIndex = 18
        Me.tjml_realisasi.Text = "0"
        Me.tjml_realisasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(363, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 16)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Administrasi :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(340, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Jml Dikeluarkan :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(105, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Provisi :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Jml Realisasi :"
        '
        'tjumlahrow
        '
        Me.tjumlahrow.Enabled = False
        Me.tjumlahrow.Location = New System.Drawing.Point(9, 6)
        Me.tjumlahrow.Name = "tjumlahrow"
        Me.tjumlahrow.Size = New System.Drawing.Size(50, 22)
        Me.tjumlahrow.TabIndex = 2
        Me.tjumlahrow.Text = "0"
        Me.tjumlahrow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 49)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1073, 208)
        Me.ListView1.TabIndex = 14
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.LKM.My.Resources.Resources.header4
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1073, 49)
        Me.Panel1.TabIndex = 8
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(863, 12)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(153, 22)
        Me.DateTimePicker2.TabIndex = 19
        Me.DateTimePicker2.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(663, 12)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(137, 22)
        Me.DateTimePicker1.TabIndex = 18
        Me.DateTimePicker1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(553, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 17
        Me.TextBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(286, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Browse Transaksi Pencairan"
        '
        'browse_transaksi_realisasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1073, 531)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "browse_transaksi_realisasi"
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnexport As System.Windows.Forms.Button
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnvalidasi As System.Windows.Forms.Button
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbproduk As System.Windows.Forms.ComboBox
    Friend WithEvents tadministrasi As System.Windows.Forms.TextBox
    Friend WithEvents tjml_dikeluarkan As System.Windows.Forms.TextBox
    Friend WithEvents tprovisi As System.Windows.Forms.TextBox
    Friend WithEvents tjml_realisasi As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tjumlahrow As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
