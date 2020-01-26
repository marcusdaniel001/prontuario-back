using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Prontuario.Api
{
    public class Program
    {
        private static readonly string Url = "http://127.0.0.1:5000";

        public static void Main(string[] args)
        {

            var host = new WebHostBuilder()
                .UseUrls(Url)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
