using Microsoft.Extensions.DependencyInjection;
using TransmitterCalculator.Drawning;

namespace TransmitterCalculator
{
    public static class Dependencies
    {
        public static ServiceProvider ResolveDependeciesAndBuild(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICoordinateSystemDrawer, CoordinateSystemDrawer>();
            serviceCollection.AddSingleton<ICoordinateSystem, CoordinateSystem>();
            serviceCollection.AddSingleton<ICoordinateCalculator, CoordinateCalculator>();
            serviceCollection.AddSingleton<ITransmitterService, TransmitterService>();
            serviceCollection.AddSingleton<MainForm>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
