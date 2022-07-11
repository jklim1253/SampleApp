using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.Extensions
{
  public static class SampleModelExtension
  {
    public static IHostBuilder ConfigureSampleModel(this IHostBuilder builder)
    {
      return builder.ConfigureServices((context, services) =>
      {
        services.AddSingleton<DatabaseProvider>();
        services.AddSingleton<DatabaseService>();
      });
    }
  }
}
