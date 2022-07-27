using Microsoft.Extensions.Logging;
using SampleModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.DTOServices
{
  public partial class SampleDTOService
  {
    private readonly ILogger<SampleDTOService> logger;
    private readonly SampleDataService dbAccess;

    public SampleDTOService(ILogger<SampleDTOService> logger, SampleDataService dbAccess)
    {
      this.logger = logger;
      this.dbAccess = dbAccess;
    }
  }
}
