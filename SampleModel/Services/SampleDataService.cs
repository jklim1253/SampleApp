using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.Services
{
  public partial class SampleDataService
  {
    private readonly ILogger<SampleDataService> logger;
    private readonly SampleDataProvider provider;

    public SampleDataService(ILogger<SampleDataService> logger, SampleDataProvider provider)
    {
      this.logger = logger;
      this.provider = provider;
    }

  }
}
