Public Class UserLogin
    Private strUsername As String
    Private strPassword As String
    Private strFirstname As String
    Private strLastname As String
    Private intType As String
    Private strType As String
    Private boolLogin As Boolean

    'Constructor
    Public Sub New(strUser As String, strPass As String)
        Dim strSQL As String = "SELECT * FROM tblUser WHERE userName='" & strUser & "' AND userPassword=md5('" & strPass & "') LIMIT 1"
        Dim dt = GetDataTable(strSQL)

        If dt.Rows.Count() > 0 Then
            strUsername = dt.Rows(0).Item("userName").ToString
            strFirstname = dt.Rows(0).Item("userFirstname").ToString
            strLastname = dt.Rows(0).Item("userLastname").ToString
            intType = CType(dt.Rows(0).Item("userType"), Integer)

            strType = If(intType = 0, "Encoder", "Admin")
            boolLogin = True
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

End Class
