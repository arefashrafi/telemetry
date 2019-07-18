using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;

namespace TelemetryGUI.ViewModel.DataList
{
    public class MotorViewModel : INotifyPropertyChanged
    {
        private Motor _motor;
        private ObservableCollection<Motor> _motors;

        public MotorViewModel()
        {
            _motors = new ObservableCollection<Motor>();
            WeakEventManager<EventSource, EntityEventArgs>.AddHandler(null, nameof(EventSource.EventMotor),
                Instance_DataChange);
        }

        public Motor Motor
        {
            get => _motor;
            set
            {
                _motor = value;
                RaisePropertyChanged("Motor");
            }
        }

        public ObservableCollection<Motor> Motors
        {
            get => _motors;
            set
            {
                _motors = value;
                RaisePropertyChanged("Motors");
            }
        }

        public int MotorRPM
        {
            get => Motor.MotorRPM;
            set
            {
                if (Motor.MotorRPM != value)
                {
                    Motor.MotorRPM = value;
                    RaisePropertyChanged("MotorRPM");
                }
            }
        }

        public int Id
        {
            get => Motor.Id;
            set
            {
                if (Motor.Id != value)
                {
                    Motor.Id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public int BatteryCurrent
        {
            get => Motor.BatteryCurrent;
            set
            {
                if (Motor.BatteryCurrent != value)
                {
                    Motor.BatteryCurrent = value;
                    RaisePropertyChanged("BatteryCurrent");
                }
            }
        }

        public int BatteryVoltage
        {
            get => Motor.BatteryVoltage;
            set
            {
                if (Motor.BatteryVoltage != value)
                {
                    Motor.BatteryVoltage = value;
                    RaisePropertyChanged("BatteryVoltage");
                }
            }
        }

        public int CurrentDirection
        {
            get => Motor.CurrentDirection;
            set
            {
                if (Motor.CurrentDirection != value)
                {
                    Motor.CurrentDirection = value;
                    RaisePropertyChanged("CurrentDirection");
                }
            }
        }

        public int FailModeInfo
        {
            get => Motor.FailModeInfo;
            set
            {
                if (Motor.FailModeInfo != value)
                {
                    Motor.FailModeInfo = value;
                    RaisePropertyChanged("FailModeInfo");
                }
            }
        }

        public int FailModeInfo1
        {
            get => Motor.FailModeInfo1;
            set
            {
                if (Motor.FailModeInfo1 != value)
                {
                    Motor.FailModeInfo1 = value;
                    RaisePropertyChanged("FailModeInfo1");
                }
            }
        }

        public int FailModeInfo2
        {
            get => Motor.FailModeInfo2;
            set
            {
                if (Motor.FailModeInfo2 != value)
                {
                    Motor.FailModeInfo2 = value;
                    RaisePropertyChanged("FailModeInfo2");
                }
            }
        }

        public int MotorCurrent
        {
            get => Motor.MotorCurrent;
            set
            {
                if (Motor.MotorCurrent != value)
                {
                    Motor.MotorCurrent = value;
                    RaisePropertyChanged("MotorCurrent");
                }
            }
        }

        public int MotorDriveMode
        {
            get => Motor.MotorDriveMode;
            set
            {
                if (Motor.MotorDriveMode != value)
                {
                    Motor.MotorDriveMode = value;
                    RaisePropertyChanged("MotorDriveMode");
                }
            }
        }

        public int OutputDuty
        {
            get => Motor.OutputDuty;
            set
            {
                if (Motor.OutputDuty != value)
                {
                    Motor.OutputDuty = value;
                    RaisePropertyChanged("OutputDuty");
                }
            }
        }

        public int OutputDutyType
        {
            get => Motor.OutputDutyType;
            set
            {
                if (Motor.OutputDutyType != value)
                {
                    Motor.OutputDutyType = value;
                    RaisePropertyChanged("OutputDutyType");
                }
            }
        }

        public int PresentCorePos
        {
            get => Motor.PresentCorePos;
            set
            {
                if (Motor.PresentCorePos != value)
                {
                    Motor.PresentCorePos = value;
                    RaisePropertyChanged("PresentCorePos");
                }
            }
        }

        public int TempControl
        {
            get => Motor.TempControl;
            set
            {
                if (Motor.TempControl != value)
                {
                    Motor.TempControl = value;
                    RaisePropertyChanged("TempControl");
                }
            }
        }

        public int TempMotor
        {
            get => Motor.TempMotor;
            set
            {
                if (Motor.TempMotor != value)
                {
                    Motor.TempMotor = value;
                    RaisePropertyChanged("TempMotor");
                }
            }
        }

        public string Time
        {
            get => Motor.Time;
            set
            {
                if (Motor.Time != value)
                {
                    Motor.Time = value;
                    RaisePropertyChanged("Time");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void Instance_DataChange(object sender, EntityEventArgs e)
        {
            _motor = e.Data as Motor;
            if (_motor == null) return;
            Application.Current.Dispatcher.Invoke(delegate // <--- HERE
            {
                _motors.Add(_motor);
                if (_motors.Count > 1000) _motors.RemoveAt(0);
            });
        }


        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}