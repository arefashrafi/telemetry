using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.ViewportManagers;
using SciChart.Charting.Visuals.Annotations;
using SciChart.Core.Extensions;
using SciChart.Examples.ExternalDependencies.Common;
using Telemetry.App;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;

namespace TelemetryGUI.ViewModel
{
    public class AltitudeDataSetViewModel : BaseViewModel
    {
        private XyDataSeries<DateTime, double> _energyDataSeries = new XyDataSeries<DateTime, double>();
        private XyDataSeries<double, double> _routeDataSeries = new XyDataSeries<double, double>();
        private VerticalLineAnnotation _verticalLineAnnotationCarPosition;
        private AnnotationCollection _verticalLineAnnotationCollection = new AnnotationCollection();
        private bool _firstRead = false;

        public AltitudeDataSetViewModel()
        {
            ViewportManager = new DefaultViewportManager();

            _verticalLineAnnotationCarPosition = new VerticalLineAnnotation
            {
                LabelValue = "Car",
                Stroke = new SolidColorBrush(Colors.BlueViolet),
                StrokeThickness = 2,
                IsEditable = false,
                ShowLabel = true
            };

            VerticalLinesRoutes();
            DataLoad();
            WeakEventManager<EventSource, EntityEventArgs>.AddHandler(null, nameof(EventSource.EventGps), OnTick);
        }

        public IDataSeries<DateTime, double> EnergyDataSeries { get; set; }
        public IDataSeries<double, double> RouteDataSeries { get; set; }
        public IViewportManager ViewportManager { get; set; }

        public AnnotationCollection VerticalLineAnnotationCollection
        {
            get => _verticalLineAnnotationCollection;
            set
            {
                _verticalLineAnnotationCollection = value;
                OnPropertyChanged("VerticalLineAnnotationCollection");
            }
        }

        public VerticalLineAnnotation VerticalLineAnnotationCarPosition
        {
            get => _verticalLineAnnotationCarPosition;
            set
            {
                _verticalLineAnnotationCarPosition = value;
                OnPropertyChanged("VerticalLineAnnotationCarPosition");
            }
        }

        private async void DataLoad()
        {

            List<Routenote> routenotes = new List<Routenote>();
            List<Bms> bms = new List<Bms>();
            try
            {
                using (TelemetryContext context = new TelemetryContext())
                {
                    routenotes = await context.Routenotes.ToListAsync();
                    bms = await context.BatteryManagementSystems.ToListAsync();
                }

            }
            catch
            {
                if (routenotes.IsNullOrEmptyList())
                {
                    MessageBox.Show("No routes available");
                }
            }

            _routeDataSeries = new XyDataSeries<double, double>();
            _energyDataSeries = new XyDataSeries<DateTime, double> {AcceptsUnsortedData = true};
            
            foreach (Routenote item in routenotes) _routeDataSeries.Append((double) item.DIST, (double) item.ALT);
            try
            {
                foreach (Bms item in bms)
                {

                    DateTime dateTime = DateTime.ParseExact(item.Time, "yyyy-MM-dd HH:mm:ss.fff",
                                                            CultureInfo.InvariantCulture);
                    if (dateTime > _energyDataSeries.XValues.LastOrDefault().AddSeconds(20) || !_firstRead)
                    {
                        _energyDataSeries.Append(dateTime, double.NaN);
                        _firstRead = true;
                    }
                    else
                    {
                        double energy = item.Current * item.Volt;

                        _energyDataSeries.Append(dateTime, energy);
                    }
                }
                EnergyDataSeries = _energyDataSeries;
                RouteDataSeries = _routeDataSeries;
            }
            catch
            {
                MessageBox.Show("Could not parse datetime");
            }
        }

        private void OnTick(object sender, EntityEventArgs e)
        {
            if (!(e.Data is Gps gps) || gps.DeviceId != 0) return;
            Application.Current.Dispatcher.Invoke(() =>
            {
                _verticalLineAnnotationCollection.Remove(_verticalLineAnnotationCarPosition);
                _verticalLineAnnotationCarPosition.X1 = gps.TDIST;
                _verticalLineAnnotationCollection.Add(_verticalLineAnnotationCarPosition);
            });


        }

        public void VerticalLinesRoutes()
        {
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "Darwin",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 0,
                IsEditable = false,
                ShowLabel = true
            });
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "Katherine",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 322,
                IsEditable = false,
                ShowLabel = true
            });
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "Daly Waters",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 588,
                IsEditable = false,
                ShowLabel = true
            });
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "Dunmarra",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 633,
                IsEditable = false,
                ShowLabel = true
            });
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "Tennant Creek",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 988,
                IsEditable = false,
                ShowLabel = true
            });
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "Barrow Creek",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 1211,
                IsEditable = false,
                ShowLabel = true
            });
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "Alice Springs",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 1496,
                IsEditable = false,
                ShowLabel = true
            });
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "Kulgera",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 1766,
                IsEditable = false,
                ShowLabel = true
            });
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "NT / SA Border",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 1786,
                IsEditable = false,
                ShowLabel = true
            });
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "Coober Pedy",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 2178,
                IsEditable = false,
                ShowLabel = true
            });
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "Glendambo",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 2432,
                IsEditable = false,
                ShowLabel = true
            });
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "Port Augusta",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 2719,
                IsEditable = false,
                ShowLabel = true
            });
            _verticalLineAnnotationCollection.Add(new VerticalLineAnnotation
            {
                LabelValue = "Adelaide",
                Stroke = new SolidColorBrush(Colors.DarkOliveGreen),
                StrokeThickness = 2,
                X1 = 3022,
                IsEditable = false,
                ShowLabel = true
            });
        }
    }
}