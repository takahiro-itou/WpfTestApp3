
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using WpfTestApp3.Commands;
using WpfTestApp3.Models;
using WpfTestApp3.Services;

namespace  WpfTestApp3.ViewModels  {

public class CounterViewModel : INotifyPropertyChanged
{

private  readonly   CounterModel _model;
private  readonly   JsonCounterStorage _storage;
private  readonly   SimpleCommand _incrementCommand;
private  readonly   SimpleCommand _decrementCommand;

private   bool      _isRunning;


public CounterViewModel(CounterModel model, JsonCounterStorage storage)
{
    _model = model;
    _storage = storage;

    var initialValue = _storage.Load();
    _model.SetValue(initialValue);
    _model.ValueChanged += OnCountChanged;

    _incrementCommand = new SimpleCommand(
            _ => executeIncrement());
    _decrementCommand = new SimpleCommand(
            _ => executeDecrement(), _ => _model.CanDecrement());

    this._isRunning = false;
}

public int Count => _model.Value;

public ICommand IncrementCommand => _incrementCommand;
public ICommand DecrementCommand => _decrementCommand;

public  virtual  bool
CanDecrement()
{
    return ( ! this._isRunning && _model.CanDecrement() );
}

public  virtual  bool
CanIncrement()
{
    return ( ! this._isRunning );
}


public  void
executeDecrement()
{
    this._isRunning = true;
    executeDecrementTask(1);
    this._isRunning = false;
}

public  async  void
executeDecrementAsync()
{
    this._isRunning = true;

    Task<int>  task = Task.Run<int>(
        () => executeDecrementTask(1)
    );
    int  result = await task;

    this._isRunning = false;
}

public  void
executeIncrement()
{
    this._isRunning = true;
    executeIncrementTask(1);
    this._isRunning = false;
}

public  async  void
executeIncrementAsync()
{
    this._isRunning = true;

    Task<int>  task = Task.Run<int>(
        () => executeIncrementTask(1)
    );
    int  result = await task;

    this._isRunning = false;
}


protected  virtual  int
executeDecrementTask(int parameter)
{
    _model.Decrement();
    _storage.Save(_model.Value);
    return ( _model.Value );
}


protected  virtual  int
executeIncrementTask(int parameter)
{
    _model.Increment();
    _storage.Save(_model.Value);
    return( _model.Value );
}


private void OnCountChanged()
{
    OnPropertyChanged(nameof(Count));
}

public  event PropertyChangedEventHandler? PropertyChanged;

protected  void
OnPropertyChanged([CallerMemberName] string? propertyName = null)
{
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    if ( propertyName == nameof(Count) ) {
        _decrementCommand.RaiseCanExecuteChanged();
    }
}

}

}
