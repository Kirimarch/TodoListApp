Imports MySql.Data.MySqlClient
Public Class FormRegister
    Dim connStr As String = "server=localhost;user id=root;password=;database=todo_app"
    Dim conn As New MySqlConnection(connStr)
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text
        Dim confirmPassword As String = txtConfirm.Text

        ' ตรวจสอบข้อมูลเบื้องต้น
        If username = "" Or password = "" Or confirmPassword = "" Then
            MessageBox.Show("Please fill in all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If password <> confirmPassword Then
            MessageBox.Show("Passwords do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' เชื่อมต่อฐานข้อมูล
        Dim connStr As String = "server=localhost;user id=root;password=;database=todo_app"
        Dim conn As New MySqlConnection(connStr)

        Try
            conn.Open()

            ' ตรวจสอบว่า username ซ้ำไหม
            Dim checkCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE username = @username", conn)
            checkCmd.Parameters.AddWithValue("@username", username)
            Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

            If count > 0 Then
                MessageBox.Show("Username already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' บันทึกข้อมูล
            Dim insertCmd As New MySqlCommand("INSERT INTO users (username, password) VALUES (@username, @password)", conn)
            insertCmd.Parameters.AddWithValue("@username", username)
            insertCmd.Parameters.AddWithValue("@password", password)
            insertCmd.ExecuteNonQuery()

            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' กลับหน้า Login
            FormLogin.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub lnkLogin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLogin.LinkClicked
        FormLogin.Show()
        Me.Close()
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        Dim showPassword As Boolean = Not chkShowPassword.Checked
        txtPassword.UseSystemPasswordChar = showPassword
        txtConfirm.UseSystemPasswordChar = showPassword
    End Sub

    Private Sub FormRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.UseSystemPasswordChar = True
        txtConfirm.UseSystemPasswordChar = True
    End Sub
End Class