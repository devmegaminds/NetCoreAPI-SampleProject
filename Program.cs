using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace UI_UX_Targeting_api
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method that starts the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates an <see cref="IHostBuilder"/> instance with predefined configurations.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>An <see cref="IHostBuilder"/> instance.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Specifies the startup class to use for configuring the application.
                    webBuilder.UseStartup<Startup>();
                });
    }
}
