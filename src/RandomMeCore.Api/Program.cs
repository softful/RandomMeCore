using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RandomMeCore.Api
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            using var webHost = CreateWebHostBuilder(args).Build();
            await webHost.RunAsync();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)                                
                .ConfigureWebHostDefaults(webBuilder =>
                {                
                    webBuilder.UseStartup<Startup>();
                });
    }
}
