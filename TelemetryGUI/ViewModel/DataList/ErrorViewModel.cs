using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;

namespace TelemetryGUI.ViewModel.DataList
{
    public class ErrorViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Error> _errors;
        private Error _error=new Error();
        public ErrorViewModel()
        { 
            _errors = new ObservableCollection<Error>();
            WeakEventManager<EventSource, EntityEventArgs>.AddHandler(null, nameof(EventSource.EventError),
    Instance_DataChange);
            ResetCommand = new RelayCommand(ResetErrors);

        }
        public RelayCommand ResetCommand { get; set; }
        public Visibility Visibility = Visibility.Hidden;
        public Error Error
        {
            get => _error;
            set
            {
                _error = value;
                OnPropertyChanged("Error");
            }
        }

        public ObservableCollection<Error> Errors
        {
            get => _errors;
            set
            {
                _errors = value;
                OnPropertyChanged("_errors");
            }
        }

        public int Id
        {
            get => Error.Id;
            set
            {
                if (Error.Id != value)
                {
                    Error.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Time
        {
            get => Error.Time;
            set
            {
                if (Error.Time != value)
                {
                    Error.Time = value;
                    OnPropertyChanged("Time");
                }
            }
        }



        private void Instance_DataChange(object sender, EntityEventArgs e)
        {
            
            _error = e.Data as Error;
            if (_error == null) return;
            Application.Current.Dispatcher.Invoke(delegate // <--- HERE
            {
                Visibility = Visibility.Visible;
                _errors.Add(_error);
                if (_errors.Count > 1000) _errors.RemoveAt(0);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

    

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        


        private void ResetErrors()
        {
            Visibility = Visibility.Hidden;
            _error = null;
            _errors.Clear();
        }
    }
}