# Library Management System API

A RESTful Library Management System built using ASP.NET Core Web API, Entity Framework Core, and SQL Server.

The application provides functionality for managing books, members, and book borrowing/return operations.

## Technologies Used

- C#
- ASP.NET Core Web API
- .NET 8
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Git and GitHub

## Architecture

The project follows a layered architecture:

```text
Client
  |
  v
Controller
  |
  v
Service
  |
  v
Repository
  |
  v
Entity Framework Core
  |
  v
SQL Server
```

### Controller Layer

Handles HTTP requests and responses.

### Service Layer

Contains application business logic, such as checking whether a book is available before allowing it to be borrowed.

### Repository Layer

Handles data access operations using Entity Framework Core.

### Data Layer

`LibraryDbContext` manages communication between Entity Framework Core and SQL Server.

## Entities

### Book

Represents a book in the library.

Main properties:

- Id
- Title
- Author
- ISBN
- PublishedYear
- IsAvailable

### Member

Represents a library member.

Main properties:

- Id
- Name
- Email
- PhoneNumber

### Borrowing

Stores book borrowing history.

Main properties:

- Id
- BookId
- MemberId
- BorrowedDate
- ReturnedDate

## API Endpoints

### Books

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Books` | Get all books |
| GET | `/api/Books/{id}` | Get book by ID |
| POST | `/api/Books` | Create a book |
| PUT | `/api/Books/{id}` | Update a book |
| DELETE | `/api/Books/{id}` | Delete a book |

### Members

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Members` | Get all members |
| GET | `/api/Members/{id}` | Get member by ID |
| POST | `/api/Members` | Create a member |
| PUT | `/api/Members/{id}` | Update a member |
| DELETE | `/api/Members/{id}` | Delete a member |

### Borrowings

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Borrowings` | Get borrowing records |
| GET | `/api/Borrowings/{id}` | Get borrowing by ID |
| POST | `/api/Borrowings?bookId={bookId}&memberId={memberId}` | Borrow a book |
| PUT | `/api/Borrowings/{id}/return` | Return a book |

## Business Rules

- A book must exist before it can be borrowed.
- A member must exist before borrowing a book.
- A book cannot be borrowed when it is already unavailable.
- Borrowing a book changes `IsAvailable` to `false`.
- Returning a book changes `IsAvailable` back to `true`.
- A borrowing cannot be returned more than once.
- A currently borrowed book cannot be deleted.

## Database Relationships

```text
Book
  1
  |
  | *
Borrowing
  *
  |
  | 1
Member
```

A book can have multiple borrowing records over time.

A member can also have multiple borrowing records.

## Running the Project

### 1. Clone the repository

```bash
git clone <repository-url>
```

### 2. Navigate to the project directory

```bash
cd "Library Management System"
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Configure the database

Update the `DefaultConnection` connection string in `appsettings.json` if necessary.

Example using SQL Server LocalDB:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=LibraryManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 5. Apply migrations

```bash
dotnet ef database update
```

### 6. Run the application

```bash
dotnet run
```

Open the Swagger URL displayed in the terminal to test the API.

## Validation

The API uses Data Annotations for model validation, including required fields, maximum lengths, valid email addresses, and publication-year validation.

## API Documentation

Swagger/OpenAPI is enabled in the development environment and can be used to explore and test all API endpoints.