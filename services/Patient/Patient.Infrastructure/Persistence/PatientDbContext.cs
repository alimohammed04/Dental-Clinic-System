using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;

namespace Patient.Infrastructure.Persistence;

public class PatientDbContext : DbContext
{
    public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
    {
    }

    public DbSet<PatientRecord> Patients => Set<PatientRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DatabaseDefaults.Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatientDbContext).Assembly);
    }
}
