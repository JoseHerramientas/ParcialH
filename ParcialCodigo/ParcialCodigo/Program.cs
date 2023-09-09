using data;
using data.repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = new mysqlConfig(builder.Configuration.GetConnectionString("mysql"));
builder.Services.AddSingleton(connection);
builder.Services.AddScoped<iClientesRepository, clientesRepository>();
builder.Services.AddScoped<iEmpleadosRepository, empleadosRepository>();
builder.Services.AddScoped<iTiposSegurosRepository, tiposSegurosRepository>();
builder.Services.AddScoped<iVentasRepository, ventasRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
