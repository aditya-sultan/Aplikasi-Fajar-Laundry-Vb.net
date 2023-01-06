Imports MySql.Data.MySqlClient

Public Class formsetuplogin

    Sub Login()
        Try
            Dim CariUser = EksekusiSQL("SELECT * FROM user WHERE username='" & txtUsername.Text & "' AND password='" & txtPassword.Text & "'").Select
            If CariUser.Length > 0 Then
                'tempat login
                Select Case CariUser(0).Item("role")
                    Case "Admin"
                        OnOfMenu(True, True, True, True, True, True, True, True)
                    Case "Kasir"
                        OnOfMenu(True, False, False, True, True, True, False, False)
                    Case "Owner"
                        OnOfMenu(False, False, True, True, False, True, False, False)
                End Select
                My.Settings.logID = CariUser(0).Item("id")
                My.Settings.logNama = CariUser(0).Item("nama")
                My.Settings.logRole = CariUser(0).Item("role")
                MenuUtama.Show()
                Me.Close()
            Else
                MessageBox.Show("Username/Password salah.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            If MessageBox.Show("Koneksi ke server gagal. Lanjutkan ke pengaturan koneksi?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                formkonfigurasiserver.ShowDialog()
            End If
        End Try
    End Sub

    Sub tutup()
        Application.Exit()
    End Sub

    Private Sub formsetuplogin_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Login()
            Case Keys.Escape
                tutup()
        End Select
    End Sub

    Private Sub formsetuplogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtPassword.UseSystemPasswordChar = True
        EksekusiInputTextClear(txtUsername, txtPassword)
        txtUsername.Focus()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Login()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        tutup()
    End Sub
End Class