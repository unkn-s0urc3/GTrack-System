using System.Windows.Controls;
using GTrack_Node.View.UserSystemControl;
using ReactiveUI;

namespace GTrack_Node.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        public string Title { get; set; }

        public UserControl Content { get; set; }


        public MainViewModel()
        {
            Title = "GTrack-Node";
            Content = new MainUserControl();
        }
    }
}
