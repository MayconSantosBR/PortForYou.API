using PortForYouProject.Data.Contexts;
using PortForYouProject.Data.Repositories;
using PortForYouProject.Data.Repositories.Interfaces;
using PortForYouProject.Models;
using PortForYouProject.Services;
using PortForYouProject.Services.Intefaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PortforyouContext>();

//Repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IFunctionaryRepository, FunctionaryRepository>();

//Services
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IFunctionaryService, FunctionaryService>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(MapperService));

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
