<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuUtama
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuUtama))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.mnlaporan = New System.Windows.Forms.Button()
        Me.mnproses = New System.Windows.Forms.Button()
        Me.mnorder = New System.Windows.Forms.Button()
        Me.mnuser = New System.Windows.Forms.Button()
        Me.mnplanggan = New System.Windows.Forms.Button()
        Me.mnpaket = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.about = New System.Windows.Forms.Button()
        Me.system = New System.Windows.Forms.Button()
        Me.server = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.keluar = New System.Windows.Forms.Button()
        Me.Logout = New System.Windows.Forms.Button()
        Me.gantipassword = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 439)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel1.Text = "Ready"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(166, 17)
        Me.ToolStripStatusLabel2.Text = "Hak Akses: ??? | Pengguna: ???"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(216, 17)
        Me.ToolStripStatusLabel3.Text = "Jam: 21.27, Minggu | 27 November 2022"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(784, 100)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.mnlaporan)
        Me.TabPage1.Controls.Add(Me.mnproses)
        Me.TabPage1.Controls.Add(Me.mnorder)
        Me.TabPage1.Controls.Add(Me.mnuser)
        Me.TabPage1.Controls.Add(Me.mnplanggan)
        Me.TabPage1.Controls.Add(Me.mnpaket)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(776, 74)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Menu"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'mnlaporan
        '
        Me.mnlaporan.Location = New System.Drawing.Point(432, 5)
        Me.mnlaporan.Name = "mnlaporan"
        Me.mnlaporan.Size = New System.Drawing.Size(75, 65)
        Me.mnlaporan.TabIndex = 5
        Me.mnlaporan.Text = "Laporan"
        Me.mnlaporan.UseVisualStyleBackColor = True
        '
        'mnproses
        '
        Me.mnproses.Location = New System.Drawing.Point(351, 5)
        Me.mnproses.Name = "mnproses"
        Me.mnproses.Size = New System.Drawing.Size(75, 65)
        Me.mnproses.TabIndex = 4
        Me.mnproses.Text = "Proses"
        Me.mnproses.UseVisualStyleBackColor = True
        '
        'mnorder
        '
        Me.mnorder.Location = New System.Drawing.Point(272, 5)
        Me.mnorder.Name = "mnorder"
        Me.mnorder.Size = New System.Drawing.Size(75, 65)
        Me.mnorder.TabIndex = 3
        Me.mnorder.Text = "Order"
        Me.mnorder.UseVisualStyleBackColor = True
        '
        'mnuser
        '
        Me.mnuser.Location = New System.Drawing.Point(168, 3)
        Me.mnuser.Name = "mnuser"
        Me.mnuser.Size = New System.Drawing.Size(75, 65)
        Me.mnuser.TabIndex = 2
        Me.mnuser.Text = "User"
        Me.mnuser.UseVisualStyleBackColor = True
        '
        'mnplanggan
        '
        Me.mnplanggan.Location = New System.Drawing.Point(87, 4)
        Me.mnplanggan.Name = "mnplanggan"
        Me.mnplanggan.Size = New System.Drawing.Size(75, 65)
        Me.mnplanggan.TabIndex = 1
        Me.mnplanggan.Text = "Pelanggan"
        Me.mnplanggan.UseVisualStyleBackColor = True
        '
        'mnpaket
        '
        Me.mnpaket.Location = New System.Drawing.Point(6, 4)
        Me.mnpaket.Name = "mnpaket"
        Me.mnpaket.Size = New System.Drawing.Size(75, 65)
        Me.mnpaket.TabIndex = 0
        Me.mnpaket.Text = "Paket"
        Me.mnpaket.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.about)
        Me.TabPage2.Controls.Add(Me.system)
        Me.TabPage2.Controls.Add(Me.server)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(776, 74)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Pengaturan"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'about
        '
        Me.about.Location = New System.Drawing.Point(166, 3)
        Me.about.Name = "about"
        Me.about.Size = New System.Drawing.Size(75, 65)
        Me.about.TabIndex = 3
        Me.about.Text = "About"
        Me.about.UseVisualStyleBackColor = True
        '
        'system
        '
        Me.system.Location = New System.Drawing.Point(86, 4)
        Me.system.Name = "system"
        Me.system.Size = New System.Drawing.Size(75, 65)
        Me.system.TabIndex = 2
        Me.system.Text = "Sistem"
        Me.system.UseVisualStyleBackColor = True
        '
        'server
        '
        Me.server.Location = New System.Drawing.Point(6, 4)
        Me.server.Name = "server"
        Me.server.Size = New System.Drawing.Size(75, 65)
        Me.server.TabIndex = 1
        Me.server.Text = "Server"
        Me.server.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.keluar)
        Me.TabPage3.Controls.Add(Me.Logout)
        Me.TabPage3.Controls.Add(Me.gantipassword)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(776, 74)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Operasi"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'keluar
        '
        Me.keluar.Location = New System.Drawing.Point(170, 3)
        Me.keluar.Name = "keluar"
        Me.keluar.Size = New System.Drawing.Size(75, 65)
        Me.keluar.TabIndex = 3
        Me.keluar.Text = "Keluar"
        Me.keluar.UseVisualStyleBackColor = True
        '
        'Logout
        '
        Me.Logout.Location = New System.Drawing.Point(89, 3)
        Me.Logout.Name = "Logout"
        Me.Logout.Size = New System.Drawing.Size(75, 65)
        Me.Logout.TabIndex = 2
        Me.Logout.Text = "Logout"
        Me.Logout.UseVisualStyleBackColor = True
        '
        'gantipassword
        '
        Me.gantipassword.Location = New System.Drawing.Point(8, 3)
        Me.gantipassword.Name = "gantipassword"
        Me.gantipassword.Size = New System.Drawing.Size(75, 65)
        Me.gantipassword.TabIndex = 1
        Me.gantipassword.Text = "Ganti Password"
        Me.gantipassword.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'MenuUtama
        '
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MenuUtama"
        Me.Text = "MenuUtama"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents mnlaporan As System.Windows.Forms.Button
    Friend WithEvents mnproses As System.Windows.Forms.Button
    Friend WithEvents mnorder As System.Windows.Forms.Button
    Friend WithEvents mnuser As System.Windows.Forms.Button
    Friend WithEvents mnplanggan As System.Windows.Forms.Button
    Friend WithEvents mnpaket As System.Windows.Forms.Button
    Friend WithEvents about As System.Windows.Forms.Button
    Friend WithEvents system As System.Windows.Forms.Button
    Friend WithEvents server As System.Windows.Forms.Button
    Friend WithEvents keluar As System.Windows.Forms.Button
    Friend WithEvents Logout As System.Windows.Forms.Button
    Friend WithEvents gantipassword As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
