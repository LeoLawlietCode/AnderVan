Imports MySql.Data.MySqlClient
Public Class Detalle
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim sql As String
    Dim comando As MySqlCommand
    Dim r As Integer
    Private Sub Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call mostrarDatos()
    End Sub
    Private Sub mostrarDatos()
        Try
            sql = "select * from detalle"
            da = New MySqlDataAdapter(Sql, _conexion)
            dt = New DataTable
            da.Fill(dt)

            dgwDetalle.DataSource = dt
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgwDetalle_DoubleClick(sender As Object, e As EventArgs) Handles dgwDetalle.DoubleClick
        txtcodfactura.Text = dgwDetalle.Rows(dgwDetalle.CurrentRow.Index).Cells(0).Value
        txtcodproducto.Text = dgwDetalle.Rows(dgwDetalle.CurrentRow.Index).Cells(1).Value
        txtcantidad.Text = dgwDetalle.Rows(dgwDetalle.CurrentRow.Index).Cells(2).Value
        txtprecio.Text = dgwDetalle.Rows(dgwDetalle.CurrentRow.Index).Cells(3).Value
    End Sub

    Private Sub dgwDetalle_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgwDetalle.RowEnter
        sql = dgwDetalle.Rows(e.RowIndex).Cells(0).Value.ToString
    End Sub

    Private Sub InsertarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertarToolStripMenuItem.Click
        Try
            comando = New MySqlCommand("INSERT INTO detalle (FAC_CODIGO, PRO_CODIGO, DET_CANTIDAD, DET_PRECIO) VALUES ('" & txtcodfactura.Text & "', '" & txtcodproducto.Text & "', '" & txtcantidad.Text & "', '" & txtprecio.Text & "')", _conexion)

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
            sql = "UPDATE Detalle  SET FAC_CODIGO ='" & txtcodfactura.Text & "', PRO_CODIGO ='" & txtcodproducto.Text & "', DET_CANTIDAD ='" & txtcantidad.Text & "', DET_PRECIO ='" & txtprecio.Text & "' WHERE FAC_CODIGO ='" & txtcodfactura.Text & "'"
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
            sql = "DELETE detalle WHERE FAC_CODIGO = '" & txtcodfactura.Text & "'"
            comando = New MySqlCommand(sql, _conexion)
            r = comando.ExecuteNonQuery()
            If r > 0 Then
                MsgBox("Datos eliminados exitosamente.............")
                Call mostrarDatos()
            End If


        End If
    End Sub
End Class