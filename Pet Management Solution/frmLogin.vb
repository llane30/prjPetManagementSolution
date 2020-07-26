Public Class frmLogin

    Public user As UserLogin
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        user = New UserLogin(txtUsername.Text, txtPass.Text)
    End Sub
End Class