# Lab 06 - Entity Framework Core

## Create a Model

1. Create a .NET Core console application
1. Create a model type, e.g. the class `Book`
1. Add properties to the model type, e.g. BookId, Title, and Publisher

## Create a Context

1. Create a BooksContext class that derives from DbContext
2. Add the necessary NuGet packages
3. Define a property to access the Book type using DbSet

## Add new objects

1. Instantiate the context in the `Main` method
1. Add new objects
1. Save changes

## Make a connection to the SQL Server database

1. Override the configuring method of the context
1. Configure to use SQL Server
1. Add the necessary NuGet package
1. Create a database on starting the application

## Migrations

1. Configure the *dotnet ef* tool in csproj.
1. Enable migrations with the project
1. Change the model type by adding an additional property
1. Define code migrations for the update
1. Run migrations from code and using the dotnet tool

## Entity Framework with ASP.NET Core MVC 

1. Create an EF context for the entity type you created earlier
1. Define the constructor needed with EF using dependency injection
1. Configure the context in the dependency injection container
1. Create the database programmatically
1. Create a new controller to write a new record to the database