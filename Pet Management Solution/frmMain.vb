' Name:         Pet Management Solution
' Purpose:      Pet Management Solution with store to Database 
' Programmer:   Llanne Enumerables on July 15, 2020

Public Class frmMain
    Private pet As PetUpdate

    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs)
        dbConnection()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If user.Type <> "Admin" Then
            MenuSettings.Visible = False
        Else
            MenuSettings.Visible = True
        End If
        statusUser.Text = user.Type & ": " & user.FirstName & " " & user.LastName
        Dim strQuery As String
        dbConnection()
        strQuery = "SELECT petID, petName, petBirthdate, petGender, tbltype.typeName, " +
                    "tblbreed.breedName, petNotes, " +
                    "tblOwner.ownerName, tblOwner.ownerAddress, tblOwner.ownerContactNumber, petStatus " +
                    "FROM tblpet INNER JOIN tblbreed ON tblpet.petBreed = tblbreed.breedID " +
                    "INNER JOIN tbltype ON tbltype.typeID = tblbreed.typeID " +
                    "INNER JOIN tblowner ON tblowner.ownerID = tblpet.ownerID ORDER BY petID"
        DisplayRecords(strQuery, dgPets)

        txtID.Text = RecordCount("tblpet", "petID") + 1

        strQuery = "SELECT * FROM tblType"
        LoadToComboBox(strQuery, cboType, "typeID", "typeName", "typeStatus")

        strQuery = "SELECT breedID, breedName, typeID FROM tblbreed " +
                    "WHERE typeID =  " + cboType.SelectedValue.ToString
        LoadToComboBox(strQuery, cboBreed, "breedID", "breedName", "breedStatus")

        strQuery = "SELECT * FROM tblOwner"
        LoadToComboBox(strQuery, cboOwner, "ownerID", "ownerName", "ownerStatus")

        txtSearch.Text = String.Empty
        btnNew.Enabled = True
        btnSave.Enabled = True
        btnClose.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnNew.PerformClick()
    End Sub

    Private Sub cboType_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboType.SelectionChangeCommitted
        Dim strQuery As String
        Try
            strQuery = "SELECT breedID, breedName, typeID FROM tblbreed " +
                "WHERE typeID = " + cboType.SelectedValue.ToString
            LoadToComboBox(strQuery, cboBreed, "breedID", "breedName", "breedStatus")
        Catch ex As Exception
            MessageBox.Show("Error: CboType SelectedChangeCommitted() " & ex.Message, "Pet DBMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strQuery As String
        Try
            strQuery = "INSERT INTO tblpet (ownerID, petName, petBirthdate, petBreed, " +
                "petGender, petStatus, petNotes) " +
                "VALUES (" + cboOwner.SelectedValue.ToString +
                                ", '" + txtName.Text + "' " +
                                ", '" + CDate(txtBirthdate.Text).ToString("yyyy-MM-dd") + "' " +
                                ", '" + cboBreed.SelectedValue.ToString + "' " +
                                ", '" + cboGender.Text + "' " +
                                ", '" + cboStatus.Text + "' " +
                                ", '" + txtNotes.Text + "' ) "
            'MsgBox(strQuery)
            SQLManager(strQuery, "Record saved.")
            executeCreatelog("Main Form", "pet", Val(txtID.Text))
            txtID.Text = RecordCount("tblpet", "petID") + 1
            strQuery = "SELECT petID, petName, petGender, tbltype.typeName, tblbreed.breedName, " +
                            "petNotes, tblOwner.ownerName, tblOwner.ownerAddress, " +
                            "tblOwner.ownerContactNumber, petStatus  " +
                            "FROM tblpet INNER JOIN tblbreed ON tblpet.petBreed = tblbreed.breedID " +
                            "INNER JOIN tbltype ON tbltype.typeID = tblbreed.typeID " +
                            "INNER JOIN tblowner ON tblowner.ownerID = tblpet.ownerID ORDER BY petID "

            DisplayRecords(strQuery, dgPets)
        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub dgPets_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPets.CellClick
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
        btnPrint.Enabled = False
        btnSave.Enabled = False
        Dim i As Integer = e.RowIndex
        Try
            pet = New PetUpdate(CType(dgPets.Item("petID", i).Value, Integer))
            txtID.Text = pet.ID
            txtName.Text = pet.Name
            txtBirthdate.Text = pet.Birthdate
            cboGender.Text = pet.Gender
            cboType.SelectedValue = pet.Type.ID
            'Update cboBreed First before anything
            Dim strQuery As String
            Try
                strQuery = "SELECT breedID, breedName, typeID FROM tblbreed " +
                "WHERE typeID = " + cboType.SelectedValue.ToString
                LoadToComboBox(strQuery, cboBreed, "breedID", "breedName", "breedStatus")
            Catch ex As Exception
                MessageBox.Show("Error: CboType SelectedChangeCommitted() " & ex.Message, "Pet DBMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            'Resume Display of Click
            cboBreed.SelectedValue = pet.Breed.ID
            cboOwner.SelectedValue = pet.Owner.ID
            txtNotes.Text = pet.Notes
            cboStatus.Text = pet.Status
        Catch ex As Exception
            MessageBox.Show("Error: Datagrid CellClick() " & ex.Message, "Pet DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        'Able a button
        btnSave.Enabled = True
        btnPrint.Enabled = True
        btnClose.Enabled = True
        'Disable a button 
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        txtID.Text = RecordCount("tblpet", "petID") + 1
        txtName.Text = String.Empty
        If cboType.Items.Count > 0 Then
            cboType.SelectedIndex = 0
        End If
        If cboBreed.Items.Count > 0 Then
            cboBreed.SelectedIndex = 0
        End If
        If cboOwner.Items.Count > 0 Then
            cboOwner.SelectedIndex = 0
        End If
        cboGender.SelectedIndex = 0
        cboStatus.SelectedIndex = 0
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim strQuery As String
        pet.Name = txtName.Text.Trim
        pet.Birthdate = Date.ParseExact(txtBirthdate.Text, "dd/MM/yyyy", Nothing).ToString("MM/dd/yyyy")
        pet.Gender = cboGender.Text
        pet.Breed = New petBreed(cboBreed.SelectedValue)
        pet.Owner = New petOwner(cboOwner.SelectedValue)
        pet.Notes = txtNotes.Text.Trim
        pet.Status = cboStatus.Text
        Try
            strQuery = $"UPDATE tblpet SET petName='{pet.Name}', petBirthdate= '{Date.ParseExact(pet.Birthdate, "dd/MM/yyyy", Nothing).ToString("yyyy-MM-dd")}', petGender='{pet.Gender}', petBreed={pet.Breed.ID}, ownerID={pet.Owner.ID}, petNotes='{pet.Notes}', petStatus='{pet.Status}' WHERE petID={pet.ID}"
            If SQLManager(strQuery) Then
                SQLManager(pet.Auditlog)
                MsgBox("Record updated.")
            End If
            txtID.Text = RecordCount("tblpet", "petID") + 1
            strQuery = "SELECT petID, petName, petBirthdate, petGender, tbltype.typeName, tblbreed.breedName, " +
                            "petNotes, tblOwner.ownerName, tblOwner.ownerAddress, " +
                            "tblOwner.ownerContactNumber, petStatus  " +
                            "FROM tblpet INNER JOIN tblbreed ON tblpet.petBreed = tblbreed.breedID " +
                            "INNER JOIN tbltype ON tbltype.typeID = tblbreed.typeID " +
                            "INNER JOIN tblowner ON tblowner.ownerID = tblpet.ownerID ORDER BY petID "

            DisplayRecords(strQuery, dgPets)
        Catch ex As Exception
            MessageBox.Show("Error: Update() " & ex.Message, "Pet DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strQuery As String
        Try
            strQuery = "UPDATE tblpet SET petStatus='Inactive' WHERE petID=" & txtID.Text
            'MsgBox(strQuery)
            SQLManager(strQuery, "Record updated.")
            executeDeletelog("Main Form", "pet", Val(txtID.Text))
            txtID.Text = RecordCount("tblpet", "petID") + 1
            strQuery = "SELECT petID, petName, petBirthdate, petGender, tbltype.typeName, tblbreed.breedName, " +
                            "petNotes, tblOwner.ownerName, tblOwner.ownerAddress, " +
                            "tblOwner.ownerContactNumber, petStatus  " +
                            "FROM tblpet INNER JOIN tblbreed ON tblpet.petBreed = tblbreed.breedID " +
                            "INNER JOIN tbltype ON tbltype.typeID = tblbreed.typeID " +
                            "INNER JOIN tblowner ON tblowner.ownerID = tblpet.ownerID ORDER BY petID "
            DisplayRecords(strQuery, dgPets)
        Catch ex As Exception
            MessageBox.Show("Error: Delete() " & ex.Message, "Pet DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub btnAddType_Click(sender As Object, e As EventArgs) Handles btnAddType.Click
        Dim frm As frmPetType
        frm = New frmPetType
        frm.ShowDialog()
        txtID.Text = RecordCount("tblpet", "petID") + 1
        Dim strQuery As String = "SELECT * FROM tblType"
        LoadToComboBox(strQuery, cboType, "typeID", "typeName", "typeStatus")

    End Sub

    Private Sub btnAddOwner_Click(sender As Object, e As EventArgs) Handles btnAddOwner.Click
        Dim frm As frmPetOwner
        frm = New frmPetOwner
        frm.ShowDialog()
        txtID.Text = RecordCount("tblpet", "petID") + 1
        Dim strQuery As String = "SELECT * FROM tblOwner"
        LoadToComboBox(strQuery, cboOwner, "ownerID", "ownerName", "ownerStatus")
    End Sub

    Private Sub btnAddBreed_Click(sender As Object, e As EventArgs) Handles btnAddBreed.Click
        Dim frm As frmBreed
        frm = New frmBreed
        frm.PetType = cboType.Text
        frm.PetTypeID = cboType.SelectedValue
        frm.ShowDialog()
        txtID.Text = RecordCount("tblpet", "petID") + 1
        Dim strQuery As String = "SELECT breedID, breedName, typeID FROM tblbreed " +
                    "WHERE typeID =  " + cboType.SelectedValue.ToString
        LoadToComboBox(strQuery, cboBreed, "breedID", "breedName", "breedStatus")

    End Sub

    Private Sub rdoAll_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactive.CheckedChanged, rdoAll.CheckedChanged, rdoActive.CheckedChanged
        If rdoAll.Checked Then
            Dim strQuery As String = "SELECT petID, petName, petBirthdate, petGender, tbltype.typeName, tblbreed.breedName, " +
                           "petNotes, tblOwner.ownerName, tblOwner.ownerAddress, " +
                           "tblOwner.ownerContactNumber, petStatus  " +
                           "FROM tblpet INNER JOIN tblbreed ON tblpet.petBreed = tblbreed.breedID " +
                           "INNER JOIN tbltype ON tbltype.typeID = tblbreed.typeID " +
                           "INNER JOIN tblowner ON tblowner.ownerID = tblpet.ownerID ORDER BY petID "
            DisplayRecords(strQuery, dgPets)
        ElseIf rdoActive.Checked Then
            Dim strQuery As String = "SELECT petID, petName, petBirthdate, petGender, tbltype.typeName, tblbreed.breedName, " +
                           "petNotes, tblOwner.ownerName, tblOwner.ownerAddress, " +
                           "tblOwner.ownerContactNumber, petStatus  " +
                           "FROM tblpet INNER JOIN tblbreed ON tblpet.petBreed = tblbreed.breedID " +
                           "INNER JOIN tbltype ON tbltype.typeID = tblbreed.typeID " +
                           "INNER JOIN tblowner ON tblowner.ownerID = tblpet.ownerID WHERE petStatus='Active' ORDER BY petID "
            DisplayRecords(strQuery, dgPets)
        ElseIf rdoInactive.Checked Then
            Dim strQuery As String = "SELECT petID, petName, petBirthdate, petGender, tbltype.typeName, tblbreed.breedName, " +
                            "petNotes, tblOwner.ownerName, tblOwner.ownerAddress, " +
                            "tblOwner.ownerContactNumber, petStatus  " +
                            "FROM tblpet INNER JOIN tblbreed ON tblpet.petBreed = tblbreed.breedID " +
                            "INNER JOIN tbltype ON tbltype.typeID = tblbreed.typeID " +
                            "INNER JOIN tblowner ON tblowner.ownerID = tblpet.ownerID WHERE petStatus='Inactive' ORDER BY petID "
            DisplayRecords(strQuery, dgPets)

        End If
    End Sub


    'search data'
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        Dim strSearch As String = "'%" & txtSearch.Text & "%'"
        Dim strQuery As String = "SELECT petID, petName, petBirthdate, petGender, tbltype.typeName, tblbreed.breedname, 
                    petNotes, tblowner.ownerName, tblowner.ownerAddress, tblowner.ownerContactNumber, petStatus
                    FROM tblpet  
                    INNER JOIN tblbreed ON tblpet.petBreed = tblbreed.breedID  
                    INNER JOIN tbltype ON tbltype.typeID = tblbreed.typeID  
                    INNER JOIN tblowner on tblowner.ownerID = tblpet.ownerID  
                    WHERE petID LIKE " & strSearch & " OR
                          petName LIKE " & strSearch & " OR 
                          petBirthdate LIKE " & strSearch & " OR 
                          typeName LIKE " & strSearch & " OR 
                          breedname LIKE " & strSearch & " OR 
                          petNotes LIKE " & strSearch & " OR 
                          ownerName LIKE " & strSearch & " OR 
                          ownerAddress LIKE " & strSearch & " OR 
                          ownerContactNumber LIKE " & strSearch & " OR 
                          petStatus LIKE " & strSearch & "
                          ORDER BY petID"
        DisplayRecords(strQuery, dgPets)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim form As New frmAboutUs
        form.ShowDialog()

    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click
        Dim form As New frmUserInfo
        form.ShowDialog()
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        executeLogout(user)
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Dim form As New frmLogin
        form.Close()
        Me.Close()
    End Sub

    Private Sub strType_Click(sender As Object, e As EventArgs) Handles strType.Click
        Dim form As New frmPetType
        form.ShowDialog()
    End Sub

    Private Sub strOwner_Click(sender As Object, e As EventArgs) Handles strOwner.Click
        Dim form As New frmPetOwner
        form.ShowDialog()
    End Sub

    Private Sub strBreed_Click(sender As Object, e As EventArgs) Handles strBreed.Click
        Dim form As New frmBreed
        form.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim form As New frmPrintPet
        form.ShowDialog()
        Dim strQuery As String = String.Empty
        executePrintlog(strQuery, "Print form")
        'MsgBox(strQuery)
        SQLManager(strQuery)
    End Sub

    Private Sub AuditLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuditLogsToolStripMenuItem.Click
        Dim form As New frmAuditlog
        form.ShowDialog()
    End Sub
End Class
