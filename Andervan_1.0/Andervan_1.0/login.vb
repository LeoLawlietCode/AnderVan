Imports MySql.Data.MySqlClient

Public Class login
    Dim cerrarAplicaciones As Integer = 0
    Dim da As MySqlDataAdapter
    Dim sql, usuario, password As String
    Dim comando As MySqlCommand
    Dim r As Integer

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetCueText(txtUsuario, "Usuario o Número de cédula")
        SetCueText(txtPassword, "Contraseña")
        SetCueText(txtNombre, "Nombre y Apellido")
        SetCueText(txtCedula, "Número de cédula")
        SetCueText(txtDireccion, "Dirección")
        SetCueText(txtTelefono, "Teléfono")
        SetCueText(txtUsuarioR, "Nombre de usuario")
        SetCueText(txtPasswordR, "Contraseña")
        SetCueText(txtPasswordV, "Verifica tu contraseña")
    End Sub

    Private Sub login_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosed
        If cerrarAplicaciones = 0 Then Application.Exit()
    End Sub

    Private Sub lblRegistrar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblRegistrar.LinkClicked
        tbcEspacio.SelectedIndex = 1
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        tbcEspacio.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtrás.Click
        tbcEspacio.SelectedIndex = 1
    End Sub

    Private Sub btnSiguiente1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente1.Click
        tbcEspacio.SelectedIndex = 2
    End Sub

    Private Sub btnIniciarSesion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIniciarSesion.Click
        Dim comparar As Boolean = True

        Try
            sql = "select cli_usuario, cli_contrasena from cliente where cli_usuario = " & txtUsuario.Text & " And cli_contrasena = " & txtPassword.Text
            da = New MySqlDataAdapter(sql, _conexion)

        Catch ex As Exception
            comparar = False
            MessageBox.Show("Usuario o contraseña incorrectos :O", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If comparar Then
            cerrarAplicaciones = 1
            main.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If txtPasswordR.Text = txtPasswordV.Text Then
            lblError.Visible = False
            lblError.Visible = True
        Else

        End If
    End Sub
End Class
