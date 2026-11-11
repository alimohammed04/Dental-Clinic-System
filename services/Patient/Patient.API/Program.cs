using Microsoft.EntityFrameworkCore;
using Patient.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DentalClinicDb")
    ?? throw new InvalidOperationException(
        "Connection string 'DentalClinicDb' is missing. Set it with: dotnet user-secrets set \"ConnectionStrings:DentalClinicDb\" \"...\"");

builder.Services.AddDbContext<PatientDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
        sqlOptions.MigrationsHistoryTable(DatabaseDefaults.MigrationsHistoryTable, DatabaseDefaults.Schema)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
