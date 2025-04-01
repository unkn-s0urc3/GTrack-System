using GTrack_Node.Service;
using GTrack_Service.Service;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;

namespace GTrack_Node.ViewModel
{
    // ViewModel for handling the GTrack Node logic
    public class GTrackNodeViewModel : MvxViewModel
    {
        private readonly NetworkValidationService _networkValidation; // Service for validating network configurations
        private readonly NotificationService _notificationService; // Service for displaying notifications

        // Property for the local IP address of the GTrack Control server
        private string _localIpGTrackControl;
        public string LocalIpGTrackControl
        {
            get => _localIpGTrackControl;
            set => SetProperty(ref _localIpGTrackControl, value); // Bindable property for LocalIpGTrackControl
        }

        // Property for the port number of the GTrack Control server
        private string _portGTrackControl;
        public string PortGTrackControl
        {
            get => _portGTrackControl;
            set => SetProperty(ref _portGTrackControl, value); // Bindable property for PortGTrackControl
        }

        // Property for the status of the GTrack Control connection
        private string _statusGTrackControl;
        public string StatusGTrackControl
        {
            get => _statusGTrackControl;
            set => SetProperty(ref _statusGTrackControl, value); // Bindable property for StatusGTrackControl
        }

        // Property for the local IP address of the GTrack Node
        private string _localIpGTrackNode;
        public string LocalIpGTrackNode
        {
            get => _localIpGTrackNode;
            set => SetProperty(ref _localIpGTrackNode, value); // Bindable property for LocalIpGTrackNode
        }

        // Property for the port number of the GTrack Node
        private string _portGTrackNode;
        public string PortGTrackNode
        {
            get => _portGTrackNode;
            set => SetProperty(ref _portGTrackNode, value); // Bindable property for PortGTrackNode
        }

        // Property for the status of the GTrack Node server
        private string _statusGTrackNode;
        public string StatusGTrackNode
        {
            get => _statusGTrackNode;
            set => SetProperty(ref _statusGTrackNode, value); // Bindable property for StatusGTrackNode
        }

        // Observable collection for storing the list of GTrack stations
        private ObservableCollection<string> _gTrackStations;
        public ObservableCollection<string> GTrackStations
        {
            get => _gTrackStations;
            set => SetProperty(ref _gTrackStations, value); // Bindable collection for GTrackStations
        }

        // Property for the current selected station
        private string _currentStation;
        public string CurrentStation
        {
            get => _currentStation;
            set => SetProperty(ref _currentStation, value); // Bindable property for CurrentStation
        }

        // Property for the current selected satellite
        private string _currentSatellite;
        public string CurrentSatellite
        {
            get => _currentSatellite;
            set => SetProperty(ref _currentSatellite, value); // Bindable property for CurrentSatellite
        }

        // Property for the time of the next session
        private string _nextSessionTime;
        public string NextSessionTime
        {
            get => _nextSessionTime;
            set => SetProperty(ref _nextSessionTime, value); // Bindable property for NextSessionTime
        }

        // Property for the azimuth value
        private string _azimuth;
        public string Azimuth
        {
            get => _azimuth;
            set => SetProperty(ref _azimuth, value); // Bindable property for Azimuth
        }

        // Property for the elevation value
        private string _elevation;
        public string Elevation
        {
            get => _elevation;
            set => SetProperty(ref _elevation, value); // Bindable property for Elevation
        }

        // Property for the slant range value
        private string _slantRange;
        public string SlantRange
        {
            get => _slantRange;
            set => SetProperty(ref _slantRange, value); // Bindable property for SlantRange
        }

        // Property for the altitude value
        private string _altitude;
        public string Altitude
        {
            get => _altitude;
            set => SetProperty(ref _altitude, value); // Bindable property for Altitude
        }

        // Property for the Doppler shift value
        private string _doppler;
        public string Doppler
        {
            get => _doppler;
            set => SetProperty(ref _doppler, value); // Bindable property for Doppler
        }

        // Command to connect to the GTrack Control server
        public MvxCommand ConnectGTrackControlServerCommand { get; }

        // Command to start the GTrack Node server
        public MvxCommand StartGTrackNodeServerCommand { get; }

        // Constructor initializing services and commands
        public GTrackNodeViewModel()
        {
            _networkValidation = new NetworkValidationService(); // Initialize the network validation service
            _notificationService = new NotificationService(); // Initialize the notification service

            // Initialize commands
            ConnectGTrackControlServerCommand = new MvxCommand(ConnectGTrackControl);
            StartGTrackNodeServerCommand = new MvxCommand(StartGTrackNodeServer);
        }

        // Method to connect to the GTrack Control server
        private void ConnectGTrackControl()
        {
            // Validate IP address and port for the GTrack Control server
            if (_networkValidation.IsValidIp(LocalIpGTrackControl))
            {
                if (_networkValidation.IsValidPort(PortGTrackControl))
                {
                    // Success message and status update if connection is valid
                    var successMessage = "Успешное подключение к GTrack на IP: " + LocalIpGTrackControl + ", порт: " + PortGTrackControl + ".";
                    StatusGTrackControl = successMessage;
                    _notificationService.ShowSuccess(successMessage);
                }
                else
                {
                    // Error message if the port is invalid
                    var errorMessage = $"Порт {PortGTrackControl} является недействительным. Порты должны быть в пределах от 1024 до 65535.";
                    _notificationService.ShowError(errorMessage);
                }
            }
            else
            {
                // Error message if the IP address is invalid
                var errorMessage = $"IP-адрес {LocalIpGTrackControl} неверный. Убедитесь, что введён корректный адрес.";
                _notificationService.ShowError(errorMessage);
            }
        }

        // Method to start the GTrack Node server
        private void StartGTrackNodeServer()
        {
            // Validate IP address and port for the GTrack Node server
            if (_networkValidation.IsValidIp(LocalIpGTrackNode))
            {
                if (_networkValidation.IsValidPort(PortGTrackNode))
                {
                    // Success message and status update if the server is started successfully
                    var successMessage = "Сервер GTrack Node успешно запущен на IP: " + LocalIpGTrackNode + ", порт: " + PortGTrackNode + ".";
                    StatusGTrackNode = successMessage;
                    _notificationService.ShowSuccess(successMessage);
                }
                else
                {
                    // Error message if the port is invalid
                    var errorMessage = $"Порт {PortGTrackNode} является недействительным. Порты должны быть в пределах от 1024 до 65535.";
                    _notificationService.ShowError(errorMessage);
                }
            }
            else
            {
                // Error message if the IP address is invalid
                var errorMessage = $"IP-адрес {LocalIpGTrackNode} неверный. Убедитесь, что введён корректный адрес.";
                _notificationService.ShowError(errorMessage);
            }
        }
    }
}