using EmpDisconnection;
using EmpDisconnection.Data;
using EmpDisconnection.Interface;
using EmpDisconnection.Repositories;
using EmpDisconnection.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IEmployeeRepositorie, EmployeeRepositories>();//your interfaces and implemented classes
builder.Services.AddScoped<IEmployeeService, EmployeeService>();//your interfaces and implemented classes

builder.Services.AddSingleton<IConnectionFactory,ConnectionFactory>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
