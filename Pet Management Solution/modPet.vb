Imports MySql.Data.MySqlClient
Module modPet

    Public user As UserLogin

    'establishes connection to a MySQL Server database
    Private dbConn As MySqlConnection

    'represents an SQL statement to execute against a MySQL database
    Private sqlCommand As MySqlCommand

    Private da As MySqlDataAdapter

    'represent a set of data commands and a database connection that are used to fill 
    ' a dataset and update a MySQL database
    Private dt As DataTable

    'sets the string used to connect to a MySQL server database
    Dim strConn As String = "Server=localhost; User ID=root; Database=dbpets; Convert Zero Datetime=True;"

    Public Sub dbConnection()
        Try
            dbConn = New MySqlConnection(strConn)
            dbConn.Open()
            'MessageBox.Show("DB test connection is successful.", "Pet DBMS",
            'MessageBoxButtons.OK, MessageBoxIcon.Information)
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: DBConnection() " & ex.Message, "Pet DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub DisplayRecords(ByVal strSQL As String, ByVal dg As DataGridView)
      dg.DataSource = GetDataTable(strSQL)
    End Sub

    Public Function GetDataTable(ByVal strSQL As String) As DataTable
        Try
            dbConnection()
            dbConn.Open()
            da = New MySqlDataAdapter(strSQL, dbConn)
            dt = New DataTable
            da.Fill(dt)
            GetDataTable = dt
        Catch ex As Exception
            MessageBox.Show("Error: GetDataTable()" & ex.Message, "Pet DBMS",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
            GetDataTable = New DataTable

        Finally
            dbConn.Close()
        End Try
        Return GetDataTable
    End Function

    Public Function RecordCount(strTable As String, strColumn As String) As Integer
        Dim count As Integer = 0
        Dim strSQL As String = $"SELECT * FROM {strTable} ORDER BY {strColumn} DESC LIMIT 1"
        Dim dt = GetDataTable(strSQL)

        If dt.Rows.Count() > 0 Then
            count = dt.Rows(0).Item(strColumn)
        Else
            count = 0
        End If
        Return count
    End Function

    Public Sub LoadToComboBox(ByVal strSQL As String, ByRef combo As ComboBox, ByVal strValue As String, ByVal strDisplay As String, strColumnStatus As String)
        If strSQL.ToLower.Contains("where") Then
            strSQL += $" AND {strColumnStatus} = 'Active'"
        Else
            strSQL += $" WHERE {strColumnStatus} = 'Active'"
        End If
        Dim dt = GetDataTable(strSQL)
        combo.DataSource = dt
        combo.ValueMember = dt.Columns(strValue).ToString
        combo.DisplayMember = dt.Columns(strDisplay).ToString
    End Sub

    Public Sub SQLManager(ByVal strSQL As String, ByVal strMsg As String)
        Try
            dbConn.Open()
            sqlCommand = New MySqlCommand(strSQL, dbConn)
            With sqlCommand
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
            dbConn.Close()
            MessageBox.Show(strMsg, "Pet DBMS ",
                MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: SQLManager() " & ex.Message, "Pet DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function SQLManager(ByVal strSQL As String) As Boolean
        Try
            dbConn.Open()
            sqlCommand = New MySqlCommand(strSQL, dbConn)
            With sqlCommand
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
            dbConn.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub executeUnsuccesslog(intID As Integer)
        Dim strQuery As String = $"INSERT INTO tblauditlog (logDateTime,logType, userID, logModule, logComment) VALUES 
                                    (now(), 0, {intID}, 'Login Form', 'Invalid username/password') "
        SQLManager(strQuery)
    End Sub

    Public Sub executeSuccesslog(intID As Integer)
        Dim strQuery As String = $"INSERT INTO tblauditlog (logDateTime,logType, userID, logModule, logComment) VALUES 
                                    (now(), 1, {intID}, 'Login Form', 'Sucessful login') "
        SQLManager(strQuery)
    End Sub

    Public Sub executeCreatelog(strForm As String, strObject As String, intID As Integer)
        Dim strQuery As String = $"INSERT INTO tblauditlog (logDateTime, logType, userID, logModule, logComment) VALUES 
                                    (now(), 2, {user.ID}, '{strForm}', 'Create new {strObject} - #{intID}') "
        SQLManager(strQuery)
    End Sub

    Public Function executeUpdatelog(ByRef strSQL As String, strForm As String, strColumn As String, strObject As String, intID As Integer, beforeValue As String, afterValue As String) As Boolean
        If beforeValue <> afterValue Then
            strSQL += $"INSERT INTO tblauditlog (logDateTime, logType, userID, logModule, logComment) VALUES 
                                    (now(), 3, {user.ID}, '{strForm}', 'Update {strColumn} of {strObject} - #{intID} from ""{beforeValue}"" to ""{afterValue}""'); "
            'MsgBox($"{beforeValue} to {afterValue}")
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub executeDeletelog(strForm As String, strObject As String, intID As Integer)
        Dim strQuery As String = $"INSERT INTO tblauditlog (logDateTime, logType, userID, logModule, logComment) VALUES 
                                    (now(), 4, {user.ID}, '{strForm}', 'Deactivated {strObject} - #{intID}') "
        SQLManager(strQuery)
    End Sub

    Public Sub executePrintlog(ByRef strQuery As String, strForm As String)
        strQuery += $"INSERT INTO tblauditlog (logDateTime, logType, userID, logModule, logComment) VALUES (now(), 5, {user.ID}, '{strForm}', 'Print Inactive and Active Pets.')"

    End Sub

    Public Sub executeLogout(user As UserLogin)
        Dim strQuery As String = $"INSERT INTO tblauditlog (logDateTime,logType, userID, logModule, logComment) VALUES 
                                    (now(), 6, {user.ID}, 'Main Form', 'Logout successfully') "
        SQLManager(strQuery)
    End Sub

End Module
