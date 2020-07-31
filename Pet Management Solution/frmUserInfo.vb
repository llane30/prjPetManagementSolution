Public Class frmUserInfo
    Private account As UserLogin
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
            account.FirstName = txtfname.Text
            account.LastName = txtLname.Text
            account.ContactNumber = txtContact.Text
            account.Username = txtUsername.Text
            account.Password = txtPass.Text
            account.Type = cboType.SelectedIndex
            Try
                If txtPass.Text = String.Empty AndAlso txtConfirmPass.Text = String.Empty Then
                    strQuery = $"UPDATE tbluser SET  userFirstname='{account.FirstName}', userLastname='{account.LastName}', userContactNum='{account.ContactNumber}', userName='{account.Username}', userType='{account.Type}' WHERE userID ={account.ID} "
                ElseIf txtPass.Text = txtConfirmPass.Text Then
                    strQuery = $"UPDATE tbluser SET  userFirstname='{account.FirstName}', userLastname='{account.LastName}', userContactNum='{account.ContactNumber}', userName='{account.Username}', userPassword=md5('{txtPass.Text}'),  userType='{account.Type}' WHERE userID ={account.ID} "
                    If SQLManager(strQuery) Then
                        SQLManager(account.Auditlog)
                        MsgBox("Record updated.")
                    End If
                End If
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
        Try
            With dgUser
                account = New UserLogin(CType(.Item("userID", i).Value, Integer))
                txtID.Text = account.ID
                txtfname.Text = account.FirstName
                txtLname.Text = account.LastName
                txtContact.Text = account.ContactNumber
                txtUsername.Text = account.Username
                cboType.SelectedIndex = account.Type
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class