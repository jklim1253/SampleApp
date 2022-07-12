using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using SampleModel;
using SampleModel.Entity;
using SampleModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.ViewModels
{
  public class SettingViewModel : ViewModelBase
  {
    private readonly ILogger<SettingViewModel> logger;
    private readonly SampleDataService dbService;

    public IRelayCommand MigrationCommand { get; set; }
    public IRelayCommand InsertSampleCommand { get; set; }

    public SettingViewModel(ILogger<SettingViewModel> logger, SampleDataService dbService)
    {
      Title = "ViewModel-Setting";

      this.logger = logger;
      this.dbService = dbService;

      MigrationCommand = new RelayCommand(OnMigration);
      InsertSampleCommand = new RelayCommand(OnInsertSample);
    }

    private void OnMigration()
    {
      using (var context = Ioc.Default.GetRequiredService<SampleContext>())
      {
        context.Database.Migrate();
      }
    }
    private async void OnInsertSample()
    {
      // view
      await dbService.InsertViewInfo(new ViewInfo() { ViewName = "HomeView" });
      await dbService.InsertViewInfo(new ViewInfo() { ViewName = "AccountView" });
      await dbService.InsertViewInfo(new ViewInfo() { ViewName = "GroupView" });
      await dbService.InsertViewInfo(new ViewInfo() { ViewName = "ViewView" });
      await dbService.InsertViewInfo(new ViewInfo() { ViewName = "SettingView" });

      // group
      await dbService.InsertGroupInfo(new GroupInfo() { GroupName = "Administrators" });
      await dbService.InsertGroupInfo(new GroupInfo() { GroupName = "Managers" });
      await dbService.InsertGroupInfo(new GroupInfo() { GroupName = "Operators" });
      await dbService.InsertGroupInfo(new GroupInfo() { GroupName = "Guests" });

      // account
      await dbService.InsertUserInfo(new UserInfo() { UserName = "admin", Password = "admin$123", GroupId = 1 });
      await dbService.InsertUserInfo(new UserInfo() { UserName = "manager-1", Password = "manager$123" });
      await dbService.InsertUserInfo(new UserInfo() { UserName = "operator-1", Password = "op$123" });
      await dbService.InsertUserInfo(new UserInfo() { UserName = "operator-2", Password = "op$123" });
      await dbService.InsertUserInfo(new UserInfo() { UserName = "operator-3", Password = "op$123" });
      await dbService.InsertUserInfo(new UserInfo() { UserName = "guest", Password = "guest$123" });
    }
  }
}
