Eshop API

Overview
Eshop API is a RESTful web service for managing an online store's product catalog. The API provides endpoints for retrieving product information, paginated product listings, updating product descriptions, and more. It is built using ASP.NET Core and MSSQL Server.

Features

    Retrieve all products using the GET /api/products/all endpoint.
    Retrieve paginated products using the GET /api/products/v2?pageNumber=1&pageSize=10 endpoint.
    Retrieve a single product using the GET /api/products/{id} endpoint.
    Update product descriptions using the PATCH /api/products/{id} endpoint.
    Integrated Swagger UI for API documentation.
    Uses MSSQL Server for data storage with Entity Framework Core.
    Initial database seeding with mock product data.
    Unit tests for API validation.

Requirements

    .NET 6 or later.
    Microsoft SQL Server.
    Visual Studio 2022 (or VS Code with C# extension).
    Postman (optional, for testing API requests).

Setup Instructions

    Database Configuration

        Open SQL Server Management Studio (SSMS) and create a new database using the command (you can use the attached initiate_eshop_db.sql file as well):
        CREATE DATABASE EshopDB;

        Switch to the new database using:
        USE EshopDB;

        Run the following script to create the Products table:

        CREATE TABLE Products (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(255) NOT NULL,
        ImgUri NVARCHAR(255) NOT NULL,
        Price DECIMAL(18,2) NOT NULL,
        Description NVARCHAR(MAX) NULL
        );

        Insert some mock data:

        INSERT INTO Products (Name, ImgUri, Price, Description)
        VALUES ('Laptop', 'laptop.jpg', 999.99, 'High-performance laptop'),
        ('Smartphone', 'smartphone.jpg', 699.99, 'Latest model smartphone');

    Configure the API

        Open the appsettings.json file in the project and update the database connection string:

        {
            "ConnectionStrings": {
                "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=EshopDB;Trusted_Connection=True;TrustServerCertificate=True;"
            }
        }

        Replace YOUR_SERVER_NAME with your actual MSSQL server name.

    Apply Migrations

        Open Visual Studio.

        Open Package Manager Console by going to Tools -> NuGet Package Manager -> Package Manager Console.

        Run the following commands:

        Add-Migration InitialCreate
        Update-Database

        This will create the database schema automatically.

    Run the Application
        Press Ctrl + F5 to start the application.
        Open your browser and go to: https://localhost:5001/swagger
        You can now test API endpoints using Swagger UI.

API Endpoints

    GET /api/products/all - Retrieves all products.
    GET /api/products/v2?pageNumber=1&pageSize=10 - Retrieves products with pagination.
    GET /api/products/{id} - Retrieves a product by ID.
    PATCH /api/products/{id} - Updates product description.

Running Unit Tests

    Open Test Explorer by going to Test -> Windows -> Test Explorer in Visual Studio.
    Click "Run All" to execute the unit tests.

Additional Notes

    The application uses Swagger UI for API documentation.
    Ensure MSSQL Server is running before starting the API.
    Use Postman for testing API requests manually.