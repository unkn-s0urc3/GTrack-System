using GTrack_Node.Service;
using GTrack_Services.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GTrack_Node.ViewModel
{
    // ViewModelLocator is responsible for setting up and providing dependencies (using Dependency Injection) for the ViewModels in the application
    public class ViewModelLocator
    {
        // Static ServiceProvider to hold the built service container for dependency injection
        private static ServiceProvider _provider;

        // Initialize the service container and register all the necessary services and view models
        public static void Init()
        {
            var services = new ServiceCollection();

            // Register ViewModels with Singleton lifetime
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<GTrackNodeViewModel>();

            // Register services with Singleton lifetime
            services.AddSingleton<NetworkValidationService>(); // Registers NetworkValidationService
            services.AddSingleton<NotificationService>(); // Registers NotificationService

            // Build the ServiceProvider to create instances of the registered services
            _provider = services.BuildServiceProvider();

            // Ensures all services are initialized by requesting them from the provider
            foreach (var item in services)
            {
                _provider.GetRequiredService(item.ServiceType);
            }
        }

        // Property to get the MainViewModel instance from the service provider
        public MainViewModel MainViewModel => _provider.GetRequiredService<MainViewModel>();

        // Property to get the GTrackNodeViewModel instance from the service provider
        public GTrackNodeViewModel GTrackNodeViewModel => _provider.GetRequiredService<GTrackNodeViewModel>();
    }
}
