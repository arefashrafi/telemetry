﻿using System;
using System.ComponentModel;
using System.Windows;
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
            var serviceBroker = new ServiceBroker();
            serviceBroker.Broker();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
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