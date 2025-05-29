Imports MySql.Data.MySqlClient
Imports System.Globalization
Imports System.Threading
Public Class Form1
    Dim connStr As String = "server=localhost;user id=root;password=;database=todo_app"
    Dim conn As New MySqlConnection(connStr)
    Public loggedInUser As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' สร้างคอลัมน์
        dgvTasks.ColumnCount = 3
        dgvTasks.Columns.Add("task_id", "ID")
        dgvTasks.Columns("task_id").Visible = False
        dgvTasks.Columns(0).Name = "Task"
        dgvTasks.Columns(1).Name = "Status"
        dgvTasks.Columns(2).Name = "Due Date"
        dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' use calendar global
        Dim culture As New CultureInfo("en-US")
        culture.DateTimeFormat.Calendar = New GregorianCalendar()
        Thread.CurrentThread.CurrentCulture = culture
        Thread.CurrentThread.CurrentUICulture = culture

        ' settind date pickup
        dtpDueDate.Format = DateTimePickerFormat.Short
        dtpDueDate.MinDate = DateTime.Today
        dtpDueDate.Value = DateTime.Today
        LoadTasks()
    End Sub

    Dim isEditing As Boolean = False
    Dim editingRowIndex As Integer = -1

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtTask.Text.Trim() = "" Then
            MessageBox.Show("Please input a task.")
            Return
        End If

        If dtpDueDate.Value.Date < DateTime.Today Then
            MessageBox.Show("Due date cannot be in the past.")
            Return
        End If

        Dim connStr As String = "server=localhost;user id=root;password=;database=todo_app"

        If isEditing AndAlso editingRowIndex >= 0 Then
            ' กำลังแก้ไข
            Dim taskId = dgvTasks.Rows(editingRowIndex).Cells("task_id").Value

            Using conn As New MySqlConnection(connStr)
                Try
                    conn.Open()
                    Dim query As String = "UPDATE tasks SET task_name=@task, due_date=@due_date WHERE id=@id AND user_create=@user"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@task", txtTask.Text.Trim())
                        cmd.Parameters.AddWithValue("@due_date", dtpDueDate.Value.ToString("yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@id", taskId)
                        cmd.Parameters.AddWithValue("@user", loggedInUser)
                        cmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Task updated successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadTasks()
                Catch ex As Exception
                    MessageBox.Show("Error updating task: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using

            isEditing = False
            editingRowIndex = -1
            btnAdd.Text = "Add"
            ResetEditing()
            Return
        End If

        ' เพิ่ม Task ใหม่
        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                Dim query As String = "INSERT INTO tasks (task_name, status, due_date, user_create) VALUES (@task, @status, @due_date, @user)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@task", txtTask.Text.Trim())
                    cmd.Parameters.AddWithValue("@status", "Unfinished")
                    cmd.Parameters.AddWithValue("@due_date", dtpDueDate.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@user", loggedInUser)

                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTasks()
            Catch ex As Exception
                MessageBox.Show("Error adding task: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        ResetEditing()
    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvTasks.CurrentRow Is Nothing OrElse dgvTasks.CurrentRow.Index >= dgvTasks.Rows.Count - 1 Then
            MessageBox.Show("Please select a task to edit.")
            Return
        End If

        txtTask.Text = dgvTasks.CurrentRow.Cells(0).Value.ToString()

        ' ตรวจสอบว่าข้อมูลวันที่ถูกต้องหรือไม่ก่อนพยายามแปลง
        Dim dueDateString = dgvTasks.CurrentRow.Cells(2).Value.ToString()
        Dim parsedDate As DateTime
        If DateTime.TryParse(dueDateString, parsedDate) Then
            dtpDueDate.Value = parsedDate
        Else
            dtpDueDate.Value = DateTime.Today
        End If

        editingRowIndex = dgvTasks.CurrentRow.Index
        isEditing = True
        btnAdd.Text = "Save"
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvTasks.CurrentRow Is Nothing OrElse dgvTasks.CurrentRow.Index >= dgvTasks.Rows.Count - 1 Then
            MessageBox.Show("Please select a task to delete.")
            Return
        End If

        Dim result = MessageBox.Show("Are you sure to delete this task?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Dim taskId = dgvTasks.CurrentRow.Cells(3).Value
            Dim connStr As String = "server=localhost;user id=root;password=;database=todo_app"
            Using conn As New MySqlConnection(connStr)
                Try
                    conn.Open()
                    Dim query As String = "DELETE FROM tasks WHERE id=@id AND user_create=@user"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", taskId)
                        cmd.Parameters.AddWithValue("@user", loggedInUser)
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Task deleted successfully!")
                    End Using
                    LoadTasks()
                Catch ex As Exception
                    MessageBox.Show("Error deleting task: " & ex.Message)
                End Try
            End Using
        End If
        ResetEditing()
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        If dgvTasks.CurrentRow Is Nothing OrElse dgvTasks.CurrentRow.Index >= dgvTasks.Rows.Count - 1 Then
            MessageBox.Show("Please select a task to mark as done.")
            Return
        End If

        Dim taskId = dgvTasks.CurrentRow.Cells(3).Value
        Dim connStr As String = "server=localhost;user id=root;password=;database=todo_app"
        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                Dim query As String = "UPDATE tasks SET status='Done' WHERE id=@id AND user_create=@user"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", taskId)
                    cmd.Parameters.AddWithValue("@user", loggedInUser)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Task marked as done!")
                End Using
                LoadTasks()
            Catch ex As Exception
                MessageBox.Show("Error marking task as done: " & ex.Message)
            End Try
        End Using
        ResetEditing()
    End Sub


    Private Sub ResetEditing()
        isEditing = False
        editingRowIndex = -1
        btnAdd.Text = "Add"
        txtTask.Clear()
        dtpDueDate.Value = DateTime.Today
    End Sub
    Private Sub LoadTasks()
        dgvTasks.Rows.Clear()

        Dim connStr As String = "server=localhost;user id=root;password=;database=todo_app"
        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                Dim query As String = "SELECT id, task_name, status, due_date FROM tasks WHERE user_create = @user"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@user", loggedInUser)
                    Dim reader = cmd.ExecuteReader()

                    While reader.Read()
                        dgvTasks.Rows.Add(reader("task_name"), reader("status"), CDate(reader("due_date")).ToString("dd-MM-yyyy"), reader("id"))
                    End While
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading tasks: " & ex.Message)
            End Try
        End Using
    End Sub
End Class