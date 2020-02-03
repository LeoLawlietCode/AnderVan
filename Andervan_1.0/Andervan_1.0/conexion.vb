Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient

Module conexion
    Public _cadena, fallo As String
    Public _conexion As MySqlConnection

    Public Function conexionGlobal() As Boolean
        Dim estado As Boolean = True

        Try
            _cadena = ("server=localhost; database=andervan; user id=root; password=password; port=3306")
            _conexion = New MySqlConnection(_cadena)
            _conexion.Open()
        Catch ex As Exception
            fallo = ex.Message
            estado = False
        End Try

        Return estado
    End Function
End Module
