using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ProjetoPrincipal.Configurations
{
    public static class LoggingConfig
    {
        public static void AddSerilogLogging(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug()
                .CreateLogger();
            builder.Host.UseSerilog();
        }
    }
}
