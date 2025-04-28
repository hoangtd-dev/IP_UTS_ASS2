using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RentalCar.Infrastructure;
using RentalCar.Mappers;
using RentalCar.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.ConfigureWarnings(warning => warning.Ignore(RelationalEventId.PendingModelChangesWarning));
});

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddScoped<CarTypeRepository>();
builder.Services.AddScoped<CarBrandRepository>();
builder.Services.AddScoped<CarRepository>();
builder.Services.AddScoped<CarReservationRepository>();

builder.Services.AddAutoMapper(typeof(CarTypeProfile));
builder.Services.AddAutoMapper(typeof(CarBrandProfile));
builder.Services.AddAutoMapper(typeof(CarProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
