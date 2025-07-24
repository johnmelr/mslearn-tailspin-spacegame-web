using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;

namespace TailSpin.SpaceGame.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a command: ");
            string input = Console.ReadLine(); // ✅ Known taint source
            Process.Start("bash", "-c \"" + input + "\""); // ✅ Known sink

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
