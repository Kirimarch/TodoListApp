Imports MySql.Data.MySqlClient
Public Class FormLogin

    Private actualPassword As String = ""
    Dim connStr As String = "server=localhost;user id=root;password=;database=todo_app"
    Dim conn As New MySqlConnection(connStr)
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If username = "" Or password = "" Then
            MessageBox.Show("Please enter both username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim connStr As String = "server=localhost;user id=root;password=;database=todo_app"
        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM users WHERE username=@username AND password=@password"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)
                    Dim reader = cmd.ExecuteReader()

                    If reader.HasRows Then
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Hide()
                        Form1.loggedInUser = username
                        Form1.Show()
                        txtUsername.Clear()
                        txtPassword.Clear()
                    Else
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtUsername.Clear()
                        txtPassword.Clear()
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Database connection error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub lnkRegister_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRegister.LinkClicked
        FormRegister.Show()
        Me.Hide()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text.Length >= 2 AndAlso txtPassword.PasswordChar <> "●"c Then
            txtPassword.PasswordChar = "●"c
        End If
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtPassword.PasswordChar = ControlChars.NullChar '
    End Sub
End Class