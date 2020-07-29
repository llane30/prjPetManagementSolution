Public Class petBreed

    Private petType As petType
    Private breedID As Integer
    Private breedname As String
    Private typeID As Integer
    Private breedStatus As String

    Public Sub New(intID As Integer)
        Dim dt As DataTable = GetDataTable($"SELECT * FROM tblbreed WHERE breedID = {intID}")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                breedID = intID
                breedname = .Item("breedname")
                typeID = CType(.Item("typeID"), Integer)
                breedStatus = .Item("breedStatus")
            End With
            petType = New petType(typeID)
            'MsgBox($"{breedID}, {breedname}, {typeID}, {breedStatus}")
        End If
    End Sub

    Public ReadOnly Property Type As petType
        Get
            Return petType
        End Get
    End Property

    Public ReadOnly Property ID As Integer
        Get
            Return breedID
        End Get
    End Property

End Class
