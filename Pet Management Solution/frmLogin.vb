Public Class frmLogin
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim form As New frmMain
        user = New UserLogin(txtUsername.Text, txtPass.Text)
        If user.LoggedIn Then
            Me.Hide()
            form.ShowDialog()
            txtUsername.Clear()
            txtPass.Clear()
            Me.Show()
        ElseIf user.Username <> String.Empty AndAlso Not user.IsActive Then
            MessageBox.Show("User is Deactivated already!", "Pet DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("Access denied. Invalid username or password.", "Pet DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class