using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Prometheus;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Sinks.Prometheus
{
	internal class PrometheusLogLevelEventSink : ILogEventSink
	{
        private readonly ConcurrentDictionary<string, Counter> _countersCache = new ConcurrentDictionary<string, Counter>();

		public void Emit(LogEvent logEvent)
        {
            var hasContext = logEvent.Properties.ContainsKey("SourceContext");
            var hasApplicationName = logEvent.Properties.TryGetValue("ApplicationName", out var applicationName);
            var counterName = $"{logEvent.Level.ToString().ToLower()}" ;
            

            var counter = _countersCache.GetOrAdd(counterName, n => Metrics.CreateCounter(counterName, "", "ApplicationName", "SourceContext"));
            counter.Labels(hasApplicationName ? applicationName.ToString(): "-", hasContext ? logEvent.Properties["SourceContext"].ToString(): "-").Inc();
        }
	}
}