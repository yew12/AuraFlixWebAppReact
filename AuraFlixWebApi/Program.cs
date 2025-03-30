using AuraFlixWebApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(); // Ensure controllers are added to the DI container

// Enable CORS for React frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
        policy.WithOrigins("http://localhost:3000")  // React dev server URL
              .AllowAnyMethod()
              .AllowAnyHeader());
});
var dbConnectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
// Configure DbContext with connection string
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseNpgsql(dbConnectionString)); // UseNpgsql should now be recognized

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

// Enable CORS
app.UseCors("AllowReactApp");


app.Run();
