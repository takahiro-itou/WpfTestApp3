
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfTestApp3.Commands;
using WpfTestApp3.Models;

namespace WpfTestApp3.ViewModels
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        private readonly CounterModel _model;
        private readonly SimpleCommand _incrementCommand;
        private readonly SimpleCommand _decrementCommand;

        public CounterViewModel()
        {
            _model = new CounterModel();
            _incrementCommand = new SimpleCommand(_ => ExecuteIncrement());
            _decrementCommand = new SimpleCommand(_ => ExecuteDecrement(), _ => _model.CanDecrement());
        }

        public int Count => _model.Value;

        public ICommand IncrementCommand => _incrementCommand;
        public ICommand DecrementCommand => _decrementCommand;

        public void ExecuteIncrement()
        {
            _model.Increment();
            OnPropertyChanged(nameof(Count));
        }
        public void ExecuteDecrement()
        {
            _model.Decrement();
            OnPropertyChanged(nameof(Count));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if ( propertyName == nameof(Count) ) {
                _decrementCommand.RaiseCanExecuteChanged();
            }
        }

    }
}
