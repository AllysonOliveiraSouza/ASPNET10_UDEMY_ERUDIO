using ProjetoPrincipal.Configurations;
using ProjetoPrincipal.Repositories;
using ProjetoPrincipal.Repositories.Implementations;
using ProjetoPrincipal.Services;
using ProjetoPrincipal.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddSerilogLogging(); //Necessário estar aqui, mais ao topo, senão pode dar problema.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped(typeof(IRepositoryBase<>),typeof(RepositoryBase<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
