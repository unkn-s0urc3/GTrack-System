using MvvmCross.ViewModels;
using System.Windows.Controls;
using GTrack_Control.View.UserSystemControl;

namespace GTrack_Control.ViewModel
{
    // Main ViewModel for the application, responsible for managing the title and content of the main view.
    public class MainViewModel : MvxViewModel
    {
        // Property to hold the title of the window or main screen
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value); // Sets the property value and notifies any changes
        }

        // Property to hold the content (UserControl) to be displayed on the main screen
        private UserControl _content;
        public UserControl Content
        {
            get => _content;
            set => SetProperty(ref _content, value); // Sets the property value and notifies any changes
        }

        // Constructor where the default values for Title and Content are set
        public MainViewModel()
        {
            Title = "GTrack-Control"; // Set the default title for the main window
            Content = new MainUserControl(); // Set the default content (a UserControl, likely the main user interface)
        }
    }
}