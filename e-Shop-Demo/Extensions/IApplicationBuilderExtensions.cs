using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace e_Shop_Demo.Extensions
{
    public static class IApplicationBuilderExtensions
    {

        public static void UseMyNLog(this IApplicationBuilder builder, IConfiguration configuration)
        {
            var fileName = configuration.GetSection("Logging:FileName").ToString();
            var config = new NLog.Config.LoggingConfiguration();
            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = fileName };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            // Rules for mapping loggers to targets            
            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logconsole);
            config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, logfile);
            // Apply config           
            NLog.LogManager.Configuration = config;
        }
    }
}
