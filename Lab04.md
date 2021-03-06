# Lab 04 - ASP.NET MVC Controllers

## Creating a Controller

1. Create an empty ASP.NET Core Web Application
1. Add a the default ASP.NET MVC route using `UseMvcWithDefaultRoute`
1. Add the necessary NuGet packages
1. Create the HomeController with an Index action method and return a simple string
1. Run the application

## Using Parameters

1. Create an action method Greeting1 that returns a "Hello, " prefix, and use this URL format: Greeting1/Stephanie
1. Create an action method Greeting2 that returns a "Hello, " prefix, and use this URL format: Greeting2?name=Matthias
1. Create a new route using `UseMvc` for a route like this: Add/3/5
1. Implement the action method Add to return an integer value 

## Returning Results

1. Create Book class with a few simple properties in the Models directory
1. Create the GetBook action method to return the Book in JSON format
1. Create the RedirectSample action method that redirects the request to a different Website, e.g. [http://www.cninnovation.com](http://www.cninnovation.com "CN innovation")

## Use Dependency Injection with the controller

1. Create a BooksRepository class in the Models directory
1. Define the GetBook method to return a Book instance
1. Define a interface for the BooksRepository, e.g. IBooksRepository
1. Register the interface and the concrete class with the dependency injection framework
1. Make use of the IBooksRepository contract with the HomeController