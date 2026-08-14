
using System.Windows;
using WpfTestApp3.Models;
using WpfTestApp3.Services;
using WpfTestApp3.ViewModels;
using WpfTestApp3.Views;

namespace  WpfTestApp3  {

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e);

    var storage = new JsonCounterStorage();
    var model = new CounterModel();
    var mainWindow = new MainWindow();

    var counterViewModel = new CounterViewModel(
            mainWindow.Dispatcher, model, storage);
    var evenOddViewModel = new EvenOddViewModel(model);

    mainWindow.CounterView.SetViewModel(counterViewModel);
    mainWindow.EvenOddView.SetViewModel(evenOddViewModel);

    mainWindow.Show();
}

}

}
