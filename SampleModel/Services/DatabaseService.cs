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
  public partial class DatabaseService
  {
    private readonly ILogger<DatabaseService> logger;
    private readonly DatabaseProvider provider;

    public DatabaseService(ILogger<DatabaseService> logger, DatabaseProvider provider)
    {
      this.logger = logger;
      this.provider = provider;
    }

  }
}
