<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pindah_afiliasi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pindah_afiliasi))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tno_rekening = New System.Windows.Forms.TextBox()
        Me.tnama_nasabah = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnpindah = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.LKM.My.Resources.Resources.header4
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnkeluar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(461, 49)
        Me.Panel1.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(192, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
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
        Me.btnkeluar.Location = New System.Drawing.Point(361, 0)
        Me.btnkeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(100, 49)
        Me.btnkeluar.TabIndex = 3
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
        Me.Label1.Size = New System.Drawing.Size(148, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pindah Afiliasi"
        '
        'tno_rekening
        '
        Me.tno_rekening.Enabled = False
        Me.tno_rekening.Location = New System.Drawing.Point(5, 56)
        Me.tno_rekening.Name = "tno_rekening"
        Me.tno_rekening.Size = New System.Drawing.Size(150, 22)
        Me.tno_rekening.TabIndex = 5
        '
        'tnama_nasabah
        '
        Me.tnama_nasabah.Enabled = False
        Me.tnama_nasabah.Location = New System.Drawing.Point(5, 84)
        Me.tnama_nasabah.Name = "tnama_nasabah"
        Me.tnama_nasabah.Size = New System.Drawing.Size(450, 22)
        Me.tnama_nasabah.TabIndex = 6
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(5, 133)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(450, 24)
        Me.ComboBox1.TabIndex = 8
        '
        'btnpindah
        '
        Me.btnpindah.BackColor = System.Drawing.Color.LightBlue
        Me.btnpindah.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnpindah.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnpindah.FlatAppearance.BorderSize = 2
        Me.btnpindah.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnpindah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpindah.Image = Global.LKM.My.Resources.Resources.Check_32x32
        Me.btnpindah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnpindah.Location = New System.Drawing.Point(355, 164)
        Me.btnpindah.Margin = New System.Windows.Forms.Padding(4)
        Me.btnpindah.Name = "btnpindah"
        Me.btnpindah.Size = New System.Drawing.Size(100, 49)
        Me.btnpindah.TabIndex = 5
        Me.btnpindah.Text = "Pindah"
        Me.btnpindah.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnpindah.UseVisualStyleBackColor = False
        '
        'pindah_afiliasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 218)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnpindah)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.tnama_nasabah)
        Me.Controls.Add(Me.tno_rekening)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "pindah_afiliasi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnkeluar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tno_rekening As System.Windows.Forms.TextBox
    Friend WithEvents tnama_nasabah As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnpindah As System.Windows.Forms.Button
End Class
