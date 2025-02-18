
using CodeShare_Library.Date;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog;
using CodeShare_Library.Abstractions;
using CodeShareFiles.Service;

namespace CodeShareFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.Console()
           .WriteTo.File(
                formatter: new JsonFormatter(),
                 path: "logs\\structured-.json",
               rollingInterval: RollingInterval.Day,
               restrictedToMinimumLevel: LogEventLevel.Debug).CreateLogger();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CodeShareDB>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("CodeShare")));
            builder.Services.AddScoped<IFilesService, FilesService>();
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
                // ѕровер€ем, есть ли неприемленные миграции
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }
                //dbContext.Database.Migrate(); 
            }

            app.MapControllers();

            app.Run();
        }
    }
}
