using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TelemetryGUI.ViewModel.DataList;

namespace TelemetryGUI.Views
{
    /// <summary>
    ///     Interaction logic for RealTimeLog.xaml
    /// </summary>
    public partial class ErrorSystemView : UserControl
    {
        private readonly ErrorViewModel errorViewModel = new ErrorViewModel();
        private readonly DispatcherTimer timer;

        public ErrorSystemView()
        {
            timer = new DispatcherTimer();
            timer.Tick += dataExchangeCommand;
            timer.Interval = new TimeSpan(0, 0, 10);
            InitializeComponent();
            dataGrid.DataContext = errorViewModel;
            timer.Start();
        }

        private void dataExchangeCommand(object sender, EventArgs e)
        {
            errorViewModel.Update();
            if (dataGrid.Items.Count > 0) dataGrid.ScrollIntoView(dataGrid.Items[dataGrid.Items.Count - 1]);
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string) runButton.Content == "RUN")
            {
                runButton.Content = "STOP";
                timer.Start();
            }
            else
            {
                runButton.Content = "RUN";
                timer.Stop();
            }
        }
    }
}