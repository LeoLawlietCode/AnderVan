Imports MySql.Data.MySqlClient
Public Class Factura
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim sql As String
    Dim comando As MySqlCommand
    Dim r As Integer
    Private Sub Factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call mostrarDatos()
    End Sub
    Private Sub mostrarDatos()
        Try
            sql = "select * from factura"
            da = New MySqlDataAdapter(sql, _conexion)
            dt = New DataTable
            da.Fill(dt)

            dgwfactura.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgwfactura_DoubleClick(sender As Object, e As EventArgs) Handles dgwfactura.DoubleClick
        txtfactura.Text = dgwfactura.Rows(dgwfactura.CurrentRow.Index).Cells(0).Value
        txtcliente.Text = dgwfactura.Rows(dgwfactura.CurrentRow.Index).Cells(1).Value
        txtfecha.Text = dgwfactura.Rows(dgwfactura.CurrentRow.Index).Cells(2).Value
        txttotal.Text = dgwfactura.Rows(dgwfactura.CurrentRow.Index).Cells(3).Value
        txtcompra.Text = dgwfactura.Rows(dgwfactura.CurrentRow.Index).Cells(4).Value
    End Sub

    Private Sub dgwfactura_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgwfactura.RowEnter
        sql = dgwfactura.Rows(e.RowIndex).Cells(0).Value.ToString
    End Sub

    Private Sub InsertarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertarToolStripMenuItem.Click
        Try
            comando = New MySqlCommand("INSERT INTO factura (FAC_CODIGO, CLI_CODIGO, FAC_FECHA_COMPRA, FAC_TOTAL, FAC_TIPO_COMPRA) VALUES ('" & txtfactura.Text & "', '" & txtcliente.Text & "', '" & txtfecha.Text & "', '" & txttotal.Text & "','" & txtcompra.Text & "')", _conexion)

            r = comando.ExecuteNonQuery()

            If (r > 0) Then
                MsgBox("Datos guardados")
                mostrarDatos()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        Try
            sql = "UPDATE Factura SET FAC_CODIGO ='" & txtfactura.Text & "', CLI_CODIGO ='" & txtcliente.Text & "', FAC_FECHA_COMPRA ='" & txtfecha.Text & "', FAC_TOTAL ='" & txttotal.Text & "', FAC_TIPO_COMPRA ='" & txtcompra.Text & "' WHERE FAC_CODIGO ='" & txtfactura.Text & "' WHERE CLI_CODIGO ='" & txtcliente.Text & "'"
            comando = New MySqlCommand(sql, _conexion)
            comando.ExecuteNonQuery()
            MessageBox.Show("Datos actualizados correctamente....")
            mostrarDatos()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        If MessageBox.Show("Seguro de eliminar..............?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            sql = "DELETE FROM factura WHERE FAC_CODIGO= '" & txtfactura.Text & "'"
            comando = New MySqlCommand(sql, _conexion)
            r = comando.ExecuteNonQuery()
            If r > 0 Then
                MsgBox("Datos eliminados exitosamente.............")
                Call mostrarDatos()
            End If


        End If
    End Sub
End Class