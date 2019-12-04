<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class browser_transaksi_tabungan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(browser_transaksi_tabungan))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tjumlahrow = New System.Windows.Forms.TextBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnexport = New System.Windows.Forms.Button()
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.btnreversal = New System.Windows.Forms.Button()
        Me.btnvalidasi = New System.Windows.Forms.Button()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbproduk = New System.Windows.Forms.ComboBox()
        Me.ttarik_o = New System.Windows.Forms.TextBox()
        Me.ttarik_t = New System.Windows.Forms.TextBox()
        Me.tsetor_o = New System.Windows.Forms.TextBox()
        Me.tsetor_t = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
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
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1073, 49)
        Me.Panel1.TabIndex = 7
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(873, 12)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(153, 22)
        Me.DateTimePicker2.TabIndex = 16
        Me.DateTimePicker2.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(673, 12)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(137, 22)
        Me.DateTimePicker1.TabIndex = 15
        Me.DateTimePicker1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(563, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 14
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
        Me.Label1.Text = "Browse Transaksi Tabungan"
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
        'ListView2
        '
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(0, 368)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(1073, 163)
        Me.ListView2.TabIndex = 9
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.btnexport)
        Me.Panel3.Controls.Add(Me.btnrefresh)
        Me.Panel3.Controls.Add(Me.btnreversal)
        Me.Panel3.Controls.Add(Me.btnvalidasi)
        Me.Panel3.Controls.Add(Me.btnkeluar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 319)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1073, 49)
        Me.Panel3.TabIndex = 11
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
        Me.btnexport.Location = New System.Drawing.Point(563, 0)
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
        Me.btnrefresh.Location = New System.Drawing.Point(663, 0)
        Me.btnrefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(100, 49)
        Me.btnrefresh.TabIndex = 11
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'btnreversal
        '
        Me.btnreversal.BackColor = System.Drawing.Color.LightBlue
        Me.btnreversal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnreversal.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnreversal.Enabled = False
        Me.btnreversal.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnreversal.FlatAppearance.BorderSize = 2
        Me.btnreversal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnreversal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreversal.Image = CType(resources.GetObject("btnreversal.Image"), System.Drawing.Image)
        Me.btnreversal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnreversal.Location = New System.Drawing.Point(763, 0)
        Me.btnreversal.Margin = New System.Windows.Forms.Padding(4)
        Me.btnreversal.Name = "btnreversal"
        Me.btnreversal.Size = New System.Drawing.Size(110, 49)
        Me.btnreversal.TabIndex = 10
        Me.btnreversal.Text = "Reversal"
        Me.btnreversal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnreversal.UseVisualStyleBackColor = False
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
        Me.Panel2.Controls.Add(Me.ttarik_o)
        Me.Panel2.Controls.Add(Me.ttarik_t)
        Me.Panel2.Controls.Add(Me.tsetor_o)
        Me.Panel2.Controls.Add(Me.tsetor_t)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.tjumlahrow)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 257)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1073, 62)
        Me.Panel2.TabIndex = 12
        '
        'cmbproduk
        '
        Me.cmbproduk.BackColor = System.Drawing.SystemColors.Window
        Me.cmbproduk.DropDownHeight = 100
        Me.cmbproduk.FormattingEnabled = True
        Me.cmbproduk.IntegralHeight = False
        Me.cmbproduk.Location = New System.Drawing.Point(861, 9)
        Me.cmbproduk.Name = "cmbproduk"
        Me.cmbproduk.Size = New System.Drawing.Size(200, 24)
        Me.cmbproduk.TabIndex = 22
        '
        'ttarik_o
        '
        Me.ttarik_o.BackColor = System.Drawing.SystemColors.Window
        Me.ttarik_o.Enabled = False
        Me.ttarik_o.ForeColor = System.Drawing.Color.Black
        Me.ttarik_o.Location = New System.Drawing.Point(434, 34)
        Me.ttarik_o.Name = "ttarik_o"
        Me.ttarik_o.Size = New System.Drawing.Size(150, 22)
        Me.ttarik_o.TabIndex = 21
        Me.ttarik_o.Text = "0"
        Me.ttarik_o.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ttarik_t
        '
        Me.ttarik_t.BackColor = System.Drawing.SystemColors.Window
        Me.ttarik_t.Enabled = False
        Me.ttarik_t.ForeColor = System.Drawing.Color.Black
        Me.ttarik_t.Location = New System.Drawing.Point(434, 6)
        Me.ttarik_t.Name = "ttarik_t"
        Me.ttarik_t.Size = New System.Drawing.Size(150, 22)
        Me.ttarik_t.TabIndex = 20
        Me.ttarik_t.Text = "0"
        Me.ttarik_t.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tsetor_o
        '
        Me.tsetor_o.BackColor = System.Drawing.SystemColors.Window
        Me.tsetor_o.Enabled = False
        Me.tsetor_o.ForeColor = System.Drawing.Color.Black
        Me.tsetor_o.Location = New System.Drawing.Point(166, 34)
        Me.tsetor_o.Name = "tsetor_o"
        Me.tsetor_o.Size = New System.Drawing.Size(150, 22)
        Me.tsetor_o.TabIndex = 19
        Me.tsetor_o.Text = "0"
        Me.tsetor_o.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tsetor_t
        '
        Me.tsetor_t.BackColor = System.Drawing.SystemColors.Window
        Me.tsetor_t.Enabled = False
        Me.tsetor_t.ForeColor = System.Drawing.Color.Black
        Me.tsetor_t.Location = New System.Drawing.Point(166, 6)
        Me.tsetor_t.Name = "tsetor_t"
        Me.tsetor_t.Size = New System.Drawing.Size(150, 22)
        Me.tsetor_t.TabIndex = 18
        Me.tsetor_t.Text = "0"
        Me.tsetor_t.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(363, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 16)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Tarik (O) :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(363, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Tarik (T) :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(93, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Setor (O) :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(94, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Setor (T) :"
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
        Me.ListView1.TabIndex = 13
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'browser_transaksi_tabungan
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
        Me.Name = "browser_transaksi_tabungan"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnexport As System.Windows.Forms.Button
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnreversal As System.Windows.Forms.Button
    Friend WithEvents btnvalidasi As System.Windows.Forms.Button
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents tjumlahrow As System.Windows.Forms.TextBox
    Friend WithEvents cmbproduk As System.Windows.Forms.ComboBox
    Friend WithEvents ttarik_o As System.Windows.Forms.TextBox
    Friend WithEvents ttarik_t As System.Windows.Forms.TextBox
    Friend WithEvents tsetor_o As System.Windows.Forms.TextBox
    Friend WithEvents tsetor_t As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
