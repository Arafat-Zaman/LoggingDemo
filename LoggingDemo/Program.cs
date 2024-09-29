using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace LoggingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Set up a service collection and configure logging services
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // 2. Build the service provider and create the logger
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            // 3. Log different levels of messages
            logger.LogTrace("This is a trace log.");
            logger.LogDebug("This is a debug log.");
            logger.LogInformation("This is an information log.");
            logger.LogWarning("This is a warning log.");
            logger.LogError("This is an error log.");
            logger.LogCritical("This is a critical log.");

            // 4. Dispose of the service provider to release resources
            serviceProvider.Dispose();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // 5. Add logging services to the service collection
            services.AddLogging(configure =>
            {
                configure.AddConsole(); // Logs to the console
                configure.SetMinimumLevel(LogLevel.Trace); // Set minimum logging level
            });
        }
    }
}
