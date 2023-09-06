using Microsoft.EntityFrameworkCore;
using webapi_project_functional;
using webapi_project_functional.Services;
using webapi_project_functional.Controllers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //builder.Services.AddSqlServer<ToDoContext>("Data Source=KRAUSP52\\SQLEXPRESS;Initial Catalog=ToDosDataB1;Trusted_Connection=True;TrustServerCertificate=true;");
        //builder.Services.AddSqlServer<ToDoContext>(builder.Configuration.GetConnectionString("connString1"));
        builder.Services.AddSqlServer<ToDoContext>(builder.Configuration.GetConnectionString("connString2"));
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IToDoService, ToDoService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}