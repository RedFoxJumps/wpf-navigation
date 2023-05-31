using System;
using System.Windows.Input;

namespace Navigation.WPF
{
    internal class RelayCommand : ICommand
    {
        private readonly Action _act;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action act)
        {
            _act = act;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _act.Invoke();
        }
    }
}
