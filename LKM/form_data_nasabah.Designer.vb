<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_data_nasabah
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_data_nasabah))
        Me.gambar_nasabahBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DATASET = New LKM.DATASET()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.gambar_nasabahTableAdapter = New LKM.DATASETTableAdapters.gambar_nasabahTableAdapter()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.gambar_nasabahBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DATASET, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gambar_nasabahBindingSource
        '
        Me.gambar_nasabahBindingSource.DataMember = "gambar_nasabah"
        Me.gambar_nasabahBindingSource.DataSource = Me.DATASET
        '
        'DATASET
        '
        Me.DATASET.DataSetName = "DATASET"
        Me.DATASET.EnforceConstraints = False
        Me.DATASET.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.gambar_nasabahBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "LKM.cetak_form_data_nasabah2.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(581, 357)
        Me.ReportViewer1.TabIndex = 0
        '
        'gambar_nasabahTableAdapter
        '
        Me.gambar_nasabahTableAdapter.ClearBeforeFill = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(159, 60)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Visible = False
        '
        'form_data_nasabah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 357)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "form_data_nasabah"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FORM DATA NASABAH"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gambar_nasabahBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DATASET, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents gambar_nasabahBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DATASET As LKM.DATASET
    Friend WithEvents gambar_nasabahTableAdapter As LKM.DATASETTableAdapters.gambar_nasabahTableAdapter
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
