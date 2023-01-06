Public Class formmasterpelanggan
    Dim Tampung As DataTable
    Dim Id As Integer

    Sub Tampildata()
        Tampung = EksekusiSQL("SELECT * FROM member")
        DataGridView1.DataSource = Tampung
    End Sub

    Sub Refreshdata()
        Tampildata()
        Id = 0
        EksekusiInputTextClear(txtNama, txtAlamat, txtNoTelp)
        txtjk.SelectedIndex = -1
        txtNama.Focus()
    End Sub

    Sub Simpandata()
        If txtNama.Text = "" Or txtAlamat.Text = "" Or txtjk.Text = "" Or txtNoTelp.Text = "" Then
            MessageBox.Show("Nama, Alamat & Nomor Telepon Harus Diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Id = 0 Then
            EksekusiSQL("INSERT INTO member(nama, alamat, jenis_kelamin, nomor_telepon) VALUES('" & txtNama.Text & "','" & txtAlamat.Text & "','" & txtjk.Text & "', '" & txtNoTelp.Text & "')")
            Refreshdata()
            MessageBox.Show("Data Berhasil Disimpan.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            EksekusiSQL("UPDATE member SET nama='" & txtNama.Text & "',alamat='" & txtAlamat.Text & "',nomor_telepon='" & txtNoTelp.Text & "',jenis_kelamin='" & txtjk.Text & "' WHERE id=" & Id & "")
            Refreshdata()
            MessageBox.Show("Data Berhasil Disimpan.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
            txtNama.Text = .Rows(BarisIndex).Cells("nama").Value
            txtAlamat.Text = .Rows(BarisIndex).Cells("alamat").Value
            txtjk.Text = .Rows(BarisIndex).Cells("jenis_kelamin").Value
            txtNoTelp.Text = .Rows(BarisIndex).Cells("nomor_telepon").Value
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
                EksekusiSQL("DELETE FROM member WHERE id=" & .Rows(BarisIndex).Cells("id").Value & "")
                Refreshdata()
            End With
        End If
    End Sub

    Sub Tutup()
        Me.Close()
    End Sub

    Private Sub formmasterpelanggan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub formmasterpelanggan_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
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