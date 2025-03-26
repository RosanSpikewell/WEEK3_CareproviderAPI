🚀 Care Provider Management System

📦 Packages Used

To set up the project, install the following .NET packages:

# Install Entity Framework Core tools
 dotnet tool install --global dotnet-ef

# Add required EF Core packages
 dotnet add package Microsoft.EntityFrameworkCore.SqlServer
 dotnet add package Microsoft.EntityFrameworkCore.Design
 dotnet add package Microsoft.EntityFrameworkCore.Tools

⚙️ Database Scaffolding Command

Use the following command to scaffold the database models:

dotnet ef dbcontext scaffold "Server=SW0103002;Database=database_name;User Id=user_id;Password=password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models

🗄️ SQL Database Schema

📌 Departments Table

CREATE TABLE Departments (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL
);

📌 Care Providers Table

CREATE TABLE CareProviders (
    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(255) NOT NULL,
    ContactInfo NVARCHAR(255),
    DepartmentID INT NOT NULL,
    IsActive BIT DEFAULT 1,  -- 1 for active, 0 for inactive (left hospital)
    YearsOfExperience INT CHECK (YearsOfExperience >= 0),
    CONSTRAINT FK_CareProviders_Department FOREIGN KEY (DepartmentID) REFERENCES Departments(ID) ON DELETE CASCADE
);

📌 Achievements Table

CREATE TABLE Achievements (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CareProviderID UNIQUEIDENTIFIER NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    AchievementDate DATE,
    CONSTRAINT FK_Achievements_CareProvider FOREIGN KEY (CareProviderID) REFERENCES CareProviders(ID) ON DELETE CASCADE
);

📌 Experiences Table

CREATE TABLE Experiences (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CareProviderID UNIQUEIDENTIFIER NOT NULL,
    HospitalName NVARCHAR(255) NOT NULL,
    Role NVARCHAR(255) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NULL,  -- NULL means currently working
    CONSTRAINT FK_Experiences_CareProvider FOREIGN KEY (CareProviderID) REFERENCES CareProviders(ID) ON DELETE CASCADE
);

🎯 Features

✅ Manage Care Providers, Achievements, and Experiences
✅ Enforce data integrity with foreign key constraints
✅ Support for active/inactive care provider tracking
✅ Scalable SQL Server database structure

📌 How to Use

Clone the repository:

git clone https://github.com/your-username/your-repository.git

Install dependencies:

dotnet restore

Apply migrations and update the database:

dotnet ef database update

Run the project:

dotnet run

📜 License

This project is licensed under the MIT License. Feel free to modify and use it as needed.
