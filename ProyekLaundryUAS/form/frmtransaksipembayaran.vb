Public Class frmtransaksipembayaran

    Dim Tampung As DataTable

    Sub Tampil()
        Tampung = EksekusiSQL("SELECT a.id, a.kode_invoice, a.id_member, b.nama as nama_pelanggan,a.tanggal, a.deadline,a.tanggal_bayar,a.biaya_tambahan,a.diskon,a.status,a.dibayar,a.id_user,c.nama as kasir FROM transaksi a LEFT JOIN member b ON a.id_member=b.id LEFT JOIN user c ON a.id_user=c.id WHERE a.status='" & txtStatus.Text & "'")
        DataGridView1.DataSource = Tampung
    End Sub

    Sub Proses()
        If DataGridView1.RowCount <= 0 Then
            MessageBox.Show("Data yang dipilih tidak ada", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim BarisIndex As Integer = DataGridView1.CurrentRow.Index
        If DataGridView1.Rows(BarisIndex).Cells("status").Value = "Baru" Then
            'proses
            If MessageBox.Show("Yakin Lanjutkan Ke Tahap Proses?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Dim ID As Integer = DataGridView1.Rows(BarisIndex).Cells("id").Value
                EksekusiSQL("UPDATE transaksi SET status='Proses' WHERE id='" & ID & "'")
                Tampil()
                MessageBox.Show("Tahapan Proses Berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Data yang dipilih harus memiliki status baru", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Sub Selesai()
        If DataGridView1.RowCount <= 0 Then
            MessageBox.Show("Data yang dipilih tidak ada", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim BarisIndex As Integer = DataGridView1.CurrentRow.Index
        If DataGridView1.Rows(BarisIndex).Cells("status").Value = "Proses" Then
            'proses
            If MessageBox.Show("Yakin Lanjutkan Ke Tahap Selesai?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Dim ID As Integer = DataGridView1.Rows(BarisIndex).Cells("id").Value
                EksekusiSQL("UPDATE transaksi SET status='Selesai' WHERE id='" & ID & "'")
                Tampil()
                MessageBox.Show("Tahapan Selesai Berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Data yang dipilih harus memiliki status Proses", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Sub Pembayaran()
        If DataGridView1.RowCount <= 0 Then
            MessageBox.Show("Data yang dipilih tidak ada", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim BarisIndex As Integer = DataGridView1.CurrentRow.Index
        If DataGridView1.Rows(BarisIndex).Cells("status").Value = "Selesai" Then
            'proses
            If MessageBox.Show("Yakin Lanjutkan Ke Tahap Pembayaran?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Dim ID As Integer = DataGridView1.Rows(BarisIndex).Cells("id").Value
                EksekusiSQL("UPDATE transaksi SET tanggal_bayar='" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "', status='Diambil', dibayar='Dibayar' WHERE id='" & ID & "'")
                Tampil()
                MessageBox.Show("Tahapan Pembayaran Berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CetakOrder(ID)
            End If
        Else
            MessageBox.Show("Data yang dipilih harus memiliki status Selesai", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Sub Tutup()
        Me.Close()
    End Sub

    Private Sub frmtransaksipembayaran_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Tampil()
            Case Keys.F1
                Proses()
            Case Keys.F2
                Selesai()
            Case Keys.F3
                Pembayaran()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub

    Private Sub frmtransaksipembayaran_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtStatus.SelectedIndex = 0
        Tampil()
    End Sub

    Private Sub txtStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles txtStatus.SelectedIndexChanged
        Tampil()
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        Tampil()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        Proses()
    End Sub

    Private Sub ToolStripStatusLabel3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel3.Click
        Selesai()
    End Sub

    Private Sub ToolStripStatusLabel4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel4.Click
        Pembayaran()
    End Sub

    Private Sub ToolStripStatusLabel6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel6.Click
        Tutup()
    End Sub
End Class