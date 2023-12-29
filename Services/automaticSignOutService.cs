
public class AutomaticSignOutService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<AutomaticSignOutService> _logger;

    public AutomaticSignOutService(IServiceScopeFactory scopeFactory, ILogger<AutomaticSignOutService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<Context>();

                    // Check the current time
                    var currentTime = DateTime.Now;

                    // Perform automatic sign-out logic if it's after 8:30 PM
                    if (currentTime.Hour >= 20 && currentTime.Minute >= 30)
                    {
                        // Get sessions that need to be signed out
                        var sessionsToSignOut = dbContext.HubSessions
                            .Where(h => !h.TimeOut.HasValue && h.TimeIn < currentTime.TimeOfDay)
                            .ToList();

                        // Sign out each session
                        foreach (var session in sessionsToSignOut)
                        {
                            session.TimeOut = currentTime.TimeOfDay;
                        }

                        // Save changes to the database
                        dbContext.SaveChanges();

                        _logger.LogInformation("Automatic sign-out performed at {Time}.", currentTime);
                    }
                }

                // Wait for the next iteration (adjust the delay as needed)
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
            catch (Exception ex)
            {
                // Log any exceptions and continue
                _logger.LogError(ex, "An error occurred in the AutomaticSignOutService.");
            }
        }
    }
}
