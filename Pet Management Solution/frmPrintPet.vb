Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CystalDecision.Shared
Public Class frmPrintPet
    Private Sub frmPrintPet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        crPets1.SummaryInfo.ReportTitle = My.Application.Info.ProductName
        crPets1.SummaryInfo.ReportAuthor = $"By: {user.FirstName} {user.LastName}"
        Dim strQuery As String
        strQuery = "Select petID, petName, DATE_FORMAT(petBirthdate,' %M %d %Y') as petBirthdate, petGender, petStatus FROM tblpet ORDER BY petStatus"
        crPets1.SetDataSource(GetDataTable(strQuery))
        CrystalReportViewer1.ReportSource = crPets1
        CrystalReportViewer1.Refresh()
        For Each ctrl As Control In CrystalReportViewer1.Controls
            If TypeOf ctrl Is System.Windows.Forms.ToolStrip Then
                AddHandler(CType(ctrl, ToolStrip).Items(1).Click), AddressOf AfterPrint
            End If
        Next
    End Sub
    Private Sub AfterPrint(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class