# HelpHub Backend

## Project Description

HelpHub is a fullstack application created to help people request and offer help within their local community.

The backend is built using ASP.NET Core Web API with Clean Architecture principles. The project demonstrates separation of concerns, CQRS, MediatR, Repository Pattern, Entity Framework Core, SQL Server, and Dependency Injection.

---

## Technologies Used

* ASP.NET Core 9
* Entity Framework Core
* SQL Server LocalDB
* MediatR
* CQRS
* Repository Pattern
* Clean Architecture
* Dependency Injection
* React Frontend
* Axios

---

## Architecture

The backend follows Clean Architecture and is divided into the following layers:

### API

Handles controllers and HTTP requests.

### Application

Contains CQRS commands, queries, DTOs, and business logic.

### Domain

Contains entities and core business models.

### Infrastructure

Contains database access, repositories, EF Core configuration, and Dependency Injection.

---

## Database

The application uses SQL Server LocalDB.

Connection string:

```json
Server=(localdb)\MSSQLLocalDB;Database=HelpHubDb;Trusted_Connection=True;TrustServerCertificate=True;
```

---

## Entities

### User

Represents a user of the system.

Properties:

* Id
* Name
* Email

### Category

Represents a help category.

Properties:

* Id
* Name

### HelpRequest

Represents a request for help.

Properties:

* Id
* Title
* Description
* Location
* IsCompleted
* UserId
* CategoryId

---

## Relationships

* One User can create many HelpRequests.
* One Category can contain many HelpRequests.
* Each HelpRequest belongs to one User.
* Each HelpRequest belongs to one Category.

---

## CRUD Operations

The API supports:

### Users

* GET
* GET BY ID
* POST
* PUT
* DELETE

### Categories

* GET
* GET BY ID
* POST
* PUT
* DELETE

### HelpRequests

* GET
* GET BY ID
* POST
* PUT
* DELETE

---

## Running the Project

1. Open the solution in Visual Studio.
2. Update the database using Entity Framework migrations.
3. Start the API project.
4. The API will run on:

https://localhost:7216

---

## Author

Created as a Fullstack Clean Architecture Group Assignment.

* Create Help Request Form
* Help Request List
* Update Functionality
* Delete Functionality

---

## Running the Project

1. Open the frontend project in Visual Studio Code.
2. Install dependencies:

```bash
npm install
```

3. Start the project:

```bash
npm run dev
```

4. Open:

http://localhost:5173

---

## Author

Created as a Fullstack Clean Architecture Group Assignment.

## UML Class Diagram

+-------------------+
|       User        |
+-------------------+
| Id                |
| Name              |
| Email             |
+-------------------+
          |
          | 1
          |
          | *
+-------------------+
|    HelpRequest    |
+-------------------+
| Id                |
| Title             |
| Description       |
| Location          |
| IsCompleted       |
| UserId            |
| CategoryId        |
+-------------------+
          |
          | *
          |
          | 1
+-------------------+
|     Category      |
+-------------------+
| Id                |
| Name              |
+-------------------+
