using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using SciChart.Charting.Model.ChartSeries;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.ViewportManagers;
using SciChart.Charting.Visuals.Annotations;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Core.Extensions;
using SciChart.Examples.ExternalDependencies.Common;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;

namespace TelemetryGUI.ViewModel
{
    public class AltitudeDataSetViewModel : BaseViewModel
    {
        private VerticalLineAnnotation _verticalLineAnnotationCarPosition;
        private AnnotationCollection _verticalLineAnnotationCollection = new AnnotationCollection();

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

            
            WeakEventManager<EventSource, EntityEventArgs>.AddHandler(null, nameof(EventSource.Event), OnTick);


            VerticalLinesRoutes();
            
            using (TelemetryContext context= new TelemetryContext())
            {
                List<Routenote> routenotes = context.Routenotes.ToList();
                List<Bms> bmses = context.BatteryManagementSystems.ToList();
                XyDataSeries<double, double> dataSeriesRoutes = new XyDataSeries<double, double>();
                XyDataSeries<DateTime, double> dataSeriesEnergy = new XyDataSeries<DateTime, double>();
                foreach (var item in routenotes)
                {
                    dataSeriesRoutes.Append((double)item.DIST,(double)item.ALT);
                }
                foreach (Bms item in bmses)
                {
                    DateTime dateTime = DateTime.ParseExact(item.Time, "yyyy-MM-dd HH:mm:ss.fff",
                                                       CultureInfo.InvariantCulture);
                    double energy = item.Current * item.Volt;
                    dataSeriesEnergy.Append(dateTime,energy);
                }
                RenderableSeries = new ObservableCollection<IRenderableSeries>
                {
                    new FastLineRenderableSeries
                    {
                       DataSeries = dataSeriesRoutes,
                       Name = "Route",
                       Stroke = Colors.Coral,
                       XAxisId = "Numeric"
                    },
                    new FastLineRenderableSeries
                    {
                        DataSeries = dataSeriesEnergy,
                        Name = "Energy",
                        Stroke = Colors.Blue,
                        XAxisId = "DateTime"
                    }
                };
            }
        }

        private void OnTick(object sender, EntityEventArgs e)
        {
            Gps gps = e.Data as Gps;
            if (gps == null || gps.DeviceId!=0) return;
            _verticalLineAnnotationCarPosition.X1 = gps.TDIST;
        }


        // Databound to via SciChartSurface.DataSet in the view
        public ObservableCollection<IRenderableSeries> RenderableSeries { get; set; }


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
            _verticalLineAnnotationCollection.Add(_verticalLineAnnotationCarPosition);
        }
    }
}