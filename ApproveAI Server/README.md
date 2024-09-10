# ApproveAI Server

## Description

The ApproveAI Server serves as the main project for the logic necessary for the ApproveAI project. This Server project consists of multiple C# projects, bundled into one solution. Each project has its own seperate documentation. This documentation file serves as a main guide, including installation and set-up

## Installation

### Running migrations
Adding of migrations:
dotnet ef migrations add InitialMigration --project "{path}\ApproveAI Server\ApproveAiApi\ApproveAiApi.csproj" --startup-project "{path}\ApproveAI Server\ApproveAiApi\ApproveAiApi.csproj"

Running of migrations:
dotnet ef database update --project "{path}\ApproveAI Server\ApproveAiModels\ApproveAiModels.csproj" --startup-project "{path}\ApproveAI Server\ApproveAiApi\ApproveAiApi.csproj"

### Running of the application and seeding of data
To test this application, the ApproveAiApi is to be launched. Please ensure to run the migrations before launching, and to not modify any data in the database before launching. Upon launching, the application will seed the database with the necessary data, which might not work if data is inserted beforehand.