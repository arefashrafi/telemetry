// *************************************************************************************
// SCICHART® Copyright SciChart Ltd. 2011-2018. All rights reserved.
//  
// Web: http://www.scichart.com
//   Support: support@scichart.com
//   Sales:   sales@scichart.com
// 
// SeriesBindingViewModel.cs is part of the SCICHART® Examples. Permission is hereby granted
// to modify, create derivative works, distribute and publish any part of this source
// code whether for commercial, private or personal use. 
// 
// The SCICHART® examples are distributed in the hope that they will be useful, but
// without any warranty. It is provided "AS IS" without warranty of any kind, either
// expressed or implied. 
// *************************************************************************************

using System;
using SciChart.Charting.Model.DataSeries;
using SciChart.Examples.ExternalDependencies.Common;
using TelemetryGUI.Util;

namespace TelemetryGUI.ViewModel.EnergyEstimation
{
    public class EnergyEstimationChartViewModel : BaseViewModel
    {
        private DateTime _dateTime;
        private SpaCalculator.SPAData _spa;

        public EnergyEstimationChartViewModel()
        {
            UpdateCommand = new RelayCommand(UpdateSeriesClick);
            ChartSeries = new XyDataSeries<DateTime, double>();
            _spa.Year = 2003;
            _spa.Month = 10;
            _spa.Day = 17;
            _spa.Hour = 12;
            _spa.Minute = 30;
            _spa.Second = 30;
            _spa.Timezone = -7.0;
            _spa.DeltaUt1 = 0;
            _spa.DeltaT = 67;
            _spa.Longitude = -105.1786;
            _spa.Latitude = 39.742476;
            _spa.Elevation = 1830.14;
            _spa.Pressure = 820;
            _spa.Temperature = 11;
            _spa.Slope = 30;
            _spa.AzmRotation = -10;
            _spa.AtmosRefract = 0.5667;
            _spa.Function = SpaCalculator.CalculationMode.SPA_ALL;
            _dateTime = new DateTime(_spa.Day, _spa.Month, _spa.Day, _spa.Hour, _spa.Minute,
                Convert.ToInt32(_spa.Second));
        }

        public RelayCommand UpdateCommand { get; set; }

        public IDataSeries<DateTime, double> ChartSeries { get; set; }

        public SpaCalculator.SPAData Spa
        {
            get => _spa;
            set => _spa = value;
        }

        private void UpdateSeriesClick()
        {
            int results = SpaCalculator.SPACalculate(ref _spa);
            if (results != 0) return;
            for (int i = 0; i < 10; i++)
            {
                _dateTime = _dateTime.AddHours(1);
                if (_spa.Hour > 23)
                {
                    _spa.Day++;
                    _spa.Hour = 0;
                }

                _spa.Hour++;
                SpaCalculator.SPACalculate(ref _spa);
                ChartSeries.Append(_dateTime, _spa.Azimuth);
            }
        }
    }
}