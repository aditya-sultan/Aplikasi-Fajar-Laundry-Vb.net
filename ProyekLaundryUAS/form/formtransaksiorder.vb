Public Class formtransaksiorder
    Dim Tampung As DataTable

    Sub TampilItem()
        Tampung = EksekusiSQL("SELECT a.id_paket,b.nama_paket,a.qty,a.harga,a.diskon, (a.harga-(a.harga*a.diskon/100)) as total_harga,a.keterangan FROM transaksi_detail a INNER JOIN paket b ON a.id_paket=b.id WHERE a.id=0")
        DataGridView1.DataSource = Tampung
    End Sub

    Sub cariPaket()
        Dim cariPaket = EksekusiSQL("SELECT * FROM paket").Select()
        txtPaket.Items.Clear()
        For Each Isi In cariPaket
            txtPaket.Items.Add(Isi.Item("nama_paket") & "→" & Isi.Item("id"))
        Next
    End Sub

    Sub HapusInputItem()
        cariPaket()
        txtPaket.SelectedIndex = -1
        EksekusiInputValueClear(txtQty)
        EksekusiInputTextClear(txtKeterangan)
        txtPaket.Focus()
    End Sub

    Sub cariPelanggan()
        Dim cariPelanggan = EksekusiSQL("SELECT * FROM member").Select()
        txtPlanggan.Items.Clear()
        For Each Isi In cariPelanggan
            txtPlanggan.Items.Add(Isi.Item("nama") & "→" & Isi.Item("id"))
        Next
    End Sub


    Sub RefreshTotalPembayaran()
        Dim TotalPembayaran As Double = 0
        For Each Isi In Tampung.Select()
            TotalPembayaran = TotalPembayaran + Isi.Item("total_harga")
        Next
        TotalPembayaran = TotalPembayaran + txtBiayaTambahan.Value
        txtTotalPembayaran.Text = "Rp. " & Format(TotalPembayaran, "#,##0") & ",-"
    End Sub


    Sub RefreshData()
        TampilItem()
        HapusInputItem()
        txtTanggal.Value = Now
        txtPlanggan.SelectedIndex = -1
        EksekusiInputValueClear(txtWaktuPengerjaan, txtBiayaTambahan)
        RefreshTotalPembayaran()
        cariPelanggan()
        txtPaket.Focus()
    End Sub

    Sub TambahItem()
        If txtPaket.Text = "" Or txtQty.Value <= 0 Then
            MessageBox.Show("Harap isi Paket dan Qty", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim CekDataPaket = EksekusiSQL("SELECT * FROM paket WHERE id='" & txtPaket.Text.Split("→")(1) & "'").Select()(0)

        Dim CekDataItem = Tampung.Select("id_paket=" & txtPaket.Text.Split("→")(1) & "")
        If CekDataItem.Length <= 0 Then
            Dim BarisBaru = Tampung.NewRow
            With BarisBaru
                .Item("id_paket") = txtPaket.Text.Split("→")(1)
                .Item("nama_paket") = txtPaket.Text.Split("→")(0)
                .Item("qty") = txtQty.Value
                .Item("harga") = CekDataPaket.Item("harga")
                .Item("diskon") = (.Item("qty") * .Item("harga")) * CekDataPaket.Item("persen_diskon") / 100
                .Item("total_harga") = (.Item("qty") * .Item("harga")) - .Item("diskon")
                .Item("keterangan") = txtKeterangan.Text
            End With
            Tampung.Rows.Add(BarisBaru)
        Else
            With CekDataItem(0)
                .Item("qty") = .Item("qty") + txtQty.Value
                .Item("harga") = CekDataPaket.Item("harga")
                .Item("diskon") = (.Item("qty") * .Item("harga")) * CekDataPaket.Item("persen_diskon") / 100
                .Item("total_harga") = (.Item("qty") * .Item("harga")) - .Item("diskon")
                If txtKeterangan.Text <> "" Then
                    .Item("keterangan") = txtKeterangan.Text
                End If
            End With
        End If
        HapusInputItem()
        RefreshTotalPembayaran()
    End Sub

    Sub HapusItem()
        If DataGridView1.RowCount <= 0 Then
            MessageBox.Show("Data yang dipilih tidak ada", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Data akan dihapus, yakin?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim BarisIndex As Integer = DataGridView1.CurrentRow.Index
            Tampung.Rows.RemoveAt(BarisIndex)
            HapusInputItem()
            RefreshTotalPembayaran()
        End If
    End Sub

    Sub Simpan()
        If txtTanggal.Text = "" Or txtPlanggan.Text = "" Or txtWaktuPengerjaan.Value <= 0 Or txtBiayaTambahan.Value < 0 Then
            MessageBox.Show("tanggal, nama pelanggan, waktu pengerjaan harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Tampung.Rows.Count <= 0 Then
            MessageBox.Show("Daftar item belum diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim NomorTransaksi As Integer = AutoCodeTransaksi()

        Dim TotalDiskon As Double = 0
        Dim TotalPembayaran As Double = 0
        For Each Isi In Tampung.Select()
            TotalDiskon = TotalDiskon + Isi.Item("diskon")
            TotalPembayaran = TotalPembayaran + Isi.Item("total_harga")
        Next

        EksekusiSQL("INSERT INTO transaksi(id, kode_invoice, id_member, tanggal, deadline, tanggal_bayar, biaya_tambahan, diskon, status, dibayar, id_user) VALUES (" & NomorTransaksi & ",'" & txtTanggal.Text & NomorTransaksi & "'," & txtPlanggan.Text.Split("→")(1) & ",'" & Format(txtTanggal.Value, "yyyy-MM-dd HH:mm:ss") & "','" & Format(txtTanggal.Value.AddDays(txtWaktuPengerjaan.Value), "yyyy-MM-dd HH:mm:ss") & "','" & Format(txtTanggal.Value, "yyyy-MM-dd HH:mm:ss") & "'," & txtBiayaTambahan.Value & "," & TotalDiskon & ",'Baru','Belum Bayar'," & My.Settings.logID & ")")
        For Each Isi In Tampung.Select()
            EksekusiSQL("INSERT INTO transaksi_detail(id_transaksi, id_paket, qty, harga, diskon, keterangan) VALUES ('" & NomorTransaksi & "'," & Isi.Item("id_paket") & "," & Isi.Item("qty") & "," & Isi.Item("harga") & "," & Isi.Item("diskon") & ",'" & Isi.Item("keterangan") & "')")
        Next
        RefreshData()
        MessageBox.Show("Transaksi berhasil.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        CetakOrder(NomorTransaksi)
    End Sub

    Sub Tutup()
        If DataGridView1.RowCount > 0 Then
            If MessageBox.Show("Daftar item sudah ditambahkan. Yakin menutup menu?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub formtransaksiorder_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtWaktuPengerjaan.Maximum = 9999999999
        txtQty.Maximum = 9999999999
        txtBiayaTambahan.Maximum = 9999999999
        RefreshData()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TambahItem()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        formmasterpelanggan.Close()
        formmasterpelanggan.ShowDialog()
        cariPelanggan()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        Simpan()
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        RefreshData()
    End Sub

    Private Sub ToolStripStatusLabel6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel6.Click
        Tutup()
    End Sub

    Private Sub ToolStripStatusLabel3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel3.Click
        HapusItem()
    End Sub

    Private Sub txtBiayaTambahan_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtBiayaTambahan.ValueChanged
        RefreshTotalPembayaran()
    End Sub
End Class