using GTrack_Control.Service;
using GTrack_Service.Service;
using Microsoft.Win32;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;

namespace GTrack_Control.ViewModel
{
    // ViewModel for the GTrack Control logic
    public class GTrackControlViewModel : MvxViewModel
    {
        private readonly NetworkValidationService _networkValidation;
        private readonly NotificationService _notificationService;

        // Properties for GTrack Control server configuration
        private string _localIpGTrackControl;
        public string LocalIpGTrackControl
        {
            get => _localIpGTrackControl;
            set => SetProperty(ref _localIpGTrackControl, value);
        }

        private string _portGTrackControl;
        public string PortGTrackControl
        {
            get => _portGTrackControl;
            set => SetProperty(ref _portGTrackControl, value);
        }

        private string _statusGTrackControl;
        public string StatusGTrackControl
        {
            get => _statusGTrackControl;
            set => SetProperty(ref _statusGTrackControl, value);
        }

        // Properties for Houston server configuration
        private string _localIpHouston;
        public string LocalIpHouston
        {
            get => _localIpHouston;
            set => SetProperty(ref _localIpHouston, value);
        }

        private string _portHouston;
        public string PortHouston
        {
            get => _portHouston;
            set => SetProperty(ref _portHouston, value);
        }

        private string _statusHouston;
        public string StatusHouston
        {
            get => _statusHouston;
            set => SetProperty(ref _statusHouston, value);
        }

        // Observable collection for GTrack stations
        private ObservableCollection<string> _gTrackStations;
        public ObservableCollection<string> GTrackStations
        {
            get => _gTrackStations;
            set => SetProperty(ref _gTrackStations, value);
        }

        // Property for the selected GTrack station
        private string _selectedStation;
        public string SelectedStation
        {
            get => _selectedStation;
            set => SetProperty(ref _selectedStation, value);
        }

        // Property for the current observation
        private string _currentObservation;
        public string CurrentObservation
        {
            get => _currentObservation;
            set => SetProperty(ref _currentObservation, value);
        }

        // Commands for UI actions
        public MvxCommand StartGTrackControlServerCommand { get; private set; }
        public MvxCommand StartHoustonServerCommand { get; private set; }
        public MvxCommand AcceptStationCommand { get; private set; }
        public MvxCommand LoadTLECommand { get; private set; }

        public GTrackControlViewModel()
        {
            // Initialize services and set default values
            _networkValidation = new NetworkValidationService();
            _notificationService = new NotificationService();

            GTrackStations = new ObservableCollection<string>();
            StatusGTrackControl = "Состояние: ожидание подключения";
            StatusHouston = "Состояние: ожидание подключения";
            CurrentObservation = "Не выбрано";

            // Initialize commands
            StartGTrackControlServerCommand = new MvxCommand(StartGTrackControlServer);
            StartHoustonServerCommand = new MvxCommand(StartHoustonServer);
            AcceptStationCommand = new MvxCommand(AcceptStation);
            LoadTLECommand = new MvxCommand(LoadTLE);
        }

        // Method to start the GTrack Control server
        private void StartGTrackControlServer()
        {
            // Validate IP and Port for GTrack Control server
            if (_networkValidation.IsValidIp(LocalIpGTrackControl))
            {
                if (_networkValidation.IsValidPort(PortGTrackControl))
                {
                    var successMessage = "Сервер GTrack успешно запущен на IP: " + LocalIpGTrackControl + ", порт: " + PortGTrackControl + ".";
                    StatusGTrackControl = successMessage;
                    _notificationService.ShowSuccess(successMessage);
                }
                else
                {
                    var errorMessage = $"Порт {PortGTrackControl} является недействительным. Порты должны быть в пределах от 1024 до 65535.";
                    _notificationService.ShowError(errorMessage);
                }
            }
            else
            {
                var errorMessage = $"IP-адрес {LocalIpGTrackControl} неверный. Убедитесь, что введён корректный адрес.";
                _notificationService.ShowError(errorMessage);
            }
        }

        // Method to start the Houston server
        private void StartHoustonServer()
        {
            // Validate IP and Port for Houston server
            if (_networkValidation.IsValidIp(LocalIpHouston))
            {
                if (_networkValidation.IsValidPort(PortHouston))
                {
                    var successMessage = $"Сервер Houston успешно запущен на IP: {LocalIpHouston}, порт: {PortHouston}.";
                    StatusHouston = successMessage;
                    _notificationService.ShowSuccess(successMessage);
                }
                else
                {
                    var errorMessage = $"Порт {PortHouston} является недействительным. Порты должны быть в пределах от 1024 до 65535.";
                    _notificationService.ShowError(errorMessage);
                }
            }
            else
            {
                var errorMessage = $"IP-адрес {LocalIpHouston} неверный. Убедитесь, что введён корректный адрес.";
                _notificationService.ShowError(errorMessage);
            }
        }

        // Method to accept a station for observation
        private void AcceptStation()
        {
            CurrentObservation = "Станция принята";
        }

        // Method to load TLE (Two-Line Element) data
        private void LoadTLE()
        {
            // Open file dialog to select a TLE file
            var openFileDialog = new OpenFileDialog
            {
                Filter = "TLE files (*.tle;*.txt)|*.tle;*.txt|All files (*.*)|*.*",
                Title = "Выберите файл TLE"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var filePath = openFileDialog.FileName;

                try
                {
                    // Set the observation status to success
                    CurrentObservation = "TLE файл успешно загружен.";
                }
                catch (Exception ex)
                {
                    // Show error if there was a problem loading the file
                    _notificationService.ShowError($"Ошибка при загрузке файла: {ex.Message}");
                    CurrentObservation = "Ошибка при загрузке TLE.";
                }
            }
            else
            {
                // If the user cancels the file selection
                _notificationService.ShowError("Загрузка TLE была отменена.");
                CurrentObservation = "Загрузка TLE отменена.";
            }
        }
    }
}