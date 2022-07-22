using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Input;
using SampleApp.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.ViewModels
{
  public class HomeViewModel : ViewModelBase
  {
    #region Fields

    private readonly ILogger<HomeViewModel> logger;

    #endregion

    #region Properties

    private SampleBoxInfo selectedItem = null!;

    public SampleBoxInfo SelectedItem
    {
      get => selectedItem;
      set => SetProperty(ref selectedItem, value);
    }

    private ObservableCollection<SampleBoxInfo> liveViews = null!;

    public ObservableCollection<SampleBoxInfo> LiveViews
    {
      get => liveViews;
      set => SetProperty(ref liveViews, value);
    }

    #endregion

    #region Commands

    public IRelayCommand AddCommand { get; }

    #endregion

    public HomeViewModel(ILogger<HomeViewModel> logger)
    {
      // fields
      this.logger = logger;

      // properties
      Title = "ViewModel-Home";
      SelectedItem = new SampleBoxInfo();
      LiveViews = new ObservableCollection<SampleBoxInfo>()
      {
        new SampleBoxInfo()
        {
          Id = 1,
          URL = "http://123"
        },
        new SampleBoxInfo()
        {
          Id = 2,
          URL = "http://123"
        },
        new SampleBoxInfo()
        {
          Id = 3,
          URL = "http://123"
        }
      };

      // commands
      AddCommand = new RelayCommand(OnAdd);

    }

    private void OnAdd()
    {
      if (SelectedItem == null) return;

      if (string.IsNullOrWhiteSpace(SelectedItem.URL)) return;

      SelectedItem.Id = LiveViews.Count;

      LiveViews.Add(SelectedItem);

      SelectedItem = new SampleBoxInfo();
    }
  }
}
