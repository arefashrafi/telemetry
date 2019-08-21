using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Telemetry.App;
using TelemetryDependencies.Models;

namespace TelemetryGUI
{
    /// <summary>
    ///     Interaction logic for MessageView.xaml
    /// </summary>
    public partial class MessageView : Window
    {
        public MessageView()
        {
            InitializeComponent();
            IdList = new List<int>();
            IdList.AddRange(Enumerable.Range(0, 10));
            IdComboBox.ItemsSource = IdList;
        }

        public List<int> IdList { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (TelemetryContext context = new TelemetryContext())
                {
                    context.Messages.Add(new Message
                    {
                        Text = MessageTextBox.Text,
                        Prefix = MessageTextBoxPrefix.Text,
                        Length = MessageTextBox.Text.Length,
                        MessageId = (int) IdComboBox.SelectedValue,
                        DateTime = DateTime.Now
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}