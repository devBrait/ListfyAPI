# 📱 Listfy API
This is the API for Listfy, an application for managing shopping lists and notes. The API is built using .NET, providing endpoints to create, edit, and synchronize lists across devices.
## 🚀 Technologies

- Language: C# (.NET)
- Database: PostgreSQL
- ORM: EF Core
- Containerization: Docker
- Architecture: RESTful API

## 🛠️ Developers
This project is being developed by:

[Danilo Honda - GitHub](https://github.com/DaniloHonda)

[devBrait - GitHub](https://github.com/devbrait)

## ⚙️ Environment Setup

To get the Listfy API up and running, configure the environment variables in two .env files: one in the project root and another in the API layer. Follow these steps:

1. Root **.env** File

Create a **.env.docker** file in the project root directory with the following structure:

    POSTGRES_HOST="IP Address"
    POSTGRES_PORT="Port"
    POSTGRES_DB="Database Name"
    POSTGRES_USER="User"
    POSTGRES_PASSWORD="Password"

This file configures the database connection for the entire project.

2. API Layer **.env** File

Create a **.env.development** file in the API directory (e.g., Listfy.API) with identical content:

    POSTGRES_HOST="IP Address"
    POSTGRES_PORT="Port"
    POSTGRES_DB="Database Name"
    POSTGRES_USER="User"
    POSTGRES_PASSWORD="Password"

This ensures the API layer can connect to the PostgreSQL database using the same credentials.

# 📝 Notes

Ensure both .env files are properly configured before starting the application.
Do not commit .env files to version control. Add them to .gitignore to prevent exposing sensitive information.
If you need to change the database credentials, update both .env files to maintain consistency.

