This project is a .NET 6 Web API built to manage student´s  information. It's got all the basic CRUD operations (Create, Read, Update, Delete), and it works hand-in-hand with a SQL Server database. You can also interact with it using Swagger to test the endpoints.
Here you will find:

## Controllers:
StudentController.cs: This is where all the magic happens for handling student data. You’ll find methods to:
Get all students
Get a single student by ID
Add a new student
Update an existing student
Delete a student

## Models:
Student.cs: This defines what a student looks like in the system. It includes:
ID, Name, Age, Gender, Course, Email, and when the record was created.
AppDbContext.cs: This connects the app to the database and manages the entities through Entity Framework.
## Migrations: 
The project uses Entity Framework Core migrations to keep track of any database changes. These migrations are already set up and stored in the Migrations folder.
## Configuration Files:
appsettings.json: Holds the config settings, including the connection string to your SQL Server.
Program.cs: This file kicks off the app and handles important features setting up the database connection, and enabling Swagger for API documentation.

# SetUp
Install the .NET 6 SDK, then go to the project folder and run:

dotnet restore

## Set up the Database: 

Run this command to apply the migrations and create the database:

It’ll be available at https://localhost:5001.

Once the API is running, go to https://localhost:5001/swagger to interact with the API in the Swagger UI.

## PD:
Make sure the database connection string in appsettings.json matches your environment.
The project also includes the setup for unit testing using xUnit. However, the tests couldn't be executed, likely due to compatibility issues between the versions of .NET 6 and the testing packages.
