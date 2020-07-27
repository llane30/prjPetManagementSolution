' Name:         Pet Management Solution
' Purpose:      Pet Management Solution with store to Database 
' Programmer:   Llanne Enumerables on July 15, 2020

Public Class frmMain

    Public user As UserLogin

    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click

        dbConnection()

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        LoadToComboBox(strQuery, cboType, "typeID", "typeName")

        strQuery = "SELECT breedID, breedName, typeID FROM tblbreed " +
                    "WHERE typeID =  " + cboType.SelectedValue.ToString
        LoadToComboBox(strQuery, cboBreed, "breedID", "breedName")

        strQuery = "SELECT * FROM tblOwner"
        LoadToComboBox(strQuery, cboOwner, "ownerID", "ownerName")


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
            LoadToComboBox(strQuery, cboBreed, "breedID", "breedName")

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
            MsgBox(strQuery)
            SQLManager(strQuery, "Record saved.")
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
            With dgPets
                txtID.Text = .Item("petID", i).Value
                txtName.Text = .Item("petName", i).Value
                txtBirthdate.Text = CDate(.Item("petBirthdate", i).Value).ToString("MM/dd/yyyy")
                cboGender.Text = .Item("petGender", i).Value
                cboType.Text = .Item("typeName", i).Value
                cboBreed.Text = .Item("breedName", i).Value
                txtNotes.Text = .Item("petNotes", i).Value
                cboStatus.Text = .Item("petStatus", i).Value
            End With
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
        'Disable a butoon
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        txtID.Text = RecordCount("tblpet", "petID") + 1
        txtName.Text = String.Empty
        cboType.SelectedIndex = 0
        cboBreed.SelectedIndex = 0
        cboOwner.SelectedIndex = 0
        cboGender.SelectedIndex = 0
        cboStatus.SelectedIndex = 0
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim strQuery As String
        Try
            strQuery = "UPDATE tblpet SET petName='" & txtName.Text & "', petBirthdate= '" & CDate(txtBirthdate.Text).ToString("yyyy-MM-dd") &
                        "', petGender='" & cboGender.Text & "', petBreed=" & cboBreed.SelectedValue.ToString & ", ownerID=" & cboOwner.SelectedValue.ToString &
                        ", petNotes='" & txtNotes.Text & "', petStatus='" & cboStatus.Text & "' WHERE petID=" & txtID.Text
            'MsgBox(strQuery)
            SQLManager(strQuery, "Record updated.")
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
        LoadToComboBox(strQuery, cboType, "typeID", "typeName")

    End Sub

    Private Sub btnAddOwner_Click(sender As Object, e As EventArgs) Handles btnAddOwner.Click
        Dim frm As frmPetOwner
        frm = New frmPetOwner
        frm.ShowDialog()
        txtID.Text = RecordCount("tblpet", "petID") + 1
        Dim strQuery As String = "SELECT * FROM tblOwner"
        LoadToComboBox(strQuery, cboOwner, "ownerID", "ownerName")
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
        LoadToComboBox(strQuery, cboBreed, "breedID", "breedName")

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
End Class
