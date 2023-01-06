Public Class formmasterpaket
    Dim Tampung As DataTable
    Dim Id As Integer

    Sub Tampildata()
        Tampung = EksekusiSQL("SELECT * FROM paket")
        DataGridView1.DataSource = Tampung
    End Sub

    Sub Refreshdata()
        Tampildata()
        Id = 0
        EksekusiInputTextClear(txtNama)
        EksekusiInputValueClear(txtHarga, txtDiskon)
        txtJenis.SelectedIndex = -1
        txtNama.Focus()
    End Sub

    Sub Simpandata()
        If txtJenis.Text = "" Or txtNama.Text = "" Or txtHarga.Value <= 0 Or txtDiskon.Value < 0 Then
            MessageBox.Show("Harap isi semua kolom. Persen diskon tidak boleh lebih kecil dari 0", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Id = 0 Then
            EksekusiSQL("INSERT INTO paket(jenis, nama_paket, harga, persen_diskon) VALUES('" & txtJenis.Text & "','" & txtNama.Text & "'," & txtHarga.Value & "," & txtDiskon.Value & ")")
            Refreshdata()
            MessageBox.Show("Data Berhasil Disimpan.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            EksekusiSQL("UPDATE paket SET nama_paket='" & txtNama.Text & "',jenis='" & txtJenis.Text & "',harga=" & txtHarga.Value & ",persen_diskon=" & txtDiskon.Value & " WHERE id=" & Id & "")
            Refreshdata()
            MessageBox.Show("Data Berhasil Diubah.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Sub Ubahdata()
        If DataGridView1.RowCount <= 0 Then
            MessageBox.Show("Data yang dipilih tidak ada", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        With DataGridView1
            Dim BarisIndex As Integer = .CurrentRow.Index
            Id = .Rows(BarisIndex).Cells("id").Value
            txtJenis.Text = .Rows(BarisIndex).Cells("jenis").Value
            txtNama.Text = .Rows(BarisIndex).Cells("nama_paket").Value
            txtHarga.Value = .Rows(BarisIndex).Cells("harga").Value
            txtDiskon.Value = .Rows(BarisIndex).Cells("persen_diskon").Value
        End With
        txtNama.Focus()
    End Sub

    Sub Hapusdata()
        If DataGridView1.RowCount <= 0 Then
            MessageBox.Show("Data yang dipilih tidak ada", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Data akan dihapus. Lanjutkan?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            With DataGridView1
                Dim BarisIndex As Integer = .CurrentRow.Index
                EksekusiSQL("DELETE FROM paket WHERE id=" & .Rows(BarisIndex).Cells("id").Value & "")
                Refreshdata()
            End With
        End If
    End Sub

    Sub Tutup()
        Me.Close()
    End Sub

    Private Sub formmasterpaket_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Refreshdata()
            Case e.Control And Keys.Enter
                Simpandata()
            Case Keys.F2
                Ubahdata()
            Case e.Control And Keys.Delete
                Hapusdata()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub

    Private Sub formmasterpaket_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtHarga.Maximum = 9999999999999
        Refreshdata()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        Simpandata()
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        Refreshdata()
    End Sub

    Private Sub ToolStripStatusLabel3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel3.Click
        Ubahdata()
    End Sub

    Private Sub ToolStripStatusLabel4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel4.Click
        Hapusdata()
    End Sub

    Private Sub ToolStripStatusLabel6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel6.Click
        Tutup()
    End Sub

End Class