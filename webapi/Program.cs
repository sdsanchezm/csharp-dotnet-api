using Microsoft.EntityFrameworkCore;
using webapi.Middleware;
using WebApi.Models;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Configuration.GetConnectionString("connTareasdB");
builder.Services.AddDbContext<ToDoContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("connTareasdB"));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// DI 1
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();

// DI 2
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService());

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

app.UseTimeMiddlware();

app.MapControllers();

app.Run();
