using IdeaCompany.Portfolio.Api.Infrastructure.Extensions;
using IdeaCompany.Portfolio.Data.Ef;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<PortfolioDbContext>((provider, options) =>
{
    var dbSqlName = configuration.GetValue<string>("DB_MSSQL_NAME");
    var dbSqlServer = configuration.GetValue<string>("DB_MSSQL_SERVER");
    var dbSqlServerUser = configuration.GetValue<string>("DB_MSSQL_USER");
    var dbSqlServerPwd = configuration.GetValue<string>("DB_MSSQL_PASSWORD");
    var dbSqlServerCertificate = configuration.GetValue<string>("DB_MSSQL_TRUST_SERVER_CERTIFICATE");
    
    var connectionStringSqlServer = $"Data Source={dbSqlServer};Initial Catalog={dbSqlName};User Id={dbSqlServerUser};Password={dbSqlServerPwd};TrustServerCertificate={dbSqlServerCertificate};";
    
    options.UseSqlServer(connectionStringSqlServer);
});

builder.Services.RegisterDependencies();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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