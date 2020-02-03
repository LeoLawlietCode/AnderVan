Imports MySql.Data.MySqlClient

Public Class consulta_cliente
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim sql As String
    Dim comando As MySqlCommand
    Dim r As Integer

    Private Sub consulta_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call mostrarDatos()
    End Sub

    Private Sub mostrarDatos()
        Try
            sql = "select * from cliente"
            da = New MySqlDataAdapter(sql, _conexion)
            dt = New DataTable
            da.Fill(dt)

            dgwDatos.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub
End Class