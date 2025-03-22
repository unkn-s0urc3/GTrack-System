using Microsoft.Extensions.DependencyInjection;

namespace GTrack_Control.ViewModel
{
    public class ViewModelLocator
    {
        private static ServiceProvider _provider;

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddTransient<MainViewModel>();
            services.AddTransient<GTrackControlViewModel>();

            _provider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                _provider.GetRequiredService(item.ServiceType);
            }
        }

        public MainViewModel MainViewModel => _provider.GetRequiredService<MainViewModel>();

        public GTrackControlViewModel GTrackControlViewModel => _provider.GetRequiredService<GTrackControlViewModel>();
    }
}