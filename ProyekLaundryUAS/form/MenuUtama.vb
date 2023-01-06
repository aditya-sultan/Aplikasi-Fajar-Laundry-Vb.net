Public Class MenuUtama

    Private Sub MenuUtama_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.IsMdiContainer = True
        ToolStripStatusLabel2.Text = "Hak Akses: " & My.Settings.logRole & " | Pengguna: " & My.Settings.logNama & ""
    End Sub

    Private Sub mnuser_Click(sender As System.Object, e As System.EventArgs) Handles mnuser.Click
        With formmasteruser
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub mnpaket_Click(sender As System.Object, e As System.EventArgs) Handles mnpaket.Click
        With formmasterpaket
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub mnplanggan_Click(sender As System.Object, e As System.EventArgs) Handles mnplanggan.Click
        With formmasterpelanggan
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub mnorder_Click(sender As System.Object, e As System.EventArgs) Handles mnorder.Click
        With formtransaksiorder
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub server_Click(sender As System.Object, e As System.EventArgs) Handles server.Click
        With formkonfigurasiserver
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub gantipassword_Click(sender As System.Object, e As System.EventArgs) Handles gantipassword.Click
        'ganti password
    End Sub

    Private Sub Logout_Click(sender As System.Object, e As System.EventArgs) Handles Logout.Click
        If MessageBox.Show("Yakin ingin keluar?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            formsetuplogin.Show()
            Me.Close()
        End If
    End Sub

    Private Sub keluar_Click(sender As System.Object, e As System.EventArgs) Handles keluar.Click
        If MessageBox.Show("Yakin ingin keluar aplikasi?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel3.Text = "Jam: " & Format(Now, "HH:mm") & "," & Format(Now, "ddd | dd MMMM yyyy") & ""
    End Sub

    Private Sub mnproses_Click(sender As System.Object, e As System.EventArgs) Handles mnproses.Click
        With frmtransaksipembayaran
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub mnlaporan_Click(sender As System.Object, e As System.EventArgs) Handles mnlaporan.Click
        With frmlaporan
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub
End Class