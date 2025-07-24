using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace TailSpin.SpaceGame.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
             // Simulate tainted input (e.g., from user input)
            string userInput = args.Length > 0 ? args[0] : "ls";
            Process.Start("bash", "-c \"" + userInput + "\"");  // ⚠️ Should trigger CodeQL command injection

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
