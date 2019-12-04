<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class petugas_pelaporan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(petugas_pelaporan))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnsimpan = New System.Windows.Forms.Button()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbtab_pengesah = New System.Windows.Forms.ComboBox()
        Me.cmbtab_pemeriksa = New System.Windows.Forms.ComboBox()
        Me.cmbtab_pembuat = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbkre_pengesah = New System.Windows.Forms.ComboBox()
        Me.cmbkre_pemeriksa = New System.Windows.Forms.ComboBox()
        Me.cmbkre_pembuat = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbakt_pengesah = New System.Windows.Forms.ComboBox()
        Me.cmbakt_pemeriksa = New System.Windows.Forms.ComboBox()
        Me.cmbakt_pembuat = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.LKM.My.Resources.Resources.header4
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.btnsimpan)
        Me.Panel1.Controls.Add(Me.btnkeluar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(797, 49)
        Me.Panel1.TabIndex = 16
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
        Me.btnsimpan.Location = New System.Drawing.Point(597, 0)
        Me.btnsimpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnsimpan.Name = "btnsimpan"
        Me.btnsimpan.Size = New System.Drawing.Size(100, 49)
        Me.btnsimpan.TabIndex = 16
        Me.btnsimpan.Text = "Simpan"
        Me.btnsimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsimpan.UseVisualStyleBackColor = False
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
        Me.btnkeluar.Location = New System.Drawing.Point(697, 0)
        Me.btnkeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(100, 49)
        Me.btnkeluar.TabIndex = 17
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
        Me.Label1.Size = New System.Drawing.Size(195, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Petugas Pelaporan"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmbtab_pengesah)
        Me.GroupBox1.Controls.Add(Me.cmbtab_pemeriksa)
        Me.GroupBox1.Controls.Add(Me.cmbtab_pembuat)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(386, 118)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Laporan Tabungan"
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'cmbtab_pengesah
        '
        Me.cmbtab_pengesah.DropDownHeight = 100
        Me.cmbtab_pengesah.FormattingEnabled = True
        Me.cmbtab_pengesah.IntegralHeight = False
        Me.cmbtab_pengesah.Location = New System.Drawing.Point(127, 81)
        Me.cmbtab_pengesah.Name = "cmbtab_pengesah"
        Me.cmbtab_pengesah.Size = New System.Drawing.Size(250, 24)
        Me.cmbtab_pengesah.TabIndex = 12
        '
        'cmbtab_pemeriksa
        '
        Me.cmbtab_pemeriksa.DropDownHeight = 100
        Me.cmbtab_pemeriksa.FormattingEnabled = True
        Me.cmbtab_pemeriksa.IntegralHeight = False
        Me.cmbtab_pemeriksa.Location = New System.Drawing.Point(127, 51)
        Me.cmbtab_pemeriksa.Name = "cmbtab_pemeriksa"
        Me.cmbtab_pemeriksa.Size = New System.Drawing.Size(250, 24)
        Me.cmbtab_pemeriksa.TabIndex = 11
        '
        'cmbtab_pembuat
        '
        Me.cmbtab_pembuat.DropDownHeight = 100
        Me.cmbtab_pembuat.FormattingEnabled = True
        Me.cmbtab_pembuat.IntegralHeight = False
        Me.cmbtab_pembuat.Location = New System.Drawing.Point(127, 21)
        Me.cmbtab_pembuat.Name = "cmbtab_pembuat"
        Me.cmbtab_pembuat.Size = New System.Drawing.Size(250, 24)
        Me.cmbtab_pembuat.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Pengesah :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Pemeriksa :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Pembuat :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmbkre_pengesah)
        Me.GroupBox2.Controls.Add(Me.cmbkre_pemeriksa)
        Me.GroupBox2.Controls.Add(Me.cmbkre_pembuat)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(401, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(386, 118)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Laporan Kredit"
        Me.GroupBox2.UseCompatibleTextRendering = True
        '
        'cmbkre_pengesah
        '
        Me.cmbkre_pengesah.DropDownHeight = 100
        Me.cmbkre_pengesah.FormattingEnabled = True
        Me.cmbkre_pengesah.IntegralHeight = False
        Me.cmbkre_pengesah.Location = New System.Drawing.Point(127, 81)
        Me.cmbkre_pengesah.Name = "cmbkre_pengesah"
        Me.cmbkre_pengesah.Size = New System.Drawing.Size(250, 24)
        Me.cmbkre_pengesah.TabIndex = 15
        '
        'cmbkre_pemeriksa
        '
        Me.cmbkre_pemeriksa.DropDownHeight = 100
        Me.cmbkre_pemeriksa.FormattingEnabled = True
        Me.cmbkre_pemeriksa.IntegralHeight = False
        Me.cmbkre_pemeriksa.Location = New System.Drawing.Point(127, 51)
        Me.cmbkre_pemeriksa.Name = "cmbkre_pemeriksa"
        Me.cmbkre_pemeriksa.Size = New System.Drawing.Size(250, 24)
        Me.cmbkre_pemeriksa.TabIndex = 14
        '
        'cmbkre_pembuat
        '
        Me.cmbkre_pembuat.DropDownHeight = 100
        Me.cmbkre_pembuat.FormattingEnabled = True
        Me.cmbkre_pembuat.IntegralHeight = False
        Me.cmbkre_pembuat.Location = New System.Drawing.Point(127, 21)
        Me.cmbkre_pembuat.Name = "cmbkre_pembuat"
        Me.cmbkre_pembuat.Size = New System.Drawing.Size(250, 24)
        Me.cmbkre_pembuat.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Pengesah :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Pemeriksa :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(53, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Pembuat :"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.cmbakt_pengesah)
        Me.GroupBox3.Controls.Add(Me.cmbakt_pemeriksa)
        Me.GroupBox3.Controls.Add(Me.cmbakt_pembuat)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 180)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(386, 118)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Laporan Akuntansi"
        Me.GroupBox3.UseCompatibleTextRendering = True
        '
        'cmbakt_pengesah
        '
        Me.cmbakt_pengesah.DropDownHeight = 100
        Me.cmbakt_pengesah.FormattingEnabled = True
        Me.cmbakt_pengesah.IntegralHeight = False
        Me.cmbakt_pengesah.Location = New System.Drawing.Point(127, 81)
        Me.cmbakt_pengesah.Name = "cmbakt_pengesah"
        Me.cmbakt_pengesah.Size = New System.Drawing.Size(250, 24)
        Me.cmbakt_pengesah.TabIndex = 18
        '
        'cmbakt_pemeriksa
        '
        Me.cmbakt_pemeriksa.DropDownHeight = 100
        Me.cmbakt_pemeriksa.FormattingEnabled = True
        Me.cmbakt_pemeriksa.IntegralHeight = False
        Me.cmbakt_pemeriksa.Location = New System.Drawing.Point(127, 51)
        Me.cmbakt_pemeriksa.Name = "cmbakt_pemeriksa"
        Me.cmbakt_pemeriksa.Size = New System.Drawing.Size(250, 24)
        Me.cmbakt_pemeriksa.TabIndex = 17
        '
        'cmbakt_pembuat
        '
        Me.cmbakt_pembuat.DropDownHeight = 100
        Me.cmbakt_pembuat.FormattingEnabled = True
        Me.cmbakt_pembuat.IntegralHeight = False
        Me.cmbakt_pembuat.Location = New System.Drawing.Point(127, 21)
        Me.cmbakt_pembuat.Name = "cmbakt_pembuat"
        Me.cmbakt_pembuat.Size = New System.Drawing.Size(250, 24)
        Me.cmbakt_pembuat.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(45, 84)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 16)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Pengesah :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(42, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 16)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Pemeriksa :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(53, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Pembuat :"
        '
        'petugas_pelaporan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 307)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "petugas_pelaporan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnsimpan As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbtab_pengesah As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtab_pemeriksa As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtab_pembuat As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbkre_pengesah As System.Windows.Forms.ComboBox
    Friend WithEvents cmbkre_pemeriksa As System.Windows.Forms.ComboBox
    Friend WithEvents cmbkre_pembuat As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbakt_pengesah As System.Windows.Forms.ComboBox
    Friend WithEvents cmbakt_pemeriksa As System.Windows.Forms.ComboBox
    Friend WithEvents cmbakt_pembuat As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
