using MvvmCross.ViewModels;
using System.Windows.Controls;
using GTrack_Node.View.UserSystemControl;

namespace GTrack_Node.ViewModel
{
    // ViewModel for the main window of the GTrack Node application
    public class MainViewModel : MvxViewModel
    {
        // Property for the title of the application window
        private string _title;
        public string Title
        {
            get => _title; // Getter for Title
            set => SetProperty(ref _title, value); // Setter for Title (with property change notification)
        }

        // Property for the content (UI element) displayed in the main window
        private UserControl _content;
        public UserControl Content
        {
            get => _content; // Getter for Content
            set => SetProperty(ref _content, value); // Setter for Content (with property change notification)
        }

        // Constructor that sets the initial state of the ViewModel
        public MainViewModel()
        {
            // Initializing the title of the application
            Title = "GTrack-Node";

            // Initializing the content to be displayed in the main window (assigning a UserControl)
            Content = new MainUserControl(); // Setting the content to the custom UserControl
        }
    }
}