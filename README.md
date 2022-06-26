# 📖 Minimalist Book Manager API - C# ASP.NET Core MVC Web API

## Introduction
The application is a Minimalist Book Manager API with synchronous API endpoints.

The project/solution consists of the following structure:

* BookManagerAPI
	* Contains the application files
* BookManagerApi.Tests
	* Contains the tests for the application

The API features are:
* Get All Books - retrieves a list of all books
* Get a Book by ID - retrieve a single book via the book id
* Add a Book - add a book
* Update a Book - modify an existing book via the book id
* Delete a Book - delete a book via the book id

### Pre-Requisites
- C# / .NET 6
- NuGet

### Technologies & Dependencies
- ASP.NET Core MVC 6 (Web API Project)
- NUnit testing framework
- Moq

### How to Get Started
- Fork this repo to your Github and then clone the forked version of this repo.

### Main Entry Point
- The Main Entry Point for the application is: [Program.cs](./BookManagerApi/Program.cs)

### Running the Unit Tests
- You can run the unit tests in Visual Studio, or you can go to your terminal and inside the root of this directory, run:

`dotnet test`