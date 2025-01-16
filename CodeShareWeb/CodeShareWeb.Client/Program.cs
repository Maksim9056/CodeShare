using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace CodeShareWeb.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddBlazoredLocalStorage(); // Register Blazored.LocalStorage
            builder.Services.AddMemoryCache();

            await builder.Build().RunAsync();
        }
    }
}
