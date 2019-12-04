<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cek_master_nasabah
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cek_master_nasabah))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnlanjut = New System.Windows.Forms.Button()
        Me.btnbaru = New System.Windows.Forms.Button()
        Me.btnbatal = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tnik = New System.Windows.Forms.TextBox()
        Me.cmbsex = New System.Windows.Forms.ComboBox()
        Me.tkode_kota = New System.Windows.Forms.TextBox()
        Me.cmbkota = New System.Windows.Forms.ComboBox()
        Me.tanggal = New System.Windows.Forms.DateTimePicker()
        Me.tnama_kota = New System.Windows.Forms.TextBox()
        Me.tnama_ibu = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tnama = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.LKM.My.Resources.Resources.header4
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.btnlanjut)
        Me.Panel1.Controls.Add(Me.btnbaru)
        Me.Panel1.Controls.Add(Me.btnbatal)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(686, 49)
        Me.Panel1.TabIndex = 0
        '
        'btnlanjut
        '
        Me.btnlanjut.BackColor = System.Drawing.Color.LightBlue
        Me.btnlanjut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnlanjut.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnlanjut.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnlanjut.FlatAppearance.BorderSize = 2
        Me.btnlanjut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnlanjut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlanjut.Image = Global.LKM.My.Resources.Resources.Forward
        Me.btnlanjut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlanjut.Location = New System.Drawing.Point(386, 0)
        Me.btnlanjut.Margin = New System.Windows.Forms.Padding(4)
        Me.btnlanjut.Name = "btnlanjut"
        Me.btnlanjut.Size = New System.Drawing.Size(100, 49)
        Me.btnlanjut.TabIndex = 200
        Me.btnlanjut.Text = "Lanjut"
        Me.btnlanjut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnlanjut.UseVisualStyleBackColor = False
        '
        'btnbaru
        '
        Me.btnbaru.BackColor = System.Drawing.Color.LightBlue
        Me.btnbaru.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnbaru.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnbaru.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnbaru.FlatAppearance.BorderSize = 2
        Me.btnbaru.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnbaru.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbaru.Image = Global.LKM.My.Resources.Resources.Add
        Me.btnbaru.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbaru.Location = New System.Drawing.Point(486, 0)
        Me.btnbaru.Margin = New System.Windows.Forms.Padding(4)
        Me.btnbaru.Name = "btnbaru"
        Me.btnbaru.Size = New System.Drawing.Size(100, 49)
        Me.btnbaru.TabIndex = 210
        Me.btnbaru.Text = "Baru"
        Me.btnbaru.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnbaru.UseVisualStyleBackColor = False
        '
        'btnbatal
        '
        Me.btnbatal.BackColor = System.Drawing.Color.LightBlue
        Me.btnbatal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnbatal.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnbatal.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnbatal.FlatAppearance.BorderSize = 2
        Me.btnbatal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnbatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbatal.Image = Global.LKM.My.Resources.Resources.Cancel
        Me.btnbatal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbatal.Location = New System.Drawing.Point(586, 0)
        Me.btnbatal.Margin = New System.Windows.Forms.Padding(4)
        Me.btnbatal.Name = "btnbatal"
        Me.btnbatal.Size = New System.Drawing.Size(100, 49)
        Me.btnbatal.TabIndex = 220
        Me.btnbatal.Text = "Batal"
        Me.btnbatal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnbatal.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cek Master Nasabah"
        '
        'tnik
        '
        Me.tnik.BackColor = System.Drawing.SystemColors.Window
        Me.tnik.Location = New System.Drawing.Point(208, 57)
        Me.tnik.Margin = New System.Windows.Forms.Padding(4)
        Me.tnik.MaxLength = 16
        Me.tnik.Name = "tnik"
        Me.tnik.Size = New System.Drawing.Size(200, 22)
        Me.tnik.TabIndex = 5
        '
        'cmbsex
        '
        Me.cmbsex.DropDownHeight = 100
        Me.cmbsex.Enabled = False
        Me.cmbsex.FormattingEnabled = True
        Me.cmbsex.IntegralHeight = False
        Me.cmbsex.Location = New System.Drawing.Point(208, 116)
        Me.cmbsex.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbsex.Name = "cmbsex"
        Me.cmbsex.Size = New System.Drawing.Size(160, 24)
        Me.cmbsex.TabIndex = 13
        '
        'tkode_kota
        '
        Me.tkode_kota.Enabled = False
        Me.tkode_kota.Location = New System.Drawing.Point(208, 148)
        Me.tkode_kota.Margin = New System.Windows.Forms.Padding(4)
        Me.tkode_kota.MaxLength = 4
        Me.tkode_kota.Name = "tkode_kota"
        Me.tkode_kota.Size = New System.Drawing.Size(65, 22)
        Me.tkode_kota.TabIndex = 14
        Me.tkode_kota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbkota
        '
        Me.cmbkota.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbkota.DropDownHeight = 100
        Me.cmbkota.Enabled = False
        Me.cmbkota.FormattingEnabled = True
        Me.cmbkota.IntegralHeight = False
        Me.cmbkota.ItemHeight = 16
        Me.cmbkota.Location = New System.Drawing.Point(284, 148)
        Me.cmbkota.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbkota.Name = "cmbkota"
        Me.cmbkota.Size = New System.Drawing.Size(235, 24)
        Me.cmbkota.TabIndex = 15
        '
        'tanggal
        '
        Me.tanggal.Checked = False
        Me.tanggal.Enabled = False
        Me.tanggal.Location = New System.Drawing.Point(527, 148)
        Me.tanggal.Margin = New System.Windows.Forms.Padding(4)
        Me.tanggal.Name = "tanggal"
        Me.tanggal.ShowCheckBox = True
        Me.tanggal.Size = New System.Drawing.Size(156, 22)
        Me.tanggal.TabIndex = 16
        '
        'tnama_kota
        '
        Me.tnama_kota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnama_kota.Enabled = False
        Me.tnama_kota.Location = New System.Drawing.Point(208, 178)
        Me.tnama_kota.Margin = New System.Windows.Forms.Padding(4)
        Me.tnama_kota.Name = "tnama_kota"
        Me.tnama_kota.Size = New System.Drawing.Size(309, 22)
        Me.tnama_kota.TabIndex = 17
        '
        'tnama_ibu
        '
        Me.tnama_ibu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnama_ibu.Enabled = False
        Me.tnama_ibu.Location = New System.Drawing.Point(208, 208)
        Me.tnama_ibu.Margin = New System.Windows.Forms.Padding(4)
        Me.tnama_ibu.MaxLength = 30
        Me.tnama_ibu.Name = "tnama_ibu"
        Me.tnama_ibu.Size = New System.Drawing.Size(309, 22)
        Me.tnama_ibu.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(33, 211)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Nama Gadis Ibu Kandung :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(66, 151)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Kota / Tanggal Lahir :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(163, 119)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Sex :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(93, 89)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Nama Lengkap :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(128, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "NIK (WNI) :"
        '
        'tnama
        '
        Me.tnama.BackColor = System.Drawing.SystemColors.Window
        Me.tnama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnama.Location = New System.Drawing.Point(208, 87)
        Me.tnama.Margin = New System.Windows.Forms.Padding(4)
        Me.tnama.MaxLength = 60
        Me.tnama.Name = "tnama"
        Me.tnama.Size = New System.Drawing.Size(378, 22)
        Me.tnama.TabIndex = 10
        '
        'cek_master_nasabah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(686, 238)
        Me.ControlBox = False
        Me.Controls.Add(Me.tnama)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tnama_ibu)
        Me.Controls.Add(Me.tnama_kota)
        Me.Controls.Add(Me.tanggal)
        Me.Controls.Add(Me.cmbkota)
        Me.Controls.Add(Me.tkode_kota)
        Me.Controls.Add(Me.cmbsex)
        Me.Controls.Add(Me.tnik)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "cek_master_nasabah"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tnik As System.Windows.Forms.TextBox
    Friend WithEvents cmbsex As System.Windows.Forms.ComboBox
    Friend WithEvents tkode_kota As System.Windows.Forms.TextBox
    Friend WithEvents cmbkota As System.Windows.Forms.ComboBox
    Friend WithEvents tanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents tnama_kota As System.Windows.Forms.TextBox
    Friend WithEvents tnama_ibu As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnlanjut As System.Windows.Forms.Button
    Friend WithEvents btnbaru As System.Windows.Forms.Button
    Friend WithEvents btnbatal As System.Windows.Forms.Button
    Friend WithEvents tnama As System.Windows.Forms.TextBox
End Class
