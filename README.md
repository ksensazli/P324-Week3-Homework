# RESTful API with .NET 8.0

This project is a RESTful API built with .NET 8.0 and C#. This API provides CRUD operations for managing products. The project demonstrates the use of best practices including SOLID principles, Dependency Injection, FluentValidation, Swagger for API documentation, and middleware for logging and exception handling.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete operations for products.
- **Validation**: Uses FluentValidation for input validation.
- **Swagger**: Integrated Swagger for API documentation and testing.
- **Logging Middleware**: Simple logging middleware to log basic request information.
- **Exception Handling Middleware**: Custom middleware for handling global exceptions.
- **Fake User Authentication** (Bonus): A basic user authentication system with custom attributes for access control.

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

## API Endpoints

- Get Products
  - GET /api/products
  - Query Parameters:
    - name (optional): Filter by product name.
    - sort (optional): Sort by name or price.

- Get Product By ID
  - GET /api/products/{id}
  - URL Parameters:
    - id: ID of the product.

- Create Product
  - POST /api/products
  - Request Body: ProductUpdateInput object.
    - Name: Product name.
    - Price: Product price.
    - Description: Product description.

- Update Product
  - PUT /api/products/{id}
  - URL Parameters:
    - id: ID of the product.
  - Request Body: ProductUpdateInput object.
    - Name: Product name.
    - Price: Product price.
    - Description: Product description.

- Delete Product
  - DELETE /api/products/{id}
  - URL Parameters:
    - id: ID of the product.
   
## Models

- ProductUpdateInput: Represents the data required to create or update a product.
  - Name: Product name.
  - Price: Product price.
  - Description: Product description.

- ProductDetailOutput: Represents the details of a product returned by the API.
  - Id: Unique identifier for the product.
  - Name: Product name.
  - Price: Product price.
  - Description: Product description.

## Validation

- ProductValidator: Validates Product model to ensure Name is not empty, Price is greater than zero, and Description is not empty.
- ProductIdValidator: Validates Product ID to ensure it is greater than zero.

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
