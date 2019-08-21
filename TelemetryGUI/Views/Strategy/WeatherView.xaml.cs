using System.Windows.Controls;

namespace TelemetryGUI.Views.Strategy
{
    /// <summary>
    ///     Interaction logic for WeatherView.xaml
    /// </summary>
    public partial class WeatherView : UserControl
    {
        public WeatherView()
        {
            InitializeComponent();
            WeatherBrowser.Navigate("http://www.bom.gov.au/australia/meteye/");
        }
    }
}