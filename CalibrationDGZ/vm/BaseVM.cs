using modus.Common.UtilBox;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
namespace modus.ViewModel
{
    public class BaseVM : TimerHdle, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propretyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propretyName));
        }
        public class RelayCommand : ICommand
        {
            private readonly Action<object?> _execute;
            private readonly Predicate<object?>? _canExecute;
            public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }
            public bool CanExecute(object? parameter)
            {
                return _canExecute == null || _canExecute(parameter);
            }
            public void Execute(object? parameter)
            {
                _execute(parameter);
            }
            public event EventHandler? CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }
        }
        public class AsyncRelayCommand : ICommand
        {
            private readonly Func<object?, Task> _execute;
            private readonly Predicate<object?>? _canExecute;
            public AsyncRelayCommand(Func<object?, Task> execute, Predicate<object?>? canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }
            public bool CanExecute(object? parameter)
            {
                return _canExecute == null || _canExecute(parameter);
            }
            public async void Execute(object? parameter)
            {
                await _execute(parameter);
            }
            public event EventHandler? CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }
        }
    }
}
