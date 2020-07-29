Public Class UserLogin
    Private intID As Integer
    Private strUsername As String
    Private strPassword As String
    Private strFirstname As String
    Private strLastname As String
    Private intType As String
    Private strType As String
    Private boolLogin As Boolean
    Private strStatus As String

    'Constructor
    Public Sub New(strUser As String, strPass As String)
        Dim strSQL As String = $"SELECT * FROM tblUser WHERE userName='{strUser}' LIMIT 1"
        Dim dt = GetDataTable(strSQL)
        Dim IsValid As Boolean
        If dt.Rows.Count() > 0 Then
            With dt.Rows(0)
                intID = CType(.Item("userID"), Integer)
                strUsername = .Item("userName").ToString
                strFirstname = .Item("userFirstname").ToString
                strLastname = .Item("userLastname").ToString
                intType = CType(.Item("userType"), Integer)
                strType = If(intType = 0, "Encoder", "Admin")
                strStatus = .Item("userStatus").ToString
            End With
            strSQL = $"SELECT userPassword=md5('{strPass}') AS IsValid FROM tbluser WHERE userID={intID}"
            dt = GetDataTable(strSQL)
            IsValid = CType(dt.Rows(0).Item("IsValid"), Integer) = 1
            If IsValid AndAlso strStatus = "Active" Then
                boolLogin = True
                executeSuccesslog(intID)
            Else
                boolLogin = False
                executeUnsuccesslog(intID)
            End If
        Else
            boolLogin = False
        End If
    End Sub

    Public ReadOnly Property LoggedIn As Boolean
        Get
            Return boolLogin
        End Get
    End Property

    Public ReadOnly Property Username As String
        Get
            Return strUsername
        End Get
    End Property

    Public ReadOnly Property FirstName As String
        Get
            Return strFirstname
        End Get
    End Property

    Public ReadOnly Property LastName As String
        Get
            Return strLastname
        End Get
    End Property

    Public ReadOnly Property Type As String
        Get
            Return strType
        End Get
    End Property

    Public ReadOnly Property IsActive As Boolean
        Get
            Return strStatus = "Active"
        End Get
    End Property

    Public ReadOnly Property ID As Integer
        Get
            Return intID
        End Get
    End Property
End Class
