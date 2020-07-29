Public Class frmUserInfo
    Private Sub btnPlus_Click(sender As Object, e As EventArgs) Handles btnPlus.Click
        txtID.Text = RecordCount("tbluser", "userID") + 1
        btnAdd.Text = "Add"
        txtfname.Clear()
        txtLname.Clear()
        txtContact.Clear()
        txtUsername.Clear()
        txtPass.Clear()
        txtConfirmPass.Clear()
        cboType.SelectedIndex = 0
        Dim strQuery As String = "SELECT userID, userFirstname, userLastname, userContactNum, userName, userType FROM tbluser"
        DisplayRecords(strQuery, dgUser)
    End Sub

    Private Sub frmUserInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnPlus.PerformClick()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim strQuery As String = String.Empty
        If btnAdd.Text.Contains("Add") Then
            If txtPass.Text <> String.Empty AndAlso txtPass.Text = txtConfirmPass.Text Then
                Try
                    strQuery = $"INSERT INTO tbluser VALUES ({txtID.Text}, '{txtfname.Text}', '{txtLname.Text}', '{txtContact.Text}', '{txtUsername.Text}', md5('{txtPass.Text}'), '{cboType.SelectedIndex}', 'Active') "
                    'MsgBox(strQuery)
                    SQLManager(strQuery, "Record saved.")
                    executeCreatelog("User Form", "user account", Val(txtID.Text))
                Catch ex As Exception
                    MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show("Password Mismatch. Retype your password.", "Pet DBMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            Try
                If txtPass.Text = String.Empty AndAlso txtConfirmPass.Text = String.Empty Then
                    strQuery = $"UPDATE tbluser SET  userFirstname='{txtfname.Text}', userLastname='{txtLname.Text}', userContactNum='{txtContact.Text}', userName='{txtUsername.Text}', userType='{cboType.SelectedIndex}' WHERE userID ={txtID.Text} "
                ElseIf txtPass.Text = txtConfirmPass.Text Then
                    strQuery = $"UPDATE tbluser SET  userFirstname='{txtfname.Text}', userLastname='{txtLname.Text}', userContactNum='{txtContact.Text}', userName='{txtUsername.Text}', userPassword=md5('{txtPass.Text}'),  userType='{cboType.SelectedIndex}' WHERE userID ={txtID.Text} "
                End If
                SQLManager(strQuery, "Record updated.")
            Catch ex As Exception
                MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        btnPlus.PerformClick()
    End Sub

    Private Sub btnActive_Click(sender As Object, e As EventArgs) Handles btnActive.Click
        Dim strQuery As String
        Try
            strQuery = $"UPDATE tbluser SET userStatus='Active'  WHERE userID ={txtID.Text} "
            SQLManager(strQuery, "Record updated.")
            btnPlus.PerformClick()
        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDeactivate_Click(sender As Object, e As EventArgs) Handles btnDeactivate.Click
        Dim strQuery As String
        Try
            strQuery = $"UPDATE tbluser SET userStatus='Inactive'  WHERE userID ={txtID.Text} "
            SQLManager(strQuery, "Record updated.")
            executeDeletelog("Pet User Form", "pet account", Val(txtID.Text))
            btnPlus.PerformClick()
        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgUser_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgUser.CellClick
        btnAdd.Text = "Update"
        Dim i As Integer = e.RowIndex
        With dgUser
            txtID.Text = .Item("userID", i).Value
            txtfname.Text = .Item("userFirstname", i).Value
            txtLname.Text = .Item("userLastname", i).Value
            txtContact.Text = .Item("userContactNum", i).Value
            txtUsername.Text = .Item("userName", i).Value
            cboType.SelectedIndex = .Item("userType", i).Value
        End With
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class