using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patient.Domain.Entities;

namespace Patient.Infrastructure.Persistence.Configurations;

public class PatientRecordConfiguration : IEntityTypeConfiguration<PatientRecord>
{
    public void Configure(EntityTypeBuilder<PatientRecord> builder)
    {
        builder.ToTable("PATIENTS");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
               .HasColumnName("PATIENT_ID")
               .ValueGeneratedOnAdd();

        // Soft delete: deleted patients are hidden from every query.
        // Use .IgnoreQueryFilters() when you really need them.
        builder.HasQueryFilter(p => !p.IsDeleted);

        builder.Property(p => p.FileNo)
               .HasColumnName("FILE_NO")
               .HasMaxLength(20)
               .IsRequired();

        builder.HasIndex(p => p.FileNo)
               .IsUnique()
               .HasDatabaseName("IX_PATIENTS_FILE_NO");

        builder.Property(p => p.NationalId)
               .HasColumnName("NATIONAL_ID")
               .HasMaxLength(30);

        builder.Property(p => p.Name)
               .HasColumnName("NAME")
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(p => p.DateOfBirth)
               .HasColumnName("DATE_OF_BIRTH")
               .HasColumnType("date")
               .IsRequired();

        builder.Property(p => p.Gender)
               .HasColumnName("GENDER")
               .HasConversion<string>()
               .HasMaxLength(10)
               .IsUnicode(false)
               .IsRequired();

        builder.Property(p => p.BloodGroup)
               .HasColumnName("BLOOD_GROUP")
               .HasMaxLength(5)
               .IsUnicode(false);

        builder.Property(p => p.PhoneNumber)
               .HasColumnName("PHONE_NUMBER")
               .HasMaxLength(20)
               .IsUnicode(false)
               .IsRequired();

        builder.HasIndex(p => p.PhoneNumber)
               .HasDatabaseName("IX_PATIENTS_PHONE_NUMBER");

        builder.Property(p => p.Email)
               .HasColumnName("EMAIL")
               .HasMaxLength(100)
               .IsUnicode(false);

        builder.Property(p => p.Address)
               .HasColumnName("ADDRESS")
               .HasMaxLength(250);

        // Audit columns from BaseModel
        builder.Property(p => p.IsDeleted)
               .HasColumnName("IS_DELETED")
               .IsRequired();

        builder.Property(p => p.CreationUser)
               .HasColumnName("CREATION_USER")
               .HasMaxLength(50)
               .IsUnicode(false)
               .IsRequired();

        builder.Property(p => p.CreationDate)
               .HasColumnName("CREATION_DATE")
               .HasColumnType("datetime2")
               .HasDefaultValueSql("SYSUTCDATETIME()")
               .IsRequired();

        builder.Property(p => p.ModificationUser)
               .HasColumnName("MODIFICATION_USER")
               .HasMaxLength(50)
               .IsUnicode(false);

        builder.Property(p => p.ModificationDate)
               .HasColumnName("MODIFICATION_DATE")
               .HasColumnType("datetime2");
    }
}
