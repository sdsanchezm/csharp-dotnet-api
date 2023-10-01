var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "your minimal API is working!");

app.Run();
