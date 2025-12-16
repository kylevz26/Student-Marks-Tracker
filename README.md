# Student-Marks-Tracker
A simple ASP.NET Core MVC application designed to manage student profiles and track academic performance.

## Overview

The project allows administrators to:
1.  Manage Student profiles (Create, Read, Update, Delete).
2.  Track individual subject marks for each student.

## Tech Stack

* **Framework:** ASP.NET Core MVC
* **Language:** C#
* **Database:** Entity Framework Core (SQL Server)
* **Frontend:** Razor Views (HTML5/CSS3) & Bootstrap 5
* **Architecture:** MVC with Dependency Injection (Service Layer)

## Features:
- Add, edit, delete, and view all students
- Add and edit marks for multiple subjects
- Clean, responsive layout using Bootstrap

## Running the project:
1.  **Clone the repository**
   
2.  **Update Database**
    Open the solution in Visual Studio. Open the **Package Manager Console** and run:
    ```bash
    Update-Database
    ```
    *This will create the local SQL database based on the Code-First Migrations.*

3.  **Run the Application**

## Screenshots:

### Home Page
![alt text](image.png)

### Student Home Page
![alt text](image-1.png)

### Add Student
![alt text](image-2.png)

### Edit Student
![alt text](image-3.png)

### Delete Student
![alt text](image-4.png)

### Student Details Page
![alt text](image-5.png)

### Add Mark
![alt text](image-6.png)

### Edit Mark
![alt text](image-7.png)

### Delete Mark
![alt text](image-8.png)

### Database (Student Table)
![alt text](image-9.png)

### Database (Marks Table)
![alt text](image-10.png)