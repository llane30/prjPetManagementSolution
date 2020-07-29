Public Class frmPetOwner
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim strQuery As String
        If btnAdd.Text.Contains("Add") Then
            Try
                strQuery = $"INSERT INTO tblowner VALUES ({txtID.Text}, '{txtName.Text}', '{txtAddress.Text}', '{txtPhone.Text}', 'Active')"
                SQLManager(strQuery, "Record saved.")
                executeCreatelog("Pet Owner Form", "pet owner", Val(txtID.Text))
            Catch ex As Exception
                MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Try
                strQuery = $"UPDATE tblowner SET ownerName='{txtName.Text}', ownerAddress='{txtAddress.Text}', ownerContactNumber='{txtPhone.Text}' WHERE ownerID ={txtID.Text} "
                'MsgBox(strQuery)
                SQLManager(strQuery, "Record updated.")
            Catch ex As Exception
                MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        btnPlus.PerformClick()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmPetOwner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnPlus.PerformClick()
    End Sub

    Private Sub dgOwner_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgOwner.CellClick
        btnAdd.Text = "Update"
        Dim i As Integer = e.RowIndex
        With dgOwner
            txtID.Text = .Item("ownerID", i).Value
            txtName.Text = .Item("ownerName", i).Value
            txtAddress.Text = .Item("ownerAddress", i).Value
            txtPhone.Text = .Item("ownerContactNumber", i).Value
        End With
    End Sub

    Private Sub btnActive_Click(sender As Object, e As EventArgs) Handles btnActive.Click
        Dim strQuery As String
        Try
            strQuery = $"UPDATE tblowner SET ownerStatus='Active'  WHERE ownerID ={txtID.Text} "
            'MsgBox(strQuery)
            SQLManager(strQuery, "Record updated.")
            btnPlus.PerformClick()
        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDeactive_Click(sender As Object, e As EventArgs) Handles btnDeactive.Click
        Dim strQuery As String
        Try
            strQuery = $"UPDATE tblowner SET ownerStatus='Inactive'  WHERE ownerID ={txtID.Text} "
            'MsgBox(strQuery)
            SQLManager(strQuery, "Record updated.")
            executeDeletelog("Pet Owner Form", "pet owner", Val(txtID.Text))
            btnPlus.PerformClick()
        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub btnPlus_Click(sender As Object, e As EventArgs) Handles btnPlus.Click
        txtID.Text = RecordCount("tblOwner", "ownerID") + 1
        btnAdd.Text = "Add"
        txtName.Clear()
        txtAddress.Clear()
        txtPhone.Clear()
        Dim strQuery As String = "SELECT * FROM tblowner"
        DisplayRecords(strQuery, dgOwner)
    End Sub
End Class