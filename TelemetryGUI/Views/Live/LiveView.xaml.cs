using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using TelemetryDependencies.Models;
using TelemetryGUI.ViewModel.Live;

namespace TelemetryGUI.Views.Live
{
    public partial class LiveView : UserControl
    {
        private LiveViewModel _liveViewModel;
        public LiveView()
        {
            InitializeComponent();
            
            foreach (var item in new Bms().GetType().GetProperties())
            {
                DataBmsSelectionComboBox.Items.Add(item.Name);
            }
            foreach (var item in new Motor().GetType().GetProperties())
            {
                DataMotorSelectionComboBox.Items.Add(item.Name);
            }
            foreach (var item in new MPPT().GetType().GetProperties())
            {
                DataMpptSelectionComboBox.Items.Add(item.Name);
            }
        }
    }
}