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
  public class MenuViewModel : ViewModelBase
  {
    public IRelayCommand<string> RequestPageCommand { get; }
    public MenuViewModel()
    {
      Title = "ViewModel-Menu";
      RequestPageCommand = new RelayCommand<string>(OnRequestPage);
    }

    private void OnRequestPage(string? page)
    {
      if (page == null)
        return;

      WeakReferenceMessenger.Default.Send(new RequestPageMessage(page));
    }
  }
}
