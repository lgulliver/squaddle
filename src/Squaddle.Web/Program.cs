using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Http;
using BlazorStrap;
using Blazored.SessionStorage;

namespace Squaddle.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);          
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient("BaseApi", client => {
                var configuration = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
                client.BaseAddress = new Uri(configuration["apiBaseUrl"]);
            });
            builder.Services.AddHttpClient("ChatApi", client => {
                var configuration = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
                client.BaseAddress = new Uri(configuration["chatApiBaseUrl"]);
            });

            builder.Services.AddBlazoredSessionStorage();

            builder.Services.AddBootstrapCss();

            await builder.Build().RunAsync();
        }
    }
}
