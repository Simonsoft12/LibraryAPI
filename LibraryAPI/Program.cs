using LibraryAPI.Repositories.Book;
using LibraryAPI.Services;
using LibraryAPI;
using System.Data.SqlClient;
using System.Data;
using LibraryAPI.Repositories;
using FluentValidation;
using MediatR;
using LibraryAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 1. Rejestracja połączenia z bazą danych
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));

// 2. Rejestracja repozytoriów
builder.Services.AddScoped<IBookRepository, BookRepository>();

// 3. Rejestracja usług
builder.Services.AddScoped<IBookService, BookService>();

// 4. Rejestracja HttpClient
builder.Services.AddHttpClient();

// 5. Rejestracja FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// 6. Rejestracja MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// 7. Rejestracja AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

// 8. Rejestracja kontrolerów
builder.Services.AddControllers();

// 9. Rejestracja Swagger (tylko w środowisku deweloperskim)
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// 10. Middleware do obsługi wyjątków
app.UseMiddleware<ExceptionHandlingMiddleware>();

// 11. Konfiguracja pipeline'u HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  // Wymuszanie HTTPS
app.UseAuthorization();     // Włączanie autoryzacji

app.MapControllers();       // Mapowanie kontrolerów

app.Run();