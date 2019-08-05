using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Maps.MapControl.WPF;
using TelemetryGUI.ViewModel;

namespace TelemetryGUI.Views
{
    /// <summary>
    ///     Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class GpsView : UserControl
    {
        public GpsView()
        {
            InitializeComponent();
        }

        private void GpsMapView_OnTargetUpdated(object sender, DataTransferEventArgs e)
        {
        }
    }
}