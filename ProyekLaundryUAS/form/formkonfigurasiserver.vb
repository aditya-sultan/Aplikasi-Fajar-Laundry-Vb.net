Imports MySql.Data.MySqlClient

Public Class formkonfigurasiserver

    Sub Tampldata()
        With My.Settings
            txtHost.Text = .conHost
            txtUsername.Text = .conUsername
            txtPassword.Text = .conPassword
            txtDatabase.Text = .conDatabase
        End With
        txtHost.Focus()
    End Sub

    Sub Teskoneksi()
        If txtHost.Text = "" Or txtUsername.Text = "" Or txtDatabase.Text = "" Then
            MessageBox.Show("Host, Password & Database Harus Diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            Dim Alamat As String = "server=" & txtHost.Text & ";user id=" & txtUsername.Text & ";password=" & txtPassword.Text & ";database=" & txtDatabase.Text & ""
            Dim Koneksi As New MySqlConnection(Alamat)
            If Koneksi.State = ConnectionState.Closed Then
                Koneksi.Open()
                Koneksi.Clone()
            Else
                Koneksi.Close()
            End If
            MessageBox.Show("Koneksi Behasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Koneksi Gagal," & vbCrLf & ex.Message, "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Simpankoneksi()
        If txtHost.Text = "" Or txtUsername.Text = "" Or txtDatabase.Text = "" Then
            MessageBox.Show("Host, Password & Database Harus Diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            Dim Alamat As String = "server=" & txtHost.Text & ";user id=" & txtUsername.Text & ";password=" & txtPassword.Text & ";database=" & txtDatabase.Text & ""
            Dim Koneksi As New MySqlConnection(Alamat)
            If Koneksi.State = ConnectionState.Closed Then
                Koneksi.Open()
                Koneksi.Clone()
            Else
                Koneksi.Close()
            End If

            With My.Settings
                .conHost = txtHost.Text
                .conUsername = txtUsername.Text
                .conPassword = txtPassword.Text
                .conDatabase = txtDatabase.Text
                .conString = "server=" & txtHost.Text & ";user id=" & txtUsername.Text & ";password=" & txtPassword.Text & ";database=" & txtDatabase.Text & ""
            End With
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Koneksi Gagal," & vbCrLf & ex.Message, "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Tutup()
        Me.Close()
    End Sub

    Private Sub formkonfigurasiserver_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Teskoneksi()
            Case e.Control And Keys.Enter
                Simpankoneksi()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub

    Private Sub formkonfigurasiserver_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtPassword.UseSystemPasswordChar = True
        Tampldata()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Teskoneksi()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Simpankoneksi()
    End Sub
End Class