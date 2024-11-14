# Online Shopping App

> This project is a multi-layered ASP.NET Core Web API that enables customers to browse products, place orders, and manage account information. The application follows the Entity Framework Code First approach and leverages ASP.NET Core Identity for authentication and authorization, JWT for secure access control, and a clean Repository - UnitOfWork pattern.

## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Screenshots](#screenshots)
* [Database Diagrams](#database-diagrams)
* [Setup](#setup)
* [Project Status](#project-status)
* [Contact](#contact)
  
<!-- * [License](#license) -->


## General Information
- Project Layers
Presentation Layer (API): Contains the controllers that handle HTTP requests.
Business Layer: Manages business logic for the application.
Data Access Layer: Handles database operations using Entity Framework (Repository - UnitOfWork).
- Data Models
User

Id (int, primary key)
FirstName (string)
LastName (string)
Email (string, unique)
PhoneNumber (string)
Password (string, encrypted with Data Protection)
Role (enum - Admin or Customer for role-based access)
Product

Id (int, primary key)
ProductName (string)
Price (decimal)
StockQuantity (int)
Order

Id (int, primary key)
OrderDate (DateTime)
TotalAmount (decimal)
CustomerId (int, linked to User)
OrderProduct

OrderId (int)
ProductId (int)
Quantity (int)
- Features
Authentication and Authorization
Uses ASP.NET Core Identity or a custom identity service for authentication. JWT is implemented for authorization, with roles for "Customer" and "Admin."
- Model Validation
Validates fields for both User and Product models, ensuring required fields, email format, and stock validation.
- Action Filter
Allows specific APIs to be accessible only within designated time periods.
- Dependency Injection
Manages services via dependency injection.
- Data Protection
Secures user passwords using Data Protection.
- Global Exception Handling
Captures all exceptions globally and returns appropriate error responses.
<!-- You don't have to answer all the questions - just the ones relevant to your project. -->


## Technologies Used
- Tech 1 - C#
- Tech 2 - ASP. Net Core Web Api
- Tech 3 - Entity Framework
- Tech 4 - Microsoft SQL Server


## Screenshots
<img width="954" alt="1" src="https://github.com/user-attachments/assets/b470ca0b-1915-490f-87d6-509aec1d9b6b">
<!-- If you have screenshots you'd like to share, include them here. -->

## Database Diagrams
<img width="691" alt="Ekran görüntüsü 14-11-2024 18 11 50" src="https://github.com/user-attachments/assets/24e797fc-7989-4700-8f8c-078090c3dc7e">

## Setup
The project is used via Visual Studio. Requests are made via Swagger.


## Project Status
Project is: _in progress_ 

## Contact
Created by [https://www.linkedin.com/in/cemilozcan/] - feel free to contact me!


<!-- Optional -->
<!-- ## License -->
<!-- This project is open source and available under the [... License](). -->

<!-- You don't have to include all sections - just the one's relevant to your project -->
