using Microsoft.EntityFrameworkCore;
using BookManagerApi.Services;
using BookManagerApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IBookManagementService, BookManagementService>();
builder.Services.AddScoped<IAuthorManagementService, AuthorManagementService>();
builder.Services.AddControllers();

if (builder.Environment.EnvironmentName == "Testing")
    // in test environment use a fresh in-memory DB
    builder.Services.AddDbContext<ModelsContext>(option =>
    option.UseInMemoryDatabase("BookDb"));
else if (builder.Environment.EnvironmentName == "Production")
    builder.Services.AddDbContext<ModelsContext, MsSqlServerDbContext>();
else
    builder.Services.AddDbContext<ModelsContext, MySqlDbContext>();



// Configure Swagger/OpenAPI Documentation
// You can learn more on this link: https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Production" 
    || app.Environment.EnvironmentName == "Testing" )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();