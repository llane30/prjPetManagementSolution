Public Class PetUpdate

    Private petID As Integer
    Private ownerID As Integer
    Private petName As String
    Private petBirthdate As String
    Private petGender As String
    Private petStatus As String
    Private breedID As Integer
    Private petNotes As String
    Private petOwner As petOwner
    Private petBreed As petBreed

    Public Sub New(intID As Integer)
        Dim dt As DataTable = GetDataTable($"SELECT * FROM tblpet WHERE petID = {intID}")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                petID = .Item("petID")
                ownerID = CType(.Item("ownerID"), Integer)
                petName = .Item("petName")
                petBirthdate = .Item("petBirthdate")
                petGender = .Item("petGender")
                petStatus = .Item("petStatus")
                BreedID = CType(.Item("petBreed"), Integer)
                petNotes = .Item("petNotes")
            End With
            'MsgBox($"{ownerID}, {petName}, {petBirthdate}, {petStatus}, {petBreed}, {petNotes}")
            petOwner = New petOwner(ownerID)
            petBreed = New petBreed(breedID)
        End If
    End Sub

    Public ReadOnly Property ID As Integer
        Get
            Return petID
        End Get
    End Property

    Public ReadOnly Property Owner As petOwner
        Get
            Return petOwner
        End Get
    End Property

    Public ReadOnly Property Breed As petBreed
        Get
            Return petBreed
        End Get
    End Property

    Public ReadOnly Property Type As petType
        Get
            Return petBreed.Type
        End Get
    End Property

    Public ReadOnly Property Name As String
        Get
            Return petName
        End Get
    End Property

    Public ReadOnly Property Birthdate As String
        Get
            Return petBirthdate
        End Get
    End Property

    Public ReadOnly Property Gender As String
        Get
            Return petGender
        End Get
    End Property

    Public ReadOnly Property Status As String
        Get
            Return petStatus
        End Get
    End Property

    Public ReadOnly Property Notes As String
        Get
            Return petNotes
        End Get
    End Property
End Class
