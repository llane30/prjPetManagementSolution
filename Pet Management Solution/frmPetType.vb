Public Class frmPetType
    Private type As petType
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim strQuery As String
        If btnAdd.Text.Contains("Add") Then
            Try
                strQuery = $"INSERT INTO tbltype VALUES ({txtID.Text}, '{txtType.Text}', 'Active') "
                'MsgBox(strQuery)
                SQLManager(strQuery, "Record saved.")
                executeCreatelog("Pet Type Form", "pet type", Val(txtID.Text))
            Catch ex As Exception
                MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            type.Name = txtType.Text
            Try
                strQuery = $"UPDATE tbltype SET  typeName='{type.Name}' WHERE typeID ={type.ID} "
                If SQLManager(strQuery) Then
                    SQLManager(type.Auditlog)
                    MsgBox("Record updated.")
                End If
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

    Private Sub frmPetType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnPlus.PerformClick()
    End Sub


    Private Sub btnPlus_Click(sender As Object, e As EventArgs) Handles btnPlus.Click
        txtID.Text = RecordCount("tbltype", "typeID") + 1
        btnAdd.Text = "Add"
        txtType.Clear()
        Dim strQuery As String = "SELECT * FROM tbltype"
        DisplayRecords(strQuery, dgType)
    End Sub

    Private Sub dgType_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgType.CellClick
        btnAdd.Text = "Update"
        Dim i As Integer = e.RowIndex
        Try
            With dgType
                type = New petType(CType(.Item("typeID", i).Value, Integer))
                txtID.Text = type.ID
                txtType.Text = type.Name
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnActive_Click(sender As Object, e As EventArgs) Handles btnActive.Click
        Dim strQuery As String
        Try
            strQuery = $"UPDATE tbltype SET typeStatus='Active'  WHERE typeID ={txtID.Text} "
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
            strQuery = $"UPDATE tbltype SET typeStatus='Inactive'  WHERE typeID ={txtID.Text} "
            'MsgBox(strQuery)
            SQLManager(strQuery, "Record updated.")
            executeDeletelog("Pet Type Form", "pet type", Val(txtID.Text))
            btnPlus.PerformClick()
        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class