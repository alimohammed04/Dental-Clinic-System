<<<<<<< HEAD
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

=======
>>>>>>> eadca8ebd51cea47f682fc8cfb8d032bc1fb76a2
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
var connectionString = builder.Configuration.GetConnectionString("DentalClinicDb");

builder.Services.AddDbContext<PatientDbContext>(options =>
{
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.MigrationsAssembly(typeof(PatientDbContext).Assembly.FullName);
        sqlOptions.MigrationsHistoryTable("__PatientsMigrationsHistory", "patients");
    });
});

=======
>>>>>>> eadca8ebd51cea47f682fc8cfb8d032bc1fb76a2
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
