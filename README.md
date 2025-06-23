# 📚 Library Management Web Application

This is a simple ASP.NET Core MVC web application for managing a library’s books.  
You can **add, edit, delete, view, and filter books by year**.

---

## 🔧 Prerequisites

- **Visual Studio** (2017 or later) with **ASP.NET and web development** workload
- **.NET Core SDK 3.1** or later installed
- **SQL Server** (Express, LocalDB, or full instance)
- Internet connection to restore NuGet packages on first build

---

## 🚀 How to Open and Run the Project

### 1. Download and Open the Solution

- Clone or download the project folder to your machine
- Open the solution file:  
  `LibraryManagment.sln` in Visual Studio

### 2. Restore NuGet Packages

Visual Studio usually restores packages automatically. If not:

- Go to `Tools` > `NuGet Package Manager` > `Manage NuGet Packages for Solution...`
- Click **Restore**

### 3. Update the Connection String

Edit `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Your-SQL-Server-Connection-String-Here"
}
```

🗃️ Apply Migrations
Create and Apply Migrations (if not already applied)
In Visual Studio, open the Package Manager Console:
Tools → NuGet Package Manager → Package Manager Console

Run the following:
`
Add-Migration {migrationName}
'
'
Update-Database
`

▶️ Run the Application using F5
