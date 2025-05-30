-----------EN---------------------------------------
# 📝 VB.NET To-Do List Application
A simple and elegant To-Do List desktop application built with **VB.NET (WinForms)** and **MySQL** as the back-end database. 
This project is designed for personal task management, allowing users to add, edit, delete, and filter tasks by status.
## ✨ Features
- ✅ User login system
- 📋 Add / Edit / Delete tasks
- 🎨 Status highlighting
- 🔍 View tasks filtered by the logged-in user only
- 🛠 MySQL backend for persistent data storage
-----------TH---------------------------------------
  # 📝 To-Do List ส่วนตัวด้วย VB.NET + MySQL

ระบบจัดการงานส่วนตัว (To-Do List) ที่พัฒนาโดยใช้ VB.NET พร้อมเชื่อมต่อฐานข้อมูล MySQL สามารถจัดการงานตามสถานะ และแสดงผลเฉพาะงานของผู้ใช้งานที่เข้าสู่ระบบ

## 🔧 ฟีเจอร์หลัก

- ✅ ระบบการล็อกอินและสมัครสมาชิก
- 📋 สร้าง แก้ไข และลบ งานของตัวเองได้
- 🎨 เปลี่ยนสถานะของงานได้
- 🔍 แสดงเฉพาะงานของผู้ใช้งานที่ล็อกอิน
- - 🛠 ใช้ MySQL เป็นตัวbackendในการจัดเก็บข้อมูล

## 🗃️ โครงสร้างฐานข้อมูล (MySQL)

**ฐานข้อมูล:** `todo_app`  
**ตาราง:** `users`, `tasks`

### ตาราง `users`

| ชื่อคอลัมน์ | ประเภทข้อมูล | รายละเอียด |
|-------------|---------------|-------------|
| id          | INT AUTO_INCREMENT | Primary Key |
| username    | VARCHAR(50)   | ไม่ซ้ำกัน |
| password    | VARCHAR(100)  | รหัสผ่านของผู้ใช้ |

### ตาราง `tasks`

| ชื่อคอลัมน์ | ประเภทข้อมูล | รายละเอียด |
|-------------|---------------|-------------|
| id          | INT AUTO_INCREMENT | Primary Key |
| user_id     | INT           | Foreign Key เชื่อมกับ users.id |
| title       | VARCHAR(100)  | ชื่องาน |
| status      | VARCHAR(20)   | สถานะ (pending, in_progress, done) |
| due_date    | DATE          | วันครบกำหนด |
| created_at  | DATETIME      | วันที่สร้างงาน |

### สิ่งที่จำเป็นต้องติดตั้ง
- Visual Basic .NET (Windows Forms)
- MySQL (ผ่าน XAMPP หรือ MySQL Server)
- MySql.Data (ไลบรารีเชื่อมต่อ MySQL)

