using System.Windows.Controls;
using SciChart.Drawing.DirectX.Context.D3D11;
using TelemetryDependencies.Models;

namespace TelemetryGUI.Views.Live
{
    public partial class LiveView : UserControl
    {
        public LiveView()
        {
            InitializeComponent();
            foreach (var item in new Bms().GetType().GetProperties()) DataBmsSelectionComboBox.Items.Add(item.Name);
            foreach (var item in new Motor().GetType().GetProperties()) DataMotorSelectionComboBox.Items.Add(item.Name);
            foreach (var item in new MPPT().GetType().GetProperties()) DataMpptSelectionComboBox.Items.Add(item.Name);
        }
    }
}