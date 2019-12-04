<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setup_wilayah
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setup_wilayah))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnafiliasi = New System.Windows.Forms.Button()
        Me.btnhapus = New System.Windows.Forms.Button()
        Me.btntambah = New System.Windows.Forms.Button()
        Me.btnsimpan = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tnama_desa = New System.Windows.Forms.TextBox()
        Me.tkode_wilayah = New System.Windows.Forms.TextBox()
        Me.tnama_kecamatan = New System.Windows.Forms.TextBox()
        Me.tkoordinator_wilayah = New System.Windows.Forms.TextBox()
        Me.talamat_koordinator = New System.Windows.Forms.TextBox()
        Me.ttelepon = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(611, 49)
        Me.Panel1.TabIndex = 5
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
        Me.btnkeluar.Location = New System.Drawing.Point(511, 0)
        Me.btnkeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(100, 49)
        Me.btnkeluar.TabIndex = 2
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
        Me.Label1.Size = New System.Drawing.Size(151, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Setup Wilayah"
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 49)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(611, 278)
        Me.ListView1.TabIndex = 6
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.btnafiliasi)
        Me.Panel3.Controls.Add(Me.btnhapus)
        Me.Panel3.Controls.Add(Me.btntambah)
        Me.Panel3.Controls.Add(Me.btnsimpan)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 327)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(611, 49)
        Me.Panel3.TabIndex = 10
        '
        'btnafiliasi
        '
        Me.btnafiliasi.BackColor = System.Drawing.Color.LightBlue
        Me.btnafiliasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnafiliasi.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnafiliasi.Enabled = False
        Me.btnafiliasi.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnafiliasi.FlatAppearance.BorderSize = 2
        Me.btnafiliasi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnafiliasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnafiliasi.Image = Global.LKM.My.Resources.Resources.Ok
        Me.btnafiliasi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnafiliasi.Location = New System.Drawing.Point(-1, 0)
        Me.btnafiliasi.Margin = New System.Windows.Forms.Padding(4)
        Me.btnafiliasi.Name = "btnafiliasi"
        Me.btnafiliasi.Size = New System.Drawing.Size(153, 49)
        Me.btnafiliasi.TabIndex = 22
        Me.btnafiliasi.Text = "Afiliasi"
        Me.btnafiliasi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnafiliasi.UseVisualStyleBackColor = False
        '
        'btnhapus
        '
        Me.btnhapus.BackColor = System.Drawing.Color.LightBlue
        Me.btnhapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnhapus.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnhapus.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnhapus.FlatAppearance.BorderSize = 2
        Me.btnhapus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnhapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnhapus.Image = Global.LKM.My.Resources.Resources.Delete
        Me.btnhapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnhapus.Location = New System.Drawing.Point(152, 0)
        Me.btnhapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnhapus.Name = "btnhapus"
        Me.btnhapus.Size = New System.Drawing.Size(153, 49)
        Me.btnhapus.TabIndex = 21
        Me.btnhapus.Text = "Hapus"
        Me.btnhapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnhapus.UseVisualStyleBackColor = False
        '
        'btntambah
        '
        Me.btntambah.BackColor = System.Drawing.Color.LightBlue
        Me.btntambah.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btntambah.Dock = System.Windows.Forms.DockStyle.Right
        Me.btntambah.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btntambah.FlatAppearance.BorderSize = 2
        Me.btntambah.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btntambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btntambah.Image = Global.LKM.My.Resources.Resources.Add
        Me.btntambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btntambah.Location = New System.Drawing.Point(305, 0)
        Me.btntambah.Margin = New System.Windows.Forms.Padding(4)
        Me.btntambah.Name = "btntambah"
        Me.btntambah.Size = New System.Drawing.Size(153, 49)
        Me.btntambah.TabIndex = 19
        Me.btntambah.Text = "Tambah"
        Me.btntambah.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btntambah.UseVisualStyleBackColor = False
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
        Me.btnsimpan.Location = New System.Drawing.Point(458, 0)
        Me.btnsimpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnsimpan.Name = "btnsimpan"
        Me.btnsimpan.Size = New System.Drawing.Size(153, 49)
        Me.btnsimpan.TabIndex = 18
        Me.btnsimpan.Text = "Simpan"
        Me.btnsimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsimpan.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 376)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 179)
        Me.Panel2.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(128, 151)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Telepon :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(65, 123)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Alamat Koordinator :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(58, 95)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Koordinator Wilayah :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(71, 67)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Nama Kecamatan :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(106, 39)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nama Desa :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(95, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Kode Wilayah :"
        '
        'tnama_desa
        '
        Me.tnama_desa.Location = New System.Drawing.Point(207, 412)
        Me.tnama_desa.MaxLength = 60
        Me.tnama_desa.Name = "tnama_desa"
        Me.tnama_desa.Size = New System.Drawing.Size(400, 22)
        Me.tnama_desa.TabIndex = 12
        '
        'tkode_wilayah
        '
        Me.tkode_wilayah.Location = New System.Drawing.Point(207, 385)
        Me.tkode_wilayah.MaxLength = 3
        Me.tkode_wilayah.Name = "tkode_wilayah"
        Me.tkode_wilayah.Size = New System.Drawing.Size(50, 22)
        Me.tkode_wilayah.TabIndex = 11
        '
        'tnama_kecamatan
        '
        Me.tnama_kecamatan.Location = New System.Drawing.Point(207, 440)
        Me.tnama_kecamatan.MaxLength = 60
        Me.tnama_kecamatan.Name = "tnama_kecamatan"
        Me.tnama_kecamatan.Size = New System.Drawing.Size(400, 22)
        Me.tnama_kecamatan.TabIndex = 14
        '
        'tkoordinator_wilayah
        '
        Me.tkoordinator_wilayah.Location = New System.Drawing.Point(207, 468)
        Me.tkoordinator_wilayah.MaxLength = 30
        Me.tkoordinator_wilayah.Name = "tkoordinator_wilayah"
        Me.tkoordinator_wilayah.Size = New System.Drawing.Size(400, 22)
        Me.tkoordinator_wilayah.TabIndex = 15
        '
        'talamat_koordinator
        '
        Me.talamat_koordinator.Location = New System.Drawing.Point(207, 496)
        Me.talamat_koordinator.MaxLength = 60
        Me.talamat_koordinator.Name = "talamat_koordinator"
        Me.talamat_koordinator.Size = New System.Drawing.Size(400, 22)
        Me.talamat_koordinator.TabIndex = 16
        '
        'ttelepon
        '
        Me.ttelepon.Location = New System.Drawing.Point(207, 524)
        Me.ttelepon.MaxLength = 16
        Me.ttelepon.Name = "ttelepon"
        Me.ttelepon.Size = New System.Drawing.Size(400, 22)
        Me.ttelepon.TabIndex = 17
        '
        'setup_wilayah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(611, 555)
        Me.ControlBox = False
        Me.Controls.Add(Me.ttelepon)
        Me.Controls.Add(Me.talamat_koordinator)
        Me.Controls.Add(Me.tkoordinator_wilayah)
        Me.Controls.Add(Me.tnama_kecamatan)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.tnama_desa)
        Me.Controls.Add(Me.tkode_wilayah)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "setup_wilayah"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnafiliasi As System.Windows.Forms.Button
    Friend WithEvents btnhapus As System.Windows.Forms.Button
    Friend WithEvents btntambah As System.Windows.Forms.Button
    Friend WithEvents btnsimpan As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tnama_desa As System.Windows.Forms.TextBox
    Friend WithEvents tkode_wilayah As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tnama_kecamatan As System.Windows.Forms.TextBox
    Friend WithEvents tkoordinator_wilayah As System.Windows.Forms.TextBox
    Friend WithEvents talamat_koordinator As System.Windows.Forms.TextBox
    Friend WithEvents ttelepon As System.Windows.Forms.TextBox
End Class
