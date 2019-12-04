<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class laporan_nominatif_bunga_tabungan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(laporan_nominatif_bunga_tabungan))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DATASET = New LKM.DATASET()
        Me.nominatif_bunga_tabunganBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.noinatif_bunga_tabunganTableAdapter = New LKM.DATASETTableAdapters.noinatif_bunga_tabunganTableAdapter()
        CType(Me.DATASET, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nominatif_bunga_tabunganBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.nominatif_bunga_tabunganBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "LKM.nominatif_bunga_tabungan.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(379, 322)
        Me.ReportViewer1.TabIndex = 0
        '
        'DATASET
        '
        Me.DATASET.DataSetName = "DATASET"
        Me.DATASET.EnforceConstraints = False
        Me.DATASET.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'nominatif_bunga_tabunganBindingSource
        '
        Me.nominatif_bunga_tabunganBindingSource.DataMember = "nominatif_bunga_tabungan"
        Me.nominatif_bunga_tabunganBindingSource.DataSource = Me.DATASET
        '
        'noinatif_bunga_tabunganTableAdapter
        '
        Me.noinatif_bunga_tabunganTableAdapter.ClearBeforeFill = True
        '
        'laporan_nominatif_bunga_tabungan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 322)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "laporan_nominatif_bunga_tabungan"
        Me.Text = "LAPORAN"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DATASET, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nominatif_bunga_tabunganBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents nominatif_bunga_tabunganBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DATASET As LKM.DATASET
    Friend WithEvents noinatif_bunga_tabunganTableAdapter As LKM.DATASETTableAdapters.noinatif_bunga_tabunganTableAdapter
End Class
