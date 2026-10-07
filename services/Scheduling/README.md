# Scheduling service

This is a .NET 10 Onion Architecture starter. The four project folders are
directly beside `Scheduling.slnx`; there is no extra `src` nesting.

| Project | Responsibility | Direct project references |
| --- | --- | --- |
| Scheduling.Domain | Entities, enums, domain rules | None |
| Scheduling.Application | Use cases, interfaces, DTOs, validation | Domain |
| Scheduling.Infrastructure | EF Core, repositories, external service clients | Domain, Application |
| Scheduling.API | Controllers, middleware, dependency injection composition | Application, Infrastructure |

## Included packages

The API project includes `Microsoft.AspNetCore.OpenApi` and
`Swashbuckle.AspNetCore` version 10.0.0. Infrastructure includes
`Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.SqlServer`,
`Microsoft.EntityFrameworkCore.Design`, and `Microsoft.EntityFrameworkCore.Tools`,
all version 10.0.0. The design and tools packages are private build-time assets.

## Build and run

Open `Scheduling.slnx` in Visual Studio 2026 and set `Scheduling.API` as the startup
project. Alternatively, open PowerShell in this service folder:

```powershell
dotnet build .\Scheduling.slnx
dotnet run --project .\Scheduling.API\Scheduling.API.csproj --launch-profile http
```

Visit `http://localhost:5003/api/health`. The response reports the service name
and API liveness; it does not test a database. Press Ctrl+C to stop the API.

| Setting | Value |
| --- | --- |
| HTTP | 5003 |
| HTTPS | 7003 |
| Planned SQL Server database | DentalClinicDb |
| Planned schema | scheduling |
| Planned migrations history | scheduling.__SchedulingMigrationsHistory |

For HTTPS development, trust the development certificate if needed with
`dotnet dev-certs https --trust`, then select the `https` launch profile.
The HTTP profile can run without certificate configuration.

## Database setup is the next step

No EF Core package, DbContext, migration, connection string, or database is
created by this starter. `Infrastructure/Persistence/DatabaseDefaults.cs`
records the planned schema and migration history names. When adding EF Core:

- Install matching EF Core 10.x SQL Server and design packages.
- Set the default schema with `modelBuilder.HasDefaultSchema(DatabaseDefaults.Schema)`.
- Set `sqlOptions.MigrationsHistoryTable(DatabaseDefaults.MigrationsHistoryTable, DatabaseDefaults.Schema)`.
- Put migrations under this service's Infrastructure project.
- Store local connection strings in API user secrets or environment variables.
- Keep migrations, designer files, and the DbContext model snapshot together in Git.

Every entity ID is `int`. Configure owned entity primary keys as SQL Server
IDENTITY when adding mappings. External IDs (for example, PatientId or DoctorId
in Scheduling) are plain integer references supplied by the owning service;
they must not have IDENTITY generation or foreign keys into another schema.
The base Entity class establishes the integer type; it does not configure SQL.

Services must not reference each other's projects or query each other's tables.
Communicate through service APIs or messages when integration is added.

Only the architecture scaffold and health endpoint are implemented. Add domain
entities, application services, persistence, and business endpoints next.

Official documentation:
- https://learn.microsoft.com/dotnet/core/tools/dotnet-build
- https://learn.microsoft.com/aspnet/core/web-api/?view=aspnetcore-10.0
