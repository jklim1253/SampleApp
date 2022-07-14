using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleApp.ViewModels;
using SampleApp.Views;
using SampleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Extensions
{
  public static class SampleAppExtension
  {
    public static IHostBuilder ConfigureSampleApp(this IHostBuilder builder)
    {
      return builder.ConfigureServices((context, services) =>
      {
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MenuViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<AccountViewModel>();
        services.AddSingleton<GroupViewModel>();
        services.AddSingleton<ViewViewModel>();
        services.AddSingleton<SettingViewModel>();
        services.AddSingleton<ArchitectureViewModel>();

        services.AddTransient<MainWindow>();
        services.AddTransient<MenuView>();
        services.AddTransient<HomeView>();
        services.AddTransient<AccountView>();
        services.AddTransient<GroupView>();
        services.AddTransient<ViewView>();
        services.AddTransient<SettingView>();
        services.AddTransient<ArchitectureView>();

        services.AddDbContext<SampleContext>(options =>
        {
          options.UseSqlite("Data Source=Sample.db");
        }, ServiceLifetime.Transient);
      });
    }
  }
}
