Public Class petOwner

    Private ownerID As Integer
    Private ownerName As String
    Private ownerAddress As String
    Private ownerContactNumber As String
    Private ownerStatus As String

    Public Sub New(intID As Integer)
        Dim dt As DataTable = GetDataTable($"SELECT * FROM tblowner WHERE ownerID = {intID}")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                ownerID = intID
                ownerName = .Item("ownerName")
                ownerAddress = .Item("ownerAddress")
                ownerContactNumber = .Item("ownerContactNumber")
                ownerStatus = .Item("ownerStatus")
            End With
            'MsgBox($"{ownerID}, {ownerName}, {ownerAddress}, {ownerAddress}, {ownerContactNumber}, {ownerStatus}")
        End If
    End Sub

    Public ReadOnly Property ID As Integer
        Get
            Return ownerID
        End Get
    End Property
End Class
