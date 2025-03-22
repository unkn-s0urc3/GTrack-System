using System.Windows.Controls;
using GTrack_Control.View.UserSystemControl;
using ReactiveUI;

namespace GTrack_Control.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        private UserControl _content;
        public UserControl Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public MainViewModel()
        {
            Title = "GTrack-Control";
            Content = new MainUserControl();
        }
    }
}