# ApproveAI Models

## Description
This project serves Models used by the Approve AI API. The Models project is used by the API, and also contains part of the database configuration. Definition of database entities is done through the model first approach and the Fluent API.

## Functionality

### Adding and running migrations
Adding of migrations:
dotnet ef migrations add InitialMigration --project "{path}\ApproveAI Server\ApproveAiApi\ApproveAiApi.csproj" --startup-project "{path}\ApproveAI Server\ApproveAiApi\ApproveAiApi.csproj"

Running of migrations:
dotnet ef database update --project "{path}\ApproveAI Server\ApproveAiModels\ApproveAiModels.csproj" --startup-project "{path}\ApproveAI Server\ApproveAiApi\ApproveAiApi.csproj"
