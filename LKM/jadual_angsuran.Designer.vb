<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class jadual_angsuran
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(jadual_angsuran))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnreset = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tno_rekening = New System.Windows.Forms.TextBox()
        Me.tnama_nasabah = New System.Windows.Forms.TextBox()
        Me.tplafond = New System.Windows.Forms.TextBox()
        Me.cmbsistem_angsuran = New System.Windows.Forms.ComboBox()
        Me.cmbsistem_bunga = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tsuku_bunga = New System.Windows.Forms.TextBox()
        Me.tjkw = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btncetak = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.btnsimpan = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel2.Size = New System.Drawing.Size(200, 154)
        Me.Panel2.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(96, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Sistem Bunga :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(78, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Sistem Angsuran :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(134, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Plafond :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(84, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Nama Nasabah :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(78, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nomor Rekening :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.LKM.My.Resources.Resources.header4
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.btnreset)
        Me.Panel1.Controls.Add(Me.btncancel)
        Me.Panel1.Controls.Add(Me.btnkeluar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(769, 49)
        Me.Panel1.TabIndex = 18
        '
        'btnreset
        '
        Me.btnreset.BackColor = System.Drawing.Color.LightBlue
        Me.btnreset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnreset.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnreset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnreset.FlatAppearance.BorderSize = 2
        Me.btnreset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreset.Location = New System.Drawing.Point(509, 0)
        Me.btnreset.Name = "btnreset"
        Me.btnreset.Size = New System.Drawing.Size(80, 49)
        Me.btnreset.TabIndex = 19
        Me.btnreset.Text = "Reset Jadual"
        Me.btnreset.UseVisualStyleBackColor = False
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.LightBlue
        Me.btncancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btncancel.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btncancel.FlatAppearance.BorderSize = 2
        Me.btncancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.Location = New System.Drawing.Point(589, 0)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(80, 49)
        Me.btncancel.TabIndex = 20
        Me.btncancel.Text = "Cancel Daftar"
        Me.btncancel.UseVisualStyleBackColor = False
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
        Me.btnkeluar.Location = New System.Drawing.Point(669, 0)
        Me.btnkeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(100, 49)
        Me.btnkeluar.TabIndex = 21
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
        Me.Label1.Size = New System.Drawing.Size(174, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Jadual Angsuran"
        '
        'tno_rekening
        '
        Me.tno_rekening.Enabled = False
        Me.tno_rekening.Location = New System.Drawing.Point(208, 57)
        Me.tno_rekening.Name = "tno_rekening"
        Me.tno_rekening.Size = New System.Drawing.Size(150, 22)
        Me.tno_rekening.TabIndex = 10
        '
        'tnama_nasabah
        '
        Me.tnama_nasabah.Enabled = False
        Me.tnama_nasabah.Location = New System.Drawing.Point(208, 85)
        Me.tnama_nasabah.Name = "tnama_nasabah"
        Me.tnama_nasabah.Size = New System.Drawing.Size(300, 22)
        Me.tnama_nasabah.TabIndex = 11
        '
        'tplafond
        '
        Me.tplafond.Enabled = False
        Me.tplafond.Location = New System.Drawing.Point(208, 113)
        Me.tplafond.Name = "tplafond"
        Me.tplafond.Size = New System.Drawing.Size(150, 22)
        Me.tplafond.TabIndex = 12
        Me.tplafond.Text = "0"
        Me.tplafond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbsistem_angsuran
        '
        Me.cmbsistem_angsuran.DropDownHeight = 100
        Me.cmbsistem_angsuran.Enabled = False
        Me.cmbsistem_angsuran.FormattingEnabled = True
        Me.cmbsistem_angsuran.IntegralHeight = False
        Me.cmbsistem_angsuran.Location = New System.Drawing.Point(208, 141)
        Me.cmbsistem_angsuran.Name = "cmbsistem_angsuran"
        Me.cmbsistem_angsuran.Size = New System.Drawing.Size(150, 24)
        Me.cmbsistem_angsuran.TabIndex = 13
        '
        'cmbsistem_bunga
        '
        Me.cmbsistem_bunga.DropDownHeight = 100
        Me.cmbsistem_bunga.Enabled = False
        Me.cmbsistem_bunga.FormattingEnabled = True
        Me.cmbsistem_bunga.IntegralHeight = False
        Me.cmbsistem_bunga.Location = New System.Drawing.Point(208, 171)
        Me.cmbsistem_bunga.Name = "cmbsistem_bunga"
        Me.cmbsistem_bunga.Size = New System.Drawing.Size(206, 24)
        Me.cmbsistem_bunga.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(429, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "SB/Nisbah :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(466, 174)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "JKW :"
        '
        'tsuku_bunga
        '
        Me.tsuku_bunga.Enabled = False
        Me.tsuku_bunga.Location = New System.Drawing.Point(514, 143)
        Me.tsuku_bunga.MaxLength = 6
        Me.tsuku_bunga.Name = "tsuku_bunga"
        Me.tsuku_bunga.Size = New System.Drawing.Size(50, 22)
        Me.tsuku_bunga.TabIndex = 16
        Me.tsuku_bunga.Text = "0,000"
        Me.tsuku_bunga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tjkw
        '
        Me.tjkw.BackColor = System.Drawing.SystemColors.Window
        Me.tjkw.Enabled = False
        Me.tjkw.Location = New System.Drawing.Point(514, 171)
        Me.tjkw.MaxLength = 3
        Me.tjkw.Name = "tjkw"
        Me.tjkw.Size = New System.Drawing.Size(50, 22)
        Me.tjkw.TabIndex = 17
        Me.tjkw.Text = "0"
        Me.tjkw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(570, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 16)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "%"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(570, 174)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "text"
        '
        'btncetak
        '
        Me.btncetak.BackColor = System.Drawing.Color.LightBlue
        Me.btncetak.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncetak.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btncetak.FlatAppearance.BorderSize = 2
        Me.btncetak.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btncetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncetak.Location = New System.Drawing.Point(610, 60)
        Me.btncetak.Name = "btncetak"
        Me.btncetak.Size = New System.Drawing.Size(150, 30)
        Me.btncetak.TabIndex = 20
        Me.btncetak.Text = "Cetak Jadual"
        Me.btncetak.UseVisualStyleBackColor = False
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 201)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(769, 335)
        Me.ListView1.TabIndex = 21
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'btnsimpan
        '
        Me.btnsimpan.BackColor = System.Drawing.Color.LightBlue
        Me.btnsimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsimpan.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnsimpan.FlatAppearance.BorderSize = 2
        Me.btnsimpan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnsimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsimpan.Location = New System.Drawing.Point(610, 139)
        Me.btnsimpan.Name = "btnsimpan"
        Me.btnsimpan.Size = New System.Drawing.Size(150, 30)
        Me.btnsimpan.TabIndex = 22
        Me.btnsimpan.Text = "Simpan dan Reset"
        Me.btnsimpan.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(536, 110)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(107, 22)
        Me.DateTimePicker1.TabIndex = 23
        Me.DateTimePicker1.Visible = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(650, 110)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(107, 22)
        Me.DateTimePicker2.TabIndex = 24
        Me.DateTimePicker2.Visible = False
        '
        'jadual_angsuran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(769, 536)
        Me.ControlBox = False
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.btnsimpan)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.btncetak)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tjkw)
        Me.Controls.Add(Me.tsuku_bunga)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbsistem_bunga)
        Me.Controls.Add(Me.cmbsistem_angsuran)
        Me.Controls.Add(Me.tplafond)
        Me.Controls.Add(Me.tnama_nasabah)
        Me.Controls.Add(Me.tno_rekening)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "jadual_angsuran"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tno_rekening As System.Windows.Forms.TextBox
    Friend WithEvents tnama_nasabah As System.Windows.Forms.TextBox
    Friend WithEvents tplafond As System.Windows.Forms.TextBox
    Friend WithEvents cmbsistem_angsuran As System.Windows.Forms.ComboBox
    Friend WithEvents cmbsistem_bunga As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tsuku_bunga As System.Windows.Forms.TextBox
    Friend WithEvents tjkw As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btncetak As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents btnreset As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btnsimpan As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
End Class
