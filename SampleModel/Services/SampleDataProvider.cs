using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.Services
{
  public class SampleDataProvider
  {
    public SampleContext GetSampleContext()
    {
      return Ioc.Default.GetRequiredService<SampleContext>();
    }
  }
}
