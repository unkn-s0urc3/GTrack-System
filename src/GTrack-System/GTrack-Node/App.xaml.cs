using System.Windows;
using GTrack_Node.ViewModel;

namespace GTrack_Node
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
