Public Class frmAuditlog
    Private Sub frmAuditlog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strQuery As String = "Select logID as ID, logDateTime as Date, concat(userFirstname,' ',userLastname) as User, logModule as Form, logComment as Comment FROM tblauditlog LEFT JOIN tbluser USING(userID) "
        DisplayRecords(strQuery, dgAudits)
    End Sub
End Class