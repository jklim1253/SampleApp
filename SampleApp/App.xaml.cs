using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using SampleApp.Extensions;
using SampleApp.Messages;
using SampleApp.ViewModels;
using SampleApp.Views;
using SampleModel;
using SampleModel.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SampleApp
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private readonly IHost host = null!;

    public App()
    {
      host = Host.CreateDefaultBuilder()
                 .ConfigureSampleModel()
                 .ConfigureSampleApp()
                 .Build();

      Ioc.Default.ConfigureServices(host.Services);

      // runtime migration. make local database file
      //using (var context = Ioc.Default.GetRequiredService<SampleContext>())
      //{
      //  context.Database.Migrate();
      //}

      host.RunAsync();
    }
    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);

      host.StartAsync();

      MainWindow = Ioc.Default.GetRequiredService<MainWindow>();
      MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
      host.StopAsync();

      base.OnExit(e);
    }
  }
}
