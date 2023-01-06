Public Class frmlaporan

    Dim Tampung As DataTable
    Dim TotalOmset As Double

    Sub HitungTotal()
        TotalOmset = 0
        For Each Isi In Tampung.Select()
            Dim TotalHarga As Double = EksekusiSQL("SELECT SUM((a.qty*a.harga)-a.diskon) as total_harga FROM transaksi_detail a WHERE a.id_transaksi = " & Isi.Item("id") & "").Select()(0).Item("total_harga")
            Dim TotalBiaya As Double = TotalHarga + Isi.Item("biaya_tambahan")
            Isi.Item("total_harga") = TotalHarga
            Isi.Item("total_biaya") = TotalBiaya
            TotalOmset = TotalOmset + TotalBiaya
        Next
        txtTotalOmset.Text = "Total Omset: Rp." & Format(TotalOmset, "#,##0") & ",-"
    End Sub

    Sub Tampil()

        Select Case My.Settings.logRole
            Case "Admin"
                Tampung = EksekusiSQL("SELECT a.tanggal,a.id, a.kode_invoice, a.id_member, b.nama as nama_pelanggan, a.deadline,a.tanggal_bayar,0.00 AS total_harga,a.biaya_tambahan,a.diskon,0.00 AS total_biaya,a.status,a.dibayar,a.id_user,c.nama as kasir FROM transaksi a LEFT JOIN member b ON a.id_member=b.id LEFT JOIN user c ON a.id_user=c.id WHERE date_format(a.tanggal, '%Y-%m-%d') BETWEEN '" & Format(txtTanggalAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(txtTanggalAkhir.Value, "yyyy-MM-dd") & "'")
            Case "Kasir"
                Tampung = EksekusiSQL("SELECT a.tanggal,a.id, a.kode_invoice, a.id_member, b.nama as nama_pelanggan, a.deadline,a.tanggal_bayar,0.00 AS total_harga,a.biaya_tambahan,a.diskon,0.00 AS total_biaya,a.status,a.dibayar,a.id_user,c.nama as kasir FROM transaksi a LEFT JOIN member b ON a.id_member=b.id LEFT JOIN user c ON a.id_user=c.id WHERE date_format(a.tanggal, '%Y-%m-%d') BETWEEN '" & Format(txtTanggalAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(txtTanggalAkhir.Value, "yyyy-MM-dd") & "' AND a.id_user=" & My.Settings.logID & "")
            Case "Owner"
                Tampung = EksekusiSQL("SELECT a.tanggal,a.id, a.kode_invoice, a.id_member, b.nama as nama_pelanggan, a.deadline,a.tanggal_bayar,0.00 AS total_harga,a.biaya_tambahan,a.diskon,0.00 AS total_biaya,a.status,a.dibayar,a.id_user,c.nama as kasir FROM transaksi a LEFT JOIN member b ON a.id_member=b.id LEFT JOIN user c ON a.id_user=c.id WHERE date_format(a.tanggal, '%Y-%m-%d') BETWEEN '" & Format(txtTanggalAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(txtTanggalAkhir.Value, "yyyy-MM-dd") & "'")
            Case Else
                MessageBox.Show("Hak Akses Tidak Terdeteksi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Select
        HitungTotal()
       DataGridView1.DataSource = Tampung
    End Sub

    Sub DetilLaporan()
        If DataGridView1.RowCount <= 0 Then
            MessageBox.Show("Data yang dipilih tidak ada", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim BarisIndex As Integer = DataGridView1.CurrentRow.Index
        Dim Id As Integer = DataGridView1.Rows(BarisIndex).Cells("id").Value
        frmlaporandetil.ID = Id
        frmlaporandetil.ShowDialog()

    End Sub

    Sub Cetak()
        CetakLaporanFajarLaundry(Tampung, txtTanggalAwal.Value, txtTanggalAkhir.Value, TotalOmset, My.Settings.logRole)
    End Sub

    Sub Hapus()
        If My.Settings.logRole = "Admin" Then
            If MessageBox.Show("Data akan dihapus. Yakin lanjutkan?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim BarisIndex As Integer = DataGridView1.CurrentRow.Index
                Dim Id As Integer = DataGridView1.Rows(BarisIndex).Cells("id").Value
                EksekusiSQL("DELETE FROM transaksi_detail WHERE id_transaksi=" & Id & "")
                EksekusiSQL("DELETE FROM transaksi WHERE id=" & Id & "")
                Tampil()
            End If
        Else
            MessageBox.Show("Access Denie", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Sub Tutup()
        Me.Close()
    End Sub

    Private Sub frmlaporan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Tampil()
            Case Keys.F1
                DetilLaporan()
            Case e.Control And Keys.P
                Cetak()
            Case e.Control And Keys.Delete
                Hapus()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub

    Private Sub frmlaporan_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtTanggalAwal.Value = Now
        txtTanggalAkhir.Value = Now
        Tampil()
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        Tampil()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        DetilLaporan()
    End Sub

    Private Sub ToolStripStatusLabel3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel3.Click
        Cetak()
    End Sub

    Private Sub ToolStripStatusLabel4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel4.Click
        Hapus()
    End Sub

    Private Sub ToolStripStatusLabel6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel6.Click
        Tutup()
    End Sub
End Class