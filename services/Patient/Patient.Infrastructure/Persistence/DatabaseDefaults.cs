namespace Patient.Infrastructure.Persistence;

// Use these values when adding this service's EF Core DbContext.
public static class DatabaseDefaults
{
    public const string Schema = "patient";
    public const string MigrationsHistoryTable = "__PatientMigrationsHistory";
}
