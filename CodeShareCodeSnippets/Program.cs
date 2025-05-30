
using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Service;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog;

namespace CodeShareCodeSnippets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(
                     formatter: new JsonFormatter(),
                      path: "logs\\structured-.json",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Debug).CreateLogger();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddDbContext<CodeShareDB>(options =>
            //options.UseNpgsql(builder.Configuration.GetConnectionString("CodeShare")));
            builder.Services.AddDbContext<CodeShareDB>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("CodeShare1")));
            //builder.Services.AddDbContext<CodeShareDB>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("CodeShare")));
            builder.Services.AddScoped<ICodeShareCodeSnippets,CodeShareCodeSnippets.Services.CodeShareCodeSnippetsService>();

            
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
                // ���������, ���� �� ������������� ��������
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
