using System.Windows.Controls;
using GTrack_Control.View.UserSystemControl;
using ReactiveUI;

namespace GTrack_Control.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        public string Title { get; set; }

        public UserControl Content { get; set; }


        public MainViewModel()
        {
            Title = "GTrack-Control";
            Content = new MainUserControl();
        }
    }
}