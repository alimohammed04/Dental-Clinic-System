
using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;



namespace Infrastructure.Persistence;

public class PatientDbContext : DbContext
{
    public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
    {
    }

    public DbSet<Patients> Patients => Set<Patients>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Patients>(entity =>
        {
            // Table and Schema
            entity.ToTable("PATIENTS", "patients");

            // Primary Key (Identity)
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .HasColumnName("PATIENT_ID")
                  .ValueGeneratedOnAdd();

            // Properties from your screenshot
            entity.Property(e => e.FileNo)
                  .HasColumnName("FILE_NO")
                  .HasMaxLength(20)
                  .IsRequired();

            entity.HasIndex(e => e.FileNo)
                  .IsUnique();

            entity.Property(e => e.NationalId)
                  .HasColumnName("NATIONAL_ID")
                  .HasMaxLength(30);

            entity.Property(e => e.Name)
                  .HasColumnName("NAME")
                  .HasMaxLength(150)
                  .IsRequired();

            entity.Property(e => e.DateOfBirth)
                  .HasColumnName("DATE_OF_BIRTH")
                  .HasColumnType("date")
                  .IsRequired();

            entity.Property(e => e.Gender)
                  .HasColumnName("GENDER")
                  .HasMaxLength(1)
                  .IsUnicode(false)
                  .IsRequired();

            entity.Property(e => e.BloodGroup)
                  .HasColumnName("BLOOD_GROUP")
                  .HasMaxLength(5)
                  .IsUnicode(false);

            entity.Property(e => e.PhoneNumber)
                  .HasColumnName("PHONE_NUMBER")
                  .HasMaxLength(20)
                  .IsUnicode(false)
                  .IsRequired();

            entity.HasIndex(e => e.PhoneNumber)
                  .HasDatabaseName("IX_PATIENTS_PHONE_NUMBER");

            entity.Property(e => e.Email)
                  .HasColumnName("EMAIL")
                  .HasMaxLength(100)
                  .IsUnicode(false);

            entity.Property(e => e.Address)
                  .HasColumnName("ADDRESS")
                  .HasMaxLength(250);

            // Audit & Status Columns (From BaseModel)

            entity.Property(e => e.IsDeleted)
                  .HasColumnName("IS_DELETED")
                  .HasDefaultValue(false)
                  .IsRequired();

            entity.Property(e => e.CreationUser)
                  .HasColumnName("CREATION_USER")
                  .HasMaxLength(50)
                  .IsUnicode(false)
                  .IsRequired();

            entity.Property(e => e.CreationDate)
                  .HasColumnName("CREATION_DATE")
                  .HasColumnType("datetime2")
                  .HasDefaultValueSql("SYSUTCDATETIME()")
                  .IsRequired();

            entity.Property(e => e.ModificationUser)
                  .HasColumnName("MODIFICATION_USER")
                  .HasMaxLength(50)
                  .IsUnicode(false);

            entity.Property(e => e.ModificationDate)
                  .HasColumnName("MODIFICATION_DATE")
                  .HasColumnType("datetime2");
        });
    }
}