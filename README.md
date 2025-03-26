#  Care Provider Management System

## Packages Used

To set up the project, install the following .NET packages:

```sh
# Install Entity Framework Core tools
 dotnet tool install --global dotnet-ef

# Add required EF Core packages
 dotnet add package Microsoft.EntityFrameworkCore.SqlServer
 dotnet add package Microsoft.EntityFrameworkCore.Design
 dotnet add package Microsoft.EntityFrameworkCore.Tools
```

---

##  Database Scaffolding Command

Use the following command to scaffold the database models:

```sh
dotnet ef dbcontext scaffold "Server=SW0103002;Database=database_name;User Id=user_id;Password=password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
```

---

##  SQL Database Schema

###  Departments Table

```sql
CREATE TABLE Departments (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL
);
```

###  Care Providers Table

```sql
CREATE TABLE CareProviders (
    ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(255) NOT NULL,
    ContactInfo NVARCHAR(255),
    DepartmentID INT NOT NULL,
    IsActive BIT DEFAULT 1,  -- 1 for active, 0 for inactive (left hospital)
    YearsOfExperience INT CHECK (YearsOfExperience >= 0),
    CONSTRAINT FK_CareProviders_Department FOREIGN KEY (DepartmentID) REFERENCES Departments(ID) ON DELETE CASCADE
);
```

###  Achievements Table

```sql
CREATE TABLE Achievements (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CareProviderID UNIQUEIDENTIFIER NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    AchievementDate DATE,
    CONSTRAINT FK_Achievements_CareProvider FOREIGN KEY (CareProviderID) REFERENCES CareProviders(ID) ON DELETE CASCADE
);
```

###  Experiences Table

```sql
CREATE TABLE Experiences (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CareProviderID UNIQUEIDENTIFIER NOT NULL,
    HospitalName NVARCHAR(255) NOT NULL,
    Role NVARCHAR(255) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NULL,  -- NULL means currently working
    CONSTRAINT FK_Experiences_CareProvider FOREIGN KEY (CareProviderID) REFERENCES CareProviders(ID) ON DELETE CASCADE
);
```

---

##  Features

 Manage Care Providers, Achievements, and Experiences  
 Enforce data integrity with foreign key constraints  
 Support for active/inactive care provider tracking  
 Scalable SQL Server database structure  

---

##  How to Use

1. Clone the repository:
   ```sh
   git clone https://github.com/your-username/your-repository.git
   ```
2. Install dependencies:
   ```sh
   dotnet restore
   ```
3. Apply migrations and update the database:
   ```sh
   dotnet ef database update
   ```
4. Run the project:
   ```sh
   dotnet run
   ```

---


