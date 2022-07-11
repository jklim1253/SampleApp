using Microsoft.EntityFrameworkCore;
using SampleModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel.Services
{
  public partial class DatabaseService
  {
    public async Task<ICollection<GroupInfoDTO>>
      SelectGroupInfoDTOs()
    {
      using (var context = provider.GetSampleContext())
      {
        var groups = await context.GroupInfos
          .Select(e =>
          new GroupInfoDTO()
          {
            GroupId = e.GroupId,
            GroupName = e.GroupName,
          })
          .ToListAsync();

        return groups;
      }
    }
  }
}
