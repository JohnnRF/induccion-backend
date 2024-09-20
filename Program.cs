using induccionef;
using induccionef.Repositories;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Conexión a la base de datos
builder.Services.AddNpgsql<InduccionContext>(builder.Configuration.GetConnectionString("InduccionDb"));

//Habilitar CORS
builder.Services.AddCors(options =>{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                        policy=>{
                            policy.WithOrigins("http://localhost:4200")
                                    .AllowAnyMethod()
                                    .AllowAnyHeader();                          
                        });
});

// Servicio para el uso de los Repository
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<BodegaRepository>();
// Servicio para el uso de los controladores
builder.Services.AddControllers();

var app = builder.Build();

//Usar la habilitación de cors
app.UseCors(MyAllowSpecificOrigins);


app.MapGet("/", () => "Hello World!");

// Mapeo de las rutas de los controladores
app.MapControllers();

app.Run();
