using MediatR;
using Nilvera.Persistence;
using Nilvera.Application.Features.Firma.Commands;
using System.Reflection;
using Nilvera.Application.Features.Firma.Handlers;
using Nilvera.Infrastructure.Repositories;
using Nilvera.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        typeof(CreateFirmaCommandHandler).Assembly, // Application katmaný
        typeof(GetFirmaByIdQueryHandler).Assembly,  // Application katmaný
        Assembly.GetExecutingAssembly()             // API katmaný
    )
);

builder.Services.AddScoped<IFirmaRepository, FirmaRepository>();


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
