namespace Scheduling.Infrastructure.Persistence;

// Use these values when adding this service's EF Core DbContext.
public static class DatabaseDefaults
{
    public const string Schema = "scheduling";
    public const string MigrationsHistoryTable = "__SchedulingMigrationsHistory";
}
