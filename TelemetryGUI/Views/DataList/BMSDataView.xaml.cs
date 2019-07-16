using System.Windows;
using System.Windows.Controls;
using TelemetryGUI.ViewModel.DataList;

namespace TelemetryGUI.Views.DataList
{
    /// <summary>
    ///     Interaction logic for RealTimeLog.xaml
    /// </summary>
    public partial class BmsDataView : UserControl
    {
        private readonly BmsViewModel _bmsViewModel = new BmsViewModel();

        public BmsDataView()
        {
            InitializeComponent();
            DataGrid.DataContext = _bmsViewModel;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.Items.Count > 0) DataGrid.ScrollIntoView(DataGrid.Items[DataGrid.Items.Count - 1]);
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string) runButton.Content == "RUN")
                runButton.Content = "STOP";
            else
                runButton.Content = "RUN";
        }

        private void BmsDataView_OnLoaded(object sender, RoutedEventArgs e)
        {
            _bmsViewModel.AddEventManager();
        }

        private void BmsDataView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _bmsViewModel.RemoveEventManager();
        }
    }
}