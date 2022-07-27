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
    public IRelayCommand RemoveCommand { get; }

    #endregion

    public HomeViewModel(ILogger<HomeViewModel> logger)
    {
      // fields
      this.logger = logger;

      // properties
      Title = "ViewModel-Home";
      SelectedItem = new SampleBoxInfo();
      LiveViews = new ObservableCollection<SampleBoxInfo>();

      // sample data.
      for (int i = 0; i < 10; ++i)
      {
        var info = new SampleBoxInfo()
        {
          Id = i,
          URL = $"http://server/{i}/123/{i * 10}"
        };
        LiveViews.Add(info);
      }

      // commands
      AddCommand = new RelayCommand(OnAdd);
      RemoveCommand = new RelayCommand(OnRemove);
    }

    private void OnRemove()
    {
      // TODO: implement here.
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
