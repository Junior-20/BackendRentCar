using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using BackendRentCar2._0.Services.Implementacion;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add context
builder.Services.AddDbContext<RENTACARContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBRentCar"));
});
//add service
builder.Services.AddScoped<IMarcasRepository, MarcasRepository>();
builder.Services.AddScoped<IModelosRepository, ModelosRepository>();
builder.Services.AddScoped<ITiposdeVehiculosRepository, TiposdeVehiculosRepository>();
builder.Services.AddScoped<ITiposdeCombustiblesRepository, TiposdeCombustiblesRepository>();
builder.Services.AddScoped<IVehiculosRepository, VehiculosRepository>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<IEmpleadosRepository, EmpleadosRepository>();
builder.Services.AddScoped<IInspeccionRepository, InspeccionRepository>();
builder.Services.AddScoped<IRentaRepository, RentaRepository>();
builder.Services.AddScoped<IDocumentosRepository, DocumentosRepository>();
//Automapper
builder.Services.AddAutoMapper(typeof(Program));
//Cors
builder.Services.AddCors(options => 
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin();
        app.AllowAnyHeader();
        app.AllowAnyMethod();
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

app.UseAuthorization();

app.MapControllers();
app.UseCors("NuevaPolitica");
app.Run();
public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(
        ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String &&
            DateTime.TryParse(reader.GetString(), out var date))
        {
            return date;
        }
        return reader.GetDateTime();
    }

    public override void Write(
        Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }
}