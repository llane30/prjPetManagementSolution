Public Class frmBreed
    Private breed As petBreed
    Private _strPetType As String
    Private _intPetTypeID As Integer
    Public WriteOnly Property PetType As String
        Set(value As String)
            _strPetType = value
        End Set
    End Property

    Public WriteOnly Property PetTypeID As Integer
        Set(value As Integer)
            _intPetTypeID = value
        End Set
    End Property

    Private Sub frmBreed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnPlus.PerformClick()
        cbPetType.SelectedValue = _intPetTypeID
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim strQuery As String
        If btnAdd.Text.Contains("Add") Then
            Try
                strQuery = $"INSERT INTO tblbreed VALUES ({txtID.Text}, '{txtBreed.Text}', '{cbPetType.SelectedValue}' , 'Active' )"
                SQLManager(strQuery, "Record saved.")
                executeCreatelog("Pet Breed Form", "pet breed", Val(txtID.Text))
            Catch ex As Exception
                MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            breed.Name = txtBreed.Text
            breed.Type = New petType(cbPetType.SelectedValue)
            Try
                strQuery = $"UPDATE tblbreed SET breedname='{breed.Name}', typeID={breed.Type.ID} WHERE breedID ={breed.ID}"
                If SQLManager(strQuery) Then
                    SQLManager(breed.Auditlog)
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

    Private Sub btnPlus_Click(sender As Object, e As EventArgs) Handles btnPlus.Click
        Dim strQuery As String = "SELECT * FROM tblType"
        LoadToComboBox(strQuery, cbPetType, "typeID", "typeName", "typeStatus")
        txtID.Text = RecordCount("tblbreed", "breedID") + 1
        cbPetType.SelectedIndex = 0
        btnAdd.Text = "Add"
        txtBreed.Clear()
        strQuery = "SELECT * FROM tblbreed"
        DisplayRecords(strQuery, dgBreed)
    End Sub

    Private Sub btnActive_Click(sender As Object, e As EventArgs) Handles btnActive.Click
        Dim strQuery As String
        Try
            strQuery = $"UPDATE tblbreed SET breedStatus='Active'  WHERE breedID ={txtID.Text} "
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
            strQuery = $"UPDATE tblbreed SET breedStatus='Inactive'  WHERE breedID ={txtID.Text} "
            SQLManager(strQuery, "Record updated.")
            executeDeletelog("Pet Breed Form", "pet breed", Val(txtID.Text))
            btnPlus.PerformClick()
        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgBreed_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBreed.CellClick
        btnAdd.Text = "Update"
        Dim i As Integer = e.RowIndex
        Try
            With dgBreed
                breed = New petBreed(CType(.Item("breedID", i).Value, Integer))
                txtID.Text = breed.ID
                cbPetType.SelectedValue = breed.Type.ID
                txtBreed.Text = breed.Name
            End With
        Catch ex As Exception
        End Try
    End Sub
End Class