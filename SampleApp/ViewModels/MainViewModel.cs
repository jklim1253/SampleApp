using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using SampleApp.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    private string currentView = "HomeView.xaml";

    public string CurrentView
    {
      get => currentView;
      set => SetProperty(ref currentView, value);
    }

    public IRelayCommand MinimizeAppCommand { get; }
    public IRelayCommand MaximizeAppCommand { get; }
    public IRelayCommand CloseAppCommand { get; }

    public MainViewModel()
    {
      Title = "ViewModel-Main";

      MinimizeAppCommand = new RelayCommand(OnMinimizeApp);
      MaximizeAppCommand = new RelayCommand(OnMaximizeApp);
      CloseAppCommand = new RelayCommand(OnCloseApp);

      WeakReferenceMessenger.Default.Register<MainViewModel, NavigateMessage>(this, OnRequestPage);
    }

    private void OnMinimizeApp()
    {
      App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
    }

    private void OnMaximizeApp()
    {
      if (App.Current.MainWindow.WindowState == System.Windows.WindowState.Maximized)
        App.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
      else
        App.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;
    }

    private void OnCloseApp()
    {
      App.Current.MainWindow.Close();
    }

    private void OnRequestPage(MainViewModel recipient, NavigateMessage message)
    {
      recipient.CurrentView = message.Value;
    }
  }
}
