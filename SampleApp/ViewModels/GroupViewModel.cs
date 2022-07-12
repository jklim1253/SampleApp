using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Input;
using SampleModel.DTO;
using SampleModel.Entity;
using SampleModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.ViewModels
{
  public class GroupViewModel : ViewModelBase
  {
    #region Fields

    private readonly ILogger<GroupViewModel> logger;
    private readonly SampleDataService dbService;

    #endregion

    #region Properties

    private GroupInfoDTO group = null!;

    public GroupInfoDTO Group
    {
      get => group;
      set => SetProperty(ref group, value);
    }

    private ICollection<GroupInfoDTO> groups = null!;

    public ICollection<GroupInfoDTO> Groups
    {
      get => groups;
      set => SetProperty(ref groups, value);
    }

    #endregion

    #region Commands

    public IRelayCommand SelectCommand { get; }
    public IRelayCommand SaveCommand { get; }
    public IRelayCommand DeleteCommand { get; }

    #endregion

    public GroupViewModel(ILogger<GroupViewModel> logger, SampleDataService dbService)
    {
      this.logger = logger;
      this.dbService = dbService;

      Group = new GroupInfoDTO();

      SelectCommand = new RelayCommand(OnSelect);
      SaveCommand = new RelayCommand(OnSave);
      DeleteCommand = new RelayCommand(OnDelete);
    }

    private async void OnSelect()
    {
      Groups = await dbService.SelectGroupInfoDTOs();

      Group = new GroupInfoDTO();
    }

    private async void OnSave()
    {
      if (Group.GroupId == null)
      {
        if (IsValidGroup())
        {
          await dbService.InsertGroupInfoDTO(Group);
          OnSelect();
        }
      }
      else
      {
        if (IsValidGroup())
        {
          await dbService.UpdateGroupInfoDTO((int)Group.GroupId, Group);
        }
      }
    }

    private async void OnDelete()
    {
      if (Group.GroupId != null)
      {
        await dbService.DeleteGroupInfoDTO((int)Group.GroupId);
        OnSelect();
      }
    }

    private bool IsValidGroup()
    {
      if (!string.IsNullOrWhiteSpace(Group.GroupName))
        return true;

      return false;
    }
  }
}
