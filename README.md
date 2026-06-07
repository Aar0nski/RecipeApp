# RecipeApp

RecipeApp är en fullstack-applikation byggd med ASP.NET Core Web API, Entity Framework Core, SQL Server och Blazor.

Applikationen hanterar recept och kategorier med full CRUD-funktionalitet.

## Funktioner

### Recept
- Visa alla recept
- Skapa recept
- Uppdatera recept
- Ta bort recept

### Kategorier
- Visa alla kategorier
- Skapa kategorier
- Ta bort kategorier

## Teknologier

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Repository Pattern
- Generic Repository
- Dependency Injection
- DTOs
- Async/Await

### Frontend
- Blazor Server
- HttpClient
- Razor Components

### Tester
- xUnit
- NSubstitute

---

## Projektstruktur

```text
RecipeApp
│
├── RecipeApp.API
│   ├── Controllers
│   ├── Services
│   ├── Repositories
│   ├── Models
│   ├── DTOs
│   └── Data
│
├── RecipeApp.Frontend
│   ├── Components
│   ├── Pages
│   └── Models
│
└── RecipeApp.Tests
```

## Databasmodell

### Category

```csharp
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Recipe> Recipes { get; set; }
}
```

### Recipe

```csharp
public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CookingTime { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
```

## Installation

### 1. Klona projektet

```bash
git clone <repository-url>
```

### 2. Gå till projektmappen

```bash
cd RecipeApp
```

### 3. Uppdatera databasen

```bash
dotnet ef database update --project RecipeApp.API
```

### 4. Starta API

```bash
dotnet run --project RecipeApp.API
```

Swagger öppnas på:

```text
http://localhost:5211/swagger
```

### 5. Starta Frontend

Öppna en ny terminal:

```bash
dotnet run --project RecipeApp.Frontend
```

Frontend öppnas på:

```text
http://localhost:5096
```

---

## Tester

Kör alla tester:

```bash
dotnet test
```

Projektet innehåller enhetstester för service-lagret med xUnit och NSubstitute.

---

## Uppfyllda krav

### Backend
- Web API
- Controllers
- Services
- Repository Pattern
- Generic Repository
- Dependency Injection
- DTOs
- Entity Framework Core
- SQL Server
- Async/Await
- Två entiteter
- En 1-många relation

### Frontend
- Blazor
- Visa data
- Skapa data
- Uppdatera data
- Ta bort data
- Enkel navigation

### Tester
- xUnit
- NSubstitute
- Minst 7 tester

---

## Författare

Aaron Enander
