Public Class petType

    Private typeID As Integer
    Private typeName As String
    Private typeStatus As String

    Public Sub New(intID As Integer)
        Dim dt As DataTable = GetDataTable($"SELECT * FROM tbltype WHERE typeID = {intID}")
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                typeID = intID
                typeName = .Item("typeName")
                typeStatus = .Item("typeStatus")
            End With
            'MsgBox($"{typeID}, {typeName}, {typeStatus}")
        End If
    End Sub

    Public ReadOnly Property ID As Integer
        Get
            Return typeID
        End Get
    End Property

End Class
