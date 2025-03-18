using System.Windows;
using GTrack_Control.ViewModel;

namespace GTrack_Control
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ViewModelLocator.Init();
            base.OnStartup(e);
        }
    }
}
