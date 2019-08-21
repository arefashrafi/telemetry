using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;

namespace TelemetryGUI.ViewModel.DataList
{
    public sealed class MpptViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MPPT> _mppts;

        public MpptViewModel()
        {
            _mppts = new ObservableCollection<MPPT>();
            WeakEventManager<EventSource, EntityEventArgs>.AddHandler(null, nameof(EventSource.EventMppt),
                Instance_DataChange);
        }

        public MPPT Mppt { get; set; }

        public ObservableCollection<MPPT> MppTs
        {
            get => _mppts;
            set
            {
                _mppts = value;
                OnPropertyChanged("mppts");
            }
        }

        public int Id
        {
            get => Mppt.Id;
            set
            {
                if (Mppt.Id != value)
                {
                    Mppt.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Time
        {
            get => Mppt.Time;
            set
            {
                if (Mppt.Time != value)
                {
                    Mppt.Time = value;
                    OnPropertyChanged("Time");
                }
            }
        }

        public int InputCurrent
        {
            get => Mppt.InputCurrent;
            set
            {
                if (Mppt.InputCurrent != value)
                {
                    Mppt.InputCurrent = value;
                    OnPropertyChanged("InputCurrent");
                }
            }
        }

        public int InputVoltage
        {
            get => Mppt.InputVoltage;
            set
            {
                if (Mppt.InputVoltage != value)
                {
                    Mppt.InputVoltage = value;
                    OnPropertyChanged("InputVoltage");
                }
            }
        }

        public int OutputVoltage
        {
            get => Mppt.OutputVoltage;
            set
            {
                if (Mppt.OutputVoltage != value)
                {
                    Mppt.OutputVoltage = value;
                    OnPropertyChanged("OutputVoltage");
                }
            }
        }

        public int ControllerTemp
        {
            get => Mppt.ControllerTemp;
            set
            {
                if (Mppt.ControllerTemp != value)
                {
                    Mppt.ControllerTemp = value;
                    OnPropertyChanged("ControllerTemp");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Instance_DataChange(object sender, EntityEventArgs e)
        {
            Mppt = e.Data as MPPT;
            if (Mppt == null) return;
            Application.Current.Dispatcher.Invoke(delegate // <--- HERE
            {
                _mppts.Add(Mppt);

                if (_mppts.Count > 1000) _mppts.RemoveAt(0);
            });
        }


        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}