MassTransit.SerilogIntegration - Serilog Integration for Mass Transit
==============================

[Mass Transit](http://masstransit-project.com/ "Mass Transit")
[Serilog](http://serilog.net/ "Serilog")

### Usage

```
ServiceBusFactory.New(sbc =>
{
	var logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Trace()
                    .CreateLogger();

	sbc.UseSerilog(logger);
});
```