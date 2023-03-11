using BackgroundWorkers.Services;

namespace BackgroundWorkers.Workers;

public class ImportShiftWorker : BackgroundService
{
    private readonly TimeSpan _period = TimeSpan.FromSeconds(10);
    private readonly IServiceScopeFactory _factory;
    public ImportShiftWorker(IServiceScopeFactory factory)
    {
        _factory = factory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new PeriodicTimer(_period);

        try
        {
            while(!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                await using AsyncServiceScope asyncScope = _factory.CreateAsyncScope();
                IShiftImportService _importService = asyncScope.ServiceProvider.GetRequiredService<IShiftImportService>();

                _importService.ImportShifts();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

    }
}
