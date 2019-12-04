<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ganti_password
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ganti_password))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnsimpan = New System.Windows.Forms.Button()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tnama_alias = New System.Windows.Forms.TextBox()
        Me.cmbgrup_akses = New System.Windows.Forms.ComboBox()
        Me.tpassword_lama = New System.Windows.Forms.TextBox()
        Me.tpassword_baru = New System.Windows.Forms.TextBox()
        Me.tulangi_password = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(383, 49)
        Me.Panel1.TabIndex = 15
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
        Me.btnsimpan.Location = New System.Drawing.Point(183, 0)
        Me.btnsimpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnsimpan.Name = "btnsimpan"
        Me.btnsimpan.Size = New System.Drawing.Size(100, 49)
        Me.btnsimpan.TabIndex = 15
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
        Me.btnkeluar.Location = New System.Drawing.Point(283, 0)
        Me.btnkeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(100, 49)
        Me.btnkeluar.TabIndex = 16
        Me.btnkeluar.Text = "Keluar"
        Me.btnkeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnkeluar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ganti Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Nama Alias / Username :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(85, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Grup Akses :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(58, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Password Lama :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(64, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Password Baru :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(53, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Ulangi Password :"
        '
        'tnama_alias
        '
        Me.tnama_alias.Enabled = False
        Me.tnama_alias.Location = New System.Drawing.Point(175, 56)
        Me.tnama_alias.Name = "tnama_alias"
        Me.tnama_alias.Size = New System.Drawing.Size(150, 22)
        Me.tnama_alias.TabIndex = 10
        '
        'cmbgrup_akses
        '
        Me.cmbgrup_akses.DropDownHeight = 100
        Me.cmbgrup_akses.Enabled = False
        Me.cmbgrup_akses.FormattingEnabled = True
        Me.cmbgrup_akses.IntegralHeight = False
        Me.cmbgrup_akses.Location = New System.Drawing.Point(175, 84)
        Me.cmbgrup_akses.Name = "cmbgrup_akses"
        Me.cmbgrup_akses.Size = New System.Drawing.Size(200, 24)
        Me.cmbgrup_akses.TabIndex = 11
        '
        'tpassword_lama
        '
        Me.tpassword_lama.Location = New System.Drawing.Point(175, 114)
        Me.tpassword_lama.MaxLength = 10
        Me.tpassword_lama.Name = "tpassword_lama"
        Me.tpassword_lama.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tpassword_lama.Size = New System.Drawing.Size(100, 22)
        Me.tpassword_lama.TabIndex = 12
        '
        'tpassword_baru
        '
        Me.tpassword_baru.Location = New System.Drawing.Point(175, 142)
        Me.tpassword_baru.MaxLength = 10
        Me.tpassword_baru.Name = "tpassword_baru"
        Me.tpassword_baru.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tpassword_baru.Size = New System.Drawing.Size(100, 22)
        Me.tpassword_baru.TabIndex = 13
        '
        'tulangi_password
        '
        Me.tulangi_password.Location = New System.Drawing.Point(175, 170)
        Me.tulangi_password.MaxLength = 10
        Me.tulangi_password.Name = "tulangi_password"
        Me.tulangi_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tulangi_password.Size = New System.Drawing.Size(100, 22)
        Me.tulangi_password.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(281, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 16)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "a"
        Me.Label4.Visible = False
        '
        'ganti_password
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 198)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tulangi_password)
        Me.Controls.Add(Me.tpassword_baru)
        Me.Controls.Add(Me.tpassword_lama)
        Me.Controls.Add(Me.cmbgrup_akses)
        Me.Controls.Add(Me.tnama_alias)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ganti_password"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnsimpan As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tnama_alias As System.Windows.Forms.TextBox
    Friend WithEvents cmbgrup_akses As System.Windows.Forms.ComboBox
    Friend WithEvents tpassword_lama As System.Windows.Forms.TextBox
    Friend WithEvents tpassword_baru As System.Windows.Forms.TextBox
    Friend WithEvents tulangi_password As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
