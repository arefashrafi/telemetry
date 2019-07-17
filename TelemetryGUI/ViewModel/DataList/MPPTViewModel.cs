using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;

namespace TelemetryGUI.ViewModel.DataList
{
    public class MPPTViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MPPT> _mppts;

        public MPPTViewModel()
        {
            _mppts = new ObservableCollection<MPPT>();
            WeakEventManager<EventSource, EntityEventArgs>.AddHandler(null, nameof(EventSource.EventMppt),
    Instance_DataChange);
        }

        public MPPT MPPT { get; set; }

        public ObservableCollection<MPPT> MPPTs
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
            get => MPPT.Id;
            set
            {
                if (MPPT.Id != value)
                {
                    MPPT.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Time
        {
            get => MPPT.Time;
            set
            {
                if (MPPT.Time != value)
                {
                    MPPT.Time = value;
                    OnPropertyChanged("Time");
                }
            }
        }

        public int InputCurrent
        {
            get => MPPT.InputCurrent;
            set
            {
                if (MPPT.InputCurrent != value)
                {
                    MPPT.InputCurrent = value;
                    OnPropertyChanged("InputCurrent");
                }
            }
        }

        public int InputVoltage
        {
            get => MPPT.InputVoltage;
            set
            {
                if (MPPT.InputVoltage != value)
                {
                    MPPT.InputVoltage = value;
                    OnPropertyChanged("InputVoltage");
                }
            }
        }

        public int OutputVoltage
        {
            get => MPPT.OutputVoltage;
            set
            {
                if (MPPT.OutputVoltage != value)
                {
                    MPPT.OutputVoltage = value;
                    OnPropertyChanged("OutputVoltage");
                }
            }
        }

        public int ControllerTemp
        {
            get => MPPT.ControllerTemp;
            set
            {
                if (MPPT.ControllerTemp != value)
                {
                    MPPT.ControllerTemp = value;
                    OnPropertyChanged("ControllerTemp");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Instance_DataChange(object sender, EntityEventArgs e)
        {
            MPPT = e.Data as MPPT;
            if (MPPT == null) return;
            Application.Current.Dispatcher.Invoke(delegate // <--- HERE
            {
                _mppts.Add(MPPT);

                if (_mppts.Count > 1000) _mppts.RemoveAt(0);
            });
        }


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}