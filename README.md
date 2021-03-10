# Serilog.Sinks.Prometheus
A Serilog sink that writes log events to the Prometheus. 

`LogLevel` properties as Labels

## Usage

```c#
Log.Logger = new LoggerConfiguration()
	.Enrich.WithProperty("ApplicationName", "TestApplication")
	.Enrich.WithProperty("SourceContext", "TestContext")
	.WriteTo.Prometheus()
	.CreateLogger();

```
