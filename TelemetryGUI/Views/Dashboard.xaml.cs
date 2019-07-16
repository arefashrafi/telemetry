using System.Windows.Controls;
using TelemetryGUI.ViewModel;

namespace TelemetryGUI.Views
{
    /// <summary>
    ///     Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        
        public Dashboard()
        {
            InitializeComponent();
            this.DataContext = new GPSViewModel();
        }

    }
}