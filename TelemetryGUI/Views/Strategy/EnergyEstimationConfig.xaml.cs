using System.ComponentModel;
using System.Windows;
using TelemetryGUI.Model.Math;

namespace TelemetryGUI.Views.Strategy
{
    public partial class EnergyEstimationConfig : Window
    {
        private TempSpa _tempSpa;

        public EnergyEstimationConfig(SPACalculator.SPAData spaData)
        {
            _tempSpa = new TempSpa
            {
                Year = spaData.Year,
                Month = spaData.Month,
                Day = spaData.Day,
                Hour = spaData.Hour,
                Minute = spaData.Minute,
                Second = spaData.Second,
                DeltaUt1 = spaData.DeltaUt1,
                DeltaT = spaData.DeltaT,
                Timezone = spaData.Timezone,
                Longitude = spaData.Longitude,
                Latitude = spaData.Latitude,
                Elevation = spaData.Elevation,
                Pressure = spaData.Pressure,
                Temperature = spaData.Temperature,
                Slope = spaData.Slope,
                AzmRotation = spaData.AzmRotation,
                AtmosRefract = spaData.AtmosRefract
            };
            InitializeComponent();
            DataContext = _tempSpa;
        }

        public TempSpa TempSpa
        {
            get => _tempSpa;
            set
            {
                if (!value.Equals(_tempSpa))
                {
                    _tempSpa = value;
                    OnPropertyChanged("TempSpa");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}