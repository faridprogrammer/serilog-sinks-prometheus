using Serilog.Configuration;

namespace Serilog.Sinks.Prometheus
{
	public  static class LoggerSincConfigurationExtensions
	{
		public static LoggerConfiguration Prometheus(this LoggerSinkConfiguration sinkConfiguration)
		{
			return sinkConfiguration.Sink(new PrometheusLogLevelEventSink());
		}
	}
}