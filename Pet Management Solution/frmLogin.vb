Public Class frmLogin

    Public user As UserLogin
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim form As New frmMain
        Dim user As New UserLogin(txtUsername.Text, txtPass.Text)
        If user.LoggedIn Then
            Me.Hide()
            form.user = user
            form.ShowDialog()
            txtUsername.Clear()
            txtPass.Clear()
            Me.Show()
        Else
            MessageBox.Show("Access denied. Invalid username or password.", "Pet DBMS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
    End Sub

End Class