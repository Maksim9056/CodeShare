
using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShareUsers.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace CodeShareUsers
{
    public class Program
    {
        public static void Main(string[] args)
        { // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(
                     formatter: new JsonFormatter(),
                      path: "logs\\structured-.json",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Debug).CreateLogger();
            //.WriteTo.File(
            //   formatter: new JsonFormatter(),       // Самое важное — формат JSON
            //   outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{Level:u3}] {Message:lj}{NewLine}{Exception}"

            //   path: "logs\\structured-.json",                     path: "logs/log-.txt",

            try
            {
                Log.Debug("Отладочная информация");

                Log.Information("Starting web host");

                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                builder.Services.AddDbContext<CodeShareDB>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("CodeShare")));
                Log.Warning("Это предупреждение!Подключение к базе CodeShare");

                builder.Services.AddScoped<IManagentUser, ManagementUser>();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                using (var scope = app.Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<CodeShareDB>();
                    // Проверяем, есть ли неприемленные миграции
                    if (dbContext.Database.GetPendingMigrations().Any())
                    {
                        dbContext.Database.Migrate();
                    }
                    //dbContext.Database.Migrate(); 
                }

                app.MapControllers();


                Log.Information("Application has started successfully.");

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Error($"Что-то пошло не так...{ex}");

                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
