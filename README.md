# RESTful API with .NET 8.0

This project is a RESTful API example built using .NET 8.0. It provides a simple product management system and is structured according to various software development principles.

## Features

- Compliance with RESTful API standards
- Adherence to SOLID principles
- Dependency Injection (DI) with fake services
- Various extension methods for the project
- Swagger implementation
- Global logging middleware
- User authentication system with custom attribute
- Global exception middleware

## Installation

Clone the repository:

```sh
git clone https://github.com/ksensazli/P324-Week3-Homework.git
cd P324-Week3-Homework
```

Restore the dependencies:

```sh
dotnet restore
```

Build and run the project:

```sh
dotnet run
```

## Usage

After running the API, you can use the following endpoints:

- GET /api/products: Retrieves the list of products, optionally filtered and sorted by name and price.
- GET /api/products/{id}: Retrieves a product by its ID.
- POST /api/products: Creates a new product.
- PUT /api/products/{id}: Updates an existing product by its ID.
- DELETE /api/products/{id}: Deletes a product by its ID.

## Swagger

Swagger UI can be used to test the API endpoints. While the project is running, visit related swagger URL in your browser.

## Development Standards

- SOLID Principles: The project is structured according to SOLID software development principles.
- Dependency Injection: Services are added to the project using DI.
- Extension Methods: Various extension methods are developed for use within the project.
- Middleware: Global logging and exception handling are provided via middleware.

## Bonus Features

- User Authentication System: A fake user authentication system is developed and controlled with a custom attribute.
- Global Exception Middleware: A middleware for global exception handling is added.
