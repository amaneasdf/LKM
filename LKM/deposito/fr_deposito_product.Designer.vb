﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_deposito_product
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.pnl_bottom = New System.Windows.Forms.Panel()
        Me.pnl_top = New System.Windows.Forms.Panel()
        Me.btnhapus = New System.Windows.Forms.Button()
        Me.btnkoreksi = New System.Windows.Forms.Button()
        Me.btntambah = New System.Windows.Forms.Button()
        Me.btnkeluar = New System.Windows.Forms.Button()
        Me.dgv_list = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.pnl_top.SuspendLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.LKM.My.Resources.Resources.header4
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.lbl_judul)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(909, 49)
        Me.Panel1.TabIndex = 4
        '
        'lbl_judul
        '
        Me.lbl_judul.AutoSize = True
        Me.lbl_judul.BackColor = System.Drawing.Color.Transparent
        Me.lbl_judul.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.ForeColor = System.Drawing.Color.White
        Me.lbl_judul.Location = New System.Drawing.Point(4, 0)
        Me.lbl_judul.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(243, 25)
        Me.lbl_judul.TabIndex = 1
        Me.lbl_judul.Text = "Master Produk Deposito"
        '
        'pnl_bottom
        '
        Me.pnl_bottom.BackColor = System.Drawing.Color.White
        Me.pnl_bottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_bottom.Location = New System.Drawing.Point(0, 497)
        Me.pnl_bottom.Name = "pnl_bottom"
        Me.pnl_bottom.Size = New System.Drawing.Size(909, 50)
        Me.pnl_bottom.TabIndex = 5
        '
        'pnl_top
        '
        Me.pnl_top.BackColor = System.Drawing.Color.White
        Me.pnl_top.Controls.Add(Me.btnhapus)
        Me.pnl_top.Controls.Add(Me.btnkoreksi)
        Me.pnl_top.Controls.Add(Me.btntambah)
        Me.pnl_top.Controls.Add(Me.btnkeluar)
        Me.pnl_top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_top.Location = New System.Drawing.Point(0, 49)
        Me.pnl_top.Name = "pnl_top"
        Me.pnl_top.Size = New System.Drawing.Size(909, 50)
        Me.pnl_top.TabIndex = 6
        '
        'btnhapus
        '
        Me.btnhapus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnhapus.BackColor = System.Drawing.Color.LightBlue
        Me.btnhapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnhapus.Enabled = False
        Me.btnhapus.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnhapus.FlatAppearance.BorderSize = 2
        Me.btnhapus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnhapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnhapus.Image = Global.LKM.My.Resources.Resources.Delete
        Me.btnhapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnhapus.Location = New System.Drawing.Point(509, 0)
        Me.btnhapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnhapus.Name = "btnhapus"
        Me.btnhapus.Size = New System.Drawing.Size(100, 50)
        Me.btnhapus.TabIndex = 12
        Me.btnhapus.Text = "Hapus"
        Me.btnhapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnhapus.UseVisualStyleBackColor = False
        '
        'btnkoreksi
        '
        Me.btnkoreksi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnkoreksi.BackColor = System.Drawing.Color.LightBlue
        Me.btnkoreksi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnkoreksi.Enabled = False
        Me.btnkoreksi.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnkoreksi.FlatAppearance.BorderSize = 2
        Me.btnkoreksi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnkoreksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnkoreksi.Image = Global.LKM.My.Resources.Resources.Edit
        Me.btnkoreksi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnkoreksi.Location = New System.Drawing.Point(609, 0)
        Me.btnkoreksi.Margin = New System.Windows.Forms.Padding(4)
        Me.btnkoreksi.Name = "btnkoreksi"
        Me.btnkoreksi.Size = New System.Drawing.Size(100, 50)
        Me.btnkoreksi.TabIndex = 13
        Me.btnkoreksi.Text = "Koreksi"
        Me.btnkoreksi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnkoreksi.UseVisualStyleBackColor = False
        '
        'btntambah
        '
        Me.btntambah.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btntambah.BackColor = System.Drawing.Color.LightBlue
        Me.btntambah.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btntambah.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btntambah.FlatAppearance.BorderSize = 2
        Me.btntambah.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btntambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btntambah.Image = Global.LKM.My.Resources.Resources.Add
        Me.btntambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btntambah.Location = New System.Drawing.Point(709, 0)
        Me.btntambah.Margin = New System.Windows.Forms.Padding(4)
        Me.btntambah.Name = "btntambah"
        Me.btntambah.Size = New System.Drawing.Size(100, 50)
        Me.btntambah.TabIndex = 14
        Me.btntambah.Text = "Tambah"
        Me.btntambah.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btntambah.UseVisualStyleBackColor = False
        '
        'btnkeluar
        '
        Me.btnkeluar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnkeluar.BackColor = System.Drawing.Color.LightBlue
        Me.btnkeluar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnkeluar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnkeluar.FlatAppearance.BorderSize = 2
        Me.btnkeluar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan
        Me.btnkeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnkeluar.Image = Global.LKM.My.Resources.Resources.Close
        Me.btnkeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnkeluar.Location = New System.Drawing.Point(809, 0)
        Me.btnkeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnkeluar.Name = "btnkeluar"
        Me.btnkeluar.Size = New System.Drawing.Size(100, 50)
        Me.btnkeluar.TabIndex = 15
        Me.btnkeluar.Text = "Keluar"
        Me.btnkeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnkeluar.UseVisualStyleBackColor = False
        '
        'dgv_list
        '
        Me.dgv_list.AllowUserToAddRows = False
        Me.dgv_list.AllowUserToDeleteRows = False
        Me.dgv_list.BackgroundColor = System.Drawing.Color.White
        Me.dgv_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_list.Location = New System.Drawing.Point(0, 99)
        Me.dgv_list.Name = "dgv_list"
        Me.dgv_list.ReadOnly = True
        Me.dgv_list.Size = New System.Drawing.Size(909, 398)
        Me.dgv_list.TabIndex = 7
        '
        'fr_deposito_product
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgv_list)
        Me.Controls.Add(Me.pnl_top)
        Me.Controls.Add(Me.pnl_bottom)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fr_deposito_product"
        Me.Size = New System.Drawing.Size(909, 547)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_top.ResumeLayout(False)
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents pnl_bottom As System.Windows.Forms.Panel
    Friend WithEvents pnl_top As System.Windows.Forms.Panel
    Friend WithEvents dgv_list As System.Windows.Forms.DataGridView
    Friend WithEvents btnhapus As System.Windows.Forms.Button
    Friend WithEvents btnkoreksi As System.Windows.Forms.Button
    Friend WithEvents btntambah As System.Windows.Forms.Button
    Friend WithEvents btnkeluar As System.Windows.Forms.Button

End Class
