using System;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Model.Filters;

namespace TelemetryGUI.Util
{
    /// <summary>
    ///     To create a custom filter, inherit FilterBase and override FilterALl. For best performance, you can also override
    ///     FilterOnAppend
    /// </summary>
    public class CustomDataFilter : FilterBase
    {
        private readonly XyDataSeries<DateTime, double> _filteredDataSeries = new XyDataSeries<DateTime, double>();
        private readonly XyDataSeries<DateTime, double> _originalDataSeries;

        public CustomDataFilter(XyDataSeries<DateTime, double> originalDataSeries) : base(originalDataSeries)
        {
            _originalDataSeries = originalDataSeries;

            // Store a reference in the base class to the FilteredDataSeries
            FilteredDataSeries = _filteredDataSeries;

            // Update the filter
            FilterAll();
        }

        public sealed override void FilterAll()
        {
            // When FilterAll is called, recreate the FilteredDataSeries and apply the filtering. 
            _filteredDataSeries.Clear();
            _filteredDataSeries.Append(_originalDataSeries.XValues[0], _originalDataSeries.YValues[0]);

            const double beta = 0.2;

            // Implementing a simple low pass filter https://kiritchatterjee.wordpress.com/2014/11/10/a-simple-digital-low-pass-filter-in-c/
            for (int i = 1; i < _originalDataSeries.Count; i++)
            {
                DateTime xValue = _originalDataSeries.XValues[i];
                double yValue = beta * _originalDataSeries.YValues[i] + (1 - beta) * _filteredDataSeries.YValues[i - 1];
                _filteredDataSeries.Append(xValue, yValue);
            }
        }
    }
}