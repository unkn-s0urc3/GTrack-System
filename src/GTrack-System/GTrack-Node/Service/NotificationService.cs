using System.Windows;

namespace GTrack_Node.Service
{
    // Interface defining the notification service
    public interface INotificationService
    {
        void ShowError(string message);  // Method to display an error message
        void ShowSuccess(string message); // Method to display a success message
    }

    // Implementation of the notification service
    public class NotificationService : INotificationService
    {
        // Displays an error message using a MessageBox
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        // Displays a success message using a MessageBox
        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}