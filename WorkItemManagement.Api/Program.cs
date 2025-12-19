using WorkItemManagement.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IWorkItemService, WorkItemService>();

var app = builder.Build();

app.UseHttpsRedirection(); // OK even if using http

app.MapControllers();

app.MapGet("/ping", () => "API is alive");
app.MapGet("/test", () => "Controller pipeline works");


app.Run();
