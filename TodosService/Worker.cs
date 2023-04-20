namespace TodosService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("** SERVICE STARTED **");

                var httpClient = new HttpClient();

                int id = 1; 

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Fetching todo {id} of 200...", id);

                    var todosJson = await httpClient.GetStringAsync(
                        $"https://localhost:7121/Coupen/DeleteingCoupensByDate");

                    _logger.LogInformation(todosJson);

                    if (id > 200)
                    {
                        id = 1;
                    }   

                    await Task.Delay(1000, stoppingToken);
                }
            }
            finally
            {
                _logger.LogInformation("** SERVICE STOPPED **");
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting service");

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping service");

            return base.StopAsync(cancellationToken);
        }
    

    }
}