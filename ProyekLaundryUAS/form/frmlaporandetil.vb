Public Class frmlaporandetil

    Dim Tampung As DataTable
    Public ID As Integer

    Sub Tampil()
        Tampung = EksekusiSQL("SELECT a.id_transaksi,a.id,a.id_paket,b.nama_paket,a.qty,a.harga,a.keterangan,(a.qty*a.harga)-a.diskon as total_harga FROM transaksi_detail a LEFT JOIN paket b on a.id_paket=b.id WHERE a.id_transaksi=" & ID & "")
        DataGridView1.DataSource = Tampung
        DataGridView1.Columns("id_transaksi").Visible = False
    End Sub

    Sub Cetak()
        CetakOrder(ID)
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

    Private Sub frmlaporandetil_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case e.Control And Keys.P
                Cetak()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub

    Private Sub frmlaporandetil_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Tampil()
    End Sub

    Private Sub ToolStripStatusLabel3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel3.Click
        Cetak()
    End Sub

    Private Sub ToolStripStatusLabel6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel6.Click
        Tutup()
    End Sub
End Class