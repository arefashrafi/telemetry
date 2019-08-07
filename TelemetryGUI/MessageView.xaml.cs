using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telemetry.App;
using TelemetryDependencies.Models;

namespace TelemetryGUI
{
    /// <summary>
    /// Interaction logic for MessageView.xaml
    /// </summary>
    public partial class MessageView : Window
    {
        public List<int> IdList { get; set; }
        private string messagePrefix = null;
        public MessageView()
        {
            InitializeComponent();
            IdList = new List<int>();
            IdList.AddRange(Enumerable.Range(0, 10));
            IdComboBox.ItemsSource = IdList;
            messagePrefix = ConfigurationManager.AppSettings["MessagePrefix"];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new TelemetryContext())
                {
                    context.Messages.Add(new Message
                    {
                        Text = MessageTextBox.Text,
                        Prefix = messagePrefix,
                        Length = MessageTextBox.Text.Count(),
                        MessageId = (int)IdComboBox.SelectedValue,
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
