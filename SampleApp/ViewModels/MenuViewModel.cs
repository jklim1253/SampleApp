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
    #region Properties

    private string currentMenu = "HomeView";

    public string CurrentMenu
    {
      get => currentMenu;
      set => SetProperty(ref currentMenu, value);
    }

    #endregion

    #region Commands

    public IRelayCommand<string> RequestPageCommand { get; }

    #endregion

    public MenuViewModel()
    {
      Title = "ViewModel-Menu";
      RequestPageCommand = new RelayCommand<string>(OnRequestPage);
    }

    private void OnRequestPage(string? page)
    {
      if (page == null)
        return;

      CurrentMenu = page.Split('.')[0];
      WeakReferenceMessenger.Default.Send(new NavigateMessage(page));
    }
  }
}
