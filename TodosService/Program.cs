using TodosService;

// Initialise the hosting environment.
IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        // Configure the Windows Service Name.
        options.ServiceName = "TodosService";
    })
    .ConfigureServices(services =>
    {
        // Register the primary worker service.
        services.AddHostedService<Worker>();

        // Register other services here...
    })
    .Build();

// Run the application.
await host.RunAsync();