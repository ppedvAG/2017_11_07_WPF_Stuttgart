using System;
using System.Windows.Input;

namespace HalloMVVM.ViewModels
{
    internal class Command : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public Command(Action execute) => this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        public Command(Action execute, Func<bool> canExecute) : this(execute) => this.canExecute = canExecute;

        public bool CanExecute(object parameter) => canExecute?.Invoke() ?? true;
        public void Execute(object parameter) => execute();
    }
}
