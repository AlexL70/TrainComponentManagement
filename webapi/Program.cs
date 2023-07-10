using Microsoft.EntityFrameworkCore;
using webapi.Domain.Repositories;
using webapi.Infrastructure.Database;
using webapi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register custom services and repositories
RegisterServices(builder);

// Configure database context
var connStr = builder.Configuration.GetConnectionString("PostgresConnectionString");
builder.Services.AddDbContext<TrainComponentsDbContext>(options => {
    options.UseNpgsql(connStr);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} else
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void RegisterServices(WebApplicationBuilder builder) {
    builder.Services.AddTransient<ITrainComponentTypesRepository, TrainComponentTypesRepository>();
}
