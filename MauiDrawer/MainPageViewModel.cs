using System.ComponentModel;
using System.Windows.Input;

namespace MauiDrawer
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool _isDrawerOpen;
        public bool IsDrawerOpen
        {
            get => _isDrawerOpen;
            set
            {
                _isDrawerOpen = value;
                OnPropertyChanged(nameof(IsDrawerOpen));
            }
        }

        public ICommand ToggleDrawerCommand { get; }

        public MainPageViewModel()
        {
            ToggleDrawerCommand = new Command(ToggleDrawer);
        }

        private void ToggleDrawer()
        {
            IsDrawerOpen = !IsDrawerOpen;
        }

    }
}
