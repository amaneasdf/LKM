<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setup_kolektor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setup_kolektor))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.tkode_kolektor = New System.Windows.Forms.TextBox()
        Me.tnama_kolektor = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnafiliasi = New System.Windows.Forms.Button()
        Me.btnhapus = New System.Windows.Forms.Button()
        Me.btntambah = New System.Windows.Forms.Button()
        Me.btnsimpan = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.ListView1.TabIndex = 5
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'tkode_kolektor
        '
        Me.tkode_kolektor.Location = New System.Drawing.Point(207, 384)
        Me.tkode_kolektor.MaxLength = 3
        Me.tkode_kolektor.Name = "tkode_kolektor"
        Me.tkode_kolektor.Size = New System.Drawing.Size(50, 22)
        Me.tkode_kolektor.TabIndex = 10
        '
        'tnama_kolektor
        '
        Me.tnama_kolektor.Location = New System.Drawing.Point(207, 412)
        Me.tnama_kolektor.MaxLength = 60
        Me.tnama_kolektor.Name = "tnama_kolektor"
        Me.tnama_kolektor.Size = New System.Drawing.Size(400, 22)
        Me.tnama_kolektor.TabIndex = 11
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.btnafiliasi)
        Me.Panel3.Controls.Add(Me.btnhapus)
        Me.Panel3.Controls.Add(Me.btntambah)
        Me.Panel3.Controls.Add(Me.btnsimpan)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 327)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(611, 49)
        Me.Panel3.TabIndex = 12
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
        Me.btnafiliasi.Location = New System.Drawing.Point(0, 0)
        Me.btnafiliasi.Margin = New System.Windows.Forms.Padding(4)
        Me.btnafiliasi.Name = "btnafiliasi"
        Me.btnafiliasi.Size = New System.Drawing.Size(152, 49)
        Me.btnafiliasi.TabIndex = 16
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
        Me.btnhapus.TabIndex = 15
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
        Me.btntambah.TabIndex = 14
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
        Me.btnsimpan.TabIndex = 12
        Me.btnsimpan.Text = "Simpan"
        Me.btnsimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsimpan.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 376)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 68)
        Me.Panel2.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(90, 39)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nama Kolektor :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(95, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Kode Kolektor :"
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
        Me.Panel1.TabIndex = 4
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
        Me.Label1.Size = New System.Drawing.Size(153, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Setup Kolektor"
        '
        'setup_kolektor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(611, 444)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tnama_kolektor)
        Me.Controls.Add(Me.tkode_kolektor)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "setup_kolektor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents tkode_kolektor As System.Windows.Forms.TextBox
    Friend WithEvents tnama_kolektor As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnafiliasi As System.Windows.Forms.Button
    Friend WithEvents btnhapus As System.Windows.Forms.Button
    Friend WithEvents btntambah As System.Windows.Forms.Button
    Friend WithEvents btnsimpan As System.Windows.Forms.Button
End Class
