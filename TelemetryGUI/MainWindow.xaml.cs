using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;

namespace TelemetryGUI
{
    /// <summary>
    ///     Interaction logic for RealTimeLog.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ServiceBroker serviceBroker = new ServiceBroker();
            serviceBroker.Broker();
            WeakEventManager<EventSource, EntityEventArgs>.AddHandler(null, nameof(EventSource.EventMessage), OnTick);
        }

        private static void OnTick(object sender, EntityEventArgs e)
        {
            if (!(e.Data is Message message)) return;

            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(() =>
                {
                    MessageBox.Show(Application.Current.MainWindow, message.Prefix + message.Text);
                }));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageView messageView = new MessageView();
            messageView.Show();
        }
    }
}