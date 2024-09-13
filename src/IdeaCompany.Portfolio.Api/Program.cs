using System.Globalization;
using IdeaCompany.Portfolio.Api.Infrastructure.Extensions;
using IdeaCompany.Portfolio.Core.Common.Data;
using IdeaCompany.Portfolio.Core.Common.Data.Impl;
using IdeaCompany.Portfolio.Data.Ef;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;
builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("PortfolioDBConexion")));

builder.Services.RegisterDependencies();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork<PortfolioDbContext>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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