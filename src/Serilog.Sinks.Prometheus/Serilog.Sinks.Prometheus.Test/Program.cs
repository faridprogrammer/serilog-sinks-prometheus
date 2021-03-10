using System;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Prometheus;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Prometheus()
                .Enrich.WithProperty("ApplicationName", "TestApplication")
                .Enrich.WithProperty("SourceContext", "TestContext")
                .CreateLogger();
            
            Log.Information("Hello, Serilog!");
        
            Log.CloseAndFlush();
        }
    }
}
