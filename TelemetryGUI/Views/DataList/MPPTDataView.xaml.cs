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

        public MPPTDataView()
        {
            InitializeComponent();

        }



        private void DataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.Items.Count > 0)
                DataGrid.ScrollIntoView(DataGrid.Items[DataGrid.Items.Count - 1]);
        }
    }
}