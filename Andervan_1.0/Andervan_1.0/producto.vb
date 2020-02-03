Imports MySql.Data.MySqlClient

Public Class producto
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim sql As String
    Dim comando As MySqlCommand
    Dim r As Integer

    Private Sub producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call mostrarDatos()
    End Sub

    Private Sub mostrarDatos()
        Try
            sql = "select * from producto"
            da = New MySqlDataAdapter(sql, _conexion)
            dt = New DataTable
            da.Fill(dt)

            dgwDatos.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgwDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgwDatos.DoubleClick
        Try
            txtCodigo.Text = dgwDatos.Rows(dgwDatos.CurrentRow.Index).Cells(0).Value
            txtTipo.Text = dgwDatos.Rows(dgwDatos.CurrentRow.Index).Cells(1).Value
            txtNombre.Text = dgwDatos.Rows(dgwDatos.CurrentRow.Index).Cells(2).Value
            txtStock.Text = dgwDatos.Rows(dgwDatos.CurrentRow.Index).Cells(3).Value
            txtTalla.Text = dgwDatos.Rows(dgwDatos.CurrentRow.Index).Cells(4).Value

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgwDatos_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwDatos.RowEnter
        sql = dgwDatos.Rows(e.RowIndex).Cells(0).Value.ToString
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrarDatos()
    End Sub

    Private Sub InsertarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertarToolStripMenuItem.Click
        Try
            comando = New MySqlCommand("INSERT INTO producto (PRO_CODIGO, PRO_TIPO, PRO_NOMBRE, PRO_STOK, PRO_TALLA) VALUES ('" & txtCodigo.Text & "', '" & txtTipo.Text & "', '" & txtNombre.Text & "', '" & txtStock.Text & "', '" & txtTalla.Text & "')", _conexion)

            r = comando.ExecuteNonQuery()

            If (r > 0) Then
                MsgBox("Datos guardados")
                mostrarDatos()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub EditarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarToolStripMenuItem.Click
        Try
            sql = "UPDATE producto SET PRO_CODIGO='" & txtCodigo.Text & "', PRO_TIPO ='" & txtTipo.Text & "', PRO_NOMBRE ='" & txtNombre.Text & "', PRO_STOK ='" & txtStock.Text & "', PRO_TALLA ='" & txtTalla.Text & "' WHERE PRO_CODIGO ='" & txtCodigo.Text & "'"
            comando = New MySqlCommand(sql, _conexion)
            comando.ExecuteNonQuery()
            MessageBox.Show("Datos actualizados correctamente....")
            mostrarDatos()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        If MessageBox.Show("Seguro de eliminar..............?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            sql = "DELETE FROM producto WHERE PRO_CODIGO = '" & txtCodigo.Text & "'"
            comando = New MySqlCommand(sql, _conexion)
            r = comando.ExecuteNonQuery()
            If r > 0 Then
                MsgBox("Datos eliminados exitosamente.............")
                Call mostrarDatos()
            End If


        End If

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub dgwDatos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgwDatos.CellContentClick

    End Sub
End Class