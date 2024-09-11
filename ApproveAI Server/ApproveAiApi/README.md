# ApproveAI API

## About

The ApproveAI API serves as the main project for the logic necessary for the ApproveAI project. The API is built using EF Core, with the OData 8 protocol for the API definitions. The API works with an SQL database and makes use of the seperate Models project for the data definitions.

## Functionality

### Seeder
Upon launching the API, data is automatically seeded into the database. Please ensure not to add any data before launching the API and running the seeder.

## Project structure

As the main part of the functionality, this project makes use of a generic controller and repository pattern, that makes use of the OData protocol. Controllers for the entities inherit the generic controller, and have necessary unique methods built on top of them.