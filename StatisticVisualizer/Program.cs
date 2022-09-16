using Microsoft.EntityFrameworkCore;
using StatisticVisualizer.Database;
using StatisticVisualizerLib.Database;
using StatisticVisualizerLib.Services.ExcelFileService;
using StatisticVisualizerLib.Services.StatisticService;

var builder = WebApplication.CreateBuilder(args);

var dbContext = new Database(builder.Configuration.GetConnectionString("Ssms"));
dbContext.Database.Migrate();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(dbContext as DatabaseContext);
builder.Services.AddScoped<IExcelFileService, ExcelFileService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Upload}/{action=Index}/{id?}");

app.Run();
