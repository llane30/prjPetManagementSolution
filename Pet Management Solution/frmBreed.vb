Public Class frmBreed
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
        txtPetType.Text = _strPetType

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim strQuery As String
        Try
            strQuery = "INSERT INTO tblbreed (breedname,typeID) VALUES ('" & txtBreed.Text & "', " & _intPetTypeID.ToString & " ) "
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