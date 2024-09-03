# ApproveAI
Multitenant approval system for GPT answers, through the use of user management and workflow approval

## Description

ApproveAI is a platform on which users can prompt a chatbot to ask questions. The chatbot generates an answer, which the user can accept or decline. Upon accepting an answer, the answer gets assigned to a configured workflow for approval. Multiple users in this multitenant application then have the possibility to approve or decline a given answer.

The platform is served through a C# EF Core Web API as the back-end, and a Next.js application as the front-end. Of both the front-end and the back-end, multiple instances will run through Docker. With this configuration, multitenancy can be simulated on one machine.

This project has been created with the motivation to learn more about the workflow and considerations of a complex multitenant application, includling the deployment of one.

## Functionality

- Q&A through GPT
- Dynamic workflow approval functionality for received answers
- Multitenancy support with the use of multiple Docker containers and Redis
- User management and authentication through Auth0
- Functionality for live updates without refreshing

## Used practices

### C# back-end

- EF Core Web API
- SignalR
- OData

---

### Next.js front-end

- App routing
- TanStack Query

---

### Other technologies

- Docker (Compose)
- Redis
- Auth0
- GPT

---
