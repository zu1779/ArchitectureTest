namespace Zu1779.ArchTest.SL.Api2BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using NLog;
    using NLog.Web;

    public class Program
    {
        public static void Main(string[] args)
        {
            var log = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                log.Debug($"static void Main, args = {string.Join(' ', args)}");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Exception in static Main");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
                log.Debug($"shutdown before void Main exit");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseLightInject()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(c =>
                {
                    c.ClearProviders();
                    c.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .UseNLog();
    }
}
