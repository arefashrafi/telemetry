using System.Collections.ObjectModel;
using System.ComponentModel;
using TelemetryDependencies.Models;

namespace TelemetryGUI.ViewModel.DataList
{
    public class ErrorViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Error> _errors;

        public ErrorViewModel()
        {
            Error = new Error();

            _errors = new ObservableCollection<Error>();
        }


        public Error Error { get; set; }

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

        public string Message
        {
            get => Error.Message;
            set
            {
                if (Error.Message != value)
                {
                    Error.Message = value;
                    OnPropertyChanged("Message");
                }
            }
        }

        public string ExceptionSource
        {
            get => Error.ExceptionSource;
            set
            {
                if (Error.Message != value)
                {
                    Error.Message = value;
                    OnPropertyChanged("ExceptionSource");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Update()
        {
            //using (var context = new TelemetryContext())
            //{
            //    var latest = context.Errors.LastOrDefault();

            //    if (_error.Id <= latest.Id)
            //    {
            //        _error.Id = latest.Id;
            //        _error = latest;
            //        if (_error != null)
            //        {
            //            if (true)//_error.Message == "Car")
            //            {
            //                MessageBox.Show(_error.Message);
            //            }
            //            _errors.Add(_error);
            //        }
            //    }
            //    _errors.Add(context.Errors.LastOrDefault());
            //}
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}