using induccionef;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNpgsql<InduccionContext>(builder.Configuration.GetConnectionString("InduccionDb"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion",async ([FromServices] InduccionContext dbContext)  => {
    dbContext.Database.EnsureCreated();

    return Results.Ok("Base de datos creada");
});

app.Run();
