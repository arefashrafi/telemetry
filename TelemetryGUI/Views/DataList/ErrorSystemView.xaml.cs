using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TelemetryGUI.ViewModel.DataList;

namespace TelemetryGUI.Views.DataList
{
    /// <summary>
    ///     Interaction logic for RealTimeLog.xaml
    /// </summary>
    public partial class ErrorSystemView : UserControl
    {
        public ErrorSystemView()
        {

            InitializeComponent();

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.Items.Count > 0) DataGrid.ScrollIntoView(DataGrid.Items[DataGrid.Items.Count - 1]);
        }
    }
}