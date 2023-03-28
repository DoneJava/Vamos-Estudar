using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VamosEstudar.BLL;
using VamosEstudar.BLL.Interfaces;
using VamosEstudar.DAO;
using VamosEstudar.DAO.Interfaces;
using VamosEstudar.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VamosEstudarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VamosEstudarContext") ?? throw new InvalidOperationException("Connection string 'VamosEstudarContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<VamosEstudarContext>();
builder.Services.AddScoped<IEstudanteManager, EstudanteManager>();
builder.Services.AddScoped<IEstudanteRepository, EstudanteRepository>();
builder.Services.AddScoped<IFacade, Facade>();


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
