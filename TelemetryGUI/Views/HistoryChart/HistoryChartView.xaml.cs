using System;
using System.Reflection;
using System.Windows.Controls;
using TelemetryDependencies.Models;
using TelemetryGUI.ViewModel.HistoryChart;

namespace TelemetryGUI.Views.HistoryChart
{
    /// <summary>
    ///     Interaction logic for HistoryChartView.xaml
    /// </summary>
    public partial class HistoryChartView : UserControl
    {
        private readonly HistoryChartViewModel _historyChartViewModel;

        public HistoryChartView()
        {
            InitializeComponent();
            _historyChartViewModel = (HistoryChartViewModel) DataContext;
            foreach (PropertyInfo parameter in new Bms().GetType().GetProperties())
            {
                ParameterComboBoxBms.Items.Add(parameter.Name);
            }

            foreach (PropertyInfo parameter in new Motor().GetType().GetProperties())
            {
                ParameterComboBoxMotor.Items.Add(parameter.Name);
            }
        }

        private void TextBoxBase_OnSelectionChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            if (!double.TryParse(textBox.Text, out double number)) return;
            DateTime dateTimeDiff = DateTime.Now.AddHours(number * -1); //-1 because we need it to be negative.
            _historyChartViewModel.TimeSpan = dateTimeDiff;
        }

        private void ParameterComboBoxBms_OnSelected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;
            if (comboBox.Name == "ParameterComboBoxBms")
                _historyChartViewModel.HistoryChartLoadData(typeof(Bms),
                    ParameterComboBoxBms.SelectedItem.ToString());
            else if (comboBox.Name == "ParameterComboBoxMotor")
                _historyChartViewModel.HistoryChartLoadData(typeof(Motor),
                    ParameterComboBoxMotor.SelectedItem.ToString());
        }
    }
}