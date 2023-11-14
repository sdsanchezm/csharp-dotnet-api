using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Middleware;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Configuration.GetConnectionString("connTareasdB");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<ToDoContext>("Data Source=KRAUSP52\\SQLEXPRESS;Initial Catalog=TodoDb;Trusted_Connection=True;TrustServerCertificate=true;");

// DI 1 - this way is used with no parameters
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();

// DI 2 - this way is used when parameters are required to be pass to the class
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService());

// this is a dependency of the service CategoryService
builder.Services.AddScoped<ICategoryService, CategoryService>();

// this is a dependency of the service ToDoService
builder.Services.AddScoped<IToDoService, ToDoService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

//app.UseTimeMiddlware();

app.MapControllers();

app.Run();
