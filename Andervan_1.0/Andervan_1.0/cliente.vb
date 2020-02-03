Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Cliente
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim sql As String
    Dim comando As MySqlCommand
    Dim r As Integer
    Private Sub InsertarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertarToolStripMenuItem.Click
        Try
            comando = New MySqlCommand("INSERT INTO cliente (CLI_CODIGO, CLI_NOMBRE, CLI_CEDULA, CLI_DIRECCION, CLI_TELEFONO,CLI_TARJETA_CREDITO,CLI_USUARIO,CLI_CONTRASENA) VALUES ('" & txtcodigo.Text & "', '" & txtnombre.Text & "', '" & txtcedula.Text & "', '" & txtdireccion.Text & "', '" & txttelefono.Text & "','" & txttarjeta.Text & "','" & txtusuario.Text & "','" & txtcontraseña.Text & "')", _conexion)

            r = comando.ExecuteNonQuery()

            If (r > 0) Then
                MsgBox("Datos guardados")
                mostrarDatos()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call mostrarDatos()
    End Sub

    Private Sub mostrarDatos()
        Try
            sql = "select * from cliente"
            da = New MySqlDataAdapter(sql, _conexion)
            dt = New DataTable
            da.Fill(dt)

            dgwCliente.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgwCliente_DoubleClick(sender As Object, e As EventArgs) Handles dgwCliente.DoubleClick
        Try
            txtcodigo.Text = dgwCliente.Rows(dgwCliente.CurrentRow.Index).Cells(0).Value
            txtnombre.Text = dgwCliente.Rows(dgwCliente.CurrentRow.Index).Cells(1).Value
            txtcedula.Text = dgwCliente.Rows(dgwCliente.CurrentRow.Index).Cells(2).Value
            txtdireccion.Text = dgwCliente.Rows(dgwCliente.CurrentRow.Index).Cells(3).Value
            txttelefono.Text = dgwCliente.Rows(dgwCliente.CurrentRow.Index).Cells(4).Value
            txttarjeta.Text = dgwCliente.Rows(dgwCliente.CurrentRow.Index).Cells(5).Value
            txtusuario.Text = dgwCliente.Rows(dgwCliente.CurrentRow.Index).Cells(6).Value
            txtcontraseña.Text = dgwCliente.Rows(dgwCliente.CurrentRow.Index).Cells(7).Value


        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgwCliente_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgwCliente.RowEnter
        sql = dgwCliente.Rows(e.RowIndex).Cells(0).Value.ToString
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        Try
            sql = "UPDATE Cliente SET CLI_CODIGO ='" & txtcodigo.Text & "', CLI_NOMBRE ='" & txtnombre.Text & "', CLI_CEDULA ='" & txtcedula.Text & "', CLI_DIRECCION ='" & txtdireccion.Text & "', CLI_TELEFONO ='" & txttelefono.Text & "', CLI_TARJETA_credito ='" & txttarjeta.Text & "', CLI_USUARIO='" & txtusuario.Text & "', CLI_CONTRASENA='" & txtcontraseña.Text & "' WHERE CLI_CODIGO ='" & txtcodigo.Text & "'"
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
            sql = "DELETE FROM cliente WHERE CLI_CODIGO = '" & txtcodigo.Text & "'"
            comando = New MySqlCommand(sql, _conexion)
            r = comando.ExecuteNonQuery()
            If r > 0 Then
                MsgBox("Datos eliminados exitosamente.............")
                Call mostrarDatos()
            End If


        End If
    End Sub

    Private Sub Examinar_Click(sender As Object, e As EventArgs) Handles Examinar.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = "C:\Users\HP\Documents\Andervan_1.0\imagenes andervan"
        openFileDialog1.Filter = "Imagenes (*.jpeg,*.png,*.jpg,*.gif)|*.jpeg;*.png;*.jpg;*.gif"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtUrl.Text = openFileDialog1.FileName
            ptbimagen.Image = Image.FromFile(openFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnguardar.Click
        Dim mstream As New System.IO.MemoryStream()
        ptbimagen.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim arrImage() As Byte = mstream.GetBuffer
        mstream.Close()
        Try
            comando = New MySqlCommand("INSERT INTO PERSONA (CLI_CODIGO, CLI_NOMBRE, CLI_CEDULA, CLI_DIRECCION,CLI_TELEFONO,CLI_TARJETA_CREDITO,CLI_USUARIO,CLI_CONTRASENA,CLI_FOTO) VALUES ('" & txtcodigo.Text & "', '" & txtnombre.Text & "', '" & txtcedula.Text & "', '" & txtdireccion.Text & "','" & txttelefono.Text & "','" & txttarjeta.Text & "', @imagen)", _conexion)
            comando.Parameters.AddWithValue("@Imagen", arrImage)
            r = comando.ExecuteNonQuery()

            If (r > 0) Then
                MsgBox("Datos guardados")
                mostrarDatos()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class