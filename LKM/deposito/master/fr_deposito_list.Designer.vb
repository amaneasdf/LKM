<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_deposito_list
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.dgv_list = New System.Windows.Forms.DataGridView()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.pnl_bottom = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_search = New System.Windows.Forms.Button()
        Me.in_search = New System.Windows.Forms.TextBox()
        Me.bt_del = New System.Windows.Forms.Button()
        Me.bt_edit = New System.Windows.Forms.Button()
        Me.bt_add = New System.Windows.Forms.Button()
        Me.bt_cl = New System.Windows.Forms.Button()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_list
        '
        Me.dgv_list.AllowUserToAddRows = False
        Me.dgv_list.AllowUserToDeleteRows = False
        Me.dgv_list.BackgroundColor = System.Drawing.Color.White
        Me.dgv_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_list.Location = New System.Drawing.Point(0, 84)
        Me.dgv_list.MultiSelect = False
        Me.dgv_list.Name = "dgv_list"
        Me.dgv_list.ReadOnly = True
        Me.dgv_list.RowHeadersVisible = False
        Me.dgv_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_list.Size = New System.Drawing.Size(898, 413)
        Me.dgv_list.StandardTab = True
        Me.dgv_list.TabIndex = 6
        '
        'lbl_judul
        '
        Me.lbl_judul.AutoSize = True
        Me.lbl_judul.BackColor = System.Drawing.Color.Transparent
        Me.lbl_judul.Font = New System.Drawing.Font("Open Sans", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.ForeColor = System.Drawing.Color.Black
        Me.lbl_judul.Location = New System.Drawing.Point(4, 6)
        Me.lbl_judul.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(370, 26)
        Me.lbl_judul.TabIndex = 1
        Me.lbl_judul.Text = "Master Rekening Simpanan Berjangka"
        '
        'pnl_bottom
        '
        Me.pnl_bottom.BackColor = System.Drawing.Color.LightCyan
        Me.pnl_bottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_bottom.Location = New System.Drawing.Point(0, 497)
        Me.pnl_bottom.Name = "pnl_bottom"
        Me.pnl_bottom.Size = New System.Drawing.Size(898, 50)
        Me.pnl_bottom.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Azure
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.bt_search)
        Me.Panel1.Controls.Add(Me.in_search)
        Me.Panel1.Controls.Add(Me.bt_del)
        Me.Panel1.Controls.Add(Me.bt_edit)
        Me.Panel1.Controls.Add(Me.bt_add)
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_judul)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(898, 84)
        Me.Panel1.TabIndex = 8
        '
        'bt_search
        '
        Me.bt_search.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_search.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.bt_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_search.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_search.ForeColor = System.Drawing.Color.White
        Me.bt_search.Location = New System.Drawing.Point(303, 44)
        Me.bt_search.Name = "bt_search"
        Me.bt_search.Size = New System.Drawing.Size(75, 29)
        Me.bt_search.TabIndex = 21
        Me.bt_search.Text = "Filter"
        Me.bt_search.UseVisualStyleBackColor = False
        '
        'in_search
        '
        Me.in_search.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_search.Location = New System.Drawing.Point(9, 44)
        Me.in_search.Name = "in_search"
        Me.in_search.Size = New System.Drawing.Size(294, 29)
        Me.in_search.TabIndex = 20
        '
        'bt_del
        '
        Me.bt_del.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_del.BackColor = System.Drawing.Color.LightBlue
        Me.bt_del.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_del.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.bt_del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.bt_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_del.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.bt_del.Image = Global.LKM.My.Resources.Resources.Delete
        Me.bt_del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_del.Location = New System.Drawing.Point(493, 37)
        Me.bt_del.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_del.Name = "bt_del"
        Me.bt_del.Size = New System.Drawing.Size(100, 45)
        Me.bt_del.TabIndex = 16
        Me.bt_del.Text = "Hapus"
        Me.bt_del.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_del.UseVisualStyleBackColor = False
        '
        'bt_edit
        '
        Me.bt_edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_edit.BackColor = System.Drawing.Color.LightBlue
        Me.bt_edit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_edit.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.bt_edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.bt_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_edit.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.bt_edit.Image = Global.LKM.My.Resources.Resources.Edit
        Me.bt_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_edit.Location = New System.Drawing.Point(594, 37)
        Me.bt_edit.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_edit.Name = "bt_edit"
        Me.bt_edit.Size = New System.Drawing.Size(100, 45)
        Me.bt_edit.TabIndex = 17
        Me.bt_edit.Text = "Koreksi"
        Me.bt_edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_edit.UseVisualStyleBackColor = False
        '
        'bt_add
        '
        Me.bt_add.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_add.BackColor = System.Drawing.Color.LightBlue
        Me.bt_add.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_add.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.bt_add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.bt_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_add.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.bt_add.Image = Global.LKM.My.Resources.Resources.Add
        Me.bt_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_add.Location = New System.Drawing.Point(695, 37)
        Me.bt_add.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_add.Name = "bt_add"
        Me.bt_add.Size = New System.Drawing.Size(100, 45)
        Me.bt_add.TabIndex = 18
        Me.bt_add.Text = "Tambah"
        Me.bt_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_add.UseVisualStyleBackColor = False
        '
        'bt_cl
        '
        Me.bt_cl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_cl.BackColor = System.Drawing.Color.LightBlue
        Me.bt_cl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_cl.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.bt_cl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.bt_cl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cl.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold)
        Me.bt_cl.Image = Global.LKM.My.Resources.Resources.Close
        Me.bt_cl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_cl.Location = New System.Drawing.Point(796, 37)
        Me.bt_cl.Margin = New System.Windows.Forms.Padding(4)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(100, 45)
        Me.bt_cl.TabIndex = 19
        Me.bt_cl.Text = "Keluar"
        Me.bt_cl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'fr_deposito_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgv_list)
        Me.Controls.Add(Me.pnl_bottom)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fr_deposito_list"
        Me.Size = New System.Drawing.Size(898, 547)
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv_list As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents pnl_bottom As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_del As System.Windows.Forms.Button
    Friend WithEvents bt_edit As System.Windows.Forms.Button
    Friend WithEvents bt_add As System.Windows.Forms.Button
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents bt_search As System.Windows.Forms.Button
    Friend WithEvents in_search As System.Windows.Forms.TextBox

End Class
