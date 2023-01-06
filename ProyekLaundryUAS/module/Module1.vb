Imports MySql.Data.MySqlClient

Module Module1
    Function EksekusiSQL(ByVal PerintahSQL As String) As DataTable
        Dim Koneksi As New MySqlConnection(My.Settings.conString)
        Dim Eksekusi As New MySqlDataAdapter(PerintahSQL, Koneksi)
        Dim Tampung As New DataTable
        Eksekusi.Fill(Tampung)
        Return Tampung
    End Function

    Public Sub EksekusiInputTextClear(ByVal ParamArray InputText() As Object)
        For Each Component In InputText
            Component.Text = ""
        Next
    End Sub

    Public Sub EksekusiInputValueClear(ByVal ParamArray InputValue() As Object)
        For Each Component In InputValue
            Component.Value = 0
        Next
    End Sub

    Sub OnOfMenu(ByVal order As Boolean, ByVal user As Boolean, ByVal paket As Boolean,
                 ByVal laporan As Boolean, ByVal langganan As Boolean, ByVal proses As Boolean,
                 ByVal server As Boolean, ByVal system As Boolean)
        With MenuUtama
            'menu
            .mnorder.Enabled = order
            .mnuser.Enabled = user
            .mnpaket.Enabled = paket
            'transaksi
            .mnlaporan.Enabled = laporan
            .mnplanggan.Enabled = langganan
            .mnproses.Enabled = proses
            'pengaturan
            .server.Enabled = server
            .system.Enabled = system
        End With
    End Sub

    Function AutoCodeTransaksi() As Integer
        Dim IdTransaksi As Integer = 0
        Try
            Dim NilaiMax As Integer = EksekusiSQL("SELECT max(id) AS nilaimax FROM transaksi").Select()(0).Item("nilaimax")
            IdTransaksi = NilaiMax + 1
        Catch ex As Exception
            IdTransaksi = 1
        End Try
        Return IdTransaksi
    End Function
End Module
