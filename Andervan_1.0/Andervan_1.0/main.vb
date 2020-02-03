Imports MySql.Data.MySqlClient

Public Class main

    Private Sub ProductoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductoToolStripMenuItem.Click
        Dim ventana As New producto()

        ventana.MdiParent = Me
        ventana.Show()
    End Sub

    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexionGlobal()
    End Sub

    Private Sub ClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClienteToolStripMenuItem.Click
        Dim ventana As New Cliente()
        ventana.MdiParent = Me
        ventana.Show()
    End Sub

    Private Sub DetalleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleToolStripMenuItem.Click
        Dim ventana As New Detalle()
        ventana.MdiParent = Me
        ventana.Show()
    End Sub

    Private Sub FacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaToolStripMenuItem.Click
        Dim ventana As New Factura()
        ventana.MdiParent = Me
        ventana.Show()
    End Sub

    Private Sub ProductoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductoToolStripMenuItem1.Click
        Dim ventana As New consulta_producto()
        ventana.MdiParent = Me
        ventana.Show()
    End Sub

    Private Sub ClienteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClienteToolStripMenuItem1.Click
        Dim ventana As New consulta_cliente()
        ventana.MdiParent = Me
        ventana.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.ExitThread()
    End Sub
End Class
