using System;
using System.Windows.Input;

namespace TelemetryGUI.Util
{
    public class RelayCommand : ICommand
    {
        private readonly Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
        #pragma warning disable 67
        public event EventHandler CanExecuteChanged;
        #pragma warning restore 67
    }
}