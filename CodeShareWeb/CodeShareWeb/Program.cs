using Blazored.LocalStorage;
using CodeShare_Library.Abstractions;
using CodeShare_Library.Service;
using CodeShareWeb.Client.Pages;
using CodeShareWeb.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CodeShareWeb
{
    public class Program
    {
        public static void Main(string[] args)
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

            builder.Services.AddBlazoredLocalStorage(); // Register Blazored.LocalStorage
            //builder.Services.Configure<UserService>(builder.Configuration.GetSection("UserService"));
            
            builder.Services.AddScoped<IUserServise, CodeShare_Library.Service.UserService>(provider =>
            {
                string url = builder.Configuration["Urls:UserService"];
                return new UserService(url);
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
    }
}
//builder.Services.AddAuthentication("Identity.Application").AddCookie();

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Админ"));
//    options.AddPolicy("UsersPolicy", policy => policy.RequireRole("Пользователь"));

//});
// Регистрация CustomAuthenticationStateProvider
