using Blazored.LocalStorage;
using CodeShare_Library.Abstractions;
using CodeShare_Library.Service;
using CodeShareWeb.Client.Pages;
using CodeShareWeb.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace CodeShareWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {


                var builder = WebApplication.CreateBuilder(args);

                //// Add services to the container.
                // Добавляем поддержку Razor компонентов с серверным и клиентским рендерингом
                builder.Services.AddRazorComponents()
                    .AddInteractiveServerComponents()
                    .AddInteractiveWebAssemblyComponents();

                //builder.Services.AddAuthentication("CustomAuthScheme")
                //    .AddCookie("CustomAuthScheme", options =>
                //    {
                //        options.LoginPath = "/Main"; 
                //        options.AccessDeniedPath = "/access-denied"; 
                //    });

                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
                    .WriteTo.File(
                         formatter: new JsonFormatter(),
                          path: "logs\\structured-.json",
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: LogEventLevel.Debug).CreateLogger();

                builder.Services.AddBlazoredLocalStorage(); // Register Blazored.LocalStorage
                                                            //builder.Services.Configure<UserService>(builder.Configuration.GetSection("UserService"));
                builder.Services.AddScoped<ICommentService, CommentService>(provider =>
                {
                    string url = builder.Configuration["Urls:CommentService"];
                    return new CommentService(url);
                });

                builder.Services.AddScoped<IUserServise, CodeShare_Library.Service.UserService>(provider =>
                {
                    string url = builder.Configuration["Urls:UserService"];
                    return new UserService(url);
                });

                builder.Services.AddScoped<ILanguage, CodeShare_Library.Service.LanguageServise>(provider =>
                {
                    string url = builder.Configuration["Urls:Code_Share_Language"];
                    return new LanguageServise(url);
                });

                builder.Services.AddScoped<ICodeShareCodeSnippets, CodeShare_Library.Service.CodeShareCodeSnippetsService>(provider =>
                {
                    string url = builder.Configuration["Urls:CodeShareCodeSnippets"];
                    return new CodeShareCodeSnippetsService(url);
                });

                builder.Services.AddScoped<IRateService, CodeShare_Library.Service.RateService>(provider =>
                {
                    string url = builder.Configuration["Urls:RateService"];
                    return new RateService(url);
                });
                builder.Services.AddScoped<ILogotype, CodeShare_Library.Service.LogotypeService>(provider =>
                {
                    string url = builder.Configuration["Urls:LogotypeService"];
                    return new LogotypeService(url);
                });
                builder.Services.AddScoped<ISettingService, CodeShare_Library.Service.SettingService>(provider =>
                {
                    string url = builder.Configuration["Urls:SettingService"];
                    return new SettingService(url);
                });
                //builder.Services.AddScoped<IFilesService, FilesService>();

                builder.Services.AddScoped<IFilesService, CodeShare_Library.Service.FilesService>(provider =>
                {
                    string url = builder.Configuration["Urls:FilesService"];
                    return new FilesService(url);
                });

                builder.Services.AddScoped<IRolesProvider, CodeShare_Library.Service.RolesService>(provider =>
                {
                    string url = builder.Configuration["Urls:Code_Share_Roles"];
                    return new RolesService(url);
                });



                //builder.Services.AddScoped<UserService>();
                builder.Services.AddHttpClient();

                builder.Services.AddRazorPages();
                builder.Services.AddServerSideBlazor();
                //builder.Services.AddCascadingAuthenticationState();
                //builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
                builder.Services.AddAuthorizationCore();
                builder.Services.AddMemoryCache();
                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseWebAssemblyDebugging();
                }
                else
                {
                    app.UseExceptionHandler("/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();

                app.UseStaticFiles();
                app.UseAntiforgery();
                app.UseAuthentication();
                app.UseAuthorization();

                app.MapRazorComponents<App>()
                    .AddInteractiveServerRenderMode()
                    .AddInteractiveWebAssemblyRenderMode()
                    .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

                app.Run();
            }
            catch(Exception exception)
            {
                Log.Error(exception.Message);

                Log.Error($"Что-то пошло не так...{exception}");

                Log.Fatal(exception, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
//builder.Services.AddAuthentication("Identity.Application").AddCookie();

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Админ"));
//    options.AddPolicy("UsersPolicy", policy => policy.RequireRole("Пользователь"));

//});
// Регистрация CustomAuthenticationStateProvider
