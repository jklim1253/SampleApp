using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.Services
{
  public class SampleContextFactory : IDesignTimeDbContextFactory<SampleContext>
  {
    public SampleContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder();
      optionsBuilder.UseSqlite("Data Source=Sample.db");

      return new SampleContext(optionsBuilder.Options);
    }
  }
}
