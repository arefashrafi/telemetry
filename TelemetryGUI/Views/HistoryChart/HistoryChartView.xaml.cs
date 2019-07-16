using System;
using System.Windows.Controls;
using TelemetryDependencies.Models;
using TelemetryGUI.ViewModel;
using TelemetryGUI.ViewModel.HistoryChart;

namespace TelemetryGUI.Views
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
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox) sender;
            switch (comboBox.Name)
            {
                case "ParameterComboBoxBms" when comboBox.Text == "Select":
                    return;
                case "ParameterComboBoxBms":
                    _historyChartViewModel.HistoryChartLoadData(typeof(Bms),
                        ParameterComboBoxBms.SelectedItem.ToString());
                    break;
                case "ParameterComboBoxMotor" when comboBox.Text == "Select":
                    return;
                case "ParameterComboBoxMotor":
                    _historyChartViewModel.HistoryChartLoadData(typeof(Motor),
                        ParameterComboBoxMotor.SelectedItem.ToString());
                    break;
            }
        }

        private void TextBoxBase_OnSelectionChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox) sender;
            double number;
            if (!double.TryParse(textBox.Text, out number)) return;
            var dateTimeDiff = DateTime.Now.AddHours(number * -1); //-1 because we need it to be negative.
            _historyChartViewModel.TimeSpan = dateTimeDiff;
        }
    }
}