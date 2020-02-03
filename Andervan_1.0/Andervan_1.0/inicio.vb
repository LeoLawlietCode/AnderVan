Imports MySql.Data.MySqlClient

Public Class inicio

    Dim fallo_conexion As Integer = 0

    Private Sub inicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexionGlobal()
        tiempo.Start()
        If Not conexionGlobal() Then
            fallo_conexion = 1
        End If

    End Sub


    Private Sub tiempo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tiempo.Tick
        progreso.Increment(1)

        If progreso.Value = 100 Then
            login.Show()
            Me.Hide()
            tiempo.Stop()
        End If

        If fallo_conexion = 1 And progreso.Value = 50 Then
            tiempo.Stop()
            If MessageBox.Show("Hay un error de conexión con el servidor: " & fallo, " Error de conexión", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Retry Then
                Application.Restart()
            Else
                Application.Exit()
            End If
        End If
    End Sub
End Class