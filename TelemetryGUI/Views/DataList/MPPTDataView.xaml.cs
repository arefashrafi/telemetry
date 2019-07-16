using System.Windows;
using System.Windows.Controls;
using TelemetryGUI.ViewModel.DataList;

namespace TelemetryGUI.Views
{
    /// <summary>
    ///     Interaction logic for RealTimeLog.xaml
    /// </summary>
    public partial class MPPTDataView : UserControl
    {
        private readonly MPPTViewModel mpptViewModel = new MPPTViewModel();

        public MPPTDataView()
        {
            InitializeComponent();
            DataContext = mpptViewModel;
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string) runButton.Content == "RUN")
                runButton.Content = "STOP";
            else
                runButton.Content = "RUN";
        }

        private void MPPTDataView_OnLoaded(object sender, RoutedEventArgs e)
        {
            //mpptViewModel.AddEventManager();
        }

        private void MPPTDataView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            //mpptViewModel.RemoveEventManager();
        }

        private void DataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.Items.Count > 0)
                DataGrid.ScrollIntoView(DataGrid.Items[DataGrid.Items.Count - 1]);
        }
    }
}