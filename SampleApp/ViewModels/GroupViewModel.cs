using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Input;
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
    private readonly DatabaseService dbService;

    #endregion

    #region Properties

    private GroupInfo group = new GroupInfo();

    public GroupInfo Group
    {
      get => group;
      set => SetProperty(ref group, value);
    }

    private ObservableCollection<GroupInfo> groups = new ObservableCollection<GroupInfo>();

    public ObservableCollection<GroupInfo> Groups
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

    public GroupViewModel(ILogger<GroupViewModel> logger, DatabaseService dbService)
    {
      this.logger = logger;
      this.dbService = dbService;

      SelectCommand = new RelayCommand(OnSelect);
      SaveCommand = new RelayCommand(OnSave);
      DeleteCommand = new RelayCommand(OnDelete);
    }

    private async void OnSelect()
    {
      var groups = await dbService.SelectGroupInfos();
      Groups = new ObservableCollection<GroupInfo>(groups);

      Group = new GroupInfo();
    }

    private async void OnSave()
    {
      if (Group.GroupId == null)
      {
        await dbService.InsertGroupInfo(Group);
        OnSelect();
      }
      else
      {
        await dbService.UpdateGroupInfo((int)Group.GroupId, Group);
      }
    }

    private async void OnDelete()
    {
      if (Group.GroupId != null)
      {
        await dbService.DeleteGroupInfo((int)Group.GroupId);
      }
    }
  }
}
