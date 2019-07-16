using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using SciChart.Charting.Model.ChartSeries;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Examples.ExternalDependencies.Common;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;

namespace TelemetryGUI.ViewModel.HistoryChart
{
    public class HistoryChartViewModel : BaseViewModel
    {
        private ObservableCollection<IRenderableSeriesViewModel> _renderableSeriesViewModels;
        private DateRange _xVisibleRange;
        private bool firstReadMotor=true;
        private bool firstReadBms=true;


        public HistoryChartViewModel()
        {
            _renderableSeriesViewModels = new ObservableCollection<IRenderableSeriesViewModel>();
            ParameterCollectionBms = new ObservableCollection<string>();
            ParameterCollectionMotor = new ObservableCollection<string>();
            DeleteCommand = new RelayCommand(DeleteSeriesClick);
            foreach (var parameter in new Bms().GetType().GetProperties())
                ParameterCollectionBms.Add(parameter.Name);
            foreach (var parameter in new Motor().GetType().GetProperties())
                ParameterCollectionMotor.Add(parameter.Name);
        }

        public ObservableCollection<string> ParameterCollectionMotor { get; set; }
        public ObservableCollection<string> ParameterCollectionBms { get; set; }
        public DateTime TimeSpan { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public ObservableCollection<IRenderableSeriesViewModel> RenderableSeriesViewModels
        {
            get => _renderableSeriesViewModels;
            set
            {
                _renderableSeriesViewModels = value;
                OnPropertyChanged("RenderableSeriesViewModels");
            }
        }


        public DateRange XVisibleRange
        {
            get => _xVisibleRange;
            set
            {
                if (Equals(_xVisibleRange, value))
                    return;
                _xVisibleRange = value;
                OnPropertyChanged("XVisibleRange");
            }
        }

        public async Task HistoryChartLoadData(Type type, string param)
        {
            var r = new Random();
            XyDataSeries<DateTime, double> xyDataSeries = new XyDataSeries<DateTime, double>();

            if (type == typeof(Motor))
            {
                using var context = new TelemetryContext();
                IQueryable<Motor> filteredMotors = context.Motors.Where(t =>
                    DateTime.ParseExact(t.Time, "yyyy-MM-dd HH:mm:ss.fff",
                        CultureInfo.InvariantCulture) > TimeSpan);
                foreach (var motor in filteredMotors)
                {
                    
                    var dateTime = DateTime.ParseExact(motor.Time, "yyyy-MM-dd HH:mm:ss.fff",
                        CultureInfo.InvariantCulture);
                    
                    if (dateTime > xyDataSeries.XValues.LastOrDefault().AddMinutes(10) || firstReadMotor)
                    {
                        xyDataSeries.Append(dateTime,double.NaN);
                        firstReadMotor = false;
                    }
                    else
                    {
                        double paramValue = Convert.ToDouble(motor.GetType().GetProperty(param)?.GetValue(motor, null));
                        xyDataSeries.XValues.Add(dateTime);
                        xyDataSeries.YValues.Add(paramValue);
                    }

                }
            }

            if (type == typeof(Bms))
            {
                using var context = new TelemetryContext();
                IQueryable<Bms> filteredBms = context.BatteryManagementSystems.Where(t =>
                    DateTime.ParseExact(t.Time, "yyyy-MM-dd HH:mm:ss.fff",
                        CultureInfo.InvariantCulture) > TimeSpan);
                foreach (var bms in filteredBms)
                {
                    var dateTime = DateTime.ParseExact(bms.Time, "yyyy-MM-dd HH:mm:ss.fff",
                        CultureInfo.InvariantCulture);
                    if (dateTime > xyDataSeries.XValues.LastOrDefault().AddMinutes(10) || firstReadBms)
                    {
                        xyDataSeries.Append(dateTime,double.NaN);
                        firstReadMotor = false;
                    }
                    else
                    {
                        double paramValue = Convert.ToDouble(bms.GetType().GetProperty(param)?.GetValue(bms, null));
                        xyDataSeries.XValues.Add(dateTime);
                        xyDataSeries.YValues.Add(paramValue);
                    }
                }
            }

            var color = Color.FromRgb(Convert.ToByte(r.Next(256)), Convert.ToByte(r.Next(256)),
                Convert.ToByte(r.Next(256)));
            _renderableSeriesViewModels.Add(new LineRenderableSeriesViewModel
            {
                DrawNaNAs = LineDrawMode.Gaps,
                DataSeries = xyDataSeries,
                Stroke = color
            });
        }

        private void DeleteSeriesClick()
        {
            var rSeries = RenderableSeriesViewModels.LastOrDefault();
            if (rSeries?.DataSeries == null)
                return;

            RenderableSeriesViewModels.Remove(rSeries);
        }
    }
}