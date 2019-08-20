using System.Windows;
using System.Windows.Controls;
using TelemetryGUI.Model.Math;
using TelemetryGUI.ViewModel.EnergyEstimation;

namespace TelemetryGUI.Views.Strategy
{
    /// <summary>
    ///     Interaction logic for EnergyEstimationChart.xaml
    /// </summary>
    public partial class EnergyEstimationChartView : UserControl
    {
        private TempSpa _tempSpa;

        public EnergyEstimationChartView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            EnergyEstimationChartViewModel estimationChartViewModel = (EnergyEstimationChartViewModel) DataContext;
            EnergyEstimationConfig energyEstimationConfig = new EnergyEstimationConfig(estimationChartViewModel.Spa);
            energyEstimationConfig.ShowDialog();
            _tempSpa = energyEstimationConfig.TempSpa;
            estimationChartViewModel.Spa = new SPACalculator.SPAData
            {
                Year = _tempSpa.Year,
                Month = _tempSpa.Month,
                Day = _tempSpa.Day,
                Hour = _tempSpa.Hour,
                Minute = _tempSpa.Minute,
                Second = _tempSpa.Second,
                DeltaUt1 = _tempSpa.DeltaUt1,
                DeltaT = _tempSpa.DeltaT,
                Timezone = _tempSpa.Timezone,
                Longitude = _tempSpa.Longitude,
                Latitude = _tempSpa.Latitude,
                Elevation = _tempSpa.Elevation,
                Pressure = _tempSpa.Pressure,
                Temperature = _tempSpa.Pressure,
                Slope = _tempSpa.Slope,
                AzmRotation = _tempSpa.AzmRotation,
                AtmosRefract = _tempSpa.AtmosRefract,
                Function = SPACalculator.CalculationMode.SPA_ALL
            };
        }
    }
}