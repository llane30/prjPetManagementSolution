Public Class frmPetType
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim strQuery As String
        Try
            strQuery = "INSERT INTO tbltype (typeName) VALUES ('" & txtType.Text & "') "
            'MsgBox(strQuery)
            SQLManager(strQuery, "Record saved.")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


End Class