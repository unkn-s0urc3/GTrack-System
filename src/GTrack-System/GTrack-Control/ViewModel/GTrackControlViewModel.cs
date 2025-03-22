using System.Collections.ObjectModel;
using ReactiveUI;

namespace GTrack_Control.ViewModel
{
    public class GTrackControlViewModel : ReactiveObject
    {
        private string _localIpGTrack;
        public string LocalIpGTrack
        {
            get => _localIpGTrack;
            set => this.RaiseAndSetIfChanged(ref _localIpGTrack, value);
        }

        private string _portGTrack;
        public string PortGTrack
        {
            get => _portGTrack;
            set => this.RaiseAndSetIfChanged(ref _portGTrack, value);
        }

        private string _statusGTrack;
        public string StatusGTrack
        {
            get => _statusGTrack;
            set => this.RaiseAndSetIfChanged(ref _statusGTrack, value);
        }

        private string _localIpHouston;
        public string LocalIpHouston
        {
            get => _localIpHouston;
            set => this.RaiseAndSetIfChanged(ref _localIpHouston, value);
        }

        private string _portHouston;
        public string PortHouston
        {
            get => _portHouston;
            set => this.RaiseAndSetIfChanged(ref _portHouston, value);
        }

        private string _statusHouston;
        public string StatusHouston
        {
            get => _statusHouston;
            set => this.RaiseAndSetIfChanged(ref _statusHouston, value);
        }

        private ObservableCollection<string> _gTrackStations;
        public ObservableCollection<string> GTrackStations
        {
            get => _gTrackStations;
            set => this.RaiseAndSetIfChanged(ref _gTrackStations, value);
        }

        private string _selectedStation;
        public string SelectedStation
        {
            get => _selectedStation;
            set => this.RaiseAndSetIfChanged(ref _selectedStation, value);
        }

        private string _currentObservation;
        public string CurrentObservation
        {
            get => _currentObservation;
            set => this.RaiseAndSetIfChanged(ref _currentObservation, value);
        }

        public GTrackControlViewModel()
        {
            GTrackStations = new ObservableCollection<string>();

            StatusGTrack = "Состояние: ожидание подключения";
            StatusHouston = "Состояние: ожидание подключения";
            CurrentObservation = "Не выбрано";
        }
    }
}