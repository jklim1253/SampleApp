using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Input;
using SampleModel.Entity;
using SampleModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.ViewModels
{
  public class ViewViewModel : ViewModelBase
  {
    private readonly ILogger<ViewViewModel> logger;
    private readonly SampleDataService dbService;

    private ViewInfo viewInfo = null!;

    public ViewInfo ViewInfo
    {
      get => viewInfo;
      set => SetProperty(ref viewInfo, value);
    }

    private ICollection<ViewInfo> viewInfos = null!;

    public ICollection<ViewInfo> ViewInfos
    {
      get => viewInfos;
      set => SetProperty(ref viewInfos, value);
    }

    public IRelayCommand SelectCommand { get; }
    public IRelayCommand SaveCommand { get; }
    public IRelayCommand DeleteCommand { get; }

    public ViewViewModel(ILogger<ViewViewModel> logger, SampleDataService dbService)
    {
      this.logger = logger;
      this.dbService = dbService;

      ViewInfo = new ViewInfo();

      SelectCommand = new RelayCommand(OnSelect);
      SaveCommand = new RelayCommand(OnSave);
      DeleteCommand = new RelayCommand(OnDelete);
    }

    private async void OnSelect()
    {
      ViewInfos = await dbService.SelectViewInfos();

      ViewInfo = new ViewInfo();
    }

    private async void OnSave()
    {
      if (ViewInfo.ViewId == null)
      {
        if (IsValidView())
        {
          await dbService.InsertViewInfo(ViewInfo);

          OnSelect();
        }
      }
      else
      {
        if (IsValidView())
        {
          await dbService.UpdateViewInfo((int)ViewInfo.ViewId, ViewInfo);
        }
      }
    }

    private async void OnDelete()
    {
      if (ViewInfo.ViewId != null)
      {
        await dbService.DeleteViewInfo((int)ViewInfo.ViewId);

        OnSelect();
      }
    }

    private bool IsValidView()
    {
      if (!string.IsNullOrWhiteSpace(ViewInfo.ViewName))
        return true;

      return false;
    }
  }
}
