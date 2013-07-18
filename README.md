MassTransit.SerilogIntegration
=====
Serilog Integration for Mass Transit
-----

### [Mass Transit Project](http://masstransit-project.com/ "Mass Transit")

### [Serilog Project](http://serilog.net/ "Serilog")

### Usage

```
ServiceBusFactory.New(sbc =>
{
	// uses the global Serilog instance.
	sbc.UseSerilog();
});
```

Or you can specify the logger explicitly:

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