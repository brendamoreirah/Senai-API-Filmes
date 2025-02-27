using api_filmes_senai.Context;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Filmes_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGeneroRepository,GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository,IFilmeRepository>();


builder.Services.AddScoped<IGeneroRepository,GeneroRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
