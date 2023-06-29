using BackV2.Data.Repositories;
using BackV2.InternalService.Interface;
using BackV2.Services.Interface;
using System.Diagnostics;

namespace BackV2.InternalService;

public class HostedService : BackgroundService
{
    public IServiceProvider Services { get; }
    private int _executionCount;

    public HostedService(IServiceProvider services) 
    {
        Services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Debug.WriteLine(
            "Consume Scoped Service Hosted Service running.");

        try
        {
            using PeriodicTimer timer = new(TimeSpan.FromSeconds(1));
        
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                await DoWork();
            }
        }
        catch (OperationCanceledException)
        {
            Debug.WriteLine("Timed Hosted Service is stopping.");
        }
        finally
        {
            Debug.WriteLine(" Hosted Service is stopping.");

        }

    }

    private async Task DoWork()
    {
        Debug.WriteLine(
            "Consume Scoped Service Hosted Service is working.");

        using (var scope = Services.CreateScope())
        {
            var scopedProcessingService =
                scope.ServiceProvider
                    .GetRequiredService<IBlockService>();

            await scopedProcessingService.DoWork();
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        Debug.WriteLine(
            "Consume Scoped Service Hosted Service is stopping.");

        await base.StopAsync(stoppingToken);
    }
}
