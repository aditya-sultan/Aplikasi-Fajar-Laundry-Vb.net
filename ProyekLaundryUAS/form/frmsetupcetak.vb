Public Class frmsetupcetak
    Public NamaLaporan As String
    Public SourceHtml As String

    Sub tampil()
        Me.Text = "Cetak " & NamaLaporan
        WebBrowser1.DocumentText = SourceHtml
    End Sub

    Sub Cetak()
        WebBrowser1.ShowPrintDialog()
    End Sub

    Sub Tutup()
        Me.Close()
    End Sub

    Private Sub frmsetupcetak_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                tampil()
            Case Keys.F8
                Cetak()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub

    Private Sub frmsetupcetak_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        tampil()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        Cetak()
    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        tampil()
    End Sub

    Private Sub ToolStripStatusLabel6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripStatusLabel6.Click
        Tutup()
    End Sub
End Class