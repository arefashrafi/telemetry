// *************************************************************************************
// SCICHART� Copyright SciChart Ltd. 2011-2018. All rights reserved.
//  
// Web: http://www.scichart.com
//   Support: support@scichart.com
//   Sales:   sales@scichart.com
// 
// EEGChannelViewModel.cs is part of the SCICHART� Examples. Permission is hereby granted
// to modify, create derivative works, distribute and publish any part of this source
// code whether for commercial, private or personal use. 
// 
// The SCICHART� examples are distributed in the hope that they will be useful, but
// without any warranty. It is provided "AS IS" without warranty of any kind, either
// expressed or implied. 
// *************************************************************************************

using System;
using System.Windows.Media;
using SciChart.Charting.Model.DataSeries;
using SciChart.Examples.ExternalDependencies.Common;

namespace TelemetryGUI.ViewModel.Live
{
    public class LiveChannelViewModel : BaseViewModel
    {
        private readonly int _size;
        private IXyDataSeries<DateTime, double> _channelDataSeries;
        private Color _color;

        public LiveChannelViewModel(int size, Color color)
        {
            _size = size;
            Stroke = color;

            // Add an empty First In First Out series. When the data reaches capacity (int size) then old samples
            // will be pushed out of the series and new appended to the end. This gives the appearance of 
            // a scrolling chart window
            ChannelDataSeries = new XyDataSeries<DateTime, double>
            {
                FifoCapacity = _size,
                AcceptsUnsortedData = true
            };
            // Pre-fill with NaN up to size. This stops the stretching effect when Fifo series are filled with AutoRange
            for (int i = 0; i < _size; i++)
                ChannelDataSeries.Append(DateTime.Now, double.NaN);
        }

        public string ChannelName { get; set; }

        public Color Stroke
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged("Stroke");
            }
        }

        public IXyDataSeries<DateTime, double> ChannelDataSeries
        {
            get => _channelDataSeries;
            set
            {
                _channelDataSeries = value;
                OnPropertyChanged("ChannelDataSeries");
            }
        }
        
        public void Reset()
        {
            _channelDataSeries.Clear();
        }
    }
}