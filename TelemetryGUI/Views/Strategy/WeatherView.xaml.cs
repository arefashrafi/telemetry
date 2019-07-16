using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TelemetryGUI.Views
{
    /// <summary>
    ///     Interaction logic for WeatherView.xaml
    /// </summary>
    public partial class WeatherView : UserControl
    {
        public WeatherView()
        {
            InitializeComponent();
            wb.Source = new Uri("https://www.google.com");
            WeatherAPIString.Text = "TeST";
        }

        private void visit(object sender, RoutedEventArgs e)
        {
            try
            {
                wb.Navigate(new Uri(tb.Text));
            }
            catch (UriFormatException)
            {
                tb.Text = "( This URL is not valid )";
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            if (wb.CanGoBack)
                wb.GoBack();
        }

        private void forward(object sender, RoutedEventArgs e)
        {
            if (wb.CanGoForward)
                wb.GoForward();
        }

        private void wb_Navigated(object sender, NavigationEventArgs e)
        {
            cb.Items.Add(wb.Source);
            tb.Text = "" + wb.Source;
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wb.Navigate(cb.SelectedItem.ToString());
        }
    }
}