using AdministracionAPI.Data;
using Microsoft.EntityFrameworkCore;


var misOrigenesEspecificosPermitidos = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Creamos nuestro propio servicio
builder.Services.AddDbContext<DataContext>(opciones =>
{
    //para poder conectar con la vase de datos
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Activar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: misOrigenesEspecificosPermitidos,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Usar todos los modelos con CORS
app.UseCors(misOrigenesEspecificosPermitidos);

app.UseAuthorization();

app.MapControllers();

app.Run();
