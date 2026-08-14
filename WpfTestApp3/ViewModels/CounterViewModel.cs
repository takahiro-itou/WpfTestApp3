
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Threading;

using WpfTestApp3.Commands;
using WpfTestApp3.Models;
using WpfTestApp3.Services;

namespace  WpfTestApp3.ViewModels  {

public class CounterViewModel : INotifyPropertyChanged
{

private  readonly   CounterModel    _model;
private  readonly   JsonCounterStorage _storage;
private  readonly   SimpleCommand   _incrementCommand;
private  readonly   SimpleCommand   _decrementCommand;
private  readonly   SimpleCommand   _asyncIncrementCommand;
private  readonly   SimpleCommand   _asyncDecrementCommand;

private  readonly   Dispatcher      _dispatcher;

private  bool       _isRunning;


public
CounterViewModel(
       Dispatcher       dispatcher,
       CounterModel     model,
       JsonCounterStorage storage)
{
    _dispatcher = dispatcher;
    _model = model;
    _storage = storage;

    var initialValue = _storage.Load();
    _model.SetValue(initialValue);
    _model.ValueChanged += OnCountChanged;

    _incrementCommand = new SimpleCommand(
            _ => executeIncrement(), _ => canIncrement() );
    _decrementCommand = new SimpleCommand(
            _ => executeDecrement(), _ => canDecrement() );
    _asyncIncrementCommand = new SimpleCommand(
            _ => executeIncrementAsync(), _ => canIncrement() );
    _asyncDecrementCommand = new SimpleCommand(
            _ => executeDecrementAsync(), _ => canDecrement() );


    this._isRunning = false;
}

public int Count => _model.Value;

public  ICommand  IncrementCommand => _incrementCommand;
public  ICommand  DecrementCommand => _decrementCommand;
public  ICommand  AsyncIncrementCommand => _asyncIncrementCommand;
public  ICommand  AsyncDecrementCommand => _asyncDecrementCommand;


public  virtual  bool
canDecrement()
{
    return ( ! this._isRunning && _model.CanDecrement() );
}

public  virtual  bool
canIncrement()
{
    return ( ! this._isRunning );
}


public  void
executeDecrement()
{
    this._isRunning = true;
    executeDecrementTask(1);
    this._isRunning = false;
    raiseCanExecuteChanged();
}

public  async  void
executeDecrementAsync()
{
    this._isRunning = true;

    await  System.Threading.Tasks.Task.Delay(1000);
    Task<int>  task = Task.Run<int>(
        () => executeDecrementTask(1)
    );
    int  result = await task;

    await  System.Threading.Tasks.Task.Delay(1000);
    System.Windows.MessageBox.Show("DecrementAsync");

    this._isRunning = false;
    raiseCanExecuteChanged();
}

public  void
executeIncrement()
{
    this._isRunning = true;
    executeIncrementTask(1);
    this._isRunning = false;
    raiseCanExecuteChanged();
}

public  async  void
executeIncrementAsync()
{
    this._isRunning = true;

    await  System.Threading.Tasks.Task.Delay(1000);
    Task<int>  task = Task.Run<int>(
        () => executeIncrementTask(1)
    );
    int  result = await task;

    await  System.Threading.Tasks.Task.Delay(1000);
    System.Windows.MessageBox.Show("IncrementAsync");

    this._isRunning = false;
    raiseCanExecuteChanged();
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


protected  virtual  int
raiseCanExecuteChanged()
{
    this._dispatcher.Invoke(
        () => {
            _decrementCommand.RaiseCanExecuteChanged();
            _asyncDecrementCommand.RaiseCanExecuteChanged();
            _incrementCommand.RaiseCanExecuteChanged();
            _asyncIncrementCommand.RaiseCanExecuteChanged();
        }
    );

    return ( 0 );
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
        raiseCanExecuteChanged();
    }
}

}

}
