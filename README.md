# ICMarketsTest
This is a project to demonstrate ICMarkets Web API .Net Developer test.

Project tech stack:
- .Net Core 6.0
- EF Core
- SQLite

Project Structure:
```bash
- Clients (Contains connected clients)
   -- ICMarkets.Developer.Clients.BlockCypher
- Shared (Contains shared models)
   -- ICMarkets.Developer.Shared.Models
- Tests (xUnit test)
   -- ICMarkets.DeveloperTest.FunctionalTest
- ICMarkets.DeveloperTest.API (Main API Project)
- ICMarkets.DeveloperTest.Datacontext (Datacontext project)
```

Ef Core Migrations are placed in project as well, for reference below are 3 migrations:
```bash
dotnet ef --startup-project ICMarkets.DeveloperTest.API migrations add Initial-Migrations
dotnet ef --startup-project ICMarkets.DeveloperTest.API migrations add Alter-Table-BlockchainData-Added_Columns
dotnet ef --startup-project ICMarkets.DeveloperTest.API migrations add Alter-Table-BlockchainData-Modified_Columns
```

Database Update should be executed automatically once the project is executed, but in case if it doesn't get executed:
```bash
dotnet ef --startup-project ICMarkets.DeveloperTest.API database update
```
