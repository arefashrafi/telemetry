using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.ViewportManagers;
using SciChart.Charting.Visuals.Annotations;
using SciChart.Core.Extensions;
using SciChart.Examples.ExternalDependencies.Common;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;

namespace TelemetryGUI.ViewModel
{
    public class AltitudeDataSetViewModel : BaseViewModel
    {
        private IDataSeries<double, double> _dataSeries0;
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
            // Create a DataSeriesSet
            _dataSeries0 = new XyDataSeries<double, double> {SeriesName = "Altitude"};

            VerticalLinesRoutes();
            using (var context= new TelemetryContext())
            {
                var data = context.Routenotes.ToList();
                foreach (var item in data)
                {
                    _dataSeries0.Append((double)item.DIST,(double)item.ALT);
                }
            }
        }

        private void OnTick(object sender, EntityEventArgs e)
        {
            Gps gps = e.Data as Gps;
            if (gps == null || gps.DeviceId!=0) return;
            _verticalLineAnnotationCarPosition.X1 = gps.TDIST;
        }


        // Databound to via SciChartSurface.DataSet in the view
        public IDataSeries<double, double> ChartData
        {
            get => _dataSeries0;
            set
            {
                _dataSeries0 = value;
                OnPropertyChanged("ChartData");
            }
        }

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