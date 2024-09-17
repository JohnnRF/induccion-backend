using induccionef;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Conexión a la base de datos
builder.Services.AddNpgsql<InduccionContext>(builder.Configuration.GetConnectionString("InduccionDb"));

// Servicio para el uso de los controladores
builder.Services.AddControllers();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

// Mapeo de las rutas de los controladores
app.MapControllers();

app.Run();
