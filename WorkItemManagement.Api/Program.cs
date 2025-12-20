using Microsoft.EntityFrameworkCore;
using WorkItemManagement.Api.Data;
using WorkItemManagement.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IWorkItemService, WorkItemService>();

var app = builder.Build();

app.MapControllers();

app.Run();
