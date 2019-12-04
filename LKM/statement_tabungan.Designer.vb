<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class statement_tabungan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(statement_tabungan))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btncetakcver = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tjumlah = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tnama_nasabah = New System.Windows.Forms.TextBox()
        Me.talamat = New System.Windows.Forms.TextBox()
        Me.cmbtemplate = New System.Windows.Forms.ComboBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnpreview = New System.Windows.Forms.Button()
        Me.tno_rekening = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btncetak = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.Panel1.Controls.Add(Me.btncetakcver)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.btnkeluar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(874, 49)
        Me.Panel1.TabIndex = 22
        '
        'btncetakcver
        '
        Me.btncetakcver.BackColor = System.Drawing.Color.LightBlue
        Me.btncetakcver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncetakcver.Dock = System.Windows.Forms.DockStyle.Right
        Me.btncetakcver.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btncetakcver.FlatAppearance.BorderSize = 2
        Me.btncetakcver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btncetakcver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncetakcver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncetakcver.Location = New System.Drawing.Point(674, 0)
        Me.btncetakcver.Margin = New System.Windows.Forms.Padding(4)
        Me.btncetakcver.Name = "btncetakcver"
        Me.btncetakcver.Size = New System.Drawing.Size(100, 49)
        Me.btncetakcver.TabIndex = 23
        Me.btncetakcver.Text = "Cetak Cover"
        Me.btncetakcver.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncetakcver.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(224, 7)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Cetak Buku Manual"
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
        Me.btnkeluar.Location = New System.Drawing.Point(774, 0)
        Me.btnkeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(100, 49)
        Me.btnkeluar.TabIndex = 24
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
        Me.Label1.Size = New System.Drawing.Size(212, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Statement Tabungan"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.tjumlah)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 49)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(125, 487)
        Me.Panel2.TabIndex = 7
        '
        'tjumlah
        '
        Me.tjumlah.Location = New System.Drawing.Point(33, 457)
        Me.tjumlah.MaxLength = 2
        Me.tjumlah.Name = "tjumlah"
        Me.tjumlah.Size = New System.Drawing.Size(50, 22)
        Me.tjumlah.TabIndex = 19
        Me.tjumlah.Text = "01"
        Me.tjumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(50, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Template :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Periode Mutasi :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(66, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Alamat :"
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
        'tnama_nasabah
        '
        Me.tnama_nasabah.Enabled = False
        Me.tnama_nasabah.Location = New System.Drawing.Point(254, 57)
        Me.tnama_nasabah.Name = "tnama_nasabah"
        Me.tnama_nasabah.Size = New System.Drawing.Size(300, 22)
        Me.tnama_nasabah.TabIndex = 11
        '
        'talamat
        '
        Me.talamat.Enabled = False
        Me.talamat.Location = New System.Drawing.Point(128, 85)
        Me.talamat.Name = "talamat"
        Me.talamat.Size = New System.Drawing.Size(426, 22)
        Me.talamat.TabIndex = 12
        '
        'cmbtemplate
        '
        Me.cmbtemplate.DropDownHeight = 100
        Me.cmbtemplate.FormattingEnabled = True
        Me.cmbtemplate.IntegralHeight = False
        Me.cmbtemplate.Location = New System.Drawing.Point(128, 143)
        Me.cmbtemplate.Name = "cmbtemplate"
        Me.cmbtemplate.Size = New System.Drawing.Size(243, 24)
        Me.cmbtemplate.TabIndex = 15
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 173)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(700, 328)
        Me.ListView1.TabIndex = 18
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(128, 113)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(157, 22)
        Me.DateTimePicker1.TabIndex = 13
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(320, 113)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(157, 22)
        Me.DateTimePicker2.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(291, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "s/d"
        '
        'btnpreview
        '
        Me.btnpreview.BackColor = System.Drawing.Color.LightBlue
        Me.btnpreview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnpreview.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnpreview.FlatAppearance.BorderSize = 2
        Me.btnpreview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnpreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpreview.Location = New System.Drawing.Point(377, 141)
        Me.btnpreview.Name = "btnpreview"
        Me.btnpreview.Size = New System.Drawing.Size(100, 26)
        Me.btnpreview.TabIndex = 17
        Me.btnpreview.Text = "Refresh"
        Me.btnpreview.UseVisualStyleBackColor = False
        '
        'tno_rekening
        '
        Me.tno_rekening.Location = New System.Drawing.Point(128, 57)
        Me.tno_rekening.MaxLength = 20
        Me.tno_rekening.Name = "tno_rekening"
        Me.tno_rekening.Size = New System.Drawing.Size(120, 22)
        Me.tno_rekening.TabIndex = 10
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Location = New System.Drawing.Point(133, 508)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(88, 20)
        Me.CheckBox1.TabIndex = 20
        Me.CheckBox1.Text = "Buku Baru"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'btncetak
        '
        Me.btncetak.BackColor = System.Drawing.Color.LightBlue
        Me.btncetak.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncetak.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btncetak.FlatAppearance.BorderSize = 2
        Me.btncetak.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btncetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncetak.Location = New System.Drawing.Point(227, 505)
        Me.btncetak.Name = "btncetak"
        Me.btncetak.Size = New System.Drawing.Size(473, 25)
        Me.btncetak.TabIndex = 21
        Me.btncetak.Text = "CETAK"
        Me.btncetak.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Khaki
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Location = New System.Drawing.Point(706, 173)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(163, 357)
        Me.Panel3.TabIndex = 61
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(3, 169)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(108, 16)
        Me.Label22.TabIndex = 75
        Me.Label22.Text = "10 : Pajak Bunga"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 185)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(125, 16)
        Me.Label19.TabIndex = 74
        Me.Label19.Text = "97 : Angsuran Kredit"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(3, 217)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(149, 16)
        Me.Label20.TabIndex = 73
        Me.Label20.Text = "99 : OB Antar Tabungan"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 201)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(142, 16)
        Me.Label21.TabIndex = 72
        Me.Label21.Text = "98 : Biaya Administrasi"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 105)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(151, 16)
        Me.Label17.TabIndex = 71
        Me.Label17.Text = "06 : Penarikan Dari COA"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 89)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(128, 16)
        Me.Label18.TabIndex = 70
        Me.Label18.Text = "05 : Setoran Ke COA"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 121)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(135, 16)
        Me.Label16.TabIndex = 69
        Me.Label16.Text = "07 : Bunga Tabungan"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 153)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 16)
        Me.Label15.TabIndex = 68
        Me.Label15.Text = "09 : Bea Rek Pasif"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 137)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(139, 16)
        Me.Label14.TabIndex = 67
        Me.Label14.Text = "08 : Bea Adm Bulanan"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(132, 16)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "04 : Penutupan Tunai"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(146, 16)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "03 : Tarik Ke Tabungan"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 16)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "02 : Penarikan Tunai"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 16)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "01 : Setoran Tunai"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 16)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "00 : Saldo Migrasi"
        '
        'statement_tabungan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 536)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btncetak)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.btnpreview)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.cmbtemplate)
        Me.Controls.Add(Me.talamat)
        Me.Controls.Add(Me.tnama_nasabah)
        Me.Controls.Add(Me.tno_rekening)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "statement_tabungan"
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tnama_nasabah As System.Windows.Forms.TextBox
    Friend WithEvents talamat As System.Windows.Forms.TextBox
    Friend WithEvents cmbtemplate As System.Windows.Forms.ComboBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tjumlah As System.Windows.Forms.TextBox
    Friend WithEvents btnpreview As System.Windows.Forms.Button
    Friend WithEvents tno_rekening As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents btncetak As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btncetakcver As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
