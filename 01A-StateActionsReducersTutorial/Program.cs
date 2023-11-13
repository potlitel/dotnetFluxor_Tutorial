using _01A_StateActionsReducersTutorial;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddScoped<App>();
        services.AddFluxor(o => o
          .ScanAssemblies(typeof(Program).Assembly));

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        var app = serviceProvider.GetRequiredService<App>();
        app.Run();
    }
}