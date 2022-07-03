# 📖 Minimalist Book Manager API - C# ASP.NET Core MVC Web API

## Introduction
The application is a Minimalist Book Manager API with synchronous API endpoints.

### Project Structure
The project/solution consists of the following structure:

* BookManagerAPI
	* Contains the application files
* BookManagerApi.Tests
	* Contains the tests for the application

### Application Components
The application contains two models with the following properties:

* Book
	* ID
	* Title
	* Description
	* Author
	* Genre

* Author
	* ID
	* Name

The application has 3 environment profiles:

- Testing: - configured to use In-Memory database
- Development: - configured to use MySQL database
- Production: - configured to use MS SQL Server database

The connection strings for both MySQL and MS SQL Server are currently defined in Environment variables:

- MySQL: env variable name = CUSTOMCONNSTR_MyContextDb
	- Context setup for MySQL is: [MySqlDbContext.cs](./BookManagerApi/Data/MySqlDbContext.cs)
![Alt text](https://github.com/Hayley96/lm-lab-csharp-book-manager-api/blob/main/BookManagerApi/resources/MySQLConnectionString.png?raw=true "MySQL Connection Setup")
	
- MS SQL Server: env variable name = CUSTOMCONNSTR_MyContextDbSQLServer
	- Context setup for MS SQL Server is: [MsSqlServerDbContext.cs](./BookManagerApi/Data/MsSqlServerDbContext.cs)
![Alt text](https://github.com/Hayley96/lm-lab-csharp-book-manager-api/blob/main/BookManagerApi/resources/MsSQLServerConnectionString.png?raw=true "MSSQL Server Connection Setup")


### Application Features
The API features are:
* Get All Books - retrieves a list of all books
* Get a Book by ID - retrieve a single book via the book id
* Add a Book - add a book
* Update a Book - modify an existing book via the book id
* Delete a Book - delete a book via the book id
* Get All Authors - return a list of authors
* Get Author by ID - return a single author via the author id
* Add author - add a author

### Pre-Requisites
- C# / .NET 6
- NuGet

### Technologies & Dependencies
- ASP.NET Core MVC 6 (Web API Project)
- MS Entity Framework Core 6
	- In Memory
	- SQL Server
	- MySSQL
	- Design
- MS Extensions
- Pomelo
- NUnit testing framework
- Moq

### How to Get Started
- Fork this repo to your Github and then clone the forked version of this repo.
- Restore dependencies:
	- Open up project in Visual Studio
	- Open up a terminal and navigate to the root folder of the main application directory [BookManagerApi](./BookManagerApi):
	 - run: `dotnet restore`

### Main Entry Point
- The Main Entry Point for the application is: [Program.cs](./BookManagerApi/Program.cs)

### Running the Unit Tests
- You can run the unit tests in Visual Studio, or you can go to your terminal and inside the root of this directory, run:

`dotnet test`