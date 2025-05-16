[Back to README](../README.md)

## Sales API

API for sales management, built with ASP.NET Core (.NET 8) and PostgreSQL.

### 🚀 How to run the project

### ✅ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

### 📥 Clone the Repository

```bash
git clone https://github.com/vinicius-masson/ambev-sales
```

2. Edit the appsettings.json file and update the ConnectionStrings section with your database details:
```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ambev_sales;User Id=postgres;Password=pg1234;TrustServerCertificate=True"
}
```
💡 Remember to change Username and Password according to your local setup.

If you don’t have the Entity Framework CLI installed, run:

```bash
dotnet tool install --global dotnet-ef
```

Then, apply the migrations to create the database schema:
```bash
dotnet ef database update
```

▶️ Run the Application
```bash
dotnet run --project src/Ambev.DeveloperEvaluation.WebApi
```

🧪 Run Tests
```bash
dotnet test
```

## 👤 Author
[Vinicius Masson](https://www.linkedin.com/in/vinicius-masson/)
Software Developer | .NET
