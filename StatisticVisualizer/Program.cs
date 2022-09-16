using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using StatisticVisualizer.Database;
using StatisticVisualizerLib;
using StatisticVisualizerLib.Database;
using StatisticVisualizerLib.Services.ExcelFileService;
using StatisticVisualizerLib.Services.StatisticService;

var builder = WebApplication.CreateBuilder(args);

#region serilog configuration
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var log = Log.ForContext<Program>();
var logTemplateConsole = "[{Level:u3}] <{ThreadId}> :: {Message:lj}{NewLine}{Exception}";
var logTemplateFile = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] <{ThreadId}> :: {Message:lj}{NewLine}{Exception}";

if (!Directory.Exists(DirectoryPaths.LogsDirectory))
{
    try
    {
        Directory.CreateDirectory(DirectoryPaths.LogsDirectory);
        log.Information($"Create directory {DirectoryPaths.LogsDirectory} for logs");
    }
    catch
    {
        log.Error($"Can't find or create directory {DirectoryPaths.LogsDirectory} for logs");
        return;
    }
}

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .Enrich.WithThreadId()
    .WriteTo.Console(outputTemplate: logTemplateConsole)
    .WriteTo.File(
        outputTemplate: logTemplateFile,
        path: Path.Combine(DirectoryPaths.LogsDirectory, "MessengerCoreApi.log"),
        shared: true,
        rollingInterval: RollingInterval.Day,
        fileSizeLimitBytes: 128 * 1024 * 1024
    )
);
#endregion serilog configuration

var dbContext = new Database(builder.Configuration.GetConnectionString("Ssms"));
dbContext.Database.Migrate();

builder.Services.AddControllersWithViews();

#region swagger settings

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "StatisticVisualizer",
        Version = "v1"
    });

    var xmlName = $"{Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location)}.xml";
    var xmlPath = Path.Combine(DirectoryPaths.WorkingDirectory, xmlName);
    c.IncludeXmlComments(xmlPath);
});

#endregion swagger settings

builder.Services.AddSingleton(dbContext as DatabaseContext);
builder.Services.AddScoped<IExcelFileService, ExcelFileService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "StatisticVisualizer"); });

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
