# 📚 Book Management API

Welcome to the **Book Management API**, a simple RESTful API for managing your collection of books. This API provides CRUD operations, pagination, search functionality, and data validation, all powered by .NET 6.

## 📖 Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup Instructions](#setup-instructions)
- [Usage](#usage)
  - [Endpoints](#endpoints)
- [CORS Configuration](#cors-configuration)
- [Conclusion](#conclusion)

## ✨ Features

- **CRUD Operations**: Create, retrieve, update, and delete books.
- **Pagination**: Retrieve books in a paginated format.
- **Search Functionality**: Filter books by title or author.
- **Data Validation**: Ensures required fields are present and `PublishedDate` is not in the future.
- **Swagger/OpenAPI Documentation**: Automatically generated API documentation.
- **Dependency Injection**: Clean service management using .NET's built-in DI.
- **Error Handling**: Proper error handling with appropriate HTTP status codes.

## 🛠️ Technologies Used

- **.NET 6**
- **ASP.NET Core Web API**
- **C#**
- **JSON File Storage**
- **Swagger/OpenAPI**

## 📝 Setup Instructions

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Getting Started

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/Izzy-kayaba/SupportWaveAPI.git
   cd SupportWaveAPI

2. **Install Dependencies**:
   ```bash
   dotnet restore

3. **Build the Project**:
   ```bash
   dotnet build

4. **Run the Application**:
   ```bash
   dotnet run

The API will be running on https://localhost:8015 or http://localhost:8016.

5. **Access Swagger Documentation:**
Navigate to https://localhost:8015/swagger/index.html in your browser to view the API documentation.

## 🚀 Usage

### 📚 Endpoints

- **GET** `/api/books`: Retrieve all books with pagination and search functionality.
- **GET** `/api/books/{id}`: Retrieve a specific book by ID.
- **POST** `/api/books`: Add a new book.
- **PUT** `/api/books/{id}`: Update an existing book.
- **DELETE** `/api/books/{id}`: Delete a book.

## 🔒 CORS Configuration

The CORS configuration for the application varies depending on whether the environment is development or production.

### Development Environment

In the development environment, CORS is configured to allow requests from any origin, with any headers and methods. This is useful for testing and development purposes

## 🎉 Conclusion

Thank you for exploring the **SupportWave API**!

We hope this API serves as a valuable tool for managing your book collection and provides a solid foundation for further development.

Happy coding! 🚀
