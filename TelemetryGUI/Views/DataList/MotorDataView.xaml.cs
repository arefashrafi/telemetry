using System.Windows;
using System.Windows.Controls;
using TelemetryGUI.ViewModel.DataList;

namespace TelemetryGUI.Views.DataList
{
    /// <summary>
    ///     Interaction logic for RealTimeLog.xaml
    /// </summary>
    public partial class MotorDataView : UserControl
    {
        private readonly MotorViewModel _motorViewModel = new MotorViewModel();

        public MotorDataView()
        {
            InitializeComponent();
            DataContext = _motorViewModel;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.Items.Count > 0) DataGrid.ScrollIntoView(DataGrid.Items[DataGrid.Items.Count - 1]);
        }

        private void MotorDataView_OnLoaded(object sender, RoutedEventArgs e)
        {
            _motorViewModel.AddEventManager();
        }

        private void MotorDataView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _motorViewModel.RemoveEventManager();
        }
    }
}