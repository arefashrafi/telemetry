using System.Reflection;
using System.Windows.Controls;
using TelemetryDependencies.Models;

namespace TelemetryGUI.Views.Live
{
    public partial class LiveView : UserControl
    {
        public LiveView()
        {
            InitializeComponent();
            foreach (PropertyInfo item in new Bms().GetType().GetProperties())
            {
                DataBmsSelectionComboBox.Items.Add(item.Name);
            }

            foreach (PropertyInfo item in new Motor().GetType().GetProperties())
            {
                DataMotorSelectionComboBox.Items.Add(item.Name);
            }

            foreach (PropertyInfo item in new MPPT().GetType().GetProperties())
            {
                DataMpptSelectionComboBox.Items.Add(item.Name);
            }
        }
    }
}