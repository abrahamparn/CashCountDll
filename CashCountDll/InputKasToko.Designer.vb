<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputKasToko
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
        Me.label_station_number = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.label_input = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Station_label = New System.Windows.Forms.Label()
        Me.kas_text_box = New System.Windows.Forms.TextBox()
        Me.button_accept_kas = New System.Windows.Forms.Button()
        Me.button_hapus_kas = New System.Windows.Forms.Button()
        Me.dgv_kas_station = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgv_kas_station, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'label_station_number
        '
        Me.label_station_number.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label_station_number.AutoSize = True
        Me.label_station_number.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label_station_number.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_station_number.Location = New System.Drawing.Point(132, 225)
        Me.label_station_number.Name = "label_station_number"
        Me.label_station_number.Size = New System.Drawing.Size(0, 25)
        Me.label_station_number.TabIndex = 0
        Me.label_station_number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.label_input, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dgv_kas_station, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.48619!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.51381!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 213.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(589, 433)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'label_input
        '
        Me.label_input.AutoSize = True
        Me.label_input.Dock = System.Windows.Forms.DockStyle.Fill
        Me.label_input.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label_input.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_input.Location = New System.Drawing.Point(3, 0)
        Me.label_input.Name = "label_input"
        Me.label_input.Size = New System.Drawing.Size(583, 86)
        Me.label_input.TabIndex = 0
        Me.label_input.Text = "KAS STATION TOKO INDOMARET"
        Me.label_input.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.75472!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.68096!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.72556!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Station_label, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.kas_text_box, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.button_accept_kas, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.button_hapus_kas, 3, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 89)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(583, 71)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Station_label
        '
        Me.Station_label.AutoSize = True
        Me.Station_label.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Station_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Station_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Station_label.Location = New System.Drawing.Point(3, 28)
        Me.Station_label.Name = "Station_label"
        Me.Station_label.Size = New System.Drawing.Size(114, 43)
        Me.Station_label.TabIndex = 0
        Me.Station_label.Text = "Station: "
        Me.Station_label.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'kas_text_box
        '
        Me.kas_text_box.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.kas_text_box.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kas_text_box.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kas_text_box.Location = New System.Drawing.Point(123, 31)
        Me.kas_text_box.Name = "kas_text_box"
        Me.kas_text_box.Size = New System.Drawing.Size(236, 28)
        Me.kas_text_box.TabIndex = 1
        '
        'button_accept_kas
        '
        Me.button_accept_kas.BackColor = System.Drawing.Color.PaleTurquoise
        Me.button_accept_kas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.button_accept_kas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button_accept_kas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button_accept_kas.Location = New System.Drawing.Point(370, 36)
        Me.button_accept_kas.Margin = New System.Windows.Forms.Padding(8)
        Me.button_accept_kas.Name = "button_accept_kas"
        Me.button_accept_kas.Size = New System.Drawing.Size(98, 27)
        Me.button_accept_kas.TabIndex = 2
        Me.button_accept_kas.Text = "OK"
        Me.button_accept_kas.UseVisualStyleBackColor = False
        '
        'button_hapus_kas
        '
        Me.button_hapus_kas.BackColor = System.Drawing.Color.Tomato
        Me.button_hapus_kas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.button_hapus_kas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button_hapus_kas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button_hapus_kas.Location = New System.Drawing.Point(484, 36)
        Me.button_hapus_kas.Margin = New System.Windows.Forms.Padding(8)
        Me.button_hapus_kas.Name = "button_hapus_kas"
        Me.button_hapus_kas.Size = New System.Drawing.Size(91, 27)
        Me.button_hapus_kas.TabIndex = 3
        Me.button_hapus_kas.Text = "HAPUS"
        Me.button_hapus_kas.UseVisualStyleBackColor = False
        '
        'dgv_kas_station
        '
        Me.dgv_kas_station.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.dgv_kas_station.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_kas_station.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_kas_station.Location = New System.Drawing.Point(3, 166)
        Me.dgv_kas_station.Name = "dgv_kas_station"
        Me.dgv_kas_station.Size = New System.Drawing.Size(583, 207)
        Me.dgv_kas_station.TabIndex = 2
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.80746!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.19255!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Button1, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Button2, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 379)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(583, 51)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(465, 8)
        Me.Button1.Margin = New System.Windows.Forms.Padding(8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 35)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "SIMPAN"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkSalmon
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(332, 8)
        Me.Button2.Margin = New System.Windows.Forms.Padding(8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(117, 35)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "ULANGI"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'InputKasToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 433)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.label_station_number)
        Me.Name = "InputKasToko"
        Me.Text = "Form1"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.dgv_kas_station, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents label_station_number As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents label_input As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Station_label As Label
    Friend WithEvents kas_text_box As TextBox
    Friend WithEvents button_accept_kas As Button
    Friend WithEvents button_hapus_kas As Button
    Friend WithEvents dgv_kas_station As DataGridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
