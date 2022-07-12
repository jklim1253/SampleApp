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
  public class AccountViewModel : ViewModelBase
  {
    #region Fields

    private readonly ILogger<AccountViewModel> logger;
    private readonly SampleDataService dbService;

    #endregion

    #region Properties

    private UserInfoDTO user = null!;

    public UserInfoDTO User
    {
      get => user;
      set => SetProperty(ref user, value);
    }

    private ICollection<UserInfoDTO> users = null!;

    public ICollection<UserInfoDTO> Users
    {
      get => users;
      set => SetProperty(ref users, value);
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

    public AccountViewModel(ILogger<AccountViewModel> logger, SampleDataService dbService)
    {
      this.logger = logger;
      this.dbService = dbService;

      User = new UserInfoDTO();

      SelectCommand = new RelayCommand(OnSelect);
      SaveCommand = new RelayCommand(OnSave);
      DeleteCommand = new RelayCommand(OnDelete);
    }

    private async void OnSelect()
    {
      Users = await dbService.SelectUserInfoDTOs();

      Groups = await dbService.SelectGroupInfoDTOs();

      User = new UserInfoDTO();
    }

    private async void OnSave()
    {
      if (User.UserId == null)
      {
        if (IsValidUser())
        {
          await dbService.InsertUserInfoDTO(User);

          OnSelect();
        }
      }
      else
      {
        if (IsValidUser())
        {
          await dbService.UpdateUserInfoDTO((int)User.UserId, User);
        }
      }
    }

    private async void OnDelete()
    {
      if (User.UserId != null)
      {
        await dbService.DeleteUserInfoDTO((int)User.UserId);

        OnSelect();
      }
    }

    private bool IsValidUser()
    {
      if (User.UserName != null &&
          User.Password != null)
        return true;

      return false;
    }
  }
}
