
using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using CodeShareChanges_in_the_system.Service;
using Microsoft.EntityFrameworkCore;

namespace CodeShareChanges_in_the_system
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CodeShareDB>(options =>
          options.UseNpgsql(builder.Configuration.GetConnectionString("CodeShare")));
            builder.Services.AddScoped<IChanges_in_the_system, Changes_in_the_system_Service>();
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
