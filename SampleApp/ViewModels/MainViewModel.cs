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
    private string currentView = "StartView.xaml";

    public string CurrentView
    {
      get => currentView;
      set => SetProperty(ref currentView, value);
    }

    public MainViewModel()
    {
      Title = "ViewModel-Main";

      WeakReferenceMessenger.Default.Register<MainViewModel, RequestPageMessage>(this, OnRequestPage);
    }

    private void OnRequestPage(MainViewModel recipient, RequestPageMessage message)
    {
      recipient.CurrentView = message.Value;
    }
  }
}
