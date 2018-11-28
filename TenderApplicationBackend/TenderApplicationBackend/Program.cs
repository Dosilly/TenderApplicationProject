using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using TenderApplicationBackend.https;

namespace TenderApplicationBackend
{
    public class Program
    {
        public static void Main(string[] args)
        { 

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options => options.ConfigureEndpoints())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://*:3708")
                .UseUrls("http://*:5000")
                .UseIISIntegration()
               // .UseSetting("https_port", "8080")
                .UseStartup<Startup>();

        }
    }
}