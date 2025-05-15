# MoodMate API

MoodMate API is a .NET Web API designed to support the MoodMate application, enabling users to track and manage their emotional well-being. It provides secure, scalable, and RESTful endpoints for mood tracking and user management, utilizing Bearer Token authentication and authorization for secure access.

---

## 📚 Table of Contents

- [Key Features](#key-features)
- [Technologies Used](#technologies-used)
- [Domain Models](#domain-models)
- [DTOs](#dtos)
- [Repository Pattern](#repository-pattern)
- [Authentication and Authorization](#authentication-and-authorization)
- [API Documentation](#api-documentation)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Running the API](#running-the-api)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

---

## 🚀 Key Features

- **Mood Tracking**: Log and retrieve user mood entries with support for trend analysis.
- **User Management**: Handle user registration, login, and profile management.
- **Secure Authentication**: JWT Bearer Token-based authentication.
- **Authorization**: Role-based and policy-based access control.
- **RESTful Architecture**: Designed for scalability and maintainability.
- **Data Validation**: DTOs used for robust input/output validation.
- **Repository Pattern**: Abstracted data access for improved testability and maintainability.

---

## 🛠 Technologies Used

- **.NET Core / .NET 8**
- **Entity Framework Core**
- **ASP.NET Core Identity**
- **JWT (JSON Web Tokens)**
- **SQL Server / SQLite**
- **Swagger / OpenAPI**
- **Dependency Injection**

---

## 🧩 Domain Models

- **User**: `Id`, `Username`, `Email`, `PasswordHash`, `Role`
- **MoodEntry**: `Id`, `UserId`, `MoodType`, `Description`, `Timestamp`, `Intensity`
- **MoodCategory**: `Id`, `Name`

These models are mapped to database tables using Entity Framework Core.

---

## 📦 DTOs

Used for API request/response shaping and validation.

- `UserRegisterDto`: `Username`, `Email`, `Password`
- `UserLoginDto`: `Email`, `Password`
- `MoodEntryCreateDto`: `MoodType`, `Description`, `Intensity`, `Timestamp`
- `MoodEntryResponseDto`: `Id`, `MoodType`, `Description`, `Timestamp`, `Intensity`
- `UserResponseDto`: `Id`, `Username`, `Email`, `Role`

---

## 🏗 Repository Pattern

Interfaces for abstracting data access:

- `IUserRepository`
  - `GetById`, `GetByEmail`, `CreateUser`
- `IMoodEntryRepository`
  - `CreateMoodEntry`, `GetMoodEntriesByUser`, `GetMoodEntriesByDateRange`
- `IMoodCategoryRepository`
  - `GetAllCategories`, `GetCategoryById`

All repositories are registered via .NET Dependency Injection.

---

## 🔐 Authentication and Authorization

### Authentication
- Uses ASP.NET Core Identity and JWT Bearer tokens.
- Token obtained via: `POST /api/auth/login`

### Authorization
- Role-based and policy-based access.
  - **Authenticated users**: Access mood tracking endpoints.
  - **Admin users**: Access user management endpoints.

JWT tokens are validated using middleware.

---

## 📄 API Documentation

- **Postman Collection**: `/docs/MoodMate_API.postman_collection.json`
- **Swagger UI**: Available at `/swagger` when the API is running.

---

## 🧰 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server or SQLite
- Git
- IDE (Visual Studio 2022 or VS Code)

### Installation

```bash
git clone https://github.com/shevon2000/MoodMate_API.git
cd MoodMate_API
dotnet restore
