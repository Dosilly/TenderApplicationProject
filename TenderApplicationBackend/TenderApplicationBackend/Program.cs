using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://*:3708")
                .UseUrls("http://*:5000")
                .UseIISIntegration()
                .UseStartup<Startup>();

        }
    }
}