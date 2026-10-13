using Microsoft.EntityFrameworkCore;
using WebEmpresa.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("ConexionSQLServer")
    ?? throw new InvalidOperationException("Falta la cadena 'ConexionSQLServer' en ConnectionStrings.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString, sql => sql.EnableRetryOnFailure()));

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

// Endpoint de diagnóstico: https://localhost:7180/api/salud
app.MapGet("/api/salud", async (AppDbContext db) =>
{
    try
    {
        return await db.Database.CanConnectAsync()
            ? Results.Ok("Conexión a la base de datos OK")
            : Results.Problem("No se pudo conectar a la base de datos");
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.Run();
