# CleanArchitecture
NET 9 Clean Architecture solution for React and TypeScript applications 

## Overview
This project is designed with Clean Architecture principles, leveraging Command Query Separation (CQS) pattern, repository pattern, and minimal APIs integrated with Scalar. The frontend is built using React and TypeScript.
A shop example with Product and Category Model has been used to illustrate this principle

## Project Structure
The solution is organized into the following projects:

1. **Shop.API**
   - Contains the API and the frontend React TypeScript application.
2. **Shop.Application**
   - Implements Command Query Separation (CQS) and Services interfaces.
3. **Shop.Domain**
   - Contains the domain entities.
4. **Shop.Contracts**
   - Contains utilities like exceptions, requests and response models, validation errors, and DTOs.
5. **Shop.Infrastructure**
   - Implements the database context and repository pattern.
   - Connects to the database and handles data persistence.

### Prerequisites
- .NET 9 SDK
- Node.js and npm
- Visual Studio or Visual Studio Code

### Demo
![UI](https://github.com/Adel-alfa/CleanArchitecture.Shop/blob/master/UI-React.png)
![API](https://github.com/Adel-alfa/CleanArchitecture.Shop/blob/master/Backend-ScalarAPI.png)
