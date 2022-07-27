using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Input;
using SampleModel.DTO;
using SampleModel.DTOServices;
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
    private readonly SampleDTOService dtoService;

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

    public GroupViewModel(ILogger<GroupViewModel> logger, SampleDTOService dtoService)
    {
      this.logger = logger;
      this.dtoService = dtoService;

      Group = new GroupInfoDTO();

      SelectCommand = new RelayCommand(OnSelect);
      SaveCommand = new RelayCommand(OnSave);
      DeleteCommand = new RelayCommand(OnDelete);
    }

    private async void OnSelect()
    {
      Groups = await dtoService.SelectGroupInfoDTOs();

      Group = new GroupInfoDTO();
    }

    private async void OnSave()
    {
      if (Group.GroupId == null)
      {
        if (IsValidGroup())
        {
          await dtoService.InsertGroupInfoDTO(Group);
          OnSelect();
        }
      }
      else
      {
        if (IsValidGroup())
        {
          await dtoService.UpdateGroupInfoDTO((int)Group.GroupId, Group);
        }
      }
    }

    private async void OnDelete()
    {
      if (Group.GroupId != null)
      {
        await dtoService.DeleteGroupInfoDTO((int)Group.GroupId);
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
