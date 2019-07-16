using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;

namespace TelemetryGUI.ViewModel.DataList
{
    public class BmsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Bms> _bmSs;

        public BmsViewModel()
        {
            _bmSs = new ObservableCollection<Bms>();
            WeakEventManager<EventSource, EntityEventArgs>.AddHandler(null, nameof(EventSource.Event),
    Instance_DataChange);
        }

        public Bms Bms { get; set; }

        public ObservableCollection<Bms> BMSs
        {
            get => _bmSs;
            set
            {
                _bmSs = value;
                RaisePropertyChanged("BMSs");
            }
        }

        public int Id
        {
            get => Bms.Id;
            set
            {
                if (Bms.Id != value)
                {
                    Bms.Id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public uint MinVolt
        {
            get => Bms.MinVolt;
            set
            {
                if (Bms.MinVolt != value)
                {
                    Bms.MinVolt = value;
                    RaisePropertyChanged("MinVolt");
                }
            }
        }

        public uint MaxVolt
        {
            get => Bms.MaxVolt;
            set
            {
                if (Bms.MaxVolt != value)
                {
                    Bms.MaxVolt = value;
                    RaisePropertyChanged("MaxVolt");
                }
            }
        }

        public uint MinVoltId
        {
            get => Bms.MinVoltId;
            set
            {
                if (Bms.MinVoltId != value)
                {
                    Bms.MinVoltId = value;
                    RaisePropertyChanged("MinVoltId");
                }
            }
        }

        public uint MaxVoltId
        {
            get => Bms.MaxVoltId;
            set
            {
                if (Bms.MaxVoltId != value)
                {
                    Bms.MaxVoltId = value;
                    RaisePropertyChanged("MaxVoltId");
                }
            }
        }

        public uint Volt
        {
            get => Bms.Volt;
            set
            {
                if (Bms.Volt != value)
                {
                    Bms.Volt = value;
                    RaisePropertyChanged("Volt");
                }
            }
        }

        public int Current
        {
            get => Bms.Current;
            set
            {
                if (Bms.Current != value)
                {
                    Bms.Current = value;
                    RaisePropertyChanged("Current");
                }
            }
        }

        public uint Soc
        {
            get => Bms.Soc;
            set
            {
                if (Bms.Soc != value)
                {
                    Bms.Soc = value;
                    RaisePropertyChanged("SOC");
                }
            }
        }

        public int MinTemp
        {
            get => Bms.MinTemp;
            set
            {
                if (Bms.MinTemp != value)
                {
                    Bms.MinTemp = value;
                    RaisePropertyChanged("MinTemp");
                }
            }
        }

        public int MinTempId
        {
            get => Bms.MinTempId;
            set
            {
                if (Bms.MinTempId != value)
                {
                    Bms.MinTempId = value;
                    RaisePropertyChanged("MinTempId");
                }
            }
        }

        public int MaxTemp
        {
            get => Bms.MaxTemp;
            set
            {
                if (Bms.MaxTemp != value)
                {
                    Bms.MaxTemp = value;
                    RaisePropertyChanged("MaxTemp");
                }
            }
        }

        public int MaxTempId
        {
            get => Bms.MaxTempId;
            set
            {
                if (Bms.MaxTempId != value)
                {
                    Bms.MaxTempId = value;
                    RaisePropertyChanged("MaxTempId");
                }
            }
        }

        public uint Status
        {
            get => Bms.Status;
            set
            {
                if (Bms.Status != value)
                {
                    Bms.Status = value;
                    RaisePropertyChanged("Status");
                }
            }
        }

        public string Time
        {
            get => Bms.Time;
            set
            {
                if (Bms.Time != value)
                {
                    Bms.Time = value;
                    RaisePropertyChanged("Time");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void Instance_DataChange(object sender, EntityEventArgs e)
        {

            Bms = e.Data as Bms;
            if (Bms == null) return;
            Application.Current.Dispatcher.Invoke(delegate // <--- HERE
            {
                _bmSs.Add(Bms);
                if (_bmSs.Count > 1000) _bmSs.RemoveAt(0);
            });
        }


        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}